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
        MyBase.getUser.xp += xpGain

        Game.pushLstLog(CStr("Drain Soul!  The " & MyBase.getTarget.name & " takes " & dmg & " damage and you gain " & xpGain & " XP!"))
        Game.pushLblCombatEvent(CStr("Drain Soul!  The " & MyBase.getTarget.name & " takes " & dmg & " damage and you gain " & xpGain & " XP!"))
        MyBase.getTarget.takeDMG(dmg, Nothing)
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Deals a low amount of magic damage that is recovered by the user as XP.  Draining the same entity more than once will lead to diminishing returns."
    End Function
End Class
