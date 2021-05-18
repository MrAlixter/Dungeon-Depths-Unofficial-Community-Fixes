Public Class CowBra
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Cow_Print_Bra")
        id = 71
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True
        MyBase.slut_var_ind = 196
        MyBase.anti_slut_ind = 262

        '|Stats|
        MyBase.d_boost = 1
        count = 0
        value = 50

        '|Image Index|
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(19, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(20, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(104, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(105, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(106, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(107, True, True)
        MyBase.bsize5 = New Tuple(Of Integer, Boolean, Boolean)(108, True, True)
        MyBase.bsize6 = New Tuple(Of Integer, Boolean, Boolean)(109, True, True)
        MyBase.bsize7 = New Tuple(Of Integer, Boolean, Boolean)(110, True, True)

        MyBase.usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(30, False, True)
        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(31, False, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(95, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(96, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(97, True, True)
        MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(98, True, True)
        MyBase.usize5 = New Tuple(Of Integer, Boolean, Boolean)(99, True, True)

        '|Description|
        setDesc("A cow print bra created to hold cow sized breasts." & DDUtils.RNRN &
                                     getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
