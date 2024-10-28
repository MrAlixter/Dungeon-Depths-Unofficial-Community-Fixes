Public Class Lililash
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Lililash")
        MyBase.setUOC(False)
        MyBase.setcost(11)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget

        Dim dmg As Integer = Int(Rnd() * 4 + 1) + Int(Rnd() * 4 + 1) + Int(Rnd() * 4 + 1)
        dmg += (p.getATK) + (p.equippedWeapon.getABoost(p))
        dmg = Entity.calcDamage(dmg, m.defense * 0.95)

        specHit(getName, dmg, getUser, getTarget)

        m.perks(npc_perk.burn) += 5
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A sharp crack that cuts through a foes defenses, and engulfs them in evil flame."
    End Function
End Class
