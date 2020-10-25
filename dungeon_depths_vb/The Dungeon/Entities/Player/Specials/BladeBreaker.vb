Public Class BladeBreaker
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Blade Breaker")
        MyBase.setUOC(False)
        MyBase.setcost(14)
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = Math.Max(MyBase.getUser.getATK - 15, 1)
       
        If 1 = 0 Then
            'critical hit
            Game.pushLstLog(CStr("Blade Breaker - Critical Hit!  You hit the " & MyBase.getTarget.name & " for " & dmg & " damage, greatly reducing their attack!"))
            Game.pushLblCombatEvent(CStr("Blade Breaker - Critical Hit!  You hit the " & MyBase.getTarget.name & " for " & dmg & " damage, greatly reducing their attack!"))
            MyBase.getTarget.takeDMG(dmg, MyBase.getUser)
            MyBase.getTarget.attack = Math.Max(1, MyBase.getTarget.attack * 0.69)
        Else
            'non critical hit
            Game.pushLstLog(CStr("Blade Breaker!  You hit the " & MyBase.getTarget.name & " for " & dmg & " damage, reducing their attack!"))
            Game.pushLblCombatEvent(CStr("Blade Breaker!  You hit the " & MyBase.getTarget.name & " for " & dmg & " damage, reducing their attack!"))
            MyBase.getTarget.takeDMG(dmg, MyBase.getUser)
            MyBase.getTarget.attack = Math.Max(1, MyBase.getTarget.attack * 0.85)
        End If
    End Sub
End Class
