Public Class VSkimpyClothes
    Inherits Armor

    Public Const ITEM_NAME As String = "Very_Skimpy_Clothes"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 192
        tier = Nothing

        '|Item Flags|
        usable = false
        compress_breast = True
        show_underboob = True
        anti_slut_ind = 191
        is_sexy = True

        '|Stats|
        h_boost = 15
        count = 0
        value = 138

        '|Image Index|
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(177, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(178, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(179, True, True)
        bsize5 = New Tuple(Of Integer, Boolean, Boolean)(180, True, True)
        bsize6 = New Tuple(Of Integer, Boolean, Boolean)(181, True, True)

        usize1 = New Tuple(Of Integer, Boolean, Boolean)(276, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(277, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(278, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(279, True, True)
        usize5 = New Tuple(Of Integer, Boolean, Boolean)(280, True, True)

        '|Description|
        setDesc("A soft set of clothing that definitely seems crafted to show off its wearer's body." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
