Public NotInheritable Class HalfSuccubusTF
    Inherits Transformation
    Sub New()
        MyBase.New(1, 0, 0, False)
        tfName = "HalfSuccubusTF"
        nextStep = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "HalfSuccubusTF"
        nextStep = getNextStep(cs)
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        stopTF()
    End Sub

    Public Sub step1()
        Dim p As player = game.player1
        Dim out = ""

        'unequips
        If p.inv.getCountAt("Succubus_Garb") < 1 Then p.inv.add("Succubus_Garb", 1)
        Equipment.clothesChange("Succubus_Garb")
        Equipment.weaponChange("Fists")
        Equipment.accChange("Nothing")

        'succubus transformation
        If p.sex = "Male" Or Not p.prt.sexBool Then
            p.MtF()
            p.breastSize = Int(Rnd() * 3) + 1
            out += " Your body becomes daintier, and you are soon fully female."
        End If
        p.prt.setIAInd(pInd.rearhair, 9, True, True)
        p.prt.setIAInd(pInd.face, 0, True, False)
        p.prt.setIAInd(pInd.midhair, 9, True, True)
        p.prt.setIAInd(pInd.nose, 0, True, False)
        p.prt.setIAInd(pInd.eyes, 19, True, True)
        p.prt.setIAInd(pInd.eyebrows, 0, True, False)
        p.prt.setIAInd(pInd.cloak, 0, True, False)
        p.prt.setIAInd(pInd.fronthair, 13, True, True)
        p.prt.setIAInd(pInd.hat, 0, True, False)
        p.prt.setIAInd(pInd.wings, 2, True, False)

        'transformation description push
        p.TextColor = Color.HotPink
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As player = game.player1
        Select Case stage
            Case 0
                Return AddressOf step1
            Case Else
                Return AddressOf stopTF
        End Select
    End Function
End Class
