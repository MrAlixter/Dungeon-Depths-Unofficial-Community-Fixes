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
        Dim p = Game.player
        turnsTilNextStep = Int(Rnd() * 50) + Int(Rnd() * 50) + Int(Rnd() * p.getmaxMana) + Int(Rnd() * p.getWillpower)
    End Sub

    Public Overrides Sub step1()
        Dim p = Game.player
        Dim out = ""

        'unequips
        Equipment.clothesChange("Naked")
        Equipment.weaponChange("Fists")

        'goddess transformation
        If p.sex = "Male" Then
            p.sexBool = True
            p.MtF()
            out += "Your body becomes daintier, and you are soon fully female.  "
        End If
        If p.skincolor = Color.FromArgb(255, 255, 105, 180) Then p.haircolor = Color.FromArgb(255, 155, 0, 0)
        If p.skincolor = Color.FromArgb(200, 0, 255, 255) Then p.haircolor = Color.FromArgb(180, 5, 245, 198)
        p.iArrInd(1) = New Tuple(Of Integer, Boolean)(15, True)
        p.iArrInd(2) = New Tuple(Of Integer, Boolean)(21, True)
        p.iArrInd(4) = New Tuple(Of Integer, Boolean)(0, True)
        p.iArrInd(5) = New Tuple(Of Integer, Boolean)(19, True)
        p.iArrInd(6) = New Tuple(Of Integer, Boolean)(7, True)
        p.iArrInd(7) = New Tuple(Of Integer, Boolean)(0, True)
        p.iArrInd(8) = New Tuple(Of Integer, Boolean)(11, True)
        p.iArrInd(9) = New Tuple(Of Integer, Boolean)(18, True)
        p.iArrInd(10) = New Tuple(Of Integer, Boolean)(0, True)
        p.iArrInd(13) = New Tuple(Of Integer, Boolean)(0, True)
        p.iArrInd(15) = New Tuple(Of Integer, Boolean)(15, True)
        p.iArrInd(16) = New Tuple(Of Integer, Boolean)(0, True)

        'transformation description push
        p.TextColor = Color.Orange
        out += "[Transformation decription pending]"
        If Not Game.combatmode Then
            Game.lblEvent.ForeColor = p.TextColor
            Game.pushLblEvent(out)
        End If
    End Sub
End Class
