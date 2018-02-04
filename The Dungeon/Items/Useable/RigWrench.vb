Public Class RigWrench
    Inherits Item

    Sub New()
        MyBase.setName("Disarment_Kit")
        MyBase.setDesc("A kit that disables any traps around you.")
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 475
    End Sub

    Overrides Sub use()
        If Me.getUsable() = False Then Exit Sub
        Form1.lstLog.Items.Add("You use the " & getName())

        Dim out As String = "No traps detected!"
        For indY = -1 To 1
            For indX = -1 To 1
                If Form1.player.pos.Y + indY < Form1.mBoardHeight And Form1.player.pos.Y + indY >= 0 And Form1.player.pos.X + indX < Form1.mBoardWidth And Form1.player.pos.X + indX >= 0 Then
                    If Form1.mBoard(Form1.player.pos.Y + indY, Form1.player.pos.X + indX).Text = "+" Then
                        Dim id As Integer
                        For i = 0 To Form1.trapList.Count - 1
                            If Form1.trapList(i).pos = Form1.player.pos Then
                                Form1.trapList(i).pos = New Point(-1, -1)
                                id = Form1.trapList(i).id
                                Form1.trapList.Remove(Form1.trapList(i))
                            End If
                        Next
                        Dim outout As String
                        Select Case id
                            Case 0
                                outout = "Trap disarmed!" & vbCrLf & "You have disarmed an aphrodisiac dart trap."
                            Case Else
                                outout = "Trap disarmed!" & vbCrLf & "You have disarmed an rope bondage trap. +1 Ropes"
                                Form1.player.inventory(54).add(1)
                        End Select
                        If out.Equals("No traps detected!") Then
                            out = outout
                        Else
                            out += vbCrLf
                            out += outout
                        End If
                        Form1.pushLblEvent(out)
                        Form1.lstLog.Items.Add("Trap disarmed!")
                    End If
                End If
            Next
        Next
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
