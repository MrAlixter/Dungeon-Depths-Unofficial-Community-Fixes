Public NotInheritable Class CinnamonBimboTF
    Inherits BimboTF
    Public Shared bimboblonde As Color = Color.FromArgb(255, 253, 200, 134)

    Private Const TF_IND As tfind = tfind.demonbimbo

    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        MyBase.update_during_combat = False
        tf_name = TF_IND
        next_step = AddressOf hairColorShift
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        MyBase.update_during_combat = False
        tf_name = TF_IND
        next_step = getNextStep(cs)
    End Sub

    'Hair Color Shift
    Overrides Sub hairColorShift()
        Game.player1.prt.haircolor = DDUtils.cShift(Game.player1.prt.haircolor, bimboblonde, 200)
        If Not Game.player1.getHairColor.Equals(bimboblonde) Then curr_step -= 1
        TextEvent.fpush("Your hair rapidly becomes lighter, brightening towards a sandy blonde.")
    End Sub

    'Step 1
    Public Overrides Sub s1BimboHairChange(ByRef p As Player)
        p.prt.haircolor = bimboblonde
        p.prt.setIAInd(pInd.rearhair, 5, True, True)
        p.prt.setIAInd(pInd.midhair, 5, True, True)
        p.prt.setIAInd(pInd.fronthair, 6, True, True)
    End Sub

    'Step 2
    Public Overrides Sub s2M2F(ByRef p As Player, ByRef out As String, ByRef haircolor As String)
        MyBase.s2M2F(p, out, "sandy blonde")
    End Sub
    Public Overrides Sub s2HairChange(ByRef p As Player)
        p.prt.haircolor = bimboblonde
        p.prt.setIAInd(pInd.rearhair, 42, True, True)
        p.prt.setIAInd(pInd.midhair, 50, True, True)
        p.prt.setIAInd(pInd.fronthair, 45, True, True)
    End Sub
    Public Overrides Sub s2FaceChange(ByRef p As Player)
        If p.name <> "Targax" Then
            p.prt.setIAInd(pInd.eyes, 26, True, True)
        Else
            p.prt.setIAInd(pInd.eyes, 29, True, True)  'eyes
        End If
        p.prt.setIAInd(pInd.mouth, 36, True, True)  'mouth

        p.prt.tanSkin()
        p.addLust(50)
    End Sub
    Overrides Sub s2ClothesChange(ByRef p As Player)
        If Not p.equippedArmor.getName.Equals("Naked") And Not p.className.Equals("Magical Girl") Then
            If p.inv.item("Skimpy_Clothes_(D)").count < 1 Then p.inv.add("Skimpy_Clothes_(D)", 1)
            EquipmentDialogBackend.armorChange(p, "Skimpy_Clothes_(D)")
        End If
    End Sub

    Public Overrides Function hasBimboHair(p As Player) As Boolean
        Return p.prt.haircolor.Equals(bimboblonde)
    End Function

    Shared Sub impTFPlayer(ByRef p As Player)
        Dim bTF As CinnamonBimboTF = New CinnamonBimboTF(3, 0, 0, False)

        bTF.step2()
        bTF.stopTF()

        p.UIupdate()
        p.drawPort()
    End Sub
    Shared Sub impTFPlayer2(ByRef p As Player)
        Dim bTF As CinnamonBimboTF = New CinnamonBimboTF(3, 0, 0, False)

        bTF.s2M2F(p, "", "platinum blonde")
        bTF.s2HairChange(p)
        bTF.s2FaceChange(p)
        bTF.s2BodyChange(p)

        bTF.stopTF()

        'unequips
        p.changeForm("Goo Girl")

        'transformation
        p.breastSize = 4
        p.buttSize = 3

        p.prt.setIAInd(pInd.ears, 5, True, True)
        p.prt.setIAInd(pInd.eyes, 35, True, True)
        p.prt.setIAInd(pInd.fronthair, 46, True, True)
        p.prt.setIAInd(pInd.eyebrows, 0, True, False)
        p.prt.setIAInd(pInd.cloak, 0, True, False)
        p.prt.setIAInd(pInd.hat, 0, True, False)

        p.prt.haircolor = Color.FromArgb(180, 253, 230, 164)
        p.prt.skincolor = Color.FromArgb(200, 255, 115, 95)

        p.UIupdate()
        p.drawPort()

        TextEvent.fpush("You glance to the flask amongst your potions, and your will cracks." & DDUtils.RNRN &
                        "It looks delectable; beckoning you to drink it with an invisible aura that promises so much.  It'll taste so good, right?  And it'll probably be enchanted in some way too- there's no telling what will happen to you if you drink it..." & DDUtils.TODO & DDUtils.RNRN &
                        "You turn into a goo-girl bimbo!")
    End Sub
End Class