Public Class WOShock
    Inherits Weapon

    Sub New()
        MyBase.setName("Wand_of_Shocking")
        MyBase.setDesc("A slender black wand charged with an almost electric energy.  Frogs may want to steer clear of its bearer...")
        id = 167
        tier = 3
        MyBase.setUsable(False)
        MyBase.count = 0
        MyBase.value = 1000

        MyBase.isMonsterDrop = False
    End Sub
    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg As Integer = 10
        Dim d31 = Int(Rnd() * 3)
        Dim d32 = Int(Rnd() * 3)

        If m.getName.Contains("Frog") Then dmg += 20
        m.takeDMG(dmg + d31 + d32, p)
        Game.pushLstLog(CStr("You zap the " & m.name & " for " & dmg + d31 + d32 & " damage!"))
        Game.pushLblCombatEvent(CStr("You zap the " & m.name & " for " & dmg + d31 + d32 & " damage!"))
        Return -3
    End Function
End Class
