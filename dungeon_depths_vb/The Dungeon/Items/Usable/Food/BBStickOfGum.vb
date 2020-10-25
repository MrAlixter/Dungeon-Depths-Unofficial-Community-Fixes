Public Class BBStickOfGum
    Inherits Food

    Sub New()
        '|ID Info|
        MyBase.setName("Berry_Stick_of_Gum")
        id = 125
        tier = 3

        '|Item Flags|
        MyBase.setUsable(True)

        '|Stats|
        MyBase.count = 0
        MyBase.value = 100
        setCalories(10)

        '|Description|
        MyBase.setDesc("An deep violet piece of gum with a faint chemical smell.  Supposedly, it tastes like blackberries. " & DDUtils.RNRN & "+10 Stamina")
    End Sub

    Overrides Sub effect()
        If Game.player1.perks(perk.bimbotf) = -1 Then
            Game.pushLblEvent("Chewing the gum causes a dizzy calm wash to over you.")
            Game.player1.ongoingTFs.Add(New BBBimboTF(2, 5, 0.25, True))
            Game.player1.perks(perk.bimbotf) = 0
        ElseIf Game.player1.className.Equals("Bimbo") Then
            Game.pushLblEvent("Chewing the gum make your head feel warm and fuzzy and stuff. You like, totally, love this gum!")
        Else
            Game.pushLblEvent("Chewing the gum make your head feel warm and fuzzy.")
        End If
    End Sub
End Class
