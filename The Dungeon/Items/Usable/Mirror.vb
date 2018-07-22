Public Class Mirror
    Inherits Item
    Sub New()
        MyBase.setName("Mirror")
        MyBase.setDesc("A shiny mirror that could bounce a spell back at its caster.")
        id = 36
        tier = 2
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 300
    End Sub

    Overrides Sub use()
        If Me.getUsable() = False Then Exit Sub
        If Game.cboxMG.Items.Contains("Self Polymorph") Then
            If MessageBox.Show("Do you want to cast Self Polymorph?", "Mirror", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then Spell.spellCast(Game.player.currTarget, Game.player, "Self Polymorph")
        Else
            Game.lstLog.Items.Add(Game.player.description)
            Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        End If
    End Sub
    Overrides Sub discard()
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
