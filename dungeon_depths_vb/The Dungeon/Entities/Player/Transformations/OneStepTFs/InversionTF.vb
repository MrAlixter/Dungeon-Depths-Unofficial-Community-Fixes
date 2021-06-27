Public NotInheritable Class InversionTF
    Inherits OneStepTF

    Private Const TF_IND As tfind = tfind.inversion

    Sub New()
        MyBase.New()
        tf_name = TF_IND
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tf_name = TF_IND
    End Sub

    Public Overrides Sub step1()
        If Not Game.player1.quests(qInds.oppositeDay).canGet Then Exit Sub

        Game.player1.quests(qInds.oppositeDay).init()

        snapTF()
        Game.player1.savePState()
    End Sub

    Public Shared Sub snapTF()
        Dim p As Player = Game.player1

        'transformation
        If p.sex.Equals("Male") Then p.MtF() Else p.FtM()

        If ((p.pForm.a + p.pForm.d + p.pClass.a + p.pClass.d) / 4) > ((p.pForm.m + p.pForm.w + p.pClass.m + p.pClass.w) / 4) Then
            toElf(p)
        Else
            toOrc(p)
        End If
    End Sub

    Private Shared Sub toOrc(ByRef p As Player)
        p.changeHairColor(Color.FromArgb(255, Math.Max(50, p.prt.haircolor.R - 100), Math.Max(50, p.prt.haircolor.G - 100), Math.Max(50, p.prt.haircolor.B - 100)))
        p.changeSkinColor(Color.FromArgb(255, 122, 158, 109))

        If p.sex.Equals("Male") Then
            p.prt.setIAInd(pInd.mouth, 9, False, True)
            'p.prt.setIAInd(pInd.eyes, 15, False, True)
            p.prt.setIAInd(pInd.rearhair, 1, False, False)
            p.prt.setIAInd(pInd.midhair, 0, False, False)
            p.dickSize = 2
        Else
            p.prt.setIAInd(pInd.mouth, 26, True, True)
            'p.prt.setIAInd(pInd.eyes, 54, True, True)
            p.prt.setIAInd(pInd.rearhair, 6, True, False)
            p.prt.setIAInd(pInd.midhair, 32, True, True)
            p.breastSize = 2
            p.buttSize = 2
        End If

        p.changeClass("Warrior")
        p.changeForm("Orc")
    End Sub

    Private Shared Sub toElf(ByRef p As Player)
        p.changeHairColor(Color.FromArgb(255, Math.Min(250, p.prt.haircolor.R + 50), Math.Min(250, p.prt.haircolor.G + 50), Math.Min(250, p.prt.haircolor.B + 50)))
        p.changeSkinColor(Color.FromArgb(255, 251, 237, 221))

        If p.sex.Equals("Male") Then
            p.prt.setIAInd(pInd.ears, 8, False, True)
            'p.prt.setIAInd(pInd.eyes, 16, False, True)
            p.prt.setIAInd(pInd.rearhair, 5, False, False)
            p.prt.setIAInd(pInd.midhair, 7, False, True)
            p.dickSize = 0
        Else
            p.prt.setIAInd(pInd.ears, 14, True, True)
            'p.prt.setIAInd(pInd.eyes, 55, True, True)
            p.prt.setIAInd(pInd.rearhair, 12, True, True)
            p.prt.setIAInd(pInd.midhair, 17, True, True)
            p.breastSize = 0
            p.buttSize = 0
        End If

        p.breastSize = 0

        p.changeClass("Cleric")
        p.changeForm("Elf")
    End Sub
End Class
