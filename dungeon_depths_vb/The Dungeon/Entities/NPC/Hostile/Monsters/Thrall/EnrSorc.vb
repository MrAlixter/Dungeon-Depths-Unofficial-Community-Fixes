Public Class EnrSorc
    Inherits Monster

    Public Const BASE_NAME As String = "Enraged Sorcerer"

    Sub New()
        Dim rng = Int(Rnd() * 2)

        '|ID Info|
        If rng = 0 Then
            name = BASE_NAME
        Else
            name = "Enraged Sorceress"
        End If

        '|Stats|
        maxHealth = 145
        attack = 50
        defense = 5
        speed = 25
        will = 30

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
        attackSpell(target, "a ball of black lightning", getATK)
    End Sub
End Class
