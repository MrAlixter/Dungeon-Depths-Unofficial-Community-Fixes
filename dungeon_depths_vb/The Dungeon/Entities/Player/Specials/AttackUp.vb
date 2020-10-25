Public Class AttackUp
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Attack Up")
        MyBase.setUOC(False)
        MyBase.setcost(10)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser

        If p.perks(perk.atkup) = -1 Then
            p.perks(perk.atkup) = 3
        Else
            p.perks(perk.atkup) += 3
        End If

        p.aBuff = p.aBuff + ((p.getATK - p.aBuff) * 0.3)

        Game.pushLstLog("Attack Up!")
        Game.pushLblCombatEvent("Attack Up!" & vbCrLf & "+30% ATK for 3 turns.")
    End Sub

    Public Overrides Function getCost() As Integer
        Dim turnsLeft = MyBase.getUser.perks(perk.atkup)

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
End Class
