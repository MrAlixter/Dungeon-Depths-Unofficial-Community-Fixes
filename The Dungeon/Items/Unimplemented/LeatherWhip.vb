Public Class LeatherWhip
    Inherits Weapon

    Sub New()
        MyBase.setName("Leather_Sword")
        MyBase.setDesc("A black leather whip that critically hits more often. +25 ATK")
        MyBase.setUsable(False)
        MyBase.aBoost = 25
        MyBase.count = 0
        MyBase.value = 500
    End Sub

    Overrides Sub discard()
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Monster) As Integer
        Dim dmg As Integer = Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)
        If dmg <= 5 Then
            Return -1
        ElseIf dmg >= 10 Then
            Return -2
        End If
        dmg += (p.attack) + (Me.aBoost)
        Return dmg - ((m.defence / 100) * dmg)
    End Function
End Class
