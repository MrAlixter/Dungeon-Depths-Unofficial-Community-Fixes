Public Class Game
    'Form1 is the main driver form that runs the game

    'board instance variables
    Public mBoardWidth As Integer = 50
    Public mBoardHeight As Integer = 40
    Public mBoard(,) As mTile
    Public mPics(,) As PictureBox       '(NOT SAVED)
    Public floor As Integer = 0
    Public stairs As Point

    Public player As Player = New Player()

    Public baseChest As Chest = New Chest(player.inventory.Count - 1)
    Public chestList As ArrayList = New ArrayList()
    Public statueList As ArrayList = New ArrayList()    '(NOT SAVED)
    Public trapList As ArrayList = New ArrayList()
    'player instance variables
    Public updatelist As PQ = New PQ
    Public shopkeeper As NPC
    Public npcList As ArrayList = New ArrayList()     'list of non-player updatables (NOT SAVED)
    Public currNPC As NPC   'the current npc the player is talking to (NOT SAVED)
    Public pImage As Image  'which tile is used for the player (NOT SAVED)
    Public combatmode As Boolean = True 'indicates if the player is in combat (NOT SAVED)
    Public npcmode As Boolean = False   'indicates if the player is talking to an npc (NOT SAVED)
    Public npcIndex As Integer = 0  'indicates which npc is encountered (NOT SAVED)
    'a list containing all valid cheats
    Public cheatList() As String = {"girl", "nude", "blue", "catc", "bmbo", "bigr", "slut", "kill", "dick", "lust", "form", "tfme",
                                    "gogo", "mana", "fuse", "rock", "doll"} 'list of cheats (NOT SAVES)
    Public isMark As Boolean = False    'indicates if the 'mark' cheat code has been used. (NOT SAVED)
    Dim keyspresed As String = ""   'records last 4 keys pressed (NOT SAVED)
    'variables related to the mystery potions
    Public Potions As New ArrayList()
    'Public OHPotionNames() As String = {"Red_Potion", "Green_Potion", "Blue_Potion", "Yellow_Potion", "Glowing_Potion", "Murky_Potion", "Purple_Potion"} '"Clear_Potion", "Smokey_Potion"}
    'Public HPotionNames() As String = OHPotionNames.Clone()
    'Dim APotionNames() As String = {"Blonde_Potion", "Red_Hair_Potion", "Black_Hair_Potion", "Feminine_Potion", "Breast_Enlarging_Potion", "Masculine_Potion", "Breast_Shrinking_Potion"} '"Weakness_Potion", "Shrink_Potion", "Snake_Potion"}
    'save lists of the players polymorph forms
    '      self      enemy
    Public formList, tFormList As New ArrayList()
    'other misc form1 instance variables
    Dim selectedItem As Item    'the item hilighted in the inventory (NOT SAVED)
    Dim monsterTier1() As Integer = {0, 1, 2}
    Dim monsterTier2() As Integer = {0, 1, 2, 3}
    Public turn As Integer = 0  '(NOT SAVED)
    Public beatboss() As Boolean = {False, False, False, False, False}  'which bosses have been beat?
    Dim floorboss() As String = {"Floor0", "Marissa the Enchantress", "Targax the Brutal", "Key"} 'boss names (NOT SAVED)
    Dim floorLayouts As ArrayList = New ArrayList()
    Public version As Double = 0.5      'the save file version
    Public lblEventOnClose As Action    'the event method preformed when lblEvent closes (NOT SAVED)
    Public invFilters() As Boolean = {True, True, True, True, True, True}
    Dim eClock As Integer = 15
    Public solFlag As Boolean = False
    'startup/new level methods
    'Form1_Load handles the loading of the form
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        loadPotionList()
        'sets the player tile image to the default @
        pImage = picPlayer.BackgroundImage
        'scales the font size to that of the window
        Dim newFont As Font = New System.Drawing.Font("Consolas", CInt(8 * Me.Size.Width / 688))
        For i = 0 To Me.Controls.Count - 1
            Me.Controls(i).Font = newFont
        Next
            FileToolStripMenuItem.Font = newFont
            SaveToolStripMenuItem.Font = newFont
            LoadToolStripMenuItem.Font = newFont
            HelpToolStripMenuItem.Font = newFont
            HelpToolStripMenuItem1.Font = newFont
            InfoToolStripMenuItem.Font = newFont
            newFont = New System.Drawing.Font("Consolas", CInt(9.25 * Me.Size.Width / 688), FontStyle.Underline)
            lblNameTitle.Font = newFont
            newFont = New System.Drawing.Font("Consolas", CInt(7 * Me.Size.Width / 688))
            btnDrop.Font = newFont
            btnLook.Font = newFont
            newFont = New System.Drawing.Font("Consolas", CInt(9 * Me.Size.Width / 688))
        MenuStrip1.Font = newFont
        For i = 0 To pnlCombat.Controls.Count - 1
            pnlCombat.Controls(i).Font = newFont
        Next
            'creates the shopkeeper
            shopkeeper = New NPC(2)

            If Not System.IO.File.Exists("dis.cla") Then
                If MessageBox.Show("This game features adult content sexual in nature, and is not for anyone under the age of 18 or otherwise of legal age in their country. By clicking 'Yes' below, you confirm that you are legally an adult in your country.", "Obligatory Disclaimer", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    System.IO.File.CreateText("dis.cla")
                Else
                    Me.Close()
                End If
            End If
    End Sub
    Sub loadPotionList()
        Randomize()
        Dim HiddenNames As ArrayList = New ArrayList({"Red_Potion", "Green_Potion", "Blue_Potion", "Yellow_Potion", "Glowing_Potion", "Murky_Potion", "Purple_Potion", "Clear_Potion", "Smokey_Potion"})
        Dim index As Integer = 0
        For i = 0 To player.inventory.Count - 1
            If player.inventory(i).GetType().IsSubclassOf(GetType(MysteryPotion)) Then
                Potions.Add(player.inventory(i))
                index = Int(Rnd() * (HiddenNames.Count - 1))
                CType(player.inventory(i), MysteryPotion).setName(HiddenNames(index))
                HiddenNames.RemoveAt(index)
            End If
        Next
    End Sub
    Sub loadPotionListFromFile()
        For i = 0 To player.inventory.Count - 1
            If player.inventory(i).GetType().IsSubclassOf(GetType(MysteryPotion)) Then
                CType(player.inventory(i), MysteryPotion).setName(Potions(0).getName())
                Potions.RemoveAt(0)
            End If
        Next
    End Sub
    'newGame prepares the application at the start of a new game
    Sub newGame()
        combatmode = False
        btnS.Visible = False
        btnL.Visible = False
        btnControls.Visible = False
        Dim chargen As New CharacterGenerator
        chargen.currSex = player.sexBool
        chargen.ShowDialog()
        If chargen.quit Then
            btnS.Visible = True
            btnL.Visible = True
            btnControls.Visible = True
            Exit Sub
        End If
        picPortrait.BackgroundImage = chargen.ExportIMG()
        chargen.Dispose()
        Dim int As Integer = 100 - player.getSpeed
        If int < 1 Then int = 1
        updatelist.add(player, int)

        'Fill Chest Tier List
        For i = 0 To player.inventory.Count - 1
            If player.inventory(i).tier <> Nothing Then
                baseChest.tiers(player.inventory(i).tier).Add(player.inventory(i))
            End If
        Next

        floorLayouts.Add("placeholder")
        floorLayouts.Add(genRNDLVLCode())
        floorLayouts.Add(genRNDLVLCode())
        floorLayouts.Add(genRNDLVLCode())
        initializeBoard()

        'potion name shuffle
        '[DEPRECATED]
        'THIS HAS BEEN MOVED TO THE CREATION OF THE POTION LIST IN loadPotionList()
        'ShuffleArray(HPotionNames)
        'For i = 0 To UBound(HPotionNames)
        '    'TODO
        '    'MAKE POTIONS ADJUST THEIR NAMES CORRECTLY, NO MATTER WHERE THEY ARE IN THE INVENTORY
        '    'Make potion array? 

        '    If i < 5 Then
        '        player.inventory(25 + i).setName(HPotionNames(i))
        '        player.inventorynames(25 + i) = HPotionNames(i)
        '    Else
        '        Select Case i
        '            Case 5
        '                player.inventory(59).setName(HPotionNames(i))
        '                player.inventorynames(59) = HPotionNames(i)
        '        End Select
        '    End If
        'Next

        player.currState = New State(player)
        player.sState = New State(player)
        player.pState = New State(player)

        turn = 0
        lstLog.Items.Add("You see before you a dungeon.")
        picStart.Visible = False
        Equipment.portraitUDate()
        player.UIupdate()
        lstLog.TopIndex = lstLog.Items.Count - 1
    End Sub
    'initializeBoard increments the floor count, and generates the next level
    Private Sub initializeBoard()
        floor += 1
        newBoard()
        If floor < 4 Then
            generateLevel(floorLayouts(floor))
        Else
            generateLevel(genRNDLVLCode())
        End If
        drawBoard()
    End Sub
    'newBoard disposes of the old board and its graphical representation
    Sub newBoard()
        If floor > 5 Then
            If player.title.Equals("Bimbo") Then
                player.pImage = picBimbof.BackgroundImage
            Else
                player.pImage = picPlayerf.BackgroundImage
            End If
            pImage = player.pImage
            player.currState.save(player)
        End If
        chestList.Clear()
        statueList.Clear()
        npcList.Clear()
        Dim yInd, xInd As Integer
        Dim Margin As Integer = 3
        Dim XSize As Integer = 15 * (Me.Size.Width / 688)
        Dim YSize As Integer = 15 * (Me.Size.Width / 688)
        'clear the old board
        If Not mBoard Is Nothing Then
            For i = 0 To mBoardHeight - 1
                For j = 0 To mBoardWidth - 1
                    mBoard(i, j).Dispose()
                    If j <= 23 And i <= 15 Then
                        mPics(i, j).Dispose()
                    End If
                Next
            Next
        End If
        'increase the board size slightly on floors after 3
        If floor > 2 And mBoardHeight < 40 Then
            mBoardHeight += 1
            mBoardWidth += 2
        End If
        'create all of  the board lables dynamacly at runtime
        ReDim mBoard(mBoardHeight - 1, mBoardWidth - 1)
        ReDim mPics(15, 23)
        For yInd = 0 To mBoardHeight - 1
            For xInd = 0 To mBoardWidth - 1
                mBoard(yInd, xInd) = New mTile(0, "", Color.Black)
                If xInd <= 23 And yInd <= 15 Then
                    Dim newPicture As PictureBox = New PictureBox()
                    newPicture.BackgroundImageLayout = ImageLayout.Stretch
                    newPicture.Size = New Point(YSize * 1.25, XSize * 1.25)
                    newPicture.Location = New Point(60 + xInd * (XSize * 1.25), 75 + yInd * (YSize * 1.25))
                    newPicture.Visible = True
                    Me.Controls.Add(newPicture)
                    mPics(yInd, xInd) = newPicture
                End If
            Next xInd
        Next yInd
    End Sub
    'generateLevel creates the random rooms and corridors of each level
    Function genRNDLVLCode() As String
        Dim numLetters As String = "abcdefghijklmnopqrstuvwxyz123456789"
        Dim output As String = ""
        Randomize()
        For i = 0 To 8
            output += numLetters.Substring(Int(Rnd() * numLetters.Length), 1)
        Next
        Return output
    End Function
    Sub generateLevel(ByVal code As String)
        Rnd(-1)
        Randomize(code.GetHashCode)
        Dim numRooms As Integer = CInt(Int(Rnd() * 15) + 1) * Int(2.25 * mBoardWidth / 30)
        Dim exits As List(Of Point) = New List(Of Point)
        For i = 0 To numRooms
            Dim roomsizecurve As Integer() = {3, 3, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6, 7, 7, 7, 8, 8, 9, 12}
            Dim roomY As Integer = roomsizecurve(CInt(Int(Rnd() * roomsizecurve.Length)))
            Dim roomX As Integer = roomsizecurve(CInt(Int(Rnd() * roomsizecurve.Length)))
            Dim pos As Point = New Point(CInt(Int(Rnd() * mBoardWidth)), CInt(Int(Rnd() * (mBoardHeight - 1))))
            Dim yBound As Integer = pos.Y + roomY
            Dim xBound As Integer = pos.X + roomX
            If yBound >= mBoardHeight - 1 Then yBound = mBoardHeight - 1
            If yBound < 0 Then yBound = 0
            If xBound >= mBoardWidth Then xBound = mBoardWidth - 1
            If xBound < 0 Then xBound = 0

            For yP = pos.Y To yBound
                For xP = pos.X To xBound
                    mBoard(yP, xP).Tag = 1
                Next
            Next

            Dim numExits As Integer = Int(Rnd() * 3)
            Dim mainExit As Point
            Select Case Int(Rnd() * 2)
                Case 0
                    mainExit = (New Point(pos.X + 2, Int(Rnd() * (yBound - pos.Y)) + pos.Y))
                    If mainExit.X - 1 < mBoardWidth And mainExit.X - 1 > 0 Then mBoard(mainExit.Y, mainExit.X - 1).Tag = 1
                Case Else
                    mainExit = (New Point(Int(Rnd() * (xBound - pos.X)) + pos.X, pos.Y + 2))
                    If mainExit.Y - 1 < mBoardHeight And mainExit.Y - 1 > 0 Then mBoard(mainExit.Y - 1, mainExit.X).Tag = 1
            End Select
            If i > 0 Then
                connectRooms(mainExit, exits(exits.Count - 1))
            Else
                exits.Add(mainExit)
            End If
            For n = 1 To numExits
                Select Case Int(Rnd() * 2)
                    Case 0
                        exits.Add(New Point(pos.X + 2, Int(Rnd() * (yBound - pos.Y)) + pos.Y))
                        If exits.Last.X - 1 < mBoardWidth And exits.Last.X - 1 > 0 Then mBoard(exits.Last.Y, exits.Last.X - 1).Tag = 1
                    Case 1
                        exits.Add(New Point(Int(Rnd() * (xBound - pos.X)) + pos.X, pos.Y + 2))
                        If exits.Last.Y - 1 < mBoardHeight And exits.Last.Y - 1 > 0 Then mBoard(exits.Last.Y - 1, exits.Last.X).Tag = 1
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
        Dim playerX As Integer
        Dim playerY As Integer
        Do While (mBoard(playerY, playerX).Tag <> 1)
            playerX = CInt(Int(Rnd() * mBoardWidth))
            playerY = CInt(Int(Rnd() * mBoardHeight))
        Loop
        mBoard(playerY, playerX).Text = "@"
        player.pos = New Point(playerX, playerY)

        placeStairs()
        placeChest(code)
        If floor > 2 Then placeTraps()
        placeNPCs()
    End Sub
    Sub connectRooms(ByVal p1 As Point, ByVal p2 As Point)
        Dim cursor As Point = p1
        Dim xOry As Boolean = CBool(Int(Rnd() * 2))
        If xOry Then
            If p1.Y < p2.Y Then
                For y = p1.Y To p2.Y
                    If y < mBoardHeight And y > 0 And p1.X < mBoardWidth And p1.X > 0 Then mBoard(y, p1.X).Tag = 1
                Next
            Else
                For y = p1.Y To p2.Y Step -1
                    If y < mBoardHeight And y > 0 And p1.X < mBoardWidth And p1.X > 0 Then mBoard(y, p1.X).Tag = 1
                Next
            End If
            If p1.X < p2.X Then
                For x = p1.X To p2.X
                    If x < mBoardWidth And x > 0 And p2.Y < mBoardHeight And p2.Y > 0 Then mBoard(p2.Y, x).Tag = 1
                Next
            Else
                For x = p1.X To p2.X Step -1
                    If x < mBoardWidth And x > 0 And p2.Y < mBoardHeight And p2.Y > 0 Then mBoard(p2.Y, x).Tag = 1
                Next
            End If
        Else
            If p1.X < p2.X Then
                For x = p1.X To p2.X
                    If x < mBoardWidth And x > 0 And p2.Y < mBoardHeight And p2.Y > 0 Then mBoard(p2.Y, x).Tag = 1
                Next
            Else
                For x = p1.X To p2.X Step -1
                    If x < mBoardWidth And x > 0 And p2.Y < mBoardHeight And p2.Y > 0 Then mBoard(p2.Y, x).Tag = 1
                Next
            End If
            If p1.Y < p2.Y Then
                For y = p1.Y To p2.Y
                    If y < mBoardHeight And y > 0 And p1.X < mBoardWidth And p1.X > 0 Then mBoard(y, p1.X).Tag = 1
                Next
            Else
                For y = p1.Y To p2.Y Step -1
                    If y < mBoardHeight And y > 0 And p1.X < mBoardWidth And p1.X > 0 Then mBoard(y, p1.X).Tag = 1
                Next
            End If
        End If
    End Sub
    Sub makeDeadEnd(ByVal p1 As Point, ByRef exits As List(Of Point))
        Dim xOry As Boolean = CBool(Int(Rnd() * 2))
        Dim dir As Boolean = CBool(Int(Rnd() * 2))
        For i = 0 To 6
            If xOry Then
                Dim y As Integer
                If dir Then
                    For y = p1.Y To Int(Rnd() * 8)
                        If y < mBoardHeight And y > 0 And p1.X < mBoardWidth And p1.X > 0 Then mBoard(y, p1.X).Tag = 1
                    Next
                Else
                    For y = p1.Y To Int(Rnd() * 8) Step -1
                        If y < mBoardHeight And y > 0 And p1.X < mBoardWidth And p1.X > 0 Then mBoard(y, p1.X).Tag = 1
                    Next
                End If
                p1 = New Point(p1.X, y)
            Else
                Dim x As Integer
                If dir Then
                    For x = p1.X To Int(Rnd() * 8)
                        If x < mBoardWidth And x > 0 And p1.Y < mBoardHeight And p1.Y > 0 Then mBoard(p1.Y, x).Tag = 1
                    Next
                Else
                    For x = p1.X To Int(Rnd() * 8) Step -1
                        If x < mBoardWidth And x > 0 And p1.Y < mBoardHeight And p1.Y > 0 Then mBoard(p1.Y, x).Tag = 1
                    Next
                End If
                p1 = New Point(x, p1.Y)
            End If
            Dim cont As Integer = (Int(Rnd() * 20))
            If cont = 11 Then exits.Add(p1)
            If cont < 8 Then Exit For
        Next
    End Sub
    Sub printBoard()
        Dim writer As IO.StreamWriter
        writer = IO.File.CreateText("bo.ard")
        For y = 0 To mBoardHeight - 1
            Dim line As String = ""
            For x = 0 To mBoardWidth - 1
                Select Case mBoard(y, x).Tag
                    Case 0
                        line += " "
                    Case Else
                        line += "#"
                End Select
            Next
            writer.WriteLine(line)
        Next
        writer.Flush()
        writer.Close()
    End Sub


    'placeStairs, placeChest, placeTraps, and placeNPCs place their respective entities on mBoard
    Sub placeStairs()
        Dim stairsX As Integer
        Dim stairsY As Integer
        Do While (mBoard(stairsY, stairsX).Tag <> 1 Or mBoard(stairsY, stairsX).Text <> "")
            stairsX = CInt(Int(Rnd() * mBoardWidth))
            stairsY = CInt(Int(Rnd() * mBoardHeight))
        Loop
        stairs = New Point(stairsX, stairsY)
        mBoard(stairsY, stairsX).ForeColor = Color.FromArgb(45, 45, 45)
        mBoard(stairsY, stairsX).Text = "H"
    End Sub
    Sub placeChest(ByVal code As String)
        Randomize(code.GetHashCode)
        Dim numChests As Integer = CInt(Int(Rnd() * 8) + 3) * Int(mBoardWidth / 30)
        Dim r As Integer
        If floor = 3 Then
            numChests *= 1.5
            r = Int(Rnd() * (numChests))
        End If
        For i = 1 To numChests
            Dim chestX As Integer = CInt(Int(Rnd() * mBoardWidth))
            Dim chestY As Integer = CInt(Int(Rnd() * mBoardHeight))
            Do While (mBoard(chestY, chestX).Tag <> 1 Or mBoard(chestY, chestX).Text <> "")
                chestX = CInt(Int(Rnd() * mBoardWidth))
                chestY = CInt(Int(Rnd() * mBoardHeight))
            Loop
            Dim chest As Chest = baseChest.Create(chestX, chestY, code)
            If r = i Then chest.add(53, 1)
            chestList.Add(chest)
            mBoard(chestY, chestX).ForeColor = Color.FromArgb(45, 45, 45)
            mBoard(chestY, chestX).Text = "#"
        Next
    End Sub
    Sub placeTraps()
        trapList.Clear()
        Dim numtrap As Integer = CInt(Int(Rnd() * 5) + 3) * Int(mBoardWidth / 30)
        For i = 1 To numtrap
            Dim trapX As Integer = CInt(Int(Rnd() * mBoardWidth))
            Dim trapY As Integer = CInt(Int(Rnd() * mBoardHeight))
            Do While (mBoard(trapY, trapX).Tag <> 1 Or mBoard(trapY, trapX).Text <> "")
                trapX = CInt(Int(Rnd() * mBoardWidth))
                trapY = CInt(Int(Rnd() * mBoardHeight))
            Loop
            Dim trap As New Trap(New Point(trapX, trapY), Int(Rnd() * 4))
            trapList.Add(trap)
            mBoard(trapY, trapX).ForeColor = Color.FromArgb(45, 45, 45)
            mBoard(trapY, trapX).Text = "+"
        Next
    End Sub
    Sub placeNPCs()
        Dim numNpc As Integer = CInt(Int(Rnd() * 1))
        For i = 0 To numNpc
            Dim npcX As Integer = CInt(Int(Rnd() * mBoardWidth))
            Dim npcY As Integer = CInt(Int(Rnd() * mBoardHeight))
            Do While (mBoard(npcY, npcX).Tag <> 1 Or mBoard(npcY, npcX).Text <> "")
                npcX = CInt(Int(Rnd() * mBoardWidth))
                npcY = CInt(Int(Rnd() * mBoardHeight))
            Loop
            Select Case numNpc
                Case 0
                    shopkeeper.pos = New Point(npcX, npcY)
                    If floor = 3 Then shopkeeper.inventory(53) += 1 Else shopkeeper.inventory(53) = 0
            End Select
            mBoard(npcY, npcX).ForeColor = Color.FromArgb(45, 45, 45)
            mBoard(npcY, npcX).Text = "$"
        Next
    End Sub

    'board draw methods
    'drawBoard updates the board with the players action
    Sub drawBoard()
        '"discover" any hidden tiles adjacent to the player and erase the players last location
        viewBubble()
        'moves down the priority que by the updatable's speed
        If pnlCombat.Visible = True Then lblCombatEvents.Text = ""
        Do While updatelist.isEmpty() = False
            Dim u As Updatable = updatelist.remove()
            u.update()
        Loop
        'updates the combat banner
        If combatmode Then updatePnlCombat(player, player.currTarget)

        'fills in any missing spaces
        If mBoard(stairs.Y, stairs.X).Text <> "H" Then
            mBoard(stairs.Y, stairs.X).Text = "H"
        End If
        If chestList.Count > 0 Then
            For i = 0 To chestList.Count - 1
                If mBoard(chestList.Item(i).pos.Y, chestList.Item(i).pos.X).Text <> "#" Then
                    mBoard(chestList.Item(i).pos.Y, chestList.Item(i).pos.X).Text = "#"
                End If
            Next
        End If
        If statueList.Count > 0 Then
            For i = 0 To statueList.Count - 1
                If mBoard(statueList.Item(i).pos.Y, statueList.Item(i).pos.X).Text <> "@" Then
                    mBoard(statueList.Item(i).pos.Y, statueList.Item(i).pos.X).Text = "@"
                End If
            Next
        End If
        If Not shopkeeper.dead And shopkeeper.pos.X > 0 And shopkeeper.pos.Y > 0 Then
            mBoard(shopkeeper.pos.Y, shopkeeper.pos.X).Text = "$"
        End If
        If mBoard(player.pos.Y, player.pos.X).Text = "+" Then
            For i = 0 To trapList.Count - 1
                If trapList(i).pos = player.pos Then
                    trapList(i).activate()
                    Exit For
                End If
            Next
        End If

        mBoard(player.pos.Y, player.pos.X).Text = "@"

        zoom()

        If floor < 3 AndAlso beatboss(floor) = False And (floor <> 3 And floor <> 4) And combatmode = False AndAlso New Point(player.pos.Y, player.pos.X).Equals(New Point(stairs.Y, stairs.X)) Then btnChallengeBoss.Visible = True Else btnChallengeBoss.Visible = False
        'If picNPC.Visible Then picNPC.BackgroundImage = NPCimgList(npcIndex)

        player.UIupdate()
        lstLog.TopIndex = lstLog.Items.Count - 1
    End Sub
    'viewBubble "discovers" the area around the player and erases the players previous location
    Sub viewBubble()
        For indY = -1 To 1
            For indX = -1 To 1
                If player.pos.Y + indY < mBoardHeight And player.pos.Y + indY >= 0 And player.pos.X + indX < mBoardWidth And player.pos.X + indX >= 0 Then
                    If mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "@" Then mBoard(player.pos.Y + indY, player.pos.X + indX).Text = ""
                    If mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "H" And mBoard(player.pos.Y + indY, player.pos.X + indX).Tag < 2 Then
                        mBoard(player.pos.Y + indY, player.pos.X + indX).ForeColor = Color.Black
                        lstLog.Items.Add("Floor " & floor & ": Staircase Discovered")
                    End If
                    If mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "#" And mBoard(player.pos.Y + indY, player.pos.X + indX).Tag < 2 Then
                        mBoard(player.pos.Y + indY, player.pos.X + indX).ForeColor = Color.Black
                        lstLog.Items.Add("Chest discovered!")
                    End If
                    If mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "$" And mBoard(player.pos.Y + indY, player.pos.X + indX).Tag < 2 Then
                        mBoard(player.pos.Y + indY, player.pos.X + indX).ForeColor = Color.Navy
                        lstLog.Items.Add("Shop discovered!")
                    End If
                    If mBoard(player.pos.Y + indY, player.pos.X + indX).Tag = 1 Then mBoard(player.pos.Y + indY, player.pos.X + indX).Tag = 2
                End If
            Next
        Next
        lstLog.TopIndex = lstLog.Items.Count - 1
    End Sub
    'zoom interperates the data around the player from mBoard, and displays it on mPics
    Sub zoom()
        'tile IDs
        '0 = Wall/Empty tile
        '1 = Undiscovered tile
        '2 = Discovered tile
        '3 = stairs
        '4 = player
        '5 = Chest
        '6 = shopkeeper
        '7 = statue
        '8 = trap
        Dim viewArray(15, 23) As Integer
        Dim x As Integer = 0
        Dim y As Integer = 0
        For indY = -7 To 7
            x = 0
            For indX = -11 To 11
                If (player.pos.Y + indY >= 0 And player.pos.Y + indY < mBoardHeight) And (player.pos.X + indX >= 0 And player.pos.X + indX < mBoardWidth) Then
                    viewArray(y, x) = mBoard(player.pos.Y + indY, player.pos.X + indX).Tag
                    If mBoard(player.pos.Y + indY, player.pos.X + indX).Tag = 2 Then
                        If mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "" Then viewArray(y, x) = 2
                        If mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "H" Then viewArray(y, x) = 3
                        If mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "#" Then viewArray(y, x) = 5
                        If mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "$" Then viewArray(y, x) = 6
                        If mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "+" Then viewArray(y, x) = 8
                    End If
                    If mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "@" Then
                        If indY = 0 And indX = 0 Then viewArray(y, x) = 4 Else viewArray(y, x) = 7
                    End If
                Else
                    viewArray(y, x) = 0
                End If
                If floor < 6 Then
                    Select Case viewArray(y, x)
                        Case 0
                            'MsgBox(x & " " & y)
                            mPics(y, x).BackgroundImage = Nothing
                            mPics(y, x).BackColor = Color.Black
                        Case 1
                            mPics(y, x).BackgroundImage = picFog.BackgroundImage
                        Case 2
                            mPics(y, x).BackgroundImage = picTile.BackgroundImage
                        Case 3
                            mPics(y, x).BackgroundImage = picStairs.BackgroundImage
                        Case 4
                            mPics(y, x).BackgroundImage = pImage
                        Case 5
                            mPics(y, x).BackgroundImage = picChest.BackgroundImage
                        Case 6
                            mPics(y, x).BackgroundImage = picShopkeepTile.BackgroundImage
                        Case 7
                            mPics(y, x).BackgroundImage = picStatue.BackgroundImage
                        Case 8
                            mPics(y, x).BackgroundImage = picTrap.BackgroundImage
                    End Select
                Else
                    Select Case viewArray(y, x)
                        Case 0
                            mPics(y, x).BackgroundImage = picTree.BackgroundImage
                        Case 1
                            mPics(y, x).BackgroundImage = picFog.BackgroundImage
                        Case 2
                            mPics(y, x).BackgroundImage = picTileF.BackgroundImage
                        Case 3
                            mPics(y, x).BackgroundImage = picLadderf.BackgroundImage
                        Case 4
                            mPics(y, x).BackgroundImage = pImage
                        Case 5
                            mPics(y, x).BackgroundImage = picChestf.BackgroundImage
                        Case 6
                            mPics(y, x).BackgroundImage = picShopkeeperf.BackgroundImage
                        Case 7
                            mPics(y, x).BackgroundImage = picStatuef.BackgroundImage
                        Case 8
                            mPics(y, x).BackgroundImage = picTrapf.BackgroundImage
                    End Select
                End If
                x += 1
            Next
            y += 1
        Next
    End Sub

    'general functions
    'randomEvents decides whether random encounters will occur, and handles what will be encountered
    Sub randomEvents()
        Randomize()
        If eClock > 0 Then eClock -= 1
        If combatmode = True Or npcmode = True Or eClock <> 0 Then Exit Sub
        Dim rand As Integer = CInt(Int(Rnd() * 200))
        Dim currTier As Integer() = monsterTier1
        Select Case floor
            Case 1
                currTier = monsterTier1
            Case 2
                currTier = monsterTier2
            Case 3
                currTier = monsterTier2
            Case 4
                currTier = monsterTier2
            Case Else
                currTier = monsterTier1
        End Select
        Dim r As Integer = Int(Rnd() * (UBound(currTier) + 1))
        Dim r2 As Integer = Int(Rnd() * (UBound(currTier) + 1))
        If rand < 5 Then
            Dim m As Monster
            If r2 = UBound(currTier) And r2 = r And ((floor < 5 AndAlso Not beatboss(floor)) Or floor >= 5) And Not floor = 3 Then
                m = New MiniBoss(floor)
            Else
                m = New Monster(r)
            End If
            npcList.Add(m)
            player.currTarget = m
            toCombat()
            lstLog.Items.Add((m.getName() & " attacks!"))
            eClock = 5
        End If
        lstLog.TopIndex = lstLog.Items.Count - 1
    End Sub
    'handleKeyPress handles the players pressed keys, and is the driver function for each turn
    Function HandleKeyPress(ByVal Keydata As Keys) As Boolean
        If tmrKeyCD.Enabled Then Return True Else tmrKeyCD.Enabled = True
        If lblEvent.Visible And npcmode = True Then
            oemSemiColon()
            Return True
        End If
        If lblEvent.Visible And Not (Keydata.Equals(Keys.Enter) Or Keydata.Equals(Keys.OemSemicolon) Or Keydata.Equals(Keys.E)) Then
            Return True
        End If
        If keyspresed.Length > 4 Then
            keyspresed = keyspresed.Substring(1, 3)
        End If
        If combatmode = True And Not (Keydata.Equals(Keys.Enter) Or Keydata.Equals(Keys.K) Or Keydata.Equals(Keys.I) Or Keydata.Equals(Keys.L)) Then Return True
        If npcmode = True Then Return True
        If player.mana < player.getmaxMana And turn Mod 3 = 0 Then player.mana += 1
        If npcList.Count > 0 Then
            For i = 0 To npcList.Count - 1
                Dim int1 As Integer = 100 - npcList.Item(i).speed
                If int1 < 1 Then int1 = 1
                updatelist.add(npcList.Item(i), (int1))
            Next
        End If
        Dim spos As Point = player.pos
        Select Case Keydata
            Case Keys.W
                keyspresed += "w"
                player.moveUp()
                randomEvents()
            Case Keys.S
                keyspresed += "s"
                player.moveDown()
                randomEvents()
            Case Keys.A
                keyspresed += "a"
                player.moveLeft()
                randomEvents()
            Case Keys.D
                keyspresed += "d"
                player.moveRight()
                randomEvents()
            Case Keys.M
                keyspresed += "m"
            Case Keys.R
                keyspresed += "r"
            Case Keys.K
                keyspresed += "k"
            Case Keys.G
                keyspresed += "g"
            Case Keys.I
                keyspresed += "i"
            Case Keys.L
                keyspresed += "l"
            Case Keys.N
                keyspresed += "n"
            Case Keys.U
                keyspresed += "u"
            Case Keys.F
                keyspresed += "f"
            Case Keys.D
                keyspresed += "d"
            Case Keys.E
                keyspresed += "e"
                Try
                    oemSemiColon()
                Catch ex As Exception
                    Return True
                End Try
            Case Keys.B
                keyspresed += "b"
            Case Keys.O
                keyspresed += "o"
            Case Keys.C
                keyspresed += "c"
            Case Keys.T
                keyspresed += "t"
            Case Keys.Enter
                If cheatList.Contains(keyspresed) Then
                    MsgBox(keyspresed)
                    If keyspresed = "mark" Then
                        player.sex = "Male"
                        player.sexBool = False
                        isMark = True
                        player.iArrInd(1) = New Tuple(Of Integer, Boolean)(CharacterGenerator.mRearHair2.Count - 1, False)
                        player.iArrInd(2) = New Tuple(Of Integer, Boolean)(0, False)
                        player.iArrInd(3) = New Tuple(Of Integer, Boolean)(CharacterGenerator.mClothing.Count - 1, False)
                        player.iArrInd(4) = New Tuple(Of Integer, Boolean)(0, False)
                        player.iArrInd(5) = New Tuple(Of Integer, Boolean)(CharacterGenerator.mRearHair1.Count - 1, False)
                        player.iArrInd(6) = New Tuple(Of Integer, Boolean)(0, False)
                        player.iArrInd(7) = New Tuple(Of Integer, Boolean)(0, False)
                        player.iArrInd(8) = New Tuple(Of Integer, Boolean)(2, False)
                        player.iArrInd(9) = New Tuple(Of Integer, Boolean)(2, False)
                        player.iArrInd(10) = New Tuple(Of Integer, Boolean)(0, False)
                        player.iArrInd(11) = New Tuple(Of Integer, Boolean)(0, False)
                        player.iArrInd(12) = New Tuple(Of Integer, Boolean)(0, False)
                        player.iArrInd(13) = New Tuple(Of Integer, Boolean)(0, False)
                        player.iArrInd(14) = New Tuple(Of Integer, Boolean)(0, False)
                        player.iArrInd(15) = New Tuple(Of Integer, Boolean)(CharacterGenerator.mFrontHair.Count - 1, False)
                        player.iArrInd(16) = New Tuple(Of Integer, Boolean)(0, False)
                        player.haircolor = Color.FromArgb(255, 125, 94, 50)
                        player.sState.save(player)
                        player.pState.save(player)
                        player.createP()
                    ElseIf keyspresed = "girl" Then
                        player.MtF()
                        player.createP()
                    ElseIf keyspresed = "dick" Then
                        player.FtM()
                        player.createP()
                    ElseIf keyspresed = "blue" Then
                        player.haircolor = Color.Cyan
                        player.createP()
                    ElseIf keyspresed = "blue" Then
                        player.haircolor = Color.Cyan
                        player.createP()
                    ElseIf keyspresed = "bmbo" Then
                        player.perks(1) = True
                    ElseIf keyspresed = "catc" Then
                        player.perks(6) = True
                    ElseIf keyspresed = "mana" Then
                        player.inventory(49).add(1)
                        player.invNeedsUDate = True
                        player.UIupdate()
                    ElseIf keyspresed = "form" Then
                        formList.Add("Slime")
                        formList.Add("Goddess")
                        formList.Add("Succubus")
                        formList.Add("Dragon")
                    ElseIf keyspresed = "fuse" Then
                        player.inventory(58).add(1)
                        player.invNeedsUDate = True
                        player.UIupdate()
                    ElseIf keyspresed = "tfme" Then
                        Polymorph.porm = True
                        Dim p As Polymorph = New Polymorph
                        p.ShowDialog()
                        p.Dispose()
                    ElseIf keyspresed = "bigr" Then
                        player.be()
                    ElseIf keyspresed = "rock" Then
                        player.petrify(Color.Gray)
                    ElseIf keyspresed = "doll" Then
                        Polymorph.transform(player, "doll", 0)
                    ElseIf keyspresed = "gogo" Then
                        Dim f As Integer = CInt(InputBox("Which floor?"))
                        floor = f - 1
                        initializeBoard()
                    ElseIf keyspresed = "slut" Then
                        player.perks(2) = True
                        player.inventory(1).add(1)
                        player.lust += 20
                        player.createP()
                    ElseIf keyspresed = "kill" Then
                        player.currTarget.takeDMG("9999")
                    End If
                End If
                keyspresed = ""
            Case Keys.Up
                player.moveUp()
                randomEvents()
            Case Keys.Down
                player.moveDown()
                randomEvents()
            Case Keys.Left
                player.moveLeft()
                randomEvents()
            Case Keys.Right
                player.moveRight()
                randomEvents()
            Case Keys.OemSemicolon
                Try
                    oemSemiColon()
                Catch ex As Exception
                    Return True
                End Try
        End Select
        Dim int As Integer = 100 - player.getSpeed
        If int < 1 Then int = 1
        updatelist.add(player, (int))
        turn += 1
        drawBoard()
        lstLog.TopIndex = lstLog.Items.Count - 1
        Return True
    End Function
    'processCmdKey is a leftover from an earlier version, and may not be needed anymore
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        ' Return MyBase.ProcessCmdKey(msg, keyData)
        Const WM_KEYDOWN As Integer = &H100
        If msg.Msg = WM_KEYDOWN Then
            If HandleKeyPress(keyData) Then Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    'oemSemicolon triggers when a player hits the semicolon key, or any of its equivalents
    Sub oemSemiColon()
        If player.pos.Equals(shopkeeper.pos) Then
            npcEncounter(shopkeeper)
        End If
        If lblEvent.Visible = True And npcmode = False Then
            picNPC.Visible = False
            lblEvent.Visible = False
            lblEvent.ForeColor = Color.White
            If Not combatmode Then player.canMoveFlag = True
            If Not lblEventOnClose Is Nothing Then
                lblEventOnClose()
                lblEventOnClose = Nothing
            End If
            drawBoard()
            If btnEQP.Enabled = False Then btnEQP.Enabled = True
            Throw New Exception
        End If
        If btnEQP.Enabled = False Then btnEQP.Enabled = True
        If chestList.Count > 0 Then
            For i = 0 To chestList.Count - 1
                If player.pos = chestList.Item(i).pos Then
                    chestList.Item(i).open()
                    chestList.RemoveAt(i)
                    Exit For
                End If
            Next
        End If
        If floor < 3 Then
            If player.pos = stairs And beatboss(floor) Then
                If floor < 3 Then
                    initializeBoard()
                    If combatmode Then fromCombat()
                Else
                    MsgBox("END OF CONTENT")
                End If
            ElseIf player.pos = stairs Then
                If floor = 3 Then pushLblEvent("The stairs are behind a locked gate!  Perhaps the key is in a chest..." & vbCrLf & "[while this game is in development it can also be bought from the shop for 2500]") Else pushLblEvent("You must defeat " & floorboss(floor) & "!")
            End If
        ElseIf player.pos = stairs Then
            initializeBoard()
            If combatmode Then fromCombat()
        End If
        If statueList.Count > 0 Then
            For i = 0 To statueList.Count - 1
                If player.pos = statueList.Item(i).pos Then
                    statueList.Item(i).examine()
                    Exit For
                End If
            Next
        End If
    End Sub

    'save/loadSave methods
    'save handles the saving of the game
    Sub save(ByVal a As String)
        If lblEvent.Visible = True Or combatmode Or npcmode Then
            pushLblEvent("You can't save now!")
            Exit Sub
        End If
        Dim writer As IO.StreamWriter
        writer = IO.File.CreateText(a)
        writer.WriteLine(version)
        writer.WriteLine(player.ToString)
        writer.WriteLine(mBoardWidth - 1)
        writer.WriteLine(mBoardHeight - 1)
        For yInd = 0 To mBoardHeight - 1
            For xInd = 0 To mBoardWidth - 1
                writer.WriteLine(mBoard(yInd, xInd).Tag)
            Next
        Next
        writer.WriteLine(stairs.X)
        writer.WriteLine(stairs.Y)
        writer.WriteLine(chestList.Count - 1)
        For i = 0 To chestList.Count - 1
            writer.WriteLine(chestList.Item(i).ToString())
        Next
        writer.WriteLine(trapList.Count - 1)
        For i = 0 To trapList.Count - 1
            writer.WriteLine(trapList.Item(i).ToString())
        Next
        writer.WriteLine(cboxMG.Items.Count - 1)
        For i = 0 To cboxMG.Items.Count - 1
            writer.WriteLine(cboxMG.Items(i).ToString())
        Next
        writer.WriteLine(formList.Count - 1)
        For i = 0 To formList.Count - 1
            writer.WriteLine(formList(i))
        Next
        writer.WriteLine(tFormList.Count - 1)
        For i = 0 To tFormList.Count - 1
            writer.WriteLine(tFormList(i))
        Next
        writer.WriteLine(cmboxSpec.Items.Count - 1)
        For i = 0 To cmboxSpec.Items.Count - 1
            writer.WriteLine(cmboxSpec.Items(i))
        Next
        For i = 0 To Potions.Count - 1
            writer.WriteLine(Potions(i).getName)
            writer.WriteLine(Potions(i).getRealName)
        Next
        'For i = 0 To UBound(HPotionNames)
        '    writer.WriteLine(HPotionNames(i))
        'Next
        For i = 0 To UBound(beatboss)
            writer.WriteLine(beatboss(i))
        Next
        writer.WriteLine(turn)
        writer.WriteLine(floor)
        writer.WriteLine(shopkeeper.pos.X)
        writer.WriteLine(shopkeeper.pos.Y)

        writer.WriteLine(floorLayouts.Count - 1)
        For i = 0 To floorLayouts.Count - 1
            writer.WriteLine(floorLayouts(i))
        Next

        writer.Flush()
        writer.Close()
        pushLblEvent("Game successfully saved!")
        player.solFlag = False
        player.createP()
    End Sub
    'loadSave handles the loading of a game
    Sub loadSave(ByVal a As String)
        cboxMG.Items.Clear()
        cboxMG.Text = "-- Select --"
        cboxNPCMG.Items.Clear()
        cboxNPCMG.Text = "-- Select --"
        cmboxSpec.Items.Clear()
        cmboxSpec.Text = "-- Select --"
        lstLog.Items.Clear()
        formList.Clear()
        tFormList.Clear()
        npcList = New ArrayList()
        updatelist = New PQ()
        pImage = picPlayer.BackgroundImage
        lblNameTitle.ForeColor = Color.White
        If Not picPortrait.BackgroundImage Is Nothing Then picPortrait.BackgroundImage.Dispose()
        lblEvent.Visible = False
        btnATK.Visible = False
        btnMG.Visible = False
        btnRUN.Visible = False
        cboxMG.Visible = False
        picEnemy.Visible = False
        picNPC.Visible = False
        btnSpec.Visible = False
        cmboxSpec.Visible = False
        pnlCombatClose()

        Dim reader As IO.StreamReader
        reader = IO.File.OpenText(a)
        If CDbl(reader.ReadLine()) < version Then
            MsgBox("Error 003: Incorrect save file version!")
            picStart.Visible = True
            btnS.Visible = True
            btnL.Visible = True
            Exit Sub
        End If

        player = New Player(reader.ReadLine())

        If Not mBoard Is Nothing Then
            For i = 0 To mBoardHeight - 1
                For j = 0 To mBoardWidth - 1
                    mBoard(i, j).Dispose()
                    If j <= 23 And i <= 15 Then
                        mPics(i, j).Dispose()
                    End If
                Next
            Next
        End If
        mBoard = Nothing
        Dim b1 As Integer = Int(reader.ReadLine())
        Dim b2 As Integer = Int(reader.ReadLine())
        mBoardHeight = b2 + 1
        mBoardWidth = b1 + 1
        newBoard()
        For yInd = 0 To b2
            For xInd = 0 To b1
                mBoard(yInd, xInd).Tag = reader.ReadLine()
            Next
        Next
        zoom()

        stairs = New Point(reader.ReadLine(), reader.ReadLine())
        For i = 0 To CInt(reader.ReadLine())
            chestList.Add(baseChest.Create(reader.ReadLine()))
        Next

        For i = 0 To CInt(reader.ReadLine())
            trapList.Add(New Trap(reader.ReadLine()))
            mBoard(trapList(i).pos.Y, trapList(i).pos.X).Text = "+"
        Next
        For i = 0 To CInt(reader.ReadLine())
            cboxMG.Items.Add(reader.ReadLine())
        Next
        For i = 0 To CInt(reader.ReadLine())
            formList.Add(reader.ReadLine())
        Next
        For i = 0 To CInt(reader.ReadLine())
            tFormList.Add(reader.ReadLine())
        Next
        For i = 0 To CInt(reader.ReadLine())
            cmboxSpec.Items.Add(reader.ReadLine())
        Next
        For i = 0 To Potions.Count - 1
            Dim nextKnownName = reader.ReadLine()
            Dim nextRealPotionName = reader.ReadLine()
            For j = 0 To Potions.Count - 1
                If CType(Potions(j), MysteryPotion).getRealName = nextRealPotionName Then
                    Potions(j).setName(nextKnownName)
                    j = Potions.Count
                End If
            Next
        Next
        Dim tempPotions As ArrayList = Potions.Clone()
        loadPotionListFromFile()
        Potions = tempPotions
        'For i = 0 To UBound(HPotionNames)
        '    HPotionNames(i) = reader.ReadLine()
        'Next
        For i = 0 To UBound(beatboss)
            beatboss(i) = CBool(reader.ReadLine)
        Next
        turn = reader.ReadLine()
        floor = reader.ReadLine()
        shopkeeper = New NPC(2)
        shopkeeper.pos.X = reader.ReadLine()
        shopkeeper.pos.Y = reader.ReadLine()

        floorLayouts.Clear()
        For i = 0 To CInt(reader.ReadLine())
            floorLayouts.Add(reader.ReadLine())
        Next
        combatmode = False

        Equipment.init()
        reader.Close()
        drawBoard()
        lblNameTitle.Text = player.name & " the " & player.title
        lblHealth.Text = "Health = " & player.health & "/" & player.maxHealth
        lblMana.Text = "Mana = " & player.mana & "/" & player.maxMana
        lblHunger.Text = "Hunger = " & player.hunger & "/100"
        'lblXP.Text = "XP = " & player.xp & "/" & player.nextLevelXp
        'lblLevel.Text = "Level " & player.level
        lblATK.Text = "ATK = " & player.getAttack
        lblDEF.Text = "DEF = " & player.getDefence
        lblSKL.Text = "WIL = " & player.getWillpower
        lblSPD.Text = "SPD = " & player.getSpeed
        lblEVD.Text = "EVD = " & player.evade

        player.createP()
        pushLblEvent("Game successfully loaded!")
        player.solFlag = False
        player.createP()
    End Sub
    Private Sub btnS1_Click(sender As Object, e As EventArgs) Handles btnS1.Click
        If solFlag Then
            Try
                loadSave("s1.ave")
            Catch ex As System.IO.FileNotFoundException
                MsgBox("Error 004: No save detected!")
            Catch ex2 As Exception
                MsgBox("Error 005: Error in loaded in save file!")
            End Try
        Else
            save("s1.ave")
        End If
        pnlSaveLoad.Visible = False
        If picStart.Visible Then closesol()
    End Sub
    Private Sub btnS2_Click(sender As Object, e As EventArgs) Handles btnS2.Click
        If solFlag Then
            Try
                loadSave("s2.ave")
            Catch ex As System.IO.FileNotFoundException
                MsgBox("Error 004: No save detected!")
            Catch ex2 As Exception
                MsgBox("Error 005: Error in loaded in save file!")
            End Try
        Else
            save("s2.ave")
        End If
        pnlSaveLoad.Visible = False
        If picStart.Visible Then closesol()
    End Sub
    Private Sub btnS3_Click(sender As Object, e As EventArgs) Handles btnS3.Click
        If solFlag Then
            Try
                loadSave("s3.ave")
            Catch ex As System.IO.FileNotFoundException
                MsgBox("Error 004: No save detected!")
            Catch ex2 As Exception
                MsgBox("Error 005: Error in loaded in save file!")
            End Try
        Else
            save("s3.ave")
        End If
        pnlSaveLoad.Visible = False
        If picStart.Visible Then closesol()
    End Sub
    Private Sub btnS4_Click(sender As Object, e As EventArgs) Handles btnS4.Click
        If solFlag Then
            Try
                loadSave("s4.ave")
            Catch ex As System.IO.FileNotFoundException
                MsgBox("Error 004: No save detected!")
            Catch ex2 As Exception
                MsgBox("Error 005: Error in loaded in save file!")
            End Try
        Else
            save("s4.ave")
        End If
        pnlSaveLoad.Visible = False
        If picStart.Visible Then closesol()
    End Sub
    Private Sub btnS5_Click(sender As Object, e As EventArgs) Handles btnS5.Click
        If solFlag Then
            Try
                loadSave("s5.ave")
            Catch ex As System.IO.FileNotFoundException
                MsgBox("Error 004: No save detected!")
            Catch ex2 As Exception
                MsgBox("Error 005: Error in loaded in save file!")
            End Try
        Else
            save("s5.ave")
        End If
        pnlSaveLoad.Visible = False
        If picStart.Visible Then closesol()
    End Sub
    Private Sub btnS6_Click(sender As Object, e As EventArgs) Handles btnS6.Click
        If solFlag Then
            Try
                loadSave("s6.ave")
            Catch ex As System.IO.FileNotFoundException
                MsgBox("Error 004: No save detected!")
            Catch ex2 As Exception
                MsgBox("Error 005: Error in loaded in save file!")
            End Try
        Else
            save("s6.ave")
        End If
        pnlSaveLoad.Visible = False
        If picStart.Visible Then closesol()
    End Sub
    Private Sub btnS7_Click(sender As Object, e As EventArgs) Handles btnS7.Click
        If solFlag Then
            Try
                loadSave("s7.ave")
            Catch ex As System.IO.FileNotFoundException
                MsgBox("Error 004: No save detected!")
            Catch ex2 As Exception
                MsgBox("Error 005: Error in loaded in save file!")
            End Try
        Else
            save("s7.ave")
        End If
        pnlSaveLoad.Visible = False
        If picStart.Visible Then closesol()
    End Sub
    Private Sub btnS8_Click(sender As Object, e As EventArgs) Handles btnS8.Click
        If solFlag Then
            Try
                loadSave("s8.ave")
            Catch ex As System.IO.FileNotFoundException
                MsgBox("Error 004: No save detected!")
            Catch ex2 As Exception
                MsgBox("Error 005: Error in loaded in save file!")
            End Try
        Else
            save("s8.ave")
        End If
        pnlSaveLoad.Visible = False
        If picStart.Visible Then closesol()
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        pnlSaveLoad.Visible = False
        If picStart.Visible = True Then
            btnS.Visible = True
            btnL.Visible = True
            btnControls.Visible = True
        End If
    End Sub
    Sub toSOL()
        pnlSaveLoad.Visible = True
        CharacterGenerator.init()
        If System.IO.File.Exists("s.ave") Then convertSave("s.ave")

        If System.IO.File.Exists("s1.ave") Then
            btnS1.BackgroundImage = getImgFromFile("s1.ave")
        Else
            If solFlag Then btnS1.Enabled = False
        End If

        If System.IO.File.Exists("s2.ave") Then
            btnS2.BackgroundImage = getImgFromFile("s2.ave")
        Else
            If solFlag Then btnS2.Enabled = False
        End If

        If System.IO.File.Exists("s3.ave") Then
            btnS3.BackgroundImage = getImgFromFile("s3.ave")
        Else
            If solFlag Then btnS3.Enabled = False
        End If

        If System.IO.File.Exists("s4.ave") Then
            btnS4.BackgroundImage = getImgFromFile("s4.ave")
        Else
            If solFlag Then btnS4.Enabled = False
        End If

        If System.IO.File.Exists("s5.ave") Then
            btnS5.BackgroundImage = getImgFromFile("s5.ave")
        Else
            If solFlag Then btnS5.Enabled = False
        End If

        If System.IO.File.Exists("s6.ave") Then
            btnS6.BackgroundImage = getImgFromFile("s6.ave")
        Else
            If solFlag Then btnS6.Enabled = False
        End If

        If System.IO.File.Exists("s7.ave") Then
            btnS7.BackgroundImage = getImgFromFile("s7.ave")
        Else
            If solFlag Then btnS7.Enabled = False
        End If

        If System.IO.File.Exists("s8.ave") Then
            btnS8.BackgroundImage = getImgFromFile("s8.ave")
        Else
            If solFlag Then btnS8.Enabled = False
        End If

    End Sub
    Sub closesol()
        Dim int As Integer = 100 - player.getSpeed
        If int < 1 Then int = 1
        updatelist.add(player, int)
        combatmode = False
        picStart.Visible = False
    End Sub

    'inventory functions
    'lstInventory_SelectedValueChanged handles the selecting of items from the inventory listbox
    Private Sub lstInventory_SelectedValueChanged(sender As Object, e As EventArgs) Handles lstInventory.SelectedValueChanged
        Try
            If lstInventory.SelectedItem.ToString.Substring(0, 1) = "-" Then Throw New NullReferenceException
            Dim subString As String = lstInventory.SelectedItem.ToString.Split(" (")(1)
            Dim aInd As Integer = player.inventorynames.IndexOf(subString)
            If aInd < 0 Then
                For i = 0 To Potions.Count - 1
                    If CType(Potions(i), MysteryPotion).getName() = subString Then
                        aInd = player.inventorynames.IndexOf(CType(Potions(i), MysteryPotion).getRealName())
                        Exit For
                    End If
                Next
            End If
            If aInd >= 0 Then
                'MsgBox(aInd & ", " & subString)
                'MsgBox(player.inventorynames(32))
                selectedItem = player.inventory.Item(aInd)
                If selectedItem.getUsable() Then btnUse.Enabled = True Else btnUse.Enabled = False
                btnDrop.Enabled = True
                btnLook.Enabled = True
            End If
        Catch ex As NullReferenceException
            btnUse.Enabled = False
            btnDrop.Enabled = False
            btnLook.Enabled = False
        End Try
    End Sub
    'inventory filter methods
    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        fUseable.Visible = True
        fPotion.Visible = True
        fFood.Visible = True
        fArmor.Visible = True
        fWeapon.Visible = True
        fMisc.Visible = True
        lstInventory.Items.Clear()
        btnOk.Visible = True
        btnAll.Visible = True
        btnNone.Visible = True

        If fUseable.Checked Then invFilters(0) = True Else invFilters(0) = False
        If fPotion.Checked Then invFilters(1) = True Else invFilters(1) = False
        If fFood.Checked Then invFilters(2) = True Else invFilters(2) = False
        If fArmor.Checked Then invFilters(3) = True Else invFilters(3) = False
        If fWeapon.Checked Then invFilters(4) = True Else invFilters(4) = False
        If fMisc.Checked Then invFilters(5) = True Else invFilters(5) = False
    End Sub
    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        fUseable.Visible = False
        fPotion.Visible = False
        fFood.Visible = False
        fArmor.Visible = False
        fWeapon.Visible = False
        fMisc.Visible = False
        btnOk.Visible = False
        btnAll.Visible = False
        btnNone.Visible = False
        player.invNeedsUDate = True
        player.UIupdate()
    End Sub
    Private Sub fUseable_CheckedChanged(sender As Object, e As EventArgs) Handles fUseable.CheckedChanged
        If fUseable.Checked Then invFilters(0) = True Else invFilters(0) = False
    End Sub
    Private Sub fPotion_CheckedChanged(sender As Object, e As EventArgs) Handles fPotion.CheckedChanged
        If fPotion.Checked Then invFilters(1) = True Else invFilters(1) = False
    End Sub
    Private Sub fFood_CheckedChanged(sender As Object, e As EventArgs) Handles fFood.CheckedChanged
        If fFood.Checked Then invFilters(2) = True Else invFilters(2) = False
    End Sub
    Private Sub fArmor_CheckedChanged(sender As Object, e As EventArgs) Handles fArmor.CheckedChanged
        If fArmor.Checked Then invFilters(3) = True Else invFilters(3) = False
    End Sub
    Private Sub fWeapon_CheckedChanged(sender As Object, e As EventArgs) Handles fWeapon.CheckedChanged
        If fWeapon.Checked Then invFilters(4) = True Else invFilters(4) = False
    End Sub
    Private Sub fMisc_CheckedChanged(sender As Object, e As EventArgs) Handles fMisc.CheckedChanged
        If fMisc.Checked Then invFilters(5) = True Else invFilters(5) = False
    End Sub
    Private Sub btnAll_Click(sender As Object, e As EventArgs) Handles btnAll.Click
        fUseable.Checked = True
        fPotion.Checked = True
        fFood.Checked = True
        fArmor.Checked = True
        fWeapon.Checked = True
        fMisc.Checked = True
    End Sub
    Private Sub btnNone_Click(sender As Object, e As EventArgs) Handles btnNone.Click
        fUseable.Checked = False
        fPotion.Checked = False
        fFood.Checked = False
        fArmor.Checked = False
        fWeapon.Checked = False
        fMisc.Checked = False
    End Sub

    'combat functions
    'toCombat displays the players combat menus
    Sub toCombat()
        updatePnlCombat(player, player.currTarget)
        pnlCombat.Visible = True
        combatmode = True
        player.canMoveFlag = False
        btnATK.Visible = True
        btnMG.Visible = True
        btnRUN.Visible = True
        cboxMG.Visible = True
        cmboxSpec.Visible = True
        btnSpec.Visible = True
        cmboxSpec.Items.Clear()
        cmboxSpec.Text = "-- Select --"
        specialRoute()
    End Sub
    'fromCombat hides the players combat menus
    Public Sub fromCombat()
        pnlCombatClose()
        btnATK.Visible = False
        btnMG.Visible = False
        btnRUN.Visible = False
        cboxMG.Visible = False
        picEnemy.Visible = False
        combatmode = False
        picNPC.Visible = False
        player.canMoveFlag = True
        player.currTarget = Nothing
        cmboxSpec.Visible = False
        btnSpec.Visible = False

        player.currTarget = Nothing

        If player.perks(5) Then
            player.perks(5) = False
            player.perksct(5) = 0
            player.revert2()
        End If
        npcList.Clear()
        player.currTarget = Nothing
    End Sub
    'the NPC versions of from and to combat
    Sub NPCtoCombat(ByRef m As Monster)
        updatePnlCombat(player, m)
        pnlCombat.Visible = True
        combatmode = True
        npcmode = False
        lstLog.Items.Add((m.getName() & " attacks!"))
        btnATK.Visible = True
        btnMG.Visible = True
        btnRUN.Visible = True
        cboxMG.Visible = True
        cmboxSpec.Visible = True
        btnSpec.Visible = True
        cmboxSpec.Items.Clear()
        specialRoute()
        player.canMoveFlag = False

        btnTalk.Visible = False
        btnNPCMG.Visible = False
        cboxNPCMG.Visible = False
        btnShop.Visible = False
        btnFight.Visible = False
        btnLeave.Visible = False
        lstLog.TopIndex = lstLog.Items.Count - 1
    End Sub
    Sub NPCfromCombat(ByRef m As Monster)
        pnlCombatClose()
        combatmode = False
        npcmode = True
        pushLblEvent((m.getName() & " stops fighting!"))
        lstLog.Items.Add((m.getName() & " stops fighting!"))
        btnATK.Visible = False
        btnMG.Visible = False
        btnRUN.Visible = False
        cboxMG.Visible = False
        cmboxSpec.Visible = False
        btnSpec.Visible = False
        player.canMoveFlag = True

        btnTalk.Visible = True
        btnNPCMG.Visible = True
        cboxNPCMG.Visible = True
        btnShop.Visible = True
        btnFight.Visible = True
        btnLeave.Visible = True
        lstLog.TopIndex = lstLog.Items.Count - 1

        If player.perks(5) Then
            player.perks(5) = False
            player.perksct(5) = 0
            player.revert2()
        End If
        npcList.Clear()
        player.currTarget = Nothing
    End Sub
    'run handles the player choice to run from combat
    Sub run()
        If player.perks(7) Then
            lstLog.Items.Add("Something inside you decides that running away is cowardly, so you don't.")
            pushLblCombatEvent("Something inside you decides that running away is cowardly, so you don't.")
            lstLog.TopIndex = lstLog.Items.Count - 1
            Exit Sub
        End If
        Dim run As Integer = Int(Rnd() * 3)
        For i = 0 To npcList.Count() - 1
            If (npcList.Item(i).GetType().IsSubclassOf(GetType(Monster)) Or npcList.Item(i).GetType() Is GetType(Monster)) AndAlso Not (npcList.Item(i).GetType() Is GetType(Boss)) Then
                If UBound(npcList.Item(i).inventory) >= 53 AndAlso npcList.Item(i).inventory(53) > 0 Then
                    pushLblCombatEvent("The glimmer of a key can be seen with your opponent!")
                    Exit For
                End If
                If run <> 1 Then
                    npcList.Item(i).despawn("run")
                Else
                    pushLblCombatEvent("You can't get away!")
                    If npcList.Count > 0 Then
                        For x = 0 To npcList.Count - 1
                            Dim int1 As Integer = 100 - npcList.Item(x).speed
                            If int1 < 1 Then int1 = 1
                            updatelist.add(npcList.Item(i), (int1))
                        Next
                    End If
                    Dim int As Integer = 100 - player.getSpeed
                    If int < 1 Then int = 1
                    updatelist.add(player, int)
                    Do While updatelist.isEmpty() = False
                        Dim u As Updatable = updatelist.remove()
                        u.update()
                    Loop
                    'updates the combat banner
                    updatePnlCombat(player, player.currTarget)
                    Exit Sub
                End If

                Exit For
            End If
        Next
        Dim chick As Integer = 1 'CInt(Int(Rnd() * 5))
        If chick = 4 And Not player.perks(3) Then player.perks(3) = True
    End Sub
    Sub leaveNPC()
        Dim m As NPC = Nothing
        For i = 0 To npcList.Count() - 1
            If npcList.Item(i).GetType() Is GetType(NPC) Then
                m = npcList.Item(i)
                Exit For
            End If
        Next
        If lblEvent.Visible = True Then
            lblEvent.Visible = False
            lblEvent.ForeColor = Color.White
            drawBoard()
        End If
        m.despawn("npc")
        npcList.Clear()
        player.currTarget = Nothing
        npcmode = False
    End Sub
    Sub npcEncounter(ByRef m As NPC)
        If m.dead Then Exit Sub
        npcList.Clear()
        npcList.Add(m)
        npcmode = True
        currNPC = m
        m.encounter()
        lstLog.Items.Add(("You walk up to " & m.getName & "!"))
        player.canMoveFlag = False
        picNPC.Visible = True
        'btnTalk.Visible = True
        btnNPCMG.Visible = True
        cboxNPCMG.Visible = True
        btnShop.Visible = True
        If m.isShop Then btnShop.Enabled = True Else btnShop.Enabled = False
        btnFight.Visible = True
        btnLeave.Visible = True
        lstLog.TopIndex = lstLog.Items.Count - 1
    End Sub
    'special route
    Public Sub specialRoute()
        If player.title = "Warrior" Or player.title = "Paladin" Then cmboxSpec.Items.Add("Berserker Rage")
        If player.title = "Mage" Or player.title = "Paladin" Then cmboxSpec.Items.Add("Risky Decision")
        If player.breastSize > 3 Then cmboxSpec.Items.Add("Massive Mammaries")
        If player.title = "Succubus" Then cmboxSpec.Items.Add("Unholy Seduction")
        If player.title = "Slime" Then cmboxSpec.Items.Add("Absorbtion")
        If player.title = "Dragon" Then cmboxSpec.Items.Add("Ironhide Fury")
    End Sub

    'button click methods
    Private Sub btnUse_Click(sender As Object, e As EventArgs) Handles btnUse.Click
        If player.iArrInd(8).Equals(New Tuple(Of Integer, Boolean)(6, False)) Or player.iArrInd(8).Equals(New Tuple(Of Integer, Boolean)(12, True)) Then
            pushLblEvent("You can't use items now!")
            Exit Sub
        End If
        selectedItem.use()
        player.invNeedsUDate = True
        player.UIupdate()
        lstInventory.SelectedItem = Nothing
        selectedItem = Nothing
        btnUse.Enabled = False
        btnDrop.Enabled = False
        btnLook.Enabled = False
        If combatmode Then
            If npcList.Count > 0 Then
                For i = 0 To npcList.Count - 1
                    Dim int1 As Integer = 100 - npcList.Item(i).speed
                    If int1 < 1 Then int1 = 1
                    updatelist.add(npcList.Item(i), (int1))
                Next
            End If
            Do While updatelist.isEmpty() = False
                Dim u As Updatable = updatelist.remove()
                u.update()
            Loop
            'updates the combat banner
            updatePnlCombat(player, player.currTarget)
        End If
        lblPHealth.Text = player.health & "/" & player.getmaxHealth
    End Sub
    Private Sub btnDrop_Click(sender As Object, e As EventArgs) Handles btnDrop.Click
        selectedItem.discard()
        player.UIupdate()
        player.invNeedsUDate = True
        lstInventory.SelectedItem = Nothing
        selectedItem = Nothing
        btnUse.Enabled = False
        btnDrop.Enabled = False
        btnLook.Enabled = False
    End Sub
    Private Sub btnLook_Click(sender As Object, e As EventArgs) Handles btnLook.Click
        selectedItem.examine()
        lstInventory.SelectedItem = Nothing
        selectedItem = Nothing
        btnUse.Enabled = False
        btnDrop.Enabled = False
        btnLook.Enabled = False
    End Sub
    Private Sub btnATK_Click(sender As Object, e As EventArgs) Handles btnATK.Click
        turn += 1
        If lblEvent.Visible = True Then
            lblEvent.Visible = False
            lblEvent.ForeColor = Color.White
        End If
        Dim m As Monster = Nothing
        For i = 0 To npcList.Count() - 1
            If npcList.Item(i).GetType().IsSubclassOf(GetType(Monster)) Or npcList.Item(i).GetType() Is GetType(Monster) Then
                m = npcList.Item(i)
                Exit For
            End If
        Next
        player.setTarg(m)
        If npcList.Count > 0 Then
            For i = 0 To npcList.Count - 1
                Dim int1 As Integer = 100 - npcList.Item(i).speed
                If int1 < 1 Then int1 = 1
                updatelist.add(npcList.Item(i), (int1))
            Next
        End If
        Dim int As Integer = 100 - player.getSpeed
        If int < 1 Then int = 1
        player.isAttacking = True
        updatelist.add(player, int)
        drawBoard()
    End Sub
    Private Sub btnSpec_Click(sender As Object, e As EventArgs) Handles btnSpec.Click
        turn += 1
        lblCombatEvents.Text = ""
        player.currTarget = Nothing
        If lblEvent.Visible = True Then
            lblEvent.Visible = False
            lblEvent.ForeColor = Color.White
        End If
        If cmboxSpec.Text = "-- Select --" Then Exit Sub
        Dim m As Monster = Nothing
        For i = 0 To npcList.Count() - 1
            If npcList.Item(i).GetType().IsSubclassOf(GetType(Monster)) Or npcList.Item(i).GetType() Is GetType(Monster) Then
                m = npcList.Item(i)
                Exit For
            End If
        Next
        Specials.goSpecial(m, player, cmboxSpec.Text)
        cmboxSpec.Visible = False
        btnSpec.Visible = False
        If npcList.Count > 0 Then
            For i = 0 To npcList.Count - 1
                Dim int1 As Integer = 100 - npcList.Item(i).speed
                If int1 < 1 Then int1 = 1
                updatelist.add(npcList.Item(i), (int1))
            Next
        End If
        Dim int As Integer = 100 - player.getSpeed
        If int < 1 Then int = 1
        updatelist.add(player, int)
        Do While updatelist.isEmpty() = False
            Dim u As Updatable = updatelist.remove()
            u.update()
        Loop
        'updates the combat banner
        updatePnlCombat(player, player.currTarget)
    End Sub
    Private Sub btnRUN_Click(sender As Object, e As EventArgs) Handles btnRUN.Click
        If lblEvent.Visible = True Then
            lblEvent.Visible = False
            lblEvent.ForeColor = Color.White
            drawBoard()
        End If
        turn += 1
        run()
    End Sub
    Private Sub btnMG_Click(sender As Object, e As EventArgs) Handles btnMG.Click
        turn += 1
        lblCombatEvents.Text = ""
        player.currTarget = Nothing
        If lblEvent.Visible = True Then
            lblEvent.Visible = False
            lblEvent.ForeColor = Color.White
        End If
        If cboxMG.Text = "-- Select --" Or player.mana <= 0 Then Exit Sub
        Dim m As Monster = Nothing
        For i = 0 To npcList.Count() - 1
            If npcList.Item(i).GetType().IsSubclassOf(GetType(Monster)) Or npcList.Item(i).GetType() Is GetType(Monster) Then
                m = npcList.Item(i)
                Exit For
            End If
        Next
        Spells.spellCast(m, player, cboxMG.Text)
        If npcList.Count > 0 Then
            For i = 0 To npcList.Count - 1
                Dim int1 As Integer = 100 - npcList.Item(i).speed
                If int1 < 1 Then int1 = 1
                updatelist.add(npcList.Item(i), (int1))
            Next
        End If
        Dim int As Integer = 100 - player.getSpeed
        If int < 1 Then int = 1
        updatelist.add(player, int)
        Do While updatelist.isEmpty() = False
            Dim u As Updatable = updatelist.remove()
            u.update()
        Loop
        'updates the combat banner
        updatePnlCombat(player, player.currTarget)
    End Sub
    Private Sub btnEQP_Click(sender As Object, e As EventArgs) Handles btnEQP.Click
        Dim f3 As Equipment = New Equipment()
        f3.ShowDialog()
        f3.Dispose()
    End Sub
    Private Sub btnEXM_Click(sender As Object, e As EventArgs) Handles btnEXM.Click
        lstLog.Items.Add(player.description)
        lstLog.TopIndex = lstLog.Items.Count - 1
    End Sub
    Private Sub btnIns_Click(sender As Object, e As EventArgs) Handles btnIns.Click
        HandleKeyPress(Keys.OemSemicolon)
    End Sub
    Private Sub BtnD_Click(sender As Object, e As EventArgs) Handles BtnD.Click
        HandleKeyPress(Keys.S)
    End Sub
    Private Sub btnU_Click(sender As Object, e As EventArgs) Handles btnU.Click
        HandleKeyPress(Keys.W)
    End Sub
    Private Sub btnR_Click(sender As Object, e As EventArgs) Handles btnR.Click
        HandleKeyPress(Keys.D)
    End Sub
    Private Sub btnLft_Click(sender As Object, e As EventArgs) Handles btnLft.Click
        HandleKeyPress(Keys.A)
    End Sub
    'btnS is the new game button on the start menu
    Private Sub btnS_Click(sender As Object, e As EventArgs) Handles btnS.Click
        newGame()
    End Sub
    'btnL is the loadSave button on the start menu
    Private Sub btnL_Click(sender As Object, e As EventArgs) Handles btnL.Click
        Try
            btnS.Visible = False
            btnL.Visible = False
            btnControls.Visible = False
            CharacterGenerator.init()
            CharacterGenerator.fFrontHair(0) = CharacterGenerator.picPort.Image
            CharacterGenerator.mFrontHair(0) = CharacterGenerator.picPort.Image
            newBoard()
            solFlag = True
            toSOL()
        Catch ex As System.IO.FileNotFoundException
            MsgBox("Error 004: No save detected!")
            btnS.Visible = True
            btnL.Visible = True
            btnControls.Visible = True
            'Catch ex2 As Exception
            '    MsgBox("Error 005: Error in loaded in save file!")
            '    btnS.Visible = True
            '    btnL.Visible = True
            '    btnControls.Visible = True
        End Try
    End Sub
    Private Sub btnControls_Click(sender As Object, e As EventArgs) Handles btnControls.Click
        Dim f6 As Controls = New Controls
        f6.ShowDialog()
        f6.Dispose()
    End Sub
    Private Sub btnTalk_Click(sender As Object, e As EventArgs) Handles btnTalk.Click
        If lblEvent.Visible = True Then
            lblEvent.Visible = False
            lblEvent.ForeColor = Color.White
            drawBoard()
        End If
    End Sub
    Private Sub btnShop_Click(sender As Object, e As EventArgs) Handles btnShop.Click
        If lblEvent.Visible = True Then
            lblEvent.Visible = False
            lblEvent.ForeColor = Color.White
            drawBoard()
        End If
        Dim s As Shop = New Shop
        s.ShowDialog()
        s.Dispose()
    End Sub
    Private Sub btnNPCMG_Click(sender As Object, e As EventArgs) Handles btnNPCMG.Click
        If MessageBox.Show("This is probably a really bad idea, are you sure?", "Bad Idea", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            If lblEvent.Visible = True Then
                lblEvent.Visible = False
                lblEvent.ForeColor = Color.White
                drawBoard()
            End If
            If cboxNPCMG.Text = "-- Select --" Or player.mana <= 0 Then Exit Sub
            Dim m As NPC = Nothing
            For i = 0 To npcList.Count() - 1
                If npcList.Item(i).GetType() Is GetType(NPC) Then
                    m = npcList.Item(i)
                    Exit For
                End If
            Next
            'MsgBox("B")
            If cboxNPCMG.Text = "Turn to Frog" Then Spells.turnToFrogN(m, player)
            If cboxNPCMG.Text = "Petrify" Then Spells.Petrify(m, player)
            If cboxNPCMG.Text = "Polymorph Enemy" Then Spells.EnemyPolymorph(m, player)

            If npcList.Count > 0 Then
                For i = 0 To npcList.Count - 1
                    Dim int1 As Integer = 100 - npcList.Item(i).speed
                    If int1 < 1 Then int1 = 1
                    updatelist.add(npcList.Item(i), int1)
                Next
            End If
            If m.npcIndex = 0 Then
                pushNPCDialog("Did . . . did you just cast a spell on me?  You know I have to kill you now, right?")
                NPCtoCombat(m)
            ElseIf m.npcIndex = 1 Then
                pushNPCDialog("Ribbit!!!")
                NPCtoCombat(m)
            ElseIf npcIndex = 2 Then
                pushNPCDialog("[angry bleets]!")
                NPCtoCombat(m)
            ElseIf npcIndex = 3 Then
                pushNPCDialog("Casting spells on royalty is genrally not a good idea.")
                NPCtoCombat(m)
            ElseIf m.npcIndex = 4 Then
                pushNPCDialog("*giggle* Was that magic?")
            End If
            Dim int As Integer = 100 - player.getSpeed
            If int < 1 Then int = 1
            updatelist.add(player, int)
            drawBoard()
        End If
    End Sub
    Private Sub btnFight_Click(sender As Object, e As EventArgs) Handles btnFight.Click
        If MessageBox.Show("This is probably a really bad idea, are you sure?", "Bad Idea", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            If lblEvent.Visible = True Then
                lblEvent.Visible = False
                lblEvent.ForeColor = Color.White
                drawBoard()
            End If
            If npcIndex = 0 Then
                pushNPCDialog("So you want to fight, eh?  I'm ready whenever you are.")
            ElseIf npcIndex = 1 Then
                pushNPCDialog("Ribbit . . .")
            ElseIf npcIndex = 2 Then
                pushNPCDialog("BAAAAAHHHH!")
            ElseIf npcIndex = 3 Then
                pushNPCDialog("You would dare to challenge me? If you wish to die, you could just say so.")
            ElseIf npcIndex = 4 Then
                pushNPCDialog("I might not be the best fighter any more, but I can definitely give it my best!")
            End If
            Dim m As Monster = Nothing
            For i = 0 To npcList.Count() - 1
                If npcList.Item(i).GetType().IsSubclassOf(GetType(Monster)) Or npcList.Item(i).GetType() Is GetType(Monster) Then
                    m = npcList.Item(i)
                    Exit For
                End If
            Next
            If npcList.Count > 0 Then
                For i = 0 To npcList.Count - 1
                    Dim int1 As Integer = 100 - npcList.Item(i).speed
                    If int1 < 1 Then int1 = 1
                    updatelist.add(npcList.Item(i), int1)
                Next
            End If
            Dim int As Integer = 100 - player.getSpeed
            If int < 1 Then int = 1
            updatelist.add(player, int)
            NPCtoCombat(m)
        End If
    End Sub
    Private Sub btnLeave_Click(sender As Object, e As EventArgs) Handles btnLeave.Click
        leaveNPC()
    End Sub
    Private Sub btnChallengeBoss_Click(sender As Object, e As EventArgs) Handles btnChallengeBoss.Click
        Dim m As Monster
        If floor Mod 5 = 0 Then
            m = New Boss(floor)
        Else
            m = New MiniBoss(floor)
        End If
        player.currTarget = m
        npcList.Add(m)
        lstLog.Items.Add((m.getName & " attacks!"))
        toCombat()
        btnChallengeBoss.Visible = False
        lstLog.TopIndex = lstLog.Items.Count - 1
    End Sub

    'toolstrip methods
    'NewGameToolStripMenuItem_Click restarts the application
    Private Sub NewGameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewGameToolStripMenuItem.Click
        Application.Restart()
    End Sub
    Private Sub LoadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadToolStripMenuItem.Click
        If lblEvent.Visible = True Or combatmode Or npcmode Then
            pushLblEvent("You can't loadSave now!")
            Exit Sub
        End If
        solFlag = True
        toSOL()
    End Sub
    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        solFlag = False
        toSOL()
    End Sub
    Private Sub InfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InfoToolStripMenuItem.Click
        Dim ab1 As About = New About
        ab1.ShowDialog()
        ab1.Dispose()
    End Sub

    'utility methods/functions
    'ShuffleArray takes an array, and randomizes its order
    Public Sub ShuffleArray(ByRef A() As String)
        Randomize()
        Dim ct As Integer = UBound(A)   'last index of A
        Dim B(ct) As String             'creates the array to put the shuffled values in
        Dim order(ct) As Integer        'creates the array the order should go in
        Dim n As Integer
        For i = 0 To UBound(order) - 1  'puts each number between 0 and ct randomly in "order", with no duplication
            Do
                n = Int(Rnd() * (ct + 1))
            Loop Until Not order.Contains(n)
            order(i) = n
        Next
        n = Int(Rnd() * (ct + 1))       'swaps the last index with a random index
        order(ct) = n
        order(Array.IndexOf(order, n)) = 0
        For i = 0 To UBound(order)      'organizes B according to order
            B(i) = A(order(i))
        Next
        A = B                       'sets A to B, the shuffled array.
    End Sub
    'pushLblEvent takes a string, formats it to wrap, and pushes a dialog box containing it
    Sub pushLblEvent(ByVal s As String)
        Dim sSplit() As String = s.Split(" ")
        Dim c As Integer = 0
        Dim ct As Integer = 0
        Dim out As String = ""
        Do While c < sSplit.Length
            If ct < 70 Then
                If Not sSplit(c).Equals("fugoo") Then
                    out += sSplit(c) & " "
                    ct += sSplit(c).Length + 1
                    c += 1
                Else
                    sSplit(c) = ""
                    out += vbCrLf
                    ct = 0
                    c += 1
                End If
            Else
                out += vbCrLf
                ct = 0
            End If
        Loop
        If Not combatmode Then out += " " & vbCrLf & " " & vbCrLf & "Press ';' to continue." Else out += " " & vbCrLf & " " & vbCrLf & "Click a combat button to continue."
        lblEvent.Text = out
        lblEvent.BringToFront()
        lblEvent.Location = New Point((265 * (Me.Size.Width / 688)) - (lblEvent.Size.Width / 2), (65 * (Me.Size.Width / 688)))
        lblEvent.Visible = True
        player.canMoveFlag = False
    End Sub
    'This pushLblEvent is identical to the first, but takes an additional action that it executes on close.
    Sub pushLblEvent(ByVal s As String, ByRef effect As Action)
        Dim sSplit() As String = s.Split(" ")
        Dim c As Integer = 0
        Dim ct As Integer = 0
        Dim out As String = ""
        Do While c < sSplit.Length
            If ct < 70 Then
                out += sSplit(c) & " "
                ct += sSplit(c).Length + 1
                c += 1
            Else
                out += vbCrLf
                ct = 0
            End If
        Loop
        If Not combatmode Then out += " " & vbCrLf & " " & vbCrLf & "Press ';' to continue." Else out += " " & vbCrLf & " " & vbCrLf & "Click a combat button to continue."
        lblEvent.Text = out
        lblEvent.BringToFront()
        lblEvent.Location = New Point((265 * (Me.Size.Width / 688)) - (lblEvent.Size.Width / 2), 65 * (Me.Size.Width / 688))
        lblEvent.Visible = True
        player.canMoveFlag = False
        lblEventOnClose = effect
        btnEQP.Enabled = False
    End Sub
    'pushNPCDialog is a variant of pushLblEvent that pushes the string into an NPC dialog box
    Sub pushNPCDialog(ByVal s As String)
        Dim sSplit() As String = s.Split(" ")
        Dim c As Integer = 0
        Dim ct As Integer = 0
        Dim out As String = ""
        Do While c < sSplit.Length
            If ct < 65 Then
                out += sSplit(c) & " "
                ct += sSplit(c).Length + 1
                c += 1
            Else
                out += vbCrLf
                ct = 0
            End If
        Loop
        lblEvent.Text = out
        lblEvent.Location = New Point(160 * Me.Size.Width / 688, 120 * Me.Size.Width / 688)
        lblEvent.Visible = True
        picNPC.Visible = True
    End Sub
    'save access files
    Shared Function getImgFromFile(ByVal a As String) As Image
        Dim reader As IO.StreamReader
        reader = IO.File.OpenText(a)
        reader.ReadLine()

        Dim img As Bitmap = Nothing
        Try
            Dim iarr(16) As Image
            Dim pState As String() = reader.ReadLine().Split("#")(0).Split("*")
            Dim haircolor = Color.FromArgb(255, CInt(pState(22)), CInt(pState(23)), CInt(pState(24)))
            Dim skincolor = Color.FromArgb(255, CInt(pState(25)), CInt(pState(26)), CInt(pState(27)))
            Dim ids(16) As Tuple(Of Integer, Boolean)
            For i = 0 To 16
                Dim arr() As String = pState(32 + CInt(pState(31)) + 1 + i).Split("%")
                Dim id = New Tuple(Of Integer, Boolean)(CInt(arr(0)), CBool(arr(1)))
                If id.Item2 Then
                    iarr(i) = CharacterGenerator.fAttributes(i)(id.Item1)
                Else
                    iarr(i) = CharacterGenerator.mAttributes(i)(id.Item1)
                End If
                ids(i) = id
                If i = 6 And (id.Item1 = 0 Or id.Item1 = 3) Then iarr(6) = CharacterGenerator.recolor2(iarr(6), skincolor)
            Next
            changeHairColor(haircolor, ids, iarr)
            iarr(2) = CharacterGenerator.recolor2(iarr(2), skincolor)
            iarr(4) = CharacterGenerator.recolor2(iarr(4), skincolor)
            iarr(7) = CharacterGenerator.recolor2(iarr(7), skincolor)

            img = CharacterGenerator.CreateBMP(iarr)
        Catch ex As Exception
            Return Nothing
        End Try
        reader.Close()
        Return img
    End Function
    Shared Function getPlayerFromFile(ByVal a As String) As Tuple(Of Player, Double)
        Dim reader As IO.StreamReader
        reader = IO.File.OpenText(a)
        Dim vers As Double = CDbl(reader.ReadLine())
        Dim player = New Player(reader.ReadLine)
        reader.Close()
        Return New Tuple(Of Player, Double)(player, vers)
    End Function
    Shared Sub convertSave(ByVal a As String)
        Dim lines() As String = System.IO.File.ReadAllLines(a)
        Dim player As Player = New Player(lines(UBound(lines)))
        Dim writer As IO.StreamWriter
        System.IO.File.Delete(a)
        writer = IO.File.CreateText("s1.ave")
        writer.WriteLine(Game.version)
        writer.WriteLine(player.ToString)
        For i = 1 To UBound(lines) - 1
            If lines(i).Length > 50 Then
                lines(i) = conv(lines(i))
            End If
            writer.WriteLine(lines(i))
        Next
        writer.Flush()
        writer.Close()
    End Sub
    Shared Function conv(ByVal s As String) As String
        Dim out = s.Split("*")
        Dim save As String = ""
        save += out(UBound(out) - 2) & "*"
        save += out(UBound(out) - 1) & "*"
        For i = 0 To UBound(out) - 3
            save += out(i) & "*"
        Next
        Return save
    End Function
    'color shift function
    Shared Function cShift(ByVal oC As Color, ByVal c As Color, ByVal inc As Integer)
        If oC.Equals(c) Then Return c
        Dim a, r, g, b As Integer
        a = oC.A
        r = oC.R
        g = oC.G
        b = oC.B
        If a > c.A Then a -= inc Else a += inc
        If r > c.R Then r -= inc Else r += inc
        If g > c.G Then g -= inc Else g += inc
        If b > c.B Then b -= inc Else b += inc

        If Math.Abs(a - c.A) < inc Or a > 255 Then a = c.A
        If Math.Abs(r - c.R) < inc Or r > 255 Then r = c.R
        If Math.Abs(g - c.G) < inc Or g > 255 Then g = c.G
        If Math.Abs(b - c.B) < inc Or b > 255 Then b = c.B

        Return Color.FromArgb(a, r, g, b)
    End Function

    Private Sub tmrKeyCD_Tick(sender As Object, e As EventArgs) Handles tmrKeyCD.Tick
        tmrKeyCD.Enabled = False
    End Sub
    Private Sub ReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportToolStripMenuItem.Click
        Process.Start("https://bitbucket.org/VowelHeavyUsername/dungeon_depths/issues?status=new&status=open")
    End Sub

    Sub pushLblCombatEvent(ByVal s As String)
        Dim sSplit() As String = s.Split(" ")
        Dim c As Integer = 0
        Dim ct As Integer = 0
        Dim out As String = ""
        Do While c < sSplit.Length
            If ct < 50 Then
                If Not sSplit(c).Equals("fugoo") Then
                    out += sSplit(c) & " "
                    ct += sSplit(c).Length + 1
                    c += 1
                Else
                    sSplit(c) = ""
                    out += vbCrLf
                    ct = 0
                    c += 1
                End If
            Else
                out += vbCrLf
                ct = 0
            End If
        Loop
        lblCombatEvents.Text += (out & vbCrLf)
    End Sub
    Sub updatePnlCombat(ByVal p As Player, ByVal t As Monster)
        If lblTurn.Text.Equals("Turn: " & turn) Or t Is Nothing Then Exit Sub
        lblPHealth.Text = p.health & "/" & p.getmaxHealth
        lblEHealth.Text = t.health & "/" & t.maxHealth
        lblTurn.Text = "Turn: " & turn
        lblPName.Text = p.name
        lblEName.Text = t.getName
        If t.getName.Length > 10 Then
            Dim tRatio = 10 / t.getName.Length
            Dim newFont As Font = New System.Drawing.Font("Consolas", CInt(9 * 2 * tRatio * Me.Size.Width / 688))
            lblEName.Font = newFont
        Else
            Dim newFont As Font = New System.Drawing.Font("Consolas", CInt(9 * Me.Size.Width / 688))
            lblEName.Font = newFont
        End If

        If lblEHealthChange.Tag > 0 Then
            lblEHealthChange.Text = "+" & lblEHealthChange.Tag
            lblEHealthChange.ForeColor = Color.YellowGreen
        Else
            lblEHealthChange.Text = lblEHealthChange.Tag
            lblEHealthChange.ForeColor = Color.Crimson
        End If
        If lblEHealthChange.Tag = 0 Then lblEHealthChange.Visible = False Else lblEHealthChange.Visible = True
        lblEHealthChange.Tag = 0

        If lblPHealtDiff.Tag > 0 Then
            lblPHealtDiff.Text = "+" & lblPHealtDiff.Tag
            lblPHealtDiff.ForeColor = Color.YellowGreen
        Else
            lblPHealtDiff.Text = lblPHealtDiff.Tag
            lblPHealtDiff.ForeColor = Color.Crimson
        End If
        If lblPHealtDiff.Tag = 0 Then lblPHealtDiff.Visible = False Else lblPHealtDiff.Visible = True
        lblPHealtDiff.Tag = 0

        Dim ratioEH As Double = t.health / t.maxHealth
        picEHbar.Size = New Size(ratioEH * 174, 15)
        Dim x As Integer = picEHbar.Location.X + (ratioEH * 174) - 30
        If x < picEHbar.Location.X Then x = picEHbar.Location.X
        lblEHealthChange.Location = New Point(x, lblEHealthChange.Location.Y)
        If ratioEH <= 0.2 Then picEHbar.BackColor = Color.Crimson Else picEHbar.BackColor = Color.YellowGreen

        Dim ratioPH As Double = p.health / p.getmaxHealth
        picPHealth.Size = New Size(ratioPH * 174, 15)
        x = picPHealth.Location.X + (ratioPH * 174) - 30
        If x > picPHealth.Location.X + 174 - 30 Then x = picPHealth.Location.X + 174 - 30
        lblPHealtDiff.Location = New Point(x, lblPHealtDiff.Location.Y)
        If ratioPH <= 0.2 Then picPHealth.BackColor = Color.Crimson Else picPHealth.BackColor = Color.YellowGreen

        player.UIupdate()
    End Sub
    Sub pnlCombatClose()
        pnlCombat.Visible = False
        lblCombatEvents.Text = ""
    End Sub
    Shared Sub changeHairColor(ByVal c As Color, ByVal iarrind() As Tuple(Of Integer, Boolean), ByRef iarr As Image())
        Dim t(16) As Image
        If iarrind(1).Item2 Then
            If iarrind(1).Item1 < 5 Then
                t(1) = CharacterGenerator.getImg("img/fRearHair2")(iarrind(1).Item1)
            Else
                t(1) = CharacterGenerator.getImg("img/fTF/tfRearHair2")(iarrind(1).Item1 - 5)
            End If
            If iarrind(5).Item1 < 5 Then
                t(5) = CharacterGenerator.getImg("img/fRearHair1")(iarrind(5).Item1)
            Else
                t(5) = CharacterGenerator.getImg("img/fTF/tfRearHair1")(iarrind(5).Item1 - 5)
            End If
            If iarrind(15).Item1 < 5 Then
                t(15) = CharacterGenerator.getImg("img/fFrontHair")(iarrind(15).Item1)
            Else
                t(15) = CharacterGenerator.getImg("img/fTF/tfFrontHair")(iarrind(15).Item1 - 6)
            End If
            CharacterGenerator.fFrontHair(0) = CharacterGenerator.picPort.Image
        Else
            If iarrind(1).Item1 < 5 Then
                t(1) = CharacterGenerator.getImg("img/mRearHair2")(iarrind(1).Item1)
            Else
                t(1) = CharacterGenerator.getImg("img/mTF/tfRearHair2")(iarrind(1).Item1 - 5)
            End If
            If iarrind(5).Item1 < 5 Then
                t(5) = CharacterGenerator.getImg("img/mRearHair1")(iarrind(5).Item1)
            Else
                t(5) = CharacterGenerator.getImg("img/mTF/tfRearHair1")(iarrind(5).Item1 - 5)
            End If
            If iarrind(15).Item1 < 5 Then
                t(15) = CharacterGenerator.getImg("img/mFrontHair")(iarrind(15).Item1)
            Else
                t(15) = CharacterGenerator.getImg("img/mTF/tfFrontHair")(iarrind(15).Item1 - 6)
            End If
            CharacterGenerator.mFrontHair(0) = CharacterGenerator.picPort.Image
        End If
        If iarrind(10).Item2 Then
            t(10) = CharacterGenerator.getImg("img/fEyebrows")(iarrind(10).Item1)
        Else
            If iarrind(10).Item1 < 3 Then t(10) = CharacterGenerator.getImg("img/mEyebrows")(iarrind(10).Item1)
        End If
        If iarrind(15).Item1 = 0 Then iarr(15) = CharacterGenerator.picPort.Image
        iarr(1) = CharacterGenerator.recolor(t(1), c)
        iarr(5) = CharacterGenerator.recolor(t(5), c)
        If Not iarr(15).Equals(CharacterGenerator.picPort.Image) Then iarr(15) = CharacterGenerator.recolor(t(15), c)
        If iarrind(10).Item1 < 3 Then iarr(10) = CharacterGenerator.recolor(t(10), c)
    End Sub
End Class
