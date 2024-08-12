Public Class FaeWoodsQ1A
    Inherits Quest

    Sub New()
        MyBase.New("Fae Woods Q1A - Introductions")

        quest_index = qInd.faewoods1a

        objectives.Add(New FaeWoodsQ1AS1)
    End Sub

    Public Overrides Sub init()
        MyBase.init()

        Dim refP = "guy"
        Dim title = "Mister"

        If Game.player1.sex = "Female" Then
            refP = "gal"
            title = "Miss"
        ElseIf Game.player1.sex = "Male" Then
            refP = "guy"
            title = "Mister"
        Else
            refP = "pal"
            title = "um, you"
        End If

        Game.player1.perks(perk.meetfae1) = 1

        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(49), "Welcome to the Fae Woods, big " & refP & "!" & DDUtils.RNRN &
                                                            "People tend to end up lost here on their lonesome, but lucky for you I was passing by and just so happen to know the way." & DDUtils.RNRN &
                                                            "Yep, I could be your very own fairy guide, " & title & "...", AddressOf askForName)
    End Sub
    Public Overrides Function canGet() As Boolean
        Return Not getActive() And Game.mDun.numCurrFloor = 13 And Game.player1.perks(perk.meetfae1) < 1 And Int(Rnd() * 2) = 0 And Not getComplete()
    End Function

    '| - QUESTIONS - |
    Public Shared Sub askForName()
        TextEvent.pushYesNo("Tell the Fae your name?", AddressOf giveName, AddressOf declineToGiveName1)
    End Sub
    Public Shared Sub askForNameAgain()
        If Game.player1.className.Equals("Bimbo") Then
            TextEvent.pushYesNo("Tell the Fae your name?", AddressOf giveName, AddressOf declineToGiveName2)
        Else
            TextEvent.pushYesNo("Tell the Fae your name?", AddressOf giveName, AddressOf askForNameAlternate)
        End If
    End Sub
    Public Shared Sub askForNameAlternate()
        TextEvent.pushYesNo("Tell the Fae your class title instead?", AddressOf giveTitle, AddressOf declineToGiveName2)
    End Sub
    Public Shared Sub askForClass()
        If Game.player1.className.Equals("Bimbo") Then
            TextEvent.pushYesNo("Tell the Fae your class title?", AddressOf ClericTFEnd, AddressOf RebelEnd)
        Else
            TextEvent.pushYesNo("Tell the Fae your class title?", AddressOf BimboTFEnd, AddressOf RebelEnd)
        End If
    End Sub
    Public Shared Sub askForApology()
        TextEvent.pushYesNo("Apologize?", AddressOf giveApology, AddressOf refuseApology)
    End Sub

    '| - RESPONSES - |
    Public Shared Sub giveName()
        Game.player1.perks(perk.faehasname) = 1
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(50), "Interesting, interesting, that's a solid name!  It suits you well!  And, " & Game.player1.name & ", before we get too far into it, what sort of adventurer are you?", AddressOf askForClass)
    End Sub
    Public Shared Sub giveTitle()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(50), "Oooooh, vocational...  But hey, big " & Game.player1.className & ", you don't gotta be that careful here, you know?  Lighten up a bit, these are the fae woods!" & DDUtils.RNRN &
                          "What, are you worried a little fun is gonna turn you into more of a bimbo?", AddressOf fairyDustEnd)
    End Sub

    'decline responses
    Public Shared Sub declineToGiveName1()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(54), "Ugh, c'mon, it's just a name...  It's going to get reeeeal awkward if I'm just calling you ""pal"" or ""you"" or something like that.  Be polite and give me your dumb name, alright?", AddressOf askForNameAgain)
    End Sub
    Public Shared Sub declineToGiveName2()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(53), "Ugh, fine, keep your crummy name secret.  You know, you're being awfully rude for someone who's asking ME for help.  I think you owe me an apology...", AddressOf askForApology)
    End Sub
    'apology conversation
    Public Shared Sub giveApology()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(50), "Glad you have some manners after all...  Tell you what, I'll forgive you if you do me a ♪sooolid!♫" & DDUtils.RNRN & "Give me something to call you, ok?", AddressOf askForName)
    End Sub
    Public Shared Sub refuseApology()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(55), "HMMPH!  Fine then, be that way.  You can find your own way through the Fae Woods.  I'd wish you luck, but honestly I hope you get turned into a tree.  You should really learn to be more polite...", AddressOf Game.player1.quests(qInd.faewoods1a).completeEntireQuest)
        Game.player1.perks(perk.faecurse) = 1

        FaeQueen.spawn(Game.currFloor)
    End Sub

    '| - STORY PROGRESSION - |
    Public Shared Sub BimboTFEnd()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(56), Game.player1.name & " the " & Game.player1.className & ", huh?  Nah, that doesn't sound right..." & DDUtils.RNRN &
                "You seem a bit too airheaded to be a " & Game.player1.className & ", not to mention your slutty clothes!" & DDUtils.RNRN &
                "Clearly you're " & Game.player1.name & " the Bimbo, right?", AddressOf fairyDustEnd)

        Game.player1.ongoingTFs.add(New FBimboTF(2, 5, 0.25, True))
        Game.player1.perks(perk.bimbotf) = 0
    End Sub
    Public Shared Sub ClericTFEnd()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(56), Game.player1.name & " the " & Game.player1.className & ", huh?  Nah, that doesn't sound right..." & DDUtils.RNRN &
                                                            "You're way too calm and collected to be a " & Game.player1.className & ", not to mention that you don't have the figure for it!" & DDUtils.RNRN &
                                                            "Clearly you're " & Game.player1.name & " the Cleric, right?", AddressOf fairyDustEnd)

        Game.player1.ongoingTFs.add(New FClericTF(2, 5, 0.25, True))
        Game.player1.perks(perk.bimbotf) = 0
    End Sub
    Public Shared Sub RebelEnd()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(51), "Woah, woah, didn't mean to pry..." & DDUtils.RNRN &
                                                            "Fine, if you don't want my help, you don't want my help.  But, " & Game.player1.name & "?  Just know, if I were going to pull something fast on you, I'd have already gotten all I needed..." & DDUtils.RNRN &
                                                            "You stay safe now, you hear?", AddressOf Game.player1.quests(qInd.faewoods1a).completeEntireQuest)
        Game.player1.perks(perk.faestaysafe) = 1

        FaeQueen.spawn(Game.currFloor)
    End Sub
    Public Shared Sub fairyDustEnd()
        TextEvent.push("Wait... what?" & DDUtils.RNRN &
                       "As the fairy rambles on and the two of you wander into the twinkley mists, you can't get her question out of your head..." & DDUtils.RNRN &
                       """Alright, it's this way!""" & DDUtils.RNRN &
                       "Glancing up to see what your 'guide' is talking about, you- and she's gone..." & DDUtils.RNRN &
                       "You aren't really sure what you expected...", AddressOf Game.player1.quests(qInd.faewoods1a).completeEntireQuest)
    End Sub

    Public Shared Sub altCompleteEntireQuest()
        Dim p = Game.player1

        TextEvent.yesAction = Nothing
        TextEvent.noAction = Nothing

        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(57), """Um... my bad..."" says the green-clad fairy, before flying off into the mists." & DDUtils.RNRN &
                                                             "The remaining sprite turns back, now that the two of you are alone." & DDUtils.RNRN &
                                                             """Some faefolk...  Ok, let's try that again.""", AddressOf Objective.fromNPC)

        FaeQueen.spawn(Game.currFloor)

        p.quests(qInd.faewoods1a).finishEarly()
        p.quests(qInd.faewoods2a).finishEarly()
    End Sub
End Class

Friend Class FaeWoodsQ1AS1
    Inherits Objective

    Sub New()
        MyBase.New("Talk with the faerie.")
    End Sub

    Public Overrides Sub complete()
        MyBase.complete()
    End Sub

    Public Overrides Function getDesc() As String
        Return description
    End Function

    Public Overrides Function isComplete() As Boolean
        Return False
    End Function
End Class