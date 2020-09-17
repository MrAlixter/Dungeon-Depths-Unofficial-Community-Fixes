Public Class MagGirlWandR
    Inherits MagGirlWand

    Sub New()
        MyBase.setName("Mag._Girl_Wand_(R)")
        MyBase.setDesc("A mysterious wand used by a mysterious protector." & vbCrLf & "+25 ATK, +10 Max Mana")
        id = 212
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.aBoost = 25
        MyBase.mBoost = 10
        MyBase.count = 0
        MyBase.value = 2000

        mgOutfit = 210
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        If Not p.pClass.name.Equals("Magical Girl") Then

            Dim magicGirlTF = New MagGirlRTF(2, 0, 0, False)
            magicGirlTF.update()
            p.ongoingTFs.add(magicGirlTF)
        End If
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg As Integer = Int(Rnd() * 6 + 1) + Int(Rnd() * 6 + 1)
        If dmg <= 4 Then '+ ((p.lust Mod 20)) Then
            Return -1
        ElseIf dmg >= 11 Then
            Return -2
        End If
        dmg += (p.getATK) + (Me.aBoost)
        Return Player.calcDamage(dmg, m.defense)
    End Function
End Class
