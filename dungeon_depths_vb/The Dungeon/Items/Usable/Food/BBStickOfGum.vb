Public Class BBStickOfGum
    Inherits Food

    Sub New()
        '|ID Info|
        setName("Berry_Stick_of_Gum")
        id = 125
        tier = 3

        '|Item Flags|
        usable = true

        '|Stats|
        count = 0
        value = 100
        setCalories(10)

        '|Description|
        setDesc("An deep violet piece of gum with a faint chemical smell.  Supposedly, it tastes like blackberries. " & DDUtils.RNRN & "+10 Stamina")
    End Sub

    Overrides Sub effect(ByRef p As Player)
        If p.perks(perk.bimbotf) = -1 Then
            Game.pushLblEvent("Chewing the gum causes a dizzy calm wash to over you.")
            p.ongoingTFs.add(New BBBimboTF(2, 5, 0.25, True))
            p.perks(perk.bimbotf) = 0
        ElseIf Game.player1.className.Equals("Bimbo") Then
            Game.pushLblEvent("Chewing the gum make your head feel warm and fuzzy and stuff. You like, totally, love this gum!")
        Else
            Game.pushLblEvent("Chewing the gum make your head feel warm and fuzzy.")
        End If
    End Sub
End Class
