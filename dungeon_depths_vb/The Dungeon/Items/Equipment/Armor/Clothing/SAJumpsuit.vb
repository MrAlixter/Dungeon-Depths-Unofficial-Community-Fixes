
Public Class SAJumpsuit
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Space_Age_Jumpsuit")
        id = 102
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True
        rando_inv_allowed = False
        MyBase.slut_var_ind = 103

        '|Stats|
        MyBase.m_boost = 14
        MyBase.d_boost = 4
        count = 0
        value = 700

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(40, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(41, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(148, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(149, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(150, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(68, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(69, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(302, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(303, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(304, True, True)

        '|Description|
        setDesc("This garment is clearly not from the world you are used to.  Even the fabric is futuristic; focusing ambient energy from the air." & DDUtils.RNRN &
                        getSizeInformation() & vbcrlf & getStatInformation())
    End Sub
End Class
