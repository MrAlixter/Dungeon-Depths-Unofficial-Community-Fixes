Public Class ScaleBikini
    Inherits Armor

    Sub New()
        MyBase.setName("Scale_Bikini")
        MyBase.setDesc("This bikini consists of a set of plates that contour to its wearer's breasts.  While the scales making up this ""armor"" don't offer much in the way of protection, they also don't get in the way." & vbCrLf & _
                       "Fits sizes 0 through 5" & vbCrLf &
                       "+9 DEF" & vbCrLf &
                       "+7 SPD")
        id = 177
        tier = Nothing
        antiSlutVarInd = 176
        MyBase.setUsable(False)
        MyBase.dBoost = 9
        MyBase.sBoost = 7
        MyBase.count = 0
        MyBase.value = 1450

        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(241, True, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(242, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(243, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(244, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(245, True, True)
        MyBase.bsize5 = New Tuple(Of Integer, Boolean, Boolean)(246, True, True)

        MyBase.compressesBreasts = True
    End Sub
End Class
