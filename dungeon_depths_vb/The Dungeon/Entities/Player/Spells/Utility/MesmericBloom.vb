Public Class MesmericBloom
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        
        MyBase.settier(1)
        MyBase.setcost(7)

        MyBase.setName("Mesmeric Bloom")
        MyBase.setUOC(False)
    End Sub
    Public Overrides Sub effect()
        If Game.combatmode Then
            Polymorph.transform(MyBase.getTarget, "Amnesiac")

            Game.pushLogAndEvent(CStr("You poof out a plume of pollen, hypnotizing " & MyBase.getTarget.title & " " & MyBase.getTarget.name & " for 3 turns!"))
        Else
            backfire()
        End If
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 1 spell that disorients its target for 3 turns."
    End Function
End Class
