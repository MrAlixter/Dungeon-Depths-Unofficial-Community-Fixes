Public Class Segment
    Dim time As Double
    Dim queue As Q
    Dim nxt As Segment

    Sub New(ByVal t As Double)
        time = t
        queue = New Q()
        nxt = Nothing
    End Sub
    Function getTime() As Double
        Return time
    End Function
    Function getEvents() As Q
        Return queue
    End Function
    Function getNext() As Segment
        Return nxt
    End Function
    Sub setNext(ByVal nextSegment As Segment)
        nxt = nextSegment
    End Sub
End Class
