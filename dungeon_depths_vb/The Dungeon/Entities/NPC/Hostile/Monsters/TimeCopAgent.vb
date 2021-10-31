Public Class TimeCopAgent
    Inherits Monster
    Sub New()
        name = "Time Cop"
        maxHealth = 135
        attack = 35
        defense = 35
        speed = 35
        will = 35

        setInventory({128, 128, 274, 261})

        If Game.currFloor.floorNumber <> 10000 Then
            setupMonsterOnSpawn()
        Else
            maxHealth *= 3.0
            attack *= 3.0
            defense *= 3.0
            speed *= 3.0
            will = Math.Max(1, will) * 3.0

            xp_value = (maxHealth + attack + defense + speed) / 4

            health = 1.0

            title = " The "
            sName = name
            sMaxHealth = maxHealth
            sMaxMana = maxMana
            sAttack = attack
            sdefense = defense
            sWill = will
            sSpeed = speed

            If Game.player1.perks(perk.lurk) > 0 Then stunct = 0 : isStunned = True

            If speed = Game.player1.getSPD Then speed -= 1
            pos = Game.player1.pos
        End If

    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        '|Basic Attack|
        Dim dmg = Entity.calcDamage(getATK, ((target.getDEF + target.getWIL) / 2))

        TextEvent.pushAndLog("The " & getName() & " fires a sleek chrome rifle!")
        target.takeDMG(dmg, Me)
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        TextEvent.pushLog("The Time Cop tosses a cryogrenade at you!")
        p.petrify(Color.FromArgb(255, 75, 209, 255), 9999)
        p.drawPort()

        TextEvent.push("The Time Cop relaxes, staring at your frozen body." & DDUtils.RNRN &
                          """I got " & If(p.sex = "Male", "him", "her") & ", I GOT " & If(p.sex = "Male", "HIM", "HER") & "!"", they exclaim into their communicatior." & DDUtils.RNRN &
                          "Before long, two more agents show up and the group hastily opens a portal to a familiar cell.  The group then rotates you horizontally, and begins carrying you towards the rift before..." & DDUtils.RNRN &
                          "CRASH!!!" & DDUtils.RNRN &
                          "Your feet slip out of one of the agent's hands, and your frozen body shatters on the floor." & DDUtils.RNRN &
                          """Uhhh... whoops...""" & DDUtils.RNRN & DDUtils.RNRN & "GAME OVER!", AddressOf p.die)
    End Sub
End Class
