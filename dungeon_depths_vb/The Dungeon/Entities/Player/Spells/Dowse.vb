Public Class Dowse
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        MyBase.setName("Dowse")
        MyBase.setUOC(True)
        MyBase.settier(1)
        MyBase.setcost(2)
    End Sub
    Public Overrides Sub effect()
        For indY = -5 To 5
            For indX = -5 To 5
                If Game.player1.pos.Y + indY < Game.mBoardHeight And Game.player1.pos.Y + indY >= 0 And Game.player1.pos.X + indX < Game.mBoardWidth And Game.player1.pos.X + indX >= 0 Then
                    If Game.currfloor.mBoard(Game.player1.pos.Y + indY, Game.player1.pos.X + indX).Text = "H" And Game.currfloor.mBoard(Game.player1.pos.Y + indY, Game.player1.pos.X + indX).Tag < 2 Then
                        Game.currfloor.mBoard(Game.player1.pos.Y + indY, Game.player1.pos.X + indX).ForeColor = Color.Black
                        If Game.currfloor.mBoard(Game.player1.pos.Y + indY, Game.player1.pos.X + indX).Tag = 1 Then Game.currfloor.mBoard(Game.player1.pos.Y + indY, Game.player1.pos.X + indX).Tag = 2
                        Game.pushLstLog("Floor " & game.mDun.numCurrFloor & ": Staircase Discovered")
                    End If
                    If Game.currfloor.mBoard(Game.player1.pos.Y + indY, Game.player1.pos.X + indX).Text = "#" And Game.currfloor.mBoard(Game.player1.pos.Y + indY, Game.player1.pos.X + indX).Tag < 2 Then
                        Game.currfloor.mBoard(Game.player1.pos.Y + indY, Game.player1.pos.X + indX).ForeColor = Color.Black
                        If Game.currfloor.mBoard(Game.player1.pos.Y + indY, Game.player1.pos.X + indX).Tag = 1 Then Game.currfloor.mBoard(Game.player1.pos.Y + indY, Game.player1.pos.X + indX).Tag = 2
                        Game.pushLstLog("Chest discovered!")
                    End If
                    If Game.currfloor.mBoard(Game.player1.pos.Y + indY, Game.player1.pos.X + indX).Text = "+" And Game.currfloor.mBoard(Game.player1.pos.Y + indY, Game.player1.pos.X + indX).Tag < 2 Then
                        Game.currfloor.mBoard(Game.player1.pos.Y + indY, Game.player1.pos.X + indX).ForeColor = Color.Navy
                        If Game.currfloor.mBoard(Game.player1.pos.Y + indY, Game.player1.pos.X + indX).Tag = 1 Then Game.currfloor.mBoard(Game.player1.pos.Y + indY, Game.player1.pos.X + indX).Tag = 2
                        Game.pushLstLog("Trap discovered!")
                    End If
                End If
            Next
        Next
        Game.drawBoard()
    End Sub
End Class
