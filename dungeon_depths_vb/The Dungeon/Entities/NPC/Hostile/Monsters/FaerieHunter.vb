Public Class FaerieHunter
    Inherits Monster

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
        setupMonsterOnSpawn()

        maxHealth *= 0.5
        attack *= 1.5
        defense *= 1.5
        speed *= 3.0
        will *= 0.33
        tfEnd = 3
        tfCt = 1
        form = "Bee Girl"
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If form = "" AndAlso (health > 0.75 OrElse Not Game.player1.passDieRoll(6, 1)) Then
            despawn("flee")
        End If

        If form.Equals("Bee Girl") Then
            MyBase.attackCMD(target)
        Else
            MyBase.attackCMD(target)
        End If
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        despawn("p-death")

        If form.Equals("Bee Girl") Then
            TextEvent.push("You collapse, defeated..." & DDUtils.RNRN &
                           "The bee girl approaches, and charges her stinger with amber light." & DDUtils.RNRN &
                           "You are now a Bee Girl!")

            BeeHoneyTF.fullTF(p)
        Else
            TextEvent.push("You collapse, defeated..." & DDUtils.PAKTC)
        End If
    End Sub
End Class
