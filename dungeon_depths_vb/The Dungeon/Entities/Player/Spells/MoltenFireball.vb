Public Class MoltenFireball
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        MyBase.setName("Molten Fireball")
        MyBase.settier(1)
        MyBase.setcost(0)
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = 40
        Dim d31 = Int(Rnd() * 3)
        Dim d32 = Int(Rnd() * 3)
        If 1 = 0 Then
            'critical hit
        Else
            'non critical hit
            MyBase.getTarget.takeDMG(dmg + d31 + d32, MyBase.getCaster)
            Game.pushLstLog(CStr("You hit the " & MyBase.getTarget.name & " for " & dmg + d31 + d32 & " damage!  The blowback hits you for 4 damage!"))
            Game.pushLblCombatEvent(CStr("You hit the " & MyBase.getTarget.name & " for " & dmg + d31 + d32 & " damage!  The blowback hits you for 4 damage!"))

            MyBase.getCaster.takeDMG(4, MyBase.getCaster)
        End If
    End Sub
End Class
