Public Class OptimalChop
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Optimal Chop")
        MyBase.setUOC(False)
        MyBase.setcost(6)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget

        If Not p.equippedWeapon.GetType().IsSubclassOf(GetType(Axe)) Then
            TextEvent.fpushAndLog("...but you don't have an axe equipped.")

            p.stamina += getCost()
            Exit Sub
        End If

        Dim dmg As Integer = 12
        dmg += (p.getATK) + (p.equippedWeapon.getABoost(p))
        dmg = Entity.calcDamage(dmg, getTarget.defense)

        specHit(getName, dmg, getUser, getTarget)
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Always deals maximum damage for an axe.  Cannot miss, cannot critically hit, and cannot be used without an axe."
    End Function
End Class
