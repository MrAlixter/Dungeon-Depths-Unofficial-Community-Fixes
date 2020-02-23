Public Class SigDagger
    Inherits Dagger

    Sub New()
        MyBase.setName("Signature_Dagger")
        MyBase.setDesc("A finely crafted dagger bearing a trademarked signature.  Despite its sturdy construction, the blade is also light enough to allow its bearer to strike thrice in the same time as a sword-swing." & vbCrLf &
                       "+10 ATK" & vbCrLf &
                       "+5 SPD")
        id = 163
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.aBoost = 10
        MyBase.sBoost = 5
        MyBase.count = 0
        MyBase.value = 235

        MyBase.isMonsterDrop = False
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
            p.miss(m)
        ElseIf dmg >= 11 Then
            p.cHit(p.getATK, m)
        Else
            dmg += (p.getATK) + (Me.aBoost)
            p.hit(Player.calcDamage(dmg, m.defence), m)
        End If

        '3rd hit
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
