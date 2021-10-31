Public Class ESuccPrincess
    Inherits ESuccubus
    Sub New()
        name = "Succubus Princess"

        maxHealth = 266
        attack = 99
        defense = 66
        speed = 666
        will = 69

        levelDrainThres = 2
        lustRaiseThres = 66
        levelsToDrain = 2
        lustToIncrease = Int(Rnd() * 6) + 6

        setInventory({25, 74, 168, 194, 182, 205, 214, 218, 226, 227})
        setupMonsterOnSpawn()
    End Sub

    Public Overrides Sub die(ByRef cause As Entity)
        If cause.GetType() Is GetType(Player) Then
            Dim p = CType(cause, Player)

            If p.perks(perk.cynnsq1ct1) > -1 Then p.perks(perk.cynnsq1ct1) += 1

            If p.perks(perk.succubuscurse) > -1 Then

                Dim isPTFed = p.perks(perk.succubuscurse) > 0

                p.perks(perk.succubuscurse) = -1

                TextEvent.pushLog("The succubus's curse is lifted!")
                TextEvent.push(If(isPTFed, "The succubus's curse is lifted!  However, this does not revert your transformation...", "The succubus's curse is lifted!"))
            End If
        End If

        MyBase.die(cause)
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        Dim r = Int(Rnd() * 10)

        If r = 0 And target.GetType Is GetType(Player) AndAlso CType(target, Player).perks(perk.succubuscurse) = -1 AndAlso CType(target, Player).perks(perk.succubuscow) = -1 Then
            Dim p = CType(target, Player)
            TextEvent.push("The " & getName() & " casts Curse of the Slut!")
            p.perks(perk.succubuscurse) = 0
            p.dembimState1.save(p)
            p.dembimState2.save(p)
            Exit Sub
        End If

        If ((r = 1 And target.GetType Is GetType(Player)) AndAlso CType(target, Player).perks(perk.succubuscurse) = -1 And Not CType(target, Player).className.Equals("Bimbo") And Not CType(target, Player).formName.Equals("Succubus")) OrElse (target.GetType Is GetType(Player) AndAlso CType(target, Player).perks(perk.succubuscow) <> -1) Then
            TextEvent.push("The " & getName() & " casts ""Moo for Me!""")
            If CType(target, Player).perks(perk.succubuscow) = -1 Then CType(target, Player).perks(perk.succubuscow) = 1 Else CType(target, Player).perks(perk.succubuscow) += 1
            MinoDTF.tfPlayer(CType(target, Player).perks(perk.succubuscow), CType(target, Player))
            Exit Sub
        End If

        If r = 2 And target.GetType Is GetType(Player) AndAlso CType(target, Player).dickSize < 3 Then
            TextEvent.push("The " & getName() & " casts Stand at Attention!  Your dick tingles warmly!")

            Dim p = CType(target, Player)
            p.de()
            p.addLust(33)

            Exit Sub
        End If

        MyBase.attackCMD(target)
    End Sub

    Public Overrides Sub sapLevel(ByRef t As Entity)
        If t.GetType Is GetType(Player) Then sapPlayer(CType(t, Player)) Else sapEntity(t)

        maxHealth *= 1.2
        attack *= 1.2
        defense *= 1.2
        speed *= 1.2

        TextEvent.push("The " & getName() & " used Drain Soul!  " & levelsToDrain & " levels drained!")
        TextEvent.pushLog("The " & getName() & " used Drain Soul!  " & levelsToDrain & " levels drained!")
    End Sub

    Public Overrides Sub charm(ByRef t As Entity)
        If Int(Rnd() * t.will) < 15 Then
            t.addLust(lustRaiseThres)
            TextEvent.push("The " & getName() & " used Charm!")
            TextEvent.pushLog("The " & getName() & " used Charm!")
        Else
            TextEvent.push("The " & getName() & " used Charm...but it fails...")
            TextEvent.pushLog("The " & getName() & " used Charm...but it fails...")
        End If
    End Sub

    Public Overrides Sub sapPlayer(ByRef p As Player)
        p.deLevel(levelsToDrain)
    End Sub
    Public Overrides Sub sapEntity(ByRef e As Entity)
        e.maxHealth *= 0.8
        e.attack *= 0.8
        e.defense *= 0.8
        e.maxMana *= 0.8
        e.speed *= 0.8
        e.will *= 0.8
    End Sub
End Class
