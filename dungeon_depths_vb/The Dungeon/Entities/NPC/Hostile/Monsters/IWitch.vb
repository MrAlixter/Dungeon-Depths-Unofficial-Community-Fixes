Public Class IWitch
    Inherits Monster

    Dim firstMove = True
    Dim tfTarget As Player = Nothing

    Sub New()
        name = "Intimidating Witch"
        maxHealth = 175
        attack = 15
        defense = 22
        speed = 1
        will = 35
        inv.setCount("Medicinal_Tea", 3)
        inv.setCount("Garden_Salad", 2)

        setupMonsterOnSpawn()

        pronoun = "she"
        p_pronoun = "her"
        r_pronoun = "her"
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        Game.fromCombat()
        tfTarget = target
        Game.pushLblEvent("Poof!", AddressOf tfToPanties)
    End Sub

    Public Sub tfToPanties()
        Dim c1 As Chest
        c1 = Game.baseChest.Create(tfTarget.inv, pos)
        c1.contents.add("Pink_Panties", 1)

        Game.currFloor.writeFloorToFile()

        tfTarget.die()
    End Sub
End Class
