Public Class FMantra
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Focus Up")
        MyBase.setUOC(False)
        MyBase.setcost(3)
    End Sub
    Public Overrides Sub effect()
        TextEvent.pushLog("Focus Up!")
        If MyBase.getUser.className.Equals("Bimbo") Or MyBase.getUser.className.Equals("Magical Slut") Then
            TextEvent.pushCombat("You, like, totally can't, ummm... focus right now!")
            Exit Sub
        ElseIf MyBase.getUser.className.Equals("Mindless") Or MyBase.getUser.className.Equals("Unconscious") Or MyBase.getUser.className.Equals("Thrall") Then
            TextEvent.pushCombat("You can't focus right now!")
            Exit Sub
        End If

        MyBase.getUser.addLust(-50)
        TextEvent.pushCombat("Focus Up!" & vbCrLf & "-50 Lust.")
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Reduces the user's LUST by 50, as long as they are able to focus."
    End Function
End Class
