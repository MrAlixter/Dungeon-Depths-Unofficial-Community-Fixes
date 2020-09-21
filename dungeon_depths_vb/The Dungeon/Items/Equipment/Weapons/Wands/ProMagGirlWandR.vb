Public Class ProMagGirlWandR
    Inherits MagGirlWand

    Sub New()
        MyBase.setName("Pro_Mag._G._Wand_(R)")
        MyBase.setDesc("A mysterious wand used by a mysterious protector." & vbCrLf & "+33 ATK, +15 Max Mana")
        id = 213
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.aBoost = 33
        MyBase.mBoost = 15
        MyBase.count = 0
        MyBase.value = 2000

        mgOutfit = 211
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        If Not p.className.Equals("Magical Girl") Then

            Dim magicGirlTF = New ProMagGirlRTF(2, 0, 0, False)
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
