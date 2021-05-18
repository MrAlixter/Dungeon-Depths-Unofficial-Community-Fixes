Public Class Cupcake
    Inherits Food
    Sub New()
        '|ID Info|
        setName("Cupcake")
        id = 35
        tier = 3

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 250
        setCalories(50)

        '|Description|
        setDesc("A 100% not magic totally not cursed cupcake. +50 Stamina")

    End Sub

    Public Overrides Sub effect(ByRef p As Player)
        If p.perks(perk.cupcake) > 4 Or Game.noRNG Then
            p.ongoingTFs.add(New LolitaSTF())
            p.update()
            p.perks(perk.cupcake) = -1
        ElseIf p.perks(perk.cupcake) = -1 Then
            p.perks(perk.cupcake) = 0
        Else
            p.perks(perk.cupcake) += 1
        End If
    End Sub
End Class
