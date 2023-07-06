Public NotInheritable Class HumanTF
    Inherits PolymorphTF

    Private Const TF_IND As tfind = tfind.humanpolymorph

    Sub New()
        MyBase.New()
        tf_name = TF_IND
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

    Public Overrides Sub step1()
        Dim p As Player = Game.player1

        change(p)
    End Sub

    Shared Sub change(ByRef p As Player, ByRef s As State, Optional ByVal changeForm As Boolean = True)
        If changeForm Then s.pForm = New Human()

        'color tfs
        s.haircolor = Color.FromArgb(255, p.prt.haircolor.R, p.prt.haircolor.G, p.prt.haircolor.B)
        s.skincolor = getSkinColor(p)

        'face tf
        If p.prt.iArrInd(pInd.eyes).Item3 Then s.setIArrInd(pInd.eyes, 0, Not p.sex.Equals("Male"), False)
        If p.prt.iArrInd(pInd.nose).Item3 Then s.setIArrInd(pInd.eyes, 0, Not p.sex.Equals("Male"), False)
        s.setIArrInd(pInd.ears, 0, Not p.sex.Equals("Male"), False)

        'hair tf
        If p.prt.iArrInd(pInd.rearhair).Item3 Or p.prt.iArrInd(pInd.midhair).Item3 Or p.prt.iArrInd(pInd.fronthair).Item3 Then
            Randomize()
            r = Int(Rnd() * 7)
            s.setIArrInd(pInd.rearhair, r, Not p.sex.Equals("Male"), False)
            s.setIArrInd(pInd.midhair, r, Not p.sex.Equals("Male"), False)
            r = Int(Rnd() * 8) + 1
            s.setIArrInd(pInd.fronthair, r, Not p.sex.Equals("Male"), False)
        End If

        'body tf
        If p.breastSize > 3 Then s.breastSize = 3
        If p.dickSize > 2 Then s.dickSize = 2
        If p.buttSize > 3 Then s.buttSize = 3

        s.setIArrInd(pInd.horns, 0, True, False)
        s.setIArrInd(pInd.tail, 0, True, False)
        s.setIArrInd(pInd.wings, 0, True, False)

        'transformation description push
        s.textColor = Color.White
    End Sub
    Shared Sub change(ByRef p As Player, Optional ByVal changeForm As Boolean = True)
        If changeForm Then p.changeForm("Human")

        'color tfs
        p.prt.changeHairColor(Color.FromArgb(255, p.prt.haircolor.R, p.prt.haircolor.G, p.prt.haircolor.B))
        p.prt.changeSkinColor(getSkinColor(p))

        'face tf
        If p.prt.iArrInd(pInd.eyes).Item3 Then p.prt.setIAInd(pInd.eyes, 0, Not p.sex.Equals("Male"), False)
        If p.prt.iArrInd(pInd.nose).Item3 Then p.prt.setIAInd(pInd.eyes, 0, Not p.sex.Equals("Male"), False)
        p.prt.setIAInd(pInd.ears, 0, Not p.sex.Equals("Male"), False)

        'hair tf
        If p.prt.iArrInd(pInd.rearhair).Item3 Or p.prt.iArrInd(pInd.midhair).Item3 Or p.prt.iArrInd(pInd.fronthair).Item3 Then
            Randomize()
            r = Int(Rnd() * 7)
            p.prt.setIAInd(pInd.rearhair, r, Not p.sex.Equals("Male"), False)
            p.prt.setIAInd(pInd.midhair, r, Not p.sex.Equals("Male"), False)
            r = Int(Rnd() * 8) + 1
            p.prt.setIAInd(pInd.fronthair, r, Not p.sex.Equals("Male"), False)
        End If

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
