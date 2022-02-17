Public Class CommonClothes2
    Inherits Armor

    Public Const ITEM_NAME As String = "Common_Garb"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 186
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        slut_var_ind = 191

        '|Stats|
        d_boost = 1
        m_boost = 1
        count = 0
        value = 0

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(2, False, False)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(259, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(2, True, False)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(101, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(4, False, False)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(5, False, False)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(4, True, False)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(5, True, False)

        '|Description|
        setDesc("Common garb for the common adventurer." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
