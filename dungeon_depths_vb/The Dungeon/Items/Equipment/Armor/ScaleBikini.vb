Public Class ScaleBikini
    Inherits Armor

    Sub New()
        '|ID Info|
        MyBase.setName("Scale_Bikini")
        id = 177
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(False)
        MyBase.compressesBreasts = True
        antiSlutVarInd = 176

        '|Stats|
        MyBase.dBoost = 9
        MyBase.sBoost = 7
        MyBase.count = 0
        MyBase.value = 1450

        '|Image Index|
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(241, True, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(242, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(243, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(244, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(245, True, True)
        MyBase.bsize5 = New Tuple(Of Integer, Boolean, Boolean)(246, True, True)

        MyBase.usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(51, False, True)
        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(186, True, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(187, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(188, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(189, True, True)
        MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(190, True, True)
        MyBase.usize5 = New Tuple(Of Integer, Boolean, Boolean)(191, True, True)

        '|Description|
        MyBase.setDesc("This bikini consists of a set of plates that contour to its wearer's breasts.  While the scales making up this ""armor"" don't offer much in the way of protection, they also don't get in the way." & DDUtils.RNRN & _
                                     getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
