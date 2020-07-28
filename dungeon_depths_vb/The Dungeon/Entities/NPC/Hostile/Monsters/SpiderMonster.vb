Public Class SpiderMonster
    Inherits Monster
    Sub New()
        name = "Spider"
        maxHealth = 65
        attack = 35
        defense = 1
        speed = 45
        setInventory({63})
        setupMonsterOnSpawn()
    End Sub
End Class
