Public Class MagGirlWandP
    Inherits MagGirlWand

    Sub New()
        '|ID Info|
        setName("Mag._Girl_Wand_(P)")
        id = 204
        tier = Nothing

        '|Item Flags|
        usable = False

        '|Stats|
        count = 0
        value = 2000
        m_boost = 20
        a_boost = 7
        uniform_id = 202

        '|Description|
        setDesc("A mysterious wand used by a mysterious protector." & DDUtils.RNRN &
                getStatInformation())

    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        If Not p.className.Equals("Magical Girl") And Not p.perks(perk.tfedbyweapon) > 0 Then

            Dim magicGirlTF = New MagGirlPTF(2, 0, 0, False)
            p.perks(perk.tfcausingwand) = id
            p.perks(perk.tfedbyweapon) = 1

            magicGirlTF.update()
            p.ongoingTFs.add(magicGirlTF)
        End If
    End Sub

    Public Overrides Sub spell(ByRef p As Player, ByRef m As Entity)
        Dim dmg As Integer = a_boost
        Dim d31 = Int(Rnd() * 3)
        Dim d32 = Int(Rnd() * 4)

        m.takeDMG(dmg + d31 + d32, p)
        TextEvent.pushLog(CStr("You fire off a heart-shaped blast, hitting the " & m.name & " for " & dmg + d31 + d32 & " damage!"))
        TextEvent.pushCombat(CStr("You fire off a heart-shaped blast, hitting the " & m.name & " for " & dmg + d31 + d32 & " damage!"))
    End Sub
End Class
