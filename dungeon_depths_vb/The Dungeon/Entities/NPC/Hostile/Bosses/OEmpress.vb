Public Class OEmpress
    Inherits MiniBoss

    Sub New()
        name = ("Ooze Empress")
        maxHealth = (100)
        attack = (30)
        defence = (70)
        speed = (1)
        setInventory({3, 58, 65})
        inv.setCount("Defence_Charm", 1 + CInt(Rnd() * 2))
        inv.setCount("Omni_Charm", 1)
        inv.setCount("Gold", 5000)

        setupMonsterOnSpawn()

        title = " "
        pronoun = "she"
        pPronoun = "her"
        rPronoun = "her"
        xpValue = 400
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        MyBase.attackCMD(target)
    End Sub
End Class
