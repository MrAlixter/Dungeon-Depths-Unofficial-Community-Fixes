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
            Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(56), "")
        ElseIf Game.player1.gold >= 750 Then
            Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(53), """Ugh, looks like you're a little low on funds too..."" the fae grumbles, before her companion interrupts," & DDUtils.RNRN &
                              """Low on funds?  Me?  Hardly...  I already told you that I have more than enough to cover your miniscule fee, and that I will pay promptly as soon as-""" & DDUtils.RNRN &
                              """You know what?  Close enough.  If it means not dealing with this for the rest of the day,"" the faerie cuts back in...")
        Else
            Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(54), """Ugh, looks like you're low on funds too..."" the fae grumbles, before her companion interrupts," & DDUtils.RNRN &
                  """Low on funds?  Me?  Hardly...  I already told you that I have more than enough to cover your miniscule fee, and that I will pay promptly as soon as-""" & DDUtils.RNRN &
                  """Yeah, no, I'm not dealing with two of you freeloaders,"" the faerie cuts back in, ""Hmm, now which one one of you would be better at pulling a cart...""")
        End If
    End Sub
    Sub noPassage()
        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(50), """Fair enough.  But hey, keep an eye out, ok?  These woods aren't exactly friendly territory for you folks, if you catch my drift...""" & DDUtils.RNRN &
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

        If Game.player1.prt.sexBool Then
            refP = "gal"
            passangerBool = True
        End If

        Game.player1.perks(perk.meetfae1) = 1

        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(49), "...for the last time, I don't know what a boat- Oh!" & DDUtils.RNRN & "Hey, what's up, other big " & refP & "?  Are you by chance looking for passage to the next floor?" & DDUtils.RNRN &
                          "The fare's only 1000 gold ~♪", AddressOf askForPassage)
    End Sub
    Private Sub horseTF1()

    End Sub
    Public Sub horseTF2()
        Objective.showNPC(If(passangerBool, ShopNPC.npcLib.atrs(0).getAt(111), ShopNPC.npcLib.atrs(0).getAt(112)), """Well, I would think that this wandering interloper perchance might be..."" the human starts, before the fae giggles with glee." & DDUtils.RNRN &
                  """Outstanding, a volunteer!  " & DDUtils.capitalizeFirst(If(passangerBool, Polymorph.rndFName, Polymorph.rndMName)) & ", you're a horse now.""")
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