Public NotInheritable Class MindlessTF
    Inherits PolymorphTF

    Dim altcourse = False
    Private Const TF_IND As tfind = tfind.mindless

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
        If altcourse Then Exit Sub
        turns_until_next_step = 100
    End Sub

    Public Overrides Sub step1()
        If altcourse Then Exit Sub
        Dim p As Player = Game.player1
        Dim out = ""

        p.changeClass("Mindless")

        out += """Oh, you offer me your mind?  Very well, I shall borrow it for a while.  Perhaps if you bear my signet I'll even make some improvements before its return, loyal one..."" you hear the voice of Uvona whisper in your ear.  As she speaks, a haze falls over your mind and... suddenly... you can't... think no more ..."

        TextEvent.push(out)
    End Sub

    Public Shared Sub step1alt(ByRef p As Player, ByVal dur As Integer)
        p.savePState()

        p.changeClass("Mindless")

        If p.perks(perk.polymorphed) < 0 Then p.perks(perk.polymorphed) = dur
    End Sub
End Class
