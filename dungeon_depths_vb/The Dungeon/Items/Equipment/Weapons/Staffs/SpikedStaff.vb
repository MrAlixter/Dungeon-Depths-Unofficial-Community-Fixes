Public Class SpikedStaff
    Inherits Staff

    Sub New()
        setName("Spiked_Staff")
        setDesc("A reinforced steel staff covered in rows of wicked looking spikes.  It's as good at smacking things as it is at boosting mana." & vbCrLf &
                       "+46 Mana" & vbCrLf &
                       "+23 ATK")
        id = 160
        tier = Nothing
        usable = false
        MyBase.m_boost = 46
        MyBase.a_boost = 23
        count = 0
        value = 1999
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg As Integer = Int(Rnd() * 6 + 1) + Int(Rnd() * 6 + 1)
        If dmg <= 4 Then '+ ((p.lust Mod 20)) Then
            Return -1
        ElseIf dmg >= 11 Then
            Return -2
        End If
        dmg += (p.getATK) + (Me.a_boost)
        Return Player.calcDamage(dmg, m.defense)
    End Function
End Class
