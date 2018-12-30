Public Class GoddessTF
    Inherits PolymorphTF
    Sub New()
        MyBase.New()
        tfName = "GoddessTF"
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
        Equipment.clothesChange("Goddess_Gown")
        Equipment.weaponChange("Fists")

        'goddess transformation
        If p.sex = "Male" Then
            p.sexBool = True
            p.MtF()
            out += "Your body becomes daintier, and you are soon fully female.  "
        End If
        p.haircolor = Color.FromArgb(255, 210, 180, 140)
        If p.skincolor = Color.FromArgb(255, 255, 105, 180) Then p.haircolor = Color.FromArgb(255, 155, 0, 0)
        If p.skincolor = Color.FromArgb(200, 0, 255, 255) Then p.haircolor = Color.FromArgb(180, 5, 245, 198)
        p.iArrInd(1) = New Tuple(Of Integer, Boolean)(8, True)
        p.iArrInd(2) = New Tuple(Of Integer, Boolean)(1, True)
        p.iArrInd(4) = New Tuple(Of Integer, Boolean)(0, True)
        p.iArrInd(5) = New Tuple(Of Integer, Boolean)(8, True)
        p.iArrInd(6) = New Tuple(Of Integer, Boolean)(0, True)
        p.iArrInd(7) = New Tuple(Of Integer, Boolean)(0, True)
        p.iArrInd(8) = New Tuple(Of Integer, Boolean)(8, True)
        p.iArrInd(9) = New Tuple(Of Integer, Boolean)(10, True)
        p.iArrInd(10) = New Tuple(Of Integer, Boolean)(0, True)
        p.iArrInd(13) = New Tuple(Of Integer, Boolean)(0, True)
        p.iArrInd(15) = New Tuple(Of Integer, Boolean)(9, True)
        p.iArrInd(16) = New Tuple(Of Integer, Boolean)(0, True)
        p.goddState.save(p)

        'transformation description push
        p.TextColor = Color.LightGoldenrodYellow
        out += "Your eyes burn with an awesome fury as golden flames engulf you.  Your opponent squints and covers their eyes, blinded by your new found vibrance.  Dialing back your personal light show, you give them a cocky grin.  They may not know it, but this battle is already over."
        Dim revertText = Game.lblEvent.Text.Split(vbCrLf)(0)
        If Not revertText.Equals("") Then out = revertText & vbCrLf & vbCrLf & out
        Game.pushLblEvent(out)
    End Sub
End Class
