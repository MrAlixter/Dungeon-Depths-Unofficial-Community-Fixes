Public Enum wFlag
    stolecharmmarissa
    stolecharmtargax
    stolecharmoozee
    stolecharmmedusa
    stolecharmfaequeen
    allfrogs
    fvendsword
    hteachslime
    snarednpc
    marrissares
    seventailsstage
End Enum

Public Class Dungeon
    Public world_flags As Dictionary(Of wFlag, Integer) = New Dictionary(Of wFlag, Integer)()

    Public floor_boss As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)
    Public floor_codes As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)

    Public floors As Dictionary(Of Integer, mFloor) = New Dictionary(Of Integer, mFloor)
    Public numCurrFloor As Integer = -1
    Public lastVisitedFloor As Integer

    Public Sub New()
        Randomize()

        initFloorBoss()

        initFloorCodes()

        initWorldFlags()

        initFirstFloor()

        setPositions()

        setFloor(Game.currFloor)
    End Sub
    Public Sub New(save)
        load(save)
    End Sub

    Private Sub initFloorBoss()
        floor_boss.Add(1, "Marissa the Enchantress")
        floor_boss.Add(2, "Targax the Brutal")
        floor_boss.Add(3, "Key")
        floor_boss.Add(4, "Key")
        floor_boss.Add(5, "Medusa")
        floor_boss.Add(91018, "???")
    End Sub
    Private Sub initFloorCodes()
        floor_codes.Add(0, mFloor.genRNDLVLCode)
        floor_codes.Add(1, Game.seed)
        For i = 2 To 10
            floor_codes.Add(i, mFloor.genRNDLVLCode)
        Next
    End Sub
    Private Sub initWorldFlags()
        world_flags.Clear()

        'Creates the dictionary of world flags
        For Each f In System.Enum.GetValues(GetType(wFlag))
            world_flags.Add(f, -1)
        Next
    End Sub
    Private Sub initFirstFloor()
        numCurrFloor = 1
        lastVisitedFloor = 1
        If Not checkForUnloadedFloor() Then floors.Add(1, New mFloor(floor_codes(1), numCurrFloor))
    End Sub

    '| - NAVIGATION - |
    Public Sub floorDown()
        lastVisitedFloor = numCurrFloor
        floors(numCurrFloor).playerPosition = Game.player1.pos

        numCurrFloor += 1
        setupCurrentFloor()
    End Sub
    Public Sub floorUp()
        lastVisitedFloor = numCurrFloor
        floors(numCurrFloor).playerPosition = Game.player1.pos

        numCurrFloor -= 1
        If numCurrFloor = 0 Then TextEvent.push("As you near the top of the staircase leading out of the dungeon, you take a deep breath.  Unfortuately, you also trip; falling to your doom.", AddressOf Game.player1.die)
        setPositions()
    End Sub
    Public Sub jumpTo(ByVal i As Integer)
        lastVisitedFloor = numCurrFloor
        floors(numCurrFloor).playerPosition = New Point(Game.player1.pos.X, Game.player1.pos.Y)

        numCurrFloor = i
        setupCurrentFloor()
    End Sub

    '| - GENERATION - |
    Public Sub setupCurrentFloor()
        If Not floors.Keys.Contains(numCurrFloor) And Not checkForUnloadedFloor() Then
            If floor_codes.Keys.Contains(numCurrFloor) Then
                floors.Add(numCurrFloor, New mFloor(floor_codes(numCurrFloor), numCurrFloor))
            Else
                Dim newCode = mFloor.genRNDLVLCode
                floor_codes.Add(numCurrFloor, newCode)
                floors.Add(numCurrFloor, New mFloor(newCode, numCurrFloor))
            End If
        Else
            setPositions()
        End If
    End Sub
    Private Sub setPositions()
        If floors(numCurrFloor).playerPosition.X = -1 Or floors(numCurrFloor).playerPosition.Y = -1 Or mFloor.nonRandomFloors.Contains(numCurrFloor) Then
            Game.player1.pos = floors(numCurrFloor).getStartPlayerPos
        Else
            Game.player1.pos = floors(numCurrFloor).playerPosition
        End If

        If Not Game.player1.forcedPath Is Nothing AndAlso UBound(Game.player1.forcedPath) > 0 Then Game.player1.forcedPath = Nothing

        For i = 0 To Game.shop_npc_list.Count - 1
            If i < floors(numCurrFloor).npcPositions.Count Then
                Game.shop_npc_list(i).pos = floors(numCurrFloor).npcPositions(i)
            Else
                Game.shop_npc_list(i).pos = New Point(-1, -1)
            End If
        Next
    End Sub
    Public Sub reset()
        jumpTo(1)
        lastVisitedFloor = 1

        Game.player1.pos = floors(numCurrFloor).randPoint
    End Sub

    '| - ACCESSORS - |
    Public Function currFloorBoss() As String
        If floor_boss.ContainsKey(numCurrFloor) Then
            Return floor_boss(numCurrFloor)
        Else
            Return ""
        End If
    End Function
    Public Function currFloorCode() As String
        For Each c In floor_codes
        Next
        If floor_codes.Count > numCurrFloor Then
            Return floor_codes(numCurrFloor)
        Else
            Return ""
        End If
    End Function

    '| - MISC - |
    Public Sub tfNPCToArachne()
        If Game.player1 Is Nothing OrElse Game.player1.perks(perk.snarednpc) = -1 Then Exit Sub

        Dim s = Game.shop_npc_list(Game.player1.perks(perk.snarednpc))

        TextEvent.push("You feel a slight vibration in the web leading to your snare.  Maybe you should pay the " & s.name & " a visit...")

        s.toArachne()
        Game.player1.perks(perk.snarednpc) = -1
    End Sub
    Public Sub setFloor(ByRef f As mFloor)
        f = floors(numCurrFloor)
        Game.mBoardHeight = f.mBoardHeight
        Game.mBoardWidth = f.mBoardWidth
    End Sub
    Public Function checkForUnloadedFloor() As Boolean
        If Not floors.Keys.Contains(numCurrFloor) And floor_codes.Keys.Contains(numCurrFloor) AndAlso IO.File.Exists("floors/" & floor_codes(numCurrFloor) & ".flr") Then
            floors.Add(numCurrFloor, New mFloor(floor_codes(numCurrFloor)))
            Return True
        End If
        Return False
    End Function

    '| - SAVE/LOAD - |
    Function save()
        Dim out = ""

        out += numCurrFloor & "@"           '0
        out += lastVisitedFloor & "@"       '1

        out += floors.Keys.Count - 1 & "@"  '2
        For i = 0 To floors.Keys.Count - 1
            out += floors.Values(i).saveMFloor & "@"   '3 to 3 + floors.keys.count - 1
        Next

        out += floor_boss.Count - 1 & "@"      '2
        For i = 0 To floor_boss.Count - 1
            out += floor_boss.Keys(i) & "~" & floor_boss.Values(i) & "@"       '3 to 2 + floor_boss.length
        Next

        out += floor_codes.Count - 1 & "@"   '4 + floor_boss.length
        For i = 0 To floor_codes.Count - 1
            out += floor_codes.Keys(i) & "~" & floor_codes.Values(i) & "@"          '5 + floor_boss.length to 4 + floor_boss.length +  floor_codes.count
        Next

        Return out
    End Function
    Sub load(ByRef s As String)
        Dim buffer = s.Split("@")

        numCurrFloor = CInt(buffer(0))
        lastVisitedFloor = CInt(buffer(1))

        floors.Clear()
        For i = 0 To CInt(buffer(2))
            Dim tFloor = New mFloor(buffer(3 + i), False)
            floors.Add(tFloor.floorNumber, tFloor)
        Next

        floor_boss.Clear()
        For i = 0 To CInt(buffer(3 + floors.Keys.Count))
            Dim kvp() = buffer(4 + floors.Keys.Count + i).Split("~")
            floor_boss.Add(CInt(kvp(0)), kvp(1))
        Next

        floor_codes.Clear()
        For i = 0 To CInt(buffer(4 + floors.Keys.Count + floor_boss.Count))
            Dim kvp() = buffer(5 + floors.Keys.Count + floor_boss.Count + i).Split("~")
            floor_codes.Add(CInt(kvp(0)), kvp(1))
        Next

        checkForUnloadedFloor()
    End Sub
End Class
