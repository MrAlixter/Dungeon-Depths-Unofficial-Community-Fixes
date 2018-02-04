Public Class Q
    Dim q() As Object
    Dim size As Integer 'number of items in the array
    Dim front As Integer  'first element
    Dim rear As Integer   'last element
    Sub New()
        ReDim q(0)
    End Sub
    Sub New(ByVal initLength As Integer)
        If (initLength < 0) Then
            ReDim q(0)
        Else
            ReDim q(initLength - 1)
        End If
    End Sub

    'selectors
    Sub add(ByVal o As Object)

        If q.Length = 1 Then  'array non-existant, create it and insert first object 
            size = 1
            q(0) = o
        ElseIf size = 0 Then   'adding to empty queue
            rear = 0
            front = 0
            size = 1
            q(0) = o
        Else  'general case: array exists and non-empty
            If size = q.Length Then  'allocate bigger array if needed
                Dim newq(2 * q.Length + 1) As Object
                If front <= rear Then 'queue has not wrapped, 
                    'so make simple copy to new space
                    Array.Copy(q, front, newq, 0, size)
                ElseIf front > rear Then  'queue has wrapped, so copy in two chunks
                    Array.Copy(q, front, newq, 0, q.Length - front)
                    Array.Copy(q, 0, newq, q.Length - front, rear + 1)
                    front = 0
                    rear = size - 1
                End If
                q = newq
            End If  'allocate bigger array if needed
                rear = (rear + 1) Mod q.Length
                q(rear) = o
                size += 1
        End If  'general case: array exists and non-empty
    End Sub
    Function remove() As Object
        If size = 0 Then
            Return Nothing
        End If
        Dim answer As Object = q(front)
        front = (front + 1) Mod q.Length
        size -= 1
        Return answer
    End Function
    Function length() As Integer
        Return size
    End Function
End Class
