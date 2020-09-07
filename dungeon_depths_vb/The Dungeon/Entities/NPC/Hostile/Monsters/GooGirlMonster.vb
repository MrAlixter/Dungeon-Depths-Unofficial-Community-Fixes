Public Class GooGirlMonster
    Inherits SlimeMonster
    Sub New()
        name = "Goo Girl"
        maxHealth = 90
        attack = 30
        defense = 80
        speed = 14
        setInventory({3})
        setupMonsterOnSpawn()
        xpValue = 25
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        Dim out As String = "As the " & getName() & " closes in on you, you push yourself off the ground, sidestep it, and make a hasty retreat.  While your back is turned, the " & getName() & " whips a ball of goo at you.  As soon as it makes contact, you can feel the familiar tingle of magic..."
        despawn("p-death")
        If p.perks(perk.googirltf) = -1 Then
            p.perks(perk.googirltf) = 1
        End If

        p.ongoingTFs.add(New GooGirlTF(p.perks(perk.googirltf)))
        Game.pushLblEvent(out, AddressOf p.update)
    End Sub
End Class
