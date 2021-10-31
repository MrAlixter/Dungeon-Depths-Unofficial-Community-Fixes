Public Class WOShock
    Inherits Wand

    Sub New()
        '|ID Info|
        setName("Wand_of_Shocking")
        id = 167
        tier = 3

        '|Item Flags|
        usable = False
        droppable = False

        '|Stats|
        count = 0
        value = 1000

        '|Description|

        setDesc("A slender black wand charged with an almost electric energy.  Frogs may want to steer clear of its bearer...")

    End Sub
    Public Overrides Sub spell(ByRef p As Player, ByRef m As Entity)
        Dim dmg As Integer = 10
        Dim d31 = Int(Rnd() * 3)
        Dim d32 = Int(Rnd() * 3)

        If m.getName.Contains("Frog") Then dmg += 20
        m.takeDMG(dmg + d31 + d32, p)
        TextEvent.pushLog(CStr("You zap the " & m.name & " for " & dmg + d31 + d32 & " damage!"))
        TextEvent.pushCombat(CStr("You zap the " & m.name & " for " & dmg + d31 + d32 & " damage!"))
    End Sub
End Class
