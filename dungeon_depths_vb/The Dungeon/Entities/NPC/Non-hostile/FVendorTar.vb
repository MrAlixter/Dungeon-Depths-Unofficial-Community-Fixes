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
        npc_index = ShopNPCInd.foodvendor

        '|NPC Flags|
        pronoun = "he"
        p_pronoun = "his"
        r_pronoun = "him"
        isShop = True

        '|Inventory|
        inv.setCount("Better_Medicinal_Tea", 1)
        inv.setCount("Dragonfruit​", 1)
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
        local_img = New Dictionary(Of ShopNPC.LocalImgInd, Image)()

        local_img.Add(LocalImgInd.normal, ShopNPC.gbl_img.atrs(0).getAt(78))
        local_img.Add(LocalImgInd.frog, ShopNPC.gbl_img.atrs(0).getAt(4))
        local_img.Add(LocalImgInd.bunny, ShopNPC.gbl_img.atrs(0).getAt(80))
        local_img.Add(LocalImgInd.princess, ShopNPC.gbl_img.atrs(0).getAt(79))
        local_img.Add(LocalImgInd.sheep, ShopNPC.gbl_img.atrs(0).getAt(5))
        local_img.Add(LocalImgInd.doll, ShopNPC.gbl_img.atrs(0).getAt(82))
        local_img.Add(LocalImgInd.arachne, ShopNPC.gbl_img.atrs(0).getAt(81))
        local_img.Add(LocalImgInd.catgirl, ShopNPC.gbl_img.atrs(0).getAt(149))
        local_img.Add(LocalImgInd.trilobite, ShopNPC.gbl_img.atrs(0).getAt(96))
        local_img.Add(LocalImgInd.beegirl, ShopNPC.gbl_img.atrs(0).getAt(148))
        local_img.Add(LocalImgInd.bimbo, ShopNPC.gbl_img.atrs(0).getAt(160))
        local_img.Add(LocalImgInd.alt1, ShopNPC.gbl_img.atrs(0).getAt(61))
    End Sub

    Public Overrides Sub encounter()
        'If the food vendor has the sword, use the alternate food vendor character
        If Game.player1.perks(perk.fvHasSword) < 0 Then
            Game.active_shop_npc = Game.fvend
            Game.fvend.encounter()
            Exit Sub
        End If

        MyBase.encounter()
    End Sub

    '| - DIALOG - |
    Protected Overrides Function normalDialog(ByRef p As Player)
        Return "Welcome and check out the new menu!" & DDUtils.RNRN &
               "Turns out this sword was a little more cursed than expected.  No worries though, I'm sure it'll work itself out..."
    End Function
    Protected Overrides Function frogDialog(ByRef p As Player)
        Return "Broak, croak, ribbit."
    End Function
    Protected Overrides Function bunnyDialog(ByRef p As Player)
        discount = -2.0
        Return "Hello once again, my murderer." & DDUtils.RNRN &
               "Remember me?  Targax?  This fool is usually able to supress my influence, but in this form taking full control was easy pickings." & DDUtils.RNRN &
               "As a show of gratitude I won't turn you away this time, but you will face my wrath once I've finished turning this pathetic chef into a proper vessel."
    End Function
    Protected Overrides Function princessDialog(ByRef p As Player)
        Return "You... ~mmm~... dine with royalty this day, " & p.className & "...  I assure you, I am more than fit for a princess, and you would know! ~🖤  " & DDUtils.RNRN &
               "Oh, you might have thought you got the upper hand by turning me into a helpless princess, but...  ~ooohhh~ this... probably doesn't bode well..."

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
        Return "Umm... I... Meow?"
    End Function
    Protected Overrides Function beegirlDialog(ByRef p As Player)
        Return "Bzz, h o n e y..."
    End Function
    Protected Overrides Function bimboDialog(ByRef p As Player)
        Return bunnyDialog(p)
    End Function

    Protected Overrides Function normalFightDialog(ByRef p As Player)
        Return "Looks like someone ordered... a knuckle sandwich!" & DDUtils.RNRN &
               "Hahaha, aaahhh... no?  Not a fan of the puns?  Well, all the more reason to kick your ass."
    End Function
    Protected Overrides Function frogFightDialog(ByRef p As Player)
        Return "rrrrrrrr..."
    End Function
    Protected Overrides Function bunnyFightDialog(ByRef p As Player)
        Return "Well then, time for round two..."
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
    Protected Overrides Function bimboFightDialog(ByRef p As Player)
        Return bunnyFightDialog(p)
    End Function

    Protected Overrides Function normalSpellDialog(ByRef p As Player)
        Return "*sigh*" & DDUtils.RNRN &
               "Alright, here we go."
    End Function
    Protected Overrides Function frogSpellDialog(ByRef p As Player)
        Return frogFightDialog(p)
    End Function
    Protected Overrides Function bunnySpellDialog(ByRef p As Player)
        Return "Magic?  Oh you *are* precious..."
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
    Protected Overrides Function bimboSpellDialog(ByRef p As Player)
        Return bunnySpellDialog(p)
    End Function

    Protected Overrides Function normalPostPurchaseDialog(ByRef p As Player) As String
        Return "Anything else I can getcha?"
    End Function
    Protected Overrides Function bimboPostPurchaseDialog(ByRef p As Player) As String
        Return "Anything else I can getcha?"
    End Function
End Class
