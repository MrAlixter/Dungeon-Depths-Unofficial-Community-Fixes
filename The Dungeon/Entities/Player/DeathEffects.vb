Public Class DeathEffects
    Shared p = Game.player

    '|MONSTER DEATHS|
    Shared Sub MBimboDeath()
        p.perks("bimbotf") = 1
        Dim out As String = "Exausted, you slump to the floor.  Glancing up, the horny mess attacking you seem to have gotten a running start, throwing herself on top of you, and pulling you into a sloppy kiss.  As she clumsily fumbles around, trying to remove your clothes, you roll out from underneath her and beat a hasty retreat, the faint sweetness of bubblegum lingering in your mouth."
        p.currTarget.despawn("run")
        Game.pushLblEvent(out)
        p.health = 0.1
    End Sub
    Shared Sub thrallDeath()
        Dim out As String = ""
        Dim ln1 As String = Nothing
        If p.pClass.name.Equals("Thrall") Then
            out = "Despite your fatigue, you are able to roll out of the way of the thrall's attempt to restrain you, and make a clumsy escape."
            p.health = 0.1
        Else
            ln1 = "As you collapse, you see the thrall pull a small metal collar out of their bag.  Lacking the strength to resist, you are powerless as they secure it firmly around your neck, all the while murmuring whispers of the joys of submission into your ear.  Once they have the collar fitted properly, they place a small glowing gem into a slot on the collar, igniting a small array of runes.  Your mind goes blank in an instant, and while at first an ammnesia-fueled panic sets in it is quickly replaced by a booming disembodied voice."
            p.inventory(69).addone()
            Equipment.accChange("Slave_Collar")
            p.health = 1
            p.mana = p.getmaxMana()
            Game.player.will -= 3
            If Game.player.will < 1 Then Game.player.will = 0
        End If
        p.currTarget.despawn("run")
        If Not ln1 Is Nothing Then
            Game.pushLblEvent(ln1, AddressOf p.thrallLN2)
        Else
            Game.pushLblEvent(out)
        End If
    End Sub
    Shared Sub sorcererDeath()
        Dim out As String = ""
        If p.pClass.name.Equals("Thrall") Then
            out = "Despite your fatigue, you are able to roll out of the way of the mage's attempt to restrain you, and make a clumsy escape."
            p.health = 0.1
        Else
            out = """Wonderful!"", your opponent exclaims as you collapse, ""You'll make a perfect thrall!""" & vbCrLf & _
                  "𝘛𝘩𝘳𝘢𝘭𝘭!? you think moments before a small metal collar finds its way around your neck and a network of runes inscribed on it begin glowing with your new master's magic.  𝘞𝘢𝘪𝘵 ... 𝘕𝘦𝘸 𝘔𝘈𝘚𝘛𝘌𝘙?!  You don't have a momment to rest before your mind is filled with a booming voice." & vbCrLf & _
                  """LISTEN UP, NEW SLAVE!  I have need of your services."" your new master begins, ""In this dungeon, there are several high-power mana arrays.  Only one of them, however, is capable of bestowing the power of a demon lord onto a mortal such as I.  Your task is to find and inspect these arrays, and report back to me with your findings.""  They snicker,  ""I'm sure you won't let me down, but I'm going to need to make a few changes to make you more ... uniform ... with the rest of your collegues.""" & vbCrLf & vbCrLf & "...       " & vbCrLf & vbCrLf & "With a final warning not to fail them, the foreign presence leaves your mind and you are once again alone with your thoughts and your task."
            p.inventory(69).addone()
            If Not p.equippedAcce.getName.Equals("Nothing") Then p.equippedAcce.onUnequip()
            p.equippedAcce = p.inventory(69)
            p.equippedAcce.onEquip()
            p.health = 1
            p.mana = p.getmaxMana()
            p.prefForm.snapShift(p.Me)
            Game.player.will -= 3
            If Game.player.will < 1 Then Game.player.will = 0
        End If
        p.currTarget.despawn("run")
        Game.pushLblEvent(out)
    End Sub
    Shared Sub slimeDeath()
        Dim out As String = "As the " & p.currTarget.name & " closes in on you, you push yourself off the ground, sidestep it, and make a hasty retreat." & vbCrLf & " " & vbCrLf & "[Insert a TF here (eventually)]"
        p.currTarget.despawn("run")
        Game.pushLblEvent(out)
        p.health = 0.1
    End Sub
    Shared Sub spiderDeath()
        Dim out As String = "As the " & p.currTarget.name & " closes in on you, you push yourself off the ground, sidestep it, and make a hasty retreat." & vbCrLf & " " & vbCrLf & "[Insert a TF here (eventually)]"
        p.currTarget.despawn("run")
        Game.pushLblEvent(out)
        p.health = 0.1
    End Sub
    Shared Sub mimicDeath()
        p.currTarget.despawn("run")
        Dim out As String = "As you collapse, out of the corner of your eye you can see thick tendrils flowing out of the chest that could only be the body of the mimic.  Some of the tendrils wrap around your wrist and ankles, while others work their way up your thighs, aggressively groping your thighs."
        If p.equippedArmor.getName.Equals("Naked") Then
            out += "  As you black out, you can feel the tendrils writhing around you crotch.  As the darkness takes you, so does the orgasmic bliss of the mimic's magic touch."
            p.lust += 50
            p.createP()
            Game.pushLblEvent(out)
            p.health = 0.1
            Exit Sub
        End If
        out += "  As you black out, you can see the mimic working its way into your armor.  As the darkness takes you, so does the orgasmic bliss of the mimic's magic touch."
        Dim x As Integer = -1
        Dim n As String = p.equippedArmor.getName()
        For i = 0 To p.inventorynames.Count - 1
            If p.inventorynames(i).Equals(n) Then
                x = i
                Exit For
            End If
        Next
        If x <> -1 Then p.inventory(x).count -= 1
        p.equippedArmor = New LiveArmor
        p.inventory(55).add(1)
        p.perks(12) = True
        Equipment.portraitUDate()
        Game.pushLblEvent(out)
        p.health = 0.1
    End Sub

    '|NPC DEATHS|
    Shared Sub ShopkeeperDeath()
        Dim n As NPC = Game.currNPC
        p.Petrify(Color.Goldenrod)
        Dim out As String = """You should have known better than to try and rob a shop keeper,"" the shopkeep says," & vbCrLf &
            " glaring down at you, ""...and if its gold you're after, I guess I've got some good news for you.""" & vbCrLf &
            "  With that, " & n.pronoun & " reaches into " & n.pPronoun & " bag and puts on a gaudy gauntlet " & vbCrLf &
            "that begins glowing with a golden light. You lack the strength to fight back as " & n.pronoun & " places" & vbCrLf &
            " his thumb on your forhead, and suddenly everything just seems so heavy. ""Noooo..."" you moan, " & vbCrLf &
            "as the area around where he touched turns to gold, and that gold turns your flesh and blood " & vbCrLf &
            "around it to gold as well. In a matter of seconds, all that is left of " & p.Me.name & " the " & vbCrLf &
            p.Me.pClass.name & " is a solid gold statue. The shopkeeper sighs, muttering to no one in particular, " & vbCrLf &
            vbCrLf & vbCrLf & """Now how am I going to get you back to the refinery?"""
        'Game.pushLblEvent(out)
        p.pClass = p.classes("Trophy")
        MsgBox(out)
    End Sub

    '|MISC DEATH|
    Shared Sub hardDeath()
        p.isDead = True
        Dim r As Integer = CInt(Int(Rnd() * 2))
        If r = 0 Then
            Dim writer As IO.StreamWriter
            writer = IO.File.CreateText("gho.sts")
            writer.WriteLine(p.toGhost())
            writer.Flush()
            writer.Close()
        End If
        If MessageBox.Show("Game Over!  Reload the a save?", "Game Over . . .", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
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
