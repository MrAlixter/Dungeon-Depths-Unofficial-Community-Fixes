Public Class ProMagGirlWand
    Inherits MagGirlWand

    Public Shadows Const ITEM_NAME As String = "Pro_Mag._Girl_Wand"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 203
        tier = Nothing

        '|Item Flags|
        usable = False
        droppable = False
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 2000
        m_boost = 20
        d_boost = 13
        uniform_id = 201

        '|Description|
        setDesc("A mysterious wand used by a mysterious protector." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        If Not p.className.Equals("Magical Girl") And Not p.perks(perk.tfedbyweapon) > 0 Then

            Dim magicGirlTF = New ProMagGirlTF(2, 0, 0, False)
            magicGirlTF.update()
            p.ongoingTFs.add(magicGirlTF)

            p.perks(perk.tfcausingwand) = id
            p.perks(perk.tfedbyweapon) = 1

        End If
    End Sub

    Public Overrides Sub spell(ByRef p As Player, ByRef m As Entity)
        Dim dmg As Integer = a_boost
        Dim d31 = Int(Rnd() * 3)
        Dim d32 = Int(Rnd() * 4)

        m.takeDMG(dmg + d31 + d32, p)

        TextEvent.pushAndLog(CStr("You fire off a heart-shaped blast, hitting the " & m.name & " for " & dmg + d31 + d32 & " damage!"))
    End Sub
End Class
