Public Class USed
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Charm")
        MyBase.setUOC(True)
        MyBase.setcost(-1)
    End Sub
    Public Overrides Sub effect()
        If Game.combatmode Then
            MyBase.getTarget.isStunned = True
            MyBase.getTarget.stunct = 2
            Game.pushLogAndEvent("Charm!  " & Trim(getTarget.title & " " & getTarget.getName) & " is stunned for 3 turns.")
        Else
            getUser.addLust(15)

            Game.pushLogAndEvent("Charm!  +15 Lust")
        End If
    End Sub

    Public Overrides Function getCost() As Integer
        If Game.combatmode Then Return -1 Else Return 10
    End Function

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Stuns its target for 3 turns.  Can be used outside combat to raise its user's lust."
    End Function
End Class
