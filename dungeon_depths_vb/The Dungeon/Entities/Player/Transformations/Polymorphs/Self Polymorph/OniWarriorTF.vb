Public NotInheritable Class OniWarriorTF
    Inherits PolymorphTF

    Private Const TF_IND As tfind = tfind.oniwarrior
    Private neededMTF As Boolean = False

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

        '| -- Oni transformation -- |
        If p.breastSize > 2 Or (p.breastSize < 2 And p.breastSize > -1) Then p.breastSize = 2

        p.prt.haircolor = DemonTF.getDemonHairColor(p.prt.haircolor)
        p.prt.skincolor = Color.FromArgb(255, 214, 106, 106)
        p.changeForm("Oni")
        p.changeClass("Warrior")

        p.prt.setIAInd(pInd.horns, 16, True, False)

        '| -- Transformation Description -- |
        p.textColor = Color.MistyRose
        Game.player1.perks(perk.canmeetcyn) = 1
    End Sub

    Public Overrides Function getTFText() As String
        Dim out = "Flames engulfs you, as you flex your new muscles before your foe.  ""Are you ready..."" you ask with a toothy grin, ""...for a fight?"""

        Return out
    End Function
End Class
