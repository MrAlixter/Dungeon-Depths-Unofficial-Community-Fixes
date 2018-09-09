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
        If Game.player.pClass.name.Equals("Magic Girl") Then
            Polymorph.bimboTF(Game.player, 2)
        Else
            Game.player.perks("bimbotf") = 0
        End If
    End Sub
End Class
