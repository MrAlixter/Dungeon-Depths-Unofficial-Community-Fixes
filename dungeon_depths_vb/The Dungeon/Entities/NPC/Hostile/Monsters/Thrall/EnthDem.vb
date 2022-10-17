Public Class EnthDem
    Inherits Monster

    Public Const BASE_NAME As String = "Enthralling Half-Demon"

    Sub New()
        Dim rng = Int(Rnd() * 2)

        '|ID Info|
        If rng = 0 Then
            name = BASE_NAME
        Else
            name = "Enthralling Half-Demoness"
        End If

        '|Stats|
        maxHealth = 200
        attack = 60
        defense = 20
        speed = 30
        will = 40

        '|Inventory|
        setInventory({})

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
        setupMonsterOnSpawn()
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        attackSpell(target, "a ball of black fire", getATK)
    End Sub
End Class
