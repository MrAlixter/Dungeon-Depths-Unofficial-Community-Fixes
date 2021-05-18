Public Class PerkEffects
    '|GENERAL EFFECTS|
    Shared Sub staminaEffect(ByRef p As Player)
        If p.perks(perk.hunger) > -1 And Game.getTurn Mod 5 = 0 Then
            If p.stamina > 0 Then
                p.perks(perk.hunger) = -1
            Else
                Game.pushLstLog("Your stomach aches... -5 health!")
                p.health -= 5 / p.getMaxHealth
                If p.health <= 0 Then p.die(Monster.monsterFactory(10))
            End If
        End If
    End Sub
    Shared Sub burnEffect(ByRef p As Player)
        If p.perks(perk.burn) > -1 And Game.getTurn Mod 4 = 0 Then
            Dim exclaim As String = "The flames scorch your arms!"
            Dim r = Int(Rnd() * 100)
            If r = 0 Then
                exclaim = "AAAAAAAAAAAAAAAAAAA!!!"
            ElseIf r < 11 Then
                exclaim = "Flailing wildly does not put out the fire."
            ElseIf r < 25 Then
                exclaim = "Your entire torso is engulfed in fire!"
            ElseIf r < 50 Then
                exclaim = "The blaze singes your legs!"
            End If

            Game.pushLstLog(exclaim & "  -2 health!")
            p.health -= 2 / p.getMaxHealth
            If p.health <= 0 Then p.die(Monster.monsterFactory(15))

            If p.perks(perk.burn) >= 0 Then p.perks(perk.burn) -= 1
        End If
    End Sub
    Shared Sub slimeHairRegen(ByRef p As Player)
        If Not p.prt.haircolor.A = 180 Then
            p.perks(perk.slimehair) = -1
        Else
            If p.health < 1 And Game.getTurn Mod 4 = 0 Then
                p.health += 5 / p.getMaxHealth()
                Game.pushLstLog("Your gel body heals some of the damage done to it. +5 health")
                If p.health > 1 Then p.health = 1
            End If
        End If
    End Sub
    Shared Sub mBurst(ByRef p As Player)
        If p.health < 1 And Game.getTurn Mod 4 = 0 Then
            p.health += 5 / p.getMaxHealth()
            If p.mana < p.getMaxMana + 5 Then p.mana += 5 Else p.mana = p.getMaxMana
            p.stamina -= 7
            Game.pushLstLog("Your blazing aura surges!  +5 health, +5 mana, -7 stamina")
            If p.health > 1 Then p.health = 1

            If p.perks(perk.mburst) >= 0 Then p.perks(perk.mburst) -= 1
        End If
    End Sub
    Shared Sub vslimeHairRegen(ByRef p As Player)
        If Not p.prt.haircolor.A = 180 Then
            p.perks(perk.vsslimehair) = -1
        Else
            If p.health < 1 And Game.getTurn Mod 7 = 0 Then
                Dim h As Integer = Int(Rnd() * 5) + 1
                p.health += h / p.getMaxHealth()
                Game.pushLstLog("The gel portion of your body is able to heal some of your wounds! +" & h & " health")
                If p.health > 1 Then p.health = 1
            End If
        End If
    End Sub
    Shared Sub plantRegen(ByRef p As Player)
        If p.health < 1 And Game.getTurn Mod 7 = 0 Then
            Dim h As Integer = 3
            p.health += h / p.getMaxHealth()
            Game.pushLstLog("You are able to absorb some nutrients through the ground. +" & h & " health")
            If p.health > 1 Then p.health = 1
        End If
    End Sub
    Shared Sub minorRegen(ByRef p As Player)
        If p.health < 1 And Game.getTurn Mod 7 = 0 Then
            Dim h As Integer = Int(Rnd() * 8) + 1
            p.health += h / p.getMaxHealth()
            Game.pushLstLog("A slight glowing aura heals some of your wounds! +" & h & " health")
            If p.health > 1 Then p.health = 1

            If Int(Rnd() * 20) = 0 Then
                Game.pushLblEvent(Game.lblEvent.Text.Split(vbCrLf)(0) & vbCrLf & "Your ring of regeneration goes dim, before shattering into dust.")
                p.inv.item(77).count -= 1
                Equipment.accChange(p, "Nothing")
            End If
        End If
    End Sub
    Shared Sub minorManaRegen(ByRef p As Player)
        If p.equippedAcce.getId <> 110 Then
            p.perks(perk.minmanregen) = -1
            Exit Sub
        End If
        If p.mana < p.getMaxMana And Game.getTurn Mod 5 = 0 Then
            Dim m As Integer = 2
            p.mana += m
            Game.pushLstLog("A slight glowing aura imbues you with magical energy! +" & m & " mana")
            If p.mana > p.getMaxMana Then p.mana = p.getMaxMana
        End If
    End Sub
    Shared Sub Regen(ByRef p As Player)
        If p.health < 1 And Game.getTurn Mod 7 = 0 Then
            Dim h As Integer = Int(Rnd() * 15) + 1
            p.health += h / p.getMaxHealth()
            Game.pushLstLog("A glowing aura heals some of your wounds! +" & h & " health")
            If p.health > 1 Then p.health = 1
        End If
    End Sub
    Shared Function livingArmor(ByRef p As Player) As Boolean
        If p.equippedArmor.getName.Equals("Living_Armor") Then
            If Game.getTurn Mod 6 = 0 And p.lust < 100 Then
                Dim l As Integer = Int(Rnd() * 15) + 10
                p.addLust(l)
                Game.pushLstLog("Your living armor raises your lust!")
                Return True
            End If
        Else
            p.perks(perk.livearm) = -1
        End If
        Return False
    End Function
    Shared Function livingLingerie(ByRef p As Player) As Boolean
        If p.equippedArmor.getName.Equals("Living_Lingerie") Then
            If Game.getTurn Mod 4 = 0 And p.lust < 100 Then
                Dim l As Integer = Int(Rnd() * 15) + 10
                p.addLust(l)
                Game.pushLstLog("Your living lingerie raises your lust!")
                Return True
            End If
        Else
            p.perks(perk.livelinge) = -1
        End If
        Return False
    End Function
    Shared Sub lightSource(ByRef p As Player)
        If p.perks(perk.lightsource) > -1 Then
            p.perks(perk.lightsource) -= 1
        End If
    End Sub
    Shared Sub amazon(ByRef p As Player)
        If p.formName.Equals("Amazon​") Then
            If p.equippedWeapon.getName.Equals("Fists") And p.formName.Equals("Amazon​") Then
                p.changeForm("Amazon​")
            ElseIf Not p.equippedWeapon.getName.Equals("Fists") And p.formName.Equals("Amazon​") Then
                Game.pushLblEvent("Your lack of familiarity with this weapon greatly lowers your attack potential!")
                p.changeForm("Amazon​")
            End If
        Else
            p.perks(perk.amazon) = -1
        End If
    End Sub
    Shared Sub barbarian(ByRef p As Player)
        If Not p.className.Equals("Barbarian") Then
            p.perks(perk.barbarian) = -1
        End If
    End Sub
    Shared Sub bunnyEars(ByRef p As Player)
        If p.getLust = 0 Then
            If p.perks(perk.bunnyears) > 1 Then
                p.revertToPState()
                p.perks(perk.bunnyears) = 1
            End If
        ElseIf p.getLust > 33 Then
            If p.perks(perk.bunnyears) < 2 Then
                p.perks(perk.bunnyears) = 2
                BunnyBimboTF.tfPlayer(1, p)
                p.drawPort()
            End If
        End If
    End Sub
    Shared Sub phaseDeflector(ByRef p As Player)
        If p.inv.getCountAt("AAAAAA_Battery") > 0 And
           Not (p.formName.Equals(p.pState.pForm.name) And p.className.Equals(p.pState.pClass.name) And DDUtils.cEquals(p.prt.haircolor, p.pState.getHairColor) And DDUtils.cEquals(p.prt.skincolor, p.pState.getSkinColor) And p.breastSize = p.pState.breastSize And p.buttSize = p.pState.buttSize And p.dickSize = p.pState.dickSize) Then

            p.revertToPState()
            p.ongoingTFs.reset()

            Game.pushLogAndEvent("A rippling aura surrounds you, and you revert to your former state!")
            Game.pushLstLog("The wristband ejects a single smoldering battery cell.")

            p.inv.add("AAAAAA_Battery", -1)
        End If
    End Sub
    Shared Sub imitationCowbell(ByRef p As Player)
        Game.pushLogAndEvent("You feel an unfamiliar presence take hold of your mind...")

        Dim closest_chest As Chest = Nothing
        Dim route_len = 9999999999999
        For Each chest In Game.currFloor.chestList
            If Not (chest.pos.X = -1 Or chest.pos.Y = -1) AndAlso Game.currFloor.route(p.pos, chest.pos).Length < route_len Then
                closest_chest = chest
                route_len = Game.currFloor.route(p.pos, chest.pos).Length
                Exit For
            End If
        Next

        If Not closest_chest Is Nothing Then
            p.forcedPath = Game.currFloor.route(p.pos, closest_chest.pos)
        Else
            Game.pushLogAndEvent("... but nothing happens")
        End If

    End Sub

    '|TRANSFORMATION TRIGGERS|
    Shared Sub targaxSwordTF(ByRef p As Player)
        If p.name <> "Targax" Then
            If Not p.equippedWeapon.getName.Equals("Sword_of_the_Brutal") Then
                p.perks(perk.swordpossess) = -1
            End If
        Else
            p.perks(perk.swordpossess) = -1
        End If
    End Sub
    Shared Sub thrallRestore(ByRef p As Player)
        p.prefForm.shiftTowards(p)
        p.perks(perk.thrall) = 1
    End Sub
    Shared Sub aStatue(ByRef p As Player)
        If p.perks(perk.astatue) > 1 Then
            p.perks(perk.astatue) -= 1
            p.canMoveFlag = False
        ElseIf p.perks(perk.astatue) <= 1 Then
            p.perks(perk.astatue) = -1
            p.revertToPState()
            p.canMoveFlag = True
        End If
    End Sub
    Shared Sub statueMove(obj As Entity)
        Game.pushLblEvent("You, being a statue, can not do anything.")
    End Sub
    Shared Sub magicGirlStatusCheck(ByRef p As Player)
        If p.getMana > 0 AndAlso Game.getTurn Mod (11 + (p.level * p.getWIL() / 4)) = 0 Then
            p.mana -= 6
            Game.pushLstLog("Your transformation consumes six mana!")
        End If

        If p.getMana < 1 Then
            Equipment.weaponChange(p, "Fists")
            Game.pushLblEvent("You no longer can keep up your transformation, and revert to your previous form!")
        End If
    End Sub
    Shared Sub valkyrieStatusCheck(ByRef p As Player)
        If p.stamina > 10 AndAlso Game.getTurn Mod (8 + (p.level * p.getWIL() / 2)) = 0 Then
            p.stamina -= 10
            Game.pushLstLog("Your transformation consumes ten stamina!")
        End If

        If p.stamina < 10 Then
            Equipment.weaponChange(p, "Fists")
            Game.pushLblEvent("You no longer can keep up your transformation, and revert to your previous form!")
        End If
    End Sub

    '|SPECIAL MOVE HANDLERS|
    Shared Sub berserkerRage(ByRef p As Player)
        If p.perks(perk.brage) > 0 Then
            p.aBuff = p.aBuff + ((p.attack) / 2)
            p.dBuff = p.dBuff - ((p.defense) / 3)
            p.perks(perk.brage) -= 1
        Else
            p.aBuff = 0
            p.dBuff = 0
            p.perks(perk.brage) = -1
            Game.pushLstLog("Berserker rage has worn off.")

        End If
    End Sub
    Shared Sub massiveMammaries(ByRef p As Player)
        If p.perks(perk.mmammaries) = 1 Then
            p.dBuff = p.dBuff + ((p.getDEF - p.dBuff) * 0.8)
            p.perks(perk.mmammaries) -= 1
        Else
            p.dBuff = 0
            p.perks(perk.mmammaries) = -1
            Game.pushLstLog("Massive mammaries has worn off.")

        End If
    End Sub
    Shared Sub guardUp(ByRef p As Player)
        If p.perks(perk.guardup) > 0 Then
            p.perks(perk.guardup) -= 1
        Else
            p.dBuff = 0
            p.perks(perk.guardup) = -1
            Game.pushLstLog("Guard Up has worn off.")
        End If
    End Sub
    Shared Sub willUp(ByRef p As Player)
        If p.perks(perk.willup) > 0 Then
            p.wBuff = p.wBuff + ((p.getWIL - p.wBuff) * 0.3)
            p.perks(perk.willup) -= 1
        Else
            p.wBuff = 0
            p.perks(perk.willup) = -1
            Game.pushLstLog("Will Up has worn off.")
        End If
    End Sub
    Shared Sub attackUp(ByRef p As Player)
        If p.perks(perk.atkup) > 0 Then
            p.perks(perk.atkup) -= 1
        Else
            p.aBuff = 0
            p.perks(perk.atkup) = -1
            Game.pushLstLog("Attack Up has worn off.")
        End If
    End Sub
    Shared Sub lurk(ByRef p As Player)
        If p.perks(perk.lurk) > 0 And p.stamina > 9 Then
            p.perks(perk.lurk) -= 1
            If Int(Rnd() * 10) = 0 Then p.stamina -= 9 : Game.pushLblEvent("Keeping up Lurk consumes 9 stamina!")
        Else
            p.perks(perk.lurk) = -1
            Game.pushLstLog("Lurk has worn off.")
            p.drawPort()
        End If
    End Sub
    Shared Sub pProt(ByRef p As Player)
        If p.perks(perk.pprot) = 1 Then
            p.dBuff = p.dBuff + ((p.getDEF - p.dBuff) * 9.99)
            p.perks(perk.pprot) -= 1
        Else
            p.dBuff = 0
            p.perks(perk.pprot) = -1
            Game.pushLstLog("Pillowy Protect has worn off.")

        End If
    End Sub
    Shared Sub ironhideFury(ByRef p As Player)
        If p.perks(perk.ihfury) = 3 Then
            p.aBuff = p.aBuff + ((p.getATK - p.aBuff) * 0.5)
            p.dBuff = p.dBuff + ((p.getDEF - p.dBuff) * 0.6)
            p.perks(perk.ihfury) -= 1
        ElseIf p.perks(perk.ihfury) > 0 Then
            p.perks(perk.ihfury) -= 1
        Else
            p.aBuff = 0
            p.dBuff = 0
            p.perks(perk.ihfury) = -1
            Game.pushLstLog("Ironhide Fury has worn off.")

        End If
    End Sub
    Shared Sub infernoAura(ByRef p As Player)
        If p.perks(perk.infernoa) = 3 Then
            p.dBuff = p.dBuff + ((p.getDEF - p.dBuff) * 0.45)
            p.perks(perk.infernoa) -= 1
        ElseIf p.perks(perk.infernoa) > 0 Then
            p.perks(perk.infernoa) -= 1
        Else
            p.dBuff = 0
            p.perks(perk.infernoa) = -1
            Game.pushLstLog("Inferno Aura has worn off.")
        End If
    End Sub

    '|CURSES|
    Shared Function curseOfRust(ByRef p As Player) As Boolean
        Dim updatePortrait = False
        If Game.getTurn Mod 25 = 0 And (p.equippedAcce.count > 0 Or p.equippedArmor.count > 0 Or p.equippedWeapon.count > 0) Then
            If p.equippedAcce.count > 0 AndAlso p.equippedAcce.damage(10 + Int(Rnd() * 20)) Then
                p.equippedAcce = New noAcce
                updatePortrait = True
            End If

            If p.equippedArmor.count > 0 AndAlso p.equippedArmor.damage(10 + Int(Rnd() * 20)) Then
                p.equippedArmor = New Naked
                updatePortrait = True
            End If

            If p.equippedWeapon.count > 0 AndAlso p.equippedWeapon.damage(10 + Int(Rnd() * 20)) Then
                p.equippedWeapon = New BareFists
            End If

            Game.pushLstLog("A cackling red aura washes over your equipment...")
        End If
        Return updatePortrait
    End Function
    Shared Function curseOfMilk(ByRef p As Player) As Boolean
        Dim updatePortrait = False
        If Game.getTurn Mod 30 = 0 And p.breastSize < 7 Then
            p.be()
            Game.pushLstLog("Your chest begins glowing a sinister red...")
            updatePortrait = True
        End If
        Return updatePortrait
    End Function
    Shared Function curseOfPolymorph(ByRef p As Player) As Boolean
        Dim updatePortrait = False
        If p.perks(perk.copoly) = 0 AndAlso Transformation.canBeTFed(p) Then
            randomPoly()
            p.perks(perk.copoly) = 50 + Int(Rnd() * 100)
            Return True
        ElseIf p.perks(perk.copoly) > 0 Then
            p.perks(perk.copoly) -= 1
        End If
        Return updatePortrait
    End Function
    Shared Sub curseOfBimbo(ByRef p As Player)
        If p.getLust = 0 Then
            If p.perks(perk.succubuscurse) > 0 Then
                p.revertToPState()
                p.perks(perk.succubuscurse) = 0
            End If

        ElseIf p.getLust < 33 Then
            If p.perks(perk.succubuscurse) < 1 Then
                p.perks(perk.succubuscurse) = 1
                DemBimboTF.tfPlayer(1, p)
            ElseIf p.perks(perk.succubuscurse) > 1 Then
                p.revertToState(p.dembimState1)
                p.perks(perk.succubuscurse) = 1
            End If

        ElseIf p.getLust < 66 Then
            If p.perks(perk.succubuscurse) < 2 Then
                p.dembimState1.save(p)
                p.perks(perk.succubuscurse) = 2
                DemBimboTF.tfPlayer(2, p)
            ElseIf p.perks(perk.succubuscurse) > 2 Then
                p.revertToState(p.dembimState2)
                p.perks(perk.succubuscurse) = 2
            End If

        Else
            If p.perks(perk.succubuscurse) < 3 Then
                p.dembimState2.save(p)
                DemBimboTF.tfPlayer(3, p)
                p.perks(perk.succubuscurse) = 3
            End If
        End If
    End Sub
    Private Shared Sub randomPoly()
        Randomize(Game.currFloor.floorCode.GetHashCode)
        Game.player1.savePState()
        Dim tfs As Dictionary(Of String, Action) = New Dictionary(Of String, Action)
        tfs.Add("Minotaur Cow", AddressOf New MinotaurCowTF().step1)
        tfs.Add("Minotaur Bull", AddressOf New MinoMTF().fulltf)
        tfs.Add("Dragon", AddressOf New DragonTF().step1)
        tfs.Add("Succubus", AddressOf New SuccubusTF().step1)
        tfs.Add("Slime", AddressOf New slimetf().step1)
        tfs.Add("Bimbo", AddressOf New BimboTF(2, 0, 0.25, True).doubleTf)
        tfs.Add("Cake", AddressOf New TTCCBF().step1)

        Dim form = tfs.Keys(Int(Rnd() * (tfs.Keys.Count - 1)))
        While Game.player1.formName.Equals(form)
            form = tfs.Keys(Int(Rnd() * (tfs.Keys.Count - 1)))
        End While
        Game.player1.revertToPState()
        Game.player1.perks(perk.polymorphed) = 999
        tfs(form)()
        Game.player1.drawPort()
        Game.player1.UIupdate()
        Game.pushLstLog("You're enveloped by a crimson aura...")
        Game.pushLblEvent("You are swiftly enveloped by a blinding crimson aura!  By the time you can see again, it's obvious that you've been physically changed by your curse.")
    End Sub

    '|TAKE DAMAGE PERKS|
    Shared Function onDamage(ByRef p As Player, ByVal dmg As Integer, Optional ByVal crit As Boolean = False) As Boolean
        Dim flag = False
        flag = bowTieEffect(p) Or flag
        flag = hardLightEffect(dmg, p) Or flag
        flag = bimboDodge(p) Or flag
        flag = stealthDodge(p) Or flag
        flag = spidersilkEffect(dmg, p) Or flag

        If p.perks(perk.bunnyears) = 2 Then p.addLust(-dmg / 2)
        If p.perks(perk.infernoa) > -1 Then flag = reflectDamage(dmg, 0.45, p.currTarget, p)
        If p.equippedAcce.getAName.Equals("Hallowed_Talisman") Then flag = reflectDamage2(dmg, 0.55, p.currTarget, p, crit)
        Return flag
    End Function
    Shared Function bowTieEffect(ByRef p As Player) As Boolean
        If p.perks(perk.bowtie) > -1 Then
            Dim r = Int(Rnd() * 10)
            If r > 8 And Not p.className.Equals("Bunny Girl") Then
                Dim dTF = New DancerTF(1, 0, 0, False)
                dTF.update()
                p.drawPort()
                Return True
            ElseIf r > 5 Then
                Game.pushLblEvent("Your bowtie begins glowing, and suddenly everything seems to slow down.  You deftly sidestep the oncomming blow!  Time returns to its normal speed shortly, and your bowtie returns to its inert state.")
                Return True
            End If
        ElseIf p.perks(perk.bunnyears) > -1 Then
            Dim r = Int(Rnd() * 10)
            If r > 4 Then
                Game.pushLblEvent("Your headband begins glowing, and suddenly everything seems to slow down.  You deftly sidestep the oncomming blow!  Time returns to its normal speed shortly, and your bunny ear headband returns to its inert state.")
                Return True
            End If
        End If
        Return False
    End Function
    Shared Function hardLightEffect(ByVal dmg As Integer, ByRef p As Player) As Boolean
        If p.perks(perk.hardlight) > -1 Then
            If Not p.equippedArmor.getName.Contains("Photon") Then
                p.perks(perk.hardlight) = -1
                Return False
            End If
            If dmg / 2 <= p.mana Then
                p.mana -= dmg / 2
                Game.pushLblEvent("Your hardlight shields withstand the impact!")
                Return True
            Else
                Game.pushLblEvent("Your hardlight shields are completely down!")
            End If
        End If
        Return False
    End Function
    Shared Function spidersilkEffect(ByVal dmg As Integer, ByRef p As Player) As Boolean
        If Not p.equippedArmor.getName.Contains("Spidersilk") Then Return False
        Dim shouldBreak = p.equippedArmor.durability - dmg <= 0

        p.equippedArmor.damage(dmg)
        If shouldBreak Then Equipment.equipArmor(p, "Naked", False)

        Return False
    End Function
    Shared Function bimboDodge(ByRef p As Player) As Boolean
        Dim out = "You, like, totally aren't feeling this right now." & DDUtils.RNRN &
                  "Giving your best pout, you wimper ""Hey, stop it!  You're gonna, like, hurt me or something!"".  As you squeeze your arms together to show off your cleavage, you look up at your opponent making sure your lip is quivering just a little bit." & DDUtils.RNRN &
                  "They stop their attack short, looking more confused than anything else.  You don't even consider this subtle distinction though, instead deciding that they, like, totally thought you were too cute to hit!"
        Dim out2 = "You realize that you probably need to dodge this next attack." & DDUtils.RNRN &
                   "Giving your best pout, you wimper ""Hey, stop it!  You're gonna, like, hurt me or something!"".  As you squeeze your arms together to show off your cleavage, you look up at your opponent making sure your lip is quivering just a little bit." & DDUtils.RNRN &
                   "They stop their attack short, looking more confused than merciful.  Inwardly, you groan to yourself.   It looks like you aren't out of the woods yet..."
        If p.className.Equals("Bimbo") And Int(Rnd() * 3) = 0 Then
            Game.pushLblEvent(out)
            Return True
        ElseIf p.className.Equals("Bimbo++") And Int(Rnd() * 3) = 0 Then
            Game.pushLblEvent(out2)
            Return True
        ElseIf p.formName.Contains("Bimbo") Or p.perks(perk.bimbododge) > 0 And Int(Rnd() * 3) = 0 Then
            Game.pushLblEvent(out)
            Return True
        End If
        Return False
    End Function
    Shared Function stealthDodge(ByRef p As Player) As Boolean
        Dim out = "You dodge the oncoming attack!"
        If (p.perks(perk.stealth) > 0 And Int(Rnd() * 7) = 0) Or p.perks(perk.dodge) > 0 Then
            Game.pushLblEvent(out)
            If p.perks(perk.dodge) - 1 > 0 Then p.perks(perk.dodge) -= 1 Else p.perks(perk.dodge) = -1
            Return True
        End If
        If p.perks(perk.lurk) > 0 And Int(Rnd() * 4) = 0 Then
            Game.pushLblEvent(out)
            Return True
        End If
        Return False
    End Function
    Shared Function reflectDamage(ByVal dmg As Integer, ByVal ratio As Double, ByRef currTarget As Entity, ByRef p As Player)
        If dmg > 0 And dmg < p.getIntHealth Then
            Game.pushLogAndEvent("Your opponent takes " & CInt(dmg * ratio) & " from their attack!")
            currTarget.takeDMG(CInt(dmg * ratio), p)
            Return True
        End If

        Return False
    End Function
    Shared Function reflectDamage2(ByVal dmg As Integer, ByVal ratio As Double, ByRef currTarget As Entity, ByRef p As Player, ByVal crit As Boolean)
        If dmg > 0 And dmg < p.getIntHealth Then
            If crit Then p.takeUnconditionalCritDMG(dmg, currTarget) Else p.takeUnconditionalDMG(dmg, currTarget)

            Game.pushLogAndEvent("Your opponent takes " & CInt(dmg * ratio) & " from their attack!")
            currTarget.takeDMG(CInt(dmg * ratio), p)

            Return True
        End If

        Return False
    End Function
End Class
