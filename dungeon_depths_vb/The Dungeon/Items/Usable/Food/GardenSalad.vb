Public Class GardenSalad
    Inherits Food

    Sub New()
        '|ID Info|
        setName("Garden_Salad")
        id = 117
        tier = Nothing

        '|Item Flags|
        usable = true

        '|Stats|
        count = 0
        value = 1999
        setCalories(22)

        '|Description|
        setDesc("A leafy dish that has some degree of healing/mana restoration power.  While it seems healthy enough, the magic used to give it its regenerative powers was not performed by an expert, so it may be slightly unstable." & DDUtils.RNRN &
                "+22 stamina" & DDUtils.RNRN &
                "Either +50 health or +25 mana")
    End Sub
    Public Overrides Sub effect(ByRef p As Player)
        If Int(Rnd() * 2) = 0 Then
            p.health += 50 / p.getMaxHealth
            If p.health > 1 Then p.health = 1.0
            TextEvent.pushLog("+50 health!")
        Else
            p.mana += 25
            If p.mana > p.getMaxMana Then p.mana = p.getMaxMana
            TextEvent.pushLog("+25 mana!")
        End If

        If Int(Rnd() * 3) = 0 Or Game.noRNG Then
            p.ongoingTFs.add(New PlantfolkTF())
        End If

        p.update()
    End Sub
End Class
