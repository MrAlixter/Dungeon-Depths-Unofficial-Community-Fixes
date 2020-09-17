Public Class UUp
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Ass Up")
        MyBase.setUOC(True)
        MyBase.setcost(5)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser()

        p.savePState()

        p.ue()
        p.lust += 10

        Game.pushLblEvent("Ass Up!  Your butt tingles plesently...")

        p.drawPort()
    End Sub
End Class
