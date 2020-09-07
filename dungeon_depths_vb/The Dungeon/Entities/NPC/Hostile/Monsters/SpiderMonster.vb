Public Class SpiderMonster
    Inherits Monster
    Sub New()
        name = "Spider"
        maxHealth = 65
        attack = 35
        defense = 1
        speed = 45
        setInventory({63})
        setupMonsterOnSpawn()
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        Dim out As String = "As the " & getName() & " closes in on you, you push yourself off the ground, and sidestep it.  It anticipates this though, and with a lunging bite it latches onto your arm and delivers a powerful bite.  You smack it off, and make your escape, though a trickle of a golden venom hints that you might not be out of the woods yet."
        despawn("p-death")
        If p.perks(perk.avenom) = -1 And p.perks(perk.svenom) = -1 Then
            p.perks(perk.svenom) = 1
        End If
        p.ongoingTFs.add(New ArachneTF(p.perks(perk.svenom)))

        Game.pushLblEvent(out, AddressOf p.update)
    End Sub
End Class
