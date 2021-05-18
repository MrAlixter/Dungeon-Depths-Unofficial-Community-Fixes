Public Class Staff
    Inherits Weapon

    Sub New()
        setName("Staff")
        setDesc("A simple staff.")
        id = 21
        tier = Nothing
        usable = false
        MyBase.a_boost = 0
        count = 0
        value = 100
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
        Game.player1.mana += getMBoost(p)
    End Sub

    Public Overloads Overrides Sub onUnEquip(ByRef p As Player, ByRef w As Weapon)
        MyBase.onUnequip(p, w)
        Game.player1.mana -= getMBoost(p)
        If Game.player1.mana < 0 Then Game.player1.mana = 0
    End Sub
End Class
