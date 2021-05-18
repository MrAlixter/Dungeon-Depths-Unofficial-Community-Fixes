Public NotInheritable Class BBBimboTF
    Inherits BimboTF
    Public Shared bimbovi1 As Color = Color.FromArgb(255, 131, 58, 113)
    Public Shared bimbovi2 As Color = Color.FromArgb(255, 111, 26, 79)

    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        MyBase.updateDuringCombat = False
        tfName = "BBBimbo"
        nextStep = AddressOf hairColorShift
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        MyBase.updateDuringCombat = False
        tfName = "BBBimbo"
        nextStep = getNextStep(cs)
    End Sub

    'Hair color shifting
    Overrides Sub hairColorShift()
        Game.player1.prt.haircolor = DDUtils.cShift(Game.player1.prt.haircolor, bimbovi1, 25)
        If Not Game.player1.getHairColor.Equals(bimbovi1) Then currStep -= 1
        Game.pushLblEvent("Your hair becomes slightly darker, deepening towards a deep purple.")
    End Sub

    'Step 1
    Public Overrides Sub s1BimboHairChange(ByRef p As Player)
        p.prt.haircolor = bimbovi1
        p.prt.setIAInd(pInd.rearhair, 5, True, True)
        p.prt.setIAInd(pInd.midhair, 5, True, True)
        p.prt.setIAInd(pInd.fronthair, 6, True, True)
    End Sub

    'Step 2
    Public Overrides Sub s2M2F(ByRef p As Player, ByRef out As String, ByRef haircolor As String)
        MyBase.s2M2F(p, out, "two-toned purple")
    End Sub
    Public Overrides Sub s2HairChange(ByRef p As Player)
        p.prt.haircolor = bimbovi2
        p.prt.setIAInd(pInd.rearhair, 22, True, True)  'rearhair1
        p.prt.setIAInd(pInd.midhair, 25, True, True)  'rearhair2
        p.prt.setIAInd(pInd.fronthair, 23, True, True) 'fronthair
    End Sub
    Public Overrides Sub s2FaceChange(ByRef p As Player)
        p.prt.setIAInd(pInd.eyes, 28, True, True)
     
        p.prt.setIAInd(pInd.mouth, 14, True, True)  'mouth
    End Sub


    Public Overrides Function hasBimboHair(p As Player) As Boolean
        Return p.prt.haircolor.Equals(bimbovi1) Or p.prt.haircolor.Equals(bimbovi2)
    End Function
End Class
