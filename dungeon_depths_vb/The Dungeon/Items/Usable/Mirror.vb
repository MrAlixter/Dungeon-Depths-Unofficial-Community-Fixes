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

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        If p.knownSpells.Contains("Self Polymorph") Then
            If MessageBox.Show("Do you want to cast Self Polymorph?", "Mirror", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then Spell.spellCast(Nothing, p, "Self Polymorph")
        Else
            Game.pushLstLog(p.description)

        End If
    End Sub
End Class
