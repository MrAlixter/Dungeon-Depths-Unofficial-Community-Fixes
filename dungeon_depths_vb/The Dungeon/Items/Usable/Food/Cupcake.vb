Public Class Cupcake
    Inherits Food
    Sub New()
        MyBase.setName("Cupcake")
        MyBase.setDesc("A 100% not magic totally not cursed cupcake. -50 Hunger")
        id = 35
        tier = 3
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 250
        setCalories(50)
    End Sub

    Public Overrides Sub Effect()
        Dim p As Player = Game.player1

        If p.perks(perk.cupcake) > 4 Or Game.noRNG Then
            p.ongoingTFs.Add(New LolitaSTF())
            p.update()
            p.perks(perk.cupcake) = -1
        ElseIf p.perks(perk.cupcake) = -1 Then
            p.perks(perk.cupcake) = 0
        Else
            p.perks(perk.cupcake) += 1
        End If
    End Sub
End Class
