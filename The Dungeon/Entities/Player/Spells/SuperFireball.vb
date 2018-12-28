Public Class SuperFireball
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As Monster)
        MyBase.New(c, t)
        MyBase.setName("Super Fireball")
        MyBase.settier(3)
        MyBase.setcost(6)
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = 60
        Dim d51 = Int(Rnd() * 5)
        Dim d52 = Int(Rnd() * 5)
        If d51 = d52 And d52 = 2 Then
            'critical hit
            MyBase.getTarget.takeDMG(2 * (dmg + d51 + d52), MyBase.getCaster)
            Game.lstLog.Items.Add(CStr("Critical hit!  You hit the " & MyBase.getTarget.name & " for " & 2 * (dmg + d51 + d52) & " damage!"))
            Game.pushLblCombatEvent(CStr("Critical hit!  You hit the " & MyBase.getTarget.name & " for " & 2 * (dmg + d51 + d52) & " damage!"))
            Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        Else
            'non critical hit
            MyBase.getTarget.takeDMG(dmg + d51 + d52, MyBase.getCaster)
            Game.lstLog.Items.Add(CStr("You hit the " & MyBase.getTarget.name & " for " & dmg + d51 + d52 & " damage!"))
            Game.pushLblCombatEvent(CStr("You hit the " & MyBase.getTarget.name & " for " & dmg + d51 + d52 & " damage!"))
            Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        End If
    End Sub
    Public Overrides Sub backfire()
        Dim dmg = Int(Rnd() * 30) + 10
        MyBase.getCaster.takeDMG(dmg, Nothing)
        Game.lstLog.Items.Add(CStr("You hit yourself for " & dmg & " damage!"))
        Game.pushLblCombatEvent(CStr("You hit yourself for " & dmg & " damage!"))
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
End Class
