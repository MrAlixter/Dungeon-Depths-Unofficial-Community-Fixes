Public Class Heal
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As Monster)
        MyBase.New(c, t)
        MyBase.setName("Heal")
        MyBase.setUOC(True)
        MyBase.settier(1)
        MyBase.setcost(3)
    End Sub
    Public Overrides Sub effect()
        Dim hdif = 50
        If Game.player.health >= Game.player.getmaxHealth Then hdif = Game.player.getmaxHealth - Game.player.health

        Game.player.health += hdif

        Game.lstLog.Items.Add("You heal yourself for " & hdif & " health!")
        Game.pushLblEvent("You heal yourself for " & hdif & " health!")
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
End Class
