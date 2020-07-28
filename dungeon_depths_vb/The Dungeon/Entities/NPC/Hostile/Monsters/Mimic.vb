Public Class Mimic
    Inherits Monster
    Sub New()
        name = "Mimic"
        maxHealth = 175
        attack = 35
        defense = 20
        speed = 50
        setInventory({0})
        setupMonsterOnSpawn()
        xpValue = 50
    End Sub
End Class
