Public Class IncandEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Dim out = Game.lblEvent.Text.Split(vbCrLf)(0) & DDUtils.RNRN

        For indY = -7 To 7
            For indX = -7 To 7
                If p.pos.Y + indY < Game.currFloor.mBoardHeight And p.pos.Y + indY >= 0 And p.pos.X + indX < Game.currFloor.mBoardWidth And p.pos.X + indX >= 0 Then
                    If Game.currFloor.mBoard(p.pos.Y + indY, p.pos.X + indX).Text = "H" And Game.currFloor.mBoard(p.pos.Y + indY, p.pos.X + indX).Tag < DDConst.TILE_SEEN Then
                        Game.currFloor.mBoard(p.pos.Y + indY, p.pos.X + indX).ForeColor = Color.Black
                        TextEvent.pushLog("Floor " & Game.mDun.numCurrFloor & ": Staircase Discovered")
                    End If
                    If Game.currFloor.mBoard(p.pos.Y + indY, p.pos.X + indX).Text = "#" And Game.currFloor.mBoard(p.pos.Y + indY, p.pos.X + indX).Tag < DDConst.TILE_SEEN Then
                        Game.currFloor.mBoard(p.pos.Y + indY, p.pos.X + indX).ForeColor = Color.Black
                        TextEvent.pushLog("Chest discovered!")
                    End If
                    If Game.currFloor.mBoard(p.pos.Y + indY, p.pos.X + indX).Text = "$" And Game.currFloor.mBoard(p.pos.Y + indY, p.pos.X + indX).Tag < DDConst.TILE_SEEN Then
                        Game.currFloor.mBoard(p.pos.Y + indY, p.pos.X + indX).ForeColor = Color.Navy
                        TextEvent.pushLog("Shop discovered!")
                    End If
                    If Game.currFloor.mBoard(p.pos.Y + indY, p.pos.X + indX).Tag = DDConst.TILE_UNSEEN Then Game.currFloor.mBoard(p.pos.Y + indY, p.pos.X + indX).Tag = DDConst.TILE_SEEN
                End If
            Next
        Next

        p.perks(perk.lightsource) = 120

        out += "You begin to glow!"
        TextEvent.push(out)
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Incandescent effect"
    End Function
End Class
