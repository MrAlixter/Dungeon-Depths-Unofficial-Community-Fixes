Public Class CommonClothes5
    Inherits Armor

    Public Const ITEM_NAME As String = "Common_Kimono"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 189
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        slut_var_ind = 191

        '|Stats|
        a_boost = 2
        count = 0
        value = 0

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(5, False, False)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(262, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(5, True, False)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(123, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(10, False, False)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(11, False, False)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(10, True, False)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(11, True, False)

        '|Description|
        setDesc("Traditional clothes for a katana-wielding adventurer." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
