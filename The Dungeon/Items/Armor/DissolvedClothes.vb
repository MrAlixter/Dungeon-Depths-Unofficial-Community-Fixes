Public Class DissolvedClothes
    Inherits Armor
    Sub New()
        MyBase.setName("Dissolved_Clothes")
        MyBase.setDesc("While at some point this set of apperal may have provided some defence, a generous dousing of slime has left it completely ruined." & vbCrLf &
                       "+1 DEF")
        id = 80
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 1
        MyBase.count = 0
        MyBase.value = 0
        MyBase.compressesBreasts = True
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(32, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(131, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(132, True, True)
    End Sub
End Class
