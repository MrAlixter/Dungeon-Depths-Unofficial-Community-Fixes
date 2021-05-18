Public Class TripleStrike
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Triple Strike")
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
            If MyBase.getTarget.isDead Then Exit For
        Next
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Deals three swift attacks that utilize the user's equipped weapon.  Particularly devistating if used with a weapon that has an on-attack effect."
    End Function
End Class
