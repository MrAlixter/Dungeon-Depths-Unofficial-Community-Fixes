Public Class SlimeTF
    Inherits PolymorphTF
    Sub New()
        MyBase.New()
        tfName = "SlimeTF"
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

        'unequips
        Equipment.clothesChange("Naked")

        'slime transformation
        p.perks("slimehair") = 1
        p.haircolor = Color.FromArgb(180, 5, 245, 198)
        p.skincolor = Color.FromArgb(200, 0, 255, 255)
        p.iArrInd(6) = New Tuple(Of Integer, Boolean, Boolean)(5, True, True)
        p.iArrInd(9) = New Tuple(Of Integer, Boolean, Boolean)(9, True, True)
        p.iArrInd(10) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        p.iArrInd(13) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        p.iArrInd(16) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        If Not p.sexBool Then
            p.idRouteFM()
        End If

        'transformation description push
        p.TextColor = Color.FromArgb(255, 2, 249, 200)
        Dim out = "Your skin feels wetter than it did a minute ago.  As you look down, you see that your body is slowly disolving into a aquamarine fluid! You melt down into a puddle, and find that while it is challenging, you can somewhat manipulate your body.  After some experimentation, you find yourself in a rough aproximation of your original form."
        Dim revertText = Game.lblEvent.Text.Split(vbCrLf)(0)
        If Not revertText.Equals("") Then out = revertText & vbCrLf & vbCrLf & out
        Game.pushLblEvent(out)
    End Sub
End Class
