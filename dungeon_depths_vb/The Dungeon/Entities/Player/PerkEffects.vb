Public Class PerkEffects
    '|GENERAL EFFECTS|
    Shared Sub hungerEffect()
        Dim p As Player = Game.player
        If p.perks("hunger") > -1 And Game.turn Mod 5 = 0 Then
            If p.hunger < 100 Then
                p.perks("hunger") = -1
            Else
                Game.pushLstLog("Your stomach aches... -5 health!")
                p.health -= 5 / p.getMaxHealth
                If p.health <= 0 Then p.die(Monster.monsterFactory(10))
            End If
        End If
    End Sub
    Shared Sub slimeHairRegen()
        Dim p As Player = Game.player
        If Not p.prt.haircolor.A = 180 Then
            p.perks("slimehair") = -1
        Else
            If p.health < 1 And Game.turn Mod 4 = 0 Then
                p.health += 5 / p.getMaxHealth()
                Game.pushLstLog("Your gel body heals some of the damage done to it. +5 health")
                If p.health > 1 Then p.health = 1
            End If
        End If
    End Sub
    Shared Sub vslimeHairRegen()
        Dim p As Player = Game.player
        If Not p.prt.haircolor.A = 180 Then
            p.perks("vsslimehair") = -1
        Else
            If p.health < 1 And Game.turn Mod 7 = 0 Then
                Dim h As Integer = Int(Rnd() * 5) + 1
                p.health += h / p.getMaxHealth()
                Game.pushLstLog("The gel portion of your body is able to heal some of your wounds! +" & h & " health")
                If p.health > 1 Then p.health = 1
            End If
        End If
    End Sub
    Shared Sub plantRegen()
        Dim p As Player = Game.player
        If p.health < 1 And Game.turn Mod 7 = 0 Then
            Dim h As Integer = 3
            p.health += h / p.getMaxHealth()
            Game.pushLstLog("You are able to absorb some nutrients through the ground. +" & h & " health")
            If p.health > 1 Then p.health = 1
        End If
    End Sub
    Shared Sub minorRegen()
        Dim p As Player = Game.player
        If p.health < 1 And Game.turn Mod 7 = 0 Then
            Dim h As Integer = Int(Rnd() * 8) + 1
            p.health += h / p.getMaxHealth()
            Game.pushLstLog("A slight glowing aura heals some of your wounds! +" & h & " health")
            If p.health > 1 Then p.health = 1

            If Int(Rnd() * 20) = 0 Then
                Game.pushLblEvent(Game.lblEvent.Text.Split(vbCrLf)(0) & vbCrLf & "Your ring of regeneration goes dim, before shattering into dust.")
                p.inv.item(77).count -= 1
                Equipment.accChange("Nothing")
            End If
        End If
    End Sub
    Shared Sub minorManaRegen()
        Dim p As Player = Game.player
        If p.equippedAcce.getId <> 110 Then
            p.perks("minmanregen") = -1
            Exit Sub
        End If
        If p.mana < p.getMaxMana And Game.turn Mod 5 = 0 Then
            Dim m As Integer = 2
            p.mana += m
            Game.pushLstLog("A slight glowing aura imbues you with magical energy! +" & m & " mana")
            If p.mana > p.getMaxMana Then p.mana = p.getMaxMana
        End If
    End Sub
    Shared Sub Regen()
        Dim p As Player = Game.player
        If p.health < 1 And Game.turn Mod 7 = 0 Then
            Dim h As Integer = Int(Rnd() * 15) + 1
            p.health += h / p.getMaxHealth()
            Game.pushLstLog("A glowing aura heals some of your wounds! +" & h & " health")
            If p.health > 1 Then p.health = 1
        End If
    End Sub
    Shared Function livingArmor() As Boolean
        Dim p As Player = Game.player
        If p.equippedArmor.getName.Equals("Living_Armor") Then
            If Game.turn Mod 6 = 0 And p.lust < 100 Then
                Dim l As Integer = Int(Rnd() * 15) + 10
                p.lust += l
                Game.pushLstLog("Your living armor raises your lust!")
                Return True
            End If
        Else
            p.perks("livearm") = -1
        End If
        Return False
    End Function
    Shared Function livingLingerie() As Boolean
        Dim p As Player = Game.player
        If p.equippedArmor.getName.Equals("Living_Lingerie") Then
            If Game.turn Mod 4 = 0 And p.lust < 100 Then
                Dim l As Integer = Int(Rnd() * 15) + 10
                p.lust += l
                Game.pushLstLog("Your living lingerie raises your lust!")
                Return True
            End If
        Else
            p.perks("livelinge") = -1
        End If
        Return False
    End Function
    Shared Sub lightSource()
        Dim p = Game.player
        If Game.turn Mod 4 = 0 And p.perks("lightsource") > -1 Then
            p.perks("lightsource") -= 1
        End If
    End Sub
    Shared Sub amazon()
        Dim p = Game.player
        If p.pForm.name.Equals("Amazon") Or p.pForm.name.Equals("Amazon​") Then
            If p.equippedWeapon.getName.Equals("Fists") And p.pForm.name.Equals("Amazon​") Then
                p.pForm = p.forms("Amazon")
            ElseIf Not p.equippedWeapon.getName.Equals("Fists") And p.pForm.name.Equals("Amazon") Then
                Game.pushLblEvent("Your lack of familiarity with this weapon greatly lowers your attack potential!")
                p.pForm = p.forms("Amazon​")
            End If
        Else
            p.perks("amazon") = -1
        End If
    End Sub
    Shared Sub barbarian()
        If Not Game.player.pClass.name.Equals("barbarian") Then
            Game.player.perks("barbarian") = -1
        End If
    End Sub
    Shared Sub ROTLGRoute()
        Dim p As Player = Game.player
        Dim rotlg = CType(p.inv.item(81), ROTLGoddess)
        rotlg.sBoost = CInt(2.2222 * p.breastSize)

        rotlg.dBoost = 0
        rotlg.aBoost = 0
        rotlg.mBoost = 0

        If p.equippedArmor.slutVarInd <> -1 Then
            rotlg.dBoost = -p.equippedArmor.dBoost
        Else
            Dim buff = p.equippedArmor.dBoost
            If buff = 0 Then
                buff = 3
            ElseIf buff < 5 Then
                buff = 5
            End If
            buff *= 4
            rotlg.dBoost = buff
            rotlg.aBoost = p.equippedArmor.aBoost * 1.5
            rotlg.mBoost = p.equippedArmor.mBoost * 1.5
        End If

        p.UIupdate()
    End Sub
    Shared Sub BowTieRoute()
        Dim p As Player = Game.player
        Dim btie = CType(p.inv.item(97), Bowtie)

        btie.aBoost = 0
        btie.mBoost = 0

        If (p.equippedArmor.slutVarInd = -1 And p.equippedArmor.antiSlutVarInd <> -1) Or p.equippedArmor.getName.Contains("Bunny") Then
            Dim buff = p.equippedArmor.dBoost
            If buff = 0 Then
                buff = 3
            ElseIf buff < 5 Then
                buff = 5
            End If
            buff *= 3.3
            btie.aBoost = buff + (p.equippedArmor.aBoost * 1.2)
            btie.mBoost = buff + (p.equippedArmor.mBoost * 1.2)
        End If

        p.UIupdate()
    End Sub

    '|TRANSFORMATION TRIGGERS|
    Shared Sub targaxSwordTF()
        Dim p As Player = Game.player
        If p.name <> "Targax" Then
            If Not p.equippedWeapon.getName.Equals("Sword_of_the_Brutal") Then
                p.perks("swordpossess") = -1
            End If
        Else
            p.perks("swordpossess") = -1
        End If
    End Sub
    Shared Sub thrallRestore()
        Dim p As Player = Game.player

        p.prefForm.shiftTowards(Game.player)
        p.perks("thrall") = 1
    End Sub
    Shared Sub aStatue()
        Dim p As Player = Game.player
        If p.perks("astatue") > 1 Then
            p.perks("astatue") -= 1
            p.canMoveFlag = False
        ElseIf p.perks("astatue") <= 1 Then
            p.perks("astatue") = -1
            p.revertToPState()
            p.canMoveFlag = True
        End If
    End Sub
    Shared Sub statueMove(obj As Entity)
        Game.pushLblEvent("You, being a statue, can not do anything.")
    End Sub

    '|SPECIAL MOVE HANDLERS|
    Shared Sub berserkerRage()
        Dim p As Player = Game.player
        If p.perks("brage") > 0 Then
            p.aBuff = p.aBuff + ((p.attack) / 2)
            p.dBuff = p.dBuff - ((p.defence) / 3)
            p.perks("brage") -= 1
        Else
            p.aBuff = 0
            p.dBuff = 0
            p.perks("brage") = -1
            Game.pushLstLog("Berserker rage has worn off.")

        End If
    End Sub
    Shared Sub massiveMammaries()
        Dim p As Player = Game.player
        If p.perks("mmammaries") = 1 Then
            p.dBuff = p.dBuff + ((p.getDEF - p.dBuff) * 0.8)
            p.perks("mmammaries") -= 1
        Else
            p.dBuff = 0
            p.perks("mmammaries") = -1
            Game.pushLstLog("Massive mammaries has worn off.")

        End If
    End Sub
    Shared Sub ironhideFury()
        Dim p As Player = Game.player
        If p.perks("ihfury") = 3 Then
            p.aBuff = p.aBuff + ((p.getATK - p.aBuff) * 0.5)
            p.dBuff = p.dBuff + ((p.getDEF - p.dBuff) * 0.6)
            p.perks("ihfury") -= 1
        ElseIf p.perks("ihfury") > 0 Then
            p.perks("ihfury") -= 1
        Else
            p.aBuff = 0
            p.dBuff = 0
            p.perks("ihfury") = -1
            Game.pushLstLog("Ironhide Fury has worn off.")

        End If
    End Sub

    '|CURSES|
    Shared Function curseOfRust(ByRef p As Player) As Boolean
        Dim updatePortrait = False
        If Game.turn Mod 25 = 0 And (p.equippedAcce.count > 0 Or p.equippedArmor.count > 0 Or p.equippedWeapon.count > 0) Then
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
        If Game.turn Mod 30 = 0 And p.breastSize < 7 Then
            p.be()
            Game.pushLstLog("Your chest begins glowing a sinister red...")
            updatePortrait = True
        End If
        Return updatePortrait
    End Function
    Shared Function curseOfPolymorph(ByRef p As Player) As Boolean
        Dim updatePortrait = False
        If p.perks("copoly") = 0 AndAlso Transformation.canBeTFed(p) Then
            randomPoly()
            p.perks("copoly") = 50 + Int(Rnd() * 100)
            Return True
        ElseIf p.perks("copoly") > 0 Then
            p.perks("copoly") -= 1
        End If
        Return updatePortrait
    End Function
    Private Shared Sub randomPoly()
        Randomize(Game.currFloor.floorCode.GetHashCode)

        Dim tfs As Dictionary(Of String, Action) = New Dictionary(Of String, Action)
        tfs.Add("Minotaur Cow", AddressOf New MinotaurCowTF().step1)
        tfs.Add("Dragon", AddressOf New DragonTF().step1)
        tfs.Add("Succubus", AddressOf New SuccubusTF().step1)
        tfs.Add("Slime", AddressOf New SlimeTF().step1)
        tfs.Add("Bimbo", AddressOf New BimboTF(2, 0, 0.25, True).doubleTf)
        tfs.Add("Cake", AddressOf New TTCCBF().step1)

        Dim form = tfs.Keys(Int(Rnd() * (tfs.Keys.Count - 1)))
        tfs(form)()
        Game.pushLstLog("You're enveloped by a crimson aura...")
        Game.pushLblEvent("You are swiftly enveloped by a blinding crimson aura!  By the time you can see again, it's obvious that you've been physically changed by your curse.")
    End Sub

    '|TAKE DAMAGE PERKS|
    Shared Function onDamage(ByVal dmg As Integer) As Boolean
        Dim flag = False
        flag = bowTieEffect() Or flag
        flag = hardLightEffect(dmg) Or flag
        flag = bimboDodge() Or flag
        flag = stealthDodge() Or flag
        Return flag
    End Function
    Shared Function bowTieEffect() As Boolean
        Dim p = Game.player
        If p.perks("bowtie") > -1 Then
            Dim r = Int(Rnd() * 10)
            If r > 8 And Not p.pClass.name.Equals("Bunny Girl") Then
                Dim dTF = New DancerTF(1, 0, 0, False)
                dTF.update()
                p.drawPort()
                Return True
            ElseIf r > 5 Then
                Game.pushLblEvent("Your bowtie begins glowing, and suddenly everything seems to slow down.  You deftly sidestep the oncomming blow!  Time returns to its normal speed shortly, and your bowtie returns to its inert state.")
                Return True
            End If
        End If
        Return False
    End Function
    Shared Function hardLightEffect(ByVal dmg As Integer) As Boolean
        Dim p = Game.player
        If p.perks("hardlight") > -1 Then
            If Not p.equippedArmor.getName.Contains("Photon") Then
                p.perks("hardlight") = -1
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
    Shared Function bimboDodge() As Boolean
        Dim p = Game.player
        Dim out = "You, like, totally aren't feeling this right now.  Giving your best pout, you wimper ""Hey, stop it!  You're gonna, like, hurt me or something!"".  Squeezing your arms together to show off your cleavage, you look up at your opponent, making sure your lip is quivering just a little bit.  They stop their attack short, looking more confused than merciful.  You don't even consider this subtle distinction though, instead deciding that they, like, totally thought you were too cute to hit!"
        Dim out2 = "You realize that you probably need to dodge this next attack.  Giving your best pout, you wimper ""Hey, stop it!  You're gonna, like, hurt me or something!"".  Squeezing your arms together to show off your cleavage, you look up at your opponent, making sure your lip is quivering just a little bit.  They stop their attack short, looking more confused than merciful.  Inwardly you groan to yourself.   It looks like you aren't out of the woods yet..."
        If p.pClass.name.Equals("Bimbo") And Int(Rnd() * 3) = 0 Then
            Game.pushLblEvent(out)
            Return True
        ElseIf p.pClass.name.Equals("Bimbo++") And Int(Rnd() * 3) = 0 Then
            Game.pushLblEvent(out2)
            Return True
        ElseIf p.pForm.name.Contains("Bimbo") Or p.perks("bimbododge") > 0 And Int(Rnd() * 3) = 0 Then
            Game.pushLblEvent(out)
            Return True
        End If
        Return False
    End Function
    Shared Function stealthDodge() As Boolean
        Dim p = Game.player
        Dim out = "You dodge the oncoming attack!"
        If p.perks("stealth") > 0 And Int(Rnd() * 7) = 0 Then
            Game.pushLblEvent(out)
            Return True
        End If
        Return False
    End Function
End Class
