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
        If p.sex = "Male" Or Not p.sexBool Then
            p.sexBool = True
            p.MtF()
            p.breastSize = Int(Rnd() * 3) + 1
            out += " Your body becomes daintier, and you are soon fully female."
        End If
        p.iArrInd(1) = New Tuple(Of Integer, Boolean, Boolean)(9, True, True)
        p.iArrInd(4) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        p.iArrInd(5) = New Tuple(Of Integer, Boolean, Boolean)(9, True, True)
        p.iArrInd(7) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        p.iArrInd(9) = New Tuple(Of Integer, Boolean, Boolean)(19, True, True)
        p.iArrInd(10) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        p.iArrInd(13) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        p.iArrInd(15) = New Tuple(Of Integer, Boolean, Boolean)(13, True, True)
        p.iArrInd(16) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        p.wingInd = 2

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
