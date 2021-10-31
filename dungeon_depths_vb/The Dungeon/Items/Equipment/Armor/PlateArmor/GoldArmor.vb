Public Class GoldArmor
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Gold_Armor")
        id = 38
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True
        MyBase.slut_var_ind = 39

        '|Stats|
        MyBase.d_boost = 30
        count = 0
        value = 3800

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(9, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(9, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(51, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(52, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(53, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(59, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(264, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(264, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(265, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(266, True, True)

        '|Description|
        setDesc("A expensive looking armor set made for the wealthy." & DDUtils.RNRN &
                                          getSizeInformation() & vbcrlf & getStatInformation())
    End Sub
End Class
