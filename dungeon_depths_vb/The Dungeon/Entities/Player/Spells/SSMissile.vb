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
            MyBase.getTarget.takeDMG(2 * (dmg + d6), MyBase.getCaster)
            Game.pushLstLog(CStr("Critical hit!  You hit the " & MyBase.getTarget.name & " for " & 2 * (dmg + d6) & " damage!"))
            Game.pushLblCombatEvent(CStr("Critical hit!  You hit the " & MyBase.getTarget.name & " for " & 2 * (dmg + d6) & " damage!  The enemy is stunned for 2 turns!"))

        Else
            'non critical hit
            MyBase.getTarget.takeDMG(dmg + d6, MyBase.getCaster)
            Game.pushLstLog(CStr("You hit the " & MyBase.getTarget.name & " for " & dmg + d6 & " damage!"))
            Game.pushLblCombatEvent(CStr("You hit the " & MyBase.getTarget.name & " for " & dmg + d6 & " damage!  The enemy is stunned for 2 turns!"))
        End If

        MyBase.getTarget.isStunned = True
        MyBase.getTarget.stunct = 1
    End Sub
End Class
