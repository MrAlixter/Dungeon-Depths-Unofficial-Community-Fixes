Public Class Blindness
    Inherits Transformation

    Sub New()
        MyBase.New(1, 0, 0, False)
        tfName = "Blind"
        nextStep = AddressOf step1
        setTurnsTilStep(0)
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "Blind"
        nextStep = getNextStep(cs)
    End Sub

    Sub step1()
        Game.player.perks("blind") = 1
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
        Game.player.perks("blind") = -1
        Game.pushLblEvent("You can see again!")
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        If stage = 0 Then Return AddressOf step1
        Return AddressOf stopTF
    End Function
    Public Overrides Sub setWaitTime(stage As Integer)
        turnsTilNextStep = Int(Rnd() * 100) + 5
    End Sub
End Class
