Public Class ScaleArmor
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Scale_Armor")
        id = 176
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True
        slut_var_ind = 177

        '|Stats|
        MyBase.d_boost = 22
        MyBase.s_boost = -3
        count = 0
        value = 2300

        '|Image Index|
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(62, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(62, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(238, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(239, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(240, True, True)

        MyBase.usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(50, False, True)
        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(183, True, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(183, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(184, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(185, True, True)

        '|Description|
        setDesc("Unlike the its bronze and steel counterparts, this armor set consists of a series of small interlocking plates.  The unique draconic alloy used by these scales provides ample protection, although it's also fairly heavy." & DDUtils.RNRN & _
                        getSizeInformation() & vbcrlf & getStatInformation())
    End Sub
End Class
