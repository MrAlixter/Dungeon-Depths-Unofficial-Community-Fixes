Public Class DeathEffects
    '|MONSTER DEATHS|
    Shared Sub MBimboDeath()
        Dim p As Player = Game.player

        p.perks("bimbotf") = 1
        Dim out As String = "Exausted, you slump to the floor.  Glancing up, the horny mess attacking you seem to have gotten a running start, throwing herself on top of you, and pulling you into a sloppy kiss.  As she clumsily fumbles around, trying to remove your clothes, you roll out from underneath her and beat a hasty retreat, the faint sweetness of bubblegum lingering in your mouth."
        p.currTarget.despawn("p-death")
        Game.pushLblEvent(out)
    End Sub
    Shared Sub thrallDeath()
        Dim p As Player = Game.player
        Dim out As String = ""
        Dim ln1 As String = Nothing
        If p.pClass.name.Equals("Thrall") Then
            out = "Despite your fatigue, you are able to roll out of the way of the thrall's attempt to restrain you, and make a clumsy escape."

        Else
            ln1 = "As you collapse, you see the thrall pull a small metal collar out of their bag.  Lacking the strength to resist, you are powerless as they secure it firmly around your neck, all the while murmuring whispers of the joys of submission into your ear.  Once they have the collar fitted properly, they place a small glowing gem into a slot on the collar, igniting a small array of runes.  Your mind goes blank in an instant, and while at first an ammnesia-fueled panic sets in it is quickly replaced by a booming disembodied voice."
            p.inv.add(69, 1)
            Equipment.accChange("Slave_Collar")
            p.health = 1
            p.mana = p.getmaxMana()
            Game.player.will -= 3
            If Game.player.will < 1 Then Game.player.will = 0
        End If
        p.currTarget.despawn("p-death")
        If Not ln1 Is Nothing Then
            Game.pushLblEvent(ln1, AddressOf ThrallTF.thrallLN2)
        Else
            Game.pushLblEvent(out)
        End If
    End Sub
    Shared Sub sorcererDeath()
        Dim p As Player = Game.player
        Dim out As String = ""
        If p.pClass.name.Equals("Thrall") Then
            out = "Despite your fatigue, you are able to roll out of the way of the mage's attempt to restrain you, and make a clumsy escape."

        Else
            out = """Wonderful!"", your opponent exclaims as you collapse, ""You'll make a perfect thrall!""" & vbCrLf & _
                  "𝘛𝘩𝘳𝘢𝘭𝘭!? you think moments before a small metal collar finds its way around your neck and a network of runes inscribed on it begin glowing with your new master's magic.  𝘞𝘢𝘪𝘵 ... 𝘕𝘦𝘸 𝘔𝘈𝘚𝘛𝘌𝘙?!  You don't have a momment to rest before your mind is filled with a booming voice." & vbCrLf & _
                  """LISTEN UP, NEW SLAVE!  I have need of your services."" your new master begins, ""In this dungeon, there are several high-power mana arrays.  Only one of them, however, is capable of bestowing the power of a demon lord onto a mortal such as I.  Your task is to find and inspect these arrays, and report back to me with your findings.""  They snicker,  ""I'm sure you won't let me down, but I'm going to need to make a few changes to make you more ... uniform ... with the rest of your collegues.""" & vbCrLf & vbCrLf & "...       " & vbCrLf & vbCrLf & "With a final warning not to fail them, the foreign presence leaves your mind and you are once again alone with your thoughts and your task."
            p.inv.add(69, 1)
            If Not p.equippedAcce.getName.Equals("Nothing") Then p.equippedAcce.onUnequip()
            p.equippedAcce = p.inv.item(69)
            p.equippedAcce.onEquip()
            p.health = 1
            p.mana = p.getmaxMana()
            p.prefForm.snapShift(p)
            Game.player.will -= 3
            If Game.player.will < 1 Then Game.player.will = 0
        End If
        p.currTarget.despawn("p-death")
        Game.pushLblEvent(out)
    End Sub
    Shared Sub slimeDeath()
        Dim p As Player = Game.player
        Dim out As String = "As the " & p.currTarget.name & " closes in on you, you push yourself off the ground, sidestep it, and make a hasty retreat." & vbCrLf & " " & vbCrLf & "[Insert a TF here (eventually)]"
        p.currTarget.despawn("p-death")
        Game.pushLblEvent(out)
    End Sub
    Shared Sub spiderDeath()
        Dim p As Player = Game.player
        Dim out As String = "As the " & p.currTarget.name & " closes in on you, you push yourself off the ground, sidestep it, and make a hasty retreat." & vbCrLf & " " & vbCrLf & "[Insert a TF here (eventually)]"
        p.currTarget.despawn("p-death")
        Game.pushLblEvent(out)
    End Sub
    Shared Sub mimicDeath()
        Dim p As Player = Game.player
        p.currTarget.despawn("p-death")
        Dim out As String = "As you collapse, out of the corner of your eye you can see thick tendrils flowing out of the chest that could only be the body of the mimic.  Some of the tendrils wrap around your wrist and ankles, while others work their way up your thighs, aggressively groping your thighs."
        If p.equippedArmor.getName.Equals("Naked") Then
            out += "  As you black out, you can feel the tendrils writhing around you crotch.  As the darkness takes you, so does the orgasmic bliss of the mimic's magic touch."
            p.lust += 50
            p.createP()
            Game.pushLblEvent(out)

            Exit Sub
        End If
        out += "  As you black out, you can see the mimic working its way into your armor.  As the darkness takes you, so does the orgasmic bliss of the mimic's magic touch."
        Dim x As Integer = p.equippedArmor.getId
        p.inv.add(x, -1)
        p.equippedArmor = New LiveArmor
        p.inv.add(55, 1)
        p.perks(12) = True
        p.createP()
        Game.pushLblEvent(out)

    End Sub

    '|BOSS / MINIBOSS DEATHS|
    Shared Sub oozeEmpDeath()
        Dim p As Player = Game.player
        p.currTarget.despawn("p-death")
        Game.pushLblEvent("""Aww, sweetie, if you wanted another go you should have just asked!"", the Ooze Empress chuckles, her aphrodesiac-laced tendrils wrapping you in their arousing embrace.  ""You really do need to relax more.  Lucky for you, I have just the thing..."" she states, plunging your entire body deeper into her slime.  As the pleasure once again overtakes you, you resign yourself to needing to try again.  Well, maybe not right away...", AddressOf oEmpDeathPt2)
    End Sub
    Shared Sub oEmpDeathPt2()
        Dim p As Player = Game.player
        p.ongoingTFs.Add(New RandoTF())
        p.sState.save(p)
        p.pState.save(p)
        Game.pushLblEvent("You awaken once again, in another body, in another part of the dungeon.")
        Dim posX As Integer
        Dim posY As Integer
        Do While (Game.mBoard(posY, posX).Tag < 1 Or Game.mBoard(posY, posX).Text <> "" Or (posX.Equals(p.pos.X) And posY.Equals(p.pos.Y)))
            'MsgBox(CBool(Game.mBoard(posY, posX).Tag < 1) & "-" & CBool(Game.mBoard(posY, posX).Text <> "") & "-" & CBool(posX.Equals(p.pos.X) And posY.Equals(p.pos.Y)))
            posX = CInt(Int(Rnd() * Game.mBoardWidth))
            posY = CInt(Int(Rnd() * Game.mBoardHeight))
        Loop
        p.pos = New Point(posX, posY)

        p.update()
    End Sub

    '|NPC DEATHS|
    Shared Sub ShopkeeperDeath()
        Dim p As Player = Game.player
        Dim n As Shopkeep = Game.currNPC
        Game.fromCombat()
        p.petrify(Color.Goldenrod, 9999)
        Dim out As String = """You should have known better than to try and rob a shop keeper,"" the shopkeep says," &
            " glaring down at you, ""...and if its gold you're after, I guess I've got some good news for you.""" &
            "  With that, " & n.pronoun & " reaches into " & n.pPronoun & " bag and puts on a gaudy gauntlet " &
            "that begins glowing with a golden light. You lack the strength to fight back as " & n.pronoun & " places" &
            " his thumb on your forhead, and suddenly everything just seems so heavy. ""Noooo..."" you moan, " &
            "as the area around where he touched turns to gold, and that gold turns your flesh and blood " &
            "around it to gold as well. In a matter of seconds, all that is left of " & p.name & " the " &
            p.pClass.name & " is a solid gold statue. The shopkeeper sighs, muttering to no one in particular, " & vbCrLf &
         """Now how am I going to get you back to the refinery?""" & vbCrLf & vbCrLf & "GAME OVER!"
        Game.pushLblEvent(out, AddressOf p.die)
        p.pClass = p.classes("Trophy")
    End Sub

    '|MISC DEATH|
    Shared Sub hardDeath()
        Dim p As Player = Game.player
        p.isDead = True
        Dim r As Integer = CInt(Int(Rnd() * 2))
        If r = 0 Then
            Dim writer As IO.StreamWriter
            writer = IO.File.CreateText("gho.sts")
            writer.WriteLine(p.toGhost())
            writer.Flush()
            writer.Close()
        End If
        If MessageBox.Show("Game Over!  Reload a save?", "Game Over . . .", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                Game.combatmode = False
                Game.solFlag = True
                Game.toSOL()
                Exit Sub
            Catch ex As Exception
                MsgBox("No save detected!")
            End Try
        End If
        Game.formReset()
    End Sub

End Class
