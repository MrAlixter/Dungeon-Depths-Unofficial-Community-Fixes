Public Class GrogBlossom
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Grog Blossom")
        MyBase.setUOC(True)
        MyBase.settier(1)
        MyBase.setcost(9)
    End Sub
    Public Overrides Sub effect()
        Dim sdif = Math.Min(100 - MyBase.getCaster.stamina, 35)
        Dim ldif = Math.Max(MyBase.getCaster.getLust, 25)

        MyBase.getCaster.stamina += sdif
        MyBase.getCaster.addLust(ldif)

        TextEvent.pushAndLog("You restore your stamina by " & sdif & " and your lust by " & ldif & "!")
    End Sub


    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 1 spell that restores its caster's stamina while raising their lust.  Its effect can be stacked if used repeatedly."
    End Function
End Class
