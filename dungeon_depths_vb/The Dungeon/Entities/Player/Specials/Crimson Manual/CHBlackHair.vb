Public Class CHBlackHair
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Chameleon (Black Hair)")
        MyBase.setUOC(True)
        MyBase.setcost(5)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser()

        p.savePState()

        Dim c As Integer = Int(Rnd() * 35) + 15
        p.prt.haircolor = Color.FromArgb(p.prt.haircolor.A, c, c, c)

        Game.pushLblEvent("CHAMELEON!  You now have black hair...")

        p.addLust(10)

        p.drawPort()
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Changes the user's appearance using an arousing energy imparted by a succubus."
    End Function
End Class
