Public Class ArachHunt
    Inherits Monster
    Sub New()
        name = "Arachne Huntress"
        maxHealth = 110
        attack = 65
        defense = 10
        speed = 60
        setInventory({63, 64})
        setupMonsterOnSpawn()
        xpValue = 25
    End Sub
End Class
