Public NotInheritable Class MPBimboTF
    Inherits BimboTF
    Public Shared bimboblue1 As Color = Color.FromArgb(255, 76, 177, 214)
    Public Shared bimboblue2 As Color = Color.FromArgb(255, 178, 234, 255)

    Private Const TF_IND As tfind = tfind.hpbimbo

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
        Game.player1.prt.haircolor = DDUtils.cShift(Game.player1.prt.haircolor, bimboblue1, 20)
        If Not Game.player1.getHairColor.Equals(bimboblue1) Then curr_step -= 1
        TextEvent.fpush("Your hair becomes slightly lighter, shifting to a bright, electric azure.")
    End Sub

    'Step 1
    Public Overrides Sub s1BimboHairChange(ByRef p As Player)
        MyBase.s1BimboHairChange(p)

        p.prt.haircolor = bimboblue1
    End Sub

    'Step 2
    Public Overrides Sub s2M2F(ByRef p As Player, ByRef out As String, ByRef haircolor As String)
        MyBase.s2M2F(p, out, "pastel blue")
    End Sub
    Public Overrides Sub s2HairChange(ByRef p As Player)
        MyBase.s2HairChange(p)

        p.prt.haircolor = bimboblue2
    End Sub
    Public Overrides Sub s2FaceChange(ByRef p As Player)
        MyBase.s2FaceChange(p)

        If p.name <> "Targax" Then
            p.prt.haircolor = bimboblue2
        End If
    End Sub

    Public Overrides Function hasBimboHair(p As Player) As Boolean
        Return p.prt.haircolor.Equals(bimboblue1) Or p.prt.haircolor.Equals(bimboblue2)
    End Function

    Public Overrides Sub setWaitTime(stage As Integer)
        turns_until_next_step = 5 + (Int(Rnd() * 5) + 1)
        turns_until_next_step += generatWILResistance()

        Dim p = Game.player1

        p.mana += 2
        If p.mana > p.getMaxMana Then p.mana = p.getMaxMana

        TextEvent.pushLog("+2 mana")
    End Sub
End Class
