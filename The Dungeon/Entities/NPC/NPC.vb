Public Class NPC
    Inherits Entity
    'transformation variables
    Public tfCt As Integer = 0
    Public tfEnd As Integer = 0
    Public sName As String
    Public sMaxHealth, sMana, sMaxMana, sAttack, sDefence, sWill, sSpeed As Integer
    'dialog variables
    Public form As String = ""
    Public title As String
    Public pronoun As String = "it"
    Public pPronoun As String = "its"
    Public rPronoun As String = "it"
    Public npcIndex As Integer = 0
    'stun variables
    Public isStunned As Boolean = False
    Public stunct As Integer = 0

    Public Overrides Sub update()
        If tfCt > 0 Then
            tfCt += 1
        ElseIf tfCt > tfEnd Then
            tfCt = 0
            revert()
        End If
        If Game.player.pClass.name = "Thrall" And Me.name.Contains("Thrall") Then
            despawn("friend")
            Exit Sub
        End If
        If Not isStunned Then
            If Game.player.pForm.name.Equals("Black Cat") Or Game.player.pForm.name.Equals("Chicken") And Me.GetType() = GetType(Monster) Then despawn("animaltf")
            nextCombatAction = Sub(t As Entity) attackCMD(t)
        Else
            If Me.GetType() Is GetType(Monster) Then
                Game.pushLstLog("The " & getName() & " is too stunned to react!")
                Game.pushLblCombatEvent("The " & getName() & " is too stunned to react!")
            Else
                Game.pushLstLog(getName() & " is too stunned to react!")
                Game.pushLblCombatEvent(getName() & " is too stunned to react!")
            End If
            If stunct <= 0 Then
                isStunned = False
                stunct = 0
            Else
                stunct -= 1
            End If
        End If

        MyBase.update()
        Game.pushLstLog(getName() & " has " & getIntHealth() & " life.")

    End Sub
    Public Overloads Overrides Sub die(ByRef cause As Entity)
        If isDead Then Exit Sub
        currTarget = Nothing
        nextCombatAction = Nothing

        endMonster()

        Game.player.clearTarget()
        cause.currTarget = Nothing
        cause.nextCombatAction = Nothing


        If getName() = "Explorer" Then
            If MessageBox.Show("Would you like to do the Explorer's body swap?", "Body Swap?", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then 'Int(Rnd() * 3) = 0 Then '
                Try
                    bodySwap(Game.player)
                Catch ex As Exception
                    Game.pushLblEvent("The body swap fails!")
                End Try
            End If
        ElseIf getName.Contains("Enthralling Half-Dem") Then
            Equipment.accChange("Nothing")
        End If

        Game.drawBoard()
    End Sub
    Public Overridable Sub toStatue()
        Game.fromCombat()
        Me.nextCombatAction = Nothing

        Game.pushLblEvent(title & name & "'s chest slowly turns to stone where the spell hits " & rPronoun &
                          ". The petrification spreads out over " & pPronoun & " body, and as more of " & pPronoun &
                          " body turns to a fine gray stone " & pPronoun &
                          " struggling becomes less and less intense. As the last of the life drains out of " &
                          pPronoun & " eyes, all that is left of the once dangerous " & name &
                          " is a lifeless stone statue. It doesn't seem like " & pronoun & " will be needing " &
                          pPronoun & " personal items anymore.", AddressOf Me.endMonster)

        Game.statueList.Add(New Statue(Me))
    End Sub
    Public Overridable Sub toGold()
        Dim gd As Integer = (maxHealth + attack + defence) * 7
        inv.setCount(43, inv.getCountAt(43) + gd)
        Game.fromCombat()
        Me.nextCombatAction = Nothing

        Game.pushLblEvent(title & name & "'s chest slowly turns to solid gold where you poked " & rPronoun & ". The gilded surface spreads out over " & pPronoun & " body, and as more of " & pPronoun & " body turns to the precious metal " & pPronoun & " struggling becomes less and less intense. As the last of the life drains out of " & pPronoun & " eyes, all that is left of the once dangerous " & name & " is a lifeless gold statue, which you then topple over, shattering it into tiny pieces.   " & vbCrLf & "+" & gd & " gold.", AddressOf endMonster)
    End Sub
    Public Overridable Sub toBlade()
        endMonster()
    End Sub
    Public Overridable Sub despawn(ByVal reason As String)
        Game.npcList.Remove(Me)
        Game.player.clearTarget()
        If reason = "run" Then
            If Int(Rnd() * 30) < 2 Then
                Game.pushLstLog("Running away makes you less confident.")
                Game.player.will -= 1
                If Game.player.will < 1 Then Game.player.will = 0
                Game.player.UIupdate()
            End If
            Game.pushLstLog("You ran from the " & name & "!")
        ElseIf reason = "p-death" Then
        ElseIf reason = "friend" Then
            If Int(Rnd() * 3) = 0 Then
                Game.pushLstLog("The " & name & " gives you some supplies before leaving!")
                Game.player.inv.add(2, 1)
                Game.player.inv.add(13, 1)
                Game.player.inv.add(31, 1)
                Game.pushLblEvent("+1 Health_Potion" & vbCrLf & "+1 Mana_Potion" & vbCrLf & "+1 Apple_Potion")
            Else
                Game.pushLstLog("The " & name & " is friendly, and you chat a bit before setting back out!")
            End If
        ElseIf reason = "npc" Then
            Game.pushLstLog("You walk away from " & name & "!")
        ElseIf reason = "animaltf" Then
            Dim output As String = ""
            If Me.GetType() Is GetType(Monster) Then output += "The "
            output += name & ", seeing that you are no longer human, wanders off."
            Game.pushLstLog(output)
        ElseIf reason = "flee" Then
            Dim output As String = ""
            If Me.GetType() Is GetType(Monster) Then output += "The "
            output += name & " runs away in fear!"
            Game.pushLstLog(output)
        ElseIf reason = "cupcake" Then
            Dim c1 As Chest
            c1 = Game.baseChest.Create(inv, pos)
            If inv.getSum > 0 Then c1.open()

            Game.npcList.Remove(Me)
            Game.pushLstLog("You've deafeated the " & name & "!")
            Game.player.currState.save(Game.player)
            isDead = True
            endBoss()
        End If
        If inv.getCountAt(53) > 0 And name <> "Shopkeeper" Then
            Game.pushLblEvent("Your foe drops a key!")
            inv.setCount(53, 1)
            Dim c1 As Chest = Game.baseChest.Create(inv, pos)
            Game.chestList.Add(c1)
        End If
        Game.player.perks("nekocurse") = -1
        Game.player.currState.save(Game.player)
        Game.fromCombat()
        
    End Sub
    Private Sub endBoss()
        If sName.Equals("Marissa the Enchantress") Then
            Game.beatboss(1) = True
            Game.player.perks("nekocurse") = -1
        End If
        If sName.Equals("Targax the Brutal") Then Game.beatboss(2) = True
        If sName.Equals("Explorer") And Game.floor < 6 Then Game.beatboss(Game.floor) = True
        If sName.Equals("Ooze Empress") Then
            'Game.beatboss(4) = True
            Game.floorboss(4) = "Key"
        End If
    End Sub
    Private Sub endMonster()
        'set temporary player pointer
        Dim p As Player = Game.player

        'create the chest for the encounter
        Dim c1 As Chest
        c1 = Game.baseChest.Create(inv, pos)
        If inv.getSum > 0 Then c1.open()

        'will update
        If Int(Rnd() * 20) < 2 Then
            Game.pushLstLog("Your victory makes you feel more confident.")
            p.will += 1
            p.UIupdate()
        End If

        'cleanup of the monster
        isDead = True
        endBoss()
        Game.fromCombat()
        Game.npcList.Remove(Me)
        Game.pushLstLog("You've deafeated the " & name & "!")
        

        'monster transformations
        If sName.Equals("Ooze Empress") Then
            Game.pushLblEvent(Game.lblEvent.Text.Split("Press")(0), AddressOf RandoTF.floor4revert, AddressOf RandoTF.floor4keep, "Take your body back?")
        End If
        For i = 0 To p.ongoingTFs.Count - 1
            If p.ongoingTFs(i).GetType() Is GetType(NekoTF) Then
                p.ongoingTFs(i).stopTF()
                p.ongoingTFs.RemoveAt(i)
            End If
        Next
        p.perks("nekocurse") = -1
        If p.perks("swordpossess") > -1 Then
            p.perks("swordpossess") += 1
            If p.perks("swordpossess") = 2 Then
                TargaxTF.step1()
            ElseIf p.perks("swordpossess") = 3 Then
                TargaxTF.step2()
            ElseIf p.perks("swordpossess") = 4 And name <> "Targax" Then
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

    Public Sub bodySwap(ByRef p As Player)
        p.ongoingTFs.Add(New RandoTF())
        p.update()
        p.health = 0.1
        Game.pushLblEvent("As the explorer is defeated, they mumble some arcane poem and make a hand gesture which causes the two of you to begin glowing.  With a flash, you suddenly find yourself looking at the dungeon from a slightly different angle.  As you black out and collapse, the last thing you see is your grinning face standing over you." & vbCrLf & "The Explorer has taken your body!")
    End Sub
    Public Overrides Sub reachedFPathDest()
        forcedPath = Nothing
    End Sub

    Public Overridable Sub revert()
        name = sName
        maxHealth = sMaxHealth
        attack = sAttack
        defence = sDefence
        speed = sSpeed
        npcIndex = 0
        Game.pushLblEvent("The " & name & " return to " & pPronoun & " original self!")
    End Sub
    Public Sub setInventory(ByVal contents() As Integer)
        inv = New Inventory()
        For i = 0 To UBound(contents)
            If Me.GetType() Is GetType(MiniBoss) Then
                inv.add(contents(i), 1)
            Else
                Dim content = inv.item(contents(i))
                Select Case content.tier
                    Case 3
                        Dim rng = (Int(Rnd() * 9))
                        If rng = 1 Then content.addOne()
                    Case 2
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
    'attacking a player
    Private Sub miss(target As Player)
        Game.pushLstLog(CStr("You are able to evade your opponent!"))
        Game.pushLblCombatEvent(CStr("You are able to evade your opponent!"))
    End Sub
    Private Sub hit(dmg As Integer, target As Player)
        target.takeDMG(dmg, Me)
        Game.pushLstLog(CStr("You got hit! -" & dmg & " health!"))
        Game.pushLblCombatEvent(CStr("You got hit! -" & dmg & " health!"))
    End Sub
    Private Sub cHit(dmg As Integer, target As Player)
        target.takeDMG(dmg * 2, Me)
        Game.pushLstLog(CStr("You got hit! Critical hit! -" & dmg * 2 & " health!"))
        Game.pushLblCombatEvent(CStr("You got hit! Critical hit! -" & dmg * 2 & " health!"))
    End Sub
    'attacking a non-player entity
    Private Sub miss(target As Entity)
        If target.GetType() Is GetType(Player) Then
            miss(CType(target, Player))
            Exit Sub
        End If

        Game.pushLstLog(CStr(target.getName & " is able to evade their opponent!"))
        Game.pushLblCombatEvent(CStr(target.getName & " is are able to evade their opponent!"))
    End Sub
    Private Sub hit(dmg As Integer, target As Entity)
        If target.GetType() Is GetType(Player) Then
            hit(dmg, CType(target, Player))
            Exit Sub
        End If

        target.takeDMG(dmg, Me)
        Game.pushLstLog(CStr(target.getName & " got hit! -" & dmg & " health!"))
        Game.pushLblCombatEvent(CStr(target.getName & " got hit! -" & dmg & " health!"))
    End Sub
    Private Sub cHit(dmg As Integer, target As Entity)
        If target.GetType() Is GetType(Player) Then
            cHit(dmg, CType(target, Player))
            Exit Sub
        End If

        target.takeDMG(dmg * 2, Me)
        Game.pushLstLog(CStr(target.getName & " got hit! Critical hit! -" & dmg * 2 & " health!"))
        Game.pushLblCombatEvent(CStr(target.getName & " got hit! Critical hit! -" & dmg * 2 & " health!"))
    End Sub
    'taking damage
    Public Overrides Sub takeDMG(ByVal dmg As Integer, ByRef source As Entity)
        MyBase.takeDMG(dmg, source)
        If Not source Is Nothing Then currTarget = source
        Game.lblEHealthChange.Tag -= dmg
    End Sub
End Class
