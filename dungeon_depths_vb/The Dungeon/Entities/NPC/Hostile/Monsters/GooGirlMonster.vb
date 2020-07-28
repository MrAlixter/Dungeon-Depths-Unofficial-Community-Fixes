Public Class GooGirlMonster
    Inherits SlimeMonster
    Sub New()
        name = "Goo Girl"
        maxHealth = 90
        attack = 30
        defense = 80
        speed = 14
        setInventory({3})
        setupMonsterOnSpawn()
        xpValue = 25
    End Sub
End Class
