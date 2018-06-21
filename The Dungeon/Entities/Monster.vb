Public Class Monster
    Implements Updatable
    Public name As String
    Public form As String = ""
    Public title As String
    Public health, maxHealth, attack, defence, speed As Integer
    Public sName As String
    Public dead As Boolean = False
    Dim sHealth, sMaxHealth, sAttack, sDefence, sSpeed As Integer
    Public inventory() As Integer
    Public firstTurn = True
    Public pronoun As String = "it"
    Public pPronoun As String = "its"
    Public rPronoun As String = "it"
    Public tfCt As Integer = 0
    Public tfEnd As Integer = 0
    Public pos As Point
    Public npcIndex As Integer = 0
    Public discount As Boolean = False
    Public mindex As Integer
    Public isStunned As Boolean = False
    Public stunct As Integer = 0
    Dim img As Image

    Sub New(ByVal mIndex As Integer)
        Select Case mIndex
            Case -1
                name = "Explorer"
                setInventory({0})
            Case 0
                name = "Mesmerized Thrall"
                health = 75
                maxHealth = 75
                attack = 15
                defence = 5
                speed = 5
                setInventory({0, 1, 13})
            Case 1
                name = "Slime"
                health = 75
                maxHealth = 75
                attack = 15
                defence = 2
                speed = 7
                setInventory({2, 3})
            Case 2
                Try
                    loadGhost()
                Catch ex As Exception
                    name = "Mesmerized Thrall"
                    health = 75
                    maxHealth = 75
                    attack = 15
                    defence = 5
                    speed = 5
                    setInventory({0, 1, 13})
                End Try
            Case 3
                name = "Goo Girl"
                health = 200
                maxHealth = 200
                attack = 30
                defence = 4
                speed = 14
                setInventory({3})
            Case 4
                Dim rng = Int(Rnd() * 2)
                If rng = 0 Then
                    name = "Enthralling Sorcerer"
                Else
                    name = "Enthralling Sorceress"
                End If
                health = 150
                maxHealth = 150
                attack = 25
                defence = 10
                speed = 20
                setInventory({4, 13})
            Case 5
                name = "Mimic"
                health = 150
                maxHealth = 150
                attack = 25
                defence = 10
                speed = 50
                setInventory({0})
            Case 6
                name = "Spider"
                health = 50
                maxHealth = 50
                attack = 35
                defence = 8
                speed = 45
                setInventory({63})
            Case 7
                name = "Arachne Huntress"
                health = 100
                maxHealth = 100
                attack = 50
                defence = 15
                speed = 60
                setInventory({63, 64})
            Case Else
                name = "Some Guy"
                health = 66
                maxHealth = 66
                attack = 1
                defence = 1
                speed = 1
                ReDim inventory(Game.player.inventorynames.Count - 1)
                For i = 0 To 2
                    inventory(Int(Rnd() * Game.player.inventorynames.Count)) = (Int(Rnd() * 2) + 1)
                Next
        End Select

        sName = name
        sHealth = health
        sMaxHealth = maxHealth
        sAttack = attack
        sDefence = defence
        sSpeed = speed

        title = " The "
        Me.mindex = mIndex
        sName = name
        If speed = Game.player.getSpeed Then speed -= 1
        pos = Game.player.pos
    End Sub
    Public Overridable Sub attackCMD(ByVal target As Player)
        Game.player.currTarget = Me
        Dim crit = Int(Rnd() * 20)
        Dim dmg = attack
        Select Case crit
            Case 19
                dmg = -2
            Case Else
                If target.getSpeed <= 20 Then
                    If crit < 1 Then dmg = -1
                ElseIf target.getSpeed <= 40 Then
                    If crit < 2 Then dmg = -1
                ElseIf target.getSpeed <= 60 Then
                    If crit < 3 Then dmg = -1
                ElseIf target.getSpeed <= 80 Then
                    If crit < 4 Then dmg = -1
                ElseIf target.getSpeed <= 100 Then
                    If crit < 5 Then dmg = -1
                Else
                    Dim ebound = 5 + ((target.getSpeed / 9999) * 5)
                    If ebound > 12 Then ebound = 12
                    If crit < ebound Then dmg = -1
                End If
        End Select
        target.takeDMG(dmg)
    End Sub
    Public Sub takeDMG(ByVal dmg As Integer)
        health -= dmg
        Game.lblEHealthChange.Tag -= dmg
    End Sub
    Public Sub Die()
        If name = "Explorer" Then
            If MessageBox.Show("Would you like to do the Explorer's body swap?", "Body Swap?", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then 'Int(Rnd() * 3) = 0 Then '
                Try
                    bodySwap(Game.player)
                Catch ex As Exception
                    Game.pushLblEvent("The body swap fails!")
                End Try
            End If
        End If
        endMonster()
        If mindex = 2 And Not name.Equals("Mesmerized Thrall") Then
            Dim writer As IO.StreamWriter
            writer = IO.File.CreateText("gho.sts")
            writer.WriteLine("MTGRAVE")
            writer.Flush()
            writer.Close()
        End If
    End Sub
    Public Overridable Sub despawn(ByVal reason As String)
        Game.npcList.Remove(Me)
        If reason = "run" Then
            Game.lstLog.Items.Add("You ran from the " & name & "!")
        ElseIf reason = "friend" Then
            If Int(Rnd() * 3) = 0 Then
                Game.lstLog.Items.Add("The " & name & " gives you some supplies before leaving!")
                Game.player.inventory(2).addone()
                Game.player.inventory(13).addone()
                Game.player.inventory(31).addone()
                Game.pushLblEvent("+1 Health_Potion" & vbCrLf & "+1 Mana_Potion" & vbCrLf & "+1 Apple_Potion")
            Else
                Game.lstLog.Items.Add("The " & name & " is friendly, and you chat a bit before setting back out!")
            End If
            ElseIf reason = "npc" Then
                Game.lstLog.Items.Add("You walk away from " & name & "!")
            ElseIf reason = "animaltf" Then
                Dim output As String = ""
                If Me.GetType() Is GetType(Monster) Then output += "The "
                output += name & ", seeing that you are no longer human, wanders off."
                Game.lstLog.Items.Add(output)
            ElseIf reason = "flee" Then
                Dim output As String = ""
                If Me.GetType() Is GetType(Monster) Then output += "The "
                output += name & " runs away in fear!"
                Game.lstLog.Items.Add(output)
            ElseIf reason = "cupcake" Then
                Dim totalSum As Integer = 0
                For i = 0 To UBound(inventory)
                    totalSum += inventory(i)
                Next
                Dim c1 As Chest
                c1 = Game.baseChest.Create(inventory, pos)
                If totalSum > 0 Then c1.open()
                Game.npcList.Remove(Me)
                Game.lstLog.Items.Add("You've deafeated the " & name & "!")
                Game.player.currState.save(Game.player)
                dead = True
                endBoss()
            End If
            If UBound(inventory) >= 53 AndAlso inventory(53) > 0 And name <> "Shopkeeper" Then
                Game.pushLblEvent("Your foe drops a key!")
                Dim inv(53) As Integer
                inv(53) = 1
                Dim c1 As Chest = Game.baseChest.Create(inventory, pos)
                Game.chestList.Add(c1)
            End If
            Game.player.perks("nekocurse") = -1
            Game.player.currState.save(Game.player)
            Game.fromCombat()
            Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Public Overridable Sub update() Implements Updatable.update
        Game.player.currTarget = Me
        If health <= 0 Then
            Die()
            Exit Sub
        End If
        If tfCt > 0 Then
            tfCt += 1
        ElseIf tfCt > tfEnd Then
            tfCt = 0
            revert()
        End If
        If Game.player.title = "Thrall" And Me.name.Contains("Thrall") Then
            despawn("friend")
            Exit Sub
        End If
        If Not isStunned Then
            If Game.player.title = "Black Cat" Or Game.player.title = "Chicken" And Me.GetType() = GetType(Monster) Then despawn("animaltf")
            attackCMD(Game.player)
        Else
            If Me.GetType() Is GetType(Monster) Then
                Game.lstLog.Items.Add("The " & getName() & " is too stunned to react!")
                Game.pushLblCombatEvent("The " & getName() & " is too stunned to react!")
            Else
                Game.lstLog.Items.Add(getName() & " is too stunned to react!")
                Game.pushLblCombatEvent(getName() & " is too stunned to react!")
            End If
            If stunct <= 0 Then
                isStunned = False
                stunct = 0
            Else
                stunct -= 1
            End If
        End If
        Game.lstLog.Items.Add(getName() & " has " & health & " life.")
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Public Overridable Sub toStatue()
        endMonster()
        Game.pushLblEvent(title & name & "'s chest slowly turns to stone where the spell hits " & rPronoun & ". The petrification spreads out over " & pPronoun & " body, and as more of " & pPronoun & " body turns to a fine gray stone " & pPronoun & " struggling becomes less and less intense. As the last of the life drains out of " & pPronoun & " eyes, all that is left of the once dangerous " & name & " is a lifeless stone statue. It doesn't seem like " & pronoun & " will be needing " & pPronoun & " personal items anymore.")
        Game.statueList.Add(New Statue(Me))
    End Sub
    Public Overridable Sub toGold()
        Dim gd As Integer = (maxHealth + attack + defence) * 7
        inventory(43) += gd
        endMonster()
        Game.pushLblEvent(title & name & "'s chest slowly turns to solid gold where you poked " & rPronoun & ". The gilded surface spreads out over " & pPronoun & " body, and as more of " & pPronoun & " body turns to the precious metal " & pPronoun & " struggling becomes less and less intense. As the last of the life drains out of " & pPronoun & " eyes, all that is left of the once dangerous " & name & " is a lifeless gold statue, which you then topple over, shattering it into tiny pieces.   " & vbCrLf & "+" & gd & " gold.")
    End Sub
    Public Overridable Sub toBlade()
        endMonster()
    End Sub
    Public Overridable Sub revert()
        name = sName
        health = sHealth
        maxHealth = sMaxHealth
        attack = sAttack
        defence = sDefence
        speed = sSpeed
        npcIndex = 0
        Game.pushLblEvent("The " & name & " return to " & pPronoun & " original self!")
    End Sub
    Public Sub setInventory(ByVal inv() As Integer)
        ReDim inventory(Game.player.inventory.Count - 1)
        For i = 0 To UBound(inv)
            Select Case Game.player.inventory(inv(i)).tier
                Case 3
                    Dim rng = (Int(Rnd() * 5))
                    If rng = 1 Then inventory(inv(i)) += 1
                Case 2
                    Dim rng = (Int(Rnd() * 3))
                    If rng = 1 Then inventory(inv(i)) += 1
                Case Else
                    Dim rng = (Int(Rnd() * 5))
                    If rng = 3 Or rng = 4 Then rng = 0
                    inventory(inv(i)) += rng
            End Select
        Next
        inventory(43) = Int(Rnd() * 250) 'Add some amount of gold
    End Sub

    Shared Sub createMimic(ByVal cont() As Integer)
        Dim m As Monster = New Monster(5)
        m.inventory = cont
        Game.npcList.Add(m)
        Game.player.currTarget = m
        Game.toCombat()
        Game.lstLog.Items.Add((m.getName() & " attacks!"))
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        Game.drawBoard()
    End Sub
    Private Function loadGhost() As Boolean
        Dim reader As IO.StreamReader
        reader = IO.File.OpenText("gho.sts")

        Dim ghost As String
        Try
            ghost = reader.ReadLine()
            ghost.Split()
        Catch e As Exception
            Return False
        End Try

        Dim ghostArray() As String = ghost.Split("*")

        name = ghostArray(0)
        health = ghostArray(2)
        maxHealth = ghostArray(2)
        attack = ghostArray(3)
        defence = ghostArray(4)
        speed = ghostArray(5)
        Dim sexBool As Boolean = CBool(ghostArray(6))
        Dim haircolor As Color = Color.FromArgb(255, ghostArray(7), ghostArray(8), ghostArray(9))

        ReDim inventory(Game.player.inventorynames.Count)
        For i = 0 To UBound(inventory)
            inventory(i) = ghostArray(10 + i)
        Next
        reader.Close()
        Return True
    End Function
    Private Sub endBoss()
        If sName.Equals("Marissa the Enchantress") Then Game.beatboss(1) = True
        If sName.Equals("Targax the Brutal") Then Game.beatboss(2) = True
        If sName.Equals("Explorer") And Game.floor < 6 Then Game.beatboss(Game.floor) = True
    End Sub
    Private Sub endMonster()
        Dim totalSum As Integer = 0
        For i = 0 To UBound(inventory)
            totalSum += inventory(i)
        Next
        Dim c1 As Chest
        c1 = Game.baseChest.Create(inventory, pos)
        If totalSum > 0 Then c1.open()
        If name = "Explorer" Then Game.pushLblEvent("As the explorer is defeated, they mumble some arcane poem and make a hand gesture which causes the two of you to begin glowing.  With a flash, you suddenly find yourself looking at the dungeon from a slightly different angle.  As you black out and collapse, the last thing you see is your grinning face standing over you." & vbCrLf & "The Explorer has taken your body!")
        Game.npcList.Remove(Me)
        Game.lstLog.Items.Add("You've deafeated the " & name & "!")
        Game.player.perks("nekocurse") = -1
            Game.player.currState.save(Game.player)
            Game.fromCombat()
            If Game.player.perks("swordpossess") > -1 Then
                Game.player.perks("swordpossess") += 1
                If Game.player.perks("swordpossess") = 2 Then
                    Polymorph.transform(Game.player, "targax", 0)
                ElseIf Game.player.perks("swordpossess") = 4 Then
                    Polymorph.transform(Game.player, "targax", 1)
                ElseIf Game.player.perks("swordpossess") = 6 And name <> "Targax" Then
                    Polymorph.transform(Game.player, "targax", 2)
                End If
            End If

            dead = True
            endBoss()
            Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Public Function getName() As String
        If form = "" Then
            Return name
        Else
            Return form & " (" & name & ")"
        End If
    End Function

    Public Sub bodySwap(ByRef p As Player)
        Randomize()

        p.title = "Explorer"
        p.sex = "Female"
        p.sexBool = True

        p.health = 10
        p.maxHealth = 70 + Int(Rnd() * 50)
        p.attack = 5 + Int(Rnd() * 7)
        p.defence = 5 + Int(Rnd() * 7)
        p.discipline = 5 + Int(Rnd() * 7)
        p.speed = 5 + Int(Rnd() * 7)
        p.evade = 5 + Int(Rnd() * 7)
        p.gold = 25 + Int(Rnd() * 200)
        p.lust = 0
        p.mana = Int(Rnd() * 7)
        p.hunger = 0
        p.hBuff = 0
        p.mBuff = 0
        p.wBuff = 0
        p.aBuff = 0
        p.dBuff = 0

        p.breastSize = Int(Rnd() * 3) + 1

        p.inventory.Clear()
        p.perks.Clear()
        p.inventorynames.Clear()
        Game.Potions.Clear()
        p.createInvPerks()
        Game.loadPotionList()

        Dim armor = New Integer() {5, 7, 12, 16, 17, 18, 19, 20, 38, 39, 46, 47, 54, 54}
        Dim armorIndex = armor(Int(Rnd() * (armor.Length)))
        Dim weapon = New Integer() {6, 9, 21, 22}
        Dim weaponIndex = weapon(Int(Rnd() * (weapon.Length )))
        p.inventory(armorIndex).addOne()
        p.inventory(weaponIndex).addOne()
        p.equippedArmor = p.inventory(armorIndex)
        p.equippedWeapon = p.inventory(weaponIndex)

        p.genRandomPortrait(True)

        Dim si As Integer = p.sState.iArrInd(3).Item1
        p.currState.save(p)
        p.pState.save(p)
        p.sState.save(p)
        p.sState.iArrInd(3) = New Tuple(Of Integer, Boolean)(si, True)
    End Sub
End Class
