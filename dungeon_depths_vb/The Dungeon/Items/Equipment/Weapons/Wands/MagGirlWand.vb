Public Class MagGirlWand
    Inherits Wand

    Public Const ITEM_NAME As String = "Magical_Girl_Wand"

    Protected uniform_id As Integer = 10

    Protected taughtSpells As String() = {}
    Protected taughtSpecials As String() = {}

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 11
        tier = 3

        '|Item Flags|
        usable = False
        taughtSpells = MagGirlTF.getTaughtSpells
        taughtSpecials = MagGirlTF.getTaughtSpecials

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

    Public Overrides Sub onUnequip(ByRef p As Player, ByRef w As Weapon)
        If (p.className.Equals("Magical Girl") Or p.perks(perk.tfedbyweapon) > 0) And Not w Is Nothing AndAlso Not w.GetType.IsSubclassOf(GetType(Wand)) And p.perks(perk.tfcausingwand) = id Then
            TextEvent.push("Sighing, you stow away your wand and revert to your base form.")

            p.inv.setCount(uniform_id, 0)

            For Each s In taughtSpells
                p.forgetSpell(s)
            Next

            For Each s In taughtSpecials
                If Game.cboxSpec.SelectedItem = s Then
                    Game.cboxSpec.Items.Insert(0, "-- Select --")
                    Game.cboxSpec.SelectedIndex = 0
                End If

                Do While Game.player1.knownSpecials.Contains(s)
                    Game.player1.knownSpecials.Remove(s)
                    TextEvent.pushLog(s & " special forgotten!")
                Loop
            Next

            p.perks(perk.tfedbyweapon) = -1

            p.formStates(stateInd.magGState).save(p)
            p.revertToPState()
        ElseIf (p.className.Equals("Magical Girl") Or p.perks(perk.tfedbyweapon) > 0) And Not w Is Nothing AndAlso Not w.GetType.IsSubclassOf(GetType(Wand)) Then
            CType(p.inv.item(p.perks(perk.tfcausingwand)), MagGirlWand).onUnequip(p, w)
        End If
    End Sub

    Public Overrides Sub spell(ByRef p As Player, ByRef m As Entity)
        Dim dmg As Integer = getABoost(p)
        Dim d31 = Int(Rnd() * 3)
        Dim d32 = Int(Rnd() * 4)

        m.takeDMG(dmg + d31 + d32, p)
        TextEvent.pushAndLog(CStr("You fire off a heart-shaped blast, hitting the " & m.name & " for " & dmg + d31 + d32 & " damage!"))
    End Sub
End Class
