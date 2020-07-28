
Public Class BarbArmor
    Inherits Armor

    Sub New()
        MyBase.setName("Barbarian_Armor")
        MyBase.setDesc("While this ""armor"" may not provide the same defence as other sets, it greatly improves offensive options." & vbCrLf & _
                       "Fits sizes -1 through 4" & vbCrLf & _
                       "+12 ATK, +10 DEF, +5 SPD")
        id = 101
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.aBoost = 12
        MyBase.dBoost = 10
        MyBase.sBoost = 5
        MyBase.count = 0
        MyBase.value = 1840

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

        MyBase.compressesBreasts = True
    End Sub
End Class
