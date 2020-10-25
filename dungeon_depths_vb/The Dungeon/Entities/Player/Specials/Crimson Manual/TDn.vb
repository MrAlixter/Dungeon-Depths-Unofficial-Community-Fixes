Public Class TDn
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Tits Down")
        MyBase.setUOC(True)
        MyBase.setcost(5)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser()

        p.savePState()

        p.bs()
        p.lust += 10

        Game.pushLblEvent("Tits Down!  Your breasts squeeze uncomfortably...")

        p.drawPort()
    End Sub
End Class
