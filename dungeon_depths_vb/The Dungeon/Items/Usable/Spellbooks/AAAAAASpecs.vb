Public Class AAAAAASpecs
    Inherits Item

    Sub New()
        '|ID Info|
        setName("AAAAAA_Specification")
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
