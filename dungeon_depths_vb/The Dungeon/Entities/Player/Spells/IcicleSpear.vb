Public Class IcicleSpear
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        MyBase.setName("Icicle Spear")
        MyBase.settier(2)
        MyBase.setcost(5)
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = 52
        Dim d6 = Int(Rnd() * 6)
        If d6 = 2 Or d6 = 3 Then
            'critical hit
            MyBase.getCaster.dealSpellDamage(MyBase.getTarget, 2 * (dmg + d6))
            Game.pushLstLog(CStr("Critical hit!  You hit the " & MyBase.getTarget.name & " for " & 2 * (dmg + d6) & " damage!"))
            Game.pushLblCombatEvent(CStr("Critical hit!  You hit the " & MyBase.getTarget.name & " for " & 2 * (dmg + d6) & " damage!"))
            
        Else
            'non critical hit
            MyBase.getCaster.dealSpellDamage(MyBase.getTarget, dmg + d6)
            Game.pushLstLog(CStr("You hit the " & MyBase.getTarget.name & " for " & dmg + d6 & " damage!"))
            Game.pushLblCombatEvent(CStr("You hit the " & MyBase.getTarget.name & " for " & dmg + d6 & " damage!"))
            
        End If
    End Sub
End Class
