Public Class FaerieEnemy
    Inherits Monster

    Public Const BASE_NAME As String = "Faerie"

    Sub New()
        '|ID Info|
        name = BASE_NAME

        '|Stats|
        maxHealth = 55
        attack = 5
        defense = 25
        speed = 70
        will = 25

        '|Inventory|
        If Int(Rnd() * 10) = 0 Then inv.add(DitzDazeWand.ITEM_NAME, 1)
        Dim r As Integer = Int(Rnd() * 3)
        If Int(Rnd() * 5) < 2 Then inv.add(DitzyPotion.ITEM_NAME, r + 1)
        If Int(Rnd() * 3) = 0 Then inv.add(Tulip.ITEM_NAME, 1)

        '|Dialog Variables|
        pronoun = "she"
        p_pronoun = "her"
        r_pronoun = "her"

        '|Misc|
        setupMonsterOnSpawn()
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If Not target.getPlayer Is Nothing AndAlso target.getPlayer.formName.Contains("Fae") Then
            despawn("friend")
            Exit Sub
        End If


        If Not target.getPlayer Is Nothing AndAlso shouldCastSpell(target.getPlayer) Then
            castSpell(target.getPlayer)
            Exit Sub
        End If

        attackSpell(target, "Twinkle Thorn", getWIL)
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        Game.npc_list.Clear()

        Dim death_passage As String = "You collapse, unable to continue fighting." & DDUtils.RNRN &
                                      "Vines creep towards you, ensnaring your arms and legs and forcing your gaze upwards.  The faerie giggles and flits closer, sizing you up as " & p_pronoun & " prison of flora keeps you completely trapped on the forest floor." & DDUtils.RNRN &
                                      """Hmm...  What should I do with you?"" " & pronoun & " asks with a quizzical smirk, ""Too weak to make a good present for Her Majesty, too big to make a cute pet for me...""" & DDUtils.RNRN &
                                      DDUtils.capitalizeFirst(pronoun) & " lands and sits on your head, thinking for a few seconds before she suddenly hops up." & DDUtils.RNRN

        death_passage += pDeathEffect(p)

        TextEvent.push(death_passage)
    End Sub

    Protected Overridable Function pDeathEffect(ByRef p As Player) As String
        PerkEffects.faeleafHair(p)

        If p.equippedAcce.getAName.Equals(FaerieBlossom.ITEM_NAME) And p.breastSize < 7 And p.buttSize < 5 Then
            If p.breastSize < 7 Then
                p.be()
            End If

            If p.buttSize < 5 Then
                p.ue()
            End If

            p.drawPort()

            Return """Ooh, it looks like you're already someone's flower bed...  Do you think they'd mind if I did some gardening myself?"""
        End If

        EquipmentDialogBackend.equipAcce(p, FaerieBlossom.ITEM_NAME, False)

        p.drawPort()

        Return """Oh!  Someone big like you would make a sweet garden!  That's perfect! ~♥"" " & pronoun & " exclaims, flying around you in a tight spiral of twinkly dust." & DDUtils.RNRN &
               "Minty green leaves begin sprouting from your hair, and a small white flower blooms out from the new flora.  You reach up to touch your now-verdant locks, and the faerie bursts into another fit of giggles before drifting back into the woods." & DDUtils.RNRN &
               """Hey, big " & If(p.sex.Equals("Male"), "guy", "gal") & ", you look better already!  Don't forget to water yourself, ok?"""
    End Function

    Public Overridable Function shouldCastSpell(ByRef p As Player) As Boolean
        Return False
    End Function

    Public Overridable Sub castSpell(ByRef p As Player)
        attackSpell(p, "Twinkle Thorn", getWIL)
    End Sub
End Class
