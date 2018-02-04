Public Class Herbs
    Inherits Food

    Sub New()
        MyBase.setName("Medicinal_Tea")
        MyBase.setDesc("A bitter tea that restores health. -15 Hunger, +50 Health")
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 275
        setCalories(15)
    End Sub

    Public Overrides Sub Effect()
        Form1.player.health += 50
        If Form1.player.health > Form1.player.getmaxHealth Then Form1.player.health = Form1.player.getmaxHealth
    End Sub
End Class
