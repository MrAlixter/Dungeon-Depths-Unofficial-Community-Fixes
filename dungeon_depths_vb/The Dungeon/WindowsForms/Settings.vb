Public Class Settings
    Dim ssize As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ssize = cboxScreenSize.Text
        Dim w As System.IO.StreamWriter
        w = System.IO.File.CreateText("sett.ing")
        w.WriteLine(ssize)
        w.WriteLine(chkNoImg.Checked)
        w.WriteLine(chkAlwaysUnwilling.Checked)
        w.WriteLine(chkNoRNG.Checked)
        w.WriteLine(chkOldSpellSpec.Checked)
        w.WriteLine(chkStartWithBooks.Checked)
        w.WriteLine(chkEoverSS.Checked)
        w.Flush()
        w.Close()
        Game.screenSize = ssize
        Game.noImg = chkNoImg.Checked
        Game.pcUnwilling = chkAlwaysUnwilling.Checked
        Game.noRNG = chkNoRNG.Checked
        Game.useOldSpellSpec = chkOldSpellSpec.Checked
        Game.startWithBooks = chkStartWithBooks.Checked
        Game.mobsOverrideSState = chkEoverSS.Checked
        Me.Close()
    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'scale to the screen size
        DDUtils.resizeForm(Me)

        Dim r As System.IO.StreamReader
        r = IO.File.OpenText("sett.ing")
        ssize = r.ReadLine
        chkNoImg.Checked = r.ReadLine
        chkAlwaysUnwilling.Checked = r.ReadLine
        chkNoRNG.Checked = r.ReadLine
        chkOldSpellSpec.Checked = r.ReadLine
        chkStartWithBooks.Checked = r.ReadLine
        chkEoverSS.Checked = r.ReadLine

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
    Shared Sub makeNewSetting()
        Dim w As System.IO.StreamWriter
        w = System.IO.File.CreateText("sett.ing")
        w.WriteLine("Large")
        w.WriteLine(False)
        w.WriteLine(False)
        w.WriteLine(False)
        w.WriteLine(True)
        w.WriteLine(True)
        w.WriteLine(True)
        w.Close()
    End Sub

    Private Sub cboxScreenSize_TextChanged(sender As Object, e As EventArgs) Handles cboxScreenSize.TextChanged
        If Not cboxScreenSize.Items.Contains(cboxScreenSize.Text) Then cboxScreenSize.Text = "Large"
        Button1.Focus()
    End Sub
End Class