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
    End Sub
    Overrides Sub onEquip()
        Dim p As Player = Game.player

        MagGirlTF.chkForMagGirlRevert(p)

        p.perks("thrall") = 0
        p.ongoingTFs.Add(New ThrallTF(2, 10, 3.0, True))

        If Not p.pClass.name.Equals("Thrall") Then formerClass = p.pClass.name
        formerEyeType = p.prt.iArrInd(9)
        If Transformation.canBeTFed(p) Then p.pState.save(p)
        p.pClass = p.classes("Thrall")
        If p.prt.sexBool Then
            p.prt.setIAInd(9, 19, True, True)
        Else
            p.prt.setIAInd(9, 8, False, True)
        End If

        p.prefForm = New preferedForm()

        p.createP()
    End Sub
    Sub forceEquip()
        Dim p As Player = Game.player

        MagGirlTF.chkForMagGirlRevert(p)

        p.perks("thrall") = 0
        p.ongoingTFs.Add(New ThrallTF(2, 10, 3.0, True))

        formerClass = p.pClass.name
        formerEyeType = p.prt.iArrInd(9)
        If Transformation.canBeTFed(p) Then p.pState.save(p)
        p.pClass = p.classes("Thrall")
        If p.prt.sexBool Then
            p.prt.setIAInd(9, 19, True, True)
        Else
            p.prt.setIAInd(9, 8, False, True)
        End If

        If p.pClass.name.Equals("Magic Girl") Then
            p.breastSize = 2
            p.prt.setIAInd(6, 0, True, False)
            p.prt.setIAInd(15, 7, True, False)
        End If

        p.prefForm = New preferedForm()

        p.createP()
    End Sub
    Public Overrides Sub onUnequip()
        Dim p As player = game.player
        For i = 0 To p.ongoingTFs.Count - 1
            If i < p.ongoingTFs.Count Then
                If p.ongoingTFs(i).GetType() Is GetType(ThrallTF) Then
                    p.ongoingTFs(i).stopTF()
                    p.ongoingTFs.RemoveAt(i)
                End If
            End If
        Next
        p.perks("thrall") = -1
        p.pClass = Game.player.classes(formerClass)
        p.prt.setIAInd(9, formerEyeType)
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

    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())
        
        count -= 1
    End Sub
End Class
