Public Class EnthConjurer
    Inherits MesThrall
    Sub New()
        name = "Enthralled Conjurer"
        maxHealth = 135
        mana = 65
        attack = 5
        defense = 35
        speed = 60
        will = 85
        setInventory({0, 1, 13})
        setupMonsterOnSpawn()
    End Sub
End Class
