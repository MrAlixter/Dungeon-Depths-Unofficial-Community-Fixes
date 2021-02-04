Public Class MagmaSpear
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        MyBase.setName("Magma Spear")
        MyBase.settier(1)
        MyBase.setcost(22)
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = 85
        Dim d51 = Int(Rnd() * 10)
        Dim d52 = Int(Rnd() * 10)
        If d51 = d52 And d52 = 2 Then
            'critical hit
            dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, 2 * (dmg + d51 + d52))
            Game.pushLogAndEvent(CStr("Critical hit!  You hit the " & MyBase.getTarget.name & " for " & dmg & " damage!"))
            MyBase.getTarget.takeDMG(dmg, MyBase.getCaster)
        Else
            'non critical hit
            dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, dmg + d51 + d52)
            Game.pushLogAndEvent(CStr("You hit the " & MyBase.getTarget.name & " for " & dmg & " damage!"))
            MyBase.getTarget.takeDMG(dmg, MyBase.getCaster)
        End If
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 1 offensive spell that deals a huge amount of magic damage."
    End Function
End Class
