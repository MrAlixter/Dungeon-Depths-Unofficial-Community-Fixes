Public NotInheritable Class DemBimboTF
    Inherits BimboTF
    Public Shared bimbop As Color = Color.FromArgb(255, 255, 184, 222)

    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        MyBase.updateDuringCombat = False
        tfName = "DemBimbo"
        nextStep = AddressOf hairColorShift
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        MyBase.updateDuringCombat = False
        tfName = "DemBimbo"
        nextStep = getNextStep(cs)
    End Sub

    'Hair Color Shift
    Overrides Sub hairColorShift()
        Game.player1.prt.haircolor = Game.cShift(Game.player1.prt.haircolor, bimbop, 25)
        If Not Game.player1.getHairColor.Equals(bimbop) Then currStep -= 1
        Game.pushLblEvent("Your hair becomes slightly lighter, brightening towards a pastel pink.")
    End Sub

    'Step 1
    Public Overrides Sub s1BimboHairChange(ByRef p As Player)
        p.prt.haircolor = bimbop
        p.prt.setIAInd(pInd.rearhair, 5, True, True)
        p.prt.setIAInd(pInd.midhair, 5, True, True)
        p.prt.setIAInd(pInd.fronthair, 6, True, True)
    End Sub

    'Step 2
    Public Overrides Sub s2M2F(ByRef p As Player, ByRef out As String, ByRef haircolor As String)
        MyBase.s2M2F(p, out, "pastel pink")
    End Sub
    Public Overrides Sub s2HairChange(ByRef p As Player)
        p.prt.haircolor = bimbop
        p.prt.setIAInd(pInd.rearhair, 6, True, True)
        p.prt.setIAInd(pInd.midhair, 22, True, True)
        p.prt.setIAInd(pInd.fronthair, 19, True, True)
    End Sub
    Public Overrides Sub s2FaceChange(ByRef p As Player)
        If p.name <> "Targax" Then
            p.prt.setIAInd(pInd.eyes, 49, True, True)
        Else
            p.prt.setIAInd(pInd.eyes, 29, True, True)  'eyes
        End If
        p.prt.setIAInd(pInd.mouth, 25, True, True)  'mouth
    End Sub

    Public Overrides Function hasBimboHair(p As Player) As Boolean
        Return p.prt.haircolor.Equals(bimbop)
    End Function
End Class
