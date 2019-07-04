Public Class TSpecial
    Inherits Food
    Sub New()
        MyBase.setName("Tavern_Special")
        MyBase.setDesc("An entire broasted chicken, served with mashed potatos and bread." & vbCrLf &
                       "-100 Hunger" & vbCrLf &
                       "Low chance to raise Max Health by 5")
        id = 133
        tier = Nothing
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 1400
        setCalories(100)
    End Sub

    Public Overrides Sub Effect()
        If Int(Rnd() * 5) = 0 Then
            Game.player.maxHealth += 5
            Game.player.health += 5 / Game.player.getMaxHealth()
            If Game.player.health > 1 Then Game.player.health = 1
            Game.player.UIupdate()
        End If
    End Sub
End Class
