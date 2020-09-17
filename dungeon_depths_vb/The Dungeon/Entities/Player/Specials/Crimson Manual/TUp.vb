Public Class TUp
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Tits Up")
        MyBase.setUOC(True)
        MyBase.setcost(5)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser()

        p.savePState()

        p.be()
        p.lust += 10

        Game.pushLblEvent("Tits Up!  Your breasts tingle plesently...")

        p.drawPort()
    End Sub
End Class
