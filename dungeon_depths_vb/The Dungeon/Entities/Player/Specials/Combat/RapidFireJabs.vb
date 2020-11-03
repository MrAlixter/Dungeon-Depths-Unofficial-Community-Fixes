Public Class RapidFireJabs
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Rapid Fire Jabs")
        MyBase.setUOC(False)
        MyBase.setcost(9)
    End Sub
    Public Overrides Sub effect()

        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget
        Game.pushLstLog("Rapid Fire Jabs!")
        Game.pushLblCombatEvent("Rapid Fire Jabs!")

        For i = 0 To Int(Rnd() * 3) + 2
            Dim dmg As Integer = p.getATK()
            dmg += Int(Rnd() * 2 * (p.getATK() * 0.05)) - (p.getATK() * 0.05)
            Game.pushLblCombatEvent("You hit your opponent for " & dmg & " damage!")
            m.takeDMG(dmg, p)
            If i <> 0 Then p.stamina -= 6
        Next
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A flurry of 2-4 quick strikes that deal physical damage."
    End Function
End Class
