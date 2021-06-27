Public Class Staff
    Inherits Weapon

    Sub New()
        '|ID Info|
        setName("Staff")
        id = 21
        tier = Nothing

        '|Item Flags|
        usable = False

        '|Stats|
        count = 0
        value = 100

        '|Description|
        setDesc("A simple staff." & DDUtils.RNRN &
                getStatInformation())
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
