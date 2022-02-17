Public Class ThrallCollar
    Inherits Accessory

    Public Const ITEM_NAME As String = "Slave_Collar"

    Dim formerClass As String = ""
    Dim formerEyeType As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 69
        tier = 3

        '|Item Flags|
        droppable = True
        usable = False
        cursed = True
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 200

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(7, True, True)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(3, False, True)

        '|Description|
        setDesc("A collar commonly placed around the necks of the thralls." & DDUtils.RNRN &
                "Provides no bonus.")
    End Sub
    Overrides Sub onEquip(ByRef p As Player)
        If p.formName.Equals("Half-Succubus") Or p.className.Equals("Thrall") Then Exit Sub
        MagGirlTF.chkForMagGirlRevert(p)

        p.perks(perk.thrall) = 0
        p.ongoingTFs.Add(New ThrallTF(2, 10, 3.0, True))

        If Not p.className.equals("Thrall") Then formerClass = p.className
        formerEyeType = p.prt.iArrInd(pInd.eyes)
        p.savePState()
        p.changeClass("Thrall")
        If p.prt.sexBool Then
            p.prt.setIAInd(pInd.eyes, 19, True, True)
        Else
            p.prt.setIAInd(pInd.eyes, 8, False, True)
        End If
        p.prefForm = New preferredForm()

        p.drawPort()
    End Sub
    Sub forceEquip()
        Dim p As Player = Game.player1

        If p.formName.Equals("Half-Succubus") Or p.className.Equals("Thrall") Then Exit Sub
        MagGirlTF.chkForMagGirlRevert(p)

        p.perks(perk.thrall) = 0
        p.ongoingTFs.Add(New ThrallTF(2, 10, 3.0, True))

        formerClass = p.className
        formerEyeType = p.prt.iArrInd(pInd.eyes)
        p.savePState()
        p.changeClass("Thrall")
        If p.prt.sexBool Then
            p.prt.setIAInd(pInd.eyes, 19, True, True)
        Else
            p.prt.setIAInd(pInd.eyes, 8, False, True)
        End If

        p.prefForm = New preferredForm()

        p.drawPort()
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        If Not p.ongoingTFs.contains(tfind.thrall) And Not p.className.Equals("Thrall") And Not p.formName.Equals("Half-Succubus") Then Exit Sub

        p.ongoingTFs.remove(tfind.thrall)

        p.perks(perk.thrall) = -1
        p.changeClass(formerClass)
        p.prt.setIAInd(pInd.eyes, formerEyeType)
        p.prefForm = Nothing
        p.forcedPath = Nothing
        p.genDescription()
    End Sub

    Public Function getFT() As String
        Return formerClass
    End Function
    Public Overrides Function ToString() As String
        Return formerClass & "$" & formerEyeType.Item1 & "$" & formerEyeType.Item2 & "$" & formerEyeType.Item3
    End Function
    Public Function save() As String
        Return formerClass & SaveFile.VALUE_SPLIT_DELIMITER &
               formerEyeType.Item1 & SaveFile.VALUE_SPLIT_DELIMITER &
               formerEyeType.Item2 & SaveFile.VALUE_SPLIT_DELIMITER &
               formerEyeType.Item3
    End Function
    Public Sub setFormerLife(ft As String, fet As Tuple(Of Integer, Boolean, Boolean))
        formerClass = ft
        formerEyeType = fet
    End Sub
End Class
