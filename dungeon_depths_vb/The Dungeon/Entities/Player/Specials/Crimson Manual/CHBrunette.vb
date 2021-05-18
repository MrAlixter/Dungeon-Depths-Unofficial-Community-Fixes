Public Class CHBrunette
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Chameleon (Brunette)")
        MyBase.setUOC(True)
        MyBase.setcost(5)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser()

        p.savePState()

        Dim r As Integer = Int(Rnd() * 35) + 110

        Dim b As Integer = Int(Rnd() * 50)

        p.prt.haircolor = Color.FromArgb(p.prt.haircolor.A, r, 80, b)

        Game.pushLblEvent("CHAMELEON!  You now have brunette hair...")

        p.addLust(10)

        p.drawPort()
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Changes the user's appearance using an arousing energy imparted by a succubus."
    End Function
End Class
