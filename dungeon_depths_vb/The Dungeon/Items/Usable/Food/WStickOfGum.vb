Public Class WStickOfGum
    Inherits Food

    Sub New()
        MyBase.setName("Melon_Stick_of_Gum")
        MyBase.setDesc("An pink piece of gum with a faint chemical smell.  Supposedly, it tastes like watermelon.  -10 Hunger")
        id = 132
        tier = 3
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 100
        setCalories(10)
    End Sub

    Overrides Sub effect()
        If Game.player1.perks(perk.bimbotf) = -1 Then
            Game.pushLblEvent("Chewing the gum causes a dizzy calm wash to over you.")
            Game.player1.ongoingTFs.Add(New WBimboTF(2, 5, 0.25, True))
            Game.player1.perks(perk.bimbotf) = 0
        ElseIf Game.player1.pClass.name.Equals("Bimbo") Then
            Game.pushLblEvent("Chewing the gum make your head feel warm and fuzzy and stuff. You like, totally, love this gum!")
        Else
            Game.pushLblEvent("Chewing the gum make your head feel warm and fuzzy.")
        End If
    End Sub
End Class
