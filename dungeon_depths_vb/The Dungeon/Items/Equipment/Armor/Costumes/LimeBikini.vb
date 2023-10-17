Public Class LimeBikini
    Inherits Armor

    Public Const ITEM_NAME As String = "Lime_Bikini"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 298
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        show_underboob = True
        rando_inv_allowed = False
        anti_slut_ind = 345
        is_sexy = True

        '|Stats|
        d_boost = 11
        s_boost = 11
        count = 0
        value = 1760

        '|Image Index|
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(378, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(379, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(380, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(381, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(382, True, True)

        usize0 = New Tuple(Of Integer, Boolean, Boolean)(362, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(363, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(364, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(365, True, True)

        '|Description|
        setDesc("A bright green swimsuit." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Function getTier(ByVal floor_num As Integer) As Integer
        If DDDateTime.isSummer Then Return 3

        Return Nothing
    End Function
End Class
