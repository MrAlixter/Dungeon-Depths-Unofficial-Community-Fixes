Public Class SiphonSlash
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Siphon Slash")
        MyBase.setUOC(False)
        MyBase.setcost(-1)
    End Sub
    Public Overrides Sub effect()
        TextEvent.pushLog("Siphon Slash!")
        TextEvent.pushCombat("Siphon Slash!" & vbCrLf & "20% of damage dealt on the next physical attack will be recovered as MP.")
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "On the next physical attack its user performs, 20% of damage dealt will be recovered as MP."
    End Function
End Class
