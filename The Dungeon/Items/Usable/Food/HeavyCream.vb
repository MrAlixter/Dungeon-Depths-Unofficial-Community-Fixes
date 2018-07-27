Public Class HeavyCream
    Inherits Food

    Sub New()
        MyBase.setName("Heavy_Cream")
        MyBase.setDesc("An increadibly heavy cream that probably isn't the best for you. -30 Hunger")
        id = 34
        tier = 2
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 265
        setCalories(30)
    End Sub
    Overrides Sub use()
        If Me.getUsable() = False Then Exit Sub
        Game.lstLog.Items.Add("You drink the " & getName())
        Game.player.hunger -= getCalories()
        If Game.player.hunger < 0 Then Game.player.hunger = 0
        Effect()
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub
    Public Overrides Sub Effect()
        Dim r As Integer = Int(Rnd() * 3)
        If r = 0 Then Game.player.be()
        If Polymorph.canBeTFed(Game.player) Then
            Game.player.pState.save(Game.player)
        End If
        Equipment.portraitUDate()
    End Sub
End Class
