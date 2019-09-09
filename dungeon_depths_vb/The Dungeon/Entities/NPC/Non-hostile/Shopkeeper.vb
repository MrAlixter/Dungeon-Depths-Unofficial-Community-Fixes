Public Class Shopkeeper
    Inherits ShopNPC
    Sub New()
        setName("Shopkeeper")
        setHealth(1.0)
        setMaxHealth(9999)
        setATK(99)
        setDEF(999)
        setSPD(99)

        'Define the inventory
        inv = New Inventory(False)
        'Useables
        inv.setCount("Compass", 1)
        inv.setCount("Spellbook", 1)
        inv.setCount("Major_Health_Potion", 1)
        'Potions
        inv.setCount("Health_Potion", 1)
        inv.setCount("Mana_Potion", 1)
        inv.setCount("Anti_Venom", 1)
        'Food
        inv.setCount("Chicken_Leg", 1)
        'Armor/Accesories
        inv.setCount("Bronze_Armor", 1)
        inv.setCount("Steel_Armor", 1)
        inv.setCount("Gold_Armor", 1)
        'Weapons
        inv.setCount("Steel_Sword", 1)
        inv.setCount("Oak_Staff", 1)
        inv.setCount("Gold_Sword", 1)
        inv.setCount("Golden_Staff", 1)
        inv.setCount("Midas_Gauntlet", 1)

        isShop = True
        setGold(99999)
        pronoun = "he"
        pPronoun = "his"
        rPronoun = "him"
        picNormal = Game.picShopkeep.BackgroundImage
        picPrincess = Game.picSKPrin.BackgroundImage
        picBunny = Game.picSKBunny.BackgroundImage

        If speed = Game.player.speed Then speed -= 1
        title = ""
    End Sub

    Public Overrides Sub encounter()
        MyBase.encounter()
        If npcIndex = 0 Then
            Game.pushNPCDialog("Hey, what's up?")
        ElseIf npcIndex = 1 Then
            Game.pushNPCDialog("Ribbit.  Ribbit.")
        ElseIf npcIndex = 2 Then
            Game.pushNPCDialog("Baaahhh.")
        ElseIf npcIndex = 3 Then
            Game.pushNPCDialog("Hello, kind " & Game.player.pClass.name & ", how are you on this fine day?")
        ElseIf npcIndex = 4 Then
            Game.pushNPCDialog("*giggle* Hey!")
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
        End If
        Return "Woah there!"
    End Function
End Class
