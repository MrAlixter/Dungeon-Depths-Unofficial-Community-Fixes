Public Class CHPastels
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Chameleon (Pastels)")
        MyBase.setUOC(True)
        MyBase.setcost(5)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser()

        p.savePState()

        Dim colors = {Color.LightSkyBlue, Color.PaleGreen, Color.Pink, Color.Plum, Color.LightGreen, Color.MistyRose, Color.Aquamarine}

        p.prt.haircolor = colors(Int(Rnd() * colors.Length))

        Game.pushLblEvent("CHAMELEON!  You now have pastel hair...")

        p.addLust(10)

        p.drawPort()
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Changes the user's appearance using an arousing energy imparted by a succubus."
    End Function
End Class
