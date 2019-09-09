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
        If p.pForm.name.Equals("Blowup Doll") Then
            p.currTarget.despawn("p-death")
            Game.pushLblEvent("Your enemy, seeing your current state, decides that you likely aren't useful and leaves you alone.")
            Exit Sub
        End If
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
        If p.pForm.name.Equals("Blowup Doll") Then
            p.currTarget.despawn("p-death")
            Game.pushLblEvent("Your enemy, seeing your current state, decides that you likely aren't useful and leaves you alone.")
            Exit Sub
        End If
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
        'Author Credit: Marionette
        Dim out As String = "As the " & p.currTarget.name & " closes in you push yourself off the ground, a burst of adrenaline pushing through your fatigue as you sidestep around it and beat a hasty retreat. While your back is turned to it, however, the " & p.currTarget.name & " whips a ball of goo towards you, the impact causing you to stumble as the goo strikes your back. You can already feel it starting to writhe and squirm as it begins to move…"
        p.currTarget.despawn("p-death")
        If p.perks("slimetf") = -1 Then
            p.perks("slimetf") = 1
        End If

        p.ongoingTFs.Add(New VialOfSlimeTF(p.perks("slimetf")))
        Game.pushLblEvent(out, AddressOf p.update)
    End Sub
    Shared Sub ggDeath()
        Dim p As Player = Game.player
        Dim out As String = "As the " & p.currTarget.name & " closes in on you, you push yourself off the ground, sidestep it, and make a hasty retreat.  While your back is turned, the " & p.currTarget.name & " whips a ball of goo at you.  As soon as it makes contact, you can feel the familiar tingle of magic..."
        p.currTarget.despawn("p-death")
        If p.perks("googirltf") = -1 Then
            p.perks("googirltf") = 1
        End If

        p.ongoingTFs.Add(New GooGirlTF(p.perks("googirltf")))
        Game.pushLblEvent(out, AddressOf p.update)
    End Sub

    Shared Sub spiderDeath()
        Dim p As Player = Game.player
        Dim out As String = "As the " & p.currTarget.name & " closes in on you, you push yourself off the ground, and sidestep it.  It anticipates this though, and with a lunging bite it latches onto your arm and delivers a powerful bite.  You smack it off, and make your escape, though a trickle of a golden venom hints that you might not be out of the woods yet."
        p.currTarget.despawn("p-death")
        If p.perks("avenom") = -1 And p.perks("svenom") = -1 Then
            p.perks("svenom") = 1
        End If
        p.ongoingTFs.Add(New ArachneTF(p.perks("svenom")))

        Game.pushLblEvent(out, AddressOf p.update)
    End Sub
    Shared Sub arachneDeath()
        Dim p As Player = Game.player
        p.currTarget.despawn("p-death")
        Dim out As String = "It's clear that you can't beat the huntress, weakened as you are.  Dodging even the simplest of her lightning quick strikes is taking more and more of a toll, and you decide that a hasty retreat might be the best bet if you want to survive.  As you turn to run, you hear a giggle over your shoulder.  Sparing a quick glance back, you see the arach... *WHAP!!!*  Suddenly, you can no longer move.  Shocked, you find that you are caught in a large web, and your assailant approaches you slowly." &
            vbCrLf & vbCrLf & """Sshhh, little one..."" she whispers, spinning a tight bond of webbing around your hands and feet before lowering you to the floor,  ""You aren't going to die yet.  Our sisterhood can always use new members, and you can be so much stronger than you are now."""
        Game.pushLblEvent(out, AddressOf arachneDeath2)
    End Sub
    Shared Sub arachneDeath2()
        Dim p As Player = Game.player
        Dim out As String = "She grips your neck firmly, before baring her small fangs and giving you a quick bite.  You can feel her potent venom as it is injected, and almost immediately your body flushes with arousal.  Everything about your captor, from her supple bossom to her glistening chitinous legs has you lusting for more, and as she positions her slit over your face, your hazy mind loses all control.  Even as your mistress lowers her body onto your face, your tongue begins lapping at her folds." &
            vbCrLf & vbCrLf & """Mmmm..."", the huntress moans, blushing, ""Someone's eager...""." &
            vbCrLf & vbCrLf & "With her approval, you double your efforts and soon your tongue finds her clit.  She begins squirming with pleasure, her warmth radiating onto your face.  Whether it's from the venom or your lover's reaction, your entire body is burning with passion, on the verge of a climax yourself and as you caress her clit with your tongue she isn't far behind you.  With a cry, she orgasms, her fangs spraying golden ichor, though your burning lust continues."
        Game.pushLblEvent(out, AddressOf arachneDeath3)
    End Sub
    Shared Sub arachneDeath3()
        Dim p As Player = Game.player
        Dim out As String = "Basking in the afterglow of her climax for mere moments, the arachne moves from your face, leaving your immobilized body unable to do much but flail wildly as the heat of your love continues to burn away all rationality." &
            vbCrLf & vbCrLf & """Ooh, you are a fun one..."" she tenderly murmurs, drips from her pussy still falling into your thisty mouth, ""Come and find me when you've finished changing, 'dungeon explorer'""." &
            vbCrLf & vbCrLf & "With that, she leaves your field of view, and you are left smoldering mess of unfulfilled lust soaked in pussy juice, venom, and webbing."
        Game.pushLblEvent(out, AddressOf arachneDeath4)
    End Sub
    Shared Sub arachneDeath4()
        Dim p As Player = Game.player
        If p.perks("avenom") = -1 And p.perks("svenom") = -1 Then
            p.perks("svenom") = 1
            p.perks("avenom") = 1
            p.ongoingTFs.Add(New ArachneTF(p.perks("svenom")))
        Else
            For Each tf In p.ongoingTFs
                If tf.GetType Is GetType(ArachneTF) Then
                    tf.setCurrStep(p.perks("svenom"))
                    tf.setTurnsTilStep(0)
                End If

            Next
        End If
        Dim out As String = "Hours later, the embers of your venom-fueled passion are all that remain.  You are able to inch yourself to a shallow well, and once in the cool water you break free of your snare and clean yourself off, reflecting on the encounter.  Although the aphrodesiac qualities of the venom have subsided, you can still feel it flow through you.  Given what your mistr...that huntress said, it's likely that you have some physical changes in store.  Part of you wonders why you would even bother stopping them."
        Game.pushLblEvent(out, AddressOf p.update)
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
        p.inv.add(55, 1)
        p.inv.invNeedsUDate = True
        Equipment.clothesChange("Living_Armor")
        p.perks(12) = True
        p.createP()
        Game.pushLblEvent(out)
        p.UIupdate()
    End Sub

    '|BOSS / MINIBOSS DEATHS|
    Shared Sub marissaASDeath()
        Dim mdtf = New MASBimboTF
        mdtf.step2()
    End Sub
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

        p.pos = Game.currfloor.randPoint

        p.update()
    End Sub

    '|NPC DEATHS|
    Shared Sub ShopkeeperDeath()
        Dim p As Player = Game.player
        Dim n As ShopNPC = Game.currNPC
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
    Shared Sub SWizDeath()
        Dim p As Player = Game.player
        Dim n As ShopNPC = Game.currNPC
        Game.fromCombat()
        Dim out = "You collapse to the ground, the wizard's onslaught wearing down your last defences.  Twirling " & n.pPronoun & " staff, they fire off one final blast, and as it hits your lifeforce...surges?  Startled, you notice that your body is coursing with magical energy, far more than you were capable of mustering before.  You spring back to your feet, resuming a fighting stance though your confusion over this turn of events has you puzzled enough to hold off on attacking." & vbCrLf & vbCrLf &
                  """Give it a sec,"" " & n.pronoun & " states, ""Or don't.  I don't really care.""" & vbCrLf & vbCrLf &
                  "You desperatly lunge at them, the flood of mana coursing through you still increasing, and before you can take three steps your body shrinks with a sudden jolt, leaving you looking at a far larger world.  The energy within you seems to have only been focused by your diminished stature.  Its electric flow overwhelms you, and you see small crystals of pure mana begining to form on your arms.  You try to flee, but your now giant opponent simply places the crook of their staff around you.  Escape no longer an option, you can do nothing but cower as the crystals swiftly replace your flesh and bone.  Nothing more than a gem full of magical energy now, you can't even react as the wizard raises their staff to inspect you."
        Game.picPortrait.BackgroundImage = Game.picStaffEnd.BackgroundImage
        Game.pushLblEvent(out, AddressOf SWizDeath2)
    End Sub
    Shared Sub SWizDeath2()
        Dim p As Player = Game.player
        Dim n As ShopNPC = Game.currNPC
        Game.fromCombat()
        Dim out = """Wow, you're in there good,"" they remark.  ""Geez, looks like somehow you got embeded in the wood.  I'm not walking around with a loser like you in one of my products.  You didn't even make that good of a crystal!  If I want to sell this now, I'm going to need to make you more...eyecatching.""" & vbCrLf & vbCrLf &
                  n.pronoun & " snaps " & n.rPronoun & " fingers, and though you can not see it your body is instantly changed to that of an incredibly busty, nude young woman." & vbCrLf & vbCrLf &
                  """Now that's a look that will draw in customers.  I might have to make more of these, assuming I can find a couple more shmucks like you!  I wonder what that food guy is up to...""" & vbCrLf & vbCrLf &
                  "GAME OVER!"
        Game.picPortrait.BackgroundImage = Game.picStaffEnd.BackgroundImage
        Game.pushLblEvent(out, AddressOf p.die)
    End Sub
    Shared Sub FVHTInterupt1()

    End Sub
    Shared Sub FVHTInterupt2()

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
