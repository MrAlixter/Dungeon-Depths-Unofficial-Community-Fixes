Public Class Warp
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Warp")
        MyBase.setUOC(True)
        MyBase.settier(2)
        MyBase.setcost(9)
    End Sub
    Public Overrides Sub effect()
        If Game.player1.passDieRoll(40, 1) And Not mFloor.nonRandomFloors.Contains(Game.currFloor.floorNumber) Then
            backfire()
        Else
            If Game.combat_engaged Then
                MyBase.getTarget.despawn("warp")
                Game.updatable_queue.clear()
            Else
                TextEvent.push("With a flash of light, you teleport yourself at random to another portion of the dungeon.")
                Game.player1.pos = Game.currFloor.randPoint
            End If
        End If
    End Sub
    Public Overrides Sub backfire()
        If mFloor.nonRandomFloors.Contains(Game.currFloor.floorNumber) Then Exit Sub
        If Game.combat_engaged Then
            MyBase.getTarget.despawn("warp")
            Game.updatable_queue.clear()
        End If
        TextEvent.push("As you cast Warp, you can feel something go wrong." & DDUtils.RNRN &
                       "With a flash of light, a massive slowly growing tunnel spirals into being before you.  You try to run, but soon you find that you can not escape the pull of its void...", AddressOf gotospace)
    End Sub

    Public Shared Sub gotospace()
        Game.mDun.jumpTo(9999)
        Game.mDun.setFloor(Game.currFloor)
        Game.initializeBoard()
        TextEvent.push("Soon, you are spit back out into reality; though as you glance around you soon begin to doubt that." & DDUtils.RNRN &
                       "The subtle whir of machinery surrounds you, and you are not able to identify the smooth material that makes up the tiles of its floor.")
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 2 spell that teleports its user to another portion of the dungeon with a low chance of missing altogether and a very low chance of backfiring."
    End Function
End Class
