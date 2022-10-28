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
                                "The fae hands you a horse's bridle, and your hands automatically slip it into your mouth.  You find yourself unable to fight, move, or do much more than glare at the faerie." & DDUtils.RNRN &
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
                If Game.player1.perks(perk.faepassangers) = 3 And Game.currFloor.mBoard(56, 39).Text = "" Then Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(123), "Ah, by all means, take as much time you need...") Else Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(123), "Ah, I was wondering when you would show up...", AddressOf FWQ2APassenger3.passenger1)
            Case p.Equals(New Point(48, 55))
                If Game.player1.perks(perk.faepassangers) = 1 Then Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(116), "Thank you, horsey!")
            Case p.Equals(New Point(52, 13))
                If Game.player1.perks(perk.faepassangers) = 1 Then Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(117), "*aroof* W-what happened to me? *pant*")
                If Game.player1.perks(perk.faepassangers) = 2 Then
                    Select Case Game.player1.perks(perk.f13p2startturn)
                        Case -5
                            Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(126), "I... um, like... what- I... you..." & DDUtils.RNRN &
                                                                                 "Spinny... empty... hot 'n stuff...")
                        Case -4
                            Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(125), "Hi, Pony!  Like, tell the, um, sparkle lady..." & DDUtils.RNRN &
                                                                                 "She, um, like, woah... I'm, uh, all... fluffy...")
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
        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(60), """Most of the people from your side of the treeline are surprisingly easy to work around, but every once and a while we get someone craftier." & DDUtils.RNRN &
                                                            "Some are here to see the fae queen, some are just here to cause trouble, but all of them have a bunch of those coins you lot like so much." & DDUtils.RNRN &
                                                            "Yeah, it's completely worthless here, but I'm thinking that with enough of 'em I can snag something cool off one of you.  Maybe a ship or a boat, something like that?  I've heard a-""" & DDUtils.RNRN &
                                                            "The fae is cut off by a rustling on the far side of the clearing, as two humans break through the underbrush.", AddressOf passenger1)
    End Sub

    Private Shared Sub passenger1()
        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(114), "Leading the pair is a muscular blonde woman who immediately narrows her gaze on the two of you.  Despite not wearing much of anything, her gleaming body seems untouched by the branches and briars." & DDUtils.RNRN &
                                                             """Ah, here it is."" she says, with a sigh." & DDUtils.RNRN &
                                                             """I am seeking safe passage out of this realm for my lady and myself.  Might you be able to help us in this regard?""", AddressOf passenger2)
    End Sub
    Private Shared Sub passenger2()
        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(114), "The smaller of the two, a young woman in an expensive-looking purple gown, peeks out from behind her guard with an excited smile." & DDUtils.RNRN &
                                                             """WOAH!  We get to go on a secret carriage ride?!  You're the best, B-*mph*"" the lady exclaims before the amazon clamps a hand over her mouth and whispers something about names that your ears can't quite make out.", AddressOf passenger3)
    End Sub
    Private Shared Sub passenger3()
        TextEvent.push("""Indeed I can, B, as long as you have 2000G on ya..."" the fae leans over in her seat, grinning at the pair, ""You do have the coin, right?""" & DDUtils.RNRN &
                       "Glancing back at the sign, the amazon sighs and withdraws a small pouch before tossing it to your driver.  The fae catches it with both hands and quickly rifles through it before slipping it into her sleeve." & DDUtils.RNRN &
                       """Hey, thanks!  Feel free to load up the back with any gear ya got and hop on in, ok?""" & DDUtils.RNRN &
                       "As the warrioress loads a large backpack into the carriage, the fae turns back and asks, with sickeningly sweet sincerity;" & DDUtils.RNRN &
                       """So what does that 'B' stand for, anyways?""", AddressOf passenger4)
    End Sub
    Private Shared Sub passenger4()
        TextEvent.push("""Pardon?"" says the amazon, before turning aroud with an annoyed glare." & DDUtils.RNRN &
                       """Does it stand for Brenda?""" & DDUtils.RNRN &
                       "The warrioress goes back to her task, ignoring your driver." & DDUtils.RNRN &
                       """Maybe Bethanie?  Blanche?  Perhaps..."" the fae goes on, as the other woman stares daggers at her, ""...'Bitch'?""" & DDUtils.RNRN &
                       """Do not concern yourself with my name..."" the warrioress snarls back, ""Your requested payment has been handed over, so take us to whichever exit will get us out of these damned woods the fastest.  Please.""" & DDUtils.RNRN &
                       """Hey, B, no problem, I'll figure it out eventually..."" the fae turns to you, giggling at her passenger's clear agrivation, ""You ready, " & Game.player1.name & "?""")

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
                           """So, what brings you two to the fae woods?""" & DDUtils.RNRN &
                           """Magic!"" exclaims the young sociallite, while her companion simply glowers at the faerie." & DDUtils.RNRN &
                           """Our reasons are many, and they are none of your buisness.""" & DDUtils.RNRN &
                           """Geez, Bitch..."" the fae says, with a sly grin, ""You could stand to lighten up a little, you know?""")
            askedPassengers = True
        ElseIf Game.player1.pos.Equals(New Point(51, 14)) Then
            Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(62), """Hey, we're here!  You lot just need to take the stairs to the right, and you'll be back in big people land or wherever it is you come from.""" & DDUtils.RNRN &
                                                                "The two passengers depart the carriage, and the warrioress seems a little dazed as she steps back down into the forest floor.  Patting your head, the disguised faerie goes on," & DDUtils.RNRN &
                                                                """Ah, except for you, " & Game.player1.name & ", those stairs will... kill you.  I'm going to check quick to see if there's anyone else looking for a ride, meet me back out in the main part of the the woods whenever you're ready, ok?""")

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

            Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(60), "Hey, try to take the long way around, ok?" & DDUtils.RNRN &
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

    Dim askedPassengers As Boolean = False
    Dim askedPlayerOffCourse As Boolean = True

    Sub New()
        MyBase.New("Follow the faerie's directions.")
    End Sub

    Public Overrides Function getDesc() As String
        Return description & "  [" & Game.player1.perks(perk.faepassangers) & "/3]"
    End Function

    Protected Friend Shared Sub passenger1()
        Game.player1.perks(perk.faepassangers) = 3
        Game.currFloor.mBoard(56, 39).Text = ""
        Game.currFloor.cleanPaths()
        Game.drawBoard()

        Dim p_form = Game.player1.sState.pForm.name
        TextEvent.push("""Ah, sorry if I kept you waiting, we were just fin-"" the faerie says before the veiled figure interrupts." & DDUtils.RNRN &
                       """Hush, little flower, I am speaking with the transformed " & p_form & ".  I shall get to you in a bit.""" & DDUtils.RNRN &
                       """O-oh...  I, uh, found them like that..."" your driver mumbles as the new stranger turns back to you." & DDUtils.RNRN &
                       """" & p_form & ", would you like a bit of help?""", AddressOf passenger1Question)
    End Sub
    Private Shared Sub passenger1Question()
        TextEvent.pushYesNo("Would you like a bit of help?", AddressOf passenger1Help, AddressOf passenger1Decline)
    End Sub
    Private Shared Sub passenger1Help()
        Dim p_form = Game.player1.sState.pForm.name
        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(57), "The faerie drops her disguise with a sudden *poof*." & DDUtils.RNRN &
                                                            """H-hey, listen, uh, h-how about I, um, waive the-""" & DDUtils.RNRN &
                                                            """I said hush, Hyacinth."" the woman cuts her off, ""I still am not talking to you.""" & DDUtils.RNRN &
                                                            """Y-y-you..."" the fae, Hyacinth, stammers, as the other figure slowly raises a hand; fingers pressed together.", AddressOf passenger1Help2)
    End Sub
    Private Shared Sub passenger1Help2()
        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(58), """W-w-what i-if...""" & DDUtils.RNRN &
                                                            "With a sigh, the yellow stranger snaps her fingers and Hyacinth collapses into a pile of fabric.  In an instant, the faerie has been turned into an outfit of clothing!" & DDUtils.RNRN &
                                                            """There.  Much better.""", AddressOf passenger1Help3)
    End Sub
    Private Shared Sub passenger1Help3()
        If Game.player1.equippedAcce.getAName.Equals(CursedBridle.ITEM_NAME) Then CursedBridle.forceUnequip(Game.player1)

        Game.player1.pos = New Point(52, 14)
        Game.drawBoard()

        Game.currFloor.mBoard(56, 48).Text = ""

        Game.player1.drawPort()

        TextEvent.push("You find yourself able to spit out the bridle, and as you do it turns to ash.  Your form ripples back to that of a " & Game.player1.formName & ", and you are finally able to meet the gaze of the veiled figure as she rests her face on a gloved hand." & DDUtils.RNRN &
                       """Tch, I had been hoping for that carriage ride though..."" she says, seemingly eyeing you from behind her veil." & DDUtils.RNRN &
                       """Oh well, no one to blame but myself.  Prepare yourself, this will be more expedient either way.""" & DDUtils.RNRN &
                       "With the wave of the woman's hand, the forest warps around you both until you find yourself at a familiar staircase." & DDUtils.RNRN &
                       """Ah, and as a reminder, so that we are clear...""", AddressOf passenger1HelpFinal)
    End Sub
    Private Shared Sub passenger1HelpFinal()
        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(123), """You owe me a favor now...""" & DDUtils.RNRN &
                                                             "+3000 " & Gold.ITEM_NAME & vbCrLf &
                                                             "+1 " & FaerieWitchRobes.ITEM_NAME.Replace("_", " "))
        TextEvent.pushLog("+3000 " & Gold.ITEM_NAME)
        TextEvent.pushLog("+1 " & FaerieWitchRobes.ITEM_NAME.Replace("_", " "))

        Game.player1.inv.add(Gold.ITEM_NAME, 3000)
        Game.player1.inv.add(FaerieWitchRobes.ITEM_NAME, 1)

        Game.player1.perks(perk.faepassangers) = -1
        Game.player1.perks(perk.yellowonefavor) = 1

        Game.player1.ongoingQuests.getAt("Fae Woods Q2A - Simple Instructions").completeEntireQuest()
    End Sub
    Private Shared Sub passenger1Decline()
        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(123), """Hmm, fair enough.  Very well then, I suppose I could go for a ride.. .""" & DDUtils.RNRN &
                                                             "The veiled lady assesses the carriage for a moment, before addressing your driver, ""Your cart could use a little work though.""" & DDUtils.RNRN &
                                                             "She snaps her fingers, and the plain wooden carriage twists into an ornately decorated stagecoach.  As the golden stranger takes a seat on a luxurious cushion that wasn't there a second ago, the fae gawks back." & DDUtils.RNRN &
                                                             """U-uh, y-yeah, no problem.""")
    End Sub
    Protected Friend Shared Sub passenger2()
        Game.currFloor.mBoard(56, 48).Text = ""
        Game.currFloor.cleanPaths()
        Game.drawBoard()

        TextEvent.push("...")
    End Sub

    Protected Friend Shared Sub questRewards1()
        If Game.player1.equippedAcce.getAName.Equals(CursedBridle.ITEM_NAME) Then CursedBridle.forceUnequip(Game.player1)

        TextEvent.push("Quest Completed!" & DDUtils.RNRN &
                       "+1500 XP" & vbCrLf &
                       "+1500 " & Gold.ITEM_NAME & vbCrLf &
                       "+1 " & Hyacinth.ITEM_NAME)

        Game.player1.addXP(1500)

        TextEvent.pushLog("+1500 " & Gold.ITEM_NAME)
        Game.player1.inv.add(Gold.ITEM_NAME, 1500)

        TextEvent.pushLog("+1 " & Hyacinth.ITEM_NAME)
        Game.player1.inv.add(Hyacinth.ITEM_NAME, 1)

        Game.player1.perks(perk.faepassangers) = -1

        Game.player1.ongoingQuests.getAt("Fae Woods Q2A - Simple Instructions").completeEntireQuest()
        Game.player1.drawPort()
    End Sub

    Public Overrides Function isComplete() As Boolean
        If Game.player1.pos.Y < 20 And Not askedPassengers Then
            TextEvent.push("As you travel, the fae turns back to the veiled passenger." & DDUtils.RNRN &
                           """S-so, what brings y-you to the woods?""" & DDUtils.RNRN &
                           """Magic..."" the yellow woman replies, with a tiny laugh, ""Why, would you like to become a part of my affairs?""" & DDUtils.RNRN &
                           """NOPE!  A-ah, t-thanks for the offer, but, uh, I'll have to pass.""" & DDUtils.RNRN &
                           "The woman giggles, covering her mouth with one hand, ""Oh, but we could have so much fun together...""")
            askedPassengers = True
        ElseIf Game.player1.pos.Equals(New Point(51, 14)) And Game.player1.perks(perk.faepassangers) = 2 And Game.currFloor.mBoard(13, 52).Text = "a" Then
            Game.currFloor.mBoard(13, 52).Text = ""
            Game.currFloor.mBoard(15, 52).Text = ""

            'Game.currFloor.mBoard(56, 38).Tag = 2
            'Game.currFloor.mBoard(56, 39).Tag = 2

            'Game.currFloor.mBoard(56, 39).Text = "a"
            Game.currFloor.mBoard(56, 48).Text = "a"

            'Dim path = Game.currFloor.route(Game.player1.pos, New Point(39, 56))

            'For i = 0 To UBound(path) Step 3
            '    Game.currFloor.mBoard(path(i).Y, path(i).X).Tag = 2
            '    If Game.currFloor.mBoard(path(i).Y, path(i).X).Text = "" Then Game.currFloor.mBoard(path(i).Y, path(i).X).Text = "x"
            'Next

            Dim path2 = Game.currFloor.route(Game.player1.pos, New Point(48, 56))

            For i = 0 To UBound(path2) Step 3
                Game.currFloor.mBoard(path2(i).Y, path2(i).X).Tag = 2
                If Game.currFloor.mBoard(path2(i).Y, path2(i).X).Text = "" Then Game.currFloor.mBoard(path2(i).Y, path2(i).X).Text = "x"
            Next

            Game.drawBoard()

            Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(60), "Huh, we had another passenger lined up, but it looks like someone is snooping around at the signpost.  Hmm, this might be drawing more attention then I'd hoped..." & DDUtils.RNRN &
                                                                "Tell ya what, " & Game.player1.name & ", I think we've made a decent haul for now.  Let's make this the last one, yeah?" & DDUtils.RNRN &
                                                                "After that, I'll turn you back and we'll divy up.")
            '"Tell ya what, " & Game.player1.name & ", I think we've made a decent haul for now, why don't you choose which one we'll pick up?" & DDUtils.RNRN &
        ElseIf Game.player1.pos.Equals(New Point(46, 54)) And Game.player1.perks(perk.faepassangers) = 3 Then
            Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(60), "A-alright, " & Game.player1.name & "... let's, ah, wrap this up...")

            FaeQueen.spawnStairs(Game.currFloor)

            Dim path = Game.currFloor.route(Game.player1.pos, Game.currFloor.stairs)

            For i = 0 To UBound(path) Step 3
                Game.currFloor.mBoard(path(i).Y, path(i).X).Tag = 2
                If Game.currFloor.mBoard(path(i).Y, path(i).X).Text = "" Then Game.currFloor.mBoard(path(i).Y, path(i).X).Text = "x"
            Next

            Game.currFloor.mBoard(56, 48).Text = ""

            Game.drawBoard()
        ElseIf Game.player1.pos.Equals(New Point(51, 14)) And Game.player1.perks(perk.faepassangers) = 3 And Game.currFloor.mBoard(56, 48).Text = "" Then
            TextEvent.push("As you arrive at the staircase, the faerie yanks back on your reins.  You slow down and stop, and she hops down to help the yellow woman out of the carriage." & DDUtils.RNRN &
                           """Thank you for the ride, little flower.  I hope you will find your payment to be... satisfactory."" the woman says, handing over a small velvet pouch." & DDUtils.RNRN &
                           """O-oh, you don't need to-""" & DDUtils.RNRN &
                           """Ah, but I insist.""" & DDUtils.RNRN &
                           "The fae thanks the stranger, who vanishes into the aether after a brief farewell.  Turning back to you, the faerie slips open the pouch and counts a few coins from within.", AddressOf postQuest)
            Return True
        End If

        Return False
    End Function

    Protected Friend Shared Sub postQuest()
        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(60), """Alright, let's get that bridle off of ya.  Your cut comes out to...""", AddressOf questRewards1)
    End Sub
End Class
