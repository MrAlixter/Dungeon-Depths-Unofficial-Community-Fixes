
Public Class BarbArmor
    Inherits Armor

    Sub New()
        MyBase.setName("Barbarian_Armor")
        MyBase.setDesc("While this ""armor"" may not provide the same defence as other sets, it greatly improves offensive options." & vbCrLf & _
                       "Fits sizes -1 through 4" & vbCrLf & _
                       "+30 ATK, +5 DEF")
        id = 101
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.aBoost = 30
        MyBase.dBoost = 5
        MyBase.count = 0
        MyBase.value = 1500
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(37, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(38, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(139, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(140, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(141, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(142, True, True)
        MyBase.compressesBreasts = True
    End Sub
End Class
