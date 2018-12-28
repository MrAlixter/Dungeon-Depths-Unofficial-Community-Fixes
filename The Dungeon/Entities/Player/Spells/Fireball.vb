Public Class Fireball
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As Monster)
        MyBase.New(c, t)
        MyBase.setName("Fireball")
        MyBase.settier(1)
        MyBase.setcost(3)
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
            Game.lstLog.Items.Add(CStr("You hit the " & MyBase.getTarget.name & " for " & dmg + d31 + d32 & " damage!"))
            Game.pushLblCombatEvent(CStr("You hit the " & MyBase.getTarget.name & " for " & dmg + d31 + d32 & " damage!"))
            Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        End If
    End Sub
End Class
