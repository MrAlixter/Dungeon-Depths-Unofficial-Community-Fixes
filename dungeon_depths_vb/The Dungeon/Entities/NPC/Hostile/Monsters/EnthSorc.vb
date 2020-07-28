Public Class EnthSorc
    Inherits Monster
    Sub New()
        Dim rng = Int(Rnd() * 2)
        If rng = 0 Then
            name = "Enthralling Sorcerer"
        Else
            name = "Enthralling Sorceress"
        End If
        maxHealth = 150
        attack = 40
        defense = 17
        speed = 20
        setInventory({4, 13})
        setupMonsterOnSpawn()
        xpValue = 25
    End Sub
End Class
