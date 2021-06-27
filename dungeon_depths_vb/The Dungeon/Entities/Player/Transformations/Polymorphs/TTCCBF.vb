Public NotInheritable Class TTCCBF
    Inherits PolymorphTF

    Private Const TF_IND As tfind = tfind.cakebackfire

    Sub New()
        MyBase.New()
        tf_name = TF_IND
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        next_step = getNextStep(cs)
        tf_name = TF_IND
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        turns_until_next_step = (Int(Rnd() * 7) + 2)
    End Sub

    Public Overrides Sub step1()
        Game.player1.changeForm("Cake")
        Game.player1.sex = "Female"
    End Sub
End Class
