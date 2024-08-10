Public NotInheritable Class DoveTF
    Inherits PolymorphTF

    Private Const TF_IND As tfind = tfind.dove

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
        Dim p As Player = Game.player1
        turns_until_next_step = Math.Max(5, (Int(Rnd() * p.getMaxMana) + Int(Rnd() * p.getWIL)))
    End Sub

    Public Overrides Sub step1()
        If Not Game.becameDove Then Game.becameDove = True
        Game.player1.changeForm("Dove")
    End Sub

    Public Overrides Function getTFText() As String
        Return "You rapidly shrink into a small, peaceful bird."
    End Function
End Class
