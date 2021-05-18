Public Class EnthSwordsman
    Inherits MesThrall
    Sub New()
        name = "Enthralled Swordsman"
        maxHealth = 135
        mana = 65
        attack = 85
        defense = 35
        speed = 60
        will = 5
        setInventory({0, 1, 13})
        setupMonsterOnSpawn()
    End Sub
End Class
