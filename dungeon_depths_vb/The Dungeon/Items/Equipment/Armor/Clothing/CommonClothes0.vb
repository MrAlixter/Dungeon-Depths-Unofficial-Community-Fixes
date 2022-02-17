Public Class CommonClothes0
    Inherits Armor

    Public Const ITEM_NAME As String = "Common_Clothes"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 184
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        slut_var_ind = 191

        '|Stats|
        d_boost = 1
        s_boost = 1
        count = 0
        value = 0

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(257, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(99, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(1, False, False)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(1, True, False)

        '|Description|
        setDesc("Common clothes for the common adventurer." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
