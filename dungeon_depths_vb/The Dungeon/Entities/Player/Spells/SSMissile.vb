Public Class SSMissile
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        MyBase.setName("Shiny Sparking Missile")
        MyBase.settier(1)
        MyBase.setcost(7)
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = 69
        Dim d6 = Int(Rnd() * 7)
        If d6 = 2 Then
            'critical hit
            dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, 2 * (dmg + d6))
            Game.pushLstLog(CStr("Critical hit!  You hit the " & MyBase.getTarget.name & " for " & dmg & " damage!"))
            Game.pushLblCombatEvent(CStr("Critical hit!  You hit the " & MyBase.getTarget.name & " for " & dmg & " damage!  The enemy is stunned for 2 turns!"))
            MyBase.getTarget.takeDMG(dmg, MyBase.getCaster)
        Else
            'non critical hit
            dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, dmg + d6)
            Game.pushLstLog(CStr("You hit the " & MyBase.getTarget.name & " for " & dmg & " damage!"))
            Game.pushLblCombatEvent(CStr("You hit the " & MyBase.getTarget.name & " for " & dmg & " damage!  The enemy is stunned for 2 turns!"))
            MyBase.getTarget.takeDMG(dmg, MyBase.getCaster)
        End If

        MyBase.getTarget.isStunned = True
        MyBase.getTarget.stunct = 1
    End Sub
End Class
