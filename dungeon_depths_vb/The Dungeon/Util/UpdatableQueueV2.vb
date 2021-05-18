Public Class UpdatableQueueV2
    Private priorities As List(Of Integer)
    Private updatables As List(Of Updatable)

    Private count As Integer
    Sub New()
        priorities = New List(Of Integer)
        updatables = New List(Of Updatable)

        count = 0
    End Sub

    Public Sub add(ByRef u As Updatable, ByVal t As Integer)
        priorities.Add(t)
        updatables.Add(u)

        count += 1
    End Sub


    Private Sub ping()
        If isEmpty() Then Exit Sub

        Dim maxID As Integer = 0

        For i = 1 To priorities.Count - 1
            If (priorities(maxID) < priorities(i)) Then maxID = i
        Next

        updatables(maxID).update()

        priorities.RemoveAt(maxID)
        updatables.RemoveAt(maxID)
    End Sub

    Public Sub update()
        While Not isEmpty()
            ping()
        End While
    End Sub

    Public Sub clear()
        priorities.Clear()
        updatables.Clear()

        count = 0
    End Sub

    Public Function isEmpty() As Boolean
        Return priorities Is Nothing Or priorities.Count < 1
    End Function
End Class
