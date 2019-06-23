Public Class MindlessTF
    Inherits PolymorphTF
    Sub New()
        MyBase.New()
        tfName = "Mindless"
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        nextStep = getNextStep(cs)
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        Dim p As Player = Game.player
        turnsTilNextStep = 100
    End Sub

    Public Overrides Sub step1()
        Dim p As Player = Game.player
        Dim out = ""

        'transformation
        If p.sex.Equals("Male") Then
            p.prt.setIAInd(8, 6, False, True)
            p.prt.setIAInd(9, 10, False, True)
        Else
            p.prt.setIAInd(8, 16, True, True)
            p.prt.setIAInd(9, 33, True, True)
        End If

        p.pClass = p.classes("Mindless")

        out += """Oh, you offer me your mind?  Very well, I shall borrow it for a while.  Perhaps if you bear my signet I'll even make some improvements before its return, loyal one..."" you hear the voice of Uvona whisper in your ear.  As she speaks, a haze falls over your mind and ... suddenly ... you can't ... think no more ..."

        Game.pushLblEvent(out)
    End Sub
End Class
