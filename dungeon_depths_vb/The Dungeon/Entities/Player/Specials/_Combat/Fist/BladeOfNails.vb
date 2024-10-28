Public Class BladeOfNails
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Blade of Nails")
        MyBase.setUOC(False)
        MyBase.setcost(25)
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = (getUser.getATKWithoutWeapon) * 2.0
        Dim d31 = Int(Rnd() * 7)
        Dim d32 = Int(Rnd() * 7)

        dmg = Entity.calcDamage(dmg, getTarget.defense)

        specHit(getName, dmg + d31 + d32, getUser, getTarget)
        getTarget.perks(npc_perk.bleed) += 3
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "An infernal slash made with the user's bare hand.  It deals bleed damage, and does not factoer in its user's weapon."
    End Function
End Class
