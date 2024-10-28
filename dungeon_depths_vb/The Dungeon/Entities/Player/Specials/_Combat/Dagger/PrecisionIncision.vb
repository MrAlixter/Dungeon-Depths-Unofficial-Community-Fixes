Public Class PrecisionIncision
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Precision Incision")
        MyBase.setUOC(False)
        MyBase.setcost(13)
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
        dmg += (p.getATK + p.equippedWeapon.getABoost(p)) * 2.5
        dmg = Entity.calcDamage(dmg, m.defense)

        specHit(getName, dmg, getUser, getTarget)
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Combines both hits of a dagger into a single targeted blow.  Cannot be used without a dagger."
    End Function
End Class
