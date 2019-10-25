Public Class GooGirlTF
    Inherits Transformation
    Sub New(Optional cs As Integer = 2)
        MyBase.New(1, 0, 0, False)
        tfName = "GooGirlTF"
        currStep = cs
        nextStep = getNextStep(cs)
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "GooGirlTF"
        nextStep = getNextStep(cs)
    End Sub

    Shared Sub step2()
        Dim p As Player = Game.player

        p.prt.setIAInd(1, 12, True, True)
        p.prt.setIAInd(5, 21, True, True)
        p.prt.setIAInd(15, 26, True, True)
        p.prt.haircolor = Color.FromArgb(180, 255, 120, 255)
        p.createP()
        p.perks("vsslimehair") = 0
        VialOfSlimeTF.pushLblEventWithoutLoss("The teal slime has taken on a pink hue now, and your hair has grown out a bit... Your hair is now made of a pink slime!")

        If Game.player.perks("googirltf") > -1 Then Game.player.perks("googirltf") += 1
    End Sub
    Shared Sub step3()
        Dim p As Player = Game.player

        p.prt.skincolor = Color.FromArgb(230, 255, 102, 179)
        p.pForm = p.forms("Half-Slime")
        VialOfSlimeTF.pushLblEventWithoutLoss("At first it seems like the slime your skin has slowly been soaking in seems to have dyed it, but as you inspect your hand and notice that you can almost see through it completely, you realize that its become more than just a different color...  You are now a half-slime!")
        p.createP()
        If Game.player.perks("googirltf") > -1 Then Game.player.perks("googirltf") += 1
    End Sub
    Shared Sub step4()
        Dim p As Player = Game.player

        p.pForm = p.forms("Goo Girl")

        If p.sex.Equals("Male") Then
            p.MtF()
        End If

        Equipment.clothesChange("Naked")

        p.breastSize = 4
        p.reverseBSRoute()

        p.prt.setIAInd(6, 5, True, True)
        p.prt.setIAInd(8, 18, True, True)
        p.prt.setIAInd(9, 35, True, True)
        p.prt.setIAInd(10, 0, True, False)
        p.prt.setIAInd(13, 0, True, False)
        p.prt.setIAInd(16, 0, True, False)

        p.prt.setIAInd(1, 27, True, True)
        p.prt.setIAInd(5, 30, True, True)
        p.prt.setIAInd(15, 28, True, True)
        Dim athe = "a"
        If p.health <= 0 Then athe = "the"
        VialOfSlimeTF.pushLblEventWithoutLoss("Nearly as soon as you make contact with the slime, a reaction begins and you start to melt.  Suprisingly, this doesn't really hurt so much as just feel weird, and you figure that with how much of your body was gelatinous this must have been just enough to finish you off.  While you are reflecting on your current state, " & athe & " Goo Girl glides toward you and giggles. " & vbCrLf & vbCrLf &
                                """Here, let me help you out!  Reforming can be kinda hard, so I'll just hop in and do it for you.""" & vbCrLf & vbCrLf &
                                "Before you can protest, she dives into your body and the two of you merge into a single puddle.  You are powerless to do anything but watch as she raises the two of you back up into a feminine humanoid body.  Once upright, you are able to resist slightly, though not enough to stop her from swelling your breasts to a massive size.  Noticing your resistance, she grabs the nucleus that contains your mind with your shared body, and smushes it into her own.  Suddenly, you can, like, totally control your hot body again!  You are now a goo girl. (You will restore to this form)")

        p.prt.skincolor = Color.FromArgb(200, p.prt.skincolor.R, p.prt.skincolor.G, p.prt.skincolor.B)
        p.createP()

        p.sState.save(p)
        If Transformation.canBeTFed(p) Then p.pState.save(p)

        p.health = 1
        If Game.player.perks("googirltf") > -1 Then Game.player.perks("googirltf") = -1
    End Sub


    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As Player = Game.player

        Select Case currStep
            Case 1
                Return AddressOf VialOfSlimeTF.step1
            Case 2
                Return AddressOf step2
            Case 3
                Return AddressOf step3
            Case 4
                Return AddressOf step4
            Case Else
                Return AddressOf stopTF
        End Select
    End Function

    Public Overrides Sub setWaitTime(stage As Integer)
        stopTF()
    End Sub
End Class
