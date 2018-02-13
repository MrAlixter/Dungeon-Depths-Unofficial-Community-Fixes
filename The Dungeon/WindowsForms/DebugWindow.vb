Imports System.ComponentModel
Imports System.Threading

Public Class Debug_Window
    Dim inventoryList As List(Of String) = New List(Of String)
    Dim itemsList As List(Of String) = New List(Of String)

    Private Sub Debug_Window_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clear()

        'GENERAL
        boxFloor.Value = Game.floor
        boxTurn.Value = Game.turn

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


        'PORTRAIT
        picPreview.Image = Game.picPortrait.BackgroundImage
        picPreview.BackgroundImage = Game.player.iArr(0)
        Dim PADDING = 0.1
        Dim w As Integer = 146
        Dim h As Integer = 216
        Dim threadCount As Integer = 4
        'Dim done As Array(threadCount)
        Dim go As Boolean = True
        While go

            'For i = 0 To UBound(done)

            'Next
        End While


        For i = 0 To tabPortrait.TabPages.Count - 1
            Dim x As Integer = w * PADDING
            Dim y As Integer = (tabPortrait.TabPages(i).Height - h) / 2
            For j = 0 To CharacterGenerator.fAttributes(i).Count - 1
                Dim img As New PictureBox
                img.Name = i.ToString() & ":" & j.ToString()
                tabPortrait.TabPages(i).Controls.Add(img)
                img.Image = CharacterGenerator.fAttributes(i)(j)
                img.BackgroundImage = CharacterGenerator.fAttributes(0)(0)
                img.Location = New Point(x, y) 'y - 20)
                img.Size = New Point(w, h)
                'img.BackgroundImageLayout = ImageLayout.Stretch
                AddHandler img.Click, AddressOf clickOnPic
                x += w * (1 + PADDING)
            Next
        Next


        'INVENTORY
        updateInventoryList()
        number.Value = 0
        updateItemsList()
    End Sub

    Private Function fillPages(first As Integer, last As Integer) '(Inclusive, exclusive)
        Dim worker As New BackgroundWorker

        Return True
    End Function

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
        If Game.player.sex = "Male" And boxSex.Items(boxSex.SelectedIndex) = "Female" Then
            Game.player.MtF()
        ElseIf Game.player.sex = "Female" And boxSex.Items(boxSex.SelectedIndex) = "Male" Then
            Game.player.FtM()
        End If
        picPreview.Image = Game.picPortrait.BackgroundImage
        picPreview.Update()
    End Sub

    Private Sub clickOnPic(sender As Object, e As EventArgs)
        Dim tab As Integer = sender.Name.Split(":")(0)
        Dim pic As Integer = sender.Name.Split(":")(1)

        Game.player.iArr(tab) = CType(sender, PictureBox).Image
        Game.player.iArrInd(tab) = New Tuple(Of Integer, Boolean)(tab, Game.player.sexBool)

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
        boxItems.SelectedIndex = -1
    End Sub

    Private Sub boxItems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles boxItems.SelectedIndexChanged
        boxInventory.SelectedIndex = -1
    End Sub
End Class