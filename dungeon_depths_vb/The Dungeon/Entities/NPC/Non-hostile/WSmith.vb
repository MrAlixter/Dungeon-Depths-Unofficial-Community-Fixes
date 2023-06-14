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
        inv.setCount(SpikedStaff.ITEM_NAME, 1)
        inv.setCount(TKnife.ITEM_NAME, 1)
        'Signature weapons
        inv.setCount(SigSpear.ITEM_NAME, 1)
        inv.setCount(SigStaff.ITEM_NAME, 1)
        inv.setCount(SigDagger.ITEM_NAME, 1)
        inv.setCount(SigWhip.ITEM_NAME, 1)
        'Flaming weapons
        inv.setCount(FlamingSword.ITEM_NAME, 1)
        inv.setCount(FlamingSpear.ITEM_NAME, 1)
        'Accursed weapons
        inv.setCount(CursedSword.ITEM_NAME, 1)
        inv.setCount(BewitchedWand.ITEM_NAME, 1)
        inv.setCount(JinxedWhip.ITEM_NAME, 1)

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
        local_img.Add(LocalImgInd.bimbo, ShopNPC.gbl_img.atrs(0).getAt(157))
        local_img.Add(LocalImgInd.alt1, ShopNPC.gbl_img.atrs(0).getAt(29))
        local_img.Add(LocalImgInd.alt2, ShopNPC.gbl_img.atrs(0).getAt(30))
        local_img.Add(LocalImgInd.alt3, ShopNPC.gbl_img.atrs(0).getAt(31))
    End Sub

    Public Overrides Sub inventoryUpdate()
        If Game.player1.quests(qInd.dfaUpgrade).getComplete Then inv.setCount(UpgradeArmor.ITEM_NAME, 1) Else inv.setCount(UpgradeArmor.ITEM_NAME, 0)
        If Game.player1.perks(perk.irondagger) > 0 Then inv.setCount(IronDagger.ITEM_NAME, 1) Else inv.setCount(IronDagger.ITEM_NAME, 0)

        If Game.mDun.getWorldFlag(wFlag.mechavalkyrie) > 0 Then inv.setCount(UpgradeValkyrieSword.ITEM_NAME, 1) Else inv.setCount(UpgradeValkyrieSword.ITEM_NAME, 0)
        If Game.mDun.getWorldFlag(wFlag.hellfiresword) > 0 Then inv.setCount(SellHellfireBlade.ITEM_NAME, 1) Else inv.setCount(SellHellfireBlade.ITEM_NAME, 0)
        If Game.mDun.getWorldFlag(wFlag.berserkercmark) > 0 Then inv.setCount(BerserkerCursemark.ITEM_NAME, 1) Else inv.setCount(BerserkerCursemark.ITEM_NAME, 0)
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

    '| - WEAPON UPGRADES - |
    Protected Sub askValkyrieQuestion()
        Dim reason1 = New Tuple(Of String, Action)("Drain on stamina", AddressOf valkyrieResponse)
        Dim reason2 = New Tuple(Of String, Action)("Locked equipment", AddressOf valkyrieResponse)
        Dim reason3 = New Tuple(Of String, Action)("I don't like birds", AddressOf valkyrieResponse)

        TextEvent.pushManySelect("The worst part about being a valkyrie?", reason1, reason2, reason3)
    End Sub
    Protected Sub valkyrieResponse()
        Objective.showNPC(local_img(LocalImgInd.alt3), "The weaponsmith doesn't seem to be listening." & DDUtils.RNRN &
                                                       """Exactly right, no mechanical eyes.  Armor that doesn't have energy shields.  The total lack of attachment points for anything, much less some sort of tiny cannon." & DDUtils.RNRN &
                                                       "Lucky for you, I've got some ideas on how to fix that.  Well, as long as you've got the parts.""" & DDUtils.RNRN &
                                                       "Upgrade_Valkyrie_Sword service is now availible for sale!")

        Game.mDun.world_flags(wFlag.mechavalkyrie) = 1
    End Sub
    Protected Sub hellfireBlade()
        Objective.showNPC(local_img(LocalImgInd.alt3), "The weaponsmith gestures, and you toss over the book." & DDUtils.RNRN &
                                                       """This is a succubus spellbook, right?  Rumor has it that they've worked out a type of flame that burns hotter as... um, well, as you do." & DDUtils.RNRN &
                                                       "I could probably work that into a better flaming sword, as long as you've got some sort of fuel that's charged with succubus energy.""" & DDUtils.RNRN &
                                                       "Hellfire_Sword is now availible for sale!")

        Game.mDun.world_flags(wFlag.hellfiresword) = 1
    End Sub
    Protected Sub berserkerMark()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(76), """Oh, it'll definitely work alright..."" Cynn says, looking over a scrawled parchment diagram." & DDUtils.RNRN &
                                                       """It's just that part of it working involves getting rid of your mana reserves.  Soooo, I'm not putting this thing on myself.""" & DDUtils.RNRN &
                                                       "She hands the diagram to the other redhead, who accepts it back with a sigh." & DDUtils.PAKTC, AddressOf berserkerMark2)
    End Sub
    Protected Sub berserkerMark2()
        Objective.showNPC(local_img(LocalImgInd.alt1), """Yeah, that's what I was worried about.  I don't think I want it on me either-""" & DDUtils.RNRN &
                                                       "Both women jolt slightly as they notice your presence, and after a quick exchange of glances the weaponsmith turns back to you." & DDUtils.RNRN &
                                                       """Hey, wanderer!  How do you feel about tattoos and ATK points?""" & DDUtils.RNRN &
                                                       "Berserker_Cursemark is now availible for sale!")

        Game.mDun.world_flags(wFlag.berserkercmark) = 1
    End Sub

    '| - DIALOG - |
    Protected Function normDialogValkyrieUpgrade(ByRef p As Player) As String
        img_index = LocalImgInd.alt3

        If Game.shop_npc_engaged Then Game.hideNPCButtons()
        Game.npc_list.Clear()
        Game.shop_npc_engaged = False

        TextEvent.lblEventOnClose = AddressOf askValkyrieQuestion

        Return """Hmm..." & DDUtils.RNRN &
               "Hey wanderer... what do you think the worst part about being a valkyrie is?""" & DDUtils.RNRN &
               "Press any non-command key to continue."
    End Function
    Protected Function normDialogHellfireBlade(ByRef p As Player) As String
        img_index = LocalImgInd.alt3

        If Game.shop_npc_engaged Then Game.hideNPCButtons()
        Game.npc_list.Clear()
        Game.shop_npc_engaged = False

        TextEvent.lblEventOnClose = AddressOf hellfireBlade

        Return """Hmm..." & DDUtils.RNRN &
               "Hey wanderer... where'd you get that crimson spellbook?""" & DDUtils.RNRN &
               "Press any non-command key to continue."
    End Function
    Protected Function normDialogBerserkerMark(ByRef p As Player) As String
        img_index = LocalImgInd.alt3

        Game.picNPC.Visible = False
        If Game.shop_npc_engaged Then Game.hideNPCButtons()
        Game.npc_list.Clear()
        Game.shop_npc_engaged = False

        Application.DoEvents()

        TextEvent.lblEventOnClose = AddressOf berserkerMark

        Return "As you approach the weaponsmith, you find her conversing with a familiar demon..."
    End Function
    Protected Overrides Function normalDialog(ByRef p As Player)
        If p.quests(qInd.dfaUpgrade).canGet Then
            p.quests(qInd.dfaUpgrade).init()
            Return ""
        End If

        If p.equippedWeapon.getAName = "Fists" Then
            img_index = LocalImgInd.alt3
            Return "Heeeey... buddy..." & DDUtils.RNRN &
                   "Need something... stabby?  Or with spikes?" & DDUtils.RNRN &
                   "Let's get you a decent weapon before someone gets hurt."
        ElseIf hasMetPlayer AndAlso Game.mDun.getWorldFlag(wFlag.mechavalkyrie) < 0 AndAlso p.inv.getCountAt(ValkyrieSword.ITEM_NAME) > 0 AndAlso (p.inv.getCountAt(PhotonBlade.ITEM_NAME) > 0 Or p.inv.getCountAt(PhotonArmor.ITEM_NAME) > 0 Or p.inv.getCountAt(PhotonBikini.ITEM_NAME) > 0) Then
            Return normDialogValkyrieUpgrade(p)
        ElseIf hasMetPlayer AndAlso Game.mDun.getWorldFlag(wFlag.hellfiresword) < 0 AndAlso p.inv.getCountAt(CSpellbook.ITEM_NAME) > 0 And p.inv.getCountAt(SuccubusGarb.ITEM_NAME) > 0 Then
            Return normDialogHellfireBlade(p)
        ElseIf hasMetPlayer AndAlso p.quests(qInd.darkPact).getComplete AndAlso Game.mDun.getWorldFlag(wFlag.berserkercmark) < 0 Then
            Return normDialogBerserkerMark(p)
        ElseIf Int(Rnd() * 2) = 0 Then
            img_index = LocalImgInd.alt1
            Return "Hey stranger, what can I getcha?" & DDUtils.RNRN &
                   "I've got swords, and spears, and- um, a box of knives.  Maybe some whips?" & DDUtils.RNRN &
                   "I make and sell weapons, mostly." & DDUtils.RNRN &
                   "Let me know if you see anything that catches your eye, ok?" & DDUtils.RNRN &
                   "While you're browsing, I'll be putting the grind on an axe."
        ElseIf Int(Rnd() * 20) = 1 And hasMetPlayer Then
            img_index = LocalImgInd.alt2
            Return "So I was working on smelting down some scrapped weapons and- um, I think I'm cursed now." & DDUtils.RNRN &
                   "Let's make this quick so that I can track down an old friend of mine who's pretty good at dealing with this sort of stuff." & DDUtils.RNRN &
                   "Hopefully they're still around somewhere, I'd rather just stay like this than ask that shady dick of a wizard for any help..."
        Else
            img_index = LocalImgInd.normal
            Return "Hey wanderer, do you like fire?" & DDUtils.RNRN &
                   "I'm more of a blacksmith than a mage, but the crackling glow of pyromancy was just too bright to ignore.  It also lets me keep a forge burning anywhere I go, even rookie-tier magic has been pretty handy around the shop." & DDUtils.RNRN &
                   "'Course on the the other hand, there's- uh, that box of- um, not cursed weapons.  Not cursed and just unusually effective, yeah..." & DDUtils.RNRN &
                   "Anyways, let me know if you need something banged out!"
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
    Protected Overrides Function bimboDialog(ByRef p As Player)
        Return "*giggle*" & DDUtils.RNRN &
               "Hey, um, let me know what you, like, ya know..." & DDUtils.RNRN &
               "Let me know if anyone that catches your eye, ok?"
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
    Protected Overrides Function bimboFightDialog(ByRef p As Player)
        Return bunnyFightDialog(p)
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
    Protected Overrides Function bimboSpellDialog(ByRef p As Player)
        Return bunnySpellDialog(p)
    End Function

    Protected Overrides Function normalPostPurchaseDialog(ByRef p As Player) As String
        Return "Stay safe, yeah?"
    End Function
    Protected Overrides Function bimboPostPurchaseDialog(ByRef p As Player) As String
        Return "Um... be careful, ok?"
    End Function

    '| - MISC - |
    Public Overrides Sub buildShopArea(ByRef floor As mFloor)
        MyBase.buildShopArea(floor)

        Dim crates = {New Point(pos.X - 1, pos.Y)}
        If floor.ptInBounds(crates(0)) AndAlso floor.mBoard(crates(0).Y, crates(0).X).Tag = 0 Then crates(0) = New Point(pos.X, pos.Y - 1)

        Dim anvils = {New Point(pos.X + 1, pos.Y)}
        If floor.ptInBounds(anvils(0)) AndAlso floor.mBoard(anvils(0).Y, anvils(0).X).Tag = 0 Then anvils(0) = New Point(pos.X, pos.Y + 1)

        For Each pt In crates
            If floor.ptInBounds(pt) Then floor.mBoard(pt.Y, pt.X).Text = "¡"
        Next

        For Each pt In anvils
            If floor.ptInBounds(pt) Then floor.mBoard(pt.Y, pt.X).Text = "¶"
        Next
    End Sub
End Class
