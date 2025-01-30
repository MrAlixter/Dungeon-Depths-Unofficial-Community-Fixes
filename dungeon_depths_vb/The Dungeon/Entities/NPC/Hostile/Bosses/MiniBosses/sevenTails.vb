Public Class SevenTails
    Inherits MiniBoss
    Dim shouldRun As Boolean = False

    Sub New()
        '|ID Info|
        name = "Seven-Tails"

        '|Stats|
        maxHealth = 7
        attack = 7
        defense = 7777
        will = 7777
        speed = 7
        xp_value = 1777
        setupMonsterOnSpawn(False)

        '|Inventory|
        inv.setCount(FoxEars.ITEM_NAME, 3)
        inv.setCount(ManaCharm.ITEM_NAME, 1 + CInt(Rnd() * 2))
        inv.setCount(OmniCharm.ITEM_NAME, 1)
        inv.setCount(SevenBandedRing.ITEM_NAME, 1)
        inv.setCount(FoxStatue.ITEM_NAME, 1)
        inv.setCount("Gold", 7000)

        '|Dialog Variables|
        title = " "
        pronoun = "she"
        p_pronoun = "her"
        r_pronoun = "her"

        '|Misc|
        If Game.player1.perks(perk.seventailsstage) = 2 Then
            'succubusTF()
            health = 0.33
            Game.player1.perks(perk.seventailsstage) = 3
        End If
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If shouldRun Then runAway() : Exit Sub

        If Int(Rnd() * 2) = 0 And getATK() < 67 Then
            TextEvent.pushAndLog((getName() & " casts Super Fireball!"))

            hit(67, target)
        ElseIf target.getSPD > getSPD() Then
            TextEvent.pushAndLog((getName() & " casts Swifter Haunches!  " & DDUtils.capitalizeFirst(r_pronoun) & " SPD raises massively..."))

            speed *= 4
        ElseIf target.getATK > getATK() Then
            TextEvent.pushAndLog((getName() & " casts Sharper Claws!  " & DDUtils.capitalizeFirst(r_pronoun) & " ATK raises massively..."))

            attack *= 4
        Else
            TextEvent.pushAndLog((getName() & " slashes at you!"))

            MyBase.attackCMD(target)
        End If
    End Sub

    Public Overrides Function reactToSpell(spell As String) As Boolean
        If spell.Contains("Polymorph") Or spell.Contains("Turn to") Or spell.Contains("Petrify") Then
            TextEvent.pushAndLog("Seven-Tails grins as the spell washes over " & r_pronoun & ", to no effect!")
            Return False
        End If

        If Game.player1.getWIL < 21 Then
            TextEvent.push("Seven-Tails grins as the spell washes over " & r_pronoun & ", to no effect!" & DDUtils.RNRN &
                           """Ooh, you'd need better resolve for that one to do anything, dummy!  I'd say you're about... " & 21 - Game.player1.getWIL & " WIL points short...""")
            TextEvent.pushLog("Seven-Tails grins as the spell washes over her, to no effect!")
            Return False
        End If

        Return True
    End Function

    Public Overrides Function takeDMG(ByRef dmg As Integer, ByRef source As Entity) As Boolean
        If dmg >= getIntHealth() And (health = 1 Or health = 0.66 Or health = 0.33) Then
            TextEvent.pushAndLog("Seven-Tails stumbles out of the way of the attack!")

            dmg = getIntHealth() - 1
        ElseIf Int(Rnd() * 2) = 0 Then
            TextEvent.pushAndLog("Seven-Tails deftly avoids the attack!")

            Return False
        End If

        Dim took_dmg = MyBase.takeDMG(Math.Min(dmg, 2), source)

        shouldRun = shouldRunST()

        Return took_dmg
    End Function
    Public Overrides Function takeCritDMG(ByRef dmg As Integer, ByRef source As Entity) As Boolean
        TextEvent.pushAndLog("Seven-Tails lets out a little ""eep!"" as " & pronoun & " dodges what would have been a critical hit...")

        Dim took_dmg = MyBase.takeDMG(1, source)
        shouldRun = shouldRunST()

        Return took_dmg
    End Function

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
        TextEvent.push("With a poof of smoke, " & getName() & " turns into a fox and flees into the forest...")
    End Sub

    Public Overrides Sub die(ByRef cause As Entity)
        If isDead Then Exit Sub
        currTarget = Nothing
        nextCombatAction = Nothing
        Game.player1.perks(perk.seventailsstage) = 7

        shouldRun = False
        Game.fromCombat()
        TextEvent.push("With a poof of smoke, Seven-Tails teleports backwards." & DDUtils.RNRN &
                       """You..."" she mutters, venom dripping in her tone, ""I refuse to lose to the likes of you...""" & DDUtils.RNRN &
                       "An inferno kicks up at her feet, and seven lines of fire rise out of the air behind her.  As she raises her arms, they spiral together into a seven-sided ring, and she boldly declares ""BEHOLD, MY ULTIMATE TECHNIQUE!  This spell is the PINNACLE of pyrotechnics, capable of rending the VERY SOUL of ANY who would dare stand against it.""" & DDUtils.RNRN &
                       "Stiffling a smug giggle, she continues, ""Normally such an overwhelming spell would backfire 5 of 6 times even for a master of flame magic, but my ability 'LUCKY 7' allows me to cheat the VERY LAWS OF PROBABILITY!  PREPARE YOURSELF, FOR THE ALL-CONSUMING BLAZE OF MY '7th RING'!""" & DDUtils.RNRN &
                       "You brace yourself for an impact, as strobes of heat ignite the surrounding foliage.", AddressOf deathStage2)
    End Sub
    Private Sub deathStage2()
        TextEvent.pushLog("Seven-Tails casts 7th Ring... but it backfires.")
        TextEvent.push("The ring of flame begins spinning in place though, and Seven-Tails' maniacal grin slowly fades.  " & DDUtils.capitalizeFirst(pronoun) & " seems distracted by " & p_pronoun & " spellcraft, almost as though she has forgotten your presence." & DDUtils.RNRN &
                       """B-b-but the odds of t-that would only be one in t-three milli...""" & DDUtils.RNRN &
                       "Before she has time to let out any more than an ""eep!"", the blazing wheel erupts into a thick, blinding cloud of black ash.  As the plume settles down, you find that Seven-Tails has once again vanished." & DDUtils.RNRN &
                       "There does seem to be another ornemental fox statue in her place, though...", AddressOf deathStage3)
    End Sub
    Private Sub deathStage3()
        Game.pnlEvent.Visible = False

        Game.combat_engaged = True
        MyBase.die(Game.player1)
        Game.drawBoard()
    End Sub
    Public Overrides Sub playerDeath(ByRef p As Player)
        despawn("p-death")
        Dim out = "You collapse, defeated..." & DDUtils.RNRN &
                  """Hmmmm, what to do with you..."" Seven-Tails grins, prodding your nearly unconscious body with a light kick.  ""Ooh, Sis's birthday is right around the corner!""" & DDUtils.RNRN &
                  "She waves her hand, and suddenly you start to feel a lot lighter.  With a *pomph*, you find yourself forced into an immobile pose as your lips begin to puff up into a permenant 'O' shape.  As your eyes widen in suprise, your expression settles as it becomes painted on to your smooth face." & DDUtils.RNRN &
                  """HA!  Oh, she's gonna get a kick out of you, the resemblance is uncanny!"" she laughs, tossing you up in the air.  As you slowly drift to the ground, the air ripples around you..."
        Game.picPortrait.BackgroundImage = Portrait.CreateBMP({Portrait.nullImg, Portrait.ol_img_lib.getImg(20)})
        TextEvent.push(out, AddressOf stailsDeath1)
    End Sub
    Public Sub stailsDeath1()
        Dim p = Game.player1

        p.pos = Game.currFloor.randPoint
        TextEvent.push("With an audible *pop*, you suddenly find yourself in another part of the dungeon, your immobile form dropping at the feet of another kitsune.  Each of her nine tails jolts straight up in surprise, and she takes a deft leap backwards as she draws a red-hot blade.", AddressOf stailsDeath2)
        Game.drawBoard()
    End Sub
    Public Sub stailsDeath2()
        Dim p = Game.player1

        Game.picNPC.BackgroundImage = ShopNPC.gbl_img.atrs(0).getAt(65)
        TextEvent.pushNPCDialog("""AHHH, what the hell!  Where did... why would..." & DDUtils.RNRN &
                                "WHAT?!?""", AddressOf stailsDeath3)
    End Sub
    Public Sub stailsDeath3()
        Dim p = Game.player1

        'Game.picNPC.BackgroundImage = ShopNPC.gbl_img.atrs(0).getAt(66)
        Game.picNPC.Visible = False
        TextEvent.push("As she relaxes her posture and her suprise fades into visible annoyance, the kitsune angles her weapon in your general direction. " & DDUtils.RNRN &
                       """Clearly you're a product of my sister's work...  I don't suppose you were one of her opponents, were you?""" & DDUtils.RNRN &
                       "With a rush of scorching wind, the edge of her blade glows white and the air surrounding it bursts into flame.  As the blaze engulfs you, her expression hardens and she continues," & DDUtils.RNRN &
                       """No matter.  Learn this well, should we ever come to somehow meet again...""", AddressOf stailsDeath4)
    End Sub
    Public Sub stailsDeath4()
        Dim p = Game.player1

        Game.picNPC.BackgroundImage = ShopNPC.gbl_img.atrs(0).getAt(66)
        Game.picNPC.Visible = True
        TextEvent.pushNPCDialog(DDUtils.capitalizeFirst(pronoun) & " slashes clean through you in a single blinding cut." & DDUtils.RNRN &
                                """I am nothing like my sister.""" & DDUtils.RNRN &
                                "Press any non combat key to continue...", AddressOf p.die)
    End Sub

    '|Arachne Fight|
    Public Sub arachneTF()
        TextEvent.pushLog((getName() & " casts self polymorph, becoming an arachne!"))
        TextEvent.pushCombat((getName() & " casts self polymorph, becoming an arachne!"))
        form = "Fire-Bite Arachne"
        maxHealth = 777
        attack = 77
        defense = 77
        speed = 777
        perks(npc_perk.tfdur) = 3

        Game.updatePnlCombat(Game.player1, Me)
    End Sub
    Public Sub aAttack(ByRef target As Entity)
        If Int(Rnd() * 2) = 0 Then
            Dim tATK As Integer = CInt(attack)
            TextEvent.pushLog((getName() & " casts Super Fireball!"))
            TextEvent.pushCombat((getName() & " casts Super Fireball!"))
            attack *= 2
            MyBase.attackCMD(target)

            attack = tATK
        Else
            TextEvent.pushLog((getName() & " goes in for a bite!"))
            TextEvent.pushCombat((getName() & " goes in for a bite!"))
            MyBase.attackCMD(target)
            If Not target.getPlayer Is Nothing Then target.getPlayer.perks(perk.burn) = 3
        End If
    End Sub

    '|Dragon Fight|
    Public Sub dragonTF()
        TextEvent.pushLog((getName() & " casts self polymorph, becoming a dragon!"))
        TextEvent.pushCombat((getName() & " casts self polymorph, becoming a dragon!"))
        Game.picNPC.Visible = False
        form = "Horned Dragon"
        maxHealth = 777
        attack = 100
        defense = 777
        speed = 77
        perks(npc_perk.tfdur) = 5

        Game.updatePnlCombat(Game.player1, Me)
    End Sub
    Public Sub dAttack(ByRef target As Entity)
        If Int(Rnd() * 2) = 0 Then
            TextEvent.pushLog((getName() & " swings a claw at you!"))
            TextEvent.pushCombat((getName() & " swings a claw at you!"))

            MyBase.attackCMD(target)
        Else
            Dim out = (getName() & " swings their tail, knocking you back!")

            Dim ownedPotions As List(Of Item) = New List(Of Item)
            For Each p In target.inv.getPotions()
                If p.count > 0 Then ownedPotions.Add(p)
            Next

            If ownedPotions.count > 0 Then
                Dim i = Int(Rnd() * ownedPotions.Count)
                out += "  As you stumble backwards, you fall, landing on your " &
                    ownedPotions(i).getAName & ", which breaks open!"
                target.inv.item(ownedPotions(i).getAName).use(Game.player1)
            End If

            TextEvent.pushLog(out)
            TextEvent.pushCombat(getName() & " swings their tail, knocking you back!")
        End If
    End Sub

    '|Succubus Fight|
    Public Sub succubusTF()
        TextEvent.pushLog((getName() & " casts self polymorph, becoming a trio of succubi!"))
        TextEvent.pushCombat((getName() & " casts self polymorph, becoming a trio of succubi!"))
        form = "Trio of Succubi"
        maxHealth = 666
        attack = 66
        defense = 77
        speed = 77777
        perks(npc_perk.tfdur) = 7

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
                Game.mDun.floor_boss(7) = "Key"
                Game.hteach.pos = New Point(Game.player1.pos.X, Game.player1.pos.Y)
            End If
        End If
        MyBase.despawn(reason)
    End Sub
End Class
