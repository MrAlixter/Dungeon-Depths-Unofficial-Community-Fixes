Public Class FantasticPhantom
    Inherits Quest

    Public Const MET_FANTOMA_BASE = 1
    Public Const MET_FANTOMA_ENEMY = 2

    Public Shared original_clothes As String = ""
    Sub New()
        MyBase.New("Phantastic Fantom")

        quest_index = qInd.fanPhan

        Game.checkIfCantEquip()
        objectives.Add(New FanPhanStep1)
        objectives.Add(New FanPhanStep2)
        objectives.Add(New FanPhanStep3)
    End Sub

    Public Overrides Sub init()
        MyBase.init()

        Dim enemy = Game.player1.currTarget.getNameWithTitle()
        Game.fromCombat()

        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(129), "With a poof of white smoke, " & enemy & " suddenly vanishes into a flock of inumerable doves, cutting your fight short." & DDUtils.RNRN &
                                                             """Hello and good" & DDDateTime.getGeneralTimeOfDay & ", ladies and gentlemen,"" announces a new figure, shrouded in mist." & DDUtils.RNRN &
                                                             """I've got an amazing show lined up for you fine folks " & If(DateTime.Now().Hour > 17, "today", "tonight") & "!  There'll be stunts that defy reality, tricks that will boggle the mind.  Watch closely, ladies and gentlemen, you won't want to miss a thing." & DDUtils.RNRN &
                                                             "So, without further ado...""" & DDUtils.PAKTC, AddressOf init2)
    End Sub
    Private Sub init2()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(128), "With a loud CRACK, a spotlight beams down from above onto the figure and an impressive wooden stage twists upwards from below her feet.  The top-hatted woman, now clearly visible, takes a few tappy steps forward." & DDUtils.RNRN &
                                                             """Let's start the show!""" & DDUtils.PAKTC, AddressOf initIntroduction)
    End Sub
    Private Sub initIntroduction()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(128), "She pauses for a brief round of applause that comes from nowhere in particular, before raising a finger as a number of additional spotlights begin sweeping around you." & DDUtils.RNRN &
                                                             """Ah, but what is a magician without her lovely assitant?  Say, you over there, I don't suppose I could borrow you for a spell?""" & DDUtils.RNRN &
                                                             "Not seeing anyone else around, you hesitantly point up at yourself and the performer nods enthusiastically." & DDUtils.PAKTC, AddressOf askForVolunteer)
    End Sub
    Private Sub askForVolunteer()
        TextEvent.pushYesNo("Play along?", AddressOf initVolunteerYes, AddressOf initVolunteerNo)
    End Sub
    Private Sub initVolunteerYes()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(127), """Wonderful, we haved a volunteer!  Let's give them a hand, folks!""" & DDUtils.RNRN &
                                                             "A round of thunderous applause breaks out from seemingly every direction, and you head to join her on stage." & DDUtils.RNRN &
                                                             "Quest ""Phantastic Fantom"" acquired!", AddressOf FanPhanStep1.step1Change)

        Game.player1.perks(perk.metfantoma) = MET_FANTOMA_BASE
    End Sub
    Private Sub initVolunteerNo()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(127), """Ooh, looks like they're a little shy...  Let's give them a little encouragement, folks!""" & DDUtils.RNRN &
                                                             "A round of cheers and applause breaks out from seemingly every direction." & DDUtils.RNRN &
                                                             "You glare back at the woman, unamused." & DDUtils.RNRN &
                                                             """Ah, one sec everyone."" she says with a sheepish chuckle, teleporting besides you with a poof of smoke.", AddressOf initVolunteerNo2)
    End Sub
    Private Sub initVolunteerNo2()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(128), """Come on, what are you doing?"" the performer whispers, sounding a little annoyed.  ""This ain't anything sinister, just a harmless little bit of fun!""" & DDUtils.RNRN &
                                                            "She vanishes with another poof, reappearing back on stage with a flourish." & DDUtils.RNRN &
                                                             """So whaddya say, pal, won't you lend me a hand?""", AddressOf askForVolunteer2)
    End Sub
    Private Sub askForVolunteer2()
        TextEvent.pushYesNo("Play along?", AddressOf initVolunteerYes, AddressOf initVolunteerNoFinal)
    End Sub

    Private Sub initVolunteerNoFinal()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(127), "You walk away.  The performer doesn't stop grinning as she turns back around herself, but you can hear a subtle break in her tone." & DDUtils.RNRN &
                                                             """W-well, silly little assistant or not, the show must go on!""" & DDUtils.RNRN &
                                                             "Whizzing and popping noises erupt behind you, as a chorus of oohs and ahhs fill the air." & DDUtils.PAKTC, AddressOf initVolunteerNoFinal2)
    End Sub
    Private Sub initVolunteerNoFinal2()
        TextEvent.push("As the noise from the ""show"" fades away into the distance, and the stage vanishes into the mist, a sudden chill runs down your spine." & DDUtils.RNRN &
                       "Nothing seems to have actually happened to have caused it, but as a dove flaps away overhead you can't help but feel that you've made a powerful enemy...")

        Game.player1.perks(perk.metfantoma) = MET_FANTOMA_ENEMY
        completeEntireQuest()
    End Sub

    Public Overrides Function canGet() As Boolean
        Return False
        'Return Not getActive() And Not getComplete() And Game.player1.level > 3 And Game.player1.perks(perk.tfcausingwand) > 0 And Game.player1.perks(perk.tfedbyweapon) > -1 And ((Int(Rnd() * 5) = 0) Or Settings.active(setting.norng)) And Game.combat_engaged AndAlso (Not Game.player1.currTarget Is Nothing AndAlso Not Game.player1.currTarget.GetType.IsSubclassOf(GetType(MiniBoss)) AndAlso Not Game.player1.currTarget.GetType.IsSubclassOf(GetType(Boss)))
    End Function
End Class

Public Class FanPhanStep1
    Inherits Objective

    Sub New()
        MyBase.New("Play along.")
    End Sub

    Protected Friend Shared Sub step1Change()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(128), "You step over to the woman, and she extends a hand." & DDUtils.RNRN &
                                                             """I'm Fantoma, pleased to meet ya!""" & DDUtils.RNRN &
                                                             "She gives your hand a vigorous shake, before wrapping an arm over and leaning on your shoulder." & DDUtils.RNRN &
                                                             """... and you are?""" & DDUtils.PAKTC, AddressOf step1Change2)
    End Sub
    Private Shared Sub step1Change2()
        Dim pName = Game.player1.getName()
        TextEvent.push("""No, wait, don't tell me.  It's... " & Game.player1.getName() & ", right?""" & DDUtils.RNRN &
                       "Somewhat suprised, you nod, and the cheers return.  Fantoma beams, and turns back to... well, whoever she's talking to." & DDUtils.RNRN &
                       """Ladies and gentlemen, we have NEVER MET!  Ah, but a simple deduction like that is just an apéritif.  " & pName & ", let's get you looking fit for the show!""" & DDUtils.RNRN &
                       "She gently grabs your arm and leads across the stage whilst whispering directions in your ear." & DDUtils.RNRN &
                       """-gonna do a little swap, just grab the first thing that jumps out to you, ok, just-"", though before you can hear anything else, she twirls you over to a faintly scratched 'x' and tosses a silver hoop over your head." & DDUtils.RNRN &
                       "It hovers for a second, spinning in place, before a curtain floofs down from seemingly nohwere and shrouds you in fabric.  You see a variety of outfits and accessories strewn around its interior, and in a split second you reach out for...", AddressOf step1Change3)
    End Sub
    Private Shared Sub step1Change3()
        Dim p As Player = Game.player1

        FantasticPhantom.original_clothes = p.equippedArmor.getAName()

        Dim bunnysuit = New Tuple(Of String, Action)("Glittering Bunny Suit", AddressOf changeGoldenBunny)
        Dim showgirl = New Tuple(Of String, Action)("Glittering Showgirl Outfit", AddressOf changeGoldenShowgirl)
        Dim bowtie = New Tuple(Of String, Action)("Bowtie", AddressOf changeBowTie)
        Dim cowbikini = New Tuple(Of String, Action)("Cow Bikini", AddressOf changeCowBikini)
        Dim spiderweb = New Tuple(Of String, Action)("Spiderweb", AddressOf changeSpiderweb)

        Dim options As List(Of Tuple(Of String, Action)) = New List(Of Tuple(Of String, Action))

        If CType(p.inv.item(BunnySuitG.ITEM_NAME), Armor).fits(p) Then options.Add(bunnysuit)
        If CType(p.inv.item(GShowgirlOutfit.ITEM_NAME), Armor).fits(p) And p.breastSize < 1 Then options.Add(showgirl)
        options.Add(bowtie)
        If CType(p.inv.item(CowBra.ITEM_NAME), Armor).fits(p) And p.breastSize > 2 Then options.Add(cowbikini)
        If CType(p.inv.item(SpidersilkBonds.ITEM_NAME), Armor).fits(p) And CType(p.inv.item(BunnySuitS.ITEM_NAME), Armor).fits(p) Then options.Add(spiderweb)

        TextEvent.pushManySelect("Grab what?", options)
    End Sub
    Private Shared Sub changeGoldenBunny()
        Dim p = Game.player1

        If p.inv.getCountAt(BunnySuitG.ITEM_NAME) < 1 Then p.inv.add(BunnySuitG.ITEM_NAME, 1)
        EquipmentDialogBackend.armorChange(p, BunnySuitG.ITEM_NAME, False)

        p.drawPort()

        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(128), "As you reach out for the outfit, it quickly flickers out of sight.  A quick glance down confirms that it didn't go far, and before you have time to think too much more on it the curtain flaps up and a beaming Fantoma announces:" & DDUtils.RNRN &
                                                             """My assistant, ladies and gentlemen;  Give it up for " & p.getName() & "!""" & DDUtils.RNRN &
                                                             "In the instant before the crowd can react, a thought occurs..." & DDUtils.PAKTC, AddressOf strikeAPose)
        TextEvent.pushLog("A " & BunnySuitG.ITEM_NAME & " equips onto you!")
    End Sub
    Private Shared Sub changeGoldenShowgirl()
        Dim p = Game.player1

        If p.inv.getCountAt(GShowgirlOutfit.ITEM_NAME) < 1 Then p.inv.add(GShowgirlOutfit.ITEM_NAME, 1)
        EquipmentDialogBackend.armorChange(p, GShowgirlOutfit.ITEM_NAME, False)

        p.drawPort()

        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(128), "As you reach out for the outfit, it quickly flickers out of sight.  A quick glance down confirms that it didn't go far, and before you have time to think too much more on it the curtain flaps up and a beaming Fantoma announces:" & DDUtils.RNRN &
                                                             """My assistant, ladies and gentlemen;  Give it up for " & p.getName() & "!""" & DDUtils.RNRN &
                                                             "In the instant before the crowd can react, a thought occurs..." & DDUtils.PAKTC, AddressOf strikeAPose)
        TextEvent.pushLog("A " & GShowgirlOutfit.ITEM_NAME & " equips onto you!")
    End Sub
    Private Shared Sub changeBowTie()
        Dim p = Game.player1

        BunnyBimboTF.fantomaTF(p)

        If p.inv.getCountAt(GShowgirlOutfit.ITEM_NAME) < 1 Then p.inv.add(GShowgirlOutfit.ITEM_NAME, 1)
        EquipmentDialogBackend.armorChange(p, GShowgirlOutfit.ITEM_NAME, False)

        p.drawPort()

        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(128), "As you reach out for the bowtie, it quickly flickers out of sight.  A quick glance down confirms that... woah, like, that's new..." & DDUtils.RNRN &
                                                             "Before you have time to think too much, the curtain flaps up and a beaming Fantoma announces:" & DDUtils.RNRN &
                                                             """My assistant, ladies and gentlemen;  Give it up for the beautiful " & p.getName() & "!""" & DDUtils.RNRN &
                                                             "In the instant before the crowd can react, a thought occurs..." & DDUtils.RNRN &
                                                             "You should, like, totally show off!" & DDUtils.PAKTC, AddressOf pose)
        TextEvent.pushLog("A " & Bowtie.ITEM_NAME & " equips onto you!")
    End Sub
    Private Shared Sub changeCowBikini()
        Dim p = Game.player1

        If p.inv.getCountAt(CowBra.ITEM_NAME) < 1 Then p.inv.add(CowBra.ITEM_NAME, 1)
        EquipmentDialogBackend.armorChange(p, CowBra.ITEM_NAME, False)

        p.drawPort()

        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(128), "As you reach out for the bikini, it quickly flickers out of sight.  A quick glance down confirms that it didn't go far, and before you have time to think too much more on it the curtain flaps up and a beaming Fantoma announces:" & DDUtils.RNRN &
                                                             """My... cow, I guess; Ladies and gentlemen, give it up for " & p.getName() & "!""" & DDUtils.RNRN &
                                                             "In the instant before the crowd can react, a thought occurs..." & DDUtils.PAKTC, AddressOf strikeAPose)
        TextEvent.pushLog("A " & CowBra.ITEM_NAME & " equips onto you!")
    End Sub
    Private Shared Sub changeSpiderweb()
        Dim p = Game.player1

        If p.inv.getCountAt(SpidersilkBonds.ITEM_NAME) < 1 Then p.inv.add(SpidersilkBonds.ITEM_NAME, 1)
        EquipmentDialogBackend.armorChange(p, SpidersilkBonds.ITEM_NAME, False)

        p.drawPort()

        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(128), "As you reach out for the cobweb, it quickly flickers out of sight.  A quick glance down reveals that you are now bound in silky strands, and before you have time to think too much more on it the curtain flaps up and a beaming Fantoma announces:" & DDUtils.RNRN &
                                                             """My assistant, ladies and- uhh... heh heh, well, we aren't running that version of the show tonight...""" & DDUtils.RNRN &
                                                             "She draws out a slender black wand and taps your head, and with a poof of smoke the cobwebs shifts into a less immobilizing bunny suit." & DDUtils.RNRN &
                                                             """Ladies and gentlemen, give it up for " & p.getName() & "!""" & DDUtils.RNRN &
                                                             "In the instant before the crowd can react, a thought occurs..." & DDUtils.PAKTC, AddressOf strikeAPose)

        EquipmentDialogBackend.armorChange(p, BunnySuitS.ITEM_NAME, False)
        TextEvent.pushLog("A " & BunnySuitS.ITEM_NAME & " equips onto you!")
    End Sub

    Private Shared Sub strikeAPose()
        If Game.player1.equippedArmor.getAName.Equals(BunnySuitS.ITEM_NAME) Then Game.player1.drawPort()
        TextEvent.pushYesNo("Strike a Pose?", AddressOf pose, AddressOf noPose)
    End Sub
    Private Shared Sub pose()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(127), "You strike a sexy pose, and flash the audience your own grin." & DDUtils.RNRN &
                          """Aww, isn't " & If(Game.player1.sex.Equals("Male"), "he", "she") & " just a treat?""" & DDUtils.RNRN &
                          "Fantoma's praise seems genuine, and it seems like that was exactly what she was hoping you would do." & DDUtils.PAKTC, AddressOf FanPhanStep2.step2Wand)
        Game.player1.quests(qInd.fanPhan).completeCurrOjb()
    End Sub
    Private Shared Sub noPose()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(127), "You strike a sexy pose, and flash the audience your own grin." & DDUtils.RNRN &
                          """Aww, isn't " & If(Game.player1.sex.Equals("Male"), "he", "she") & " just a treat?""" & DDUtils.RNRN &
                          "Despite your outward confidence, you feel dazed, and foggy.  You weren't planning to do a pose, right?" & DDUtils.PAKTC, AddressOf FanPhanStep2.step2Wand)
        Game.player1.wBuff -= 5
        Game.player1.mana /= 3
        Game.player1.quests(qInd.fanPhan).completeCurrOjb()
    End Sub

    Public Overrides Sub complete()
        MyBase.complete()
    End Sub

    Public Overrides Function getDesc() As String
        Return description & "  [???/???]"
    End Function

    Public Overrides Function isComplete() As Boolean
        Return False
    End Function
End Class

Public Class FanPhanStep2
    Inherits Objective

    Sub New()
        MyBase.New("Keep playing along.")
    End Sub

    Protected Friend Shared Sub step2Wand()
        Dim p = Game.player1

        Dim out As String = ""

        If p.equippedWeapon.GetType.IsSubclassOf(GetType(Wand)) Then
            out += """Oop, better hang onto that fancy wand of yours for safekeeping, it'd be a shame if something happened to it during the show.""" & DDUtils.RNRN &
                   "Fantoma snatches the wand out of your hands, before turning to you with a smile." & DDUtils.RNRN &
                   """...but don't worry, in the meantime you get to spin..."""
        Else
            out += """One last finishing touch touch though...""" & DDUtils.RNRN &
                   "Fantoma places a hand on your shoulder, turning to you with a smile." & DDUtils.RNRN &
                   """...lucky, lucky, you get to spin..."""
        End If

        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(128), out & DDUtils.PAKTC, AddressOf step2spin1)
    End Sub

    Private Shared Sub step2spin1()
        Dim PAKTS As String = DDUtils.RNRN & "Press any non-movement key to SPIN THE WHEEEEL!"

        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(127), """THE WHEEL OF WACKY WANDS!"" she chants, along with the audience." & DDUtils.RNRN &
                                                             "A massive spin wheel slowly lowers from the ceiling, with inumerable blinking segments that cast a colorful glow across the stage." & DDUtils.RNRN &
                                                             """Step right up and give 'er a spin!  Will you win an ultimate weapon, or mayhaps land on the sliver of instant demise?  Only the wheel knows, only the wheel can design your fate!""" & DDUtils.RNRN &
                                                             "You approach to the wheel, and hesitantly place a hand on the spinner..." & PAKTS, AddressOf step2spin2)
    End Sub
    Private Shared Sub step2spin2()
        Dim spun As String = spin()

        Dim intro As String = "The wheel spins around and around and around..." & DDUtils.RNRN &
                              "...around and around..." & DDUtils.RNRN &
                              "...around..." & DDUtils.RNRN &
                              "The spinner lands on... " & spun.Replace("_", " ") & "!"

        Select Case spun
            Case DitzDazeWand.ITEM_NAME, HealFeelWand.ITEM_NAME, RNDPolyWand.ITEM_NAME
                TextEvent.push(intro & DDUtils.RNRN & """Ooh, that's a good one!"" Fantoma grins, ""Perfect for the next act...""", AddressOf step2final)
            Case FantomaWand.ITEM_NAME
                TextEvent.push(intro & DDUtils.RNRN & """Hey, that's my signature wand!"" Fantoma grins, ""It's a really good one, nice spin!""", AddressOf step2final)
            Case HBSWand.ITEM_NAME
                TextEvent.push(intro & DDUtils.RNRN & """Jackpot, that's a crowd favorite!"" Fantoma grins, ""Perfect for the next act...""", AddressOf step2final)
            Case Else
                TextEvent.push(intro & DDUtils.RNRN & """Ouch...  Well, they aren't all winners..."" Fantoma grimaces, ""Ah, but all the same, the show must go on.""", AddressOf step2final)
        End Select

        EquipmentDialogBackend.weaponChange(Game.player1, spun)
        TextEvent.pushLog("+1 " & spun & "!")


    End Sub
    Private Shared Function spin() As String
        Dim rng = Int(Rnd() * 6)

        Select Case rng
            Case 0
                Return FantomaWand.ITEM_NAME
            Case 1
                Return HealFeelWand.ITEM_NAME
            Case 2
                Return RNDPolyWand.ITEM_NAME
            Case 3
                Return DitzDazeWand.ITEM_NAME
            Case 4
                Return HBSWand.ITEM_NAME
            Case Else
                Return StickWand.ITEM_NAME
        End Select
    End Function

    Private Shared Sub step2final()
        TextEvent.push("A slow drumroll starts to echo through the dungeon, as she continues," & DDUtils.RNRN &
                       """This one's the main event, folks, the extravaganza du jour!""" & DDUtils.RNRN &
                       "Fantoma flips her top hat off of her head, and reaches into it.  She plucks from within its brim another larger hat, this one wrapped in thick chains and a hefty padlock." & DDUtils.RNRN &
                       """I hold here in my hands a trapped greater Ooze, one of the all-consuming variety.  Now, normally we wouldn't be able to safely show off such a specimen, but fortunately for us we've got a magical protector on the scene.  Right, " & Game.player1.getName & "?"" she says, unlatching the lock and setting the hat down on the stage." & DDUtils.RNRN &
                       "A jet black goop seeps forth, amassing into a larger and larger blob that slowly begins engulfing the stage.  Two 'ears' spring up on top of it, giving the monstrosity a rabbitlike silhouette." & DDUtils.RNRN &
                       """Get 'em, champ, we're rooting for you!""" & DDUtils.RNRN &
                       "The Leporine Ooze roars a gooey roar, and you ready your wand for battle!", AddressOf FanPhanStep3.step3tocombat)

        Game.player1.quests(qInd.fanPhan).completeCurrOjb()
    End Sub

    Public Overrides Sub complete()
        MyBase.complete()
    End Sub

    Public Overrides Function getDesc() As String
        Return description & "  [???/???]"
    End Function

    Public Overrides Function isComplete() As Boolean
        Return False
    End Function
End Class

Public Class FanPhanStep3
    Inherits Objective

    Sub New()
        MyBase.New("Defeat the Leporine Ooze!")
    End Sub

    Public Shared Sub step3tocombat()
        Dim m = Monster.monsterFactory(24)

        Monster.targetRoute(m)
        Game.toCombat(m)
    End Sub

    Public Shared Sub lose()
        TextEvent.push("You falter, and the Leporine Ooze rushes in.  Fantoma doesn't seem much to mind, and the last thing you hear before sinking completely into the tar-like goop is her announcing that you look to be in a bit of a jam." & DDUtils.RNRN &
                       "Engulfed in slime and unable to so much as flail around, you find yourself feeling... tingly..." & DDUtils.RNRN &
                       "The sensation starts in your arms and legs, but before long your entire body feels as though it's fading away.  It doesn't stop there, though, and before long, like, even your head... ugh, even your mind feels as though it's... um, dissolving..." & DDUtils.RNRN &
                       "You, like... bubble... away... totally... gone... forever... until..." & DDUtils.RNRN &
                       "Suddenly, reality flashes back into focus with a brilliant light!", AddressOf lose2)
    End Sub
    Private Shared Sub lose2()
        Dim p = Game.player1

        losstf(p)
        p.magGState.save(p)

        EquipmentDialogBackend.equipWeapon(p, "Fists", False)

        If p.breastSize > 4 Then p.breastSize = 4
        If p.inv.getCountAt(BunnySuitG.ITEM_NAME) < 1 Then p.inv.add(BunnySuitG.ITEM_NAME, 1)
        EquipmentDialogBackend.armorChange(p, BunnySuitG.ITEM_NAME, False)
        p.drawPort()

        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(127), """TA-DAAAA!"" Fantoma cheers, plucking your head up by the rabbit-ear headband from her now upside down hat." & DDUtils.RNRN &
                                                             "Once you've been pulled fully out, she turns away from you, towards her 'audience', and throws her hands out with a flourish." & DDUtils.RNRN &
                                                             """Ladies and gentlemen, " & Game.player1.getName & "!""" & DDUtils.RNRN &
                                                             "As the roar of the invisible crowd dies down, Fantoma bows and gestures for you to do the same.  Before long, the dungeon falls silent once again and you Fantoma stand alone on the stage." & DDUtils.PAKTC, AddressOf lose3)
    End Sub
    Private Shared Sub lose3()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(128), """I don't know about you, but I had a blast."" Fantoma chuckles, patting you on the shoulder." & DDUtils.RNRN &
                                                             """Hey, Magical Girl, I'll be sure to get in touch next time I need an assistant!""" & DDUtils.RNRN &
                                                             "With a poof of smoke, Fantoma vanishes as suddenly as she appeared." & DDUtils.RNRN &
                                                             "Quest complete!" & DDUtils.PAKTC)

        Game.player1.quests(qInd.fanPhan).completeEntireQuest()
    End Sub
    Public Shared Sub losstf(ByRef p As Player)
        If p.inv.getCountAt(GShowgirlOutfit.ITEM_NAME) < 1 Then p.inv.add(GShowgirlOutfit.ITEM_NAME, 1)
        EquipmentDialogBackend.armorChange(p, GShowgirlOutfit.ITEM_NAME, False)

        If p.sex = "Male" Then
            p.MtF()
        End If

        p.changeClass("Bimbo")
        p.changeForm("Goo Girl")

        p.breastSize = 3

        'hair
        p.prt.setIAInd(pInd.rearhair, 28, True, True)
        p.prt.setIAInd(pInd.midhair, 9, True, False)
        p.prt.setIAInd(pInd.fronthair, 28, True, True)
        'face
        p.prt.setIAInd(pInd.face, 0, True, False)
        p.prt.setIAInd(pInd.eyes, 25, True, True)
        p.prt.setIAInd(pInd.mouth, 27, True, True)

        'other
        p.prt.setIAInd(pInd.cloak, 0, True, False)

        p.prt.skincolor = Color.FromArgb(210, 255, 142, 179)
        p.prt.haircolor = Color.FromArgb(180, 255, 160, 255)
        p.drawPort()
        p.perks(perk.vsslimehair) = 0
    End Sub

    Public Shared Sub win()
        TextEvent.push("As what's left of the Leporine Ooze drips through the crack of the stage, Fantoma claps you on the shoulder." & DDUtils.RNRN &
                       """Woah, impressive work!  I didn't think you had it in you..."" she says, chuckling to herself, ""...but what else should we have expected, folks?""" & DDUtils.RNRN &
                       "She turns away from you, towards her 'audience', and throws her hands out with a flourish." & DDUtils.RNRN &
                       """Let's hear it for the magnificent " & Game.player1.getName & "!""", AddressOf win2)
    End Sub
    Private Shared Sub win2()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(127), "After the roar of the invisible crowd begins to die down, Fantoma bows and gestures for you to do the same.  Before long, the dungeon falls silent once again and you Fantoma stand alone on the stage." & DDUtils.RNRN &
                                                             """Hey, you did great!  Next time I'm looking for help with something, I'll definitely be keeping you in mind."" she says, tossing you a small pouch of coins and waving a hand, causing your clothing and original wand to flicker back into place." & DDUtils.RNRN &
                                                             "+1500 Gold" & DDUtils.PAKTC, AddressOf win3)

        Dim p = Game.player1

        p.inv.add(Gold.ITEM_NAME, 1500)
        If p.inv.getCountAt(p.perks(perk.tfcausingwand)) > 0 Then EquipmentDialogBackend.weaponChange(p, p.inv.item(p.perks(perk.tfcausingwand)).getAName(), False)
        If p.inv.getCountAt(FantasticPhantom.original_clothes) > 0 Then EquipmentDialogBackend.armorChange(p, FantasticPhantom.original_clothes, False)

        p.drawPort()
    End Sub
    Private Shared Sub win3()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(128), """Don't worry though, when the time comes I'll find you." & DDUtils.RNRN &
                                                             "It was a pleasure, " & Game.player1.getName & " the " & Game.player1.className & "!""" & DDUtils.RNRN &
                                                             "With a poof of smoke, Fantoma vanishes as suddenly as she appeared." & DDUtils.RNRN &
                                                             "Quest complete!" & DDUtils.PAKTC)

        Game.player1.quests(qInd.fanPhan).completeEntireQuest()
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
