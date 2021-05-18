Public Class QuestList
    Dim internalList As Dictionary(Of String, Quest)
    Sub New()
        reset()
    End Sub

    Sub add(ByRef q As Quest)
        If q Is Nothing Then Exit Sub
        If q.getName Is Nothing Then MsgBox("Error 009: " & q.GetType.ToString & " quest missing name field!")
        If Not q.getName Is Nothing AndAlso Not internalList.ContainsKey(q.getName) Then internalList.Add(q.getName(), q)
    End Sub

    Sub ping(Optional ByRef pUpdateFlag = False)
        For i = internalList.Count - 1 To 0 Step -1
            Dim q = internalList.Values(i)
            If q Is Nothing Then Continue For
            If q.getComplete Or q.getCurrObj Is Nothing Then
                remove(internalList.Keys(i))
            Else
                Try
                    If q.getCurrObj.isComplete Then q.completeCurrOjb()
                Catch ex As Exception
                    MsgBox("Error 010: " & q.GetType.ToString & " quest has thrown an unhandled exception!")
                End Try
            End If
        Next
    End Sub

    Sub remove(ByVal s As String)
        If internalList.ContainsKey(s) Then
            internalList.Remove(s)
        End If
    End Sub

    Sub reset()
        internalList = New Dictionary(Of String, Quest)
    End Sub

    Function getAt(ByVal s As String) As Quest
        If Not internalList.Keys.Contains(s) Then Return Nothing

        Return internalList(s)
    End Function

    Function count() As Integer
        Return internalList.Count
    End Function

    Function save() As String
        Dim output = ""
        output += internalList.Count - 1 & "Ͱ"

        For Each q In internalList
            output += q.Value.getQInd & "Ͱ"
        Next

        Return output
    End Function
End Class
