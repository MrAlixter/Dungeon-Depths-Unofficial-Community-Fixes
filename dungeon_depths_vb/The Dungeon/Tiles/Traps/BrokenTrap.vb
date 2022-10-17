Public Class BrokenTrap
    Inherits Trap

    Sub New(ByVal p As Point)
        MyBase.New(p)
        iD = tInd.broken
    End Sub

    Overrides Sub activate()
        MyBase.activate()

        TextEvent.push("The trap crackles with mana, before crumbling to dust...")
    End Sub
End Class
