Public Class ThrallCollar
    Inherits Accessory
    'The the slave collar handles the thrall tf
    Dim formerClass As String = ""
    Dim formerEyeType As Tuple(Of Integer, Boolean) = New Tuple(Of Integer, Boolean)(0, False)

    Sub New()
        MyBase.setName("Slave_Collar")
        MyBase.setDesc("A collar commonly placed around the necks of the thralls." & vbCrLf & _
                       "Provides no bonus.")
        id = 69
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.count = 0
        MyBase.value = 200
        MyBase.fInd = New Tuple(Of Integer, Boolean)(7, True)
        MyBase.mInd = New Tuple(Of Integer, Boolean)(3, False)
    End Sub
    Overrides Sub onEquip()
        Dim p = Game.player
        p.perks("thrall") = 0
        p.ongoingTFs.Add(New ThrallTF(2, 10, 3.0, True))

        If Not p.pClass.name.Equals("Thrall") Then formerClass = p.pClass.name
        formerEyeType = p.iArrInd(9)
        If Transformation.canBeTFed(p) Then p.pState.save(p)
        p.pClass = p.classes("Thrall")
        If p.sexBool Then
            p.iArrInd(9) = New Tuple(Of Integer, Boolean)(19, True)
        Else
            p.iArrInd(9) = New Tuple(Of Integer, Boolean)(8, False)
        End If

        p.prefForm = New preferedForm()

        p.createP()
    End Sub
    Sub forceEquip()
        Dim p = Game.player
        p.perks("thrall") = 0
        p.ongoingTFs.Add(New ThrallTF(2, 10, 3.0, True))

        formerClass = p.pClass.name
        formerEyeType = p.iArrInd(9)
        If Transformation.canBeTFed(p) Then p.pState.save(p)
        p.pClass = p.classes("Thrall")
        If p.sexBool Then
            p.iArrInd(9) = New Tuple(Of Integer, Boolean)(19, True)
        Else
            p.iArrInd(9) = New Tuple(Of Integer, Boolean)(8, False)
        End If

        If p.pClass.name.Equals("Magic Girl") Then
            p.breastSize = 2
            p.iArrInd(6) = New Tuple(Of Integer, Boolean)(0, True)
            p.iArrInd(15) = New Tuple(Of Integer, Boolean)(7, True)
        End If

        p.prefForm = New preferedForm()

        p.createP()
    End Sub
    Public Overrides Sub onUnequip()
        Dim p = Game.player
        For i = 0 To p.ongoingTFs.Count - 1
            If p.ongoingTFs(i).GetType() Is GetType(ThrallTF) Then
                p.ongoingTFs(i).stopTF()
                p.ongoingTFs.RemoveAt(i)
            End If
        Next
        p.pClass = Game.player.classes(formerClass)
        p.iArrInd(9) = formerEyeType
        p.prefForm = Nothing
        p.forcedPath = Nothing
    End Sub

    Public Function getFT() As String
        Return formerClass
    End Function
    Public Overrides Function ToString() As String
        Return formerClass & "$" & formerEyeType.Item1 & "$" & formerEyeType.Item2
    End Function
    Public Sub setFormerLife(ft As String, fet As Tuple(Of Integer, Boolean))
        formerClass = ft
        formerEyeType = fet
    End Sub

    Overrides Sub discard()
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
