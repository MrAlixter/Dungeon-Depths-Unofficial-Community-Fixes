Public Class Glowstick
    Inherits Item

    Sub New()
        MyBase.setName("Glowstick")
        MyBase.setDesc("A light source for illuminating the map.")
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 150
    End Sub

    Overrides Sub use()
        If Me.getUsable() = False Then Exit Sub
        Form1.lstLog.Items.Add("You use the " & getName())

        For indY = -3 To 3
            For indX = -3 To 3
                If Form1.player.pos.Y + indY < Form1.mBoardHeight And Form1.player.pos.Y + indY >= 0 And Form1.player.pos.X + indX < Form1.mBoardWidth And Form1.player.pos.X + indX >= 0 Then
                    If Form1.mBoard(Form1.player.pos.Y + indY, Form1.player.pos.X + indX).Text = "H" And Form1.mBoard(Form1.player.pos.Y + indY, Form1.player.pos.X + indX).Tag < 2 Then
                        Form1.mBoard(Form1.player.pos.Y + indY, Form1.player.pos.X + indX).ForeColor = Color.Black
                        Form1.lstLog.Items.Add("Floor " & Form1.floor & ": Staircase Discovered")
                    End If
                    If Form1.mBoard(Form1.player.pos.Y + indY, Form1.player.pos.X + indX).Text = "#" And Form1.mBoard(Form1.player.pos.Y + indY, Form1.player.pos.X + indX).Tag < 2 Then
                        Form1.mBoard(Form1.player.pos.Y + indY, Form1.player.pos.X + indX).ForeColor = Color.Black
                        Form1.lstLog.Items.Add("Chest discovered!")
                    End If
                    If Form1.mBoard(Form1.player.pos.Y + indY, Form1.player.pos.X + indX).Text = "$" And Form1.mBoard(Form1.player.pos.Y + indY, Form1.player.pos.X + indX).Tag < 2 Then
                        Form1.mBoard(Form1.player.pos.Y + indY, Form1.player.pos.X + indX).ForeColor = Color.Navy
                        Form1.lstLog.Items.Add("Shop discovered!")
                    End If
                    If Form1.mBoard(Form1.player.pos.Y + indY, Form1.player.pos.X + indX).Tag = 1 Then Form1.mBoard(Form1.player.pos.Y + indY, Form1.player.pos.X + indX).Tag = 2
                End If
            Next
        Next

        Dim r As Integer = (Int(Rnd() * 7))
        If r = 0 And (Form1.player.iArrInd(1).Item1 < 5 Or (Form1.player.iArrInd(1).Item2 And Form1.player.iArrInd(1).Item1 = 7)) Then
            Dim rc As Integer = (Int(Rnd() * 6))
            Dim c As Color
            Select Case rc
                Case 0
                    c = Color.Cyan
                Case 1
                    c = Color.HotPink
                Case 2
                    c = Color.LimeGreen
                Case 3
                    c = Color.OrangeRed
                Case 4
                    c = Color.Violet
                Case 5
                    c = Color.GreenYellow
            End Select
            If Form1.player.iArrInd(1).Item1 < 5 Or (Form1.player.iArrInd(1).Item1 = 7 And Form1.player.sexBool) Then
                Form1.pushLblEvent("As you crack the glowstick to activate it, the tube cracks open slightly, spraying some fluid on your face.  You wipe it off, and while you don't feel any different, your hair seems a little more...vibrant than it was before.")
                Form1.player.haircolor = c
                Form1.player.createP()
                If Not Form1.player.perks(5) Or Not Form1.player.title.Equals("Magic Girl") Then
                    Form1.player.pState.save(Form1.player)
                End If
            Else
                Form1.pushLblEvent("As you crack the glowstick to activate it, the tube cracks open slightly, spraying some fluid on your face.  You wipe it off, and nothing unusual seems to have happened.")
            End If
        End If
        Form1.drawBoard()
        count -= 1
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
    End Sub
    Overrides Sub discard()
        Form1.lstLog.Items.Add("You drop the " & getName())
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
