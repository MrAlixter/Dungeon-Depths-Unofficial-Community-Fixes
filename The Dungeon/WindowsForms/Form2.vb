Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Form2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If (ComboBox1.Text <> "Male" And ComboBox1.Text <> "Female") Or (ComboBox2.Text <> "Warrior" And ComboBox2.Text <> "Mage") Then
            If MessageBox.Show("Woah there buddy! One of your choices was a bit of a write in, eh?  You sure you want to do that?", "Sneeky sneek", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If
        Form1.player.name = TextBox1.Text
        Form1.player.sex = ComboBox1.Text
        Form1.player.setClass(ComboBox2.Text)
    End Sub
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("Male")
        ComboBox1.Items.Add("Female")
        ComboBox2.Items.Add("Warrior")
        ComboBox2.Items.Add("Mage")
        Dim newFont As Font = New System.Drawing.Font("Consolas", CInt(8 * Me.Size.Width / 198))
        For i = 0 To Me.Controls.Count - 1
            Me.Controls(i).Font = newFont
        Next
    End Sub
End Class