Public Class SteelSword
    Inherits Weapon

    Sub New()
        MyBase.setName("Steel_Sword")
        MyBase.setDesc("A simple sword forged from steel. +17 ATK")
        id = 6
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.aBoost = 17
        MyBase.count = 0
        MyBase.value = 235
    End Sub

    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())
        
        count -= 1
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg As Integer = Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)
        If dmg <= 4 Then '+ ((p.lust Mod 20)) Then
            Return -1
        ElseIf dmg >= 11 Then
            Return -2
        End If
        dmg += (p.getATK) + (Me.aBoost)
        Return Player.calcDamage(dmg, m.defence)
    End Function
End Class
