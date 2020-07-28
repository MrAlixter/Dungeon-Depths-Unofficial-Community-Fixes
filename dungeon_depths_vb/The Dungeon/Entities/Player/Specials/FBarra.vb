Public Class FBarra
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Focused Barrage")
        MyBase.setUOC(False)
        MyBase.setcost(6)
    End Sub
    Public Overrides Sub effect()

        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget
        Game.pushLstLog("Focused Barrage!")
        Game.pushLblCombatEvent("Focused Barrage!")

        For i = 0 To Int(Rnd() * 4) + 4
            Dim dmg As Integer = (p.attack + p.aBuff) * p.pClass.a * p.pForm.a * 0.65
            dmg += Int(Rnd() * 2 * ((p.attack + p.aBuff) * p.pClass.a * p.pForm.a * 0.65 * 0.05)) -
                ((p.attack + p.aBuff) * p.pClass.a * p.pForm.a * 0.65 * 0.05)
            m.takeDMG(dmg, p)
            Game.pushLblCombatEvent("You hit your opponent for " & dmg & " damage!")
            If i <> 0 Then p.stamina -= 4
        Next

    End Sub
End Class
