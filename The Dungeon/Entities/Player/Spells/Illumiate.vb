Public Class Illumiate
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As Monster)
        MyBase.New(c, t)
        MyBase.setName("Illuminate")
        MyBase.setUOC(True)
        MyBase.settier(1)
        MyBase.setcost(2)
    End Sub
    Public Overrides Sub effect()
        For indY = -2 To 2
            For indX = -2 To 2
                If Game.player.pos.Y + indY < Game.mBoardHeight And Game.player.pos.Y + indY >= 0 And Game.player.pos.X + indX < Game.mBoardWidth And Game.player.pos.X + indX >= 0 Then
                    If Not (Game.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).Text = "H" Or Game.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).Text = "$" Or Game.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).Text = "#" Or Game.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).Text = "+") And Game.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).Tag < 2 Then
                        If Game.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).Tag = 1 Then Game.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).Tag = 2
                    End If
                End If
            Next
        Next
        Game.drawBoard()
    End Sub
End Class
