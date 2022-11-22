Public Class DDDateTime
    Shared Function isWinter()
        Return DateTime.Now.Month = 12 Or DateTime.Now.Month = 1 Or DateTime.Now.Month = 2
    End Function
    Shared Function isSpring()
        Return DateTime.Now.Month = 3 Or DateTime.Now.Month = 4 Or DateTime.Now.Month = 5
    End Function
    Shared Function isSummer()
        Return DateTime.Now.Month = 6 Or DateTime.Now.Month = 7 Or DateTime.Now.Month = 8
    End Function
    Shared Function isFall()
        Return DateTime.Now.Month = 9 Or DateTime.Now.Month = 10 Or DateTime.Now.Month = 11
    End Function
    Shared Function isAni()
        Return DateTime.Now.Month = 9 And plusMinus(10, DateTime.Now.Day, 5)
    End Function
    Shared Function isValen()
        Return DateTime.Now.Month = 2 And plusMinus(14, DateTime.Now.Day, 5)
    End Function
    Shared Function isHallow()
        Return (DateTime.Now.Month = 10 And plusMinus(31, DateTime.Now.Day, 10) Or DateTime.Now.Month = 11 And plusMinus(1, DateTime.Now.Day, 5))
    End Function
    Shared Function isHoli()
        Return DateTime.Now.Month = 12 And plusMinus(25, DateTime.Now.Day, 5)
    End Function

    Public Shared Function getTimeNow() As Double
        Return (DateTime.Now - New DateTime(1970, 1, 1)).TotalMilliseconds
    End Function

    Public Shared Function getGeneralTimeOfDay() As String
        Select Case DateTime.Now.Hour
            Case 1, 2, 3, 4, 5
                Return "... morning"
            Case 6, 7, 8, 9, 10, 11
                Return " morning"
            Case 12
                Return " midday"
            Case 13, 14, 15, 16
                Return " afternoon"
            Case 17, 18, 19, 20
                Return " evening"
            Case Else
                Return " night"
        End Select
    End Function


    Private Shared Function plusMinus(ByVal x As Integer, ByVal y As Integer, ByVal o As Integer) As Boolean
        'returns true if y is within x +- o
        If y >= x - o And y <= x + 0 Then Return True Else Return False
    End Function
End Class
