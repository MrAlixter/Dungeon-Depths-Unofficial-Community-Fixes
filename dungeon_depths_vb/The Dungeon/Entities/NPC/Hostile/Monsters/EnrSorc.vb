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
        defence = 5
        speed = 25
        setInventory({})
        setupMonsterOnSpawn()
    End Sub
End Class
