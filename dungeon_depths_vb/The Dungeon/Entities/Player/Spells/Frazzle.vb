Public Class Frazzle
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        MyBase.setName("Frazzle")
        MyBase.setUOC(True)
        MyBase.settier(1)
        MyBase.setcost(0)
    End Sub
    Public Overrides Sub effect()
        Game.pushLogAndEvent("Something isn't right, and whatever you tried to cast fizzled into nothing.")
    End Sub
End Class
