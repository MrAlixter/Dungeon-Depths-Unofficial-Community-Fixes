Public Class FocusUp
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Focus Up")
        MyBase.setUOC(True)
        MyBase.setcost(3)
    End Sub
    Public Overrides Sub effect()
        If Not HypnosisEffect.hypnotize(getUser(), getUser.getWIL() + 10, h_ind.focusup) Or Not HypnosisEffect.trigger(getUser(), h_ind.focusup) Then
            TextEvent.fpushAndLog("Focus Up failed...")
        End If
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Reduces the user's LUST by 50, as long as they are able to focus."
    End Function
End Class
