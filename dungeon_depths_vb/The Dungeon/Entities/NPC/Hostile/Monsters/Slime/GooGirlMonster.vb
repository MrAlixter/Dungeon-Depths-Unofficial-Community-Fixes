Public Class GooGirlMonster
    Inherits Monster

    Public Shadows Const BASE_NAME As String = "Goo Girl"

    Sub New()
        '|ID Info|
        name = BASE_NAME

        '|Stats|
        maxHealth = 90
        attack = 30
        defense = 80
        speed = 14

        '|Inventory|
        setInventory({3, 136})

        '|Dialog Variables|
        pronoun = "she"
        p_pronoun = "her"
        r_pronoun = "her"

        '|Misc|
        setupMonsterOnSpawn()
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If Int(Rnd() * 4) = 0 And form = "" Then
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " extends a hand, firing off a barrage of slime!")

            Dim dmg = calcDamage(Me.getATK * 0.75, target.getDEF) 'calculate the hit
            If dmg > 0 Then dmg += Int(Rnd() * 3) + -1 'adds some variance

            hit(dmg, target)
            If dmg > 0 Then dmg += Int(Rnd() * 3) + -2 'adds some variance
            If Game.combat_engaged Then hit(dmg, target)
            If dmg > 0 Then dmg += Int(Rnd() * 3) + -1 'adds some variance
            If Game.combat_engaged Then hit(dmg, target)

            If target.health > 0 And Not target.getPlayer Is Nothing AndAlso Not target.getPlayer.equippedArmor.getAName.Equals("Naked") Then
                TextEvent.push("With a caustic hiss it evaporates, eating into your gear..." & DDUtils.RNRN &
                               Math.Max(target.getPlayer.equippedArmor.durability - 10, 0) & " durability remains on your " & target.getPlayer.equippedArmor.getAName.Replace("_", " ") & "...")
                If target.getPlayer.equippedArmor.durability > 10 Then
                    target.getPlayer.equippedArmor.damage(10)
                Else
                    target.getPlayer.equippedArmor.break()
                    target.getPlayer.drawPort()
                End If
            End If
        ElseIf health < 0.75 And Int(Rnd() * 2) = 0 Then
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " used Absorption!")

            Dim dmg = calcDamage(Me.getATK * 1.5, target.getDEF)
            hit(dmg, target)
            takeDMG(-dmg, Nothing)

            If health > 1.0 Then health = 1.0
        Else
            MyBase.attackCMD(target)
        End If
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        Dim out As String = "As " & getNameWithTitle() & " closes in, you push yourself off the ground and sidestep " & r_pronoun & "; making a hasty retreat." & DDUtils.RNRN &
                            "While your back is turned, " & getNameWithTitle() & " slings a glob of slime at you.  It splatters directly on your back, and the familiar tingle of magic washes over you..."

        despawn("p-death")

        If Not p.equippedArmor.getAName.Equals("Naked") Then
            p.perks(perk.googirltf) = 1
        ElseIf p.perks(perk.googirltf) = -1 Or p.prt.haircolor.A = 255 Then
            p.perks(perk.googirltf) = 2
        End If

        p.ongoingTFs.add(New GooGirlTF(p.perks(perk.googirltf)))
        TextEvent.push(out, AddressOf p.update)
    End Sub
End Class
