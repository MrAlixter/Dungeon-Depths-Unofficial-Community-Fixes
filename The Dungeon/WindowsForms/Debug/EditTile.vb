Public Class EditTile
    Dim p As Point
    Dim t As mTile
    Dim prevTypeSel

    Public Sub SetLoc(_p As Point)
        p = _p
        Reload()
    End Sub

    Public Sub SetLoc(_x As Integer, _y As Integer)
        p = New Point(_x, _y)
        Reload()
    End Sub

    Private Sub Update()
        Reload()
        Debug_Window.refreshMap()
        Game.zoom()
    End Sub

    Private Sub Reload()
        t = Game.mBoard(p.Y, p.X)

        lblPosition.Text = "POSITION: " & p.X & ", " & p.Y
        lblText.Text = "TEXT: " & t.Text.ToString()
        lblColTxt.Text = t.ForeColor.ToString()

        boxOptions.Visible = False
        boxOptions.Controls.Clear()
        boxSeen.Enabled = True
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
        boxType.Items.Add("+ (Trap)")
        'Temporarily removes handler so that the event doesn't trigger
        RemoveHandler boxType.SelectedIndexChanged, AddressOf boxType_SelectedIndexChanged
        If (t.Text = "#") Then 'Chest
            boxType.SelectedItem = "# (Chest)"
            boxType.Enabled = True
            boxOptions.Visible = True

            Dim btnEditContents As Button
            btnEditContents = New System.Windows.Forms.Button()
            boxOptions.Controls.Add(btnEditContents)
            btnEditContents.BackColor = System.Drawing.Color.Black
            btnEditContents.Location = New System.Drawing.Point(25, 32)
            btnEditContents.Name = "btnEditContents"
            btnEditContents.Size = New System.Drawing.Size(103, 48)
            btnEditContents.TabIndex = 0
            btnEditContents.Text = "Edit Contents"
            btnEditContents.UseVisualStyleBackColor = False
            AddHandler btnEditContents.Click, AddressOf btnEditContents_Clicked

            addMoveButton(boxOptions.Controls.Count)
        ElseIf (t.Text = "H") Then 'Stairs
            boxType.SelectedItem = "H (Stairs)"
            boxType.Enabled = False
            boxOptions.Visible = True
            addMoveButton(boxOptions.Controls.Count)
        ElseIf (t.Text = "@" And Game.player.pos.X = p.X And Game.player.pos.Y = p.Y) Then 'Player
            boxType.SelectedItem = "@ (Player)"
            boxType.Enabled = False
            boxOptions.Visible = True
            addMoveButton(boxOptions.Controls.Count)
        ElseIf (t.Text = "@") Then 'Statue
            boxType.SelectedItem = "@ (Statue)"
            boxType.Enabled = False
            boxOptions.Visible = True
            addMoveButton(boxOptions.Controls.Count)
        ElseIf (t.Text = "$") Then 'NPC
            boxType.SelectedItem = "$ (NPC)"
            boxType.Enabled = False
            boxOptions.Visible = True
            addMoveButton(boxOptions.Controls.Count)
        ElseIf (t.Text = "+") Then 'Trap
            boxType.SelectedItem = "+ (Trap)"
            boxType.Enabled = False
            boxOptions.Visible = True
            addMoveButton(boxOptions.Controls.Count)
        ElseIf (t.Tag = 0) Then 'Wall
            boxType.SelectedItem = "(Wall)"
        Else 'Walkable
            boxType.SelectedItem = "(Walkable)"
        End If
        prevTypeSel = boxType.SelectedItem
        AddHandler boxType.SelectedIndexChanged, AddressOf boxType_SelectedIndexChanged


    End Sub

    Private Sub addMoveButton(Optional others As Integer = 0)
        Dim btnMove As Button
        btnMove = New System.Windows.Forms.Button()
        boxOptions.Controls.Add(btnMove)
        btnMove.BackColor = System.Drawing.Color.Black
        If others = 0 Then
            btnMove.Location = New System.Drawing.Point(77, 32)
        ElseIf others = 1 Then
            btnMove.Location = New System.Drawing.Point(129, 32)
        End If

        btnMove.Name = "btnMove"
        btnMove.Size = New System.Drawing.Size(103, 48)
        btnMove.TabIndex = 0
        btnMove.Text = "Move"
        btnMove.UseVisualStyleBackColor = False
        AddHandler btnMove.Click, AddressOf btnMove_Clicked
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
            If prevTypeSel = "# (Chest)" Then
                removeChest()
            End If
            t.Tag = 0
            t.Text = ""
            t.ForeColor = Color.Black
            boxSeen.Enabled = False
            boxSeen.Checked = False
        ElseIf boxType.SelectedItem.ToString() = "(Walkable)" Then
            If prevTypeSel = "# (Chest)" Then
                removeChest()
            End If
            If t.Tag = 0 Then
                t.Tag = 1
            End If
            t.Text = ""
            t.ForeColor = Color.Black
            boxSeen.Enabled = True
            boxSeen.Checked = False
        Else
            If prevTypeSel = "(Wall)" Or prevTypeSel = "(Walkable)" Then
                If boxType.SelectedItem = "# (Chest)" Then
                    Dim c As Chest = Game.baseChest.Create(p.X, p.Y)
                    Game.chestList.Add(c)
                    Game.mBoard(p.Y, p.X).ForeColor = Color.FromArgb(45, 45, 45)
                    Game.mBoard(p.Y, p.X).Text = "#"
                    If prevTypeSel = "(Wall)" Then
                        Game.mBoard(p.Y, p.X).Tag = 1
                        t.Tag = 1
                    End If
                Else
                    MessageBox.Show("ERR: CURRENTLY NOT BUILT")
                    boxType.SelectedItem = "(Wall)"
                End If
            Else
                MessageBox.Show("ERR: CURRENTLY NOT BUILT")
                boxType.SelectedItem = "(Wall)"
            End If
        End If
        Update()
        prevTypeSel = boxType.SelectedItem
    End Sub

    Private Sub removeChest()
        For i = 0 To Game.chestList.Count - 1
            If p = CType(Game.chestList(i), Chest).pos Then
                Game.chestList.RemoveAt(i)
                Exit Sub
            End If
        Next
    End Sub

    Private Sub btnEditContents_Clicked(sender As Object, e As EventArgs)
        Dim ec As New EditContents(p)
        ec.ShowDialog()
    End Sub

    Private Sub btnMove_Clicked(sender As Object, e As EventArgs)
        Dim ts As New TileSelector()
        ts.ShowDialog()
        If ts.saveChoice AndAlso ts.selected <> Nothing Then
            'MessageBox.Show("SELECTED " & ts.selected.ToString())
            Dim toReplace As mTile = Game.mBoard(ts.selected.Y, ts.selected.X)
            If toReplace.Text = "" Then
                Dim tag As Integer = t.Tag
                Dim col As Color = t.ForeColor
                t.Tag = toReplace.Tag
                t.Text = toReplace.Text
                t.ForeColor = toReplace.ForeColor

                Dim item As String = boxType.SelectedItem.ToString()
                If item.IndexOf("Stairs") <> -1 Then
                    toReplace.Text = "H"
                    Game.stairs = ts.selected
                ElseIf item.IndexOf("NPC") <> -1 Then
                    For Each npc As NPC In Game.npcList
                        If npc.pos = p Then
                            npc.pos = ts.selected
                            Exit For
                        End If
                    Next
                    If p = Game.shopkeeper.pos Then
                        Game.shopkeeper.pos = ts.selected
                    End If
                    toReplace.Text = "$"
                ElseIf item.IndexOf("Chest") <> -1 Then
                    For Each chest As Chest In Game.chestList
                        If chest.pos = p Then
                            chest.pos = ts.selected
                            Exit For
                        End If
                    Next
                    toReplace.Text = "#"
                ElseIf item.IndexOf("Player") <> -1 Then
                    Game.player.pos = ts.selected
                    toReplace.Text = "@"
                ElseIf item.IndexOf("Statue") <> -1 Then
                    toReplace.Text = "@"
                ElseIf item.IndexOf("Trap") <> -1 Then
                    For Each trap As Trap In Game.trapList
                        If trap.pos = p Then
                            trap.pos = ts.selected
                            Exit For
                        End If
                    Next
                    toReplace.Text = "+"
                Else
                    toReplace.Text = ""
                End If

                toReplace.Tag = tag
                toReplace.ForeColor = col



                Reload()

                Game.zoom()
            Else
                MessageBox.Show("TILE OCCUPIED")
            End If
            Game.mBoard(ts.selected.Y, ts.selected.X) = toReplace
            Game.mBoard(p.Y, p.X) = t
        End If
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