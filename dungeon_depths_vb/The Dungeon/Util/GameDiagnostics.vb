Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.IO
Imports System.Reflection
Imports System.Text

' Local diagnostics only. Never call gameplay getters while handling a failure:
' calculating equipment bonuses can itself be the cause of the exception.
Public NotInheritable Class GameDiagnostics
    Private Shared ReadOnly Gate As New Object()
    Private Shared ReadOnly Recent As New Queue(Of String)()
    Private Const RecordedKey As String = "DungeonDepths.GameDiagnostics.Recorded"
    Private Const MaxLogBytes As Long = 2097152

    Private Sub New()
    End Sub

    Private Shared Function Clip(value As String, limit As Integer) As String
        If value Is Nothing Then Return ""
        If value.Length <= limit Then Return value
        Return value.Substring(0, limit) & " [truncated]"
    End Function

    Public Shared Sub Remember(action As String, context As String)
        Try
            SyncLock Gate
                Recent.Enqueue(DateTime.UtcNow.ToString("o", CultureInfo.InvariantCulture) &
                               " " & Clip(action, 256) & " | " & Clip(context, 4096))
                While Recent.Count > 24
                    Recent.Dequeue()
                End While
            End SyncLock
        Catch
            ' Diagnostic failure must not interrupt an otherwise valid action.
        End Try
    End Sub

    Private Shared Function FieldValue(value As Object, fieldName As String) As Object
        If value Is Nothing Then Return Nothing
        Dim t As Type = value.GetType()
        While t IsNot Nothing
            Dim f = t.GetField(fieldName, BindingFlags.Instance Or BindingFlags.Public Or
                              BindingFlags.NonPublic Or BindingFlags.DeclaredOnly)
            If f IsNot Nothing Then Return f.GetValue(value)
            t = t.BaseType
        End While
        Return Nothing
    End Function

    Public Shared Function Snapshot(value As Object) As String
        Try
            If value Is Nothing Then Return "<none>"
            Dim result As New StringBuilder(value.GetType().FullName)
            For Each key As String In New String() {"name", "id", "count", "floorNumber", "level",
                "attack", "defense", "speed", "will", "health", "maxHealth", "mana", "maxMana",
                "stamina", "aBuff", "dBuff", "sBuff", "wBuff", "hBuff", "mBuff", "a", "d", "s", "w"}
                Dim raw = FieldValue(value, key)
                If raw Is Nothing Then Continue For
                If TypeOf raw Is String OrElse raw.GetType().IsPrimitive OrElse TypeOf raw Is Decimal Then
                    result.Append(" ").Append(key).Append("=").Append(Clip(Convert.ToString(raw, CultureInfo.InvariantCulture), 128))
                End If
            Next
            ' A fixed depth avoids traversing inventories, portraits, or UI objects.
            For Each key As String In New String() {"pClass", "pForm"}
                Dim raw = FieldValue(value, key)
                If raw Is Nothing Then Continue For
                result.Append(" ").Append(key).Append("={").Append(raw.GetType().Name)
                For Each stat As String In New String() {"a", "d", "s", "w"}
                    Dim multiplier = FieldValue(raw, stat)
                    If TypeOf multiplier Is Double Then
                        result.Append(" ").Append(stat).Append("=").Append(Convert.ToString(multiplier, CultureInfo.InvariantCulture))
                    End If
                Next
                result.Append("}")
            Next
            Return Clip(result.ToString(), 4096)
        Catch
            Return "<snapshot unavailable>"
        End Try
    End Function

    Public Shared Function Context(player As Object, floor As Object, target As Object) As String
        Return "player: " & Snapshot(player) & Environment.NewLine &
               "floor: " & Snapshot(floor) & Environment.NewLine &
               "target: " & Snapshot(target)
    End Function

    ' Optional folder supports isolated diagnostic checks without touching real logs.
    ' Callers always rethrow their original exception after this best-effort write.
    Public Shared Function Record(fault As Exception, stage As String, context As String,
                                  Optional logFolder As String = Nothing) As Boolean
        Try
            If fault Is Nothing Then Return False
            SyncLock Gate
                If fault.Data.Contains(RecordedKey) Then Return True
                If String.IsNullOrEmpty(logFolder) Then
                    logFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                                             "DungeonDepths", "Logs")
                End If
                Directory.CreateDirectory(logFolder)
                Dim logPath = Path.Combine(logFolder, "errors.log")
                If File.Exists(logPath) AndAlso New FileInfo(logPath).Length >= MaxLogBytes Then
                    Dim previous = logPath & ".previous"
                    If File.Exists(previous) Then File.Delete(previous)
                    File.Move(logPath, previous)
                End If
                Dim report As New StringBuilder()
                report.AppendLine("--- " & DateTime.UtcNow.ToString("o", CultureInfo.InvariantCulture))
                report.AppendLine("Assembly: " & GetType(GameDiagnostics).Assembly.FullName)
                report.AppendLine("Build MVID: " & GetType(GameDiagnostics).Module.ModuleVersionId.ToString())
                report.AppendLine("Stage: " & Clip(stage, 256))
                report.AppendLine(Clip(context, 16384))
                report.AppendLine("Recent actions (history, not proof of cause):")
                For Each entry As String In Recent
                    report.AppendLine(entry)
                Next
                report.AppendLine("Exception:")
                report.AppendLine(Clip(fault.ToString(), 32768))
                File.AppendAllText(logPath, report.ToString(), New UTF8Encoding(False))
                fault.Data(RecordedKey) = True
                Return True
            End SyncLock
        Catch
            ' Disk, permissions or diagnostics failures must not replace the original fault.
            Return False
        End Try
    End Function
End Class
