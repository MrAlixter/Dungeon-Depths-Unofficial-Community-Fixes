Public Class CynnsBraid
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)

        setName("Cynn's Braid")

        can_be_reacted_to = False

        settier(1)
        setcost(8)
    End Sub
    Public Overrides Sub effect()
        '| - First Hit - |
        If caster.passDieRoll(10, 9) And getTarget.reactToSpell(name) Then
            Dim dmg1 As Integer = 35 + Int(Rnd() * 3)
            dmg1 = Entity.calcDamage(dmg1 + (Math.Max(getCaster.getLust - 10, -10)), getTarget.getWIL)
            lReduction = getCaster.getLust / 2

            getCaster.addLust(-lReduction)
            getCaster.hit(dmg1, getTarget, If(lReduction > 0, "  -" & lReduction & " Lust.", ""), "burn")
        Else
            TextEvent.fpushAndLog("The first fireball fizzles into nothing!")
        End If

        '| - Second Hit - |
        If MyBase.getTarget.isDead Then Exit Sub

        Dim dmg2 As Integer = 40 + Int(Rnd() * 3) + Int(Rnd() * 3)
        dmg2 = Entity.calcDamage(dmg2 + (Math.Max(getCaster.getLust - 10, -10)), getTarget.getWIL)
        lReduction = getCaster.getLust / 2

        getCaster.addLust(-lReduction)
        getCaster.hit(dmg2, getTarget, If(lReduction > 0, "  -" & lReduction & " Lust.", ""), "burn")
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 2 spell, woven into a tier 1 spell.  Each deals medium magic damage; with the first hit having a medium chance of missing, and the second having no chance to miss.  Increases in power based on its caster's lust rather than their will."
    End Function
End Class
