Public Class SpeedCharm
    Inherits Item

    Public Const ITEM_NAME As String = "Speed_Charm"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 52
        tier = 3

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 1750

        '|Description|
        setDesc("A charm that slightly boosts your speed.")
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        TextEvent.pushLog("You use the " & getName() & ". +5 base SPD!")

        p.speed += 5
        p.perks(perk.scharmsused) += 1
        p.UIupdate()
        count -= 1
    End Sub
End Class
