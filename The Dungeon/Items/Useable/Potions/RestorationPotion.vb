Public Class RestorationPotion
    Inherits Item

    Sub New()
        MyBase.setName("Restore_Potion")
        MyBase.setDesc("'Restores ye to ye original form' says the bottle.")
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 275
    End Sub

    Overrides Sub use()
        If Me.getUsable() = False Then Exit Sub
        Form1.lstLog.Items.Add("You drink the " & getName())
        Form1.player.health += 25
        If Form1.player.health > Form1.player.maxHealth Then Form1.player.health = Form1.player.maxHealth
        'If Not Form1.player.iArrInd.Equals(Form1.player.sIArrInd) And Not Form1.player.iArrInd.Equals(Form1.player.pIArrInd) Then
        'Form1.player.revert2()
        ' ElseIf Form1.player.iArrInd.Equals(Form1.player.sIArrInd) Then
        'Form1.lstLog.Items.Add( "You can't revert further!")
        'Else
        Form1.player.revert()
        'End If
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
        count -= 1
    End Sub
    Overrides Sub discard()
        Form1.lstLog.Items.Add("You drop the " & getName())
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
