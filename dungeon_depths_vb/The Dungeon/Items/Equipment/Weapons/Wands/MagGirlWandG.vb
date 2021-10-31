Public Class MagGirlWandG
    Inherits MagGirlWand

    Sub New()
        '|ID Info|
        setName("Mag._Girl_Wand_(G)")
        id = 307
        tier = Nothing

        '|Item Flags|
        usable = False

        '|Stats|
        count = 0
        value = 2000
        w_boost = 25
        m_boost = 10
        uniform_id = 304

        '|Description|
        setDesc("A mysterious wand used by a mysterious protector." & DDUtils.RNRN &
                getStatInformation())

    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        If Not p.className.Equals("Magical Girl") And Not p.perks(perk.tfedbyweapon) > 0 Then

            Dim magicGirlTF = New MagGirlGTF(2, 0, 0, False)
            magicGirlTF.update()
            p.ongoingTFs.add(magicGirlTF)

            p.perks(perk.tfcausingwand) = id
            p.perks(perk.tfedbyweapon) = 1

        End If
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg As Integer = Int(Rnd() * 6 + 1) + Int(Rnd() * 6 + 1)
        If dmg <= 4 Then '+ ((p.lust Mod 20)) Then
            Return -1
        ElseIf dmg >= 11 Then
            Return -2
        End If
        dmg += (p.getWIL) + (Me.w_boost)
        Return Player.calcDamage(dmg, m.defense)
    End Function
End Class
