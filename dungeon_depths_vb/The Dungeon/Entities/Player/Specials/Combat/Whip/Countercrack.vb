Public Class Countercrack
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Countercrack")
        MyBase.setUOC(False)
        MyBase.setcost(12)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget

        Dim dmg As Integer = Int(Rnd() * 4 + 1) + Int(Rnd() * 4 + 1) + Int(Rnd() * 4 + 1)
        dmg += (p.getATK) + (p.equippedWeapon.getABoost(p))
        dmg = Entity.calcDamage(dmg, 0) * 1.25

        specHit(getName, dmg, getUser, getTarget, "  Critical hit!")
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A loud slashing attack that always hits last... and always hits critical."
    End Function
End Class
