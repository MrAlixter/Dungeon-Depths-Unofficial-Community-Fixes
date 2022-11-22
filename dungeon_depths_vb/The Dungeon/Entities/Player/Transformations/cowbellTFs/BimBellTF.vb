Public NotInheritable Class BimBellTF
    Inherits MinoFTF

    Private Const TF_IND As tfind = tfind.bimbomino

    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        tf_name = TF_IND
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tf_name = TF_IND
    End Sub

    Overrides Function hairColorTF(ByRef p As Player) As Integer
        Dim grey = Color.FromArgb(p.prt.haircolor.A, 240, 240, 240)
        Dim rose = Color.FromArgb(p.prt.haircolor.A, 255, 213, 238)
        Dim blue = Color.FromArgb(p.prt.haircolor.A, 206, 245, 255)
        Dim blonde = Color.FromArgb(p.prt.haircolor.A, 255, 250, 200)
        Dim white = Color.FromArgb(p.prt.haircolor.A, 255, 255, 255)

        Dim hcs = {grey, rose, blonde, white, blue}

        Dim i = Int(Rnd() * hcs.Length)
        p.prt.haircolor = hcs(i)

        Return i
    End Function
    Overrides Sub tfDialogStep1(ByVal hairColorInd As Integer)
        Try
            Dim hcn = {"Light Grey", "Rose", "Blonde", "White", "Sky-Colored"}
            TextEvent.push("Your foot falls on an uneven patch of dungeon and you breifly lose your footing. As you lurch forward, catching your balance, your cowbell gives out a loud ring.  Looking franctically around, you are relived to see that nothing seems to have been attracted by the noise.  As you brush your shaken up hair back into place, you notice that at some point your hair color had changed to a shade of " & hcn(hairColorInd) & "." & DDUtils.RNRN & """Maybe I stepped on a cursed brick or something..."" you muse as you continue on." & DDUtils.RNRN & "You now have " & hcn(hairColorInd) & " hair!")
        Catch ex As Exception
            TextEvent.push("Your foot falls on an uneven patch of dungeon and you breifly lose your footing. As you lurch forward, catching your balance, your cowbell gives out a loud ring.  Looking franctically around, you are relived to see that nothing seems to have been attracted by the noise.  As you brush your shaken up hair back into place, you notice that at some point your hair color had shifted." & DDUtils.RNRN & """Maybe I stepped on a cursed brick or something..."" you muse as you continue on." & DDUtils.RNRN & "Your hair color has changed!")
        End Try
    End Sub

    Overrides Sub step3()
        Dim p As Player = Game.player1

        Dim tfEars As Boolean = False
        Dim tfHair As Boolean = False

        If p.prt.iArrInd(pInd.rearhair).Item2 Then
            earTF(p)
            tfEars = True
        Else
            hairTF1(p)
            tfHair = True
            If Not 0 = 0 Then
                earTF(p)
                tfEars = True
            End If
        End If
        p.hBuff += 5
        p.health += 5 / p.getMaxHealth

        tfDialogStep3(tfEars, tfHair)
    End Sub

    Overrides Sub hairTF2(ByRef p As Player)
        p.prt.setIAInd(pInd.rearhair, 30, True, True)
        p.prt.setIAInd(pInd.midhair, 34, True, True)
        p.prt.setIAInd(pInd.fronthair, 33, True, True)
    End Sub

    Overrides Sub growHorns(ByRef p As Player)
        p.prt.setIAInd(pInd.eyes, 42, True, True)
        p.prt.setIAInd(pInd.mouth, 19, True, True)
    End Sub
    Overrides Sub tfDialogStep5()
        TextEvent.push("As you trudge through a particularly dusty patch of dungeon, you feel a powerful sneeze coming on.  As the sneeze rocks your body, the cowbell on your neck rattles noisily, the loudest it has rung yet, and you need to take a few minutes to get your bearings back.  Your head feels slightly heavier, and as you feel around you can tell that your horns have gotten longer, and seem to have a more extreme curl.  Sweet!")
    End Sub

    Overrides Sub boobTF(ByRef p As Player)
        p.breastSize += 1
        MyBase.boobTF(p)
    End Sub
    Overrides Sub tfDialogStep678(ByVal bsize7 As Boolean, ByVal bsizeneg1 As Boolean, ByVal be As Boolean, ByVal mtf As Boolean)
        Dim out = "Despite being out of the cloud of dust, another small sneeze rattles your bell slightly..."

        If bsize7 Then
            out += DDUtils.RNRN & "... but nothing seems to have happened, and you go on your way."
        End If

        If bsizeneg1 Then
            out += DDUtils.RNRN & "Your breasts jiggle a little, and- wait, BREASTS?!" & DDUtils.RNRN &
                   "You strip off your top and examine your chest and sure enough, you have breasts now."
        End If

        If be Then
            out += DDUtils.RNRN & "Your breasts jiggle quite a bit, and it seems that you've gone up a cup size or two."
        End If

        If mtf Then
            out += DDUtils.RNRN & "You also notice that you feel a little... breezier... between your legs, and a quick pat down confirms that you are now female." & DDUtils.RNRN &
                   "Seems like this bell is turning you into a proper cow after all."
        End If

        TextEvent.push(out)
    End Sub

    Overrides Sub tfClothes(ByRef p As Player)
        If p.inv.item(CowCosplay.ITEM_NAME).getCount > 0 Then p.inv.add(CowCosplay.ITEM_NAME, 1)
        EquipmentDialogBackend.equipArmor(p, CowCosplay.ITEM_NAME, False)
    End Sub
    Overrides Sub tfDialogStep9()
        TextEvent.push("Giggling, you take hold of the bell dangling from the collar on your neck.  With each ring so far you've gotten a little bit ditzier, but also a whole lot cuter." & DDUtils.RNRN &
                       "Between your little horns and your gigantic tits, you almost look like some sort of cow...  Falling into another fit of giggles, you give the bell a hard shake, and the sound from its ring echos throughout the dungeon." & DDUtils.RNRN &
                       "You are now a female minotaur!")
    End Sub
End Class
