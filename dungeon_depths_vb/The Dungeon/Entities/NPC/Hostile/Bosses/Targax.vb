Public Class Targax
    Inherits MiniBoss

    Sub New()
        setName("Targax the Brutal")
        setMaxHealth(250)
        setATK(50)
        setDEF(20)
        setSPD(5)
        inv.setCount("Health_Potion", 2)
        inv.setCount("Major_Health_Potion", 3)
        inv.setCount("Sword_of_the_Brutal", 1)
        inv.setCount("Warrior's_Cuirass", CInt(Rnd() * 2))
        inv.setCount("Attack_Charm", 1 + CInt(Rnd() * 2))
        inv.setCount("Omni_Charm", 1)
        inv.setCount("Gold", 2500)

        setupMonsterOnSpawn()

        title = " "
        pronoun = "he"
        pPronoun = "his"
        rPronoun = "him"
        xpValue = 200
    End Sub
End Class
