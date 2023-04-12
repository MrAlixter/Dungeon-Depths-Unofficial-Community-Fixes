Public Class Whip
    Inherits Weapon

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg As Integer = Int(Rnd() * 4 + 1) + Int(Rnd() * 4 + 1) + Int(Rnd() * 4 + 1)
        If dmg <= 5 Then
            Return -1
        ElseIf dmg >= 10 Then
            Return -2
        End If
        dmg += (p.attack) + (Me.getABoost(p))
        Return Player.calcDamage(dmg, m.defense)
    End Function
End Class
