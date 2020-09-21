Public NotInheritable Class COServ
    Inherits Transformation

    Dim destForm As preferedForm = New SuccMaid()
    Sub New()
        MyBase.New(1, 0, 0, False)
        tfName = "CurseOfServ"
        nextStep = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "CurseOfServ"
        nextStep = getNextStep(cs)
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        setTurnsTilStep(20 + Int(Rnd() * 50))
    End Sub

    Public Sub step1()
        Dim p As Player = Game.player1
        Dim t = p.className
        destForm.shiftTowards(p)
        p.changeClass(t)
    End Sub

    Public Overrides Sub stopTF()
        setWaitTime(0)
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As Player = Game.player1
        currStep = 1
        Return AddressOf step1
    End Function
End Class
