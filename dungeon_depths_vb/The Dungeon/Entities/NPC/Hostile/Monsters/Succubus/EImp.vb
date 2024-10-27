Public Class EImp
    Inherits ESuccubus

    Public Shadows Const BASE_NAME As String = "Imp"

    Sub New()
        '|ID Info|
        name = BASE_NAME

        '|Stats|
        maxHealth = 33
        attack = 16
        defense = 33
        speed = 66
        will = 13

        levelDrainThres = 2
        lustRaiseThres = 100
        levelsToDrain = Int(Rnd() * 2)
        lustToIncrease = Int(Rnd() * 20) + 6

        '|Inventory|
        setInventory({74, 168, 182, 194, 227, 451})

        '|Dialog Variables|

        '|Misc|
        setupMonsterOnSpawn()
    End Sub

    Public Overrides Sub sapLevel(ByRef t As Entity)
        If Not t.getPlayer Is Nothing Then sapPlayer(t.getPlayer) Else sapEntity(t)

        maxHealth *= 1.6
        attack *= 1.6
        defense *= 1.6
        speed *= 1.6

        TextEvent.push("The " & getName() & " used Drain Soul!  " & levelsToDrain & " levels drained!")
        TextEvent.pushLog("The " & getName() & " used Drain Soul!  " & levelsToDrain & " levels drained!")
    End Sub

    Public Overrides Sub sapPlayer(ByRef p As Player)
        drainedXP += p.deLevel(levelsToDrain)
        If Not explainedDrain Then TextEvent.pushAndLog("Defeat " & getNameWithTitle() & " to regain your lost XP!") : explainedDrain = True
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
