Public Class BronzeXiphos
    Inherits Weapon
    'The BronzeXiphos is a weapon with the following damage breakdown
    '4 D3s + 25 + players attack
    'if all four roll 1, then it misses
    'if the sum of the rolls is 11 or 12, then it criticals
    'lust applies
    Sub New()
        MyBase.setName("Bronze_Xiphos")
        MyBase.setDesc("A neat curved double-edged blade forged from bronze. +25 ATK")
        id = 23
        tier = 3
        MyBase.setUsable(False)
        MyBase.aBoost = 25
        count = 0
        value = 900
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
        Return Player.calcDamage(dmg, m.defence)
    End Function
End Class
