Public NotInheritable Class MBimboTF
    Inherits BimboTF
    Public Shared bimboblue1 As Color = Color.FromArgb(255, 200, 255, 250)
    Public Shared bimboblue2 As Color = Color.FromArgb(255, 230, 255, 255)

    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        MyBase.updateDuringCombat = False
        tfName = "MBimbo"
        nextStep = AddressOf hairColorShift
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        MyBase.updateDuringCombat = False
        tfName = "MBimbo"
        nextStep = getNextStep(cs)
    End Sub

    'Hair Color Shift
    Overrides Sub hairColorShift()
        Game.player1.prt.haircolor = Game.cShift(Game.player1.prt.haircolor, bimboblue1, 25)
        If Not Game.player1.getHairColor.Equals(bimboblue1) Then currStep -= 1
        Game.pushLblEvent("Your hair becomes slightly lighter, brightening to a cool, pale blue.")
    End Sub

    'Step 1
    Public Overrides Sub s1BimboHairChange(ByRef p As Player)
        p.prt.haircolor = bimboblue1
        p.prt.setIAInd(pInd.rearhair, 5, True, True)
        p.prt.setIAInd(pInd.midhair, 5, True, True)
        p.prt.setIAInd(pInd.fronthair, 6, True, True)
    End Sub

    'Step 2
    Public Overrides Sub s2M2F(ByRef p As Player, ByRef out As String, ByRef haircolor As String)
        MyBase.s2M2F(p, out, "minty cyan")
    End Sub
    Public Overrides Sub s2HairChange(ByRef p As Player)
        p.prt.haircolor = bimboblue2
        p.prt.setIAInd(pInd.rearhair, 19, True, True)  'rearhair1
        p.prt.setIAInd(pInd.midhair, 23, True, True)  'rearhair2
        p.prt.setIAInd(pInd.fronthair, 20, True, True) 'fronthair
    End Sub
    Public Overrides Sub s2FaceChange(ByRef p As Player)
        If p.name <> "Targax" Then
            p.prt.haircolor = bimboblue2
            p.prt.setIAInd(pInd.eyes, 27, True, True)  'eyes
        Else
            p.prt.setIAInd(pInd.eyes, 16, True, True)
        End If
        p.prt.setIAInd(pInd.mouth, 13, True, True)  'mouth
    End Sub

    Public Overrides Function hasBimboHair(p As Player) As Boolean
        Return p.prt.haircolor.Equals(bimboblue1) Or p.prt.haircolor.Equals(bimboblue2)
    End Function
End Class
