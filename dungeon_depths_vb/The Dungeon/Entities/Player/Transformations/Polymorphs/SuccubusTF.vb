Public NotInheritable Class SuccubusTF
    Inherits PolymorphTF
    Sub New()
        MyBase.New()
        tfName = "SuccubusTF"
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        nextStep = getNextStep(cs)
        tfName = "SuccubusTF"
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        Dim p As player = Game.player1
        turnsTilNextStep = Int(Rnd() * 50) + Int(Rnd() * 50) + Int(Rnd() * p.getmaxMana) + Int(Rnd() * p.getWIL)
    End Sub

    Public Overrides Sub step1()
        Dim p As player = Game.player1
        Dim out = ""

        'unequips
        Equipment.clothesChange(p, "Succubus_Garb")
        Equipment.weaponChange(p, "Fists")

        'succubus transformation
        If p.sex = "Male" Then
            p.MtF()
            out += "Your body becomes daintier, and you are soon fully female.  "
        End If
        p.prt.haircolor = Color.FromArgb(255, 155, 0, 0)
        p.prt.skincolor = Color.FromArgb(255, 255, 105, 180)
        p.prt.setIAInd(pInd.rearhair, 9, True, True)
        If p.breastSize < 2 Then p.breastSize = 2
        p.prt.setIAInd(pInd.face, 0, True, False)
        p.prt.setIAInd(pInd.midhair, 9, True, True)
        p.prt.setIAInd(pInd.nose, 0, True, False)
        p.prt.setIAInd(pInd.eyes, 12, True, True)
        p.prt.setIAInd(pInd.eyebrows, 0, True, False)
        p.prt.setIAInd(pInd.cloak, 0, True, False)
        p.prt.setIAInd(pInd.fronthair, 13, True, True)
        p.prt.setIAInd(pInd.hat, 0, True, False)
        p.prt.setIAInd(pInd.wings, 2, True, False)
        p.prt.setIAInd(pInd.horns, 3, True, False)

        'transformation description push
        p.TextColor = Color.HotPink
        out += "As hellfire engulfs you, you ponder over what you should do to your opponent.  Maybe flay them, mabye just go for a quick clean decapitation, or maybe tie them up and use them as a fucktoy until you get bored?  ""Well,"" you tell them with a sinister grin, ""... whatever I decide on ..."" you do a pirouette, showing off your new body in all its glory ""... will certainly be more fun for me ..."" you lock eyes with your prey and bare your fangs in a vicious sneer ""... than for you."""

        Game.player1.perks(perk.canmeetcyn) = 1

        Game.pushLblEvent(out)
    End Sub
End Class
