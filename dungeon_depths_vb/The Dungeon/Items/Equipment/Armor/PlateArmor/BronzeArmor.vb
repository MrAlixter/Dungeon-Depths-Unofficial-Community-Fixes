Public Class BronzeArmor
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Bronze_Armor")
        id = 83
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True
        MyBase.slut_var_ind = 85

        '|Stats|
        MyBase.d_boost = 6
        MyBase.s_boost = 2
        count = 0
        value = 125

        '|Image Index|
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(28, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(29, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(125, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(126, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(127, True, True)

        MyBase.usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(15, False, True)
        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(16, False, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(21, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(22, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(23, True, True)
        MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(24, True, True)

        '|Description|
        setDesc("A lightweight armor set forged from bronze that, while not offering much defense also gives a slight speed boost." & DDUtils.RNRN &
                               getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
