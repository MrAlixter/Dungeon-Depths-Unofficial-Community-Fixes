Public Class Shopkeeper
    Inherits ShopNPC
    Sub New()
        name = "Shopkeeper"
        health = 1.0
        maxHealth = 9999
        attack = 99
        defence = 999
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

        picNCP = New List(Of Image)
        picNCP.AddRange({picNormal, ShopNPC.npcLib.atrs(0).getAt(4), ShopNPC.npcLib.atrs(0).getAt(5), picPrincess, picBunny})

        picNCP.AddRange({ShopNPC.npcLib.atrs(0).getAt(3)})
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
            Game.pushNPCDialog("Hey, what's up?")
        ElseIf npcIndex = 1 Then
            Game.pushNPCDialog("Ribbit.  Ribbit.")
        ElseIf npcIndex = 2 Then
            Game.pushNPCDialog("Baaahhh.")
        ElseIf npcIndex = 3 Then
            Game.pushNPCDialog("Hello, kind " & Game.player1.pClass.name & ", how are you on this fine day?")
        ElseIf npcIndex = 4 Then
            Game.pushNPCDialog("*giggle* Hey!")
        ElseIf npcIndex = 5 Then
            Game.pushNPCDialog("...")
        End If
    End Sub
    Public Overrides Function toFight() As String
        If npcIndex = 0 Then
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
        If npcIndex = 0 Then
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
End Class
