Public Class HealthPotion
    Inherits Item

    Sub New()
        MyBase.setName("Health_Potion")
        MyBase.setDesc("A normal, everyday health potion. +75 Health")
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 100
    End Sub

    Overrides Sub use()
        If Me.getUsable() = False Then Exit Sub
        Form1.lstLog.Items.Add("You drink the " & getName())
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
        Form1.player.health += 75
        If Form1.player.health > Form1.player.getmaxHealth Then Form1.player.health = Form1.player.getmaxHealth
        count -= 1
    End Sub
    Overrides Sub discard()
        Form1.lstLog.Items.Add("You drop the " & getName())
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
