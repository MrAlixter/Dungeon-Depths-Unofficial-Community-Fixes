Public Class CHNeon
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Chameleon (Neon)")
        MyBase.setUOC(True)
        MyBase.setcost(5)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser()

        p.savePState()

        Dim colors = {Color.Aqua, Color.Chartreuse, Color.Crimson, Color.Magenta, Color.Lime, Color.OrangeRed, Color.SpringGreen}

        p.prt.haircolor = colors(Int(Rnd() * colors.Length))

        TextEvent.push("CHAMELEON!  You now have neon hair...")

        p.addLust(10)

        p.drawPort()
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Changes the user's appearance using an arousing energy imparted by a succubus."
    End Function
End Class
