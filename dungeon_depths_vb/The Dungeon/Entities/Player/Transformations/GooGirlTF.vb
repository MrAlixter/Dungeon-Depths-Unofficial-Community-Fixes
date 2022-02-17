Public NotInheritable Class GooGirlTF
    Inherits Transformation

    Private Const TF_IND As tfind = tfind.googirl

    Sub New(Optional cs As Integer = 2)
        MyBase.New(1, 0, 0, False)
        tf_name = TF_IND
        curr_step = cs
        next_step = getNextStep(cs)
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tf_name = TF_IND
        next_step = getNextStep(cs)
    End Sub

    Shared Sub step2()
        Dim p As Player = Game.player1

        p.prt.setIAInd(pInd.rearhair, 12, True, True)
        p.prt.setIAInd(pInd.midhair, 21, True, True)
        p.prt.setIAInd(pInd.fronthair, 3, True, False)
        p.prt.haircolor = Color.FromArgb(180, 255, 120, 255)
        p.drawPort()
        p.perks(perk.vsslimehair) = 0
        VialOfslimetf.pushLblEventWithoutLoss("The teal slime has taken on a pink hue now, and your hair has grown out a bit... Your hair is now made of a pink slime!")

        If Game.player1.perks(perk.googirltf) > -1 Then Game.player1.perks(perk.googirltf) += 1
    End Sub
    Shared Sub step3()
        Dim p As Player = Game.player1

        p.prt.skincolor = Color.FromArgb(230, 255, 102, 179)
        p.changeForm("Half-Slime")
        VialOfslimetf.pushLblEventWithoutLoss("At first it seems like the slime your skin has slowly been soaking in seems to have dyed it, but as you inspect your hand and notice that you can almost see through it completely, you realize that its become more than just a different color...  You are now a half-slime!")
        p.drawPort()
        If Game.player1.perks(perk.googirltf) > -1 Then Game.player1.perks(perk.googirltf) += 1
    End Sub
    Shared Sub step4()
        Dim p As Player = Game.player1

        p.changeForm("Goo Girl")

        If p.sex.Equals("Male") Then
            p.MtF()
        End If

        EquipmentDialogBackend.armorChange(p, "Naked")

        p.breastSize = 4

        p.prt.setIAInd(pInd.ears, 5, True, True)
        p.prt.setIAInd(pInd.mouth, 18, True, True)
        p.prt.setIAInd(pInd.eyes, 35, True, True)
        p.prt.setIAInd(pInd.eyebrows, 0, True, False)
        p.prt.setIAInd(pInd.cloak, 0, True, False)
        p.prt.setIAInd(pInd.hat, 0, True, False)

        p.prt.setIAInd(pInd.rearhair, 27, True, True)
        p.prt.setIAInd(pInd.midhair, 30, True, True)
        p.prt.setIAInd(pInd.fronthair, 28, True, True)
        Dim athe = "a"
        If p.health <= 0 Then athe = "the"
        VialOfslimetf.pushLblEventWithoutLoss("Nearly as soon as you make contact with the slime, a reaction begins and you start to melt.  Suprisingly, this doesn't really hurt so much as just feel weird, and you figure that with how much of your body was gelatinous this must have been just enough to finish you off.  While you are reflecting on your current state, " & athe & " Goo Girl glides toward you and giggles. " & DDUtils.RNRN &
                                """Here, let me help you out!  Reforming can be kinda hard, so I'll just hop in and do it for you.""" & DDUtils.RNRN &
                                "Before you can protest, she dives into your body and the two of you merge into a single puddle.  You are powerless to do anything but watch as she raises the two of you back up into a feminine humanoid body.  Once upright, you are able to resist slightly, though not enough to stop her from swelling your breasts to a massive size.  Noticing your resistance, she grabs the nucleus that contains your mind with your shared body, and smushes it into her own.  Suddenly, you can, like, totally control your hot body again!  You are now a goo girl. (You will restore to this form)")

        p.prt.skincolor = Color.FromArgb(200, p.prt.skincolor.R, p.prt.skincolor.G, p.prt.skincolor.B)
        p.drawPort()

        p.sState.save(p)
        p.savePState()

        p.health = 1
        If Game.player1.perks(perk.googirltf) > -1 Then Game.player1.perks(perk.googirltf) = -1
    End Sub


    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As Player = Game.player1

        Select Case curr_step
            Case 1
                Return AddressOf VialOfslimetf.step1
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
