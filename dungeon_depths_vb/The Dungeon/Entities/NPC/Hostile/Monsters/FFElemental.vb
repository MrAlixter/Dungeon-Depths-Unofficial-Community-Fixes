Public Class FFElemental
    Inherits Monster
    Sub New()
        '|ID Info|
        name = "Fox-Fire Elemental"

        '|Stats|
        maxHealth = 3
        attack = 60
        defense = 3
        speed = 60
        will = 7777

        '|Inventory|
        setInventory({49, 189, 198, 205})

        '|Dialog Variables|


        '|Misc|
        setupMonsterOnSpawn()
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        Game.pushLblCombatEvent("The " & getName() & " casts Blaze!")
        Game.pushLstLog("The " & getName() & " casts Blaze!")
        Dim dmg = calcDamage(Me.getATK, target.getDEF * 0.8)
        hit(dmg, target)

        If target.GetType() Is GetType(Player) Then CType(target, Player).perks(perk.burn) += 3
    End Sub
End Class
