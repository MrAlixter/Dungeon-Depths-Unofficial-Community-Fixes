Public Class Shopkeeper
    Inherits ShopNPC
    Sub New()
        name = "Shopkeeper"
        health = 1.0
        maxHealth = 9999
        attack = 99
        defense = 999
        speed = 99

        'Define the inventory
        inv = New Inventory(False)
        'Useables
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

        isShop = True
        gold = 99999
        pronoun = "he"
        pPronoun = "his"
        rPronoun = "him"
        picNormal = ShopNPC.npcLib.atrs(0).getAt(0)
        picPrincess = ShopNPC.npcLib.atrs(0).getAt(2)
        picBunny = ShopNPC.npcLib.atrs(0).getAt(1)
        picArachne = ShopNPC.npcLib.atrs(0).getAt(67)

        picNPC = New List(Of Image)
        picNPC.AddRange({picNormal, ShopNPC.npcLib.atrs(0).getAt(4), ShopNPC.npcLib.atrs(0).getAt(5), picPrincess, picBunny})

        picNPC.AddRange({ShopNPC.npcLib.atrs(0).getAt(3), picArachne})
        If speed = Game.player1.speed Then speed -= 1
        title = " the "
    End Sub

    Public Overrides Sub encounter()
        MyBase.encounter()

        MyBase.discount = 0

        If Game.mDun.numCurrFloor < 2 Then
            inv.setCount("Scale_Armor", 1)
            inv.setCount("Gold_Armor", 0)
            inv.setCount("Midas_Gauntlet", 0)
        Else
            inv.setCount("Scale_Armor", 1)
            inv.setCount("Gold_Armor", 1)
            inv.setCount("Midas_Gauntlet", 1)
        End If

        If npcIndex = 0 Then
            If Game.player1.quests(0).canGet Then
                Game.player1.quests(0).init()
                Game.pushNPCDialog("""Hey, can I ask for your help on something?  I've been seeing a lot of people roaming around here with those collars looking for valubles, and that got me thinking... Why don't I expand my staff?  If you can snip off a few of their collars and send them my way,  I can make it worth your time.""" & DDUtils.RNRN &
                                   "Quest ""Help Wanted"" aquired!" & vbCrLf & "+1 Old Snips")
                Exit Sub
            End If
            Game.pushNPCDialog("Hey, what's up?")
        ElseIf npcIndex = 6 Then
            Game.pushNPCDialog("Hey, what's up?")
        ElseIf npcIndex = 1 Then
            Game.pushNPCDialog("Ribbit.  Ribbit.")
        ElseIf npcIndex = 2 Then
            Game.pushNPCDialog("Baaahhh.")
        ElseIf npcIndex = 3 Then
            Game.pushNPCDialog("Hello, kind " & Game.player1.className & ", how are you on this fine day?")
        ElseIf npcIndex = 4 Then
            Game.pushNPCDialog("*giggle* Hey!")
        ElseIf npcIndex = 5 Then
            Game.pushNPCDialog("...")
        End If

        If npcIndex = getArachneImageInd() And Not Game.player1.formName.Equals("Arachne") Then inv.setCount(244, 1) Else inv.setCount(244, 0)

    End Sub
    Public Overrides Function toFight() As String
        If npcIndex = 0 Or npcIndex = 6 Then
            Return "So you want to fight, eh?  I'm ready whenever you are."
        ElseIf npcIndex = 1 Then
            Return "Ribbit . . ."
        ElseIf npcIndex = 2 Then
            Return "BAAAAAHHHH!"
        ElseIf npcIndex = 3 Then
            Return "You would dare to challenge me? If you wish to die, you could just say so."
        ElseIf npcIndex = 4 Then
            Return "I might not be the best fighter any more, but I can definitely give it my best!"
        ElseIf npcIndex = 5 Then
            Return "..."
        End If
        Return "Bad move."
    End Function
    Public Overrides Function hitBySpell() As String
        If npcIndex = 0 Or npcIndex = 6 Then
            Game.NPCtoCombat(Me)
            Return "Did . . . did you just cast a spell on me?  You know I have to kill you now, right?"
        ElseIf npcIndex = 1 Then
            Game.NPCtoCombat(Me)
            Return "Ribbit!!!"
        ElseIf npcIndex = 2 Then
            Game.NPCtoCombat(Me)
            Return "[angry bleets]!"
        ElseIf npcIndex = 3 Then
            Game.NPCtoCombat(Me)
            Return "Casting spells on royalty is genrally not a good idea."
        ElseIf npcIndex = 4 Then
            Return "*giggle* Was that magic?"
        ElseIf npcIndex = 5 Then
            Return "..."
        End If
        Return "Woah there!"
    End Function

    Public Overrides Function reactToSpell(spell As String) As Boolean
        If Rnd() < (0.01) Then
            Return True
        Else
            Game.pushLstLog("The spell bounces off the Shopkeeper!")
            Game.pushLblCombatEvent("The spell bounces off the Shopkeeper!")
            Return False
        End If
    End Function

    Public Overrides Sub playerDeath(ByRef p As Player)
        Game.fromCombat()
        p.petrify(Color.Goldenrod, 9999)
        Dim out As String = """You should have known better than to try and rob a shop keeper,"" the shopkeep says," &
            " glaring down at you, ""...and if its gold you're after, I guess I've got some good news for you.""" &
            "  With that, " & pronoun & " reaches into " & pPronoun & " bag and puts on a gaudy gauntlet " &
            "that begins glowing with a golden light. You lack the strength to fight back as " & pronoun & " places" &
            " his thumb on your forhead, and suddenly everything just seems so heavy. ""Noooo..."" you moan, " &
            "as the area around where he touched turns to gold, and that gold turns your flesh and blood " &
            "around it to gold as well. In a matter of seconds, all that is left of " & p.name & " the " &
            p.className & " is a solid gold statue. The shopkeeper sighs, muttering to no one in particular, " & vbCrLf &
         """Now how am I going to get you back to the refinery?""" & DDUtils.RNRN & "GAME OVER!"
        Game.pushLblEvent(out, AddressOf p.die)
        p.changeClass("Trophy")
    End Sub
End Class
