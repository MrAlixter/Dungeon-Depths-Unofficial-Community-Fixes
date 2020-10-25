Public Class FlashStrike
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Flash Strike")
        MyBase.setUOC(False)
        MyBase.setcost(17)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget

        Dim dmg As Integer = p.getATK * ((Rnd() * 0.1) + 0.7)

        If Int(Rnd() * 6) = 0 Then
            'critical hit
            dmg = Entity.calcDamage((dmg) * 2, m.getDEF)
            Game.pushLstLog(CStr("Flash Strike - Critical Hit!  You hit the " & m.name & " for " & dmg & " damage!"))
            Game.pushLblCombatEvent(CStr("Flash Strike - Critical Hit!  You hit the " & m.name & " for " & dmg & " damage!"))
            MyBase.getTarget.takeDMG(dmg, p)
        Else
            'non critical hit
            dmg = Entity.calcDamage(dmg, m.getDEF)
            Game.pushLstLog(CStr("Flash Strike!  You hit the " & m.name & " for " & dmg & " damage!"))
            Game.pushLblCombatEvent(CStr("Flash Strike!  You hit the " & m.name & " for " & dmg & " damage!"))
            MyBase.getTarget.takeDMG(dmg, p)
        End If
    End Sub
End Class
