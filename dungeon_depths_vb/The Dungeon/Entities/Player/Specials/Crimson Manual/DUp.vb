Public Class DUp
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Dick Up")
        MyBase.setUOC(True)
        MyBase.setcost(5)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser()

        p.savePState()

        p.de()
        p.lust += 10

        Game.pushLblEvent("Dick Up!  Your cock tingles plesently...")

        p.drawPort()
    End Sub
End Class
