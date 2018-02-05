Public Class Staff
    Inherits Weapon

    Sub New()
        MyBase.setName("Staff")
        MyBase.setDesc("A simple staff.")
        MyBase.setUsable(False)
        MyBase.aBoost = 0
        count = 0
        value = 100
    End Sub

    Overrides Sub discard()
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
