Public Class WSmith
    Inherits ShopNPC
    Sub New()
        MyBase.New()

        '|ID Info|
        name = "Weaponsmith"
        sName = name
        npc_index = ShopNPCInd.weaponsmith

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
        local_img = New Dictionary(Of ShopNPC.LocalImgInd, Image)()

        local_img.Add(LocalImgInd.normal, ShopNPC.gbl_img.atrs(0).getAt(25))
        local_img.Add(LocalImgInd.frog, ShopNPC.gbl_img.atrs(0).getAt(4))
        local_img.Add(LocalImgInd.bunny, ShopNPC.gbl_img.atrs(0).getAt(26))
        local_img.Add(LocalImgInd.princess, ShopNPC.gbl_img.atrs(0).getAt(27))
        local_img.Add(LocalImgInd.sheep, ShopNPC.gbl_img.atrs(0).getAt(5))
        local_img.Add(LocalImgInd.doll, ShopNPC.gbl_img.atrs(0).getAt(28))
        local_img.Add(LocalImgInd.arachne, ShopNPC.gbl_img.atrs(0).getAt(71))
        local_img.Add(LocalImgInd.catgirl, ShopNPC.gbl_img.atrs(0).getAt(94))
        local_img.Add(LocalImgInd.trilobite, ShopNPC.gbl_img.atrs(0).getAt(96))
        local_img.Add(LocalImgInd.beegirl, ShopNPC.gbl_img.atrs(0).getAt(148))

        local_img.Add(LocalImgInd.alt1, ShopNPC.gbl_img.atrs(0).getAt(29))
        local_img.Add(LocalImgInd.alt2, ShopNPC.gbl_img.atrs(0).getAt(30))
        local_img.Add(LocalImgInd.alt3, ShopNPC.gbl_img.atrs(0).getAt(31))
    End Sub

    Public Overrides Sub inventoryUpdate()
        If Game.player1.quests(qInd.dfaUpgrade).getComplete Then inv.setCount(UpgradeArmor.ITEM_NAME, 1) Else inv.setCount(UpgradeArmor.ITEM_NAME, 0)
        If Game.player1.perks(perk.irondagger) > 0 Then inv.setCount(IronDagger.ITEM_NAME, 1) Else inv.setCount(IronDagger.ITEM_NAME, 0)
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        Game.fromCombat()

        Dim out As String = """Did ya ever think, like... maaaaybe you shouldn't have picked this fight?"" the Smith says, twirling her hammer in a lazy circle as you collapse to the ground.  She levels it at you, flinging a blazing spell that you are far to weak to even try to dodge." & DDUtils.RNRN &
                            "Your body begins glowing, and you feel lighter as you drift upwards.  A sleek texture creeps up your hands as they shrink inward, the light flaring until it takes up your entire field of view.  You are now a skimpy set of underwear!  As you float there, the Weaponsmith chuckles before snatching you out of the air." & DDUtils.RNRN &
                            """Aw, geez, that spell was supposed to turn ya into a set of magic tongs, must have botched it or something..."" she says, seeming genuinely suprised by the results of her handiwork.  She inspects you for a few seconds before dropping you and strolling away into the dungeon." & DDUtils.RNRN &
                            """Well, I'm sure someone will find you eventually...  Good luck, ok?"""

        p.changeClass("Thong")
        p.drawPort()
        p.UIupdate()

        TextEvent.push(out, AddressOf playerDeath2)

    End Sub
    Public Sub playerDeath2()
        Dim out As String = "Nothing but fabric, your new body flutters to the floor." & DDUtils.RNRN &
                            "GAME OVER!"

        Game.player1.changeClass("Thong​")
        Game.player1.drawPort()

        TextEvent.push(out, AddressOf Game.player1.die)
    End Sub

    '| - DIALOG - |
    Protected Overrides Function normalDialog(ByRef p As Player)
        If p.quests(qInd.dfaUpgrade).canGet Then
            p.quests(qInd.dfaUpgrade).init()
            Return ""
        End If

        If Int(Rnd() * 2) = 0 Then
            img_index = LocalImgInd.alt1
            Return "Hey stranger, how's it hanging?" & DDUtils.RNRN &
                   "I'm still getting everything moved in, but feel free to check out what I've got ready so far.  I should be operating at 100% by the time-" & DDUtils.RNRN &
                   "Wait... what year is it now?"
        ElseIf Int(Rnd() * 20) = 1 Then
            img_index = LocalImgInd.alt2
            Return "So I was working on smelting down some scrapped weapons and, uh, I think I'm cursed now." & DDUtils.RNRN &
                   "Let's make this quick so that I can track down an old friend of mine who's pretty good at dealing with this sort of stuff." & DDUtils.RNRN &
                   "Hopefully they're still around somewhere, I'd rather just stay like this than ask that shady dick of a wizard for any help..."
        Else
            img_index = LocalImgInd.normal
            Return "Hey wanderer, what's going on?" & DDUtils.RNRN &
                   "I've got enough fire magic to keep a mobile forge burning basically wherever I go.  Lets me keep my hardware fresh and hot off the anvil, ya know?  I can tell you're not just looking for something pointy though. If you want that top-shelf quality I've got a signature series of stabby stuff that's been through an quick enchanting process." & DDUtils.RNRN &
                   "Let me know what I'm banging out, ok?"
        End If
    End Function
    Protected Overrides Function bunnyDialog(ByRef p As Player)
        Return "*giggle* Let me know what you, like, need and I'll totally hop to it, cutie! *fit of giggles*"
    End Function
    Protected Overrides Function princessDialog(ByRef p As Player)
        Return "Oh my, I appear to have broken a nail." & DDUtils.RNRN &
               "I suppose it comes with the title of ""Princess of Smithery"" to get my hands dirty, but I really should still be more careful..."
    End Function
    Protected Overrides Function sheepDialog(ByRef p As Player)
        Return "..."
    End Function
    Protected Overrides Function arachneDialog(ByRef p As Player)
        If p.formName.Equals("Arachne") Then
            Return "I'm suprised more members of the sisterhood don't have any intrest in metal arms and armor.  Well, let me know if you see anything you like!"
        Else
            Return "Heeeey, you wouldn't mind drinking some of this venom, right?  I'd hate it if another arachne ate one of my best customers..."
        End If
    End Function
    Protected Overrides Function catgirlDialog(ByRef p As Player)
        Return "*purrrr*"
    End Function
    Protected Overrides Function beegirlDialog(ByRef p As Player)
        Return "..."
    End Function

    Protected Overrides Function normalFightDialog(ByRef p As Player)
        Return "Unless you're packing some serious magic, probably not your best move..."
    End Function
    Protected Overrides Function frogFightDialog(ByRef p As Player)
        Return "CROoooOOOAK!"
    End Function
    Protected Overrides Function bunnyFightDialog(ByRef p As Player)
        Return "*giggle* I'll show you just how, like, cute I am, even in a fight!"
    End Function
    Protected Overrides Function princessFightDialog(ByRef p As Player)
        Return "As a warrior princess I shall not refuse this duel...  I shall end thou rightly!"
    End Function
    Protected Overrides Function sheepFightDialog(ByRef p As Player)
        Return "*nervous bleets*"
    End Function
    Protected Overrides Function arachneFightDialog(ByRef p As Player)
        Return normalFightDialog(p)
    End Function
    Protected Overrides Function catgirlFightDialog(ByRef p As Player)
        Return normalFightDialog(p)
    End Function
    Protected Overrides Function beegirlFightDialog(ByRef p As Player)
        Return "!!!"
    End Function

    Protected Overrides Function normalSpellDialog(ByRef p As Player)
        Return "W-w-wait, don't try turning me into anything gross, ok?"
    End Function
    Protected Overrides Function frogSpellDialog(ByRef p As Player)
        Return "!!!"
    End Function
    Protected Overrides Function bunnySpellDialog(ByRef p As Player)
        Return "Woah, everything's so... shiny...."
    End Function
    Protected Overrides Function princessSpellDialog(ByRef p As Player)
        Return "You now face the ""Princess of Smithery"", mage!"
    End Function
    Protected Overrides Function sheepSpellDialog(ByRef p As Player)
        Return "!!!"
    End Function
    Protected Overrides Function arachneSpellDialog(ByRef p As Player)
        Return "Magic isn't going to get you out of this one..."
    End Function
    Protected Overrides Function catgirlSpellDialog(ByRef p As Player)
        Return normalSpellDialog(p)
    End Function
    Protected Overrides Function beegirlSpellDialog(ByRef p As Player)
        Return "!!!"
    End Function

    Public Overrides Function postPurchaseDialog(ByRef p As Player) As Object
        Return "Stay safe, yeah?"
    End Function

    '| - MISC - |
    Public Overrides Sub buildShopArea(ByRef floor As mFloor)
        MyBase.buildShopArea(floor)

        Dim crates = {New Point(pos.X - 1, pos.Y)}
        If floor.mBoard(crates(0).Y, crates(0).X).Tag = 0 Then crates(0) = New Point(pos.X, pos.Y - 1)

        Dim anvils = {New Point(pos.X + 1, pos.Y)}
        If floor.mBoard(anvils(0).Y, anvils(0).X).Tag = 0 Then anvils(0) = New Point(pos.X, pos.Y + 1)

        For Each pt In crates
            If floor.ptInBounds(pt) Then floor.mBoard(pt.Y, pt.X).Text = "¡"
        Next

        For Each pt In anvils
            If floor.ptInBounds(pt) Then floor.mBoard(pt.Y, pt.X).Text = "¶"
        Next
    End Sub
End Class
