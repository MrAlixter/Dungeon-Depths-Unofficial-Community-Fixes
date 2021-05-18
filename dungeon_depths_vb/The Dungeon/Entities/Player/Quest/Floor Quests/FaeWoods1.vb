Public Class FaeWoods1
    Inherits Quest

    Sub New()
        MyBase.New("Fae Woods P1")

        qInd = qInds.faewoods1

        objectives.Add(New FaeWoodsS1)
        objectives.Add(New FaeWoodsHorse)
    End Sub

    Public Overrides Sub init()
        MyBase.init()

        Dim refP = "guy"
        Dim title = "Mister"

        If Game.player1.prt.sexBool Then
            refP = "gal"
            title = "Miss"
        End If

        Game.player1.perks(perk.meetfae1) = 1

        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(49), "Welcome to the Fae Woods, big " & refP & "!  People tend to end up lost here on there lonesome, but lucky for you I was passing by and just so happen to know the way.  Yep, I could be your very own fairy guide, " & title & "...", AddressOf askForName)
    End Sub

    'introduction conversation
    Sub askForName()
        Game.pushPnlYesNo("Tell the Fae your name?", AddressOf giveName, AddressOf declineToGiveName1)
    End Sub
    Sub giveName()
        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(50), "Interesting, interesting, that's a solid name!  It suits you well!  Say, " & Game.player1.name & ", I don't suppose you could do me a favor before we're off...", AddressOf askForFavor)
    End Sub
    Sub declineToGiveName1()
        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(54), "Ugh, c'mon, it's just a name...  It's going to get reeeeal awkward if I'm just calling you ""pal"" or ""you"" or something like that.  Be polite and give me your dumb name, alright?", AddressOf askForNameAgain)
    End Sub
    Sub askForNameAgain()
        Game.pushPnlYesNo("Tell the Fae your class title?", AddressOf giveTitle, AddressOf declineToGiveName2)
    End Sub
    Sub giveTitle()
        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(50), "Oooooh, vocational...  Say, " & Game.player1.className & ", I don't suppose you could do me a favor before we're off...", AddressOf askForFavor)
    End Sub
    Sub declineToGiveName2()
        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(53), "Ugh, fine, keep your crummy name secret.  You know, you're being awfully rude for someone who's asking ME for help.  I think you owe me an apology...", AddressOf askForApology)
    End Sub

    'apology conversation
    Sub askForApology()
        Game.pushPnlYesNo("Apologize?", AddressOf giveApology, AddressOf refuseApology)
    End Sub
    Sub giveApology()
        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(50), "Glad you have some concept of manners after all...  Tell you what, I'll forgive you if you do me a ♪sooolid!♫", AddressOf askForFavor)
    End Sub
    Sub refuseApology()
        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(55), "HMMPH!  Fine then, be that way.  You can find your own way through the Fae Woods.  I'd wish you luck, but honestly I hope you get turned into a tree.  You should really learn to be more polite...", AddressOf completeEntireQuest)
    End Sub

    'favor conversation
    Sub askForFavor()
        Game.pushPnlYesNo("Do the Fae's favor?", AddressOf acceptFavor, AddressOf refuseFavor)
    End Sub
    Sub acceptFavor()
        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(49), "Yay, great!  I've been workshopping a pie recipe, but for some reason no one wants to try it.  Have a slice and let me know what you think, ok?", AddressOf askToEatPie)
    End Sub
    Sub refuseFavor()
        Game.pushPnlYesNo("Decline Politely?", AddressOf declinePolitely, AddressOf declineRudely)
    End Sub
    Sub declinePolitely()
        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(53), "Oh, that's too bad...  I understand though, I guess you can't be too careful in these parts!  I guess I'll see you around, ok?", AddressOf completeEntireQuest)
    End Sub
    Sub declineRudely()
        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(51), "Ooh, is that so?  Well if that favor isn't your cup of tea, I do have something else that would be perfect for someone as ""selfless"" as you...", AddressOf horseTF1)
    End Sub

    'pie conversation
    Sub askToEatPie()
        Game.pushPnlYesNo("Eat a slice of pie?", AddressOf eatPie1, AddressOf declinePolitely)
    End Sub
    Sub eatPie1()
        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(56), "I appreciate it!  Here, I'll get some for both of us!", AddressOf eatPie2)
    End Sub
    Sub eatPie2()
        Game.pushLblEvent("The fae waves one of her hands, and a plate containing a steaming hot slice of apple pie materializes in front of her.  Grasping it with both hands, she hands it over to you before twirling a fork from nothingness and placing it on the plate.  As you inspect the pie, she beams and summons herself a smaller plate." & DDUtils.RNRN &
                          """Dig in!""" & DDUtils.RNRN &
                          "As the fae begins eating, you glance down one last time before shrugging and taking a bite.  To your suprise, the pie is some of the best you've ever tasted!  Before long, your plate is clean, and you are enthusiastically praising the fae on her recipe.  The fae... who seeeems to be getting bigger by the second..." & DDUtils.RNRN &
                          "With folktales and warnings of the tricks of the fairies running through your mind, you internally curse yourself as you sink deep into your apparel.", AddressOf eatPie3)
    End Sub
    Sub eatPie3()
        Polymorph.transform(Game.player1, "Fae")
        ' Game.picPortrait.BackgroundImage = Portrait.CreateBMP({Game.picPortrait.BackgroundImage, Game.picPFaeShock.BackgroundImage})
        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(51), "Oh, right, I probably should have warned you, this pie turns humans into fae; the enchantment gives the pie some of its flavor I've been told..." & DDUtils.RNRN &
                                                            "Whelp, a fae shouldn't need a guide in these parts or that pile of junk you're standing in, so I guess I'll pick that mess up for you and skedaddle!  ♪Also you're welllcome!♫", AddressOf eatPie4)
    End Sub
    Sub eatPie4()
        Game.leaveNPC()
        Game.pushLblEvent("As the fae vanishes into the mist with all of your stuff, you collapse to your tiny knees." & DDUtils.RNRN &
                          """Did I really just get robbed by a damn fairy!?""", AddressOf completeEntireQuest)
    End Sub

    'horse transformation
    Sub horseTF1()
        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(52), "Oh yeah, I know the PERFECT way for you to pay me back!", AddressOf horseTF2)
    End Sub
    Sub horseTF2()
        Polymorph.transform(Game.player1, "Horse")
        System.Threading.Thread.Sleep(750)
        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(60), "With a glittering poof, the fae is replaced by a shadowy figure clad in a hooded robe.  Rather a gasp of shock, you let out a loud neigh and rear back on your hind legs at the sight of the now not-so-teeny fae.  In a panic, you make off into the mist of the forest and away from the angry forest spirit but before you can get far you are tugged back by a bridle and reins that seem to have materialized out of thin air.", AddressOf horseTF3)
    End Sub
    Sub horseTF3()
        Dim refP = "guy"
        If Game.player1.prt.sexBool Then refP = "gal"
        If Game.player1.perks(perk.faehasname) Then refP = Game.player1.name

        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(60), "Woah there, " & refP & ", let's cut it out with the running.  I'm not gonna hurt you.  See, there's a lot of travellers that end up in these woods without knowing where they need to go.  Some of them don't exactly play nice, so we fae-folk like to keep you all moving through here as soon as possible.", AddressOf horseTF4)
    End Sub
    Sub horseTF4()
        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(62), "Turns out that the easiest way to get the more savy wanderers out of here is to just roll up with a carrige and ferry them out.  Congrats, you get to help me out!  Let's get moving, I'll point you in the right direction...")
    End Sub

    Public Overrides Function canGet() As Boolean
        Return Not getActive() And Game.mDun.numCurrFloor = 13 And Game.player1.perks(perk.meetfae1) < 1 And Int(Rnd() * 2) = 0 And Not getComplete()
    End Function
End Class

Public Class FaeWoodsS1
    Inherits Objective

    Sub New()
        MyBase.New("Talk with the faerie")
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

Public Class FaeWoodsHorse
    Inherits Objective

    Sub New()
        MyBase.New("Escort 5 passengers")
    End Sub

    Public Overrides Sub complete()
        MyBase.complete()
    End Sub

    Public Overrides Function getDesc() As String
        Return description & "  [" & 1 & "/1]"
    End Function

    Public Overrides Function isComplete() As Boolean
        Return False
    End Function
End Class

