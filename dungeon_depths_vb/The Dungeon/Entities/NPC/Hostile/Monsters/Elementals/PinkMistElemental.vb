Public Class PinkMistElemental
    Inherits Monster

    Public Const BASE_NAME As String = "Mist-Wisp Elemental"

    Sub New()
        '|ID Info|
        name = BASE_NAME

        '|Stats|
        maxHealth = 3
        attack = 60
        defense = 777
        speed = 60
        will = 3
        setupMonsterOnSpawn()

        '|Inventory|
        setInventory({49, 191, 197, 205})

        '|Dialog Variables|

        '|Misc|

    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If Int(Rnd() * 3) < 2 Then
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " casts Haze!")
            TextEvent.push("...but it doens't seem to do anything.")
        Else
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " just... kinda floats there...")
        End If
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        despawn("p-death")

        TextEvent.push("You collapse, defeated..." & DDUtils.PAKTC)
    End Sub
End Class
