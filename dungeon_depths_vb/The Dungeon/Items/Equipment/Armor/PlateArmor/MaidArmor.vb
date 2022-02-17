Public Class MaidArmor
    Inherits Armor

    Public Const ITEM_NAME As String = "Maid's_Armor"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 322
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        slut_var_ind = 72

        '|Stats|
        d_boost = 20
        s_boost = 5
        w_boost = 10
        count = 0
        value = 1840

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(92, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(409, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(410, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(411, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(412, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(88, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(393, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(394, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(395, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(396, True, True)

        '|Description|
        setDesc("A lightweight armor set fitted over a the classic outfit of a maid." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN & getStatInformation())
    End Sub
End Class
