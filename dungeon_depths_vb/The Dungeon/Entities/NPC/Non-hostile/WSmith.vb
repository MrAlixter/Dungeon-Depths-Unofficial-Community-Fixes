Public Class WSmith
    Inherits ShopNPC
    Sub New()
        name = "Weaponsmith"
        health = 1.0
        maxHealth = 99
        attack = 9999
        defense = 9999
        speed = 99

        'Define the inventory
        inv = New Inventory(False)
        'Weapons
        inv.setCount("Bronze_Spear", 1)
        inv.setCount("Steel_Spear", 1)
        inv.setCount("Flaming_Spear", 1)
        inv.setCount("Signature_Spear", 1)
        inv.setCount("Signature_Staff", 1)
        inv.setCount("Spiked_Staff", 1)
        inv.setCount("Throwing_Knife", 1)
        inv.setCount("Signature_Dagger", 1)
        inv.setCount("Flaming_Sword", 1)
        inv.setCount("Signature_Whip", 1)


        isShop = True
        gold = 99999
        pronoun = "she"
        pPronoun = "her"
        rPronoun = "her"
        picNormal = ShopNPC.npcLib.atrs(0).getAt(25)
        picPrincess = ShopNPC.npcLib.atrs(0).getAt(27)
        picBunny = ShopNPC.npcLib.atrs(0).getAt(26)
        picArachne = ShopNPC.npcLib.atrs(0).getAt(71)

        picNPC = New List(Of Image)
        picNPC.AddRange({picNormal,
                         ShopNPC.npcLib.atrs(0).getAt(4),
                         ShopNPC.npcLib.atrs(0).getAt(5),
                         picPrincess,
                         picBunny})

        picNPC.AddRange({ShopNPC.npcLib.atrs(0).getAt(29),
                         ShopNPC.npcLib.atrs(0).getAt(30),
                         ShopNPC.npcLib.atrs(0).getAt(31),
                         ShopNPC.npcLib.atrs(0).getAt(28),
                         picArachne})

        If speed = Game.player1.speed Then speed -= 1
        title = " the "
    End Sub

    Public Overrides Sub encounter()
        MyBase.encounter()

        discount = 0

        If npcIndex = 0 Then
            If Int(Rnd() * 2) = 0 Then
                npcIndex = 5
                Game.pushNPCDialog("I'm still getting everything moved in, but feel free to check out what I've got ready so far.  I should be operating at 100% by the time 0.9 rolls around, so stay in touch, ok?")
            ElseIf Int(Rnd() * 20) = 1 Then
                npcIndex = 6
                Game.pushNPCDialog("So I was working on smelting down some scrapped weapons and, uh, I think I'm cursed now.  Let's make " &
                                   "this quick so that I can track down an old friend of mine who's pretty good at dealing with this sort " &
                                   "of stuff.  Hopefully they're around, because I'd rather just stay like this than ask that shady dick of " &
                                   "a wizard for any help...")
            Else
                Game.pushNPCDialog("Hey wanderer, what's going on?  I've got the firepower to keep a mobile forge burning basically wherever I go, " &
                                   "and that means I can get you the best damn weapons you've ever seen hot off the anvil!  I can tell you're not " &
                                   "just looking for something pointy though. If you want that top-shelf quality I've got a signature series " &
                                   "of stabby stuff that's been through an quick enchanting process." & DDUtils.RNRN &
                                   "Let me know what I'm banging out, ok?")
            End If
        ElseIf npcIndex = 1 Then
            Game.pushNPCDialog("...")
        ElseIf npcIndex = 2 Then
            Game.pushNPCDialog("...")
        ElseIf npcIndex = 3 Then
            Game.pushNPCDialog("Oh my, I appear to have broken a nail.  I suppose it comes with the title of ""Princess of Smithery"" to get my hands dirty, but I should still be more careful...")
        ElseIf npcIndex = 4 Then
            Game.pushNPCDialog("*giggle* Let me know what you, like, need and I'll totally hop to it, cutie! *fit of giggles*")
        ElseIf npcIndex = 7 Then
            Game.pushNPCDialog("...")
        ElseIf npcIndex = 9 Then
            If Game.player1.formName.Equals("Arachne") Then
                Game.pushNPCDialog("I'm suprised more members of the sisterhood don't have any intrest in metal arms and armor.  Well, let me know if you see anything you like!")
            Else
                Game.pushNPCDialog("Heeeey, you wouldn't mind drinking some of this venom, right?  I'd hate if another arachne ate one of my best customers...")
            End If

        End If

        Game.picNPC.BackgroundImage = picNPC(npcIndex)
    End Sub

    Public Overrides Function toFight() As String
        If npcIndex = 0 Or npcIndex = 9 Then
            Return "Unless you're packing some serious magic, probably not your best move..."
        ElseIf npcIndex = 1 Then
            Return "CROoooOOOAK!"
        ElseIf npcIndex = 2 Then
            Return "*nervous bleets*"
        ElseIf npcIndex = 3 Then
            Return "As a warrior princess I shall not refuse this duel...  I shall end thou rightly!"
        ElseIf npcIndex = 4 Then
            Return "*giggle* I'll show you just how, like, cute I am, even in a fight!"
        ElseIf npcIndex = 7 Then
            Return "..."
        End If
        Return "Unless you're packing some serious magic, probably not your best move..."
    End Function
    Public Overrides Function hitBySpell() As String
        If npcIndex = 0 Then
            Game.NPCtoCombat(Me)
            Return "W-w-wait, don't try turning me into anything gross, ok?"
        ElseIf npcIndex = 1 Then
            Game.NPCtoCombat(Me)
            Return "!!!"
        ElseIf npcIndex = 2 Then
            Game.NPCtoCombat(Me)
            Return "!!!"
        ElseIf npcIndex = 3 Then
            Return "You now face the ""Princess of Smithery"", mage!"
        ElseIf npcIndex = 4 Then
            Return "Woah, everything's so...shiny...."
        ElseIf npcIndex = 7 Then
            Return "..."
        ElseIf npcIndex = 9 Then
            Game.NPCtoCombat(Me)
            Return "Magic isn't going to get you out of this one..."
        End If

        Game.NPCtoCombat(Me)
        Return "W-w-wait, don't try turning me into anything gross, ok?"
    End Function

    Public Overrides Function getArachneImageInd() As Integer
        Return 9
    End Function

    Public Overrides Sub toDoll()
        Game.pushNPCDialog("...")
        Game.picNPC.BackgroundImage = picNPC(7)

        discount = 0.5
    End Sub
End Class
