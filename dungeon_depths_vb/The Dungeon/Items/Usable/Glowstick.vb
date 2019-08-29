Public Class Glowstick
    Inherits Item

    Sub New()
        MyBase.setName("Glowstick")
        MyBase.setDesc("A light source for illuminating the map.")
        id = 37
        tier = 1
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 150
    End Sub

    Overrides Sub use()
        If Me.getUsable() = False Then Exit Sub
        Game.pushLstLog("You use the " & getName())

        For indY = -3 To 3
            For indX = -3 To 3
                If Game.player.pos.Y + indY < Game.mBoardHeight And Game.player.pos.Y + indY >= 0 And Game.player.pos.X + indX < Game.mBoardWidth And Game.player.pos.X + indX >= 0 Then
                    If Game.currfloor.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).Text = "H" And Game.currfloor.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).Tag < 2 Then
                        Game.currfloor.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).ForeColor = Color.Black
                        Game.pushLstLog("Floor " & game.mDun.numCurrFloor & ": Staircase Discovered")
                    End If
                    If Game.currfloor.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).Text = "#" And Game.currfloor.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).Tag < 2 Then
                        Game.currfloor.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).ForeColor = Color.Black
                        Game.pushLstLog("Chest discovered!")
                    End If
                    If Game.currfloor.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).Text = "$" And Game.currfloor.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).Tag < 2 Then
                        Game.currfloor.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).ForeColor = Color.Navy
                        Game.pushLstLog("Shop discovered!")
                    End If
                    If Game.currfloor.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).Tag = 1 Then Game.currfloor.mBoard(Game.player.pos.Y + indY, Game.player.pos.X + indX).Tag = 2
                End If
            Next
        Next

        Dim r As Integer = (Int(Rnd() * 7))
        If r = 0 Then
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
            Game.pushLblEvent("As you crack the glowstick to activate it, the tube cracks open slightly, spraying some fluid on your face.  You wipe it off, and while you don't feel any different, your hair seems a little more...vibrant than it was before.")
            Game.player.prt.haircolor = c
            Game.player.createP()
            If Transformation.canBeTFed(Game.player) Then
                Game.player.pState.save(Game.player)
            End If
        End If
        Game.drawBoard()
        count -= 1
        
    End Sub
    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())
        
        count -= 1
    End Sub
End Class
