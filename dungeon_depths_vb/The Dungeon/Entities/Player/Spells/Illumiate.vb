Public Class Illumiate
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        MyBase.setName("Illuminate")
        MyBase.setUOC(True)
        MyBase.settier(1)
        MyBase.setcost(3)
    End Sub
    Public Overrides Sub effect()
        For indY = -5 To 5
            For indX = -5 To 5
                If indY >= -3 And indY <= 3 And indX >= -3 And indX <= -3 Then
                    If Game.player.pos.Y + indY < Game.mBoardHeight And Game.player.pos.Y + indY >= 0 And Game.player.pos.X + indX < Game.mBoardWidth And Game.player.pos.X + indX >= 0 Then
                        If Not (Game.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).Text = "H" Or Game.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).Text = "$" Or Game.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).Text = "#" Or Game.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).Text = "+") And Game.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).Tag < 2 Then
                            If Game.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).Tag = 1 Then Game.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).Tag = 2
                        End If
                    End If
                End If

                If Game.player.pos.Y + indY < Game.mBoardHeight And Game.player.pos.Y + indY >= 0 And Game.player.pos.X + indX < Game.mBoardWidth And Game.player.pos.X + indX >= 0 Then
                    If Game.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).Text = "H" And Game.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).Tag < 2 Then
                        Game.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).ForeColor = Color.Black
                        If Game.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).Tag = 1 Then Game.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).Tag = 2
                        Game.pushLstLog("Floor " & Game.floor & ": Staircase Discovered")
                    End If
                    If Game.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).Text = "#" And Game.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).Tag < 2 Then
                        Game.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).ForeColor = Color.Black
                        If Game.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).Tag = 1 Then Game.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).Tag = 2
                        Game.pushLstLog("Chest discovered!")
                    End If
                    If Game.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).Text = "+" And Game.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).Tag < 2 Then
                        Game.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).ForeColor = Color.Navy
                        If Game.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).Tag = 1 Then Game.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).Tag = 2
                        Game.pushLstLog("Trap discovered!")
                    End If
                End If
            Next
        Next
        Game.drawBoard()
    End Sub
End Class
