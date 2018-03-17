Public Class EditTile
    Dim p As Point
    Dim t As mTile

    Public Sub SetLoc(_p As Point)
        p = _p
        Reload()
    End Sub

    Public Sub SetLoc(_x As Integer, _y As Integer)
        p = New Point(_x, _y)
        Reload()
    End Sub

    Private Sub Reload()
        t = Game.mBoard(p.Y, p.X)

        lblPosition.Text = "POSITION: " & p.X & ", " & p.Y
        lblText.Text = "TEXT: " & t.Text.ToString()
        lblCol.Text = "COL: " & t.ForeColor.ToString()

        boxOptions.Visible = False
        If (t.Tag = 2) Then 'Seen
            boxSeen.Checked = True
        ElseIf (t.Tag = 1) Then 'Unseen
            boxSeen.Checked = False
        Else 'WALL
            boxSeen.Enabled = False
        End If
        updateTagLbl()

        boxType.Items.Add("(Wall)")
        boxType.Items.Add("(Walkable)")
        boxType.Items.Add("# (Chest)")
        boxType.Items.Add("H (Stairs)")
        boxType.Items.Add("@ (Player)")
        boxType.Items.Add("@ (Statue)")
        boxType.Items.Add("$ (NPC)")
        'Temporarily removes handler so that the event doesn't trigger
        RemoveHandler boxType.SelectedIndexChanged, AddressOf boxType_SelectedIndexChanged
        If (t.Text = "#") Then 'Chest
            boxType.SelectedItem = "# (Chest)"
            boxType.Enabled = False
            boxOptions.Visible = True

            Dim btnEditContents As Button
            btnEditContents = New System.Windows.Forms.Button()
            boxOptions.Controls.Add(btnEditContents)
            btnEditContents.BackColor = System.Drawing.Color.Black
            btnEditContents.Location = New System.Drawing.Point(77, 32)
            btnEditContents.Name = "btnEditContents"
            btnEditContents.Size = New System.Drawing.Size(103, 48)
            btnEditContents.TabIndex = 0
            btnEditContents.Text = "Edit Contents"
            btnEditContents.UseVisualStyleBackColor = False
            AddHandler btnEditContents.Click, AddressOf btnEditContents_Clicked

        ElseIf (t.Text = "H") Then 'Stairs
            boxType.SelectedItem = "H (Stairs)"
            boxType.Enabled = False
            boxOptions.Visible = True
        ElseIf (t.Text = "@" And Game.player.pos.X = p.X And Game.player.pos.Y = p.Y) Then 'Player
            boxType.SelectedItem = "@ (Player)"
            boxType.Enabled = False
        ElseIf (t.Text = "@") Then 'Statue
            boxType.SelectedItem = "@ (Statue)"
            boxType.Enabled = False
        ElseIf (t.Text = "$") Then 'NPC
            boxType.SelectedItem = "$ (NPC)"
            boxType.Enabled = False
        ElseIf (t.Tag = 0) Then 'Wall
            boxType.SelectedItem = "(Wall)"
        Else 'Walkable
            boxType.SelectedItem = "(Walkable)"
        End If
        AddHandler boxType.SelectedIndexChanged, AddressOf boxType_SelectedIndexChanged


    End Sub

    Private Sub boxSeen_CheckedChanged(sender As Object, e As EventArgs) Handles boxSeen.CheckedChanged
        If t.Tag <> 0 Then
            If boxSeen.Checked Then
                t.Tag = 2
            Else
                t.Tag = 1
            End If
        End If
        updateTagLbl()
    End Sub

    Private Sub updateTagLbl()
        If t.Tag = 0 Then
            lblTag.Text = "TAG: 0 (WALL)"
        ElseIf t.Tag = 1 Then
            lblTag.Text = "TAG: 1 (UNSEEN)"
        ElseIf t.Tag = 2 Then
            lblTag.Text = "TAG: 2 (SEEN)"
        End If
    End Sub

    Private Sub boxType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles boxType.SelectedIndexChanged
        If boxType.SelectedItem.ToString() = "(Wall)" Then
            t.Tag = 0
            boxSeen.Enabled = False
            boxSeen.Checked = False
        ElseIf boxType.SelectedItem.ToString() = "(Walkable)" Then
            t.Tag = 1
            boxSeen.Enabled = True
            boxSeen.Checked = False
        Else
            MessageBox.Show("ERR: CURRENTLY NOT BUILD")
            boxType.SelectedItem = "(Wall)"
        End If
    End Sub

    Private Sub btnEditContents_Clicked(sender As Object, e As EventArgs)
        Dim ec As New EditContents(p)
        ec.ShowDialog()
    End Sub

    Private Sub EditTile_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim tag As Integer
        If Not boxSeen.Enabled Then
            tag = 0
        ElseIf boxSeen.Checked Then
            tag = 2
        ElseIf Not boxSeen.Checked Then
            tag = 1
        End If
        Game.mBoard(p.Y, p.X).Tag = tag
        Game.mBoard(p.Y, p.X).Text = t.Text
        Game.mBoard(p.Y, p.X).ForeColor = t.ForeColor
    End Sub
End Class