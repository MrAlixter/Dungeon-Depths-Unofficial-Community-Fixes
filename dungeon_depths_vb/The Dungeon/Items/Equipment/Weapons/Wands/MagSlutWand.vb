Public Class MagSlutWand
    Inherits MagGirlWand

    Public Shadows Const ITEM_NAME As String = "​Magical_Girl_Wand​"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 171
        tier = Nothing

        '|Item Flags|
        usable = False
        cursed = True
        can_hit_flying = True
        taughtSpells = MagSlutTF.getTaughtSpells
        taughtSpecials = MagSlutTF.getTaughtSpecials

        '|Stats|
        count = 0
        value = 10
        m_boost = 20
        a_boost = 7
        uniform_id = 170

        '|Description|
        setDesc("A heart adorned wand used by a mysterious protector.  Every once in a while, if flickers with a sinister crimson aura" & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        If Not p.className.Equals("Magical Slut") And Not p.perks(perk.tfedbyweapon) > 0 Then

            Dim magicGirlTF = New MagSlutTF(2, 0, 0, False)
            magicGirlTF.update()
            p.ongoingTFs.add(magicGirlTF)

            p.perks(perk.tfcausingwand) = id
            p.perks(perk.tfedbyweapon) = 1
        End If
    End Sub
    Public Overloads Overrides Sub onUnequip(ByRef p As Player, ByRef w As Weapon)
        If (p.className.Equals("Magical Slut") Or p.perks(perk.tfedbyweapon) > 0) And (w Is Nothing OrElse Not w.GetType.IsSubclassOf(GetType(Wand))) And p.perks(perk.tfcausingwand) = id Then
            TextEvent.pushAndLog("Sighing, you stow away your wand and revert to your base form.")

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
        ElseIf (p.className.Equals("Magical Slut") Or p.perks(perk.tfedbyweapon) > 0) And p.perks(perk.tfcausingwand) > -1 And Not w Is Nothing AndAlso Not w.GetType.IsSubclassOf(GetType(Wand)) Then
            CType(p.inv.item(p.perks(perk.tfcausingwand)), MagGirlWand).onUnequip(p, w)
        End If
    End Sub

    Public Overrides Sub spell(ByRef p As Player, ByRef m As Entity)
        Dim dmg As Integer = getABoost(p)
        Dim d31 = Int(Rnd() * 5)
        Dim d32 = Int(Rnd() * 5)

        m.takeDMG(dmg + d31 + d32, p)
        TextEvent.pushAndLog(CStr("You fire off a heart-shaped blast, hitting the " & m.name & " for " & dmg + d31 + d32 & " damage!"))
    End Sub
End Class
