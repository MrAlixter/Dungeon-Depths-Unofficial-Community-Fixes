Public Class ArchwitchRecluse
    Inherits Monster

    Public Const BASE_NAME As String = "Archwitch Recluse"

    Dim firstMove = True
    Dim tfTarget As Player = Nothing

    Sub New()
        '|ID Info|
        name = BASE_NAME

        '|Stats|
        maxHealth = 175
        maxMana = 77
        attack = 15
        defense = 22
        speed = 1
        will = 35
        setupMonsterOnSpawn()

        '|Inventory|
        setInventory({379, 381, 382, 383})

        '|Dialog Variables|
        pronoun = "she"
        p_pronoun = "her"
        r_pronoun = "her"

        '|Misc|

    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If tfEnd > 0 And mana >= 17 Then
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " casts Greater Restoration!")
            mana -= 17
            revert()
            Exit Sub
        ElseIf (health < 0.3 And mana >= 2) Or mana < 4 Then
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " casts Photosynth!  +50% HP")
            health = Math.Min(1.0, health + 0.5)
            mana -= 2
            Exit Sub
        ElseIf mana >= 25 Then
            thistleMissle(target)
            mana -= 25
            Exit Sub
        ElseIf mana >= 4 Then
            attackSpell(target, "Slitherslice", getWIL())
            mana -= 4
            Exit Sub
        End If

        attackSpell(target, "Twinkle Thorn", getWIL() * 0.75)
    End Sub

    Private Sub thistleMissle(ByRef target As Entity)
        TextEvent.pushAndLog(Trim(title & getName() & " casts Thistle Missle!"))

        Dim crit = Int(Rnd() * 20) 'roll for a critical
        Dim damage = getSpellDamage(target, getWIL() * 0.6) 'calculate the hit
        If damage > 0 Then damage += Int(Rnd() * 3) + -1 'adds some variance

        Select Case crit
            Case 19
                cHit(damage, target)
            Case Else
                If target.getSPD <= 20 Then
                    If crit < 1 Then miss(target) Else hit(damage, target)
                ElseIf target.getSPD <= 40 Then
                    If crit < 2 Then miss(target) Else hit(damage, target)
                ElseIf target.getSPD <= 60 Then
                    If crit < 3 Then miss(target) Else hit(damage, target)
                ElseIf target.getSPD <= 80 Then
                    If crit < 4 Then miss(target) Else hit(damage, target)
                ElseIf target.getSPD <= 100 Then
                    If crit < 5 Then miss(target) Else hit(damage, target)
                Else
                    Dim ebound = 5 + ((target.getSPD / 9999) * 5)
                    If ebound > 12 Then ebound = 12
                    If crit < ebound Then miss(target) Else hit(damage, target)
                End If
        End Select

        If target.health < 0.0 Then Exit Sub
        crit = Int(Rnd() * 20) 'roll for a critical
        damage = getSpellDamage(target, getWIL() * 0.6) 'calculate the hit
        If damage > 0 Then damage += Int(Rnd() * 3) + -1 'adds some variance

        Select Case crit
            Case 19
                cHit(damage, target)
            Case Else
                If target.getSPD <= 20 Then
                    If crit < 1 Then miss(target) Else hit(damage, target)
                ElseIf target.getSPD <= 40 Then
                    If crit < 2 Then miss(target) Else hit(damage, target)
                ElseIf target.getSPD <= 60 Then
                    If crit < 3 Then miss(target) Else hit(damage, target)
                ElseIf target.getSPD <= 80 Then
                    If crit < 4 Then miss(target) Else hit(damage, target)
                ElseIf target.getSPD <= 100 Then
                    If crit < 5 Then miss(target) Else hit(damage, target)
                Else
                    Dim ebound = 5 + ((target.getSPD / 9999) * 5)
                    If ebound > 12 Then ebound = 12
                    If crit < ebound Then miss(target) Else hit(damage, target)
                End If
        End Select
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
