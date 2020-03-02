Public Class HBSC
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        MyBase.setName("Heartblast Starcannon")
        MyBase.settier(2)
        MyBase.setcost(5)
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = 55
        Dim d51 = Int(Rnd() * 4)
        Dim d52 = Int(Rnd() * 4)
        If d51 = d52 And d52 = 2 Then
            'critical hit
            MyBase.getTarget.takeDMG(2 * (dmg + d51 + d52), MyBase.getCaster)
            Game.pushLstLog(CStr("Critical hit!  You hit the " & MyBase.getTarget.name & " for " & 2 * (dmg + d51 + d52) & " damage!"))
            Game.pushLblCombatEvent(CStr("Critical hit!  You hit the " & MyBase.getTarget.name & " for " & 2 * (dmg + d51 + d52) & " damage!"))
            
        Else
            'non critical hit
            MyBase.getTarget.takeDMG(dmg + d51 + d52, MyBase.getCaster)
            Game.pushLstLog(CStr("You hit the " & MyBase.getTarget.name & " for " & dmg + d51 + d52 & " damage!"))
            Game.pushLblCombatEvent(CStr("You hit the " & MyBase.getTarget.name & " for " & dmg + d51 + d52 & " damage!"))
            
        End If
    End Sub
End Class
