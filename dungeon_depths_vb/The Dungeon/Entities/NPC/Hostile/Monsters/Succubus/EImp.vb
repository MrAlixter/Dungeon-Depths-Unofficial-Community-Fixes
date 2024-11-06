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

    Public Overrides Sub playerDeath(ByRef p As Player)
        despawn("p-death")

        Dim p1 As Player = p

        TextEvent.fpush(DDUtils.capitalizeFirst(getNameWithTitle) & " cackles as you collapse, defeated." & DDUtils.RNRN &
                        """Wow, you sure didn't put up much of a fight.  Really know how to make an imp feel special, yeah?""" & DDUtils.RNRN &
                        DDUtils.capitalizeFirst(pronoun) & " looks to your belongings, with a cocky grin.  ""Now, let's see if you've got anything good on ya...""", Sub() playerDeathP2(p1))
    End Sub

    Public Sub playerDeathP2(ByRef p As Player)
        'turn vial of slime into pink slime, cover the player in it
        'turn any stick of gum into cinnimon stick of gum
        'turn cowbell/bimbell into ring of the cow
        Dim out As String = "Eh... so what's this here?" & DDUtils.RNRN
        If GumGun20mm.getSelectedGum(p).count > 0 Then

            GumGun20mm.getSelectedGum(p).add(-1)

            p.ongoingTFs.add(New CinnamonBimboTF(2, 5, 0.25, True))
            p.perks(perk.bimbotf) = 0
        Else
            out += "Or should I say- why isn't there anything in here?  "

            CinnamonBimboTF.impTFPlayer2(p)
        End If

    End Sub
End Class
