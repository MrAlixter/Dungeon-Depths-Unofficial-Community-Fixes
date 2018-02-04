Public Class ManaCharm
    Inherits Item

    Sub New()
        MyBase.setName("Mana_Charm")
        MyBase.setDesc("A charm that slightly boosts your mana.")
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 750
    End Sub

    Overrides Sub use()
        If Me.getUsable() = False Then Exit Sub
        Form1.lstLog.Items.Add("You use the " & getName() & ". +5 Mana!")
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
        Form1.player.mBuff += 5
        Form1.player.mana += 5
        Form1.player.UIupdate()
        count -= 1
    End Sub
    Overrides Sub discard()
        Form1.lstLog.Items.Add("You drop the " & getName())
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
