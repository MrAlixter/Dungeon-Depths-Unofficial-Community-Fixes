Public Class Sword
    Inherits Weapon

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg As Integer = Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)
        If dmg <= 4 Then '+ ((p.lust Mod 20)) Then
            Return -1
        ElseIf dmg >= 11 Then
            Return -2
        End If
        dmg += (p.getATK) + (Me.aBoost)
        Return Player.calcDamage(dmg, m.defense)
    End Function

    Public Overrides Sub onUnequip(ByRef p As Player, ByRef w As Weapon)
        MyBase.onUnequip(p, w)

        If p.perks(perk.tfcausingsword) <> -1 Then
            CType(p.inv.item(p.perks(perk.tfcausingsword)), Sword).onUnequip(p, w)
            p.perks(perk.tfcausingsword) = -1
        End If
    End Sub
End Class
