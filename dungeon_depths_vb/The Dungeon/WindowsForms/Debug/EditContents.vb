Public Class EditContents
    Dim loc As Point
    Dim chest As Chest
    Dim inventoryList As List(Of String) = New List(Of String)

    Public Sub New(_x As Integer, _y As Integer)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        loc = New Point(_x, _y)
        loadChest()
        loadItems()
    End Sub

    Public Sub New(_p As Point)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        loc = _p
        loadChest()
        loadItems()
    End Sub

    Private Sub loadChest()
        For Each c In Game.currfloor.chestList
            If CType(c, Chest).pos = loc Then
                chest = c
                refreshChest()
                Exit For
            End If
        Next
    End Sub

    Private Sub loadItems()
        boxItems.Items.Clear()
        Dim p_inv = Game.player1.inv
        For i = 0 To p_inv.upperBound
            boxItems.Items.Add(p_inv.getKeyByID(i))
        Next
    End Sub

    Private Sub refreshChest()
        boxContents.Items.Clear()
        inventoryList.Clear()
        Dim c_inv = chest.contents
        For i = 0 To chest.contents.upperBound
            If chest.contents.getCountAt(i) > 0 Then
                boxContents.Items.Add(c_inv.getKeyByID(i) & " x" & c_inv.getCountAt(i).ToString())
                inventoryList.Add(c_inv.getKeyByID(i) & " x" & c_inv.getCountAt(i).ToString())
            End If
        Next
        contentsFilterUpdate()
    End Sub

    Private Sub boxContentsFilter_TextChanged(sender As Object, e As EventArgs) Handles boxContentsFilter.TextChanged
        contentsFilterUpdate()
    End Sub

    Private Sub boxItemsFilter_TextChanged(sender As Object, e As EventArgs) Handles boxItemsFilter.TextChanged
        itemFilterUpdate()
    End Sub

    Private Sub contentsFilterUpdate()
        boxContents.Items.Clear()
        For i As Integer = 0 To inventoryList.Count - 1
            If inventoryList(i).IndexOf(boxContentsFilter.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1 Then
                boxContents.Items.Add(inventoryList(i).ToString())
            End If
        Next
    End Sub

    Private Sub itemFilterUpdate()
        boxItems.Items.Clear()
        Dim p_inv = Game.player1.inv
        For i As Integer = 0 To Game.player1.inv.upperbound
            If p_inv.getKeyByID(i).IndexOf(boxItemsFilter.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1 Then
                boxItems.Items.Add(p_inv.getKeyByID(i).ToString())
            End If
        Next
    End Sub

    Private Sub btnSub_Click(sender As Object, e As EventArgs) Handles btnSub.Click
        If boxContents.SelectedIndices.Count < 1 Or boxAmt.Value < 1 Then Exit Sub
        Dim selected As ListBox.SelectedIndexCollection = boxContents.SelectedIndices
        Do Until selected.Count = 0
            Dim temp As Integer = selected(0)
            Dim name As String = inventoryList(temp)
            Dim itemInd As Integer = chest.contents.idOfKey(name)
            If boxAmt.Value >= chest.contents.getCountAt(itemInd) Then
                chest.contents.setCount(itemInd, 0)
                boxContents.Items.RemoveAt(temp) 'This will automatically remove that selected index
                inventoryList.RemoveAt(temp)
            Else
                chest.contents.add(itemInd, CInt(-boxAmt.Value))
                boxContents.Items(temp) = chest.contents.getKeyByID(itemInd) & " x" & chest.contents.getCountAt(itemInd)
                selected.Remove(0)
            End If
        Loop
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If boxItems.SelectedIndices.Count <> 0 And boxAmt.Value > 0 Then
            For i = 0 To boxItems.SelectedIndices.Count - 1
                Dim itemInd As Integer = chest.contents.idOfKey(boxItems.SelectedItems(i))
                chest.contents.add(itemInd, CInt(boxAmt.Value))
            Next
        End If
        refreshChest()
    End Sub

    Private Sub boxContents_SelectedIndexChanged(sender As Object, e As EventArgs) Handles boxContents.SelectedIndexChanged
        If boxItems.SelectedIndex <> -1 Then
            boxItems.SelectedIndex = -1
        End If
    End Sub

    Private Sub boxItems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles boxItems.SelectedIndexChanged
        If boxContents.SelectedIndex <> -1 Then
            boxContents.SelectedIndex = -1
        End If
    End Sub
End Class