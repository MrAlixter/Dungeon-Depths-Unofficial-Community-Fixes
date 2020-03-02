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
        If Game.player.knownSpells.Contains("Self Polymorph") Then
            If MessageBox.Show("Do you want to cast Self Polymorph?", "Mirror", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then Spell.spellCast(Nothing, Game.player, "Self Polymorph")
        Else
            Game.pushLstLog(Game.player.description)

        End If
    End Sub
    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())
        
        count -= 1
    End Sub
End Class
