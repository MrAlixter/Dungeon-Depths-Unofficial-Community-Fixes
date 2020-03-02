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

    Overrides Sub use()
        If Me.getUsable() = False Then Exit Sub
        Game.pushLstLog("You use the " & getName())
        
        Dim p = Game.route(Game.player.pos, Game.stairs)
        For i = 0 To UBound(p) Step 4
            Game.mBoard(p(i).Y, p(i).X).Tag = 2
            If Game.mBoard(p(i).Y, p(i).X).Text = "" Then Game.mBoard(p(i).Y, p(i).X).Text = "x"
        Next
        Game.mBoard(p(UBound(p)).Y, p(UBound(p)).X).Tag = 2
        Game.drawBoard()
        count -= 1
    End Sub
    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())
        
        count -= 1
    End Sub
End Class
