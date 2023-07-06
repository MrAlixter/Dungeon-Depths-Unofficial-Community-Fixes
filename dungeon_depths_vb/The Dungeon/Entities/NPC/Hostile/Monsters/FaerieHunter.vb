Public Class FaerieHunter
    Inherits Monster

    Private Enum mode
        pink
        red
        amber
    End Enum

    Private cmode As mode = mode.pink
    Private stingEffect As Action

    Public Const BASE_NAME As String = "Fae Hunter"

    Sub New()
        Dim rng = Int(Rnd() * 2)

        '|ID Info|
        If rng = 0 Then
            name = BASE_NAME
        Else
            name = "Fae Huntress"
        End If

        '|Stats|
        maxHealth = 140
        attack = 35
        defense = 20
        speed = 10
        will = 20
        setupMonsterOnSpawn()

        '|Inventory| 
        Dim r As Boolean = Game.player1.passDieRoll(4, 1)
        inv.setCount(IronCollar.ITEM_NAME, If(r, 1, 0))

        '|Dialog Variables|
        If rng = 0 Then
            pronoun = "he"
            p_pronoun = "his"
            r_pronoun = "him"
        Else
            pronoun = "she"
            p_pronoun = "her"
            r_pronoun = "her"
        End If

        '|Misc|
        maxHealth *= 0.5
        attack *= 1.5
        defense *= 1.5
        speed *= 3.0
        will *= 0.33
        perks(npc_perk.tfdur) = 3
        form = "Bee Girl"
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If form = "" AndAlso (health > 0.75 OrElse Not Game.player1.passDieRoll(6, 1)) Then
            despawn("flee")
            Exit Sub
        End If

        If form.Equals("Bee Girl") Then
            If Not target.getPlayer Is Nothing AndAlso target.getPlayer.formName.Contains("Bee") Then
                despawn("friend")
                Exit Sub
            End If

            Randomize()
            If Int(Rnd() * 3) = 0 Or perks(npc_perk.firstturn) < 0 Then
                Select Case cmode
                    Case mode.red
                        TextEvent.pushAndLog("The Bee Girl's stinger ripples with a pink sheen!")
                        cmode = mode.pink
                        stingEffect = AddressOf pinkSting
                    Case mode.pink
                        TextEvent.pushAndLog("The Bee Girl's stinger ripples with a red sheen!")
                        cmode = mode.red
                        stingEffect = AddressOf redSting
                End Select
            End If

            sting(target)
        Else
            MyBase.attackCMD(target)
        End If

        If perks(npc_perk.firstturn) > 0 Then perks(npc_perk.firstturn) = -1
    End Sub

    Public Sub redSting()
        If currTarget Is Nothing OrElse currTarget.getPlayer Is Nothing OrElse Int(Rnd() * 2) = 0 Then Exit Sub

        Dim hp = New HazardousPotion()

        hp.textlessApply(currTarget.getPlayer)
    End Sub
    Public Sub pinkSting()

        If currTarget Is Nothing OrElse currTarget.getPlayer Is Nothing OrElse Int(Rnd() * 2) = 0 Then Exit Sub

        Dim dp = New DitzyPotion()

        dp.textlessApply(currTarget.getPlayer)
    End Sub

    Public Sub sting(ByRef target As Entity)
        TextEvent.push(DDUtils.capitalizeFirst(getNameWithTitle) & " swipes a stinger at you...")
        Dim crit = Int(Rnd() * 20) 'roll for a critical
        Dim dmg = calcDamage(Me.getATK / 5, target.getDEF) 'calculate the hit
        If dmg > 0 Then dmg += Int(Rnd() * 3) + -1 'adds some variance

        Select Case crit
            Case 19
                cHit(dmg, target)
                stingEffect()
            Case Else
                If target.getSPD <= 20 Then
                    If crit < 1 Then miss(target) Else hit(dmg, target) : stingEffect()
                ElseIf target.getSPD <= 40 Then
                    If crit < 2 Then miss(target) Else hit(dmg, target) : stingEffect()
                ElseIf target.getSPD <= 60 Then
                    If crit < 3 Then miss(target) Else hit(dmg, target) : stingEffect()
                ElseIf target.getSPD <= 80 Then
                    If crit < 4 Then miss(target) Else hit(dmg, target) : stingEffect()
                ElseIf target.getSPD <= 100 Then
                    If crit < 5 Then miss(target) Else hit(dmg, target) : stingEffect()
                Else
                    Dim ebound = 5 + ((target.getSPD / 9999) * 5)
                    If ebound > 12 Then ebound = 12
                    If crit < ebound Then miss(target) Else hit(dmg, target) : stingEffect()
                End If
        End Select
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        despawn("p-death")

        If form.Equals("Bee Girl") Then
            TextEvent.push("You collapse, defeated..." & DDUtils.RNRN &
                           "The bee girl buzzes closer, and " & p_pronoun & " stinger ripples with an amber sheen.  " & DDUtils.capitalizeFirst(p_pronoun) & " vacant smile never falters as " & p_pronoun & " stinger thrusts in one last time." & DDUtils.RNRN &
                           "With each beat of your heartbeat, you can feel yourself... changing.  A honey-colored aura washes outwards over you, reshaping your face and body until you look nearly the same as the insectress who stung you.  Two antennae spring fourth from your forehead, and suddenly a pulsing hum rings through your mind.  The more you think, the more intense the humming seems to get, so you try to just... relax..." & DDUtils.RNRN &
                           "Your wings beat twice in quick succession as you stare back at the other drone, an empty grin spreading across your face." & DDUtils.RNRN &
                           "You are now a Bee Girl!")

            BeeHoneyTF.fullTF(p)
        Else
            TextEvent.push("You collapse, defeated..." & DDUtils.PAKTC)
        End If
    End Sub
End Class
