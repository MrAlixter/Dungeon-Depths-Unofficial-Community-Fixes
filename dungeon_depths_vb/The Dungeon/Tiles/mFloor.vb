Imports System.ComponentModel
Public Class mFloor
    Public mBoardWidth As Integer = 60
    Public mBoardHeight As Integer = 60
    Public coveredBoardSpace As Integer = 0

    Public mBoard(,) As mTile
    Dim rooms As List(Of List(Of Room)) = New List(Of List(Of Room))
    Public floorNumber As Integer = 0
    Public floorCode As String
    Public stairs As Point

    Public chestList As List(Of Chest) = New List(Of Chest)
    Public statueList As List(Of Statue) = New List(Of Statue)
    Public trapList As List(Of Trap) = New List(Of Trap)

    Public playerPosition As Point = New Point(-1, -1)
    Public npcPositions As List(Of Point) = New List(Of Point)

    Public bossDialog As Boolean = False
    Public beatBoss As Boolean = False
    Public pinkMist As Boolean = False

    Public sessions As Dictionary(Of Integer, Session) = New Dictionary(Of Integer, Session)

    Public Shared nonRandomFloors() As Integer = {9999, 10000, 91017, 91018, 5, 75, 9, 10, 13}
    Public Shared loopVerticalFloors() As Integer = {13}

    Public Sub New(ByVal code As String, ByVal fNum As Integer,
                   Optional ByVal bh As Integer = -1,
                   Optional ByVal bw As Integer = -1)
        Dim updateLoadbar = False
        updateLoadbar = Not Game.picLoadBar.Visible

        If updateLoadbar Then Game.initLoadBar()
        floorNumber = fNum
        floorCode = code
        If bh = -1 Then mBoardHeight = Game.mBoardHeight Else mBoardHeight = bh
        If bw = -1 Then mBoardWidth = Game.mBoardWidth Else mBoardWidth = bw

        defineBoardSpace()

        If nonRandomFloors.Contains(floorNumber) Then
            Game.updateLoadbar(99)
            Game.boardWorker.CancelAsync()
            Exit Sub
        End If
        If updateLoadbar Then Game.updateLoadbar(40)

        placeStairs()
        placePlayer(Game.player1)

        If Not nonRandomFloors.Contains(floorNumber) Then verifyNoDisconectedChunks(Game.player1)

        placeChest(floorCode)
        If floorNumber > 2 Then placeTraps()

        placeNPCs(Game.shop_npc_list, getPossibleNPCs)
        If updateLoadbar Then Game.updateLoadbar(70)

        If pinkMist Then deployPinkMist()

        If updateLoadbar Then
            Game.updateLoadbar(99)
            Game.boardWorker.CancelAsync()
        End If

        SaveFile.saveFloor(Me)
        'If Not sessions.ContainsKey(Game.sessionID) Then
        '    sessions.Add(Game.sessionID, New Session(Game.sessionID, Game.player1.pos, beatBoss))
        'End If
    End Sub
    Public Sub New(ByVal code As String, Optional readFromFile As Boolean = True)
        If Not readFromFile Then
            loadMFloor(code)
        Else
            readFloorFromFile(code)
        End If
    End Sub
    Public Sub New()
        'Used for the save file
    End Sub

    '|---GENERAL FLOOR GENERATION METHODS---|
    Sub defineBoardSpace()
        'reset the board
        ReDim mBoard(mBoardHeight, mBoardWidth)
        For y = 0 To mBoardHeight
            For x = 0 To mBoardWidth
                mBoard(y, x) = New mTile(0, "", Color.Black)
            Next
        Next
        For Each n In Game.shop_npc_list
            n.pos = New Point(-1, -1)
        Next

        Select Case floorNumber
            Case 5, 91018
                genBossFloor(Game.player1)
            Case 6, 7, 8, 11, 12
                generateForestLevel(floorCode)
            Case 9
                genFloor9()
            Case 10
                genFloor10(floorCode)
            Case 13
                genFloor13()
            Case 9999
                genSpaceFloor()
            Case 10000
                genSpaceFloor2()
            Case 91017
                genLegacyFloor()
            Case Else
                generateDungeonLevel(floorCode)
        End Select

        'Pink Mist
        'If floorNumber > 13 Then
        '    For i = 0 To Int(Rnd() * rooms.Count)
        '        Dim j = Int(Rnd() * rooms(i).Count)

        '        Dim room = rooms(i)(j)

        '        For y = room.top_left_pos.Y To room.top_left_pos.Y + room.height
        '            For x = room.top_left_pos.X To room.top_left_pos.X + room.width
        '                If ptInBounds(New Point(x, y)) Then mBoard(y, x).Tag = DDConst.TILE_MARKED
        '            Next
        '        Next
        '    Next
        '    deployPinkMist()
        'End If

        If Settings.active(setting.isotiles) Then fillIsoWalls()

        If floorNumber = 7 Then placeFloor7Statues()
    End Sub

    '|-Dungeon Floors-|
    Sub fillIsoWalls()
        For y = 0 To mBoardHeight - 1
            For x = 0 To mBoardWidth - 1
                If mBoard(y, x).Tag = DDConst.TILE_WALL And mBoard(y, x).Text.Equals("") Then
                    If ((ptInBounds(New Point(x + 1, y + 1)) And ptInBounds(New Point(x + 1, y)) And ptInBounds(New Point(x, y + 1))) AndAlso (mBoard(y + 1, x + 1).Tag <> 0 And mBoard(y + 1, x).Tag = 0 And mBoard(y, x + 1).Tag = 0)) Then
                        mBoard(y, x).Text = "╔"
                    ElseIf ((ptInBounds(New Point(x - 1, y - 1)) And ptInBounds(New Point(x + 1, y)) And ptInBounds(New Point(x, y - 1)) And ptInBounds(New Point(x + 1, y - 1)) And ptInBounds(New Point(x, y + 1))) AndAlso (mBoard(y, x).Tag = 0 And mBoard(y - 1, x).Tag = 0 And (mBoard(y - 1, x + 1).Tag <> 0 Or mBoard(y, x + 1).Tag <> 0) And mBoard(y + 1, x).Tag <> 0)) Then
                        mBoard(y, x).Text = "╝"
                    ElseIf ((ptInBounds(New Point(x + 1, y + 1)) And ptInBounds(New Point(x + 1, y)) And ptInBounds(New Point(x - 1, y)) And ptInBounds(New Point(x, y + 1))) AndAlso (mBoard(y, x).Tag = 0 And mBoard(y + 1, x + 1).Tag = 0 And mBoard(y + 1, x).Tag <> 0 And (Not ptInBounds(New Point(x + 1, y)) Or mBoard(y, x + 1).Tag = 0) And mBoard(y, x - 1).Tag = 0)) Then
                        mBoard(y, x).Text = "╕"
                    ElseIf ((ptInBounds(New Point(x + 1, y + 1)) And ptInBounds(New Point(x, y + 1)) And ptInBounds(New Point(x, y - 1)) And ptInBounds(New Point(x + 1, y))) AndAlso (mBoard(y, x).Tag = 0 And mBoard(y + 1, x + 1).Tag = 0 And mBoard(y, x + 1).Tag <> 0 And (Not ptInBounds(New Point(x, y + 1)) Or mBoard(y + 1, x).Tag = 0) And mBoard(y - 1, x).Tag = 0)) Then
                        mBoard(y, x).Text = "╙"
                    ElseIf ((ptInBounds(New Point(x + 1, y)) And ptInBounds(New Point(x, y + 1))) AndAlso (mBoard(y, x).Tag = 0 And mBoard(y + 1, x).Tag <> 0)) Then
                        mBoard(y, x).Text = "═"
                    ElseIf ((ptInBounds(New Point(x + 1, y)) And ptInBounds(New Point(x, y + 1))) AndAlso (mBoard(y, x).Tag = 0 And mBoard(y, x + 1).Tag <> 0 And (Not ptInBounds(New Point(x, y + 1)) Or mBoard(y + 1, x).Tag = 0))) Then
                        mBoard(y, x).Text = "║"
                    End If
                End If
            Next
        Next
    End Sub
    Sub generateDungeonLevel(ByVal code As String)
        'generateLevel creates the random rooms and corridors of each level
        floorCode = code
        Rnd(-1)
        Randomize(code.GetHashCode)

        Dim maxBoardSpace As Integer = mBoardWidth * mBoardHeight
        Dim roomRow As List(Of Room) = New List(Of Room)
        Dim cursor As Point = New Point(0, 5)

        '|CREATE THE ROOMS|
        Dim prevProgress As Double = -1
        While (coveredBoardSpace / maxBoardSpace) < 0.75
            'define a new room:  Each iteration get smaller
            For i = 0 To 18
                'define the new room's length
                Dim l = Int(Rnd() * (16 - i)) + 2
                Dim h = Int(Rnd() * (16 - i)) + 2

                'define the new room's x and y positions
                Dim x = cursor.X
                'y +- 10% of the board's height 
                Dim y = cursor.Y - (Int(Rnd() * 10)) + ((Int(Rnd() * 20)))
                If x + l < mBoardWidth And x >= 0 And y + h < mBoardHeight And y >= 0 Then
                    Dim roomToPlace = New Room(New Point(x, y), l, h)
                    roomRow.Add(roomToPlace)
                    For j = 0 To h
                        For k = 0 To l
                            placeTile(k + x, j + y, False)
                        Next
                    Next


                    'move the cursor to the next room
                    Dim newCursorX = x + l + 1 + Int(Rnd() * 20)
                    Dim newCursorY = cursor.Y
                    If newCursorX >= mBoardWidth - 4 Then
                        rooms.Add(roomRow)
                        roomRow = New List(Of Room)
                        newCursorX = 0 + Int(Rnd() * 3)
                        newCursorY = cursor.Y + 20
                    End If


                    cursor = New Point(newCursorX, newCursorY)
                    Exit For
                End If
            Next
            If prevProgress = (coveredBoardSpace / maxBoardSpace) Then Exit While
            prevProgress = (coveredBoardSpace / maxBoardSpace)
        End While

        '|CONNECT THE ROOMS|
        Dim allrooms As List(Of Room) = New List(Of Room)()
        For j = 0 To rooms.Count - 1
            For i = 0 To rooms(j).Count - 1
                'get the room in question
                Dim r = rooms(j)(i)
                allrooms.Add(r)


                Dim potentialNeighbors As List(Of Room) = getPotentialNeigbors(rooms, i, j)
                If potentialNeighbors.Count = 0 Then Continue For

                'set the number of exits on the room
                Dim numExits = Int(Rnd() * potentialNeighbors.Count) + 1
                For num = 1 To numExits
                    connectRooms(r, potentialNeighbors(Int(Rnd() * potentialNeighbors.Count)))
                Next

                r.marked = True
            Next
        Next

        '|VERIFY NO DISCONECTED CHUNKS|
        For i = 0 To allrooms.Count - 1
            For j = i + 1 To allrooms.Count - 1
                If Not allrooms(i).connectedTo(allrooms(j)) Then connectRooms(allrooms(i), allrooms(j), True)
            Next
        Next
    End Sub
    Private Sub placeTile(ByVal x As Integer, ByVal y As Integer, ByVal seen As Boolean, Optional ByVal glow As Boolean = False)
        If Settings.active(setting.isotiles) AndAlso DDConst.ISO_WALL_CHARS.Contains(mBoard(y, x).Text) Then
            mBoard(y, x).Text = ""
        End If

        If mBoard(y, x).Tag <> 2 Then
            mBoard(y, x).Tag = If(seen, 2, 1)

            If glow Then
                mBoard(y, x).Text = "x"
            End If

            coveredBoardSpace += 1
        End If
    End Sub
    Private Sub connectRooms(ByRef r1 As Room, ByRef r2 As Room, Optional overrideFlag As Boolean = False)
        If (r1.connectedTo(r2) Or r2.connectedTo(r1)) And Not overrideFlag Then Exit Sub
        If r1.directConnections > Room.MAX_DIRECT_CONNECTIONS Or r2.directConnections > Room.MAX_DIRECT_CONNECTIONS Then Exit Sub

        r1.directConnections += 1
        r2.directConnections += 1

        connectPoints(r1.getExit, r2.getExit)

        r1.connect(r2)
        r2.connect(r1)
    End Sub
    Sub connectPoints(ByVal p1 As Point, ByVal p2 As Point)
        p1 = New Point(Math.Max(p1.X, 0), Math.Max(p1.Y, 0))
        p2 = New Point(Math.Max(p2.X, 0), Math.Max(p2.Y, 0))
        p1 = New Point(Math.Min(p1.X, mBoardWidth - 1), Math.Min(p1.Y, mBoardHeight - 1))
        p2 = New Point(Math.Min(p2.X, mBoardWidth - 1), Math.Min(p2.Y, mBoardHeight - 1))

        If p1.X.Equals(p2.X) And p1.Y.Equals(p2.Y) Then Exit Sub

        'Connects the entrances/exits of the rooms
        If p1.Y > p2.Y Then
            'p1 is below p2
            If p1.X > p2.X Then
                'p1 is right of p2
                goLeftThenUp(p1, p2)
            Else
                'p1 is left of p2
                goRightThenUp(p1, p2)
            End If
        Else
            'p1 is above p2
            If p1.X > p2.X Then
                'p1 is right of p2
                goLeftThenDown(p1, p2)
            Else
                'p1 is left of p2
                goRightThenDown(p1, p2)
            End If
        End If
    End Sub
    Private Sub goRightThenUp(ByVal p1 As Point, ByVal p2 As Point)
        'go right from p1's X to p2's X
        For x = p1.X + 1 To p2.X
            Dim y = Math.Max(0, p2.Y)
            y = Math.Min(mBoardHeight, p2.Y)

            x = Math.Max(0, x)
            x = Math.Min(mBoardWidth, x)

            If Not mBoard(y, x).Tag = DDConst.TILE_SEEN Then
                placeTile(x, y, False)
            End If
        Next

        'go up from p1's Y to p2's Y
        For y = p1.Y - 1 To p2.Y Step -1
            y = Math.Max(0, y)
            y = Math.Min(mBoardHeight, y)

            Dim x = Math.Max(0, p1.X)
            x = Math.Min(mBoardWidth, p1.X)

            If Not mBoard(y, x).Tag = DDConst.TILE_SEEN Then
                placeTile(x, y, False)
            End If
        Next
    End Sub
    Private Sub goLeftThenUp(ByVal p1 As Point, ByVal p2 As Point)
        'go left from p1's X to p2's X
        For x = p1.X - 1 To p2.X Step -1
            Dim y = Math.Max(0, p2.Y)
            y = Math.Min(mBoardHeight, y)

            x = Math.Max(0, x)
            x = Math.Min(mBoardWidth, x)

            If Not mBoard(y, x).Tag = DDConst.TILE_SEEN Then
                placeTile(x, y, False)
            End If
        Next

        'go up from p1's Y to p2's Y
        For y = p1.Y - 1 To p2.Y Step -1
            y = Math.Max(0, y)
            y = Math.Min(mBoardHeight, y)

            Dim x = Math.Max(0, p1.X)
            x = Math.Min(mBoardWidth, p1.X)

            If Not mBoard(y, x).Tag = DDConst.TILE_SEEN Then
                placeTile(x, y, False)
            End If
        Next
    End Sub
    Private Sub goRightThenDown(ByVal p1 As Point, ByVal p2 As Point)
        'go right from p1's X to p2's X
        For x = p1.X + 1 To p2.X
            Dim y = Math.Max(0, p2.Y)
            y = Math.Min(mBoardHeight, y)

            x = Math.Max(0, x)
            x = Math.Min(mBoardWidth, x)

            If Not mBoard(y, x).Tag = DDConst.TILE_SEEN Then
                placeTile(x, y, False)
            End If
        Next

        'go up from p1's Y to p2's Y
        For y = p1.Y + 1 To p2.Y
            y = Math.Max(0, y)
            y = Math.Min(mBoardHeight, y)

            Dim x = Math.Max(0, p1.X)
            x = Math.Min(mBoardWidth, p1.X)

            If Not mBoard(y, x).Tag = DDConst.TILE_SEEN Then
                placeTile(x, y, False)
            End If
        Next
    End Sub
    Private Sub goLeftThenDown(ByVal p1 As Point, ByVal p2 As Point)
        'go left from p1's X to p2's X
        For x = p1.X - 1 To p2.X Step -1
            Dim y = Math.Max(0, p2.Y)
            y = Math.Min(mBoardHeight, y)

            x = Math.Max(0, x)
            x = Math.Min(mBoardWidth, x)

            If Not mBoard(y, x).Tag = DDConst.TILE_SEEN Then
                placeTile(x, y, False)
            End If
        Next

        'go down from p1's Y to p2's Y
        For y = p1.Y + 1 To p2.Y
            y = Math.Max(0, y)
            y = Math.Min(mBoardHeight, y)

            Dim x = Math.Max(0, p1.X)
            x = Math.Min(mBoardWidth, p1.X)

            If Not mBoard(y, x).Tag = DDConst.TILE_SEEN Then
                placeTile(x, y, False)
            End If
        Next
    End Sub
    Private Shared Function getPotentialNeigbors(ByRef allRooms As List(Of List(Of Room)), ByVal x As Integer, ByVal y As Integer) As List(Of Room)
        Dim results As List(Of Room) = New List(Of Room)

        If x > 0 Then results.Add(allRooms(y)(x - 1))
        If x < allRooms(y).Count - 1 Then results.Add(allRooms(y)(x + 1))
        If y > 0 AndAlso x < allRooms(y - 1).Count - 1 Then results.Add(allRooms(y - 1)(x))
        If y < allRooms.Count - 1 AndAlso x < allRooms(y + 1).Count - 1 Then results.Add(allRooms(y + 1)(x))

        Return results
    End Function
    'floor 4
    Function ptInBounds(ByVal pt As Point) As Boolean
        Return pt.X >= 0 And pt.X <= mBoardWidth And pt.Y >= 0 And pt.Y <= mBoardHeight
    End Function
    Sub placeFloor4TrappedChest(ByRef p As Player)
        Dim c As Chest = New LoadedChest(getRndAdjPoint(p), 4)
        chestList.Add(c)
        mBoard(c.pos.Y, c.pos.X).ForeColor = Color.FromArgb(45, 45, 45)
        mBoard(c.pos.Y, c.pos.X).Text = "#"
    End Sub
    Public Function getRndAdjPoint(ByVal p As Player) As Point
        Dim possiblePoints = {New Point(p.pos.X + 1, p.pos.Y), _
                                  New Point(p.pos.X - 1, p.pos.Y), _
                                  New Point(p.pos.X, p.pos.Y + 1), _
                                  New Point(p.pos.X, p.pos.Y - 1), _
                                  New Point(p.pos.X + 1, p.pos.Y + 1), _
                                  New Point(p.pos.X - 1, p.pos.Y - 1), _
                                  New Point(p.pos.X + 1, p.pos.Y - 1), _
                                  New Point(p.pos.X - 1, p.pos.Y + 1)}
        Dim pt As Point = possiblePoints(0)
        Dim i = 0
        Do While (Not ptInBounds(pt) OrElse mBoard(pt.Y, pt.X).Tag < 1 Or mBoard(pt.Y, pt.X).Text <> "") And i < possiblePoints.Count - 1
            i += 1
            pt = possiblePoints(i)
        Loop

        Return pt
    End Function

    '|-Forest Floors-|
    Sub generateForestLevel(ByVal code As String)
        'generateLevel creates the random rooms and corridors of each level
        floorCode = code
        Rnd(-1)
        Randomize(code.GetHashCode)
        'Dump into area And agregate Map generator'
        Dim numRooms As Integer = CInt(Int((Rnd() * 5) + 25)) 'Create a random number of rooms
        Dim radius As Integer = CInt(20) ' Set the randius to the average of the board hight & width
        Dim RoomXY As List(Of Point) = New List(Of Point)
        Dim RoomWH As List(Of Point) = New List(Of Point)

        For i = 0 To numRooms
            Dim t = 2 * Math.PI * Rnd() 'a point around a circle
            Dim u = Rnd() + Rnd() 'a points radius
            Dim rad As Double = 0
            If u > 1 Then 'make sure that it isn't 0
                rad = 2 - u
            End If
            If u < 1 Then
                rad = u
            End If
            Dim pos As Point = New Point(Int(radius * rad * Math.Cos(t)), Int(radius * rad * Math.Sin(t))) 'Place the point multiplied by given radius
            RoomXY.Add(pos)
            'look into generating a poison distribution
            'Create a random width and lenth for each room
            Dim dime As Point = New Point(Int((Rnd() * 5) + 3), CInt((Rnd() * 5) + 3))
            RoomWH.Add(dime)
        Next

        'Run through all the rooms and check if they overlap
        For i = 0 To numRooms - 1
            Dim aPos As Point = RoomXY(i)
            Dim aDime As Point = RoomWH(i)
            For j = 0 To numRooms - 1
                Dim bPos As Point = RoomXY(j)
                Dim bDime As Point = RoomWH(j)
                If Not (aPos = bPos) And Not (aDime = bDime) Then


                    'Check for overlapping
                    Dim H_Overlaps As Boolean = (aPos.X <= bPos.X + bDime.X) AndAlso (bPos.X <= aPos.X + aDime.X)
                    Dim V_Overlaps As Boolean = (aPos.Y <= bPos.Y + bDime.Y) AndAlso (bPos.Y <= aPos.Y + aDime.Y)
                    If H_Overlaps AndAlso V_Overlaps Then
                        'Find the minimum amount of movment that stops the squares from touching
                        Dim dx = Math.Min(Math.Abs((aPos.X + aDime.X) - (bPos.X + 3)), Math.Abs(aPos.X - (bPos.X + bDime.X + 3)))
                        Dim dy = Math.Min(Math.Abs((aPos.Y + aDime.Y) - (bPos.Y + 3)), Math.Abs(aPos.Y - (bPos.Y + bDime.Y + 3)))
                        If dx <= dy Then
                            dy = 0
                        Else
                            dx = 0
                        End If
                        If aPos.X >= bPos.X Then
                            RoomXY(i) = New Point(RoomXY(i).X + Int(dx / 2), RoomXY(i).Y)
                            RoomXY(j) = New Point(RoomXY(j).X - Int(dx / 2), RoomXY(j).Y)
                        Else
                            RoomXY(i) = New Point(RoomXY(i).X - Int(dx / 2), RoomXY(i).Y)
                            RoomXY(j) = New Point(RoomXY(j).X + Int(dx / 2), RoomXY(j).Y)
                        End If
                        If aPos.Y >= bPos.Y Then
                            RoomXY(i) = New Point(RoomXY(i).X, RoomXY(i).Y + Int(dy / 2))
                            RoomXY(j) = New Point(RoomXY(j).X, RoomXY(j).Y - (dy / 2))
                        Else
                            RoomXY(i) = New Point(RoomXY(i).X, RoomXY(i).Y - Int(dy / 2))
                            RoomXY(j) = New Point(RoomXY(j).X, RoomXY(j).Y + Int(dy / 2))
                        End If


                    End If
                End If

            Next

        Next

        Dim exits As List(Of Point) = New List(Of Point)
        For i = 0 To numRooms - 1

            Dim RoomPos As Point = New Point(CInt(RoomXY(i).X + (mBoardWidth / 2)), CInt(Int(RoomXY(i).Y + (mBoardWidth / 2))))
            Dim RoomSpanY As Integer = RoomPos.Y + CInt(RoomWH(i).Y)
            Dim RoomSpanX As Integer = RoomPos.X + CInt(RoomWH(i).X)
            If RoomSpanY >= mBoardHeight - 1 Then RoomSpanY = mBoardHeight - 1
            If RoomSpanY < 0 Then RoomSpanY = 0
            If RoomSpanX >= mBoardWidth Then RoomSpanX = mBoardWidth - 1
            If RoomSpanX < 0 Then RoomSpanX = 0
            'Randomly place a special tag
            If Int(Rnd() * 3) = 0 Then
                For yP = RoomPos.Y To RoomSpanY
                    For xP = RoomPos.X To RoomSpanX
                        If xP < mBoardWidth And yP < mBoardHeight And xP > 0 And yP > 0 Then mBoard(yP, xP).Tag = DDConst.TILE_SEEN 'Colour in the square
                    Next
                Next
                'else just colour it
            Else
                For yP = RoomPos.Y To RoomSpanY
                    For xp = RoomPos.X To RoomSpanX
                        If xp < mBoardWidth And yP < mBoardHeight And xp > 0 And yP > 0 Then mBoard(yP, xp).Tag = DDConst.TILE_UNSEEN 'Colour in the square
                    Next
                Next
            End If

            Dim numExits As Integer = Int(Rnd() * 3)
            Dim mainExit As Point
            Select Case Int(Rnd() * 2)
                Case 0
                    mainExit = (New Point(RoomPos.X + 2, Int(Rnd() * (RoomSpanY - RoomPos.Y)) + RoomPos.Y))
                    If mainExit.X - 1 < mBoardWidth And mainExit.X - 1 > 0 And mainExit.Y - 1 < mBoardHeight And mainExit.Y - 1 > 0 AndAlso Not mBoard(mainExit.Y, mainExit.X - 1).Tag = DDConst.TILE_SEEN Then mBoard(mainExit.Y, mainExit.X - 1).Tag = DDConst.TILE_UNSEEN
                Case Else
                    mainExit = (New Point(Int(Rnd() * (RoomSpanX - RoomPos.X)) + RoomPos.X, RoomPos.Y + 2))
                    If mainExit.X - 1 < mBoardWidth And mainExit.X - 1 > 0 And mainExit.Y - 1 < mBoardHeight And mainExit.Y - 1 > 0 AndAlso Not mBoard(mainExit.Y - 1, mainExit.X).Tag = DDConst.TILE_SEEN Then mBoard(mainExit.Y - 1, mainExit.X).Tag = DDConst.TILE_UNSEEN
            End Select
            If i > 0 Then
                connectPoints(mainExit, exits(exits.Count - 1))
            Else
                exits.Add(mainExit)
            End If
            For n = 1 To numExits
                Select Case Int(Rnd() * 2)
                    Case 0
                        exits.Add(New Point(RoomPos.X + 2, Int(Rnd() * (RoomSpanY - RoomPos.Y)) + RoomPos.Y))
                        If exits.Last.X - 1 < mBoardWidth And exits.Last.X - 1 > 0 And exits.Last.Y - 1 < mBoardHeight And exits.Last.Y - 1 > 0 And
                            exits.Last.X < mBoardWidth And exits.Last.X > 0 And exits.Last.Y < mBoardHeight And exits.Last.Y > 0 AndAlso Not mBoard(exits.Last.Y, exits.Last.X - 1).Tag = DDConst.TILE_SEEN Then mBoard(exits.Last.Y, exits.Last.X - 1).Tag = DDConst.TILE_UNSEEN
                    Case 1
                        exits.Add(New Point(Int(Rnd() * (RoomSpanX - RoomPos.X)) + RoomPos.X, RoomPos.Y + 2))
                        If exits.Last.X - 1 < mBoardWidth And exits.Last.X - 1 > 0 And exits.Last.Y - 1 < mBoardHeight And exits.Last.Y - 1 > 0 And
                            exits.Last.X < mBoardWidth And exits.Last.X > 0 And exits.Last.Y < mBoardHeight And exits.Last.Y > 0 AndAlso Not mBoard(exits.Last.Y - 1, exits.Last.X).Tag = DDConst.TILE_SEEN Then mBoard(exits.Last.Y - 1, exits.Last.X).Tag = DDConst.TILE_UNSEEN
                End Select
            Next
        Next
        While exits.Count > 1
            Dim r1 As Integer = Int(Rnd() * exits.Count)
            Dim r2 As Integer = Int(Rnd() * exits.Count)
            Dim r3 As Integer = Int(Rnd() * 3)

            ' MsgBox("R1: " & r1 & " R2: " & r2 & " R3: " & r3 & " E count: " & exits.Count)

            If r1 > r2 Or r3 > 0 Then
                makeDeadEnd(exits(r1), exits)
                exits.RemoveAt(r1)
            Else
                If r1 <> r2 Then
                    connectPoints(exits(r1), exits(r2))
                    Dim exit1 As Point = exits(r1)
                    Dim exit2 As Point = exits(r2)
                    If exits.Contains(exit1) Then exits.Remove(exit1)
                    If exits.Contains(exit2) Then exits.Remove(exit2)
                End If
            End If
        End While

        Dim tileCount As Integer = 0
        For yInd As Integer = 0 To mBoardHeight - 1
            For xInd As Integer = 0 To mBoardWidth - 1
                If mBoard(yInd, xInd).Tag > 0 AndAlso mBoard(yInd, xInd).Text = "" Then
                    tileCount += 1
                End If
            Next
        Next

        If tileCount < 4 Then
            Dim timesDug As Integer = 0
            Do While tileCount < 4 'To handle if it needs to keep "digging", in case it couldn't make it big enough with just one iteration
                timesDug += 1
                If timesDug > 5 Then 'If a map was created without any walkable space, get it started
                    Dim tilesBefore As Integer = tileCount
                    For yInd As Integer = 0 To mBoardHeight - 1
                        For xInd As Integer = 0 To mBoardWidth - 1
                            If mBoard(yInd, xInd).Tag = 0 Then
                                mBoard(yInd, xInd).Tag = DDConst.TILE_UNSEEN
                                timesDug = 0
                                tileCount += 1
                                Exit For
                            End If
                        Next
                        If tilesBefore < tileCount Then
                            Exit For
                        End If
                    Next
                    timesDug = 0
                End If
                For yInd As Integer = 0 AndAlso tileCount < 4 To mBoardHeight - 1
                    For xInd As Integer = 0 AndAlso tileCount < 4 To mBoardWidth - 1
                        If mBoard(yInd, xInd).Tag > 0 AndAlso mBoard(yInd, xInd).Text = "" Then
                            If yInd - 1 >= 0 AndAlso mBoard(yInd - 1, xInd).Tag = 0 Then
                                mBoard(yInd - 1, xInd).Tag = DDConst.TILE_UNSEEN
                                tileCount += 1
                            ElseIf yInd + 1 < mBoardHeight AndAlso mBoard(yInd + 1, xInd).Tag = 0 Then
                                mBoard(yInd + 1, xInd).Tag = DDConst.TILE_UNSEEN
                                tileCount += 1
                            ElseIf xInd - 1 >= 0 AndAlso mBoard(yInd, xInd - 1).Tag = 0 Then
                                mBoard(yInd, xInd - 1).Tag = DDConst.TILE_UNSEEN
                                tileCount += 1
                            ElseIf xInd + 1 < mBoardWidth AndAlso mBoard(yInd, xInd + 1).Tag = 0 Then
                                mBoard(yInd, xInd + 1).Tag = DDConst.TILE_UNSEEN
                                tileCount += 1
                            End If
                        End If
                    Next
                Next
            Loop
        End If
    End Sub
    Sub makeDeadEnd(ByVal p1 As Point, ByRef exits As List(Of Point))
        'Creates a path from a room to a dead end
        Dim xOry As Boolean = CBool(Int(Rnd() * 2))
        Dim dir As Boolean = CBool(Int(Rnd() * 2))
        For i = 0 To 6
            If xOry Then
                Dim y As Integer
                If dir Then
                    For y = p1.Y To Int(Rnd() * 8)
                        If y < mBoardHeight And y > 0 And p1.X < mBoardWidth And p1.X > 0 AndAlso Not mBoard(y, p1.X).Tag = DDConst.TILE_SEEN Then mBoard(y, p1.X).Tag = DDConst.TILE_UNSEEN
                    Next
                Else
                    For y = p1.Y To Int(Rnd() * 8) Step -1
                        If y < mBoardHeight And y > 0 And p1.X < mBoardWidth And p1.X > 0 AndAlso Not mBoard(y, p1.X).Tag = DDConst.TILE_SEEN Then mBoard(y, p1.X).Tag = DDConst.TILE_UNSEEN
                    Next
                End If
                p1 = New Point(p1.X, y)
            Else
                Dim x As Integer
                If dir Then
                    For x = p1.X To Int(Rnd() * 8)
                        If x < mBoardWidth And x > 0 And p1.Y < mBoardHeight And p1.Y > 0 AndAlso Not mBoard(p1.Y, x).Tag = DDConst.TILE_SEEN Then mBoard(p1.Y, x).Tag = DDConst.TILE_UNSEEN
                    Next
                Else
                    For x = p1.X To Int(Rnd() * 8) Step -1
                        If x < mBoardWidth And x > 0 And p1.Y < mBoardHeight And p1.Y > 0 AndAlso Not mBoard(p1.Y, x).Tag = DDConst.TILE_SEEN Then mBoard(p1.Y, x).Tag = DDConst.TILE_UNSEEN
                    Next
                End If
                p1 = New Point(x, p1.Y)
            End If
            Dim cont As Integer = (Int(Rnd() * 35))
            If cont = 11 Or cont = 27 Then exits.Add(p1)
            If cont < 8 Then Exit For
        Next
    End Sub
    'floor 7
    Sub placeFloor7Statues()
        For i = 1 To 6
            statueList.Add(New Statue(randPoint(), "Fox", "You see here a statue of a fox"))
        Next

        statueList.Add(New Statue(randPoint(), "seventailsstatue", "You see here a golden statue of a fox"))
    End Sub
    'floor 8
    Sub genFloor8()
        Dim floorLayout As String() = {"##############################_____________________________________",
                                       "#____________________________#_###_______________________________#_",
                                       "#_##############_#############_#@#############################___#_",
                                       "#_#____________#_#___________#_###_#_________________________#####_",
                                       "#_#___####_____#_###_###_###_#_____#___________#############_#_#_#_",
                                       "#_#___########_#_#_#_#_#####_#################_#___________#_#_#_#_",
                                       "#_#___####___#_#_#_#_#___###_________________#_#_#########_#_#_#_#_",
                                       "#_#__________#_#_#_#_#_____#########_#######_#_#_#__######_#_#_#_#_",
                                       "#_############_#_#_###__________#__#_#_____#_#_#_#_________#_#_#_#_",
                                       "#______________#_#______#######_##_#_#_###_#_#_#_#__#####__#_#_#_#_",
                                       "################_######_#_____#_#__#_#_###_#_#_#_#__#_#_#_##_#_#_#_",
                                       "_________________#____#_#_###_#_##_#_#_###_#_#_#_####_#___#__#_#_#_",
                                       "_#################_##_#_#___#_#____#_#__#__#_#_#____#_#_####_#_#_#_",
                                       "_#_____#____________#_#_#####_######_####__#_#_######___####_#___#_",
                                       "_______#____________#_#____________#_______#_#________######_###_#_",
                                       "____#################_#################################_####_#_#_#_",
                                       "____#________________________________________________________#_#_#_",
                                       "_#__#_########################################################_#_#_",
                                       "_#__#_#________________________________________________________#_#_",
                                       "_####_#_#######_###############__####__####__####__#############_#_",
                                       "____#_#_#_______#_______##_#########################_____________#_",
                                       "_####_#_#__####_#_#####_##_####__####__####__####__#############_#_",
                                       "_#__#_#_#_###_#_#_#___#__________________________________________#_",
                                       "_#__#_#_#_###_#_#_#_#_#_##########################################_",
                                       "_####_#_#_###_#_#_###_#_#_____________________________________#____",
                                       "_####_#_#_____#_#_____#_#_#########_###########################____",
                                       "_####_#_#_#####_###_###_#_#_______#___________________________#____",
                                       "__##__#_###_______#_#___#_#_#####_#_#########################_#____",
                                       "__##__#_#_#######_#_#_#_#_#_#___#___#_______________________#_###__",
                                       "______#_#_________#_#_#_#_#_#_#####_#_#_###################_#___#__",
                                       "______#_###########_#_###_#_#_#####_#_#_#_________________#_#_####_",
                                       "______#_____________#_____#_#_##%##_#_#_#_#################_#_####_",
                                       "______#_#_#########_#_#####_#_#####_#_#_#_#_______#_________#_####_",
                                       "______#_#_#___#_#_#_#_#_____#_#####_#_#_#_#_#####_#_#####_#_#_####_",
                                       "#####_#_###_#___#_#_#_#_###_#_______#_#_#_#___#_#_#_###_#_#_#______",
                                       "#___#_#_#_#_#_#___#_#_#_#_#_#########_#_#_#####_#_#_____#_###______",
                                       "#_#_#_#_#_#_#_#_#___#_#_#_#___________#_#_______#_#######_#_#______",
                                       "#_#_#_#_#_###_#_###_#_#_#_#############_#_#####_#_________#_#______",
                                       "#_#_#_#_____###_#_#_#_#_#_______________#_____#_###########_#______",
                                       "#_#_#_###_____#_#_#_#_#_#################_____#_____________#______",
                                       "#_#_#_#_#####_###_#_#_#___#___________________#############_#______",
                                       "#_#_###_____#_____#_###___#####___________________________#_#______",
                                       "__#_#_#_###_#######_______#___#_#########################_#_###____",
                                       "###_#_#___#_______________#_#_#_#___________________________#_#_#__",
                                       "#___#_###_#_###_#########_#_#___#_###########################_#_#__",
                                       "#####_#___#_#_#_#_______#_#_#_###_#___________________________#_#__",
                                       "______#_###_#_#_#_###___#_#_#_#_#_#_###############_####______#_#__",
                                       "______#_#___#_#_#_#####_#_#_#_#_#_#_#_____________#____########_#__",
                                       "______#_#_#_#_#_#_###_#_#_#_#_#_#_#_#_###########_######________#__",
                                       "______#_#_#_#_#_#_____#_#_____#_#_#_#_#_________#________########__",
                                       "______#_#####_#_#######_#_#####_#_#_#_#_#######_#_###########___#__",
                                       "______#_______#_________#_#_____#_#___#_______#_#_#______########__",
                                       "______#_______###########_#######_###_#########_#_#________________",
                                       "_####_#___________________________#_#___________#_#________________",
                                       "_####_#############################_#############_#__#_#_#_#_#_#___",
                                       "_####___#____#____________________________________#__#_#_###_#_#___",
                                       "_########____######################################___#__#_#_###___",
                                       "___________________________________________________________________"}

        If mBoardHeight < 50 Then mBoardHeight = 50
        If mBoardWidth < 69 Then mBoardWidth = 69

        ReDim mBoard(mBoardHeight, mBoardWidth)
        For y = 0 To mBoardHeight
            For x = 0 To mBoardWidth
                mBoard(y, x) = New mTile(0, "", Color.Black)
            Next
        Next

        For y = 0 To UBound(floorLayout)
            Dim line = floorLayout(y).ToCharArray
            For x = 0 To UBound(line)
                If Not line(x) = "_"c Then mBoard(y, x).Tag = DDConst.TILE_SEEN
                If line(x) = "%"c Then
                    stairs = New Point(x, y)
                ElseIf line(x) = "@"c Then
                    Game.player1.pos = New Point(x, y)
                End If
            Next
        Next

        placeChest(floorCode)
        placeTraps()
    End Sub
    'floor 9
    Sub genFloor9()
        Dim floorLayout As String() = {"___________________________________##✢*##___________",
                                       "___________#####___________________#✢*✢*#___________",
                                       "__________#######_______#__________*%⇨⇦#✢___________",
                                       "__________################_________##><##___________",
                                       "__________#######_______#__________##>⇦✢*___________",
                                       "__________#######__________________##⇨<*#___________",
                                       "__________#######__________________##><##___________",
                                       "___________#####___________________#✢>⇦*#___________",
                                       "_____________#_____________________#*><##___________",
                                       "_____________#_____________________##⇨<##___________",
                                       "_____________#_______##____________##><##___________",
                                       "_____________#_____#####___________#*⇨<#✢___________",
                                       "_____________###########___________##>⇦##___________",
                                       "___________________#####___________##><*#___________",
                                       "____________________###____________##⇨⇦##___________",
                                       "_____________________#_____________#*⇨<##___________",
                                       "____#####____________#_____________##>⇦##___________",
                                       "____#####_____###____#_____________✢#⇨<##___________",
                                       "____#####____########################><##___________",
                                       "____#####___###__##_______________###>⇦#*___________",
                                       "_######_____##____###########_____###\/##___________",
                                       "_######____###______#_______###########✢#___________",
                                       "_#############______##_____________######___________",
                                       "_##@#########______###______________________________",
                                       "_######____________###______________________________",
                                       "____________________________________________________",
                                       "____________________________________________________"}
        If mBoardHeight < 27 Then mBoardHeight = 27
        If mBoardWidth < 53 Then mBoardWidth = 53

        ReDim mBoard(mBoardHeight, mBoardWidth)
        For y = 0 To mBoardHeight
            For x = 0 To mBoardWidth
                mBoard(y, x) = New mTile(0, "", Color.Black)
            Next
        Next

        For y = 0 To 26
            Dim line = floorLayout(y).ToCharArray
            For x = 0 To UBound(line)
                If Not line(x) = "_"c Then mBoard(y, x).Tag = DDConst.TILE_SEEN
                If line(x) = "%"c Then
                    stairs = New Point(x, y)
                ElseIf line(x) = "@"c Then
                    Game.player1.pos = New Point(x, y)
                ElseIf line(x) = "✢"c Then
                    mBoard(y, x).Text = "✢"
                ElseIf line(x) = "*"c Then
                    mBoard(y, x).Text = "*"
                ElseIf line(x) = "⇨"c Then
                    mBoard(y, x).Text = "⇨"
                    mBoard(y, x).Tag = DDConst.TILE_WALL
                ElseIf line(x) = "⇦"c Then
                    mBoard(y, x).Text = "⇦"
                    mBoard(y, x).Tag = DDConst.TILE_WALL
                ElseIf line(x) = ">"c Then
                    mBoard(y, x).Text = ">"
                    mBoard(y, x).Tag = DDConst.TILE_WALL
                ElseIf line(x) = "<"c Then
                    mBoard(y, x).Text = "<"
                    mBoard(y, x).Tag = DDConst.TILE_WALL
                ElseIf line(x) = "\"c Then
                    mBoard(y, x).Text = "\"
                    mBoard(y, x).Tag = DDConst.TILE_WALL
                ElseIf line(x) = "/"c Then
                    mBoard(y, x).Text = "/"
                    mBoard(y, x).Tag = DDConst.TILE_WALL
                End If
            Next
        Next

        placeChest(floorCode, Int(Rnd() * 3) + 4)
        placeTraps()
    End Sub
    'floor 10
    Sub genFloor10(ByVal floorCode As String)
        'Generate base level
        generateRadialFloor(floorCode)
        Dim center_x As Integer = Math.Floor(mBoardWidth / 2)
        Dim center_y As Integer = Math.Floor(mBoardHeight / 2)
        Dim banned_tiles = {New Point(center_x - 1, center_y - 1), New Point(center_x, center_y - 1), New Point(center_x + 1, center_y - 1),
                         New Point(center_x - 1, center_y), New Point(center_x, center_y), New Point(center_x + 1, center_y),
                         New Point(center_x - 1, center_y + 1), New Point(center_x, center_y + 1), New Point(center_x + 1, center_y + 1)}

        'Spawn in player and safe area
        Dim failsafe As Integer = 0
        Do While (banned_tiles.Contains(Game.player1.pos) Or Game.player1.pos.X < 2 Or Game.player1.pos.Y < 2) And failsafe < 30
            Game.player1.pos = randPoint()
            failsafe += 1
        Loop
        Dim gen_tiles = {New Point(Game.player1.pos.X - 1, Game.player1.pos.Y - 1), New Point(Game.player1.pos.X, Game.player1.pos.Y - 1),
                         New Point(Game.player1.pos.X - 1, Game.player1.pos.Y), New Point(Game.player1.pos.X, Game.player1.pos.Y)}

        'Spawn in stairs/chests/traps
        stairs = randPoint()
        failsafe = 0
        Do While route(Game.player1.pos, stairs).Length < 10 And failsafe < 30
            stairs = randPoint()
            failsafe += 1
        Loop

        placeChest(floorCode)
        If floorNumber > 2 Then placeTraps()

        'Spawn in NPCs
        placeNPCs(Game.shop_npc_list, getPossibleNPCs)

        For Each npc In getPossibleNPCs()
            Dim break = 0
            While gen_tiles.Contains(Game.shop_npc_list(npc).pos)
                Game.shop_npc_list(npc).pos = randPoint()
                break += 1
                If break > 10 Then Game.shop_npc_list(npc).pos = New Point(-1, -1)
            End While
        Next

        If Not Game.hteach.isDead Then
            Game.hteach.pos = New Point(Game.player1.pos.X - 1, Game.player1.pos.Y - 1)
        End If

        mBoard(center_y, center_x).Text = "⬤"

        verifyNoDisconectedChunks(Game.player1)

        'Set up the mist
        For Each t In gen_tiles
            mBoard(t.Y, t.X).Tag = DDConst.TILE_MARKED
        Next

        deployPinkMist()
    End Sub
    Sub deployPinkMist()
        For y = 0 To mBoardHeight - 1
            For x = 0 To mBoardWidth - 1
                If mBoard(y, x).Tag = DDConst.TILE_MARKED Then
                    mBoard(y, x).Tag = DDConst.TILE_SEEN
                ElseIf mBoard(y, x).Tag > 0 Then
                    mBoard(y, x).Tag += DDConst.PINK_MIST_OFFSET
                End If
            Next
        Next

        pinkMist = True
    End Sub
    Sub cleanupPinkMist()
        For y = 0 To mBoardHeight - 1
            For x = 0 To mBoardWidth - 1
                If mBoard(y, x).Tag >= DDConst.PINK_MIST_OFFSET Then
                    mBoard(y, x).Tag -= DDConst.PINK_MIST_OFFSET
                End If
            Next
        Next
    End Sub
    'floor 13
    Sub genFloor13()
        Dim floorLayout As String() = {"________________################################________________",
                                       "_________________##############################_________________",
                                       "_________________#####################_########_________________",
                                       "__________________#######___#########___######__________________",
                                       "__________________#########__#########_#######__________________",
                                       "__________________##########_#################__________________",
                                       "_________________##############################_________________",
                                       "_________________##############################_________________",
                                       "________________###__###########################________________",
                                       "______________####++__##########################________________",
                                       "____________###_###__###########################________________",
                                       "____________#____##############################_________________",
                                       "___________##____###########_###########_######_____+++_________",
                                       "___________#______#########___#########__#####_____+++++________",
                                       "___________#______#########___#########++#####+++++++%++________",
                                       "___________##_____##########_##########__#####_____+++++________",
                                       "____________#____######################_#######_____+++_________",
                                       "____________##___##############################_________________",
                                       "_____________###################################________________",
                                       "________________################################________________",
                                       "________________##################################______________",
                                       "_________________#########_####################__#______________",
                                       "_________________########___###################__##_____________",
                                       "__________________#######++_##################____##____________",
                                       "__________________#######___##################_____##___________",
                                       "__________________#######___##################______#___________",
                                       "_________________#########_####################_____#___________",
                                       "______+___+______##############################____##___________",
                                       "_______+_+______################################__##____________",
                                       "_____++H++++++++###################################_____________",
                                       "_______+_+______################################________________",
                                       "______+_+_+______##############################_________________",
                                       "_________________###############_+_############_________________",
                                       "__________________#############__+__##########__________________",
                                       "__________________#############__+__##########__________________",
                                       "__________________#############_____##########__________________",
                                       "_________________###############___############_________________",
                                       "_________________##############################_________________",
                                       "________________################################________________",
                                       "______________##################################________________",
                                       "____________###_################################________________",
                                       "____________#____#######################_######_________________",
                                       "___________##____#########_############___#####_________________",
                                       "___________#______########__############_#####__________________",
                                       "___________#______########__##################__________________",
                                       "___________##_____########__##################__________________",
                                       "____________#____##########_###################_________________",
                                       "____________##___##############################_________________",
                                       "_____________###################################________________",
                                       "________________##########################__####________________",
                                       "________________##########################___#####______________",
                                       "_________________##########################__##__#______________",
                                       "_________________##############################__##_____________",
                                       "__________________#####################_######____##____________",
                                       "__________________############_#######___#####_____##______+++__",
                                       "__________________###########___######___#####______#+++++++++__",
                                       "_________________#############_#######___######_____#______+++__",
                                       "_________________#####################___######____##___________",
                                       "________________#######################_########__##____________",
                                       "________________###################################_____________",
                                       "________________################################________________",
                                       "_________________##############################_________________",
                                       "_________________######_#######################_________________",
                                       "__________________####___#####################__________________",
                                       "__________________#####_######################__________________",
                                       "__________________##################__########__________________",
                                       "_________________##################____########_________________",
                                       "_________________###################__#########_________________",
                                       "________________################################________________",
                                       "________________################################________________"}

        If mBoardHeight < 69 Then mBoardHeight = 69
        If mBoardWidth < 65 Then mBoardWidth = 65

        ReDim mBoard(mBoardHeight, mBoardWidth)
        For y = 0 To mBoardHeight
            For x = 0 To mBoardWidth
                mBoard(y, x) = New mTile(0, "", Color.Black)
            Next
        Next

        For y = 0 To UBound(floorLayout)
            Dim line = floorLayout(y).ToCharArray
            For x = 0 To UBound(line)
                If line(x) = "#"c Then
                    mBoard(y, x).Tag = DDConst.TILE_SEEN
                ElseIf line(x) = "%"c Then
                    stairs = New Point(x, y)
                End If
            Next
        Next

        coveredBoardSpace = 2050
        Game.player1.pos = randPoint()
        placeChest(floorCode)
        If floorNumber > 2 Then placeTraps()

        placeNPCs(Game.shop_npc_list, getPossibleNPCs)
    End Sub

    '|-Radial Floors-|
    Sub generateRadialFloor(ByVal code As String, Optional ByVal diameter As Integer = 25)
        'generateLevel creates the random rooms and corridors of each level
        floorCode = code
        Rnd(-1)
        Randomize(code.GetHashCode)

        If mBoardHeight < diameter Then mBoardHeight = diameter
        If mBoardWidth < diameter Then mBoardWidth = diameter
        ReDim mBoard(mBoardHeight, mBoardWidth)
        For y = 0 To mBoardHeight
            For x = 0 To mBoardWidth
                mBoard(y, x) = New mTile(0, "", Color.Black)
            Next
        Next

        Dim maxBoardSpace As Integer = mBoardWidth * mBoardHeight
        Dim roomRow As List(Of Room) = New List(Of Room)
        Dim cursor As Point = New Point(0, 5)

        '|CREATE THE CENTER ROOM|
        Dim clearingLayout As String() = {"_______________________",
                                          "_______#########_______",
                                          "_____#############_____",
                                          "____###############____",
                                          "___#################___",
                                          "__###################__",
                                          "__###################__",
                                          "_#####################_",
                                          "_#####################_",
                                          "_#####################_",
                                          "_#####################_",
                                          "_#####################_",
                                          "_#####################_",
                                          "_#####################_",
                                          "_#####################_",
                                          "_#####################_",
                                          "__###################__",
                                          "__###################__",
                                          "___#################___",
                                          "____###############____",
                                          "_____#############_____",
                                          "_______#########_______",
                                          "_______________________"}

        For y = 0 To UBound(clearingLayout)
            Dim line = clearingLayout(y).ToCharArray
            For x = 0 To UBound(line)
                If line(x) = "#"c Then placeTile(x + (Math.Floor(mBoardWidth / 2) - 11), y + (Math.Floor(mBoardHeight / 2) - 11), True)
            Next
        Next

        Dim centerRoom = New Room(New Point(((mBoardWidth / 2) - 5), ((mBoardHeight / 2) - 5)), 11, 11)

        Dim prevProgress As Double = -1
        While (coveredBoardSpace / maxBoardSpace) < 0.75
            'define a new room:  Each iteration get smaller
            For i = 0 To 18
                'define the new room's length
                Dim l = Int(Rnd() * (16 - i)) + 2
                Dim h = Int(Rnd() * (16 - i)) + 2

                'define the new room's x and y positions
                Dim x = cursor.X
                'y +- 10% of the board's height 
                Dim y = (cursor.Y - (Int(Rnd() * 10)) + ((Int(Rnd() * 20))))

                Dim outer_radius_width As Integer = (mBoardWidth / 2) - (diameter / 2)
                Dim outer_radius_height As Integer = (mBoardHeight / 2) - (diameter / 2)

                If y > outer_radius_height And y + h < outer_radius_height And x > outer_radius_width And x + l < outer_radius_width Then
                    i -= 1
                    If y > outer_radius_height Then cursor = New Point(cursor.X, outer_radius_height)
                    If y + l < outer_radius_height Then cursor = New Point(cursor.X, h + outer_radius_height)
                    If x > outer_radius_width Then cursor = New Point(outer_radius_width, cursor.Y)
                    If x + l < outer_radius_width Then cursor = New Point(l + outer_radius_width, cursor.Y)
                    Continue For
                End If

                If x + l < mBoardWidth And x >= 0 And y + h < mBoardHeight And y >= 0 Then
                    Dim roomToPlace = New Room(New Point(x, y), l, h)
                    roomRow.Add(roomToPlace)
                    For j = 0 To h
                        For k = 0 To l
                            placeTile(k + x, j + y, False)
                        Next
                    Next

                    'move the cursor to the next room
                    Dim newCursorX = x + l + 1 + Int(Rnd() * 20)
                    Dim newCursorY = cursor.Y
                    If newCursorX >= mBoardWidth - 4 Then
                        rooms.Add(roomRow)
                        roomRow = New List(Of Room)
                        newCursorX = 0 + Int(Rnd() * 3)
                        newCursorY = cursor.Y + 20
                    End If

                    cursor = New Point(newCursorX, newCursorY)
                    Exit For
                End If
            Next
            If prevProgress = (coveredBoardSpace / maxBoardSpace) Then Exit While
            prevProgress = (coveredBoardSpace / maxBoardSpace)
        End While

        '|CONNECT THE ROOMS|
        Dim allrooms As List(Of Room) = New List(Of Room)()
        allrooms.Add(centerRoom)
        For j = 0 To rooms.Count - 1
            For i = 0 To rooms(j).Count - 1
                'get the room in question
                Dim r = rooms(j)(i)
                allrooms.Add(r)


                Dim potentialNeighbors As List(Of Room) = getPotentialNeigbors(rooms, i, j)
                If potentialNeighbors.Count = 0 Then Continue For

                'set the number of exits on the room
                Dim numExits = Int(Rnd() * potentialNeighbors.Count) + 1
                For num = 1 To numExits
                    connectRooms(r, potentialNeighbors(Int(Rnd() * potentialNeighbors.Count)))
                Next

                r.marked = True
            Next
        Next

        '|VERIFY NO DISCONECTED CHUNKS|
        For i = 0 To allrooms.Count - 1
            For j = i + 1 To allrooms.Count - 1
                If Not allrooms(i).connectedTo(allrooms(j)) Then connectRooms(allrooms(i), allrooms(j), True)
            Next
        Next
    End Sub
    Private Shared Function getPotentialRadialNeigbors(ByRef allRooms As List(Of List(Of Room)), ByVal x As Integer, ByVal y As Integer) As List(Of Room)

        'Directions
        '
        ' ↖ = 1
        ' ↗ = 2
        ' ↘ = 3
        ' ↙ = 4

        Dim direction = -1

        Dim allRooms_y_mid = allRooms.Count() / 2
        Dim allRooms_x_mid = allRooms(y).Count() / 2

        If x < allRooms_x_mid And y < allRooms_y_mid Then direction = 1
        If x >= allRooms_x_mid And y < allRooms_y_mid Then direction = 2
        If x >= allRooms_x_mid And y >= allRooms_y_mid Then direction = 3
        If x < allRooms_x_mid And y >= allRooms_y_mid Then direction = 4


        Dim results As List(Of Room) = New List(Of Room)

        If x > 0 And (direction = 1 Or direction = 4) Then results.Add(allRooms(y)(x - 1))
        If x < allRooms(y).Count - 1 And (direction = 2 Or direction = 3) Then results.Add(allRooms(y)(x + 1))
        If y > 0 AndAlso x < allRooms(y - 1).Count - 1 And (direction = 1 Or direction = 2) Then results.Add(allRooms(y - 1)(x))
        If y < allRooms.Count - 1 AndAlso x < allRooms(y + 1).Count - 1 And (direction = 3 Or direction = 4) Then results.Add(allRooms(y + 1)(x))

        Return results
    End Function
    Private Sub connectRadialRooms(ByRef r1 As Room, ByRef r2 As Room, Optional overrideFlag As Boolean = False)
        If (r1.connectedTo(r2) Or r2.connectedTo(r1)) And Not overrideFlag Then Exit Sub
        If r1.directConnections > (Room.MAX_DIRECT_CONNECTIONS / 2) Or r2.directConnections > (Room.MAX_DIRECT_CONNECTIONS / 2) Then Exit Sub

        'Directions
        '
        ' ↖ = 1
        ' ↗ = 2
        ' ↘ = 3
        ' ↙ = 4

        Dim direction = -1

        If r1.top_left_pos.X < r2.top_left_pos.X And r1.top_left_pos.Y < r2.top_left_pos.Y Then direction = 1
        If r1.top_left_pos.X >= -r2.top_left_pos.X And r1.top_left_pos.Y < r2.top_left_pos.Y Then direction = 2
        If r1.top_left_pos.X >= r2.top_left_pos.X And r1.top_left_pos.Y >= r2.top_left_pos.Y Then direction = 3
        If r1.top_left_pos.X < r2.top_left_pos.X And r1.top_left_pos.Y >= r2.top_left_pos.Y Then direction = 4

        r1.directConnections += 1
        r2.directConnections += 1

        connectPoints(r1.getExit(direction), r2.getExit)

        r1.connect(r2)
        r2.connect(r1)
    End Sub

    '|-Boss Hallways-|
    Sub genBossFloor(ByRef p As Player)
        'Creates a straight hallway of a floor for a boss floor
        If mBoardHeight < 30 Then mBoardHeight = 30
        If mBoardWidth < 15 Then mBoardWidth = 15

        ReDim mBoard(mBoardHeight, mBoardWidth)
        For y = 0 To mBoardHeight
            For x = 0 To mBoardWidth
                mBoard(y, x) = New mTile(0, "", Color.Black)
            Next
        Next

        For y = 1 To 25
            For x = 3 To 7
                mBoard(y, x).Tag = DDConst.TILE_SEEN
            Next
        Next
        p.pos = New Point(5, 25)
        stairs = New Point(5, 3)
        If floorNumber = 5 Then genMedusaStatues()
        If floorNumber = 91018 Then genFVendFire()
        'beatBoss = True
    End Sub
    'floor 5
    Sub genMedusaStatues()
        'places the statues on floor 5 for ambience
        Randomize()
        Dim numStatues As Integer = Int((Rnd() * 5) + 6)
        For i = 0 To numStatues
            Dim x = Int((Rnd() * 5) + 3)
            Dim y = Int((Rnd() * 15) + 7)

            If mBoard(y, x).Text = "" Then
                Dim tr As New Monster()
                tr.pos = New Point(x, y)
                statueList.Add(New Statue(tr))
            End If
        Next
    End Sub
    'floor 91018
    Sub genFVendFire()
        For i = 0 To mBoardHeight
            If i Mod 4 = 0 And mBoard(i, 5).Tag > 0 Then
                mBoard(i, 3).Text = "✢"
                mBoard(i, 7).Text = "✢"
                mBoard(i, 3).Tag = DDConst.TILE_SEEN
                mBoard(i, 7).Tag = DDConst.TILE_SEEN
            End If
        Next
    End Sub

    '|-Space Floor-|
    Sub genSpaceFloor()
        Dim floorLayout As String() = {"_____________________________",
                                       "____________#####____________",
                                       "___________#######___________",
                                       "___________###%###___________",
                                       "___________#######___________",
                                       "____________#####____________",
                                       "__#^##________#______________",
                                       "_######_______#______####____",
                                       "_$#############_____##&###___",
                                       "_######_______############___",
                                       "__##^#________#_____###&##___",
                                       "______________#______####____",
                                       "______________#______________",
                                       "_____________##!_____________",
                                       "_____________#@#_____________",
                                       "_____________###_____________"}

        If mBoardHeight < 16 Then mBoardHeight = 16
        If mBoardWidth < 30 Then mBoardWidth = 30

        ReDim mBoard(mBoardHeight, mBoardWidth)
        For y = 0 To mBoardHeight
            For x = 0 To mBoardWidth
                mBoard(y, x) = New mTile(0, "", Color.Black)
            Next
        Next

        For y = 0 To UBound(floorLayout)
            Dim line = floorLayout(y).ToCharArray
            For x = 0 To UBound(line)
                If Not line(x) = "_"c Then mBoard(y, x).Tag = DDConst.TILE_SEEN
                If line(x) = "%"c Then
                    stairs = New Point(x, y)
                ElseIf line(x) = "^"c Then
                    Dim chestPoint = New Point(x, y)
                    genSpaceChest2(chestPoint)
                ElseIf line(x) = "&"c Then
                    Dim chestPoint = New Point(x, y)
                    genSpaceChest1(chestPoint)
                ElseIf line(x) = "$"c Then
                    Dim trapPoint = New Point(x, y)
                    Dim t = Trap.trapFactory(CStr(x) & "*" & CStr(y) & "*" & CStr(6) & "*")
                    trapList.Add(t)
                    mBoard(trapPoint.Y, trapPoint.X).ForeColor = Color.FromArgb(45, 45, 45)
                    mBoard(trapPoint.Y, trapPoint.X).Text = "+"
                ElseIf line(x) = "!"c Then
                    Dim trapPoint = New Point(x, y)
                    Dim t = Trap.trapFactory(CStr(x) & "*" & CStr(y) & "*" & CStr(5) & "*")
                    trapList.Add(t)
                    mBoard(trapPoint.Y, trapPoint.X).ForeColor = Color.FromArgb(45, 45, 45)
                    mBoard(trapPoint.Y, trapPoint.X).Text = "+"
                ElseIf line(x) = "@"c Then
                    Game.player1.pos = New Point(x, y)
                End If
            Next
        Next
    End Sub
    Sub genSpaceChest1(ByVal p As Point)
        Dim c1 As Chest
        Dim inv = New Inventory(False)

        Dim r = 0

        For Each itm In LootTable.getSpaceChest1Contents
            If Not itm.Equals(SAJumpsuit.ITEM_NAME) Then
                If Int(Rnd() * 3) = 0 Then r = 1 Else r = 0
                inv.add(itm, r)
            End If
        Next

        inv.add(SAJumpsuit.ITEM_NAME, 1)
        c1 = DDConst.BASE_CHEST.Create(inv, p, False)

        chestList.Add(c1)
        mBoard(p.Y, p.X).ForeColor = Color.FromArgb(45, 45, 45)
        mBoard(p.Y, p.X).Text = "#"
    End Sub
    Sub genSpaceChest2(ByVal p As Point)
        Dim c1 As Chest
        Dim inv = New Inventory(False)

        Dim r = 0

        For Each itm In LootTable.getSpaceChest2Contents
            If Not itm.Equals(VialOfBimbo.ITEM_NAME) And Not itm.Equals(SpaceBun.ITEM_NAME) Then
                If Int(Rnd() * 3) = 0 Then r = 1 Else r = 0
                inv.add(itm, r)
            End If
        Next

        If Int(Rnd() * 3) = 0 Then r = 3 Else r = 0
        inv.add(SpaceBun.ITEM_NAME, r)

        inv.add(VialOfBimbo.ITEM_NAME, 1)
        c1 = DDConst.BASE_CHEST.Create(inv, p, False)

        chestList.Add(c1)
        mBoard(p.Y, p.X).ForeColor = Color.FromArgb(45, 45, 45)
        mBoard(p.Y, p.X).Text = "#"
    End Sub

    '|-Space Floor 2-|
    Sub genSpaceFloor2()
        Dim floorLayout As String() = {"_________________________________________________________________________________________",
                                       "_________________________________________________________________________________________",
                                       "_________________________________________________________________________________________",
                                       "_____________________________________________###_________________________________________",
                                       "__________________###_______________________#####________________________###_____________",
                                       "__________________#########################|##%##|######################|###_____________",
                                       "__________________###_______________________#####________________________###_____________",
                                       "__________________###________________________###_________________________###_____________",
                                       "__________________###____________________________________________________###_____________",
                                       "__________________###______LLL___________________________###_____________###_____________",
                                       "__________________#########LLL___________________________###|LLLLLLLLLLLL###_____________",
                                       "__________________###______LLL___________________________###_____________###_____________",
                                       "__________________###____________________________________________________###_____________",
                                       "__________________###______###___________________________###_____________###_____________",
                                       "__________________##########$#___________________________#!#################_____________",
                                       "_________###______###______###___________________________###_____________###_____________",
                                       "________#####_____###__________________####______________________________###_____________",
                                       "________#&T######|###______LLL_________#^^#______________###_____________###_____________",
                                       "________#####_____###LLLLLLLLL_________####______________###################_____________",
                                       "_________###______###______LLL__________#________________###_____________###_____________",
                                       "__________________###___________________#________________________________###_____________",
                                       "__________________###___________________#________________________________###_____________",
                                       "LLLLLLLLLLLLLLLLL|######################################################|###|LLLLLLLLLLLL",
                                       "LLLLLLLLLLLLLLLLL|######################################################|###|LLLLLLLLLLLL",
                                       "LLLLLLLLLLLLLLLLL|######################################################|###|LLLLLLLLLLLL",
                                       "LLLLLLLLLLLLLLLLL|######################################################|###|LLLLLLLLLLLL",
                                       "__________________---____________________________________________________###_____________",
                                       "__________________###____________________________________________________###_____________",
                                       "__________________###|LLLLLLLLLLLLLL____________________LLLLLLLLLLLLLLLL|###_____________",
                                       "__________________###__________LLLLL____________________LLLLL____________###_____________",
                                       "__________________###__________LLLLL____________________LLLLL____________###_____________",
                                       "__________________###__________LLLLL____________________LLLLL____________###_____________",
                                       "__________________###____________________________________________________###_____________",
                                       "__________________###|LLLLLLLLLLLLLL____________________####################_____________",
                                       "__________________###__________LLLLL____________________#####____________###_____________",
                                       "__________________###__________LLLLL____________________###@#____________###_____________",
                                       "__________________###__________LLLLL____________________#####____________###_____________",
                                       "__________________###____________________________________________________###_____________",
                                       "__________________###|LLLLLLLLLLLLLL____________________LLLLLLLLLLLLLLLL|###_____________",
                                       "__________________###__________LLLLL____________________LLLLL____________###_____________",
                                       "__________________###__________LLLLL____________________LLLLL____________###_____________",
                                       "__________________###__________LLLLL____________________LLLLL____________###_____________",
                                       "__________________###____________________________________________________###_____________",
                                       "__________________###|LLLLLLLLLLLLLL____________________LLLLLLLLLLLLLLLL|###_____________",
                                       "__________________###__________LLLLL____________________LLLLL____________###_____________",
                                       "__________________###__________LLLLL____________________LLLLL____________###_____________",
                                       "__________________###__________LLLLL____________________LLLLL____________###_____________",
                                       "__________________###____________________________________________________###_____________",
                                       "__________________---____________________________________________________---_____________",
                                       "__________________LLL____________________________________________________LLL_____________",
                                       "__________________LLL____________________________________________________LLL_____________",
                                       "__________________LLL____________________________________________________LLL_____________",
                                       "__________________LLL____________________________________________________LLL_____________",
                                       "__________________LLL____________________________________________________LLL_____________",
                                       "__________________LLL____________________________________________________LLL_____________",
                                       "__________________LLL____________________________________________________LLL_____________"}

        If mBoardHeight < 60 Then mBoardHeight = 60
        If mBoardWidth < 100 Then mBoardWidth = 100

        ReDim mBoard(mBoardHeight, mBoardWidth)
        For y = 0 To mBoardHeight
            For x = 0 To mBoardWidth
                mBoard(y, x) = New mTile(0, "", Color.Black)
            Next
        Next

        For y = 0 To UBound(floorLayout)
            Dim line = floorLayout(y).ToCharArray
            For x = 0 To UBound(line)
                If Not line(x) = "_"c Then mBoard(y, x).Tag = DDConst.TILE_SEEN
                If line(x) = "L"c Then
                    mBoard(y, x).Tag = DDConst.TILE_UNSEEN
                ElseIf line(x) = "%"c Then
                    stairs = New Point(x, y)
                ElseIf line(x) = "^"c Then
                    Dim chestPoint = New Point(x, y)
                    genSpaceChest3(chestPoint)
                ElseIf line(x) = "&"c Then
                    Dim chestPoint = New Point(x, y)
                    genSpaceChest4(chestPoint)
                ElseIf line(x) = "$"c Then
                    Dim trapPoint = New Point(x, y)
                    Dim t = Trap.trapFactory(CStr(x) & "*" & CStr(y) & "*" & CStr(8) & "*")
                    trapList.Add(t)
                    mBoard(trapPoint.Y, trapPoint.X).ForeColor = Color.FromArgb(45, 45, 45)
                    mBoard(trapPoint.Y, trapPoint.X).Text = "+"
                ElseIf line(x) = "!"c Then
                    Dim trapPoint = New Point(x, y)
                    Dim t = Trap.trapFactory(CStr(x) & "*" & CStr(y) & "*" & CStr(7) & "*")
                    trapList.Add(t)
                    mBoard(trapPoint.Y, trapPoint.X).ForeColor = Color.FromArgb(45, 45, 45)
                    mBoard(trapPoint.Y, trapPoint.X).Text = "+"
                ElseIf line(x) = "@"c Then
                    Game.player1.pos = New Point(x, y)
                ElseIf line(x) = "-"c Then
                    mBoard(y, x).Tag = DDConst.TILE_WALL
                    mBoard(y, x).Text = "-"
                ElseIf line(x) = "|"c Then
                    mBoard(y, x).Tag = DDConst.TILE_WALL
                    mBoard(y, x).Text = "|"
                ElseIf line(x) = "T"c Then
                    addNPC(Game.ttraveler, New Point(x, y))
                ElseIf line(x) = "@"c Then
                    Game.ttraveler.pos = New Point(x, y)
                End If
            Next
        Next
    End Sub
    Sub genSpaceChest3(ByVal p As Point)
        Dim c1 As Chest
        Dim inv = New Inventory(False)

        Dim r = 0

        For Each itm In LootTable.getSpaceChest3Contents
            If Not itm.Equals(BitGold.ITEM_NAME) And
                Not itm.Equals(A6Battery.ITEM_NAME) And
                Not itm.Equals(CryoGrenade.ITEM_NAME) And
                Not itm.Equals(PhaseHammer.ITEM_NAME) And
                Not itm.Equals(PhaseDrill.ITEM_NAME) And
                Not itm.Equals(PhaseRifle.ITEM_NAME) Then
                If Int(Rnd() * 6) = 0 Then r = 1 Else r = 0
                inv.add(itm, r)
            End If
        Next

        If Int(Rnd() * 6) = 0 Then r = Int(Rnd() * 3) + 1 Else r = 0
        inv.add("BitGold", r)

        If Int(Rnd() * 6) = 0 Then r = Int(Rnd() * 5) + 1 Else r = 0
        inv.add("CryoGrenade", r)

        If Int(Rnd() * 2) = 0 Then
            Select Case Int(Rnd() * 3)
                Case 0
                    inv.add("Phase_Rifle", 1)
                Case 1
                    inv.add("Phase_Hammer", 1)
                Case 2
                    inv.add("Phase_Drill", 1)
            End Select
        End If

        inv.add("AAAAAA_Battery", CInt(Rnd() * 10) + 5)

        c1 = DDConst.BASE_CHEST.Create(inv, p, False)

        chestList.Add(c1)
        mBoard(p.Y, p.X).ForeColor = Color.FromArgb(45, 45, 45)
        mBoard(p.Y, p.X).Text = "#"
    End Sub
    Sub genSpaceChest4(ByVal p As Point)
        Dim c1 As Chest
        Dim inv = New Inventory(False)

        For Each itm In LootTable.getSpaceChest4Contents
            If Not itm.Equals(A6Battery.ITEM_NAME) Then
                inv.add(itm, 1)
            End If
        Next

        inv.add(A6Battery.ITEM_NAME, CInt(Rnd() * 10) + 5)

        c1 = DDConst.BASE_CHEST.Create(inv, p, False)

        chestList.Add(c1)
        mBoard(p.Y, p.X).ForeColor = Color.FromArgb(45, 45, 45)
        mBoard(p.Y, p.X).Text = "#"
    End Sub

    '|-Legacy Floor-|
    Sub genLegacyFloor()
        Dim floorLayout As String() = {"_____________________________",
                                       "_############################",
                                       "____####____________#@#_____#",
                                       "____#^##____________###_____#",
                                       "____####____________________#",
                                       "#############################",
                                       "#___________###^####_________",
                                       "#___________###########______",
                                       "#_____________###__#####______",
                                       "#####################$#######",
                                       "______#####___###__#####____#",
                                       "______#####___###__#####____#",
                                       "______##^##___###___________#",
                                       "#############################",
                                       "#_____#####___###____________",
                                       "#_____________#########______",
                                       "#_____________#########______",
                                       "##################%##########",
                                       "______________######^##_____#",
                                       "______________#########______"}

        If mBoardHeight < 20 Then mBoardHeight = 20
        If mBoardWidth < 30 Then mBoardWidth = 30

        For y = 0 To 19
            Dim line = floorLayout(y).ToCharArray
            For x = 0 To UBound(line)
                If Not line(x) = "_"c Then mBoard(y, x).Tag = DDConst.TILE_UNSEEN
                If line(x) = "%"c Then
                    stairs = New Point(x, y)
                ElseIf line(x) = "^"c Then
                    Dim chestPoint = New Point(x, y)
                    Dim chest As Chest = DDConst.BASE_CHEST.Create(chestPoint, floorCode)
                    addChest(chest, chestPoint)
                ElseIf line(x) = "@"c Then
                    Game.player1.pos = New Point(x, y)
                ElseIf line(x) = "$"c Then
                    Game.shopkeeper.pos = New Point(x, y)
                End If
            Next
        Next

        populateLegacyChests()
    End Sub
    Sub populateLegacyChests()
        Dim itemsItemsToPlace As List(Of Tuple(Of String, Integer)) = New List(Of Tuple(Of String, Integer))

        'Armors
        itemsItemsToPlace.Add(New Tuple(Of String, Integer)(ChickenSuit.ITEM_NAME, 1))
        itemsItemsToPlace.Add(New Tuple(Of String, Integer)(GalGarb.ITEM_NAME, 1))

        'Weapons
        itemsItemsToPlace.Add(New Tuple(Of String, Integer)(TwinBlades.ITEM_NAME, 1))
        itemsItemsToPlace.Add(New Tuple(Of String, Integer)(SevenfoldStaff.ITEM_NAME, 1))

        'Other
        itemsItemsToPlace.Add(New Tuple(Of String, Integer)(BunnyEars.ITEM_NAME, 1))
        itemsItemsToPlace.Add(New Tuple(Of String, Integer)(AllSeeingShadesOrig.ITEM_NAME, 1))
        itemsItemsToPlace.Add(New Tuple(Of String, Integer)(OtherVialOfBimbo.ITEM_NAME, 1))

        For Each i In itemsItemsToPlace
            chestList(Int(Rnd() * chestList.Count)).contents.add(i.Item1, i.Item2)
        Next
    End Sub

    '|---OBJECT PLACEMENT---|
    Sub placeStairs()
        stairs = randPoint()
        mBoard(stairs.Y, stairs.X).ForeColor = Color.FromArgb(45, 45, 45)
        mBoard(stairs.Y, stairs.X).Text = "H"
    End Sub
    Sub placePlayer(ByRef p As Player)
        p.pos = getStartPlayerPos()
        playerPosition = p.pos
        mBoard(p.pos.Y, p.pos.X).Text = "@"
        If floorNumber = 4 Then placeFloor4TrappedChest(Game.player1)
    End Sub
    Public Function getStartPlayerPos() As Point
        Select Case floorNumber
            Case 5
                Return New Point(5, 25)
            Case 9
                Return New Point(4, 24)
            Case 91017
                Return New Point(21, 1)
            Case 9999
                Return New Point(14, 13)
            Case 10000
                Return New Point(59, 35)
            Case Else
                Return randPoint()
        End Select
    End Function
    Sub placeChest(ByVal code As String, Optional ByVal numChests As Integer = 0)
        'Fill Chest Tier List
        If DDConst.BASE_CHEST.getCachedLootTableBracket(floorNumber) <> LootTable.getBracket(floorNumber) Then
            For i = cTier.tier1 To DDConst.BASE_CHEST.tiers.Count - 1
                DDConst.BASE_CHEST.tiers(i).Clear()
            Next

            For i = 0 To DDConst.BASE_CHEST.contents.upperBound
                Dim c_item = DDConst.BASE_CHEST.contents.item(i)
                If c_item.getTier(floorNumber) <> Nothing And Not c_item.npc_drop_only Then
                    DDConst.BASE_CHEST.tiers(c_item.getTier(floorNumber)).Add(c_item)
                End If
            Next

            DDConst.BASE_CHEST.getCachedLootTableBracket(floorNumber, True)
        End If

        Randomize(code.GetHashCode)
        'Dim numChests As Integer = CInt(Int(Rnd() * 8) + 3) * Int((mBoardWidth / 30) + (mBoardHeight / 30) / 2)
        If numChests = 0 Then numChests = CInt((Int(Rnd() * Game.chestFreqRange) + Game.chestFreqMin) * (Math.Sqrt(coveredBoardSpace) / Game.chestSizeDependence))

        If floorNumber = 3 Then
            numChests *= 1.5
            placeKeyChest()
        End If


        If floorNumber >= 3 And Int(Rnd() * 20) = 0 Then
            Dim p = randPoint()
            addChest(New LoadedChest(p, 5), p)
        End If

        If Not Game.player1 Is Nothing AndAlso Game.player1.quests(qInd.dfaUpgrade).getActive Then
            For i = 0 To Int(Rnd() * 3) + 1
                Dim p = randPoint()
                addChest(New LoadedChest(p, 6), p)
            Next
        End If

        For i = 1 To numChests
            Dim chestPoint = randPoint()
            Dim chest As Chest = DDConst.BASE_CHEST.Create(chestPoint, code)
            addChest(chest, chestPoint)
        Next


        For Each c In chestList
            mBoard(c.pos.Y, c.pos.X).Text = ""
        Next
    End Sub
    Sub addChest(ByVal c As Chest, ByVal p As Point)
        chestList.Add(c)
        mBoard(p.Y, p.X).ForeColor = Color.FromArgb(45, 45, 45)
        mBoard(p.Y, p.X).Text = "#"
    End Sub
    Sub placeTraps()
        trapList.Clear()
        If Game.trapSizeDependence <= 0 Then Game.trapSizeDependence = 1
        Dim numtrap As Integer = CInt(Int(Rnd() * Game.trapFreqRange) + Game.trapFreqMin) * (Math.Sqrt(coveredBoardSpace) / Game.trapSizeDependence)
        For i = 1 To numtrap
            Dim trapPoint = randPoint()
            mBoard(trapPoint.Y, trapPoint.X).ForeColor = Color.FromArgb(45, 45, 45)
            mBoard(trapPoint.Y, trapPoint.X).Text = "+"
            Dim t = Trap.trapFactory(Trap.getRandomTrapId(floorNumber), trapPoint)
            trapList.Add(t)
        Next
    End Sub
    Sub placeNPCs(ByRef npc_list As List(Of ShopNPC), ByVal possibleNPCs As Integer())
        If npc_list.Count < 1 Then Exit Sub

        npcPositions.Clear()

        Dim numNpc As Integer = Int(Rnd() * possibleNPCs.Length) + 1
        If floorNumber = 1 Then numNpc = 1
        Dim placed = New List(Of Integer)

        For i = 1 To numNpc
            Dim npcPoint = randPoint()
            Dim npcInd = Int(Rnd() * possibleNPCs.Length)
            While placed.Contains(npcInd) And Not placed.Count >= npc_list.Count
                npcInd = Int(Rnd() * possibleNPCs.Length)
            End While

            If floorNumber = 1 Then npcInd = 0

            Dim sNPC = npc_list(possibleNPCs(npcInd))

            addNPC(sNPC, npcPoint)

            If floorNumber = 3 Then sNPC.inv.add(53, 1) Else sNPC.inv.item(53).count = 0
            placed.Add(npcInd)
        Next

        If Game.player1.cursed AndAlso Game.cbrok.pos.X = -1 And Not Game.cbrok.isDead Then addNPC(Game.cbrok, randPoint)
        If Not Game.currFloor Is Nothing AndAlso Game.currFloor.pinkMist AndAlso Game.shopkeeper.pos.X = -1 And Not Game.shopkeeper.isDead Then addNPC(Game.shopkeeper, randPoint)

        For i = 0 To npc_list.Count - 1
            npcPositions.Add(npc_list(i).pos)
        Next
    End Sub
    Function getPossibleNPCs() As Integer()
        If floorNumber < 3 Then
            Return {ShopNPCInd.shopkeeper, ShopNPCInd.shadywizard, ShopNPCInd.foodvendor}
        ElseIf floorNumber = 3 Then
            Return {ShopNPCInd.shopkeeper, ShopNPCInd.shadywizard, ShopNPCInd.hypnoteach, ShopNPCInd.foodvendor, ShopNPCInd.cursebroker}
        ElseIf floorNumber = 7 Then
            Return {ShopNPCInd.hypnoteach}
        ElseIf floorNumber = 10 Then
            Return {ShopNPCInd.shopkeeper, ShopNPCInd.hypnoteach, ShopNPCInd.weaponsmith, ShopNPCInd.cursebroker, ShopNPCInd.maskmaggirl}
        ElseIf floorNumber = 13 Then
            Return {ShopNPCInd.foodvendor, ShopNPCInd.cursebroker}
        Else
            If Game.player1.className.StartsWith("Magical") Then
                Return {ShopNPCInd.shopkeeper, ShopNPCInd.shadywizard, ShopNPCInd.hypnoteach, ShopNPCInd.weaponsmith, ShopNPCInd.cursebroker, ShopNPCInd.maskmaggirl}
            Else
                Return {ShopNPCInd.shopkeeper, ShopNPCInd.shadywizard, ShopNPCInd.hypnoteach, ShopNPCInd.foodvendor, ShopNPCInd.weaponsmith, ShopNPCInd.cursebroker}
            End If
        End If
    End Function
    Sub addNPC(ByRef n As ShopNPC, ByRef npcPoint As Point)
        n.pos = npcPoint
        mBoard(npcPoint.Y, npcPoint.X).ForeColor = Color.FromArgb(45, 45, 45)
        mBoard(npcPoint.Y, npcPoint.X).Text = "$"

        Try
            If Not nonRandomFloors.Contains(floorNumber) Then n.buildShopArea(Me)
        Catch ex As Exception
        End Try
    End Sub
    Sub placeKeyChest()
        Dim ChestP = randPoint()
        Dim c As Chest = New LoadedChest(ChestP, 3)
        chestList.Add(c)
        mBoard(c.pos.Y, c.pos.X).ForeColor = Color.FromArgb(45, 45, 45)
        mBoard(c.pos.Y, c.pos.X).Text = "#"
    End Sub

    '|---UTILITY METHODS---|
    Function randPoint() As Point
        Dim posX As Integer
        Dim posY As Integer
        Dim attempts = 0
        Do While (mBoard(posY, posX).Tag < 1 Or mBoard(posY, posX).Text <> "") And attempts < 75
            posX = CInt(Int(Rnd() * mBoardWidth))
            posY = CInt(Int(Rnd() * mBoardHeight))
            attempts += 1
        Loop
        Return New Point(posX, posY)
        'Return randPointV2()
    End Function
    Function randPointV2() As Point
        Dim pos_x As Integer
        Dim pos_y As Integer

        Dim min_x As Integer = 0
        Dim max_x As Integer = mBoardWidth

        Dim min_y As Integer = 0
        Dim max_y As Integer = mBoardHeight

        For i = 0 To 10
            Do While (mBoard(pos_y, pos_x).Tag < 1 Or mBoard(pos_y, pos_x).Text <> "") And Not (min_x = max_x Or min_y = max_y)

                Select Case Int(Rnd() * 4)
                    Case 0
                        'Q4: X, -Y
                        min_y = Math.Floor(min_y / 2)
                        max_y = Math.Floor(max_y / 2)
                    Case 1
                        'Q2: -X, Y
                        min_x = Math.Floor(min_x / 2)
                        max_x = Math.Floor(max_x / 2)
                    Case 2
                        'Q3: -X, -Y
                        max_x = Math.Floor(max_x / 2)
                        max_y = Math.Floor(max_y / 2)
                    Case Else
                        'Q1: X, Y
                        min_x = Math.Floor(max_x / 2)
                        min_y = Math.Floor(max_y / 2)
                End Select

                pos_x = CInt(Int(Rnd() * (max_x - min_x))) + min_x
                pos_y = CInt(Int(Rnd() * (max_y - min_y))) + min_y
            Loop

            If mBoard(pos_y, pos_x).Tag >= 1 And mBoard(pos_y, pos_x).Text = "" Then Exit For
        Next


        Return New Point(pos_x, pos_y)
    End Function
    Function route(ByVal p1 As Point, ByVal p2 As Point) As Point()
        'Generates a path between two points.  This is not always the shortest path
        'between the two points, but they will always be connected.

        'iterative dijkstra's shortest path implementation
        Dim dist(mBoardHeight, mBoardWidth) As Integer
        Dim allPoints As List(Of Point) = New List(Of Point)
        Dim prev(mBoardHeight, mBoardWidth) As Point
        Dim path As List(Of Point) = New List(Of Point)
        For i = 0 To mBoardHeight - 1
            For j = 0 To mBoardWidth - 1
                dist(i, j) = 999999999
                allPoints.Add(New Point(j, i))
                prev(i, j) = Nothing
            Next
        Next
        dist(p1.Y, p1.X) = 0
        While allPoints.Count > 0
            Dim min = allPoints(0)
            For i = 0 To allPoints.Count - 1
                If dist(allPoints(i).Y, allPoints(i).X) < dist(min.Y, min.X) Then min = allPoints(i)
            Next
            allPoints.Remove(min)
            Dim u, d, l, r As Point
            u = New Point(min.X - 1, min.Y)
            d = New Point(min.X + 1, min.Y)
            l = New Point(min.X, min.Y - 1)
            r = New Point(min.X, min.Y + 1)
            For Each p In {u, d, l, r}
                Dim tDist = dist(min.Y, min.X) + DDUtils.distance(min, p)
                If Not (p.X < 0 Or p.X > mBoardWidth - 1 Or p.Y < 0 Or p.Y > mBoardHeight - 1) AndAlso Not mBoard(p.Y, p.X).Tag = 0 AndAlso Not path.Contains(p) AndAlso allPoints.Contains(p) Then
                    If tDist < dist(p.Y, p.X) Then
                        dist(p.Y, p.X) = tDist
                        prev(p.Y, p.X) = min
                    End If
                End If
                If p.Equals(p2) Then
                    Dim pp = p2
                    While Not path.Contains(pp)
                        path.Insert(0, pp)
                        pp = prev(pp.Y, pp.X)
                    End While
                    Exit For
                End If
            Next
        End While
        If path.Count > 1 Then path.RemoveAt(0)
        Return path.ToArray
    End Function
    Sub printBoard()
        'Outputs a file creating a text version of the board
        Dim writer As IO.StreamWriter
        writer = IO.File.CreateText("bo.ard")
        For y = 0 To mBoardHeight - 1
            Dim line As String = ""
            For x = 0 To mBoardWidth - 1
                Select Case mBoard(y, x).Tag
                    Case 0
                        line += " "
                    Case Else
                        If Not mBoard(y, x).Text = "" Then line += mBoard(y, x).Text Else line += "_"
                End Select
            Next
            writer.WriteLine(line)
        Next
        writer.Flush()
        writer.Close()
    End Sub
    Shared Function genRNDLVLCode() As String
        'returns a randomized seed to be used in level generation
        Dim numLetters As String = "abcdefghijklmnopqrstuvwxyz123456789"
        Dim output As String = ""
        Randomize() 'initializes the randomizer
        For i = 0 To 8
            output += numLetters.Substring(Int(Rnd() * numLetters.Length), 1)
        Next
        Return output
    End Function
    Function getTile(ByVal y As Integer, ByVal x As Integer) As mTile
        Return mBoard(y, x)
    End Function
    Sub verifyNoDisconectedChunks(ByRef p As Player)
        connectPoints(p.pos, stairs)
    End Sub
    Sub cleanPaths()
        For Each tile In mBoard
            If Not tile Is Nothing AndAlso tile.Text = "x" Then tile.Text = ""
        Next
    End Sub

    '|---SERIALIZATION METHODS---|
    Sub loadMFloor(ByVal s As String)
        Dim buffer = s.Split("%")

        floorNumber = CInt(buffer(1))
        floorCode = buffer(2)
        mBoardHeight = CInt(buffer(3))
        mBoardWidth = CInt(buffer(4))

        'reset the board
        ReDim mBoard(mBoardHeight, mBoardWidth)
        For y = 0 To mBoardHeight
            For x = 0 To mBoardWidth
                mBoard(y, x) = New mTile(0, "", Color.Black)
            Next
        Next

        trapList.Clear()
        For i = 0 To CInt(buffer(6))
            Dim t = Trap.trapFactory(buffer(7 + i))
            trapList.Add(t)
            If t.pos.X < mBoardWidth And t.pos.X > 0 And t.pos.Y < mBoardHeight And t.pos.Y > 0 Then
                mBoard(t.pos.Y, t.pos.X).Text = "+"
            End If
        Next

        statueList.Clear()
        For i = 0 To CInt(buffer(8 + trapList.Count))
            statueList.Add(New Statue(buffer(9 + trapList.Count + i)))
        Next

        chestList.Clear()
        For i = 0 To CInt(buffer(10 + trapList.Count + statueList.Count))
            chestList.Add(New Chest().Create(buffer(11 + trapList.Count + statueList.Count + i)))
        Next

        beatBoss = CBool(buffer(12 + trapList.Count + statueList.Count + chestList.Count))

        stairs = New Point(CInt(buffer(14 + trapList.Count + statueList.Count + chestList.Count)),
                           CInt(buffer(15 + trapList.Count + statueList.Count + chestList.Count)))

        playerPosition = New Point(CInt(buffer(17 + trapList.Count + statueList.Count + chestList.Count)),
                           CInt(buffer(18 + trapList.Count + statueList.Count + chestList.Count)))

        npcPositions.Clear()
        For i = 0 To CInt(buffer(20 + trapList.Count + statueList.Count + chestList.Count))
            Dim xy = buffer(21 + trapList.Count + statueList.Count + chestList.Count + i).Split("~")
            npcPositions.Add(New Point(xy(0), xy(1)))
        Next

        Dim sessionLines = 0
        If buffer(21 + trapList.Count + statueList.Count + chestList.Count + npcPositions.Count).Equals("sessions") Then sessionLines = 2

        If sessionLines = 2 Then
            sessions.Clear()
            For i = 0 To CInt(buffer(22 + trapList.Count + statueList.Count + chestList.Count + npcPositions.Count))
                Dim idxybb = buffer(23 + trapList.Count + statueList.Count + chestList.Count + npcPositions.Count + i).Split("~")
                sessions.Add(CInt(idxybb(0)), New Session(idxybb(0), New Point(idxybb(1), idxybb(2)), idxybb(3)))
            Next
        End If

        coveredBoardSpace = 0
        For y = 0 To mBoardHeight - 1
            For x = 0 To mBoardWidth - 1
                Dim i = (y * mBoardWidth) + x
                Dim tile = buffer(22 + sessionLines + trapList.Count + statueList.Count + chestList.Count + npcPositions.Count + sessions.Count + i).Split("`")
                mBoard(y, x).Tag = CInt(tile(0))
                If tile.Length > 1 Then mBoard(y, x).Text = tile(1)
                If mBoard(y, x).Tag > 0 Then coveredBoardSpace += 1
            Next
        Next

        '|Floor statue doublecheck|
        If floorNumber = 7 And Game.player1.perks(perk.seventailsstage) = -1 Then
            Dim stailsStatue = Nothing

            For Each stat In statueList
                If stat.name = "seventailsstatue" Then stailsStatue = stat
            Next

            If stailsStatue Is Nothing Then statueList.Add(New Statue(Game.player1.pos, "seventailsstatue", "You see here a golden statue of a fox"))
        End If
    End Sub
    Sub loadMFloor(ByRef f As mFloor)
        Me.mBoardWidth = f.mBoardWidth
        Me.mBoardHeight = f.mBoardHeight
        Me.coveredBoardSpace = f.coveredBoardSpace

        Me.mBoard = f.mBoard

        Me.floorNumber = f.floorNumber
        Me.floorCode = f.floorCode
        Me.stairs = f.stairs

        Me.chestList = f.chestList
        Me.statueList = f.statueList
        Me.trapList = f.trapList

        Me.playerPosition = f.playerPosition
        Me.npcPositions = f.npcPositions

        me.bossDialog = f.bossDialog
        Me.beatBoss = f.beatBoss
    End Sub
    Public Sub writeFloorToFile()
        Try
            SaveFile.saveFloor(Me)
        Catch ex As Exception
            TextEvent.push("Error writing floor " & floorCode & " to file!")
        End Try
    End Sub
    Public Sub readFloorFromFile(ByVal fCode As String)
        Dim reader As IO.StreamReader = Nothing
        Try
            If IO.File.Exists("floors/" & fCode & ".flr") Then
                reader = IO.File.OpenText("floors/" & fCode & ".flr")
                loadMFloor(reader.ReadLine)
            ElseIf IO.File.Exists("floors/" & fCode & ".flrx") Then
                loadMFloor(SaveFile.loadFloor("floors/" & fCode & ".flrx"))
            End If
        Catch ex As Exception
            TextEvent.push("Error reading floor " & floorCode & " from file!")
        Finally
            If Not reader Is Nothing Then reader.Close()
        End Try
    End Sub
End Class

Public Class Room 
    Public Shared MAX_DIRECT_CONNECTIONS As Integer = 5

    Public top_left_pos As Point
    Public width, height As Integer
    Public marked As Boolean = False
    Dim exits As List(Of Point) = New List(Of Point)
    Public connectedRooms As List(Of Room) = New List(Of Room)
    Public directConnections As Integer

    Public Sub New(tlp As Point, w As Integer, h As Integer)
        top_left_pos = tlp
        width = w
        height = h
    End Sub
    Public Function getExit() As Point
        Dim p As Point = Nothing
        Dim ct = 0
        While (p = Nothing Or DDUtils.withinOnePlusMinus(p, exits)) And ct < 12
            Select Case Int(Rnd() * 4)
                Case 0
                    ' ←
                    p = New Point(top_left_pos.X, top_left_pos.Y + Int(Rnd() * height))
                Case 1
                    ' →
                    p = New Point(top_left_pos.X + width, top_left_pos.Y + Int(Rnd() * height))
                Case 2
                    ' ↑
                    p = New Point(top_left_pos.X + Int(Rnd() * width), top_left_pos.Y)
                Case Else
                    ' ↓
                    p = New Point(top_left_pos.X + Int(Rnd() * width), top_left_pos.Y + height)
            End Select
            ct += 1
        End While

        exits.Add(p)
        Return p
    End Function
    Public Function getExit(ByVal d As Integer) As Point
        'Directions
        '
        ' ↖ = 1
        ' ↗ = 2
        ' ↘ = 3
        ' ↙ = 4

        Dim p As Point = Nothing
        Dim ct = 0
        While (p = Nothing Or DDUtils.withinOnePlusMinus(p, exits)) And ct < 12
            Select Case d
                Case 1
                    Select Case Int(Rnd() * 2)
                        Case 0
                            ' ←
                            p = New Point(top_left_pos.X, top_left_pos.Y + Int(Rnd() * height))
                        Case Else
                            ' ↑
                            p = New Point(top_left_pos.X + Int(Rnd() * width), top_left_pos.Y)
                    End Select
                Case 2
                    Select Case Int(Rnd() * 2)
                        Case 0
                            ' →
                            p = New Point(top_left_pos.X + width, top_left_pos.Y + Int(Rnd() * height))
                        Case Else
                            ' ↑
                            p = New Point(top_left_pos.X + Int(Rnd() * width), top_left_pos.Y)
                    End Select
                Case 3
                    Select Case Int(Rnd() * 2)
                        Case 0
                            ' →
                            p = New Point(top_left_pos.X + width, top_left_pos.Y + Int(Rnd() * height))
                        Case Else
                            ' ↓
                            p = New Point(top_left_pos.X + Int(Rnd() * width), top_left_pos.Y + height)
                    End Select
                Case 4
                    Select Case Int(Rnd() * 2)
                        Case 0
                            ' ←
                            p = New Point(top_left_pos.X, top_left_pos.Y + Int(Rnd() * height))
                        Case Else
                            ' ↓
                            p = New Point(top_left_pos.X + Int(Rnd() * width), top_left_pos.Y + height)
                    End Select
            End Select

            ct += 1
        End While

        exits.Add(p)
        Return p
    End Function
    Public Sub connect(ByRef r As Room)
        If connectedRooms.Contains(r) Then Exit Sub

        connectedRooms.Add(r)

        For Each subR In difference(r.connectedRooms, connectedRooms)
            connect(subR)
        Next

        For Each subR In difference(connectedRooms, r.connectedRooms)
            r.connect(subR)
        Next
    End Sub
    Public Function connectedTo(ByRef r1 As Room, Optional ByRef checkedRooms As List(Of Point) = Nothing)
        If checkedRooms Is Nothing Then checkedRooms = New List(Of Point)()

        If r1.top_left_pos.Equals(top_left_pos) Then Return True

        For Each r2 In connectedRooms
            If r2.top_left_pos.Equals(r1.top_left_pos) Then Return True

            For Each subR2 In r2.connectedRooms
                If Not checkedRooms.Contains(subR2.top_left_pos) Then
                    checkedRooms.Add(subR2.top_left_pos)
                    Return subR2.connectedTo(r1, checkedRooms)
                End If
            Next
        Next

        Return False
    End Function
    Public Overrides Function Equals(obj As Object) As Boolean
        If Not obj.GetType Is GetType(Room) Then Return False

        Return CType(obj, Room).top_left_pos.Equals(top_left_pos)
    End Function

    Public Shared Function difference(ByRef l1 As List(Of Room), ByRef l2 As List(Of Room)) As List(Of Room)
        'Returns the items in l1 that are not in l2
        Dim results As List(Of Room) = New List(Of Room)()

        For Each i In l1
            If Not l2.Contains(i) Then results.Add(i)
        Next

        Return results
    End Function
End Class

Public Class Session
    Dim ID As Integer
    Dim playerPos As Point
    Dim beatBoss As Boolean

    Sub New(ByVal i As Integer, ByVal p As Point, ByVal b As Boolean)
        ID = i
        playerPos = p
        beatBoss = b
    End Sub

    Sub load(ByRef f As mFloor)
        f.playerPosition = playerPos
        f.beatBoss = beatBoss
    End Sub

    Function hasID(ByVal sID As Integer) As Boolean
        Return sID = ID
    End Function

    Overrides Function ToString() As String
        Return ID & "~" & playerPos.X & "~" & playerPos.Y & "~" & beatBoss
    End Function
End Class