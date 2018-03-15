Public Class EditContents
    Dim loc As Point

    Public Sub New(_x As Integer, _y As Integer)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        loc = New Point(_x, _y)
        loadChest()
    End Sub

    Public Sub New(_p As Point)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        loc = _p
        loadChest()
    End Sub

    Private Sub loadChest()
        For Each chest In Game.chestList
            If CType(chest, Chest).pos = loc Then
                Dim c As Chest = CType(chest, Chest)
                For i = 0 To c.contents.Count - 1
                    If c.contents(i) > 0 Then
                        boxContents.Items.Add(CType(Game.player.inventory(i), Item).getName())
                    End If
                Next
                Exit For
            End If
        Next
        boxContents.Invalidate()
    End Sub
End Class