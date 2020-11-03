Public Class GigaPunch
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Gigaton Punch")
        MyBase.setUOC(False)
        MyBase.setcost(99)
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = MyBase.getUser.getATK * 100
        Dim d31 = Int(Rnd() * 7)
        Dim d32 = Int(Rnd() * 7)
        If 1 = 0 Then
            'critical hit
        Else
            'non critical hit
            Game.pushLstLog(CStr("Gigaton Punch!  You hit the " & MyBase.getTarget.name & " for " & dmg + d31 + d32 & " damage!"))
            Game.pushLblCombatEvent(CStr("Gigaton Punch!  You hit the " & MyBase.getTarget.name & " for " & dmg + d31 + d32 & " damage!"))
            MyBase.getTarget.takeDMG(dmg + d31 + d32, MyBase.getUser)
        End If
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A titanic punch so fast and powerful that its shockwave alone can shatter stone and a direct hit deals ultimate magic damage."
    End Function
End Class
