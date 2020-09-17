Public Class XPSandwich
    Inherits Food
    Sub New()
        MyBase.setName("XP_Sandwich")
        MyBase.setDesc("A roasted and seasoned chicken leg, served steaming hot on a bun!" & vbCrLf &
                       "+25 Stamina")
        id = 228
        tier = Nothing
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 150
        setCalories(25)
    End Sub

    Public Overrides Sub Effect()
        MyBase.Effect()
        Game.player1.xp += 500
        If Game.player1.xp >= Game.player1.nextLevelXp Then Game.player1.levelUp()
    End Sub
End Class
