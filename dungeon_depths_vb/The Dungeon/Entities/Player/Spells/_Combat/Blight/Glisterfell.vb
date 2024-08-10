Public Class Glisterfell
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Glisterfell")
        MyBase.settier(1)
        MyBase.setcost(5)

        can_be_reacted_to = False
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = 40

        getTarget.perks(npc_perk.poison) += 2
        dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, dmg)
        getCaster.hit(dmg, getTarget, "", "zap")
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 1 offensive spell that deals a medium amount of magic damage.  It cannot be dodged or deflected."
    End Function
End Class
