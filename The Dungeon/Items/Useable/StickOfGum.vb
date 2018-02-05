Public Class StickOfGum
    Inherits Food

    Sub New()
        MyBase.setName("Stick_of_Gum")
        MyBase.setDesc("An ordinary looking piece of gum with a faint chemical smell. -10 Hunger")
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 100
        setCalories(10)
    End Sub

    Overrides Sub effect()
        Game.player.perks(1) = True
    End Sub
End Class
