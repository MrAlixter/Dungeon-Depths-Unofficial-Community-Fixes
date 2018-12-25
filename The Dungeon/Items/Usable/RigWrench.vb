Public Class RigWrench
    Inherits Item

    Sub New()
        MyBase.setName("Disarment_Kit")
        MyBase.setDesc("A kit that disables any traps around you.")
        id = 57
        tier = 3
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 475
    End Sub

    Overrides Sub use()
        If Me.getUsable() = False Then Exit Sub
        Game.lstLog.Items.Add("You use the " & getName())

        Dim out As String = "No traps detected!"
        For indY = -1 To 1
            For indX = -1 To 1
                Dim y As Integer = Game.player.pos.Y + indY
                Dim x As Integer = Game.player.pos.X + indX
                If y < Game.mBoardHeight And y >= 0 And x < Game.mBoardWidth And x >= 0 Then
                    If Game.mBoard(y, x).Text = "+" Then
                        Dim id As Integer = -1
                        For i = 0 To Game.trapList.Count - 1
                            If Game.trapList(i).pos.Equals(New Point(x, y)) Then
                                Game.trapList(i).pos = New Point(-1, -1)
                                id = Game.trapList(i).id
                                Game.trapList.RemoveAt(i)
                                Game.mBoard(y, x).Text = ""
                                Exit For
                            End If
                        Next
                        Game.drawBoard()
                        Dim outout As String
                        Select Case id
                            Case 0
                                outout = "Trap disarmed! " & vbCrLf & " You have disarmed an aphrodisiac dart trap."
                            Case 1
                                outout = "Trap disarmed!" & vbCrLf & " You have disarmed an rope bondage trap. +1 Ropes"
                                Game.player.p_inventory.add(54, 1)
                            Case 2
                                outout = "Trap disarmed!" & vbCrLf & " You have disarmed an ruby trap."
                            Case 3
                                outout = "Trap disarmed!" & vbCrLf & "You have disarmed an blowup doll trap."
                            Case Else
                                outout = "Trap disarmed!" & vbCrLf & " You have disarmed an broken trap."
                        End Select
                        If out.Equals("No traps detected!") Then
                            out = outout
                        Else
                            out += vbCrLf
                            out += outout
                        End If
                        Game.pushLblEvent(out)
                        Game.lstLog.Items.Add("Trap disarmed!")
                    End If
                End If
            Next
        Next
        Game.drawBoard()
        count -= 1
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Overrides Sub discard()
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
