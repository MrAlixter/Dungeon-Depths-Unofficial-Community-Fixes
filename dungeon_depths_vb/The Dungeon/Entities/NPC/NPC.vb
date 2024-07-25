'| -- Constructor Layout Example -- |
'|ID Info|


'|Stats|


'|Inventory|


'|Dialog Variables|


'|Misc|

Public Enum npc_perk
    tfdur
    stun
    firstturn
    debuffed
    poison
    burn
    bleed
End Enum
Public Class NPC
    Inherits Entity
    'stats
    Public sMaxHealth, sMana, sMaxMana, sAttack, sDefense, sWill, sSpeed As Integer
    Public xp_value As Integer = 10
    Public perks As Dictionary(Of npc_perk, Integer) = New Dictionary(Of npc_perk, Integer)()

    'dialog variables
    Public form As String = ""
    Public title As String = " The "
    Public pronoun As String = "it"
    Public p_pronoun As String = "its"
    Public r_pronoun As String = "it"
    Public intro_taunt As String = ""
    Public img_index As Integer = 0

    Dim img As Image

    Public Sub scaleStats(ByVal multiplier As Double)
        maxHealth = Math.Min(Math.Max(1, maxHealth) * multiplier, DDUtils.INTLMT)
        maxMana = Math.Min(Math.Max(1, maxMana) * multiplier, DDUtils.INTLMT)
        attack = Math.Min(Math.Max(1, attack) * multiplier, DDUtils.INTLMT)
        defense = Math.Min(Math.Max(1, defense) * multiplier, DDUtils.INTLMT)
        will = Math.Min(Math.Max(1, will) * multiplier, DDUtils.INTLMT)
        speed = Math.Min(Math.Max(1, speed) * multiplier, DDUtils.INTLMT)
    End Sub
    Public Sub initPerks()
        perks.Clear()
        'Creates the dictionary of perks
        For Each p In System.Enum.GetValues(GetType(npc_perk))
            perks.Add(p, -1)
        Next
    End Sub
    Public Overrides Sub update()
        reactToTF()

        If (Game.player1.className = "Thrall" And Me.name.Contains("Thrall")) Or
           (Game.player1.formName = "Arachne" And Me.name.Contains("Arachne")) Or
            (Game.player1.formName = "Slime" And Me.name.Contains("Slime")) Or
            (Game.player1.formName.Equals("Goo Girl") And Me.name.Contains("Goo")) Or
            (Game.player1.formName = "Alraune" And Me.name.Contains("Alraune")) Then
            despawn("friend")
            Exit Sub
        End If

        If Not perks(npc_perk.stun) >= 0 Then
            If (Game.player1.formName.Equals("Frog") Or Game.player1.formName.Equals("Chicken") Or (Game.player1.formName.Equals("Cow") And Not sName = Bovinomancer.BASE_NAME) Or Game.player1.formName.Equals("Horse") Or Game.player1.formName.Equals("Unicorn")) And (Me.GetType().IsSubclassOf(GetType(Monster)) And Not Me.GetType().IsSubclassOf(GetType(MiniBoss))) Then
                despawn("animaltf")
                Exit Sub
            End If

            nextCombatAction = Sub(t As Entity) attackCMD(t)
        Else
            handleStun()
        End If

        If perks(npc_perk.poison) > -1 Then
            Dim d As Integer = Math.Min(0.15 * getMaxHealth(), 750)
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " takes " & d & " poison damage!")
            takeDMG(d, Game.player1)
            perks(npc_perk.poison) -= 1
        End If

        If perks(npc_perk.bleed) > 4 Then
            Dim d As Integer = Math.Min(0.2 * getMaxHealth(), 900)
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " takes " & d & " major bleed damage!")
            takeDMG(d, Game.player1)
            perks(npc_perk.bleed) -= 1
        ElseIf perks(npc_perk.bleed) > -1 Then
            Dim d As Integer = Math.Min(0.1 * getMaxHealth(), 600)
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " takes " & d & " bleed damage!")
            takeDMG(d, Game.player1)
            perks(npc_perk.bleed) -= 1
        End If

        If perks(npc_perk.burn) > -1 Then
            Dim d As Integer = 4 + Int(Rnd() * 3)
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " takes " & d & " fire damage!")
            takeDMG(d, Game.player1)
            perks(npc_perk.burn) -= 1
        End If

        MyBase.update()
        TextEvent.pushLog(Trim(title & getName() & " has " & getIntHealth() & " life."))
    End Sub
    Public Overridable Sub handleStun()
        If Me.GetType() Is GetType(Monster) Then
            TextEvent.pushAndLog(Trim(title & getName() & " is too stunned to react!"))
        Else
            TextEvent.pushAndLog(Trim(title & getName() & " is too stunned to react!"))
        End If
        If perks(npc_perk.stun) <= 0 Then
            perks(npc_perk.stun) = -1
        Else
            perks(npc_perk.stun) -= 1
        End If
    End Sub
    Protected Function getXPValue() As Integer
        Dim p As Player = Game.player1

        '| -- Cynn's Tonic -- |
        If p.perks(perk.cynnstonic) > -1 Then
            If p.perks(perk.cynnstonic) < CynnTonic.TIER2 Then
                xp_value *= 1.15
                p.perks(perk.cynnstonic) /= 2
            ElseIf p.perks(perk.cynnstonic) < CynnTonic.TIER3 Then
                xp_value *= 1.25
                p.perks(perk.cynnstonic) *= (7 / 8)
            ElseIf p.perks(perk.cynnstonic) < CynnTonic.TIER4 Then
                xp_value *= 2
                TextEvent.lblEventOnClose = AddressOf CynnTonicTF.blowupCynnTF
            ElseIf p.perks(perk.cynnstonic) < CynnTonic.TIER5 Then
                xp_value *= 10
                TextEvent.lblEventOnClose = AddressOf CynnTonicTF.cynnOnaholeTF
                p.perks(perk.cynnstonic) *= 3
            Else
                TextEvent.lblEventOnClose = AddressOf CynnTonicTF.onaholeTF
            End If
        End If

        Return xp_value
    End Function
    Public Overloads Overrides Sub die(ByRef cause As Entity)
        If isDead Then Exit Sub
        currTarget = Nothing
        nextCombatAction = Nothing
        cause.currTarget = Nothing
        cause.nextCombatAction = Nothing

        Game.player1.addXP(getXPValue)

        endMonster()

        If getName.Contains("Enthralling Half-Dem") Then
            Equipment.accChange(Game.player1, "Nothing")
        End If

        Game.drawBoard()
    End Sub
    Public Overridable Sub toStatue()
        Game.fromCombat()
        Me.nextCombatAction = Nothing

        TextEvent.push("As the fine gray texture of stone engulfs " & getNameWithTitle() & ", " & pronoun & " hardly " & If(pronoun = "they", "seem", "seems") & " able to put up a fight anymore.  What little struggle " & pronoun & " has left only ends up setting the pose that " & pronoun & " will be stuck in, a pose that " & pronoun & " will have to hold for quite some time." & DDUtils.RNRN &
                       "The petrification drains the last of the life from " & p_pronoun & " eyes, leaving behind nothing more of the once threatening " & name & " than an impressively realistic statue." & DDUtils.RNRN &
                       "Hmm, an impressively realistic statue that doesn't seem like " & pronoun & " will be needing " & p_pronoun & " items anymore...", AddressOf Me.endMonster)

        Game.currFloor.statueList.Add(New Statue(Me))
    End Sub
    Public Overridable Sub toGold()
        Dim gd As Integer = (maxHealth + attack + defense) * 7
        inv.setCount(43, inv.getCountAt(43) + gd)
        Game.fromCombat()
        Me.nextCombatAction = Nothing

        TextEvent.push(DDUtils.capitalizeFirst(getNameWithTitle()) & "'s chest slowly turns to solid gold where you poked " & r_pronoun & ".  The gilded texture ripples out over " & p_pronoun & " entire body, and as more and more turns into the precious metal " & p_pronoun & " struggling becomes less and less intense." & DDUtils.RNRN &
                       "As the last of the life drains out of " & p_pronoun & " eyes, all that is left of the once dangerous " & name & " is a lifeless gold statue, which you then topple over, shattering it into tiny pieces." & DDUtils.RNRN &
                       "+" & gd & " Gold", AddressOf endMonster)
    End Sub
    Public Overridable Sub toBlade()
        endMonster()
    End Sub
    Public Overridable Sub despawn(ByVal reason As String)
        '| - General Despawn Logic - |
        Game.npc_list.Remove(Me)
        Game.player1.clearTarget()
        Game.player1.perks(perk.nekocurse) = -1
        Game.player1.currState.save(Game.player1)
        Game.fromCombat()

        '| - Specific Despawn Cases - |
        If reason = "run" Then
            TextEvent.pushLog("You ran from " & getNameWithTitle() & "!")
            If Int(Rnd() * 30) < 2 Then
                TextEvent.pushLog("Running away makes you less confident...")
                Game.player1.will -= 1
                If Game.player1.will < 1 Then Game.player1.will = 0
                Game.player1.UIupdate()
            End If
        ElseIf reason = "warp" Then
            TextEvent.pushAndLog("With a flash, you teleport " & getNameWithTitle() & " far away!")
        ElseIf reason = "pwarp" Then
            TextEvent.pushAndLog("With a flash, you teleport away!")
        ElseIf reason = "p-death" Then
            If Game.lstLog.Items(Game.lstLog.Items.Count - 1).Equals("You are defeated!") Then Game.lstLog.Items.RemoveAt(Game.lstLog.Items.Count - 1)
            TextEvent.pushLog("You are defeated by " & getNameWithTitle() & "...")
        ElseIf reason = "friend" Then
            If Int(Rnd() * 3) = 0 Then
                TextEvent.pushLog(DDUtils.capitalizeFirst(getNameWithTitle) & " is friendly, and " & pronoun & " gives you some supplies!")
                TextEvent.push(DDUtils.capitalizeFirst(getNameWithTitle) & " is friendly, and " & pronoun & " gives you some supplies!" & DDUtils.RNRN &
                               "+1 " & HealthPotion.ITEM_NAME.Replace("_", " ") & vbCrLf &
                               "+1 " & ManaPotion.ITEM_NAME.Replace("_", " ") & vbCrLf &
                               "+1 " & Apple.ITEM_NAME.Replace("_", " "))
                Game.player1.inv.add(HealthPotion.ITEM_NAME, 1)
                Game.player1.inv.add(ManaPotion.ITEM_NAME, 1)
                Game.player1.inv.add(Apple.ITEM_NAME, 1)
            Else
                TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " is friendly, and the fight resolves itself peacefully...")
            End If
        ElseIf reason = "npc" Then
            TextEvent.pushLog("You walk away from " & getNameWithTitle() & "!")
        ElseIf reason = "animaltf" Then
            Dim output As String = ""
            output += DDUtils.capitalizeFirst(getNameWithTitle()) & " sees you as nothing but a harmless animal, and wanders off..."
            TextEvent.pushAndLog(output)
        ElseIf reason = "shrink" Then
            Dim output As String = ""
            output += DDUtils.capitalizeFirst(getNameWithTitle()) & ", losing track of you, wanders off."
            TextEvent.pushAndLog(output)
        ElseIf reason = "flee" Then
            Dim output As String = ""
            output += DDUtils.capitalizeFirst(getNameWithTitle()) & " runs away in fear!"
            TextEvent.pushAndLog(output)
        ElseIf reason = "cupcake" Then
            Dim c1 As Chest
            c1 = DDConst.BASE_CHEST.Create(inv, pos)
            If inv.getSum > 0 Then c1.open()
            Game.npc_list.Remove(Me)
            TextEvent.pushLog("You've defeated " & getNameWithTitle() & "!")
            Game.player1.currState.save(Game.player1)
            isDead = True
            endBoss()
        End If

        '| - Key Handling - |
        If inv.getCountAt(53) > 0 And Not Me.GetType().IsSubclassOf(GetType(ShopNPC)) And Not Me.GetType().IsSubclassOf(GetType(MiniBoss)) And Not Me.GetType().IsSubclassOf(GetType(Boss)) Then
            TextEvent.push("Your foe drops a key!")
            inv.setCount(53, 1)
            Dim c1 As Chest = DDConst.BASE_CHEST.Create(inv, pos)
            Game.currFloor.chestList.Add(c1)
        End If
    End Sub
    Private Sub endBoss()
        If Not Me.GetType().IsSubclassOf(GetType(MiniBoss)) Then Exit Sub
        If sName.Equals("Marissa the Enchantress") Then Game.player1.perks(perk.nekocurse) = -1
        If sName.Equals("Medusa, Gorgon of Myth") Then
            If Game.player1.perks(perk.blind) = 2 Then Game.player1.perks(perk.blind) = -1
        End If
        If sName.Equals("Ooze Empress") Then
            Game.mDun.floor_boss(4) = "Key"
            Exit Sub
        End If

        Game.currFloor.beatBoss = True
    End Sub
    Protected Sub endMonster()
        'set temporary player pointer
        Dim p As Player = Game.player1

        'create the chest for the encounter
        Dim c1 As Chest
        c1 = DDConst.BASE_CHEST.Create(inv, pos)
        If inv.getSum > 0 Then c1.open()

        'cleanup of the monster
        isDead = True
        endBoss()
        If p.perks(perk.cynnsq1ct2) > -1 Then p.perks(perk.cynnsq1ct2) += 1
        Game.fromCombat()
        Game.npc_list.Remove(Me)
        TextEvent.push2ndLastLog("You've defeated the " & name & "!  +" & xp_value & " XP!")

        'will update
        If Int(Rnd() * 20) < 2 Then
            TextEvent.pushLog("Your victory makes you feel more confident.")
            p.will += 1
            p.UIupdate()
        End If

        'monster transformations
        p.ongoingTFs.remove(tfind.neko)

        p.perks(perk.nekocurse) = -1
        If p.perks(perk.swordpossess) > -1 Then
            p.perks(perk.swordpossess) += 1
            If p.perks(perk.swordpossess) = 2 Then
                TargaxTF.step1()
            ElseIf p.perks(perk.swordpossess) = 3 Then
                TargaxTF.step2()
            ElseIf p.perks(perk.swordpossess) = 4 And name <> "Targax" Then
                TargaxTF.step3()
            End If
        End If
    End Sub
    Public Overrides Function getName() As String
        If form = "" Then
            Return name
        Else
            Return form & " (" & name & ")"
        End If
    End Function
    Public Function getNameWithTitle() As String
        Return Trim(title.ToLower & getName())
    End Function
    Public Overrides Sub reachedFPathDest()
        forcedPath = Nothing
    End Sub

    Public Overridable Sub revert()
        name = sName
        maxHealth = sMaxHealth
        attack = sAttack
        defense = sdefense
        speed = sSpeed
        img_index = 0
        form = ""
        TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle()) & " returns to " & p_pronoun & " original self!")
    End Sub
    Public Sub setInventory(ByVal contents() As Integer, Optional ByVal resetCurrentInv As Boolean = True)
        If resetCurrentInv Then inv = New Inventory(False)
        For i = 0 To UBound(contents)
            If Me.GetType().IsSubclassOf(GetType(MiniBoss)) Then
                inv.add(contents(i), 1)
            Else
                Dim content = inv.item(contents(i))
                Select Case content.getTier(Game.mDun.numCurrFloor)
                    Case 3
                        Dim rng = (Int(Rnd() * 9))
                        If rng = 1 Then content.addOne()
                    Case 2, Nothing
                        Dim rng = (Int(Rnd() * 6))
                        If rng < 2 Then content.addOne()
                    Case Else
                        Dim rng = (Int(Rnd() * 5))
                        If rng < 4 Then rng = 0
                        content.add(rng)
                End Select
            End If
        Next

        inv.setCount(43, CInt(Rnd() * 250)) 'Add some amount of gold

        If Game.player1.equippedGlasses.getAName.Equals(SwashMagicEPatch.ITEM_NAME) Then inv.setCount(43, inv.getCountAt(43) * 2)
    End Sub

    '|COMBAT|
    Public Overrides Sub attackCMD(ByRef target As Entity)
        Dim crit = Int(Rnd() * 20) 'roll for a critical
        Dim dmg = calcDamage(Me.getATK, target.getDEF) 'calculate the hit
        If dmg > 0 Then dmg += Int(Rnd() * 3) + -1 'adds some variance

        Select Case crit
            Case 19
                cHit(dmg, target)
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
    Public Overridable Sub attackSpell(ByRef target As Entity, ByVal spellName As String, ByVal dmg As Integer)
        TextEvent.pushAndLog(Trim(title & getName() & " casts " & spellName & "!"))

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
    'attacking a player
    Protected Overridable Sub miss(target As Player)
        TextEvent.pushAndLog(CStr("You are able to evade your opponent!"))
    End Sub
    Protected Sub hit(dmg As Integer, target As Player)
        target.takeDMG(dmg, Me)
    End Sub
    Protected Sub cHit(dmg As Integer, target As Player)
        target.takeCritDMG(dmg * 2, Me)
    End Sub
    'attacking a non-player entity
    Private Sub miss(target As Entity)
        If target.GetType() Is GetType(Player) Then
            miss(CType(target, Player))
            Exit Sub
        End If

        TextEvent.pushAndLog(CStr(target.getName & " is are able to evade their opponent!"))
    End Sub
    Private Sub hit(dmg As Integer, target As Entity)
        If target.GetType() Is GetType(Player) Then
            hit(dmg, CType(target, Player))
            Exit Sub
        End If

        target.takeDMG(dmg, Me)

        TextEvent.pushAndLog(CStr(target.getName & " got hit! -" & dmg & " health!"))
    End Sub
    Private Sub cHit(dmg As Integer, target As Entity)
        If target.GetType() Is GetType(Player) Then
            cHit(dmg, CType(target, Player))
            Exit Sub
        End If

        target.takeDMG(dmg * 2, Me)

        TextEvent.pushAndLog(CStr(target.getName & " got hit! Critical hit! -" & dmg * 2 & " health!"))
    End Sub
    'taking damage
    Public Overrides Function takeDMG(ByRef dmg As Integer, ByRef source As Entity) As Boolean
        Dim took_damage = MyBase.takeDMG(dmg, source)

        If took_damage Then
            If Not source Is Nothing Then currTarget = source
            Game.lblEHealthChange.Tag -= dmg
        End If

        Return took_damage
    End Function
    Public Overridable Function reactToSpell(ByVal spell As String) As Boolean
        Return True
    End Function
    Public Overridable Sub reactToTF()
        If perks(npc_perk.tfdur) > 0 Then
            perks(npc_perk.tfdur) -= 1
        ElseIf perks(npc_perk.tfdur) <> -1 Then
            perks(npc_perk.tfdur) = -1
            revert()
        End If
    End Sub

    Overridable Sub playerDeath(ByRef p As Player)
        DeathEffects.hardDeath()
        Game.npc_list.Clear()
    End Sub
End Class
