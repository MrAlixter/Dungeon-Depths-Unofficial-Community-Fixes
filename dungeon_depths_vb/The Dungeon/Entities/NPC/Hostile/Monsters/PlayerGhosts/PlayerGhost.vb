Public Class PlayerGhost
    Inherits Monster

    Public Const BASE_NAME As String = "Player Ghost"

    Protected first_name As String = "Ghost"
    Protected class_name As String = "Classless"

    Protected sex_bool As Boolean
    Protected eye_ind As Tuple(Of Integer, Boolean, Boolean)
    Protected haircolor As Color

    Protected deathfloor = ""

    Sub New()
        loadGhost()

        'don't summon ghosts of the player's current character
        If first_name.Equals(Game.player1.getName) Then Throw New Exception

        'set the ghost's class
        name = first_name & " the " & redefineClassName(class_name)

        setupMonsterOnSpawn(False)
        title = " "

        'if the player died on this floor, their belongings will be in a chest
        If deathfloor.Equals(Game.currFloor.floorCode) Then inv = New Inventory()
    End Sub

    '| - LOADING THE GHOST - |
    Protected Overridable Function loadGhost() As Boolean
        Dim reader As IO.StreamReader
        reader = IO.File.OpenText("gho.sts")

        Try
            Dim ghost_array() As String = reader.ReadLine().Split("*")

            'personal information
            name = ghost_array(0)
            first_name = name.Split(" the " & class_name)(0)
            deathfloor = ghost_array(1)
            class_name = ghost_array(2)

            'stats
            health = ghost_array(4)
            maxHealth = ghost_array(4)
            attack = ghost_array(5)
            mana = ghost_array(6)
            defense = ghost_array(7)
            speed = ghost_array(8)
            will = ghost_array(9)

            'portrait
            sex_bool = CBool(ghost_array(10))
            eye_ind = New Tuple(Of Integer, Boolean, Boolean)(ghost_array(11), ghost_array(12), ghost_array(13))
            haircolor = Color.FromArgb(255, ghost_array(14), ghost_array(15), ghost_array(16))

            'inventory
            setGhostInventory(ghost_array(17))

            Return True
        Finally
            reader.Close()
        End Try

        Return False
    End Function
    Sub setGhostInventory(ByVal s As String)
        Dim old_inventory As Inventory = New Inventory()
        old_inventory.load(s)

        Dim number_of_drops As Integer = 5

        Dim checked_items As List(Of Integer) = New List(Of Integer)
        checked_items.Add(43)

        Do While number_of_drops > 0
            If checked_items.count = inv.count Then Exit Do

            Dim rnd_ind As Integer = Int(Rnd() * inv.Count)

            If Not checked_items.Contains(rnd_ind) AndAlso old_inventory.item(rnd_ind).count > 0 Then
                inv.item(rnd_ind).count = old_inventory.item(rnd_ind).count
                number_of_drops -= 1
            End If

            checked_items.Add(rnd_ind)
        Loop
    End Sub
    Function redefineClassName(ByVal s As String) As String
        Select Case s
            Case "Warrior", "Barbarian", "Time Cop"
                Return "Wraith"
            Case "Mage", "Warlock", "Necromancer"
                Return "Specter"
            Case "Rogue", "Battlemaiden", "Pirate"
                Return "Shade"
            Case "Paladin", "Unconscious", "Mindless", "Classless"
                Return "Poltergeist"
            Case "Magical Girl", "Magical Slut"
                Return "Specteral Girl"
            Case "Witch", "Maiden", "Cleric"
                Return "Phantom"
            Case "Bimbo", "Bunny Girl", "Princess", "Maid", "Shrunken", "Bimbo++"
                Return "Siren"
            Case "Thrall", "Soul-Lord", "Targaxian", "Fae Bee​"
                Return "Thrall"
            Case Else
                Return "Ghost"
        End Select
    End Function

    '| - ATTACKS - |
    Public Overrides Sub attackCMD(ByRef target As Entity)
        If attack > will Then
            MyBase.attackCMD(target)
        ElseIf will > attack Then
            darkOrb(target)
        ElseIf Int(Rnd() * 2) = 0 Then
            darkOrb(target)
        Else
            MyBase.attackCMD(target)
        End If
    End Sub
    Public Sub darkOrb(ByRef target As Entity)
        Dim crit = Int(Rnd() * 20) 'roll for a critical
        Dim dmg = calcDamage(Me.getWIL, target.getWIL) 'calculate the hit
        If dmg > 0 Then dmg += Int(Rnd() * 3) + -1 'adds some variance

        TextEvent.push(getName() & " casts Dark Orb!")
        TextEvent.pushLog(getName() & " casts Dark Orb!")

        Select Case crit
            Case 19
                target.takeCritDMG(dmg, Me)
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

    '| - DEATH HANDLERS - |
    Public Overrides Sub die(ByRef cause As Entity)
        MyBase.die(cause)

        IO.File.Delete("gho.sts")
    End Sub
    Public Overrides Sub playerDeath(ByRef p As Player)
        If Not Settings.active(setting.enemiesoverwritess) Then
            p.savePState()
        End If


        Dim writer As IO.StreamWriter
        writer = IO.File.CreateText("gho.sts")
        writer.WriteLine(p.toGhost())
        writer.Flush()
        writer.Close()

        Dim out As String = "As you collapse to your knees, the ghost of " & first_name & " begins floating towards you with an spectral glow." & DDUtils.RNRN &
                            """Sorry, but you're my second chance..."" " & If(sex_bool, "she", "he") & " mutters softly, before phasing into your body.  Your perspective skews as the " & redefineClassName(class_name) & " takes control and forces you out, turning you into a disembodied spirit yourself." & DDUtils.RNRN &
                            "You've been possessed by " & first_name & " the " & class_name & "!"
        despawn("p-death")

        p.name = first_name

        p.changeHairColor(DDUtils.cShift(p.prt.haircolor, haircolor, 105))
        p.prt.setIAInd(pInd.eyes, eye_ind)

        If p.sex = "Female" And Not sex_bool Then
            p.FtM()
        ElseIf p.sex = "Male" And sex_bool Then
            p.MtF()
        ElseIf Not sex_bool Then
            p.FtM()
        ElseIf sex_bool Then
            p.MtF()
        End If

        TextEvent.push(out, AddressOf p.drawPort)

        If Settings.active(setting.enemiesoverwritess) Then
            p.sState.save(p)
            p.pState.save(p)
        End If
    End Sub
End Class
