Public Class BareFists
    Inherits Weapon

    'BareFists are the default player weapon, they deal damage equal to 4 D3 rolls, plus the player's 
    'attack stat minus the opponents defensive reduction
    Sub New()
        setName("Fists")
        setDesc("DO NOT SEE THIS EVER")
        id = Nothing
        tier = Nothing
        usable = false
        MyBase.a_boost = 0
        count = 0
        value = 0
    End Sub
    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg As Integer = Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)
        If dmg <= 5 Then
            Return -1
        End If
        dmg += p.getATK
        dmg = Player.calcDamage(dmg, m.defense)
        Return dmg
    End Function
End Class
