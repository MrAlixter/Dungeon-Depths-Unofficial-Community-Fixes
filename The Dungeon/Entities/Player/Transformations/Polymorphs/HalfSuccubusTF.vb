Public Class HalfSuccubusTF
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
        Dim p As player = game.player
        Dim out = ""

        'unequips
        Equipment.clothesChange("Succubus_Garb")
        Equipment.weaponChange("Fists")
        Equipment.accChange("Nothing")

        'succubus transformation
        If p.sex = "Male" Or Not p.prt.sexBool Then
            p.MtF()
            p.breastSize = Int(Rnd() * 3) + 1
            out += " Your body becomes daintier, and you are soon fully female."
        End If
        p.prt.setIAInd(1, 9, True, True)
        p.prt.setIAInd(4, 0, True, False)
        p.prt.setIAInd(5, 9, True, True)
        p.prt.setIAInd(7, 0, True, False)
        p.prt.setIAInd(9, 19, True, True)
        p.prt.setIAInd(10, 0, True, False)
        p.prt.setIAInd(13, 0, True, False)
        p.prt.setIAInd(15, 13, True, True)
        p.prt.setIAInd(16, 0, True, False)
        p.prt.wingInd = 2

        'transformation description push
        p.TextColor = Color.HotPink
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As player = game.player
        Select Case stage
            Case 0
                Return AddressOf step1
            Case Else
                Return AddressOf stopTF
        End Select
    End Function
End Class
