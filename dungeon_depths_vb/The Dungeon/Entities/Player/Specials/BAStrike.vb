Public Class BAStrike
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Helix Slash")
        MyBase.setUOC(False)
        MyBase.setcost(77)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget

        Dim dmg As Integer = p.getATK * 2.5
        Dim rcv As Integer = (dmg / 8) / p.getMaxHealth
        m.takeDMG(dmg, p)
        p.health += rcv
        If p.health * p.getMaxHealth > p.maxHealth + p.hBuff Then p.health = 1
        Game.pushLstLog("Helix Slash!")
        Game.pushLblCombatEvent("Helix Slash!" & vbCrLf & "You fly up into the air, the edge of your blade burning white hot.  Before your opponent can even react, you dart at them in a supersonic spiral.  Your firey sword cleaves clean through your opponent, dealing " & dmg & " damage, and heals you for " & rcv * p.getMaxHealth & " health between blows.")
    End Sub
End Class
