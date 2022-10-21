Public Class FFElemental
    Inherits Monster

    Public Const BASE_NAME As String = "Fox-Fire Elemental"

    Sub New()
        '|ID Info|
        name = BASE_NAME

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
        TextEvent.pushCombat("The " & getName() & " casts Blaze!")
        TextEvent.pushLog("The " & getName() & " casts Blaze!")
        Dim dmg = calcDamage(Me.getATK, target.getDEF * 0.8)
        hit(dmg, target)

        If target.GetType() Is GetType(Player) Then CType(target, Player).perks(perk.burn) += 3
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        despawn("p-death")

        TextEvent.push("You collapse, defeated..." & DDUtils.PAKTC)
    End Sub
End Class
