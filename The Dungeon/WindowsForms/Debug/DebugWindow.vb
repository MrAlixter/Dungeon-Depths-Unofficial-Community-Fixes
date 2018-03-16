Imports System.ComponentModel
Imports System.Threading

Public Class Debug_Window
    Dim inventoryList As List(Of String) = New List(Of String)
    Dim itemsList As List(Of String) = New List(Of String)
    'Dim tileTypes As List(Of mTile)
    Dim magnification As Integer
    Dim map As Bitmap
    Dim prevSelectP As Point = New Point(-1, -1)
    Dim prevSelectC As Color = Nothing
    Dim dragging As Boolean
    Dim xOffset As Integer
    Dim yOffset As Integer
    Dim mouseMoveThread As Thread
    Private Delegate Sub delegateExecute()

    Private Sub Debug_Window_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clear()

        dragging = False
        xOffset = 0
        yOffset = 0
        unselectMapControlButtons()
        btnPan.Checked = True

        'GENERAL
        boxFloor.Value = Game.floor
        boxTurn.Value = Game.turn

        'MAP
        magnification = Math.Floor(Math.Min(picBoard.Width / Game.mBoardWidth, picBoard.Height / Game.mBoardHeight))
        boxZoom.Value = magnification
        createMap()
        AddHandler picBoard.Paint, AddressOf Me.picBoard_Draw
        AddHandler picBoard.MouseDown, AddressOf Me.mapMousePress
        AddHandler picBoard.MouseUp, AddressOf Me.mapMouseRelease

        btnEditSelection.Enabled = False

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
        boxHealth.Value = Game.player.health
        boxMaxHealth.Value = Game.player.maxHealth
        boxMana.Value = Game.player.mana
        boxMaxMana.Value = Game.player.maxMana
        boxHunger.Value = Game.player.hunger
        boxAtk.Value = Game.player.attack
        boxDef.Value = Game.player.defence
        boxWil.Value = Game.player.discipline
        boxSpd.Value = Game.player.speed
        boxEvd.Value = Game.player.evade
        boxGold.Value = Game.player.gold
        pnlSC.BackColor = Game.player.skincolor
        pnlHC.BackColor = Game.player.haircolor

        'PORTRAIT
        loadPortrait()

        'INVENTORY
        updateInventoryList()
        number.Value = 0
        updateItemsList()
    End Sub

    Private Sub loadPortrait()
        picPreview.Image = Game.picPortrait.BackgroundImage
        picPreview.BackgroundImage = Game.player.iArr(0)
        Dim PADDING = 0.1
        Dim w As Integer = 146
        Dim h As Integer = 216

        Dim attr
        If Game.player.sexBool Then
            attr = CharacterGenerator.fAttributes
        Else
            attr = CharacterGenerator.mAttributes
        End If
        For i = 0 To tabPortrait.TabPages.Count - 1
            Dim x As Integer = w * PADDING
            Dim y As Integer = (tabPortrait.TabPages(i).Height - h) / 2
            For j = 0 To attr(i).Count - 1
                Dim img As New PictureBox
                img.Name = i.ToString() & ":" & j.ToString()
                tabPortrait.TabPages(i).Controls.Add(img)
                img.Image = attr(i)(j)
                img.BackgroundImage = attr(0)(0)
                img.Location = New Point(x, y)
                img.Size = New Point(w, h)
                'img.BackgroundImageLayout = ImageLayout.Stretch
                AddHandler img.Click, AddressOf clickOnPic
                x += w * (1 + PADDING)
            Next
        Next
    End Sub

    Private Sub clearPortrait()
        For i = 0 To tabPortrait.TabPages.Count - 1
            For j = 0 To tabPortrait.TabPages(i).Controls.Count - 1
                tabPortrait.TabPages(i).Controls(0).Dispose()
            Next
        Next
    End Sub

    Private Sub clear()
        Dim ctrl As Control = Me
        Do Until ctrl Is Nothing
            If ctrl.GetType() = GetType(TextBox) Then
                ctrl.Text = ""
            ElseIf ctrl.GetType() = GetType(ComboBox) Then
                CType(ctrl, ComboBox).Items.Clear()
            ElseIf ctrl.GetType() = GetType(ListBox) Then
                CType(ctrl, ListBox).Items.Clear()
            End If
            ctrl = GetNextControl(ctrl, True)
        Loop
        clearPortrait()
    End Sub

    Private Sub unselectMapControlButtons()
        For i = 0 To boxMapControls.Controls.Count - 1
            If TypeOf (boxMapControls.Controls(i)) Is RadioButton Then
                CType(boxMapControls.Controls(i), RadioButton).Checked = False
            End If
        Next
    End Sub

    Private Sub btnPan_Click(sender As Object, e As EventArgs) Handles btnPan.Click
        unselectMapControlButtons()
        btnPan.Checked = True
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        unselectMapControlButtons()
        btnSelect.Checked = True
    End Sub

    Private Sub createMap()
        map = New Bitmap(Game.mBoardWidth + 2, Game.mBoardHeight + 2)
        For boardX = 0 To map.Width - 3
            For boardY = 0 To map.Height - 3
                If (Game.mBoard(boardY, boardX).Text = "#") Then 'Chest
                    map.SetPixel(boardX + 1, boardY + 1, Color.Yellow)
                ElseIf (Game.mBoard(boardY, boardX).Text = "H") Then 'Stairs
                    map.SetPixel(boardX + 1, boardY + 1, Color.Brown)
                ElseIf (Game.mBoard(boardY, boardX).Text = "@" And Game.player.pos.X = boardX And Game.player.pos.Y = boardY) Then 'Player
                    map.SetPixel(boardX + 1, boardY + 1, Color.LawnGreen)
                ElseIf (Game.mBoard(boardY, boardX).Text = "@") Then 'Statue
                    map.SetPixel(boardX + 1, boardY + 1, Color.LightSlateGray)
                ElseIf (Game.mBoard(boardY, boardX).Text = "$") Then 'NPC
                    map.SetPixel(boardX + 1, boardY + 1, Color.Blue)
                ElseIf (Game.mBoard(boardY, boardX).Tag = 2) Then 'Seen
                    map.SetPixel(boardX + 1, boardY + 1, Color.White)
                ElseIf (Game.mBoard(boardY, boardX).Tag = 1) Then 'Unseen
                    map.SetPixel(boardX + 1, boardY + 1, Color.Gray)
                Else 'Nothing
                    map.SetPixel(boardX + 1, boardY + 1, Color.Black)
                End If
            Next
        Next
    End Sub

    Private Sub picBoard_Draw(sender As Object, e As PaintEventArgs)
        e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
        e.Graphics.DrawImage(map, CInt((picBoard.Width - (map.Width * magnification)) / 2) + xOffset, CInt((picBoard.Height - (map.Height * magnification)) / 2) + yOffset, map.Width * magnification + 0, map.Height * magnification + 0)

        ''DEBUG LINES
        'Dim p As Pen
        ''EDGE
        'p = Pens.LimeGreen
        'e.Graphics.DrawLine(p, 0, 0, picBoard.Width, 0)
        'e.Graphics.DrawLine(p, 0, 0, 0, picBoard.Height)
        'e.Graphics.DrawLine(p, picBoard.Width, picBoard.Height, 0, picBoard.Height)
        'e.Graphics.DrawLine(p, picBoard.Width - 1, picBoard.Height - 1, picBoard.Width - 1, 0)
        ''CENTER
        'p = Pens.Maroon
        'e.Graphics.DrawLine(p, CInt(picBoard.Width / 2), 0, CInt(picBoard.Width / 2), picBoard.Height)
        'e.Graphics.DrawLine(p, 0, CInt(picBoard.Height / 2), picBoard.Width, CInt(picBoard.Height / 2))
        ''EDGE OF MAP IMAGE
        'p = Pens.Black
        ''e.Graphics.DrawLine(p, CInt(0), CInt(picBoard.Height / 2 - map.Height * magnification / 2) + yOffset, CInt(picBoard.Width), CInt(picBoard.Height / 2 - map.Height * magnification / 2) + yOffset)
        ''e.Graphics.DrawLine(p, CInt(0), CInt(picBoard.Height / 2 + map.Height * magnification / 2) + yOffset, CInt(picBoard.Width), CInt(picBoard.Height / 2 + map.Height * magnification / 2) + yOffset)
        ''e.Graphics.DrawLine(p, CInt(picBoard.Width / 2 - map.Width * magnification / 2) + xOffset, CInt(0), CInt(picBoard.Width / 2 - map.Width * magnification / 2) + xOffset, CInt(picBoard.Height))
        ''e.Graphics.DrawLine(p, CInt(picBoard.Width / 2 + map.Width * magnification / 2) + xOffset, CInt(0), CInt(picBoard.Width / 2 + map.Width * magnification / 2) + xOffset, CInt(picBoard.Height))
        ''EDGE OF MAP
        'p = Pens.Teal
        'e.Graphics.DrawLine(p, CInt(0), CInt(Math.Floor(picBoard.Height / 2 - (map.Height - 1) * magnification / 2)) + yOffset, CInt(picBoard.Width), CInt(Math.Floor(picBoard.Height / 2 - (map.Height - 1) * magnification / 2)) + yOffset)
        'e.Graphics.DrawLine(p, CInt(0), CInt(Math.Floor(picBoard.Height / 2 + (map.Height - 3) * magnification / 2)) + yOffset, CInt(picBoard.Width), CInt(Math.Floor(picBoard.Height / 2 + (map.Height - 3) * magnification / 2)) + yOffset)
        'e.Graphics.DrawLine(p, CInt(Math.Floor(picBoard.Width / 2 - (map.Width - 1) * magnification / 2)) + xOffset, CInt(0), CInt(Math.Floor(picBoard.Width / 2 - (map.Width - 1) * magnification / 2)) + xOffset, CInt(picBoard.Height))
        'e.Graphics.DrawLine(p, CInt(Math.Floor(picBoard.Width / 2 + (map.Width - 3) * magnification / 2)) + xOffset, CInt(0), CInt(Math.Floor(picBoard.Width / 2 + (map.Width - 3) * magnification / 2)) + xOffset, CInt(picBoard.Height))
    End Sub

    Private Sub mapMousePress(sender As Object, e As MouseEventArgs)
        If btnPan.Checked Then
            dragging = True
            mouseMoveThread = New Thread(New ThreadStart(AddressOf mapMove))
            mouseMoveThread.IsBackground = True
            mouseMoveThread.Start()
        ElseIf btnSelect.Checked Then

        End If
    End Sub

    Private Sub mapMouseRelease(sender As Object, e As MouseEventArgs)
        If btnPan.Checked Then
            dragging = False
            'mouseMoveThread.Abort()
        ElseIf btnSelect.Checked Then
            Dim Top As Integer = CInt(Math.Floor(picBoard.Height / 2 - (map.Height - 1) * magnification / 2)) + yOffset
            Dim Bottom As Integer = CInt(Math.Floor(picBoard.Height / 2 + (map.Height - 3) * magnification / 2)) + yOffset
            Dim Left As Integer = CInt(Math.Floor(picBoard.Width / 2 - (map.Width - 1) * magnification / 2)) + xOffset
            Dim Right As Integer = CInt(Math.Floor(picBoard.Width / 2 + (map.Width - 3) * magnification / 2)) + xOffset
            If e.X > Left And e.X < Right And e.Y > Top And e.Y < Bottom Then
                Dim _x As Integer = CInt(Math.Floor((e.X - Left) / magnification))
                Dim _y As Integer = CInt(Math.Floor((e.Y - Top) / magnification))
                If Not (prevSelectP.X < 0 Or prevSelectP.Y < 0) Then
                    map.SetPixel(prevSelectP.X + 1, prevSelectP.Y + 1, prevSelectC)
                End If
                prevSelectP = New Point(_x, _y)
                prevSelectC = map.GetPixel(_x + 1, _y + 1)
                map.SetPixel(_x + 1, _y + 1, Color.PeachPuff)
                btnEditSelection.Enabled = True
                'MessageBox.Show(_x & ", " & _y)
                picBoard.Refresh()
            End If
        End If
    End Sub

    Public Sub refreshMap()
        If picBoard.InvokeRequired Then
            picBoard.Invoke(New delegateExecute(AddressOf refreshMap))
        Else
            picBoard.Refresh()
        End If
    End Sub

    Private Sub mapMove()
        Dim lastX As Integer = Cursor.Position.X
        Dim lastY As Integer = Cursor.Position.Y
        While dragging
            xOffset += Cursor.Position.X - lastX
            yOffset += Cursor.Position.Y - lastY
            refreshMap()
            lastX = Cursor.Position.X
            lastY = Cursor.Position.Y
            Thread.Sleep(15)
        End While
    End Sub

    Private Sub updateInventoryList()
        inventoryList.Clear()
        boxInventory.Items.Clear()
        For i = 0 To Game.player.inventorynames.Count - 1
            If (CType(Game.player.inventory(i), Item).count > 0) Then
                inventoryList.Add(Game.player.inventorynames(i) & " x" & CType(Game.player.inventory(i), Item).count)
            End If
        Next
        inventoryList.Sort()
        For i = 0 To inventoryList.Count - 1
            boxInventory.Items.Add(inventoryList(i))
        Next
    End Sub

    Private Sub updateItemsList()
        itemsList.Clear()
        boxItems.Items.Clear()
        For i = 0 To Game.player.inventorynames.Count - 1
            itemsList.Add(Game.player.inventorynames(i))
        Next
        itemsList.Sort()
        For i = 0 To itemsList.Count - 1
            boxItems.Items.Add(itemsList(i))
        Next
    End Sub

    Private Sub picBoard_MouseWheel(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles picBoard.MouseWheel
        Dim scrollAmt As Integer = CInt(Math.Floor(e.Delta * SystemInformation.MouseWheelScrollLines / (120 * 6)))
        magnification -= scrollAmt
        If magnification < 1 Then magnification = 1
        boxZoom.Value = magnification
        picBoard.Refresh()
    End Sub

    Private Sub boxZoom_ValueChanged(sender As Object, e As EventArgs) Handles boxZoom.ValueChanged
        magnification = boxZoom.Value
        picBoard.Refresh()
    End Sub

    Private Sub btnEditSelection_Click(sender As Object, e As EventArgs) Handles btnEditSelection.Click
        If prevSelectP.X >= 0 And prevSelectP.Y >= 0 Then
            Dim et As New EditTile()
            et.SetLoc(prevSelectP)
            et.ShowDialog()

            Dim tempPoint As Point = prevSelectP
            prevSelectC = Nothing
            prevSelectP = New Point(-1, -1)

            createMap()

            prevSelectC = map.GetPixel(tempPoint.X + 1, tempPoint.Y + 1)
            prevSelectP = tempPoint
            map.SetPixel(tempPoint.X + 1, tempPoint.Y + 1, Color.PeachPuff)
            btnEditSelection.Enabled = True
            picBoard.Refresh()
            Game.zoom()
        End If
    End Sub

    Private Sub boxTurn_ValueChanged(sender As Object, e As EventArgs) Handles boxTurn.ValueChanged
        Game.turn = boxTurn.Value
    End Sub

    Private Sub boxName_TextChanged(sender As Object, e As EventArgs) Handles boxName.TextChanged
        If boxName.Text.Trim() <> "" Then
            Game.player.name = boxName.Text.Trim()
        End If
    End Sub

    Private Sub boxHealth_ValueChanged(sender As Object, e As EventArgs) Handles boxHealth.ValueChanged
        Game.player.health = boxHealth.Value
    End Sub

    Private Sub boxMaxHealth_ValueChanged(sender As Object, e As EventArgs) Handles boxMaxHealth.ValueChanged
        Game.player.maxHealth = boxMaxHealth.Value
    End Sub

    Private Sub boxMana_ValueChanged(sender As Object, e As EventArgs) Handles boxMana.ValueChanged
        Game.player.mana = boxMana.Value
    End Sub

    Private Sub boxMaxMana_ValueChanged(sender As Object, e As EventArgs) Handles boxMaxMana.ValueChanged
        Game.player.maxMana = boxMaxMana.Value
    End Sub

    Private Sub boxHunger_ValueChanged(sender As Object, e As EventArgs) Handles boxHunger.ValueChanged
        Game.player.hunger = boxHunger.Value
    End Sub

    Private Sub boxAtk_ValueChanged(sender As Object, e As EventArgs) Handles boxAtk.ValueChanged
        Game.player.attack = boxAtk.Value
    End Sub

    Private Sub boxDef_ValueChanged(sender As Object, e As EventArgs) Handles boxDef.ValueChanged
        Game.player.defence = boxDef.Value
    End Sub

    Private Sub boxWil_ValueChanged(sender As Object, e As EventArgs) Handles boxWil.ValueChanged
        Game.player.discipline = boxWil.Value
    End Sub

    Private Sub boxSpd_ValueChanged(sender As Object, e As EventArgs) Handles boxSpd.ValueChanged
        Game.player.speed = boxSpd.Value
    End Sub

    Private Sub boxEvd_ValueChanged(sender As Object, e As EventArgs) Handles boxEvd.ValueChanged
        Game.player.evade = boxEvd.Value
    End Sub

    Private Sub boxGold_ValueChanged(sender As Object, e As EventArgs) Handles boxGold.ValueChanged
        Game.player.gold = boxGold.Value
    End Sub

    Private Sub boxSex_SelectedValueChanged(sender As Object, e As EventArgs) Handles boxSex.SelectedValueChanged
        Dim before = Nothing
        If Game.player.sex = "Male" And boxSex.Items(boxSex.SelectedIndex) = "Female" Then
            before = Game.player.sex
            Game.player.MtF()
        ElseIf Game.player.sex = "Female" And boxSex.Items(boxSex.SelectedIndex) = "Male" Then
            before = Game.player.sex
            Game.player.FtM()
        End If
        If (Not before = Nothing) And (Game.player.sex = before) Then
            MessageBox.Show("Something prevents the player's sex from changing")
            boxSex.SelectedItem = before
        Else
            clearPortrait()
            loadPortrait()
        End If
    End Sub

    Private Sub pnlSC_Paint(sender As Object, e As EventArgs) Handles pnlSC.Click
        Dim cd As New SCPicker
        cd.ShowDialog()
        Game.player.changeSkinColor(cd.sc)
        CType(sender, Panel).BackColor = cd.sc
        cd.Dispose()
        picPreview.Image = CharacterGenerator.CreateBMP(Game.player.iArr)
    End Sub

    Private Sub pnlHC_Paint(sender As Object, e As EventArgs) Handles pnlHC.Click
        Dim cd As New ColorDialog()
        cd.Color = Game.player.haircolor
        cd.ShowDialog()
        Game.player.changeHairColor(cd.Color)
        cd.Dispose()
        picPreview.Image = CharacterGenerator.CreateBMP(Game.player.iArr)
    End Sub

    Private Sub clickOnPic(sender As Object, e As EventArgs)
        Dim tab As Integer = sender.Name.Split(":")(0)
        Dim pic As Integer = sender.Name.Split(":")(1)

        Game.player.iArr(tab) = CType(sender, PictureBox).Image
        Game.player.iArrInd(tab) = New Tuple(Of Integer, Boolean)(pic, Game.player.sexBool)

        'picPreview.Image = CharacterGenerator.recolor(CharacterGenerator.CreateBMP(Game.player.iArr), Game.player.skincolor)
        picPreview.Image = CharacterGenerator.CreateBMP(Game.player.iArr)
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If boxInventory.SelectedIndices.Count < 1 Then Exit Sub
        Dim selected As ListBox.SelectedIndexCollection = boxInventory.SelectedIndices
        Do Until selected.Count = 0
            Dim name As String = boxInventory.Items(selected(0)).ToString()
            name = name.Substring(0, name.IndexOf(" x")).Trim()
            Dim itemInd As Integer = Game.player.inventorynames.IndexOf(name)
            If number.Value >= CType(Game.player.inventory(itemInd), Item).count Then
                CType(Game.player.inventory(itemInd), Item).count = 0
                boxInventory.Items.RemoveAt(selected(0))
            Else
                CType(Game.player.inventory(itemInd), Item).count -= number.Value
                Dim temp As Integer = selected(0)
                boxInventory.Items.RemoveAt(selected(0))
                boxInventory.Items.Insert(temp, Game.player.inventorynames(itemInd) & " x" & CType(Game.player.inventory(itemInd), Item).count)
            End If
        Loop
    End Sub


    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If boxInventory.SelectedIndices.Count > 0 Then
            Dim selected As ListBox.SelectedIndexCollection = boxInventory.SelectedIndices
            Do Until selected.Count = 0
                Dim name As String = boxInventory.Items(selected(0)).ToString()
                name = name.Substring(0, name.IndexOf(" x")).Trim()
                Dim itemInd As Integer = Game.player.inventorynames.IndexOf(name)
                CType(Game.player.inventory(itemInd), Item).count += number.Value
                Dim temp As Integer = selected(0)
                boxInventory.Items.RemoveAt(selected(0))
                boxInventory.Items.Insert(temp, Game.player.inventorynames(itemInd) & " x" & CType(Game.player.inventory(itemInd), Item).count)
            Loop
        ElseIf boxItems.SelectedIndices.Count > 0 Then
            Do Until boxItems.SelectedIndices.Count = 0
                Dim name As String = boxItems.Items(boxItems.SelectedIndices(0))
                Dim itemInd As Integer = Game.player.inventorynames.IndexOf(name)
                CType(Game.player.inventory(itemInd), Item).count += number.Value
                updateInventoryList()
                boxItems.SelectedIndices.Remove(boxItems.SelectedIndices(0))
            Loop
        End If
    End Sub

    Private Sub boxInventory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles boxInventory.SelectedIndexChanged
        If boxItems.SelectedIndex <> -1 Then
            boxItems.SelectedIndex = -1
        End If
    End Sub

    Private Sub boxItems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles boxItems.SelectedIndexChanged
        If boxInventory.SelectedIndex <> -1 Then
            boxInventory.SelectedIndex = -1
        End If
    End Sub
End Class