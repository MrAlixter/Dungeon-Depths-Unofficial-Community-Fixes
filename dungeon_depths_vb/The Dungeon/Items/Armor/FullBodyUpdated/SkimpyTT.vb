Public Class SkimpyTT
    Inherits Armor

    Sub New()
        MyBase.setName("Skimpy_Tank_Top")
        MyBase.setDesc("Barely there, this skimpy outfit boosts agility." & vbCrLf & _
                       "Fits sizes 1 through 4" & vbCrLf & _
                       "+10 SPD")
        id = 147
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.sBoost = 10
        MyBase.count = 0
        MyBase.value = 0

        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(215, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(216, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(217, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(218, True, True)

        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(252, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(253, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(254, True, True)
        MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(255, True, True)

        MyBase.compressesBreasts = True
        MyBase.isRandoTFAcceptable = False
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
        p.perks(perk.bimbododge) = 2
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)
        p.perks(perk.bimbododge) = -1
    End Sub
End Class
