Public Class UvonasFugue
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        If c.equippedAcce.getName.Equals("Ring_of_Uvona") Then
            MyBase.settier(3)
            MyBase.setcost(11)
        Else
            MyBase.settier(5)
            MyBase.setcost(24)
        End If
        MyBase.setName("Uvona's Fugue")
        MyBase.setUOC(True)
    End Sub
    Public Overrides Sub effect()
        If Game.combatmode Then
            Polymorph.transform(MyBase.getTarget, "Amnesiac")

            Game.pushLstLog(CStr("You wipe " & MyBase.getTarget.title & " " & MyBase.getTarget.name & "'s mind for 5 turns!"))
            Game.pushLblCombatEvent(CStr("You wipe " & MyBase.getTarget.title & " " & MyBase.getTarget.name & "'s mind for 5 turns!"))
        Else
            backfire()
        End If
    End Sub
    Public Overrides Sub backfire()
        Polymorph.transform(MyBase.getCaster, "Mindless")
    End Sub
End Class
