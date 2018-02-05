'priority queue
Public Class PQ
    Implements PQInterface
    Dim seg As Segment

    Sub New()
        seg = New Segment(0)
    End Sub
    Public Sub add(o As Updatable, t As Integer) Implements PQInterface.add
        t += getCurrentTime()
        If (t < seg.getTime()) Then
            Game.lstLog.Items.Add("Silly user, time travel is forbidden!")
            Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        ElseIf t = seg.getTime() Then
            seg.getEvents().add(o)
        Else   'search list for correct insertion point, then insert
            Dim trailer As Segment = seg
            Dim ptr As Segment = seg.getNext()
            Do While (Not (ptr Is Nothing) AndAlso t > ptr.getTime())
                ptr = ptr.getNext()
                trailer = trailer.getNext()
            Loop
            If (Not (ptr Is Nothing) AndAlso t = ptr.getTime()) Then
                ptr.getEvents().add(o)
            Else
                Dim temp As Segment = New Segment(t)
                temp.getEvents().add(o)
                temp.setNext(ptr)
                trailer.setNext(temp)
            End If
        End If
    End Sub
    Function remove() As Updatable Implements PQInterface.remove
        If Me.isEmpty() Then
            Game.lstLog.Items.Add("Error: removing from empty queue")
            Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
            Return Nothing
        ElseIf (seg.getEvents().length() = 0) Then
            seg = seg.getNext()
            Return seg.getEvents().remove()
        Else
            Return seg.getEvents().remove()
        End If
    End Function
    Public Function getCurrentTime() As Integer Implements PQInterface.getCurrentTime
        Return seg.getTime()
    End Function
    Public Function isEmpty() As Boolean Implements PQInterface.isEmpty
        Return seg.getEvents().length() = 0 And seg.getNext() Is Nothing
    End Function
End Class
