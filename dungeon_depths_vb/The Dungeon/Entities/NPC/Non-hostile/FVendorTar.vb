Public Class FVendorTar
    Inherits ShopNPC
    Sub New()
        MyBase.New()

        init()
    End Sub

    Sub New(ByRef fVend As FVendor)
        MyBase.New()

        init()

        img_index = fVend.img_index
        gold = fVend.gold
        pronoun = fVend.pronoun
        p_pronoun = fVend.p_pronoun
        r_pronoun = fVend.r_pronoun
        title = fVend.title
    End Sub

    Sub init()
        '|ID Info|
        name = "Food Vendor (Targax)"
        sName = name
        npc_index = sNPCInd.foodvendor

        '|NPC Flags|
        pronoun = "he"
        p_pronoun = "his"
        r_pronoun = "him"
        isShop = True

        '|Inventory|
        inv.setCount("Better_Medicinal_Tea", 1)
        inv.setCount("Dragonfruit", 1)
        inv.setCount("Dragonfruit_S._of_Gum", 1)
        inv.setCount("Mage's_Delicacy", 1)
        inv.setCount("""Normal""_Steak", 1)
        inv.setCount("Nature's_Kiss", 1)
        inv.setCount("Panacea", 1)
        inv.setCount("Roc_Drumstick", 1)
        inv.setCount("Tavern_Special", 1)
        inv.setCount("Warrior's_Feast", 1)

        '|Stats|
        maxHealth = 9999
        attack = 999
        defense = 99
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
        picNormal = ShopNPC.npcLib.atrs(0).getAt(78)
        picPrincess = ShopNPC.npcLib.atrs(0).getAt(79)
        picBunny = ShopNPC.npcLib.atrs(0).getAt(80)
        picArachne = ShopNPC.npcLib.atrs(0).getAt(81)

        picNPC = New List(Of Image)
        picNPC.AddRange({picNormal,
                         ShopNPC.npcLib.atrs(0).getAt(4),
                         ShopNPC.npcLib.atrs(0).getAt(5),
                         picPrincess,
                         picBunny})

        picNPC.AddRange({ShopNPC.npcLib.atrs(0).getAt(16),
                         ShopNPC.npcLib.atrs(0).getAt(15),
                         ShopNPC.npcLib.atrs(0).getAt(23),
                         ShopNPC.npcLib.atrs(0).getAt(82),
                         ShopNPC.npcLib.atrs(0).getAt(61),
                         picArachne,
                         ShopNPC.npcLib.atrs(0).getAt(82),
                         ShopNPC.npcLib.atrs(0).getAt(96)})
    End Sub


    Public Overrides Sub encounter()
        'If the food vendor has the sword, use the alternate food vendor character
        If Game.player1.perks(perk.fvHasSword) < 0 Then
            Game.active_shop_npc = Game.fvend
            Game.fvend.encounter()
            Exit Sub
        End If

        MyBase.encounter()

        discount = 0

        If img_index = 0 Then
            TextEvent.pushNPCDialog("Welcome and check out the new menu!  Turns out this sword was a little more cursed than expected.  No worries though, I'm sure it'll work itself out...  Eat up!")
        ElseIf img_index = 1 Then
            TextEvent.pushNPCDialog("Broak, croak, ribbit.")
        ElseIf img_index = 2 Then
            TextEvent.pushNPCDialog("...")
        ElseIf img_index = 3 Then
            TextEvent.pushNPCDialog("You... ~mmm~... dine with royalty this day, " & Game.player1.className & "...  I assure you, I am more than fit for a princess, and you would know! ~🖤  " &
                               "Oh, you might have thought you got the upper hand by turning me into a helpless princess, but...  ~ooohhh~ this... probably doesn't bode well...")
        ElseIf img_index = 4 Then
            discount = 2.0
            TextEvent.pushNPCDialog("Hello once again, my murderer.  Remember me?  Targax?  This fool is usually able to supress my influance, but in her current state taking full control was easy pickings.  As a show of gratitude I won't turn you away this time, but once I've finished turning the chef into a proper vessal you will know my wrath.")
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


        If img_index = 5 Then inv.setCount(98, 1) Else inv.setCount(98, 0)
        If img_index = getArachneImageInd() And Not Game.player1.formName.Equals("Arachne") Then inv.setCount(244, 1) Else inv.setCount(244, 0)

        Game.picNPC.BackgroundImage = picNPC(img_index)
    End Sub

    Public Overrides Function toFight() As String
        If img_index = 0 Then
            Return "Looks like someone ordered...a knuckle sandwich!  Hahaha, aaahhh...no?  Not a fan of the puns?  Well, all the more reason to kick your ass."
        ElseIf img_index = 1 Then
            Return "rrrrrrrr..."
        ElseIf img_index = 2 Then
            Return "!!!"
        ElseIf img_index = 3 Then
            Return "Wait, you wouldn't hit a princess, right?"
        ElseIf img_index = 4 Then
            Return "Well then, round two time..."
        ElseIf img_index = 8 Or img_index = 12 Then
            Return "..."
        ElseIf img_index = 10 Then
            Return "Whelp, time for one of us to die."
        ElseIf img_index = 11 Then
            Return "Alright, let's do this..."
        End If
        Return "Looks like someone ordered...a knuckle sandwich!  Hahaha, aaahhh...no?  Not a fan of the puns?  Well, all the more reason to kick your ass."
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
            Return "Magic?  Oh you *are* precious..."
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
