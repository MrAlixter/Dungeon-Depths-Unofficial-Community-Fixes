Public Class NamestealerFaerie
    Inherits FaerieEnemy

    Public Shadows Const BASE_NAME As String = "Namestealer Faerie"

    Private deducedName As String = ""
    Private testedName As Boolean = False

    Sub New()
        '|ID Info|
        name = BASE_NAME

        '|Stats|
        maxHealth = 60
        attack = 5
        defense = 20
        speed = 60
        will = 35

        '|Inventory|
        Dim r As Integer = Int(Rnd() * 3)
        inv.add(VialOfManyNames.ITEM_NAME, r + 1)
        If Int(Rnd() * 3) = 0 Then inv.add(Tulip.ITEM_NAME, 1)

        '|Dialog Variables|
        pronoun = "she"
        p_pronoun = "her"
        r_pronoun = "her"

        '|Misc|
        setupMonsterOnSpawn()
    End Sub

    Protected Overrides Function pDeathEffect(ByRef p As Player) As String
        PerkEffects.faeleafHair(p)

        If p.equippedAcce.getAName.Equals(FaerieBlossom.ITEM_NAME) And p.breastSize < 7 And p.buttSize < 5 Then
            If p.breastSize < 7 Then
                p.be()
            End If

            If p.buttSize < 5 Then
                p.ue()
            End If

            Return """Ooh, it looks like you're already someone's flower bed...  Do you think they'd mind if I did some gardening myself?"""
        End If

        EquipmentDialogBackend.equipAcce(p, FaerieBlossom.ITEM_NAME, False)

        p.drawPort()

        Return """Oh!  Someone big like you would make a sweet garden!  That's perfect! ~♥"" " & pronoun & " exclaims, flying around you as she sprinkles a fine mist of twinkly dust over your person." & DDUtils.RNRN &
               "Minty green leaves begin sprouting from your hair, and a small white flower blooms out from the new flora.  You reach up to touch your now-verdant locks, and the faerie bursts into another fit of giggles before drifting back into the woods." & DDUtils.RNRN &
               """Hey, big " & If(p.sex.Equals("Male"), "guy", "gal") & ", you look better already!  Don't forget to water yourself, ok?"""
    End Function

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If deducedName.Equals(target.name) And Not testedName Then
            TextEvent.push("""" & DDUtils.capitalizeFirst(target.name) & ", " & DDUtils.capitalizeFirst(target.name) & ", huh?  If you're really " & DDUtils.capitalizeFirst(target.name) & "..."" says the " & BASE_NAME & ", ""... take off your clothes!""")
            TextEvent.pushLog(DDUtils.capitalizeFirst(getNameWithTitle) & " tests the name " & pronoun & " deduced...")

            Game.player1.nextCombatAction = AddressOf PerkEffects.namestealerStun

            testedName = True

            Exit Sub
        ElseIf deducedName.Equals(target.name) Then
            Game.fromCombat()
            TextEvent.push("The " & BASE_NAME & " cackles maniacally." & DDUtils.RNRN &
                           """" & target.getName.ToUpper & "!  BOW TO YOUR NEW GODDESS!""", AddressOf pDeath)
            Exit Sub
        End If

        MyBase.attackCMD(target)
    End Sub

    Private Sub pDeath()
        Game.player1.die(Me)
    End Sub

    Public Overrides Function shouldCastSpell(ByRef p As Player) As Boolean
        Return tfCt < 1 And Game.turn Mod 2 = 0
    End Function

    Public Overrides Sub castSpell(ByRef p As Player)
        Dim deduction = p.name.Substring(deducedName.Length, Math.Min(2, p.name.Length - deducedName.Length))

        If p.perks(perk.vofmanynames) > 0 Then
            Dim falseDeduction = DDUtils.rndAlpha & DDUtils.rndAlpha

            While falseDeduction.Equals(deduction)
                falseDeduction = DDUtils.rndAlpha & DDUtils.rndAlpha
            End While

            TextEvent.push(DDUtils.capitalizeFirst(getNameWithTitle) & " casts True-Name Clairvoyance!  " & DDUtils.capitalizeFirst(pronoun) & " learned that your name contains """ & falseDeduction & """" & DDUtils.RNRN &
                           """Nah, that isn't right...""")
            TextEvent.pushLog(DDUtils.capitalizeFirst(getNameWithTitle) & " casts True-Name Clairvoyance!")

            p.perks(perk.vofmanynames) -= 1

            Exit Sub
        ElseIf p.perks(perk.vofmanynames) <> -1 Then
            p.perks(perk.vofmanynames) = -1
        End If

        TextEvent.push(DDUtils.capitalizeFirst(getNameWithTitle) & " casts True-Name Clairvoyance!  " & DDUtils.capitalizeFirst(pronoun) & " learned that your name contains """ & deduction & """")
        TextEvent.pushLog(DDUtils.capitalizeFirst(getNameWithTitle) & " casts True-Name Clairvoyance!")

        deducedName += deduction
    End Sub
End Class
