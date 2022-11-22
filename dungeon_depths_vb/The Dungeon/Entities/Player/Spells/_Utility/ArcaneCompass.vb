Public Class ArcaneCompass
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Arcane Compass")
        MyBase.setUOC(True)
        MyBase.settier(1)
        MyBase.setcost(5)
    End Sub
    Public Overrides Sub effect()
        If Game.mDun.numCurrFloor = 13 Then TextEvent.pushAndLog("With a blinding flash, your magic... fizzles into nothing...") : Exit Sub

        TextEvent.push("With a blinding flash, your magic cuts a glowing path straight to the stairs!")
        Dim p = Game.currFloor.route(Game.player1.pos, Game.currFloor.stairs)

        For i = 0 To UBound(p)
            Dim tileTag = Game.currFloor.mBoard(p(i).Y, p(i).X).Tag
            Dim tileText = Game.currFloor.mBoard(p(i).Y, p(i).X).Text

            tileTag = 2

            If tileText = "" Then Game.currFloor.mBoard(p(i).Y, p(i).X).Text = "x"
        Next

        Game.drawBoard()
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 1 spell that creates a glowing path to the nearest staircase."
    End Function
End Class
