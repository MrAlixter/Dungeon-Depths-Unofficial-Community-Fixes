Public Class FaeWoodsQ2A
    Inherits Quest

    Public Shared horseTFongoing = False

    Sub New()
        MyBase.New("Fae Woods Q2A - Simple Instructions")

        quest_index = qInd.faewoods2a

        objectives.Add(New FaeWoodsQ2AS1)
        objectives.Add(New FaeWoodsQ2AS2)
        objectives.Add(New FWQ2APassenger1)
        objectives.Add(New FWQ2APassenger2)
        objectives.Add(New FWQ2APassenger3)
    End Sub
    Public Shared Sub altInit()
        Game.player1.quests(qInd.faewoods2a).init()
    End Sub
    Public Overrides Sub init()
        MyBase.init()

        Game.player1.perks(perk.faepassangers) = -1

        Game.currFloor.cleanPaths()

        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(49), "Hey, there you are!  What happened?  I thought you were right behind me..." & DDUtils.RNRN &
                          "Hmm..." & DDUtils.RNRN &
                          "Actually, there might be a way I can keep you from getting lost again, if you're interested...", AddressOf askForHelp)
    End Sub
    Public Overrides Function canGet() As Boolean
        Dim p = Game.player1
        Return Not getActive() And Game.mDun.numCurrFloor = 13 And p.perks(perk.meetfae1) > 0 And Game.player1.perks(perk.faecurse) < 0 And p.quests(qInd.faewoods1a).getComplete And ((Game.currFloor.chestList.Count < 1 And Int(Rnd() * 3) = 0) Or Game.currFloor.chestList.Count > 0) And Not p.ongoingTFs.contains(tfind.faebimbo) And Not p.ongoingTFs.contains(tfind.faecleric) And Not getComplete() And Not Game.combat_engaged And Not Game.shop_npc_engaged
    End Function

    '| - QUESTIONS - |
    Sub askForHelp()
        TextEvent.pushYesNo("Are you interested?", AddressOf agreeHelp, AddressOf disagreeHelp)
    End Sub

    '| - RESPONSES - |
    Public Sub agreeHelp()
        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(56), """Yay!  Here, pop this in, ok?""" & DDUtils.RNRN &
                          "The fae hands you a horse's bridle, and you slip it into your mouth." & DDUtils.RNRN &
                          """Give it a sec...""", AddressOf horseTransformation)
    End Sub
    Public Sub disagreeHelp()
        If Game.player1.perks(perk.faehasname) > 0 Then
            Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(50), """Well, too bad...  I'm not exactly keen to spend the afternoon chasing you around, so be a dear and pop this in, ok, " & Game.player1.getName() & "?""" & DDUtils.RNRN &
                                "The fae hands you a horse's bridle, and you automatically slip it into your mouth before shooting her a glare." & DDUtils.RNRN &
                                """What?  Don't give me that look, you're the one tossing your name around all willy-nilly here.  Keeping your name hush-hush is, like, rule one of fairy magic." & DDUtils.RNRN &
                                "I mean, unless you want strangers to take the wheel... which is fair too...  I guess...""", AddressOf horseTransformation)
        Else
            Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(56), """Fair e-nough.  Can't blame a gal for trying, right?  So, if you still want me to lead you to the exit, just follow along...""" & DDUtils.RNRN &
                              "she says, twinkling away into the misty woods," & DDUtils.RNRN &
                              """...and try not to get lost, yeah?""")
            FaeQueen.spawn(Game.currFloor)
        End If
    End Sub

    '| - STORY PROGRESSION - |
    Public Sub horseTransformation()
        horseTFongoing = True
        Equipment.equipAcce(Game.player1, CursedBridle.ITEM_NAME, False)
    End Sub
    Public Shared Sub passengerDialog(ByVal p As Point)
        Select Case True
            Case p.Equals(New Point(48, 56))
                If Game.player1.perks(perk.faepassangers) = 1 Then Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(115), "Your owner is quite grating on the nerves, is she not?")
                If Game.player1.perks(perk.faepassangers) = 3 Then Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(123), "Ah, I was wondering when you would show up...", AddressOf FWQ2APassenger3.passenger1)
            Case p.Equals(New Point(48, 55))
                If Game.player1.perks(perk.faepassangers) = 1 Then Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(116), "Thank you, horsey!")
            Case p.Equals(New Point(52, 13))
                If Game.player1.perks(perk.faepassangers) = 1 Then Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(117), "*aroof* W-what happened to me? *pant*")
                If Game.player1.perks(perk.faepassangers) = 2 Then
                    Select Case Game.player1.perks(perk.f13p2startturn)
                        Case -5
                            Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(126), "I... um, like... what- I... you..." & DDUtils.RNRN &
                                                                                 "Spinny... empty... hot and stuff...")
                        Case -4
                            Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(125), "Hi, Pony!  Like, tell the, um, sparkle lady..." & DDUtils.RNRN &
                                                                                 "She, um, like, woah... My head's all... fluffy...")
                        Case -2
                            Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(124), "Sigh... Like all moments of rest, this ride ended far too soon..." & DDUtils.RNRN &
                                                                                 "Well, back to the battlefield.")
                        Case Else
                            Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(120), "The twinkly lady, like, um, said that I was gonna feel all... fuzzy and stuff..." & DDUtils.RNRN &
                                                                                 "Like, woah, she wasn't kidding...")
                    End Select
                End If

            Case p.Equals(New Point(52, 15))
                If Game.player1.perks(perk.faepassangers) = 1 Then Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(118), "It was a fun ride, we'll have to come back soon!")
            Case p.Equals(New Point(26, 23))
                If Game.player1.perks(perk.faepassangers) = 2 Then Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(119), "Hello, steed.  I hear this will be a quick, relaxing journey?" & DDUtils.RNRN &
                                                                                                                        "Hmm, I guess I could use a break...")
            Case p.Equals(New Point(39, 56))
                If Game.player1.perks(perk.faepassangers) = 3 Then Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(121), "How's it going, horse?  Hey, does your driver seem a little weird to you?", AddressOf FWQ2APassenger3.passenger2)
        End Select
    End Sub
    Public Shared Sub faeAttack()
        Dim target = Game.player1.currTarget

        If Game.lblPHealtDiff.Tag / Game.player1.getMaxHealth > 0.25 Then
            TextEvent.pushAndLog("The fae casts Mega Heal!")
            Game.player1.health = 1.0
            Exit Sub
        End If

        Select Case Int(Rnd() * 1)
            Case 0
                Dim dmg = Game.fqueen.getSpellDamage(target, -12400)
                TextEvent.pushAndLog("The fae casts Thorn Whip!")
                TextEvent.pushAndLog(CStr("The fae hits " & Trim(target.getNameWithTitle) & " for " & dmg & " damage!"))
                target.takeDMG(dmg, Game.player1)
        End Select
    End Sub
End Class

Friend Class FaeWoodsQ2AS1
    Inherits Objective

    Sub New()
        MyBase.New("Talk with the faerie.")
    End Sub

    Public Overrides Sub complete()
        MyBase.complete()

        Game.player1.perks(perk.faepassangers) = 0
    End Sub

    Public Overrides Function getDesc() As String
        Return description
    End Function

    Public Overrides Function isComplete() As Boolean
        Return False
    End Function
End Class
Friend Class FaeWoodsQ2AS2
    Inherits Objective

    Sub New()
        MyBase.New("Follow the faerie's directions.")
    End Sub

    Public Shared Sub init()
        TextEvent.push("The fae vanishes into the misty woods, leaving you free to take stock of your equine form." & DDUtils.RNRN &
                       "Right as you start to wander off, though, you feel a tug on your reigns and glance back to see a hooded figure and carriage." & DDUtils.RNRN &
                       "The mysterious stranger chuckles in a familiar voice...", AddressOf carriage1)
        Game.player1.quests(qInd.faewoods2a).completeCurrOjb()
        horseTFongoing = False
    End Sub

    Public Overrides Function getDesc() As String
        Return description & "  [" & Game.player1.perks(perk.faepassangers) & "/3]"
    End Function

    Private Shared Sub spawnClearing(ByRef floor As mFloor)
        Dim points As Point() = {New Point(46, 54), New Point(47, 54), New Point(48, 54),
                                 New Point(48, 55), New Point(48, 56), New Point(49, 55), New Point(49, 56)}

        Game.player1.pos = New Point(49, 56)

        For Each p In points
            floor.mBoard(p.Y, p.X).Tag = 2
        Next

        Game.drawBoard()
    End Sub

    Private Shared Sub carriage1()
        Dim refP = "guy"
        Dim title = "Mister"

        If Game.player1.prt.sexBool Then
            refP = "gal"
            title = "Miss"
        End If

        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(62), "Welcome to the Fae Woods, big " & refP & ".  Don't worry, I'm still going to take you where you need to go, but you and I are gonna make a little gold along the way...", AddressOf carriage2)
    End Sub
    Private Shared Sub carriage2()

        TextEvent.push("The faerie leads you along through the foliage until you reach a small clearing." & DDUtils.RNRN &
                       "A small wooden sign in the center of the clearing reads 'HORSE RIDE, 1000 GOLD'.  The fae leans forward in the driver's seat, setting down the reins." & DDUtils.RNRN &
                       """And now, we wait...""", AddressOf carriage3)

        spawnClearing(Game.currFloor)
    End Sub
    Private Shared Sub carriage3()
        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(60), "See, most of the people from your side of the treeline are pretty easy to work around.  You come in all big and trudging, giving everyone a real name, and then you wonder why you end up as someone's fountain for the rest of time." & DDUtils.RNRN &
                                                            "However, every once and a while, we get someone craftier." & DDUtils.RNRN &
                                                            "Some are here to see the fae queen, some are here to cause trouble, but the one thing they all have in common is that they're all carrying coin." & DDUtils.RNRN &
                                                            "And in these woods, whoever controls the coin...", AddressOf carriage4)
    End Sub
    Private Shared Sub carriage4()
        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(62), """...controls absolutely nothing.  It's completely worthless here, but you all seem to like it." & DDUtils.RNRN &
                                                            "I'm thinking that with enough of it saved up I can get something cool.  Hey, do you know anyone with a ship that I could take off their hands?  I've heard a thing or two about these 'high seas' that are apparently are out there, and let's just say-""" & DDUtils.RNRN &
                                                            "The fae is cut off by a rustling on the far side of the clearing, as two humans break through the underbrush.", AddressOf passenger1)
    End Sub

    Private Shared Sub passenger1()
        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(114), """Ah, here it is."" the larger of the two, a muscular blonde woman says." & DDUtils.RNRN &
                                                             """I am seeking safe passage out of this realm for my lady and myself.  Might you be able to help us in this regard?""" & DDUtils.RNRN &
                                                             "The smaller, a young woman in an expensive-looking purple gown peaks out from behind her with an excited smile." & DDUtils.RNRN &
                                                             """WOAH!  We get to go on a secret carriage ride?!  You're the best, B-*mph*"" the lady exclaims before the amazon clamps a hand over her mouth and whispers something about names that your ears can't quite make out.", AddressOf passenger2)
    End Sub
    Private Shared Sub passenger2()
        TextEvent.push("""Indeed I can, B, as long as you have 2000G on ya..."" the fae leans over in her seat, grinning at the pair, ""You do have the coin, right?""" & DDUtils.RNRN &
                       "Glancing back at the sign, the amazon sighs and withdraws a small pouch before tossing it to your driver.  The fae catches it with both hands and quickly rifles through it before slipping it into her sleeve." & DDUtils.RNRN &
                       """Hey, thanks!  Feel free to load up the back with any gear ya got and hop on in, ok?""" & DDUtils.RNRN &
                       "As the warrioress loads a large backpack into the carriage, the fae turns back and with a sickly sweet curiosity, asks," & DDUtils.RNRN &
                       """So what does that 'B' stand for, anyways?""", AddressOf passenger3)
    End Sub
    Private Shared Sub passenger3()
        TextEvent.push("""Pardon?"" says the amazon, before turning aroud with an annoyed glare." & DDUtils.RNRN &
                       """Does it stand for Brenda?""" & DDUtils.RNRN &
                       "The warrioress goes back to her task, ignoring your driver." & DDUtils.RNRN &
                       """Maybe Bethanie?  Or perhaps the simple, yet demeaning classic, 'Bitch'?""" & DDUtils.RNRN &
                       """Do not concern yourself with my name..."" the amazon snarls back, ""Your requested payment has been handed over, please take us to whichever exit would get us out of these cursed woods the fastest...""" & DDUtils.RNRN &
                       """Hey, B, no problem.  You ready, " & Game.player1.name & "?"" the fae turns to you, giggling at her passenger's clear agrivation...")

        Game.player1.perks(perk.faepassangers) = 1

        Game.currFloor.mBoard(56, 48).Text = "a"
        Game.currFloor.mBoard(55, 48).Text = "a"

        Game.drawBoard()
    End Sub

    Public Overrides Function isComplete() As Boolean
        If Game.player1.pos.Equals(New Point(46, 54)) Then
            Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(60), "Alright, " & Game.player1.name & ", let's get a move on...")

            FaeQueen.spawnStairs(Game.currFloor)

            Dim path = Game.currFloor.route(Game.player1.pos, Game.currFloor.stairs)

            For i = 0 To UBound(path) Step 3
                Game.currFloor.mBoard(path(i).Y, path(i).X).Tag = 2
                If Game.currFloor.mBoard(path(i).Y, path(i).X).Text = "" Then Game.currFloor.mBoard(path(i).Y, path(i).X).Text = "x"
            Next

            Game.currFloor.mBoard(56, 48).Text = ""
            Game.currFloor.mBoard(55, 48).Text = ""

            Game.drawBoard()

            Return True
        End If

        Return False
    End Function
End Class

Friend Class FWQ2APassenger1
    Inherits Objective

    Dim askedPlayerOffCourse As Boolean = False
    Dim askedPassengers As Boolean = False

    Sub New()
        MyBase.New("Follow the faerie's directions.")
    End Sub

    Public Overrides Function getDesc() As String
        Return description & "  [" & Game.player1.perks(perk.faepassangers) & "/3]"
    End Function

    Public Overrides Function isComplete() As Boolean
        If Game.player1.pos.Y < 20 And Not askedPassengers Then
            TextEvent.push("As you travel, the fae turns back to the two women resting in the carriage." & DDUtils.RNRN &
                           """So, Bitch and co, what brings you two to the fae woods?""" & DDUtils.RNRN &
                           """Magic!"" exclaims the young sociallite, while her companion simply glowers at the faerie." & DDUtils.RNRN &
                           """That is not my name.""" & DDUtils.RNRN &
                           """You know, for someone who isn't named 'Bitch' you sure seem to be responding to it a lot..."" the fae says, with a sly grin.")
            askedPassengers = True
        ElseIf Game.player1.pos.Equals(New Point(51, 14)) Then
            Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(62), "Hey, we're here!  You lot just need to take the stairs to the right, and you'll be back in big people land or wherever it is you come from." & DDUtils.RNRN &
                                                                "Not you though, " & Game.player1.name & ", you hang tight for a sec while I see if there's anyone else looking for a ride.")

            Game.currFloor.mBoard(13, 52).Text = "a"
            Game.currFloor.mBoard(15, 52).Text = "a"

            Game.currFloor.cleanPaths()

            Game.drawBoard()

            Return True
        End If

        Return False
    End Function
End Class

Friend Class FWQ2APassenger2
    Inherits Objective
    Dim askedPlayerOffCourse As Boolean = True

    Sub New()
        MyBase.New("Follow the faerie's directions.")
    End Sub

    Public Overrides Function getDesc() As String
        Return description & "  [" & Game.player1.perks(perk.faepassangers) & "/3]"
    End Function

    Public Overrides Function isComplete() As Boolean
        If Game.player1.pos.Equals(New Point(51, 14)) And Game.player1.perks(perk.faepassangers) = 1 And Game.currFloor.mBoard(13, 52).Text = "a" Then
            Game.currFloor.mBoard(13, 52).Text = ""
            Game.currFloor.mBoard(15, 52).Text = ""

            Game.currFloor.mBoard(23, 25).Tag = 2
            Game.currFloor.mBoard(23, 26).Tag = 2

            Game.currFloor.mBoard(23, 26).Text = "a"

            Dim path = Game.currFloor.route(Game.player1.pos, New Point(25, 23))

            For i = 0 To UBound(path) Step 3
                Game.currFloor.mBoard(path(i).Y, path(i).X).Tag = 2
                If Game.currFloor.mBoard(path(i).Y, path(i).X).Text = "" Then Game.currFloor.mBoard(path(i).Y, path(i).X).Text = "x"
            Next

            Game.drawBoard()

            Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(50), "Alright, we've got our next mark." & DDUtils.RNRN &
                                                                "Whenever you're ready, " & Game.player1.name & "!")
        ElseIf Game.player1.pos.Equals(New Point(25, 23)) And Game.player1.perks(perk.faepassangers) = 1 Then
            Game.player1.perks(perk.faepassangers) = 2

            Game.currFloor.cleanPaths()

            Game.drawBoard()
        ElseIf Game.player1.pos.Equals(New Point(25, 23)) And Game.player1.perks(perk.faepassangers) = 2 And Game.currFloor.mBoard(23, 26).Text = "a" Then
            Dim path = Game.currFloor.route(Game.player1.pos, Game.currFloor.stairs)

            For i = 0 To UBound(path) Step 3
                Game.currFloor.mBoard(path(i).Y, path(i).X).Tag = 2
                If Game.currFloor.mBoard(path(i).Y, path(i).X).Text = "" Then Game.currFloor.mBoard(path(i).Y, path(i).X).Text = "x"
            Next

            Game.currFloor.mBoard(23, 26).Text = ""

            Game.drawBoard()

            Game.player1.perks(perk.f13p2startturn) = Game.turn

            Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(60), "Feel free to take the long way around." & DDUtils.RNRN &
                                                                "I'm gonna work my magic so our friend back there can get some much needed rest...")
        ElseIf Game.player1.pos.Equals(New Point(51, 14)) And Game.player1.perks(perk.faepassangers) = 2 Then
            Game.currFloor.mBoard(13, 52).Text = "a"

            Game.currFloor.cleanPaths()

            Game.drawBoard()

            Select Case True
                Case (Game.turn - Game.player1.perks(perk.f13p2startturn)) > 900
                    Game.player1.perks(perk.f13p2startturn) = -5
                Case (Game.turn - Game.player1.perks(perk.f13p2startturn)) > 400
                    Game.player1.perks(perk.f13p2startturn) = -4
                Case (Game.turn - Game.player1.perks(perk.f13p2startturn)) < 45
                    Game.player1.perks(perk.f13p2startturn) = -2
                Case Else
                    Game.player1.perks(perk.f13p2startturn) = -3
            End Select

            Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(62), "You still with us, miss?  We're at your stop!")

            Return True
        End If

        Return False
    End Function
End Class

Friend Class FWQ2APassenger3
    Inherits Objective
    Dim askedPlayerOffCourse As Boolean = True

    Sub New()
        MyBase.New("Follow the faerie's directions.")
    End Sub

    Public Overrides Function getDesc() As String
        Return description & "  [" & Game.player1.perks(perk.faepassangers) & "/3]"
    End Function

    Protected Friend Shared Sub passenger1()
        Game.currFloor.mBoard(56, 39).Text = "a"
        Game.currFloor.cleanPaths()
        Game.drawBoard()

        Dim p_form = Game.player1.sState.pForm.name
        TextEvent.push("""Ah, sorry if I kept you waiting, we were just fin-"" the faerie says before the veiled figure interrupts." & DDUtils.RNRN &
                       """Hush, little flower, I am talking with the transformed " & p_form & ".  I'll get to you in a bit.""" & DDUtils.RNRN &
                       """O-oh.  I, uh, found them like that..."" your driver mumbles as the woman turns back to you." & DDUtils.RNRN &
                       """True name magic is powerful to be sure, but there are better ways to reduce an adventurer to a mere beast of burden.  Ancient arts that warp reality itself, and that can bend even the most powerful mage to your will." & DDUtils.RNRN &
                       "Would you, " & p_form & ", be interested in learning this sort of ability?""", AddressOf passenger1Question)
    End Sub
    Private Shared Sub passenger1Question()
        TextEvent.pushYesNo("Learn the ancient ways?", AddressOf passenger1Learn, AddressOf passenger1Decline)
    End Sub
    Private Shared Sub passenger1Learn()

    End Sub
    Private Shared Sub passenger1Decline()
        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(123), """Disappointing...  If that is your choice though, then so be it.""" & DDUtils.RNRN &
                                                             "The veiled lady lets out a deep sigh, before addressing your driver, ""Well, little flower, I suppose I could go for a ride.  Your cart could use a little work though...""" & DDUtils.RNRN &
                                                             "She snaps her fingers, and the plain wooden carriage twists into an ornately decorated stagecoach.  As the golden stranger takes a seat on a luxurious cushion that wasn't there a second ago, the fae gawks back." & DDUtils.RNRN &
                                                             """U-uh, y-yeah, no problem.  H-hey, do you think that maybe I could learn some of those ancient ways?   Since, uh, " & Game.player1.name & " doesn't want to?""", AddressOf passenger1Decline2)
    End Sub
    Private Shared Sub passenger1Decline2()
        Dim tfForm = If(Game.player1.formName.Equals("Horse"), "Unicorn", "Horse")
        TextEvent.push("The veiled lady pauses for but a second, before laughing melodically.  ""Sure, why not?  You could prove to be an interesting replacement if our friend here is content to remain unenlightened...""" & DDUtils.RNRN &
                       "You can feel your body shift slightly, and while you have yet to feel the telltale tingle of a polymorph spell at work, you seem to have been turned into a " & tfForm & "!" & DDUtils.RNRN &
                       """Reality can be such a... fickle thing.  By pouring mana into a spell, one can convince reality to allow supernatural effects to take place.  Mana, however, is not the only force that can twist and transform.  This spell, 'Transfigure the Body' works on another of these forces." & DDUtils.RNRN &
                       "Now, a clever little faerie like you should be able to figure out how it works before we reach out destination, right?  Especially after seeing it cast in person, right?" & DDUtils.RNRN &
                       "Hmm, if I'm not to gain a new student, I suppose I could use a new cow...  Understand?""")
        Game.player1.changeForm(tfForm)
        Game.player1.drawPort()
    End Sub
    Protected Friend Shared Sub passenger2()
        Game.currFloor.mBoard(56, 48).Text = "a"
        Game.currFloor.cleanPaths()
        Game.drawBoard()

        TextEvent.push("")
    End Sub

    Public Overrides Function isComplete() As Boolean

        If Game.player1.pos.Equals(New Point(51, 14)) And Game.player1.perks(perk.faepassangers) = 2 And Game.currFloor.mBoard(13, 52).Text = "a" Then
            Game.currFloor.mBoard(13, 52).Text = ""
            Game.currFloor.mBoard(15, 52).Text = ""

            Game.currFloor.mBoard(56, 38).Tag = 2
            Game.currFloor.mBoard(56, 39).Tag = 2

            Game.currFloor.mBoard(56, 39).Text = "a"
            Game.currFloor.mBoard(56, 48).Text = "a"

            Game.player1.perks(perk.faepassangers) = 3

            Dim path = Game.currFloor.route(Game.player1.pos, New Point(39, 56))

            For i = 0 To UBound(path) Step 3
                Game.currFloor.mBoard(path(i).Y, path(i).X).Tag = 2
                If Game.currFloor.mBoard(path(i).Y, path(i).X).Text = "" Then Game.currFloor.mBoard(path(i).Y, path(i).X).Text = "x"
            Next

            Dim path2 = Game.currFloor.route(New Point(37, 46), New Point(48, 56))

            For i = 0 To UBound(path2) Step 3
                Game.currFloor.mBoard(path2(i).Y, path2(i).X).Tag = 2
                If Game.currFloor.mBoard(path2(i).Y, path2(i).X).Text = "" Then Game.currFloor.mBoard(path2(i).Y, path2(i).X).Text = "x"
            Next

            Game.drawBoard()

            Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(60), "Huh, we had another passenger lined up, but it looks like someone also is waiting at the signpost..." & DDUtils.RNRN &
                                                                "Tell ya what, " & Game.player1.name & ", I think we've made a decent haul for now, why don't you choose which one we'll pick up?" & DDUtils.RNRN &
                                                                "After that, I'll turn you back and we'll divy up, ok?")
        End If

        Return False
    End Function
End Class
