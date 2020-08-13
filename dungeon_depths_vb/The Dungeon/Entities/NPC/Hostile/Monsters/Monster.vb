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
                m.name = "Hunger"
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
            Case 16
                Return New ESuccubus
            Case 17
                Return New EImp
            Case 18
                Return New ESuccPrincess
        End Select

        Return New Monster()
    End Function
    Shared Function floorMonsterTier(ByVal floorInd As Integer) As Integer()
        Dim tier = {0, 1, 2, 6}

        Select Case floorInd
            Case 1
                tier = {0, 1, 2, 6}
            Case 2
                tier = {0, 1, 2, 4, 6}
            Case 3
                tier = {0, 1, 2, 4, 6, 7}
            Case 4
                tier = {0, 1, 2, 3, 4, 6, 7}
            Case Else
                tier = {0, 1, 2, 3, 4, 6, 7, 12, 12, 14}
        End Select

        If Game.player1.getLust < 25 Then
            DDUtils.append(tier, 17)
            DDUtils.append(tier, 17)
            DDUtils.append(tier, 17)

            DDUtils.append(tier, 16)
        ElseIf Game.player1.getLust < 50 Then
            DDUtils.append(tier, 17)
            DDUtils.append(tier, 17)
            DDUtils.append(tier, 17)

            DDUtils.append(tier, 16)
            DDUtils.append(tier, 16)

            DDUtils.append(tier, 18)
        ElseIf Game.player1.getLust < 75 Then
            DDUtils.append(tier, 17)
            DDUtils.append(tier, 17)
            DDUtils.append(tier, 17)
            DDUtils.append(tier, 17)

            DDUtils.append(tier, 16)
            DDUtils.append(tier, 16)
            DDUtils.append(tier, 16)

            DDUtils.append(tier, 18)
            DDUtils.append(tier, 18)
        Else
            DDUtils.append(tier, 17)
            DDUtils.append(tier, 17)
            DDUtils.append(tier, 17)
            DDUtils.append(tier, 17)

            DDUtils.append(tier, 16)
            DDUtils.append(tier, 16)
            DDUtils.append(tier, 16)

            DDUtils.append(tier, 18)
            DDUtils.append(tier, 18)
            DDUtils.append(tier, 18)
        End If

        Return tier
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
