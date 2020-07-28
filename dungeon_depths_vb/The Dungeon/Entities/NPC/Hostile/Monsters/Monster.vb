Public Class Monster
    Inherits NPC
    Sub New()
        name = "Explorer"
        setInventory({0})
        setupMonsterOnSpawn()
    End Sub
    Sub setupMonsterOnSpawn(Optional ByVal scaleToFloor As Boolean = True)
        If scaleToFloor Then
            Select Case Game.mDun.numCurrFloor 'sets the multiplier for enemy stats based on floor
                Case 1
                    maxHealth *= 1
                    attack *= 1
                    defense *= 1
                    speed *= 1
                Case 2
                    maxHealth *= 1.05
                    attack *= 1.05
                    defense *= 1.05
                    speed *= 1.05
                Case 3
                    maxHealth *= 1.1
                    attack *= 1.1
                    defense *= 1.1
                    speed *= 1.1
                Case 4
                    maxHealth *= 1.2
                    attack *= 1.2
                    defense *= 1.2
                    speed *= 1.2
                Case Else
                    maxHealth *= (1 + (0.05 * Game.mDun.numCurrFloor))
                    attack *= (1 + (0.05 * Game.mDun.numCurrFloor))
                    defense *= (1 + (0.05 * Game.mDun.numCurrFloor))
                    speed *= (1 + (0.05 * Game.mDun.numCurrFloor))
            End Select
        End If

        health = 1.0

        title = " The "
        sName = name
        sMaxHealth = maxHealth
        sMaxMana = maxMana
        sAttack = attack
        sdefense = defense
        sWill = will
        sSpeed = speed

        If speed = Game.player1.getSPD Then speed -= 1
        pos = Game.player1.pos
    End Sub
    Shared Function monsterFactory(ByVal mIndex As Integer) As Monster
        Select Case mIndex
            Case 0
                Return New MesThrall
            Case 1
                Return New SlimeMonster
            Case 2
                Try
                    Return New PlayerGhost
                Catch ex As Exception
                    Select Case Int(Rnd() * 3)
                        Case 0
                            Return New MesThrall
                        Case 1
                            Return New SlimeMonster
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
                m.name = "stamina"
                Return m
            Case 11
                Return New MarissaAS
            Case 12
                Return New Alraune
            Case 13
                Return New IWitch
            Case 14
                Return New FFElemental
            Case 15
                Dim m = New Monster
                m.name = "Fire"
                Return m
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
        Game.player1.setTarget(m)
        m.currTarget = Game.player1
        Game.toCombat()
    End Sub
End Class
