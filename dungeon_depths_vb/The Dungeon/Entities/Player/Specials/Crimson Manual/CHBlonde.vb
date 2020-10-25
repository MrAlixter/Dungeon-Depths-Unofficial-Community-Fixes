Public Class CHBlonde
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Chameleon (Blonde)")
        MyBase.setUOC(True)
        MyBase.setcost(5)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser()

        p.savePState()

        Dim c As Integer = Int(Rnd() * 75) + 180
        p.prt.haircolor = Color.FromArgb(p.prt.haircolor.A, c, c - 25, 0)

        Game.pushLblEvent("CHAMELEON!  You now have blonde hair...")

        p.addLust(10)

        p.drawPort()
    End Sub
End Class
