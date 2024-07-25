Public Class PowerDrill
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Power Drill")
        MyBase.setUOC(True)
        MyBase.setcost(30)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget

        If Not p.equippedWeapon.GetType().IsSubclassOf(GetType(Spear)) Then
            TextEvent.fpushAndLog("...but you don't have a spear equipped.")

            p.stamina += getCost()
            Exit Sub
        End If

        If Game.combat_engaged Then
            Dim dmg As Integer = Int(Rnd() * 2 + 1) + Int(Rnd() * 2 + 1) + Int(Rnd() * 2 + 1) + Int(Rnd() * 2 + 1) + Int(Rnd() * 2 + 1) + Int(Rnd() * 2 + 1)
            dmg += (p.getATK) + (p.equippedWeapon.getABoost(p))
            dmg = Entity.calcDamage(dmg, 0)

            specHit(getName, dmg, getUser, getTarget)
        Else
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
                TextEvent.pushLog("You cut through the wall in front of you!")
                Game.closeLblEvent()
                Game.drawBoard()
            Else
                TextEvent.fpushAndLog("Your drill spins through the air in front of you, but there isn't anything to cut...")
                p.stamina += getCost() - 5
            End If
        End If
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "If used in combat, strikes with a spinning attack that ignores defense.  If used outside of combat, destroys a single adjacent wall block.  Cannot be used if a spear is not equipped."
    End Function
End Class
