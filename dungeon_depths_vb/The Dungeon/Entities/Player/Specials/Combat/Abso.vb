Public Class Abso
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Absorption")
        MyBase.setUOC(False)
        MyBase.setcost(-1)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget

        Dim dmg As Integer = p.getATK * 0.75
        Dim rcv As Integer = dmg * 2

        p.health = Math.Min(1, p.health + (rcv / p.getMaxHealth))

        TextEvent.pushAndLog("Absorption!  You hit " & getTarget.getNameWithTitle & " for " & dmg & " damage and heal yourself for " & rcv & " HP!")
        m.takeDMG(dmg, p)
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A weaker attack that ignores the opponent's defense and deals physical damage.  Restores health to its user equal to twice the damage dealt."
    End Function
End Class
