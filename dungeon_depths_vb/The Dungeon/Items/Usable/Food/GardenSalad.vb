Public Class GardenSalad
    Inherits Food

    Sub New()
        MyBase.setName("Garden_Salad")
        MyBase.setDesc("A leafy dish that has some degree of healing/mana restoration power.  While it seems healthy enough, the magic used to give it its regenerative powers was not performed by an expert, so it may be slightly unstable." & vbCrLf &
                       "-22 Hunger, Either +35 health or +14 mana")
        id = 117
        tier = Nothing
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 1999
        setCalories(22)
    End Sub
    Public Overrides Sub Effect()
        Dim p As Player = Game.player

        If Int(Rnd() * 2) = 0 Then
            p.health += 35 / p.getMaxHealth
            If p.health > 1 Then p.health = 1.0
            Game.pushLstLog("+35 health!")
        Else
            p.mana += 14
            If p.mana > p.getMaxMana Then p.mana = p.getMaxMana
            Game.pushLstLog("+14 mana!")
        End If

        If Int(Rnd() * 3) = 0 Or Game.noRNG Then
            p.ongoingTFs.Add(New PlantfolkTF())
        End If

        p.update()
    End Sub
End Class
