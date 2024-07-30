Public Class EnthSorc
    Inherits Monster

    Public Const BASE_NAME As String = "Enthralling Sorcerer"

    Sub New()
        Dim rng = Int(Rnd() * 2)

        '|ID Info|
        If rng = 0 Then
            name = BASE_NAME
        Else
            name = "Enthralling Sorceress"
        End If

        '|Stats|
        maxHealth = 150
        attack = 40
        defense = 17
        speed = 20
        will = 15

        '|Inventory|
        setInventory({4, 13})

        '|Dialog Variables|
        If rng = 0 Then
            pronoun = "he"
            p_pronoun = "his"
            r_pronoun = "him"
        Else
            pronoun = "she"
            p_pronoun = "her"
            r_pronoun = "her"
        End If

        '|Misc|
        setupMonsterOnSpawn()
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        attackSpell(target, "a bolt of black lightning", getATK)
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        despawn("p-death")

        '| - Cases where the player should not be collared - |
        If p.formName.Equals("Blowup Doll") Or p.formName.Equals("Cake") Or p.formName.Equals("Frog") Or p.formName.Equals("Horse") Or p.formName.Equals("Unicorn") Or p.formName.Equals("Cow") Then
            TextEvent.push("Your enemy sees your pitiful state and leaves you be, deciding that you aren't useful to " & p_pronoun & " cause...")
            Exit Sub
        End If

        If p.className.Equals("Thrall") Or p.equippedAcce.getCursed(p) Then
            TextEvent.push("Despite your fatigue, you are able to roll out of the way of the hostile " & If(pronoun.Equals("he"), "sorcerer", "sorceress") & "'s grasp...")
            Exit Sub
        End If

        If p.passDieRoll(8, 5) Then
            TextEvent.pushLog("The " & If(pronoun.Equals("he"), "sorcerer", "sorceress") & " snaps " & p_pronoun & " fingers, dropping you into a trance!  -2 WIL.")
            Game.player1.will -= 2
            Game.player1.UIupdate()

            ThrallTF.collarlessThallTF(Game.player1)
            Game.player1.drawPort()

            Dim possible_desired_classes As List(Of String) = {"Warrior", "Mage", "Rogue", "Cleric", "Dancer", "Paladin", "Necromancer", "Barbarian"}.ToList
            If possible_desired_classes.Contains(p.className) Then possible_desired_classes.Remove(p.className)
            TextEvent.push("""Ah, what a victory!"", your opponent exclaims as you collapse, defeated. ""Don't worry, I'm sure you'll make a perfect slave...""" & DDUtils.RNRN &
                           DDUtils.capitalizeFirst(pronoun) & " pauses for a bit, clasping your cheeks tenderly...  ""Mmm... maybe not...""" & DDUtils.RNRN &
                           """Really I was looking for more of a... " & possible_desired_classes(Int(Rnd() * possible_desired_classes.Count)) & "..."" your opponent say, pensively, ""Still, it would be a waste to discard such a pathetic foe...""" & DDUtils.RNRN &
                           "SNAP!" & DDUtils.RNRN &
                           "Your mind goes blank in an instant, and your surroundings fade away into unimportantance.", AddressOf thrallFleeP2)
            Exit Sub
        End If

        '| - Main player death case - |
        p.inv.add(ThrallCollar.ITEM_NAME, 1)
        EquipmentDialogBackend.equipAcce(p, ThrallCollar.ITEM_NAME)

        p.health = 1.0
        p.mana = p.getMaxMana()
        p.will -= 3
        p.UIupdate()

        p.prefForm.snapShift(p)

        TextEvent.pushLog("The " & If(pronoun.Equals("he"), "sorcerer", "sorceress") & " snaps a collar around your neck, enslaving you to " & p_pronoun & " will!  -3 WIL.")
        TextEvent.push("""Ah, what a victory!"", your opponent exclaims as you collapse, defeated. ""Don't worry, I'm sure you'll make a perfect slave...""" & DDUtils.RNRN &
                       "Effortlessly, " & pronoun & " levitates a small metal collar from under " & p_pronoun & " cloak and clamps it around your neck.  " & DDUtils.capitalizeFirst(pronoun) & " struts closer, raising you up by the chin to your knees." & DDUtils.RNRN &
                       "With a sadistic smirk, " & pronoun & " places a finger on your forehead and, with a short incantation, wracks you with a surge of magic electricity.  You writhe at " & p_pronoun & " fingertip as your form twists and changes, an array of runes igniting along the length of the collar." & DDUtils.RNRN &
                       "After a few moments, your transformation slows down and your " & If(pronoun.Equals("he"), "master", "mistress") & " withdraws " & p_pronoun & " hand, seemingly satisfied with your new appearance." & DDUtils.RNRN &
                       "Wait... your " & If(pronoun.Equals("he"), "master", "mistress") & "?!  Before you have the chance to question any further, " & getNameWithTitle() & " gleefully raises " & p_pronoun & " other hand and..." & DDUtils.RNRN &
                       "SNAP!" & DDUtils.RNRN &
                       "Your mind goes blank in an instant, and your surroundings fade away into unimportantance.", AddressOf thrallLN2)
    End Sub
    Private Sub thrallLN2()
        TextEvent.push("""LISTEN UP, NEW SLAVE!"" your new master commands," & DDUtils.RNRN &
                       """In this dungeon, there is a cluster of arcane glyph arrays scrawled into magic gemstones.  Rumor has it that one amongst them is capable of bestowing the power of a demon lord onto whomever activates it." & DDUtils.RNRN &
                       "Your sole purpose is now to find and inspect as many of these arrays as you can, and to report back to me with your findings.""" & DDUtils.RNRN &
                       "Arcs of black lightning crackle across your body, and you jolt to your feet as " & pronoun & " continues," & DDUtils.RNRN &
                       """I'm sure you won't let me down, especially now that I've made a few changes to keep you- hmm... uniform... with the rest of my minions.""", AddressOf thrallLN3)
    End Sub
    Private Sub thrallLN3()
        Dim ptype = If(pronoun.Equals("he"), "master", "mistress")

        TextEvent.push("With a final warning not to fail them, " & getNameWithTitle() & " pats you on the head and teleports away." & DDUtils.RNRN &
                       "Once again you are alone in the dungeon, left with your tainted thoughts and your " & ptype & "'s task.")
    End Sub

    Private Sub thrallFleeP2()
        TextEvent.push("You fall to the ground, and your " & If(pronoun.Equals("he"), "master", "mistress") & " orders that you serve as a chair." & DDUtils.TODO, AddressOf thrallFleeP3)
    End Sub
    Private Sub thrallFleeP3()
        TextEvent.push("With a final condecending laugh, " & getNameWithTitle() & " pats you on the head and teleports away." & DDUtils.RNRN &
                       "You get up and dust yourself off, once again you are alone in the dungeon.")
    End Sub
End Class
