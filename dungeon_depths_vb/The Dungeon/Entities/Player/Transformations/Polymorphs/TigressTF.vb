Public Class TigressTF
    Inherits PolymorphTF
    Sub New()
        MyBase.New()
        tfName = "Tigress"
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        nextStep = getNextStep(cs)
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        Dim p As player = game.player
        turnsTilNextStep = Int(Rnd() * 50) + Int(Rnd() * 50) + Int(Rnd() * p.getmaxMana) + Int(Rnd() * p.getWIL)
    End Sub

    Public Overrides Sub step1()
        Dim p As player = game.player
        Dim out = ""

        'unequips
        Equipment.clothesChange("Naked")
        Equipment.weaponChange("Fists")

        'goddess transformation
        If p.sex = "Male" Then
            p.MtF()
            out += "Your body becomes daintier, and you are soon fully female.  "
        End If
        If p.prt.skincolor = Color.FromArgb(255, 255, 105, 180) Then p.prt.haircolor = Color.FromArgb(255, 155, 0, 0)
        If p.prt.skincolor = Color.FromArgb(200, 0, 255, 255) Then p.prt.haircolor = Color.FromArgb(180, 5, 245, 198)
        p.prt.setIAInd(1, 15, True, True)
        p.prt.setIAInd(2, 21, True, True)
        p.prt.setIAInd(4, 0, True, False)
        p.prt.setIAInd(5, 19, True, True)
        p.prt.setIAInd(6, 7, True, True)
        p.prt.setIAInd(7, 0, True, False)
        p.prt.setIAInd(8, 11, True, True)
        p.prt.setIAInd(9, 18, True, True)
        p.prt.setIAInd(10, 0, True, False)
        p.prt.setIAInd(13, 0, True, False)
        p.prt.setIAInd(15, 15, True, True)
        p.prt.setIAInd(16, 0, True, False)

        'transformation description push
        p.TextColor = Color.Orange
        out += "[Transformation decription pending]"
        
        Game.pushLblEvent(out)
    End Sub
End Class
