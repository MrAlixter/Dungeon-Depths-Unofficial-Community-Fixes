Public Class FVendor
    Inherits ShopNPC
    Sub New()
        name = "Food Vendor"
        health = 1.0
        maxHealth = 9999
        attack = 999
        defense = 99
        speed = 99

        'Define the inventory
        inv = New Inventory(False)
        'Food
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

        isShop = True
        gold = 99999
        pronoun = "he"
        pPronoun = "his"
        rPronoun = "him"
        picNormal = ShopNPC.npcLib.atrs(0).getAt(11)
        picPrincess = ShopNPC.npcLib.atrs(0).getAt(13)
        picBunny = ShopNPC.npcLib.atrs(0).getAt(12)

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
                         ShopNPC.npcLib.atrs(0).getAt(61)})
        If speed = Game.player1.speed Then speed -= 1
        title = " the "
    End Sub

    Public Overrides Sub encounter()
        MyBase.encounter()

        discount = 0
        If Game.currFloor.floorNumber = 13 Then
            npcIndex = 9
            inv.setCount("Chicken_Leg", 0)
            inv.setCount("Warrior's_Feast", 0)
            inv.setCount("Mage's_Delicacy", 0)
            inv.setCount("Tavern_Special", 0)
            Game.pushNPCDialog("Hey!  I'm turning into a tree!  Now, obviously this ain't great, but at least I'm getting hard!  HA!  That's a little bit of some tree humor, buy some stuff before you leaf and maybe I can get this straighed out before I'm all arborial...")
        Else
            If npcIndex = 0 Then
                If Int(Rnd() * 20) = 0 Then
                    discount = 0.25
                    npcIndex = 7
                    Game.pushNPCDialog("*ahem* Apologies, but my dear friend here is currently occupied with helping me test out one of my more..." &
                                       "intimate...hypnosis techniques.  If it helps speed up your decision, I had him whip up a bit of a surplus beforehand " &
                                       "and I can give you a 25% discount on that.  I'm going to get back to my reaserch now, you can leave the gold on the counter.  " &
                                       "Oh, and by the way, don't dawdle or try anything else suspicious.  I am always in need of guinea pigs, and I have quite the " &
                                       "back-log of expirements I'd like to try on a less amiable subject.")
                ElseIf Int(Rnd() * 20) = 1 Then
                    npcIndex = 5
                    Game.pushNPCDialog("Hey!  I was trying out a new milk in my food, and, well, there were...a couple of side effects.  " &
                                       "Don't worry though, I'm pretty sure none of it made it into the stuff for sale.  But hey, if you " &
                                       "want any of it, I have some to spare.  If you're hungry, I've also always got something cooking.  So, what can I get you?")
                ElseIf Int(Rnd() * 20) = 2 Then
                    npcIndex = 6
                    Game.pushNPCDialog("Say what you will about Marissa, but the lady's got a type for sure.  Fortunately for me, I've got a " &
                                       "deal goin' on with one of the hottest mind controllers you'll find in these parts, and part of my payment was " &
                                       "some solid mental defense training.  I'm not even worried about the new body, either.  I've got just the thing " &
                                       "to change back me to my old self...when I get bored, that is.  No reason not to enjoy Marissa's ""tip"" to its fullest, right?  " &
                                       "In the meantime, I've always got something cooking if you're hungry.  Let me know if I can get you anything, ok?")
                Else
                    Game.pushNPCDialog("Welcome!  If you're hungry, I've always got something cooking.  Not just food, by the way.  " &
                                       "I've done a fair bit of testing with magic ingredients, and while I can't use magic myself, " &
                                       "I can still work wonders with the right recipe.  So, what can I get you?")
                End If
            ElseIf npcIndex = 1 Then
                Game.pushNPCDialog("Broak, croak, ribbit.")
            ElseIf npcIndex = 2 Then
                Game.pushNPCDialog("...")
            ElseIf npcIndex = 3 Then
                Game.pushNPCDialog("You dine with royalty this day, " & Game.player1.className & ".  I assure you, my cooking is more than fit for a princess, and I would know! ~🖤  " &
                                   "See, you may have thought you got the upper hand by turning me into a helpless princess, but now I've turned it around into marketing!  Pretty sneaky, huh?")
            ElseIf npcIndex = 4 Then
                Game.pushNPCDialog("I'd be lyinig if I said I wasn't used to being turned into a woman at this point.  Between my bestie and possibly girlfriend, and all the crazy stuff that " &
                                   "goes on around this place, you'd think I'd have more than just the mental defenses.  But hey, variety is the spice of life, and I'm totally sizzlin' in this thing!  " &
                                   "Don't, uh, tell Teach I said that though, she might end up keeping me like this...")
            ElseIf npcIndex = 8 Then
                Game.pushNPCDialog("...")
            End If
        End If

        If npcIndex = 5 Then inv.setCount(98, 1) Else inv.setCount(98, 0)
        Game.picNPC.BackgroundImage = picNPC(npcIndex)
    End Sub

    Public Overrides Function toFight() As String
        If npcIndex = 0 Then
            Return "Looks like someone ordered...a knuckle sandwich!  Hahaha, aaahhh...no?  Not a fan of the puns?  Well, all the more reason to kick your ass."
        ElseIf npcIndex = 1 Then
            Return "rrrrrrrr..."
        ElseIf npcIndex = 2 Then
            Return "!!!"
        ElseIf npcIndex = 3 Then
            Return "Wait, you wouldn't hit a princess, right?"
        ElseIf npcIndex = 4 Then
            Return "WHAA...can't we talk this out, or at least wait for me to turn back?!?"
        ElseIf npcIndex = 8 Then
            Return "..."
        End If
        Return "Looks like someone ordered...a knuckle sandwich!  Hahaha, aaahhh...no?  Not a fan of the puns?  Well, all the more reason to kick your ass."
    End Function
    Public Overrides Function hitBySpell() As String
        If npcIndex = 0 Then
            Game.NPCtoCombat(Me)
            Return "*sigh* Alright, here we go."
        ElseIf npcIndex = 1 Then
            Game.NPCtoCombat(Me)
            Return "rrrrrr."
        ElseIf npcIndex = 2 Then
            Game.NPCtoCombat(Me)
            Return "!!!"
        ElseIf npcIndex = 3 Then
            Return "Hmmmm...  This actually might be useful..."
        ElseIf npcIndex = 4 Then
            Return "*giggle* Was tha... No, I've gotta focus...  "
        ElseIf npcIndex = 8 Then
            Return "..."
        End If

        Game.NPCtoCombat(Me)
        Return "*sigh* Alright, here we go."
    End Function

    Public Overrides Sub toDoll()
        Game.pushNPCDialog("...")
        Game.picNPC.BackgroundImage = picNPC(8)

        discount = 0.5
    End Sub
End Class
