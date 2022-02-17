Public Class CommonClothes8
    Inherits Armor

    Public Const ITEM_NAME As String = "Regular_Clothes"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 285
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        slut_var_ind = 191

        '|Stats|
        w_boost = 2
        count = 0
        value = 0

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(8, False, False)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(83, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(8, True, False)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(363, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(16, False, False)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(17, False, False)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(16, True, False)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(17, True, False)

        '|Description|
        setDesc("Regular clothes for the everyday adventurer." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
