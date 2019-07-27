Public Class GooGirlTF
    Inherits Transformation
    Sub New(Optional cs As Integer = 2)
        MyBase.New(1, 0, 0, False)
        tfName = "GooGirlTF"
        currStep = cs
        nextStep = getNextStep(cs)
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "GooGirlTF"
        nextStep = getNextStep(cs)
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As Player = Game.player

        Select Case currStep
            Case 1
                Return AddressOf VialOfSlimeTF.step1
            Case 2
                Return AddressOf VialOfSlimeTF.step2alt
            Case 3
                Return AddressOf VialOfSlimeTF.step3alt
            Case 4
                Return AddressOf VialOfSlimeTF.step4alt
            Case Else
                Return AddressOf stopTF
        End Select
    End Function

    Public Overrides Sub setWaitTime(stage As Integer)
        stopTF()
    End Sub
End Class
