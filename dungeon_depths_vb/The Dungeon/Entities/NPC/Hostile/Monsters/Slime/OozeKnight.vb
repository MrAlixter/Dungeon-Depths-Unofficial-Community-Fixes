Public Class OozeKnight
    Inherits SlimeMonster

    Public Shadows Const BASE_NAME As String = "Ooze Knight"

    Sub New()
        '|ID Info|
        name = BASE_NAME

        '|Stats|
        maxHealth = 150
        mana = 125
        attack = 15
        defense = 100
        speed = 1

        '|Inventory|
        setInventory({2, 3})

        '|Dialog Variables|

        '|Misc|
        setupMonsterOnSpawn()
    End Sub
End Class
