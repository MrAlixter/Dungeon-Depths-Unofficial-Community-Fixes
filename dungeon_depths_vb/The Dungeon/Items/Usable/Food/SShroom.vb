Public Class SShroom
    Inherits Food
    'Apple is a food item that reduces stamina by 15
    Sub New()
        '|ID Info|
        setName("Spatial_Shroom")
        id = 108
        tier = 1

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 150
        setCalories(15)

        '|Description|
        setDesc("An small white mushroom that gives off a subtle white glow.  Rumor has it that eating one has the potential to disrupt time and space." & DDUtils.RNRN &
                "+25 Stamina.")

    End Sub

    Public Overrides Sub effect(ByRef p As Player)
        If Int(Rnd() * 2) = 0 And Not Game.noRNG Or (Game.currFloor.floorNumber = 91017 Or Game.currFloor.floorNumber = 9999) Then
            TextEvent.push("Disapointingly, nothing seems to have happened.")
        Else
            If Int(Rnd() * 7) = 0 Or Game.noRNG Then
                If Game.combat_engaged Then
                    p.currTarget.despawn("pwarp")
                    Game.updatable_queue.clear()
                End If
                TextEvent.push("As you eat the mushroom, you can feel something... weird.  Unlike the simple teleports of past experiences, this time a massive, slowly growing tunnel of sorts has opened up in front of you.  You try to run, but soon you find that you can not escape the pull of its void.", AddressOf Warp.gotospace)
            Else
                If Game.combat_engaged Then
                    p.currTarget.despawn("pwarp")
                    Game.updatable_queue.clear()
                End If
                TextEvent.push("With a flash of light, you suddenly find yourself at random to another portion of the dungeon.")
                Game.player1.pos = Game.currFloor.randPoint
            End If
        End If
    End Sub
End Class
