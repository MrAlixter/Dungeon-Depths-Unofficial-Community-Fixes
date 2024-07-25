Public Class HitAndRun
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Hit and Run")
        MyBase.setUOC(False)
        MyBase.setcost(18)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget

        If Not p.equippedWeapon.GetType().IsSubclassOf(GetType(Dagger)) Then
            TextEvent.fpushAndLog("...but you don't have a dagger equipped.")

            p.stamina += getCost()
            Exit Sub
        End If

        Dim dmg As Integer = Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)
        dmg += (p.getATK + p.equippedWeapon.getABoost(p)) * 0.85
        dmg = Entity.calcDamage(dmg, m.defense)

        Dim dodge As Boolean = If(p.equippedWeapon.GetType().IsSubclassOf(GetType(Dagger)) Or p.passDieRoll(3), True, False)
        specHit(getName, dmg, getUser, getTarget, If(dodge, "  You prepare yourself to avoid the next oncoming attack!", ""))

        If dodge Then p.perks(perk.dodge) = 1
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A single quick attack, followed by the user preparing to dodge.  Dodge is guranteed if the user has a dagger.  Otherwise, dodge is a 1-in-3 chance."
    End Function
End Class
