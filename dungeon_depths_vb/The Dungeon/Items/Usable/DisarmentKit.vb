Public Class DisarmentKit
    Inherits Item

    Public Const ITEM_NAME As String = "Disarment_Kit"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 57
        tier = 3

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 475

        '|Description|
        setDesc("A kit that disables any traps around you.")
    End Sub

    Overrides Sub use(ByRef p As Player)
        MyBase.use(p)

        'start by assuming no traps have been found
        Dim out As String = "No traps detected!"
        Dim traps_detected As Integer = 0

        'scan all adjacent tiles to the player for traps
        For indY = -1 To 1
            For indX = -1 To 1
                'save the x/y position of the tile being scanned
                Dim scan_x = p.pos.X + indX
                Dim scan_y = p.pos.Y + indY

                'if a trap is found, disarm it
                If tileIsTrap(scan_x, scan_y) Then
                    For Each t In Game.currFloor.trapList
                        If t.pos.Equals(New Point(scan_x, scan_y)) Then
                            t.pos = New Point(-1, -1)
                            disarm(t.iD, traps_detected, out, p)
                            Game.currFloor.trapList.Remove(t)
                            Game.currFloor.mBoard(scan_y, scan_x).Text = ""
                            Exit For
                        End If
                    Next
                End If
            Next
        Next

        'print a dialog indicating whether a trap has been disarmed
        If traps_detected > 0 Then
            out = "You've detected " & traps_detected & " traps!" & DDUtils.RNRN & out
            TextEvent.pushLog("You've detected " & traps_detected & " traps!")
        Else
            TextEvent.pushLog(out)
        End If

        pushLblEventDisarm(out)

        'clean up anything else that needs doing
        Game.drawBoard()
        count -= 1
    End Sub

    Public Sub pushLblEventDisarm(ByRef s As String)
        s += DDUtils.PAKTC
        Game.lblEvent.Text = s
        Game.lblEvent.BringToFront()
        Game.lblEvent.Location = New Point((250 * Game.Size.Width / 688) - (Game.lblEvent.Size.Width / 2), 65 * Game.Size.Width / 688)
        Game.lblEvent.Visible = True
        Game.player1.inv.invNeedsUDate = True
    End Sub

    Public Function tileIsTrap(ByVal x As Integer, ByVal y As Integer) As Boolean
        'if the tile is out of bounds, it isn't a trap
        If Not Game.currFloor.ptInBounds(New Point(x, y)) Then Return False

        'if the tile's text is not the symbol for trap (+), it isn't a trap
        If Not Game.currFloor.mBoard(y, x).Text = "+" Then Return False

        'if the floor's trap list contains a trap at that tile, it is a trap
        For Each t In Game.currFloor.trapList
            If t.pos.Equals(New Point(x, y)) Then Return True
        Next

        'it isn't a trap
        Return False
    End Function

    Public Sub disarm(ByVal trap_ind As Integer, ByRef traps_detected As Integer, ByRef out As String, ByRef p As Player)
        'for the first trap detected, update the message that will be printed
        If traps_detected < 1 Then out = ""

        Select Case trap_ind
            Case tInd.dart
                out += " - Aphrodisiac Dart Trap"
            Case tInd.rope
                out += " - Rope Bondage Trap." & vbCrLf &
                         "   +1 Ropes"
                p.inv.add("Ropes", 1)
            Case tInd.ruby
                out += " - Ruby Trap"
            Case tInd.coupon
                out += " - Blowup Doll Trap" & vbCrLf &
                         "   +1 Cursed Cupon"
                p.inv.add("Cursed_Coupon", 1)
            Case tInd.mirror
                out += " - Mirror Trap"
            Case tInd.gag
                out += " - Ball Gag Trap" & vbCrLf &
                         "   +1 Ball Gag"
                p.inv.add("Ball_Gag", 1)
            Case Else
                out += " - Unidentifiable Trap"
        End Select

        out += vbCrLf

        traps_detected += 1
    End Sub
End Class
