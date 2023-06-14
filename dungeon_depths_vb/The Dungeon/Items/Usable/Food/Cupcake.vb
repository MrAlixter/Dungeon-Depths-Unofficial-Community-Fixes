Public Class Cupcake
    Inherits Food

    Public Const ITEM_NAME As String = "Cupcake"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 35
        tier = 3

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 592
        setCalories(50)

        '|Description|
        setDesc("A 100% not magic totally not cursed cupcake." & DDUtils.RNRN &
                "+50 Stamina")
    End Sub

    Public Overrides Sub effect(ByRef p As Player)
        If p.perks(perk.cupcake) > 4 Or Settings.active(setting.norng) And Not p.className.Equals("Maiden") Then
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
