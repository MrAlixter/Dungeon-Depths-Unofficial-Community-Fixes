Public NotInheritable Class Blindness
    Inherits Transformation

    Private Const TF_IND As tfind = tfind.blindness

    Sub New()
        MyBase.New(1, 0, 0, False)
        tf_name = TF_IND
        next_step = AddressOf step1
        setTurnsTilStep(0)
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tf_name = TF_IND
        next_step = getNextStep(cs)
    End Sub

    Sub step1()
        Game.player1.perks(perk.blind) = 1
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
        Game.player1.perks(perk.blind) = -1
        Game.pushLblEvent("You can see again!")
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        If stage = 0 Then Return AddressOf step1
        Return AddressOf stopTF
    End Function
    Public Overrides Sub setWaitTime(stage As Integer)
        turns_until_next_step = Int(Rnd() * 100) + 5
    End Sub
End Class
