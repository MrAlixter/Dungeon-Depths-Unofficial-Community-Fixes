Public Class EnthDem
    Inherits Monster
    Sub New()
        Dim rng = Int(Rnd() * 2)
        If rng = 0 Then
            name = "Enthralling Half-Demon"
        Else
            name = "Enthralling Half-Demoness"
        End If
        maxHealth = 200
        attack = 60
        defense = 7
        speed = 30
        will = 40
        setInventory({})
        setupMonsterOnSpawn()
    End Sub
End Class
