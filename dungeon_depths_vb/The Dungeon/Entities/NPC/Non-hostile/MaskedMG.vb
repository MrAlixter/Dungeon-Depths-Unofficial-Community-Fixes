Public Class MaskedMG
    Inherits ShopNPC
    Sub New()
        MyBase.New()

        '|ID Info|
        name = "Magical Girl"
        sName = name
        npc_index = ShopNPCInd.maskmaggirl

        '|NPC Flags|
        pronoun = "she"
        p_pronoun = "her"
        r_pronoun = "her"
        isShop = True

        '|Inventory|
        inv.setCount(GemOfProg.ITEM_NAME, 1)
        inv.setCount(GemOfPink.ITEM_NAME, 1)
        inv.setCount(GemOfFlame.ITEM_NAME, 1)
        inv.setCount(GemOfDark.ITEM_NAME, 1)
        inv.setCount(GemOfIvy.ITEM_NAME, 1)

        inv.setCount(MGReset.ITEM_NAME, 1)

        '|Stats|
        health = 1.0
        maxHealth = 99999
        attack = 9999
        defense = 999
        will = 999
        speed = 99
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

        local_img.Add(LocalImgInd.normal, ShopNPC.gbl_img.atrs(0).getAt(45))
        local_img.Add(LocalImgInd.frog, ShopNPC.gbl_img.atrs(0).getAt(4))
        local_img.Add(LocalImgInd.sheep, ShopNPC.gbl_img.atrs(0).getAt(5))
        local_img.Add(LocalImgInd.doll, ShopNPC.gbl_img.atrs(0).getAt(48))
        local_img.Add(LocalImgInd.arachne, ShopNPC.gbl_img.atrs(0).getAt(72))
        local_img.Add(LocalImgInd.catgirl, ShopNPC.gbl_img.atrs(0).getAt(95))
        local_img.Add(LocalImgInd.trilobite, ShopNPC.gbl_img.atrs(0).getAt(96))
        local_img.Add(LocalImgInd.beegirl, ShopNPC.gbl_img.atrs(0).getAt(148))
        local_img.Add(LocalImgInd.alt1, ShopNPC.gbl_img.atrs(0).getAt(46))
        local_img.Add(LocalImgInd.alt2, ShopNPC.gbl_img.atrs(0).getAt(47))
        local_img.Add(LocalImgInd.alt3, ShopNPC.gbl_img.atrs(0).getAt(59))
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        attackSpell(target, "Howitzer of Love", MyBase.getWIL)
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
        TextEvent.pushNPCDialog("Woah there, rookie, don't do anything crazy now.  I'm going to give you some space for now, but if you keep pushing me you're gonna regret it...", AddressOf leave)
    End Sub
    Sub leave()
        Game.player1.pos = Game.currFloor.randPoint()
        isDead = True
        Game.leaveNPC()
    End Sub

    '| - DIALOG - |
    Protected Overrides Function normalDialog(ByRef p As Player)
        If Int(Rnd() * 25) = 0 And hasMetPlayer Then
            img_index = LocalImgInd.alt1
            Return "Hey, like, have you seen that spooky red guy with a hood?  He TOTALLY put some sorta curse on my wand!" & DDUtils.RNRN &
                   "It's not like I, uh, wanted to get, um, turned all, like, ditzy or whatever..."
        ElseIf Int(Rnd() * 25) = 0 And hasMetPlayer Then
            img_index = LocalImgInd.alt3
            inv.item("Gem_of_Darkness").value -= 0.8 * inv.item("Gem_of_Darkness").value
            Return "Hey kid, how'd you like a quick and easy path to power?  I've got just the rock for you if you don't mind a bit of darkness...."
        Else
            img_index = LocalImgInd.normal
            Return "Always a pleasure to run across another Magic Girl!  What can I get ya?"
        End If
    End Function
    Protected Overrides Function arachneDialog(ByRef p As Player)
        If Game.player1.formName.Equals("Arachne") Then
            Return "Arachne or not, there are still dummies out there that need protectin'!"
        Else
            Return "Hey, if I were to roll out a ""Gem Of Spiders"" do you think you'd take the plunge into eight-legged glory?  Well, I've got the next best thing in the meantime!"
        End If
    End Function

    Public Overrides Function postPurchaseDialog(ByRef p As Player) As Object
        Return "Anything else I can get ya?"
    End Function

    '| - MISC - |
    Public Overrides Sub buildShopArea(ByRef floor As mFloor)
        MyBase.buildShopArea(floor)

        Dim mannequins = {New Point(pos.X - 1, pos.Y)}
        If floor.ptInBounds(mannequins(0)) AndAlso floor.mBoard(mannequins(0).Y, mannequins(0).X).Tag = 0 Then mannequins(0) = New Point(pos.X, pos.Y - 1)

        Dim mannequin2s = {New Point(pos.X + 1, pos.Y)}
        If floor.ptInBounds(mannequin2s(0)) AndAlso floor.mBoard(mannequin2s(0).Y, mannequin2s(0).X).Tag = 0 Then mannequin2s(0) = New Point(pos.X, pos.Y - 1)

        For Each pt In mannequins
            If floor.ptInBounds(pt) Then floor.mBoard(pt.Y, pt.X).Text = "ø"
        Next

        For Each pt In mannequin2s
            If floor.ptInBounds(pt) Then floor.mBoard(pt.Y, pt.X).Text = "æ"
        Next
    End Sub
End Class
