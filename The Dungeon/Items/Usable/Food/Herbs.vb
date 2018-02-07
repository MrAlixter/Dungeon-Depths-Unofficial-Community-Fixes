Public Class Herbs
    Inherits Food

    Sub New()
        MyBase.setName("Medicinal_Tea")
        MyBase.setDesc("A bitter tea that restores health. -15 Hunger, +50 Health")
        id = 33
        tier = 2
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 275
        setCalories(15)
    End Sub

    Public Overrides Sub Effect()
        Game.player.health += 50
        If Game.player.health > Game.player.getmaxHealth Then Game.player.health = Game.player.getmaxHealth
    End Sub
End Class
