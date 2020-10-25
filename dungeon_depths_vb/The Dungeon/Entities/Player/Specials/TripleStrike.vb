Public Class TripleStrike
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Triple Strike")
        MyBase.setUOC(False)
        MyBase.setcost(45)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget
        Game.pushLstLog("Triple Strike!")
        Game.pushLblCombatEvent("Triple Strike!")

        For i = 1 To 3
            ' Dim dmg = m.getIntHealth()
            p.attackCMD(m)
            ' dmg -= m.getIntHealth()
        Next
    End Sub
End Class
