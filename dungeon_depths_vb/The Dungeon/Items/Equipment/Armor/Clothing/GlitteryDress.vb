Public Class GlitteryDress
    Inherits Armor

    Public Const ITEM_NAME As String = "Glittery_Dress"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 455
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        rando_inv_allowed = False
        adjust_sleeve_layer = False
        is_sexy = True

        '|Stats|
        a_boost = 4
        d_boost = 4
        s_boost = 4
        w_boost = 4
        count = 0
        value = 0

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(124, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(542, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(539, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(540, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(541, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(543, True, True)
        bsize5 = New Tuple(Of Integer, Boolean, Boolean)(544, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(117, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(529, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(528, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(530, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(531, True, True)
        'usize4 = New Tuple(Of Integer, Boolean, Boolean)(522, True, True)

        '|Description|
        setDesc("A sparkly silver dress that shines playfully with it's user's every move.  The outfit is completed with jewelry of platinum and gold, and a gleaming pair of high heels." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
