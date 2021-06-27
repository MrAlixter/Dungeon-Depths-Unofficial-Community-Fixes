Public Class DarkPact
    Inherits Quest

    Sub New()
        MyBase.New("Dark Pact")

        qInd = qInds.darkPact

        objectives.Add(New DarkPactStep1)
        objectives.Add(New DarkPactStep2)
        objectives.Add(New DarkPactStep3)
    End Sub

    Public Overrides Sub init()
        MyBase.init()

        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(76), """Hey.  Name's Cynn.  Couldn't help but notice that you're trying out the demonic form, and I just so happen to be recruiting underlings for one hell of a scheme.  You seem to be decently skilled, but it doesn't look like those horns are permenant, if you catch my drift." & DDUtils.RNRN &
                                                            "Fortunately that's pretty easy to correct, and I'd be happy to help you out on that front in exchange for your loyalty." & DDUtils.RNRN &
                                                            "If you want in, start by, uhhh, taking down... three... succubus princesses.  Yeah, that'll work.  I'll get back in touch when you're finished, although I might be shapeshifted, so keep an eye out.""" & DDUtils.RNRN &
                                                            "Quest ""Dark Pact"" acquired!")

        Game.player1.perks(perk.cynnsq1ct1) = 0
    End Sub

    Public Overrides Function canGet() As Boolean
        Return Not getActive() And Game.player1.level > 2 And Not getComplete() And Game.player1.perks(perk.canmeetcyn) > 0 And ((Int(Rnd() * 3) = 0) Or Game.noRNG)
    End Function
End Class

Public Class DarkPactStep1
    Inherits Objective

    Sub New()
        MyBase.New("Defeat 3 Succubus Princesses.")
    End Sub

    Public Overrides Sub complete()
        showNPC(ShopNPC.npcLib.atrs(0).getAt(75), """Ha, awesome!  I didn't think you had it in you, but that makes " & Game.player1.perks(perk.cynnsq1ct1) &
                         " less snooty royals to get in my way.  I'd say I'm impressed, buuuuut they'll be replaced in no time at all." & DDUtils.RNRN &
                         "Still though, that's more than enough for me to see you won't get picked off easy. Your next step?  Track down one of those dark crystals floating around...""" & DDUtils.RNRN &
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

Public Class DarkPactStep2
    Inherits Objective

    Sub New()
        MyBase.New("Find one of the dark crystals sought by the enthralled.")
    End Sub

    Public Overrides Sub complete()
        Game.picNPC.BackgroundImage = ShopNPC.npcLib.atrs(0).getAt(77)
        Game.picNPC.Visible = True

        Game.pushNPCDialog("Alright, great, you found a crystal!  It doesn't look like this one's been activated yet, so I'll get that going...", AddressOf completeDialogStep2)

        Game.player1.addXP(1000)

        MyBase.complete()
    End Sub

    Private Sub completeDialogStep2()
        Game.picNPC.Visible = False

        Game.pushLblEvent("Cynn places a hand on the crystal, and she is quickly engulfed in a crackling red aura.  As the crystal begins glowing a sinister purple, Cynn bursts into a jet black flame and reverts to her demonic form.  She glances over at you, and gestures for you to come over." & DDUtils.RNRN &
                          "She grabs your hand, and with a surge of energy and a blinding flash the crystal returns to a dormant state." & DDUtils.RNRN &
                          "Your abdomen is now marked with a glowing red glyph!", AddressOf completeDialogStep3)

        If Game.player1.inv.getCountAt("Cynn's_Mark") < 1 Then Game.player1.inv.add("Cynn's_Mark", 1)
        Equipment.accChange(Game.player1, "Cynn's_Mark")

        Game.player1.drawPort()
    End Sub

    Private Sub completeDialogStep3()
        showNPC(ShopNPC.npcLib.atrs(0).getAt(76), "Alright, now all you gotta do is activate that bad boy by killing a bunch of stuff or getting real horny and you'll be a full demon.  If you're getting cold feet, now's the last chance you have to back out because after this, you'll be on the dark side and it isn't exactly easy to cross back over...")

        Game.player1.perks(perk.cynnsq1ct2) = 0
    End Sub

    Public Overrides Function getDesc() As String
        Return description & "  [" & 0 & "/1]"
    End Function

    Public Overrides Function isComplete() As Boolean
        Return Not Game.lastTile Is Nothing AndAlso Game.lastTile.Item1.Equals("c")
    End Function
End Class

Public Class DarkPactStep3
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

        MyBase.complete()
    End Sub

    Public Overrides Function getDesc() As String
        Return description & "  [" & Game.player1.lust & "/100 or " & Game.player1.perks(perk.cynnsq1ct2) & "/13]"
    End Function

    Public Overrides Function isComplete() As Boolean
        Return (Game.player1.lust >= 100) Or (Game.player1.perks(perk.cynnsq1ct2) >= 13)
    End Function
End Class



