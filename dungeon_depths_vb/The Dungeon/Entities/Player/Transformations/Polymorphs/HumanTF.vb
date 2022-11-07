Public NotInheritable Class HumanTF
    Inherits Transformation

    Private Const TF_IND As tfind = tfind.humanpolymorph

    Sub New()
        MyBase.New(1, 0, 0, False)
        tf_name = TF_IND
        next_step = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tf_name = TF_IND
        next_step = getNextStep(cs)
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        Dim p As Player = Game.player1
        turns_until_next_step = 2 * (Int(Rnd() * 50) + Int(Rnd() * 50) + Int(Rnd() * p.getMaxMana) + Int(Rnd() * p.getWIL))
    End Sub

    Public Sub step1()
        Dim p As player = Game.player1

        change(p)
    End Sub

    Shared Sub change(ByRef p As Player)
        p.changeForm("Human")

        'color tfs
        p.prt.changeHairColor(Color.FromArgb(255, p.prt.haircolor.R, p.prt.haircolor.G, p.prt.haircolor.B))
        p.prt.changeSkinColor(getSkinColor(p))

        'face tf
        If p.prt.iArrInd(pInd.eyes).Item3 Then p.prt.setIAInd(pInd.eyes, 0, p.sex.Equals("Female"), False)
        If p.prt.iArrInd(pInd.nose).Item3 Then p.prt.setIAInd(pInd.eyes, 0, p.sex.Equals("Female"), False)
        p.prt.setIAInd(pInd.ears, 0, p.sex.Equals("Female"), False)

        'hair tf
        Randomize()
        r = Int(Rnd() * 7)
        p.prt.setIAInd(pInd.rearhair, r, p.sex.Equals("Female"), False)
        p.prt.setIAInd(pInd.midhair, r, p.sex.Equals("Female"), False)
        r = Int(Rnd() * 8) + 1
        p.prt.setIAInd(pInd.fronthair, r, p.sex.Equals("Female"), False)

        'body tf
        If p.breastSize > 3 Then p.breastSize = 3
        If p.dickSize > 2 Then p.dickSize = 2
        If p.buttSize > 3 Then p.buttSize = 3

        p.prt.setIAInd(pInd.horns, 0, True, False)
        p.prt.setIAInd(pInd.tail, 0, True, False)
        p.prt.setIAInd(pInd.wings, 0, True, False)

        'transformation description push
        p.textColor = Color.White
    End Sub

    Private Shared Function getSkinColor(ByRef p As Player) As Color
        Dim cArr As Color() = {Color.AntiqueWhite, Color.FromArgb(255, 247, 219, 195), Color.FromArgb(255, 240, 184, 160), Color.FromArgb(255, 210, 161, 140), Color.FromArgb(255, 180, 138, 120), Color.FromArgb(255, 105, 80, 70)}

        Dim c As Color = Color.FromArgb(255, 210, 161, 140)
        Dim closest As Double = 99999999999999
        For Each clr In cArr
            Dim ratio = Player.isShadeOf(p.prt.skincolor.R, p.prt.skincolor.G, p.prt.skincolor.B, clr)
            If ratio < closest Then
                closest = ratio
                c = clr
            End If
        Next

        Return c
    End Function

    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As player = Game.player1
        Select Case stage
            Case 0
                Return AddressOf step1
            Case Else
                Return AddressOf stopTF
        End Select
    End Function
End Class
