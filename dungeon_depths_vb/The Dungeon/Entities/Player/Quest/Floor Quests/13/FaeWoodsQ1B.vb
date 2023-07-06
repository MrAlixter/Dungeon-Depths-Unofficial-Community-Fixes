Public Class FaeWoodsQ1B
    Inherits Quest

    Dim passangerBool As Boolean = False

    Sub New()
        MyBase.New("Fae Woods Q1B - The Easy Way")

        quest_index = qInd.faewoods1b

        objectives.Add(New FaeWoodsQ1BS1)
    End Sub

    Public Overrides Sub init()
        MyBase.init()

        TextEvent.lblEventOnClose = AddressOf questTransition
    End Sub

    Public Overrides Function canGet() As Boolean
        Return Not getActive() And Game.mDun.numCurrFloor = 13 AndAlso Game.player1.perks(perk.meetfae1) < 1 And Not Game.player1.quests(qInd.faewoods1a).getComplete() And Not getComplete()
    End Function

    '| - QUESTIONS - |
    Sub askForPassage()
        TextEvent.pushYesNo("Pay for passage?", AddressOf passage, AddressOf noPassage)
    End Sub

    '| - RESPONSES - |
    Sub passage()
        If Game.player1.gold >= 1000 Then
            Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(56), """Alright, sweet deal!"" the fae cheers, ""That makes this so much easier...""", AddressOf playerPaid)
        ElseIf Game.player1.gold >= 750 Then
            Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(53), """Ugh, looks like you're a little low on funds too..."" the fae grumbles, before her companion interrupts," & DDUtils.RNRN &
                              """Low on funds?  Me?  Hardly...  I already told you that I have more than enough to cover your miniscule fee, and that I will pay promptly as soon as-""" & DDUtils.RNRN &
                              """You know what?  Close enough.  If it means not dealing with this for the rest of the day,"" the faerie cuts back in...", AddressOf playerPaid)
        Else
            Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(54), """Ugh, looks like you're low on funds too..."" the fae grumbles, before her companion interrupts," & DDUtils.RNRN &
                  """Low on funds?  Me?  Hardly...  I already told you that I have more than enough to cover your miniscule fee, and that I will pay promptly as soon as-""" & DDUtils.RNRN &
                  """Yeah, no, I'm not dealing with two of you freeloaders,"" the faerie cuts back in, ""Hmm, now which one one of you would be better at pulling a cart...""", AddressOf passengerHorseTF2)
        End If
    End Sub
    Sub playerPaid()
        Game.player1.gold -= Math.Min(Game.player1.gold, 1000)
        Game.player1.UIupdate()
        Objective.showNPC(If(passangerBool, ShopNPC.gbl_img.atrs(0).getAt(111), ShopNPC.gbl_img.atrs(0).getAt(112)), """So...  I believe there was some mention of a carriage ride?"" the human asks, causing the fae to giggle with glee." & DDUtils.RNRN &
                                                                                                                      """Yes, yes, yes, indeed!  A nice quiet ride-"" she says, charging a tiny ball of arcane energy...", AddressOf playerPaid2)
    End Sub
    Sub playerPaid2()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(113), """...courtesy of a muzzle.""" & DDUtils.RNRN &
                                                             "Her spell hits the other person in the chest, and with an audible 'poof' they transform into a horse.  She turns to you, with a grin." & DDUtils.RNRN &
                                                             """Hang tight while I get the carriage, ok?""", AddressOf playerPaid3)
    End Sub
    Sub playerPaid3()
        FaeQueen.spawnStairs(Game.currFloor)
        Game.player1.pos = New Point(52, 14)
        Game.drawBoard()

        TextEvent.push("A few minutes pass..." & DDUtils.RNRN &
                       "Right as the newly transformed equine starts to wander off, a sharp tug on their reins pulls both of your gazes back to a hooded figure stepping out from the brush and dragging a carriage." & DDUtils.RNRN &
                       "The mysterious stranger chuckles in the familiar voice of the faerie;" & DDUtils.RNRN &
                       """Let's get a move on, yeah?""" & DDUtils.RNRN &
                       "You spend the short ride seated next to the fae, politely refusing all of her requests to eat suspicious foodstuffs and recite eldritch incantations." & DDUtils.RNRN &
                       "As you arrive at a hidden staircase, the fae helps you down from the carriage to the forest floor.", AddressOf playerPaid4)
    End Sub
    Sub playerPaid4()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(62), """Take it easy, ya hear?"" the fae says, with a laugh as she yanks the reins of her steed back towards the woods." & DDUtils.RNRN &
                                                             """Thanks for the coin, and feel free to come back any time!""")

        Game.player1.ongoingQuests.getAt("Fae Woods Q1B - The Easy Way").completeEntireQuest()
    End Sub

    Sub noPassage()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(50), """Fair enough.  But hey, keep an eye out, ok?  These woods aren't exactly friendly territory for you folks, if you catch my drift...""" & DDUtils.RNRN &
                          "The two journey off into the twinkling mist.")

        completeEntireQuest()
        FaeQueen.spawn(Game.currFloor)
    End Sub

    '| - STORY PROGRESSION - |
    Private Sub questTransition()
        TextEvent.push("You hear two loud strangers coming up behind you.  A rather annoyed-looking faerie leads a human in fancy clothes, and you can just catch the tail end of their conversation as they approach...", AddressOf faeIntroduction)
    End Sub
    Private Sub faeIntroduction()
        Dim refP = "guy"

        If Game.player1.sex = "Female" Then
            refP = "gal"
            passangerBool = True
        ElseIf Game.player1.sex = "Male" Then
            refP = "guy"
        Else
            refP = "person"
        End If

        Game.player1.perks(perk.meetfae1) = 1

        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(49), "...for the last time, I don't know what a boat- Oh!" & DDUtils.RNRN & "Hey, what's up, other big " & refP & "?  Are you by chance looking for passage to the next floor?" & DDUtils.RNRN &
                          "The fare's only 1000 gold ~♪", AddressOf askForPassage)
    End Sub

    Public Sub passengerHorseTF2()
        Objective.showNPC(If(passangerBool, ShopNPC.gbl_img.atrs(0).getAt(111), ShopNPC.gbl_img.atrs(0).getAt(112)), """Well, I would think that this wandering interloper perchance might be..."" the human starts, before the fae giggles with glee." & DDUtils.RNRN &
                                                                                                                   """Outstanding, a volunteer!  Ohh, you have no idea how much I've wanted to do this.  Finally, peace and quiet-"" she says, charging a tiny ball of arcane energy...", AddressOf passengerHorseTF2p2)
    End Sub
    Public Sub passengerHorseTF2p2()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(113), """...courtesy of a muzzle.""" & DDUtils.RNRN &
                                                             "Her spell hits the other person in the chest, and with an audible 'poof' they transform into a horse.  She turns to you, with a grin." & DDUtils.RNRN &
                                                             """Now for you, free rider.  If I'm gonna give you a free ride, you're gonna get me some clout as a passenger, ok?""" & DDUtils.RNRN &
                                                             "Cackling wildly, the fae charges another hex.  She casts it at you, and with a soft squeak you fall to the ground as an unmoving inflatable." & DDUtils.RNRN &
                                                             """Hang tight while I get the carriage, ok?""", AddressOf passengerHorseTF2p3)
        BUDollTF.faeriePrincessTF()
    End Sub
    Public Sub passengerHorseTF2p3()
        FaeQueen.spawnStairs(Game.currFloor)
        Game.player1.pos = New Point(52, 14)
        Game.drawBoard()

        TextEvent.push("A few minutes pass..." & DDUtils.RNRN &
                       "Right as your equine companion starts to wander off, a sharp tug on their reins pulls both of your gazes back to a hooded figure stepping out from the brush and dragging a carriage." & DDUtils.RNRN &
                       "The mysterious stranger chuckles in the familiar voice of the faerie;" & DDUtils.RNRN &
                       """Let's get a move on, yeah?""" & DDUtils.RNRN &
                       "You spend the short ride proudly displayed in the front seat, the leer of many invisible eyes following you the entire way.  Fortunately your embarrassment is hidden by your synthetic face, and you find yourself almost grateful for its mask as a spell strikes you from beyond the treeline." & DDUtils.RNRN &
                       "As you arrive at a hidden staircase, you are simply tossed from the carriage onto the forest floor.", AddressOf passengerHorseTF2p4)

        Game.player1.prt.setIAInd(pInd.rearhair, 39, True, True)
        Game.player1.prt.setIAInd(pInd.midhair, 13, True, True)
        If Game.player1.inv.getCountAt(RegalGownF.ITEM_NAME) > 1 Then Game.player1.inv.add(RegalGownF.ITEM_NAME, -1)
        If Game.player1.inv.getCountAt(RegalLingerieF.ITEM_NAME) < 1 Then Game.player1.inv.add(RegalLingerieF.ITEM_NAME, 1)
        EquipmentDialogBackend.armorChange(Game.player1, RegalLingerieF.ITEM_NAME)
        Game.player1.be()
        Game.player1.drawPort()
    End Sub
    Public Sub passengerHorseTF2p4()
        Game.player1.revertToPState()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(62), """Take it easy, your 'highness'..."" the fae says, with a laugh.  You find yourself able to move again!" & DDUtils.RNRN &
                                                             """And, uh, maybe stay out of the woods going forward.""")

        Game.player1.ongoingQuests.getAt("Fae Woods Q1B - The Easy Way").completeEntireQuest()
    End Sub
End Class

Friend Class FaeWoodsQ1BS1
    Inherits Objective

    Sub New()
        MyBase.New("Talk with the faerie about passage.")
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