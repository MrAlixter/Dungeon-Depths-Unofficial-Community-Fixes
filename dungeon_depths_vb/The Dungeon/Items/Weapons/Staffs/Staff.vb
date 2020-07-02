Public Class Staff
    Inherits Weapon

    Sub New()
        MyBase.setName("Staff")
        MyBase.setDesc("A simple staff.")
        id = 21
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.aBoost = 0
        count = 0
        value = 100
    End Sub

    Public Overrides Sub onEquip()
        MyBase.onEquip()
        Game.player1.mana += mBoost
    End Sub

    Public Overrides Sub onunEquip(Optional w As Weapon = Nothing)
        MyBase.onEquip()
        Game.player1.mana -= mBoost
        If Game.player1.mana < 0 Then Game.player1.mana = 0
    End Sub
End Class
