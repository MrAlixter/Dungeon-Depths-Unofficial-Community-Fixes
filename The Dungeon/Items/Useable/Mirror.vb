Public Class Mirror
    Inherits Item
    Sub New()
        MyBase.setName("Mirror")
        MyBase.setDesc("A shiny mirror that could bounce a spell back at its caster.")
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 300
    End Sub

    Overrides Sub use()
        If Me.getUsable() = False Then Exit Sub
        If Form1.cboxMG.Items.Contains("Self Polymorph") Then
            If MessageBox.Show("Do you want to cast Self Polymorph?", "Mirror", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then Spells.SelfPolymorph(Form1.player)
        Else
            Form1.lstLog.Items.Add(Form1.player.description)
            Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
        End If
    End Sub
    Overrides Sub discard()
        Form1.lstLog.Items.Add("You drop the " & getName())
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
