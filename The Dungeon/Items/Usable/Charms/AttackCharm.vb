Public Class AttackCharm
    Inherits Item
    'AttackCharms are useable items that permenantly boost player attack by 2
    Sub New()
        MyBase.setName("Attack_Charm")
        MyBase.setDesc("A charm that slightly boosts your attack.")
        id = 50
        tier = 2
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 750
    End Sub

    Overrides Sub use()
        If Me.getUsable() = False Then Exit Sub
        Game.lstLog.Items.Add("You use the " & getName() & ". +5 base ATK!")
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        Game.player.attack += 5
        Game.player.UIupdate()
        count -= 1
    End Sub
    Overrides Sub discard()
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
