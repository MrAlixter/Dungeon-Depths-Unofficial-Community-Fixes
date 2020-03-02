Public Class CHeavyCream
    Inherits Food

    Sub New()
        MyBase.setName("Cursed_Heavy_Cream")
        MyBase.setDesc("An increadibly heavy cream that seems a bit fattening.  Apperantly it might be a little bit cursed." & vbCrLf & "-30 Hunger, major breast enlargement")
        id = 98
        tier = Nothing
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 265
        setCalories(30)
    End Sub
    Overrides Sub use()
        If Me.getUsable() = False Then Exit Sub
        Game.pushLstLog("You drink the " & getName())
        Game.player.hunger -= getCalories()
        If Game.player.hunger < 0 Then Game.player.hunger = 0
        Effect()

        count -= 1
    End Sub
    Public Overrides Sub Effect()
        Game.player.be()
        Game.player.be()
        If Transformation.canBeTFed(Game.player) Then
            Game.player.pState.save(Game.player)
        End If
        Game.player.createP()
    End Sub
End Class
