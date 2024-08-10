Public Class FieldOfThorns
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Field of Thorns")
        MyBase.settier(1)
        MyBase.setcost(6)

        can_be_reacted_to = False
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = 25
        Dim d12_1 = Int(Rnd() * 12)
        Dim d12_2 = Int(Rnd() * 12)

        dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, dmg + d12_1 + d12_2)
        getCaster.hit(dmg, getTarget, "", "prick")
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 1 offensive spell that deals a medium amount of magic damage.  It cannot be dodged or deflected."
    End Function
End Class
