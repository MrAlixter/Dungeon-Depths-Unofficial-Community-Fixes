Public Class BurningPunch
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Megaton Punch")
        MyBase.setUOC(False)
        MyBase.setcost(9)
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = MyBase.getUser.getATK + 20
        Dim d31 = Int(Rnd() * 6)
        Dim d32 = Int(Rnd() * 6)
        If 1 = 0 Then
            'critical hit
        Else
            'non critical hit
            MyBase.getTarget.takeDMG(dmg + d31 + d32, MyBase.getUser)
            Game.pushLstLog(CStr("Megaton Punch!  You hit the " & MyBase.getTarget.name & " for " & dmg + d31 + d32 & " damage!"))
            Game.pushLblCombatEvent(CStr("Megaton Punch!  You hit the " & MyBase.getTarget.name & " for " & dmg + d31 + d32 & " damage!"))
        End If
    End Sub
End Class
