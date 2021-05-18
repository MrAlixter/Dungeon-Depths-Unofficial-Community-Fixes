Public Class CurseBGone
    Inherits Item

    Sub New()
        '|ID Info|
        setName("Curse_'B'_Gone")
        id = 195
        tier = Nothing

        '|Item Flags|
        usable = true

        '|Stats|
        count = 0
        value = 50

        '|Description|
        setDesc("A small paper tag with instructions to ""Stuck in a bind?  Slap me on any cursed clothing to 'bust' out of it!""")
    End Sub

    Overrides Sub use(ByRef p As Player)
        Equipment.clothesChange(p, "Naked")

        p.breastSize = 7
        p.buttSize = 5

        Game.pushLblEvent("Peeling off the paper backing from the Curse-B-Gone tag, you place it gently on your chest.")
        p.drawPort()
        count -= 1
    End Sub
End Class
