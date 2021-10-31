Public Class MStickOfGum
    Inherits Food

    Sub New()
        setName("Mint_Stick_of_Gum")
        setDesc("An pale blue piece of gum with a faint chemical smell.  Supposedly, it tastes like mint.  +10 Stamina")
        id = 109
        tier = 3
        usable = true
        count = 0
        value = 100
        setCalories(10)
    End Sub

    Overrides Sub effect(ByRef p As Player)
        If p.perks(perk.bimbotf) = -1 Then
            TextEvent.push("Chewing the gum causes a dizzy calm wash to over you.")
            p.ongoingTFs.add(New MBimboTF(2, 5, 0.25, True))
            p.perks(perk.bimbotf) = 0
        ElseIf p.className.Equals("Bimbo") Then
            TextEvent.push("Chewing the gum make your head feel warm and fuzzy and stuff. You like, totally, love this gum!")
        Else
            TextEvent.push("Chewing the gum make your head feel warm and fuzzy.")
        End If
    End Sub
End Class
