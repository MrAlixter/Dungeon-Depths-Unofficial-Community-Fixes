Public NotInheritable Class MagSlutTF
    Inherits Transformation
    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        tfName = "Magical Slut"
        nextStep = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "Magical Slut"
        nextStep = getNextStep(cs)
    End Sub

    Sub step1()
        Dim p As player = game.player
        p.pClass = p.classes("Magical Girl​")
        Dim out = "Swinging your wand, you are engulfed in a rain of hearts. As the light around your body grows blinding and your clothes disolve into the aether, you become a increadibly busty young woman wearing next to nothing!  "
        If p.isUnwilling() Then
            out += "Scoffing, you tug at your outfit, unable to remove it.  You throw the wand across the dungeon, only for it to poof back into your hand seconds later.  Grumbling to yourself, you stomp your feet before setting back out, tugging down on your new skirt in a failing attempt to preserve some of your dignity."
        Else
            out += "Twirling, you giggle before striking a pose, making sure to press your big titties together.  If you were paying better attention, you might have noticed the almost sinister crimson aura binding the wand to your perfectly manicured hand, but, like, hey, why would you want to get rid of your cute new wand?"
        End If
        If p.sex = "Male" Then
            p.sex = "Female"
        End If
        p.prt.setIAInd(pInd.hat, Portrait.imgLib.atrs("Hat").getF.Count - 3, True, False)
        Game.pushLblEvent(out, AddressOf step2)


        p.TextColor = Game.lblEvent.ForeColor

        p.specialRoute()
        p.magicRoute()
    End Sub
    Sub step2()
        Game.lblEvent.Text = ""

        Dim p As Player = Game.player

        p.breastSize = 3
        p.prt.hBowInd = 3
        p.prt.haircolor = Color.FromArgb(255, 255, 250, 205)
        p.prt.setIAInd(pInd.rearhair, 10, True, True)
        p.prt.setIAInd(pInd.clothes, 12, True, True)
        p.prt.setIAInd(pInd.face, 0, True, False)
        p.prt.setIAInd(pInd.midhair, 10, True, True)
        p.prt.setIAInd(pInd.nose, 0, True, False)
        p.prt.setIAInd(pInd.mouth, 21, True, True)
        p.prt.setIAInd(pInd.eyes, 39, True, True)
        p.prt.setIAInd(pInd.eyebrows, 0, True, False)
        p.prt.setIAInd(pInd.cloak, 0, True, False)
        p.prt.setIAInd(pInd.fronthair, 30, True, True)
        p.prt.setIAInd(pInd.hat, 0, True, False)
        p.reverseBSRoute()
        p.magGState.save(p)
        p.magGState.initFlag = True
        If p.isUnwilling() Then p.pout()
        If Not p.knownSpells.Contains("Heartblast Starcannon") Then p.knownSpells.Add("Heartblast Starcannon")
        If p.inv.item(170).count < 1 Then p.inv.add(170, 1)

        p.pClass = p.classes("Magical Slut")
        Equipment.clothesChange("Magical_Slut_Outfit")
        p.canMoveFlag = True
        p.drawPort()
        stopTF()
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As Player = Game.player
        If p.pClass.name.Equals("Magical Girl​") Then
            Return AddressOf step2
        ElseIf p.pClass.name.Equals("Magical Slut") Then
            Return AddressOf stopTF
        Else
            Return AddressOf step1
        End If
    End Function
    Public Overrides Sub setWaitTime(stage As Integer)
        turnsTilNextStep = 0
    End Sub

    Public Shared Sub pushLblEventWithoutLoss(ByRef out As String)
        Dim revertText = Game.lblEvent.Text.Split(vbCrLf)(0)
        If Not revertText.Equals("") Then out = revertText & vbCrLf & vbCrLf & out
        Game.pushLblEvent(out)
    End Sub
End Class
