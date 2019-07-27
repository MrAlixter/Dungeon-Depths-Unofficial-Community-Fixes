Public Class MajorHeal
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        MyBase.setName("Major Heal")
        MyBase.setUOC(True)
        MyBase.settier(1)
        MyBase.setcost(5)
    End Sub
    Public Overrides Sub effect()
        Dim hdif = 100 / Game.player.getMaxHealth
        If Game.player.health + hdif >= Game.player.getmaxHealth Then hdif = 1 - Game.player.health

        Game.player.health += hdif

        Game.pushLstLog("You heal yourself for " & hdif * Game.player.getmaxHealth & " health!")
        Game.pushLblEvent("You heal yourself for " & hdif * Game.player.getmaxHealth & " health!")

    End Sub
End Class
