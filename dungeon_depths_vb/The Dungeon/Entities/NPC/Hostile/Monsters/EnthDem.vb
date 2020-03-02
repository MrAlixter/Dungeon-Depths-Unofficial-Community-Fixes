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
        defence = 7
        speed = 30
        setInventory({})
        setupMonsterOnSpawn()
        xpValue = 40
    End Sub
End Class
