Public Class ManaCharm
    Inherits Item

    Public Const ITEM_NAME As String = "Mana_Charm"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 49
        tier = 3

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 1750

        '|Description|
        setDesc("A charm that slightly boosts your mana.")
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        TextEvent.pushLog("You use the " & getName() & ". +5 base mana!")

        p.maxMana += 5
        p.mana += 5
        If p.mana > p.getMaxMana Then p.mana = p.getMaxMana
        p.perks(perk.mcharmsused) += 1
        p.UIupdate()
        count -= 1
    End Sub
End Class
