Public Class PBeegirl
    Inherits PolymorphedNPC

    Private Enum mode
        pink
        red
        amber
    End Enum

    Private cmode As mode = mode.pink
    Private stingEffect As Action

    Public Sub New(ByRef e As NPC, ByRef p As Player, ByVal duration As Integer)
        MyBase.New(e, p, duration)
    End Sub

    Overrides Function getHPModifier() As Double
        Return 0.5
    End Function
    Overrides Function getATKModifier() As Double
        Return 1.5
    End Function
    Overrides Function getDEFModifier() As Double
        Return 0.33
    End Function
    Overrides Function getSPDModifier() As Double
        Return 3.0
    End Function
    Overrides Function getWILModifier() As Double
        Return 0.33
    End Function

    Public Overrides Function getFormName() As String
        Return "Bee-Girl"
    End Function

    Public Overrides Sub newAttackCMD(ByRef target As Entity)
        If Int(Rnd() * 3) = 0 Or perks(npc_perk.firstturn) < 0 Then
            Select Case cmode
                Case mode.red
                    TextEvent.pushAndLog("The Bee Girl's stinger ripples with a pink sheen!")
                    cmode = mode.pink
                    stingEffect = AddressOf pinkSting
                Case mode.pink
                    TextEvent.pushAndLog("The Bee Girl's stinger ripples with a red sheen!")
                    cmode = mode.red
                    stingEffect = AddressOf redSting
            End Select
        End If

        sting(target)
    End Sub

    Public Sub redSting()
        If currTarget Is Nothing OrElse currTarget.getPlayer Is Nothing OrElse Int(Rnd() * 2) = 0 Then Exit Sub

        Dim hp = New HazardousPotion()

        hp.textlessApply(currTarget.getPlayer)
    End Sub
    Public Sub pinkSting()

        If currTarget Is Nothing OrElse currTarget.getPlayer Is Nothing OrElse Int(Rnd() * 2) = 0 Then Exit Sub

        Dim dp = New DitzyPotion()

        dp.textlessApply(currTarget.getPlayer)
    End Sub

    Public Sub sting(ByRef target As Entity)
        TextEvent.push(DDUtils.capitalizeFirst(getNameWithTitle) & " swipes a stinger at you...")
        Dim crit = Int(Rnd() * 20) 'roll for a critical
        Dim dmg = calcDamage(Me.getATK / 5, target.getDEF) 'calculate the hit
        If dmg > 0 Then dmg += Int(Rnd() * 3) + -1 'adds some variance

        Select Case crit
            Case 19
                cHit(dmg, target)
                stingEffect()
            Case Else
                If target.getSPD <= 20 Then
                    If crit < 1 Then miss(target) Else hit(dmg, target) : stingEffect()
                ElseIf target.getSPD <= 40 Then
                    If crit < 2 Then miss(target) Else hit(dmg, target) : stingEffect()
                ElseIf target.getSPD <= 60 Then
                    If crit < 3 Then miss(target) Else hit(dmg, target) : stingEffect()
                ElseIf target.getSPD <= 80 Then
                    If crit < 4 Then miss(target) Else hit(dmg, target) : stingEffect()
                ElseIf target.getSPD <= 100 Then
                    If crit < 5 Then miss(target) Else hit(dmg, target) : stingEffect()
                Else
                    Dim ebound = 5 + ((target.getSPD / 9999) * 5)
                    If ebound > 12 Then ebound = 12
                    If crit < ebound Then miss(target) Else hit(dmg, target) : stingEffect()
                End If
        End Select
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        despawn("p-death")

        TextEvent.push("You collapse, defeated..." & DDUtils.RNRN &
                       "The bee girl buzzes closer, and " & p_pronoun & " stinger ripples with an amber sheen.  " & DDUtils.capitalizeFirst(p_pronoun) & " vacant smile never falters as " & p_pronoun & " stinger thrusts in one last time." & DDUtils.RNRN &
                       "With each beat of your heartbeat, you can feel yourself... changing.  A honey-colored aura washes outwards over you, reshaping your face and body until you look nearly the same as the insectress who stung you.  Two antennae spring fourth from your forehead, and suddenly a pulsing hum rings through your mind.  The more you think, the more intense the humming seems to get, so you try to just... relax..." & DDUtils.RNRN &
                       "Your wings beat twice in quick succession as you stare back at the other drone, an empty grin spreading across your face." & DDUtils.RNRN &
                       "You are now a Bee Girl!")

        BeeHoneyTF.fullTF(p)
    End Sub
End Class
