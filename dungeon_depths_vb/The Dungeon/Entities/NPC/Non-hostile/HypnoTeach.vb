Public Class HypnoTeach
    Inherits ShopNPC

    Dim preHypnoID = 0
    Sub New()
        MyBase.New()

        '|ID Info|
        name = "Hypnotist Teacher"
        sName = name

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
        picNormal = ShopNPC.npcLib.atrs(0).getAt(17)
        picPrincess = ShopNPC.npcLib.atrs(0).getAt(19)
        picBunny = ShopNPC.npcLib.atrs(0).getAt(18)
        picArachne = ShopNPC.npcLib.atrs(0).getAt(70)

        picNPC = New List(Of Image)
        picNPC.AddRange({picNormal,
                         ShopNPC.npcLib.atrs(0).getAt(4),
                         ShopNPC.npcLib.atrs(0).getAt(5),
                         picPrincess,
                         picBunny})

        picNPC.AddRange({ShopNPC.npcLib.atrs(0).getAt(21),
                         ShopNPC.npcLib.atrs(0).getAt(24),
                         ShopNPC.npcLib.atrs(0).getAt(22),
                         ShopNPC.npcLib.atrs(0).getAt(20),
                         picArachne,
                         ShopNPC.npcLib.atrs(0).getAt(74),
                         ShopNPC.npcLib.atrs(0).getAt(91),
                         ShopNPC.npcLib.atrs(0).getAt(96)})
    End Sub

    Public Overrides Sub encounter()
        MyBase.encounter()

        MyBase.discount = 0

        seventailsAdjustment()

        If img_index = 0 Then
            If Int(Rnd() * 20) = 0 And Game.currFloor.floorNumber <> 7 Then
                MyBase.discount = 0.25
                img_index = 6
                Game.pushNPCDialog("Like, hey!  I, like, totally just got back from negot...nagosh...trying to work out a deal with that wizard guy, and it like, didn't go too well..." & DDUtils.RNRN &
                                   "But hey, now I feel soooo gooood, and I'm even doing a I'm-having-fun sale!  I ran into Food Guy, and don't tell him I said this but he's, like, toootally a cutie..." & DDUtils.RNRN &
                                   "Anyway, like, he has that panana...penasi...special food thing that can get me back to my normal self!" & DDUtils.RNRN &
                                   "But first, I'm like, totally gonna take a break from being all serious and see what else he has that I can eat! ~🖤")
            ElseIf Int(Rnd() * 20) = 1 And Game.currFloor.floorNumber <> 7 Then
                img_index = 7
                Game.pushNPCDialog("Hello, potential customer!  I do not suppose you have seen Mr. Vendor around anywhere, have you?" & DDUtils.RNRN &
                                   "He appears to have mixed the cream in my usual morning coffee up with some other malarkey and now, as I am sure you can see, I have begun morphing into some sort of bovine.  Hopefully he has some Panacea on hand, because otherwise I would be in a bit of a prediciment.  Ugh, he is just so..." & DDUtils.RNRN &
                                   "*sigh* Apologies, this is not appropriate buisness talk.  I have spellbooks and manuals for sale, and if you are looking for something specific, I have some recorded hypnotic lessons on tape.  Take a look around, in the meantime I am going to track down my idiot.")
            Else
                Game.pushNPCDialog("Hello, kind stranger.  I have been researching a new technique combining traditional hypnosis with the arcane arts for more potent effects faster than either is capable of alone." & DDUtils.RNRN &
                                   "While I will admit it is still slightly experimental, I have worked out most of the kinks thanks to some volunteering by the Food Vendor you may have seen around.  Together, we have achived impressive results in long term behavior modification." & DDUtils.RNRN &
                                   "If you're feeling a bit... hesitant, I also have a curated selection of books and manuals for sale.")
            End If
        ElseIf img_index = 1 Then
            Game.pushNPCDialog("CROAK!")
        ElseIf img_index = 2 Then
            Game.pushNPCDialog("BLEEEET!")
        ElseIf img_index = 3 Then
            Game.pushNPCDialog("Well salutations there, " & Game.player1.className & ".  Please let me know if there's anything I can do to help you.")
        ElseIf img_index = 4 Then
            Game.pushNPCDialog("HI!  I, like, don't know if it would be smart for me to try to hypno...hypotho...do my thing to you right now, but I totally have some tapes you can use!")
        ElseIf img_index = 8 Or img_index = 12 Then
            Game.pushNPCDialog("...")
        ElseIf img_index = 9 Then
            If Game.player1.formName.Equals("Arachne") Then
                Game.pushNPCDialog("Oh, it's you.  I'm not sure which is worse, the fact that I'm part bug now, or the fact that your bait actually decieved me.")
            Else
                Game.pushNPCDialog("You should try this venom.  Or don't.  Say, you don't happen to have a Panacea in your possession, do you?")
            End If
        ElseIf img_index = 11 Then
            Game.pushNPCDialog("I do not approve of plagerism, but...  lucky for you...  I am rather enjoying this form...  nya...")
        End If

        If Game.mDun.numCurrFloor > 5 Then inv.setCount(113, 1) Else inv.setCount(113, 0)
        If Game.mDun.numCurrFloor < 5 Then inv.setCount(122, 1) Else inv.setCount(122, 0)
        If img_index = getArachneImageInd() And Not Game.player1.formName.Equals("Arachne") Then inv.setCount(244, 1) Else inv.setCount(244, 0)

        Game.picNPC.BackgroundImage = picNPC(img_index)
    End Sub

    Public Overrides Function toFight() As String
        If img_index = 0 Then
            Return "Seems like you need another type of lesson."
        ElseIf img_index = 1 Then
            Return "bbbbrrrROOOAAAK!"
        ElseIf img_index = 2 Then
            Return "baaaaaahhh."
        ElseIf img_index = 3 Then
            Return "You would dare to challenge me? If you wish to die, you could just say so."
        ElseIf img_index = 4 Then
            Return "Whaaaaaat?!?  No, like, don't do that!"
        ElseIf img_index = 6 Then
            Return "Cmon!  I'm, like, trying to help you out here!"
        ElseIf img_index = 8 Or img_index = 12 Then
            Return "..."
        ElseIf img_index = 9 Then
            Return "Outstanding!  I've been looking for the opportunity to burn off some arachnophobic stress..."
        ElseIf img_index = 11 Then
            Return "~Oooh~, you want to play?"
        End If
        Return "Bad move."
    End Function
    Public Overrides Function hitBySpell() As String
        If Game.currFloor.floorNumber = 7 And Game.player1.perks(perk.seventailsstage) = 1 Then sevenTailsFight()

        If img_index = 0 Or img_index = 9 Then
            Game.NPCtoCombat(Me)
            Return "*sigh*...Well, I can always use another test subject."
        ElseIf img_index = 1 Then
            Game.NPCtoCombat(Me)
            Return "Ribbit, RIBBIT!"
        ElseIf img_index = 2 Then
            Game.NPCtoCombat(Me)
            Return "BAH!  BAH!"
        ElseIf img_index = 3 Then
            Game.NPCtoCombat(Me)
            Return "Prepare yourself, I won't be manipulated easily."
        ElseIf img_index = 4 Then
            Return "WOAH!  That's a neat trick!"
        ElseIf img_index = 6 Then
            Return "Cmon!  I'm, like, trying to help you out here!"
        ElseIf img_index = 8 Or img_index = 12 Then
            Return "..."
        ElseIf img_index = 11 Then
            Return "~Oooh~, you want to play?"
        End If
        Return "Woah there!"
    End Function

    Public Sub hypnotize(ByVal s As String)
        hypnotize(s, AddressOf back)
    End Sub
    Public Sub hypnotize(ByVal s As String, a As Action)
        preHypnoID = img_index

        If form.Equals("Arachne") Then img_index = 10 Else img_index = 5

        Game.pushNPCDialog(s, a)
        Game.shopMenu.Close()

        Game.picNPC.BackgroundImage = picNPC(img_index)
    End Sub
    Public Sub back()
        img_index = preHypnoID
        Game.pushNPCDialog("So, anything else?")
        Game.picNPC.BackgroundImage = picNPC(img_index)
        Game.showNPCButtons()
        Game.player1.canMoveFlag = False
    End Sub
    Public Overrides Sub toDoll()
        Game.pushNPCDialog("...")
        Game.picNPC.BackgroundImage = picNPC(8)

        discount = 0.5
    End Sub

    Public Overrides Function getArachneImageInd() As Integer
        Return 9
    End Function
    Public Overrides Function getCatgirlImageInd() As Integer
        Return 11
    End Function
    Public Overrides Function getTrilobiteImageInd() As Integer
        Return 12
    End Function

    Public Overrides Sub attackCMD(ByRef target As Entity)
        attackSpell(target, "Split the Mind", MyBase.getWIL)
    End Sub

    Sub seventailsAdjustment()
        If Game.currFloor.floorNumber = 7 And Game.player1.perks(perk.seventailsstage) = 1 Then
            img_index = 0
            picNPC(0) = ShopNPC.npcLib.atrs(0).getAt(63)
            picNPC(5) = ShopNPC.npcLib.atrs(0).getAt(64)
        Else
            picNPC(0) = ShopNPC.npcLib.atrs(0).getAt(17)
            picNPC(5) = ShopNPC.npcLib.atrs(0).getAt(21)
        End If
    End Sub
    Public Shared Sub sevenTailsFight()
        If Game.combatmode Then Game.fromCombat()
        If Game.npcmode Then Game.hideNPCButtons()
        Game.picNPC.Visible = False
        Game.lblEvent.Visible = False

        Dim m As SevenTails = MiniBoss.miniBossFactory(7)
        m.health = 0.66

        'adds the miniboss to combat queues
        Monster.targetRoute(m)
        Game.toCombat(m)

        Game.pushLogAndEvent("With a poof of smoke, the hypnotist shifts into a familiar kitsune and " & m.getName() & " attacks!")

        Game.player1.perks(perk.seventailsstage) = 2

        Game.currFloor.beatBoss = False
        Game.npcmode = False
        Game.mDun.floorboss.Add(7, "Seven-Tails")

        Game.hteach.pos = New Point(-1, -1)
        Game.drawBoard()
    End Sub

    Public Overrides Sub die(ByRef cause As Entity)
        If Game.currFloor.floorNumber = 7 Then Exit Sub
        MyBase.die(cause)
    End Sub
End Class
