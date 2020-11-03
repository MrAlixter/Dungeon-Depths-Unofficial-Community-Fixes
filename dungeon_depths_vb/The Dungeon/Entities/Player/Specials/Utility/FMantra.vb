Public Class FMantra
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Focus Up")
        MyBase.setUOC(False)
        MyBase.setcost(3)
    End Sub
    Public Overrides Sub effect()
        Game.pushLstLog("Focus Up!")
        If MyBase.getUser.className.Equals("Bimbo") Or MyBase.getUser.className.Equals("Magical Slut") Then
            Game.pushLblCombatEvent("You, like, totally can't, ummm... focus right now!")
            Exit Sub
        ElseIf MyBase.getUser.className.Equals("Mindless") Or MyBase.getUser.className.Equals("Unconscious") Or MyBase.getUser.className.Equals("Thrall") Then
            Game.pushLblCombatEvent("You can't focus right now!")
            Exit Sub
        End If

        MyBase.getUser.addLust(-20)
        Game.pushLblCombatEvent("Focus Up!" & vbCrLf & "-20 Lust.")
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Reduces the user's LUST by 20, as long as they are able to focus."
    End Function
End Class
