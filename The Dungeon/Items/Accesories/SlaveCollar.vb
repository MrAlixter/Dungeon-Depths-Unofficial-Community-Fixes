Public Class SlaveCollar
    Inherits Accessory
    'The the slave collar handles the thrall tf
    Dim formerTitle As String
    Dim formerEyeType As Tuple(Of Integer, Boolean)

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
        Game.player.perks("thrall") = 0
        formerTitle = Game.player.title
        formerEyeType = Game.player.iArrInd(9)
        If Polymorph.canBeTFed(Game.player) Then Game.player.pState.save(Game.player)
        Game.player.title = "Thrall"
        If Game.player.sexBool Then
            Game.player.iArrInd(9) = New Tuple(Of Integer, Boolean)(19, True)
        Else
            Game.player.iArrInd(9) = New Tuple(Of Integer, Boolean)(8, False)
        End If

        Game.player.prefForm = New preferedForm()

        Equipment.portraitUDate()
    End Sub
    Public Overrides Sub onUnequip()
        Game.player.perks("thrall") = -1
        Game.player.title = formerTitle
        Game.player.iArrInd(9) = formerEyeType
    End Sub

    Public Sub setFormerLife(ft As String, fet As Tuple(Of Integer, Boolean))
        formerTitle = ft
        formerEyeType = fet
    End Sub
End Class
