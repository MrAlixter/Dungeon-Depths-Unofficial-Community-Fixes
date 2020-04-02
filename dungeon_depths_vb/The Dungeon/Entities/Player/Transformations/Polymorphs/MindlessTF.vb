Public NotInheritable Class MindlessTF
    Inherits PolymorphTF

    Dim altcourse = False
    Sub New()
        MyBase.New()
        tfName = "Mindless"
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        nextStep = getNextStep(cs)
    End Sub

    Sub altNew()
        altcourse = True
        nextStep = AddressOf step1alt
        turnsTilNextStep = 3
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        If altcourse Then Exit Sub
        turnsTilNextStep = 100
    End Sub

    Public Overrides Sub step1()
        If altcourse Then Exit Sub
        Dim p As Player = Game.player1
        Dim out = ""

        'transformation
        If p.sex.Equals("Male") Then
            p.prt.setIAInd(pInd.mouth, 6, False, True)
            p.prt.setIAInd(pInd.eyes, 10, False, True)
        Else
            p.prt.setIAInd(pInd.mouth, 16, True, True)
            p.prt.setIAInd(pInd.eyes, 33, True, True)
        End If

        p.pClass = p.classes("Mindless")

        out += """Oh, you offer me your mind?  Very well, I shall borrow it for a while.  Perhaps if you bear my signet I'll even make some improvements before its return, loyal one..."" you hear the voice of Uvona whisper in your ear.  As she speaks, a haze falls over your mind and ... suddenly ... you can't ... think no more ..."

        Game.pushLblEvent(out)
    End Sub

    Public Sub step1alt()
        Dim p As Player = Game.player1
        Dim out = ""

        p.pState.save(p)

        'transformation
        'eyes/mouth
        If p.sex.Equals("Male") Then
            p.prt.setIAInd(pInd.eyes, 10, False, True)
            p.prt.setIAInd(pInd.mouth, 6, False, True)
        Else
            p.prt.setIAInd(pInd.eyes, 33, True, True)
            p.prt.setIAInd(pInd.mouth, 16, True, True)
        End If

        p.pClass = p.classes("Mindless")

        Game.pushLblEvent("The alraune's spell puts you into a deep trance!")

        turnsTilNextStep = 3

        p.polymorphs("Mindless") = PolymorphTF.newPoly("MindlessAlt")
        p.ongoingTFs.Add(p.polymorphs("Mindless"))
        p.perks("polymorphed") = turnsTilNextStep
        p.pClass = p.classes("Mindless")

        p.drawPort()
    End Sub
End Class
