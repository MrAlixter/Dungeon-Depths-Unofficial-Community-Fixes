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

        Dim spdBuff = m.getSPD - p.getSPD
        If spdBuff < 0 Then spdBuff = 0

        Dim dmg As Integer = p.getATK + (p.getATK * (spdBuff / m.getSPD))
        Game.pushLstLog("Heavy Blow!")
        Game.pushLblCombatEvent("Heavy Blow!" & vbCrLf & "You hit your opponent for " & dmg & " damage!")

        m.takeDMG(dmg, p)
        If Not m.isStunned Then
            m.isStunned = True
            m.stunct = 0
        End If
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Deals variable physical damage to its target.  More damage is dealt the slower the user is compared to their target."
    End Function
End Class
