Public Class CowBra
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Cow_Print_Bra")
        id = 71
        tier = Nothing

        '|Item Flags|
        usable = false
        compress_breast = True
        show_underboob = True
        slut_var_ind = 196
        anti_slut_ind = 262

        '|Stats|
        d_boost = 1
        count = 0
        value = 50

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(19, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(20, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(104, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(105, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(106, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(107, True, True)
        bsize5 = New Tuple(Of Integer, Boolean, Boolean)(108, True, True)
        bsize6 = New Tuple(Of Integer, Boolean, Boolean)(109, True, True)
        bsize7 = New Tuple(Of Integer, Boolean, Boolean)(110, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(30, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(31, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(95, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(96, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(97, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(98, True, True)
        usize5 = New Tuple(Of Integer, Boolean, Boolean)(99, True, True)

        '|Description|
        setDesc("A cow print bra created to hold cow sized breasts." & DDUtils.RNRN &
                                     getSizeInformation() & vbcrlf & getStatInformation())
    End Sub
End Class
