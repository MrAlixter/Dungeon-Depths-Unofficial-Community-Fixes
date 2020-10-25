Public Class Snare
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Snare")
        MyBase.setUOC(True)
        MyBase.setcost(0)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget

        If Game.combatmode Then
            Dim oSPD = CInt(m.getSPD)
            Dim dmg = Entity.calcDamage(p.getATK * 0.25, m.getDEF)

            m.speed = Math.Max(1, m.speed - p.getATK * 0.1)

            Game.pushLstLog("You use Snare!  Your opponent is sliced for " & dmg & " damage and has their SPD reduced by " & oSPD - m.speed & "!")
            Game.pushLblCombatEvent("You use Snare!  Your opponent is sliced for " & dmg & " damage and has their SPD reduced by " & oSPD - m.speed & "!")
        Else
            SnareDialogBackend.toPnlSnare(Nothing, Nothing, Game.player1)
        End If
    End Sub
End Class
