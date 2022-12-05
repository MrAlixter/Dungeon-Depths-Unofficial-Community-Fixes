Public Class PerkEffects
    Private Enum randomPolymorph
        minotaurCow
        minotaurBull
        dragon
        succubus
        slime
        cake
        alraune
        bunnyGirl
        blob
        halfDragonR
        tigress
        faerie
        beegirl
    End Enum

    '|GENERAL EFFECTS|
    Shared Sub staminaEffect(ByRef p As Player)
        If p.perks(perk.hunger) > -1 And Game.getTurn Mod 5 = 0 Then
            If p.stamina > 0 Then
                p.perks(perk.hunger) = -1
            Else
                TextEvent.pushLog("Your stomach aches... -5 health!")
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

            TextEvent.pushLog(exclaim & "  -2 health!")
            p.health -= 2 / p.getMaxHealth
            If p.health <= 0 Then p.die(Monster.monsterFactory(15))

            If p.perks(perk.burn) >= 0 Then p.perks(perk.burn) -= 1
        End If
    End Sub
    Shared Sub slimeHairRegen(ByRef p As Player)
        If Not p.prt.haircolor.A = 180 Then
            p.perks(perk.slimehair) = -1
            p.perks(perk.slimeregenplus) = -1
        Else
            If p.health < 1 And Game.getTurn Mod 4 = 0 Then
                Dim h As Integer = If(p.perks(perk.slimeregenplus) > -1, Math.Max(5, p.getMaxHealth / 12), 5)
                p.health += h / p.getMaxHealth()
                TextEvent.pushLog("Your entire body glows, healing you for " & h & " HP!")
            End If
        End If
    End Sub
    Shared Sub mBurst(ByRef p As Player)
        If p.health < 1 And Game.getTurn Mod 4 = 0 Then
            p.health += 5 / p.getMaxHealth()
            If p.mana < p.getMaxMana + 5 Then p.mana += 5 Else p.mana = p.getMaxMana
            p.stamina -= 7
            TextEvent.pushLog("Your blazing aura surges!  +5 health, +5 mana, -7 stamina")
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
                TextEvent.pushLog("Your slime hair glows, healing you for " & h & " HP!")
            End If
        End If
    End Sub
    Shared Sub plantRegen(ByRef p As Player)
        If p.health < 1 And Game.getTurn Mod 7 = 0 Then
            Dim h As Integer = 3
            p.health += h / p.getMaxHealth()
            TextEvent.pushLog("You are able to absorb some nutrients through the ground. +" & h & " health")
            If p.health > 1 Then p.health = 1
        End If
    End Sub
    Shared Sub minorRegen(ByRef p As Player)
        If p.health < 1 And Game.getTurn Mod 7 = 0 Then
            Dim h As Integer = Int(Rnd() * 8) + 1
            p.health += h / p.getMaxHealth()
            TextEvent.pushLog("A slight glowing aura heals some of your wounds! +" & h & " health")
            If p.health > 1 Then p.health = 1

            If Int(Rnd() * 20) = 0 Then
                TextEvent.push(Game.lblEvent.Text.Split(vbCrLf)(0) & vbCrLf & "Your ring of regeneration goes dim, before shattering into dust.")
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
            TextEvent.pushLog("A slight glowing aura imbues you with magical energy! +" & m & " mana")
            If p.mana > p.getMaxMana Then p.mana = p.getMaxMana
        End If
    End Sub
    Shared Sub Regen(ByRef p As Player)
        If p.health < 1 And Game.getTurn Mod 7 = 0 Then
            Dim h As Integer = Int(Rnd() * 15) + 1
            p.health += h / p.getMaxHealth()
            TextEvent.pushLog("A glowing aura heals some of your wounds! +" & h & " health")
            If p.health > 1 Then p.health = 1
        End If
    End Sub
    Shared Function livingArmor(ByRef p As Player) As Boolean
        If p.equippedArmor.getName.Equals("Living_Armor") Then
            If Game.getTurn Mod 6 = 0 And p.lust < 100 Then
                Dim l As Integer = Int(Rnd() * 15) + 10
                p.addLust(l)
                TextEvent.pushLog("Your living armor raises your lust!")
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
                TextEvent.pushLog("Your living lingerie raises your lust!")
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
                TextEvent.push("Your lack of familiarity with this weapon greatly lowers your attack potential!")
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

            TextEvent.pushAndLog("A rippling aura surrounds you, and you revert to your former state!")
            TextEvent.pushLog("The wristband ejects a single smoldering battery cell.")

            p.inv.add("AAAAAA_Battery", -1)
        End If
    End Sub
    Shared Sub imitationCowbell(ByRef p As Player)
        TextEvent.pushAndLog("You feel an unfamiliar presence take hold of your mind...")

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
            TextEvent.pushAndLog("... but nothing happens")
        End If

    End Sub
    Shared Sub mesmerized(ByRef p As Player)
        If p.perks(perk.mesmerized) > 1 Then
            p.perks(perk.mesmerized) -= 1
        Else
            p.perks(perk.mesmerized) = -1
        End If
    End Sub
    Shared Sub rotlgTracker(ByRef p As Player)
        If p.perks(perk.moamarphne) > 2 Then
            p.perks(perk.moamarphne) -= 1
        Else
            p.perks(perk.moamarphne) = -1
            If p.equippedAcce.getAName.Equals("Mark_of_Amaraphne") Then EquipmentDialogBackend.equipAcce(p, "Nothing", False) : p.inv.add("Mark_of_Amaraphne", -1)
        End If
    End Sub
    Shared Function dragonBoobsMana(ByRef p As Player) As Integer
        If p.perks(perk.dragonboobs) < 0 Then Return 0
        Select Case p.breastSize
            Case 0
                Return 5
            Case 1
                Return 8
            Case 2
                Return 11
            Case 3
                Return 14
            Case 4
                Return 17
            Case 5
                Return 20
            Case 6
                Return 25
            Case 7, Is > 7
                Return 30
            Case Else
                Return 0
        End Select
    End Function
    Shared Sub faeleafBloom(ByRef p As Player)
        TextEvent.pushAndLog("A puff of pollen poofs out from the " & FaerieBlossom.ITEM_NAME.Replace("_", " ") & "...")

        Dim d10 As Integer = Int(Rnd() * 10)
        If d10 = 0 Or d10 = 1 Then
            p.inv.setPotionNames()
            TextEvent.pushLog("The labels on your potions shift and twist around!")
        ElseIf d10 = 2 Or d10 = 3 Then
            Dim mp = Int(0.35 * p.getMaxMana())
            p.mana += mp
            TextEvent.pushLog("Your MP is restored by " & mp & "!")
        Else
            TextEvent.pushLog("...but nothing else happens.")
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
        TextEvent.push("You, being a statue, can not do anything.")
    End Sub
    Shared Sub mesStun()
        TextEvent.pushAndLog("You stare blankly forward, lost in a mesmerized daze...")
    End Sub
    Shared Sub namestealerStun()
        EquipmentDialogBackend.equipArmor(Game.player1, "Naked", True)
        TextEvent.pushAndLog("You stare blankly forward, taking off your " & If(Game.player1.equippedArmor.getAName.Contains("Armor"), "armor", "clothes") & " in a dazed trance...")
    End Sub
    Shared Sub firstStun()
        TextEvent.pushAndLog("You are too stunned to act!")
        Game.player1.perks(perk.stunned) = 1
    End Sub
    Shared Sub stun()
        TextEvent.pushAndLog("You shake off the stun, though you don't have time to do anything else...")
        Game.player1.perks(perk.stunned) = -1
    End Sub
    Shared Sub magicGirlStatusCheck(ByRef p As Player)
        If p.ongoingQuests.contains("Phantastic Fantom") Then Exit Sub

        If p.getMana > 0 AndAlso Game.getTurn Mod (11 + (p.level * p.getWIL() / 4)) = 0 Then
            p.mana -= 6
            TextEvent.pushLog("Your transformation consumes six mana!")
        End If

        If p.getMana < 1 Then
            EquipmentDialogBackend.weaponChange(p, "Fists")
            TextEvent.push("You no longer can keep up your transformation, and revert to your previous form!")
            p.perks(perk.tfedbyweapon) = -1
        End If
    End Sub
    Shared Sub valkyrieStatusCheck(ByRef p As Player)
        If p.stamina > 10 AndAlso Game.getTurn Mod (8 + (p.level * p.getWIL() / 2)) = 0 Then
            p.stamina -= 10
            TextEvent.pushLog("Your transformation consumes ten stamina!")
        End If

        If p.stamina < 10 Then
            EquipmentDialogBackend.weaponChange(p, "Fists")
            p.perks(perk.tfedbyweapon) = -1
            TextEvent.push("You no longer can keep up your transformation, and revert to your previous form!")
        End If
    End Sub
    Shared Sub faeleafHair(ByRef p As Player)
        If Not p.prt.checkNDefFemInd(pInd.midhair, 13) And Not p.prt.checkNDefMalInd(pInd.midhair, 6) Then
            Dim faeleaf_green As Color = Color.FromArgb(255, 117, 183, 139)

            If Not p.prt.iArrInd(pInd.midhair).Item2 Then
                p.prt.setIAInd(pInd.midhair, 6, False, True)
                p.prt.setIAInd(pInd.fronthair, 7, False, True)
            Else
                p.prt.setIAInd(pInd.midhair, 13, True, True)
                p.prt.setIAInd(pInd.fronthair, 22, True, True)
            End If

            p.changeHairColor(faeleaf_green)
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
            TextEvent.pushLog("Berserker rage has worn off.")

        End If
    End Sub
    Shared Sub massiveMammaries(ByRef p As Player)
        If p.perks(perk.mmammaries) = 1 Then
            p.dBuff = p.dBuff + ((p.getDEF - p.dBuff) * 0.8)
            p.perks(perk.mmammaries) -= 1
        Else
            p.dBuff = 0
            p.perks(perk.mmammaries) = -1
            TextEvent.pushLog("Massive mammaries has worn off.")

        End If
    End Sub
    Shared Sub guardUp(ByRef p As Player)
        If p.perks(perk.guardup) > 0 Then
            p.perks(perk.guardup) -= 1
        Else
            p.dBuff = 0
            p.perks(perk.guardup) = -1
            TextEvent.pushLog("Guard Up has worn off.")
        End If
    End Sub
    Shared Sub willUp(ByRef p As Player)
        If p.perks(perk.willup) > 0 Then
            p.wBuff = p.wBuff + ((p.getWIL - p.wBuff) * 0.3)
            p.perks(perk.willup) -= 1
        Else
            p.wBuff = 0
            p.perks(perk.willup) = -1
            TextEvent.pushLog("Will Up has worn off.")
        End If
    End Sub
    Shared Sub attackUp(ByRef p As Player)
        If p.perks(perk.atkup) > 0 Then
            p.perks(perk.atkup) -= 1
        Else
            p.aBuff = 0
            p.perks(perk.atkup) = -1
            TextEvent.pushLog("Attack Up has worn off.")
        End If
    End Sub
    Shared Sub lurk(ByRef p As Player)
        If p.perks(perk.lurk) > 0 And p.stamina > 9 Then
            p.perks(perk.lurk) -= 1
            If Int(Rnd() * 10) = 0 Then p.stamina -= 9 : TextEvent.push("Keeping up Lurk consumes 9 stamina!")
        Else
            p.perks(perk.lurk) = -1
            TextEvent.pushLog("Lurk has worn off.")
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
            TextEvent.pushLog("Pillowy Protect has worn off.")

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
            TextEvent.pushLog("Ironhide Fury has worn off.")

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
            TextEvent.pushLog("Inferno Aura has worn off.")
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

            TextEvent.pushLog("A cackling red aura washes over your equipment...")
        End If
        Return updatePortrait
    End Function
    Shared Function curseOfMilk(ByRef p As Player) As Boolean
        Dim updatePortrait = False
        If Game.getTurn Mod 30 = 0 And p.breastSize < 7 Then
            p.be()
            TextEvent.pushLog("Your chest begins glowing a sinister red...")
            updatePortrait = True
        End If
        Return updatePortrait
    End Function
    Shared Function curseOfPolymorph(ByRef p As Player) As Boolean
        Dim updatePortrait = False
        If p.perks(perk.copoly) = 0 AndAlso Transformation.canBeTFed(p) Then
            randomPoly()

            TextEvent.pushLog("You're enveloped by a crimson aura...")
            TextEvent.push("You are swiftly enveloped by a blinding crimson aura!  By the time you can see again, it's obvious that you've been physically changed by your curse.")

            p.perks(perk.copoly) = 50 + Int(Rnd() * 100)
            Return True
        ElseIf p.perks(perk.copoly) > 0 Then
            p.perks(perk.copoly) -= 1
        End If
        Return updatePortrait
    End Function
    Shared Sub curseOfBimbo(ByRef p As Player)
        If Not Transformation.canBeTFed(p) Then Exit Sub

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
                p.revertToState(p.formStates(stateInd.dembimState1))
                p.perks(perk.succubuscurse) = 1
            End If

        ElseIf p.getLust < 66 Then
            If p.perks(perk.succubuscurse) < 2 Then
                p.formStates(stateInd.dembimState1).save(p)
                p.perks(perk.succubuscurse) = 2
                DemBimboTF.tfPlayer(2, p)
            ElseIf p.perks(perk.succubuscurse) > 2 Then
                p.revertToState(p.formStates(stateInd.dembimState2))
                p.perks(perk.succubuscurse) = 2
            End If

        Else
            If p.perks(perk.succubuscurse) < 3 Then
                p.formStates(stateInd.dembimState2).save(p)
                DemBimboTF.tfPlayer(3, p)
                p.perks(perk.succubuscurse) = 3
            End If
        End If
    End Sub
    Shared Sub crypticCursemark(ByRef p As Player)
        If p.getLust <= 25 And Not p.className.Equals("Mindless") Then
            MindlessTF.step1alt(p, -1)
            TextEvent.pushAndLog("Your mind fades away...")
            p.drawPort()
        ElseIf p.getLust > 25 And p.className.Equals("Mindless") And Not p.pState.pClass.name.Equals("Mindless") Then
            p.revertToPState()
        End If
    End Sub
    Public Shared Sub randomPoly()
        randomPoly(Game.player1.pState)
    End Sub
    Public Shared Sub randomPoly(ByRef revert_state As State)
        Randomize(Game.currFloor.floorCode.GetHashCode)

        Game.player1.revertToState(revert_state)
        Game.player1.savePState()

        Dim tfs As Dictionary(Of randomPolymorph, Action) = New Dictionary(Of randomPolymorph, Action)
        tfs.Add(randomPolymorph.minotaurCow, AddressOf New MinotaurCowTF().step1)
        tfs.Add(randomPolymorph.minotaurBull, AddressOf New MinoMTF().fulltf)
        tfs.Add(randomPolymorph.dragon, AddressOf New DragonTF().step1Full)
        tfs.Add(randomPolymorph.succubus, AddressOf New SuccubusTF().step1)
        tfs.Add(randomPolymorph.slime, AddressOf New SlimeTF().step1)
        tfs.Add(randomPolymorph.cake, AddressOf New TTCCBF().step1)
        tfs.Add(randomPolymorph.alraune, AddressOf New AlrauneTF().fullRNDTF)
        tfs.Add(randomPolymorph.bunnyGirl, AddressOf DancerTF.step1RND)
        tfs.Add(randomPolymorph.blob, AddressOf SlimeTF.blobTF)
        tfs.Add(randomPolymorph.halfDragonR, AddressOf DragonTF.halfDragonRTF)
        tfs.Add(randomPolymorph.tigress, AddressOf New TigressTF().step1Full)
        tfs.Add(randomPolymorph.faerie, AddressOf New FaerieTF().step1)
        tfs.Add(randomPolymorph.beegirl, AddressOf BeeHoneyTF.fullTF)

        Dim form = tfs.Keys(Int(Rnd() * (tfs.Keys.Count - 1)))
        While Game.player1.formName.Equals(form)
            form = tfs.Keys(Int(Rnd() * (tfs.Keys.Count - 1)))
        End While

        Game.player1.perks(perk.polymorphed) = 999

        tfs(form)()
        Game.player1.drawPort()
        Game.player1.UIupdate()
    End Sub

    '|TAKE DAMAGE PERKS|
    Shared Function onDamage(ByRef p As Player, ByVal dmg As Integer, Optional ByVal crit As Boolean = False) As Boolean
        Dim flag = False
        flag = bowTieEffect(p) Or flag
        flag = hardLightEffect(dmg, p) Or flag
        flag = bimboDodge(p) Or flag
        flag = stealthDodge(p) Or flag
        flag = spidersilkEffect(dmg, p) Or flag
        flag = faeStaySafe(p) Or flag

        If p.perks(perk.rotlg) > 0 And dmg >= p.getIntHealth Then
            Dim a = New AmaraphneAngelTF()
            a.update()
            p.drawPort()
            Game.fromCombat()
            TextEvent.push("Before the strike lands, a blazing rose aura flares from your person." & DDUtils.RNRN & "You begin floating upward, and as wings burst forth from your back you are overwhelmed with a burning lust.  You can feel both your body and clothing shifting rapidly, but before you can really takes stock of what is happening you automatically flap upwards." & DDUtils.RNRN & "Your wings carry you to safety, and as soon as you touch down on the ground the glow surrounding you begins to fade.", AddressOf p.revertToPState)
            p.pos = Game.currFloor.randPoint
            If p.pState.breastSize = -1 Then p.pState.breastSize = 0 : p.pState.buttSize = 0
            Return True
        End If

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
                TextEvent.push("Your bowtie begins glowing, and suddenly everything seems to slow down.  You deftly sidestep the oncoming blow!  Time returns to its normal speed shortly, and your bowtie returns to its inert state.")
                Return True
            End If
        ElseIf p.perks(perk.bunnyears) > -1 Then
            Dim r = Int(Rnd() * 10)
            If r > 4 Then
                TextEvent.push("Your headband begins glowing, and suddenly everything seems to slow down.  You deftly sidestep the oncoming blow!  Time returns to its normal speed shortly, and your bunny ear headband returns to its inert state.")
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
                TextEvent.push("Your hardlight shields withstand the impact!")
                Return True
            Else
                TextEvent.push("Your hardlight shields are completely down!")
            End If
        End If
        Return False
    End Function
    Shared Function spidersilkEffect(ByVal dmg As Integer, ByRef p As Player) As Boolean
        If Not p.equippedArmor.getName.Contains("Spidersilk") Then Return False
        Dim shouldBreak = p.equippedArmor.durability - dmg <= 0

        p.equippedArmor.damage(dmg)
        If shouldBreak Then EquipmentDialogBackend.equipArmor(p, "Naked", False)

        Return False
    End Function
    Shared Function bimboDodge(ByRef p As Player) As Boolean
        Dim out = "As your opponent attacks, you pout and wimper ""Hey, stop it!""" & DDUtils.RNRN &
                  "You squeeze your arms together to show off your titties, gazing longingly at your opponent while trying to look as cute as possible." & DDUtils.RNRN &
                  "Your foe stops short, looking more confused than anything..." & DDUtils.RNRN &
                  "They must be, like, totally into you!"
        Dim out2 = "As your opponent attacks, you pout and wimper ""Hey, stop it!""" & DDUtils.RNRN &
                   "You squeeze your arms together to show off your cleavage, gazing longingly at your opponent while making sure your lip is quivering just a little bit." & DDUtils.RNRN &
                   "Your foe stops short, looking more confused than merciful..." & DDUtils.RNRN &
                   "Inwardly, you groan to yourself.   It looks like you aren't out of the woods yet..."
        If p.className.Equals("Bimbo") And Int(Rnd() * 3) = 0 Then
            TextEvent.push(out)
            Return True
        ElseIf p.className.Equals("Bimbo++") And Int(Rnd() * 3) = 0 Then
            TextEvent.push(out2)
            Return True
        ElseIf p.formName.Contains("Bimbo") Or p.perks(perk.bimbododge) > 0 And Int(Rnd() * 3) = 0 Then
            TextEvent.push(out)
            Return True
        End If
        Return False
    End Function
    Shared Function stealthDodge(ByRef p As Player) As Boolean
        Dim out = "You dodge the oncoming attack!"
        If (p.perks(perk.stealth) > 0 And Int(Rnd() * 7) = 0) Or p.perks(perk.dodge) > 0 Then
            TextEvent.push(out)
            If p.perks(perk.dodge) - 1 > 0 Then p.perks(perk.dodge) -= 1 Else p.perks(perk.dodge) = -1
            Return True
        End If
        If p.perks(perk.lurk) > 0 And Int(Rnd() * 4) = 0 Then
            TextEvent.push(out)
            Return True
        End If
        Return False
    End Function
    Shared Function reflectDamage(ByVal dmg As Integer, ByVal ratio As Double, ByRef currTarget As Entity, ByRef p As Player)
        If dmg > 0 And dmg < p.getIntHealth Then
            TextEvent.pushAndLog("Your opponent takes " & CInt(dmg * ratio) & " from their attack!")
            currTarget.takeDMG(CInt(dmg * ratio), p)
            Return True
        End If

        Return False
    End Function
    Shared Function reflectDamage2(ByVal dmg As Integer, ByVal ratio As Double, ByRef currTarget As Entity, ByRef p As Player, ByVal crit As Boolean)
        If dmg > 0 And dmg < p.getIntHealth Then
            If crit Then p.takeUnconditionalCritDMG(dmg, currTarget) Else p.takeUnconditionalDMG(dmg, currTarget)

            TextEvent.pushAndLog("Your opponent takes " & CInt(dmg * ratio) & " from their attack!")
            currTarget.takeDMG(CInt(dmg * ratio), p)

            Return True
        End If

        Return False
    End Function
    Shared Function faeStaySafe(ByRef p As Player)
        If Game.player1.perks(perk.faestaysafe) = 1 Then
            If Game.combat_engaged Then Game.fromCombat()

            Dim healing_item As Item = Nothing

            If p.inv.getCountAt(HealthPotion.ITEM_NAME) > 0 Then
                healing_item = p.inv.item(HealthPotion.ITEM_NAME)
            ElseIf p.inv.getCountAt(Herbs.ITEM_NAME) > 0 Then
                healing_item = p.inv.item(Herbs.ITEM_NAME)
            ElseIf p.inv.getCountAt(BetterHerbs.ITEM_NAME) > 0 Then
                healing_item = p.inv.item(BetterHerbs.ITEM_NAME)
            ElseIf p.inv.getCountAt(MajHealthPotion.ITEM_NAME) > 0 Then
                healing_item = p.inv.item(MajHealthPotion.ITEM_NAME)
            ElseIf p.inv.getCountAt(GardenSalad.ITEM_NAME) > 0 Then
                healing_item = p.inv.item(GardenSalad.ITEM_NAME)
            ElseIf p.inv.getCountAt(NatureKiss.ITEM_NAME) > 0 Then
                healing_item = p.inv.item(NatureKiss.ITEM_NAME)
            ElseIf p.inv.getCountAt(HHealthPotion.ITEM_NAME) > 0 Then
                healing_item = p.inv.item(HHealthPotion.ITEM_NAME)
            ElseIf p.inv.getCountAt(Panacea.ITEM_NAME) > 0 Then
                healing_item = p.inv.item(Panacea.ITEM_NAME)
            End If

            If Not healing_item Is Nothing Then
                healing_item.use(p)
                TextEvent.push("Gasping, you dart away from your foe.  You reach into your bag and grab a " & healing_item.getName() & ", and as you use it the fae's words echo in your head." & DDUtils.RNRN &
                               """Stay safe...""")
            Else
                TextEvent.push("Gasping, you dart away from your foe, the fae's words echoing in your head." & DDUtils.RNRN &
                               """Stay safe...""")
            End If

            Game.player1.perks(perk.faestaysafe) = -1
            Return True
        End If

        Return False
    End Function
End Class
