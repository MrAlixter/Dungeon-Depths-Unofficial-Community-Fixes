Public Class HypnoTeach
    Inherits ShopNPC

    Dim preHypnoID = 0

    Sub New()
        MyBase.New()

        '|ID Info|
        name = "Hypnotist Teacher"
        sName = name
        npc_index = ShopNPCInd.hypnoteach

        '|NPC Flags|
        pronoun = "she"
        p_pronoun = "her"
        r_pronoun = "her"
        isShop = True

        '|Inventory|
        inv.setCount("Advanced_Spellbook", 1)
        inv.item("Advanced_Spellbook").value -= 0.2 * MyBase.inv.item("Advanced_Spellbook").value
        inv.setCount("Spellbook", 1)
        inv.item("Spellbook").value -= 0.2 * MyBase.inv.item("Spellbook").value
        inv.setCount("Utility_Manual", 1)
        inv.item("Utility_Manual").value -= 0.2 * MyBase.inv.item("Utility_Manual").value
        inv.setCount("Combat_Manual", 1)
        inv.item("Combat_Manual").value -= 0.2 * MyBase.inv.item("Combat_Manual").value
        inv.setCount("Anti_Curse_Tag", 1)
        'Services
        inv.setCount("Bimbo_Lesson", 1)
        inv.setCount("Name_Change", 1)
        inv.setCount("Base_Form_Reset", 1)
        inv.setCount("Learn_'Focus_Up'", 1)
        inv.setCount("Basic_Class_Change", 1)
        inv.setCount("Advanced_Class_Change", 1)

        '|Stats|
        maxHealth = 9999
        attack = 99
        defense = 999
        speed = 99
        will = 999
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

        local_img.Add(LocalImgInd.normal, ShopNPC.gbl_img.atrs(0).getAt(17))
        local_img.Add(LocalImgInd.frog, ShopNPC.gbl_img.atrs(0).getAt(4))
        local_img.Add(LocalImgInd.bunny, ShopNPC.gbl_img.atrs(0).getAt(18))
        local_img.Add(LocalImgInd.princess, ShopNPC.gbl_img.atrs(0).getAt(19))
        local_img.Add(LocalImgInd.sheep, ShopNPC.gbl_img.atrs(0).getAt(5))
        local_img.Add(LocalImgInd.doll, ShopNPC.gbl_img.atrs(0).getAt(20))
        local_img.Add(LocalImgInd.arachne, ShopNPC.gbl_img.atrs(0).getAt(70))
        local_img.Add(LocalImgInd.catgirl, ShopNPC.gbl_img.atrs(0).getAt(91))
        local_img.Add(LocalImgInd.trilobite, ShopNPC.gbl_img.atrs(0).getAt(96))
        local_img.Add(LocalImgInd.beegirl, ShopNPC.gbl_img.atrs(0).getAt(148))
        local_img.Add(LocalImgInd.alt1, ShopNPC.gbl_img.atrs(0).getAt(21))
        local_img.Add(LocalImgInd.alt2, ShopNPC.gbl_img.atrs(0).getAt(22))
        local_img.Add(LocalImgInd.alt3, ShopNPC.gbl_img.atrs(0).getAt(102))
        local_img.Add(LocalImgInd.alt4, ShopNPC.gbl_img.atrs(0).getAt(24))
        local_img.Add(LocalImgInd.alt5, ShopNPC.gbl_img.atrs(0).getAt(74))
    End Sub

    Public Overrides Sub encounter()
        seventailsAdjustment()

        MyBase.encounter()
    End Sub
    Public Overrides Sub inventoryUpdate()
        If Game.mDun.numCurrFloor > 5 Then inv.setCount(113, 1) Else inv.setCount(113, 0)
        If Game.mDun.numCurrFloor < 5 Then inv.setCount(122, 1) Else inv.setCount(122, 0)
    End Sub

    '| - COMBAT - |
    Public Overrides Sub attackCMD(ByRef target As Entity)
        attackSpell(target, "Split the Mind", MyBase.getWIL)
    End Sub

    '| - HYPNOSIS - |
    Public Sub hypnotize(ByVal s As String)
        hypnotize(s, AddressOf back)
    End Sub
    Public Sub hypnotize(ByVal s As String, a As Action)
        preHypnoID = img_index

        If form.Equals("Arachne") Then
            img_index = LocalImgInd.alt5
        Else
            img_index = LocalImgInd.alt1
        End If

        TextEvent.pushNPCDialog(s, a)
        Game.shopMenu.Close()

        Game.picNPC.BackgroundImage = local_img(img_index)
    End Sub
    Public Sub back()
        img_index = preHypnoID
        TextEvent.pushNPCDialog("So, anything else?")
        Game.picNPC.BackgroundImage = local_img(img_index)
        Game.showNPCButtons()
        Game.player1.canMoveFlag = False
    End Sub

    '| - SEVEN TAILS - |
    Sub seventailsAdjustment()
        If Game.currFloor.floorNumber = 7 And Game.player1.perks(perk.seventailsstage) = 1 Then
            img_index = LocalImgInd.normal
            local_img(LocalImgInd.normal) = ShopNPC.gbl_img.atrs(0).getAt(63)
            local_img(LocalImgInd.alt1) = ShopNPC.gbl_img.atrs(0).getAt(64)
        Else
            local_img(LocalImgInd.normal) = ShopNPC.gbl_img.atrs(0).getAt(17)
            local_img(LocalImgInd.alt1) = ShopNPC.gbl_img.atrs(0).getAt(21)
        End If
    End Sub
    Public Shared Sub sevenTailsFight()
        If Game.combat_engaged Then Game.fromCombat()
        If Game.shop_npc_engaged Then Game.hideNPCButtons()
        Game.npc_list.Clear()
        Game.picNPC.Visible = False
        Game.lblEvent.Visible = False

        Dim m As SevenTails = MiniBoss.miniBossFactory(7)
        m.health = 0.66

        'adds the miniboss to combat queues
        Monster.targetRoute(m)
        Game.toCombat(m)

        TextEvent.pushAndLog("With a poof of smoke, the ""hypnotist"" shifts into a familiar kitsune and " & m.getName() & " attacks!")

        Game.player1.perks(perk.seventailsstage) = 2

        Game.currFloor.beatBoss = False
        Game.shop_npc_engaged = False
        Game.mDun.floor_boss.Add(7, "Seven-Tails")

        Game.hteach.pos = New Point(-1, -1)
        Game.drawBoard()
    End Sub
    Public Overrides Sub die(ByRef cause As Entity)
        If Game.currFloor.floorNumber = 7 Then Exit Sub
        MyBase.die(cause)
    End Sub

    '| - DIALOG - |
    Protected Overrides Function normalDialog(ByRef p As Player)
        If Int(Rnd() * 20) = 0 And Game.currFloor.floorNumber <> 7 Then
            discount = 0.25
            img_index = LocalImgInd.alt4
            Return "Like, hey!  I, like, totally just got back from negot...nagosh... um, trying to work out a deal with that wizard guy, and it like, didn't go too well..." & DDUtils.RNRN &
                   "But hey, now I feel soooo gooood, and I'm even doing a I'm-having-fun sale!  I ran into Food Guy, and don't tell him I said this but he's, like, toootally a cutie..." & DDUtils.RNRN &
                   "Anyway, like, he has that panana...penasi...special food thing that can get me back to my normal self!" & DDUtils.RNRN &
                   "But for now, I'm, like, gonna take a lil' break from being all serious!  Maybe I'll see what else he has for me to put in my mouth... ~🖤"
        ElseIf Int(Rnd() * 20) = 1 And Game.currFloor.floorNumber <> 7 Then
            img_index = LocalImgInd.alt2
            Return "Hello, valued customer!  Have you perchance seen the Food Vendor around anywhere?" & DDUtils.RNRN &
                   "He appears to have mixed the cream in my usual morning coffee up with some other malarkey and now, as I am sure you can see, I have begun morphing into some sort of bovine." & DDUtils.RNRN &
                   "Hopefully he has some Panacea on hand, because otherwise I would be in a bit of a prediciment.  Ugh, he is just so..." & DDUtils.RNRN &
                   "*sigh* Apologies, this is not appropriate talk for business.  Please feel free to take a look around, I shall track down my idiot later."
        Else
            img_index = LocalImgInd.normal
            Return "Hello, adventurer." & DDUtils.RNRN &
                   "I have been researching a new technique of self-improvement that combines traditional hypnosis with the arcane arts to achive a more potent effect than either is capable of alone." & DDUtils.RNRN &
                   "While admittedly it is still... slightly experimental, most of the kinks have been ironed out through repeated testing and a very helpful volunteer." & DDUtils.RNRN &
                   "If you're feeling hesitant, I also have a curated selection of books and manuals for sale."
        End If
    End Function
    Protected Overrides Function frogDialog(ByRef p As Player)
        Return "CROAK!"
    End Function
    Protected Overrides Function bunnyDialog(ByRef p As Player)
        Return "HI!" & DDUtils.RNRN &
               "I, like, don't know if it would be smart for me to try to hypno...hypotho... um, do my thing to you right now... but I totally have some tapes you can use!"
    End Function
    Protected Overrides Function princessDialog(ByRef p As Player)
        Return "Hark!" & DDUtils.RNRN &
               "My salutations to thee, " & p.className & "." & DDUtils.RNRN &
               "Please let me know if there is anything I can help you with."
    End Function
    Protected Overrides Function sheepDialog(ByRef p As Player)
        Return "BLEET!"
    End Function
    Protected Overrides Function arachneDialog(ByRef p As Player)
        If p.formName.Equals("Arachne") Then
            Return "Oh, it's you.  I am not sure which is worse, the fact that I am part bug now or the fact that your bait actually decieved me."
        Else
            Return "You should try this venom.  Or don't.  Say, you would not happen to have a Panacea in your possession, do you?"
        End If
    End Function
    Protected Overrides Function catgirlDialog(ByRef p As Player)
        Return "I do not approve of plagerism, but...  fortunately for you I am rather enjoying this form." & DDUtils.RNRN &
               "Nya..."
    End Function
    Protected Overrides Function beegirlDialog(ByRef p As Player)
        Return "BZZZ!"
    End Function

    Public Overrides Function toFight() As String
        If img_index = LocalImgInd.alt4 Then Return "Cmon!  I'm, like, trying to help you out here!"

        Return MyBase.toFight()
    End Function
    Protected Overrides Function normalFightDialog(ByRef p As Player)
        Return "Seems like you need another type of lesson..."
    End Function
    Protected Overrides Function frogFightDialog(ByRef p As Player)
        Return "bbbbrrrROOOAAAK!"
    End Function
    Protected Overrides Function bunnyFightDialog(ByRef p As Player)
        Return "Whaaaaaat?!?  No, like, don't do that!"
    End Function
    Protected Overrides Function princessFightDialog(ByRef p As Player)
        Return "You would dare to challenge me?  If you wished become my servant, you could have just asked."
    End Function
    Protected Overrides Function sheepFightDialog(ByRef p As Player)
        Return "baaaaaahhh."
    End Function
    Protected Overrides Function arachneFightDialog(ByRef p As Player)
        Return "Outstanding!  I've been looking for the opportunity to burn off some arachnophobic stress..."
    End Function
    Protected Overrides Function catgirlFightDialog(ByRef p As Player)
        Return "~Oooh~, you want to play?"
    End Function

    Public Overrides Function hitBySpell() As String
        If img_index = LocalImgInd.alt4 Then Return "Cmon!  I'm, like, trying to help you out here!"

        Return MyBase.hitBySpell()
    End Function
    Protected Overrides Function normalSpellDialog(ByRef p As Player)
        Return "*sigh*" & DDUtils.RNRN &
               "Well, I can always use another test subject."
    End Function
    Protected Overrides Function frogSpellDialog(ByRef p As Player)
        Return "Ribbit, RIBBIT!"
    End Function
    Protected Overrides Function bunnySpellDialog(ByRef p As Player)
        Return "WOAH!  That's a neat trick!"
    End Function
    Protected Overrides Function princessSpellDialog(ByRef p As Player)
        Return "Prepare yourself, for I shan't be manipulated so easily..."
    End Function
    Protected Overrides Function sheepSpellDialog(ByRef p As Player)
        Return "Bah, BAH!"
    End Function
    Protected Overrides Function arachneSpellDialog(ByRef p As Player)
        Return normalSpellDialog(p)
    End Function
    Protected Overrides Function catgirlSpellDialog(ByRef p As Player)
        Return "~Oooh~, you want to play?"
    End Function

    Public Overrides Function postPurchaseDialog(ByRef p As Player) As Object
        Return "Would you like anything else?"
    End Function

    '| - MISC - |
    Public Overrides Sub buildShopArea(ByRef floor As mFloor)
        MyBase.buildShopArea(floor)

        Dim lounge = {New Point(pos.X - 1, pos.Y)}

        Dim tables = {New Point(pos.X + 1, pos.Y)}

        For Each pt In lounge
            If floor.ptInBounds(pt) Then floor.mBoard(pt.Y, pt.X).Text = "¦"
        Next

        For Each pt In tables
            If floor.ptInBounds(pt) Then floor.mBoard(pt.Y, pt.X).Text = "§"
        Next
    End Sub
End Class
