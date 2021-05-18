Public Class SuccubusArmor
    Inherits Armor
    Sub New()
        '|ID Info|
        setName("Succubus_Armor")
        id = 237
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True
        MyBase.slut_var_ind = 74

        '|Stats|
        MyBase.a_boost = 10
        w_boost = 10
        MyBase.m_boost = 15
        MyBase.d_boost = 20
        count = 0
        value = 0

        '|Image Index|
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(326, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(327, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(328, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(329, True, True)

        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(309, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(310, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(311, True, True)
        MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(312, True, True)

        '|Description|
        setDesc("The scanty clothes of a succubus." & DDUtils.RNRN & _
                              getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
