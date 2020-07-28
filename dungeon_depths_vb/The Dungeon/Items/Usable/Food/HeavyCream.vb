Public Class HeavyCream
    Inherits Food

    Sub New()
        MyBase.setName("Heavy_Cream")
        MyBase.setDesc("An increadibly heavy cream that seems a bit fattening. +30 stamina")
        id = 34
        tier = 2
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 265
        setCalories(30)
    End Sub
    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        Game.pushLstLog("You drink the " & getName())
        p.stamina += getCalories()
        If p.stamina > 100 Then p.stamina = 100
        Effect()

        count -= 1
    End Sub
    Public Overrides Sub Effect()
        Dim r As Integer = Int(Rnd() * 3)
        If r = 0 Or Game.noRNG Then Game.player1.be()
        If transformation.canbeTFed(Game.player1) Then
            Game.player1.pState.save(Game.player1)
        End If
        Game.player1.drawPort()
    End Sub
End Class
