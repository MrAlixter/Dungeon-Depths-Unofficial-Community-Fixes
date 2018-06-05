Public Class DragonsBreath
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As Monster)
        MyBase.New(c, t)
        MyBase.setName("Dragon's Breath")
        MyBase.settier(6)
        MyBase.setcost(2)
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = 68
        Dim d31 = Int(Rnd() * 6)
        Dim d32 = Int(Rnd() * 6)
        If d31 = d32 And d31 = 3 Then
            'critical hit
            MyBase.getTarget.takeDMG(1.75 * (dmg + d31 + d32))
            Game.lstLog.Items.Add(CStr("Critical hit! You hit the " & MyBase.getTarget.name & " for " & 1.75 * (dmg + d31 + d32) & " damage!"))
            Game.pushLblCombatEvent(CStr("Critical hit! You hit the " & MyBase.getTarget.name & " for " & 1.75 * (dmg + d31 + d32) & " damage!"))
            Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        Else
            'non critical hit
            MyBase.getTarget.takeDMG(dmg + d31 + d32)
            Game.lstLog.Items.Add(CStr("You hit the " & MyBase.getTarget.name & " for " & dmg + d31 + d32 & " damage!"))
            Game.pushLblCombatEvent(CStr("You hit the " & MyBase.getTarget.name & " for " & dmg + d31 + d32 & " damage!"))
            Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        End If
    End Sub
End Class
