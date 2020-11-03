Public Class BAStrike
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Helix Slash")
        MyBase.setUOC(False)
        MyBase.setcost(33)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget

        Dim dmg As Integer = p.getATK * 1.5
        Dim rcv As Integer = (dmg / 8) / p.getMaxHealth

        p.health += rcv
        If p.health * p.getMaxHealth > p.maxHealth + p.hBuff Then p.health = 1
        Game.pushLstLog("Helix Slash!")
        Game.pushLblCombatEvent("Helix Slash!" & vbCrLf & "You fly up into the air, the edge of your blade burning white hot.  Before your opponent can even react, you dart at them in a supersonic spiral.  Your firey sword cleaves clean through your opponent, dealing " & dmg & " damage, and heals you for " & rcv * p.getMaxHealth & " health between blows.")
        m.takeDMG(dmg, p)
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Deals physical damage equal to 150% of the user's ATK and restores health to the user equal to 1/8th of the damage dealt."
    End Function
End Class
