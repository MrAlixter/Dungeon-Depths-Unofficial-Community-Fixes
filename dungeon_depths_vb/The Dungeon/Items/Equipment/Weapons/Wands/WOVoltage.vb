Public Class WOVoltage
    Inherits Wand

    Public Const ITEM_NAME As String = "Wand_of_Voltage"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 179
        tier = 3

        '|Item Flags|
        usable = False
        droppable = False
        can_hit_flying = True

        '|Stats|
        count = 0
        value = 1122

        '|Description|

        setDesc("A slender black wand crackling with electricity.  This power causes it to tend to be a bit unstable though.  Frogs may want to steer clear of its bearer...")

    End Sub
    Public Overrides Sub spell(ByRef p As Player, ByRef m As Entity)
        Dim dmg As Integer = 20
        Dim d31 = Int(Rnd() * 3)
        Dim d32 = Int(Rnd() * 3)

        If m.getName.Contains("Frog") Then dmg += 30
        m.takeDMG(dmg + d31 + d32, p)
        TextEvent.pushAndLog(CStr("You zap the " & m.name & " for " & dmg + d31 + d32 & " damage!"))

        durability -= Int(Rnd() * 5) + 5
    End Sub
End Class
