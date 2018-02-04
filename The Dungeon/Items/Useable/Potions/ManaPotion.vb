Public Class ManaPotion
    Inherits Item

    Sub New()
        MyBase.setName("Mana_Potion")
        MyBase.setDesc("A normal, everyday mana potion.")
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 150
    End Sub

    Overrides Sub use()
        If Me.getUsable() = False Then Exit Sub
        Form1.lstLog.Items.Add("You drink the " & getName())
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
        Form1.player.mana += 25
        If Form1.player.mana > Form1.player.getmaxMana Then Form1.player.mana = Form1.player.getmaxMana
        count -= 1
    End Sub
    Overrides Sub discard()
        Form1.lstLog.Items.Add("You drop the " & getName())
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
