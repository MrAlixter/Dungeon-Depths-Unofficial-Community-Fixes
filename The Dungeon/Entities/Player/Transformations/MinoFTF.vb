Public Class MinoFTF
    Inherits Transformation
    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        tfName = "MinoFTF"
        MyBase.updateDuringCombat = False
        Game.player.perks("cowbell") = 0
        nextStep = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        MyBase.updateDuringCombat = False
        tfName = "MinoFTF"
        nextStep = getNextStep(cs)
    End Sub

    Sub step1()
        Dim p As player = game.player
        Dim black = Color.FromArgb(p.prt.haircolor.A, 50, 50, 50)
        Dim brown = Color.FromArgb(p.prt.haircolor.A, 131, 81, 54)
        Dim blonde = Color.FromArgb(p.prt.haircolor.A, 248, 189, 90)
        Dim white = Color.FromArgb(p.prt.haircolor.A, 249, 249, 249)
        Dim hcs = {black, brown, blonde, white}
        Dim hcn = {"Black", "Brown", "Blonde", "White"}
        Dim i = Int(Rnd() * hcs.Length)
        p.prt.haircolor = hcs(i)
        Game.pushLblEvent("Your foot falls on an uneven patch of dungeon and you breifly lose your footing. As you lurch forward, catching your balance, your cowbell gives out a loud ring.  Looking franctically around, you are relived to see that nothing seems to have been attracted by the noise.  As you brush your shaken up hair back into place, you notice that at some point your hair color had changed to a shade of " & hcn(i) & ".  𝘔𝘢𝘺𝘣𝘦 𝘐 𝘴𝘵𝘦𝘱𝘱𝘦𝘥 𝘰𝘯 𝘢 𝘤𝘶𝘳𝘴𝘦𝘥 𝘣𝘳𝘪𝘤𝘬 𝘰𝘳 𝘴𝘰𝘮𝘦𝘵𝘩𝘪𝘯𝘨, you muse as you continue on." & vbCrLf & vbCrLf & "You now have " & hcn(i) & " hair!")
    End Sub
    Sub step2()
        Dim p As player = game.player
        p.prt.hornInd = 1
        Game.pushLblEvent("Out of nowhere, you feel the tile beneath you depress slightly.  You instinctively roll left just in time for a projectile to fly through the air where you just to the left.  Breathing a sigh of relief, you take a couple of steps back only to step on another pressure plate.  Another dart fires straight for your neck and without any time to dodge it strikes you right ... in your cowbell.  The ding it lets out is louder than last time, but not by much.  After a nervous scan of your surroundings, you go to readjust your hair again only to find a small pair of horns.  As you size them up, you realize that they give you a slightly bovine appearance.")
    End Sub
    Sub step3()
        Dim p As player = game.player
        Dim out = "Through the sway of your motion your cowbell rings out quietly, but repeatedly.  After a while of this, you take a rest and check yourself for any changes that may have taken place."
        If p.prt.iArrInd(1).Item2 Then
            out += "  Looking at your reflection in the nearby pool of water, you see that you now have bovine ears!  Between these and the horns, you're pretty sure you're slowly turning into some sort of cow."
            p.prt.setIAInd(6, 8, True, True)
            p.wBuff -= 1
        Else
            out += "  You can feel the tickle of hair much further down on your back than you are used to, and a quick glance in a nearby puddle confirms that your hair has lengthened considerably."
            p.prt.setIAInd(1, 1, True, False)
            p.prt.setIAInd(5, 0, True, False)
            If Not Int(Rnd() * 3) = 0 Then
                out += "  Looking at your reflection in the nearby pool of water, you see that you now have bovine ears!  Between these and the horns, you're pretty sure you're slowly turning into some sort of cow."
                p.prt.setIAInd(6, 8, True, True)
                p.equippedAcce.wBoost -= 1
            End If
        End If
        p.hBuff += 5
        p.health += 5 / p.getmaxHealth
        Game.pushLblEvent(out)
    End Sub
    Sub step4()
        Dim p As player = game.player
        Dim out = "As you bend down to pick up a dropped item, your cowbell jangles as you stand back up.  Already used to this, you give yourself a quick once over.  You don't see that much different, though your hair seems to have styled itself since you last checked up on it."
        If p.pClass.name.Equals("Magic Girl") Or p.pClass.name.Equals("Valkyrie") Then
            out += "  You loose hold of your weapon dropping it and reverting your transformation."
            Equipment.weaponChange("Fists")
        End If
        p.prt.setIAInd(1, 16, True, True)
        p.prt.setIAInd(5, 20, True, True)
        p.prt.setIAInd(15, 16, True, True)
        Game.pushLblEvent(out)
    End Sub
    Sub step5()
        Dim p As player = game.player
        p.prt.hornInd = 2
        Game.pushLblEvent("As you trudge through a particularly dusty patch of dungeon, you feel a powerful sneeze coming on.  As the sneeze rocks your body, the cowbell on your neck rattles noisily, the loudest it has rung yet, and you need to take a few minutes to get your bearings back.  Your head feels slightly heavier, and as you feel around you can tell that your horns have gotten longer, and seem to have a more extreme curl.  Sweet!")
    End Sub
    Sub step678()
        Dim p As player = game.player
        Dim out = "Despite being out of the cloud of dust, another small sneeze rattles your bell slightly."
        If p.breastSize = 7 Then
            out += "  Nothing seems to have happened, and you go on your way."
        ElseIf p.breastSize = -1 Then
            out += "  Your breasts jiggle a little, and ..." & vbCrLf & vbCrLf & "Wait, BREASTS?!" & vbCrLf & vbCrLf & "You strip off your top and examine your chest and sure enough, you have two small breasts now."
            p.breastSize += 1
            p.reverseBSRoute()
        Else
            out += "  Your breasts jiggle a little, and it seems that you've gone up a cup size."
            If p.breastSize < 7 Then
                p.breastSize += 1
                p.reverseBSRoute()
            End If
        End If
        If Not p.prt.sexBool Then
            If Int(Rnd() * 2) = 0 Then
                out += "  You also notice that you feel a little ... breathier ... between your legs and a quick pat down confirms that you are now female.  Seems like this bell is turning you into a proper cow after all..."
                Game.player.MtF()
            End If
        End If
        Game.pushLblEvent(out)
    End Sub
    Sub step9()
        Dim p As player = game.player
        Game.pushLblEvent("You take another look at your cowbell.  Every time its rung thus far, you've progressed a little more into some form of bovine-human hybrid.  𝘔𝘪𝘯𝘰𝘵𝘢𝘶𝘳, you correct your self.  It's been turning you into a minotaur, and a female one at that.  Your transformation seems pretty far along, and you'd wager you're only one more chime away from completing the change.  With that in mind, you give the bell a hard shake, and the sound from its ring echos throughout the dungeon." & vbCrLf & vbCrLf & "You are now a female minotaur!")
        Game.player.pForm = p.forms("Minotaur Cow")
        p.inv.add(71, 1)
        Equipment.clothesChange("Cow_Print_Bra")
    End Sub

    Sub resist()
        Game.pushLblCombatEvent("You are able to resist the curse, but you can feel your resolve wavering...")
        Game.player.will -= 1
    End Sub
    Public Overrides Sub stopTF()
        MyBase.stopTF()
        Game.player.perks("cowbell") = -1
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        If Game.player.perks("cowbell") = -1 Then
            Return AddressOf stopTF
        End If
        Select Case stage
            Case 0
                Return AddressOf step1
            Case 1
                Return AddressOf step2
            Case 2
                Return AddressOf step3
            Case 3
                Return AddressOf step4
            Case 4
                Return AddressOf step5
            Case 5, 6, 7
                Return AddressOf step678
            Case 8
                Return AddressOf step9
            Case Else
                Return AddressOf stopTF
        End Select
    End Function
    Public Overrides Sub setWaitTime(stage As Integer)
        turnsTilNextStep = 10
        turnsTilNextStep += generatWILResistance()
    End Sub
End Class
