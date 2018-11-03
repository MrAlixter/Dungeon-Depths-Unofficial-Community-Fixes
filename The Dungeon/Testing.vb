Imports System.IO
Public Class Testing
    Shared Sub runTests()
        Dim out As StreamWriter
        out = IO.File.CreateText("TextLog.txt")
        out.WriteLine("TEST LOG FOR D_D v" & Application.ProductVersion.ToString & "- RAN ON " & Date.Today.Date.ToString.Split("12:00")(0))

        runUnitTests(out)

        out.Flush()
        out.Dispose()
    End Sub
    Shared Sub runUnitTests(ByRef out As StreamWriter)
        Dim testQueue As List(Of Func(Of Tuple(Of Boolean, String))) = New List(Of Func(Of Tuple(Of Boolean, String)))
        'testQueue.Add(AddressOf moveTests)

        Dim successes = 0
        Dim failures = 0
        out.WriteLine(vbCrLf & "-||UNIT TESTS:")
        For i = 0 To testQueue.Count - 1
            Dim result As Tuple(Of Boolean, String) = testQueue(i).Invoke
            If Not result.Item1 Then
                out.WriteLine(vbCrLf & "Test Failed!:")
                out.WriteLine(result.Item2 & vbCrLf)
                failures += 1
            Else
                out.WriteLine(result.Item2)
                successes += 1
            End If
        Next
        out.WriteLine(successes & "/" & (successes + failures) & " tests passed." & vbCrLf)

    End Sub

    '|PLAYER METHOD UNIT TESTS|
    'Shared Function moveTests() As Tuple(Of Boolean, String)
    '    Dim results = ""
    '    Dim testSuccess = False
    '    Dim p1 = New Player()
    '    p1.pos = New Point(0, 0)
    '    p1.moveDown()
    '    p1.moveLeft()
    '    p1.moveUp()
    '    p1.moveRight()
    '    results = "P1.pos >" & p1.pos.ToString & ", Should be: (0, 0)"
    '    If p1.pos.Equals(New Point(0, 0)) Then testSuccess = True
    '    Return New Tuple(Of Boolean, String)(testSuccess, results)
    'End Function
End Class
