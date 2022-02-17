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

    Private Sub Update_Map()
        Reload()
        Debug_Window.refreshMap()
        Game.zoom()
    End Sub

    Private Sub Reload()
        t = Game.currfloor.mBoard(p.Y, p.X)

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

        boxType.Items.Clear()
        boxType.Items.Add("(Wall)")
        boxType.Items.Add("(Walkable)")
        boxType.Items.Add("# (Chest)")
        boxType.Items.Add("# (Mimic)")
        boxType.Items.Add("H (Stairs)")
        boxType.Items.Add("@ (Player)")
        boxType.Items.Add("@ (Statue)")
        boxType.Items.Add("$ (NPC)")
        boxType.Items.Add("+ (Trap)")
        If Game.currFloor.floorNumber = 9999 Or Game.currFloor.floorNumber = 10000 Then
            boxType.Items.Add("- (Barrier)")
            boxType.Items.Add("| (Barrier)")
        End If

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
        ElseIf (t.Text = "@" And Game.player1.pos.X = p.X And Game.player1.pos.Y = p.Y) Then 'Player
            boxType.SelectedItem = "@ (Player)"
            boxType.Enabled = False
            boxOptions.Visible = True
            addMoveButton(boxOptions.Controls.Count)
        ElseIf (t.Text = "@") Then 'Statue
            boxType.SelectedItem = "@ (Statue)"
            boxType.Enabled = True
            boxOptions.Visible = True
            addMoveButton(boxOptions.Controls.Count)
        ElseIf (t.Text = "$") Then 'NPC
            boxType.SelectedItem = "$ (NPC)"
            boxType.Enabled = False
            boxOptions.Visible = True
            addMoveButton(boxOptions.Controls.Count)
        ElseIf (t.Text = "+") Then 'Trap
            boxType.SelectedItem = "+ (Trap)"
            boxType.Enabled = True
            boxOptions.Visible = True
            addMoveButton(boxOptions.Controls.Count)
        ElseIf (t.Text = "-") Then 'Barrier
            boxType.SelectedItem = "- (Barrier)"
            boxType.Enabled = True
            boxOptions.Visible = True
            addMoveButton(boxOptions.Controls.Count)
        ElseIf (t.Text = "|") Then 'Barrier
            boxType.SelectedItem = "| (Barrier)"
            boxType.Enabled = True
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
        'HANDLE THE "FROM" 
        'If prevTypeSel = "(Wall)" Or prevTypeSel = "(Walkable)" Or prevTypeSel = "@ (Statue)" Then 'No extra work
        'Else
        Dim removeFlag As Boolean = False
        If prevTypeSel = "H (Stairs)" Or prevTypeSel = "@ (Player)" Or prevTypeSel = "$ (NPC)" Then 'DENY! Cannot remove stairs, player, or NPC
            MessageBox.Show("ERR: CANNOT CHANGE THIS TYPE OF TILE")
            boxType.SelectedItem = prevTypeSel
            Exit Sub
        ElseIf prevTypeSel = "# (Chest)" Or prevTypeSel = "+ (Trap)" Then 'Say to remove chest/trap from list
            removeFlag = True
        End If

        'HANDLE THE "TO"
        Dim name = boxType.SelectedItem.ToString()
        If name = "H (Stairs)" Or name = "$ (NPC)" Then 'DENY! Cannot duplicatre stairs, player, or NPC
            MessageBox.Show("ERR: CANNOT ADD TILES OF THIS TYPE")
            boxType.SelectedItem = prevTypeSel
            Exit Sub
        ElseIf name = "@ (Player)" Then
            t.Tag = 2
            t.Text = "@"
            Game.player1.pos = p
        ElseIf name = "(Wall)" Then
            If removeFlag Then removeItem()
            t.Tag = 0
            t.Text = ""
            t.ForeColor = Color.Black
            boxSeen.Enabled = False
            boxSeen.Checked = False
        ElseIf name = "(Walkable)" Or name = "@ (Statue)" Then
            If removeFlag Then removeItem()
            If t.Tag = 0 Then t.Tag = 1
            If name = "(Walkable)" Then
                t.Text = ""
            Else
                t.Text = "@"
            End If
            t.ForeColor = Color.Black
            boxSeen.Enabled = True
            If t.Tag = 1 Then
                boxSeen.Checked = False
            ElseIf t.Tag = 2 Then
                boxSeen.Checked = True
            End If
        ElseIf name = "# (Chest)" Then
            If removeFlag Then removeItem()
            If t.Tag = 0 Then t.Tag = 1
            t.Text = "#"
            t.ForeColor = Color.FromArgb(45, 45, 45)
            Game.currFloor.mBoard(p.Y, p.X).ForeColor = Color.FromArgb(45, 45, 45)
            Dim c As Chest = DDConst.BASE_CHEST.Create(New Point(p.X, p.Y))
            Game.currFloor.chestList.Add(c)
        ElseIf name = "+ (Trap)" Then
            If removeFlag Then removeItem()
            If t.Tag = 0 Then t.Tag = 1
            t.Text = "+"
            t.ForeColor = Color.FromArgb(45, 45, 45)
            Game.currFloor.mBoard(p.Y, p.X).ForeColor = Color.FromArgb(45, 45, 45)
            Dim trp = Trap.trapFactory(Trap.getRandomTrapId(), New Point(p.X, p.Y))
            Game.currFloor.trapList.Add(trp)
        ElseIf name = "- (Barrier)" Then
            If removeFlag Then removeItem()
            t.Tag = 0
            t.Text = "-"
            t.ForeColor = Color.FromArgb(45, 45, 45)
            Game.currFloor.mBoard(p.Y, p.X).ForeColor = Color.FromArgb(45, 45, 45)
        ElseIf name = "| (Barrier)" Then
            If removeFlag Then removeItem()
            t.Tag = 0
            t.Text = "|"
            t.ForeColor = Color.FromArgb(45, 45, 45)
            Game.currFloor.mBoard(p.Y, p.X).ForeColor = Color.FromArgb(45, 45, 45)
        End If



        'If boxType.SelectedItem.ToString() = "(Wall)" Then
        '    If prevTypeSel = "# (Chest)" Then
        '        removeChest()
        '    End If
        '    t.Tag = 0
        '    t.Text = ""
        '    t.ForeColor = Color.Black
        '    boxSeen.Enabled = False
        '    boxSeen.Checked = False
        'ElseIf boxType.SelectedItem.ToString() = "(Walkable)" Then
        '    If prevTypeSel = "# (Chest)" Then
        '        removeChest()
        '    End If
        '    If t.Tag = 0 Then
        '        t.Tag = 1
        '    End If
        '    t.Text = ""
        '    t.ForeColor = Color.Black
        '    boxSeen.Enabled = True
        '    boxSeen.Checked = False
        'Else
        '    If prevTypeSel = "(Wall)" Or prevTypeSel = "(Walkable)" Then
        '        If boxType.SelectedItem = "# (Chest)" Then
        '            Dim c As Chest = DDConst.BASE_CHEST.Create(p.X, p.Y)
        '            Game.currfloor.chestList.Add(c)
        '            Game.currfloor.mBoard(p.Y, p.X).ForeColor = Color.FromArgb(45, 45, 45)
        '            Game.currfloor.mBoard(p.Y, p.X).Text = "#"
        '            If prevTypeSel = "(Wall)" Then
        '                Game.currfloor.mBoard(p.Y, p.X).Tag = 1
        '                t.Tag = 1
        '            End If
        '        Else
        '            MessageBox.Show("CANNOT CHANGE TO THIS TYPE")
        '            boxType.SelectedItem = prevTypeSel
        '        End If
        '    Else
        '        MessageBox.Show("ERR: CURRENTLY NOT BUILT")
        '        boxType.SelectedItem = prevTypeSel
        '    End If
        'End If
        Reload()
    End Sub

    Private Sub removeItem()
        If t.Text = "#" Then
            For i = 0 To Game.currfloor.chestList.Count - 1
                If p = CType(Game.currfloor.chestList(i), Chest).pos Then
                    Game.currfloor.chestList.RemoveAt(i)
                    Exit Sub
                End If
            Next
        ElseIf t.Text = "+" Then
            For i = 0 To Game.currfloor.trapList.Count - 1
                If p = CType(Game.currfloor.trapList(i), Trap).pos Then
                    Game.currfloor.trapList.RemoveAt(i)
                    Exit Sub
                End If
            Next
        End If
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
            Dim toReplace As mTile = Game.currfloor.mBoard(ts.selected.Y, ts.selected.X)
            If toReplace.Text = "" Then
                Dim tag As Integer = t.Tag
                Dim col As Color = t.ForeColor
                t.Tag = toReplace.Tag
                t.Text = toReplace.Text
                t.ForeColor = toReplace.ForeColor

                Dim item As String = boxType.SelectedItem.ToString()
                If item.IndexOf("Stairs") <> -1 Then
                    toReplace.Text = "H"
                    Game.currFloor.stairs = ts.selected
                ElseIf item.IndexOf("NPC") <> -1 Then
                    For Each npc As ShopNPC In Game.npc_list
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
                    For Each chest As Chest In Game.currfloor.chestList
                        If chest.pos = p Then
                            chest.pos = ts.selected
                            Exit For
                        End If
                    Next
                    toReplace.Text = "#"
                ElseIf item.IndexOf("Player") <> -1 Then
                    Game.player1.pos = ts.selected
                    toReplace.Text = "@"
                ElseIf item.IndexOf("Statue") <> -1 Then
                    toReplace.Text = "@"
                ElseIf item.IndexOf("Trap") <> -1 Then
                    For Each trap As Trap In Game.currfloor.trapList
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
            Game.currfloor.mBoard(ts.selected.Y, ts.selected.X) = toReplace
            Game.currfloor.mBoard(p.Y, p.X) = t
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
        Game.currfloor.mBoard(p.Y, p.X).Tag = tag
        Game.currfloor.mBoard(p.Y, p.X).Text = t.Text
        Game.currfloor.mBoard(p.Y, p.X).ForeColor = t.ForeColor
    End Sub
End Class