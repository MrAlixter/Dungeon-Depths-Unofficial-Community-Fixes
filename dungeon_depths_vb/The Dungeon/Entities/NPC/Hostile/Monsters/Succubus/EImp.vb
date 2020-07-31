Public Class EImp
    Inherits ESuccubus

    Sub New()
        name = "Imp"
        maxHealth = 33
        attack = 16
        defense = 33
        speed = 66

        levelDrainThres = 1
        lustRaiseThres = 100
        levelsToDrain = Int(Rnd() * 2)
        lustToIncrease = Int(Rnd() * 20) + 6

        setInventory({74, 168, 182, 194})
        setupMonsterOnSpawn()
    End Sub

    Public Overrides Sub sapLevel(ByRef t As Entity)
        If t.GetType Is GetType(Player) Then sapPlayer(CType(t, Player)) Else sapEntity(t)

        health *= 1.6
        maxHealth *= 1.6
        attack *= 1.6
        defense *= 1.6
        speed *= 1.6

        Game.pushLblEvent("The " & getName() & " used Drain Soul!  " & levelsToDrain & " level drained!")
        Game.pushLstLog("The " & getName() & " used Drain Soul!  " & levelsToDrain & " level drained!")
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
