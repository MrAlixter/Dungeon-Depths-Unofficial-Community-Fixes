Public Class FVendor
    Inherits ShopNPC
    Sub New()
        MyBase.New()

        '|ID Info|
        name = "Food Vendor"
        sName = name
        npc_index = sNPCInd.foodvendor

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
        picNormal = ShopNPC.npcLib.atrs(0).getAt(11)
        picPrincess = ShopNPC.npcLib.atrs(0).getAt(13)
        picBunny = ShopNPC.npcLib.atrs(0).getAt(12)
        picArachne = ShopNPC.npcLib.atrs(0).getAt(69)

        picNPC = New List(Of Image)
        picNPC.AddRange({picNormal,
                         ShopNPC.npcLib.atrs(0).getAt(4),
                         ShopNPC.npcLib.atrs(0).getAt(5),
                         picPrincess,
                         picBunny})

        picNPC.AddRange({ShopNPC.npcLib.atrs(0).getAt(16),
                         ShopNPC.npcLib.atrs(0).getAt(15),
                         ShopNPC.npcLib.atrs(0).getAt(23),
                         ShopNPC.npcLib.atrs(0).getAt(14),
                         ShopNPC.npcLib.atrs(0).getAt(61),
                         picArachne,
                         ShopNPC.npcLib.atrs(0).getAt(82),
                         ShopNPC.npcLib.atrs(0).getAt(96)})
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

        discount = 0
        If Game.currFloor.floorNumber = 13 Then
            img_index = 9
            inv.setCount("Chicken_Leg", 0)
            inv.setCount("Warrior's_Feast", 0)
            inv.setCount("Mage's_Delicacy", 0)
            inv.setCount("Tavern_Special", 0)
            TextEvent.pushNPCDialog("Hey!  I'm turning into a tree!  Now, obviously this ain't great, but at least I'm getting wood!  HA!" & DDUtils.RNRN &
                               "That's a little bit of some tree humor, buy some stuff before you leaf and maybe I can get this straighed out before this curse runs its course, eh?")
        Else
            If img_index = 0 Then
                If Game.player1.quests(qInds.banEgg).canGet Then Game.player1.quests(qInds.banEgg).init() : Exit Sub

                If Int(Rnd() * 20) = 0 Then
                    discount = 0.25
                    img_index = 7
                    TextEvent.pushNPCDialog("*ahem* Apologies, but my dear friend here is currently occupied..." & DDUtils.RNRN &
                                       "If it helps speed up your decision, I had him whip up a bit of a surplus beforehand, and I can give you a 25% discount on that.  Please leave the gold for anything you purchase on the counter." & DDUtils.RNRN &
                                       "Oh, and by the way, take care not to dawdle or try anything suspicious.  I am always in need of guinea pigs, and I have quite the back-log of expirements I would like to try on a less amiable subject.")
                ElseIf Int(Rnd() * 20) = 1 Then
                    img_index = 5
                    TextEvent.pushNPCDialog("Hey!  I was trying out a new type of cream, aaaaaaaaand, well, turns out there were a couple side effects..." & DDUtils.RNRN &
                                       "Don't worry though, I'm pretty sure none of it made it into the stuff for sale.  But hey, if you want any of it, let me know, ok?" & DDUtils.RNRN &
                                       "If you're hungry, I've always got something cooking.  So, what can I get you?")
                ElseIf Int(Rnd() * 20) = 2 Then
                    img_index = 6
                    TextEvent.pushNPCDialog("Say what you will about Marissa, but the lady " & If(Game.player1.perks(perk.mrevived) < 0, "had", "has") & " a type for sure..." & DDUtils.RNRN &
                                       "Fortunately for me, I've got a deal goin' on with one of the hottest mind controllers you'll find in these parts, and part of my payment was some solid mental defense training.  I'm not even worried about the new body, either.  I've got just the thing to change back me to my old self... when I get bored, that is.  No reason not to enjoy " & If(Game.player1.perks(perk.mrevived) < 0, "her student's", "her") & " ""tip"" to its fullest, right?" & DDUtils.RNRN &
                                       "In the meantime, I've always got something cooking if you're hungry.  Let me know if I can get you anything, ok?")
                Else
                    TextEvent.pushNPCDialog("Welcome!  If you're hungry, I've always got something cooking." & DDUtils.RNRN &
                                       "Not just food, by the way.  I've done a fair bit of playin' around with magic ingredients, and even if I can't use magic myself I can still work wonders with the right recipe." & DDUtils.RNRN &
                                       "So, what can I get ya?")
                End If
            ElseIf img_index = 1 Then
                TextEvent.pushNPCDialog("Broak, croak, ribbit.")
            ElseIf img_index = 2 Then
                TextEvent.pushNPCDialog("...")
            ElseIf img_index = 3 Then
                TextEvent.pushNPCDialog("You dine with royalty this day, " & Game.player1.className & ".  I assure you, my cooking is more than fit for a princess, and I would know! ~🖤" & DDUtils.RNRN &
                                   "See, you may have thought you got the upper hand by turning me into a helpless princess, but now I've turned it around into marketing!  Pretty sneaky, huh?")
            ElseIf img_index = 4 Then
                TextEvent.pushNPCDialog("I'd be lyin' if I said I wasn't used to being turned into a woman at this point." & DDUtils.RNRN &
                                   "Between my research dates, and all the other crazy stuff that goes on around this place, it'd probably be a decent idea to have more than just the mental defenses.  But hey, variety is the spice of life, and I'm totally sizzlin' in this thing!" & DDUtils.RNRN &
                                   "Don't, uh, tell Teach I said that though, she might end up keeping me like this...")
            ElseIf img_index = 8 Or img_index = 12 Then
                TextEvent.pushNPCDialog("...")
            ElseIf img_index = 10 Then
                If Game.player1.formName.Equals("Arachne") Then
                    TextEvent.pushNPCDialog("Hey, it's you!  All hail the spider goddess or whatever we're on about, to be completely honest I wasn't really paying attention during my initiation." & DDUtils.RNRN &
                                       "So, whatcha eatin'?")
                Else
                    TextEvent.pushNPCDialog("Ya know, they did give me this extra strength venom you could use if you wanted to try this spider thing out...")
                End If
            ElseIf img_index = 11 Then
                TextEvent.pushNPCDialog("I'll be the one to say it, you're better at this than Marissa.  Are you two working together or something?")
            End If
        End If

        If img_index = 5 Then inv.setCount(98, 1) Else inv.setCount(98, 0)
        If img_index = getArachneImageInd() And Not Game.player1.formName.Equals("Arachne") Then inv.setCount(244, 1) Else inv.setCount(244, 0)

        Game.picNPC.BackgroundImage = picNPC(img_index)
    End Sub

    Public Overrides Function toFight() As String
        If img_index = 0 Then
            Return "Looks like someone ordered... a knuckle sandwich!  Hahaha, aaahhh... no?  Not a fan of the puns?  Well, all the more reason to kick your ass."
        ElseIf img_index = 1 Then
            Return "rrrrrrrr..."
        ElseIf img_index = 2 Then
            Return "!!!"
        ElseIf img_index = 3 Then
            Return "Wait, you wouldn't hit a princess, right?"
        ElseIf img_index = 4 Then
            Return "WHAA... can't we talk this out, or at least wait for me to turn back?!?"
        ElseIf img_index = 8 Or img_index = 12 Then
            Return "..."
        ElseIf img_index = 10 Then
            Return "Whelp, time for one of us to die."
        ElseIf img_index = 11 Then
            Return "Alright, let's do this..."
        End If
        Return "Looks like someone ordered...a knuckle sandwich!  Hahaha, aaahhh... no?  Not a fan of the puns?  Well, all the more reason to kick your ass."
    End Function
    Public Overrides Function hitBySpell() As String
        If img_index = 0 Or img_index = 10 Then
            Game.NPCtoCombat(Me)
            Return "*sigh* Alright, here we go."
        ElseIf img_index = 1 Then
            Game.NPCtoCombat(Me)
            Return "rrrrrr."
        ElseIf img_index = 2 Then
            Game.NPCtoCombat(Me)
            Return "!!!"
        ElseIf img_index = 3 Then
            Return "Hmmmm...  This actually might be useful..."
        ElseIf img_index = 4 Then
            Return "*giggle* Was tha... No, I've gotta focus...  "
        ElseIf img_index = 8 Or img_index = 12 Then
            Return "..."
        ElseIf img_index = 11 Then
            Game.NPCtoCombat(Me)
            Return "Mrrrrrr..."
        End If

        Game.NPCtoCombat(Me)
        Return "*sigh* Alright, here we go."
    End Function

    Public Overrides Sub toDoll()
        TextEvent.pushNPCDialog("...")
        Game.picNPC.BackgroundImage = picNPC(8)

        discount = 0.5
    End Sub

    Public Overrides Function getArachneImageInd() As Integer
        Return 10
    End Function
    Public Overrides Function getCatgirlImageInd() As Integer
        Return 11
    End Function
    Public Overrides Function getTrilobiteImageInd() As Integer
        Return 12
    End Function
End Class
