Public Class Fireball
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        MyBase.setName("Fireball")
        MyBase.settier(1)
        MyBase.setcost(4)
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = 40
        Dim d31 = Int(Rnd() * 3)
        Dim d32 = Int(Rnd() * 3)
        If 1 = 0 Then
            'critical hit
        Else
            'non critical hit
            dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, dmg + d31 + d32)
            Game.pushLstLog(CStr("You hit the " & MyBase.getTarget.name & " for " & dmg & " damage!"))
            Game.pushLblCombatEvent(CStr("You hit the " & MyBase.getTarget.name & " for " & dmg & " damage!"))
            MyBase.getTarget.takeDMG(dmg, MyBase.getCaster)
        End If
    End Sub
End Class
