Public NotInheritable Class GABimboTF
    Inherits BimboTF
    Public Shared bimboyellowg1 As Color = Color.FromArgb(255, 228, 255, 83)
    Public Shared bimboyellowg2 As Color = Color.FromArgb(255, 244, 255, 184)

    Private Const TF_IND As tfind = tfind.gabimbo

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
        Game.player1.prt.haircolor = DDUtils.cShift(Game.player1.prt.haircolor, bimboyellowg1, 55)
        If Not Game.player1.getHairColor.Equals(bimboyellowg1) Then curr_step -= 1
        TextEvent.push("Your hair becomes slightly lighter, brightening to a greenish blonde.")
    End Sub

    'Step 1
    Public Overrides Sub s1BimboHairChange(ByRef p As Player)
        p.prt.haircolor = bimboyellowg1
        p.prt.setIAInd(pInd.rearhair, 5, True, True)
        p.prt.setIAInd(pInd.midhair, 5, True, True)
        p.prt.setIAInd(pInd.fronthair, 6, True, True)
    End Sub

    'Step 2
    Public Overrides Sub s2M2F(ByRef p As Player, ByRef out As String, ByRef haircolor As String)
        MyBase.s2M2F(p, out, "greenish blonde")
    End Sub
    Public Overrides Sub s2HairChange(ByRef p As Player)
        p.prt.haircolor = bimboyellow2
        p.prt.setIAInd(pInd.rearhair, 3, True, False)
        p.prt.setIAInd(pInd.midhair, 21, True, True)
        p.prt.setIAInd(pInd.fronthair, 16, True, True)
    End Sub
    Public Overrides Sub s2FaceChange(ByRef p As Player)
        If p.name <> "Targax" Then
            p.prt.haircolor = bimboyellow2
            p.prt.setIAInd(pInd.eyes, 28, True, True)
        Else
            p.prt.setIAInd(pInd.eyes, 16, True, True)
        End If

        p.prt.setIAInd(pInd.eyebrows, 9, True, False)
        p.prt.setIAInd(pInd.mouth, 32, True, True)
        p.prt.setIAInd(pInd.hat, 6, True, False)
    End Sub
    Overrides Sub s2BodyChange(ByRef p As Player)
        If p.breastSize < 3 Then
            p.breastSize = 3
        ElseIf p.breastSize < 7 Then
            p.breastSize += 1
        End If

        If p.buttSize < 3 Then
            p.buttSize = 3
        ElseIf p.buttSize < 7 Then
            p.buttSize += 1
        End If

        s2ClothesChange(p)
    End Sub
    Overrides Sub s2ClothesChange(ByRef p As Player)
        If Not p.equippedArmor.getName.Equals("Naked") And Not p.className.Equals("Magical Girl") Then
            If p.inv.item(RegalLingerieF.ITEM_NAME).count < 1 Then p.inv.add(RegalLingerieF.ITEM_NAME, 1)
            EquipmentDialogBackend.armorChange(p, RegalLingerieF.ITEM_NAME)
        End If
    End Sub
    Overrides Sub s2WrapUp(ByRef p As Player, ByRef out As String)
        p.changeClass("Princess")
        p.perks(perk.bimbotf) = -1

        TextEvent.push(out)
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        turns_until_next_step = 3
        turns_until_next_step += generatWILResistance()
    End Sub

    Public Overrides Function hasBimboHair(p As Player) As Boolean
        Return p.prt.haircolor.Equals(bimboyellowg1) Or p.prt.haircolor.Equals(bimboyellowg2)
    End Function
End Class
