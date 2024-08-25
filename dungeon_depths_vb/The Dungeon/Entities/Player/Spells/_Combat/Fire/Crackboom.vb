Public Class Crackboom
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Crackboom")
        MyBase.settier(1)
        MyBase.setcost(22)
        MyBase.setUOC(True)

        can_be_reacted_to = False
    End Sub
    Public Overrides Sub effect()


        If Game.combat_engaged Then
            Dim dmg As Integer = 55
            Dim d31 = Int(Rnd() * 3)
            Dim d32 = Int(Rnd() * 3)

            dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, dmg + d31 + d32)
            getCaster.hit(dmg, getTarget, "", "blast")
        Else
            Dim p = getCaster()
            Dim board = Game.currFloor.mBoard
            Dim success As Boolean = False

            Select Case p.direction
                Case edir.up
                    If Game.currFloor.ptInBounds(New Point(p.pos.X, p.pos.Y - 1)) AndAlso board(p.pos.Y - 1, p.pos.X).Tag = DDConst.TILE_WALL Then
                        board(p.pos.Y - 1, p.pos.X).Tag = DDConst.TILE_SEEN
                        success = True
                    End If
                Case edir.down
                    If Game.currFloor.ptInBounds(New Point(p.pos.X, p.pos.Y + 1)) AndAlso board(p.pos.Y + 1, p.pos.X).Tag = DDConst.TILE_WALL Then
                        board(p.pos.Y + 1, p.pos.X).Tag = DDConst.TILE_SEEN
                        success = True
                    End If
                Case edir.left
                    If Game.currFloor.ptInBounds(New Point(p.pos.X - 1, p.pos.Y)) AndAlso board(p.pos.Y, p.pos.X - 1).Tag = DDConst.TILE_WALL Then
                        board(p.pos.Y, p.pos.X - 1).Tag = DDConst.TILE_SEEN
                        success = True
                    End If
                Case edir.right
                    If Game.currFloor.ptInBounds(New Point(p.pos.X + 1, p.pos.Y)) AndAlso board(p.pos.Y, p.pos.X + 1).Tag = DDConst.TILE_WALL Then
                        board(p.pos.Y, p.pos.X + 1).Tag = DDConst.TILE_SEEN
                        success = True
                    End If
            End Select

            If success Then
                TextEvent.pushLog("You blast through the wall in front of you!")
                Game.closeLblEvent()
                Game.drawBoard()
            Else
                TextEvent.fpushAndLog("You explode the air in front of you, but there isn't a wall to destroy...")
            End If

            If Not OutOfTime.canBreakWalls(p) Then OutOfTimeS3.alert(False)
        End If
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 1 offensive spell that deals a medium amount of magic damage.  It cannot be dodged or deflected." & DDUtils.RNRN &
               "Can be used outside of combat to destroy a wall."
    End Function
End Class
