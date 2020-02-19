Public Class MesmericBloom
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        
        MyBase.settier(1)
        MyBase.setcost(7)

        MyBase.setName("Mesmeric Bloom")
        MyBase.setUOC(True)
    End Sub
    Public Overrides Sub effect()
        If Game.combatmode Then
            Polymorph.transform(MyBase.getTarget, "Amnesiac")

            Game.pushLstLog(CStr("You poof out a plume of pollen, hypnotizing " & MyBase.getTarget.title & " " & MyBase.getTarget.name & " for 3 turns!"))
            Game.pushLblCombatEvent(CStr("You poof out a plume of pollen, hypnotizing " & MyBase.getTarget.title & " " & MyBase.getTarget.name & " for 3 turns!"))
        Else
            backfire()
        End If
    End Sub
End Class
