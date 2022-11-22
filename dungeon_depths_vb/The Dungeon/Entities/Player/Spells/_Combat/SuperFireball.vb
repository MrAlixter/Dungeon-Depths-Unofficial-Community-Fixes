Public Class SuperFireball
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Super Fireball")
        MyBase.settier(3)
        MyBase.setcost(8)
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = 60
        Dim d51 = Int(Rnd() * 6)
        Dim d52 = Int(Rnd() * 6)
        If d51 = d52 And d52 = 2 Then
            'critical hit
            dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, 2 * (dmg + d51 + d52))
            TextEvent.pushAndLog(CStr("Critical hit!  You hit the " & MyBase.getTarget.name & " for " & dmg & " damage!"))
            MyBase.getTarget.takeDMG(dmg, MyBase.getCaster)
        Else
            'non critical hit
            dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, dmg + d51 + d52)
            TextEvent.pushAndLog(CStr("You hit the " & MyBase.getTarget.name & " for " & dmg & " damage!"))
            MyBase.getTarget.takeDMG(dmg, MyBase.getCaster)
        End If
    End Sub
    Public Overrides Sub backfire()
        Dim dmg = Int(Rnd() * 30) + 10
        MyBase.getCaster.takeDMG(dmg, Nothing)
        TextEvent.pushAndLog("You hit yourself for " & dmg & " damage!")
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 3 offensive spell that deals heavy magic damage with a low chance of backfiring or missing altogether."
    End Function
End Class
