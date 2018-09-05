Public Class Frazzle
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As Monster)
        MyBase.New(c, t)
        MyBase.setName("Frazzle")
        MyBase.setUOC(True)
        MyBase.settier(1)
        MyBase.setcost(0)
    End Sub
    Public Overrides Sub effect()
        Game.lstLog.Items.Add("Whatever you tried to cast fizzled into nothing.")
        Game.pushLblEvent("Something isn't right, and whatever you tried to cast fizzled into nothing.")
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
End Class
