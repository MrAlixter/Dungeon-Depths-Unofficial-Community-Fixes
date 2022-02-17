Public Class OmniCharm
    Inherits Item

    Public Const ITEM_NAME As String = "Omni_Charm"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 126
        tier = Nothing

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 4700

        '|Description|
        setDesc("A charm that slightly boosts all base stats.")
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        TextEvent.push("You use the " & getName() & ". +5 base ATK, DEF, SPD, WILL, Max Mana, +10 Max Health!")

        p.attack += 5
        p.defense += 5
        p.speed += 5
        p.maxMana += 5
        p.will += 5
        p.maxHealth += 10

        p.UIupdate()
        count -= 1
    End Sub
End Class
