Public Class SpidersilkBikini
    Inherits Armor

    Sub New()
        '|ID Info|
        MyBase.setName("Spidersilk_Bikini")
        id = 240
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(False)
        MyBase.compressesBreasts = True
        MyBase.hidesDick = False
        MyBase.isRandoTFAcceptable = False
        antiSlutVarInd = 239

        '|Stats|
        MyBase.sBoost = 13
        MyBase.count = 0
        MyBase.value = 1450

        '|Image Index|
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(72, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(330, True, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(331, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(332, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(333, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(334, True, True)

        MyBase.usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(71, False, True)
        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(313, True, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(314, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(315, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(316, True, True)
        MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(317, True, True)

        '|Description|
        MyBase.setDesc("A nearly invisible bikini composed of gossamer strands of spidersilk." & DDUtils.RNRN & _
                        getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
