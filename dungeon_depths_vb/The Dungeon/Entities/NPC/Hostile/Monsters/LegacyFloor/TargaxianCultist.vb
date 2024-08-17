Public Class TargaxianCultist
    Inherits Monster

    Public Const BASE_NAME As String = "Targaxian Cultist"

    Sub New()
        Dim rng = Int(Rnd() * 2)

        '|Stats|
        maxHealth = 150
        attack = 40
        defense = 17
        speed = 20
        will = 15

        '|Inventory|
        setInventory({4, 13})
        '|Dialog Variables|
        If rng = 0 Then
            pronoun = "he"
            p_pronoun = "his"
            r_pronoun = "him"
        Else
            pronoun = "she"
            p_pronoun = "her"
            r_pronoun = "her"
        End If

        '|Misc|
        setupMonsterOnSpawn(Math.Max(1, Game.player1.level + 1))
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If target.getWIL > target.getDEF Then
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " slashes with a glowing sword!")
            MyBase.attackCMD(target)
        Else
            attackSpell(target, "a bolt of red lightning", getATK() * 0.8)
        End If

    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        Game.player1.pos = Game.currFloor.randPoint

        TextEvent.push("Before you can be finished off by your foe, your feet clip through the floor and you wind up somewhere else.")
    End Sub
End Class
