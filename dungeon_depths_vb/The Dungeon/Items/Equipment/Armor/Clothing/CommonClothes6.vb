Public Class CommonClothes6
    Inherits Armor

    Public Const ITEM_NAME As String = "Sneaky_Clothes"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 190
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        slut_var_ind = 191

        '|Stats|
        a_boost = 1
        s_boost = 1
        count = 0
        value = 0

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(6, False, False)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(263, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(6, True, False)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(124, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(12, False, False)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(13, False, False)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(12, True, False)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(13, True, False)

        '|Description|
        setDesc("Sneaky clothes for a sneaky adventurer." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
