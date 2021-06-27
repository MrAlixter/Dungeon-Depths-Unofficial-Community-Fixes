Public NotInheritable Class MimicMinoTF
    Inherits MinoFTF

    Private Const TF_IND As tfind = tfind.mimicmino

    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        tf_name = TF_IND
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tf_name = TF_IND
    End Sub

    Overrides Function hairColorTF(ByRef p As Player) As Integer
        Dim lavender = Color.FromArgb(p.prt.haircolor.A, 211, 169, 237)
        Dim violet = Color.FromArgb(p.prt.haircolor.A, 152, 79, 174)
        Dim maroon = Color.FromArgb(p.prt.haircolor.A, 174, 79, 152)

        Dim hcs = {lavender, violet, maroon}

        Dim i = Int(Rnd() * hcs.Length)
        p.prt.haircolor = hcs(i)

        Return i
    End Function
    Overrides Sub tfDialogStep1(ByVal hairColorInd As Integer)
        Try
            Dim hcn = {"Lavender", "Violet", "Maroon"}
            Game.pushLblEvent("Your foot falls on an uneven patch of dungeon and you breifly lose your footing. As you lurch forward, catching your balance, your cowbell gives out a loud ring.  Looking franctically around, you are relived to see that nothing seems to have been attracted by the noise.  As you brush your shaken up hair back into place, you notice that at some point your hair color had changed to a shade of " & hcn(hairColorInd) & "." & DDUtils.RNRN & """Maybe I stepped on a cursed brick or something..."" you muse as you continue on." & DDUtils.RNRN & "You now have " & hcn(hairColorInd) & " hair!")
        Catch ex As Exception
            Game.pushLblEvent("Your foot falls on an uneven patch of dungeon and you breifly lose your footing. As you lurch forward, catching your balance, your cowbell gives out a loud ring.  Looking franctically around, you are relived to see that nothing seems to have been attracted by the noise.  As you brush your shaken up hair back into place, you notice that at some point your hair color had shifted." & DDUtils.RNRN & """Maybe I stepped on a cursed brick or something..."" you muse as you continue on." & DDUtils.RNRN & "Your hair color has changed!")
        End Try
    End Sub

    Overrides Sub step2()
        Dim p As Player = Game.player1
        p.prt.setIAInd(pInd.horns, 13, True, False)
        tfDialogStep2()
    End Sub

    Overrides Sub earTF(ByRef p As Player)
        p.prt.setIAInd(pInd.ears, 15, True, True)
    End Sub
    Overrides Sub step3()
        Dim p As Player = Game.player1

        Dim tfEars As Boolean = True
        Dim tfHair As Boolean = False

        earTF(p)
      
        p.hBuff += 5
        p.health += 5 / p.getMaxHealth

        tfDialogStep3(tfEars, tfHair)
    End Sub

    Overrides Sub tfDialogStep4(ByVal dropItem As Boolean)
        Dim out = "As you bend down to pick up a dropped item, your cowbell jangles as you stand back up." & DDUtils.RNRN &
                  "Already used to this, you give yourself a quick once over.  You don't seem to have changed..."

        If dropItem Then
            out += DDUtils.RNRN & "You lose hold of your weapon, dropping it and reverting your transformation."
        End If

        Game.pushLblEvent(out)
    End Sub
    Overrides Sub step4()
        Dim p As Player = Game.player1

        Dim dropItem = dropEWeapon(p)

        tfDialogStep4(dropItem)
    End Sub

    Overrides Sub growHorns(ByRef p As Player)
        p.prt.setIAInd(pInd.eyes, 42, True, True)
        p.prt.setIAInd(pInd.horns, 12, True, False)
    End Sub
    Overrides Sub tfDialogStep5()
        Game.pushLblEvent("As you trudge through a particularly dusty patch of dungeon, you feel a powerful sneeze coming on.  As the sneeze rocks your body, the cowbell on your neck rattles noisily, the loudest it has rung yet, and you need to take a few minutes to get your bearings back.  Your head feels slightly heavier, and as you feel around you can tell that your horns have gotten longer, and seem to have a more extreme curl.  Sweet!")
    End Sub

    Overrides Sub tfDialogStep678(ByVal bsize7 As Boolean, ByVal bsizeneg1 As Boolean, ByVal be As Boolean, ByVal mtf As Boolean)
        Dim out = "Despite being out of the cloud of dust, another small sneeze rattles your bell slightly."

        If bsize7 Then
            out += "  Nothing seems to have happened, and you go on your way."
        End If

        If bsizeneg1 Then
            out += "  Your breasts jiggle a little, and ..." & DDUtils.RNRN & "Wait, BREASTS?!" & DDUtils.RNRN & "You strip off your top and examine your chest and sure enough, you have breasts now."
        End If

        If be Then
            out += "  Your breasts jiggle quite a bit, and it seems that you've gone up a cup size or two."
        End If

        If mtf Then
            out += "  You also notice that you feel a little ... breathier ... between your legs and a quick pat down confirms that you are now female.  Seems like this bell is turning you into a proper cow..."
        End If

        Game.pushLblEvent(out)
    End Sub
End Class
