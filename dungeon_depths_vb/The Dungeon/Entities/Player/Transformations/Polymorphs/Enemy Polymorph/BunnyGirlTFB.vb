Public NotInheritable Class BunnyGirlTFB
    Inherits PolymorphTF

    Private Const TF_IND As tfind = tfind.bunnygirlbackfire

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
        Game.player1.sex = "Female"
        Game.player1.changeForm("Human")
        Game.player1.changeClass("Bunny Girl​")
    End Sub
End Class
