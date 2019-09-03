Public Class Mimic
    Inherits Monster
    Sub New()
        name = "Mimic"
        maxHealth = 175
        attack = 35
        defence = 20
        speed = 50
        setInventory({0})
        setupMonsterOnSpawn()
    End Sub
End Class
