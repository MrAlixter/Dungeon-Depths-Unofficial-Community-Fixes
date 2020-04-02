Public Class BBStickOfGum
    Inherits Food

    Sub New()
        MyBase.setName("Berry_Stick_of_Gum")
        MyBase.setDesc("An deep violet piece of gum with a faint chemical smell.  Supposedly, it tastes like blackberries.  -10 Hunger")
        id = 125
        tier = 3
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 100
        setCalories(10)
    End Sub

    Overrides Sub effect()
        If Game.player1.perks("bimbotf") = -1 Then
            Game.pushLblEvent("Chewing the gum causes a dizzy calm wash to over you.")
            Game.player1.ongoingTFs.Add(New BBBimboTF(2, 5, 0.25, True))
            Game.player1.perks("bimbotf") = 0
        ElseIf Game.player1.pClass.name.Equals("Bimbo") Then
            Game.pushLblEvent("Chewing the gum make your head feel warm and fuzzy and stuff. You like, totally, love this gum!")
        Else
            Game.pushLblEvent("Chewing the gum make your head feel warm and fuzzy.")
        End If
    End Sub
End Class
