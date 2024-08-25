Public Class GalGarb
    Inherits Armor

    Public Const ITEM_NAME As String = "Gal_Garb"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 446
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        rando_inv_allowed = False
        is_sexy = True

        '|Stats|
        d_boost = 1
        a_boost = 3
        s_boost = 3
        w_boost = 13
        count = 0
        value = 400

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(123, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(534, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(535, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(536, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(537, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(538, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(116, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(523, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(524, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(525, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(526, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(527, True, True)

        '|Description|
        setDesc("A white blouse that has been tied off at the front, paired with a red pleated skirt." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN & getStatInformation())
    End Sub
End Class
