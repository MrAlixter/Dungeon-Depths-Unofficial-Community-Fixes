Public Class DDn
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Dick Down")
        MyBase.setUOC(True)
        MyBase.setcost(5)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser()

        p.savePState()

        p.ds()
        p.lust += 10

        Game.pushLblEvent("Dick Down!  Your cock squeezes uncomfortably...")

        p.drawPort()
    End Sub
End Class
