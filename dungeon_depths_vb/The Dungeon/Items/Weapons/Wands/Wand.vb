Public MustInherit Class Wand
    Inherits Weapon

    Sub New()
        MyBase.setName("Wand")
        MyBase.setDesc("A simple wand.")
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

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        spell(p, m)
        Return -3
    End Function
    MustOverride Sub spell(ByRef p As Player, ByRef m As Entity)
End Class
