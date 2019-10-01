Public Class DragonsBreath
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        MyBase.setName("Dragon's Breath")
        MyBase.settier(2)
        If Not c Is Nothing AndAlso c.pForm.name.Equals("Dragon") Then MyBase.setcost(0) Else MyBase.setcost(6)
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = 68
        Dim d31 = Int(Rnd() * 6)
        Dim d32 = Int(Rnd() * 6)
        If d31 = d32 And d31 = 3 Then
            'critical hit
            MyBase.getTarget.takeDMG(1.75 * (dmg + d31 + d32), MyBase.getCaster)
            Game.pushLstLog(CStr("Critical hit! You hit the " & MyBase.getTarget.name & " for " & 1.75 * (dmg + d31 + d32) & " damage!"))
            Game.pushLblCombatEvent(CStr("Critical hit! You hit the " & MyBase.getTarget.name & " for " & 1.75 * (dmg + d31 + d32) & " damage!"))
            
        Else
            'non critical hit
            MyBase.getTarget.takeDMG(dmg + d31 + d32, MyBase.getCaster)
            Game.pushLstLog(CStr("You hit the " & MyBase.getTarget.name & " for " & dmg + d31 + d32 & " damage!"))
            Game.pushLblCombatEvent(CStr("You hit the " & MyBase.getTarget.name & " for " & dmg + d31 + d32 & " damage!"))
            
        End If
    End Sub
End Class
