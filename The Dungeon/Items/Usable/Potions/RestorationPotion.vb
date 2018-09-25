Public Class RestorationPotion
    Inherits Item

    Sub New()
        MyBase.setName("Restore_Potion")
        MyBase.setDesc("'Restores ye to ye original form' says the bottle.")
        id = 14
        tier = 3
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 275
    End Sub

    Overrides Sub use()
        If Me.getUsable() = False Then Exit Sub
        Game.lstLog.Items.Add("You drink the " & getName())
        Game.player.health += 25 / Game.player.getmaxHealth
        If Game.player.health > 1 Then Game.player.health = 1
        'If Not Form1.player.iArrInd.Equals(Form1.player.sIArrInd) And Not Form1.player.iArrInd.Equals(Form1.player.pIArrInd) Then
        'Form1.player.revert2()
        ' ElseIf Form1.player.iArrInd.Equals(Form1.player.sIArrInd) Then
        'Form1.lstLog.Items.Add( "You can't revert further!")
        'Else
        Game.player.revertToSState()
        'End If
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub
    Overrides Sub discard()
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
