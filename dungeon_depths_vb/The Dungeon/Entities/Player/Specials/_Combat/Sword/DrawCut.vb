Public Class DrawCut
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Draw Cut")
        MyBase.setUOC(False)
        MyBase.setcost(7)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget

        If Not p.equippedWeapon.GetType().IsSubclassOf(GetType(Sword)) Then
            TextEvent.fpushAndLog("...but you don't have a sword equipped.")

            p.stamina += getCost()
            Exit Sub
        End If

        Dim dmg As Integer = Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)
        dmg += (p.getATK) + (p.equippedWeapon.getABoost(p))
        dmg = Entity.calcDamage(dmg, m.defense) * 0.8

        specHit(getName, dmg, getUser, getTarget)

        If m.perks(npc_perk.bleed) < 0 Then m.perks(npc_perk.bleed) = 0
        m.perks(npc_perk.bleed) += 1 + Int(Rnd() * 2) + Int(Rnd() * 2)
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A sharp slicing attack that applies 1-3 turns of bleed damage to the opponent.  Cannot be used if a sword is not equipped."
    End Function
End Class
