Public Class OozeScion
    Inherits Monster

    Public Shadows Const BASE_NAME As String = "Ooze Scion"

    Sub New()
        '|ID Info|
        name = BASE_NAME

        '|Stats|
        maxHealth = 80
        attack = 30
        defense = 70
        speed = 22

        '|Inventory|

        '|Dialog Variables|
        pronoun = "she"
        p_pronoun = "her"
        r_pronoun = "her"

        '|Misc|
        setupMonsterOnSpawn(Math.Max(1, Game.player1.level + 1))
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If Int(Rnd() * 4) = 0 And form = "" Then
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " extends a hand, firing off a barrage of slime!")

            Dim dmg = calcDamage(Me.getATK * 0.75, target.getDEF) 'calculate the hit
            If dmg > 0 Then dmg += Int(Rnd() * 3) + -1 'adds some variance

            hit(dmg, target)
            If dmg > 0 Then dmg += Int(Rnd() * 3) + -2 'adds some variance
            If Game.combat_engaged Then hit(dmg, target)
            If dmg > 0 Then dmg += Int(Rnd() * 3) + -1 'adds some variance
            If Game.combat_engaged Then hit(dmg, target)
        ElseIf health < 0.75 And Int(Rnd() * 2) = 0 Then
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " used Absorption!")

            Dim dmg = calcDamage(Me.getATK * 1.5, target.getDEF)
            hit(dmg, target)
            takeDMG(-dmg, Nothing)

            If health > 1.0 Then health = 1.0
        Else
            MyBase.attackCMD(target)
        End If
    End Sub


    Public Overrides Sub playerDeath(ByRef p As Player)
        Game.player1.pos = Game.currFloor.randPoint

        TextEvent.push("Before you can be engulfed by your foe, your feet clip through the floor and you wind up somewhere else.")
    End Sub
End Class
