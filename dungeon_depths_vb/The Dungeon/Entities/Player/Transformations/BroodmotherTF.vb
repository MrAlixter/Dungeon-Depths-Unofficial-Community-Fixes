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
        Game.player.perks("cowbell") = 0
        nextStep = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        MyBase.updateDuringCombat = False
        tfName = "BroodmotherTF"
        nextStep = getNextStep(cs)
    End Sub

    Sub step1()
        Dim p As Player = Game.player
        p.changeHairColor(Game.cShift(p.prt.haircolor, hc, 40))
        p.changeSkinColor(Game.cShift(p.prt.skincolor, sc, 40))

        If p.breastSize = -1 Then p.breastSize = 0
        If p.breastSize > 3 Then p.bs()
        If Not p.prt.haircolor.Equals(hc) Or Not p.prt.skincolor.Equals(sc) Then currStep -= 1
    End Sub
    Sub step2()
        Dim p As Player = Game.player

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
        Dim p As Player = Game.player
        p.prt.setIAInd(pInd.mouth, 7, True, True)
        p.prt.setIAInd(pInd.eyes, 40, True, True)
    End Sub
    Sub step4()
        Dim p As Player = Game.player
        p.prt.wingInd = 5
        p.prt.hornInd = 4
        p.changeHairColor(hc)
        p.changeSkinColor(sc)
    End Sub
    Sub step5p1()
        Dim p As Player = Game.player
        p.pForm = p.forms("Half-Dragoness")
        p.drawPort()

        Game.pushLblEvent("You are now a half broodmother! (Work in progress)", AddressOf step5p2)
    End Sub
    Sub step5p2()
        Dim p As Player = Game.player
        p.pForm = p.forms("Half-Broodmother")
        Game.pushLblEvent("You are now a broodmother! (Work in progress)", AddressOf step5p3)
        p.drawPort()
    End Sub
    Sub step5p3()
        Dim p As Player = Game.player
        p.pForm = p.forms("Broodmother")
        p.drawPort()
    End Sub

    Sub resist()
        Game.pushLblCombatEvent("You are able to resist the curse, but you can feel your resolve wavering...")
        Game.player.will -= 1
    End Sub
    Public Overrides Sub stopTF()
        MyBase.stopTF()
        Game.player.perks("coscale") = -1
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        If Game.player.perks("coscale") = -1 Then
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
