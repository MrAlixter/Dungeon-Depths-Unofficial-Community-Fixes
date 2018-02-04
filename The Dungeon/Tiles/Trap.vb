Public Class Trap
    Public pos As Point
    Public iD As Integer
    Sub New(ByVal p As Point, ByVal i As Integer)
        pos = p
        iD = i
    End Sub
    Sub New(ByVal s As String)
        Dim cArray() As String = s.Split("*")
        pos = New Point(CInt(cArray(0)), CInt(cArray(1)))
        iD = CInt(cArray(2))
    End Sub

    Public Sub activate()
        Form1.lstLog.Items.Add("Trap activated!")
        Select Case iD
            Case 0
                Form1.player.lust += 20
                Form1.player.health -= 2
                Dim out As String = "𝘱𝘸𝘩𝘪𝘱! You smack your neck, expecitng a bug, only to feel a sharp pain as your smack crushes a small dart and leaks its contents all over your neck.  Initially fearing some sort of poison, the blushing of your cheeks and "
                If Form1.player.sexBool Then
                    out += "warmth between your legs "
                Else
                    out += "stiffening your cock "
                End If
                out += "is probably a sign that the dart was acutally carrying a potent aphrodisiac."
                Form1.pushLblEvent(out)
                Form1.player.createP()
            Case 1
                Dim x As Integer = -1
                Dim n As String = Form1.player.equippedArmor.getName()
                For i = 0 To UBound(Form1.player.inventorynames)
                    If Form1.player.inventorynames(i).Equals(n) Then
                        x = i
                        Exit For
                    End If
                Next
                If x <> -1 Then Form1.player.inventory(x).count -= 1
                Dim out As String = "A beam fires out of the wall to your left, striking you in the chest."
                If n <> "Ropes" Then
                    If n <> "Naked" Then
                        out += "  Your clothes glow a bright purple, before vanishing into the Æther, leaving you naked.  You look around frantically, before accepting that they probably aren't coming back."
                    Else
                        out += "  Since you're already naked, the beam doesn't seem to have done much."
                    End If
                    out += "  Shortly after, a bundle of rope drops from the ceiling, ensnaring you, and as it is pulled taut, you find yourself in a rather unique, less mobile, position."
                Else
                    out += "  It doesn't seem to have done anything.  𝘞𝘦𝘪𝘳𝘥..."
                End If
                Form1.player.inventory(54).add(1)
                Form3.clothesChange("Ropes")
                Form3.portraitUDate()
                If Not Form1.player.perks(5) Or Not Form1.player.title.Equals("Magic Girl") Then
                    Form1.player.pState.save(Form1.player)
                End If
                Form1.player.UIupdate()
                Form1.player.createP()
                Form1.pushLblEvent(out)
            Case 2
                Dim ruby As Color = Color.FromArgb(255, 200, 55, 55)
                Dim rubyTF As Color = Color.FromArgb(185, 200, 55, 55)
                Form1.player.skincolor = Form1.cShift(Form1.player.skincolor, ruby, 50)
                Form1.player.pState.save(Form1.player)
                Form1.player.petrify(rubyTF)
                Dim out As String = "As you walk through the dungeon, you see what looks like a valuable ruby on the ground, and you bend down to pick it up.  As soon as you touch it, a shock runs through your body, and starting with the hand you have on the gem your body is turned into ruby.  𝘚𝘩𝘪𝘵!  Looks like that ruby was probably cursed . . ."
                Form1.pushLblEvent(out, AddressOf Trap.rubyRevert)
                Form1.player.createP()
            Case 3
                Form4.transform(Form1.player, "doll", 0)
            Case 4
        End Select

        pos = New Point(-1, -1)
        Form1.trapList.Remove(Me)
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
    End Sub

    Shared Sub rubyRevert()
        Form1.player.revert2()
        Form1.player.canMoveFlag = True
        Dim tr As New Monster(-1)
        Form1.statueList.Add(New Statue(tr))
        Form1.pushLblEvent("𝑺𝒆𝒗𝒆𝒓𝒂𝒍 𝒅𝒂𝒚𝒔 𝒍𝒂𝒕𝒆𝒓..." & vbCrLf & _
                           "As you stand frozen in the same position you've held since you touched the cursed stone, suddenly you fall flat faced onto the ground.  Springing to your feet, you are exited to find yourself as you were, albiet redder than before, and another explorer frozen in your place.  From their pose, it seems that they were going through your stuff, and must have accidently touched you.  What's more, the original ruby you touched is nowhere to be found.  You muse on the nature of the curse for a bit, before grabbing your things and moving on.  𝘘𝘶𝘦𝘴𝘵𝘪𝘰𝘯𝘴 𝘧𝘰𝘳 𝘢𝘯𝘰𝘵𝘩𝘦𝘳 𝘵𝘪𝘮𝘦...")
    End Sub

    Public Overrides Function ToString() As String
        Return pos.X & "*" & pos.Y & "*" & iD
    End Function
End Class
