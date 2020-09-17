Public Class UDn
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Ass Down")
        MyBase.setUOC(True)
        MyBase.setcost(5)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser()

        p.savePState()

        p.us()
        p.lust += 10

        Game.pushLblEvent("Ass Down!  Your butt squeezes uncomfortably...")

        p.drawPort()
    End Sub
End Class
