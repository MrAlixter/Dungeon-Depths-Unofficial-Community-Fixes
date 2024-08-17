Public Class Boss
    Inherits MiniBoss
    'The Bosses appear every 5 floors, can not be fled from, and guard the entrance to the next stage
    Shared Function bossFactory(ByVal mIndex As Integer) As MiniBoss
        Select Case mIndex
            Case 5
                Return New Medusa
            Case 91017
                Return New MarissaAS
            Case 91018
                Return New TarFoodVend
            Case Else
                Return miniBossFactory(mIndex)
        End Select
    End Function
End Class
