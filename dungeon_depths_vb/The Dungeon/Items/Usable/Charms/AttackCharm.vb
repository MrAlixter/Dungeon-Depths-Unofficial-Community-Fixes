Public Class AttackCharm
    Inherits Item

    Public Const ITEM_NAME As String = "Attack_Charm"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 50
        tier = 2

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 1750

        '|Description|
        setDesc("A charm that slightly boosts your attack.")
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        TextEvent.pushLog("You use the " & getName() & ". +5 base ATK!")

        p.attack += 5
        p.UIupdate()
        p.perks(perk.acharmsused) += 1
        count -= 1
    End Sub
End Class
