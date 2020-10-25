Public Class HeavyBlow
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Heavy Blow")
        MyBase.setUOC(False)
        MyBase.setcost(24)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget

        Dim spdBuff = 20 - p.getSPD
        If spdBuff < 0 Then spdBuff = 0

        Dim dmg As Integer = p.getATK + (p.getATK * (spdBuff / 20))
        Game.pushLstLog("Heavy Blow!")
        Game.pushLblCombatEvent("Heavy Blow!" & vbCrLf & "You hit your opponent for " & dmg & " damage!")

        m.takeDMG(dmg, p)
        If Not m.isStunned Then
            m.isStunned = True
            m.stunct = 0
        End If
    End Sub
End Class
