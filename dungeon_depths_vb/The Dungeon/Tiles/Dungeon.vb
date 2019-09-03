Imports System.ComponentModel

<Serializable()> Public Class Dungeon
    Public floorboss() As String = {"Floor0", "Marissa the Enchantress", "Targax the Brutal", "Key", "Key", "Medusa"} 'boss names (NOT SAVED)
    Public floors As Dictionary(Of Integer, mFloor) = New Dictionary(Of Integer, mFloor)
    Public floorCodes As List(Of String) = New List(Of String)

    Public numCurrFloor As Integer = -1
    Public lastVisitedFloor As Integer

    Public Sub New()
        Randomize()

        For i = 0 To 10
            floorCodes.Add(mFloor.genRNDLVLCode)
        Next

        numCurrFloor = 1
        lastVisitedFloor = 1
        floors.Add(1, New mFloor(floorCodes(1), numCurrFloor))
        setFloor(Game.currFloor)
    End Sub
    Public Sub New(save)
        load(save)
    End Sub

    Public Sub floorDown()
        lastVisitedFloor = numCurrFloor
        floors(numCurrFloor).playerPosition = Game.player.pos

        numCurrFloor += 1
        If Not floors.Keys.Contains(numCurrFloor) Then
            If floorCodes.Count > numCurrFloor Then
                floors.Add(numCurrFloor, New mFloor(floorCodes(numCurrFloor), numCurrFloor))
            Else
                floors.Add(numCurrFloor, New mFloor(mFloor.genRNDLVLCode, numCurrFloor))
            End If
        Else
            setPositions()
        End If
    End Sub
    Public Sub floorUp()
        lastVisitedFloor = numCurrFloor
        floors(numCurrFloor).playerPosition = Game.player.pos

        numCurrFloor -= 1
        If numCurrFloor = 0 Then Game.pushLblEvent("As you near the top of the staircase leading out of the dungeon, you take a deep breath.  Unfortuately, you also trip; falling to your doom.", AddressOf Game.player.die)
        setPositions()
    End Sub
    Public Sub jumpTo(ByVal i As Integer)
        lastVisitedFloor = numCurrFloor
        floors(numCurrFloor).playerPosition = Game.player.pos

        numCurrFloor = i
        If Not floors.Keys.Contains(numCurrFloor) Then
            If floorCodes.Count > numCurrFloor Then
                floors.Add(numCurrFloor, New mFloor(floorCodes(numCurrFloor), numCurrFloor))
            Else
                floors.Add(numCurrFloor, New mFloor(mFloor.genRNDLVLCode, numCurrFloor))
            End If
        Else
            setPositions()
        End If
    End Sub
    Private Sub setPositions()
        Game.player.pos = floors(numCurrFloor).playerPosition

        For i = 0 To Game.shopNPCList.Count - 1
            Game.shopNPCList(i).pos = floors(numCurrFloor).npcPositions(i)
        Next
    End Sub
    Public Sub setFloor(ByRef f As mFloor)
        f = floors(numCurrFloor)
        Game.mBoardHeight = f.mBoardHeight
        Game.mBoardWidth = f.mBoardWidth
    End Sub

    Public Function currFloorBoss() As String
        If floorboss.Count > numCurrFloor Then
            Return floorboss(numCurrFloor)
        Else
            Return ""
        End If
    End Function
    Public Function currFloorCode() As String
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

        out += UBound(floorboss) & "@"      '3 + floors.keys.count
        For i = 0 To UBound(floorboss)
            out += floorboss(i) & "@"       '4 + floors.keys.count to 3 + floors.keys.count + floorboss.length
        Next

        out += floorCodes.Count - 1 & "@"   '4 + floors.keys.count + floorboss.length
        For i = 0 To floorCodes.Count - 1
            out += floorCodes(i) & "@"          '5 + floors.keys.count + floorboss.length to 4 + floors.keys.count + floorboss.length + floorcodes.count
        Next

        Return out
    End Function
    Sub load(ByRef s As String)
        Dim buffer = s.Split("@")

        numCurrFloor = CInt(buffer(0))
        lastVisitedFloor = CInt(buffer(1))

        floors.Clear()
        For i = 0 To CInt(buffer(2))
            Dim tFloor = New mFloor(buffer(3 + i))
            floors.Add(tFloor.floorNumber, tFloor)
        Next

        For i = 0 To CInt(buffer(3 + floors.Keys.Count))
            floorboss(i) = buffer(4 + floors.Keys.Count + i)
        Next

        floorCodes.Clear()
        For i = 0 To CInt(buffer(4 + floors.Keys.Count + floorboss.Length))
            floorCodes.Add(buffer(5 + floors.Keys.Count + floorboss.Length + i))
        Next
    End Sub
End Class
