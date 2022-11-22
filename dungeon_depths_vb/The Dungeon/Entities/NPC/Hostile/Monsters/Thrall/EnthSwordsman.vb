Public Class EnthSwordsman
    Inherits MesThrall

    Public Shadows Const BASE_NAME As String = "Enthralled Swordsman"

    Sub New()
        '|ID Info|
        name = BASE_NAME

        '|Stats|
        maxHealth = 135
        mana = 65
        attack = 85
        defense = 35
        speed = 60
        will = 5

        '|Inventory|
        setInventory({0, 1, 13})

        '|Dialog Variables|

        '|Misc|
        setupMonsterOnSpawn()
    End Sub
End Class
