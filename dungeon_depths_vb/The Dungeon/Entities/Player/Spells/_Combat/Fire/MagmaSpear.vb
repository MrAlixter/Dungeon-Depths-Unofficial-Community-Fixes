Public Class MagmaSpear
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Magma Spear")
        MyBase.settier(1)
        MyBase.setcost(14)
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = 85
        Dim d51 = Int(Rnd() * 10)
        Dim d52 = Int(Rnd() * 10)
        If d51 = d52 And d52 = 2 Then
            'critical hit
            dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, 2 * (dmg + d51 + d52))
            getCaster.hit(dmg, getTarget, "  Critical hit!", "burn")
        Else
            'non critical hit
            dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, dmg + d51 + d52)
            getCaster.hit(dmg, getTarget, "", "burn")
        End If
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 1 offensive spell that deals a huge amount of magic damage."
    End Function
End Class
