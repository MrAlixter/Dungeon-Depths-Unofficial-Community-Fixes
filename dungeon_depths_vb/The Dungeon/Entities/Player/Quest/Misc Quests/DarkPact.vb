Public Class DarkPact
    Inherits Quest

    Sub New()
        MyBase.New("Dark Pact")

        quest_index = qInd.darkPact

        objectives.Add(New DarkPactStep1A)
        objectives.Add(New DarkPactStep2)
        objectives.Add(New DarkPactStep3)
    End Sub

    Public Overrides Sub init()
        MyBase.init()

        Select Case Game.player1.perks(perk.canmeetcyn)
            Case 2
                Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(76), """Hey.  Name's Cynn." & DDUtils.RNRN &
                                                                     "Couldn't help but notice a new demonic face roaming about, and as it happens I'm recruiting underlings for one hell of a scheme.  Maybe we can help each other out here?" & DDUtils.RNRN &
                                                                     "You seem skilled enough, but that doesn't change the fact that I haven't seen much out of you yet.  If you want in, I'm gonna need you to prove that you can hold your own weight.  Y'know those succubus princesses?  How about you take out- uhh, let's say... four- yeah, four of them." & DDUtils.RNRN &
                                                                     "I'll get back in touch when you're finished.  I- ah, might be shapeshifted then... so... just keep an eye out.""" & DDUtils.RNRN &
                                                                     "Quest ""Dark Pact"" acquired!")
                objectives.Clear()
                objectives.Add(New DarkPactStep1B)
            Case 3
                Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(76), """Hey.  Name's Cynn." & DDUtils.RNRN &
                                                                     "Couldn't help but notice that you're halfway through one of the demon god's curses, and as it happens that might come in handy for one hell of a scheme I've been cooking up.  Maybe we can help each other out here?" & DDUtils.RNRN &
                                                                     "That curse'd make you a powerful asset, but we're gonna need to get that transformation finished before it takes... well, a downturn.  Fortunately, I've got a trick of my own that'll take care of that for you.  If you want in, that is...""" & DDUtils.PAKTC, AddressOf init2C)
                objectives.Clear()
                objectives.Add(New DarkPactStep1C)
            Case Else
                Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(76), """Hey.  Name's Cynn." & DDUtils.RNRN &
                                                                     "Couldn't help but notice that you're trying out the demonic form, and as it happens I'm recruiting underlings for one hell of a scheme.  Maybe we can help each other out here?" & DDUtils.RNRN &
                                                                     "You seem skilled enough, but it doesn't look like those horns are permenant; if you catch my drift.  Fortunately, that's pretty easy to correct, and I'd be happy to help you out on that front in exchange for your loyalty.  If you want in, start by- uhh- taking down... three... yeah, three succubus princesses." & DDUtils.RNRN &
                                                                     "I'll get back in touch when you're finished.  I- ah, might be shapeshifted then... so... just keep an eye out.""" & DDUtils.RNRN &
                                                                     "Quest ""Dark Pact"" acquired!")
        End Select


        Game.player1.perks(perk.cynnsq1ct1) = 0
    End Sub

    Private Sub init2C()
        TextEvent.pushYesNo("Accept Cynn's Help?", AddressOf acceptCynnsHelp, AddressOf refuseCynnsHelp)
    End Sub
    Private Sub acceptCynnsHelp()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(76), """Good to hear.  But, before this goes any further, I'm gonna need you to prove that you can hold your own weight." & DDUtils.RNRN &
                                                             "Y'know those succubus princesses?  How about you take out- uhh, let's say... four- yeah, four of them." & DDUtils.RNRN &
                                                             "I'll get back in touch when you're finished.  I- ah, might be shapeshifted then... so... just keep an eye out.""" & DDUtils.RNRN &
                                                             "Quest ""Dark Pact"" acquired!")
    End Sub
    Private Sub refuseCynnsHelp()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(150), """Fair enough, I guess..." & DDUtils.RNRN &
                                                              "...but I can't just let you wander around with that sort of potential on ya.  So... if you aren't gonna side with me...""" & DDUtils.RNRN &
                                                              "Cynn traces a pattern in the air with her hands, before lazily flicking a spell in your direction." & DDUtils.RNRN &
                                                              "A glowing mark appears on your abdomen, and you can feel a warm haze clouding up your mind." & DDUtils.RNRN &
                                                              """...I can find another use for you.""" & DDUtils.RNRN &
                                                              "Cynn afflicts you with a cursemark!")

        Game.player1.inv.add(CynnsBimboMark.ITEM_NAME, 1)
        EquipmentDialogBackend.equipAcce(Game.player1, CynnsBimboMark.ITEM_NAME, False)

        Game.player1.drawPort()

        completeEntireQuest()
    End Sub

    Public Overrides Function canGet() As Boolean
        Return Not getActive() And Game.player1.level > 2 And Not getComplete() And Game.player1.perks(perk.canmeetcyn) > 0 And ((Int(Rnd() * 3) = 0) Or Settings.active(setting.norng))
    End Function
End Class

Friend Class DarkPactStep1A
    Inherits Objective

    Sub New()
        MyBase.New("Defeat 3 Succubus Princesses.")
    End Sub

    Public Overrides Sub complete()
        showNPC(ShopNPC.gbl_img.atrs(0).getAt(75), """Ha, awesome!  I didn't think you had it in you, but that makes " & Game.player1.perks(perk.cynnsq1ct1) & " less snooty royals to get in my way.  I'd say I'm impressed, buuuuut they'll be replaced in no time at all." & DDUtils.RNRN &
                                                   "Still though, that's more than enough for me to see you won't get picked off easy.  So, let's get you turned into a succubus then, right?" & DDUtils.RNRN &
                                                   "Next step is tracking down one of those dark crystals that are floating around...  Yeah, the ones the legions of thralls are all after.  Think you're up to it?""" & DDUtils.RNRN &
                                                   "+3 Chilling_Potion" & vbCrLf & "+1000 XP")

        Game.player1.perks(perk.cynnsq1ct1) = -1

        Game.player1.addXP(1000)

        Game.player1.inv.add("Chilling_Potion", 3)

        MyBase.complete()
    End Sub

    Public Overrides Function getDesc() As String
        Return description & "  [" & Game.player1.perks(perk.cynnsq1ct1) & "/3]"
    End Function

    Public Overrides Function isComplete() As Boolean
        Return Game.player1.perks(perk.cynnsq1ct1) >= 3
    End Function
End Class
Friend Class DarkPactStep1B
    Inherits Objective

    Sub New()
        MyBase.New("Defeat 3 Succubus Princesses.")
    End Sub

    Public Overrides Sub complete()
        showNPC(ShopNPC.gbl_img.atrs(0).getAt(75), """Ha, awesome!  I didn't think you had it in you, but that makes " & Game.player1.perks(perk.cynnsq1ct1) & " less snooty royals to get in my way.  I'd say I'm impressed, buuuuut they'll be replaced in no time at all." & DDUtils.RNRN &
                                                   "Still though, that's more than enough for me to see you won't get picked off easy.  Hmm... but what to do now..." & DDUtils.RNRN &
                                                   "Eh, tell you what.  I'm gonna think it over and get back to you with a real task.  In the meantime, how'd you like to learn one of my favorite tricks?""" & DDUtils.RNRN &
                                                   "+3 Chilling_Potion" & vbCrLf & "+1000 XP")

        Game.player1.perks(perk.cynnsq1ct1) = -1

        Game.player1.addXP(1000)

        Game.player1.inv.add("Chilling_Potion", 3)
        DarkPactTF.learnCynnsDisguise(Game.player1)
        MyBase.complete()
    End Sub

    Public Overrides Function getDesc() As String
        Return description & "  [" & Game.player1.perks(perk.cynnsq1ct1) & "/3]"
    End Function

    Public Overrides Function isComplete() As Boolean
        Return Game.player1.perks(perk.cynnsq1ct1) >= 3
    End Function
End Class
Friend Class DarkPactStep1C
    Inherits Objective

    Sub New()
        MyBase.New("Defeat 3 Succubus Princesses.")
    End Sub

    Public Overrides Sub complete()
        showNPC(ShopNPC.gbl_img.atrs(0).getAt(75), """Ha, awesome!  I didn't think you had it in you, but that makes " & Game.player1.perks(perk.cynnsq1ct1) & " less snooty royals to get in my way.  I'd say I'm impressed, buuuuut they'll be replaced in no time at all." & DDUtils.RNRN &
                                                   "Still though, that's more than enough for me to see you won't get picked off easy.  Alright, let's get that loose end wrapped up.""" & DDUtils.RNRN &
                                                   "Cynn waves her hand and you turn from a Demon into a Daemon." & DDUtils.RNRN &
                                                   "+3 Chilling_Potion" & vbCrLf & "+1000 XP" & vbCrLf & "You are now a Daemon." & DDUtils.TODO)

        Game.player1.perks(perk.cynnsq1ct1) = -1

        Game.player1.addXP(1000)

        Game.player1.inv.add("Chilling_Potion", 3)
        Game.player1.changeForm("Daemon")
        If Game.player1.prt.iArrInd(pInd.eyes).Item2 Then
            Game.player1.prt.setIAInd(pInd.eyes, 69, True, True)
        Else
            Game.player1.prt.setIAInd(pInd.eyes, 20, False, True)
        End If
        DarkPactTF.learnCynnsDisguise(Game.player1)
        Game.player1.drawPort()
        MyBase.complete()
    End Sub

    Public Overrides Function getDesc() As String
        Return description & "  [" & Game.player1.perks(perk.cynnsq1ct1) & "/3]"
    End Function

    Public Overrides Function isComplete() As Boolean
        Return Game.player1.perks(perk.cynnsq1ct1) >= 3
    End Function
End Class
Friend Class DarkPactStep2
    Inherits Objective

    Sub New()
        MyBase.New("Find one of the dark crystals sought by the enthralled.")
    End Sub

    Public Overrides Sub complete()
        Game.picNPC.BackgroundImage = ShopNPC.gbl_img.atrs(0).getAt(77)
        Game.picNPC.Visible = True

        TextEvent.pushNPCDialog("Yep, that'd be one of the right ones!  Doesn't look like this one's been activated yet, so I'll get that going...", AddressOf completeDialogStep2)

        Game.player1.addXP(1000)

        MyBase.complete()
    End Sub

    Private Sub completeDialogStep2()
        Game.picNPC.Visible = False

        TextEvent.push("Cynn places a hand on the stone, and is quickly engulfed in a crackling red aura.  As the crystal begins glowing with sinister light, Cynn reverts to her demonic form with a burst of black flame.  She glances over at you, and gestures for you to come over." & DDUtils.RNRN &
                       "She grabs your hand, and with a surge of energy and a blinding flash the crystal returns to a dormant state." & DDUtils.RNRN &
                       "Your abdomen is now marked with a glowing red glyph!", AddressOf completeDialogStep3)

        If Game.player1.inv.getCountAt("Cynn's_Mark") < 1 Then Game.player1.inv.add("Cynn's_Mark", 1)
        Equipment.accChange(Game.player1, "Cynn's_Mark")

        Game.player1.drawPort()
    End Sub

    Private Sub completeDialogStep3()
        showNPC(ShopNPC.gbl_img.atrs(0).getAt(76), "Alright, now all you gotta do is activate that bad boy by killing a bunch of stuff or getting real horny and you'll be a full demon." & DDUtils.RNRN &
                                                   "If you're getting cold feet, now's the last chance you have to back out because after this, you'll be on the dark side and it isn't exactly easy to cross back over...")

        Game.player1.perks(perk.cynnsq1ct2) = 0
    End Sub

    Public Overrides Function getDesc() As String
        Return description & "  [" & 0 & "/1]"
    End Function

    Public Overrides Function isComplete() As Boolean
        Return Not Game.last_tile Is Nothing AndAlso Game.last_tile.Item1.Equals("c")
    End Function
End Class
Friend Class DarkPactStep3
    Inherits Objective

    Sub New()
        MyBase.New("Activate Cynn's mark by either raising your lust or defeating 13 opponents.")
    End Sub

    Public Overrides Sub complete()
        Game.player1.ongoingTFs.reset()
        Game.player1.revertToPState()

        Dim dptf As DarkPactTF = New DarkPactTF
        dptf.step1()

        Game.player1.addXP(2000)
        Game.compDP = True

        MyBase.complete()
    End Sub

    Public Overrides Function getDesc() As String
        Return description & "  [" & Game.player1.lust & "/100 or " & Game.player1.perks(perk.cynnsq1ct2) & "/13]"
    End Function

    Public Overrides Function isComplete() As Boolean
        Return (Game.player1.lust >= 100) Or (Game.player1.perks(perk.cynnsq1ct2) >= 13)
    End Function
End Class



