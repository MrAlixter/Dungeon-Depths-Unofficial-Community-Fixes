Public Class CurseBGone
    Inherits Item

    Sub New()
        MyBase.setName("Curse_'B'_Gone")
        MyBase.setDesc("A small paper tag with instructions to ""Stuck in a bind?  Slap me on any cursed clothing to 'bust' out of it!""")
        id = 195
        tier = Nothing
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 50
    End Sub

    Overrides Sub use(ByRef p As Player)
        Equipment.clothesChange("Naked")

        p.breastSize = 7
        p.buttSize = 5
        p.reverseAllRoute()

        Game.pushLblEvent("Peeling off the paper backing from the Curse-B-Gone tag, you place it gently on your chest.")
        p.drawPort()
        count -= 1
    End Sub
End Class
