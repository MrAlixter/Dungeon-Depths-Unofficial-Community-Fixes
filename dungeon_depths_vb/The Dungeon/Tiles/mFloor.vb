Imports System.ComponentModel

<Serializable()> Public Class mFloor
    Public mBoardWidth As Integer = 60
    Public mBoardHeight As Integer = 60
    Dim coveredBoardSpace As Integer = 0

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

    Public beatBoss As Boolean = False

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
        If floorNumber = 9999 Or floorNumber = 91017 Or floorNumber = 5 Then
            Game.updateLoadbar(99)
            Game.boardWorker.CancelAsync()
            Exit Sub
        End If
        If updateLoadbar Then Game.updateLoadbar(40)

        placePlayer(Game.player)
        placeStairs()
        placeChest(floorCode)
        If floorNumber > 2 Then placeTraps()

        placeNPCs(Game.shopNPCList)
        If updateLoadbar Then Game.updateLoadbar(70)
        verifyNoDisconectedChunks(Game.player)
        If updateLoadbar Then
            Game.updateLoadbar(99)
            Game.boardWorker.CancelAsync()
        End If
    End Sub
    Public Sub New(ByVal save As String)
        loadMFloor(save)
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
        For Each n In Game.shopNPCList
            n.pos = New Point(-1, -1)
        Next


        If floorNumber < 5 Then
            generateDungeonLevel(floorCode)
            If floorNumber = 4 Then placeFloor4TrappedChest(Game.player)
        ElseIf floorNumber = 5 Then
            genBossFloor(Game.player)
        ElseIf floorNumber = 9999 Then
            genSpaceFloor()
        ElseIf floorNumber = 91017 Then
            genLegacyFloor()
        ElseIf floorNumber > 5 Then
            generateForestLevel(floorCode)
        End If
    End Sub
    Sub placeStairs()
        stairs = randPoint()
        mBoard(stairs.Y, stairs.X).ForeColor = Color.FromArgb(45, 45, 45)
        mBoard(stairs.Y, stairs.X).Text = "H"
    End Sub
    Sub placePlayer(ByRef p As Player)
        p.pos = randPoint()
        playerPosition = p.pos
        mBoard(p.pos.Y, p.pos.X).Text = "@"
    End Sub
    Sub placeChest(ByVal code As String)
        'Fill Chest Tier List
        For i = 1 To Game.baseChest.tiers.Count - 1
            Game.baseChest.tiers(i).Clear()
        Next
        For i = 0 To Game.baseChest.contents.upperBound
            Dim c_item = Game.baseChest.contents.item(i)
            If c_item.tier <> Nothing And Not c_item.isMonsterDrop Then
                Game.baseChest.tiers(c_item.tier).Add(c_item)
            End If
        Next
        Rnd(-1)
        Randomize(code.GetHashCode)
        'Dim numChests As Integer = CInt(Int(Rnd() * 8) + 3) * Int((mBoardWidth / 30) + (mBoardHeight / 30) / 2)
        Dim numChests As Integer = CInt((Int(Rnd() * Game.chestFreqRange) + Game.chestFreqMin) * (Math.Sqrt(coveredBoardSpace) / Game.chestSizeDependence))

        Dim r As Integer
        If floorNumber = 3 Then
            numChests *= 1.5
            r = Int(Rnd() * (numChests))
        End If
        For i = 1 To numChests
            Dim chestPoint = randPoint()
            Dim chest As Chest = Game.baseChest.Create(chestPoint, code)
            If r = i Then chest.add(53, 1)
            chestList.Add(chest)
            mBoard(chestPoint.Y, chestPoint.X).ForeColor = Color.FromArgb(45, 45, 45)
            mBoard(chestPoint.Y, chestPoint.X).Text = "#"
        Next
        For Each c In chestList
            mBoard(c.pos.Y, c.pos.X).Text = ""
        Next
    End Sub
    Sub placeTraps()
        trapList.Clear()
        If Game.trapSizeDependence <= 0 Then Game.trapSizeDependence = 1
        Dim numtrap As Integer = CInt(Int(Rnd() * Game.trapFreqRange) + Game.trapFreqMin) * (Math.Sqrt(coveredBoardSpace) / Game.trapSizeDependence)
        For i = 1 To numtrap
            Dim trapPoint = randPoint()
            Dim trap As New Trap(trapPoint)
            trapList.Add(trap)
            mBoard(trapPoint.Y, trapPoint.X).ForeColor = Color.FromArgb(45, 45, 45)
            mBoard(trapPoint.Y, trapPoint.X).Text = "+"
        Next
    End Sub
    Sub placeNPCs(ByRef npcList As List(Of ShopNPC))
        npcPositions.Clear()

        Dim numNpc As Integer = CInt(Int(Rnd() * npcList.Count)) + 1
        If floorNumber = 1 Then numNpc = 1
        Dim placed = New List(Of Integer)

        For i = 1 To numNpc
            Dim npcPoint = randPoint()
            Dim npcInd = Int(Rnd() * npcList.Count)
            While placed.Contains(npcInd) And Not placed.Count >= npcList.Count
                npcInd = Int(Rnd() * npcList.Count)
            End While

            If floorNumber = 1 Then npcInd = 0

            Dim sNPC = npcList(npcInd)

            sNPC.pos = npcPoint


            If floorNumber = 3 Then sNPC.inv.add(53, 1) Else sNPC.inv.item(53).count = 0

            mBoard(npcPoint.Y, npcPoint.X).ForeColor = Color.FromArgb(45, 45, 45)
            mBoard(npcPoint.Y, npcPoint.X).Text = "$"

            placed.Add(npcInd)
        Next

        For i = 0 To npcList.Count - 1
            npcPositions.Add(npcList(i).pos)
        Next
    End Sub
    Sub connectRooms(ByVal p1 As Point, ByVal p2 As Point)
        'Connects the entrances/exits of the rooms
        Dim cursor As Point = p1
        Dim xOry As Boolean = CBool(Int(Rnd() * 2))
        If xOry Then
            If p1.Y < p2.Y Then
                For y = p1.Y To p2.Y
                    If y < mBoardHeight And y > 0 And p1.X < mBoardWidth And p1.X > 0 AndAlso Not mBoard(y, p1.X).Tag = 2 Then
                        mBoard(y, p1.X).Tag = 1
                        coveredBoardSpace += 1
                    End If

                Next
            Else
                For y = p1.Y To p2.Y Step -1
                    If y < mBoardHeight And y > 0 And p1.X < mBoardWidth And p1.X > 0 AndAlso Not mBoard(y, p1.X).Tag = 2 Then
                        mBoard(y, p1.X).Tag = 1
                        coveredBoardSpace += 1
                    End If

                Next
            End If
            If p1.X < p2.X Then
                For x = p1.X To p2.X
                    If x < mBoardWidth And x > 0 And p2.Y < mBoardHeight And p2.Y > 0 AndAlso Not mBoard(p2.Y, x).Tag = 2 Then
                        mBoard(p2.Y, x).Tag = 1
                        coveredBoardSpace += 1
                    End If

                Next
            Else
                For x = p1.X To p2.X Step -1
                    If x < mBoardWidth And x > 0 And p2.Y < mBoardHeight And p2.Y > 0 AndAlso Not mBoard(p2.Y, x).Tag = 2 Then
                        coveredBoardSpace += 1
                        mBoard(p2.Y, x).Tag = 1
                    End If
                Next
            End If
        Else
            If p1.X < p2.X Then
                For x = p1.X To p2.X
                    If x < mBoardWidth And x > 0 And p2.Y < mBoardHeight And p2.Y > 0 AndAlso Not mBoard(p2.Y, x).Tag = 2 Then
                        mBoard(p2.Y, x).Tag = 1
                        coveredBoardSpace += 1
                    End If

                Next
            Else
                For x = p1.X To p2.X Step -1
                    If x < mBoardWidth And x > 0 And p2.Y < mBoardHeight And p2.Y > 0 AndAlso Not mBoard(p2.Y, x).Tag = 2 Then
                        mBoard(p2.Y, x).Tag = 1
                        coveredBoardSpace += 1
                    End If

                Next
            End If
            If p1.Y < p2.Y Then
                For y = p1.Y To p2.Y
                    If y < mBoardHeight And y > 0 And p1.X < mBoardWidth And p1.X > 0 AndAlso Not mBoard(y, p1.X).Tag = 2 Then
                        mBoard(y, p1.X).Tag = 1
                        coveredBoardSpace += 1
                    End If

                Next
            Else
                For y = p1.Y To p2.Y Step -1
                    If y < mBoardHeight And y > 0 And p1.X < mBoardWidth And p1.X > 0 AndAlso Not mBoard(y, p1.X).Tag = 2 Then
                        mBoard(y, p1.X).Tag = 1
                        coveredBoardSpace += 1
                    End If
                Next
            End If
        End If
    End Sub
    Sub verifyNoDisconectedChunks(ByRef p As Player)
        For j = 0 To rooms.Count - 1
            For i = 0 To rooms(j).Count - 1
                Dim r = route(p.pos, rooms(j)(i).topLeftPos)
                If r.Length = 1 Then
                    connectRooms(p.pos, rooms(j)(i).topLeftPos)
                End If
            Next
        Next
    End Sub
    'dungeon floors
    Sub generateDungeonLevel(ByVal code As String)
        'generateLevel creates the random rooms and corridors of each level
        floorCode = code
        Rnd(-1)
        Randomize(code.GetHashCode)

        Dim maxBoardSpace As Integer = mBoardWidth * mBoardHeight
        Dim roomRow As List(Of Room) = New List(Of Room)
        Dim cursor As Point = New Point(0, 5)

        'define all of the rooms
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
                            mBoard(j + y, k + x).Tag = 1
                            coveredBoardSpace += 1
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

        For j = 0 To rooms.Count - 1
            For i = 0 To rooms(j).Count - 1
                'get the room in question
                Dim r = rooms(j)(i)
                Dim potentialNeighbors As List(Of Room) = New List(Of Room)

                'add all possible neighbors
                If i > 0 Then potentialNeighbors.Add(rooms(j)(i - 1))
                If i < rooms(j).Count - 1 Then potentialNeighbors.Add(rooms(j)(i + 1))
                If j > 0 AndAlso i < rooms(j - 1).Count - 1 Then potentialNeighbors.Add(rooms(j - 1)(i))
                If j < rooms.Count - 1 AndAlso i < rooms(j + 1).Count - 1 Then potentialNeighbors.Add(rooms(j + 1)(i))
                'get rid of any previously visited rooms
                Dim markedNeighbors As List(Of Room) = New List(Of Room)
                For k = 0 To potentialNeighbors.Count - 1
                    If potentialNeighbors(k).marked Then markedNeighbors.Add(potentialNeighbors(k))
                Next
                For Each mn In markedNeighbors
                    potentialNeighbors.Remove(mn)
                Next
                If potentialNeighbors.Count = 0 Then Exit For

                'set the number of exits on the room
                Dim numExits = Int(Rnd() * potentialNeighbors.Count) + 1
                Select Case numExits
                    Case 2
                        connectRooms(r.getExit, potentialNeighbors(Int(Rnd() * potentialNeighbors.Count)).getExit)
                        connectRooms(r.getExit, potentialNeighbors(Int(Rnd() * potentialNeighbors.Count)).getExit)
                    Case 3
                        connectRooms(r.getExit, potentialNeighbors(Int(Rnd() * potentialNeighbors.Count)).getExit)
                        connectRooms(r.getExit, potentialNeighbors(Int(Rnd() * potentialNeighbors.Count)).getExit)
                        connectRooms(r.getExit, potentialNeighbors(Int(Rnd() * potentialNeighbors.Count)).getExit)
                    Case 4
                        connectRooms(r.getExit, potentialNeighbors(Int(Rnd() * potentialNeighbors.Count)).getExit)
                        connectRooms(r.getExit, potentialNeighbors(Int(Rnd() * potentialNeighbors.Count)).getExit)
                        connectRooms(r.getExit, potentialNeighbors(Int(Rnd() * potentialNeighbors.Count)).getExit)
                        connectRooms(r.getExit, potentialNeighbors(Int(Rnd() * potentialNeighbors.Count)).getExit)
                    Case Else
                        connectRooms(r.getExit, potentialNeighbors(Int(Rnd() * potentialNeighbors.Count)).getExit)
                End Select

                r.marked = True
            Next
        Next
    End Sub
    'forest floors
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
                        If xP < mBoardWidth And yP < mBoardHeight And xP > 0 And yP > 0 Then mBoard(yP, xP).Tag = 2 'Colour in the square
                    Next
                Next
                'else just colour it
            Else
                For yP = RoomPos.Y To RoomSpanY
                    For xp = RoomPos.X To RoomSpanX
                        If xp < mBoardWidth And yP < mBoardHeight And xp > 0 And yP > 0 Then mBoard(yP, xp).Tag = 1 'Colour in the square
                    Next
                Next
            End If

            Dim numExits As Integer = Int(Rnd() * 3)
            Dim mainExit As Point
            Select Case Int(Rnd() * 2)
                Case 0
                    mainExit = (New Point(RoomPos.X + 2, Int(Rnd() * (RoomSpanY - RoomPos.Y)) + RoomPos.Y))
                    If mainExit.X - 1 < mBoardWidth And mainExit.X - 1 > 0 And mainExit.Y - 1 < mBoardHeight And mainExit.Y - 1 > 0 AndAlso Not mBoard(mainExit.Y, mainExit.X - 1).Tag = 2 Then mBoard(mainExit.Y, mainExit.X - 1).Tag = 1
                Case Else
                    mainExit = (New Point(Int(Rnd() * (RoomSpanX - RoomPos.X)) + RoomPos.X, RoomPos.Y + 2))
                    If mainExit.X - 1 < mBoardWidth And mainExit.X - 1 > 0 And mainExit.Y - 1 < mBoardHeight And mainExit.Y - 1 > 0 AndAlso Not mBoard(mainExit.Y - 1, mainExit.X).Tag = 2 Then mBoard(mainExit.Y - 1, mainExit.X).Tag = 1
            End Select
            If i > 0 Then
                connectRooms(mainExit, exits(exits.Count - 1))
            Else
                exits.Add(mainExit)
            End If
            For n = 1 To numExits
                Select Case Int(Rnd() * 2)
                    Case 0
                        exits.Add(New Point(RoomPos.X + 2, Int(Rnd() * (RoomSpanY - RoomPos.Y)) + RoomPos.Y))
                        If exits.Last.X - 1 < mBoardWidth And exits.Last.X - 1 > 0 And exits.Last.Y - 1 < mBoardHeight And exits.Last.Y - 1 > 0 And
                            exits.Last.X < mBoardWidth And exits.Last.X > 0 And exits.Last.Y < mBoardHeight And exits.Last.Y > 0 AndAlso Not mBoard(exits.Last.Y, exits.Last.X - 1).Tag = 2 Then mBoard(exits.Last.Y, exits.Last.X - 1).Tag = 1
                    Case 1
                        exits.Add(New Point(Int(Rnd() * (RoomSpanX - RoomPos.X)) + RoomPos.X, RoomPos.Y + 2))
                        If exits.Last.X - 1 < mBoardWidth And exits.Last.X - 1 > 0 And exits.Last.Y - 1 < mBoardHeight And exits.Last.Y - 1 > 0 And
                            exits.Last.X < mBoardWidth And exits.Last.X > 0 And exits.Last.Y < mBoardHeight And exits.Last.Y > 0 AndAlso Not mBoard(exits.Last.Y - 1, exits.Last.X).Tag = 2 Then mBoard(exits.Last.Y - 1, exits.Last.X).Tag = 1
                End Select
            Next
        Next

        While exits.Count > 1
            Dim r1 As Integer = Int(Rnd() * exits.Count)
            Dim r2 As Integer = Int(Rnd() * exits.Count)
            Dim r3 As Integer = Int(Rnd() * 3)
            If r1 > r2 Or r3 > 0 Then
                makeDeadEnd(exits(r1), exits)
                exits.RemoveAt(r1)
            Else
                If r1 <> r2 Then
                    connectRooms(exits(r1), exits(r2))
                    exits.RemoveAt(r1)
                    exits.RemoveAt(r2 - 1)
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
                                mBoard(yInd, xInd).Tag = 1
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
                                mBoard(yInd - 1, xInd).Tag = 1
                                tileCount += 1
                            ElseIf yInd + 1 < mBoardHeight AndAlso mBoard(yInd + 1, xInd).Tag = 0 Then
                                mBoard(yInd + 1, xInd).Tag = 1
                                tileCount += 1
                            ElseIf xInd - 1 >= 0 AndAlso mBoard(yInd, xInd - 1).Tag = 0 Then
                                mBoard(yInd, xInd - 1).Tag = 1
                                tileCount += 1
                            ElseIf xInd + 1 < mBoardWidth AndAlso mBoard(yInd, xInd + 1).Tag = 0 Then
                                mBoard(yInd, xInd + 1).Tag = 1
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
                        If y < mBoardHeight And y > 0 And p1.X < mBoardWidth And p1.X > 0 AndAlso Not mBoard(y, p1.X).Tag = 2 Then mBoard(y, p1.X).Tag = 1
                    Next
                Else
                    For y = p1.Y To Int(Rnd() * 8) Step -1
                        If y < mBoardHeight And y > 0 And p1.X < mBoardWidth And p1.X > 0 AndAlso Not mBoard(y, p1.X).Tag = 2 Then mBoard(y, p1.X).Tag = 1
                    Next
                End If
                p1 = New Point(p1.X, y)
            Else
                Dim x As Integer
                If dir Then
                    For x = p1.X To Int(Rnd() * 8)
                        If x < mBoardWidth And x > 0 And p1.Y < mBoardHeight And p1.Y > 0 AndAlso Not mBoard(p1.Y, x).Tag = 2 Then mBoard(p1.Y, x).Tag = 1
                    Next
                Else
                    For x = p1.X To Int(Rnd() * 8) Step -1
                        If x < mBoardWidth And x > 0 And p1.Y < mBoardHeight And p1.Y > 0 AndAlso Not mBoard(p1.Y, x).Tag = 2 Then mBoard(p1.Y, x).Tag = 1
                    Next
                End If
                p1 = New Point(x, p1.Y)
            End If
            Dim cont As Integer = (Int(Rnd() * 35))
            If cont = 11 Or cont = 27 Then exits.Add(p1)
            If cont < 8 Then Exit For
        Next
    End Sub
    'boss floors
    Sub genBossFloor(ByRef p As Player)
        'Creates a straight hallway of a floor for a boss floor
        If mBoardHeight < 30 Then mBoardHeight = 30
        If mBoardWidth < 10 Then mBoardWidth = 10
        For y = 0 To 25
            For x = 3 To 7
                mBoard(y, x).Tag = 2
            Next
        Next
        p.pos = New Point(5, 25)
        stairs = New Point(5, 2)
        If floorNumber = 5 Then genMedusaStatues()
        beatBoss = True
    End Sub

    '|---SPECIFIC FLOOR GENERATION METHODS---|
    'floor 4
    Sub placeFloor4TrappedChest(ByRef p As Player)
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
        Do While (mBoard(pt.Y, pt.X).Tag < 1 Or mBoard(pt.Y, pt.X).Text <> "") And i < possiblePoints.Count
            i += 1
            pt = possiblePoints(i)
        Loop
        Dim c As Chest = New LoadedChest(pt, 4)
        chestList.Add(c)
    End Sub
    'floor 5
    Sub genMedusaStatues()
        'places the statues on floor 5 for ambience
        Randomize()
        Dim numStatues As Integer = Int((Rnd() * 5) + 6)
        For i = 0 To numStatues
            Dim x = Int((Rnd() * 4) + 3)
            Dim y = Int((Rnd() * 15) + 3)
            Dim tr As New Monster()
            tr.pos = New Point(x, y)
            statueList.Add(New Statue(tr))
        Next
    End Sub
    'space floor
    Sub genSpaceFloor()
        Dim floorLayout As String() = {"___________#######___________",
                                       "___________#######___________",
                                       "___________###%###___________",
                                       "___________#######___________",
                                       "___________#######___________",
                                       "__#^##________#______________",
                                       "_######_______#______####____",
                                       "#$#############_____##&###___",
                                       "_######_______############___",
                                       "__##^#________#_____###&##___",
                                       "______________#______####____",
                                       "______________#______________",
                                       "_____________##!_____________",
                                       "_____________#@#_____________",
                                       "_____________###_____________"}

        If mBoardHeight < 15 Then mBoardHeight = 15
        If mBoardWidth < 30 Then mBoardWidth = 30

        For y = 0 To 14
            Dim line = floorLayout(y).ToCharArray
            For x = 0 To UBound(line)
                If Not line(x) = "_"c Then mBoard(y, x).Tag = 1
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
                    Dim trap As New Trap(CStr(x) & "*" & CStr(y) & "*" & CStr(6) & "*")
                    trapList.Add(trap)
                    mBoard(trapPoint.Y, trapPoint.X).ForeColor = Color.FromArgb(45, 45, 45)
                    mBoard(trapPoint.Y, trapPoint.X).Text = "+"
                ElseIf line(x) = "!"c Then
                    Dim trapPoint = New Point(x, y)
                    Dim trap As New Trap(CStr(x) & "*" & CStr(y) & "*" & CStr(5) & "*")
                    trapList.Add(trap)
                    mBoard(trapPoint.Y, trapPoint.X).ForeColor = Color.FromArgb(45, 45, 45)
                    mBoard(trapPoint.Y, trapPoint.X).Text = "+"
                ElseIf line(x) = "@"c Then
                    Game.player.pos = New Point(x, y)
                End If
            Next
        Next
    End Sub
    Sub genSpaceChest1(ByVal p As Point)
        Dim c1 As Chest
        Dim inv = New Inventory(False)

        Dim r = 0
        If Int(Rnd() * 3) = 0 Then r = 1 Else r = 0
        inv.add("Photon_Armor", r)
        If Int(Rnd() * 3) = 0 Then r = 1 Else r = 0
        inv.add("Labcoat", r)
        If Int(Rnd() * 3) = 0 Then r = 1 Else r = 0
        inv.add("Mobile_Powerbank", r)
        If Int(Rnd() * 3) = 0 Then r = 1 Else r = 0
        inv.add("Discharge_Gauntlets", r)
        If Int(Rnd() * 3) = 0 Then r = 1 Else r = 0
        inv.add("Photon_Blade", r)

        inv.add("Space_Age_Jumpsuit", 1)
        c1 = Game.baseChest.Create(inv, p, False)

        chestList.Add(c1)
        mBoard(p.Y, p.X).ForeColor = Color.FromArgb(45, 45, 45)
        mBoard(p.Y, p.X).Text = "#"
    End Sub
    Sub genSpaceChest2(ByVal p As Point)
        Dim c1 As Chest
        Dim inv = New Inventory(False)

        Dim r = 0
        If Int(Rnd() * 3) = 0 Then r = 1 Else r = 0
        inv.add("Shrink_Ray", r)
        If Int(Rnd() * 3) = 0 Then r = 1 Else r = 0
        inv.add("Galaxy_Dye", r)
        If Int(Rnd() * 3) = 0 Then r = 1 Else r = 0
        inv.add("CryoGrenade", r)
        If Int(Rnd() * 3) = 0 Then r = 1 Else r = 0
        inv.add("Combat_Module", r)

        inv.add("Vial_of_BIM_II", 1)
        c1 = Game.baseChest.Create(inv, p, False)

        chestList.Add(c1)
        mBoard(p.Y, p.X).ForeColor = Color.FromArgb(45, 45, 45)
        mBoard(p.Y, p.X).Text = "#"
    End Sub
    'legacy floor
    Sub genLegacyFloor()
        Dim floorLayout As String() = {"_############################",
                                       "____####____________#@#_____#",
                                       "____####____________###_____#",
                                       "____####____________________#",
                                       "#############################",
                                       "#___________########_________",
                                       "#___________###########______",
                                       "#_____________###__#####______",
                                       "#############################",
                                       "______#####___###__#####____#",
                                       "______#####___###__#####____#",
                                       "______##^##___###___________#",
                                       "#############################",
                                       "#_____#####___###____________",
                                       "#_____________#########______",
                                       "#_____________#########______",
                                       "##################%##########",
                                       "______________#########_____#",
                                       "______________#########______"}

        If mBoardHeight < 19 Then mBoardHeight = 19
        If mBoardWidth < 30 Then mBoardWidth = 30

        For y = 0 To 18
            Dim line = floorLayout(y).ToCharArray
            For x = 0 To UBound(line)
                If Not line(x) = "_"c Then mBoard(y, x).Tag = 1
                If line(x) = "%"c Then
                    stairs = New Point(x, y)
                ElseIf line(x) = "^"c Then
                    Dim chestPoint = New Point(x, y)
                    genLegacyChest(chestPoint)
                ElseIf line(x) = "@"c Then
                    Game.player.pos = New Point(x, y)
                End If
            Next
        Next
    End Sub
    Sub genLegacyChest(ByVal p As Point)
        Dim c1 As Chest
        Dim inv = New Inventory(False)

        inv.add("Chicken_Suit", 1)

        c1 = Game.baseChest.Create(inv, p, False)

        chestList.Add(c1)
        mBoard(p.Y, p.X).ForeColor = Color.FromArgb(45, 45, 45)
        mBoard(p.Y, p.X).Text = "#"
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
                dist(i, j) = 99999
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
                Dim tDist = dist(min.Y, min.X) + distance(min, p)
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
        path.RemoveAt(0)
        Return path.ToArray
    End Function
    Function distance(ByVal x As Point, ByVal y As Point) As Double
        'the straight-line distance between two points
        Return Math.Abs(Math.Sqrt(CDbl((y.X - x.X) ^ 2) + CDbl((y.Y - x.Y) ^ 2)))
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
    Shared Function withinOnePlusMinus(ByVal p1 As Point, ByVal pList As List(Of Point)) As Boolean
        'indicates whether a point is within plus/minus one space of another in a list of points
        For Each p In pList
            If p.X + 1 = p1.X Or p.X - 1 = p1.X Then Return True
            If p.Y + 1 = p1.Y Or p.Y - 1 = p1.Y Then Return True
        Next
        Return False
    End Function
    Function getTile(ByVal y As Integer, ByVal x As Integer) As mTile
        Return mBoard(y, x)
    End Function

    '|---SERIALIZATION METHODS---|
    Function saveMFloor() As String
        Dim out = "floornumber" & floorNumber & "%"

        out += floorNumber & "%"                '1
        out += floorCode & "%"                  '2
        out += mBoardHeight & "%"               '3
        out += mBoardWidth & "%"                '4

        out += "traps%"
        out += trapList.Count - 1 & "%"         '6
        For i = 0 To trapList.Count - 1
            out += trapList(i).ToString & "%"   '7 to 6 + traplist.Count
        Next

        out += "statues%"
        out += statueList.Count - 1 & "%"       '8 + traplist.Count
        For i = 0 To statueList.Count - 1
            out += statueList(i).ToString & "%" '9 + traplist.Count to 8 + traplist.Count + statueList.Count
        Next

        out += "chest%"
        out += chestList.Count - 1 & "%"        '10 + traplist.Count + statueList.Count
        For i = 0 To chestList.Count - 1
            If chestList(i).GetType Is GetType(LoadedChest) Then
                chestList(i).pos = New Point(-1, -1)  'LoadedChests are not saved
            End If
            out += chestList(i).ToString & "%"  '11 + traplist.Count + statueList.Count to 10 + traplist.Count + statueList.Count + chestList.Count
        Next

        out += "beatboss%"
        out += beatBoss & "%"                   '12 + traplist.Count + statueList.Count + chestList.Count

        out += "stairs%"
        out += stairs.X & "%"                   '14 + traplist.Count + statueList.Count + chestList.Count
        out += stairs.Y & "%"                   '15 + traplist.Count + statueList.Count + chestList.Count

        out += "playerpos%"
        out += playerPosition.X & "%"           '17 + traplist.Count + statueList.Count + chestList.Count
        out += playerPosition.Y & "%"           '18 + traplist.Count + statueList.Count + chestList.Count

        out += "NPCpos%"
        out += CStr(npcPositions.Count - 1) & "%" '20 + traplist.Count + statueList.Count + chestList.Count
        For i = 0 To npcPositions.Count - 1
            out += npcPositions(i).X & "~"
            out += npcPositions(i).X & "%"      '21 + traplist.Count + statueList.Count + chestList.Count to 20 + traplist.Count + statueList.Count + chestList.Count + npcPositions.Count
        Next

        out += "boardtags%"
        For y = 0 To mBoardHeight - 1
            For x = 0 To mBoardWidth - 1
                out += mBoard(y, x).Tag & "%"   '22 + traplist.Count + statueList.Count + chestList.Count + npcPositions.Count
            Next
        Next

        Return out
    End Function
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
            trapList.Add(New Trap(buffer(7 + i)))
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

        coveredBoardSpace = 0
        For y = 0 To mBoardHeight - 1
            For x = 0 To mBoardWidth - 1
                Dim i = (y * mBoardWidth) + x
                mBoard(y, x).Tag = CInt(buffer(22 + trapList.Count + statueList.Count + chestList.Count + npcPositions.Count + i))
                If mBoard(y, x).Tag > 0 Then coveredBoardSpace += 1
            Next
        Next
    End Sub
End Class

Public Class Room
    Public topLeftPos As Point
    Public width, height As Integer
    Public marked As Boolean = False
    Dim exits As List(Of Point) = New List(Of Point)
    Public Sub New(tlp As Point, w As Integer, h As Integer)
        topLeftPos = tlp
        width = w
        height = h
    End Sub
    Public Function getExit() As Point
        Dim p As Point = Nothing
        Dim ct = 0
        While (p = Nothing Or mFloor.withinOnePlusMinus(p, exits)) And ct < 12
            Select Case Int(Rnd() * 4)
                Case 0
                    p = New Point(topLeftPos.X, topLeftPos.Y + Int(Rnd() * height))
                Case 1
                    p = New Point(topLeftPos.X + width, topLeftPos.Y + Int(Rnd() * height))
                Case 2
                    p = New Point(topLeftPos.X + Int(Rnd() * width), topLeftPos.Y)
                Case Else
                    p = New Point(topLeftPos.X + Int(Rnd() * width), topLeftPos.Y + height)
            End Select
            ct += 1
        End While

        exits.Add(p)
        Return p
    End Function
End Class
