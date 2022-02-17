Public Class Hydrodart
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Hydrodart")
        MyBase.settier(1)
        MyBase.setcost(6)
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = 45 + Int(Rnd() * 3) + Int(Rnd() * 3)

        dmg *= (getCaster.getMana / getCaster.getMaxMana) / 0.66

        'non critical hit
        dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, dmg)
        TextEvent.pushAndLog(CStr("You hit the " & MyBase.getTarget.name & " for " & dmg & " damage!"))
        MyBase.getTarget.takeDMG(dmg, MyBase.getCaster)
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 1 offensive spell that deals a medium amount of magic damage.  The closer the mana of its caster is to full, the more damage is dealt."
    End Function
End Class
