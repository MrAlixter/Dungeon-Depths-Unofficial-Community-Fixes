Public Class WOVoltage
    Inherits Wand

    Sub New()
        MyBase.setName("Wand_of_Voltage")
        MyBase.setDesc("A slender black wand crackling with electricity.  This power causes it to tend to be a bit unstable though.  Frogs may want to steer clear of its bearer...")
        id = 179
        tier = 3
        MyBase.setUsable(False)
        MyBase.count = 0
        MyBase.value = 1000

        MyBase.isMonsterDrop = False
    End Sub
    Public Overrides Sub spell(ByRef p As Player, ByRef m As Entity)
        Dim dmg As Integer = 20
        Dim d31 = Int(Rnd() * 3)
        Dim d32 = Int(Rnd() * 3)

        If m.getName.Contains("Frog") Then dmg += 30
        m.takeDMG(dmg + d31 + d32, p)
        Game.pushLstLog(CStr("You zap the " & m.name & " for " & dmg + d31 + d32 & " damage!"))
        Game.pushLblCombatEvent(CStr("You zap the " & m.name & " for " & dmg + d31 + d32 & " damage!"))

        durability -= Int(Rnd() * 5) + 5
    End Sub
End Class
