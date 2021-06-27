Public Class TarFoodVend
    Inherits Boss
    Sub New()
        '|ID Info|
        name = "Targax, The Food Vendor"

        '|Stats|
        maxHealth = 400
        attack = 600
        defense = 250
        speed = 700
        will = 250
        xp_value = 70000

        '|Inventory|
        inv.setCount("Omni_Charm", 1)
        inv.setCount("Tavern_Special", 1)

        '|Dialog Variables|
        title = " "
        pronoun = "he"
        p_pronoun = "his"
        r_pronoun = "him"


        '|Misc|
        setupMonsterOnSpawn()

    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        MyBase.attackCMD(target)
    End Sub
End Class
