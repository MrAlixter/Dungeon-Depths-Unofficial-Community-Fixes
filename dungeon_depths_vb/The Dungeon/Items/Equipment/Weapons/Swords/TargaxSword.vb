Public Class TargaxSword
    Inherits Sword

    Sub New()
        MyBase.setName("Sword_of_the_Brutal")
        MyBase.setDesc("A suspicious sword owned by a brutal despot." & vbcrlf & 
		               "+50 ATK")
        id = 24
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.aBoost = 50
        MyBase.count = 0
        MyBase.value = 3332

        MyBase.isRandoTFAcceptable = False
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg As Integer = Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)
        If dmg <= 4 Then '+ ((p.lust Mod 20)) Then
            Return -1
        End If
        dmg += (p.getATK) + (Me.aBoost)
        Return Player.calcDamage(dmg, m.defense)
    End Function

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
        If Not p.perks(perk.swordpossess) > -1 Then p.perks(perk.swordpossess) = 0
    End Sub
    Public Overloads Overrides Sub onUnequip(ByRef p As Player, ByRef w As Weapon)
        MyBase.onUnequip(p, w)
        If p.perks(perk.swordpossess) > -1 Then p.perks(perk.swordpossess) = -1
    End Sub
End Class
