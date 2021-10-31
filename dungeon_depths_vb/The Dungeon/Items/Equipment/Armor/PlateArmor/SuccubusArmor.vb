Public Class SuccubusArmor
    Inherits Armor
    Sub New()
        '|ID Info|
        setName("Succubus_Armor")
        id = 237
        tier = Nothing

        '|Item Flags|
        usable = false
        compress_breast = True
        show_underboob = True
        slut_var_ind = 74

        '|Stats|
        a_boost = 10
        w_boost = 10
        m_boost = 15
        d_boost = 20
        count = 0
        value = 0

        '|Image Index|
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(326, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(327, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(328, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(329, True, True)

        usize1 = New Tuple(Of Integer, Boolean, Boolean)(309, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(310, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(311, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(312, True, True)

        '|Description|
        setDesc("The scanty clothes of a succubus." & DDUtils.RNRN & _
                              getSizeInformation() & vbcrlf & getStatInformation())
    End Sub
End Class
