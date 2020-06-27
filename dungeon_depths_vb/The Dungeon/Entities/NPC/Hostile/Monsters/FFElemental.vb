Public Class FFElemental
    Inherits Monster
    Sub New()
        name = "Fox-Fire Elemental"
        maxHealth = 1
        attack = 30
        defence = 1
        speed = 60
        setInventory({2, 3})
        setupMonsterOnSpawn()
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        Game.pushLblCombatEvent("The " & getName() & " casts Blaze!")
        Game.pushLstLog("The " & getName() & " casts Blaze!")
        Dim dmg = calcDamage(Me.getATK, target.getDEF * 0.8)
        hit(dmg, target)
    End Sub
End Class
