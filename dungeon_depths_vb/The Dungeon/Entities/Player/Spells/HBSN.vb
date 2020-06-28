Public Class HBSN
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        MyBase.setName("Heartbreak Supernova")
        MyBase.settier(1)
        MyBase.setcost(6)
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = 66
        Dim d51 = Int(Rnd() * 6)
        Dim d52 = Int(Rnd() * 6)
        If d51 = d52 And d52 = 6 Then
            'critical hit
            MyBase.getTarget.takeDMG(2 * (dmg + d51 + d52), MyBase.getCaster)
            Game.pushLstLog(CStr("Critical hit!  You hit the " & MyBase.getTarget.name & " for " & 2 * (dmg + d51 + d52) & " damage!"))
            Game.pushLblCombatEvent(CStr("Critical hit!  You hit the " & MyBase.getTarget.name & " for " & 2 * (dmg + d51 + d52) & " damage!"))
        Else
            'non critical hit
            MyBase.getTarget.takeDMG(dmg + d51 + d52, MyBase.getCaster)
            Game.pushLstLog(CStr("You hit the " & MyBase.getTarget.name & " for " & dmg + d51 + d52 & " damage!"))
            Game.pushLblCombatEvent(CStr("You hit the " & MyBase.getTarget.name & " for " & dmg + d51 + d52 & " damage!"))
        End If

        getCaster.takeCritDMG(Int(Rnd() * 6) + 6, getCaster)
        getCaster.hunger += 6
    End Sub
End Class
