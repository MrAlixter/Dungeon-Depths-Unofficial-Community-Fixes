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
                inventory = {1}
            Case 0
                name = "Zombie"
                health = 75
                maxHealth = 75
                attack = 15
                defence = 5
                speed = 5
                inventory = {0, 1}
            Case 1
                name = "Slime"
                health = 75
                maxHealth = 75
                attack = 15
                defence = 2
                speed = 7
                inventory = {0, 0, 0, 2}
            Case 2
                Try
                    loadGhost()
                Catch ex As Exception
                    name = "Zombie"
                    health = 75
                    maxHealth = 75
                    attack = 15
                    defence = 5
                    speed = 5
                    inventory = {0, 1}
                End Try
            Case 3
                name = "Goo Girl"
                health = 150
                maxHealth = 150
                attack = 30
                defence = 4
                speed = 14
                inventory = {0, 0, 0, 2}
            Case 4
                name = "Shadow Warrior"
                health = 200
                maxHealth = 200
                attack = 50
                defence = 10
                speed = 10
                inventory = {0, 0, 2, 0, 0, Int(Rnd() * 2)}
            Case 5
                name = "Mimic"
                health = 150
                maxHealth = 150
                attack = 25
                defence = 10
                speed = 50
                inventory = {0}
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
        target.takeDMG(attack)
    End Sub
    Public Sub takeDMG(ByVal dmg As Integer)
        health -= dmg
        Game.lblEHealthChange.Tag -= dmg
    End Sub
    Public Sub Die()
        endMonster()
        Game.npcList.Remove(Me)
        If mindex = 2 And Not name.Equals("Zombie") Then
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
        If health <= 0 Then
            Die()
            Exit Sub
        End If
        If dead = True Then Exit Sub
        If tfCt > 0 Then
            tfCt += 1
        ElseIf tfCt > tfEnd Then
            tfCt = 0
            revert()
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
        endMonster()
        Dim gd As Integer = (maxHealth + attack + defence) * 7
        Game.pushLblEvent(title & name & "'s chest slowly turns to solid gold where you poked " & rPronoun & ". The gilded surface spreads out over " & pPronoun & " body, and as more of " & pPronoun & " body turns to the precious metal " & pPronoun & " struggling becomes less and less intense. As the last of the life drains out of " & pPronoun & " eyes, all that is left of the once dangerous " & name & " is a lifeless gold statue, which you then topple over, shattering it into tiny pieces.   " & vbCrLf & "+" & gd & " gold.")
        Game.player.gold += gd
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
    End Sub
    Private Sub endMonster()
        Dim totalSum As Integer = 0
        For i = 0 To UBound(inventory)
            totalSum += inventory(i)
        Next
        Dim c1 As Chest
        c1 = Game.baseChest.Create(inventory, pos)
        If totalSum > 0 Then c1.open()
        Game.npcList.Remove(Me)
        Game.lstLog.Items.Add("You've deafeated the " & name & "!")
        Game.player.perks("nekocurse") = -1
        Game.player.currState.save(Game.player)
        Game.fromCombat()
        If Game.player.perks("swordpossess") > -1 Then Game.player.perks("swordpossess") += 1
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
End Class
