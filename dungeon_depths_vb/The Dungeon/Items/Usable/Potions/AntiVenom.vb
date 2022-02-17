Public Class AntiVenom
    Inherits Item

    Public Const ITEM_NAME As String = "Anti_Venom"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 92
        tier = 3

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 1000

        '|Description|
        setDesc("A concoction brewed to eliminate venom from one's system.")

    End Sub

    Overrides Sub use(ByRef p As Player)
        TextEvent.pushLog("You drink the " & getName())
        Dim av As AntiVenomEffect = New AntiVenomEffect
        av.apply(p)
        TextEvent.push("You drink the " & getName() & ".  All venom effects have been neutralized!")
        count -= 1
    End Sub
End Class
