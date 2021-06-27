Public Class MagGirlWand
    Inherits Wand
    Protected uniform_id As Integer = 10
    Sub New()
        '|ID Info|
        setName("Magical_Girl_Wand")
        id = 11
        tier = 3

        '|Item Flags|
        usable = False

        '|Stats|
        count = 0
        value = 1000
        m_boost = 20
        a_boost = 7

        '|Description|
        setDesc("A mysterious wand used by a mysterious protector." & DDUtils.RNRN &
                getStatInformation())

    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
        If Not p.className.Equals("Magical Girl") And Not p.perks(perk.tfedbyweapon) > 0 Then

            Dim magicGirlTF = New MagGirlTF(2, 0, 0, False)
            magicGirlTF.update()
            p.ongoingTFs.add(magicGirlTF)

            p.perks(perk.tfcausingwand) = id
            p.perks(perk.tfedbyweapon) = 1
        End If
    End Sub

    Public Overrides Sub onunEquip(ByRef p As Player, ByRef w As Weapon)
        If (p.className.Equals("Magical Girl") Or p.perks(perk.tfedbyweapon) > 0) And Not w Is Nothing AndAlso Not w.GetType.IsSubclassOf(GetType(Wand)) Then
            Game.pushLstLog("Sighing, you stow away your wand and revert to your base form.  Heartblast Starcannon spell forgotten...")
            If p.knownSpecials.Contains("Heartblast Starcannon") Then p.knownSpecials.Remove("Heartblast Starcannon")
            p.inv.add(uniform_id, -1)

            p.perks(perk.tfedbyweapon) = -1

            p.magGState.save(p)
            p.revertToPState()
        End If
    End Sub

    Public Overrides Sub spell(ByRef p As Player, ByRef m As Entity)
        Dim dmg As Integer = a_boost
        Dim d31 = Int(Rnd() * 3)
        Dim d32 = Int(Rnd() * 4)

        m.takeDMG(dmg + d31 + d32, p)
        Game.pushLstLog(CStr("You fire off a heart-shaped blast, hitting the " & m.name & " for " & dmg + d31 + d32 & " damage!"))
        Game.pushLblCombatEvent(CStr("You fire off a heart-shaped blast, hitting the " & m.name & " for " & dmg + d31 + d32 & " damage!"))
    End Sub
End Class
