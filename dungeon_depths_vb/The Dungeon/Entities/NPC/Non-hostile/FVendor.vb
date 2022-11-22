Public Class FVendor
    Inherits ShopNPC
    Sub New()
        MyBase.New()

        '|ID Info|
        name = "Food Vendor"
        sName = name
        npc_index = ShopNPCInd.foodvendor

        '|NPC Flags|
        pronoun = "he"
        p_pronoun = "his"
        r_pronoun = "him"
        isShop = True

        '|Inventory|
        inv.setCount("Chicken_Leg", 1)
        inv.item("Chicken_Leg").value -= 0.2 * inv.item("Chicken_Leg").value
        inv.setCount("Apple", 1)
        inv.item("Apple").value -= 0.2 * inv.item("Apple").value
        inv.setCount("Heavy_Cream", 1)
        inv.item("Heavy_Cream").value -= 0.2 * inv.item("Heavy_Cream").value
        inv.setCount("Medicinal_Tea", 1)
        inv.item("Medicinal_Tea").value -= 0.2 * inv.item("Medicinal_Tea").value
        inv.setCount("Panacea", 1)
        inv.setCount("Cherry_Stick_of_Gum", 1)
        inv.setCount("Mint_Stick_of_Gum", 1)
        inv.setCount("Spatial_Shroom", 1)
        inv.setCount("Garden_Salad", 1)
        inv.setCount("Warrior's_Feast", 1)
        inv.setCount("Mage's_Delicacy", 1)
        inv.setCount("Tavern_Special", 1)

        '|Stats|
        maxHealth = 9999
        attack = 999
        defense = 99
        speed = 99
        will = 99
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

        local_img.Add(LocalImgInd.normal, ShopNPC.gbl_img.atrs(0).getAt(11))
        local_img.Add(LocalImgInd.frog, ShopNPC.gbl_img.atrs(0).getAt(4))
        local_img.Add(LocalImgInd.bunny, ShopNPC.gbl_img.atrs(0).getAt(12))
        local_img.Add(LocalImgInd.princess, ShopNPC.gbl_img.atrs(0).getAt(13))
        local_img.Add(LocalImgInd.sheep, ShopNPC.gbl_img.atrs(0).getAt(5))
        local_img.Add(LocalImgInd.doll, ShopNPC.gbl_img.atrs(0).getAt(14))
        local_img.Add(LocalImgInd.arachne, ShopNPC.gbl_img.atrs(0).getAt(69))
        local_img.Add(LocalImgInd.catgirl, ShopNPC.gbl_img.atrs(0).getAt(92))
        local_img.Add(LocalImgInd.trilobite, ShopNPC.gbl_img.atrs(0).getAt(96))
        local_img.Add(LocalImgInd.beegirl, ShopNPC.gbl_img.atrs(0).getAt(148))
        local_img.Add(LocalImgInd.alt1, ShopNPC.gbl_img.atrs(0).getAt(15))
        local_img.Add(LocalImgInd.alt2, ShopNPC.gbl_img.atrs(0).getAt(16))
        local_img.Add(LocalImgInd.alt3, ShopNPC.gbl_img.atrs(0).getAt(23))
        local_img.Add(LocalImgInd.alt4, ShopNPC.gbl_img.atrs(0).getAt(61))
        local_img.Add(LocalImgInd.alt5, ShopNPC.gbl_img.atrs(0).getAt(104))
    End Sub

    Public Overrides Sub encounter()
        'If the food vendor has the sword, use the alternate food vendor character

        If Game.player1.perks(perk.fvHasSword) > 0 Then
            Dim fvt = New FVendorTar(Me)
            Game.active_shop_npc = fvt
            fvt.encounter()
            Exit Sub
        End If

        MyBase.encounter()
    End Sub

    Public Overrides Sub inventoryUpdate()
        If Game.currFloor.floorNumber = 13 Then
            inv.setCount("Chicken_Leg", 0)
            inv.setCount("Warrior's_Feast", 0)
            inv.setCount("Mage's_Delicacy", 0)
            inv.setCount("Tavern_Special", 0)
        Else
            inv.setCount("Chicken_Leg", 1)
            inv.setCount("Warrior's_Feast", 1)
            inv.setCount("Mage's_Delicacy", 1)
            inv.setCount("Tavern_Special", 1)
        End If

        If img_index = LocalImgInd.alt2 Then
            inv.setCount(98, 1)
        Else
            inv.setCount(98, 0)
        End If
    End Sub

    '| - COMBAT - |
    Public Overrides Sub playerDeath(ByRef p As Player)
        Game.fromCombat()

        Dim out As String = """Listen, I get it..."" the cook says, as you fall back to catch your breath, ""Well, not really, but I'm willing to let you off the hook...""" & DDUtils.RNRN &
                            """IF you agree to do me a favor.  Nothing big, it's just that the restock of salt looks a little shinier than usual.  I buy it from fairies, they're a pranksy sort, doesn't take too much to guess they're trying to pull one over on me.""" & DDUtils.RNRN &
                            pronoun.Substring(0, 1).ToUpper & pronoun.Substring(1, pronoun.Length - 1) & " tosses you a small drawstring bag of what seems to be normal salt.  Hesitantly, you reach a finger in to give it a taste..."

        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(11), out, AddressOf playerDeath2)

    End Sub
    Public Sub playerDeath2()
        Game.player1.changeClass("Fae Bee")
        Game.player1.drawPort()

        TextEvent.push("POP!" & DDUtils.RNRN &
                       "The instant your finger touches the contents of the bag, your entire world shifts.  Everything is suddenly so much bigger, and you see tell-tale trails of scent that you instinctively know each lead to something in bloom." & DDUtils.RNRN &
                       "Briefly, you take a confused glance down at the pile of junk beneath you.  Why do you feel some sense of ownership over any of it?  It's clearly too big to drag back to the hive." & DDUtils.RNRN &
                       "From an outside perspective, it simply appears that you've vanished; replaced by a tiny glowing speck." & DDUtils.RNRN &
                       "You flit off into the dungeon, mindlessly searching for a flower to pollenate.", AddressOf playerDeath3)
    End Sub
    Public Sub playerDeath3()
        Game.player1.changeClass("Fae Bee​")
        Game.player1.drawPort()

        Objective.showNPC(local_img(LocalImgInd.alt5), """OH!  Uhhhh...  Well, shit...""" & DDUtils.RNRN &
                                                       "GAME OVER!", AddressOf Game.player1.die)
    End Sub

    '| - DIALOG - |
    Protected Overrides Function normalDialog(ByRef p As Player)
        If Game.player1.quests(qInd.banEgg).canGet Then
            Game.player1.quests(qInd.banEgg).init()
            Return ""
        End If

        If Game.mDun.numCurrFloor = 13 Then
            img_index = LocalImgInd.alt4
            Return "Hey!  I'm turning into a tree!  Now, obviously this ain't great, but at least I'm getting wood!  HA!" & DDUtils.RNRN &
                   "That's a little bit of some tree humor, buy some stuff before you leaf and maybe I can get this straighed out before this curse runs its course, eh?"
        ElseIf Int(Rnd() * 20) = 0 Then
            discount = 0.25
            img_index = LocalImgInd.alt3
            Return "*ahem* Apologies, but my dear friend here is currently occupied..." & DDUtils.RNRN &
                   "If it helps speed up your decision, I had him whip up a bit of a surplus beforehand, and I can give you a 25% discount on that.  Please leave the gold for anything you purchase on the counter." & DDUtils.RNRN &
                   "Oh, and by the way, take care not to dawdle or try anything suspicious.  I am always in need of guinea pigs, and I have quite the back-log of expirements I would like to try on a less amiable subject."
        ElseIf Int(Rnd() * 20) = 1 Then
            img_index = LocalImgInd.alt2
            Return "Hey!  I was trying out a new type of cream, aaaaaaaaand, well, turns out there were a couple side effects..." & DDUtils.RNRN &
                   "Don't worry though, I'm pretty sure none of it made it into the stuff for sale.  But hey, if you want any of it, let me know, ok?" & DDUtils.RNRN &
                   "If you're hungry, I've always got something cooking.  So, what can I get you?"
        ElseIf Int(Rnd() * 20) = 2 Then
            img_index = LocalImgInd.alt1
            Return "Say what you will about Marissa, but the lady " & If(p.perks(perk.mrevived) < 0, "had", "has") & " a type for sure..." & DDUtils.RNRN &
                   "Fortunately for me, I've got a deal goin' on with one of the hottest mind controllers you'll find in these parts, and part of my payment was some solid mental defense training.  I'm not even worried about the new body, either.  I've got just the thing to change back me to my old self... when I get bored, that is.  No reason not to enjoy " & If(p.perks(perk.mrevived) < 0, "her student's", "her") & " ""tip"" to its fullest, right?" & DDUtils.RNRN &
                   "In the meantime, I've always got something cooking if you're hungry.  Let me know if I can get you anything, ok?"
        Else
            img_index = LocalImgInd.normal
            Return "Welcome!  If you're hungry, I've always got something cooking." & DDUtils.RNRN &
                   "Not just food, by the way.  I've done a fair bit of playin' around with magic ingredients, and even if I can't use magic myself I can still work wonders with the right recipe." & DDUtils.RNRN &
                   "So, what can I get ya?"
        End If
    End Function
    Protected Overrides Function frogDialog(ByRef p As Player)
        Return "Broak, croak, ribbit."
    End Function
    Protected Overrides Function bunnyDialog(ByRef p As Player)
        Return "I'd be lyin' if I said I wasn't used to being turned into a woman at this point." & DDUtils.RNRN &
               "Between my research dates, and all the other crazy stuff that goes on around this place, it'd probably be a decent idea to have more than just the mental defenses.  But hey, variety is the spice of life, and I'm totally sizzlin' in this thing!" & DDUtils.RNRN &
               "Don't, uh, tell Teach I said that though, she might end up keeping me like this..."
    End Function
    Protected Overrides Function princessDialog(ByRef p As Player)
        Return "You dine with royalty this day, " & p.className & ".  I assure you, my cooking is more than fit for a princess, and I would know! ~🖤" & DDUtils.RNRN &
               "See, you may have thought you got the upper hand by turning me into a helpless princess, but now I've turned it around into marketing!  Pretty sneaky, huh?"

    End Function
    Protected Overrides Function sheepDialog(ByRef p As Player)
        Return "..."
    End Function
    Protected Overrides Function arachneDialog(ByRef p As Player)
        If p.formName.Equals("Arachne") Then
            Return "Hey, it's you!  All hail the spider goddess or whatever we're on about, to be completely honest I wasn't really paying attention during my initiation." & DDUtils.RNRN &
                   "So, whatcha eatin'?"
        Else
            Return "Ya know, they did give me this extra strength venom you could use if you wanted to try this spider thing out..."
        End If
    End Function
    Protected Overrides Function catgirlDialog(ByRef p As Player)
        Return "I'll be the one to say it, you're better at this than Marissa.  Are you two working together or something?"
    End Function
    Protected Overrides Function beegirlDialog(ByRef p As Player)
        Return "Bzz, h o n e y..."
    End Function

    Protected Overrides Function normalFightDialog(ByRef p As Player)
        Return "Looks like someone ordered... a knuckle sandwich!" & DDUtils.RNRN &
               "Hahaha, aaahhh... no?  Not a fan of the puns?  Well, all the more reason to kick your ass."
    End Function
    Protected Overrides Function frogFightDialog(ByRef p As Player)
        Return "rrrrrrrr..."
    End Function
    Protected Overrides Function bunnyFightDialog(ByRef p As Player)
        Return "WHAA... can't we talk this out, or at least wait for me to turn back?!"
    End Function
    Protected Overrides Function princessFightDialog(ByRef p As Player)
        Return "Wait, you wouldn't hit a princess, right?"
    End Function
    Protected Overrides Function sheepFightDialog(ByRef p As Player)
        Return "!!!"
    End Function
    Protected Overrides Function arachneFightDialog(ByRef p As Player)
        Return "Whelp, time for one of us to die."
    End Function
    Protected Overrides Function catgirlFightDialog(ByRef p As Player)
        Return "Alright, let's do this..."
    End Function
    Protected Overrides Function beegirlFightDialog(ByRef p As Player)
        Return "ZBZBZBZB!"
    End Function

    Protected Overrides Function normalSpellDialog(ByRef p As Player)
        Return "*sigh*" & DDUtils.RNRN &
               "Alright, here we go."
    End Function
    Protected Overrides Function frogSpellDialog(ByRef p As Player)
        Return frogFightDialog(p)
    End Function
    Protected Overrides Function bunnySpellDialog(ByRef p As Player)
        Return "*giggle* Was tha...  No, I've gotta focus..."
    End Function
    Protected Overrides Function princessSpellDialog(ByRef p As Player)
        Return "Hmmmm...  This actually might be useful..."
    End Function
    Protected Overrides Function sheepSpellDialog(ByRef p As Player)
        Return sheepFightDialog(p)
    End Function
    Protected Overrides Function arachneSpellDialog(ByRef p As Player)
        Return normalSpellDialog(p)
    End Function
    Protected Overrides Function catgirlSpellDialog(ByRef p As Player)
        Return "Mrrrrrr..."
    End Function
    Protected Overrides Function beegirlSpellDialog(ByRef p As Player)
        Return beegirlFightDialog(p)
    End Function

    Public Overrides Function postPurchaseDialog(ByRef p As Player) As Object
        Return "Anything else I can get ya?"
    End Function

    '| - MISC - |
    Public Overrides Sub buildShopArea(ByRef floor As mFloor)
        MyBase.buildShopArea(floor)

        Dim grills = {New Point(pos.X - 1, pos.Y)}

        Dim tables = {New Point(pos.X + 1, pos.Y)}

        For Each pt In grills
            If floor.ptInBounds(pt) Then floor.mBoard(pt.Y, pt.X).Text = "±"
        Next

        For Each pt In tables
            If floor.ptInBounds(pt) Then floor.mBoard(pt.Y, pt.X).Text = "µ"
        Next
    End Sub
End Class
