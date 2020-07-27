Public Class MaskedMG
    Inherits ShopNPC
    Sub New()
        name = "Magical Girl"
        health = 1.0
        maxHealth = 99999
        attack = 9999
        defence = 999
        speed = 99

        'Define the inventory
        inv = New Inventory(False)
        inv.setCount("Gem_of_Progress", 1)
        inv.setCount("Gem_of_Sweetness", 1)
        inv.setCount("Gem_of_Flame", 1)
        inv.setCount("Gem_of_Darkness", 1)

        isShop = True
        gold = 99999
        pronoun = "she"
        pPronoun = "her"
        rPronoun = "her"
        picNormal = ShopNPC.npcLib.atrs(0).getAt(45)
        picPrincess = ShopNPC.npcLib.atrs(0).getAt(47)
        picBunny = ShopNPC.npcLib.atrs(0).getAt(46)

        picNCP = New List(Of Image)
        picNCP.AddRange({picNormal, ShopNPC.npcLib.atrs(0).getAt(4), ShopNPC.npcLib.atrs(0).getAt(5), picPrincess, picBunny})

        picNCP.AddRange({ShopNPC.npcLib.atrs(0).getAt(48), ShopNPC.npcLib.atrs(0).getAt(59)})
        If speed = Game.player1.speed Then speed -= 1
        title = " the "
    End Sub

    Public Overrides Sub encounter()
        MyBase.encounter()

        If Int(Rnd() * 25) = 0 Then
            npcIndex = 4
            Game.pushNPCDialog("Hey, like, have you seen a shadowy guy with a hood?  He TOTALLY put some sorta curse on my wand!  It's not like I, uh, wanted to get all, like, ditzy to have some fun or whatever...")
        ElseIf Int(Rnd() * 25) = 0 Then
            npcIndex = 6
            Game.pushNPCDialog("Hey kid, how'd you like a quick and easy path to power?  I've got just the rock for you if you don't mind a bit of darkness....")
            inv.item("Gem_of_Darkness").value -= 0.8 * inv.item("Gem_of_Darkness").value
        Else
            npcIndex = 0
            Game.pushNPCDialog("Always a pleasure to run across another Magic Girl!  What can I get ya?")
        End If

        Game.picNPC.BackgroundImage = picNCP(npcIndex)
    End Sub

    Public Overrides Function toFight() As String
        badForYou()
        Return ""
    End Function
    Public Overrides Function hitBySpell() As String
        badForYou()
        Return ""
    End Function

    Sub badForYou()
        If Game.combatmode Then Game.fromCombat()
        Game.picNPC.BackgroundImage = picPrincess
        Game.picNPC.Location = New Point(82 * Game.Size.Width / 1024, 179 * Game.Size.Width / 1024)
        Game.picNPC.Visible = True
        If Game.npcmode Then Game.hideNPCButtons()
        Game.pushNPCDialog("Woah there, rookie, don't do anything crazy now.  I'm going to give you some space for now, but if you keep pushing me you're gonna regret it...", AddressOf leave)
    End Sub
    Sub leave()
        Game.player1.pos = Game.currFloor.randPoint()
        isDead = True
        Game.leaveNPC()
    End Sub

    Public Overrides Sub toDoll()
        Game.pushNPCDialog("*squeek*")
        Game.picNPC.BackgroundImage = picNCP(5)

        discount = 0.5
    End Sub
End Class
