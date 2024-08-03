Public NotInheritable Class SlimePaladinTF
    Inherits PolymorphTF

    Private Const TF_IND As tfind = tfind.slimepaladpolymorph

    Sub New()
        MyBase.New()
        tf_name = TF_IND
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        next_step = getNextStep(cs)
        tf_name = TF_IND
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        Dim p As Player = Game.player1
        turns_until_next_step = Int(Rnd() * 50) + Int(Rnd() * 50) + Int(Rnd() * p.getMaxMana) + Int(Rnd() * p.getWIL)
    End Sub

    Public Overrides Sub step1()
        Dim p As Player = Game.player1

        'unequips
        EquipmentDialogBackend.antiClothingCurse(p, False)

        'slime transformation
        p.changeForm("Slime")
        p.changeClass("Paladin")
        p.perks(perk.slimehair) = 1
        p.perks(perk.slimeguard) = 1

        p.prt.haircolor = Color.FromArgb(180, 5, 245, 198)
        p.prt.skincolor = Color.FromArgb(200, 0, 255, 255)

        p.prt.setIAInd(pInd.ears, 5, True, True)
        p.prt.setIAInd(pInd.eyes, 11, True, True)
        p.prt.setIAInd(pInd.eyebrows, 0, True, False)

        p.prt.setIAInd(pInd.cloak, 0, True, False)
        p.prt.setIAInd(pInd.hat, 0, True, False)

        If Not p.prt.sexBool Then
            p.idRouteFM()
        End If

        p.textColor = Color.FromArgb(255, 2, 249, 200)
    End Sub

    Public Overrides Function getTFText() As String
        Return "Your skin feels wetter than it did a minute ago.  As you look down, you see that your body is slowly disolving into a aquamarine fluid! You melt down into a puddle, and find that while it is challenging, you can somewhat manipulate your body.  After some experimentation, you find yourself in a rough aproximation of your original form."
    End Function
End Class
