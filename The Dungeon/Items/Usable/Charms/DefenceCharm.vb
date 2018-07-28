Public Class DefenceCharm
    Inherits Item

    Sub New()
        MyBase.setName("Defence_Charm")
        MyBase.setDesc("A charm that slightly boosts your defence.")
        id = 51
        tier = 2
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 750
    End Sub

    Overrides Sub use()
        If Me.getUsable() = False Then Exit Sub
        Game.lstLog.Items.Add("You use the " & getName() & ". +5 base DEF!")
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        Game.player.defence += 5
        Game.player.UIupdate()
        count -= 1
    End Sub
    Overrides Sub discard()
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
