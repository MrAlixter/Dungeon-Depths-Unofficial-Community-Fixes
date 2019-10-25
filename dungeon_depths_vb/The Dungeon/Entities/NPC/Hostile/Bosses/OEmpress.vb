Public Class OEmpress
    Inherits MiniBoss

    Sub New()
        setName("Ooze Empress")
        setMaxHealth(100)
        setATK(30)
        setDEF(70)
        setSPD(1)
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
End Class
