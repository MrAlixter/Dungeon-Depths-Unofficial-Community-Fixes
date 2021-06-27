Public Class FlashStrike
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Flash Strike")
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
            Game.pushLogAndEvent(CStr("Flash Strike - Critical Hit!  You hit the " & m.name & " for " & dmg & " damage!"))
            MyBase.getTarget.takeDMG(dmg, p)
        Else
            'non critical hit
            dmg = Entity.calcDamage(dmg, m.getDEF)
            Game.pushLogAndEvent(CStr("Flash Strike!  You hit the " & m.name & " for " & dmg & " damage!"))
            MyBase.getTarget.takeDMG(dmg, p)
        End If
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A light and fast attack that is guaranteed to hit first."
    End Function
End Class
