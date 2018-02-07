Public Class VialOfSlime
    Inherits Item
    Sub New()
        MyBase.setName("Vial_of_Slime")
        MyBase.setDesc("A glass bottle filled with an aquamarine non-newtonian gel.")
        id = 3
        tier = 1
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 100
    End Sub

    Overrides Sub use()
        If Me.getUsable() = False Then Exit Sub
        Game.lstLog.Items.Add("You apply the " & getName())
        Polymorph.transform(Game.player, "slime", 0)
        count -= 1
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Overrides Sub discard()
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
