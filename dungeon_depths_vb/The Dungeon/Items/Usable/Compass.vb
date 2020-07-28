Public Class Compass
    Inherits Item

    'The compass identifies where the stairs are.
    Sub New()
        MyBase.setName("Compass")
        MyBase.setDesc("A compass, used to find the stairs leading down to the next level.")
        id = 0
        tier = 1
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 150
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        Game.pushLstLog("You use the " & getName())

        Dim path = Game.currFloor.route(p.pos, Game.currFloor.stairs)
        For i = 0 To UBound(path) Step 4
            Game.currFloor.mBoard(path(i).Y, path(i).X).Tag = 2
            If Game.currFloor.mBoard(path(i).Y, path(i).X).Text = "" Then Game.currFloor.mBoard(path(i).Y, path(i).X).Text = "x"
        Next
        Game.currFloor.mBoard(path(UBound(path)).Y, path(UBound(path)).X).Tag = 2
        Game.drawBoard()
        count -= 1
    End Sub
End Class
