Public Class ArachHunt
    Inherits Monster
    Sub New()
        name = "Arachne Huntress"
        maxHealth = 110
        attack = 65
        defence = 10
        speed = 60
        setInventory({63, 64})
        setupMonsterOnSpawn()
    End Sub
End Class
