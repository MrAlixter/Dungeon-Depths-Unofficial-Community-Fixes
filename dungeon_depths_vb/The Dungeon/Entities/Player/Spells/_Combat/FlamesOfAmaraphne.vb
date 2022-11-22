Public Class FlamesOfAmaraphne
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Flames of Amaraphne")
        MyBase.settier(1)
        MyBase.setcost(1)
    End Sub
    Public Overrides Sub effect()
        Dim d31 = Int(Rnd() * 3)
        Dim d32 = Int(Rnd() * 3)
        If 1 = 0 Then
            'critical hit
        Else
            'non critical hit
            dmg = Entity.calcDamage(getCaster.getLust + d31 + d32 + (Math.Max(getCaster.getWIL - 5, -5)), (getTarget.getDEF + getTarget.getWIL) / 2)

            getCaster.addLust(-getCaster.getLust / 2)

            TextEvent.pushAndLog(CStr("You burn the " & MyBase.getTarget.name & " for " & dmg & " damage!"))

            MyBase.getTarget.takeDMG(dmg, MyBase.getCaster)
        End If
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 1 offensive spell that uses one's lust to fuel a magic attack."
    End Function
End Class
