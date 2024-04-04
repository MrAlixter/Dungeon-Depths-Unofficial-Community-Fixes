Public Class BimboGorgon
    Inherits Monster

    Public Const BASE_NAME As String = "Gorgon Fashionista"

    Dim failed_stun As Boolean = False

    Sub New()
        '|ID Info|
        name = BASE_NAME

        '|Stats|
        maxHealth = 175
        attack = 20
        defense = 15
        speed = 20
        will = 20
        setupMonsterOnSpawn()

        '|Inventory|
        Dim r1 As Integer = Int(Rnd() * 3000) + 1000
        inv.setCount("Gold", r1)

        Dim r2 As Integer = Int(Rnd() * 2)
        inv.setCount(ScaleBikini.ITEM_NAME, r2)

        Dim r3 As Integer = Int(Rnd() * 3)
        inv.setCount(SthenoSalve.ITEM_NAME, r3)

        '|Dialog Variables|
        pronoun = "she"
        p_pronoun = "her"
        r_pronoun = "her"

        '|Misc|

    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If target.getPlayer Is Nothing Then
            tailSwipe(target)
        Else
            If Not failed_stun And Not target.getPlayer.perks(perk.stunned) > 0 And Not target.getPlayer.perks(perk.astatue) > 0 Then
                charmingSnakes(target.getPlayer)
            ElseIf (target.getPlayer.perks(perk.stunned) > 0 Or (failed_stun And Int(Rnd() * 2))) And Not target.getPlayer.perks(perk.astatue) > 0 Then
                setInStone(target.getPlayer)
            ElseIf Int(Rnd() * 3) = 0 Then
                If target.getPlayer.equippedArmor.getAName.Equals("Naked") Then

                Else
                    TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle()) & " eyes you up, focusing on the fit of your gear...")
                End If
            Else
                tailSwipe(target)
            End If
        End If
    End Sub

    Public Sub charmingSnakes(ByRef target As Player)
        Dim out = DDUtils.capitalizeFirst(getNameWithTitle()) & "'s snake hair hisses, and each little pair of eyes starts strobing hypnotically..."
        If Int(Rnd() * 3) = 0 Then
            TextEvent.push(out & DDUtils.RNRN & "...but the snakes seem to be looking elsewhere.")
            TextEvent.pushLog(DDUtils.capitalizeFirst(getNameWithTitle()) & " casts Charming Snakes, but it fails...")
        ElseIf (target.getWIL >= getWIL()) And Not target.perks(perk.blind) > -1 Then
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
        TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle()) & " casts Strike a Pose!  You are petrified for 2 turns...")
        target.petrify(Color.LightGray, 3)
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


        TextEvent.pushLog("The gorgon casts a supercharged Petrify!")
        TextEvent.push("The gorgon slithers around you, snaring your legs in the firm embrace of " & p_pronoun & " tail.  You close your eyes, trying to look away as your foe gently caresses your cheek." & DDUtils.RNRN &
                       "A few moments pass, and yet no final blow or tingle of spellcraft comes.  Any efforts to steady your racing heart fall apart as a silky voice whispers in your ear," & DDUtils.RNRN &
                       """Like... Come on, I'm totally not going to bite...  Don't you wanna see me up close?""" & DDUtils.RNRN &
                       "You know you shouldn't, but you can't help but peek straight into the emerald gaze you know is waiting for you.  Before you can even regret your decison, your body turns to stone." & DDUtils.RNRN &
                       "As " & pronoun & " victoriously backs away from your statuesque figure, the gorgon takes in " & p_pronoun & " craft." & DDUtils.RNRN &
                       """Hmm, I don't know if you'll do...""", AddressOf playerDeath2)
    End Sub

    Public Sub playerDeath2()
        Dim p As Player = Game.player1

        If p.breastSize = 2 Then
            p.breastSize = 3
        Else
            p.breastSize = 2
        End If

        If p.buttSize = 3 Then
            p.buttSize = 4
        Else
            p.buttSize = 3
        End If

        p.prt.setIAInd(pInd.rearhair, New Tuple(Of Integer, Boolean, Boolean)(20, True, True))
        p.prt.changeHairColor(Color.MistyRose)

        Select Case Int(Rnd() * 3)
            Case 0
                'MistwarpedClothes
            Case 1
                'NotColdWeatherGarb
            Case Else
                If p.breastSize >= 3 Then
                    'GothOutfit
                Else
                    'GShowgirlOutfit
                End If
        End Select

        p.drawPort()
    End Sub
End Class
