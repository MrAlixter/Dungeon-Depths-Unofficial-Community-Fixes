Public Class EditTile
    Dim x As Integer
    Dim y As Integer
    Dim t As mTile

    Public Sub SetLoc(p As Point)
        x = p.X
        y = p.Y

        Reload()
    End Sub

    Public Sub SetLoc(_x As Integer, _y As Integer)
        x = _x
        y = _y

        Reload()
    End Sub

    Private Sub Reload()
        t = Game.mBoard(y, x)

        lblPosition.Text = "POSITION: " & x & ", " & y
        lblTag.Text = "TAG: " & t.Tag.ToString()
        lblText.Text = "TEXT: " & t.Text.ToString()
        lblCol.Text = "COL: " & t.ForeColor.ToString()
    End Sub
End Class