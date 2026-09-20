Public Class HeavyBlow
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Heavy Blow")
        MyBase.setUOC(False)
        MyBase.setcost(24)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget

        Dim targetSpeed As Integer = m.getSPD
        Dim spdBuff = targetSpeed - p.getSPD
        If spdBuff < 0 Then spdBuff = 0

        Dim dmg As Integer = p.getATK

        If targetSpeed <> 0 Then
            dmg = p.getATK + (p.getATK * (spdBuff / targetSpeed))
        End If
        dmg = Entity.calcDamage(dmg, m.defense)

        specHit(getName, dmg, getUser, getTarget)

        If Not m.perks(npc_perk.stun) < 0 Then
            m.perks(npc_perk.stun) = 0
        End If
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Deals variable physical damage to its target.  More damage is dealt the slower the user is compared to their target."
    End Function
End Class
