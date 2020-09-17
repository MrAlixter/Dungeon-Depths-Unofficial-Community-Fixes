Public Class SevenTails
    Inherits MiniBoss
    Dim shouldRun As Boolean = False

    Sub New()
        name = "Seven-Tails"
        maxHealth = 7
        attack = 7
        defense = 7777
        speed = 7

        inv.setCount("Fox_Ears", 3)
        inv.setCount("Mana_Charm", 1 + CInt(Rnd() * 2))
        inv.setCount("Omni_Charm", 1)
        inv.setCount("Seven_Banded_Ring", 1)
        inv.setCount("Fox_Statue", 1)
        inv.setCount("Gold", 7000)

        setupMonsterOnSpawn(False)

        title = " "
        pronoun = "she"
        pPronoun = "her"
        rPronoun = "her"
        xpValue = 1777

        If Game.player1.perks(perk.seventailsstage) = 2 Then
            'succubusTF()
            health = 0.33
            Game.player1.perks(perk.seventailsstage) = 3
        End If
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If shouldRun Then runAway() : Exit Sub

        If Int(Rnd() * 2) = 0 And getATK() < 67 Then
            Game.pushLstLog((getName() & " casts Super Fireball!"))
            Game.pushLblCombatEvent((getName() & " casts Super Fireball!"))

            hit(67, target)
        ElseIf target.getSPD > getSPD() Then
            Game.pushLstLog((getName() & " casts Sharper Claws!  " & rPronoun & " ATK raises massively..."))
            Game.pushLblCombatEvent((getName() & " casts Sharper Claws!  " & rPronoun & " ATK raises massively..."))

            speed *= 4
        ElseIf target.getATK > getATK() Then
            Game.pushLstLog((getName() & " casts Swifter Haunches!  " & rPronoun & " ATK raises massively..."))
            Game.pushLblCombatEvent((getName() & " casts Swifter Haunches!  " & rPronoun & " ATK raises massively..."))

            speed *= 4
        Else
            Game.pushLstLog((getName() & " casts Super Fireball!"))
            Game.pushLblCombatEvent((getName() & " casts Super Fireball!"))

            MyBase.attackCMD(target)
        End If
    End Sub

    Public Overrides Function reactToSpell(spell As String) As Boolean
        If spell.Contains("Polymorph") Or spell.Contains("Turn to") Or spell.Contains("Petrify") Then
            Game.pushLstLog("Seven-Tails grins as the spell washes over her, to no effect!")
            Game.pushLblCombatEvent("Seven-Tails grins as the spell washes over her, to no effect!")
            Return False
        End If

        If Game.player1.getWIL < 21 Then
            Game.pushLstLog("Seven-Tails grins as the spell washes over her, to no effect!" & DDUtils.RNRN &
                            """Ooh, you need a deeper resolve for that one to do anything, dummy!  I'd say you're about... " & 21 - Game.player1.getWIL & " Will points short...""")
            Game.pushLblCombatEvent("Seven-Tails grins as the spell washes over her, to no effect!")
            Return False
        End If

        Return True
    End Function

    Public Overrides Sub takeDMG(dmg As Integer, ByRef source As Entity)
        If dmg >= getIntHealth() And (health = 1 Or health = 0.66 Or health = 0.33) Then
            Game.pushLstLog("Seven-Tails stumbles out of the way of the attack!")
            Game.pushLblCombatEvent("Seven-Tails stumbles out of the way of the attack!")

            dmg = getIntHealth() - 1
        End If

        MyBase.takeDMG(dmg, source)

        shouldRun = shouldRunST()
    End Sub
    Public Overrides Sub takeCritDMG(dmg As Integer, ByRef source As Entity)
        shouldRun = shouldRunST()
        MyBase.takeCritDMG(dmg, source)
    End Sub

    Public Function shouldRunST() As Boolean
        If Game.player1.perks(perk.seventailsstage) = 1 Then
            If health <= 0.66 Then Return True
        ElseIf Game.player1.perks(perk.seventailsstage) = 2 Then
            If health <= 0.33 Then Return True
        End If

        Return False
    End Function
    Public Sub runAway()
        If getIntHealth() <= 2 Then die() : Exit Sub
        shouldRun = False
        Game.fromCombat()
        Game.pushLblEvent("With a poof of smoke, " & getName() & " returns to " & rPronoun & " original form and flees into the forest...")
    End Sub
    
    Public Overrides Sub die(ByRef cause As Entity)
        If isDead Then Exit Sub
        currTarget = Nothing
        nextCombatAction = Nothing

        shouldRun = False
        Game.fromCombat()
        Game.pushLblEvent("With a poof of smoke, Seven-Tails returns to her original form.  ""You..."" she mutters, venom dripping in her tone, ""I refuse to lose to the likes of you...""" & DDUtils.RNRN &
                          "An inferno kicks up at her feet, and seven lines of fire rise out of the air behind her.  As she raises her arms, they spiral together into a seven-sided ring, and she boldly declares ""BEHOLD, MY ULTIMATE TECHNIQUE!  This spell is the PINNACLE of pyrotechnics, capable of rending the VERY SOUL of ANY who would dare stand against it.""" & DDUtils.RNRN &
                          "Stiffling a smug giggle, she continues, ""Normally such an overwhelming spell would backfire 5 of 6 times even for a master of flame magic, but my ability 'LUCKY 7' allows me to cheat the VERY LAWS OF PROBABILITY!  PREPARE YOURSELF, FOR THE ALL-CONSUMING BLAZE OF MY '7th RING'!!!""" & DDUtils.RNRN &
                          "You brace yourself for an impact, as a number strobes of heat ignite the surrounding foliage.  As the ring begins spinning in place though, Seven-Tails' maniacal grin slowly erodes.  ""Bu-bu-but the o-odds of t-that would only be one in t-three milli...""" & DDUtils.RNRN &
                          "Before she has time to let out any more than an ""eep!"", the blazing wheel erupts into a thick, blinding cloud of black ash.  As the plume settles down it's clear that your opponent is nowhere to be seen, although there does seem to be another ornemental fox statue in her place.", AddressOf deathStage2)
        Game.pushLstLog("Seven-Tails casts 7th Ring... but it backfires...")
    End Sub
    Private Sub deathStage2()
        endMonster()

        Game.player1.clearTarget()
        Game.player1.xp += xpValue
        Game.player1.currTarget = Nothing
        Game.player1.nextCombatAction = Nothing

        Game.drawBoard()
    End Sub
    Public Overrides Sub playerDeath(ByRef p As Player)
        despawn("p-death")
        Dim out = """Hmmmm, what to do with you..."" Seven-Tails grins, prodding your nearly unconscious body with a light kick.  ""Ooh, Sis's birthday is right around the corner!""" & DDUtils.RNRN &
                  "She waves her hand, and suddenly you start to feel a lot lighter.  With a *pomph*, you find yourself forced into an immobile pose as your lips begin to puff up into a permenant 'O' shape.  As your eyes widen in suprise, your expression settles as it becomes painted on to your smooth face." & DDUtils.RNRN &
                  """HA!  Oh, she's gonna get a kick out of you, the resemblance is uncanny!"" she laughs, tossing you up in the air.  As you slowly drift to the ground, the air ripples around you..."
        Game.picPortrait.BackgroundImage = Portrait.CreateBMP({Portrait.nullImg, Game.pic9tailsBimbo.BackgroundImage})
        Game.pushLblEvent(out, AddressOf stailsDeath1)
    End Sub
    Public Sub stailsDeath1()
        Dim p = Game.player1

        p.pos = Game.currFloor.randPoint
        Game.pushLblEvent("With an audible *pop*, you suddenly find yourself in another part of the dungeon, your immobile form dropping at the feet of another kitsune.  Each of her nine tails jolts straight up in surprise, and she takes a deft leap backwards as she draws a red-hot blade.", AddressOf stailsDeath2)
        Game.drawBoard()
    End Sub
    Public Sub stailsDeath2()
        Dim p = Game.player1

        Game.picNPC.BackgroundImage = ShopNPC.npcLib.atrs(0).getAt(65)
        Game.pushNPCDialog("AHHH, what the hell!  Where did...  Why would...  WHAT?!?", AddressOf p.die)
    End Sub
    Public Sub stailsDeath3()
        Dim p = Game.player1

        Game.picNPC.BackgroundImage = ShopNPC.npcLib.atrs(0).getAt(66)
        Game.pushNPCDialog("How dare she...  IT'S NOT EVEN MY BIRTHDAY!!!", AddressOf p.die)
    End Sub

    '|Arachne Fight|
    Public Sub arachneTF()
        Game.pushLstLog((getName() & " casts self polymorph, becoming an arachne!"))
        Game.pushLblCombatEvent((getName() & " casts self polymorph, becoming an arachne!"))
        form = "Fire-Bite Arachne"
        maxHealth = 777
        attack = 77
        defense = 77
        speed = 777
        tfCt = 1
        tfEnd = 3

        Game.updatePnlCombat(Game.player1, Me)
    End Sub
    Public Sub aAttack(ByRef target As Entity)
        If Int(Rnd() * 2) = 0 Then
            Dim tATK As Integer = CInt(attack)
            Game.pushLstLog((getName() & " casts Super Fireball!"))
            Game.pushLblCombatEvent((getName() & " casts Super Fireball!"))
            attack *= 2
            MyBase.attackCMD(target)

            attack = tATK
        Else
            Game.pushLstLog((getName() & " goes in for a bite!"))
            Game.pushLblCombatEvent((getName() & " goes in for a bite!"))
            MyBase.attackCMD(target)
            If target.GetType Is GetType(Player) Then CType(target, Player).perks(perk.burn) = 3
        End If
    End Sub

    '|Dragon Fight|
    Public Sub dragonTF()
        Game.pushLstLog((getName() & " casts self polymorph, becoming a dragon!"))
        Game.pushLblCombatEvent((getName() & " casts self polymorph, becoming a dragon!"))
        Game.picNPC.Visible = False
        form = "Horned Dragon"
        maxHealth = 777
        attack = 100
        defense = 777
        speed = 77
        tfCt = 1
        tfEnd = 5

        Game.updatePnlCombat(Game.player1, Me)
    End Sub
    Public Sub dAttack(ByRef target As Entity)
        If Int(Rnd() * 2) = 0 Then
            Game.pushLstLog((getName() & " swings a claw at you!"))
            Game.pushLblCombatEvent((getName() & " swings a claw at you!"))

            MyBase.attackCMD(target)
        Else
            Dim out = (getName() & " swings their tail, knocking you back!")

            Dim ownedPotions As List(Of Item) = New List(Of Item)
            For Each p In target.inv.getPotions()
                If p.count > 0 Then ownedPotions.Add(p)
            Next

            If ownedPotions.Count > 0 Then
                Dim i = Int(Rnd() * ownedPotions.Count)
                out += "  As you stumble backwards, you fall, landing on your " &
                    ownedPotions(i).getAName & ", which breaks open!"
                target.inv.item(ownedPotions(i).getAName).use(Game.player1)
            End If

            Game.pushLstLog(out)
            Game.pushLblCombatEvent(getName() & " swings their tail, knocking you back!")
        End If
    End Sub

    '|Succubus Fight|
    Public Sub succubusTF()
        Game.pushLstLog((getName() & " casts self polymorph, becoming a trio of succubi!"))
        Game.pushLblCombatEvent((getName() & " casts self polymorph, becoming a trio of succubi!"))
        form = "Trio of Succubi"
        maxHealth = 666
        attack = 66
        defense = 77
        speed = 77777
        tfCt = 1
        tfEnd = 7

        Game.updatePnlCombat(Game.player1, Me)
    End Sub
    Public Sub suAttack(ByRef target As Entity)

    End Sub

    Public Overrides Sub despawn(reason As String)
        If reason = "run" Then
            If Game.player1.perks(perk.seventailsstage) = 1 Then
                Game.player1.perks(perk.seventailsstage) = -1

                Game.currFloor.statueList.Add(New Statue(Game.player1.pos, "seventailsstatue", "You see here a golden statue of a fox"))
            ElseIf Game.player1.perks(perk.seventailsstage) = 1 Then
                Game.player1.perks(perk.seventailsstage) = 1

                Game.currFloor.beatBoss = True
                Game.mDun.floorboss(7) = "Key"
                Game.hteach.pos = New Point(Game.player1.pos.X, Game.player1.pos.Y)
            End If
        End If
        MyBase.despawn(reason)
    End Sub
End Class
