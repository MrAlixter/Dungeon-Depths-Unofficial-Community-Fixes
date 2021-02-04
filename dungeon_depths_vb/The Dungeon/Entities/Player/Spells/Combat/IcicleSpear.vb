Public Class IcicleSpear
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        MyBase.setName("Icicle Spear")
        MyBase.settier(2)
        MyBase.setcost(5)
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = 52
        Dim d6 = Int(Rnd() * 6)
        If d6 = 2 Or d6 = 3 Then
            'critical hit
            dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, 2 * (dmg + d6))
            Game.pushLogAndEvent(CStr("Critical hit!  You hit the " & MyBase.getTarget.name & " for " & dmg & " damage!"))
            MyBase.getTarget.takeDMG(dmg, MyBase.getCaster)
        Else
            'non critical hit
            dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, dmg + d6)
            Game.pushLogAndEvent(CStr("You hit the " & MyBase.getTarget.name & " for " & dmg & " damage!"))
            MyBase.getTarget.takeDMG(dmg, MyBase.getCaster)
        End If
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 1 offensive spell that deals a medium amount of magic damage, with a higher chance to hit critically."
    End Function
End Class
