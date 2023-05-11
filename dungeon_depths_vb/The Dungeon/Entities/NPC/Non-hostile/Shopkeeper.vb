Public Class Shopkeeper
    Inherits ShopNPC
    Sub New()
        MyBase.New()

        '|ID Info|
        name = "Shopkeeper"
        sName = name
        npc_index = ShopNPCInd.shopkeeper

        '|NPC Flags|
        pronoun = "he"
        p_pronoun = "his"
        r_pronoun = "him"
        isShop = True

        '|Inventory|
        inv.setCount("Compass", 1)
        inv.setCount("Spellbook", 1)
        inv.setCount("Major_Health_Potion", 1)
        inv.setCount("Anti_Curse_Tag", 1)
        inv.item("Anti_Curse_Tag").value *= 2.5
        'Potions
        inv.setCount("Health_Potion", 1)
        inv.setCount("Mana_Potion", 1)
        inv.setCount("Anti_Venom", 1)
        'Food
        inv.setCount("Chicken_Leg", 1)
        'Armor/Accesories
        inv.setCount("Bronze_Armor", 1)
        inv.setCount("Steel_Armor", 1)
        'Weapons
        inv.setCount("Steel_Sword", 1)
        inv.setCount("Oak_Staff", 1)
        inv.setCount("Gold_Sword", 1)
        inv.setCount("Golden_Staff", 1)
        If DDDateTime.isSummer Then inv.setCount("Staff_of_the_Tidemage", 1)

        '|Stats|
        maxHealth = 9999
        attack = 99
        defense = 999
        speed = 99
        will = 999
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

        local_img.Add(LocalImgInd.normal, ShopNPC.gbl_img.atrs(0).getAt(0))
        local_img.Add(LocalImgInd.frog, ShopNPC.gbl_img.atrs(0).getAt(4))
        local_img.Add(LocalImgInd.bunny, ShopNPC.gbl_img.atrs(0).getAt(1))
        local_img.Add(LocalImgInd.princess, ShopNPC.gbl_img.atrs(0).getAt(2))
        local_img.Add(LocalImgInd.sheep, ShopNPC.gbl_img.atrs(0).getAt(5))
        local_img.Add(LocalImgInd.doll, ShopNPC.gbl_img.atrs(0).getAt(3))
        local_img.Add(LocalImgInd.arachne, ShopNPC.gbl_img.atrs(0).getAt(67))
        local_img.Add(LocalImgInd.catgirl, ShopNPC.gbl_img.atrs(0).getAt(89))
        local_img.Add(LocalImgInd.trilobite, ShopNPC.gbl_img.atrs(0).getAt(96))
        local_img.Add(LocalImgInd.beegirl, ShopNPC.gbl_img.atrs(0).getAt(148))
        local_img.Add(LocalImgInd.alt1, ShopNPC.gbl_img.atrs(0).getAt(140))
    End Sub

    Public Overrides Sub encounter()
        floor10Adjustment()

        MyBase.encounter()
    End Sub
    Public Overrides Sub inventoryUpdate()
        If Game.mDun.numCurrFloor < 2 Then
            inv.setCount("Scale_Armor", 1)
            inv.setCount("Gold_Armor", 0)
            inv.setCount("Midas_Gauntlet", 0)
        Else
            inv.setCount("Scale_Armor", 1)
            inv.setCount("Gold_Armor", 1)
            inv.setCount("Midas_Gauntlet", 1)
        End If

        If Game.player1.quests(qInd.helpWanted).getComplete Then
            inv.setCount("Platinum_Axe", 1)
            inv.setCount("Platinum_Daggers", 1)
            inv.setCount("Platinum_Staff", 1)
            inv.setCount("Platinum_Armor", 1)
            inv.setCount("Crimson_Cloak", 1)
            inv.setCount("Oak_Staff", 0)
            inv.setCount("Steel_Sword", 0)
            inv.setCount("Bronze_Armor", 0)
            inv.setCount("Steel_Armor", 0)
        End If
    End Sub

    '| - COMBAT - |
    Public Overrides Function reactToSpell(spell As String) As Boolean
        If Rnd() < (0.01) Then
            Return True
        Else
            TextEvent.pushLog("The spell bounces off the Shopkeeper!")
            TextEvent.pushCombat("The spell bounces off the Shopkeeper!")
            Return False
        End If
    End Function
    Public Overrides Sub playerDeath(ByRef p As Player)
        Game.fromCombat()
        p.petrify(Color.Goldenrod, 9999)

        Dim out As String = """You should have known better than to try and rob a shop keeper,"" the shopkeep says, glaring down at you, ""...and if its gold you're after, I guess I've got some good news for you.""" & DDUtils.RNRN &
            "With that, " & pronoun & " reaches into " & p_pronoun & " bag and puts on a gaudy gauntlet that begins glowing with a golden light. You lack the strength to fight back as " & pronoun & " places" &
            " his thumb on your forhead, and suddenly everything just seems so heavy. ""Noooo..."" you moan, as the area around where he touched turns to gold, and that gold turns your flesh and blood " &
            "around it to gold as well. In a matter of seconds, all that is left of " & p.name & " the " & p.className & " is a solid gold statue. The shopkeeper sighs, muttering to no one in particular, " & DDUtils.RNRN &
            """Now how am I going to get you back to the refinery?""" & DDUtils.RNRN &
            "GAME OVER!"

        TextEvent.push(out, AddressOf p.die)
        p.changeClass("Trophy")
    End Sub

    '| - FLOOR 10 - |
    Sub floor10Adjustment()
        If Game.currFloor.pinkMist Then
            img_index = 0
        End If
    End Sub

    '| - DIALOG - |
    Protected Overrides Function normalDialog(ByRef p As Player)
        If Game.currFloor.pinkMist Then
            img_index = LocalImgInd.alt1

            gold = 1000

            Return "Like, hey..." & DDUtils.RNRN &
                   "What's... um..." & DDUtils.RNRN &
                   "I'm, so, like... um..." & DDUtils.RNRN &
                   "Do you want to buy stuff?"
        End If

        If Game.player1.quests(qInd.helpWanted).canGet Then
            Game.player1.quests(qInd.helpWanted).init()
            Return ""
        End If

        Return "Hey, what's up?"
    End Function
    Protected Overrides Function bunnyDialog(ByRef p As Player)
        Return "*giggle* Hey!"
    End Function
    Protected Overrides Function princessDialog(ByRef p As Player)
        Return "Hello, kind " & p.className & ", how are you on this fine day?"
    End Function
    Protected Overrides Function arachneDialog(ByRef p As Player)
        Return "Hey, what's up?"
    End Function
    Protected Overrides Function catgirlDialog(ByRef p As Player)
        Return bunnyDialog(p)
    End Function

    Protected Overrides Function normalFightDialog(ByRef p As Player)
        Return "So you want to fight, eh?  Well, I'm ready whenever you are."
    End Function
    Protected Overrides Function bunnyFightDialog(ByRef p As Player)
        Return "I might not, like, be the best fighter anymore... but I can totally give it my best!"
    End Function
    Protected Overrides Function princessFightDialog(ByRef p As Player)
        Return "You would dare to challenge me? If you wish to die, you could just say so."
    End Function
    Protected Overrides Function arachneFightDialog(ByRef p As Player)
        Return normalFightDialog(p)
    End Function
    Protected Overrides Function catgirlFightDialog(ByRef p As Player)
        Return bunnyFightDialog(p)
    End Function

    Protected Overrides Function normalSpellDialog(ByRef p As Player)
        Return "Did...  Did you just cast a spell on me?  You know I have to kill you now, right?"
    End Function
    Protected Overrides Function frogSpellDialog(ByRef p As Player)
        Return "Ribbit!!!"
    End Function
    Protected Overrides Function bunnySpellDialog(ByRef p As Player)
        Return "*giggle* Was that magic?"
    End Function
    Protected Overrides Function princessSpellDialog(ByRef p As Player)
        Return "Casting unrequested spells on royalty is generally a poor idea..."
    End Function
    Protected Overrides Function sheepSpellDialog(ByRef p As Player)
        Return "[angry bleets]!"
    End Function
    Protected Overrides Function arachneSpellDialog(ByRef p As Player)
        Return normalDialog(p)
    End Function
    Protected Overrides Function catgirlSpellDialog(ByRef p As Player)
        Return bunnyDialog(p)
    End Function

    Public Overrides Function postPurchaseDialog(ByRef p As Player) As Object
        If Game.currFloor.pinkMist Then
            Return "Like- um, thanks..."
        End If

        Return "Thank you for your patronage!"
    End Function

    '| - MISC - |
    Public Overrides Sub buildShopArea(ByRef floor As mFloor)
        MyBase.buildShopArea(floor)

        Dim crates = {New Point(pos.X - 1, pos.Y)}
        If floor.ptInBounds(crates(0)) AndAlso floor.mBoard(crates(0).Y, crates(0).X).Tag = 0 Then crates(0) = New Point(pos.X, pos.Y - 1)

        Dim barrels = {New Point(pos.X + 1, pos.Y)}
        If floor.ptInBounds(barrels(0)) AndAlso floor.mBoard(barrels(0).Y, barrels(0).X).Tag = 0 Then barrels(0) = New Point(pos.X, pos.Y + 1)

        For Each pt In crates
            If floor.ptInBounds(pt) Then floor.mBoard(pt.Y, pt.X).Text = "£"
        Next

        For Each pt In barrels
            If floor.ptInBounds(pt) Then floor.mBoard(pt.Y, pt.X).Text = "¢"
        Next
    End Sub
End Class
