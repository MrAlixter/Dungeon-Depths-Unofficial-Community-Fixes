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
    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        Game.pushLstLog("You drink the " & getName())
        p.hunger -= getCalories()
        If p.hunger < 0 Then p.hunger = 0
        Effect()

        count -= 1
    End Sub
    Public Overrides Sub Effect()
        Game.player1.be()
        Game.player1.be()
        If Transformation.canBeTFed(Game.player1) Then
            Game.player1.pState.save(Game.player1)
        End If
        Game.player1.drawPort()
    End Sub
End Class
