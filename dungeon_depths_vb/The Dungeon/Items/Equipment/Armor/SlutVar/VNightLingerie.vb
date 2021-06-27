Public Class VNightLingerie
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Val._Night_Lingerie")
        id = 78
        If DDDateTime.isValen Then tier = 2 Else tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True
        MyBase.droppable = False
        rando_inv_allowed = False

        '|Stats|
        MyBase.d_boost = 6
        count = 0
        MyBase.anti_slut_ind = 79
        value = 428

        '|Image Index|
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(252, True, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(117, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(118, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(119, True, True)

        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(192, True, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(193, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(194, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(195, True, True)

        '|Description|
        setDesc("A lovely set of black, white, and red undergarments perfect for a romantic evening with a signifigant other." & DDUtils.RNRN &
                       getSizeInformation() & vbcrlf & getStatInformation())
    End Sub
End Class
