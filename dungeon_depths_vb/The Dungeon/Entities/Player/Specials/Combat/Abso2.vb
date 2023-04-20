Public Class Abso2
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Absorption II")
        MyBase.setUOC(False)
        MyBase.setcost(11)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget

        Dim dmg As Integer = Entity.calcDamage(p.getATK * 1.25, m.getDEF)
        Dim rcv As Integer = dmg

        p.health = Math.Min(1, p.health + (rcv / p.getMaxHealth))

        Dim t_took_dmg = m.takeDMG(dmg, p)

        If t_took_dmg And Not m.isDead Then
            TextEvent.pushAndLog(CStr("Absorption II!  You hit " & getTarget.getNameWithTitle & " for " & dmg & " damage and heal yourself for " & rcv & " HP!"))
        ElseIf t_took_dmg Then
            TextEvent.push3rdLastLog(CStr("Absorption II!  You hit " & getTarget.getNameWithTitle & " for " & dmg & " damage and heal yourself for " & rcv & " HP!"))
        End If
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "An attack that restores health to its user equal to the damage dealt."
    End Function
End Class
