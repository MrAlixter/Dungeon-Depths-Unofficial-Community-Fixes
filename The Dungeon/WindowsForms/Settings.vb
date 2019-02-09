Public Class Settings
    Dim ssize As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ssize = cboxScreenSize.Text
        Dim w As System.IO.StreamWriter
        w = System.IO.File.CreateText("sett.ing")
        w.WriteLine(ssize)
        w.WriteLine(chkNoImg.Checked)
        w.Flush()
        w.Close()
        Game.screenSize = ssize
        Game.noImg = chkNoImg.Checked
        Me.Close()
    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'scale to the screen size
        Dim startingWidth = Me.Width
        Dim startingHeight = Me.Height
        If Game.screenSize = "Small" Then
            Size = New Size(Size.Width * 0.8, Size.Height * 0.8)
        ElseIf Game.screenSize = "Medium" Then
            Size = New Size(Size.Width * 0.9, Size.Height * 0.9)
        ElseIf Game.screenSize = "XLarge" Then
            Size = New Size(Size.Width * 1.3, Size.Height * 1.3)
        End If
        Dim RW As Double = (Me.Width - startingWidth) / startingWidth ' Ratio change of width
        Dim RH As Double = (Me.Height - startingHeight) / startingHeight ' Ratio change of height
        Dim newFont As Font = New System.Drawing.Font("Consolas", CInt(8 * Me.Size.Width / 180))
        For i = 0 To Me.Controls.Count - 1
            Me.Controls(i).Font = newFont
            Me.Controls(i).Width += CDbl(Me.Controls(i).Width * RW)
            Me.Controls(i).Height += CDbl(Me.Controls(i).Height * RH)
            Me.Controls(i).Left += CDbl(Me.Controls(i).Left * RW)
            Me.Controls(i).Top += CDbl(Me.Controls(i).Top * RH)
        Next

        Dim r As System.IO.StreamReader
        r = IO.File.OpenText("sett.ing")
        ssize = r.ReadLine
        chkNoImg.Checked = r.ReadLine

        r.Close()

        cboxScreenSize.Items.Add("Small")
        cboxScreenSize.Items.Add("Medium")
        cboxScreenSize.Items.Add("Large")
        cboxScreenSize.Items.Add("XLarge")
        'cboxScreenSize.Items.Add("Maximized")
        cboxScreenSize.Text = ssize
    End Sub

    Private Sub chkNoImg_CheckedChanged(sender As Object, e As EventArgs) Handles chkNoImg.CheckedChanged
        If chkNoImg.Checked Then
            Game.picPortrait.Visible = False
            Game.picDescPort.Visible = False
        Else
            Game.picPortrait.Visible = True
            Game.picDescPort.Visible = True
        End If
    End Sub

    Private Sub cboxScreenSize_TextChanged(sender As Object, e As EventArgs) Handles cboxScreenSize.TextChanged
        If Not cboxScreenSize.Items.Contains(cboxScreenSize.Text) Then cboxScreenSize.Text = "Large"
        Button1.Focus()
    End Sub
End Class