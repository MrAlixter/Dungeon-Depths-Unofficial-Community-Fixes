Public Class SaveFile
    Private Const SAVE_SEG As String = "SVE"
    Private Const ITEM_SEG As String = "ITM"
    Private Const MYSTERY_POT_SEG As String = "MPOT"
    Private Const IMAGE_INDEX_SEG As String = "IMG"
    Private Const PERK_COUNT_SEG As String = "PERKC"
    Private Const PERK_SEG As String = "PERK"
    Private Const PREFERRED_FORM_SEG As String = "PRF"
    Private Const FORCED_PATH_SEG As String = "PATH"
    Private Const COLOR_SEG As String = "CLR"
    Private Const TRANSFORMATION_SEG As String = "OTF"
    Private Const SELF_POLY_SEG As String = "SPM"
    Private Const ENEMY_POLY_SEG As String = "EPM"
    Private Const SPELL_SEG As String = "SPL"
    Private Const SPECIAL_SEG As String = "SPC"
    Private Const QUEST_SEG As String = "QST"
    Private Const ONGOING_QUEST_SEG As String = "OQST"
    Private Const NPC_SEG As String = "NPC"
    Private Const INVENTORY_HEADER_SEG As String = "INV"
    Private Const INVENTORY_END_SEG As String = "EINV"
    Private Const TEMP_INVENTORY_HEADER_SEG As String = "TINV"
    Private Const PORTRAIT_HEADER_SEG As String = "PRT"
    Private Const PORTRAIT_END_SEG As String = "EPRT"
    Private Const NPCS_HEADER_SEG As String = "SNPC"
    Private Const NPCS_END_SEG As String = "ENPC"
    Private Const PLAYER_STATE_HEADER_SEG As String = "STE"
    Private Const PLAYER_STATE_END_SEG As String = "ESTE"
    Private Const DUNGEON_SETTING_SEG As String = "DSET"
    Private Const PLAYER_HEADER_SEG As String = "PLR"
    Private Const PLAYER_END_SEG As String = "EPLR"
    Private Const DUNGEON_HEADER_SEG As String = "DUN"
    Private Const DUNGEON_END_SEG As String = "EDUN"
    Private Const WFLAG_SEG As String = "WFLG"
    Private Const FLOOR_BOSS_SEG As String = "FBS"
    Private Const FLOOR_CODE_SEG As String = "FCS"
    Private Const DUNGEON_FLOOR_SEG As String = "FLR"
    Private Const DUNGEON_FLOOR_END_SEG As String = "EFLR"
    Private Const TILE_INFO_SEG As String = "DTL"
    Private Const TRAP_SEG As String = "TRP"
    Private Const CHEST_SEG As String = "CST"
    Private Const LOADED_CHEST_SEG As String = "LCST"
    Private Const STATUE_SEG As String = "STU"
    Private Const FLOOR_NPC_POSS_SEG As String = "FNPS"

    Private Shared resumableSegments() As String = {SAVE_SEG, DUNGEON_HEADER_SEG, NPCS_HEADER_SEG, PLAYER_HEADER_SEG}

    Public Const SEGMENT_DELIMITER As String = "~"
    Public Const VALUE_DELIMITER As String = "*"
    Public Const VALUE_SPLIT_DELIMITER As String = "%"

    Private Const SAVE_EMPTY_SPACES As Boolean = False

    '| - File Creation/Load Segments - |
    Public Shared Sub save(ByVal filename As String)
        Dim writer As IO.StreamWriter
        IO.File.Delete(filename)
        writer = IO.File.CreateText(filename)

        writer.WriteLine(Game.version & SEGMENT_DELIMITER)
        writer.WriteLine(saveSaveInfoSegment())
        writer.WriteLine(saveDungeonSettingsSegment())
        writer.WriteLine(saveDungeonLoop(Game.mDun))
        writer.WriteLine(saveNPCSLoop())
        writer.WriteLine(savePlayerLoop(Game.player1))

        writer.Flush()
        writer.Close()
    End Sub
    Public Shared Sub load(ByVal filename As String)
        Dim reader As IO.StreamReader
        reader = IO.File.OpenText(filename)

        Dim cursor = 1
        Dim lines As List(Of String) = reader.ReadToEnd().Replace(vbCrLf, "").Split(SEGMENT_DELIMITER).ToList

        Game.initLoadBar()
        Game.updateLoadbar(10)

        Try
            Dim header_seg() As String = lines(cursor).Split(VALUE_DELIMITER)

            If header_seg(0).Equals(SAVE_SEG) Then
                loadSaveInfoSegment(CInt(header_seg(1)), CInt(header_seg(2)))
            Else
                defaultSaveInfo()
            End If
            cursor += 1

            Dim dset_seg() As String = lines(cursor).Split(VALUE_DELIMITER)

            If dset_seg(0).Equals(DUNGEON_SETTING_SEG) Then
                loadDungeonSettingsSegment(CInt(dset_seg(1)), CInt(dset_seg(2)), CInt(dset_seg(3)), CInt(dset_seg(4)), CInt(dset_seg(5)), CInt(dset_seg(6)), CInt(dset_seg(7)), CInt(dset_seg(8)), CInt(dset_seg(9)), CInt(dset_seg(10)))
            Else
                defaultLoadDungeonSettings()
            End If
            cursor += 1
        Catch ex As Exception
            Throw ex
            DDError.saveFileResumeError()
            defaultSaveInfo()
            defaultLoadDungeonSettings()
            cursor = 3
        End Try

        Game.updateLoadbar(45)

        Try
            Game.mDun = loadDungeonLoop(lines, cursor)
            Game.currFloor = Game.mDun.floors(Game.mDun.numCurrFloor)
            Game.newBoard()
        Catch ex As Exception
            Throw ex
            DDError.saveFileResumeError()
        End Try

        cursor = findNextResumableSeg(lines, cursor + 1)
        Game.updateLoadbar(55)

        Try
            loadNPCSLoop(lines, cursor)
        Catch ex As Exception
            Throw ex
            DDError.saveFileResumeError()
        End Try

        cursor = findNextResumableSeg(lines, cursor + 1)
        Game.updateLoadbar(65)

        Try
            Game.player1 = loadPlayerLoop(lines, cursor)
        Catch ex As Exception
            Throw ex
            DDError.saveFileFatalError()
            Throw New Exception("Fatal Save Corruption")
        End Try

        Game.updateLoadbar(80)

        reader.Close()
    End Sub
    Protected Shared Function findNextResumableSeg(ByVal save As List(Of String), ByVal cursor As Integer)
        For i = cursor To save.Count - 1
            If resumableSegments.Contains(save(i).Split(VALUE_DELIMITER)(0)) Then Return i
        Next

        Return cursor + 1
    End Function

    '| -- Save Info Segment (SVE) -- |
    Protected Shared Function saveSaveInfoSegment() As String
        Return SAVE_SEG & VALUE_DELIMITER &
               Game.version & VALUE_DELIMITER &
               Game.sessionID & VALUE_DELIMITER &
               DateTime.Now.ToString("yyyyMMddhhmm") & SEGMENT_DELIMITER
    End Function
    Protected Shared Sub loadSaveInfoSegment(ByVal v As Double, ByVal sID As Integer)
        Game.version = v
        Game.sessionID = sID
    End Sub
    Protected Shared Sub defaultSaveInfo()
        Game.sessionID = DateTime.Now.GetHashCode()
    End Sub

    '| - Dungeon Settings Loop - |
    Protected Shared Function saveDungeonSettingsSegment() As String
        Return DUNGEON_SETTING_SEG & VALUE_DELIMITER &
               Game.mBoardWidth & VALUE_DELIMITER &
               Game.mBoardHeight & VALUE_DELIMITER &
               Game.chestFreqMin & VALUE_DELIMITER &
               Game.chestFreqRange & VALUE_DELIMITER &
               Game.chestSizeDependence & VALUE_DELIMITER &
               Game.chestRichnessBase & VALUE_DELIMITER &
               Game.chestRichnessRange & VALUE_DELIMITER &
               Game.turn & VALUE_DELIMITER &
               Game.encounterRate & VALUE_DELIMITER &
               Game.eClockResetVal & SEGMENT_DELIMITER
    End Function
    Protected Shared Sub loadDungeonSettingsSegment(ByVal bW As Integer, ByVal bH As Integer, ByVal cFM As Integer, ByVal cFR As Integer, ByVal cSD As Integer, ByVal cRB As Integer, ByVal cRR As Integer, ByVal t As Integer, ByVal eR As Integer, ByVal eCRV As Integer)
        Game.mBoardWidth = bW
        Game.mBoardHeight = bH
        Game.chestFreqMin = cFM
        Game.chestFreqRange = cFR
        Game.chestSizeDependence = cSD
        Game.chestRichnessBase = cRB
        Game.chestRichnessRange = cRR
        Game.turn = t
        Game.encounterRate = eR
        Game.eClockResetVal = eCRV
    End Sub
    Protected Shared Sub defaultLoadDungeonSettings()
        Game.mBoardWidth = 60
        Game.mBoardHeight = 60
        Game.chestFreqMin = 3
        Game.chestFreqRange = 8
        Game.chestSizeDependence = 30
        Game.chestRichnessBase = 1
        Game.chestRichnessRange = 4
        Game.encounterRate = 25
        Game.eClockResetVal = 10
    End Sub

    '| - Dungeon Map Loop - |
    Protected Shared Function saveDungeonLoop(ByRef d As Dungeon)
        Dim dungeon_loop = DUNGEON_HEADER_SEG & VALUE_DELIMITER &
                           d.world_flags.Count() & VALUE_DELIMITER &
                           d.floor_boss.Count() & VALUE_DELIMITER &
                           d.floor_codes.Count() & VALUE_DELIMITER &
                           d.floors.Count() & VALUE_DELIMITER &
                           d.numCurrFloor & VALUE_DELIMITER &
                           d.lastVisitedFloor & SEGMENT_DELIMITER

        For Each flag In d.world_flags
            dungeon_loop += vbCrLf & saveWorldFlagSegment(New Tuple(Of wFlag, Integer)(flag.Key, flag.Value))
        Next

        For Each fboss In d.floor_boss
            dungeon_loop += vbCrLf & saveFloorBossSegment(New Tuple(Of Integer, String)(fboss.Key, fboss.Value))
        Next

        For Each code In d.floor_codes
            dungeon_loop += vbCrLf & saveFloorCodeSegment(New Tuple(Of Integer, String)(code.Key, code.Value))
        Next

        For Each floor In d.floors
            dungeon_loop += vbCrLf & saveFloorLoop(floor.Value)
        Next

        Return dungeon_loop & vbCrLf & DUNGEON_END_SEG & SEGMENT_DELIMITER
    End Function
    Protected Shared Function loadDungeonLoop(ByVal save As List(Of String), ByVal start_pos As Integer) As Dungeon
        Dim subseg() As String = save(start_pos).Split(VALUE_DELIMITER)

        If Not subseg(0).Equals(DUNGEON_HEADER_SEG) Then Throw New Exception("Dungeon at line " & start_pos & " is corrupt!")

        Dim dun As Dungeon = New Dungeon(False)

        dun.world_flags = New Dictionary(Of wFlag, Integer)
        dun.floor_boss = New Dictionary(Of Integer, String)
        dun.floor_codes = New Dictionary(Of Integer, String)
        dun.floors = New Dictionary(Of Integer, mFloor)
        dun.numCurrFloor = CInt(subseg(5))
        dun.lastVisitedFloor = CInt(subseg(6))

        start_pos += 1
        For i = 1 To CInt(subseg(1))
            Dim flag = loadWorldFlagSegment(save(start_pos))
            dun.world_flags.Add(flag.Item1, flag.Item2)
            start_pos += 1
        Next

        For i = 1 To CInt(subseg(2))
            Dim boss = loadFloorBossSegment(save(start_pos))
            dun.floor_boss.Add(boss.Item1, boss.Item2)
            start_pos += 1
        Next

        For i = 1 To CInt(subseg(3))
            Dim code = loadFloorCodeSegment(save(start_pos))
            dun.floor_codes.Add(code.Item1, code.Item2)
            start_pos += 1
        Next

        For i = 1 To CInt(subseg(4))
            Dim floor_tuple = loadFloorLoop(save, start_pos)
            dun.floors.Add(floor_tuple.Item1.floorNumber, floor_tuple.Item1)
            start_pos = 1 + floor_tuple.Item2
        Next

        Return dun
    End Function
    Protected Shared Function saveWorldFlagSegment(ByRef f As Tuple(Of wFlag, Integer)) As String
        Return WFLAG_SEG & VALUE_DELIMITER &
               f.Item1.ToString & VALUE_DELIMITER &
               f.Item2 & SEGMENT_DELIMITER
    End Function
    Protected Shared Function loadWorldFlagSegment(ByVal seg As String) As Tuple(Of wFlag, Integer)
        seg = seg.Replace(SEGMENT_DELIMITER, "")

        Dim subseg = seg.Split(VALUE_DELIMITER)

        Return New Tuple(Of wFlag, Integer)([Enum].Parse(GetType(wFlag), subseg(1)), CInt(subseg(2)))
    End Function
    Protected Shared Function saveFloorBossSegment(ByRef b As Tuple(Of Integer, String)) As String
        Return FLOOR_BOSS_SEG & VALUE_DELIMITER &
               b.Item1 & VALUE_DELIMITER &
               b.Item2 & SEGMENT_DELIMITER
    End Function
    Protected Shared Function loadFloorBossSegment(ByVal seg As String) As Tuple(Of Integer, String)
        seg = seg.Replace(SEGMENT_DELIMITER, "")

        Dim subseg = seg.Split(VALUE_DELIMITER)

        Return New Tuple(Of Integer, String)(CInt(subseg(1)), subseg(2))
    End Function
    Protected Shared Function saveFloorCodeSegment(ByRef c As Tuple(Of Integer, String)) As String
        Return FLOOR_CODE_SEG & VALUE_DELIMITER &
               c.Item1 & VALUE_DELIMITER &
               c.Item2 & SEGMENT_DELIMITER
    End Function
    Protected Shared Function loadFloorCodeSegment(ByVal seg As String) As Tuple(Of Integer, String)
        seg = seg.Replace(SEGMENT_DELIMITER, "")

        Dim subseg = seg.Split(VALUE_DELIMITER)

        Return New Tuple(Of Integer, String)(CInt(subseg(1)), subseg(2))
    End Function

    '| - Dungeon Floor Loop - |
    Public Shared Sub saveFloor(ByRef f As mFloor)
        Dim writer As IO.StreamWriter

        Dim filename = "floors/" + f.floorCode & ".flrx"
        IO.File.Delete(filename)
        writer = IO.File.CreateText(filename)

        writer.WriteLine(saveFloorLoop(f))

        writer.Flush()
        writer.Close()
    End Sub
    Public Shared Function loadFloor(ByVal filename As String) As mFloor
        Dim reader As IO.StreamReader
        reader = IO.File.OpenText(filename)

        Dim lines As List(Of String) = reader.ReadToEnd().Replace(vbCrLf, "").Split(SEGMENT_DELIMITER).ToList
        Return loadFloorLoop(lines, 0).Item1
    End Function
    Protected Shared Function saveFloorLoop(ByRef f As mFloor) As String
        Dim floor_loop = DUNGEON_FLOOR_SEG & VALUE_DELIMITER &
                         f.mBoardWidth & VALUE_DELIMITER &
                         f.mBoardHeight & VALUE_DELIMITER &
                         f.coveredBoardSpace & VALUE_DELIMITER &
                         f.floorNumber & VALUE_DELIMITER &
                         f.floorCode & VALUE_DELIMITER &
                         f.stairs.X & VALUE_DELIMITER &
                         f.stairs.Y & VALUE_DELIMITER &
                         f.playerPosition.X & VALUE_DELIMITER &
                         f.playerPosition.Y & VALUE_DELIMITER &
                         f.bossDialog & VALUE_DELIMITER &
                         f.beatBoss & VALUE_DELIMITER &
                         f.chestList.Count & VALUE_DELIMITER &
                         f.statueList.Count & VALUE_DELIMITER &
                         f.trapList.Count & SEGMENT_DELIMITER

        For y = 0 To f.mBoardHeight - 1
            For x = 0 To f.mBoardWidth - 1
                If (f.mBoard(y, x).Tag <> 0 Or f.mBoard(y, x).Text <> "") Or SAVE_EMPTY_SPACES Then floor_loop += vbCrLf + saveTileSegment(f.mBoard(y, x), x, y)
            Next
        Next

        For Each c In f.chestList
            floor_loop += vbCrLf + saveChestLoop(c)
        Next

        For Each s In f.statueList
            floor_loop += vbCrLf + saveStatueSegment(s)
        Next

        For Each t In f.trapList
            floor_loop += vbCrLf + saveTrapSegment(t)
        Next

        Return floor_loop & vbCrLf & DUNGEON_FLOOR_END_SEG & SEGMENT_DELIMITER
    End Function
    Protected Shared Function loadFloorLoop(ByVal save As List(Of String), ByVal start_pos As Integer) As Tuple(Of mFloor, Integer)
        Dim subseg() As String = save(start_pos).Split(VALUE_DELIMITER)


        If Not subseg(0).Equals(DUNGEON_FLOOR_SEG) Then Throw New Exception("Floor at line " & start_pos & " is corrupt!")

        Dim mBoardWidth As Integer = CInt(subseg(1))
        Dim mBoardHeight As Integer = CInt(subseg(2))
        Dim coveredBoardSpace As Integer = CInt(subseg(3))
        Dim floorNumber As Integer = CInt(subseg(4))
        Dim floorCode As String = subseg(5)
        Dim stairs As Point = New Point(CInt(subseg(6)), CInt(subseg(7)))
        Dim playerPosition As Point = New Point(CInt(subseg(8)), CInt(subseg(9)))
        Dim bossDialog As String = subseg(10)
        Dim beatBoss As Boolean = CBool(subseg(11))
        Dim chestCount As Integer = CInt(subseg(12))
        Dim statueCount As Integer = CInt(subseg(13))
        Dim trapCount As Integer = CInt(subseg(14))
        Dim floor As mFloor = New mFloor()
        ReDim floor.mBoard(mBoardHeight, mBoardWidth)
        floor.chestList = New List(Of Chest)()
        floor.statueList = New List(Of Statue)()
        floor.trapList = New List(Of Trap)()

        floor.mBoardWidth = mBoardWidth
        floor.mBoardHeight = mBoardHeight
        floor.coveredBoardSpace = coveredBoardSpace
        floor.floorNumber = floorNumber
        floor.floorCode = floorCode
        floor.stairs = stairs
        floor.playerPosition = playerPosition
        floor.bossDialog = bossDialog
        floor.beatBoss = beatBoss

        start_pos += 1
        For y = 0 To mBoardHeight - 1
            For x = 0 To mBoardWidth - 1
                Try
                    Dim tile_seg = save(start_pos).Split(VALUE_DELIMITER)

                    If x <> CInt(tile_seg(1)) Or y <> CInt(tile_seg(2)) Then
                        floor.mBoard(y, x) = New mTile(0, "", Color.Black)
                        Continue For
                    Else
                        floor.mBoard(y, x) = loadTileSegment(save(start_pos))
                    End If
                Catch ex As Exception
                    floor.mBoard(y, x) = New mTile(0, "", Color.Black)
                End Try

                start_pos += 1
            Next
        Next

        For i = 0 To chestCount - 1
            Dim chest_tuple = loadChestLoop(save, start_pos)

            floor.chestList.Add(chest_tuple.Item1)
            start_pos += 2 + chest_tuple.Item2
        Next

        For i = 0 To statueCount - 1
            floor.statueList.Add(loadStatueSegment(save(start_pos)))
            start_pos += 1
        Next

        For i = 0 To trapCount - 1
            floor.trapList.Add(loadTrapSegment(save(start_pos)))
            start_pos += 1
        Next

        Return New Tuple(Of mFloor, Integer)(floor, start_pos)
    End Function
    Protected Shared Function saveTileSegment(ByRef t As mTile, ByVal x As Integer, ByVal y As Integer) As String
        Return TILE_INFO_SEG & VALUE_DELIMITER &
               x & VALUE_DELIMITER &
               y & VALUE_DELIMITER &
               t.Tag & VALUE_DELIMITER &
               t.Text & VALUE_DELIMITER &
               t.ForeColor.A & VALUE_DELIMITER &
               t.ForeColor.R & VALUE_DELIMITER &
               t.ForeColor.G & VALUE_DELIMITER &
               t.ForeColor.B & SEGMENT_DELIMITER
    End Function
    Protected Shared Function loadTileSegment(ByVal seg As String) As mTile
        If Not seg.StartsWith(TILE_INFO_SEG) Then Throw New Exception("Tile """ & seg & """ is corrupt!")

        seg = seg.Replace(SEGMENT_DELIMITER, "")

        Dim subseg = seg.Split(VALUE_DELIMITER)

        Return New mTile(CInt(subseg(3)), subseg(4), Color.FromArgb(CInt(subseg(5)), CInt(subseg(6)), CInt(subseg(7)), CInt(subseg(8))))
    End Function
    Protected Shared Function saveChestLoop(ByRef c As Chest) As String
        If c.GetType.IsSubclassOf(GetType(LoadedChest)) Or c.GetType Is GetType(LoadedChest) Then Return saveLoadedChestSegment(CType(c, LoadedChest))

        Return CHEST_SEG & VALUE_DELIMITER &
               c.pos.X & VALUE_DELIMITER &
               c.pos.Y & VALUE_DELIMITER &
               c.contents.count & VALUE_DELIMITER &
               c.contents.calcSum & SEGMENT_DELIMITER & vbCrLf &
               saveInventoryLoop(c.contents)
    End Function
    Protected Shared Function loadChestLoop(ByVal save As List(Of String), ByVal start_pos As Integer) As Tuple(Of Chest, Integer)
        If save(start_pos).StartsWith(LOADED_CHEST_SEG) Then Return loadLoadedChestSegment(save, start_pos)
        If Not save(start_pos).StartsWith(CHEST_SEG) Then Throw New Exception("Chest at line " & start_pos & " is corrupt!")

        Dim header_seg = save(start_pos).Replace(SEGMENT_DELIMITER, "")

        Dim subseg = header_seg.Split(VALUE_DELIMITER)

        Dim pos As Point = New Point(CInt(subseg(1)), CInt(subseg(2)))
        start_pos += 1

        Dim inv_tuple = loadInventoryLoop(save, start_pos)
        Dim contents As Inventory = inv_tuple.Item1

        Dim c As Chest = New Chest()
        c.pos = pos
        c.contents = contents

        Return New Tuple(Of Chest, Integer)(c, inv_tuple.Item2)
    End Function
    Protected Shared Function saveLoadedChestSegment(ByRef c As LoadedChest) As String
        Return LOADED_CHEST_SEG & VALUE_DELIMITER &
               CStr(c.pos.X) & VALUE_DELIMITER &
               CStr(c.pos.Y) & VALUE_DELIMITER &
               CStr(c.cid) & SEGMENT_DELIMITER
    End Function
    Protected Shared Function loadLoadedChestSegment(ByVal save As List(Of String), ByVal start_pos As Integer) As Tuple(Of Chest, Integer)
        Dim header_seg = save(start_pos).Replace(SEGMENT_DELIMITER, "")

        Dim subseg = header_seg.Split(VALUE_DELIMITER)
        Dim pos As Point = New Point(CInt(subseg(1)), CInt(subseg(2)))
        Dim cind = CInt(subseg(3))

        Dim l_chest = New LoadedChest(pos, cind)

        Return New Tuple(Of Chest, Integer)(l_chest, -1)
    End Function
    Protected Shared Function saveStatueSegment(ByRef s As Statue) As String
        Return STATUE_SEG & VALUE_DELIMITER &
               s.pos.X & VALUE_DELIMITER &
               s.pos.Y & VALUE_DELIMITER &
               s.desc & VALUE_DELIMITER &
               s.isRuby & SEGMENT_DELIMITER
    End Function
    Protected Shared Function loadStatueSegment(ByVal seg As String) As Statue
        seg = seg.Replace(SEGMENT_DELIMITER, "")
        seg = seg.Replace(STATUE_SEG & VALUE_DELIMITER, "")

        Return New Statue(seg)
    End Function
    Protected Shared Function saveTrapSegment(ByRef t As Trap) As String
        Return TRAP_SEG & VALUE_DELIMITER &
               t.pos.X & VALUE_DELIMITER &
               t.pos.Y & VALUE_DELIMITER &
               t.iD & SEGMENT_DELIMITER
    End Function
    Protected Shared Function loadTrapSegment(ByVal seg As String) As Trap
        seg = seg.Replace(SEGMENT_DELIMITER, "")
        seg = seg.Replace(TRAP_SEG & VALUE_DELIMITER, "")

        Return Trap.trapFactory(seg)
    End Function

    '| - NPC Loop - |
    Protected Shared Function saveNPCSegment(ByRef npc As ShopNPC) As String
        Return NPC_SEG & VALUE_DELIMITER &
               npc.npc_index & VALUE_DELIMITER &
               npc.img_index & VALUE_DELIMITER &
               npc.gold & VALUE_DELIMITER &
               npc.pos.X & VALUE_DELIMITER &
               npc.pos.Y & VALUE_DELIMITER &
               npc.form & VALUE_DELIMITER &
               npc.title & VALUE_DELIMITER &
               npc.pronoun & VALUE_DELIMITER &
               npc.p_pronoun & VALUE_DELIMITER &
               npc.r_pronoun & VALUE_DELIMITER &
               npc.isShop & VALUE_DELIMITER &
               npc.isDead & SEGMENT_DELIMITER
    End Function
    Protected Shared Function saveNPCSLoop() As String
        'npcs header segment
        Dim npcs_loop = NPCS_HEADER_SEG & VALUE_DELIMITER &
                        Game.shop_npc_list.Count & SEGMENT_DELIMITER

        For Each npc In Game.shop_npc_list
            npcs_loop += vbCrLf & saveNPCSegment(npc)
        Next

        Return npcs_loop & vbCrLf & NPCS_END_SEG & SEGMENT_DELIMITER
    End Function
    Protected Shared Function loadNPCUpperBound(ByVal seg As String) As Integer
        seg = seg.Replace(SEGMENT_DELIMITER, "")

        Dim subseg = seg.Split(VALUE_DELIMITER)

        Return CInt(subseg(1))
    End Function
    Protected Shared Function loadNPCSegment(ByVal seg As String) As ShopNPC
        seg = seg.Replace(SEGMENT_DELIMITER, "")

        Dim subseg = seg.Split(VALUE_DELIMITER)

        Dim shop_npc As ShopNPC = ShopNPC.shopFactory(CInt(subseg(1)))

        shop_npc.img_index = CInt(subseg(2))
        shop_npc.setGold(CInt(subseg(3)))
        shop_npc.pos = New Point(CInt(subseg(4)), CInt(subseg(5)))
        shop_npc.form = subseg(6)
        shop_npc.title = subseg(7)
        shop_npc.pronoun = subseg(8)
        shop_npc.p_pronoun = subseg(9)
        shop_npc.r_pronoun = subseg(10)
        shop_npc.isShop = CBool(subseg(11))
        shop_npc.isDead = CBool(subseg(12))

        Return shop_npc
    End Function
    Protected Shared Sub loadNPCSLoop(ByVal save As List(Of String), ByVal start_pos As Integer)
        If Not save(start_pos).StartsWith(NPCS_HEADER_SEG) Then Throw New Exception("Saved NPCs at line " & start_pos & " are corrupt!")

        Game.shop_npc_list.Clear()

        For i = 1 To loadNPCUpperBound(save(start_pos))
            Game.shop_npc_list.Add(loadNPCSegment(save(start_pos + i)))
        Next

        Game.shopkeeper = Game.shop_npc_list(0)
        Game.swiz = Game.shop_npc_list(1)
        Game.hteach = Game.shop_npc_list(2)
        Game.fvend = Game.shop_npc_list(3)
        Game.wsmith = Game.shop_npc_list(4)
        Game.cbrok = Game.shop_npc_list(5)
        Game.mgirl = Game.shop_npc_list(6)
        Game.ttraveler = Game.shop_npc_list(7)
        Game.fqueen = Game.shop_npc_list(8)
    End Sub

    '| - Player Loop - |
    Protected Shared Function savePlayerHeaderSegment(ByRef p As Player) As String
        Return PLAYER_HEADER_SEG & VALUE_DELIMITER &
               p.pos.X & VALUE_DELIMITER &
               p.pos.Y & VALUE_DELIMITER &
               p.health & VALUE_DELIMITER &
               p.mana & VALUE_DELIMITER &
               p.stamina & VALUE_DELIMITER &
               p.hBuff & VALUE_DELIMITER &
               p.mBuff & VALUE_DELIMITER &
               p.aBuff & VALUE_DELIMITER &
               p.dBuff & VALUE_DELIMITER &
               p.wBuff & VALUE_DELIMITER &
               p.sBuff & VALUE_DELIMITER &
               p.level & VALUE_DELIMITER &
               p.xp & VALUE_DELIMITER &
               p.nextLevelXp & VALUE_DELIMITER &
               CType(p.inv.item(69), ThrallCollar).save() & VALUE_DELIMITER &
               p.ongoingTFs.count & VALUE_DELIMITER &
               p.selfPolyForms.Count & VALUE_DELIMITER &
               p.enemPolyForms.Count & VALUE_DELIMITER &
               p.knownSpells.Count & VALUE_DELIMITER &
               p.knownSpecials.Count & VALUE_DELIMITER &
               p.quests.Count & VALUE_DELIMITER &
               p.ongoingQuests.count & SEGMENT_DELIMITER
    End Function
    Protected Shared Function savePlayerLoop(ByRef p As Player) As String
        Dim save_loop As String = savePlayerHeaderSegment(p) & vbCrLf

        For i = 0 To p.ongoingTFs.count - 1
            If Not (p.ongoingTFs.getAt(i) Is Nothing) Then
                save_loop += saveTransformationSegment(p.ongoingTFs.getAt(i)) & vbCrLf
            Else
                save_loop += TRANSFORMATION_SEG & VALUE_DELIMITER & "NULL" & SEGMENT_DELIMITER & vbCrLf
            End If
        Next

        For Each s In p.selfPolyForms
            save_loop += saveSelfPolySegment(s) & vbCrLf
        Next

        For Each e In p.enemPolyForms
            save_loop += saveEnemyPolySegment(e) & vbCrLf
        Next

        For Each s In p.knownSpells
            save_loop += saveSpellSegment(s) & vbCrLf
        Next

        For Each s In p.knownSpecials
            save_loop += saveSpecialSegment(s) & vbCrLf
        Next

        For Each q In p.quests
            save_loop += saveQuestSegment(q) & vbCrLf
        Next

        For i = 0 To p.ongoingQuests.count - 1
            save_loop += saveOngoingQuestSegment(p.ongoingQuests.getAt(i).getQInd) & vbCrLf
        Next

        save_loop += savePlayerStateLoop(p.currState) & vbCrLf
        save_loop += savePlayerStateLoop(p.pState) & vbCrLf
        save_loop += savePlayerStateLoop(p.sState) & vbCrLf

        For Each ste In p.formStates
            save_loop += savePlayerStateLoop(ste) & vbCrLf
        Next

        save_loop += saveInventoryLoop(p.inv)

        If (Game.mDun.numCurrFloor = 4 And Game.mDun.floor_boss(4) = "Ooze Empress") Then
            save_loop += saveTempInvSegment(Game.floor_4_starting_inv)
        End If

        Return save_loop & vbCrLf & PLAYER_END_SEG & SEGMENT_DELIMITER
    End Function
    Protected Shared Function loadPlayerLoop(ByVal save As List(Of String), ByVal start_pos As Integer) As Player
        If Not save(start_pos).StartsWith(PLAYER_HEADER_SEG) Then MsgBox(save(start_pos) & " " & PLAYER_HEADER_SEG) : Throw New Exception("Player at line " & start_pos & " is corrupt!")

        Dim p As Player = New Player()

        p.solFlag = True

        p.currState = New State(p)
        p.sState = New State(p)
        p.pState = New State(p)
        For i = 0 To UBound(p.formStates)
            p.formStates(i) = New State()
        Next

        Dim header_seg = save(start_pos).Replace(SEGMENT_DELIMITER, "")

        Dim subseg = header_seg.Split(VALUE_DELIMITER)

        p.pos = New Point(CInt(subseg(1)), CInt(subseg(2)))
        p.health = CDbl(subseg(3))
        p.mana = CInt(subseg(4))
        p.stamina = CInt(subseg(5))
        p.hBuff = CInt(subseg(6))
        p.mBuff = CInt(subseg(7))
        p.aBuff = CInt(subseg(8))
        p.dBuff = CInt(subseg(9))
        p.wBuff = CInt(subseg(10))
        p.sBuff = CInt(subseg(11))
        p.level = CInt(subseg(12))
        p.xp = CInt(subseg(13))
        p.nextLevelXp = CInt(subseg(14))

        start_pos += 1

        p.ongoingTFs = New TFList
        For i = 1 To CInt(subseg(16))
            If Not save(start_pos).Equals(TRANSFORMATION_SEG & VALUE_DELIMITER & "NULL") Then
                p.ongoingTFs.add(loadTransformationSegment(save(start_pos)))
            End If

            start_pos += 1
        Next

        p.selfPolyForms = New List(Of String)
        For i = 1 To CInt(subseg(17))
            p.selfPolyForms.Add(loadSelfPolySegment(save(start_pos)))
            start_pos += 1
        Next

        p.enemPolyForms = New List(Of String)
        For i = 1 To CInt(subseg(18))
            p.enemPolyForms.Add(loadEnemyPolySegment(save(start_pos)))
            start_pos += 1
        Next

        p.knownSpells = New List(Of String)
        For i = 1 To CInt(subseg(19))
            p.knownSpells.Add(loadSpellSegment(save(start_pos)))
            start_pos += 1
        Next

        p.knownSpecials = New List(Of String)
        For i = 1 To CInt(subseg(20))
            p.knownSpecials.Add(loadSpecialSegment(save(start_pos)))
            start_pos += 1
        Next

        For i = 1 To CInt(subseg(21))
            loadQuestSegment(save(start_pos), p.quests, i - 1)
            start_pos += 1
        Next

        p.ongoingQuests = New QuestList
        For i = 1 To CInt(subseg(22))
            p.ongoingQuests.add(p.quests(loadOngoingQuestSegment(save(start_pos))))
            start_pos += 1
        Next

        Dim cstate_tuple = loadPlayerStateLoop(save, start_pos)
        p.currState = cstate_tuple.Item1
        start_pos = 1 + cstate_tuple.Item2

        Dim pstate_tuple = loadPlayerStateLoop(save, start_pos)
        p.pState = pstate_tuple.Item1
        start_pos = 1 + pstate_tuple.Item2

        Dim sstate_tuple = loadPlayerStateLoop(save, start_pos)
        p.sState = sstate_tuple.Item1
        start_pos = 1 + sstate_tuple.Item2

        Dim ste_ct = 0
        Do While save(start_pos).StartsWith(PLAYER_STATE_HEADER_SEG)
            Dim state_tuple = loadPlayerStateLoop(save, start_pos)
            p.formStates(ste_ct) = state_tuple.Item1
            start_pos = 1 + state_tuple.Item2
            ste_ct += 1
        Loop

        Dim inv_tuple = loadInventoryLoop(save, start_pos)
        p.inv = inv_tuple.Item1
        Dim thrall_collar = subseg(15).Split(VALUE_SPLIT_DELIMITER)
        CType(p.inv.item(69), ThrallCollar).setFormerLife(thrall_collar(0), New Tuple(Of Integer, Boolean, Boolean)(CInt(thrall_collar(1)), CBool(thrall_collar(2)), CBool(thrall_collar(3))))
        start_pos += 1 + inv_tuple.Item2

        If (Game.mDun.numCurrFloor = 4 And Game.mDun.floor_boss(4) = "Ooze Empress") Then
            Game.floor_4_starting_inv = loadTempInvSegment(save(start_pos))
        End If

        p.solFlag = False

        p.currState.load(p, True)

        Return p
    End Function

    '| - Ongoing Transformation Segment - |
    Protected Shared Function saveTransformationSegment(ByRef tf As Transformation) As String
        Return TRANSFORMATION_SEG & VALUE_DELIMITER & tf.save() & SEGMENT_DELIMITER
    End Function
    Protected Shared Function loadTransformationSegment(ByVal seg As String) As Transformation
        seg = seg.Replace(SEGMENT_DELIMITER, "")
        seg = seg.Replace(TRANSFORMATION_SEG & VALUE_DELIMITER, "")

        Dim subseg = seg.Split(VALUE_DELIMITER)

        Return Transformation.newTF(subseg)
    End Function

    '| - Self Polymorph Segment - |
    Protected Shared Function saveSelfPolySegment(ByRef s As String) As String
        Return SELF_POLY_SEG & VALUE_DELIMITER & s & SEGMENT_DELIMITER
    End Function
    Protected Shared Function loadSelfPolySegment(ByVal seg As String) As String
        seg = seg.Replace(SEGMENT_DELIMITER, "")
        seg = seg.Replace(SELF_POLY_SEG & VALUE_DELIMITER, "")

        Return seg
    End Function

    '| - Enemy Polymorph Segment - |
    Protected Shared Function saveEnemyPolySegment(ByRef s As String) As String
        Return ENEMY_POLY_SEG & VALUE_DELIMITER & s & SEGMENT_DELIMITER
    End Function
    Protected Shared Function loadEnemyPolySegment(ByVal seg As String) As String
        seg = seg.Replace(SEGMENT_DELIMITER, "")
        seg = seg.Replace(ENEMY_POLY_SEG & VALUE_DELIMITER, "")

        Return seg
    End Function

    '| - Known Spell Segment - |
    Protected Shared Function saveSpellSegment(ByRef s As String) As String
        Return SPELL_SEG & VALUE_DELIMITER & s & SEGMENT_DELIMITER
    End Function
    Protected Shared Function loadSpellSegment(ByVal seg As String) As String
        seg = seg.Replace(SEGMENT_DELIMITER, "")
        seg = seg.Replace(SPELL_SEG & VALUE_DELIMITER, "")

        Return seg
    End Function

    '| - Known Special Segment - |
    Protected Shared Function saveSpecialSegment(ByRef s As String) As String
        Return SPECIAL_SEG & VALUE_DELIMITER & s & SEGMENT_DELIMITER
    End Function
    Protected Shared Function loadSpecialSegment(ByVal seg As String) As String
        seg = seg.Replace(SEGMENT_DELIMITER, "")
        seg = seg.Replace(SPECIAL_SEG & VALUE_DELIMITER, "")

        Return seg
    End Function

    '| - Quest Segment - |
    Protected Shared Function saveQuestSegment(ByRef q As Quest) As String
        Return QUEST_SEG & VALUE_DELIMITER & q.save() & SEGMENT_DELIMITER
    End Function
    Protected Shared Sub loadQuestSegment(ByVal seg As String, ByRef quests As List(Of Quest), ByVal i As Integer)
        seg = seg.Replace(SEGMENT_DELIMITER, "")
        seg = seg.Replace(QUEST_SEG & VALUE_DELIMITER, "")

        quests(i).load(seg)
    End Sub

    '| - Ongoing Quest Segment - |
    Protected Shared Function saveOngoingQuestSegment(ByRef q As qInd) As String
        Return ONGOING_QUEST_SEG & VALUE_DELIMITER & q.ToString() & SEGMENT_DELIMITER
    End Function
    Protected Shared Function loadOngoingQuestSegment(ByVal seg As String) As qInd
        seg = seg.Replace(SEGMENT_DELIMITER, "")
        seg = seg.Replace(ONGOING_QUEST_SEG & VALUE_DELIMITER, "")

        Return [Enum].Parse(GetType(perk), CInt(seg))
    End Function

    '| - Portrait Loop - |
    Protected Shared Function saveImageLayerSegment(ByRef prt As Tuple(Of Integer, Boolean, Boolean)) As String
        Return IMAGE_INDEX_SEG & VALUE_DELIMITER &
               prt.Item1 & VALUE_DELIMITER &
               prt.Item2 & VALUE_DELIMITER &
               prt.Item3 & SEGMENT_DELIMITER
    End Function
    Protected Shared Function loadImageLayerSegment(ByVal seg As String) As Tuple(Of Integer, Boolean, Boolean)
        seg = seg.Replace(SEGMENT_DELIMITER, "")

        Dim subseg = seg.Split(VALUE_DELIMITER)

        Return New Tuple(Of Integer, Boolean, Boolean)(CInt(subseg(1)), CBool(subseg(2)), CBool(subseg(3)))
    End Function
    Protected Shared Function savePortraitLoop(ByRef prt As Tuple(Of Integer, Boolean, Boolean)()) As String
        'portrait header segment
        Dim prt_loop = PORTRAIT_HEADER_SEG & VALUE_DELIMITER &
                       prt.Count & SEGMENT_DELIMITER

        For Each layer In prt
            prt_loop += vbCrLf & saveImageLayerSegment(layer)
        Next

        Return prt_loop & vbCrLf & PORTRAIT_END_SEG & SEGMENT_DELIMITER
    End Function
    Protected Shared Function loadPortraitUpperBound(ByVal seg As String) As Integer
        seg = seg.Replace(SEGMENT_DELIMITER, "")

        Dim subseg = seg.Split(VALUE_DELIMITER)

        Return CInt(subseg(1))
    End Function
    Protected Shared Function loadPortraitLoop(ByVal save As List(Of String), ByVal start_pos As Integer) As Tuple(Of Integer, Boolean, Boolean)()
        If Not save(start_pos).StartsWith(PORTRAIT_HEADER_SEG) Then Throw New Exception("Saved portait at line " & start_pos & " are corrupt!")

        Dim layerCount As Integer = loadPortraitUpperBound(save(start_pos))
        start_pos += 1

        Dim iArrInd(layerCount - 1) As Tuple(Of Integer, Boolean, Boolean)
        For i = 0 To layerCount - 1
            iArrInd(i) = loadImageLayerSegment(save(start_pos))
            start_pos += 1
        Next

        Return iArrInd
    End Function

    '| - Perk Loop - |
    Protected Shared Function savePerkSegment(ByRef p As Tuple(Of perk, Integer)) As String
        Return PERK_SEG & VALUE_DELIMITER &
               p.Item1.ToString & VALUE_DELIMITER &
               p.Item2 & SEGMENT_DELIMITER
    End Function
    Protected Shared Function loadPerkSegment(ByVal seg As String) As Tuple(Of perk, Integer)
        seg = seg.Replace(SEGMENT_DELIMITER, "")

        Dim subseg = seg.Split(VALUE_DELIMITER)

        Return New Tuple(Of perk, Integer)([Enum].Parse(GetType(perk), subseg(1)), CInt(subseg(2)))
    End Function
    Protected Shared Function loadPerkUpperBound(ByVal seg As String) As Integer
        seg = seg.Replace(SEGMENT_DELIMITER, "")

        Dim subseg = seg.Split(VALUE_DELIMITER)

        Return CInt(subseg(1))
    End Function
    Protected Shared Function savePerkLoop(ByRef perks As Dictionary(Of perk, Integer)) As String
        'portrait header segment
        Dim perk_loop = PERK_COUNT_SEG & VALUE_DELIMITER &
                        perks.Count & SEGMENT_DELIMITER & vbCrLf

        For Each p In perks.Keys
            perk_loop += savePerkSegment(New Tuple(Of perk, Integer)(p, perks(p))) & vbCrLf
        Next

        Return perk_loop
    End Function
    Protected Shared Function loadPerkLoop(ByVal save As List(Of String), ByRef start_pos As Integer) As Dictionary(Of perk, Integer)
        If Not save(start_pos).StartsWith(PERK_COUNT_SEG) Then Throw New Exception("Saved perks at line " & start_pos & " are corrupt!")

        Dim perks As Dictionary(Of perk, Integer) = New Dictionary(Of perk, Integer)
        Dim perkCount = loadPerkUpperBound(save(start_pos))
        start_pos += 1

        For i = 1 To perkCount
            Dim perk = loadPerkSegment(save(start_pos))
            perks.Add(perk.Item1, perk.Item2)

            start_pos += 1
        Next

        Return perks
    End Function

    '| - Color Segment - |
    Protected Shared Function saveColorSegment(ByRef clr As Color) As String
        Return COLOR_SEG & VALUE_DELIMITER &
               clr.A & VALUE_DELIMITER &
               clr.R & VALUE_DELIMITER &
               clr.G & VALUE_DELIMITER &
               clr.B & SEGMENT_DELIMITER
    End Function
    Protected Shared Function loadColorSegment(ByVal seg As String) As Color
        seg = seg.Replace(SEGMENT_DELIMITER, "")

        Dim subseg = seg.Split(VALUE_DELIMITER)

        Return Color.FromArgb(CInt(subseg(1)), CInt(subseg(2)), CInt(subseg(3)), CInt(subseg(4)))
    End Function

    '| - Player State Loop - |
    Protected Shared Function savePlayerStateLoop(ByRef ste As State) As String
        If Not ste.initFlag Then
            Return PLAYER_STATE_HEADER_SEG & VALUE_DELIMITER & "NULL" & SEGMENT_DELIMITER
        End If

        Return PLAYER_STATE_HEADER_SEG & VALUE_DELIMITER &
               ste.name & VALUE_DELIMITER &
               ste.pClass.name & VALUE_DELIMITER &
               ste.pForm.name & VALUE_DELIMITER &
               ste.description & VALUE_DELIMITER &
               ste.health & VALUE_DELIMITER &
               ste.maxHealth & VALUE_DELIMITER &
               ste.mana & VALUE_DELIMITER &
               ste.maxMana & VALUE_DELIMITER &
               ste.attack & VALUE_DELIMITER &
               ste.defense & VALUE_DELIMITER &
               ste.will & VALUE_DELIMITER &
               ste.speed & VALUE_DELIMITER &
               ste.lust & VALUE_DELIMITER &
               ste.stamina & VALUE_DELIMITER &
               ste.gold & VALUE_DELIMITER &
               ste.breastSize & VALUE_DELIMITER &
               ste.buttSize & VALUE_DELIMITER &
               ste.dickSize & VALUE_DELIMITER &
               ste.sex & VALUE_DELIMITER &
               ste.initFlag & VALUE_DELIMITER &
               ste.invNeedsUDate & VALUE_DELIMITER &
               ste.isPetrified & VALUE_DELIMITER &
               ste.equippedArmor.getAName & VALUE_DELIMITER &
               ste.equippedWeapon.getAName & VALUE_DELIMITER &
               ste.equippedAcce.getAName & VALUE_DELIMITER &
               ste.equippedGlasses.getAName & SEGMENT_DELIMITER & vbCrLf &
               saveColorSegment(ste.haircolor) & vbCrLf &
               saveColorSegment(ste.skincolor) & vbCrLf &
               saveColorSegment(ste.textColor) & vbCrLf &
               savePerkLoop(ste.perks) &
               savePortraitLoop(ste.iArrInd)
    End Function
    Protected Shared Function loadPlayerStateLoop(ByVal save As List(Of String), ByVal start_pos As Integer) As Tuple(Of State, Integer)
        Dim ste As State = New State()
        If save(start_pos).Equals(PLAYER_STATE_HEADER_SEG & VALUE_DELIMITER & "NULL") Then Return New Tuple(Of State, Integer)(ste, start_pos)

        Dim subseg = save(start_pos).Split(VALUE_DELIMITER)

        ste.name = subseg(1)
        ste.pClass = Player.classes(subseg(2))
        ste.pForm = Player.forms(subseg(3))
        ste.description = subseg(4)
        ste.health = CDbl(subseg(5))
        ste.maxHealth = CInt(subseg(6))
        ste.mana = CInt(subseg(7))
        ste.maxMana = CInt(subseg(8))
        ste.attack = CInt(subseg(9))
        ste.defense = CInt(subseg(10))
        ste.will = CInt(subseg(11))
        ste.speed = CInt(subseg(12))
        ste.lust = CInt(subseg(13))
        ste.stamina = CInt(subseg(14))
        ste.gold = CInt(subseg(15))
        ste.breastSize = CInt(subseg(16))
        ste.buttSize = CInt(subseg(17))
        ste.dickSize = CInt(subseg(18))
        ste.sex = subseg(19)
        ste.initFlag = CBool(subseg(20))
        ste.invNeedsUDate = CBool(subseg(21))
        ste.isPetrified = CBool(subseg(22))
        ste.equippedArmor = EquipmentDialogBackend.armor_list(subseg(23))
        ste.equippedWeapon = EquipmentDialogBackend.weapon_list(subseg(24))
        ste.equippedAcce = EquipmentDialogBackend.accessory_list(subseg(25))
        ste.equippedGlasses = EquipmentDialogBackend.glasses_list(subseg(26))
        start_pos += 1

        ste.haircolor = loadColorSegment(save(start_pos))
        start_pos += 1

        ste.skincolor = loadColorSegment(save(start_pos))
        start_pos += 1

        ste.textColor = loadColorSegment(save(start_pos))
        start_pos += 1

        ste.perks = loadPerkLoop(save, start_pos)

        ste.iArrInd = loadPortraitLoop(save, start_pos)

        start_pos += 1 + loadPortraitUpperBound(save(start_pos))

        Return New Tuple(Of State, Integer)(ste, start_pos)
    End Function

    '| - Inventory Loop - |
    Protected Shared Function saveInvItemSegment(ByRef i As Item) As String
        'save segment for an item
        Return ITEM_SEG & VALUE_DELIMITER &
               i.getAName() & VALUE_DELIMITER &
               i.getId() & VALUE_DELIMITER &
               i.getCount() & VALUE_DELIMITER &
               i.durability & SEGMENT_DELIMITER
    End Function
    Protected Shared Function saveInvMysteryPotionDataSegment(ByRef m_pot As MysteryPotion) As String
        'save segment for mystery potion data
        Return MYSTERY_POT_SEG & VALUE_DELIMITER &
               m_pot.getId & VALUE_DELIMITER &
               m_pot.getName() & VALUE_DELIMITER &
               m_pot.hasBeenUsed & SEGMENT_DELIMITER
    End Function
    Protected Shared Function saveInventoryLoop(ByRef inv As Inventory) As String
        'inventory header segment
        Dim inventory_loop = INVENTORY_HEADER_SEG & VALUE_DELIMITER & inv.upperBound & SEGMENT_DELIMITER

        'item segments
        For i = 0 To inv.upperBound
            If inv.item(i).count > 0 Or SAVE_EMPTY_SPACES Then inventory_loop += vbCrLf & saveInvItemSegment(inv.item(i))
        Next

        'mystery potion segments
        If Not inv.getMPotions() Is Nothing Then
            For Each m_pot In inv.getMPotions()
                inventory_loop += vbCrLf & saveInvMysteryPotionDataSegment(m_pot)
            Next
        End If

        'terminal segment
        Return inventory_loop & vbCrLf & INVENTORY_END_SEG & VALUE_DELIMITER & DDUtils.countToken(inventory_loop, SEGMENT_DELIMITER) + 1 & SEGMENT_DELIMITER
    End Function
    Protected Shared Function loadUpperBound(ByVal seg As String) As Integer
        seg = seg.Replace(SEGMENT_DELIMITER, "")

        Return CInt(seg.Split(VALUE_DELIMITER)(1))
    End Function
    Protected Shared Sub loadItem(ByVal seg As String, ByRef inv As Inventory)
        seg = seg.Replace(SEGMENT_DELIMITER, "")

        Dim subseg = seg.Split(VALUE_DELIMITER)

        Dim itmName = subseg(1)
        Dim itmId = subseg(2)
        Dim itmCount = CInt(subseg(3))
        Dim itmDura = CInt(subseg(4))

        inv.add(itmName, itmCount)
        inv.item(itmName).durability = itmDura
    End Sub
    Protected Shared Sub loadMysteryPot(ByVal seg As String, ByRef inv As Inventory)
        seg = seg.Replace(SEGMENT_DELIMITER, "")

        Dim subseg = seg.Split(VALUE_DELIMITER)

        Dim itmId = CInt(subseg(1))
        Dim itmName = subseg(2)
        Dim itmHasBeenUsed = CBool(subseg(3))

        If inv.item(itmId).GetType.IsSubclassOf(GetType(MysteryPotion)) Then
            CType(inv.item(itmId), MysteryPotion).setFName(itmName)
            CType(inv.item(itmId), MysteryPotion).hasBeenUsed = itmHasBeenUsed
            If itmHasBeenUsed Then CType(inv.item(itmId), MysteryPotion).reveal()
            inv.getMPotions.Add(CType(inv.item(itmId), MysteryPotion))
        End If
    End Sub
    Protected Shared Function loadInventoryLoop(ByVal save As List(Of String), ByVal start_pos As Integer) As Tuple(Of Inventory, Integer)
        If Not save(start_pos).StartsWith(INVENTORY_HEADER_SEG) Then Throw New Exception("Inventory at line " & start_pos & " is corrupt!")

        Dim upper_bound = loadUpperBound(save(start_pos))

        Dim cursor = start_pos + 1

        Dim inv = New Inventory()
        inv.mPotions = New List(Of MysteryPotion)

        Do Until cursor - start_pos > upper_bound * 2 Or save(cursor).StartsWith(INVENTORY_END_SEG)
            If save(cursor).StartsWith(ITEM_SEG) Then
                loadItem(save(cursor), inv)
            ElseIf save(cursor).StartsWith(MYSTERY_POT_SEG) Then
                loadMysteryPot(save(cursor), inv)
            End If

            cursor += 1
        Loop

        If Not save(cursor).StartsWith(INVENTORY_END_SEG) Then Throw New Exception("Inventory at line " & start_pos & " is corrupt!")

        inv.calcSum()

        Return New Tuple(Of Inventory, Integer)(inv, cursor - start_pos)
    End Function
    Protected Shared Function saveTempInvSegment(ByRef l As ArrayList)
        Dim segment As String = TEMP_INVENTORY_HEADER_SEG

        segment += VALUE_DELIMITER & l.Count()

        For Each itm In l
            segment += VALUE_DELIMITER & itm
        Next

        Return segment & SEGMENT_DELIMITER
    End Function
    Protected Shared Function loadTempInvSegment(ByVal seg As String) As ArrayList
        If Not seg.StartsWith(TEMP_INVENTORY_HEADER_SEG) Then MsgBox("Temp. Inv is corrupt!")

        seg = seg.Replace(SEGMENT_DELIMITER, "")
        Dim subseg = seg.Split(VALUE_DELIMITER)

        Dim temp_inv = New ArrayList()

        For i = 2 To CInt(subseg(1)) + 1
            temp_inv.Add(CInt(subseg(i)))
        Next

        Return temp_inv
    End Function
End Class
