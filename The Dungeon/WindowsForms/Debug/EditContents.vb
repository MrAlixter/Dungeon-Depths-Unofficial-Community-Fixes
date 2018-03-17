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
        For Each c In Game.chestList
            If CType(c, Chest).pos = loc Then
                chest = c
                refreshChest()
                Exit For
            End If
        Next
    End Sub

    Private Sub loadItems()
        For i = 0 To Game.player.inventorynames.Count - 1
            boxItems.Items.Add(Game.player.inventorynames(i))
        Next
    End Sub

    Private Sub refreshChest()
        boxContents.Items.Clear()
        inventoryList.Clear()
        For i = 0 To chest.contents.Count - 1
            If chest.contents(i) > 0 Then
                boxContents.Items.Add(Game.player.inventorynames(i) & " x" & chest.contents(i).ToString())
                inventoryList.Add(Game.player.inventorynames(i))
            End If
        Next
    End Sub

    Private Sub btnSub_Click(sender As Object, e As EventArgs) Handles btnSub.Click
        If boxContents.SelectedIndices.Count < 1 Or boxAmt.Value < 1 Then Exit Sub
        Dim selected As ListBox.SelectedIndexCollection = boxContents.SelectedIndices
        Do Until selected.Count = 0
            Dim temp As Integer = selected(0)
            Dim name As String = inventoryList(temp)
            Dim itemInd As Integer = Game.player.inventorynames.IndexOf(name)
            If boxAmt.Value >= chest.contents(itemInd) Then
                chest.contents(itemInd) = 0
                boxContents.Items.RemoveAt(temp) 'This will automatically remove that selected index
                inventoryList.RemoveAt(temp)
            Else
                chest.contents(itemInd) -= boxAmt.Value
                boxContents.Items(temp) = Game.player.inventorynames(itemInd) & " x" & chest.contents(itemInd)
                selected.Remove(0)
            End If
        Loop
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If boxItems.SelectedIndices.Count <> 0 And boxAmt.Value > 0 Then
            For i = 0 To boxItems.SelectedIndices.Count - 1
                chest.contents(boxItems.SelectedIndices(i)) += boxAmt.Value
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