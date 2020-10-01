Public Class ThrallCollar
    Inherits Accessory
    'The the slave collar handles the thrall tf
    Dim formerClass As String = ""
    Dim formerEyeType As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)

    Sub New()
        MyBase.setName("Slave_Collar")
        MyBase.setDesc("A collar commonly placed around the necks of the thralls." & vbCrLf & _
                       "Provides no bonus.")
        id = 69
        tier = 3
        isMonsterDrop = True
        MyBase.setUsable(False)
        MyBase.count = 0
        MyBase.value = 200
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(7, True, True)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(3, False, True)
        MyBase.isCursed = True
        MyBase.isRandoTFAcceptable = False
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
        p.prefForm = New preferedForm()

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

        p.prefForm = New preferedForm()

        p.drawPort()
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        If p.ongoingTFs.getAt("ThrallTF") Is Nothing And Not p.className.Equals("Thrall") And Not p.formName.Equals("Half-Succubus") Then Exit Sub

        p.ongoingTFs.remove("ThrallTF")

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
    Public Sub setFormerLife(ft As String, fet As Tuple(Of Integer, Boolean, Boolean))
        formerClass = ft
        formerEyeType = fet
    End Sub
End Class
