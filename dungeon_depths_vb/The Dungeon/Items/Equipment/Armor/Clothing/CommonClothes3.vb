Public Class CommonClothes3
    Inherits Armor

    Public Const ITEM_NAME As String = "Fancy_Clothes"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 187
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        slut_var_ind = 191

        '|Stats|
        w_boost = 1
        d_boost = 1
        count = 0
        value = 0

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(3, False, False)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(260, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(3, True, False)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(102, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(6, False, False)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(7, False, False)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(6, True, False)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(7, True, False)

        '|Description|
        setDesc("Fancy clothes for a fancy adventurer." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
