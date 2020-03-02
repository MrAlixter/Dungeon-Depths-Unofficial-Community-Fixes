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
        Game.pushLstLog("You drink the " & getName())

        Dim rEffect = New RestEffect
        rEffect.apply(Game.player)
        
        count -= 1
    End Sub
End Class
