Public Class LeatherWhip
    Inherits Weapon

    Sub New()
        setName("Leather_Sword")
        setDesc("A black leather whip that critically hits more often. +25 ATK")
        id = Nothing
        tier = Nothing
        usable = false
        MyBase.a_boost = 25
        count = 0
        value = 500
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg As Integer = Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)
        If dmg <= 5 Then
            Return -1
        ElseIf dmg >= 10 Then
            Return -2
        End If
        dmg += (p.attack) + (Me.a_boost)
        Return dmg - ((m.defense / 100) * dmg)
    End Function
End Class
