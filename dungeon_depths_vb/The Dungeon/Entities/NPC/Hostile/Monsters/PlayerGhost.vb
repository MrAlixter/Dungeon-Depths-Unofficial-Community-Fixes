Public Class PlayerGhost
    Inherits Monster
    Dim eyeInd As Tuple(Of Integer, Boolean, Boolean)
    Dim className As String = "Classless"
    Dim deathfloor = ""
    Sub New()
        If name = Game.player1.getName Then Throw New Exception
        loadGhost()
        setupMonsterOnSpawn()
        If deathfloor.Equals(Game.currFloor.floorCode) Then inv = New Inventory()
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
        deathfloor = ghostArray(1)
        className = redefineClassName(ghostArray(2))
        health = ghostArray(4)
        maxHealth = ghostArray(4)
        attack = ghostArray(5)
        mana = ghostArray(6)
        defense = ghostArray(7)
        speed = ghostArray(8)
        will = ghostArray(9)
        Dim sexBool As Boolean = CBool(ghostArray(10))
        eyeInd = New Tuple(Of Integer, Boolean, Boolean)(ghostArray(11), ghostArray(12), ghostArray(13))
        Dim haircolor As Color = Color.FromArgb(255, ghostArray(14), ghostArray(15), ghostArray(16))
        inv.load(ghostArray(17))
        filterInv()
        reader.Close()
        Return True
    End Function

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

        Game.pushLblEvent(getName() & " casts Dark Orb!")
        Game.pushLstLog(getName() & " casts Dark Orb!")

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

    Public Overrides Sub die(ByRef cause As Entity)
        MyBase.die(cause)

        Dim writer = IO.File.CreateText("gho.sts")
        writer.WriteLine("MTGRAVE")
        writer.Flush()
        writer.Close()
    End Sub

    Sub filterInv()
        Dim tierCount As Integer = New Chest().tiers.Length
        For i = 0 To inv.count
            If inv.item(i).count > 0 Then
                If Not Int(Rnd() * (tierCount - inv.item(i).getTier)) = 0 Then inv.item(i).count = 0
            End If
        Next
    End Sub

    Function redefineClassName(ByVal s As String) As String
        Select Case s
            Case "Warrior", "Barbarian"
                Return "Wraith"
            Case "Mage", "Warlock"
                Return "Specter"
            Case "Rogue"
                Return "Shade"
            Case "Paladin", "Unconscious", "Mindless"
                Return "Poltergeist"
            Case "Magical Girl"
                Return "Specteral Girl"
            Case "Witch", "Maiden"
                Return "Phantom"
            Case "Bunny Girl", "Princess", "Maid", "Shrunken"
                Return "Siren"
        End Select

        Return s
    End Function
End Class
