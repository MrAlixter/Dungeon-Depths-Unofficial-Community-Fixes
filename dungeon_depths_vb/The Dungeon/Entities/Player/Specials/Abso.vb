Public Class Abso
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Absorbtion")
        MyBase.setUOC(False)
        MyBase.setcost(-1)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget

        Dim dmg As Integer = p.attack * 0.75
        Dim rcv As Integer = dmg * 2 / p.getMaxHealth
        p.health += rcv
        If p.health * p.getMaxHealth > p.maxHealth + p.hBuff Then p.health = 1
        Game.pushLstLog("Absorbtion!")
        Game.pushLblCombatEvent("Absorbtion!" & vbCrLf & "Deals " & dmg & " damage and heals you for " & rcv)
        m.takeDMG(dmg, p)
    End Sub
End Class
