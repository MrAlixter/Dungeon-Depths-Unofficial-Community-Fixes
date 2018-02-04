Public Class GoldSword
    Inherits Weapon

    Sub New()
        MyBase.setName("Gold_Sword")
        MyBase.setDesc("A shiny sword forged from a gold alloy. +35 ATK")
        MyBase.setUsable(False)
        MyBase.aBoost = 35
        MyBase.count = 0
        MyBase.value = 1800
    End Sub

    Overrides Sub discard()
        Form1.lstLog.Items.Add("You drop the " & getName())
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
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
