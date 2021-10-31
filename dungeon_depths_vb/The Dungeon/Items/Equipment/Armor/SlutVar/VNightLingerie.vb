Public Class VNightLingerie
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Val._Night_Lingerie")
        id = 78
        If DDDateTime.isValen Then tier = 2 Else tier = Nothing

        '|Item Flags|
        usable = false
        compress_breast = True
        show_underboob = True
        droppable = False
        rando_inv_allowed = False

        '|Stats|
        MyBase.d_boost = 6
        count = 0
        MyBase.anti_slut_ind = 79
        value = 428

        '|Image Index|
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(252, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(117, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(118, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(119, True, True)

        usize0 = New Tuple(Of Integer, Boolean, Boolean)(192, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(193, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(194, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(195, True, True)

        '|Description|
        setDesc("A lovely set of black, white, and red undergarments perfect for a romantic evening with a signifigant other." & DDUtils.RNRN &
                       getSizeInformation() & vbcrlf & getStatInformation())
    End Sub
End Class
