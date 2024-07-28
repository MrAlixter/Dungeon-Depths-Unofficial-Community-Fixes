Public Class IceElemental
    Inherits Monster

    Public Const BASE_NAME As String = "Ice Elemental"

    Sub New()
        '|ID Info|
        name = BASE_NAME

        '|Stats|
        maxHealth = 4
        attack = 22
        defense = 277
        speed = 0
        will = 7777
        setupMonsterOnSpawn()

        xp_value *= 0.35

        '|Inventory|
        setInventory({76, 432, 433})

        '|Dialog Variables|

        '|Misc|

    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        TextEvent.pushCombat("The " & getName() & " casts Ice Wind!")
        TextEvent.pushLog("The " & getName() & " casts Ice Wind!")
        Dim dmg = calcDamage(Me.getATK, target.getDEF * 0.7)
        hit(dmg, target)

        If Not target.getPlayer Is Nothing And target.getPlayer.lust > 0 Then
            target.getPlayer.addLust(-21)
        End If
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        despawn("p-death")

        p.setLust(0)
        TextEvent.push("You collapse, shivering..." & DDUtils.PAKTC)
    End Sub
End Class
