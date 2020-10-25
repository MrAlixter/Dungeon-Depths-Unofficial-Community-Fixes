Public Class CHRedhead
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Chameleon (Redhead)")
        MyBase.setUOC(True)
        MyBase.setcost(5)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser()

        p.savePState()

        Dim r As Integer = Int(Rnd() * 100) + 155
        p.prt.haircolor = Color.FromArgb(p.prt.haircolor.A, r, 69, 0)

        Game.pushLblEvent("CHAMELEON!  You now have red hair...")

        p.addLust(10)

        p.drawPort()
    End Sub
End Class
