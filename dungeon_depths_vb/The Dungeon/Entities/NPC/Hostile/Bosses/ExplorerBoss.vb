Public Class ExplorerBoss
    Inherits MiniBoss

    Sub New()
        name = "Explorer"
        maxHealth = 300
        attack = 15
        defence = 15
        speed = 15
        Randomize()
        For i = 0 To 5
            Dim invInd As Integer = 8
            While invInd = 8 Or invInd = 10 Or invInd = 24 Or invInd = 53 Or invInd = 119
                invInd = Int(Rnd() * (Game.player.inv.upperBound + 1))
            End While
            inv.add(invInd, CInt(Rnd() * 2) + 1)
        Next

        setupMonsterOnSpawn()
        xpValue = 200
    End Sub
End Class
