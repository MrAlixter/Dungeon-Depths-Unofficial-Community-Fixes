Public Class RitOfMana
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Ritual of Mana")
        MyBase.setUOC(True)
        If u.getMana < 5 Then
            setcost(20)
        ElseIf u.getMana < 10 Then
            setcost(40)
        ElseIf u.getMana < 15 Then
            setcost(60)
        ElseIf u.getMana < 20 Then
            setcost(80)
        ElseIf u.getMana < 30 Then
            setcost(100)
        Else
            setcost(120)
        End If
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        p.mana += 15
        Game.pushLstLog("Ritual of Mana!")
        Game.pushLblEvent("Ritual of Mana!" & vbCrLf & "Generate 15 mana, with a hunger cost based on the existing mana.")
    End Sub
End Class
