Public Class SpiderMonster
    Inherits Monster

    Public Const BASE_NAME As String = "Spider"

    Sub New()
        '|ID Info|
        name = BASE_NAME

        '|Stats|
        maxHealth = 65
        attack = 35
        defense = 1
        speed = 45
        will = 6

        '|Inventory|
        setInventory({63})

        '|Dialog Variables|

        '|Misc|
        setupMonsterOnSpawn()

        If Int(Rnd() * 75) = 1 Then
            name = "Jewelled Spider"
            attack *= 3
            speed *= 1.5
            xp_value = 10000
        End If
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        Dim out As String = "As the " & getName() & " closes in on you, you push yourself off the ground, and sidestep it.  It anticipates this though, and with a lunging bite it latches onto your arm and delivers a powerful bite.  You smack it off, and make your escape, though a trickle of a golden venom hints that you might not be out of the woods yet."
        despawn("p-death")
        If p.perks(perk.avenom) = -1 And p.perks(perk.svenom) = -1 Then
            p.perks(perk.svenom) = 1
        End If
        p.ongoingTFs.add(New ArachneTF(p.perks(perk.svenom)))

        TextEvent.push(out, AddressOf p.update)
    End Sub
End Class
