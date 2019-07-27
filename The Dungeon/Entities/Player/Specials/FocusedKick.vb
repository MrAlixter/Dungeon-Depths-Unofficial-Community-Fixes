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
        m.takeDMG(dmg, p)
        Game.pushLstLog("Focused Roundhouse!")
        Game.pushLblCombatEvent("Focused Roundhouse!" & vbCrLf & "You kick your opponent for " & dmg & " damage!")
    End Sub
End Class
