Public Class TDn
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Tits Down")
        MyBase.setUOC(True)
        MyBase.setcost(5)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser()

        p.savePState()

        p.bs()
        p.lust += 10

        TextEvent.push("Tits Down!  Your breasts squeeze uncomfortably...")

        p.drawPort()
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Changes the user's appearance through the infernal dexterity of a succubus."
    End Function
End Class
