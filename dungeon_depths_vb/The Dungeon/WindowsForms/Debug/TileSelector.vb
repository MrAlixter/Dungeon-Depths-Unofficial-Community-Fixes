Imports System.Threading

Public Class TileSelector
    Dim magnification As Integer
    Dim map As Bitmap
    Dim prevSelectP As Point = New Point(-1, -1)
    Dim prevSelectC As Color = Nothing
    Dim dragging As Boolean
    Dim xOffset As Integer
    Dim yOffset As Integer
    Dim mouseMoveThread As Thread
    Private Delegate Sub delegateExecute()

    Public saveChoice As Boolean = False
    Public selected As Point

    Private Sub Debug_Window_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dragging = False
        xOffset = 0
        yOffset = 0
        unselectMapControlButtons()
        btnPan.Checked = True

        magnification = Math.Floor(Math.Min(picBoard.Width / Game.mBoardWidth, picBoard.Height / Game.mBoardHeight))
        boxZoom.Value = magnification
        createMap()
        AddHandler picBoard.Paint, AddressOf Me.picBoard_Draw
        AddHandler picBoard.MouseDown, AddressOf Me.mapMousePress
        AddHandler picBoard.MouseUp, AddressOf Me.mapMouseRelease
    End Sub

    Private Sub unselectMapControlButtons()
        For i = 0 To boxMapControls.Controls.Count - 1
            If TypeOf (boxMapControls.Controls(i)) Is RadioButton Then
                CType(boxMapControls.Controls(i), RadioButton).Checked = False
            End If
        Next
    End Sub

    Private Sub createMap()
        map = New Bitmap(Game.mBoardWidth + 2, Game.mBoardHeight + 2)
        For boardX = 0 To map.Width - 3
            For boardY = 0 To map.Height - 3
                If (Game.currfloor.mBoard(boardY, boardX).Text = "#") Then 'Chest
                    map.SetPixel(boardX + 1, boardY + 1, Color.Yellow)
                ElseIf (Game.currfloor.mBoard(boardY, boardX).Text = "H") Then 'Stairs
                    map.SetPixel(boardX + 1, boardY + 1, Color.Sienna)
                ElseIf (Game.currfloor.mBoard(boardY, boardX).Text = "@" And Game.player1.pos.X = boardX And Game.player1.pos.Y = boardY) Then 'Player
                    map.SetPixel(boardX + 1, boardY + 1, Color.LawnGreen)
                ElseIf (Game.currfloor.mBoard(boardY, boardX).Text = "@") Then 'Statue
                    map.SetPixel(boardX + 1, boardY + 1, Color.LightSlateGray)
                ElseIf (Game.currfloor.mBoard(boardY, boardX).Text = "$") Then 'NPC
                    map.SetPixel(boardX + 1, boardY + 1, Color.Blue)
                ElseIf (Game.currfloor.mBoard(boardY, boardX).Text = "+") Then 'Trap
                    map.SetPixel(boardX + 1, boardY + 1, Color.Red)
                ElseIf (Game.currfloor.mBoard(boardY, boardX).Tag = 2) Then 'Seen
                    map.SetPixel(boardX + 1, boardY + 1, Color.White)
                ElseIf (Game.currfloor.mBoard(boardY, boardX).Tag = 1) Then 'Unseen
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

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        saveChoice = False
        selected = Nothing
        Me.Close()
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        If prevSelectP = Nothing Then
            MessageBox.Show("NOTHING SELECTED")
            Exit Sub
        End If
        saveChoice = True
        selected = prevSelectP
        Me.Close()
    End Sub
End Class