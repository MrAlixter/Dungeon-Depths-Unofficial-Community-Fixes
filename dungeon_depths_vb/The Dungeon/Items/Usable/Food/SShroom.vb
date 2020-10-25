Public Class SShroom
    Inherits Food
    'Apple is a food item that reduces stamina by 15
    Sub New()
        MyBase.setName("Spatial_Shroom")
        MyBase.setDesc("An small white mushroom that gives off a subtle white glow.  Rumor has it that eating one has the potential to disrupt time and space. +25 Stamina.")
        id = 108
        tier = 1
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 150
        setCalories(15)
    End Sub

    Public Overrides Sub Effect()
        If Int(Rnd() * 2) = 0 And Not Game.noRNG Or (Game.currFloor.floorNumber = 91017 Or Game.currFloor.floorNumber = 9999) Then
            Game.pushLblEvent("Disapointingly, nothing seems to have happened.")
        Else
            If Int(Rnd() * 7) = 0 Or Game.noRNG Then
                If Game.combatmode Then
                    Game.player1.currTarget.despawn("pwarp")
                    Game.updateList = New PQ
                End If
                Game.pushLblEvent("As you eat the mushroom, you can feel something...weird.  Unlike the simple teleports of past experiences, this time a massive, slowly growing tunnel of sorts has opened up in front of you.  You try to run, but soon you find that you can not escape the pull of its void.", AddressOf Warp.gotospace)
            Else
                If Game.combatmode Then
                    Game.player1.currTarget.despawn("pwarp")
                    Game.updateList = New PQ
                End If
                Game.pushLblEvent("With a flash of light, you suddenly find yourself at random to another portion of the dungeon.")
                Game.player1.pos = Game.currFloor.randPoint
            End If
        End If
    End Sub
End Class
