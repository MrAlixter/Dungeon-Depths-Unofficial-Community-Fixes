Public NotInheritable Class BunnyGirlTFB
    Inherits PolymorphTF
    Sub New()
        MyBase.New()
        tfName = "BunnyGirl​TF"
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        nextStep = getNextStep(cs)
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        turnsTilNextStep = (Int(Rnd() * 7) + 2)
    End Sub

    Public Overrides Sub step1()
        Game.player.sex = "Female"
    End Sub
End Class
