Public Class GooGirlMonster
    Inherits MarissaAS
    Sub New()
        name = "Goo Girl"
        maxHealth = 90
        attack = 30
        defence = 80
        speed = 14
        setInventory({3})
        setupMonsterOnSpawn()
    End Sub
End Class
