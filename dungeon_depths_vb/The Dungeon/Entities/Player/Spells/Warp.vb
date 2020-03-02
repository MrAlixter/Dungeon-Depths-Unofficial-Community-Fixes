Public Class Warp
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        MyBase.setName("Warp")
        MyBase.setUOC(True)
        MyBase.settier(3)
        MyBase.setcost(9)
    End Sub
    Public Overrides Sub effect()
        If Game.combatmode Then
            MyBase.getTarget.despawn("warp")
            Game.updateList = New PQ
        Else
            Game.pushLblEvent("With a flash of light, you teleport yourself at random to another portion of the dungeon.")
            Game.player.pos = Game.currfloor.randPoint
        End If
    End Sub
    Public Overrides Sub backfire()
        If Game.currFloor.floorNumber = 91017 Or Game.currFloor.floorNumber = 9999 Then Exit Sub
        If Game.combatmode Then
            MyBase.getTarget.despawn("warp")
            Game.updateList = New PQ
        End If
        Game.pushLblEvent("As you cast Warp, you can feel something go wrong.  Unlike past warps, which simply teleported you with a small flash of light, this casting of the spell has created a massive, slowly growing tunnel of sorts.  You try to run, but soon you find that you can not escape the pull of its void.", AddressOf gotospace)
    End Sub

    Public Shared Sub gotospace()
        Game.mDun.jumpTo(9999)
        Game.mDun.setFloor(Game.currFloor)
        Game.initializeBoard()
        Game.pushLblEvent("Soon, you are spit back out into reality, though as you glance around you soon begin to doubt that.  The subtle whir of machinery surrounds you, and you are not able to identify the smooth material that makes up the tiles of its floor.")
    End Sub
End Class
