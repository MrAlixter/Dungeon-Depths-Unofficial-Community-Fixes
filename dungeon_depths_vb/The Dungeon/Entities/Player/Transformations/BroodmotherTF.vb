Public NotInheritable Class BroodmotherTF
    Inherits Transformation
    Dim hc As Color = Color.FromArgb(255, 236, 196, 87)
    Dim sc As Color = Color.FromArgb(255, 213, 145, 113)
    Sub New()
        MyBase.New(5, 15, 2.0, True)
    End Sub
    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        tfName = "BroodmotherTF"
        MyBase.updateDuringCombat = False
        Game.player1.perks(perk.coscale) = 0
        nextStep = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        MyBase.updateDuringCombat = False
        tfName = "BroodmotherTF"
        nextStep = getNextStep(cs)
    End Sub

    Sub step1()
        Dim p As Player = Game.player1
        p.changeHairColor(Game.cShift(p.prt.haircolor, hc, 40))
        p.changeSkinColor(Game.cShift(p.prt.skincolor, sc, 40))

        If p.breastSize = -1 Then p.breastSize = 0
        If p.breastSize > 3 Then p.bs()
        If Not p.prt.haircolor.Equals(hc) Or Not p.prt.skincolor.Equals(sc) Then currStep -= 1
    End Sub
    Sub step2()
        Dim p As Player = Game.player1

        If Not p.prt.haircolor.Equals(hc) Or Not p.prt.skincolor.Equals(sc) Then
            currStep = 0
            Exit Sub
        End If

        Dim out = "Catching a glimpse of your reflection in a puddle, you nearly do a double take.  As you take a closer look, you notice that you're hairstyle seems to have completely have changed.  "
        If p.sState.getSkinColor.R > sc.R Then out += "In addition, you seem to have developed a bit of a tan!  "
        If p.sState.getSkinColor.R < sc.R Then out += "In addition, your skin seems have become a little bit lighter!  "
        p.prt.setIAInd(pInd.rearhair, 11, True, True)
        p.prt.setIAInd(pInd.midhair, 32, True, True)
        p.prt.setIAInd(pInd.fronthair, 31, True, True)

        If p.sex.Equals("Male") Then
            p.MtF()
            out += "It seems that you've missed more of a transformation than you thought, and a quick inspection shows that you now have a pussy!"
        End If

        out += vbCrLf & vbCrLf & "Slightly concerned, you set back out while musing on your changes, which hopefully won't go any further..."
        If p.breastSize <> 2 Then p.breastSize = 2

        Game.pushLblEvent(out)
    End Sub
    Sub step3()
        Dim p As Player = Game.player1
        p.prt.setIAInd(pInd.mouth, 7, True, True)
        p.prt.setIAInd(pInd.eyes, 40, True, True)

        Game.pushLblEvent("While it's been subtle, you can tell that your vision is getting sharper.  As you watch an ant across the dungeon crawl up the wall, you grin to yourself..." & vbCrLf & vbCrLf & "Soon, there won't be anything that can escape your gaze.")
    End Sub
    Sub step4()
        Dim p As Player = Game.player1
        p.prt.setIAInd(pInd.wings, 5, True, False)
        p.prt.setIAInd(pInd.horns, 4, True, False)
        p.changeHairColor(hc)
        p.changeSkinColor(sc)
        Game.pushLblEvent("As you walk around, you become increasingly aware of a pressure on your head and back.  A quick inspection reveals that you now have a pair of leathery wings, and a set of wicked looking black horns!")
    End Sub
    Sub step5p1()
        Dim p As Player = Game.player1
        p.pForm = p.forms("Half-Dragoness")
        p.drawPort()

        Game.pushLblEvent("While your senses have been steadily becoming more precise, you can't help but feel that you're getting less done.  It's almost as though some distraction is clouding your judgment, and as you catch the echo of a dragon's wingbeat from far off in the distance you wonder if maybe you should track it down for a good fucking to clear your head..." & vbCrLf & vbCrLf & "You are now a half broodmother!", AddressOf step5p2)
    End Sub
    Sub step5p2()
        Dim p As Player = Game.player1
        p.pForm = p.forms("Half-Broodmother")
        Game.pushLblEvent("*The next day...*" & vbCrLf & vbCrLf & "You may have set off to find the dragon on somewhat of a whim, but the mere thought of being pinned down and bred by it has fanned a burning desire within you.  Blushing under your scales, you stagger forward, knees weak with anticipation.  While a small part of your psyche is screaming that you need to focus up, you practically tear off your clothes to get at your sex.  You collapse to the ground, panting as you desperately finger your pussy.  As you edge closer and closer to climaxing, you let out a gutteral roar, thrusting your wings out and spitting out a jet of red-hot flame.  As you sprawl out, scales covering every inch of your once fleshy hide, you giggle with an almost schoolgirl-like excitement.  That dragon may have gotten away this time, but next time you'll get him for sure!" & vbCrLf & vbCrLf & "You are now a broodmother!", AddressOf step5p3)
        p.drawPort()
    End Sub
    Sub step5p3()
        Dim p As Player = Game.player1
        p.pForm = p.forms("Broodmother")
        p.drawPort()
    End Sub

    Sub resist()
        Game.pushLblCombatEvent("You are able to resist the curse, but you can feel your resolve wavering...")
        Game.player1.will -= 1
    End Sub
    Public Overrides Sub stopTF()
        MyBase.stopTF()
        Game.player1.perks(perk.coscale) = -1
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        If Game.player1.perks(perk.coscale) = -1 Then
            Return AddressOf stopTF
        End If
        Select Case stage
            Case 0
                Return AddressOf step1
            Case 1
                Return AddressOf step2
            Case 2
                Return AddressOf step3
            Case 3
                Return AddressOf step4
            Case 4
                Return AddressOf step5p1
            Case Else
                Return AddressOf stopTF
        End Select
    End Function
    Public Overrides Sub setWaitTime(stage As Integer)
        turnsTilNextStep = 10
        turnsTilNextStep += generatWILResistance()
    End Sub
End Class
