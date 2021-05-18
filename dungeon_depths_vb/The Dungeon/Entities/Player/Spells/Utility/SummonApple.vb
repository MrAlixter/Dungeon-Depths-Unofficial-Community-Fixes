Public Class SummonApple
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Summon Apple")
        MyBase.setUOC(True)
        MyBase.settier(1)
        MyBase.setcost(9)
    End Sub
    Public Overrides Sub effect()
        Game.player1.inv.add("Apple", 1)

        Game.player1.UIupdate()

        Game.pushLogAndEvent("You summon a crisp red apple!")
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 1 spell that materializes an apple out of thin air."
    End Function
End Class
