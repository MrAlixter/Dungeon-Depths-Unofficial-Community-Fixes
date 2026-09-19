Imports System
Imports System.Collections.Generic
Imports System.Linq

Public Class UpdatableQueue
    Private ReadOnly indexes As New Dictionary(Of Integer, Integer)
    Private ReadOnly updatables As New List(Of Updatable)

    ' A fresh token invalidates a turn even if clear() is followed by add().
    Private generation As Object = New Object()
    Private processing As Boolean

    Public Sub add(ByRef u As Updatable, ByVal t As Integer)
        If u Is Nothing Then Throw New ArgumentNullException("u")
        If updatables.Contains(u) Then Exit Sub

        indexes.Add(updatables.Count, t)
        updatables.Add(u)
    End Sub

    Public Sub replace(ByRef u As Updatable, ByRef new_u As Updatable)
        If new_u Is Nothing Then Throw New ArgumentNullException("new_u")
        Dim pos As Integer = updatables.IndexOf(u)
        If pos < 0 Then Exit Sub

        ' Keep the old priority and turn position, but use the new object.
        updatables(pos) = new_u
    End Sub

    Public Sub ping()
        ' A callback must not recursively execute this same turn.
        If processing OrElse isEmpty() Then Exit Sub

        Dim startGeneration As Object = generation
        Dim sortedKeys = indexes.OrderByDescending(Function(entry) entry.Value).
                                 ThenBy(Function(entry) entry.Key).
                                 Select(Function(entry) entry.Key).ToList()
        processing = True
        Try
            For Each queueIndex As Integer In sortedKeys
                If Not Object.ReferenceEquals(generation, startGeneration) Then Exit For
                updatables(queueIndex).update()
            Next
        Finally
            ' Do not erase a new queue created by a callback during this turn.
            ' Exceptions still propagate, but the old turn cannot be replayed.
            If Object.ReferenceEquals(generation, startGeneration) Then clear()
            processing = False
        End Try
    End Sub

    Public Sub clear()
        generation = New Object()
        indexes.Clear()
        updatables.Clear()
    End Sub

    Public Function isEmpty() As Boolean
        Return updatables.Count = 0
    End Function
End Class
