Public Class ShadyWizard
    Inherits ShopNPC
    Sub New()
        name = "Shady Wizard"
        health = (1.0)
        maxHealth = (9999)
        attack = (999)
        defense = (99)
        speed = (99)
        'Define the inventory
        inv = New Inventory(False)
        'Useables
        inv.setCount("Spellbook", 1)
        inv.setCount("Mana_Charm", 1)
        'Potions
        inv.setCount("Mana_Potion", 1)

        'Foods
        inv.setCount("Apple​", 1)
        inv.setCount("Angel_Food_Cake", 1)
        inv.setCount("Stick_of_Gum", 1)
        inv.setCount("Berry_Stick_of_Gum", 1)
        inv.setCount("Melon_Stick_of_Gum", 1)

        'Armors
        inv.setCount("Bronze_Bikini", 1)
        inv.setCount("Bunny_Suit", 1)
        inv.setCount("Witch_Cosplay", 1)
        inv.setCount("Brawler_Cosplay", 1)
        inv.setCount(perk.cowbell, 1)
        inv.setCount("Crystalline_Armor", 1)

        'Weapons
        inv.setCount("Duster", 1)
        inv.setCount("Scepter_of_Ash", 1)

        isShop = True
        gold = 99999
        pronoun = "he"
        pPronoun = "his"
        rPronoun = "him"
        picNormal = ShopNPC.npcLib.atrs(0).getAt(6)
        picPrincess = ShopNPC.npcLib.atrs(0).getAt(8)
        picBunny = ShopNPC.npcLib.atrs(0).getAt(7)

        picNCP = New List(Of Image)
        picNCP.AddRange({picNormal, ShopNPC.npcLib.atrs(0).getAt(4), ShopNPC.npcLib.atrs(0).getAt(5), picPrincess, picBunny})

        picNCP.AddRange({ShopNPC.npcLib.atrs(0).getAt(9)})
        If speed = Game.player1.speed Then speed -= 1
        title = " the "
    End Sub

    Public Overrides Sub encounter()

        If Game.mDun.numCurrFloor < 3 Then
            inv.setCount("Scale_Bikini", 1)
        Else
            inv.setCount("Gold_Adornment", 1)
        End If

        MyBase.encounter()

        MyBase.discount = 0

        If npcIndex = 0 Then
            If CInt(Game.player1.health * Game.player1.getMaxHealth()) = 69 Then
                Game.pushNPCDialog("Ehehe. Your health. Nice." & vbCrLf & "Anyway, what are you buying?")
            Else
                Game.pushNPCDialog("What are you buying?")
            End If
        ElseIf npcIndex = 1 Then
            Game.pushNPCDialog("Ribbit.  Ribbit!")
        ElseIf npcIndex = 2 Then
            Game.pushNPCDialog("*bleets*")
        ElseIf npcIndex = 3 Then
            Game.pushNPCDialog("Hey, " & Game.player1.pClass.name & ", how's it going?")
        ElseIf npcIndex = 4 Then
            Game.pushNPCDialog("So are these real or fake?  My ears, I mean.")
        ElseIf npcIndex = 5 Then
            Game.pushNPCDialog("...")
        End If
    End Sub

    Public Overrides Function toFight() As String
        If npcIndex = 0 Then
            Return "Alright, get ready to fight.  This ain't going well for you."
        ElseIf npcIndex = 1 Then
            Return "Ribbit . . ."
        ElseIf npcIndex = 2 Then
            Return "BAAAAAHHHH!"
        ElseIf npcIndex = 3 Then
            Return "Get ready, I was trained by the royal mage's guild and I certainly won't submit easily."
        ElseIf npcIndex = 4 Then
            Return "Whaaaat!?!"
        ElseIf npcIndex = 5 Then
            Return "..."
        End If
        Return "Bad move."
    End Function
    Public Overrides Function hitBySpell() As String
        If npcIndex = 0 Then
            Game.NPCtoCombat(Me)
            Return "Ha!  That's just sloppy."
        ElseIf npcIndex = 1 Then
            Game.NPCtoCombat(Me)
            Return "Ribbit!!!"
        ElseIf npcIndex = 2 Then
            Game.NPCtoCombat(Me)
            Return "[angry bleets]!"
        ElseIf npcIndex = 3 Then
            Game.NPCtoCombat(Me)
            Return "I've seen better spellwork, but that was a decent attempt."
        ElseIf npcIndex = 4 Then
            Return "That's neat!"
        ElseIf npcIndex = 5 Then
            Return "..."
        End If
        Return "Woah there!"
    End Function

    Public Overrides Sub toFemale(form As String)
        MyBase.toFemale(form)
        setName("Shady Witch")
    End Sub
    Public Overrides Sub toMale(form As String)
        MyBase.toMale(form)
        setName("Shady Wizard")
    End Sub

    Public Overrides Sub toDoll()
        MyBase.toDoll()
        MyBase.npcIndex = 5
        Game.npcIndex = 5
        isShop = False
    End Sub
End Class
