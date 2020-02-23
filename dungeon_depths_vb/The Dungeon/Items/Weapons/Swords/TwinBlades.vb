Public Class TwinBlades
    Inherits Weapon
    Sub New()
        MyBase.setName("Twin_Xiphoi")
        MyBase.setDesc("Why have one neat curved double-edged blade forged from bronze when you can have 2?" & vbCrLf &
                       "+25 ATK" & vbCrLf &
                       "Hits twice")
        id = 150
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.aBoost = 25
        count = 0
        value = 1820
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        '1st hit
        Dim dmg As Integer = Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)
        If dmg <= 4 Then '+ ((p.lust Mod 20)) Then
            p.miss(m)
        ElseIf dmg >= 11 Then
            p.cHit(p.getATK, m)
        Else
            dmg += (p.getATK) + (Me.aBoost)
            p.hit(Player.calcDamage(dmg, m.defence), m)
        End If

        '2nd hit
        dmg = Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)
        If dmg <= 4 Then '+ ((p.lust Mod 20)) Then
            Return -1
        ElseIf dmg >= 11 Then
            Return -2
        End If
        dmg += (p.getATK) + (Me.aBoost)
        Return Player.calcDamage(dmg, m.defence)
    End Function
End Class
