Public Class CommonClothes4
    Inherits Armor

    Public Const ITEM_NAME As String = "Ordinary_Clothes"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 188
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        slut_var_ind = 191

        '|Stats|
        m_boost = 1
        s_boost = 1
        count = 0
        value = 0

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(4, False, False)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(261, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(4, True, False)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(103, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(8, False, False)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(9, False, False)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(8, True, False)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(9, True, False)

        '|Description|
        setDesc("Ordinary clothes for a ordinary adventurer." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
