Public Class HelixSlash
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Helix Slash")
        MyBase.setUOC(False)
        MyBase.setcost(25)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget

        Dim dmg As Integer = p.getATK * 2.0
        dmg = Entity.calcDamage(dmg, getTarget.defense)

        Dim rcv As Integer = (dmg / 4) / p.getMaxHealth

        p.health += rcv

        Dim t_took_dmg = m.takeDMG(dmg, p)

        If t_took_dmg And Not m.isDead Then
            TextEvent.pushLog("Helix Slash!  Your sword slashes your opponent, dealing " & dmg & " damage and healing you for " & rcv * p.getMaxHealth & " health!")
            TextEvent.push("Helix Slash!" & DDUtils.RNRN & "You fly up into the air, the edge of your blade burning white hot.  Before your opponent can even react, you dart at them in a supersonic spiral.  Your firey sword cleaves clean through your opponent, dealing " & dmg & " damage, and heals you for " & rcv * p.getMaxHealth & " health between blows.")
        ElseIf t_took_dmg Then
            TextEvent.push3rdLastLog(CStr("Helix Slash!  Your sword slashes your opponent, dealing " & dmg & " damage and healing you for " & rcv * p.getMaxHealth & " health!"))
        End If
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Deals physical damage equal to 200% of the user's ATK and restores health to the user equal to 1/4th of the damage dealt."
    End Function
End Class
