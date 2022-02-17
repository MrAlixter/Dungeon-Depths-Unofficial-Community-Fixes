Public Class DragonsBreath
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Dragon's Breath")
        MyBase.settier(2)
        MyBase.setcost(6)
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = 68
        Dim d31 = Int(Rnd() * 6)
        Dim d32 = Int(Rnd() * 6)
        If d31 = d32 And d31 = 3 Then
            'critical hit
            dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, 1.75 * (dmg + d31 + d32))
            TextEvent.pushAndLog(CStr("Critical hit! You hit the " & MyBase.getTarget.name & " for " & dmg & " damage!"))
            MyBase.getTarget.takeDMG(dmg, MyBase.getCaster)
        Else
            'non critical hit
            dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, dmg + d31 + d32)
            TextEvent.pushAndLog(CStr("You hit the " & MyBase.getTarget.name & " for " & dmg & " damage!"))
            MyBase.getTarget.takeDMG(dmg, MyBase.getCaster)
        End If
    End Sub

    Public Overrides Function getcost() As Integer
        If Not getCaster() Is Nothing AndAlso (getCaster().formName.Contains("Dragon") Or getCaster().formName.Contains("Broodmother")) Then Return 0 Else Return 6
    End Function

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 2 spell that deals heavy magic damage with a low chance of missing altogether.  While it can still be used by non-dragons, it comes effortlessly to those with draconic blood."
    End Function
End Class
