Public Class OozeKnight
    Inherits SlimeMonster
    Sub New()
        name = "Ooze Knight"
        maxHealth = 150
        mana = 125
        attack = 15
        defense = 100
        speed = 1
        setInventory({2, 3})
        setupMonsterOnSpawn()
    End Sub
End Class
