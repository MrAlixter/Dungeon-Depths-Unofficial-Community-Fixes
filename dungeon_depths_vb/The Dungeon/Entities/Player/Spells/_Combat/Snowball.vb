Public Class Snowball
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Snowball")
        MyBase.settier(1)
        MyBase.setcost(0)
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = 10
        Dim d31 = Int(Rnd() * 3)
        Dim d32 = Int(Rnd() * 3)

        If MyBase.getTarget.isStunned = True Then
            '"critical" hit
            dmg *= MyBase.getTarget.stunct + 2
            dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, dmg + d31 + d32)
            getCaster.hit(dmg, getTarget, "  Oof, what a throw!")
        Else
            'non critical hit
            dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, dmg + d31 + d32)
            'should target be stunned?
            If Int(Rnd() * 2) = 0 Then
                MyBase.getTarget.isStunned = True
                MyBase.getTarget.stunct = 3
                getCaster.hit(dmg, getTarget, "  They are stunned by the spell!")
            Else
                getCaster.hit(dmg, getTarget)
            End If
        End If
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 1 offensive spell that deals light magic damage with a high chance to stun the target.  If the target is already stunned, damage is massively increased by the number of stunned turns remaining."
    End Function
End Class
