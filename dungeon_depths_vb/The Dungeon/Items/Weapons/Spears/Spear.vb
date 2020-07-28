Public Class Spear
    Inherits Weapon
    Protected Friend weight As Integer = 17

    Overridable Sub wThrow(ByRef p As Player, ByRef m As Entity)
        If m Is Nothing Then
            Game.pushLblEvent("You throw the spear across the dungeon at nothing in particular.")
            Game.pushLstLog("You throw the spear across the dungeon at nothing in particular.")
        Else
            Game.pushLstLog("You throw the spear!")
            Dim dmg As Integer = (p.getATK) + (Me.aBoost) + (Me.aBoost) + Int(Rnd() * 3 + 1)
            p.hit(dmg, m)
        End If

        durability -= weight + Int(Rnd() * 6 + 1) + Int(Rnd() * 6 + 1)
        If durability <= 0 Then break()
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg As Integer = Int(Rnd() * 2 + 1) + Int(Rnd() * 2 + 1) + Int(Rnd() * 2 + 1) +
            Int(Rnd() * 2 + 1) + Int(Rnd() * 2 + 1) + Int(Rnd() * 2 + 1)
        If dmg <= 8 Then '+ ((p.lust Mod 20)) Then
            Return -1
        ElseIf dmg >= 10 Then
            Return -2
        End If
        dmg += (p.getATK) + (Me.aBoost)
        Return Player.calcDamage(dmg, m.defense)
    End Function

    Public Overrides Sub use(ByRef p As Player)
        wThrow(p, p.currTarget)
    End Sub
End Class
