Public Class PuffUp
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        MyBase.setName("Puff Up")
        MyBase.setUOC(True)
        MyBase.settier(4)
        MyBase.setcost(6)
    End Sub
    Public Overrides Sub effect()
        If Not Game.combatmode Then backfire() : Exit Sub
        Dim t = MyBase.getTarget

        Dim sattack = t.attack
        Dim sspeed = t.speed
        Dim sHealth = t.maxHealth
        t.attack = Math.Max(t.attack * 0.85, 1)
        t.speed = Math.Max(t.speed * 0.85, 1)
        If sspeed > 1 Then t.maxHealth = t.maxHealth * 1.15

        Game.pushLstLog("Your foe's body inflates slightly!  -" & sattack - t.attack & " ATK, -" & sspeed - t.speed & " SPD, +" & t.maxHealth - sHealth & " Max Health")
        Game.pushLblEvent("Your foe's body inflates slightly!  -" & sattack - t.attack & " ATK, -" & sspeed - t.speed & " SPD, +" & t.maxHealth - sHealth & " Max Health")
    End Sub

    Public Overrides Sub backfire()
        Dim p = MyBase.getCaster

        Dim sattack = p.attack
        Dim sspeed = p.speed
        Dim sHealth = p.maxHealth
        p.attack = Math.Max(p.attack * 0.85, 1)
        p.speed = Math.Max(p.speed * 0.85, 1)
        If sspeed > 1 Then p.maxHealth = p.maxHealth * 1.15

        If Not p.breastSize = -1 Then p.be()
        If Not p.buttSize = -1 Then p.ue()
        If Not p.dickSize = -1 Then p.de()

        Game.pushLstLog("Your body inflates slightly!  -" & sattack - p.attack & " ATK, -" & sspeed - p.speed & " SPD, +" & p.maxHealth - sHealth & " Max Health")
        Game.pushLblEvent("Your body inflates slightly!  -" & sattack - p.attack & " ATK, -" & sspeed - p.speed & " SPD, +" & p.maxHealth - sHealth & " Max Health")
    End Sub
End Class
