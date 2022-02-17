Public Class AntiFreeze
    Inherits Food

    Public Const ITEM_NAME As String = "Antifreeze"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 178
        tier = Nothing

        '|Item Flags|
        usable = true
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 226
        setCalories(100)

        '|Description|
        setDesc("The forbidden sport's drink.  If you drink it, you will die. " & DDUtils.RNRN & "+100 Stamina")
    End Sub
    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        TextEvent.pushLog("You drink the " & getName())
        p.stamina += getCalories()
        If p.stamina > 100 Then p.stamina = 100
        effect(p)

        count -= 1
    End Sub
    Public Overrides Sub effect(ByRef p As Player)
        p.die(Nothing)
    End Sub
End Class
