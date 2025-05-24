Public Class HexedSpelldabbler
    Inherits Monster

    Public Const BASE_NAME As String = "Hexed Spelldabbler"

    Dim firstMove = True
    Dim tfTarget As Player = Nothing

    Sub New()
        '|ID Info|
        name = BASE_NAME

        '|Stats|
        maxHealth = 80
        maxMana = 60
        attack = 8
        defense = 8
        speed = 10
        will = 20
        setupMonsterOnSpawn()

        '|Inventory|
        setInventory({1})

        '|Dialog Variables|
        pronoun = "she"
        p_pronoun = "her"
        r_pronoun = "her"

        '|Misc|
        intro_taunt = "Your foe wears the robes of a competent mage, despite " & p_pronoun & " vacant expression..."
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If Int(Rnd() * 7) = 0 Or mana < 2 Then
            TextEvent.push(DDUtils.capitalizeFirst(getNameWithTitle) & " giggles; pointing once at you, and then back towards " & p_pronoun & "self...")
            TextEvent.pushLog(DDUtils.capitalizeFirst(getNameWithTitle) & " skips " & p_pronoun & " turn.")
        ElseIf mana >= 25 And Not target.getPlayer Is Nothing And (firstMove Or Int(Rnd() * 3) = 0) Then
            castSelfPolymorph(target)
            mana -= 25
        ElseIf perks(npc_perk.tfdur) > 0 And mana >= 11 Then
            castRestoration()
            mana -= 11
        ElseIf (health < 0.3 And mana >= 2) Or mana < 4 Then
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " casts Heal!  +45% HP")
            health = Math.Min(1.0, health + 0.45)
            mana -= 2
        Else
            attackSpell(target, "Ditzzap", getWIL())
            mana -= 4
        End If

        firstMove = False
    End Sub

    Protected Sub castRestoration()
        If Int(Rnd() * 3) = 0 Then
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " casts Restoration!")
            revert()
        Else
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " casts Restoration... but it fails...")
        End If
    End Sub

    Protected Sub castSelfPolymorph(ByRef target As Player)
        If Int(Rnd() * 3) <> 0 Then
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " casts Self Polymorph - Goo Girl!")
            will = 0
            Polymorph.transform(Me, "Goo Girl")
        Else
            If getWIL() >= target.getWIL Then
                Polymorph.transform(target, "Goo Girl", True, False)
                TextEvent.fpushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " casts Self Polymorph... but it backfires!  You are turned into a Goo Girl for " & target.perks(perk.polymorphed) & " turns.")
            Else
                TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " casts Self Polymorph - Goo Girl... but it backfires, and you shrug it off.")
            End If
        End If
    End Sub

    Protected Sub castAuraOfPain(ByRef target As Player)
        If Int(Rnd() * 3) = 0 Then
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " casts Restoration!")
            revert()
        Else
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " casts Restoration... but it fails...")
        End If
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        despawn("p-death")

        p.changeForm("Frog")
        p.perks(perk.polymorphed) += 26

        TextEvent.push("You collapse, defeated." & DDUtils.RNRN &
                       """How foolish..."" the forgotten mage states, idly twirling her staff.  ""Hm.""" & DDUtils.RNRN &
                       "She levels it at your face, as you gaze up at her intimidating silhouette.  The staff's tip begins crackling with green energy, and she laughs." & DDUtils.RNRN &
                       """Let's give you a more fitting form...""", AddressOf p.drawPort)

        TextEvent.pushLog("The Archmage Recluse turns you into a frog for 25 turns!")
    End Sub
End Class
