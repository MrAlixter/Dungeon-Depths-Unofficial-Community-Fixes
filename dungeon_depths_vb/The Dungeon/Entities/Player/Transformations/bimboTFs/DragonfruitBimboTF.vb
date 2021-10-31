Public NotInheritable Class DragonfruitBimboTF
    Inherits BimboTF
    Public Shared bimbopink1 As Color = Color.FromArgb(255, 219, 127, 216)
    Public Shared bimbopink2 As Color = Color.FromArgb(255, 255, 73, 248)

    Private Const TF_IND As tfind = tfind.dragonfruitbimbo

    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        MyBase.update_during_combat = False
        tf_name = TF_IND
        next_step = AddressOf hairColorShift
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        MyBase.update_during_combat = False
        tf_name = TF_IND
        next_step = getNextStep(cs)
    End Sub

    'Hair Color Shift
    Overrides Sub hairColorShift()
        Game.player1.prt.haircolor = DDUtils.cShift(Game.player1.prt.haircolor, bimbopink1, 25)
        If Not Game.player1.getHairColor.Equals(bimbopink1) Then curr_step -= 1
        TextEvent.push("Your hair becomes slightly lighter, brightening to a rosy pink.")
    End Sub

    'Step 1
    Public Overrides Sub s1BimboHairChange(ByRef p As Player)
        p.prt.haircolor = bimbopink1
        p.prt.setIAInd(pInd.rearhair, 5, True, True)
        p.prt.setIAInd(pInd.midhair, 5, True, True)
        p.prt.setIAInd(pInd.fronthair, 6, True, True)
    End Sub

    'Step 2
    Public Overrides Sub s2M2F(ByRef p As Player, ByRef out As String, ByRef haircolor As String)
        MyBase.s2M2F(p, out, "rosy pink")
    End Sub
    Public Overrides Sub s2HairChange(ByRef p As Player)
        p.prt.haircolor = bimbopink2
        p.prt.setIAInd(pInd.rearhair, 6, True, True)  'rearhair1
        p.prt.setIAInd(pInd.midhair, 34, True, True)  'rearhair2
        p.prt.setIAInd(pInd.fronthair, 6, True, True) 'fronthair
    End Sub
    Public Overrides Sub s2FaceChange(ByRef p As Player)
        p.prt.haircolor = bimbopink2
        p.prt.setIAInd(pInd.eyes, 16, True, True)  'eyes
        p.prt.setIAInd(pInd.mouth, 2, True, False)  'mouth
        p.prt.setIAInd(pInd.wings, 5, True, False)
        p.prt.setIAInd(pInd.horns, 4, True, False)
        p.changeForm("Half-Dragon (R)")
    End Sub

    Public Overrides Function hasBimboHair(p As Player) As Boolean
        Return p.prt.haircolor.Equals(bimbopink1) Or p.prt.haircolor.Equals(bimbopink2)
    End Function
End Class
