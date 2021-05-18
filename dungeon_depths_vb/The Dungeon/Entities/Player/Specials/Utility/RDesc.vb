Public Class RDesc
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Risky Decision")
        MyBase.setUOC(False)
        MyBase.setcost(-1)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser

        Dim m_boost As Integer = (p.getmaxHealth / 4)
        If (p.health * p.getmaxHealth) <= m_boost Then p.Die() Else p.health -= m_boost / p.getmaxHealth
        p.mana += m_boost
        Game.pushLstLog("Risky Decision!")
        Game.pushLblCombatEvent("Risky Decision!" & vbCrLf & "Convert 25% Max Health into mana.")
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Converts 25% of its user's Max HP into MP."
    End Function
End Class
