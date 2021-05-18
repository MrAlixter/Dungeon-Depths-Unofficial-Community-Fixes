Public Class RitOfMana
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Ritual of Mana")
        MyBase.setUOC(True)

        setcost(100)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        p.mana += 15
        Game.pushLstLog("Ritual of Mana!")
        Game.pushLblEvent("Ritual of Mana!" & vbCrLf & "Generate 15 mana, with a stamina cost based on the user's existing mana.")
    End Sub

    Public Overrides Function getCost() As Integer
        If getUser.getMana < 5 Then
            Return 20
        ElseIf getUser.getMana < 10 Then
            Return 30
        ElseIf getUser.getMana < 15 Then
            Return 45
        ElseIf getUser.getMana < 20 Then
            Return 60
        ElseIf getUser.getMana < 30 Then
            Return 85
        Else
            Return 100
        End If
    End Function

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Generate 15 mana, with a stamina cost based on the user's existing mana."
    End Function
End Class
