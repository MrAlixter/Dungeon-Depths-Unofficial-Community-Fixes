Public Class IWitch
    Inherits Monster

    Public Const BASE_NAME As String = "Intimidating Witch"

    Dim firstMove = True
    Dim tfTarget As Player = Nothing

    Sub New()
        '|ID Info|
        name = BASE_NAME

        '|Stats|
        maxHealth = 175
        attack = 15
        defense = 22
        speed = 1
        will = 35

        '|Inventory|
        inv.setCount("Medicinal_Tea", 3)
        inv.setCount("Garden_Salad", 2)

        '|Dialog Variables|
        pronoun = "she"
        p_pronoun = "her"
        r_pronoun = "her"

        '|Misc|
        setupMonsterOnSpawn()
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        Game.fromCombat()
        tfTarget = target
        TextEvent.push("Poof!", AddressOf tfToPanties)
    End Sub

    Public Sub tfToPanties()
        Dim c1 As Chest
        c1 = DDConst.BASE_CHEST.Create(tfTarget.inv, pos)
        c1.contents.add("Pink_Panties", 1)

        Game.currFloor.writeFloorToFile()

        tfTarget.die()
    End Sub
End Class
