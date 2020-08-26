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

        levelDrainThres = 2
        lustRaiseThres = 33
        levelsToDrain = 1
        lustToIncrease = Int(Rnd() * 6) + 6

        setInventory({74, 194, 217})
        setupMonsterOnSpawn()
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If target.lust < lustRaiseThres And Int(Rnd() * 2) Then
            charm(target)
        Else
            If target.level > levelDrainThres Then
                sapLevel(target)
            Else
                MyBase.attackCMD(target)
            End If
        End If
    End Sub

    Public Overridable Sub sapLevel(ByRef t As Entity)
        If t.GetType Is GetType(Player) Then sapPlayer(CType(t, Player)) Else sapEntity(t)

        health *= 1.2
        maxHealth *= 1.2
        attack *= 1.2
        defense *= 1.2
        speed *= 1.2

        Game.pushLblEvent("The " & getName() & " used Drain Soul!  1 level drained!")
        Game.pushLstLog("The " & getName() & " used Drain Soul!  1 level drained!")
    End Sub

    Public Overridable Sub charm(ByRef t As Entity)
        If Int(Rnd() * t.will) < 15 Then
            t.lust += lustRaiseThres
            Game.pushLblEvent("The " & getName() & " used Charm!")
            Game.pushLstLog("The " & getName() & " used Charm!")
        Else
            Game.pushLblEvent("The " & getName() & " used Charm...but it fails...")
            Game.pushLstLog("The " & getName() & " used Charm...but it fails...")
        End If
    End Sub

    Public Overridable Sub sapPlayer(ByRef p As Player)
        p.deLevel(levelsToDrain)
    End Sub
    Public Overridable Sub sapEntity(ByRef e As Entity)
        e.maxHealth *= 0.8
        e.attack *= 0.8
        e.defense *= 0.8
        e.maxMana *= 0.8
        e.speed *= 0.8
        e.will *= 0.8
    End Sub
End Class
