Public Class Monster
    Inherits NPC
    Sub New()
        name = "Explorer"
        setInventory({0})
        setupMonsterOnSpawn()
    End Sub
    Sub setupMonsterOnSpawn()
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
    Shared Function monsterFactory(ByVal mIndex As Integer) As Monster
        Select Case mIndex
            Case 0
                Return New MesThrall
            Case 1
                Return New MarissaAS
            Case 2
                Try
                    Return New PlayerGhost
                Catch ex As Exception
                    Select Case Int(Rnd() * 3)
                        Case 0
                            Return New MesThrall
                        Case 1
                            Return New MarissaAS
                        Case 2
                            Return New SpiderMonster
                    End Select
                End Try
            Case 3
                Return New GooGirlMonster
            Case 4
                Return New EnthSorc
            Case 5
                Return New Mimic
            Case 6
                Return New SpiderMonster
            Case 7
                Return New ArachHunt
            Case 8
                Return New EnrSorc
            Case 9
                Return New EnthDem
            Case 10
                Dim m = New Monster
                m.name = "Hunger"
                Return m
            Case 11
                Return New MarissaAS
        End Select

        Return New Monster()
    End Function

    Shared Sub createMimic(ByRef contents As Inventory)
        Dim m As Monster = monsterFactory(5)
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
