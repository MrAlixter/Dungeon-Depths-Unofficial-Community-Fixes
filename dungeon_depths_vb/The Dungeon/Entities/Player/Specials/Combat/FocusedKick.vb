Public Class FocusedKick
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Focused Roundhouse")
        MyBase.setUOC(False)
        MyBase.setcost(16)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget

        Dim dmg As Integer = (p.attack + p.aBuff) * p.pClass.a * p.pForm.a * 1.95
        Game.pushLstLog("Focused Roundhouse!")
        Game.pushLblCombatEvent("Focused Roundhouse!" & vbCrLf & "You kick your opponent for " & dmg & " damage!")
        m.takeDMG(dmg, p)
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Deals heavy damage that does not factor in the equipment of its user."
    End Function
End Class
