Public Class TimeTravellerFight
    Inherits Boss
    Sub New()
        '|ID Info|
        name = "Time Traveler"

        '|Stats|
        maxHealth = 1300
        attack = 40
        defense = 40
        speed = 40
        will = 60
        xp_value = 5000

        '|Inventory|
        inv.setCount("AAAAAA_Battery", CInt(Int(Rnd() * 2000)) + 1)

        '|Dialog Variables|
        title = " "
        pronoun = "she"
        p_pronoun = "her"
        r_pronoun = "her"

        '|Misc|
        setupMonsterOnSpawn()

    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        Dim p = target.getPlayer()
        If target.getIntHealth < 5 Then
            despawn("arrest")

            If Not p Is Nothing Then
                p.savePState()

                p.defense = 20

                p.petrify(Color.FromArgb(255, 75, 209, 255), 9999)
                p.drawPort()
            End If


            TextEvent.push("The Time Traveler tosses a cryogrenade at you!")
            Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(42), "Alright, easy there.  Let's just put you on ice for a bit...", AddressOf OutOfTime.hostileArrest)
            Exit Sub
        End If


        '|Basic Attack|
        Dim dmg = Entity.calcDamage(getATK, target.getDEF)

        If dmg > target.getIntHealth Then dmg = target.getIntHealth - 1
        TextEvent.pushAndLog("The " & getName() & " fires a sleek chrome blaster!")
        target.takeDMG(dmg, Me)
    End Sub

    Public Overrides Sub reactToTF()
        If tfCt > 0 Then
            tfCt = 0
            revert()

            TextEvent.push("A rippling aura surrounds the time traveler..." & DDUtils.RNRN &
                              "The " & name & " return to " & p_pronoun & " original self!")
        End If
    End Sub

    Public Overrides Sub die(ByRef cause As Entity)
        MyBase.die(cause)

        Game.player1.quests(qInd.outOfTime).finishEarly()
    End Sub
End Class
