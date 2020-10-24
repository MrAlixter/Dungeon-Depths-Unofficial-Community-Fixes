Public Class ESuccubus
    Inherits Monster

    Protected levelDrainThres, lustRaiseThres As Integer
    Protected levelsToDrain, lustToIncrease As Integer

    Sub New()
        name = "Succubus"
        maxHealth = 66
        attack = 33
        defense = 66
        speed = 33
        will = 40

        levelDrainThres = 3
        lustRaiseThres = 33
        levelsToDrain = 1
        lustToIncrease = Int(Rnd() * 6) + 6

        setInventory({74, 194, 217, 226, 227})
        setupMonsterOnSpawn()


        If Int(Rnd() * 4) = -1 Then
            name = "Charming Succubus"
        End If
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If target.lust < lustRaiseThres And Int(Rnd() * 3) = 0 Then
            charm(target)
        Else
            If levelDrainThres > 0 And levelsToDrain > 0 And target.level > 2 And target.level - levelDrainThres >= 1 And Int(Rnd() * 4) = 0 Then
                sapLevel(target)
            Else
                MyBase.attackCMD(target)
            End If
        End If
    End Sub

    Public Overridable Sub sapLevel(ByRef t As Entity)
        If t.GetType Is GetType(Player) Then sapPlayer(CType(t, Player)) Else sapEntity(t)

        maxHealth *= 1.2
        attack *= 1.2
        defense *= 1.2
        speed *= 1.2

    End Sub
    Private Function playerHadCharmsReverted(ByRef p As Player)
        Select Case Int(Rnd() * 6)
            Case 0
                If p.perks(perk.hcharmsused) > 0 Then
                    p.perks(perk.hcharmsused) -= 1
                    p.maxHealth -= 10
                    Return True
                End If
            Case 1
                If p.perks(perk.mcharmsused) > 0 Then
                    p.perks(perk.mcharmsused) -= 1
                    p.maxMana -= 5
                    Return True
                End If
            Case 2
                If p.perks(perk.acharmsused) > 0 Then
                    p.perks(perk.acharmsused) -= 1
                    p.attack -= 5
                    Return True
                End If
            Case 3
                If p.perks(perk.dcharmsused) > 0 Then
                    p.perks(perk.dcharmsused) -= 1
                    p.defense -= 5
                    Return True
                End If
            Case 4
                If p.perks(perk.scharmsused) > 0 Then
                    p.perks(perk.scharmsused) -= 1
                    p.speed -= 5
                    Return True
                End If
            Case 5
                If p.perks(perk.wcharmsused) > 0 Then
                    p.perks(perk.wcharmsused) -= 1
                    p.will -= 5
                    Return True
                End If
        End Select

        Return False
    End Function
    Private Function totalCharms(ByRef p As Player)
        Return p.perks(perk.hcharmsused) + p.perks(perk.mcharmsused) + p.perks(perk.acharmsused) + p.perks(perk.dcharmsused) + p.perks(perk.scharmsused) + p.perks(perk.wcharmsused)
    End Function

    Public Overridable Sub charm(ByRef t As Entity)
        If Int(Rnd() * t.will) < 15 Then
            t.addLust(lustRaiseThres)
            Game.pushLblEvent("The " & getName() & " used Charm!")
            Game.pushLstLog("The " & getName() & " used Charm!")
        Else
            Game.pushLblEvent("The " & getName() & " used Charm...but it fails...")
            Game.pushLstLog("The " & getName() & " used Charm...but it fails...")
        End If
    End Sub

    Public Overridable Sub sapPlayer(ByRef p As Player)
        If name.Contains("Charming") Then
            If totalCharms(p) < 3 And Not Int(Rnd() * totalCharms(p) / 2) = 0 AndAlso playerHadCharmsReverted(p) Then
                Game.pushLblEvent("The " & getName() & " used Drain Charm!  1 charm removed!")
                Game.pushLstLog("The " & getName() & " used Drain Charm!  1 charm removed!")
            End If
        Else
            p.deLevel(levelsToDrain)
            Game.pushLblEvent("The " & getName() & " used Drain Soul!  1 level drained!")
            Game.pushLstLog("The " & getName() & " used Drain Soul!  1 level drained!")
        End If
    End Sub
    Public Overridable Sub sapEntity(ByRef e As Entity)
        e.maxHealth *= 0.8
        e.attack *= 0.8
        e.defense *= 0.8
        e.maxMana *= 0.8
        e.speed *= 0.8
        e.will *= 0.8
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        despawn("p-death")

        Game.pushLblEvent("You black out..." & DDUtils.RNRN &
                        "-1 level!")
        Game.pushLstLog("You black out...")

        p.deLevel(1)
        p.addLust(-p.lust)
    End Sub
End Class
