Public Class Fae
    Inherits ShopNPC
    Sub New()
        name = "Fae"
        health = 1.0
        maxHealth = 9999
        attack = 99
        defense = 99
        speed = 999

        'Define the inventory
        inv = New Inventory(False)
        'Armor/Accesories

        isShop = False
        gold = 0
        pronoun = "she"
        pPronoun = "her"
        rPronoun = "her"
        picNormal = ShopNPC.npcLib.atrs(0).getAt(49)

        picNPC = New List(Of Image)
        picNPC.AddRange({ShopNPC.npcLib.atrs(0).getAt(49),
                         ShopNPC.npcLib.atrs(0).getAt(50),
                         ShopNPC.npcLib.atrs(0).getAt(51),
                         ShopNPC.npcLib.atrs(0).getAt(52),
                         ShopNPC.npcLib.atrs(0).getAt(53),
                         ShopNPC.npcLib.atrs(0).getAt(54),
                         ShopNPC.npcLib.atrs(0).getAt(55),
                         ShopNPC.npcLib.atrs(0).getAt(56),
                         ShopNPC.npcLib.atrs(0).getAt(57),
                         ShopNPC.npcLib.atrs(0).getAt(58),
                         ShopNPC.npcLib.atrs(0).getAt(60),
                         ShopNPC.npcLib.atrs(0).getAt(62)})

        If speed = Game.player1.speed Then speed -= 1
        title = ""
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If Not target.GetType() Is GetType(Player) Then
            MyBase.attackCMD(target)
        Else
            Game.NPCfromCombat(Me)
            Game.leaveNPC()
            Game.pushLblEvent("""Well, someone needs to relax...""")
            Dim bTF As BimboTF = New BimboTF(2, 0, 0.25, True)
            bTF.step2()
            Game.player1.inv.add(147, 1)
            Equipment.clothesChange(Game.player1, "Skimpy_Tube_Top")
            Game.player1.drawPort()
            pos = New Point(-1, -1)
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

    'name conversation
    Shared Sub firstEncounter()
        displayFaeImg(0)

        Dim refP = "guy"
        Dim title = "Mister"
        If Game.player1.prt.sexBool Then refP = "gal" : title = "Miss"
        Game.player1.perks(perk.meetfae1) = 1
        Game.pushNPCDialog("Welcome to the Fae Woods, big " & refP & "!  People tend to end up lost here on there lonesome, but lucky for you I was passing by and just so happen to know the way.  Yep, I could be your very own fairy guide, " & title & "...", AddressOf askForName)
    End Sub
    Shared Sub askForName()
        Game.pushPnlYesNo("Tell the Fae your name?", AddressOf giveName, AddressOf declineToGiveName1)
    End Sub
    Shared Sub giveName()
        displayFaeImg(1)

        Game.pushNPCDialog("Interesting, interesting, that's a solid name!  It suits you well!  Say, " & Game.player1.name & ", I don't suppose you could do me a favor before we're off...", AddressOf askForFavor)
    End Sub
    Shared Sub declineToGiveName1()
        displayFaeImg(5)

        Game.pushNPCDialog("Ugh, c'mon, it's just a name...  It's going to get reeeeal awkward if I'm just calling you ""pal"" or ""you"" or something like that.  Be polite and give me your dumb name, alright?", AddressOf askForNameAgain)
    End Sub
    Shared Sub askForNameAgain()
        Game.pushPnlYesNo("Tell the Fae your class title?", AddressOf giveTitle, AddressOf declineToGiveName2)
    End Sub
    Shared Sub giveTitle()
        displayFaeImg(1)

        Game.pushNPCDialog("Oooooh, vocational...  Say, " & Game.player1.className & ", I don't suppose you could do me a favor before we're off...", AddressOf askForFavor)
    End Sub
    Shared Sub declineToGiveName2()
        displayFaeImg(4)

        Game.pushNPCDialog("Ugh, fine, keep your crummy name secret.  You know, you're being awfully rude for someone who's asking ME for help.  I think you owe me an apology...", AddressOf askForApology)
    End Sub

    'apology conversation
    Shared Sub askForApology()
        Game.pushPnlYesNo("Apologize?", AddressOf giveApology, AddressOf refuseApology)
    End Sub
    Shared Sub giveApology()
        displayFaeImg(1)

        Game.pushNPCDialog("Glad you have some concept of manners after all...  Tell you what, I'll forgive you if you do me a ♪sooolid!♫", AddressOf askForFavor)
    End Sub
    Shared Sub refuseApology()
        Dim f = New Fae
        displayFaeImg(6)

        Game.pushNPCDialog("HMMPH!  Fine then, be that way.  You can find your own way through the Fae Woods.  I'd wish you luck, but honestly I hope you get turned into a tree.  You should really learn to be more polite...", AddressOf f.leave)
    End Sub

    'favor conversation
    Shared Sub askForFavor()
        Game.pushPnlYesNo("Do the Fae's favor?", AddressOf acceptFavor, AddressOf refuseFavor)
    End Sub
    Shared Sub acceptFavor()
        displayFaeImg(0)

        Game.pushNPCDialog("Yay, great!  I've been workshopping a pie recipe, but for some reason no one wants to try it.  Have a slice and let me know what you think, ok?", AddressOf askToEatPie)
    End Sub
    Shared Sub refuseFavor()
        Game.pushPnlYesNo("Decline Politely?", AddressOf declinePolitely, AddressOf declineRudely)
    End Sub
    Shared Sub declinePolitely()
        displayFaeImg(8)

        Game.pushNPCDialog("Oh, that's too bad...  I understand though, I guess you can't be too careful in these parts!  I guess I'll see you around, ok?", AddressOf Game.leaveNPC)
    End Sub
    Shared Sub declineRudely()
        displayFaeImg(2)

        Game.pushNPCDialog("Ooh, is that so?  Well if that favor isn't your cup of tea, I do have something else that would be perfect for someone as ""selfless"" as you...", AddressOf horseTF1)
    End Sub

    'pie conversation
    Shared Sub askToEatPie()
        Game.pushPnlYesNo("Eat a slice of pie?", AddressOf eatPie1, AddressOf declinePolitely)
    End Sub
    Shared Sub eatPie1()
        displayFaeImg(7)

        Game.pushNPCDialog("I appreciate it!  Here, I'll get some for both of us!", AddressOf eatPie2)
    End Sub
    Shared Sub eatPie2()
        Game.pushLblEvent("The fae waves one of her hands, and a plate containing a steaming hot slice of apple pie materializes in front of her.  Grasping it with both hands, she hands it over to you before twirling a fork from nothingness and placing it on the plate.  As you inspect the pie, she beams and summons herself a smaller plate." & DDUtils.RNRN &
                          """Dig in!""" & DDUtils.RNRN &
                          "As the fae begins eating, you glance down one last time before shrugging and taking a bite.  To your suprise, the pie is some of the best you've ever tasted!  Before long, your plate is clean, and you are enthusiastically praising the fae on her recipe.  The fae...who...seeeems to be getting bigger by the second..." & DDUtils.RNRN &
                          "With folktales and warnings of the tricks of the fairies running through your mind, you internally curse yourself as you sink deep into your apparel.", AddressOf eatPie3)
    End Sub
    Shared Sub eatPie3()
        displayFaeImg(2)
        Polymorph.transform(Game.player1, "Fae")
        Game.picPortrait.BackgroundImage = Portrait.CreateBMP({Game.picPortrait.BackgroundImage, Game.picPFaeShock.BackgroundImage})
        Game.pushNPCDialog("Oh, right, I probably should have warned you, this pie turns humans into fae; the enchantment gives the pie some of its flavor I've been told...  Whelp, a fae shouldn't need a guide in these parts or that pile of junk you're standing in, so I guess I'll see you around?  ♪Also you're welllcome!♫", AddressOf eatPie4)
    End Sub
    Shared Sub eatPie4()
        Game.leaveNPC()
        Game.pushLblEvent("As the fae vanishes into the mist with all of your stuff, you collapse to your tiny knees." & DDUtils.RNRN &
                          """Did I really just get robbed by a damn fairy!?""")
    End Sub

    'horse transformation
    Shared Sub horseTF1()
        displayFaeImg(3)

        Game.pushNPCDialog("Oh yeah, I know the PERFECT way for you to pay me back!", AddressOf horseTF2)
    End Sub
    Shared Sub horseTF2()
        displayFaeImg(10)
        Polymorph.transform(Game.player1, "Horse")
        System.Threading.Thread.Sleep(750)
        Game.pushLblEvent("With a glittering poof, the fae is replaced by a shadowy figure clad in a hooded robe.  Rather a gasp of shock, you let out a loud neigh and rear back on your hind legs at the sight of the now not-so-teeny fae.  In a panic, you make off into the mist of the forest and away from the angry forest spirit but before you can get far you are tugged back by a bridle and reins that seem to have materialized out of thin air.", AddressOf horseTF3)
    End Sub
    Shared Sub horseTF3()
        displayFaeImg(10)

        Dim refP = "guy"
        If Game.player1.prt.sexBool Then refP = "gal"
        If Game.player1.perks(perk.faehasname) Then refP = Game.player1.name

        Game.pushNPCDialog("Woah there, " & refP & ", let's cut it out with the running.  I'm not gonna hurt you.  See, there's a lot of travellers that end up in these woods without knowing where they need to go.  Some of them don't exactly play nice, so we fae-folk like to keep you all moving through here as soon as possible.", AddressOf horseTF4)
    End Sub
    Shared Sub horseTF4()
        displayFaeImg(11)

        Game.pushNPCDialog("Turns out that the easiest way to get the more savy wanderers out of here is to just roll up with a carrige and ferry them out.  Congrats, you get to help me out!  Let's get moving, I'll point you in the right direction...")
    End Sub

    Shared Sub displayFaeImg(ByVal i As Integer)
        Dim f = New Fae
        f.npcIndex = i
        Game.picNPC.BackgroundImage = f.picNPC(i)
    End Sub
    Sub leave()
        Game.leaveNPC()
    End Sub
    Sub badForYou()
        If Game.combatmode Then Game.fromCombat()
        Game.picNPC.BackgroundImage = picNPC(7)
        Game.picNPC.Location = New Point(82 * Game.Size.Width / 1024, 179 * Game.Size.Width / 1024)
        Game.picNPC.Visible = True
        If Game.npcmode Then Game.hideNPCButtons()
        Game.pushNPCDialog("HMMPH!  RUDE!  Honestly, you should really learn to be more polite...", AddressOf leave)
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
