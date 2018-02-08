Public Class Debug_Window
    Private Sub Debug_Window_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'GENERAL
        boxFloor.Text = Game.floor
        boxTurn.Text = Game.turn

        'PLAYER
        boxName.Text = Game.player.name
        boxSex.Items.Add("Male")
        boxSex.Items.Add("Female")
        If Game.player.sexBool Then
            boxSex.SelectedItem = "Female"
        Else
            boxSex.SelectedItem = "Male"
        End If
        For i = 0 To Game.titleList.Count - 1
            boxForm.Items.Add(Game.titleList(i).ToString())
        Next
        boxForm.SelectedItem = Game.player.title
    End Sub
End Class