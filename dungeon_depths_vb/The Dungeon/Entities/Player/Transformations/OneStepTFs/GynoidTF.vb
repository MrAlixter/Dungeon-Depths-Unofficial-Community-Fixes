Public NotInheritable Class GynoidTF
    Inherits OneStepTF

    Private Const TF_IND As tfind = tfind.gynoid

    Sub New()
        MyBase.New()
        tf_name = TF_IND
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tf_name = TF_IND
        next_step = getNextStep(cs)
    End Sub

    Public Shared Sub tf(ByRef p As Player)
        'transformation
        If p.sex.Equals("Male") Then
            p.MtF()
        End If

        p.changeForm("Gynoid")

        p.breastSize = 2 + Int(Rnd() * 2)

        p.prt.setIAInd(pInd.rearhair, 2, True, False)
        p.prt.setIAInd(pInd.face, 0, True, True)
        p.prt.setIAInd(pInd.midhair, 2, True, False)
        p.prt.setIAInd(pInd.ears, 9, True, True)
        p.prt.setIAInd(pInd.mouth, 4, True, False)
        p.prt.setIAInd(pInd.eyes, 25, True, True)
        p.prt.setIAInd(pInd.facemark, 0, True, False)

        If p.inv.getCountAt("Cyber_Visor_(P)") < 1 Then p.inv.add("Cyber_Visor_(P)", 1)
        EquipmentDialogBackend.glassesChange(p, "Cyber_Visor_(P)")


        p.setName(p.name.Substring(0, 1) & "-1" & Int(Rnd() * 999))
        p.inv.add("Gynoid_Uniform", 1)
        EquipmentDialogBackend.armorChange(p, "Gynoid_Uniform")

        p.perks(perk.slutcurse) = 1
    End Sub
    Public Overrides Sub step1()
        Dim p As Player = Game.player1
        Dim out = ""

        'transformation
        tf(p)

        'transformation description push
        out += "..." & DDUtils.RNRN &
            "Your system seems to have been rebooted.  As you open your robotic eyes, you triple check your system logs to make sure everything starts properly." & DDUtils.RNRN &
            "[sys:] Recalling nanobots---------------COMPLETE!" & vbCrLf &
            "[sys:] Releasing limb restraints--------COMPLETE!" & vbCrLf &
            "[sys/body:] Enabling motion control-----COMPLETE!" & vbCrLf &
            "[sys/body:] Enabling subdermal sensors--COMPLETE!" & DDUtils.RNRN &
            "...as the list goes on, you take in your newly activated senses.  Your skin feels far more sensitive than you remember, even the fabric of your clothes causing a fair amount of arousal.  Looking down further, you notice that your body is different...than...hmm.  You aren't sure what ""differences"" you're noticing.  Adding a re-calibration of your body to the boot seqence, you prep a logfile to..." & DDUtils.RNRN &
            "[sys/mind:] Enabling mental dampener----COMPLETE!" & DDUtils.RNRN &
            "...what were you doing again?  You giggle to yourself, you can be so airheaded sometimes..." & DDUtils.RNRN &
            "[sys/mind:] Enabling libido-------------COMPLETE!" & DDUtils.RNRN &
            "...mmmm...maybe you should try to find someone to help you out of this uniform...it's making you so horny..."
        TextEvent.push(out, AddressOf pt2)
        p.lust = 100
        p.drawPort()
    End Sub
    Sub pt2()
        Dim out = "[sys/mind:] Dialing libido to 1000%-----COMPLETE!" & vbCrLf &
            "[sys/mind:] Downloading sex libraries---COMPLETE!" & DDUtils.RNRN &
            "...your eyes widen and you moan slightly.  Your pussy feels like you have a vibrator in it even though you're empty, and in seconds you are like totally gonna cum!  Surprisingly, though, you just keep on getting hornier and hornier, far past whatever you've, like, felt before." & DDUtils.RNRN &
            "[sys:] Completing conversion------------COMPLETE!" & vbCrLf &
            "[sys:] Assigning owner------------------FAILED!" & DDUtils.RNRN &
            "The hatch suddenly flies open and the waves of pleasure reach their climax.  Basking in the pod, you realize that the mental dampener seems to have malfunctioned during your orgasm.  You realize that the system procedure that governs your owner assignment failed, and this leaves you a sexbot without a master.  Without anyone else calling the shots, you might actually be able to turn this new form to your..." & DDUtils.RNRN &
            "[sys/mind:] Re-enabling mental dampener-COMPLETE!" & DDUtils.RNRN &
            "... uh oh.  You giggle to your self again.  If the only time you can be, like, totally smart is right after sex, then you're like totally gonna have to bang everything in this dungeon!"
        TextEvent.push(out)
        Game.player1.lust = 0
        Game.player1.drawPort()
    End Sub
End Class
