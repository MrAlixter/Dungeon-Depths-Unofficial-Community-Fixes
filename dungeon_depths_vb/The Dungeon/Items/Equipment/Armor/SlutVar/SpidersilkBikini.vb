Public Class SpidersilkBikini
    Inherits Armor

    Public Const ITEM_NAME As String = "Spidersilk_Bikini"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 240
        tier = Nothing

        '|Item Flags|
        usable = false
        compress_breast = True
        hide_dick = False
        show_underboob = True
        rando_inv_allowed = False
        anti_slut_ind = 239

        '|Stats|
        s_boost = 13
        count = 0
        value = 1450

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(72, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(330, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(331, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(332, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(333, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(334, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(71, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(313, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(314, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(315, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(316, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(317, True, True)

        '|Description|
        setDesc("A nearly invisible bikini composed of gossamer strands of spidersilk." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f14fXX
                Return 4
            Case Else
                Return MyBase.getTier(floor_num)
        End Select
    End Function
End Class
