Public Class CracklegSnare
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Crackleg Snare")
        MyBase.setUOC(False)
        MyBase.setcost(9)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget

        Dim dmg As Integer = Int(Rnd() * 4 + 1) + Int(Rnd() * 4 + 1) + Int(Rnd() * 4 + 1)
        dmg += (p.getATK) + (p.equippedWeapon.getABoost(p))
        dmg = Entity.calcDamage(dmg, m.defense) * 0.25

        specHit(getName, dmg, getUser, getTarget)

        If m.perks(npc_perk.stun) < 0 Then m.perks(npc_perk.stun) = 0
        m.perks(npc_perk.stun) += 1
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "An winding attack that deals 0.25x damage and stuns the opponent for 1 turn."
    End Function
End Class
