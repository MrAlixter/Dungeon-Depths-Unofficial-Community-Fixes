Public Enum mInd
    mesm_thrall
    slime
    player_ghost
    goo_girl
    enth_sorc
    mimic
    spider
    arach_hunt
    enrage_sorc
    enth_demon
    hunger
    marissa_as
    alraune
    i_witch
    fox_fire_elem
    fire
    succubus
    imp
    succ_princess
    web_caster_arach
    bovinomancer
    time_cop_agent
    less_gorgon
    many_squirrel
    lepo_ooze
    default_ghost
    faerie
    namestealer_faerie
    faerie_hunter
    archwitch_recluse
    marissa_neop
    bewitched_ration
End Enum

Public Class Monster
    Inherits NPC

    Public Shared Function getRNGMonsters() As List(Of Tuple(Of mInd, String))
        Dim l As List(Of Tuple(Of mInd, String)) = New List(Of Tuple(Of mInd, String))

        l.Add(New Tuple(Of mInd, String)(mInd.mesm_thrall, MesThrall.BASE_NAME))
        l.Add(New Tuple(Of mInd, String)(mInd.slime, SlimeMonster.BASE_NAME))
        l.Add(New Tuple(Of mInd, String)(mInd.player_ghost, PlayerGhost.BASE_NAME))
        l.Add(New Tuple(Of mInd, String)(mInd.goo_girl, GooGirlMonster.BASE_NAME))
        l.Add(New Tuple(Of mInd, String)(mInd.enth_sorc, EnthSorc.BASE_NAME))
        l.Add(New Tuple(Of mInd, String)(mInd.spider, SpiderMonster.BASE_NAME))
        l.Add(New Tuple(Of mInd, String)(mInd.arach_hunt, ArachHunt.BASE_NAME))
        l.Add(New Tuple(Of mInd, String)(mInd.alraune, Alraune.BASE_NAME))
        l.Add(New Tuple(Of mInd, String)(mInd.fox_fire_elem, FFElemental.BASE_NAME))
        l.Add(New Tuple(Of mInd, String)(mInd.succubus, ESuccubus.BASE_NAME))
        l.Add(New Tuple(Of mInd, String)(mInd.imp, EImp.BASE_NAME))
        l.Add(New Tuple(Of mInd, String)(mInd.succ_princess, ESuccPrincess.BASE_NAME))
        l.Add(New Tuple(Of mInd, String)(mInd.web_caster_arach, WebCasterArach.BASE_NAME))
        l.Add(New Tuple(Of mInd, String)(mInd.bovinomancer, Bovinomancer.BASE_NAME))
        l.Add(New Tuple(Of mInd, String)(mInd.less_gorgon, LesserGorgon.BASE_NAME))
        l.Add(New Tuple(Of mInd, String)(mInd.faerie, FaerieEnemy.BASE_NAME))
        l.Add(New Tuple(Of mInd, String)(mInd.namestealer_faerie, NamestealerFaerie.BASE_NAME))
        l.Add(New Tuple(Of mInd, String)(mInd.faerie_hunter, FaerieHunter.BASE_NAME))
        l.Add(New Tuple(Of mInd, String)(mInd.archwitch_recluse, ArchwitchRecluse.BASE_NAME))
        l.Add(New Tuple(Of mInd, String)(mInd.lepo_ooze, LeporineOoze.BASE_NAME))
        l.Add(New Tuple(Of mInd, String)(mInd.marissa_neop, MarissasStudent.BASE_NAME))

        Return l
    End Function

    Sub New()
        name = "Explorer"
        setInventory({0})
        setupMonsterOnSpawn()
    End Sub
    Sub setupMonsterOnSpawn(Optional ByVal scaleToFloor As Boolean = True)
        If scaleToFloor Then
            Select Case Game.mDun.numCurrFloor 'sets the multiplier for enemy stats based on floor
                Case 1
                    scaleStats(1.0)
                Case Else
                    scaleStats(1 + (0.08 * Game.mDun.numCurrFloor))
            End Select
        End If

        If xp_value < 20 Then xp_value = (maxHealth + attack + defense + speed) / 4

        health = 1.0

        title = " The "

        sName = name
        sMaxHealth = maxHealth
        sMaxMana = maxMana
        mana = maxMana
        sAttack = attack
        sDefense = defense
        sWill = will
        sSpeed = speed

        If Game.player1.perks(perk.lurk) > 0 Then stunct = 0 : isStunned = True

        If speed = Game.player1.getSPD Then speed -= 1
        pos = Game.player1.pos
    End Sub

    Shared Function monsterFactory(ByVal mIndex As Integer) As Monster
        Select Case mIndex
            Case mInd.mesm_thrall
                Return New MesThrall
            Case mInd.slime
                Return New SlimeMonster
            Case mInd.player_ghost
                Try
                    Return New PlayerGhost
                Catch ex As Exception
                    Return New DefaultGhost
                End Try
            Case mInd.goo_girl
                Return New GooGirlMonster
            Case mInd.enth_sorc
                Return New EnthSorc
            Case mInd.mimic
                Return New Mimic
            Case mInd.spider
                Return New SpiderMonster
            Case mInd.arach_hunt
                Return New ArachHunt
            Case mInd.enrage_sorc
                Return New EnrSorc
            Case mInd.enth_demon
                Return New EnthDem
            Case mInd.hunger
                Dim m = New Monster
                m.name = "Hunger"
                Return m
            Case mInd.marissa_as
                Return New MarissaAS
            Case mInd.alraune
                Return New Alraune
            Case mInd.archwitch_recluse
                Return New ArchwitchRecluse
            Case mInd.fox_fire_elem
                Return New FFElemental
            Case mInd.fire
                Dim m = New Monster
                m.name = "Fire"
                Return m
            Case mInd.succubus
                Return New ESuccubus
            Case mInd.imp
                Return New EImp
            Case mInd.succ_princess
                Return New ESuccPrincess
            Case mInd.web_caster_arach
                Return New WebCasterArach
            Case mInd.bovinomancer
                Return New Bovinomancer
            Case mInd.time_cop_agent
                Return New TimeCopAgent
            Case mInd.less_gorgon
                Return New LesserGorgon
            Case mInd.many_squirrel
                Return New ManySquirrels
            Case mInd.lepo_ooze
                Return New LeporineOoze
            Case mInd.faerie
                Return New FaerieEnemy
            Case mInd.faerie
                Return New FaerieEnemy
            Case mInd.namestealer_faerie
                Return New NamestealerFaerie
            Case mInd.faerie_hunter
                Return New FaerieHunter
            Case mInd.marissa_neop
                Return New MarissasStudent
            Case mInd.bewitched_ration
                Dim m = New Monster
                m.name = BewitchedRations.ITEM_NAME
                Return m
        End Select

        Return New Monster()
    End Function
    Shared Function floorMonsterTier(ByVal floorInd As Integer) As Integer()
        '| -- Random Enemies -- |
        Dim tier = {mInd.mesm_thrall, mInd.slime, mInd.spider}

        Select Case floorInd
            Case 1
                tier = {mInd.mesm_thrall, mInd.slime, mInd.spider}
            Case 2
                tier = {mInd.mesm_thrall, mInd.slime, mInd.enth_sorc, mInd.spider}
            Case 3
                tier = {mInd.mesm_thrall, mInd.slime, mInd.enth_sorc, mInd.spider, mInd.arach_hunt}
            Case 4
                tier = {mInd.mesm_thrall, mInd.slime, mInd.goo_girl, mInd.enth_sorc, mInd.spider, mInd.arach_hunt, mInd.web_caster_arach}
            Case 7
                tier = {mInd.mesm_thrall, mInd.slime, mInd.goo_girl, mInd.enth_sorc, mInd.spider, mInd.arach_hunt, mInd.alraune, mInd.fox_fire_elem, mInd.fox_fire_elem, mInd.web_caster_arach}
            Case 13
                tier = {mInd.faerie, mInd.alraune, mInd.archwitch_recluse, mInd.namestealer_faerie}
            Case 10000, 91018
                tier = {}
            Case Else
                If Int(Rnd() * 3) = 0 Then
                    tier = {mInd.mesm_thrall, mInd.slime, mInd.goo_girl, mInd.spider, mInd.arach_hunt, mInd.alraune, mInd.alraune, mInd.web_caster_arach}
                ElseIf Int(Rnd() * 3) = 1 Then
                    tier = {mInd.mesm_thrall, mInd.slime, mInd.goo_girl, mInd.enth_sorc, mInd.spider, mInd.fox_fire_elem, mInd.web_caster_arach, mInd.web_caster_arach}
                Else
                    tier = {mInd.mesm_thrall, mInd.slime, mInd.enth_sorc, mInd.spider, mInd.arach_hunt, mInd.alraune, mInd.fox_fire_elem, mInd.fox_fire_elem}
                End If
        End Select

        If floorInd > 6 And Not mFloor.nonRandomFloors.Contains(floorInd) And Not Game.player1.formName.Equals("Cow") Then
            DDUtils.append(tier, mInd.bovinomancer)
        End If

        If floorInd > 2 And Not mFloor.nonRandomFloors.Contains(floorInd) And Int(Rnd() * 2) = 0 Then
            DDUtils.append(tier, mInd.lepo_ooze)
        End If

        If floorInd > 5 And Not mFloor.nonRandomFloors.Contains(floorInd) And Int(Rnd() * 3) = 0 Then
            DDUtils.append(tier, mInd.less_gorgon)
        End If

        If IO.File.Exists("gho.sts") And Not mFloor.nonRandomFloors.Contains(floorInd) And Int(Rnd() * 2) = 0 Then
            DDUtils.append(tier, mInd.player_ghost)
        End If

        '| --- Marissa's Forces --- |
        If Game.player1.perks(perk.mrevived) > 0 Then
            DDUtils.append(tier, mInd.marissa_neop)
        End If

        '| --- Time Cops --- |
        If Game.player1.perks(perk.enemyoftime) > 0 Then
            DDUtils.append(tier, mInd.time_cop_agent)
            DDUtils.append(tier, mInd.time_cop_agent)

            If Game.currFloor.floorNumber = 10000 Then Return tier
        End If

        '| --- Succubi --- |
        If Not Game.player1.perks(perk.moamarphne) > 0 Then
            If Game.player1.getLust = 0 Then
            ElseIf Game.player1.getLust < 25 Then
                DDUtils.append(tier, mInd.imp)
                DDUtils.append(tier, mInd.succubus)
            ElseIf Game.player1.getLust < 50 Then
                DDUtils.append(tier, mInd.imp)
                DDUtils.append(tier, mInd.succubus)
                DDUtils.append(tier, mInd.succubus)
            ElseIf Game.player1.getLust < 75 Then
                DDUtils.append(tier, mInd.imp)
                DDUtils.append(tier, mInd.imp)
                DDUtils.append(tier, mInd.succubus)
                DDUtils.append(tier, mInd.succubus)
                DDUtils.append(tier, mInd.succ_princess)
            ElseIf Game.player1.getLust < 100 Then
                DDUtils.append(tier, mInd.imp)
                DDUtils.append(tier, mInd.imp)
                DDUtils.append(tier, mInd.succubus)
                DDUtils.append(tier, mInd.succubus)
                DDUtils.append(tier, mInd.succubus)
                DDUtils.append(tier, mInd.succ_princess)
                DDUtils.append(tier, mInd.succ_princess)
            ElseIf Game.player1.getLust < 200 Then
                DDUtils.append(tier, mInd.succubus)
                DDUtils.append(tier, mInd.succubus)
                DDUtils.append(tier, mInd.succubus)
                DDUtils.append(tier, mInd.succubus)
                DDUtils.append(tier, mInd.succ_princess)
                DDUtils.append(tier, mInd.succ_princess)
                DDUtils.append(tier, mInd.succ_princess)
                DDUtils.append(tier, mInd.succ_princess)
                DDUtils.append(tier, mInd.succ_princess)
                DDUtils.append(tier, mInd.succ_princess)
            End If
        End If

        '| --- Fae Curse Enemies --- |
        If floorInd = 13 And Game.player1.perks(perk.faecurse) > -1 Then
            DDUtils.append(tier, mInd.faerie_hunter)

            If Game.player1.perks(perk.faecurse) > 1 Then
                DDUtils.append(tier, mInd.namestealer_faerie)
                DDUtils.append(tier, mInd.faerie_hunter)
            End If
        End If

        '| -- Final Tier Creation -- |
        Dim final_tier As List(Of Integer) = New List(Of Integer)

        For Each m In tier
            Select Case Settings.getSpawnRate(m)
                Case 3
                    final_tier.Add(m)
                    final_tier.Add(m)
                    final_tier.Add(m)
                    final_tier.Add(m)
                Case 2
                    final_tier.Add(m)
                    final_tier.Add(m)
                Case 1
                    final_tier.Add(m)
            End Select
        Next

        Return final_tier.ToArray
    End Function
    Shared Sub createMimic(ByRef contents As Inventory)
        Dim m As Monster = monsterFactory(5)
        m.inv.merge(contents)

        'adds the mimmic to combat queues
        targetRoute(m)

        TextEvent.pushAndLog(DDUtils.capitalizeFirst(m.getNameWithTitle) & " attacks!")

        Game.drawBoard()
    End Sub
    Shared Sub targetRoute(ByRef m As Monster)
        m.currTarget = Game.player1
        Game.toCombat(m)
    End Sub
End Class
