Public Class MarissaAS
    Inherits Monster
    Dim spellCooldown = 0
    Sub New()
        '|ID Info|
        name = "Marissa, Aspiring Sorceress"

        '|Stats|
        maxHealth = 115
        attack = 15
        defense = 5
        speed = 30
        will = 15
        xp_value = 75

        '|Inventory|
        inv.setCount("Spellbook", 1)
        inv.setCount("Restore_Potion", CInt(Rnd() * 2))
        inv.setCount("Mana_Charm", 1 + CInt(Rnd() * 2))
        inv.setCount("Witch_Cosplay", CInt(Rnd() * 2))

        '|Dialog Variables|
        title = " "
        pronoun = "she"
        p_pronoun = "her"
        r_pronoun = "her"

        '|Misc|
        setupMonsterOnSpawn(False)

    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If spellCooldown > 0 Then spellCooldown -= 1
        If target.GetType() Is GetType(Player) Then
            If spellCooldown < 1 And Not Game.player1.className.Equals("Bimbo") And (Int(Rnd() * 3) = 0 Or Game.noRNG) Then
                TextEvent.pushLog((getName() & " casts Bimbofy on you!"))
                TextEvent.pushCombat((getName() & " casts Bimbofy on you!"))
                Polymorph.transform(Game.player1, "MASBimbo")
                Game.player1.update()
            Else
                attackSpell(target, "a spark", getATK)
            End If
        Else
            attackSpell(target, "a spark", getATK)
        End If
    End Sub

    Public Overrides Sub die(ByRef cause As Entity)
        If isDead Then Exit Sub
        currTarget = Nothing
        nextCombatAction = Nothing

        Game.player1.clearTarget()
        cause.currTarget = Nothing
        cause.nextCombatAction = Nothing
        Game.drawBoard()

        'will update
        If Int(Rnd() * 8) < 2 Then
            TextEvent.pushLog("Your victory makes you feel more confident.")
            Game.player1.will += 1
            Game.player1.UIupdate()
        End If

        'cleanup of the monster
        isDead = True
        Game.fromCombat()
        Game.npc_list.Remove(Me)
        TextEvent.pushLog("You've defeated " & getName() & "!")

        'player transformation
        Dim lastsentence = "When your senses return to you, your ear's twitch and you notice that they have become feline.  A quick glance confirms that Marissa is no longer present, though it seems like here last ditch effort might have actually held some power after all..."
        If Game.player1.prt.checkFemInd(pInd.ears, 1) Or Game.player1.prt.checkMalInd(pInd.ears, 1) Then
            lastsentence = "When your senses return to you, a quick glance confirms that Marissa is no longer present."
        End If
        Game.player1.prt.setIAInd(pInd.ears, 1, True, False)
        Game.player1.drawPort()


        TextEvent.push("""D-d-damn it..."" Marissa sputters, taking a shakey step backwards.  ""It looks like I u-underestimated you, but r-rest assured that it won't happen again..."" she declares, before charging a weak looking ball of energy, ""T-this one's g-going to leave you a mewing m-m-mess.""\n" &
                          "She half heartedly casts the spell at you, and you easily turn to the side to dodge it.  As you turn back to face her with a glare, a blinding flash of light along with a deafening whine from somewhere behind you nearly knocks you to your feet.  Momentarily stunned, you lose track of your adversary as they fade silently into the milky white that has replaced your field of vision.  " &
                          lastsentence)

        Game.currFloor.beatBoss = True
    End Sub
    Public Overrides Sub playerDeath(ByRef p As Player)
        Dim mdtf = New MASBimboTF
        mdtf.step2()
    End Sub
End Class
