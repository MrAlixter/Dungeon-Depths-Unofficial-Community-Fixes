Public Class DefenseCharm
    Inherits Item

    Public Const ITEM_NAME As String = "Defense_Charm"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 51
        tier = 3

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 1750

        '|Description|
        setDesc("A charm that slightly boosts your defense.")
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        TextEvent.pushLog("You use the " & getName() & ". +5 base DEF!")

        p.defense += 5
        p.UIupdate()
        p.perks(perk.dcharmsused) += 1
        count -= 1
    End Sub
End Class
