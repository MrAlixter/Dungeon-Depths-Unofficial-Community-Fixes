Public Class ShadyWizard
    Inherits ShopNPC
    Sub New()
        setName("Shady Wizard")
        setHealth(1.0)
        setMaxHealth(9999)
        setATK(999)
        setDEF(99)
        setSPD(99)
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
        inv.setCount("Cowbell", 1)
        inv.setCount("Gold_Adornment", 1)
        inv.setCount("Crystalline_Armor", 1)

        'Weapons
        inv.setCount("Duster", 1)
        inv.setCount("Scepter_of_Ash", 1)

        isShop = True
        setGold(99999)
        pronoun = "he"
        pPronoun = "his"
        rPronoun = "him"
        picNormal = Game.picSW.BackgroundImage
        picPrincess = Game.picSWPrin.BackgroundImage
        picBunny = Game.picSWb.BackgroundImage

        If speed = Game.player.speed Then speed -= 1
        title = " the "
    End Sub

    Public Overrides Sub encounter()
        MyBase.encounter()
        If npcIndex = 0 Then
            If CInt(Game.player.health * Game.player.getMaxHealth()) = 69 Then
                Game.pushNPCDialog("Ehehe. Your health. Nice." & vbCrLf & "Anyway, what are you buying?")
            Else
                Game.pushNPCDialog("What are you buying?")
            End If
        ElseIf npcIndex = 1 Then
            Game.pushNPCDialog("Ribbit.  Ribbit!")
        ElseIf npcIndex = 2 Then
            Game.pushNPCDialog("*bleets*")
        ElseIf npcIndex = 3 Then
            Game.pushNPCDialog("Hey, " & Game.player.pClass.name & ", how's it going?")
        ElseIf npcIndex = 4 Then
            Game.pushNPCDialog("So are these real or fake?  My ears, I mean.")
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
End Class
