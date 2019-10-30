Public Class Targax
    Inherits MiniBoss

    Sub New()
        name = "Targax the Brutal"
        maxHealth = 250
        attack = 50
        defence = 20
        speed = 5
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
