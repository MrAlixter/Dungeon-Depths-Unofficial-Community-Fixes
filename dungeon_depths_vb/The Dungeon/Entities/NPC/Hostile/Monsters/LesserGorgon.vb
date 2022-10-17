Public Class LesserGorgon
    Inherits Monster

    Public Const BASE_NAME As String = "Lesser Gorgon"

    Dim failed_stun As Boolean = False

    Sub New()
        '|ID Info|
        name = BASE_NAME

        '|Stats|
        maxHealth = 175
        attack = 40
        defense = 25
        speed = 30
        will = 20

        '|Inventory|
        Dim r1 As Integer = Int(Rnd() * 2500)
        inv.setCount("Gold", r1)

        Dim r2 As Integer = Int(Rnd() * 2)
        inv.setCount(VipersFang.ITEM_NAME, r2)

        Dim r3 As Integer = Int(Rnd() * 2)
        inv.setCount(ScaleBikini.ITEM_NAME, r3)

        Dim r4 As Integer = Int(Rnd() * 3)
        inv.setCount(SthenoSalve.ITEM_NAME, r4)

        '|Dialog Variables|
        pronoun = "she"
        p_pronoun = "her"
        r_pronoun = "her"

        '|Misc|
        setupMonsterOnSpawn()
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If target.getPlayer Is Nothing Then
            tailSwipe(target)
        Else
            If Not failed_stun And Not target.getPlayer.perks(perk.stunned) > 0 And Not target.getPlayer.perks(perk.astatue) > 0 Then
                charmingSnakes(target.getPlayer)
            ElseIf (target.getPlayer.perks(perk.stunned) > 0 Or (failed_stun And Int(Rnd() * 2))) And Not target.getPlayer.perks(perk.astatue) > 0 Then
                setInStone(target.getPlayer)
            Else
                tailSwipe(target)
            End If
        End If
    End Sub

    Public Sub charmingSnakes(ByRef target As Player)
        Dim out = DDUtils.capitalizeFirst(getNameWithTitle()) & "'s snake hair hisses, and each little pair of eyes starts strobing hypnotically..."
        If (target.getWIL >= getWIL()) Then
            TextEvent.push(out & DDUtils.RNRN & "...but you don't fall under their influence.")
            TextEvent.pushLog(DDUtils.capitalizeFirst(getNameWithTitle()) & " casts Charming Snakes, but it fails...")
            failed_stun = True
        Else
            TextEvent.push(out & DDUtils.RNRN & "The charm works, and you fall into a stunned trance!")
            TextEvent.pushLog(DDUtils.capitalizeFirst(getNameWithTitle()) & " casts Charming Snakes, stunning you for 1 turn!")
            target.perks(perk.stunned) = 2
            target.nextCombatAction = AddressOf PerkEffects.firstStun
        End If
    End Sub

    Public Sub setInStone(ByRef target As Player)
        TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle()) & " casts Set In Stone!  You are petrified for 2 turns...")
        target.petrify(Color.DarkGray, 3)
    End Sub

    Public Sub tailSwipe(ByRef target As Entity)
        TextEvent.pushAndLog("The " & getName() & " swipes with a tail!")
        Dim crit = If(Not target.getPlayer Is Nothing And target.getPlayer.perks(perk.astatue) > 0, 19, Int(Rnd() * 19)) 'roll for a critical
        Dim dmg = calcDamage(Me.getATK, target.getDEF) 'calculate the hit
        If dmg > 0 Then dmg += Int(Rnd() * 3) + -1 'adds some variance

        Select Case crit
            Case 19
                dealCritDMG(target, dmg * 2, Me)
            Case Else
                If target.getSPD <= 20 Then
                    If crit < 1 Then miss(target) Else hit(dmg, target)
                ElseIf target.getSPD <= 40 Then
                    If crit < 2 Then miss(target) Else hit(dmg, target)
                ElseIf target.getSPD <= 60 Then
                    If crit < 3 Then miss(target) Else hit(dmg, target)
                ElseIf target.getSPD <= 80 Then
                    If crit < 4 Then miss(target) Else hit(dmg, target)
                ElseIf target.getSPD <= 100 Then
                    If crit < 5 Then miss(target) Else hit(dmg, target)
                Else
                    Dim ebound = 5 + ((target.getSPD / 9999) * 5)
                    If ebound > 12 Then ebound = 12
                    If crit < ebound Then miss(target) Else hit(dmg, target)
                End If
        End Select
    End Sub
    Public Sub dealCritDMG(ByRef target As Entity, ByVal dmg As Integer, ByRef source As Entity)
        If PerkEffects.onDamage(target, dmg, True) Then Exit Sub

        Game.lblPHealtDiff.Tag -= dmg

        TextEvent.pushAndLog(CStr("You got hit!  Critical hit!  -" & dmg & " health!"))

        target.takeDMG(dmg, source)
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        Game.fromCombat()

        Equipment.clothesChange(p, "Naked")
        p.petrify(Color.LightGray, 30)


        If p.perks(perk.blind) > 0 Then
            TextEvent.push("The gorgon casts a supercharged Petrify!")
        Else
            TextEvent.push("The gorgon slithers around you, snaring your legs in the firm embrace of " & p_pronoun & " tail.  You close your eyes, trying to look away as your foe gently caresses your cheek." & DDUtils.RNRN &
                           "A few moments pass, and yet no final blow or tingle of spellcraft comes.  Any efforts to steady your racing heart fall apart as a silky voice whispers in your ear," & DDUtils.RNRN &
                           """Come on, I'm not going to bite... Aren't you even a little curious what I look like up close?""" & DDUtils.RNRN &
                           "You know you shouldn't, but you can't help but peek straight into the emerald gaze you know is waiting for you.  Before you can even regret your decison, your body turns to stone." & DDUtils.RNRN &
                           "As " & pronoun & " victoriously backs away from your statuesque figure, the gorgon takes in " & p_pronoun & " craft." & DDUtils.RNRN &
                           """Hmm, not my best work...""")
        End If
    End Sub
End Class
