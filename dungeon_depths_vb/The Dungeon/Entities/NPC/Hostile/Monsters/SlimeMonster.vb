Public Class SlimeMonster
    Inherits Monster
    Sub New()
        name = "Slime"
        maxHealth = 30
        attack = 15
        defence = 60
        speed = 6
        setInventory({2, 3})
        setupMonsterOnSpawn()
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If health < 0.75 And Int(Rnd() * 2) = 0 Then
            Game.pushLblCombatEvent("The " & getName() & " used Absortion!")
            Game.pushLstLog("The " & getName() & " used Absortion!")
            Dim dmg = calcDamage(Me.getATK * 1.5, target.getDEF)
            hit(dmg, target)
            takeDMG(-dmg, Nothing)
            If health > 1.0 Then health = 1.0
        Else
            MyBase.attackCMD(target)
        End If
    End Sub
End Class
