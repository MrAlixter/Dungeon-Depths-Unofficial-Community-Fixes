Public Class RDesc
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Risky Decision")
        MyBase.setUOC(False)
        MyBase.setcost(-1)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser

        Dim mBoost As Integer = (p.getmaxHealth / 4)
        If (p.health * p.getmaxHealth) <= mBoost Then p.Die() Else p.health -= mBoost / p.getmaxHealth
        p.mana += mBoost
        Game.pushLstLog("Risky Decision!")
        Game.pushLblCombatEvent("Risky Decision!" & vbCrLf & "Convert 25% Max Health into mana.")
    End Sub
End Class
