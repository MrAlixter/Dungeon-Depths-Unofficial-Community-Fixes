Public Class StickOfGum
    Inherits Food

    Sub New()
        '|ID Info|
        setName("Stick_of_Gum")
        id = 1
        tier = 1

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 100
        setCalories(10)

        '|Description|

        setDesc("An ordinary looking piece of gum with a faint chemical smell." & DDUtils.RNRN &
                "+10 Stamina")

    End Sub

    Overrides Sub effect(ByRef p As Player)
        If p.perks(perk.bimbotf) = -1 Then
            TextEvent.push("Chewing the gum causes a dizzy calm wash to over you.")
            p.ongoingTFs.add(New BimboTF(2, 5, 0.25, True))
            p.perks(perk.bimbotf) = 0
        ElseIf p.className.Equals("Bimbo") Then
            TextEvent.push("Chewing the gum make your head feel warm and fuzzy and stuff. You like, totally, love this gum!")
        End If
    End Sub
End Class
