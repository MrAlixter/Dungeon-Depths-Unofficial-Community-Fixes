Public Class ChitArmor
    Inherits Armor

    Sub New()
        MyBase.setName("Chitin_Armor")

        id = 64
        tier = 3
        isMonsterDrop = True
        MyBase.setUsable(False)
        MyBase.dBoost = 15
        MyBase.sBoost = 10
        MyBase.count = 0
        MyBase.value = 346
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(17, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(265, True, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(93, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(94, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(95, True, True)

        MyBase.usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(35, False, True)
        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(110, True, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(111, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(112, True, True)
        MyBase.compressesBreasts = True

        MyBase.setDesc("A set of armor built out of discarded chitin, commonly made and used by arachne huntresses." & DDUtils.RNRN &
                                       getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class

