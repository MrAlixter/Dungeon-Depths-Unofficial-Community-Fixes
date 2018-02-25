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

    Public Sub activate(ByVal i As Integer)
        Game.lstLog.Items.Add("Trap activated!")
        Select Case iD
            Case 0
                Game.player.lust += 20
                Game.player.health -= 2
                Dim out As String = "𝘱𝘸𝘩𝘪𝘱! You smack your neck, expecitng a bug, only to feel a sharp pain as your smack crushes a small dart and leaks its contents all over your neck.  Initially fearing some sort of poison, the blushing of your cheeks and "
                If Game.player.sexBool Then
                    out += "warmth between your legs "
                Else
                    out += "stiffening your cock "
                End If
                out += "is probably a sign that the dart was acutally carrying a potent aphrodisiac."
                Game.pushLblEvent(out)
                Game.player.createP()
            Case 1
                Dim x As Integer = -1
                Dim n As String = Game.player.equippedArmor.getName()
                For i = 0 To Game.player.inventorynames.Count
                    If Game.player.inventorynames(i).Equals(n) Then
                        x = i
                        Exit For
                    End If
                Next
                If x <> -1 Then Game.player.inventory(x).count -= 1
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
                Game.player.inventory(54).add(1)
                Equipment.clothesChange("Ropes")
                Equipment.portraitUDate()
                If Not Game.player.perks("polymorphed") > -1 And Not Game.player.title.Equals("Magic Girl") Then
                    Game.player.pState.save(Game.player)
                End If
                Game.player.UIupdate()
                Game.player.createP()
                Game.pushLblEvent(out)
            Case 2
                Dim rubyTF As Color = Color.FromArgb(185, 200, 55, 55)
                Game.player.skincolor = Game.cShift(Game.player.skincolor, Color.Crimson, 50)
                Game.player.pState.save(Game.player)
                Game.player.petrify(rubyTF)
                Dim out As String = "As you walk through the dungeon, you see what looks like a valuable ruby on the ground, and you bend down to pick it up.  As soon as you touch it, a shock runs through your body, and starting with the hand you have on the gem your body is turned into ruby.  𝘚𝘩𝘪𝘵!  Looks like that ruby was probably cursed . . ."
                Game.pushLblEvent(out, AddressOf Trap.rubyRevert)
                Game.player.createP()
            Case 3
                Polymorph.transform(Game.player, "doll", 0)
            Case 4
        End Select

        pos = New Point(-1, -1)
        Game.trapList.RemoveAt(i)
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub

    Shared Sub rubyRevert()
        Game.player.revert2()
        Game.player.canMoveFlag = True
        Dim tr As New Monster(-1)
        Game.statueList.Add(New Statue(tr))
        Game.pushLblEvent("𝑺𝒆𝒗𝒆𝒓𝒂𝒍 𝒅𝒂𝒚𝒔 𝒍𝒂𝒕𝒆𝒓..." & vbCrLf & _
                           "As you stand frozen in the same position you've held since you touched the cursed stone, suddenly you fall flat faced onto the ground.  Springing to your feet, you are exited to find yourself as you were, albiet redder than before, and another explorer frozen in your place.  From their pose, it seems that they were going through your stuff, and must have accidently touched you.  What's more, the original ruby you touched is nowhere to be found.  You muse on the nature of the curse for a bit, before grabbing your things and moving on.  𝘘𝘶𝘦𝘴𝘵𝘪𝘰𝘯𝘴 𝘧𝘰𝘳 𝘢𝘯𝘰𝘵𝘩𝘦𝘳 𝘵𝘪𝘮𝘦...")
    End Sub

    Public Overrides Function ToString() As String
        Return pos.X & "*" & pos.Y & "*" & iD
    End Function
End Class
