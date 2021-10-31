Public NotInheritable Class GBimboTF
    Inherits BimboTF
    Public Shared bimbogold1 As Color = Color.FromArgb(255, 255, 232, 67)
    Public Shared bimbogold2 As Color = Color.FromArgb(255, 255, 249, 179)
    Public Shared bimbogold3 As Color = Color.FromArgb(255, 255, 255, 97)

    Private Const TF_IND As tfind = tfind.goldbimbo

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
        Game.player1.prt.haircolor = DDUtils.cShift(Game.player1.prt.haircolor, bimbogold1, 50)
        If Not Game.player1.getHairColor.Equals(bimbogold1) Then curr_step -= 1
        TextEvent.push("Your hair becomes slightly lighter, brightening to a brilliant gold." & DDUtils.RNRN & "+6 LUST")

        Game.player1.addLust(6)
    End Sub

    'Step 1
    Public Overrides Sub s1BimboHairChange(ByRef p As Player)
        p.prt.haircolor = bimbogold1
        p.prt.setIAInd(pInd.rearhair, 5, True, True)
        p.prt.setIAInd(pInd.midhair, 5, True, True)
        p.prt.setIAInd(pInd.fronthair, 6, True, True)
    End Sub
    Public Overrides Sub s1FaceChange(ByRef p As Player)
        If p.prt.checkNDefFemInd(pInd.ears, 6) Then p.prt.setIAInd(pInd.ears, 0, True, True)
        p.prt.setIAInd(pInd.mouth, 5, True, True)
        p.prt.setIAInd(pInd.eyes, 57, True, True)
        p.prt.setIAInd(pInd.cloak, 0, True, False)
        If Not p.className.Equals("Magical Girl") Then p.prt.setIAInd(pInd.hat, 0, True, False)
    End Sub

    'Step 2
    Public Overrides Sub s2M2F(ByRef p As Player, ByRef out As String, ByRef haircolor As String)
        MyBase.s2M2F(p, out, "brilliant gold")
    End Sub
    Public Overrides Sub s2HairChange(ByRef p As Player)
        p.prt.haircolor = bimbogold2
        p.prt.setIAInd(pInd.rearhair, 12, True, True)  'rearhair1
        p.prt.setIAInd(pInd.midhair, 36, True, True)  'rearhair2
    End Sub
    Public Overrides Sub s2FaceChange(ByRef p As Player)
        p.prt.haircolor = bimbogold2
        p.prt.setIAInd(pInd.eyes, 56, True, True)  'eyes
        p.prt.setIAInd(pInd.mouth, 27, True, True)  'mouth
    End Sub
    Overrides Sub s2ClothesChange(ByRef p As Player)
        If Not p.equippedArmor.getName.Equals("Naked") And Not p.className.Equals("Magical Girl") Then
            If p.inv.item("Skimpy_Clothes_(G)").count < 1 Then p.inv.add("Skimpy_Clothes_(G)", 1)
            EquipmentDialogBackend.armorChange(p, "Skimpy_Clothes_(G)")
        End If
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        If Not hasBimboHair(Game.player1) Then
            Return AddressOf hairColorShift
        End If
        If Game.player1.className.Equals("Magical Girl") Then
            Return AddressOf step2alt
        End If
        If Game.player1.inv.getCountAt("Golden_Gum") < 1 or Game.player1.className.Equals("Bimbo") Then
            Return AddressOf stopTF
        End If

        Select Case stage
            Case 0
                Return AddressOf step1
            Case 1
                Return AddressOf step2
            Case Else
                Return AddressOf stopTF
        End Select
    End Function

    Public Overrides Sub setWaitTime(stage As Integer)
        turns_until_next_step = 10 + (Int(Rnd() * 5) + 1)
        turns_until_next_step += generatWILResistance()
    End Sub

    Public Overrides Function hasBimboHair(p As Player) As Boolean
        Return p.prt.haircolor.Equals(bimbogold1) Or p.prt.haircolor.Equals(bimbogold2) Or p.prt.haircolor.Equals(bimbogold3)
    End Function

    Public Shared Sub snapTF(Optional ByRef p As Player = Nothing)
        If p Is Nothing Then p = Game.player1

        If p.sex = "Male" Then p.MtF()

        p.changeHairColor(bimbogold2)

        If p.inv.item("Skimpy_Clothes_(G)").count < 1 Then p.inv.add("Skimpy_Clothes_(G)", 1)
        EquipmentDialogBackend.armorChange(p, "Skimpy_Clothes_(G)")

        p.prt.setIAInd(pInd.rearhair, 12, True, True)  'rearhair1
        p.prt.setIAInd(pInd.midhair, 39, True, True)  'rearhair2
        p.prt.setIAInd(pInd.eyes, 56, True, True)  'eyes
        p.prt.setIAInd(pInd.mouth, 25, True, True)  'mouth

        p.addLust(66)

        If p.breastSize < 5 Then
            p.breastSize = 5
            p.buttSize = 4
        ElseIf p.breastSize < 7 Then
            p.breastSize += 1
            p.buttSize += 1
        End If

        p.changeClass("Bimbo")
    End Sub
End Class
