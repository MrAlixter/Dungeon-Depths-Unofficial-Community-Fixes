
Public Class BarbArmor
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Barbarian_Armor")
        id = 101
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True

        '|Stats|
        MyBase.a_boost = 12
        MyBase.d_boost = 10
        MyBase.s_boost = 5
        count = 0
        value = 1840

        '|Image Index|
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(37, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(38, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(139, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(140, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(141, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(142, True, True)

        MyBase.usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(22, False, True)
        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(23, False, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(64, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(65, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(66, True, True)
        MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(67, True, True)

        MyBase.bsizeneg2 = New Tuple(Of Integer, Boolean, Boolean)(67, False, True)
        MyBase.usizeneg2 = New Tuple(Of Integer, Boolean, Boolean)(49, False, True)

        '|Description|
        setDesc("While this ""armor"" may not provide the same defense as other sets, it greatly improves offensive options." & DDUtils.RNRN &
                                      getSizeInformation() & vbcrlf & getStatInformation())
    End Sub
End Class
