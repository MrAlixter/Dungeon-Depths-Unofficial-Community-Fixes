Public Class BareFists
    Inherits Weapon

    'BareFists are the default player weapon, they deal damage equal to 4 D3 rolls, plus the player's 
    'attack stat minus the opponents defensive reduction
    Sub New()
        MyBase.setName("Fists")
        MyBase.setDesc("DO NOT SEE THIS EVER")
        MyBase.setUsable(False)
        MyBase.aBoost = 0
        MyBase.count = 0
        MyBase.value = 0
    End Sub
    Overrides Sub discard()
        Form1.lstLog.Items.Add("You drop the " & getName())
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
        count -= 1
    End Sub
    Overrides Function attack(ByRef p As Player, ByRef m As Monster) As Integer
        Dim dmg As Integer = Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)
        If dmg <= 5 Then
            Return -1
        End If
        dmg += p.getAttack
        dmg -= ((m.defence / 100) * dmg)
        If dmg < 0 Then dmg = 0
        Return dmg
    End Function
End Class
