Public Class GuardUp
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Guard Up")
        MyBase.setUOC(False)
        MyBase.setcost(10)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser

        If p.perks(perk.guardup) = -1 Then
            p.perks(perk.guardup) = 3
        Else
            p.perks(perk.guardup) += 3
        End If

        p.dBuff = p.dBuff + ((p.getDEF - p.dBuff) * 0.4)

        TextEvent.pushLog("Guard Up!")
        TextEvent.pushCombat("Guard Up!" & vbCrLf & "+40% DEF for 3 turns.")
    End Sub

    Public Overrides Function getCost() As Integer
        Dim turnsLeft = MyBase.getUser.perks(perk.guardup)

        If turnsLeft < 0 Then
            Return 10
        ElseIf turnsLeft < 3 Then
            Return 20
        ElseIf turnsLeft < 6 Then
            Return 60
        Else
            Return 100
        End If
    End Function

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Boosts the user's DEF by 40% for 3 turns."
    End Function
End Class
