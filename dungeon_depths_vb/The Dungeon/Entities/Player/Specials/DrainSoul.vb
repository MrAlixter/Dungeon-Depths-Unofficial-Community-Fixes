Public Class DrainSoul
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Drain Soul")
        MyBase.setUOC(False)
        MyBase.setcost(0)
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = MyBase.getTarget.getIntHealth * 0.13
        Dim xpGain As Integer = dmg
       
        'non critical hit
        MyBase.getTarget.takeDMG(dmg, Nothing)
        MyBase.getUser.xp += xpGain

        Game.pushLstLog(CStr("Drain Soul!  The " & MyBase.getTarget.name & " takes " & dmg & " damage and you gain " & xpGain & " XP!"))
        Game.pushLblCombatEvent(CStr("Drain Soul!  The " & MyBase.getTarget.name & " takes " & dmg & " damage and you gain " & xpGain & " XP!"))
    End Sub
End Class
