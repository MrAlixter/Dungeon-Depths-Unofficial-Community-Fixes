Public Class Trap
    Public pos As Point
    Public iD As Integer
    Sub New(ByVal p As Point)
        pos = p
        iD = Int(Rnd() * 5)
    End Sub
    Sub New(ByVal s As String)
        Dim cArray() As String = s.Split("*")
        pos = New Point(CInt(cArray(0)), CInt(cArray(1)))
        iD = CInt(cArray(2))
    End Sub

    Public Sub activate(ByVal i As Integer)
        Game.lstLog.Items.Add("Trap activated!")
        Select Case iD
            Case 0
                Game.player.lust += 20
                Game.player.health -= 2 / Game.player.getmaxHealth
                Dim out As String = "𝘱𝘸𝘩𝘪𝘱! You smack your neck, expecting a bug, only to feel a sharp pain as your smack crushes a small dart and leaks its contents all over your neck.  Initially fearing some sort of poison, the blushing of your cheeks and "
                If Game.player.sexBool Then
                    out += "warmth between your legs "
                Else
                    out += "stiffening your cock "
                End If
                out += "is probably a sign that the dart was actually carrying a potent aphrodisiac."
                Game.pushLblEvent(out)
                Game.player.createP()
            Case 1
                Dim x As Integer = -1
                Dim n As String = Game.player.equippedArmor.getName()
                For i = 0 To Game.player.inventorynames.Count - 1
                    If Game.player.inventorynames(i).Equals(n) Then
                        x = i
                        Exit For
                    End If
                Next
                If x <> -1 Then Game.player.inventory(x).count -= 1
                Dim rng As Integer = Int(Rnd() * Game.chestList.Count)
                Dim out As String = "A beam fires out of the wall to your left, striking you in the chest."
                If n <> "Ropes" Then
                    If n <> "Naked" Then
                        out += "  Your clothes glow a bright purple, before vanishing into the Æther, leaving you naked.  You look around frantically, before accepting that they probably aren't coming back."
                    Else
                        out += "  Since you're already naked, the beam doesn't seem to have done much."
                    End If
                    out += "  Shortly after, a bundle of rope drops from the ceiling, ensnaring you, and as it is pulled taut, you find yourself in a rather unique, less mobile, position."
                    If Game.player.breastSize > 5 Then
                        out += "  However, the ropes are not able to contain your massive breasts, and they quickly burst apart leaving you naked."
                        Equipment.clothesChange("Naked")
                        pos = New Point(-1, -1)
                        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
                        Exit Sub
                    End If
                Else
                    out += "  It doesn't seem to have done anything.  𝘞𝘦𝘪𝘳𝘥..."
                End If
                Game.player.inventory(54).add(1)
                Equipment.clothesChange("Ropes")
                Equipment.portraitUDate()
                If transformation.canbeTFed(Game.player) Then
                    Game.player.pState.save(Game.player)
                End If
                Game.player.UIupdate()
                Game.pushLblEvent(out)
            Case 2
                Dim rubyTF As Color = Color.FromArgb(185, 200, 55, 55)
                Dim r As Integer = Game.player.skincolor.R + 50
                Dim g = Game.player.skincolor.G
                Dim b = Game.player.skincolor.B
                If r > 255 Then
                    r = 255
                    If g > 50 Then g -= 10
                    If g < 200 Then b -= 10
                End If

                Game.player.skincolor = Color.FromArgb(Game.player.skincolor.A, r, g, b)
                If transformation.canbeTFed(Game.player) Then
                    Game.player.pState.save(Game.player)
                End If
                Game.player.petrify(rubyTF)
                Dim out As String = "As you walk through the dungeon, you see what looks like a valuable ruby on the ground, and you bend down to pick it up.  As soon as you touch it, a shock runs through your body, and starting with the hand you have on the gem your body is turned into ruby.  𝘚𝘩𝘪𝘵!  Looks like that ruby was probably cursed . . ."
                Game.pushLblEvent(out, AddressOf Trap.rubyRevert)
                Game.player.createP()
            Case 3
                Game.player.ongoingTFs.Add(New BUDollTF())
                Game.player.update()
            Case 4
                Dim out = "As your foot touches down on what looks to be the same ground that you have been walking on, you find that it is not met with any resistance.  Unable to keep your balance, you fall face first into the shiny waterlike facsimile of the floor and are thrown, flipping, into a another room.  As you regain your senses, you notice that you actually just ahead of where you were.  Turning around, you tap the floor you presumably fell out through, only to find it as solid as any other patch of floor you have come across.  Not able to find anything else abnormal with your surroundings, you write your expirience off as some failed illusion and set off on your way."
                If Game.player.sexBool Then
                    Game.player.iArrInd(1) = New Tuple(Of Integer, Boolean)(Game.player.sState.iArrInd(1).Item1, False)
                    Game.player.iArrInd(2) = New Tuple(Of Integer, Boolean)(0, True)
                    Game.player.iArrInd(4) = New Tuple(Of Integer, Boolean)(Game.player.sState.iArrInd(4).Item1, False)
                    Game.player.iArrInd(5) = New Tuple(Of Integer, Boolean)(Game.player.sState.iArrInd(5).Item1, False)
                    Game.player.iArrInd(8) = New Tuple(Of Integer, Boolean)(Game.player.sState.iArrInd(8).Item1, False)
                    Game.player.iArrInd(10) = New Tuple(Of Integer, Boolean)(Game.player.sState.iArrInd(10).Item1, False)
                    Game.player.iArrInd(15) = New Tuple(Of Integer, Boolean)(Game.player.sState.iArrInd(15).Item1, False)
                    Game.player.FtM()
                Else
                    Game.player.iArrInd(1) = New Tuple(Of Integer, Boolean)(Game.player.sState.iArrInd(1).Item1, True)
                    Game.player.iArrInd(5) = New Tuple(Of Integer, Boolean)(Game.player.sState.iArrInd(5).Item1, True)
                    Game.player.iArrInd(8) = New Tuple(Of Integer, Boolean)(Game.player.sState.iArrInd(8).Item1, True)
                    Game.player.iArrInd(15) = New Tuple(Of Integer, Boolean)(Game.player.sState.iArrInd(15).Item1, True)
                    Game.player.MtF()
                End If
                Game.player.createP()
                Game.player.UIupdate()
                Game.pushLblEvent(out)
        End Select

        pos = New Point(-1, -1)
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub

    Shared Sub rubyRevert()
        Game.player.revertToPState()
        Game.player.canMoveFlag = True
        Dim tr As New Monster(-1)
        Game.statueList.Add(New Statue(tr))
        Game.pushLblEvent("𝑺𝒆𝒗𝒆𝒓𝒂𝒍 𝒅𝒂𝒚𝒔 𝒍𝒂𝒕𝒆𝒓..." & vbCrLf &
                           "As you stand frozen in the same position you've held since you touched the cursed stone, suddenly you fall flat faced onto the ground.  Springing to your feet, you are exited to find yourself as you were, albiet redder than before, and another explorer frozen in your place.  From their pose, it seems that they were going through your stuff, and must have accidently touched you.  What's more, the original ruby you touched is nowhere to be found.  You muse on the nature of the curse for a bit, before grabbing your things and moving on." & vbCrLf & vbCrLf & "Your stomach rumbles loudly, and you can tell that your time as a statue hasn't been kind to you.")
        Game.player.mana = 0
        Game.player.hunger += 60
    End Sub

    Public Overrides Function ToString() As String
        Return pos.X & "*" & pos.Y & "*" & iD
    End Function
End Class
