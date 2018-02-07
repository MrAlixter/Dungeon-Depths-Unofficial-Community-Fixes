Public Class SteelSword
    Inherits Weapon

    Sub New()
        MyBase.setName("Steel_Sword")
        MyBase.setDesc("A simple sword forged from steel. +10 ATK")
        id = 6
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.aBoost = 10
        MyBase.count = 0
        MyBase.value = 125
    End Sub

    Overrides Sub discard()
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Monster) As Integer
        Dim dmg As Integer = Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)
        If dmg <= 4 Then '+ ((p.lust Mod 20)) Then
            Return -1
        ElseIf dmg >= 11 Then
            Return -2
        End If
        dmg += (p.getAttack) + (Me.aBoost)
        Return dmg - ((m.defence / 100) * dmg)
    End Function
End Class
