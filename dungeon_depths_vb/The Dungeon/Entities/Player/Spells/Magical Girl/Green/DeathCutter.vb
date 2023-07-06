Public Class DeathCutter
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Death Cutter")
        settier(5)
        setcost(9)
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = 200
        Dim d51 = Int(Rnd() * 4)
        Dim d52 = Int(Rnd() * 4)
        If d51 = d52 And d52 = 2 Then
            'critical hit
            dmg = getCaster.getSpellDamage(getTarget, 2 * (dmg + d51 + d52))
            TextEvent.pushAndLog(CStr("Critical hit!  You hit the " & getTarget.name & " for " & dmg & " damage!"))
            getTarget.takeDMG(dmg, getCaster)
        Else
            'non critical hit
            dmg = getCaster.getSpellDamage(getTarget, dmg + d51 + d52)
            If getTarget.getHealth > 0.1 Then dmg = Math.Min(dmg, getTarget.getIntHealth - 1)
            TextEvent.pushAndLog(CStr("You hit the " & getTarget.name & " for " & dmg & " damage!"))
            getTarget.takeDMG(dmg, getCaster)
        End If
    End Sub
    Public Overrides Sub backfire()
        TextEvent.pushAndLog("The blade whizzes past your foe, leaving them stunned for 1 turn!")
        getTarget.perks(npc_perk.stun) = 0
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 5 offensive spell that deals extreme magic damage with a medium chance of nearly missing the target, and a medium chance of missing altogether."
    End Function
End Class
