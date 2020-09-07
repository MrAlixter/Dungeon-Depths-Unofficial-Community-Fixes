Public Class CBrok
    Inherits ShopNPC
    Sub New()
        name = "Curse Broker"
        health = 1.0
        maxHealth = 99999
        attack = 99999
        defense = 99999
        speed = 99999

        'Define the inventory
        inv = New Inventory(False)
        'Useables
        inv.setCount("Anti_Curse_Tag", 1)
        inv.setCount("Magical_Girl_Wand​", 1)
        inv.setCount(174, 1)
        inv.setCount(200, 1)

        isShop = True
        gold = 99999
        pronoun = "they"
        pPronoun = "their"
        rPronoun = "them"
        picNormal = ShopNPC.npcLib.atrs(0).getAt(35)
        picPrincess = ShopNPC.npcLib.atrs(0).getAt(36)
        picBunny = ShopNPC.npcLib.atrs(0).getAt(37)

        picNPC = New List(Of Image)
        picNPC.AddRange({picNormal, ShopNPC.npcLib.atrs(0).getAt(4), ShopNPC.npcLib.atrs(0).getAt(5), picPrincess, picBunny})

        picNPC.AddRange({ShopNPC.npcLib.atrs(0).getAt(38)})
        If speed = Game.player1.speed Then speed -= 1
        title = " the "
    End Sub

    Public Overrides Sub encounter()
        MyBase.encounter()
        If Not Game.player1.isCursed Then
            npcIndex = 0
            Game.pushNPCDialog("What have you gotten yourself into this time?  Nothing?  Perhaps there's a curse somewhere out there for you...")
        Else
            npcIndex = 3
            Game.pushNPCDialog("Oh, so you're cursed? Truely a tragedy; if you'd like I can take care of that for you...")
        End If
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
        Game.picNPC.BackgroundImage = picBunny
        Game.picNPC.Location = New Point(82 * Game.Size.Width / 1024, 179 * Game.Size.Width / 1024)
        Game.picNPC.Visible = True
        If Game.npcmode Then Game.hideNPCButtons()
        Game.pushNPCDialog("So be it.  While I'm not suprised by this betrayal, it's nonetheless disappointing. Your actions " &
                           "will result in nothing but future hardship, and moving forward I hope you get cursed into ȏ̸̞͕ḅ̷̨͠ļ̴̮́í̶̯͒v̵̪̤̓͠í̵̻̩͆o̵̰̼̓n̵͈̄. " & DDUtils.RNRN &
                           "I certainly won't stick around to save you.", AddressOf leave)
    End Sub

    Sub leave()
        applyCurses(Game.player1)
        isDead = True
        Game.leaveNPC()
    End Sub

    Sub applyCurses(ByRef p As Player)
        'Amnesia
        If Int(Rnd() * 5) = 0 Then
            p.knownSpells.Clear()
            p.knownSpecials.Clear()
            Game.pushLstLog("You've been afflicted with the curse of Amnesia!")
        End If
        'Blindness
        If Int(Rnd() * 5) = 0 Then
            p.perks(perk.coblind) = 2
            Game.pushLstLog("You've been afflicted with the curse of Blindness!")
        End If
        'Claustrophobia
        If Int(Rnd() * 5) = 0 Then
            Game.mBoardHeight = 10
            Game.mBoardWidth = 10
            Game.pushLstLog("You've been afflicted with the curse of Claustrophobia!")
        End If
        'Greed
        If Int(Rnd() * 5) = 0 Then
            p.perks(perk.cogreed) = 2
            Game.pushLstLog("You've been afflicted with the curse of Greed!")
        End If
        'Milk
        If Int(Rnd() * 5) = 0 Then
            p.perks(perk.comilk) = 2
            Game.pushLstLog("You've been afflicted with the curse of Milk!")
        End If
        'Polymorph
        If Int(Rnd() * 5) = 0 Then
            p.perks(perk.copoly) = 7
            Game.pushLstLog("You've been afflicted with the curse of Polymorph!")
        End If
        'Rusting
        If Int(Rnd() * 5) = 0 Then
            p.perks(perk.corust) = 2
            Game.pushLstLog("You've been afflicted with the curse of Rusting!")
        End If
        'Tits
        If Int(Rnd() * 5) = 0 Then
            p.breastSize = 6
            Game.pushLstLog("You've been afflicted with the curse of Tits!")
            p.drawPort()
        End If
        'Servitude
        If Int(Rnd() * 5) = 80 Then
            p.ongoingTFs.add(New COServ)
            Game.pushLstLog("You've been afflicted with the curse of Servitude!")
        End If
    End Sub

    Public Overrides Sub toBunny()
        badForYou()
    End Sub
    Public Overrides Sub toFrog()
        badForYou()
    End Sub
    Public Overrides Sub toSheep()
        badForYou()
    End Sub
    Public Overrides Sub toPrincess()
        badForYou()
    End Sub
End Class
