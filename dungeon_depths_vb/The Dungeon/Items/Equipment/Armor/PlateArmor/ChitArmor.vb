Public Class ChitArmor
    Inherits Armor

    Sub New()
        setName("Chitin_Armor")

        id = 64
        tier = 3
        droppable = True
        usable = false
        MyBase.d_boost = 15
        MyBase.s_boost = 10
        count = 0
        value = 346
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(17, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(265, True, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(93, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(94, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(95, True, True)

        MyBase.usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(35, False, True)
        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(110, True, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(111, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(112, True, True)
        MyBase.compress_breast = True

        setDesc("A set of armor built out of discarded chitin, commonly made and used by arachne huntresses." & DDUtils.RNRN &
                                       getSizeInformation() & vbcrlf & getStatInformation())
    End Sub
End Class

