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
    Dim tabPortraitsLoaded As Boolean

    Private Sub Debug_Window_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clear()
        If tabPortraitsLoaded = Nothing Then tabPortraitsLoaded = False

        dragging = False
        xOffset = 0
        yOffset = 0
        unselectMapControlButtons()
        btnPan.Checked = True

        'GENERAL
        boxFloor.Value = Game.floor
        boxTurn.Value = Game.turn
        If Game.floor < Game.beatboss.Count Then
            boxBeaten.Checked = Game.beatboss(Game.floor)
        Else
            boxBeaten.Enabled = False
        End If

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
        RemoveHandler boxSex.CheckedChanged, AddressOf boxSex_CheckedChanged
        If Game.player.sexBool <> boxSex.Checked Then
            clearPortrait()
        End If
        boxSex.Checked = Game.player.sexBool
        AddHandler boxSex.CheckedChanged, AddressOf boxSex_CheckedChanged
        For i = 0 To Game.titleList.Count - 1
            boxForm.Items.Add(Game.titleList(i).ToString())
        Next

        boxForm.SelectedItem = Game.player.pClass.name

        boxHealth.Value = Game.player.health * Game.player.getmaxHealth()
        boxMaxHealth.Value = Game.player.maxHealth
        boxMana.Value = Game.player.mana
        boxMaxMana.Value = Game.player.maxMana
        boxHunger.Value = Game.player.hunger
        boxAtk.Value = Game.player.attack
        boxDef.Value = Game.player.defence
        boxWil.Value = Game.player.will
        boxSpd.Value = Game.player.speed
        boxEvd.Value = -0
        boxGold.Value = Game.player.gold


        pnlSC.BackColor = Game.player.skincolor
        pnlHC.BackColor = Color.FromArgb(255, Game.player.haircolor.R, Game.player.haircolor.G, Game.player.haircolor.B)
        boxAlpha.Value = Game.player.haircolor.A

        'PORTRAIT
        loadPortrait()

        'INVENTORY
        updateInventoryList()
        number.Value = 1
        updateItemsList()

        'PERKS
        Dim groupBoxes As List(Of GroupBox) = New List(Of GroupBox)
        For Each control In tabPerks.Controls
            If TypeOf (control) Is GroupBox Then
                groupBoxes.Add(control)
            End If
        Next
        If groupBoxes.Count <> Game.player.perks.Count Then
            tabPerks.Controls.Clear()

            Dim row = 0
            Dim col = 0
            Dim test = 0
            For Each perk In Game.player.perks
                addPerk(perk, col, row)
                row += 1
                Dim control As Control = tabPerks.Controls.Item(tabPerks.Controls.Count - 1)
                If (control.Location.Y + control.Size.Height) > tabPerks.Size.Height Then
                    row = 0
                    col += 1
                    movePerkControl(control, col, row)
                    row += 1
                End If
                test += 1
            Next
        Else
            For i As Integer = 0 To groupBoxes.Count - 1
                Dim box As GroupBox = groupBoxes(i)
                Dim num As NumericUpDown = Nothing
                Dim lbl As Label = Nothing
                For j As Integer = 0 To box.Controls.Count - 1
                    Dim c As Control = box.Controls(j)
                    If TypeOf (c) Is NumericUpDown Then
                        num = c
                    ElseIf TypeOf (c) Is Label Then
                        lbl = c
                    End If

                    If num IsNot Nothing AndAlso lbl IsNot Nothing Then
                        num.Value = Game.player.perks(lbl.Text)
                        Exit For
                    End If
                Next
            Next
        End If

        'GENERATION SETTINGS
        lblFC.Text = "Floorcode: " & Game.floorCode
        boxWidth.Value = Game.mBoardWidth
        boxHeight.Value = Game.mBoardHeight
        boxChestFreqMin.Value = Game.chestFreqMin
        boxChestFreqRange.Value = Game.chestFreqRange
        boxChestSizeDependence.Value = Game.chestSizeDependence
        boxChestRichnessBase.Value = Game.chestRichnessBase
        boxChestRichnessRange.Value = Game.chestRichnessRange
        boxEncounterRate.Value = Game.encounterRate
        boxEClockResetVal.Value = Game.eClockResetVal
        boxTrapFreqMin.Value = Game.trapFreqMin
        boxTrapFreqRange.Value = Game.trapFreqRange
        boxTrapSizeDependence.Value = Game.trapSizeDependence
    End Sub

    Private Sub loadPortrait()
        picPreview.Image = Game.picPortrait.BackgroundImage
        picPreview.BackgroundImage = Game.player.iArr(0)
        Dim PADDING = 0.1
        Dim w As Integer = 146
        Dim h As Integer = 216

        Dim attr As List(Of Image)()
        If Game.player.sexBool Then
            attr = CharacterGenerator.fAttributes
        Else
            attr = CharacterGenerator.mAttributes
        End If

        If tabPortraitsLoaded = False Then
            Dim y As Integer = (tabPortrait.TabPages(0).Height - h) / 2
            Dim bg As Image = attr(0)(0)
            For i = 0 To tabPortrait.TabPages.Count - 1
                Dim page As TabPage = tabPortrait.TabPages(i)
                Dim x As Integer = w * PADDING
                Dim att As List(Of Image) = attr(i)
                For j As Integer = 0 To att.Count - 1
                    Dim img As New PictureBox
                    img.Name = i.ToString() & ":" & j.ToString()
                    page.Controls.Add(img)
                    img.Image = att(j)
                    img.BackgroundImage = bg
                    img.Location = New Point(x, y)
                    img.Size = New Point(w, h)
                    'img.BackgroundImageLayout = ImageLayout.Stretch
                    AddHandler img.Click, AddressOf clickOnPic
                    x += w * (1 + PADDING)
                Next
            Next
            tabPortraitsLoaded = True
        End If
    End Sub

    Private Sub clearPortrait()
        For i = 0 To tabPortrait.TabPages.Count - 1
            For j = 0 To tabPortrait.TabPages(i).Controls.Count - 1
                tabPortrait.TabPages(i).Controls(0).Dispose()
            Next
        Next
        tabPortraitsLoaded = False
    End Sub

    Public Sub clear()
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
        'clearPortrait()
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
                    map.SetPixel(boardX + 1, boardY + 1, Color.Sienna)
                ElseIf (Game.mBoard(boardY, boardX).Text = "@" And Game.player.pos.X = boardX And Game.player.pos.Y = boardY) Then 'Player
                    map.SetPixel(boardX + 1, boardY + 1, Color.LawnGreen)
                ElseIf (Game.mBoard(boardY, boardX).Text = "@") Then 'Statue
                    map.SetPixel(boardX + 1, boardY + 1, Color.LightSlateGray)
                ElseIf (Game.mBoard(boardY, boardX).Text = "$") Then 'NPC
                    map.SetPixel(boardX + 1, boardY + 1, Color.Blue)
                ElseIf (Game.mBoard(boardY, boardX).Text = "+") Then 'Trap
                    map.SetPixel(boardX + 1, boardY + 1, Color.Red)
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
                map.SetPixel(_x + 1, _y + 1, Color.HotPink)
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

    Private Sub boxBeaten_CheckedChanged(sender As Object, e As EventArgs) Handles boxBeaten.CheckedChanged
        Game.beatboss(Game.floor) = boxBeaten.Checked
    End Sub

    Private Sub boxName_TextChanged(sender As Object, e As EventArgs) Handles boxName.TextChanged
        If boxName.Text.Trim() <> "" Then
            Game.player.name = boxName.Text.Trim()
        End If
    End Sub

    Private Sub boxHealth_ValueChanged(sender As Object, e As EventArgs) Handles boxHealth.ValueChanged
        Game.player.health = boxHealth.Value / Game.player.getmaxHealth
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
        Game.player.will = boxWil.Value
    End Sub

    Private Sub boxSpd_ValueChanged(sender As Object, e As EventArgs) Handles boxSpd.ValueChanged
        Game.player.speed = boxSpd.Value
    End Sub

    Private Sub boxEvd_ValueChanged(sender As Object, e As EventArgs) Handles boxEvd.ValueChanged
        'evade removed
    End Sub

    Private Sub boxGold_ValueChanged(sender As Object, e As EventArgs) Handles boxGold.ValueChanged
        Game.player.gold = boxGold.Value
    End Sub

    Private Sub boxSex_CheckedChanged(sender As Object, e As EventArgs) Handles boxSex.CheckedChanged
        Dim before As Boolean = Nothing
        If Not Game.player.sexBool And boxSex.Checked Then
            before = Game.player.sexBool
            Game.player.MtF()
        ElseIf Game.player.sexBool And Not boxSex.Checked Then
            before = Game.player.sexBool
            Game.player.FtM()
        End If
        If (Not before = Nothing) And (Game.player.sexBool = before) Then
            MessageBox.Show("Something prevents the player's sex from changing")
            boxSex.Checked = before
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
        Dim c As Color = Color.FromArgb(boxAlpha.Value, cd.Color.R, cd.Color.G, cd.Color.B)
        Game.player.changeHairColor(c)
        cd.Dispose()
        picPreview.Image = CharacterGenerator.CreateBMP(Game.player.iArr)
    End Sub

    Private Sub boxAlpha_ValueChanged(sender As Object, e As EventArgs) Handles boxAlpha.ValueChanged
        Dim c As Color = Color.FromArgb(boxAlpha.Value, Game.player.haircolor.R, Game.player.haircolor.G, Game.player.haircolor.B)
        Game.player.changeHairColor(c)
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

    Private Sub boxInventoryFilter_TextChanged(sender As Object, e As EventArgs) Handles boxInventoryFilter.TextChanged
        inventoryFilterUpdate()
    End Sub

    Private Sub boxItemsFilter_TextChanged(sender As Object, e As EventArgs) Handles boxItemsFilter.TextChanged
        itemFilterUpdate()
    End Sub

    Private Sub inventoryFilterUpdate()
        boxInventory.Items.Clear()
        For i As Integer = 0 To inventoryList.Count - 1
            If inventoryList(i).IndexOf(boxInventoryFilter.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1 Then
                boxInventory.Items.Add(inventoryList(i).ToString())
            End If
        Next
    End Sub

    Private Sub itemFilterUpdate()
        boxItems.Items.Clear()
        For i As Integer = 0 To itemsList.Count - 1
            If itemsList(i).IndexOf(boxItemsFilter.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1 Then
                boxItems.Items.Add(itemsList(i).ToString())
            End If
        Next
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
        inventoryFilterUpdate()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If boxInventory.SelectedIndices.Count > 0 Then
            Dim selected As ListBox.SelectedIndexCollection = boxInventory.SelectedIndices
            Do Until selected.Count = 0
                Dim name As String = boxInventory.Items(selected(0)).ToString()
                name = name.Substring(0, name.IndexOf(" x")).Trim()
                Dim itemInd As Integer = Game.player.inventorynames.IndexOf(name)
                Game.player.inventory(itemInd).add(number.Value)
                Dim temp As Integer = selected(0)
                boxInventory.Items.RemoveAt(selected(0))
                boxInventory.Items.Insert(temp, Game.player.inventorynames(itemInd) & " x" & CType(Game.player.inventory(itemInd), Item).count)
            Loop
        ElseIf boxItems.SelectedIndices.Count > 0 Then
            Do Until boxItems.SelectedIndices.Count = 0
                Dim name As String = boxItems.Items(boxItems.SelectedIndices(0))
                Dim itemInd As Integer = Game.player.inventorynames.IndexOf(name)
                Game.player.inventory(itemInd).add(number.Value)
                updateInventoryList()
                boxItems.SelectedIndices.Remove(boxItems.SelectedIndices(0))
            Loop
        End If
        inventoryFilterUpdate()
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

    Private Sub addPerk(p As KeyValuePair(Of String, Integer), col As Integer, row As Integer)
        Dim group = New System.Windows.Forms.GroupBox()
        Me.tabPerks.Controls.Add(group)

        Dim box = New System.Windows.Forms.NumericUpDown()
        Dim lbl = New System.Windows.Forms.Label()
        'CType(box, System.ComponentModel.ISupportInitialize).BeginInit()
        'group.SuspendLayout()

        lbl.Location = New System.Drawing.Point(10, 10)
        lbl.Name = p.Key & "Lbl"
        lbl.Size = New System.Drawing.Size(125, 25)
        lbl.TabStop = False
        lbl.Text = p.Key

        box.BackColor = System.Drawing.Color.Black
        box.ForeColor = System.Drawing.Color.White
        box.Name = p.Key & "Box"
        box.Location = New System.Drawing.Point(lbl.Location.X + lbl.Size.Width + 10, lbl.Location.Y)
        box.Minimum = -1
        box.Value = p.Value
        box.Size = New System.Drawing.Size(63, 26)
        AddHandler box.ValueChanged, AddressOf numericUpDownChanged

        group.Controls.Add(box)
        group.Controls.Add(lbl)

        movePerkControl(group, col, row)

        Dim w As Integer = box.Size.Width + lbl.Size.Width + 10 * 3
        Dim h As Integer = Math.Max(box.Size.Height, lbl.Size.Height) + 10 * 2
        group.Name = "groupTest"
        group.Size = New System.Drawing.Size(w, h)
        group.TabIndex = 1
        group.TabStop = False

        'group.ResumeLayout()
        tabPerks.Controls.Add(group)
    End Sub

    Private Sub movePerkControl(c As Control, col As Integer, row As Integer)
        Dim box As Control = Nothing
        Dim lbl As Control = Nothing
        For Each Control In c.Controls
            If Control.Name.Substring(Control.Name.Length - 3) = "Box" Then
                box = Control
            ElseIf Control.Name.Substring(Control.Name.Length - 3) = "Lbl" Then
                lbl = Control
            End If
        Next

        Dim w As Integer = box.Size.Width + lbl.Size.Width + 10 * 3
        Dim h As Integer = Math.Max(box.Size.Height, lbl.Size.Height) + 10 * 2
        Dim pad As Decimal = 0.05
        Dim x As Integer = w * pad + (w * pad * 2 + w) * col
        Dim y As Integer = h * pad + (h * pad * 2 + h) * row

        c.Location = New System.Drawing.Point(x, y)
    End Sub

    Private Sub numericUpDownChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim name As String = sender.Name.Substring(0, sender.Name.Length - 3)
        Game.player.perks(name) = sender.Value
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnGenerationReset.Click
        reset()
        refreshBoxes()
    End Sub

    Sub reset()
        Game.mBoardWidth = 50
        Game.mBoardHeight = 40
        Game.chestFreqMin = 3
        Game.chestFreqRange = 8
        Game.chestSizeDependence = 30
        Game.chestRichnessBase = 1
        Game.chestRichnessRange = 5
        Game.encounterRate = 25
        Game.eClockResetVal = 5
    End Sub

    Sub refreshBoxes()
        boxWidth.Value = Game.mBoardWidth
        boxHeight.Value = Game.mBoardHeight
        boxChestFreqMin.Value = Game.chestFreqMin
        boxChestFreqRange.Value = Game.chestFreqRange
        boxChestFreqRange.Value = Game.chestSizeDependence
        boxChestRichnessBase.Value = Game.chestRichnessBase
        boxChestRichnessRange.Value = Game.chestRichnessRange
        boxEncounterRate.Value = Game.encounterRate
        boxEClockResetVal.Value = Game.eClockResetVal
    End Sub

    Private Sub btnSaveGeneration_Click(sender As Object, e As EventArgs) Handles btnSaveGeneration.Click
        Game.mBoardWidth = boxWidth.Value
        Game.mBoardHeight = boxHeight.Value
        Game.chestFreqMin = boxChestFreqMin.Value
        Game.chestFreqRange = boxChestFreqRange.Value
        Game.chestSizeDependence = boxChestSizeDependence.Value
        Game.chestRichnessBase = boxChestRichnessBase.Value
        Game.chestRichnessRange = boxChestRichnessRange.Value
        Game.encounterRate = boxEncounterRate.Value
        Game.eClockResetVal = boxEClockResetVal.Value
        Game.trapFreqMin = boxTrapFreqMin.Value
        Game.trapFreqRange = boxTrapFreqRange.Value
        Game.trapSizeDependence = boxTrapSizeDependence.Value
    End Sub
End Class