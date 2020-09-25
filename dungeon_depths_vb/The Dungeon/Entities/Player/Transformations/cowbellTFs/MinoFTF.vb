Public Class MinoFTF
    Inherits Transformation
    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        tfName = "MinoFTF"
        MyBase.updateDuringCombat = False
        Game.player1.perks(perk.cowbell) = 0
        nextStep = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        MyBase.updateDuringCombat = False
        tfName = "MinoFTF"
        nextStep = getNextStep(cs)
    End Sub

    Overridable Function hairColorTF(ByRef p As Player) As Integer
        Dim black = Color.FromArgb(p.prt.haircolor.A, 50, 50, 50)
        Dim brown = Color.FromArgb(p.prt.haircolor.A, 131, 81, 54)
        Dim blonde = Color.FromArgb(p.prt.haircolor.A, 248, 189, 90)
        Dim white = Color.FromArgb(p.prt.haircolor.A, 249, 249, 249)

        Dim hcs = {black, brown, blonde, white}

        Dim i = Int(Rnd() * hcs.Length)
        p.prt.haircolor = hcs(i)

        Return i
    End Function
    Overridable Sub tfDialogStep1(ByVal hairColorInd As Integer)
        Try
            Dim hcn = {"Black", "Brown", "Blonde", "White"}
            Game.pushLblEvent("Your foot falls on an uneven patch of dungeon and you breifly lose your footing. As you lurch forward, catching your balance, your cowbell gives out a loud ring.  Looking franctically around, you are relived to see that nothing seems to have been attracted by the noise.  As you brush your shaken up hair back into place, you notice that at some point your hair color had changed to a shade of " & hcn(hairColorInd) & "." & DDUtils.RNRN & """Maybe I stepped on a cursed brick or something..."" you muse as you continue on." & DDUtils.RNRN & "You now have " & hcn(hairColorInd) & " hair!")
        Catch ex As Exception
            Game.pushLblEvent("Your foot falls on an uneven patch of dungeon and you breifly lose your footing. As you lurch forward, catching your balance, your cowbell gives out a loud ring.  Looking franctically around, you are relived to see that nothing seems to have been attracted by the noise.  As you brush your shaken up hair back into place, you notice that at some point your hair color had shifted." & DDUtils.RNRN & """Maybe I stepped on a cursed brick or something..."" you muse as you continue on." & DDUtils.RNRN & "Your hair color has changed!")
        End Try
    End Sub
    Sub step1()
        Dim p As Player = Game.player1

        Dim hairColorInd As Integer = hairColorTF(p)
        tfDialogStep1(hairColorInd)
    End Sub

    Overridable Sub tfDialogStep2()
        Game.pushLblEvent("Out of nowhere, you feel the tile beneath you depress slightly.  You instinctively roll left just in time for a projectile to fly through the air where you just to the left.  Breathing a sigh of relief, you take a couple of steps back only to step on another pressure plate.  Another dart fires straight for your neck and without any time to dodge it strikes you right ... in your cowbell.  The ding it lets out is louder than last time, but not by much.  After a nervous scan of your surroundings, you go to readjust your hair again only to find a small pair of horns.  As you size them up, you realize that they give you a slightly bovine appearance.")
    End Sub
    Sub step2()
        Dim p As Player = Game.player1
        p.prt.setIAInd(pInd.horns, 1, True, False)
        tfDialogStep2()
    End Sub

    Overridable Sub earTF(ByRef p As Player)
        p.prt.setIAInd(pInd.ears, 8, True, True)
        p.wBuff -= 1
    End Sub
    Overridable Sub hairTF1(ByRef p As Player)
        p.prt.setIAInd(pInd.rearhair, 1, True, False)
        p.prt.setIAInd(pInd.midhair, 0, True, False)

        p.wBuff -= 1
    End Sub
    Overridable Sub tfDialogStep3(ByVal tfEars As Boolean, ByVal tfHair As Boolean)
        Dim out = "Through the sway of your motion your cowbell rings out quietly, but repeatedly.  After a while of this, you take a rest and check yourself for any changes that may have taken place."

        If tfEars Then
            out += "  Looking at your reflection in the nearby pool of water, you see that you now have bovine ears!  Between these and the horns, you're pretty sure you're slowly turning into some sort of cow."
        End If

        If tfHair Then
            out += "  You can feel the tickle of hair much further down on your back than you are used to, and a quick glance in a nearby puddle confirms that your hair has lengthened considerably."
        End If

        Game.pushLblEvent(out)
    End Sub
    Overridable Sub step3()
        Dim p As Player = Game.player1

        Dim tfEars As Boolean = False
        Dim tfHair As Boolean = False

        If p.prt.iArrInd(pInd.rearhair).Item2 Then
            earTF(p)
            tfEars = True
        Else
            hairTF1(p)
            tfHair = True
            If Not Int(Rnd() * 3) = 0 Then
                earTF(p)
                tfEars = True
            End If
        End If
        p.hBuff += 5
        p.health += 5 / p.getMaxHealth

        tfDialogStep3(tfEars, tfHair)
    End Sub

    Overridable Function dropEWeapon(ByRef p As Player) As Boolean
        If p.className.Equals("Magical Girl") Or p.className.Equals("Valkyrie") Then
            Equipment.weaponChange("Fists")
            Return True
        End If
        Return False
    End Function
    Overridable Sub hairTF2(ByRef p As Player)
        p.prt.setIAInd(pInd.rearhair, 16, True, True)
        p.prt.setIAInd(pInd.midhair, 20, True, True)
        p.prt.setIAInd(pInd.fronthair, 16, True, True)
    End Sub
    Overridable Sub tfDialogStep4(ByVal dropItem As Boolean)
        Dim out = "As you bend down to pick up a dropped item, your cowbell jangles as you stand back up.  Already used to this, you give yourself a quick once over.  You don't see that much different, though your hair seems to have styled itself since you last checked up on it."

        If dropItem Then
            out += "  You lose hold of your weapon, dropping it and reverting your transformation."
        End If

        Game.pushLblEvent(out)
    End Sub
    Overridable Sub step4()
        Dim p As Player = Game.player1

        Dim dropItem = dropEWeapon(p)

        hairTF2(p)

        tfDialogStep4(dropItem)
    End Sub

    Overridable Sub growHorns(ByRef p As Player)
        p.prt.setIAInd(pInd.horns, 2, True, False)
    End Sub
    Overridable Sub tfDialogStep5()
        Game.pushLblEvent("As you trudge through a particularly dusty patch of dungeon, you feel a powerful sneeze coming on.  As the sneeze rocks your body, the cowbell on your neck rattles noisily, the loudest it has rung yet, and you need to take a few minutes to get your bearings back.  Your head feels slightly heavier, and as you feel around you can tell that your horns have gotten longer, and seem to have a more extreme curl.  Sweet!")
    End Sub
    Sub step5()
        Dim p As Player = Game.player1
        growHorns(p)
        tfDialogStep5()
    End Sub

    Overridable Sub boobTF(ByRef p As Player)
        p.breastSize += 1
        p.reverseAllRoute()
    End Sub
    Overridable Sub tfDialogStep678(ByVal bsize7 As Boolean, ByVal bsizeneg1 As Boolean, ByVal be As Boolean, ByVal mtf As Boolean)
        Dim out = "Despite being out of the cloud of dust, another small sneeze rattles your bell slightly."

        If bsize7 Then
            out += "  Nothing seems to have happened, and you go on your way."
        End If

        If bsizeneg1 Then
            out += "  Your breasts jiggle a little, and ..." & DDUtils.RNRN & "Wait, BREASTS?!" & DDUtils.RNRN & "You strip off your top and examine your chest and sure enough, you have two small breasts now."
        End If

        If be Then
            out += "  Your breasts jiggle a little, and it seems that you've gone up a cup size."
        End If

        If mtf Then
            out += "  You also notice that you feel a little ... breathier ... between your legs and a quick pat down confirms that you are now female.  Seems like this bell is turning you into a proper cow after all..."
        End If

        Game.pushLblEvent(out)
    End Sub
    Overridable Sub step678()
        Dim p As Player = Game.player1
        Dim bsize7 As Boolean = False
        Dim bsizeneg1 As Boolean = False
        Dim be As Boolean = False
        Dim mtf As Boolean = False

        If p.breastSize = 7 Then
            bsize7 = True
        ElseIf p.breastSize = -1 Then
            boobTF(p)
            bsizeneg1 = True
        Else
            If p.breastSize < 7 Then
                boobTF(p)
            End If
            be = True
        End If
        If Not p.prt.sexBool Then
            If Int(Rnd() * 2) = 0 Then
                Game.player1.MtF()
                mtf = True
            End If
        End If

        tfDialogStep678(bsize7, bsizeneg1, be, mtf)
    End Sub

    Overridable Sub tfClothes(ByRef p As Player)
        p.inv.add(71, 1)
        Equipment.clothesChange("Cow_Print_Bra")
    End Sub
    Overridable Sub tfDialogStep9()
        Game.pushLblEvent("You take another look at your cowbell.  Every time its rung thus far, you've progressed a little more into some form of bovine-human hybrid.  'Minotaur', you correct your self.  It's been turning you into a minotaur, and a female one at that.  Your transformation seems pretty far along, and you'd wager you're only one more chime away from completing the change.  With that in mind, you give the bell a hard shake, and the sound from its ring echos throughout the dungeon." & DDUtils.RNRN & "You are now a female minotaur!")
    End Sub
    Overridable Sub step9()
        Dim p As Player = Game.player1

        tfDialogStep9()

        p.changeForm("Minotaur Cow")

        tfClothes(p)
    End Sub

    Sub resist()
        Game.pushLblCombatEvent("You are able to resist the curse, but you can feel your resolve wavering...")
        Game.player1.will -= 1
    End Sub
    Public Overrides Sub stopTF()
        MyBase.stopTF()
        Game.player1.perks(perk.cowbell) = -1
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        If Game.player1.perks(perk.cowbell) = -1 Then
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
