Public Class TentacleCrushcannon
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Tentacle Crushcannon")
        MyBase.settier(2)
        MyBase.setcost(8)
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = 20

        For i = 0 To getCaster.getLust \ 10
            dmg += 9 + Int(Rnd() * 3)
        Next

        'non critical hit
        dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, dmg)

        MyBase.getCaster.addLust(5)

        TextEvent.pushAndLog(CStr("You summon " & ((getCaster.getLust \ 10) + 1) & " tentacles and hit the " & MyBase.getTarget.name & " for " & dmg & " damage!"))

        MyBase.getTarget.takeDMG(dmg, MyBase.getCaster)
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 2 offensive spell that deals an amount of magic damage scaled to its caster's lust with a low chance of missing altogether."
    End Function
End Class
