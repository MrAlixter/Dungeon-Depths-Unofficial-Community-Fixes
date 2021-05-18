Public Class Abso
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Absorbtion")
        MyBase.setUOC(False)
        MyBase.setcost(-1)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget

        Dim dmg As Integer = p.attack * 0.75
        Dim rcv As Integer = dmg * 2

        p.health = Math.Min(1, p.health + (rcv / p.getMaxHealth))

        Game.pushLogAndEvent("Absorbtion!" & vbCrLf & "Deals " & dmg & " damage and heals you for " & rcv)
        m.takeDMG(dmg, p)
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A weaker attack that ignores equipment, class, and form buffs to deal physical damage.  Restores health to its user equal to twice the damage dealt."
    End Function
End Class
