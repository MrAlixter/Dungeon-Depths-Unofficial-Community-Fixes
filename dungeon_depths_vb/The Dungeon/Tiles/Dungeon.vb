Imports System.ComponentModel
Public Enum wFlag
    allfrogs
    fvendsword
    hteachslime
    snarednpc
    mrevived
End Enum

<Serializable()> Public Class Dungeon
    Public floorboss As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)
    Public floors As Dictionary(Of Integer, mFloor) = New Dictionary(Of Integer, mFloor)
    Public floorCodes As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)
    Public numCurrFloor As Integer = -1
    Public lastVisitedFloor As Integer

    Public Sub New()
        Randomize()

        floorboss.Add(1, "Marissa the Enchantress")
        floorboss.Add(2, "Targax the Brutal")
        floorboss.Add(3, "Key")
        floorboss.Add(4, "Key")
        floorboss.Add(5, "Medusa")
        floorboss.Add(91018, "???")

        floorCodes.Add(0, mFloor.genRNDLVLCode)
        floorCodes.Add(1, Game.seed)
        For i = 2 To 10
            floorCodes.Add(i, mFloor.genRNDLVLCode)
        Next

        numCurrFloor = 1
        lastVisitedFloor = 1
        If Not checkForUnloadedFloor() Then floors.Add(1, New mFloor(floorCodes(1), numCurrFloor))
        setPositions()
        setFloor(Game.currFloor)
    End Sub
    Public Sub New(save)
        load(save)
    End Sub
    Public Sub reset()
        jumpTo(1)
        lastVisitedFloor = 1

        Game.player1.pos = floors(numCurrFloor).randPoint
    End Sub

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
    Public Sub setupCurrentFloor()
        If Not floors.Keys.Contains(numCurrFloor) And Not checkForUnloadedFloor() Then
            If floorCodes.Keys.Contains(numCurrFloor) Then
                floors.Add(numCurrFloor, New mFloor(floorCodes(numCurrFloor), numCurrFloor))
            Else
                Dim newCode = mFloor.genRNDLVLCode
                floorCodes.Add(numCurrFloor, newCode)
                floors.Add(numCurrFloor, New mFloor(newCode, numCurrFloor))
            End If
        Else
            setPositions()
        End If
    End Sub
    Private Sub setPositions()
        If floors(numCurrFloor).playerPosition.X = -1 Or floors(numCurrFloor).playerPosition.Y = -1 Then
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
        If Not floors.Keys.Contains(numCurrFloor) And floorCodes.Keys.Contains(numCurrFloor) AndAlso IO.File.Exists("floors/" & floorCodes(numCurrFloor) & ".flr") Then
            floors.Add(numCurrFloor, New mFloor(floorCodes(numCurrFloor)))
            Return True
        End If
        Return False
    End Function

    Public Function currFloorBoss() As String
        If floorboss.ContainsKey(numCurrFloor) Then
            Return floorboss(numCurrFloor)
        Else
            Return ""
        End If
    End Function
    Public Function currFloorCode() As String
        For Each c In floorCodes
        Next
        If floorCodes.Count > numCurrFloor Then
            Return floorCodes(numCurrFloor)
        Else
            Return ""
        End If
    End Function

    Function save()
        Dim out = ""

        out += numCurrFloor & "@"           '0
        out += lastVisitedFloor & "@"       '1

        out += floors.Keys.Count - 1 & "@"  '2
        For i = 0 To floors.Keys.Count - 1
            out += floors.Values(i).saveMFloor & "@"   '3 to 3 + floors.keys.count - 1
        Next

        out += floorboss.Count - 1 & "@"      '2
        For i = 0 To floorboss.Count - 1
            out += floorboss.Keys(i) & "~" & floorboss.Values(i) & "@"       '3 to 2 + floorboss.length
        Next

        out += floorCodes.Count - 1 & "@"   '4 + floorboss.length
        For i = 0 To floorCodes.Count - 1
            out += floorCodes.Keys(i) & "~" & floorCodes.Values(i) & "@"          '5 + floorboss.length to 4 + floorboss.length + floorcodes.count
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

        floorboss.Clear()
        For i = 0 To CInt(buffer(3 + floors.Keys.Count))
            Dim kvp() = buffer(4 + floors.Keys.Count + i).Split("~")
            floorboss.Add(CInt(kvp(0)), kvp(1))
        Next

        floorCodes.Clear()
        For i = 0 To CInt(buffer(4 + floors.Keys.Count + floorboss.Count))
            Dim kvp() = buffer(5 + floors.Keys.Count + floorboss.Count + i).Split("~")
            floorCodes.Add(CInt(kvp(0)), kvp(1))
        Next

        checkForUnloadedFloor()
    End Sub
End Class
