Public Class SlimeMonster
    Inherits Monster
    Sub New()
        name = "Slime"
        maxHealth = 30
        attack = 15
        defense = 60
        speed = 6
        setInventory({2, 3})
        setupMonsterOnSpawn()
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If health < 0.75 And Int(Rnd() * 2) = 0 Then
            Game.pushLblCombatEvent("The " & getName() & " used Absortion!")
            Game.pushLstLog("The " & getName() & " used Absortion!")
            Dim dmg = calcDamage(Me.getATK * 1.5, target.getDEF)
            hit(dmg, target)
            takeDMG(-dmg, Nothing)
            If health > 1.0 Then health = 1.0
        Else
            MyBase.attackCMD(target)
        End If
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        'Author Credit: Marionette
        Dim out As String = "As the " & getName() & " closes in you push yourself off the ground, a burst of adrenaline pushing through your fatigue as you sidestep around it and beat a hasty retreat. While your back is turned to it, however, the " & getName() & " whips a ball of goo towards you, the impact causing you to stumble as the goo strikes your back. You can already feel it starting to writhe and squirm as it begins to move…"
        despawn("p-death")
        If p.perks(perk.slimetf) = -1 Then
            p.perks(perk.slimetf) = 1
        End If

        p.ongoingTFs.add(New SlimeETF(p.perks(perk.slimetf)))
        Game.pushLblEvent(out, AddressOf p.update)
    End Sub
End Class
