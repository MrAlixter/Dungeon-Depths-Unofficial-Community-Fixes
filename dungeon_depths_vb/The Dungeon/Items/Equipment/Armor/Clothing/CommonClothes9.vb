Public Class CommonClothes9
    Inherits Armor

    Public Const ITEM_NAME As String = "Common_Cloak"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 384
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        slut_var_ind = 191

        '|Stats|
        m_boost = 1
        w_boost = 1
        count = 0
        value = 0

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(9, False, False)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(103, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(9, True, False)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(481, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(18, False, False)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(19, False, False)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(18, True, False)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(19, True, False)

        '|Description|
        setDesc("Regular clothes for the everyday scholar." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
