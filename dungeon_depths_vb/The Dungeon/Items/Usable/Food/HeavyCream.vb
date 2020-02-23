Public Class HeavyCream
    Inherits Food

    Sub New()
        MyBase.setName("Heavy_Cream")
        MyBase.setDesc("An increadibly heavy cream that seems a bit fattening. -30 Hunger")
        id = 34
        tier = 2
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
        Dim r As Integer = Int(Rnd() * 3)
        If r = 0 Or Game.noRNG Then Game.player.be()
        If transformation.canbeTFed(Game.player) Then
            Game.player.pState.save(Game.player)
        End If
        Game.player.drawPort()
    End Sub
End Class
