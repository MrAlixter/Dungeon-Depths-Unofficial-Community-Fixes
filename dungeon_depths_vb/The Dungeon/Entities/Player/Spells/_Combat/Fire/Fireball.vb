Public Class Fireball
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Fireball")
        MyBase.settier(1)
        MyBase.setcost(4)
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = 40
        Dim d31 = Int(Rnd() * 3)
        Dim d32 = Int(Rnd() * 3)
        If 1 = 0 Then
            'critical hit
        Else
            'non critical hit
            dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, dmg + d31 + d32)
            getCaster.hit(dmg, getTarget, "", "burn")
        End If
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 1 offensive spell that deals a medium amount of magic damage."
    End Function
End Class
