Public NotInheritable Class CowTF
    Inherits PolymorphTF

    Private Const TF_IND As tfind = tfind.cow

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
        If Game.combat_engaged Then turns_until_next_step = 4 Else turns_until_next_step = 18
    End Sub

    Public Overrides Sub step1()
        Game.player1.sex = "Female"
        Game.player1.changeForm("Cow")
    End Sub

    Public Overrides Function getTFText() As String
        Return "You collapse to all fours, as your body takes on the shape of a bovine.  You let out a loud ""Mooo!"""
    End Function
End Class
