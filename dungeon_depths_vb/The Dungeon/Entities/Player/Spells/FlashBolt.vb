Public Class FlashBolt
    Inherits Spell

    Public Const SPELL_NAME As String = "Flash Bolt"

    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        MyBase.setName("Flash Bolt")
        MyBase.settier(2)
        MyBase.setcost(7)
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = 35
        Dim d31 = Int(Rnd() * 7)
        Dim d32 = Int(Rnd() * 7)
        If Int(Rnd() * 6) = 0 Then
            'critical hit
            dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, (dmg + d31 + d32) * 2)
            Game.pushLstLog(CStr("Critical Hit!  You hit the " & MyBase.getTarget.name & " for " & dmg & " damage!"))
            Game.pushLblCombatEvent(CStr("Critical Hit!  You hit the " & MyBase.getTarget.name & " for " & dmg & " damage!"))
            MyBase.getTarget.takeDMG(dmg, MyBase.getCaster)
        Else
            'non critical hit
            dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, dmg + d31 + d32)
            Game.pushLstLog(CStr("You hit the " & MyBase.getTarget.name & " for " & dmg & " damage!"))
            Game.pushLblCombatEvent(CStr("You hit the " & MyBase.getTarget.name & " for " & dmg & " damage!"))
            MyBase.getTarget.takeDMG(dmg, MyBase.getCaster)
        End If
    End Sub
End Class
