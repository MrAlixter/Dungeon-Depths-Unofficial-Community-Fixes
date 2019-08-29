Public Class Monster
    Inherits NPC

    Sub New()
        Select Case Game.mDun.numCurrFloor 'sets the multiplier for enemy stats based on floor
            Case 1
                maxHealth *= 1
                attack *= 1
                defence *= 1
                speed *= 1
            Case 2
                maxHealth *= 1.05
                attack *= 1.05
                defence *= 1.05
                speed *= 1.05
            Case 3
                maxHealth *= 1.1
                attack *= 1.1
                defence *= 1.1
                speed *= 1.1
            Case 4
                maxHealth *= 1.2
                attack *= 1.2
                defence *= 1.2
                speed *= 1.2
            Case Else
                maxHealth *= (1 + (0.05 * Game.mDun.numCurrFloor))
                attack *= (1 + (0.05 * Game.mDun.numCurrFloor))
                defence *= (1 + (0.05 * Game.mDun.numCurrFloor))
                speed *= (1 + (0.05 * Game.mDun.numCurrFloor))
        End Select

        health = 1.0

        title = " The "
        sName = name
        sMaxHealth = maxHealth
        sMaxMana = maxMana
        sAttack = attack
        sDefence = defence
        sWill = will
        sSpeed = speed

        If speed = Game.player.getSPD Then speed -= 1
        pos = Game.player.pos
    End Sub
    Sub New(ByVal mIndex As Integer)
        Select Case mIndex
            Case -1
                name = "Explorer"
                setInventory({0})
            Case 0
                name = "Mesmerized Thrall"
                maxHealth = 85
                attack = 20
                defence = 7
                speed = 9
                setInventory({0, 1, 13})
            Case 1
                name = "Slime"
                maxHealth = 30
                attack = 15
                defence = 60
                speed = 6
                setInventory({2, 3})
            Case 2
                Try
                    loadGhost()
                Catch ex As Exception
                    name = "Slime"
                    maxHealth = 30
                    attack = 15
                    defence = 60
                    speed = 6
                    setInventory({2, 3})
                End Try
            Case 3
                name = "Goo Girl"
                maxHealth = 90
                attack = 30
                defence = 80
                speed = 14
                setInventory({3})
            Case 4
                Dim rng = Int(Rnd() * 2)
                If rng = 0 Then
                    name = "Enthralling Sorcerer"
                Else
                    name = "Enthralling Sorceress"
                End If
                maxHealth = 150
                attack = 40
                defence = 17
                speed = 20
                setInventory({4, 13})
            Case 5
                name = "Mimic"
                maxHealth = 175
                attack = 35
                defence = 20
                speed = 50
                setInventory({0})
            Case 6
                name = "Spider"
                maxHealth = 65
                attack = 35
                defence = 1
                speed = 45
                setInventory({63})
            Case 7
                name = "Arachne Huntress"
                maxHealth = 110
                attack = 65
                defence = 10
                speed = 60
                setInventory({63, 64})
            Case 8
                Dim rng = Int(Rnd() * 2)
                If rng = 0 Then
                    name = "Enraged Sorcerer"
                Else
                    name = "Enraged Sorceress"
                End If
                maxHealth = 145
                attack = 50
                defence = 5
                speed = 25
                setInventory({})
            Case 9
                Dim rng = Int(Rnd() * 2)
                If rng = 0 Then
                    name = "Enthralling Half-Demon"
                Else
                    name = "Enthralling Half-Demoness"
                End If
                maxHealth = 200
                attack = 60
                defence = 7
                speed = 30
                setInventory({})
            Case 10
                name = "Hunger"
            Case Else
                name = "Some Guy"
                maxHealth = 66
                attack = 1
                defence = 1
                speed = 1
                For i = 0 To 2
                    inv.setCount(CInt(Rnd() * (Game.player.inv.upperBound + 1)), CInt(Rnd() * 2) + 1)
                Next
        End Select

        Select Case Game.mDun.numCurrFloor 'sets the multiplier for enemy stats based on floor
            Case 1
                maxHealth *= 1
                attack *= 1
                defence *= 1
                speed *= 1
            Case 2
                maxHealth *= 1.05
                attack *= 1.05
                defence *= 1.05
                speed *= 1.05
            Case 3
                maxHealth *= 1.1
                attack *= 1.1
                defence *= 1.1
                speed *= 1.1
            Case 4
                maxHealth *= 1.2
                attack *= 1.2
                defence *= 1.2
                speed *= 1.2
            Case Else
                maxHealth *= (1 + (0.05 * Game.mDun.numCurrFloor))
                attack *= (1 + (0.05 * Game.mDun.numCurrFloor))
                defence *= (1 + (0.05 * Game.mDun.numCurrFloor))
                speed *= (1 + (0.05 * Game.mDun.numCurrFloor))
        End Select

        health = 1.0

        title = " The "
        sName = name
        sMaxHealth = maxHealth
        sMaxMana = maxMana
        sAttack = attack
        sDefence = defence
        sWill = will
        sSpeed = speed

        If speed = Game.player.getSPD Then speed -= 1
        pos = Game.player.pos
    End Sub

    Shared Sub createMimic(ByRef contents As Inventory)
        Dim m As Monster = New Monster(5)
        m.inv.merge(contents)

        'adds the mimmic to combat queues
        targetRoute(m)

        Game.toCombat()
        Game.pushLblCombatEvent((m.getName() & " attacks!"))
        Game.pushLstLog((m.getName() & " attacks!"))

        Game.drawBoard()
    End Sub
    Shared Sub targetRoute(ByRef m As Monster)
        Game.npcList.Add(m)
        Game.player.setTarget(m)
        m.currTarget = Game.player
        Game.toCombat()
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

        inv.load(ghostArray(10))
        reader.Close()

        Dim writer = IO.File.CreateText("gho.sts")
        writer.WriteLine("MTGRAVE")
        writer.Flush()
        writer.Close()
        Return True
    End Function
End Class
