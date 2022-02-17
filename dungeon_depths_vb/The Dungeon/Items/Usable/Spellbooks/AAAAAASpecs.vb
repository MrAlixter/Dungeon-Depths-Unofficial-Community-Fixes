Public Class AAAAAASpecs
    Inherits Item

    Public Const ITEM_NAME As String = "AAAAAA_Specification"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 279
        tier = Nothing

        '|Item Flags|
        usable = true
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 200

        '|Description|
        setDesc("A small paper pamphlet containing a diagam of a sextuple-A battery.  On its back, a simple incantation is scrawled in ink.")
    End Sub

    Overrides Sub use(ByRef p As Player)
        p.learnSpell("Summon Battery")

        count -= 1
    End Sub
End Class
