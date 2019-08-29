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
        Game.pushLstLog("Trap activated!")
        Select Case iD
            Case 0
                Game.player.lust += 20
                Game.player.health -= 2 / Game.player.getmaxHealth
                Dim out As String = "𝘱𝘸𝘩𝘪𝘱! You smack your neck, expecting a bug, only to feel a sharp pain as your smack crushes a small dart and leaks its contents all over your neck.  Initially fearing some sort of poison, the blushing of your cheeks and "
                If Game.player.prt.sexBool Then
                    out += "warmth between your legs "
                Else
                    out += "stiffening your cock "
                End If
                out += "is probably a sign that the dart was actually carrying a potent aphrodisiac."
                Game.pushLblEvent(out)
                Game.player.createP()
            Case 1
                Dim n As String = Game.player.equippedArmor.getName()
                Dim rng As Integer = Int(Rnd() * Game.currfloor.chestList.Count)
                Dim out As String = "A beam fires out of the wall to your left, striking you in the chest."
                If n <> "Ropes" Then
                    If n <> "Naked" Then
                        out += "  Your clothes glow a bright purple, before vanishing into the Æther, leaving you naked.  You look around frantically, before a quick check confirms that they are tucked away with your other gear."
                    Else
                        out += "  Since you're already naked, the beam doesn't seem to have done much."
                    End If
                    out += "  Shortly after, a bundle of rope drops from the ceiling, ensnaring you, and as it is pulled taut, you find yourself in a rather unique, less mobile, position."
                    If Game.player.breastSize > 5 Then
                        out += "  However, the ropes are not able to contain your massive breasts, and they quickly burst apart leaving you naked."
                        Equipment.clothesChange("Naked")
                        pos = New Point(-1, -1)
                        Game.pushLblEvent(out)
                        Exit Sub
                    End If
                Else
                    out += "  It doesn't seem to have done anything.  𝘞𝘦𝘪𝘳𝘥..."
                End If
                Game.player.inv.add(54, 1)
                Equipment.clothesChange("Ropes")
                Game.player.createP()
                If transformation.canbeTFed(Game.player) Then
                    Game.player.pState.save(Game.player)
                End If
                Game.player.UIupdate()
                Game.pushLblEvent(out)
            Case 2
                Dim rubyTF As Color = Color.FromArgb(185, 200, 55, 55)
                Dim r As Integer = Game.player.prt.skincolor.R + 50
                Dim g = Game.player.prt.skincolor.G
                Dim b = Game.player.prt.skincolor.B
                If r > 255 Then
                    r = 255
                    If g > 50 Then g -= 10
                    If g < 200 Then b -= 10
                End If

                Game.player.prt.skincolor = Color.FromArgb(Game.player.prt.skincolor.A, r, g, b)
                If transformation.canbeTFed(Game.player) Then
                    Game.player.pState.save(Game.player)
                End If
                Game.player.petrify(rubyTF, 1)
                Dim out As String = "As you walk through the dungeon, you see what looks like a valuable ruby on the ground, and you bend down to pick it up.  As soon as you touch it, a shock runs through your body, and starting with the hand you have on the gem your body is turned into ruby.  𝘚𝘩𝘪𝘵!  Looks like that ruby was probably cursed . . ."
                Game.pushLblEvent(out, AddressOf Trap.rubyRevert)
                Game.player.createP()
            Case 3
                Game.player.ongoingTFs.Add(New BUDollTF())
                Game.player.update()
            Case 4
                Dim out = "As your foot touches down on what looks to be the same ground that you have been walking on, you find that it is not met with any resistance.  Unable to keep your balance, you fall face first into the shiny waterlike facsimile of the floor and are thrown, flipping, into a another room.  As you regain your senses, you notice that you actually just ahead of where you were.  Turning around, you tap the floor you presumably fell out through, only to find it as solid as any other patch of floor you have come across.  Not able to find anything else abnormal with your surroundings, you write your expirience off as some failed illusion and set off on your way."
                If Game.player.prt.sexBool Then
                    Game.player.prt.setIAInd(1, Game.player.sState.iArrInd(1).Item1, False, Game.player.sState.iArrInd(1).Item3)
                    Game.player.prt.setIAInd(2, 0, True, False)
                    Game.player.prt.setIAInd(4, Game.player.sState.iArrInd(4).Item1, False, Game.player.sState.iArrInd(1).Item3)
                    Game.player.prt.setIAInd(5, Game.player.sState.iArrInd(5).Item1, False, Game.player.sState.iArrInd(1).Item3)
                    Game.player.prt.setIAInd(8, Game.player.sState.iArrInd(8).Item1, False, Game.player.sState.iArrInd(1).Item3)
                    Game.player.prt.setIAInd(10, Game.player.sState.iArrInd(10).Item1, False, Game.player.sState.iArrInd(1).Item3)
                    Game.player.prt.setIAInd(15, Game.player.sState.iArrInd(15).Item1, False, Game.player.sState.iArrInd(1).Item3)
                    Game.player.FtM()
                Else
                    Game.player.prt.setIAInd(1, Game.player.sState.iArrInd(1).Item1, True, Game.player.sState.iArrInd(1).Item3)
                    Game.player.prt.setIAInd(5, Game.player.sState.iArrInd(5).Item1, True, Game.player.sState.iArrInd(1).Item3)
                    Game.player.prt.setIAInd(8, Game.player.sState.iArrInd(8).Item1, True, Game.player.sState.iArrInd(1).Item3)
                    Game.player.prt.setIAInd(15, Game.player.sState.iArrInd(15).Item1, True, Game.player.sState.iArrInd(1).Item3)
                    Game.player.MtF()
                End If
                Game.player.createP()
                Game.player.UIupdate()
                Game.pushLblEvent(out)
            Case 5
                Game.pushLblEvent("""Hello again Doctor, "" a metallic voice chimes from a terminal to your right.  ""I was not aware of your return.  My appologies.  Would you like me to execute standard dress protocols at this time?""", AddressOf doctorAccept, AddressOf doctorCancel, "Give the command?")
            Case 6
                Game.pushLblEvent("Before you, you see a person-sized metal canister with an opened pink glass lid.  Looking at the chamber, you spot the text ""G.C.U"" written on the side, and a holographic countdown timer projected from a chome pedistal next to it.  This timer seems to be counting down to something called ""ConvProccess.exe"".  You think that you can fit in the canister, but you have no clue what will happen if you do...", AddressOf gConvChamb, AddressOf gcuCancel, "Get in the G.C.U?")
        End Select

        pos = New Point(-1, -1)
    End Sub

    Shared Sub rubyRevert()
        Game.player.revertToPState()
        Game.player.canMoveFlag = True
        Dim tr As Monster = New Monster(-1)
        Game.currfloor.statueList.Add(New Statue(tr))
        Game.pushLblEvent("𝑺𝒆𝒗𝒆𝒓𝒂𝒍 𝒅𝒂𝒚𝒔 𝒍𝒂𝒕𝒆𝒓..." & vbCrLf &
                           "As you stand frozen in the same position you've held since you touched the cursed stone, suddenly you fall flat faced onto the ground.  Springing to your feet, you are exited to find yourself as you were, albiet redder than before, and another explorer frozen in your place.  From their pose, it seems that they were going through your stuff, and must have accidently touched you.  What's more, the original ruby you touched is nowhere to be found.  You muse on the nature of the curse for a bit, before grabbing your things and moving on." & vbCrLf & vbCrLf & "Your stomach rumbles loudly, and you can tell that your time as a statue hasn't been kind to you.")
        Game.player.mana = 0
        Game.player.hunger += 60
    End Sub

    Sub doctorAccept()
        Game.pushLblEvent("""Very good.  Please step onto the equipping pad.""" & vbCrLf & vbCrLf &
                          "Spotting a raised area of the floor that looks to be equipped with all sorts of fancy machinery, you step onto it." & vbCrLf & vbCrLf &
                          """Thank you.  Please remain still.""" & vbCrLf & vbCrLf &
                          """Suddenly, the pad's machinery whirs to life.  While some of its many mechanical arms quickly strip you, others prepare a clinical looking labcoat and begin dressing you in it.  Finally, one arm places a pair of small glasses carefully onto your face and the pad returns to its idle state." & vbCrLf & vbCrLf &
                          """Have a nice day, doctor."" chimes the terminal, before darkening and going to sleep.")
        Equipment.clothesChange("Labcoat")
        Game.player.prt.setIAInd(12, 2, True, False)

        Game.player.createP()
    End Sub
    Sub doctorCancel()
        Game.pushLblEvent("""Very well.  Have a nice day, doctor."" chimes the terminal, before darkening and going to sleep.")
    End Sub
    Shared Sub gcuCancel()
        Game.pushLblEvent("The lid slams tightly shut, and the system begins whatever it was going to do.  You can not get in anymore.")
    End Sub
    Shared Sub gConvChamb()
        Dim out = "You climb into the chamber, mere seconds until the timer hits zero.  Almost as soon as you are clear, the lid slams tightly shut.  While you aren't exactly familiar with this level of technology, a forceful 'CHNK' is probably a sign that you won't be getting out until it's hatch opens back up.  Suddenly, a pink visor drops down onto your face from above.  A log of information starts on the visor, and as two antennae are positioned on the sides of your head you notice that some of the information is...yours?  Name, sex, age...this machine is reading your mind!  While this has you slightly worried, the fact that it seems to be populating a ""DELETION QUEUE"" has you ready to attempt to escape.  As you squirm, the machine takes notice and soon ""SECOND THOUGHTS PROTOCOL"" is flashing on the visor.  Beginning to relax that at least this crazy device has a failsafe, you fail to notice until it's too late that the deletion queue has been re-arranged.  All of a sudden, both the visor and the chambers lid become flashing strobes, and with each flash one of your attributes is marked as ""[deleted]"".  ""MOTOR FUNCTION"" is the first to go, followed by ""NAME"", ""AGE"", and ""LANGUAGE"", and before long a list of your negative emotions fly by on the screen.  Unable to fear, or mourn your loss, you sit idly as your body's abilities to do, well, anything, are erased one by one.  Finally, after what could be a few seconds or a millenia ""CONSCIOUSNESS"" is at the head of the queue.  With a final flash, everything goes dark."
        Dim p As Player = Game.player

        p.prt.setIAInd(6, 9, True, True)
        p.prt.setIAInd(12, 6, True, True)

        p.ongoingTFs.Add(New GynoidTF)

        Game.pushLblEvent(out, AddressOf p.update)
    End Sub
    Public Overrides Function ToString() As String
        Return pos.X & "*" & pos.Y & "*" & iD
    End Function
End Class
