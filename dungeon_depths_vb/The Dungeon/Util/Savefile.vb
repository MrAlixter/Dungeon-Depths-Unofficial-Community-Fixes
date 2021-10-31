Public Class SaveFile
    Private Const SAVE_SEG As String = "SVE"
    Private Const ITEM_SEG As String = "ITM"
    Private Const MYSTERY_POT_SEG As String = "MPOT"
    Private Const IMAGE_INDEX_SEG As String = "IMG"
    Private Const PERK_SEG As String = "PERK"
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

    Private Shared resumableSegments() As String = {SAVE_SEG, INVENTORY_HEADER_SEG, PORTRAIT_HEADER_SEG, NPCS_HEADER_SEG, PLAYER_STATE_HEADER_SEG, DUNGEON_SETTING_SEG}

    '| -- Save Info Segment (SVE) -- |
    Public Shared Function saveSaveInfoSegment() As String
        Return SAVE_SEG & "*" & Game.version & "*" & Game.sessionID & "*" & DateTime.Now.ToString("yyyyMMddhhmm") & "~"
    End Function
    Public Shared Sub loadSaveInfoSegment(ByVal v As Double, ByVal sID As Integer)
        Game.version = v
        Game.sessionID = sID
    End Sub

    '| - World Flag Loop - |


    '| - Dungeon Map Loop - |


    '| - NPC Loop - |
    Public Function saveNPCSegment(ByRef npc As ShopNPC) As String
        Return NPC_SEG & "*" & npc.npc_index & "*" & npc.img_index & "*" & npc.gold & "*" & npc.pos.X & "*" & npc.pos.Y & "*" & npc.form & "*" & npc.title & "*" & npc.pronoun & "*" & npc.p_pronoun & "*" & npc.r_pronoun & "*" & npc.isShop & "*" & npc.isDead & "~"
    End Function
    Public Function saveNPCSLoop()
        'npcs header segment
        Dim npcs_loop = NPCS_HEADER_SEG & "*" & Game.shop_npc_list.Count & "~"

        For Each npc In Game.shop_npc_list
            npcs_loop += vbCrLf & saveNPCSegment(npc)
        Next

        Return npcs_loop & vbCrLf & NPCS_END_SEG & "~"
    End Function
    Public Shared Function loadNPCUpperBound(ByVal seg As String) As Integer
        seg = seg.Replace("~", "")

        Dim subseg = seg.Split("*")

        Return CInt(subseg(1))
    End Function
    Public Shared Function loadNPCSegment(ByVal seg As String) As ShopNPC
        seg = seg.Replace("~", "")

        Dim subseg = seg.Split("*")

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


    '| - Portrait Loop - |


    '| - Inventory Loop - |
    Public Shared Function saveInvItemSegment(ByRef i As Item) As String
        'save segment for an item
        Return ITEM_SEG & "*" & i.getAName() & "*" & i.getId() & "*" & i.getCount() & "*" & i.durability & "~"
    End Function
    Public Shared Function saveInvMysteryPotionDataSegment(ByRef m_pot As MysteryPotion) As String
        'save segment for mystery potion data
        Return MYSTERY_POT_SEG & "*" & m_pot.getId & "*" & m_pot.getName() & "*" & m_pot.hasBeenUsed & "~"
    End Function
    Public Shared Function saveInventoryLoop(ByRef inv As Inventory) As String
        'inventory header segment
        Dim inventory_loop = INVENTORY_HEADER_SEG & "*" & inv.upperBound & "~"

        'item segments
        For i = 0 To inv.upperBound
            inventory_loop += vbCrLf & saveInvItemSegment(inv.item(i))
        Next

        'mystery potion segments
        For Each m_pot In inv.getMPotions()
            inventory_loop += vbCrLf & saveInvMysteryPotionDataSegment(m_pot)
        Next

        'terminal segment
        Return inventory_loop & vbCrLf & INVENTORY_END_SEG & "*" & DDUtils.countToken(inventory_loop, "~") + 1 & "~"
    End Function
    Public Shared Function loadUpperBound(ByVal seg As String) As Integer
        seg = seg.Replace("~", "")

        Return CInt(seg.Split("*")(1))
    End Function
    Public Shared Sub loadItem(ByVal seg As String, ByRef inv As Inventory)
        seg = seg.Replace("~", "")

        Dim subseg = seg.Split("*")

        Dim itmName = subseg(1)
        Dim itmId = subseg(2)
        Dim itmCount = CInt(subseg(3))
        Dim itmDura = CInt(subseg(4))

        inv.add(itmName, itmCount)
        inv.item(itmName).durability = itmDura
    End Sub
    Public Shared Sub loadMysteryPot(ByVal seg As String, ByRef inv As Inventory)
        seg = seg.Replace("~", "")

        Dim subseg = seg.Split("*")

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
        Return DUNGEON_SETTING_SEG & "*" & Game.mBoardWidth & "*" & Game.mBoardHeight & "*" & Game.chestFreqMin & "*" & Game.chestFreqRange & "*" & Game.chestSizeDependence & "*" & Game.chestRichnessBase & "*" & Game.chestRichnessRange & "*" & Game.turn & "*" & Game.encounterRate & "*" & Game.eClockResetVal & "~"
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
