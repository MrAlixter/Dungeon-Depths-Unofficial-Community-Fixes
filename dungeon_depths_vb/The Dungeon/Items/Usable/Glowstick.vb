Public Class Glowstick
    Inherits Item

    Sub New()
        MyBase.setName("Glowstick")
        MyBase.setDesc("A light source for illuminating the map.")
        id = 37
        tier = 1
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 250
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        Game.pushLstLog("You use the " & getName())

        For indY = -3 To 3
            For indX = -3 To 3
                If p.pos.Y + indY < Game.currFloor.mBoardHeight And p.pos.Y + indY >= 0 And p.pos.X + indX < Game.currFloor.mBoardWidth And p.pos.X + indX >= 0 Then
                    If Game.currFloor.mBoard(p.pos.Y + indY, p.pos.X + indX).Text = "H" And Game.currFloor.mBoard(p.pos.Y + indY, p.pos.X + indX).Tag < 2 Then
                        Game.currFloor.mBoard(p.pos.Y + indY, p.pos.X + indX).ForeColor = Color.Black
                        Game.pushLstLog("Floor " & Game.mDun.numCurrFloor & ": Staircase Discovered")
                    End If
                    If Game.currFloor.mBoard(p.pos.Y + indY, p.pos.X + indX).Text = "#" And Game.currFloor.mBoard(p.pos.Y + indY, p.pos.X + indX).Tag < 2 Then
                        Game.currFloor.mBoard(p.pos.Y + indY, p.pos.X + indX).ForeColor = Color.Black
                        Game.pushLstLog("Chest discovered!")
                    End If
                    If Game.currFloor.mBoard(p.pos.Y + indY, p.pos.X + indX).Text = "$" And Game.currFloor.mBoard(p.pos.Y + indY, p.pos.X + indX).Tag < 2 Then
                        Game.currFloor.mBoard(p.pos.Y + indY, p.pos.X + indX).ForeColor = Color.Navy
                        Game.pushLstLog("Shop discovered!")
                    End If
                    If Game.currFloor.mBoard(p.pos.Y + indY, p.pos.X + indX).Tag = 1 Then Game.currFloor.mBoard(p.pos.Y + indY, p.pos.X + indX).Tag = 2
                End If
            Next
        Next

        p.perks(perk.lightsource) = 60

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
            p.prt.haircolor = c
            p.drawPort()
            p.savePState()
        End If
        Game.drawBoard()
        count -= 1

    End Sub
End Class
