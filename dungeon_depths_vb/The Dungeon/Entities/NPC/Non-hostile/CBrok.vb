Public Class CBrok
    Inherits ShopNPC
    Sub New()
        MyBase.New()

        '|ID Info|
        name = "Curse Broker"
        sName = name
        npc_index = ShopNPCInd.cursebroker

        '|NPC Flags|
        pronoun = "they"
        p_pronoun = "their"
        r_pronoun = "them"
        isShop = True

        '|Inventory|
        inv.setCount(AntiCurseTag.ITEM_NAME, 1)
        inv.setCount(CursedSword.ITEM_NAME, 1)
        inv.setCount(BewitchedWand.ITEM_NAME, 1)
        inv.setCount(JinxedWhip.ITEM_NAME, 1)
        inv.setCount(CursePurge.ITEM_NAME, 1)

        '|Stats|
        maxHealth = 99999
        attack = 99999
        defense = 99999
        speed = 99999
        will = 99999
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

        local_img.Add(LocalImgInd.normal, ShopNPC.gbl_img.atrs(0).getAt(35))
        local_img.Add(LocalImgInd.frog, ShopNPC.gbl_img.atrs(0).getAt(4))
        local_img.Add(LocalImgInd.sheep, ShopNPC.gbl_img.atrs(0).getAt(5))
        local_img.Add(LocalImgInd.doll, ShopNPC.gbl_img.atrs(0).getAt(38))
        local_img.Add(LocalImgInd.arachne, ShopNPC.gbl_img.atrs(0).getAt(73))
        local_img.Add(LocalImgInd.catgirl, ShopNPC.gbl_img.atrs(0).getAt(93))
        local_img.Add(LocalImgInd.trilobite, ShopNPC.gbl_img.atrs(0).getAt(96))
        local_img.Add(LocalImgInd.beegirl, ShopNPC.gbl_img.atrs(0).getAt(148))
        local_img.Add(LocalImgInd.bimbo, ShopNPC.gbl_img.atrs(0).getAt(158))
        local_img.Add(LocalImgInd.alt1, ShopNPC.gbl_img.atrs(0).getAt(36))
        local_img.Add(LocalImgInd.alt2, ShopNPC.gbl_img.atrs(0).getAt(37))
        local_img.Add(LocalImgInd.alt3, ShopNPC.gbl_img.atrs(0).getAt(139))
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
        If Game.combat_engaged Then Game.fromCombat()
        Game.picNPC.BackgroundImage = local_img(LocalImgInd.alt2)
        Game.picNPC.Location = New Point(82 * Game.Size.Width / 1024, 179 * Game.Size.Width / 1024)
        Game.picNPC.Visible = True
        If Game.shop_npc_engaged Then Game.hideNPCButtons()
        TextEvent.pushNPCDialog("So be it.  While I'm not suprised by this betrayal, it's nonetheless disappointing. Your actions will result in nothing but future hardship, and moving forward I hope you get cursed into ȏ̸̞͕ḅ̷̨͠ļ̴̮́í̶̯͒v̵̪̤̓͠í̵̻̩͆o̵̰̼̓n̵͈̄. " & DDUtils.RNRN &
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
            TextEvent.pushLog("You've been afflicted with the curse of Amnesia!")
        End If
        'Blindness
        If Int(Rnd() * 5) = 0 Then
            p.perks(perk.coblind) = 2
            TextEvent.pushLog("You've been afflicted with the curse of Blindness!")
        End If
        'Claustrophobia
        If Int(Rnd() * 5) = 0 Then
            Game.mBoardHeight = 10
            Game.mBoardWidth = 10
            TextEvent.pushLog("You've been afflicted with the curse of Claustrophobia!")
        End If
        'Greed
        If Int(Rnd() * 5) = 0 Then
            p.perks(perk.cogreed) = 2
            TextEvent.pushLog("You've been afflicted with the curse of Greed!")
        End If
        'Milk
        If Int(Rnd() * 5) = 0 Then
            p.perks(perk.comilk) = 2
            TextEvent.pushLog("You've been afflicted with the curse of Milk!")
        End If
        'Polymorph
        If Int(Rnd() * 5) = 0 Then
            p.perks(perk.copoly) = 7
            TextEvent.pushLog("You've been afflicted with the curse of Polymorph!")
        End If
        'Rusting
        If Int(Rnd() * 5) = 0 Then
            p.perks(perk.corust) = 2
            TextEvent.pushLog("You've been afflicted with the curse of Rusting!")
        End If
        'Tits
        If Int(Rnd() * 5) = 0 Then
            p.breastSize = 6
            TextEvent.pushLog("You've been afflicted with the curse of Tits!")
            p.drawPort()
        End If
        'Servitude
        If Int(Rnd() * 5) = 80 Then
            p.ongoingTFs.add(New COServ)
            TextEvent.pushLog("You've been afflicted with the curse of Servitude!")
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
    Public Overrides Sub toCatgirl()
        img_index = LocalImgInd.catgirl
        badForYou()
    End Sub
    Public Overrides Sub toTrilobite()
        badForYou()
    End Sub

    Public Overrides Sub encounter()
        floor10Adjustment()

        MyBase.encounter()
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
            img_index = LocalImgInd.alt3

            If Game.currFloor.mBoard(pos.Y, pos.X).Tag >= DDConst.PINK_MIST_OFFSET Then
                Return "Ooh, what a delightful affliction..." & DDUtils.RNRN &
                       "Are you taking deep breaths?"
            Else
                Return "You..." & DDUtils.RNRN &
                       "How dare you?  Breaking such a delightful curse..."
            End If
        End If

        If p.perks(perk.faecurse) > 1 Then
            img_index = LocalImgInd.normal
            Return "Ah, so you've spurned one of the faefolk?" & DDUtils.RNRN &
                   "An interesting choice... but not necessarily an unwise one.  Far better to anger them than to give up your name." & DDUtils.RNRN &
                   "Of course, to move forward you'll need to go through the Fae Queen now.  That curse seems made solely to provoke her, if you do battle I would suggest hiding your true name; perhaps her Namestealers may be of assistance there." & DDUtils.RNRN &
                   "Those former ""Fae Hunters"" may also still carry iron collars.  Iron is most effective against the fae..."
        ElseIf p.cursed Then
            img_index = LocalImgInd.normal
            Return "Oh, so you're cursed?" & DDUtils.RNRN &
                   "Truely a tragedy, if you'd like I can take care of that for you..."
        End If

        img_index = LocalImgInd.alt1
        Return "What have you gotten yourself into this time?  Nothing?  Perhaps there's a curse somewhere out there for you..."
    End Function
    Protected Overrides Function arachneDialog(ByRef p As Player)
        Return "So, so many eyes..."
    End Function
    Protected Overrides Function catgirlDialog(ByRef p As Player)
        Return "Meow indeed..."
    End Function
    Protected Overrides Function bimboDialog(ByRef p As Player)

        If p.perks(perk.faecurse) > 1 Then
            img_index = LocalImgInd.bimbo
            Return "Ah, so you've spu- um- made one of the faefolk mad?" & DDUtils.RNRN &
                   "A weird choice... but not nec- ness- um... maybe not a dumb one?  Totally better to make 'em angry than to give up your name." & DDUtils.RNRN &
                   "Of course, to move forward you'll need to talk to the Fae Queen now.  That curse seems made solely to p- like, make fun of her, so you should keep your name secret.  Maybe her Namestealers can help?" & DDUtils.RNRN &
                   "Hmm, I think, uh, someone... somewhere... you should get a iron collar?  Iron is, like, super-effective to the fae..."
        ElseIf p.cursed Then
            img_index = LocalImgInd.bimbo
            Return "Ooooh, you're cursed now?" & DDUtils.RNRN &
                   "*giggle*" & DDUtils.RNRN &
                   "That's, like, totally a t-tragedy.  If you want I can take care of that for you..."
        End If

        img_index = LocalImgInd.bimbo
        Return "What did you get yourself into this time?  Nothing?" & DDUtils.RNRN &
               "*giggle*" & DDUtils.RNRN &
               "Per- uh... maybe there's some sorta curse out there for you..."
    End Function

    Protected Overrides Function normalPostPurchaseDialog(ByRef p As Player) As String
        If Game.currFloor.pinkMist Then
            Return "Come back soon, cutie..."
        End If

        Return "Come back soon..."
    End Function
    Protected Overrides Function bimboPostPurchaseDialog(ByRef p As Player) As String
        Return "Come back soon, cutie..."
    End Function

    '| - MISC - |
    Public Overrides Sub buildShopArea(ByRef floor As mFloor)
        MyBase.buildShopArea(floor)

        Dim tables = {New Point(pos.X - 1, pos.Y)}
        If floor.ptInBounds(tables(0)) AndAlso floor.mBoard(tables(0).Y, tables(0).X).Tag = 0 Then tables(0) = New Point(pos.X, pos.Y - 1)

        Dim barrels = {New Point(pos.X + 1, pos.Y)}
        If floor.ptInBounds(barrels(0)) AndAlso floor.mBoard(barrels(0).Y, barrels(0).X).Tag = 0 Then barrels(0) = New Point(pos.X, pos.Y + 1)

        For Each pt In tables
            If floor.ptInBounds(pt) Then floor.mBoard(pt.Y, pt.X).Text = "¿"
        Next

        For Each pt In barrels
            If floor.ptInBounds(pt) Then floor.mBoard(pt.Y, pt.X).Text = "×"
        Next
    End Sub
End Class
