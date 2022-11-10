Public NotInheritable Class MinoMTF
    Inherits MinoFTF

    Private Const TF_IND As tfind = tfind.malmino

    Sub New()
        MyBase.New(9, 15, 2.0, True)
        tf_name = TF_IND
        next_step = AddressOf step1
    End Sub
    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        tf_name = TF_IND
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tf_name = TF_IND
        next_step = getNextStep(cs)
    End Sub

    Overrides Sub tfDialogStep1(ByVal hairColorInd As Integer)
        Try
            Dim hcn = {"Black", "Brown", "Blonde", "White"}
            TextEvent.push("Your foot falls on an uneven patch of dungeon and you breifly lose your footing." & DDUtils.RNRN &
                              "As you brush your shaken up hair back into place, you notice that at some point your hair color had changed to a shade of " & hcn(hairColorInd) & "." & DDUtils.RNRN &
                              """Maybe I stepped on a cursed brick or something..."" you muse as you continue on." & DDUtils.RNRN &
                              "You now have " & hcn(hairColorInd) & " hair!")
        Catch ex As Exception
            TextEvent.push("Your foot falls on an uneven patch of dungeon and you breifly lose your footing." & DDUtils.RNRN &
                              "As you brush your shaken up hair back into place, you notice that at some point your hair color had shifted." & DDUtils.RNRN &
                              """Maybe I stepped on a cursed brick or something..."" you muse as you continue on." & DDUtils.RNRN &
                              "Your hair color has changed!")
        End Try
    End Sub

    Overrides Sub tfDialogStep2()
        TextEvent.push("Out of nowhere, you feel the tile beneath you depress slightly." & DDUtils.RNRN &
                          "You instinctively roll left just in time for a projectile to fly through the air where you just to the left.  After a nervous scan of your surroundings, you go to re-adjust your hair again only to find a small pair of horns." & DDUtils.RNRN &
                          "As you size them up, you realize that they give you a slightly bovine appearance.")
    End Sub

    Overrides Sub earTF(ByRef p As Player)
        p.prt.setIAInd(pInd.ears, 7, False, True)
        p.wBuff -= 1
    End Sub
    Overrides Sub hairTF1(ByRef p As Player)
        p.prt.setIAInd(pInd.rearhair, 5, False, False)
        p.prt.setIAInd(pInd.midhair, 5, False, False)

        p.wBuff -= 1
    End Sub
    Overrides Sub tfDialogStep3(ByVal tfEars As Boolean, ByVal tfHair As Boolean)
        Dim out = "Considering that your curse doesn't seem to have stopped yet, you decide to take a rest and check yourself for any changes that may have taken place."

        If tfEars Then
            out += "  Looking at your reflection in the nearby pool of water, you see that you now have bovine ears!  Between these and the horns, you're pretty sure you're slowly turning into some sort of cow."
        End If

        If tfHair Then
            out += "  You can feel the tickle of hair much further up on your neck than you are used to, and a quick glance in a nearby puddle confirms that your hair has shortened considerably."
        End If

        TextEvent.push(out)
    End Sub
    Overrides Sub step3()
        Dim p As Player = Game.player1

        Dim tfEars As Boolean = False
        Dim tfHair As Boolean = False

        If Not p.prt.iArrInd(pInd.rearhair).Item2 Then
            earTF(p)
            tfEars = True
        Else
            hairTF1(p)
            tfHair = True

            earTF(p)
            tfEars = True
        End If

        p.aBuff += 5

        If p.breastSize > 3 Then p.bs()

        p.reverseBSroute()

        tfDialogStep3(tfEars, tfHair)
    End Sub

    Overrides Sub tfDialogStep4(ByVal dropItem As Boolean)
        Dim out = ""

        If dropItem Then
            out += "You loose hold of your weapon dropping it and reverting your transformation."
        End If

        If Not out.Equals("") Then TextEvent.push(out)
    End Sub
    Overrides Sub step4()
        Dim p As Player = Game.player1

        Dim dropItem = dropEWeapon(p)

        tfDialogStep4(dropItem)
    End Sub

    Overrides Sub growHorns(ByRef p As Player)
        p.prt.setIAInd(pInd.horns, 5, True, False)
    End Sub
    Overrides Sub tfDialogStep5()
        TextEvent.push("As you trudge through a particularly dusty patch of dungeon, you feel a powerful sneeze coming on." & DDUtils.RNRN &
                          """Achoo!"" the sneeze rocks your body, and your head feels slightly heavier.  As you feel around your head, you can tell that your horns have both gotten longer and developed a more extreme curl." & DDUtils.RNRN &
                          "Epic.")
    End Sub

    Overrides Sub boobTF(ByRef p As Player)
        p.breastSize -= 1
    End Sub
    Overrides Sub tfDialogStep678(ByVal bsize7 As Boolean, ByVal bsizeneg1 As Boolean, ByVal be As Boolean, ByVal mtf As Boolean)
        Dim out = "Despite being out of the cloud of dust, another small sneeze rattles you slightly."

        If bsize7 Then
            out += "  You feel your bountiful breasts squeeze together...  It seems like you've gone down a cup size!"
        End If

        If bsizeneg1 Then
            out += "  Nothing seems to have happened, although you feel slightly stronger..."
        End If

        If be Then
            out += "  Your breasts squeeze a little, and it seems that you've gone down a cup size."
        End If

        If mtf Then
            out += "  You also notice that you feel a little ... tighter ... between your legs and a quick pat down confirms that you now have a dick.  Seems like this curse isn't exactly turning you into a proper cow after all..."
        End If

        TextEvent.push(out)
    End Sub
    Overrides Sub step678()
        Dim p As Player = Game.player1
        Dim bsize7 As Boolean = False
        Dim bsizeneg1 As Boolean = False
        Dim be As Boolean = False
        Dim mtf As Boolean = False

        If p.breastSize = 7 Then
            bsize7 = True
            boobTF(p)
        ElseIf p.breastSize = -1 Then
            bsizeneg1 = True
        Else
            If p.breastSize < 7 Then
                boobTF(p)
            End If
            be = True
        End If
        If p.prt.sexBool Then
            If Int(Rnd() * 2) = 0 Then
                Game.player1.FtM()
                mtf = True
            End If
        End If

        tfDialogStep678(bsize7, bsizeneg1, be, mtf)
    End Sub

    Overrides Sub tfClothes(ByRef p As Player)
        p.breastSize = -2
        p.buttSize = -2
        p.dickSize = 3

        If p.inv.getCountAt("Barbarian_Armor") < 1 Then p.inv.add("Barbarian_Armor", 1)
        EquipmentDialogBackend.armorChange(p, "Barbarian_Armor")

        p.prt.setIAInd(pInd.eyebrows, 5, False, False)
        p.prt.setIAInd(pInd.mouth, 8, False, False)
        p.prt.setIAInd(pInd.eyes, 13, False, True)
        p.prt.setIAInd(pInd.nose, 2, False, True)
    End Sub
    Overrides Sub tfDialogStep9()
        TextEvent.push("You take another look at your chest." & DDUtils.RNRN &
                          "It seems that with every change this curse inflicts, you've progressed a little more into some form of bovine-human hybrid.  'Minotaur', you correct your self.  It's been turning you into a minotaur, and a masculine one at that." & DDUtils.RNRN &
                          "Your transformation seems pretty far along, and you'd wager you're only one more change away.  With that in mind, you focus all your energy on bulking up your already ample muscles." & DDUtils.RNRN &
                          "You are now a male minotaur!")
    End Sub
    Overrides Sub step9()
        Dim p As Player = Game.player1

        tfDialogStep9()

        p.changeForm("Minotaur Bull")

        tfClothes(p)
    End Sub

    Public Sub fulltf()
        Dim p As Player = Game.player1

        If p.prt.sexBool Then p.FtM()

        'Minotaur M transformation
        p.changeHairColor(Color.FromArgb(255, 234, 189, 134))
        p.breastSize = -2
        p.buttSize = -2
        p.dickSize = 3

        p.prt.setIAInd(pInd.rearhair, 5, False, False)
        p.prt.setIAInd(pInd.eyebrows, 5, False, False)
        p.prt.setIAInd(pInd.mouth, 8, False, False)
        p.prt.setIAInd(pInd.eyes, 13, False, True)
        p.prt.setIAInd(pInd.nose, 2, False, True)
        p.prt.setIAInd(pInd.ears, 7, False, True)
        p.prt.setIAInd(pInd.horns, 5, True, False)

        If p.inv.getCountAt("Barbarian_Armor") < 1 Then p.inv.add("Barbarian_Armor", 1)
        EquipmentDialogBackend.armorChange(p, "Barbarian_Armor")

        p.changeForm("Minotaur Bull")
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
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
                Return AddressOf Me.step678
            Case 8
                Return AddressOf step9
            Case Else
                Return AddressOf stopTF
        End Select
    End Function
End Class
