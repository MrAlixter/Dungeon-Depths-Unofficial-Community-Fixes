Public Class Lurk
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Lurk")
        MyBase.setUOC(True)
        MyBase.setcost(15)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser

        If p.perks(perk.lurk) = -1 Then
            p.perks(perk.lurk) += 200
            Game.pushLstLog("Lurk!")
            Game.pushLblCombatEvent("Lurk!")
        Else
            p.perks(perk.lurk) = -1
            Game.pushLstLog("You come out of hiding...")
        End If

        p.drawPort()
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
        Return "Conceals the user in a large shrub, which makes them nearly invisible and may suprise new foes..."
    End Function
End Class
