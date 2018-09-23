Public Class DragonTF
    Inherits PolymorphTF
    Sub New()
        MyBase.New()
        tfName = "DragonTF"
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

        'dragon transformation
        p.iArrInd(16) = New Tuple(Of Integer, Boolean)(CharacterGenerator.fHat.Count - 2, True)
        If Not Game.cboxMG.Items.Contains("Dragon's Breath") Then Game.cboxMG.Items.Add("Dragon's Breath")

        'transformation description push
        p.TextColor = Color.LightGreen
        out += "You can feel green scales begin to cover most of your body, as another wave of mana washes over you.  As your new scales begin to thicken, you are forced down onto all fours, and a quick glance back confirms that you now have grown considerably, as well as now have a thick reptilian tail, an a proper set of dragon wings, colored the same color green as the rest of your body. After your face finishes extending into a snout, and you feel the last of the changes stop, it finally hits you. You are now a dragon."
        Dim revertText = Game.lblEvent.Text.Split(vbCrLf)(0)
        If Not revertText.Equals("") Then out = revertText & vbCrLf & vbCrLf & out
        Game.pushLblEvent(out)
    End Sub
End Class
