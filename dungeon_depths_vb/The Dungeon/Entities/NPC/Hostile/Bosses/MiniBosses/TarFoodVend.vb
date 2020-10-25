Public Class TarFoodVend
    Inherits Boss
    Sub New()
        name = "Targax, The Food Vendor"

        maxHealth = 400
        attack = 600
        defense = 250
        speed = 700
        will = 250

        inv.setCount("Omni_Charm", 1)
        inv.setCount("Tavern_Special", 1)

        setupMonsterOnSpawn()

        title = " "
        pronoun = "he"
        pPronoun = "his"
        rPronoun = "him"

        xpValue = 70000
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        MyBase.attackCMD(target)
    End Sub
End Class
