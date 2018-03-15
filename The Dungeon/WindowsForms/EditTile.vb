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
        lblText.Text = "TEXT: " & t.Text.ToString()
        lblCol.Text = "COL: " & t.ForeColor.ToString()
        boxOptions.Visible = False
        If (Game.mBoard(y, x).Text = "#") Then 'Chest
            lblType.Text = "TYPE: Chest"
            boxOptions.Visible = True
        ElseIf (Game.mBoard(y, x).Text = "H") Then 'Stairs
            lblType.Text = "TYPE: Stairs"
            boxOptions.Visible = True
        ElseIf (Game.mBoard(y, x).Text = "@" And Game.player.pos.X = x And Game.player.pos.Y = y) Then 'Player
            lblType.Text = "TYPE: Player"
        ElseIf (Game.mBoard(y, x).Text = "@") Then 'Statue
            lblType.Text = "TYPE: Statue"
        ElseIf (Game.mBoard(y, x).Text = "$") Then 'NPC
            lblType.Text = "TYPE: NPC"
        ElseIf (Game.mBoard(y, x).Tag = 0) Then 'Wall
            lblType.Text = "TYPE: WALL"
        Else 'Walkable
            lblType.Text = "TYPE: WALKABLE"
        End If

        If (Game.mBoard(y, x).Tag = 2) Then 'Seen
            boxSeen.Checked = True
            boxWall.Checked = False
        ElseIf (Game.mBoard(y, x).Tag = 1) Then 'Unseen
            boxSeen.Checked = False
            boxWall.Checked = False
        Else 'WALL
            boxSeen.Enabled = False
            boxWall.Checked = True
        End If
        updateTagLbl()
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

    Private Sub boxWall_CheckedChanged(sender As Object, e As EventArgs) Handles boxWall.CheckedChanged
        If boxWall.Checked Then
            t.Tag = 0
            boxSeen.Enabled = False
            boxSeen.Checked = False
        Else
            t.Tag = 1
            boxSeen.Enabled = True
            boxSeen.Checked = False
        End If
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

    Private Sub EditTile_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim tag As Integer
        If Not boxSeen.Enabled Then
            tag = 0
        ElseIf boxSeen.Checked Then
            tag = 2
        ElseIf Not boxSeen.Checked Then
            tag = 1
        End If
        Game.mBoard(y, x).Tag = tag
        Game.mBoard(y, x).Text = t.Text
        Game.mBoard(y, x).ForeColor = t.ForeColor
    End Sub
End Class