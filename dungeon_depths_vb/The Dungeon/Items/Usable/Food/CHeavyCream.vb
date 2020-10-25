Public Class CHeavyCream
    Inherits Food

    Sub New()
        '|ID Info|
        MyBase.setName("Cursed_Heavy_Cream")
        id = 98
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(True)

        '|Stats|
        MyBase.count = 0
        MyBase.value = 265
        setCalories(30)

        '|Description|
        MyBase.setDesc("An increadibly heavy cream that seems a bit fattening.  Apperantly it might be a little bit cursed." & DDUtils.RNRN &
                       "-30 stamina" & DDUtils.RNRN &
                       "Major breast enlargement")
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
        Game.player1.be()
        Game.player1.be()
        If Transformation.canBeTFed(Game.player1) Then
            Game.player1.pState.save(Game.player1)
        End If
        Game.player1.drawPort()
    End Sub
End Class
