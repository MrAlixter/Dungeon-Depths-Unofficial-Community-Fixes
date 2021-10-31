Public Class WOVoltage
    Inherits Wand

    Sub New()
        '|ID Info|
        setName("Wand_of_Voltage")
        id = 179
        tier = 3

        '|Item Flags|
        usable = False
        droppable = False

        '|Stats|
        count = 0
        value = 1000

        '|Description|

        setDesc("A slender black wand crackling with electricity.  This power causes it to tend to be a bit unstable though.  Frogs may want to steer clear of its bearer...")

    End Sub
    Public Overrides Sub spell(ByRef p As Player, ByRef m As Entity)
        Dim dmg As Integer = 20
        Dim d31 = Int(Rnd() * 3)
        Dim d32 = Int(Rnd() * 3)

        If m.getName.Contains("Frog") Then dmg += 30
        m.takeDMG(dmg + d31 + d32, p)
        TextEvent.pushLog(CStr("You zap the " & m.name & " for " & dmg + d31 + d32 & " damage!"))
        TextEvent.pushCombat(CStr("You zap the " & m.name & " for " & dmg + d31 + d32 & " damage!"))

        durability -= Int(Rnd() * 5) + 5
    End Sub
End Class
