Public Class EnthConjurer
    Inherits MesThrall

    Public Shadows Const BASE_NAME As String = "Enthralled Conjurer"

    Sub New()
        '|ID Info|
        name = BASE_NAME

        '|Stats|
        maxHealth = 135
        mana = 65
        attack = 5
        defense = 35
        speed = 60
        will = 85

        '|Inventory|
        setInventory({0, 1, 13})

        '|Dialog Variables|


        '|Misc|
        setupMonsterOnSpawn()
    End Sub
End Class
