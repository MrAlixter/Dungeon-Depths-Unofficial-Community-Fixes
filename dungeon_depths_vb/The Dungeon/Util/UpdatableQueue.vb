Public Class UpdatableQueue
    Private indexes As Dictionary(Of Integer, Integer)
    Private updatables As List(Of Updatable)

    Private count As Integer
    Sub New()
        indexes = New Dictionary(Of Integer, Integer)
        updatables = New List(Of Updatable)

        count = 0
    End Sub

    Public Sub add(ByRef u As Updatable, ByVal t As Integer)
        If updatables.Contains(u) Then Exit Sub

        indexes.Add(count, t)
        updatables.Add(u)

        count += 1
    End Sub

    Public Sub ping()
        If isEmpty() Then Exit Sub

        Dim startTime As Double = DDDateTime.getTimeNow()
        Dim sortedKeys = sortMaxToMin(indexes)

        For i = 0 To sortedKeys.Count - 1
            If updatables.Count < 1 Then Exit For
            updatables(sortedKeys(i)).update()
        Next
        Dim endTime As Double = DDDateTime.getTimeNow()
        Console.WriteLine(" - UPDATE TIME (" & updatables.Count & "): " + (endTime - startTime).ToString())
        clear()
    End Sub

    Public Sub clear()
        indexes.Clear()
        updatables.Clear()

        count = 0
    End Sub

    Public Function isEmpty() As Boolean
        Return indexes Is Nothing Or indexes.Count < 1
    End Function


    Private Function append(ByVal a As Integer, ByVal b As List(Of Integer)) As List(Of Integer)
        b.Insert(0, a)

        Return b
    End Function
    Private Function sortMaxToMin(ByVal l As Dictionary(Of Integer, Integer)) As List(Of Integer)

        If l.Count < 2 Then
            Return l.Keys.ToList
        Else
            Dim max As Integer = -999999999
            Dim indMax As Integer = 0

            For i = 0 To l.Count - 1
                If l(l.Keys(i)) > max Then
                    max = l(l.Keys(i))
                    indMax = l.Keys(i)
                End If
            Next

            l.Remove(indMax)

            Return append(indMax, sortMaxToMin(l))
        End If
    End Function
End Class
