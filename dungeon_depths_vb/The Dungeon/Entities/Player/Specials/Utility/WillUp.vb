Public Class WillUp
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Will Up")
        MyBase.setUOC(False)
        MyBase.setcost(10)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser

        If p.perks(perk.willup) = -1 Then
            p.perks(perk.willup) = 3
        Else
            p.perks(perk.willup) += 3
        End If

        p.wBuff = p.wBuff + ((p.getWIL - p.wBuff) * 0.3)

        Game.pushLstLog("Will Up!")
        Game.pushLblCombatEvent("Will Up!" & vbCrLf & "+30% WILL for 3 turns.")
    End Sub

    Public Overrides Function getCost() As Integer
        Dim turnsLeft = MyBase.getUser.perks(perk.willup)

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
        Return "Boosts the user's WILL by 30% for 3 turns."
    End Function
End Class
