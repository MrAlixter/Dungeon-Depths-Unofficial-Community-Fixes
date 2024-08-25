Public Class SShroom
    Inherits Food

    Public Const ITEM_NAME As String = "Spatial_Shroom"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
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
        If Int(Rnd() * 2) = 0 And Not Settings.active(setting.norng) Or mFloor.nonRandomFloors.Contains(Game.currFloor.floorNumber) Then
            TextEvent.push("Disapointingly, nothing seems to have happened.")
        Else
            If p.passDieRoll(26, 1) Or Settings.active(setting.norng) Then
                If Game.combat_engaged Then
                    p.currTarget.despawn("pwarp")
                    Game.updatable_queue.clear()
                End If

                TextEvent.push("As you eat the mushroom, you can feel something... weird." & DDUtils.RNRN &
                               "With a flash of light, a massive slowly growing tunnel spirals into being before you.  You try to run, but soon you find that you can not escape the pull of its void...", AddressOf Warp.gotospace)
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
