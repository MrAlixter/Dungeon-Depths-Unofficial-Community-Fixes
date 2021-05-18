Public NotInheritable Class WBimboTF
    Inherits BimboTF
    Public Shared bimbog1 As Color = Color.FromArgb(255, 102, 217, 64)
    Public Shared bimbog2 As Color = Color.FromArgb(255, 82, 209, 41)

    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        MyBase.updateDuringCombat = False
        tfName = "WBimbo"
        nextStep = AddressOf hairColorShift
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        MyBase.updateDuringCombat = False
        tfName = "WBimbo"
        nextStep = getNextStep(cs)
    End Sub

    'Hair Color Shift
    Overrides Sub hairColorShift()
        Game.player1.prt.haircolor = DDUtils.cShift(Game.player1.prt.haircolor, bimbog1, 25)
        If Not Game.player1.getHairColor.Equals(bimbog1) Then currStep -= 1
        Game.pushLblEvent("Your hair becomes slightly lighter, brightening towards a lime green.")
    End Sub

    'Step 1
    Public Overrides Sub s1BimboHairChange(ByRef p As Player)
        p.prt.haircolor = bimbog1
        p.prt.setIAInd(pInd.rearhair, 5, True, True)
        p.prt.setIAInd(pInd.midhair, 5, True, True)
        p.prt.setIAInd(pInd.fronthair, 6, True, True)
    End Sub

    'Step 2
    Public Overrides Sub s2M2F(ByRef p As Player, ByRef out As String, ByRef haircolor As String)
        MyBase.s2M2F(p, out, "lime green")
    End Sub
    Public Overrides Sub s2HairChange(ByRef p As Player)
        p.prt.haircolor = bimbog2
        p.prt.setIAInd(pInd.rearhair, 25, True, True)
        p.prt.setIAInd(pInd.midhair, 28, True, True)
        p.prt.setIAInd(pInd.fronthair, 26, True, True)
    End Sub
    Public Overrides Sub s2FaceChange(ByRef p As Player)
        p.prt.setIAInd(pInd.eyes, 29, True, True)  'eyes
        p.prt.setIAInd(pInd.mouth, 15, True, True)  'mouth
    End Sub

  Public Overrides Function hasBimboHair(p As Player) As Boolean
        Return p.prt.haircolor.Equals(bimbog1) Or p.prt.haircolor.Equals(bimbog2)
    End Function
End Class
