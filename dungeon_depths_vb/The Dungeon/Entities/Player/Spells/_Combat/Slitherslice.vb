Public Class Slitherslice
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Slitherslice")
        settier(3)
        setcost(4)
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = 80
        Dim d51 = Int(Rnd() * 4)
        Dim d52 = Int(Rnd() * 4)
        If d51 = d52 And d52 = 2 Then
            'critical hit
            dmg = getCaster.getSpellDamage(getTarget, 2 * (dmg + d51 + d52))
            getCaster.hit(dmg, getTarget, "  Critical hit!", "cut")
        Else
            'non critical hit
            dmg = getCaster.getSpellDamage(getTarget, dmg + d51 + d52)
            If getTarget.getHealth > 0.1 Then dmg = Math.Min(dmg, getTarget.getIntHealth - 1)
            getCaster.hit(dmg, getTarget, "cut")
        End If
    End Sub
    Public Overrides Sub backfire()
        TextEvent.pushAndLog("You try to cast " & name & ", but it fizzles into nothing!")
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 3 offensive spell that deals heavy magic damage with a medium chance of missing altogether."
    End Function
End Class
