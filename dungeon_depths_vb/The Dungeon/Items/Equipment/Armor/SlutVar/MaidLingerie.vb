Public Class MaidLingerie
    Inherits Armor

    Public Const ITEM_NAME As String = "Maid_Lingerie"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 169
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        anti_slut_ind = 72
        is_sexy = True

        '|Stats|
        s_boost = 4
        count = 0
        value = 0

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(56, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(57, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(223, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(224, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(225, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(47, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(48, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(164, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(165, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(166, True, True)

        '|Description|
        setDesc("A smutty version of a French maid's outfit." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
