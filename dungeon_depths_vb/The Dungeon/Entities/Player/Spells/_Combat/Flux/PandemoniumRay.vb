Public Class PandemoniumRay
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Pandemonium Ray")
        MyBase.settier(1)
        MyBase.setcost(12)
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = 30
        Dim d10p6 = Int(Rnd() * 10) + 6

        If getCaster.perks(perk.polymorphed) > 0 Then dmg *= 2
        If getTarget.perks(npc_perk.tfdur) > 0 Then dmg *= 2

        'non critical hit
        dmg = getCaster.getSpellDamage(MyBase.getTarget, dmg + d10p6)
        getCaster.hit(dmg, getTarget, "", "zap")
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 1 offensive spell that deals a medium amount of magic damage.  Damage is doubled if the caster is under the effect of a polymorph.  Damage is doubled if the target is under the effect of a polymorph."
    End Function
End Class
