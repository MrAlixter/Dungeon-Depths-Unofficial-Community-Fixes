Public Class GardenSalad
    Inherits Food

    Sub New()
        '|ID Info|
        MyBase.setName("Garden_Salad")
        id = 117
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(True)

        '|Stats|
        MyBase.count = 0
        MyBase.value = 1999
        setCalories(22)

        '|Description|
        MyBase.setDesc("A leafy dish that has some degree of healing/mana restoration power.  While it seems healthy enough, the magic used to give it its regenerative powers was not performed by an expert, so it may be slightly unstable." & DDUtils.RNRN &
                       "+22 stamina" & vbCrLf &
                       "Either +50 health or +25 mana")
    End Sub
    Public Overrides Sub Effect()
        Dim p As Player = Game.player1

        If Int(Rnd() * 2) = 0 Then
            p.health += 50 / p.getMaxHealth
            If p.health > 1 Then p.health = 1.0
            Game.pushLstLog("+50 health!")
        Else
            p.mana += 25
            If p.mana > p.getMaxMana Then p.mana = p.getMaxMana
            Game.pushLstLog("+25 mana!")
        End If

        If Int(Rnd() * 3) = 0 Or Game.noRNG Then
            p.ongoingTFs.Add(New PlantfolkTF())
        End If

        p.update()
    End Sub
End Class
