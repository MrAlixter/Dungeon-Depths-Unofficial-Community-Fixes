Public Class TarFoodVend
    Inherits Boss

    'shhhh... this isn't ready yet

    Private Enum phase
        phase1
        phase2
        phase3
        phase4
    End Enum
    Private Enum p_weakness
        def
        will
    End Enum

    Private curr_phase As phase = phase.phase1
    Private identified_weakness As p_weakness = p_weakness.def
    Private combat_turn As Integer = 0
    Private dodgeing As Integer = False

    Sub New()
        '|ID Info|
        name = "Targax, The Food Vendor"

        '|Stats|
        maxHealth = 400
        attack = 400
        defense = 250
        speed = 700
        will = 250
        xp_value = 70000
        setupMonsterOnSpawn()

        '|Inventory|
        inv.setCount("Omni_Charm", 1)
        inv.setCount("Portal_Chalk", 1)
        inv.setCount("Tavern_Special", 1)

        '|Dialog Variables|
        title = " "
        pronoun = "he"
        p_pronoun = "his"
        r_pronoun = "him"
        intro_taunt = """So... you've come to reclaim the sword?"""

        '|Misc|

    End Sub

    Public Overrides Sub update()
        If curr_phase = phase.phase1 And health <= 0.9 Then
            phaseChange1()
            Exit Sub
        ElseIf curr_phase = phase.phase2 And health <= 0.5 Then
            phaseChange2()
            Exit Sub
        ElseIf curr_phase = phase.phase3 And health <= 0.1 Then
            phaseChange3()
            Exit Sub
        End If

        dodgeing = False

        MyBase.update()
    End Sub

    Public Overrides Function takeDMG(ByRef dmg As Integer, ByRef source As Entity) As Boolean
        If dodgeing Then
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " deftly avoids the attack!")

            Return False
        End If

        Dim took_dmg = MyBase.takeDMG(dmg, source)

        Return took_dmg
    End Function

    '| -- COMBAT -- |
    Public Overrides Sub attackCMD(ByRef target As Entity)
        Select Case curr_phase
            Case phase.phase1
                MyBase.attackCMD(target)
            Case phase.phase2
                phase2Attack(target)
            Case phase.phase3

            Case phase.phase4

        End Select

        combat_turn += 1
    End Sub
    Public Overrides Function reactToSpell(spell As String) As Boolean
        If spell.Contains("Petrify") Or spell.Contains("Turn to") Or spell.Equals("Medusa's Gaze") Then
            TextEvent.push("The spell bends off-target and strikes the ground!")
            Return False
        ElseIf spell.Equals("Polymorph Enemy") Then
            Dim pe = New EnemyPolymorph(Game.player1, Nothing)
            TextEvent.push(DDUtils.capitalizeFirst(getNameWithTitle) & " parries your spell, bouncing a copy back at you!")
            pe.backfire()
            Return False
        ElseIf spell.Equals("Uvona's Fugue") Then
            Dim uf = New UvonasFugue(Game.player1, Nothing)
            TextEvent.push(DDUtils.capitalizeFirst(getNameWithTitle) & " parries your spell, bouncing a copy back at you!")
            uf.backfire()
            Return False
        End If

        Return True
    End Function
    Public Overrides Sub attackSpell(ByRef target As Entity, ByVal spellName As String, ByVal dmg As Integer)
        TextEvent.pushAndLog(Trim(title & getName() & " fires a " & spellName & " at you!"))

        Dim crit = Int(Rnd() * 20) 'roll for a critical
        Dim damage = getSpellDamage(target, dmg) 'calculate the hit
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

    Private Sub phase2Attack(ByRef target As Entity)
        If combat_turn Mod 3 = 2 And getSPD() > target.getSPD Then
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " performs Dodge!")
            dodgeing = True

            Exit Sub
        End If

        If identified_weakness = p_weakness.def Then
            If combat_turn Mod 3 = 0 Or combat_turn Mod 3 = 2 Then
                TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle()) & " thrusts at you, " & p_pronoun & " attack faster than lightning!")
                If target.takeDMG(Entity.calcDamage(getATK() * 1.15, target.getDEF), Me) Then TextEvent.pushAndLog("You take " & Entity.calcDamage(getATK() * 1.15, target.getDEF) & " damage!")
            ElseIf combat_turn Mod 3 = 1 Then
                TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle()) & " swipes at you with " & p_pronoun & " cursed blade!")
                MyBase.attackCMD(target)
            End If
        Else
            If combat_turn Mod 3 = 0 Or combat_turn Mod 3 = 2 Then
                attackSpell(target, "spectral knife", getWIL() * 0.75)
                If Game.combat_engaged Then attackSpell(target, "spectral knife", getWIL() * 0.75)
            ElseIf combat_turn Mod 3 = 1 Then
                attackSpell(target, "spectral cleaver", getWIL() * 1.15)
            End If
        End If
    End Sub

    Private Sub phase3Attack(ByRef target As Entity)

    End Sub

    Private Sub phase4Attack(ByRef target As Entity)

    End Sub

    '| -- DEATHS -- |
    Public Overrides Sub playerDeath(ByRef p As Player)
        Select Case curr_phase
            Case phase.phase1
                phase1PDeath(p)
            Case phase.phase2
                MyBase.playerDeath(p)
        End Select
    End Sub
    Private Sub phase1PDeath(ByRef p As Player)
        EquipmentDialogBackend.equipArmor(p, "Naked")
        EquipmentDialogBackend.equipWeapon(p, "Fists")
        EquipmentDialogBackend.equipAcce(p, "Nothing")
        EquipmentDialogBackend.equipGlasses(p, "Nothing")

        For i = 0 To p.inv.upperBound
            p.inv.setCount(i, 0)
        Next

        p.inv.add(CrackedBrick.ITEM_NAME, 5)

        p.gold = 0

        TextEvent.push("""Pathetic..."" says Targax, before punting you upwards through 91017 floors." & DDUtils.RNRN &
                       "As you black out in a pile of rubble, you hear him call out from the dungeon depths." & DDUtils.RNRN &
                       """COME BACK IN FIFTEEN MILLION YEARS, WORM!""", AddressOf phase1PDeath_2)
    End Sub
    Private Sub phase1PDeath_2()
        Game.mDun.jumpTo(1)
        Game.mDun.setFloor(Game.currFloor)

        Game.player1.health = 0.01

        Game.player1.inv.invNeedsUDate = True
        Game.player1.UIupdate()
        Game.player1.drawPort()
    End Sub

    '| -- DIALOG -- |
    Private Sub toFem()
        title = " "
        pronoun = "she"
        p_pronoun = "her"
        r_pronoun = "her"
    End Sub

    Private Sub phaseChange1()
        Game.fromCombat()

        If Game.player1.getDEF > Game.player1.getWIL Then identified_weakness = p_weakness.will Else identified_weakness = p_weakness.def
        combat_turn = 0

        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(143), """Not too shabby...""" & DDUtils.RNRN &
                                                              "Your foe lowers " & p_pronoun & " blade with an excited grin." & DDUtils.RNRN &
                                                              """I wasn't planning to go all out, but here we are...""", AddressOf phaseChange1_2)
        curr_phase = phase.phase2
    End Sub
    Private Sub phaseChange1_2()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(144), """Alright!"" says the Food Vendor, tossing " & p_pronoun & " jacket into the fiery pit surrounding you both." & DDUtils.RNRN &
                                                              """I'm gonna enter my second phase!  I hope you can keep up!""", AddressOf returnToCombat)
    End Sub

    Private Sub phaseChange2()
        Game.fromCombat()

        If Game.player1.getDEF > Game.player1.getWIL Then identified_weakness = p_weakness.will Else identified_weakness = p_weakness.def
        combat_turn = 0

        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(145), """Is that..."" pants the Food Vendor, blade falling from " & p_pronoun & " hands, ""...all you've got?""" & DDUtils.RNRN, AddressOf phaseChange2_2)
        curr_phase = phase.phase3
    End Sub
    Private Sub phaseChange2_2()
        toFem()
        name = "Cake Demoness (Food Vendor)"
        Objective.showNPC(Game.picFVTBoss1.BackgroundImage, """Whoops, looks like I went a bit overboard...""" & DDUtils.RNRN, AddressOf phaseChange2_3)
    End Sub
    Private Sub phaseChange2_3()
        toFem()
        Objective.showNPC(Game.picFVTBoss2.BackgroundImage, """PHASE THREE!""" & DDUtils.RNRN &
                                                            "A surge of infernal energy erupts from your foe, as " & pronoun & " cackles with glee." & DDUtils.RNRN &
                                                            """YOU'RE IN THE OVEN NOW!""", AddressOf returnToCombat)
    End Sub

    Private Sub phaseChange3()
        Game.fromCombat()

        If Game.player1.getDEF > Game.player1.getWIL Then identified_weakness = p_weakness.will Else identified_weakness = p_weakness.def
        combat_turn = 0

        Objective.showNPC(Game.picFVTBoss3.BackgroundImage, """Wow, you're actually keeping up..."" your foe giggles through heavy breaths, " & p_pronoun & " exaution clearly showing, ""I guess... I'll have to pull deeper yet...""" & DDUtils.RNRN, AddressOf phaseChange3_2)
        curr_phase = phase.phase4
    End Sub
    Private Sub phaseChange3_2()
        name = "Abyssal Demon Queen"
        Objective.showNPC(Game.picFVTBoss4.BackgroundImage, """Phase four...  Will I need to go for a fifth?""" & DDUtils.RNRN, AddressOf returnToCombat)
    End Sub

    Private Sub returnToCombat()
        Game.toCombat(Me)
    End Sub
End Class
