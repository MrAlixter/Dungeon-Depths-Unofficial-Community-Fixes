Public Class ZoomStep
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Zoom Step")
        MyBase.setUOC(True)
        MyBase.setcost(20)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget


        If Game.combat_engaged Then
            Dim dmg As Integer = Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)
            dmg += (p.getATK) + (p.equippedWeapon.getABoost(p))
            dmg = Entity.calcDamage(1.6 * dmg, m.getDEF)

            specHit(getName, dmg, getUser, getTarget)
        Else
            'this probably goes through some barriers and other non-wall unwalkable tiles.
            'not really intentional, but also not really getting patched by VHU because it's fun
            Dim new_pos = p.pos

            Select Case p.direction
                Case edir.up
                    For y = p.pos.Y To Math.Max(0, p.pos.Y - 10) Step -1
                        If Game.currFloor.mBoard(y, new_pos.X).Tag = DDConst.TILE_WALL Then
                            new_pos = New Point(new_pos.X, y + 1)
                            Exit For
                        Else
                            new_pos = New Point(new_pos.X, y)
                        End If
                    Next
                Case edir.down
                    For y = p.pos.Y To Math.Min(Game.currFloor.mBoardHeight - 1, p.pos.Y + 10)
                        If Game.currFloor.mBoard(y, new_pos.X).Tag = DDConst.TILE_WALL Then
                            new_pos = New Point(new_pos.X, y - 1)
                            Exit For
                        Else
                            new_pos = New Point(new_pos.X, y)
                        End If
                    Next
                Case edir.left
                    For x = p.pos.X To Math.Max(0, p.pos.X - 10) Step -1
                        If Game.currFloor.mBoard(new_pos.Y, x).Tag = DDConst.TILE_WALL Then
                            new_pos = New Point(x + 1, new_pos.Y)
                            Exit For
                        Else
                            new_pos = New Point(x, new_pos.Y)
                        End If
                    Next
                Case edir.right
                    For x = p.pos.X To Math.Min(Game.currFloor.mBoardWidth - 1, p.pos.X + 10)
                        If Game.currFloor.mBoard(new_pos.Y, x).Tag = DDConst.TILE_WALL Then
                            new_pos = New Point(x - 1, new_pos.Y)
                            Exit For
                        Else
                            new_pos = New Point(x, new_pos.Y)
                        End If
                    Next
            End Select

            p.pos = new_pos
            Game.drawBoard()

            p.stamina += getCost() / 2
        End If
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A step so zoom, it can even be used outside of combat to zip around.  In combat, it is guaranteed to hit first."
    End Function
End Class
