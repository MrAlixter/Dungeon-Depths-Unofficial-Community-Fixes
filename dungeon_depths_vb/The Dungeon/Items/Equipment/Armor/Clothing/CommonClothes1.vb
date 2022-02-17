Public Class CommonClothes1
    Inherits Armor

    Public Const ITEM_NAME As String = "Common_Armor"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 185
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        slut_var_ind = 191

        '|Stats|
        d_boost = 2
        count = 0
        value = 0

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(1, False, False)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(258, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(1, True, False)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(100, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(2, False, False)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(3, False, False)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(2, True, False)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(3, True, False)

        '|Description|
        setDesc("Common armor for the common adventurer." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
