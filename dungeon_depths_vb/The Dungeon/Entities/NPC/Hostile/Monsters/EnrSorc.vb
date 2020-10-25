Public Class EnrSorc
    Inherits Monster
    Sub New()
        Dim rng = Int(Rnd() * 2)
        If rng = 0 Then
            name = "Enraged Sorcerer"
        Else
            name = "Enraged Sorceress"
        End If
        maxHealth = 145
        attack = 50
        defense = 5
        speed = 25
        will = 30
        setInventory({})
        setupMonsterOnSpawn()
        xpValue = 35
    End Sub
End Class
