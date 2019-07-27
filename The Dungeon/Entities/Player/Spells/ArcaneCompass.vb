Public Class ArcaneCompass
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        MyBase.setName("Arcane Compass")
        MyBase.setUOC(True)
        MyBase.settier(1)
        MyBase.setcost(5)
    End Sub
    Public Overrides Sub effect()
        Game.pushLblEvent("With a blinding flash, your magic cuts a glowing path straight to the stairs!")
        Dim p = Game.route(Game.player.pos, Game.stairs)
        For i = 0 To UBound(p)
            Game.mBoard(p(i).Y, p(i).X).Tag = 2
            If Game.mBoard(p(i).Y, p(i).X).Text = "" Then Game.mBoard(p(i).Y, p(i).X).Text = "x"
        Next

        Game.drawBoard()
    End Sub
End Class
