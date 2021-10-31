'| -- Constructor Layout Example -- |
'|ID Info|


'|Stats|


'|Inventory|


'|Dialog Variables|


'|Misc|

Public Class NPC
    Inherits Entity
    'transformation variables
    Public tfCt As Integer = 0
    Public tfEnd As Integer = 0
    Public sMaxHealth, sMana, sMaxMana, sAttack, sdefense, sWill, sSpeed As Integer
    Public xp_value As Integer = 10
    'dialog variables
    Public form As String = ""
    Public title As String = " The "
    Public pronoun As String = "it"
    Public p_pronoun As String = "its"
    Public r_pronoun As String = "it"
    Public img_index As Integer = 0
    'stun variables
    Public isStunned As Boolean = False
    Public stunct As Integer = 0
    Public firstTurn = True
    Dim img As Image

    Public Sub scaleStats(ByVal multiplier As Double)
        maxHealth = Math.Max(1, maxHealth) * multiplier
        maxMana = Math.Max(1, maxMana) * multiplier
        attack = Math.Max(1, attack) * multiplier
        defense = Math.Max(1, defense) * multiplier
        will = Math.Max(1, will) * multiplier
        speed = Math.Max(1, speed) * multiplier
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
        If Not isStunned Then
            If Game.player1.formName.Equals("Black Cat") Or Game.player1.formName.Equals("Chicken") And Me.GetType() = GetType(Monster) Then despawn("animaltf")
            nextCombatAction = Sub(t As Entity) attackCMD(t)
        Else
            If Me.GetType() Is GetType(Monster) Then
                TextEvent.pushAndLog(Trim(title & getName() & " is too stunned to react!"))
            Else
                TextEvent.pushAndLog(Trim(title & getName() & " is too stunned to react!"))
            End If
            If stunct <= 0 Then
                isStunned = False
                stunct = 0
            Else
                stunct -= 1
            End If
        End If

        MyBase.update()
        TextEvent.pushLog(Trim(title & getName() & " has " & getIntHealth() & " life."))
    End Sub
    Public Overloads Overrides Sub die(ByRef cause As Entity)
        If isDead Then Exit Sub
        currTarget = Nothing
        nextCombatAction = Nothing

        endMonster()

        Game.player1.addXP(xp_value)
        cause.currTarget = Nothing
        cause.nextCombatAction = Nothing


        If getName.Contains("Enthralling Half-Dem") Then
            Equipment.accChange(Game.player1, "Nothing")
        End If

        Game.drawBoard()
    End Sub
    Public Overridable Sub toStatue()
        Game.fromCombat()
        Me.nextCombatAction = Nothing

        TextEvent.push(title & name & "'s chest slowly turns to stone where the spell hits " & r_pronoun &
                          ". The petrification spreads out over " & p_pronoun & " body, and as more of " & p_pronoun &
                          " body turns to a fine gray stone " & p_pronoun &
                          " struggling becomes less and less intense. As the last of the life drains out of " &
                          p_pronoun & " eyes, all that is left of the once dangerous " & name &
                          " is a lifeless stone statue. It doesn't seem like " & pronoun & " will be needing " &
                          p_pronoun & " personal items anymore.", AddressOf Me.endMonster)

        Game.currFloor.statueList.Add(New Statue(Me))
    End Sub
    Public Overridable Sub toGold()
        Dim gd As Integer = (maxHealth + attack + defense) * 7
        inv.setCount(43, inv.getCountAt(43) + gd)
        Game.fromCombat()
        Me.nextCombatAction = Nothing

        TextEvent.push(title & name & "'s chest slowly turns to solid gold where you poked " & r_pronoun & ". The gilded surface spreads out over " & p_pronoun & " body, and as more of " & p_pronoun & " body turns to the precious metal " & p_pronoun & " struggling becomes less and less intense. As the last of the life drains out of " & p_pronoun & " eyes, all that is left of the once dangerous " & name & " is a lifeless gold statue, which you then topple over, shattering it into tiny pieces.   " & vbCrLf & "+" & gd & " gold.", AddressOf endMonster)
    End Sub
    Public Overridable Sub toBlade()
        endMonster()
    End Sub
    Public Overridable Sub despawn(ByVal reason As String)
        Game.npc_list.Remove(Me)
        Game.player1.clearTarget()
        If reason = "run" Then
            If Int(Rnd() * 30) < 2 Then
                TextEvent.pushLog("Running away makes you less confident.")
                Game.player1.will -= 1
                If Game.player1.will < 1 Then Game.player1.will = 0
                Game.player1.UIupdate()
            End If
            TextEvent.pushLog("You ran from the " & name & "!")
        ElseIf reason = "warp" Then
            TextEvent.pushLog("With a flash, you teleport the " & name & " far away!")
        ElseIf reason = "pwarp" Then
            TextEvent.pushLog("With a flash, you teleport away!")
        ElseIf reason = "p-death" Then
        ElseIf reason = "friend" Then
            If Int(Rnd() * 3) = 0 Then
                TextEvent.pushLog("The " & name & " gives you some supplies before leaving!")
                Game.player1.inv.add(2, 1)
                Game.player1.inv.add(13, 1)
                Game.player1.inv.add(31, 1)
                TextEvent.push("The " & name & " gives you some supplies before leaving!" &
                                  vbCrLf &
                                  "+1 Health_Potion" & vbCrLf & "+1 Mana_Potion" & vbCrLf & "+1 Apple")
            Else
                TextEvent.pushLog("The " & name & " is friendly, and you chat briefly before setting out!")
            End If
        ElseIf reason = "npc" Then
            TextEvent.pushLog("You walk away from " & Trim(title & getName()) & "!")
        ElseIf reason = "animaltf" Then
            Dim output As String = ""
            If Me.GetType() Is GetType(Monster) Then output += "The "
            output += name & ", seeing that you are no longer human, wanders off."
            TextEvent.pushLog(output)
        ElseIf reason = "shrink" Then
            Dim output As String = ""
            If Me.GetType() Is GetType(Monster) Then output += "The "
            output += name & ", losing track of you, wanders off."
            TextEvent.pushLog(output)
        ElseIf reason = "flee" Then
            Dim output As String = ""
            If Me.GetType() Is GetType(Monster) Then output += "The "
            output += name & " runs away in fear!"
            TextEvent.pushLog(output)
        ElseIf reason = "cupcake" Then
            Dim c1 As Chest
            c1 = DDConst.BASE_CHEST.Create(inv, pos)
            If inv.getSum > 0 Then c1.open()

            Game.npc_list.Remove(Me)
            TextEvent.pushLog("You've defeated the " & name & "!")
            Game.player1.currState.save(Game.player1)
            isDead = True
            endBoss()
        End If
        If inv.getCountAt(53) > 0 And Not Me.GetType().IsSubclassOf(GetType(ShopNPC)) Then
            TextEvent.push("Your foe drops a key!")
            inv.setCount(53, 1)
            Dim c1 As Chest = DDConst.BASE_CHEST.Create(inv, pos)
            Game.currFloor.chestList.Add(c1)
        End If
        Game.player1.perks(perk.nekocurse) = -1
        Game.player1.currState.save(Game.player1)
        Game.fromCombat()

    End Sub
    Private Sub endBoss()
        If Not Me.GetType().IsSubclassOf(GetType(MiniBoss)) Then Exit Sub
        If sName.Equals("Marissa the Enchantress") Then Game.player1.perks(perk.nekocurse) = -1
        If sName.Equals("Medusa, Gorgon of Myth") Then
            If Game.player1.perks(perk.blind) = 2 Then Game.player1.perks(perk.blind) = -1
        End If
        If sName.Equals("Ooze Empress") Then
            Game.mDun.floorboss(4) = "Key"
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

        'will update
        If Int(Rnd() * 20) < 2 Then
            TextEvent.pushLog("Your victory makes you feel more confident.")
            p.will += 1
            p.UIupdate()
        End If

        'cleanup of the monster
        isDead = True
        endBoss()
        If p.perks(perk.cynnsq1ct2) > -1 Then p.perks(perk.cynnsq1ct2) += 1
        Game.fromCombat()
        Game.npc_list.Remove(Me)
        TextEvent.pushLog("You've defeated the " & name & "!  +" & xp_value & " XP!")


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
        TextEvent.pushAndLog("The " & name & " return to " & p_pronoun & " original self!")
    End Sub
    Public Sub setInventory(ByVal contents() As Integer, Optional ByVal resetCurrentInv As Boolean = True)
        If resetCurrentInv Then inv = New Inventory(False)
        For i = 0 To UBound(contents)
            If Me.GetType().IsSubclassOf(GetType(MiniBoss)) Then
                inv.add(contents(i), 1)
            Else
                Dim content = inv.item(contents(i))
                Select Case content.getTier()
                    Case 3
                        Dim rng = (Int(Rnd() * 9))
                        If rng = 1 Then content.addOne()
                    Case 2, Nothing
                        Dim rng = (Int(Rnd() * 6))
                        If rng = 1 Then content.addOne()
                    Case Else
                        Dim rng = (CInt(Rnd() * 5))
                        If rng >= 3 Then rng = 0
                        content.add(rng)
                End Select
            End If
        Next
        inv.setCount(43, CInt(Rnd() * 250)) 'Add some amount of gold
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
    Protected Sub miss(target As Player)
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
    Public Overrides Sub takeDMG(ByVal dmg As Integer, ByRef source As Entity)
        MyBase.takeDMG(dmg, source)
        If Not source Is Nothing Then currTarget = source
        Game.lblEHealthChange.Tag -= dmg
    End Sub
    Public Overridable Function reactToSpell(ByVal spell As String) As Boolean
        Return True
    End Function
    Public Overridable Sub reactToTF()
        If tfCt > 0 Then
            tfCt += 1
        ElseIf tfCt > tfEnd Then
            tfCt = 0
            revert()
        End If
    End Sub

    Overridable Sub playerDeath(ByRef p As Player)
        DeathEffects.hardDeath()
        Game.npc_list.Clear()
    End Sub
End Class
