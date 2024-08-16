Public Class RosethrallDragon
    Inherits MiniBoss

    Dim combatCounter As Integer

    Sub New()
        '|ID Info|
        name = "Rosethrall Dragon"

        '|Stats|
        maxHealth = 266
        attack = 52
        defense = 32
        speed = 15
        will = -10
        xp_value = 1000
        setupMonsterOnSpawn()

        '|Inventory|
        inv.setCount(OmniCharm.ITEM_NAME, 1)
        inv.setCount(CrackedPinkOrb.ITEM_NAME, 1)
        inv.setCount("Gold", 10000)
        'random drops
        Dim possible_drops = {"Combat_Manual", "Warrior's_Cuirass", "Attack_Charm"}
        Dim number_of_drops = Int(Rnd() * 2) + Int(Rnd() * 2) + 1
        For i = 0 To number_of_drops
            Dim r = Int(Rnd() * (possible_drops.Count))
            inv.setCount(possible_drops(r), 1)
        Next

        '|Dialog Variables|
        title = " the "
        pronoun = "she"
        p_pronoun = "her"
        r_pronoun = "her"

        '|Misc|
        combatCounter = 0
        intro_taunt = """..."""
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If Not target.getPlayer Is Nothing AndAlso target.getPlayer.className.Equals("Mindless Bimbo") Then playerDeath(target.getPlayer)

        If combatCounter = 0 Or (perks(npc_perk.flying) < 0 And Int(Rnd() * 5) = 0) Then
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " takes to the sky!")
            perks(npc_perk.flying) = 2
        ElseIf 1 = 1 Then 'Int(Rnd() * 3) = 0 Then
            'puff of mist
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " breathes out a thick plume of the pink mist!")

            If Not target.getPlayer Is Nothing Then
                Dim p As Player = target.getPlayer

                If Not p.ongoingTFs.contains(tfind.mistbimbo) Then
                    p.ongoingTFs.add(New MistBimboTF(10, 13, 0.25, True))
                    p.perks(perk.bimbotf) = 0
                End If

                If p.ongoingTFs.getAt(tfind.mistbimbo).getCurrStep < 2 Then
                    p.changeHairColor(MistBimboTF.bimbopink1)
                    TextEvent.fpush("Your hair color brightens to a rosy pink.")
                    p.ongoingTFs.getAt(tfind.mistbimbo).setCurrStep(1)
                End If

                p.ongoingTFs.getAt(tfind.mistbimbo).update_during_combat = True
                p.ongoingTFs.getAt(tfind.mistbimbo).setTurnsTilStep(0)
                p.ongoingTFs.getAt(tfind.mistbimbo).update()
                p.ongoingTFs.getAt(tfind.mistbimbo).update_during_combat = False

                p.UIupdate()
                p.drawPort()
            End If

        ElseIf health < 0.3 Then
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " breathes out a jet of scarlet flame!")

            Dim damage = getSpellDamage(target, getATK() * 1.1) 'calculate the hit
            If damage > 0 Then damage += Int(Rnd() * 3) + -1 'adds some variance

            If Not Game.player1.passDieRoll(8, 3) Then hit(damage, target) Else miss(target)
        Else
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " slashes with " & p_pronoun & " claws!")
            MyBase.attackCMD(target)
        End If

        combatCounter += 1
    End Sub

    Public Overrides Sub die(ByRef cause As Entity)
        MyBase.die(cause)

        Game.currFloor.cleanupPinkMist()
        TextEvent.pushLog("You pick up the cracked orb, and the strange mist subsides!")
        Game.last_tile = Nothing
    End Sub
End Class
