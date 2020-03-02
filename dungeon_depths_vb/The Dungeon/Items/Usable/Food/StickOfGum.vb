Public Class StickOfGum
    Inherits Food

    Sub New()
        MyBase.setName("Stick_of_Gum")
        MyBase.setDesc("An ordinary looking piece of gum with a faint chemical smell. -10 Hunger")
        id = 1
        tier = 1
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 100
        setCalories(10)
    End Sub

    Overrides Sub effect()
            If Game.player.perks("bimbotf") = -1 Then
                Game.pushLblEvent("Chewing the gum causes a dizzy calm wash to over you.")
                Game.player.ongoingTFs.Add(New BimboTF(2, 5, 0.25, True))
                Game.player.perks("bimbotf") = 0
            ElseIf Game.player.pClass.name.Equals("Bimbo") Then
                Game.pushLblEvent("Chewing the gum make your head feel warm and fuzzy and stuff. You like, totally, love this gum!")
            End If
    End Sub
End Class
