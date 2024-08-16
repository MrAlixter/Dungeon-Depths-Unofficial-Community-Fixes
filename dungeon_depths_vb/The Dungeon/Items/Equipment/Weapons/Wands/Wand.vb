Public MustInherit Class Wand
    Inherits Weapon

    Sub New()
        setName("Wand")
        setDesc("A simple wand.")
        tier = Nothing
        usable = False
        can_hit_flying = True
        MyBase.a_boost = 0
        count = 0
        value = 100
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
        Game.player1.mana += getMBoost(p)
    End Sub

    Public Overrides Sub onUnequip(ByRef p As Player, ByRef w As Weapon)
        MyBase.onUnequip(p, w)

        Game.player1.mana -= getMBoost(p)
        If Game.player1.mana < 0 Then Game.player1.mana = 0

        If p.perks(perk.tfcausingwand) <> -1 Then
            CType(p.inv.item(p.perks(perk.tfcausingwand)), Wand).onUnequip(p, w)
            p.perks(perk.tfcausingwand) = -1
        End If
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        spell(p, m)
        Return -3
    End Function
    MustOverride Sub spell(ByRef p As Player, ByRef m As Entity)
End Class
