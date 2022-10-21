Public Class BrokenRemotePicker

    Private Sub BrokenRemotePicker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'scale to the screen size
        DDUtils.resizeForm(Me)

        Dim p = Game.player1

        For Each form In BrokenRemote.forms
            cboxRemoteForms.Items.Add(form.ToString)
        Next

        If cboxRemoteForms.Items.Contains(p.className) Then cboxRemoteForms.Items.Remove(p.className)
        If cboxRemoteForms.Items.Contains(p.formName) Then cboxRemoteForms.Items.Remove(p.formName)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If cboxRemoteForms.SelectedItem Is Nothing Then Exit Sub

        BrokenRemote.selectedForm = cboxRemoteForms.SelectedItem.ToString
        Me.Close()
    End Sub
End Class