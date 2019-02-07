Public Class VialOfSlimeTF
    Inherits Transformation
    Sub New()
        MyBase.New(1, 0, 0, False)
        tfName = "VialOfSlimeTF"
        nextStep = getNextStep(0)
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "VialOfSlimeTF"
        nextStep = getNextStep(cs)
    End Sub

    Sub step1()
        Dim p As player = game.player
        If p.iArrInd(5).Item1 = 7 And p.iArrInd(5).Item2 Then
            Game.pushLstLog("Your hair resists being altered!")
        Else
            p.haircolor = Color.FromArgb(180, 5, 245, 198)
            p.createP()
            p.perks("vsslimehair") = 0
        End If
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As player = game.player
        If p.perks("vsslimehair") < 0 Then
            Return AddressOf step1
        Else
            Return AddressOf stopTF
        End If
    End Function

    Public Overrides Sub setWaitTime(stage As Integer)
        stopTF()
    End Sub
End Class
