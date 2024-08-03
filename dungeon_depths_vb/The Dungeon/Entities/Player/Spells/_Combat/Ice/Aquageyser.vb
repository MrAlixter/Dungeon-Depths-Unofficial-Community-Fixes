Public Class Aquageyser
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Aquageyser")
        MyBase.settier(2)
        MyBase.setcost(12)
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = 89 + Int(Rnd() * 3) + Int(Rnd() * 3)

        dmg *= (getCaster.getMana / getCaster.getMaxMana) / 0.66

        'non critical hit
        dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, dmg)
        getCaster.hit(dmg, getTarget)
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 2 offensive spell that deals a heavy amount of magic damage.  The closer the mana of its caster is to full, the more damage is dealt."
    End Function
End Class
