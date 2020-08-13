Public Class ESuccPrincess
    Inherits ESuccubus
    Sub New()
        name = "Succubus Princess"

        maxHealth = 266
        attack = 99
        defense = 66
        speed = 66

        levelDrainThres = 1
        lustRaiseThres = 66
        levelsToDrain = 2
        lustToIncrease = Int(Rnd() * 6) + 6

        setInventory({25, 74, 168, 194, 182, 205, 214, 218})
        setupMonsterOnSpawn()
    End Sub

    Public Overrides Sub sapLevel(ByRef t As Entity)
        If t.GetType Is GetType(Player) Then sapPlayer(CType(t, Player)) Else sapEntity(t)

        health *= 1.2
        maxHealth *= 1.2
        attack *= 1.2
        defense *= 1.2
        speed *= 1.2

        Game.pushLblEvent("The " & getName() & " used Drain Soul!  1 level drained!")
        Game.pushLstLog("The " & getName() & " used Drain Soul!  1 level drained!")
    End Sub

    Public Overrides Sub charm(ByRef t As Entity)
        If Int(Rnd() * t.will) < 15 Then
            t.lust += lustRaiseThres
            Game.pushLblEvent("The " & getName() & " used Charm!")
            Game.pushLstLog("The " & getName() & " used Charm!")
        Else
            Game.pushLblEvent("The " & getName() & " used Charm...but it fails...")
            Game.pushLstLog("The " & getName() & " used Charm...but it fails...")
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
