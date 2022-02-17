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
    Private Const PORTRAIT_HEADER_SEG As String = "PRT"
    Private Const PORTRAIT_END_SEG As String = "EPRT"
    Private Const NPCS_HEADER_SEG As String = "SNPC"
    Private Const NPCS_END_SEG As String = "ENPC"
    Private Const PLAYER_STATE_HEADER_SEG As String = "STE"
    Private Const PLAYER_STATE_END_SEG As String = "ESTE"
    Private Const DUNGEON_SETTING_SEG As String = "DSET"
    Private Const PLAYER_HEADER_SEG As String = "PLR"
    Private Const PLAYER_END_SEG As String = "EPLR"

    Private Shared resumableSegments() As String = {SAVE_SEG, INVENTORY_HEADER_SEG, PORTRAIT_HEADER_SEG, PERK_COUNT_SEG, NPCS_HEADER_SEG, PLAYER_STATE_HEADER_SEG, DUNGEON_SETTING_SEG, PLAYER_HEADER_SEG}

    Public Const SEGMENT_DELIMITER As String = "~"
    Public Const VALUE_DELIMITER As String = "*"
    Public Const VALUE_SPLIT_DELIMITER As String = "%"

    '| - File Creation/Load Segments - |
    Public Shared Sub save()
        Dim writer As IO.StreamWriter
        IO.File.Delete("s.avex")
        writer = IO.File.CreateText("s.avex")

        writer.WriteLine(saveSaveInfoSegment())
        writer.WriteLine(saveDungeonSettingsSegment())
        writer.WriteLine(saveNPCSLoop())
        writer.WriteLine(savePlayerLoop(Game.player1))

        writer.Flush()
        writer.Close()
    End Sub

    '| -- Save Info Segment (SVE) -- |
    Public Shared Function saveSaveInfoSegment() As String
        Return SAVE_SEG & VALUE_DELIMITER &
               Game.version & VALUE_DELIMITER &
               Game.sessionID & VALUE_DELIMITER &
               DateTime.Now.ToString("yyyyMMddhhmm") & SEGMENT_DELIMITER
    End Function
    Public Shared Sub loadSaveInfoSegment(ByVal v As Double, ByVal sID As Integer)
        Game.version = v
        Game.sessionID = sID
    End Sub

    '| - World Flag Loop - |


    '| - Dungeon Map Loop - |


    '| - NPC Loop - |
    Public Shared Function saveNPCSegment(ByRef npc As ShopNPC) As String
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
    Public Shared Function saveNPCSLoop() As String
        'npcs header segment
        Dim npcs_loop = NPCS_HEADER_SEG & VALUE_DELIMITER &
                        Game.shop_npc_list.Count & SEGMENT_DELIMITER

        For Each npc In Game.shop_npc_list
            npcs_loop += vbCrLf & saveNPCSegment(npc)
        Next

        Return npcs_loop & vbCrLf & NPCS_END_SEG & SEGMENT_DELIMITER
    End Function
    Public Shared Function loadNPCUpperBound(ByVal seg As String) As Integer
        seg = seg.Replace(SEGMENT_DELIMITER, "")

        Dim subseg = seg.Split(VALUE_DELIMITER)

        Return CInt(subseg(1))
    End Function
    Public Shared Function loadNPCSegment(ByVal seg As String) As ShopNPC
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
    Public Shared Sub loadNPCSLoop(ByVal save As List(Of String), ByVal start_pos As Integer)
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
    End Sub

    '| - Player Loop - |
    Public Shared Function savePlayerHeaderSegment(ByRef p As Player) As String
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
    Public Shared Function savePlayerLoop(ByRef p As Player) As String
        Dim save_loop As String = savePlayerHeaderSegment(p) & vbCrLf

        For i = 0 To p.ongoingTFs.count - 1
            save_loop += saveTransformationSegment(p.ongoingTFs.getAt(i)) & vbCrLf
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

        Return save_loop & vbCrLf & PLAYER_END_SEG & SEGMENT_DELIMITER
    End Function
    Public Shared Function loadPlayerLoop(ByVal save As List(Of String), ByVal start_pos As Integer) As Player
        Dim p As Player = New Player()

        p.solFlag = True

        p.currState = New State(p)
        p.sState = New State(p)
        p.pState = New State(p)
        For i = 0 To UBound(p.formStates)
            p.formStates(i) = New State()
        Next

        p.solFlag = False

        Return p
    End Function

    '| - Ongoing Transformation Segment - |
    Public Shared Function saveTransformationSegment(ByRef tf As Transformation) As String
        Return TRANSFORMATION_SEG & VALUE_DELIMITER & tf.save() & SEGMENT_DELIMITER
    End Function
    Public Shared Function loadTransformationSegment(ByVal seg As String) As Transformation
        seg = seg.Replace(SEGMENT_DELIMITER, "")
        seg = seg.Replace(PLAYER_HEADER_SEG & VALUE_DELIMITER, "")

        Dim subseg = seg.Split(VALUE_DELIMITER)

        Return Transformation.newTF(subseg)
    End Function

    '| - Self Polymorph Segment - |
    Public Shared Function saveSelfPolySegment(ByRef s As String) As String
        Return SELF_POLY_SEG & VALUE_DELIMITER & s & SEGMENT_DELIMITER
    End Function
    Public Shared Function loadSelfPolySegment(ByVal seg As String) As String
        seg = seg.Replace(SEGMENT_DELIMITER, "")
        seg = seg.Replace(SELF_POLY_SEG & VALUE_DELIMITER, "")

        Return seg
    End Function

    '| - Enemy Polymorph Segment - |
    Public Shared Function saveEnemyPolySegment(ByRef s As String) As String
        Return ENEMY_POLY_SEG & VALUE_DELIMITER & s & SEGMENT_DELIMITER
    End Function
    Public Shared Function loadEnemyPolySegment(ByVal seg As String) As String
        seg = seg.Replace(SEGMENT_DELIMITER, "")
        seg = seg.Replace(ENEMY_POLY_SEG & VALUE_DELIMITER, "")

        Return seg
    End Function

    '| - Known Spell Segment - |
    Public Shared Function saveSpellSegment(ByRef s As String) As String
        Return SPELL_SEG & VALUE_DELIMITER & s & SEGMENT_DELIMITER
    End Function
    Public Shared Function loadSpellSegment(ByVal seg As String) As String
        seg = seg.Replace(SEGMENT_DELIMITER, "")
        seg = seg.Replace(SPELL_SEG & VALUE_DELIMITER, "")

        Return seg
    End Function

    '| - Known Special Segment - |
    Public Shared Function saveSpecialSegment(ByRef s As String) As String
        Return SPECIAL_SEG & VALUE_DELIMITER & s & SEGMENT_DELIMITER
    End Function
    Public Shared Function loadSpecialSegment(ByVal seg As String) As String
        seg = seg.Replace(SEGMENT_DELIMITER, "")
        seg = seg.Replace(SPECIAL_SEG & VALUE_DELIMITER, "")

        Return seg
    End Function

    '| - Quest Segment - |
    Public Shared Function saveQuestSegment(ByRef q As Quest) As String
        Return QUEST_SEG & VALUE_DELIMITER & q.save() & SEGMENT_DELIMITER
    End Function
    Public Shared Sub loadQuestSegment(ByVal seg As String, ByRef quests As List(Of Quest), ByVal i As Integer)
        seg = seg.Replace(SEGMENT_DELIMITER, "")
        seg = seg.Replace(QUEST_SEG & VALUE_DELIMITER, "")

        quests(i).load(seg)
    End Sub

    '| - Ongoing Quest Segment - |
    Public Shared Function saveOngoingQuestSegment(ByRef q As qInds) As String
        Return ONGOING_QUEST_SEG & VALUE_DELIMITER & q.ToString() & SEGMENT_DELIMITER
    End Function
    Public Shared Function loadOngoingQuestSegment(ByVal seg As String) As qInds
        seg = seg.Replace(SEGMENT_DELIMITER, "")
        seg = seg.Replace(ONGOING_QUEST_SEG & VALUE_DELIMITER, "")

        Return [Enum].Parse(GetType(perk), CInt(seg))
    End Function

    '| - Portrait Loop - |
    Public Shared Function saveImageLayerSegment(ByRef prt As Tuple(Of Integer, Boolean, Boolean)) As String
        Return IMAGE_INDEX_SEG & VALUE_DELIMITER &
               prt.Item1 & VALUE_DELIMITER &
               prt.Item2 & VALUE_DELIMITER &
               prt.Item3 & SEGMENT_DELIMITER
    End Function
    Public Shared Function loadImageLayerSegment(ByVal seg As String) As Tuple(Of Integer, Boolean, Boolean)
        seg = seg.Replace(SEGMENT_DELIMITER, "")

        Dim subseg = seg.Split(VALUE_DELIMITER)

        Return New Tuple(Of Integer, Boolean, Boolean)(CInt(subseg(0)), CBool(subseg(1)), CBool(subseg(2)))
    End Function
    Public Shared Function savePortraitLoop(ByRef prt As Tuple(Of Integer, Boolean, Boolean)()) As String
        'portrait header segment
        Dim prt_loop = PORTRAIT_HEADER_SEG & VALUE_DELIMITER &
                       prt.Count & SEGMENT_DELIMITER

        For Each layer In prt
            Console.Out.WriteLine(layer.Item1)
            prt_loop += vbCrLf & saveImageLayerSegment(layer)
        Next

        Return prt_loop & vbCrLf & PORTRAIT_END_SEG & SEGMENT_DELIMITER
    End Function
    Public Shared Function loadPortraitUpperBound(ByVal seg As String) As Integer
        seg = seg.Replace(SEGMENT_DELIMITER, "")

        Dim subseg = seg.Split(VALUE_DELIMITER)

        Return CInt(subseg(1))
    End Function
    Public Shared Function loadPortraitLoop(ByVal save As List(Of String), ByVal start_pos As Integer) As Tuple(Of Integer, Boolean, Boolean)()
        If Not save(start_pos).StartsWith(PORTRAIT_HEADER_SEG) Then Throw New Exception("Saved portait at line " & start_pos & " are corrupt!")

        Dim layerCount As Integer = loadPortraitUpperBound(save(start_pos))

        Dim iArrInd(layerCount) As Tuple(Of Integer, Boolean, Boolean)
        For i = 0 To layerCount
            iArrInd(i) = loadImageLayerSegment(save(start_pos + 1 + i))
        Next

        Return iArrInd
    End Function

    '| - Perk Loop - |
    Public Shared Function savePerkSegment(ByRef p As Tuple(Of perk, Integer)) As String
        Return PERK_SEG & VALUE_DELIMITER &
               p.Item1.ToString & VALUE_DELIMITER &
               p.Item2 & SEGMENT_DELIMITER
    End Function
    Public Shared Function loadPerkSegment(ByVal seg As String) As Tuple(Of perk, Integer)
        seg = seg.Replace(SEGMENT_DELIMITER, "")

        Dim subseg = seg.Split(VALUE_DELIMITER)

        Return New Tuple(Of perk, Integer)([Enum].Parse(GetType(perk), CInt(subseg(0))), CInt(subseg(1)))
    End Function
    Public Shared Function loadPerkUpperBound(ByVal seg As String) As Integer
        seg = seg.Replace(SEGMENT_DELIMITER, "")

        Dim subseg = seg.Split(VALUE_DELIMITER)

        Return CInt(subseg(1))
    End Function
    Public Shared Function savePerkLoop(ByRef perks As Dictionary(Of perk, Integer)) As String
        'portrait header segment
        Dim perk_loop = PERK_COUNT_SEG & VALUE_DELIMITER &
                        perks.Count & SEGMENT_DELIMITER & vbCrLf

        For Each p In perks.Keys
            perk_loop += savePerkSegment(New Tuple(Of perk, Integer)(p, perks(p))) & vbCrLf
        Next

        Return perk_loop
    End Function
    Public Shared Function loadPerkLoop(ByVal save As List(Of String), ByRef start_pos As Integer) As Dictionary(Of perk, Integer)
        If Not save(start_pos).StartsWith(PERK_COUNT_SEG) Then Throw New Exception("Saved perks at line " & start_pos & " are corrupt!")

        Dim perks As Dictionary(Of perk, Integer) = New Dictionary(Of perk, Integer)
        Dim perkCount = loadPerkUpperBound(save(start_pos))
        For i = 0 To perkCount
            Dim perk = loadPerkSegment(save(start_pos + 1 + i))
            perks.Add(perk.Item1, perk.Item2)
        Next

        start_pos += 2 + perkCount

        Return perks
    End Function

    '| - Color Segment - |
    Public Shared Function saveColorSegment(ByRef clr As Color) As String
        Return COLOR_SEG & VALUE_DELIMITER &
               clr.A & VALUE_DELIMITER &
               clr.R & VALUE_DELIMITER &
               clr.G & VALUE_DELIMITER &
               clr.B & SEGMENT_DELIMITER
    End Function
    Public Shared Function loadColorSegment(ByVal seg As String) As Color
        seg = seg.Replace(SEGMENT_DELIMITER, "")

        Dim subseg = seg.Split(VALUE_DELIMITER)

        Return Color.FromArgb(CInt(subseg(0)), CInt(subseg(1)), CInt(subseg(2)), CInt(subseg(3)))
    End Function

    '| - Player State Loop - |
    Public Shared Function savePlayerStateLoop(ByRef ste As State) As String
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
    Public Shared Function loadPlayerStateLoop(ByVal save As List(Of String), ByVal start_pos As Integer) As State
        Dim ste As State = New State()

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
        ste.sex = CBool(subseg(19))
        ste.initFlag = CBool(subseg(20))
        ste.invNeedsUDate = CBool(subseg(21))
        ste.isPetrified = CBool(subseg(22))
        ste.equippedArmor = EquipmentDialogBackend.armor_list(subseg(23))
        ste.equippedWeapon = EquipmentDialogBackend.weapon_list(subseg(24))
        ste.equippedAcce = EquipmentDialogBackend.accessory_list(subseg(25))
        ste.equippedGlasses = EquipmentDialogBackend.glasses_list(subseg(26))

        ste.perks = loadPerkLoop(save, start_pos + 1)
        start_pos += 1

        ste.iArrInd = loadPortraitLoop(save, start_pos)

        Return ste
    End Function

    '| - Inventory Loop - |
    Public Shared Function saveInvItemSegment(ByRef i As Item) As String
        'save segment for an item
        Return ITEM_SEG & VALUE_DELIMITER &
               i.getAName() & VALUE_DELIMITER &
               i.getId() & VALUE_DELIMITER &
               i.getCount() & VALUE_DELIMITER &
               i.durability & SEGMENT_DELIMITER
    End Function
    Public Shared Function saveInvMysteryPotionDataSegment(ByRef m_pot As MysteryPotion) As String
        'save segment for mystery potion data
        Return MYSTERY_POT_SEG & VALUE_DELIMITER &
               m_pot.getId & VALUE_DELIMITER &
               m_pot.getName() & VALUE_DELIMITER &
               m_pot.hasBeenUsed & SEGMENT_DELIMITER
    End Function
    Public Shared Function saveInventoryLoop(ByRef inv As Inventory) As String
        'inventory header segment
        Dim inventory_loop = INVENTORY_HEADER_SEG & VALUE_DELIMITER & inv.upperBound & SEGMENT_DELIMITER

        'item segments
        For i = 0 To inv.upperBound
            inventory_loop += vbCrLf & saveInvItemSegment(inv.item(i))
        Next

        'mystery potion segments
        For Each m_pot In inv.getMPotions()
            inventory_loop += vbCrLf & saveInvMysteryPotionDataSegment(m_pot)
        Next

        'terminal segment
        Return inventory_loop & vbCrLf & INVENTORY_END_SEG & VALUE_DELIMITER & DDUtils.countToken(inventory_loop, SEGMENT_DELIMITER) + 1 & SEGMENT_DELIMITER
    End Function
    Public Shared Function loadUpperBound(ByVal seg As String) As Integer
        seg = seg.Replace(SEGMENT_DELIMITER, "")

        Return CInt(seg.Split(VALUE_DELIMITER)(1))
    End Function
    Public Shared Sub loadItem(ByVal seg As String, ByRef inv As Inventory)
        seg = seg.Replace(SEGMENT_DELIMITER, "")

        Dim subseg = seg.Split(VALUE_DELIMITER)

        Dim itmName = subseg(1)
        Dim itmId = subseg(2)
        Dim itmCount = CInt(subseg(3))
        Dim itmDura = CInt(subseg(4))

        inv.add(itmName, itmCount)
        inv.item(itmName).durability = itmDura
    End Sub
    Public Shared Sub loadMysteryPot(ByVal seg As String, ByRef inv As Inventory)
        seg = seg.Replace(SEGMENT_DELIMITER, "")

        Dim subseg = seg.Split(VALUE_DELIMITER)

        Dim itmId = subseg(1)
        Dim itmName = subseg(2)
        Dim itmHasBeenUsed = CBool(subseg(3))

        If inv.item(itmId).GetType.IsSubclassOf(GetType(MysteryPotion)) Then
            CType(inv.item(itmId), MysteryPotion).setFName(itmName)
            CType(inv.item(itmId), MysteryPotion).hasBeenUsed = itmHasBeenUsed
            If itmHasBeenUsed Then CType(inv.item(itmId), MysteryPotion).reveal()
        End If
    End Sub
    Public Shared Function loadInventoryLoop(ByVal save As List(Of String), ByVal start_pos As Integer) As Inventory
        If Not save(start_pos).StartsWith(INVENTORY_HEADER_SEG) Then Throw New Exception("Inventory at line " & start_pos & " is corrupt!")

        Dim upper_bound = loadUpperBound(save(start_pos))

        Dim cursor = start_pos + 1

        Dim inv = New Inventory

        Do Until cursor > upper_bound * 2 Or save(cursor).StartsWith(INVENTORY_END_SEG)
            If save(cursor).StartsWith(ITEM_SEG) Then
                loadItem(save(cursor), inv)
            ElseIf save(cursor).StartsWith(MYSTERY_POT_SEG) Then
                loadMysteryPot(save(cursor), inv)
            End If

            cursor += 1
        Loop

        If Not save(cursor).StartsWith(INVENTORY_END_SEG) Then Throw New Exception("Inventory at line " & start_pos & " is corrupt!")

        inv.calcSum()

        Return inv
    End Function

    '| - Dungeon Settings Loop - |
    Public Shared Function saveDungeonSettingsSegment() As String
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
    Public Shared Sub loadDungeonSettingsSegment(ByVal bW As Integer, ByVal bH As Integer, ByVal cFM As Integer, ByVal cFR As Integer, ByVal cSD As Integer, ByVal cRB As Integer, ByVal cRR As Integer, ByVal t As Integer, ByVal eR As Integer, ByVal eCRV As Integer)
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
End Class
