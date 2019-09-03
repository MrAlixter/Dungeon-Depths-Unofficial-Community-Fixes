Public Class MesThrall
    Inherits Monster
    Sub New()
        name = "Mesmerized Thrall"
        maxHealth = 85
        attack = 20
        defence = 7
        speed = 9
        setInventory({0, 1, 13})
        setupMonsterOnSpawn()
    End Sub
End Class
