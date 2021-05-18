Public Class SpidersilkBikini
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Spidersilk_Bikini")
        id = 240
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True
        MyBase.hide_dick = False
        rando_inv_allowed = False
        anti_slut_ind = 239

        '|Stats|
        MyBase.s_boost = 13
        count = 0
        value = 1450

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
        setDesc("A nearly invisible bikini composed of gossamer strands of spidersilk." & DDUtils.RNRN & _
                        getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
