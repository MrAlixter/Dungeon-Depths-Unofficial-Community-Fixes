Public NotInheritable Class GynoidTF
    Inherits Transformation
    Sub New()
        MyBase.New(1, 0, 0, False)
        tfName = "GynoidTF"
        nextStep = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "GynoidTF"
        nextStep = getNextStep(cs)
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        stopTF()
    End Sub


    Public Shared Sub tf(ByRef p As Player)
        'transformation
        If p.sex.Equals("Male") Then
            p.MtF()
        End If
        p.breastSize = 2 + Int(Rnd() * 2)

        p.prt.setIAInd(pInd.rearhair, 2, True, False)
        p.prt.setIAInd(pInd.face, 6, True, True)
        p.prt.setIAInd(pInd.midhair, 2, True, False)
        p.prt.setIAInd(pInd.ears, 9, True, True)
        p.prt.setIAInd(pInd.mouth, 4, True, False)
        p.prt.setIAInd(pInd.eyes, 25, True, True)
        p.prt.setIAInd(pInd.facemark, 0, True, False)
        p.prt.setIAInd(pInd.glasses, 6, True, True)

        p.pForm = p.forms("Gynoid")

        p.setName(p.name.Substring(0, 1) & "-1" & Int(Rnd() * 999))
        p.inv.add("Gynoid_Uniform", 1)
        Equipment.clothesChange("Gynoid_Uniform")

        p.perks("slutcurse") = 1
    End Sub
    Public Sub step1()
        Dim p As player = game.player
        Dim out = ""

        'transformation
        tf(p)

        'transformation description push
        out += "..." & vbCrLf &
            "Your system seems to have been rebooted.  As you open your robotic eyes, you triple check your system logs to make sure everything starts properly." & vbCrLf &
            "[sys:] Recalling nanobots---------------COMPLETE!" & vbCrLf &
            "[sys:] Releasing limb restraints--------COMPLETE!" & vbCrLf &
            "[sys/body:] Enabling motion control-----COMPLETE!" & vbCrLf &
            "[sys/body:] Enabling subdermal sensors--COMPLETE!" & vbCrLf &
            "...as the list goes on, you take in your newly activated senses.  Your skin feels far more sensitive than you remember, even the fabric of your clothes causing a fair amount of arousal.  Looking down further, you notice that your body is different...than...hmm.  You aren't sure what ""differences"" you're noticing.  Adding a re-calibration of your body to the boot seqence, you prep a logfile to..." & vbCrLf &
            "[sys/mind:] Enabling mental dampener----COMPLETE!" & vbCrLf &
            "...what were you doing again?  You giggle to yourself, you can be so airheaded sometimes..." & vbCrLf &
            "[sys/mind:] Enabling libido-------------COMPLETE!" & vbCrLf &
            "...mmmm...maybe you should try to find someone to help you out of this uniform...it's making you so horny..."
        Game.pushLblEvent(out, AddressOf pt2)
        p.lust = 100
        p.drawPort()
    End Sub
    Sub pt2()
        Dim out = "[sys/mind:] Dialing libido to 1000%-----COMPLETE!" & vbCrLf &
            "[sys/mind:] Downloading sex libraries---COMPLETE!" & vbCrLf &
            "...your eyes widen and you moan slightly.  Your pussy feels like you have a vibrator in it even though you're empty, and in seconds you are like totally gonna cum!  Surprisingly, though, you just keep on getting hornier and hornier, far past whatever you've, like, felt before." & vbCrLf &
            "[sys:] Completing conversion------------COMPLETE!" & vbCrLf &
            "[sys:] Assigning owner------------------FAILED!" & vbCrLf &
            "The hatch suddenly flies open and the waves of pleasure reach their climax.  Basking in the pod, you realize that the mental dampener seems to have malfunctioned during your orgasm.  You realize that the system procedure that governs your owner assignment failed, and this leaves you a sexbot without a master.  Without anyone else calling the shots, you might actually be able to turn this new form to your..." & vbCrLf &
            "[sys/mind:] Re-enabling mental dampener-COMPLETE!" & vbCrLf &
            "... uh oh.  You giggle to your self again.  If the only time you can be, like, totally smart is right after sex, then you're like totally gonna have to bang everything in this dungeon!"
        Game.pushLblEvent(out)
        Game.player.lust = 0
        Game.player.drawPort()
    End Sub
    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As player = game.player
        Select Case stage
            Case 0
                Return AddressOf step1
            Case Else
                Return AddressOf stopTF
        End Select
    End Function
End Class
