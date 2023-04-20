Public Class Smite
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Smite")
        MyBase.settier(1)
        MyBase.setcost(4)
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = 30
        Dim d31 = Int(Rnd() * 3)
        Dim d32 = Int(Rnd() * 3)
        If MyBase.getTarget.GetType Is GetType(ESuccubus) Or MyBase.getTarget.GetType.IsSubclassOf(GetType(ESuccubus)) Or MyBase.getTarget.GetType Is GetType(EnthDem) Then
            'critical hit
            dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, dmg + d31 + d32) * 4
            getCaster.hit(dmg, getTarget, "  Critical Hit!", "shock")
        Else
            'non critical hit
            dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, dmg + d31 + d32)
            getCaster.hit(dmg, getTarget, "", "zap")
        End If
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 1 offensive spell that deals a medium amount of magic damage.  Guaranteed to hit critically against demons and the undead."
    End Function
End Class
