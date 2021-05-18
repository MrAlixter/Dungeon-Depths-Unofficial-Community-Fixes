Public Class UvonasFugue
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        If Not c Is Nothing AndAlso c.equippedAcce.getName.Equals("Ring_of_Uvona") Then
            MyBase.settier(3)
            MyBase.setcost(11)
        Else
            MyBase.settier(5)
            MyBase.setcost(24)
        End If
        setName("Uvona's Fugue")
        MyBase.setUOC(True)
    End Sub
    Public Overrides Sub effect()
        If Game.combatmode Then
            Polymorph.transform(MyBase.getTarget, "Amnesiac")

            Game.pushLogAndEvent(CStr("You wipe " & MyBase.getTarget.title & " " & MyBase.getTarget.name & "'s mind for 5 turns!"))
        Else
            backfire()
        End If
    End Sub
    Public Overrides Sub backfire()
        Polymorph.transform(MyBase.getCaster, "Mindless")
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 5 spell that wipes its target's mind for 5 turns with a medium chance of backfiring or missing altogether.  Wearing a ring of Uvona decreases the tier of the spell, lowering its cost and failure rate."
    End Function
End Class
