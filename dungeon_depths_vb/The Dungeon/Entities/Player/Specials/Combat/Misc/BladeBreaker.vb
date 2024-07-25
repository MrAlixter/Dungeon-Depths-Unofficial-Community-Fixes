Public Class BladeBreaker
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Blade Breaker")
        MyBase.setUOC(False)
        MyBase.setcost(14)
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = Math.Max(MyBase.getUser.getATK - 15, 1)
        dmg = Entity.calcDamage(dmg, getTarget.defense)

        If 1 = 0 Then
            'critical hit
            Dim t_took_dmg = getTarget.takeDMG(dmg, getUser)
            getTarget.attack = Math.Max(1, MyBase.getTarget.attack * 0.69)

            If t_took_dmg And Not getTarget.isDead Then
                TextEvent.pushAndLog(CStr("Blade Breaker - Critical Hit!  You hit the " & MyBase.getTarget.name & " for " & dmg & " damage, greatly reducing their attack!"))
            ElseIf t_took_dmg Then
                TextEvent.push3rdLastLog(CStr("Blade Breaker - Critical Hit!  You hit the " & MyBase.getTarget.name & " for " & dmg & " damage, greatly reducing their attack!"))
            End If
        Else
            'non critical hit
            Dim t_took_dmg = getTarget.takeDMG(dmg, getUser)
            getTarget.attack = Math.Max(1, MyBase.getTarget.attack * 0.85)

            If t_took_dmg And Not getTarget.isDead Then
                TextEvent.pushAndLog(CStr("Blade Breaker!  You hit the " & MyBase.getTarget.name & " for " & dmg & " damage, reducing their attack!"))
            ElseIf t_took_dmg Then
                TextEvent.push3rdLastLog(CStr("Blade Breaker!  You hit the " & MyBase.getTarget.name & " for " & dmg & " damage, reducing their attack!"))
            End If
        End If
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Deals physical damage equal to the user's ATK - 15 and reduces the target's attack by 15 percent."
    End Function
End Class
