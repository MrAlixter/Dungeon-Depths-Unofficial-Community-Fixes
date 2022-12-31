Public Class NanosilkQipaoP
    Inherits Armor

    Public Const ITEM_NAME As String = "Nanosilk_Qipao_(P)"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 393
        tier = Nothing

        '|Item Flags|
        usable = False
        rando_inv_allowed = False

        '|Stats|
        d_boost = 8
        s_boost = 15
        count = 0
        value = 888

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(105, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(482, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(483, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(484, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(485, True, True)
        'bsize4 = New Tuple(Of Integer, Boolean, Boolean)(486, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(99, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(464, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(465, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(466, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(467, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(468, True, True)
        usize5 = New Tuple(Of Integer, Boolean, Boolean)(469, True, True)

        '|Description|
        setDesc("A sleek pink dress, made of a remarkably smooth fabric.  Despite its delicate apperance, it actually seems fairly durable." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN & getStatInformation() & DDUtils.TODO)
    End Sub
End Class
