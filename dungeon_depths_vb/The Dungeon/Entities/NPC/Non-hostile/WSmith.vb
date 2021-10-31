Public Class WSmith
    Inherits ShopNPC
    Sub New()
        MyBase.New()

        '|ID Info|
        name = "Weaponsmith"
        sName = name
        npc_index = sNPCInd.weaponsmith

        '|NPC Flags|
        pronoun = "she"
        p_pronoun = "her"
        r_pronoun = "her"
        isShop = True

        '|Inventory|
        inv.setCount("Spiked_Staff", 1)
        inv.setCount("Throwing_Knife", 1)
        'Signature weapons
        inv.setCount("Signature_Spear", 1)
        inv.setCount("Signature_Staff", 1)
        inv.setCount("Signature_Dagger", 1)
        inv.setCount("Signature_Whip", 1)
        'Flaming weapons
        inv.setCount("Flaming_Spear", 1)
        inv.setCount("Flaming_Sword", 1)
        'Accursed weapons
        inv.setCount("Accursed_Blade", 1)
        inv.setCount("Bewitched_Wand", 1)
        inv.setCount("Jinxed_Whip", 1)



        '|Stats|
        maxHealth = 99
        attack = 9999
        defense = 9999
        will = 9
        speed = 99
        gold = 99999
        xp_value = (maxHealth + attack + defense + speed) / 4
        sMaxHealth = maxHealth
        sMaxMana = maxMana
        sAttack = attack
        sdefense = defense
        sWill = will
        sSpeed = speed

        '|Images|
        picNormal = ShopNPC.npcLib.atrs(0).getAt(25)
        picPrincess = ShopNPC.npcLib.atrs(0).getAt(27)
        picBunny = ShopNPC.npcLib.atrs(0).getAt(26)
        picArachne = ShopNPC.npcLib.atrs(0).getAt(71)

        picNPC = New List(Of Image)
        picNPC.AddRange({picNormal,
                         ShopNPC.npcLib.atrs(0).getAt(4),
                         ShopNPC.npcLib.atrs(0).getAt(5),
                         picPrincess,
                         picBunny})

        picNPC.AddRange({ShopNPC.npcLib.atrs(0).getAt(29),
                         ShopNPC.npcLib.atrs(0).getAt(30),
                         ShopNPC.npcLib.atrs(0).getAt(31),
                         ShopNPC.npcLib.atrs(0).getAt(28),
                         picArachne,
                         ShopNPC.npcLib.atrs(0).getAt(94),
                         ShopNPC.npcLib.atrs(0).getAt(96)})


    End Sub

    Public Overrides Sub encounter()
        MyBase.encounter()

        discount = 0

        If Game.player1.quests(qInds.dfaUpgrade).getComplete Then
            inv.setCount("Upgrade_Armor", 1)
        Else
            inv.setCount("Upgrade_Armor", 0)
        End If

        If img_index = 0 Then
            If Game.player1.quests(qInds.dfaUpgrade).canGet Then Game.player1.quests(qInds.dfaUpgrade).init() : Exit Sub

            If Int(Rnd() * 2) = 0 Then
                img_index = 5
                TextEvent.pushNPCDialog("Hey stranger, how's it hanging?" & DDUtils.RNRN &
                                   "I'm still getting everything moved in, but feel free to check out what I've got ready so far.  I should be operating at 100% by the time- uh, wait... what year is it now?")
            ElseIf Int(Rnd() * 20) = 1 Then
                img_index = 6
                TextEvent.pushNPCDialog("So I was working on smelting down some scrapped weapons and, uh, I think I'm cursed now." & DDUtils.RNRN &
                                   "Let's make this quick so that I can track down an old friend of mine who's pretty good at dealing with this sort of stuff." & DDUtils.RNRN &
                                   "Hopefully they're still around somewhere, because I'd rather just stay like this than ask that shady dick of a wizard for any help...")
            Else
                TextEvent.pushNPCDialog("Hey wanderer, what's going on?" & DDUtils.RNRN &
                                   "I've got enough fire magic to keep a mobile forge burning basically wherever I go.  Lets me keep my hardware fresh and hot off the anvil, ya know?  I can tell you're not just looking for something pointy though. If you want that top-shelf quality I've got a signature series of stabby stuff that's been through an quick enchanting process." & DDUtils.RNRN &
                                   "Let me know what I'm banging out, ok?")
            End If
        ElseIf img_index = 1 Then
            TextEvent.pushNPCDialog("...")
        ElseIf img_index = 2 Then
            TextEvent.pushNPCDialog("...")
        ElseIf img_index = 3 Then
            TextEvent.pushNPCDialog("Oh my, I appear to have broken a nail.  I suppose it comes with the title of ""Princess of Smithery"" to get my hands dirty, but I really should still be more careful...")
        ElseIf img_index = 4 Then
            TextEvent.pushNPCDialog("*giggle* Let me know what you, like, need and I'll totally hop to it, cutie! *fit of giggles*")
        ElseIf img_index = 7 Or img_index = 11 Then
            TextEvent.pushNPCDialog("...")
        ElseIf img_index = 9 Then
            If Game.player1.formName.Equals("Arachne") Then
                TextEvent.pushNPCDialog("I'm suprised more members of the sisterhood don't have any intrest in metal arms and armor.  Well, let me know if you see anything you like!")
            Else
                TextEvent.pushNPCDialog("Heeeey, you wouldn't mind drinking some of this venom, right?  I'd hate if another arachne ate one of my best customers...")
            End If
        ElseIf img_index = 10 Then
            TextEvent.pushNPCDialog("Hey, what's up? *nya*")
        End If

        If img_index = getArachneImageInd() And Not Game.player1.formName.Equals("Arachne") Then inv.setCount(244, 1) Else inv.setCount(244, 0)

        Game.picNPC.BackgroundImage = picNPC(img_index)
    End Sub

    Public Overrides Function toFight() As String
        If img_index = 0 Or img_index = 9 Or img_index = 10 Then
            Return "Unless you're packing some serious magic, probably not your best move..."
        ElseIf img_index = 1 Then
            Return "CROoooOOOAK!"
        ElseIf img_index = 2 Then
            Return "*nervous bleets*"
        ElseIf img_index = 3 Then
            Return "As a warrior princess I shall not refuse this duel...  I shall end thou rightly!"
        ElseIf img_index = 4 Then
            Return "*giggle* I'll show you just how, like, cute I am, even in a fight!"
        ElseIf img_index = 7 Or img_index = 11 Then
            Return "..."
        End If
        Return "Unless you're packing some serious magic, probably not your best move..."
    End Function
    Public Overrides Function hitBySpell() As String
        If img_index = 0 Or img_index = 10 Then
            Game.NPCtoCombat(Me)
            Return "W-w-wait, don't try turning me into anything gross, ok?"
        ElseIf img_index = 1 Then
            Game.NPCtoCombat(Me)
            Return "!!!"
        ElseIf img_index = 2 Then
            Game.NPCtoCombat(Me)
            Return "!!!"
        ElseIf img_index = 3 Then
            Return "You now face the ""Princess of Smithery"", mage!"
        ElseIf img_index = 4 Then
            Return "Woah, everything's so...shiny...."
        ElseIf img_index = 7 Or img_index = 11 Then
            Return "..."
        ElseIf img_index = 9 Then
            Game.NPCtoCombat(Me)
            Return "Magic isn't going to get you out of this one..."
        End If

        Game.NPCtoCombat(Me)
        Return "W-w-wait, don't try turning me into anything gross, ok?"
    End Function

    Public Overrides Function getArachneImageInd() As Integer
        Return 9
    End Function
    Public Overrides Function getCatgirlImageInd() As Integer
        Return 10
    End Function
    Public Overrides Function getTrilobiteImageInd() As Integer
        Return 11
    End Function

    Public Overrides Sub toDoll()
        TextEvent.pushNPCDialog("...")
        Game.picNPC.BackgroundImage = picNPC(7)

        discount = 0.5
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        Game.fromCombat()

        Dim out As String = """Did ya ever think, like... maaaaybe you shouldn't have picked this fight?"" the Smith says, twirling her hammer in a lazy circle as you collapse to the ground.  She levels it at you, flinging a blazing spell that you are far to weak to even try to dodge." & DDUtils.RNRN &
                            "Your body begins glowing, and you feel lighter as you drift upwards.  A sleek texture creeps up your hands as they shrink inward, the light flaring until it takes up your entire field of view.  You are now a skimpy set of underwear!  As you float there, the Weaponsmith chuckles before snatching you out of the air." & DDUtils.RNRN &
                            """Aw, geez, that spell was supposed to turn ya into a set of magic tongs, must have botched it or something..."" she says, seeming genuinely suprised by the results of her handiwork.  She inspects you for a few seconds before dropping you and strolling away into the dungeon." & DDUtils.RNRN &
                            """Well, I'm sure someone will find you eventually...  Good luck, ok?"""

        p.changeClass("Thong")
        p.drawPort()

        TextEvent.push(out, AddressOf playerDeath2)

    End Sub
    Public Sub playerDeath2()

        Dim out As String = "Nothing but fabric, your new body flutters to the floor." & DDUtils.RNRN &
                            "GAME OVER!"

        Game.player1.changeClass("Thong​")
        Game.player1.drawPort()

        TextEvent.push(out, AddressOf Game.player1.die)

    End Sub
End Class
