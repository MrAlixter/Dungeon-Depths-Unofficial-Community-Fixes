Public Class SuccubusTF
    Inherits PolymorphTF
    Sub New()
        MyBase.New()
        tfName = "SuccubusTF"
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
        Equipment.clothesChange("Succubus_Garb")
        Equipment.weaponChange("Fists")

        'succubus transformation
        If p.sex = "Male" Then
            p.sexBool = True
            p.MtF()
            out += "Your body becomes daintier, and you are soon fully female.  "
        End If
        p.haircolor = Color.FromArgb(255, 155, 0, 0)
        p.skincolor = Color.FromArgb(255, 255, 105, 180)
        p.iArrInd(1) = New Tuple(Of Integer, Boolean)(9, True)
        p.iArrInd(4) = New Tuple(Of Integer, Boolean)(0, True)
        p.iArrInd(5) = New Tuple(Of Integer, Boolean)(9, True)
        p.iArrInd(7) = New Tuple(Of Integer, Boolean)(0, True)
        p.iArrInd(9) = New Tuple(Of Integer, Boolean)(12, True)
        p.iArrInd(10) = New Tuple(Of Integer, Boolean)(0, True)
        p.iArrInd(13) = New Tuple(Of Integer, Boolean)(0, True)
        p.iArrInd(15) = New Tuple(Of Integer, Boolean)(13, True)
        p.iArrInd(16) = New Tuple(Of Integer, Boolean)(0, True)
        p.wingInd = 2
        p.hornInd = 3

        'transformation description push
        p.TextColor = Color.HotPink
        out += "As hellfire engulfs you, you ponder over what you should do to your opponent.  Maybe flay them, mabye just go for a quick clean decapitation, or maybe tie them up and use them as a fucktoy until you get bored?  ""Well,"" you tell them with a sinister grin, ""... whatever I decide on ..."" you do a pirouette, showing off your new body in all its glory ""... will certainly be more fun for me ..."" you lock eyes with your prey and bare your fangs in a vicious sneer ""... than for you."""
        Dim revertText = Game.lblEvent.Text.Split(vbCrLf)(0)
        If Not revertText.Equals("") Then out = revertText & vbCrLf & vbCrLf & out
        Game.pushLblEvent(out)
    End Sub
End Class
