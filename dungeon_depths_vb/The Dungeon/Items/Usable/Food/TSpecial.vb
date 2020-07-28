Public Class TSpecial
    Inherits Food
    Sub New()
        MyBase.setName("Tavern_Special")
        MyBase.setDesc("An entire broasted chicken, served with mashed potatos and bread." & vbCrLf &
                       "+100 Stamina" & vbCrLf &
                       "Low chance to raise Max Health by 5")
        id = 135
        tier = Nothing
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 1400
        setCalories(100)
    End Sub

    Public Overrides Sub Effect()
        If Int(Rnd() * 5) = 0 Or Game.noRNG Then
            Game.player1.maxHealth += 5
            Game.player1.health += 5 / Game.player1.getMaxHealth()
            If Game.player1.health > 1 Then Game.player1.health = 1
            Game.player1.UIupdate()
        End If
    End Sub
End Class
