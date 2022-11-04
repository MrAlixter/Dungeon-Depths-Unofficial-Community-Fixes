Imports System.ComponentModel
Imports System.IO
Imports System.Threading

Public Enum cmds
    up
    down
    left
    right
    inspect
    talk
    attack
    spell
    special
    wait
    run
    drink
    use
    shop
    earmor
    eaccessory
    eweapon
    inspectself
    eat
    yes
    no
End Enum

Public Class Game
    '| -- Board Backend -- |
    Public mDun As Dungeon
    Public currFloor As mFloor

    '| -- Board Front End -- |  
    Private Const VIEW_HEIGHT As Integer = 15
    Private Const VIEW_WIDTH As Integer = 23
    Dim board As Image                                  '(NOT SAVED)
    Public mPics(,) As PictureBox                       '(NOT SAVED)
    Dim viewArray(VIEW_HEIGHT, VIEW_WIDTH) As Integer   '(NOT SAVED)
    Public last_tile As Tuple(Of String, Point)         '(NOT SAVED)

    '| -- Dungeon Settings -- |
    Public seed As String = "noseed"
    Public mBoardWidth As Integer = 60
    Public mBoardHeight As Integer = 60
    Public chestFreqMin As Integer = 3
    Public chestFreqRange As Integer = 8
    Public chestSizeDependence As Integer = 30
    Public chestRichnessBase As Integer = 1
    Public chestRichnessRange As Integer = 5
    Public encounterRate As Integer = 25
    Public eClockResetVal As Integer = 5
    Public trapFreqMin As Integer = 3
    Public trapFreqRange As Integer = 5
    Public trapSizeDependence As Integer = 30

    '| -- Game Settings -- |
    Public screenSize As String
    Public compOOT As Boolean
    Public stealEverything As Boolean  'not added yet

    '| -- Player(s) -- |
    Public player1 As Player
    Public player_image As Image                        '(NOT SAVED)

    '| -- Entities -- |
    Public updatable_queue As UpdatableQueue = New UpdatableQueue
    Public npc_list As List(Of NPC) = New List(Of NPC)  '(NOT SAVED)
    Public combat_engaged As Boolean = False            '(NOT SAVED)

    '| -- Shop NPCs -- |
    Public shop_npc_list As List(Of ShopNPC) = New List(Of ShopNPC)
    Public shopkeeper, swiz, hteach, fvend, wsmith, cbrok, mgirl, ttraveler, fqueen As ShopNPC
    Public active_shop_npc As ShopNPC                   '(NOT SAVED)
    Public shop_npc_engaged As Boolean = False          '(NOT SAVED)

    '| -- Keys/Commands -- |
    Private last_keys_pressed As String = ""            '(NOT SAVED)

    '| -- Inventory -- |
    Dim selectedItem As Item = New Item()               '(NOT SAVED)
    Public floor_4_starting_inv As New ArrayList()

    '| -- Misc. Variables -- |
    Public turn As Integer = 0                          '(NOT SAVED)
    Public version As Double = 11.0
    Public sessionID As Integer = DateTime.Now.GetHashCode
    Dim imagesWorker As BackgroundWorker
    Public boardWorker As BackgroundWorker
    Dim cKeys As List(Of System.Windows.Forms.Keys) = New List(Of Keys)
    Dim iHeight, iWidth As Integer
    Dim debugWindow As Debug_Window                     '(NOT SAVED)
    Public shopMenu As ShopV3                           '(NOT SAVED)
    Dim health_bar_color_grad As Bitmap = Nothing

    Dim eClock As Integer = eClockResetVal * 3
    Public solFlag As Boolean = True
    Private savePics As New List(Of Image)(11)
    Dim imagesWorkerArg = Nothing
    Dim savePicsReady As Boolean = False
    Dim boardReady As Boolean = False
    Dim selecting As Boolean = False
    Dim selectionType As String = ""
    Protected Friend selectionList As Dictionary(Of String, Action) = Nothing
    Dim maxSelectionPages As Integer = 0

    '| - STARTUP - |
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IO.File.Exists("sett.ing") Then Settings.makeNewSetting()
        If Not IO.File.Exists("configs.ave") Then createConfigs()
        If Not IO.Directory.Exists("presets") Then IO.Directory.CreateDirectory("presets")
        If Not IO.Directory.Exists("saves") Then IO.Directory.CreateDirectory("saves")
        If Not IO.Directory.Exists("floors") Then IO.Directory.CreateDirectory("floors")
        If Not IO.Directory.Exists("items") Then IO.Directory.CreateDirectory("items")

        mTile.init()
        player1 = New Player()

        Settings.applySavedSettings()

        If Settings.active(setting.noimg) Then
            picPortrait.Visible = False
            picDescPort.Visible = False
        End If

        pnlCombat.Location = New Point(115, pnlCombat.Location.Y)
        pnlDescription.Location = New Point(115, pnlDescription.Location.Y)
        pnlSaveLoad.Location = New Point(208, pnlSaveLoad.Location.Y)
        pnlSelection.Location = New Point(115, pnlSelection.Location.Y)
        pnlEquip.Location = New Point(363, pnlEquip.Location.Y)
        picStart.Location = New Point(-2, picStart.Location.Y)

        iHeight = CInt(Size.Height)
        iWidth = CInt(Size.Width)

        Game_Resize()

        loadCKeys()
        imagesWorker = New BackgroundWorker
        AddHandler imagesWorker.DoWork, AddressOf prefetchImages
        imagesWorkerArg = Nothing
        imagesWorker.RunWorkerAsync()

        If (File.Exists("img/LifeColors.png")) Then
            health_bar_color_grad = Image.FromFile("img/LifeColors.png")
        End If

        If Not System.IO.File.Exists("dis.cla") Then
            If MessageBox.Show("This game features adult content sexual in nature, and is not for anyone under the age of 18 or otherwise of legal age in their country. By clicking 'Yes' below, you confirm that you are legally an adult in your country.", "Obligatory Disclaimer", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                System.IO.File.CreateText("dis.cla")
            Else
                Me.Close()
            End If
        End If

        Spell.init()
        Special.init()

        eventDialogBox = New EventBox(txtPNLEvents, pnlEvent)
    End Sub
    Sub createConfigs()
        Dim w As StreamWriter
        w = File.CreateText("configs.ave")
        w.WriteLine("OemQuestion")
        w.WriteLine("N")
        w.WriteLine("Y")
        w.WriteLine("M")
        w.WriteLine("OemQuotes")
        w.WriteLine("L")
        w.WriteLine("K")
        w.WriteLine("J")
        w.WriteLine("P")
        w.WriteLine("U")
        w.WriteLine("Q")
        w.WriteLine("B")
        w.WriteLine("V")
        w.WriteLine("C")
        w.WriteLine("Z")
        w.WriteLine("X")
        w.WriteLine("T")
        w.WriteLine("OemSemicolon")
        w.WriteLine("D")
        w.WriteLine("A")
        w.WriteLine("S")
        w.WriteLine("W")
        w.Close()
    End Sub
    Sub newGame()
        If combat_engaged Or shop_npc_engaged Then Exit Sub

        cleanupPanels()

        player1 = New Player()

        'newGame prepares the application at the start of a new game
        combat_engaged = False
        btnS.Visible = False
        btnL.Visible = False
        btnControls.Visible = False
        btnSettings.Visible = False
        btnAbout.Visible = False

        Dim chargen As New CharacterGenerator
        If Settings.active(setting.noimg) Then
            chargen.picPort.Visible = False
            chargen.pnlBody.Visible = False
        End If
        chargen.ShowDialog()
        If chargen.quit_early Then
            btnS.Visible = True
            btnL.Visible = True
            btnControls.Visible = True
            btnSettings.Visible = True
            btnAbout.Visible = True
            Exit Sub
        End If
        chargen.Dispose()

        updatable_queue.add(player1, player1.getSPD)

        If Not mDun Is Nothing Then
            TextEvent.pushYesNo("Use the existing dungeon?", AddressOf useOldDungeon, AddressOf makeNewDungeon)
        Else
            makeNewDungeon()
        End If
    End Sub

    '| - DUNGEON SETUP - |
    Sub useOldDungeon()
        mDun.reset()
        setupDungeon()
    End Sub
    Sub makeNewDungeon()
        seed = mFloor.genRNDLVLCode
        Dim genSet As New GeneratorSettings(seed)
        genSet.ShowDialog()
        seed = genSet.txtSeed.Text
        mBoardWidth = genSet.boxWidth.Value
        mBoardHeight = genSet.boxHeight.Value
        chestFreqMin = genSet.boxChestFreqMin.Value
        chestFreqRange = genSet.boxChestFreqRange.Value
        chestSizeDependence = genSet.boxChestSizeDependence.Value
        chestRichnessBase = genSet.boxChestRichnessBase.Value
        chestRichnessRange = genSet.boxChestRichnessRange.Value
        eClockResetVal = genSet.boxEClockResetVal.Value
        encounterRate = genSet.boxEncounterRate.Value
        trapFreqMin = genSet.boxTrapFreqMin.Value
        trapFreqRange = genSet.boxTrapFreqRange.Value
        trapSizeDependence = genSet.boxTrapSizeDependence.Value
        'creates the shopkeepers
        shop_npc_list.Clear()
        shopkeeper = ShopNPC.shopFactory(0)
        swiz = ShopNPC.shopFactory(1)
        hteach = ShopNPC.shopFactory(2)
        fvend = ShopNPC.shopFactory(3)
        wsmith = ShopNPC.shopFactory(4)
        cbrok = ShopNPC.shopFactory(5)
        mgirl = ShopNPC.shopFactory(6)
        ttraveler = ShopNPC.shopFactory(7)
        fqueen = ShopNPC.shopFactory(8)
        shop_npc_list.AddRange({shopkeeper, swiz, hteach, fvend, wsmith, cbrok, mgirl, ttraveler, fqueen})
        mDun = New Dungeon

        setupDungeon()
    End Sub
    Sub setupDungeon()
        initLoadBar()
        If mBoardWidth * mBoardHeight < 4 Then
            Do While mBoardWidth * mBoardHeight < 4
                If mBoardHeight < mBoardWidth Then
                    mBoardHeight += 1
                Else
                    mBoardWidth += 1
                End If
            Loop
        End If
        'lblLoadMsg.Visible = True
        Select Case Int(Rnd() * 2)
            Case Else
                lblLoadMsg.Text = "You can challenge a floor boss at any time by finding the stairs " & vbCrLf &
                                  "and either clicking the ""Challenge Boss?"" button, or hitting the " & vbCrLf &
                                  "yes key (y by default)."
        End Select

        'create the dungeon
        updateLoadbar(40)
        mDun.setFloor(currFloor)
        initializeBoard(False)
        updateLoadbar(60)

        'setup the player
        player1.currState = New State(player1)
        player1.sState = New State(player1)
        player1.pState = New State(player1)

        eClock = eClockResetVal * 3

        turn = 0

        lstLog.Items.Clear()
        TextEvent.pushLog("You see before you a dungeon.")
        picStart.Visible = False

        'this also updates the player's UI
        player1.UIupdate()

        updateLoadbar(99)
        boardWorker.CancelAsync()

        drawBoard()
    End Sub
    Sub loadCKeys()
        cKeys.Clear()
        Dim sr As StreamReader
        Dim kc As KeysConverter = New KeysConverter()
        sr = IO.File.OpenText("configs.ave")
        Dim nextKey As String = sr.ReadLine()
        While nextKey <> ""
            cKeys.Add(kc.ConvertFromString(nextKey))
            nextKey = sr.ReadLine()
        End While
        cKeys.Reverse()
        sr.Close()
    End Sub

    '| - BOARD GENERATION - |
    Public Sub initializeBoard(Optional Draw As Boolean = True)
        lblEvent.Visible = False
        player1.canMoveFlag = False
        last_tile = Nothing
        'newBoard()

        player1.setPlayerImage()
        If Draw Then drawBoard()
    End Sub
    Sub newBoard()
        'newBoard creates a new representation of the board.
        player1.setPlayerImage()
        Dim Margin As Integer = 3
        Dim XSize As Double = 23 * (CDbl(Me.Size.Width) / iWidth)
        Dim YSize As Double = 23 * (CDbl(Me.Size.Height) / iHeight)

        'create all of  the board lables dynamacly at runtime
        Dim viewWidth = 23
        Dim viewHeight = 15

        If Not mPics Is Nothing Then
            For y = 0 To viewHeight
                For x = 0 To viewWidth
                    If Not mPics(y, x) Is Nothing Then mPics(y, x).Dispose()
                Next
            Next
        End If

        ReDim mPics(viewHeight, viewWidth)

        For y As Integer = 0 To viewHeight - 1
            For x As Integer = 0 To viewWidth - 1
                Dim newPicture As PictureBox = New PictureBox()
                newPicture.Name = "boardBox|" & x & "_" & y
                newPicture.BackgroundImageLayout = ImageLayout.Stretch
                newPicture.Size = New Point(YSize * 1.25, XSize * 1.25)
                newPicture.Location = New Point(50 + x * (XSize * 1.233), 75 + y * (YSize * 1.233))
                newPicture.Visible = True
                'newPicture.BorderStyle = BorderStyle.FixedSingle
                Me.Controls.Add(newPicture)
                mPics(y, x) = newPicture
            Next
        Next
    End Sub
    Private Sub boxBoard_Draw(sender As Object, e As PaintEventArgs)
        'Dim startTime As Double = DDDateTime.getTimeNow()
        'e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
        'e.Graphics.DrawImage(map, CInt((picBoard.Width - (map.Width * magnification)) / 2) + xOffset, CInt((picBoard.Height - (map.Height * magnification)) / 2) + yOffset, map.Width * magnification + 0, map.Height * magnification + 0)
        'Dim magnification As Double = 25 / 60
        'Dim xOffSet As Integer, yOffset As Integer = 0
        'xOffSet = player1.pos.X * -25
        'yOffset = player1.pos.Y * -25
        'xOffSet = 25
        'yOffset = 25
        'e.Graphics.FillRectangle(Brushes.Purple, 0, 0, boxBoard.Width, boxBoard.Height)
        'e.Graphics.DrawImage(savedBoardPic, CInt(boxBoard.Width / 2) + xOffSet, CInt(boxBoard.Height / 2) + yOffset, CInt(savedBoardPic.Width * magnification), CInt(savedBoardPic.Height * magnification))

        'e.Graphics.DrawImage(boardPic, CInt(boardPic.Width / 2) + xOffSet, CInt(boardPic.Height / 2) + yOffset, CInt(boardPic.Width * magnification), CInt(boardPic.Height * magnification))
        'e.Graphics.DrawImage(seenBoardPic, CInt(seenBoardPic.Width / 2) + xOffSet, CInt(seenBoardPic.Height / 2) + yOffset, CInt(seenBoardPic.Width * magnification), CInt(seenBoardPic.Height * magnification))

        'e.Graphics.DrawImage(boardPic, CInt(boxBoard.Width / 2) + xOffSet, CInt(boxBoard.Height / 2) + yOffset, CInt(boardPic.Width * magnification), CInt(boardPic.Height * magnification))
        'e.Graphics.DrawImage(seenBoardPic, CInt(boxBoard.Width / 2) + xOffSet, CInt(boxBoard.Height / 2) + yOffset, CInt(boardPic.Width * magnification), CInt(boardPic.Height * magnification))

        '15 tall, 23 wide
        'e.Graphics.DrawImage(picPlayer.BackgroundImage, CInt(Math.Floor(11.5 * 25)) - 1, CInt(Math.Floor(7.5 * 25)) - 1, CInt(picPlayer.BackgroundImage.PhysicalDimension.Width * magnification), CInt(picPlayer.BackgroundImage.PhysicalDimension.Height * magnification))
        'Dim endTime = DDDateTime.getTimeNow()
        'Console.WriteLine("DRAW TIME: " + (endTime - startTime).ToString())
    End Sub

    '| - DRAW - |
    Sub drawBoard()
        'Dim startTime As Double = DDDateTime.getTimeNow()
        '"discover" any hidden tiles adjacent to the player and erase the players last location
        viewBubble()

        'update the combat banner
        If combat_engaged Then
            updatePnlCombat(player1, player1.currTarget)
        End If


        'fill in the stairs if they are missing
        currFloor.mBoard(currFloor.stairs.Y, currFloor.stairs.X).Text = "H"

        'fill in any missing chests
        For Each c In currFloor.chestList
            currFloor.mBoard(c.pos.Y, c.pos.X).Text = "#"
        Next

        'fill in any missing statues
        For Each s In currFloor.statueList
            If s.pos.X <> -1 And s.pos.Y <> -1 Then
                currFloor.mBoard(s.pos.Y, s.pos.X).Text = s.getBoardCharacter()
            End If
        Next

        'fill in any missing shop NPCs
        For Each sNPC In shop_npc_list
            If Not sNPC.isDead AndAlso sNPC.pos.X >= 0 And sNPC.pos.Y >= 0 And sNPC.pos.Y < mBoardHeight And sNPC.pos.X < mBoardWidth Then
                currFloor.mBoard(sNPC.pos.Y, sNPC.pos.X).Text = "$"
            End If
        Next

        'activate any traps that the player stepped on
        If currFloor.mBoard(player1.pos.Y, player1.pos.X).Text = "+" OrElse currFloor.mBoard(player1.pos.Y, player1.pos.X).Text = "♩" Then
            For Each t In currFloor.trapList
                If t.pos = player1.pos And Not t.Equals(New Point(-1, -1)) Then
                    Try
                        If Trap.shouldBreak(player1) Then Throw New Exception("Trap should break.")
                        t.activate()
                    Catch ex As Exception
                        TextEvent.push("Your foot falls on an unseen pressure plate, with an audible click..." & DDUtils.RNRN &
                        "...but nothing happens.")
                    End Try
                    Exit For
                End If
            Next
        End If

        If Not last_tile Is Nothing Then
            currFloor.mBoard(last_tile.Item2.Y, last_tile.Item2.X).Text = last_tile.Item1
            Console.WriteLine("Loading last tile: " & last_tile.Item1)
            last_tile = Nothing
        End If

        If Not DDConst.NOT_REDRAWN_CHARS.Contains(currFloor.mBoard(player1.pos.Y, player1.pos.X).Text) Then
            Console.WriteLine("Saving current tile: " & currFloor.mBoard(player1.pos.Y, player1.pos.X).Text)
            last_tile = New Tuple(Of String, Point)(currFloor.mBoard(player1.pos.Y, player1.pos.X).Text, New Point(player1.pos.X, player1.pos.Y))
        End If

        currFloor.mBoard(player1.pos.Y, player1.pos.X).Text = "@"

        zoom()

        If mDun.floorboss.ContainsKey(mDun.numCurrFloor) AndAlso currFloor.beatBoss = False AndAlso Not mDun.floorboss(mDun.numCurrFloor).Equals("Key") And
            combat_engaged = False And player1.health > 0 And player1.canMoveFlag = True AndAlso
            New Point(player1.pos.Y, player1.pos.X).Equals(New Point(currFloor.stairs.Y, currFloor.stairs.X)) Then
            If Not combat_engaged Then TextEvent.pushYesNo("Challenge the floor boss?", AddressOf ChallengeBoss, Nothing)
        End If

        'If picNPC.Visible Then picNPC.BackgroundImage = NPCimgList(img_index)

        player1.UIupdate(False)

        If player1.isDead And lblEvent.Visible = False And pnlEvent.Visible = False Then player1.die()

        drawBoardView()
        'Dim endTime = DDDateTime.getTimeNow()
        'Console.WriteLine(" - DRAW BOARD TIME: " + (endTime - startTime).ToString())
    End Sub
    Sub drawBoardView()
        Dim x_size As Integer = Int(30 * (CSng(Me.Size.Width) / iWidth))
        Dim y_size As Integer = Int(30 * (CSng(Me.Size.Height) / iHeight))

        Dim board_width = (x_size * VIEW_WIDTH)
        Dim board_height = (x_size * VIEW_HEIGHT)
        Dim board As Bitmap = New Bitmap(board_width, board_height)

        Dim g As Graphics = Graphics.FromImage(board)
        g.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
        g.CompositingMode = Drawing2D.CompositingMode.SourceOver

        For y As Integer = 0 To VIEW_HEIGHT - 1
            For x As Integer = 0 To VIEW_WIDTH - 1
                Select Case mDun.numCurrFloor
                    Case 6, 7, 8, 9, 10, 11, 12
                        g.DrawImage(getForestTileImg(x, y, viewArray), x_size * x, y_size * y, x_size, y_size)
                    Case 13
                        g.DrawImage(getFoggyForestTileImg(x, y, viewArray), x_size * x, y_size * y, x_size, y_size)
                    Case 14
                        g.DrawImage(getHubTileImg(x, y, viewArray), x_size * x, y_size * y, x_size, y_size)
                        'Case 15
                        '    g.DrawImage(getDesertTileImg(x, y, viewArray), x_size * x, y_size * y, x_size, y_size)
                    Case 9999, 10000
                        g.DrawImage(getSpaceTileImg(x, y, viewArray), x_size * x, y_size * y, x_size, y_size)
                    Case 91017
                        g.DrawImage(getLegacyTileImg(x, y, viewArray), x_size * x, y_size * y, x_size, y_size)
                    Case 91018
                        g.DrawImage(getCaveHTileImg(x, y, viewArray), x_size * x, y_size * y, x_size, y_size)
                    Case Is > 14
                        g.DrawImage(getHubTileImg(x, y, viewArray), x_size * x, y_size * y, x_size, y_size)
                    Case Else
                        g.DrawImage(getDungeonTileImg(x, y, viewArray), x_size * x, y_size * y, x_size, y_size)
                End Select
            Next
        Next

        If Not picBoard.Size.Height = board_height Or Not picBoard.Size.Width = board_width Then picBoard.Size = New Size(board_width, board_height)
        picBoard.BackgroundImage = board
        g.Dispose()
    End Sub
    Sub viewBubble()
        'viewBubble "discovers" the area around the player and erases the players previous location
        Dim viewRad = 1
        If player1.perks(perk.lightsource) > 0 Then viewRad = 2
        If player1.equippedGlasses.getAName.Equals("All-Seeing_Shades") Then viewRad = 5

        'Dim startTime As Double = DDDateTime.getTimeNow()
        For indY = -viewRad To viewRad
            For indX = -viewRad To viewRad
                Dim x = player1.pos.X + indX
                Dim y = player1.pos.Y + indY
                If (y < currFloor.mBoardHeight And y >= 0 And x < currFloor.mBoardWidth And x >= 0) Then
                    Dim tile = currFloor.mBoard(y, x)

                    If tile.Text = "@" Then tile.Text = ""

                    If tile.Text = "H" And tile.Tag < 2 Then
                        TextEvent.pushLog("Floor " & mDun.numCurrFloor & ": Staircase Discovered")
                    End If

                    If tile.Text = "#" And tile.Tag < 2 Then
                        TextEvent.pushLog("Chest discovered!")
                    End If

                    If tile.Text = "$" And tile.Tag < 2 Then
                        TextEvent.pushLog("Shop discovered!")
                    End If

                    If tile.Text = "`" And tile.Tag < 2 Then
                        TextEvent.pushLog("Statue discovered!")
                    End If

                    If tile.Text = "d" And tile.Tag < 2 Then
                        TextEvent.pushLog("Fox Statue discovered!")
                    End If

                    If tile.Tag = 1 Then tile.Tag = 2
                End If
            Next
        Next

        'Dim endTime = DDDateTime.getTimeNow()
        'Console.WriteLine("- VIEW BUBBLE TIME: " + (endTime - startTime).ToString())
    End Sub
    Sub zoom()
        'zoom interperates the data around the player from mBoard, and displays it on mPics

        'Dim startTime As Double = DDDateTime.getTimeNow()
        Dim x As Integer = 0
        Dim y As Integer = 0
        For indY = -7 To 7
            x = 0
            For indX = -11 To 11
                If (player1.pos.Y + indY >= 0 And player1.pos.Y + indY < currFloor.mBoardHeight) And (player1.pos.X + indX >= 0 And player1.pos.X + indX < currFloor.mBoardWidth) Then
                    'get the tile's text/tag
                    'Console.WriteLine(player1.pos.X + indX & ", " & player1.pos.Y + indY)
                    Dim tileText As String = currFloor.mBoard(player1.pos.Y + indY, player1.pos.X + indX).Text
                    Dim tileTag As Integer = currFloor.mBoard(player1.pos.Y + indY, player1.pos.X + indX).Tag

                    viewArray(y, x) = tileTag
                    If tileTag = 2 Or DDConst.ALWAYS_REDRAWN_CHARS.Contains(tileText) Then
                        'get the tile to display
                        viewArray(y, x) = getTileToDisplay(player1.pos.X + indX, player1.pos.Y + indY, tileText, tileTag)

                        'if the player is blind, treat all tiles as unseen
                        If player1.perks(perk.blind) > -1 Then viewArray(y, x) = 1
                    End If

                    If currFloor.mBoard(player1.pos.Y + indY, player1.pos.X + indX).Text = "@" Then
                        If indY = 0 And indX = 0 Then viewArray(y, x) = 4
                    End If
                ElseIf mDun.numCurrFloor = 13 AndAlso (player1.pos.Y + indY >= currFloor.mBoardHeight Or player1.pos.Y + indY < 0) And (player1.pos.X + indX >= 0 And player1.pos.X + indX < currFloor.mBoardWidth) Then
                    Dim y_offset = 0
                    If player1.pos.Y + indY < 0 Then
                        y_offset = currFloor.mBoardHeight + (player1.pos.Y + indY)
                    Else
                        y_offset = indY - (currFloor.mBoardHeight - player1.pos.Y)
                    End If

                    Dim tileText As String = currFloor.mBoard(y_offset, player1.pos.X + indX).Text
                    Dim tileTag As Integer = currFloor.mBoard(y_offset, player1.pos.X + indX).Tag

                    viewArray(y, x) = tileTag
                    If tileTag = 2 Or DDConst.ALWAYS_REDRAWN_CHARS.Contains(tileText) Then
                        'get the tile to display
                        viewArray(y, x) = getTileToDisplay(player1.pos.X + indX, y_offset, tileText, tileTag)

                        'if the player is blind, treat all tiles as unseen
                        If player1.perks(perk.blind) > -1 Then viewArray(y, x) = 1
                    End If

                    If currFloor.mBoard(y_offset, player1.pos.X + indX).Text = "@" Then
                        If indY = 0 And indX = 0 Then viewArray(y, x) = 4
                    End If
                Else
                    viewArray(y, x) = 0
                End If

                x += 1
            Next
            y += 1
        Next

        'Dim endTime As Double = DDDateTime.getTimeNow()
        'Console.WriteLine(" - ZOOM TIME: " + (endTime - startTime).ToString())
    End Sub
    Function getTileToDisplay(ByVal posX As Integer, ByVal posY As Integer, ByVal tileText As String, ByVal tileTag As Integer)
        'tile IDs
        '0 = Wall/Empty tile
        '1 = Undiscovered tile
        '2 = Discovered tile
        '3 = stairs
        '4 = player1
        '5 = Chest
        '6 = shopkeeper
        '7 = statue
        '8 = trap
        '9 = locked stairs
        '10 = boss stairs
        '11 = shady wizard
        '12 = crystal
        '13 = path
        '14 = h. teacher
        '15 = f. vendor
        '16 = w. smith
        '17 = c. broker
        '18 = m. magical girl
        '19 = fox statue
        '20 = fox statue (gold)
        '21 = Vertical wall
        '22 = Horizontal wall
        '23 = Time traveler
        '24 = NonShop NPC
        '25 = fire 1
        '26 = fire 2
        '27 = fire3
        '28 = firescar L1
        '29 = firescar L2
        '30 = firescar R1
        '31 = firescar R2
        '32 = firescar end L
        '33 = firescar end R
        '34 = note
        '35 = fae queen
        '36 = generic NPC

        Select Case tileText
            Case ""
                Return 2
            Case "x"
                Return 13
            Case "H"
                If Not mDun.floorboss.ContainsKey(mDun.numCurrFloor) Or currFloor.beatBoss Then
                    Return 3
                ElseIf mDun.floorboss.ContainsKey(mDun.numCurrFloor) AndAlso mDun.floorboss(mDun.numCurrFloor).Equals("Key") Then
                    Return 9
                Else
                    Return 10
                End If
            Case "#"
                Return 5
            Case "$"
                If posY = shopkeeper.pos.Y And posX = shopkeeper.pos.X Then
                    Return 6
                ElseIf posY = swiz.pos.Y And posX = swiz.pos.X Then
                    Return 11
                ElseIf posY = hteach.pos.Y And posX = hteach.pos.X Then
                    Return 14
                ElseIf posY = fvend.pos.Y And posX = fvend.pos.X Then
                    Return 15
                ElseIf posY = wsmith.pos.Y And posX = wsmith.pos.X Then
                    Return 16
                ElseIf posY = cbrok.pos.Y And posX = cbrok.pos.X Then
                    Return 17
                ElseIf posY = mgirl.pos.Y And posX = mgirl.pos.X Then
                    Return 18
                ElseIf posY = ttraveler.pos.Y And posX = ttraveler.pos.X Then
                    Return 23
                ElseIf posY = fqueen.pos.Y And posX = fqueen.pos.X Then
                    Return 35
                End If
            Case "`"
                Return 7
            Case "+"
                Return 8
            Case "c"
                Return 12
            Case "d"
                Return 19
            Case "-"
                Return 21
            Case "|"
                Return 22
            Case "G"
                Return 24
            Case "✢"
                If (Int(Rnd() * 3) = 0) Then currFloor.mBoard(posY, posX).Text = "*"
                Return 25
            Case "*"
                If (Int(Rnd() * 3) = 0) Then currFloor.mBoard(posY, posX).Text = "✢"
                Return 27
            Case ">"
                If (Int(Rnd() * 2) = 0) Then currFloor.mBoard(posY, posX).Text = "⇨"
                Return 28
            Case "⇨"
                If (Int(Rnd() * 2) = 0) Then currFloor.mBoard(posY, posX).Text = ">"
                Return 29
            Case "<"
                If (Int(Rnd() * 2) = 0) Then currFloor.mBoard(posY, posX).Text = "⇦"
                Return 30
            Case "⇦"
                If (Int(Rnd() * 2) = 0) Then currFloor.mBoard(posY, posX).Text = "<"
                Return 31
            Case "\"
                Return 32
            Case "/"
                Return 33
            Case "♩"
                Return 34
            Case "a"
                Return 36
        End Select

        Return 2
    End Function
    Function getDungeonTileImg(ByVal x As Integer, ByVal y As Integer, ByRef viewArray As Integer(,)) As Image
        Select Case viewArray(y, x)
            Case 0
                Return mTile.imgLib.getImg(tSet.dungeon, tile.wall)
            Case 1
                Return mTile.imgLib.getImg(tSet.dungeon, tile.fog)
            Case 2
                Return mTile.imgLib.getImg(tSet.dungeon, tile.tile)
            Case 3
                Return mTile.imgLib.getImg(tSet.dungeon, tile.stairs)
            Case 4
                Return player1.player_image
            Case 5
                Return mTile.imgLib.getImg(tSet.dungeon, tile.chest)
            Case 6
                Return mTile.imgLib.getImg(tSet.dungeon, tile.sk)
            Case 7
                Return mTile.imgLib.getImg(tSet.dungeon, tile.statue)
            Case 8
                Return mTile.imgLib.getImg(tSet.dungeon, tile.trap)
            Case 9
                Return mTile.imgLib.getImg(tSet.dungeon, tile.stairslock)
            Case 10
                Return mTile.imgLib.getImg(tSet.dungeon, tile.stairsboss)
            Case 11
                Return mTile.imgLib.getImg(tSet.dungeon, tile.sw)
            Case 12
                Return mTile.imgLib.getImg(tSet.dungeon, tile.crystal)
            Case 13
                Return mTile.imgLib.getImg(tSet.dungeon, tile.path)
            Case 14
                Return mTile.imgLib.getImg(tSet.dungeon, tile.ht)
            Case 15
                Return mTile.imgLib.getImg(tSet.dungeon, tile.fv)
            Case 16
                Return mTile.imgLib.getImg(tSet.dungeon, tile.ws)
            Case 17
                Return mTile.imgLib.getImg(tSet.dungeon, tile.cb)
            Case 18
                Return mTile.imgLib.getImg(tSet.dungeon, tile.mg)
            Case 24
                Return mTile.imgLib.getImg(tSet.dungeon, tile.player)
            Case 34
                Return mTile.imgLib.getImg(tSet.dungeon, tile.note)
            Case Else
                Return mTile.imgLib.getImg(tSet.dungeon, tile.wall)
        End Select
    End Function
    Function getForestTileImg(ByVal x As Integer, ByVal y As Integer, ByRef viewArray As Integer(,)) As Image
        Select Case viewArray(y, x)
            Case 0
                Return mTile.imgLib.getImg(tSet.forest, tile.wall)
            Case 1
                Return mTile.imgLib.getImg(tSet.forest, tile.fog)
            Case 2
                Return mTile.imgLib.getImg(tSet.forest, tile.tile)
            Case 3
                Return mTile.imgLib.getImg(tSet.forest, tile.stairs)
            Case 4
                Return player1.player_image
            Case 5
                Return mTile.imgLib.getImg(tSet.forest, tile.chest)
            Case 6
                Return mTile.imgLib.getImg(tSet.forest, tile.sk)
            Case 7
                Return mTile.imgLib.getImg(tSet.forest, tile.statue)
            Case 8
                Return mTile.imgLib.getImg(tSet.forest, tile.trap)
            Case 9
                Return mTile.imgLib.getImg(tSet.forest, tile.stairslock)
            Case 10
                Return mTile.imgLib.getImg(tSet.forest, tile.stairsboss)
            Case 11
                Return mTile.imgLib.getImg(tSet.forest, tile.sw)
            Case 12
                Return mTile.imgLib.getImg(tSet.forest, tile.crystal)
            Case 13
                Return mTile.imgLib.getImg(tSet.forest, tile.path)
            Case 14
                Return mTile.imgLib.getImg(tSet.forest, tile.ht)
            Case 15
                Return mTile.imgLib.getImg(tSet.forest, tile.fv)
            Case 16
                Return mTile.imgLib.getImg(tSet.forest, tile.ws)
            Case 17
                Return mTile.imgLib.getImg(tSet.forest, tile.cb)
            Case 18
                Return mTile.imgLib.getImg(tSet.forest, tile.mg)
            Case 19
                Return mTile.imgLib.getImg(tSet.forest, tile.extra11)
            Case 24
                Return mTile.imgLib.getImg(tSet.forest, tile.player)
            Case 25
                Return mTile.imgLib.getImg(tSet.forest, tile.extra1)
            Case 26
                Return mTile.imgLib.getImg(tSet.forest, tile.extra2)
            Case 27
                Return mTile.imgLib.getImg(tSet.forest, tile.extra3)
            Case 28
                Return mTile.imgLib.getImg(tSet.forest, tile.extra6)
            Case 29
                Return mTile.imgLib.getImg(tSet.forest, tile.extra7)
            Case 30
                Return mTile.imgLib.getImg(tSet.forest, tile.extra8)
            Case 31
                Return mTile.imgLib.getImg(tSet.forest, tile.extra9)
            Case 32
                Return mTile.imgLib.getImg(tSet.forest, tile.extra4)
            Case 33
                Return mTile.imgLib.getImg(tSet.forest, tile.extra5)
            Case 34
                Return mTile.imgLib.getImg(tSet.forest, tile.note)
            Case Else
                Return mTile.imgLib.getImg(tSet.dungeon, tile.wall)
        End Select
    End Function
    Function getSpaceTileImg(ByVal x As Integer, ByVal y As Integer, ByRef viewArray As Integer(,)) As Image
        Select Case viewArray(y, x)
            Case 0
                Return mTile.imgLib.getImg(tSet.space, tile.wall)
            Case 1
                Return mTile.imgLib.getImg(tSet.space, tile.fog)
            Case 2
                Return mTile.imgLib.getImg(tSet.space, tile.tile)
            Case 3
                Return mTile.imgLib.getImg(tSet.space, tile.stairs)
            Case 4
                Return player1.player_image
            Case 5
                Return mTile.imgLib.getImg(tSet.space, tile.chest)
            Case 7
                Return mTile.imgLib.getImg(tSet.space, tile.statue)
            Case 8
                Return mTile.imgLib.getImg(tSet.space, tile.trap)
            Case 12
                Return mTile.imgLib.getImg(tSet.space, tile.crystal)
            Case 13
                Return mTile.imgLib.getImg(tSet.space, tile.path)
            Case 21
                Return mTile.imgLib.getImg(tSet.space, tile.extra3)
            Case 22
                Return mTile.imgLib.getImg(tSet.space, tile.extra2)
            Case 23
                Return mTile.imgLib.getImg(tSet.space, tile.tt)
            Case 24
                Return mTile.imgLib.getImg(tSet.space, tile.player)
            Case 34
                Return mTile.imgLib.getImg(tSet.space, tile.note)
            Case Else
                Return mTile.imgLib.getImg(tSet.dungeon, tile.wall)
        End Select
    End Function
    Function getLegacyTileImg(ByVal x As Integer, ByVal y As Integer, ByRef viewArray As Integer(,)) As Image
        Select Case viewArray(y, x)
            Case 0
                Return mTile.imgLib.getImg(tSet.legacy, tile.wall)
            Case 1
                Return mTile.imgLib.getImg(tSet.legacy, tile.fog)
            Case 2
                Return mTile.imgLib.getImg(tSet.legacy, tile.tile)
            Case 3
                Return mTile.imgLib.getImg(tSet.legacy, tile.stairs)
            Case 4
                Return player1.player_image
            Case 5
                Return mTile.imgLib.getImg(tSet.legacy, tile.chest)
            Case 7
                Return mTile.imgLib.getImg(tSet.legacy, tile.crystal)
            Case 8
                Return mTile.imgLib.getImg(tSet.legacy, tile.trap)
            Case 12
                Return mTile.imgLib.getImg(tSet.legacy, tile.crystal)
            Case 13
                Return mTile.imgLib.getImg(tSet.legacy, tile.path)
            Case 16
                Return mTile.imgLib.getImg(tSet.legacy, tile.extra1)
            Case 24
                Return mTile.imgLib.getImg(tSet.legacy, tile.player)
            Case 34
                Return mTile.imgLib.getImg(tSet.legacy, tile.note)
            Case Else
                Return mTile.imgLib.getImg(tSet.dungeon, tile.wall)
        End Select
    End Function
    Function getFoggyForestTileImg(ByVal x As Integer, ByVal y As Integer, ByRef viewArray As Integer(,)) As Image
        Select Case viewArray(y, x)
            Case 0
                Return mTile.imgLib.getImg(tSet.fogforest, tile.wall)
            Case 1
                Return mTile.imgLib.getImg(tSet.fogforest, tile.fog)
            Case 2
                Return mTile.imgLib.getImg(tSet.fogforest, tile.tile)
            Case 3
                Return mTile.imgLib.getImg(tSet.fogforest, tile.stairs)
            Case 4
                Return player1.player_image
            Case 5
                Return mTile.imgLib.getImg(tSet.fogforest, tile.chest)
            Case 7
                Return mTile.imgLib.getImg(tSet.fogforest, tile.statue)
            Case 8
                Return mTile.imgLib.getImg(tSet.fogforest, tile.trap)
            Case 10
                Return mTile.imgLib.getImg(tSet.fogforest, tile.stairsboss)
            Case 12
                Return mTile.imgLib.getImg(tSet.fogforest, tile.crystal)
            Case 13
                Return mTile.imgLib.getImg(tSet.fogforest, tile.path)
            Case 15
                Return mTile.imgLib.getImg(tSet.fogforest, tile.fv)
            Case 17
                Return mTile.imgLib.getImg(tSet.fogforest, tile.cb)
            Case 24
                Return mTile.imgLib.getImg(tSet.fogforest, tile.player)
            Case 32
                Return mTile.imgLib.getImg(tSet.fogforest, tile.extra2)
            Case 33
                Return mTile.imgLib.getImg(tSet.fogforest, tile.extra3)
            Case 34
                Return mTile.imgLib.getImg(tSet.fogforest, tile.note)
            Case 35
                Return mTile.imgLib.getImg(tSet.fogforest, tile.extra1)
            Case 36
                Return mTile.imgLib.getImg(tSet.fogforest, tile.extra4)
            Case Else
                Return mTile.imgLib.getImg(tSet.dungeon, tile.wall)
        End Select
    End Function
    Function getHubTileImg(ByVal x As Integer, ByVal y As Integer, ByRef viewArray As Integer(,)) As Image
        Select Case viewArray(y, x)
            Case 0
                Return mTile.imgLib.getImg(tSet.hub, tile.wall)
            Case 1
                Return mTile.imgLib.getImg(tSet.hub, tile.fog)
            Case 2
                Return mTile.imgLib.getImg(tSet.hub, tile.tile)
            Case 3
                Return mTile.imgLib.getImg(tSet.hub, tile.stairs)
            Case 4
                Return player1.player_image
            Case 5
                Return mTile.imgLib.getImg(tSet.hub, tile.chest)
            Case 6
                Return mTile.imgLib.getImg(tSet.hub, tile.sk)
            Case 7
                Return mTile.imgLib.getImg(tSet.hub, tile.statue)
            Case 8
                Return mTile.imgLib.getImg(tSet.hub, tile.trap)
            Case 9
                Return mTile.imgLib.getImg(tSet.hub, tile.stairslock)
            Case 10
                Return mTile.imgLib.getImg(tSet.hub, tile.stairsboss)
            Case 11
                Return mTile.imgLib.getImg(tSet.hub, tile.sw)
            Case 12
                Return mTile.imgLib.getImg(tSet.hub, tile.crystal)
            Case 13
                Return mTile.imgLib.getImg(tSet.hub, tile.path)
            Case 14
                Return mTile.imgLib.getImg(tSet.hub, tile.ht)
            Case 15
                Return mTile.imgLib.getImg(tSet.hub, tile.fv)
            Case 16
                Return mTile.imgLib.getImg(tSet.hub, tile.ws)
            Case 17
                Return mTile.imgLib.getImg(tSet.hub, tile.cb)
            Case 18
                Return mTile.imgLib.getImg(tSet.hub, tile.mg)
            Case 24
                Return mTile.imgLib.getImg(tSet.hub, tile.player)
            Case 34
                Return mTile.imgLib.getImg(tSet.hub, tile.note)
            Case Else
                Return mTile.imgLib.getImg(tSet.dungeon, tile.wall)
        End Select
    End Function
    Function getDesertTileImg(ByVal x As Integer, ByVal y As Integer, ByRef viewArray As Integer(,)) As Image
        Select Case viewArray(y, x)
            Case 0
                Return mTile.imgLib.getImg(tSet.desert, tile.wall)
            Case 1
                Return mTile.imgLib.getImg(tSet.desert, tile.fog)
            Case 2
                Return mTile.imgLib.getImg(tSet.desert, tile.tile)
            Case 3
                Return mTile.imgLib.getImg(tSet.desert, tile.stairs)
            Case 4
                Return player1.player_image
            Case 5
                Return mTile.imgLib.getImg(tSet.desert, tile.chest)
            Case 7
                Return mTile.imgLib.getImg(tSet.desert, tile.crystal)
            Case 8
                Return mTile.imgLib.getImg(tSet.desert, tile.trap)
            Case 12
                Return mTile.imgLib.getImg(tSet.desert, tile.crystal)
            Case 13
                Return mTile.imgLib.getImg(tSet.desert, tile.path)
            Case 16
                Return mTile.imgLib.getImg(tSet.desert, tile.extra1)
            Case 24
                Return mTile.imgLib.getImg(tSet.desert, tile.player)
            Case 34
                Return mTile.imgLib.getImg(tSet.desert, tile.note)
            Case Else
                Return mTile.imgLib.getImg(tSet.dungeon, tile.wall)
        End Select
    End Function
    Function getCaveHTileImg(ByVal x As Integer, ByVal y As Integer, ByRef viewArray As Integer(,)) As Image
        Select Case viewArray(y, x)
            Case 0
                Return mTile.imgLib.getImg(tSet.caveh, tile.wall)
            Case 1
                Return mTile.imgLib.getImg(tSet.caveh, tile.fog)
            Case 2
                Return mTile.imgLib.getImg(tSet.caveh, tile.tile)
            Case 3
                Return mTile.imgLib.getImg(tSet.caveh, tile.stairs)
            Case 4
                Return player1.player_image
            Case 5
                Return mTile.imgLib.getImg(tSet.caveh, tile.chest)
            Case 6
                Return mTile.imgLib.getImg(tSet.caveh, tile.sk)
            Case 7
                Return mTile.imgLib.getImg(tSet.caveh, tile.statue)
            Case 8
                Return mTile.imgLib.getImg(tSet.caveh, tile.trap)
            Case 9
                Return mTile.imgLib.getImg(tSet.caveh, tile.stairslock)
            Case 10
                Return mTile.imgLib.getImg(tSet.caveh, tile.stairsboss)
            Case 11
                Return mTile.imgLib.getImg(tSet.caveh, tile.sw)
            Case 12
                Return mTile.imgLib.getImg(tSet.caveh, tile.crystal)
            Case 13
                Return mTile.imgLib.getImg(tSet.caveh, tile.path)
            Case 14
                Return mTile.imgLib.getImg(tSet.caveh, tile.ht)
            Case 15
                Return mTile.imgLib.getImg(tSet.caveh, tile.fv)
            Case 16
                Return mTile.imgLib.getImg(tSet.caveh, tile.ws)
            Case 17
                Return mTile.imgLib.getImg(tSet.caveh, tile.cb)
            Case 18
                Return mTile.imgLib.getImg(tSet.caveh, tile.mg)
            Case 24
                Return mTile.imgLib.getImg(tSet.caveh, tile.player)
            Case 25
                Return mTile.imgLib.getImg(tSet.caveh, tile.extra3)
            Case 27
                Return mTile.imgLib.getImg(tSet.caveh, tile.extra4)
            Case 34
                Return mTile.imgLib.getImg(tSet.caveh, tile.note)
            Case Else
                Return mTile.imgLib.getImg(tSet.caveh, tile.wall)
        End Select
    End Function

    '| - PROGRESS TURN - |
    Public Sub progressTurn()
        turn += 1

        '|-Set up the queue based on speed-|
        queueSetup()

        '|-Clear the previous combat logs-|
        If combat_engaged Then lblCombatEvents.Text = ""

        '|-Ping the list of updatables-|
        updatable_queue.ping()

        '|-Update the combat menu based on the turn-|
        If combat_engaged Then updatePnlCombat(player1, player1.currTarget)
    End Sub
    Public Function getTurn()
        Return turn
    End Function

    '| - COMMAND DRIVERS - |
    Function HandleKeyPress(ByVal Keydata As Keys) As Boolean
        'handleKeyPress handles the players pressed keys, and is the driver function for each one
        Dim startTime As Double = DDDateTime.getTimeNow()
        Dim endTime As Double = startTime

        If Not selecting Then
            If shouldReturnEarly(Keydata) Then Return True

            Dim spos As Point = player1.pos

            If isALetter(Keydata.ToString.ToLower) Then last_keys_pressed += Keydata.ToString.ToLower

            If normalKeyPress(Keydata) Then Return True

            updatable_queue.add(player1, player1.getSPD)

            drawBoard()

            endTime = DDDateTime.getTimeNow()
            Console.WriteLine("TOTAL TIME: " + (endTime - startTime).ToString())
            Return True
        Else
            If Keydata.Equals(Keys.Up) Then
                lstSelec.TopIndex -= 1
                endTime = DDDateTime.getTimeNow()
                Console.WriteLine("TOTAL TIME: " + (endTime - startTime).ToString())
                Return True
            ElseIf Keydata.Equals(Keys.Down) Then
                lstSelec.TopIndex += 1
                endTime = DDDateTime.getTimeNow()
                Console.WriteLine("TOTAL TIME: " + (endTime - startTime).ToString())
                Return True
            End If

            If Keydata.Equals(Keys.Back) Then
                If selectionType = "SelfTF" Or selectionType = "EnemyTF" Then
                    player1.mana += 12
                ElseIf selectionType = "BasicClassChange" Then
                    player1.gold += New BasicClassChange().value
                    leaveNPC()
                ElseIf selectionType = "AdvClassChange" Then
                    player1.gold += New AdvClassChange().value
                    leaveNPC()
                ElseIf selectionType = "yesNo" Then
                    If Not TextEvent.noAction Is Nothing Then TextEvent.noAction()
                    TextEvent.choiceText = Nothing
                    TextEvent.yesAction = Nothing
                    TextEvent.noAction = Nothing
                ElseIf selectionType = "FaeQueen" Then
                    FaeQueen.playerLeaves()
                End If

                selecting = False
                pnlSelection.Visible = False
                endTime = DDDateTime.getTimeNow()
                Console.WriteLine("TOTAL TIME: " + (endTime - startTime).ToString())
                Return True
            End If

            selection(Keydata)
        End If

        endTime = DDDateTime.getTimeNow()
        Console.WriteLine("TOTAL TIME: " + (endTime - startTime).ToString())

        Return True
    End Function
    Function normalKeyPress(ByVal Keydata As Keys) As Boolean
        Select Case Keydata
            Case cKeys(cmds.up)
                player1.moveUp()
                randomEvents()
            Case cKeys(cmds.down)
                player1.moveDown()
                randomEvents()
            Case cKeys(cmds.left)
                player1.moveLeft()
                randomEvents()
            Case cKeys(cmds.right)
                player1.moveRight()
                randomEvents()
            Case cKeys(cmds.inspect)
                Try
                    oemSemiColon()
                Catch ex As Exception
                    Return True
                End Try
            Case cKeys(cmds.talk)
                talkKey()
            Case cKeys(cmds.attack)
                attackKey()
            Case cKeys(cmds.spell)
                magicKey()
                Return True
            Case cKeys(cmds.special)
                specialKey()
            Case cKeys(cmds.wait)
                waitKey()
            Case cKeys(cmds.run)
                runKey()
            Case cKeys(cmds.drink)
                drinkKey()
            Case cKeys(cmds.use)
                useKey()
            Case cKeys(cmds.shop)
                toShopKey()
            Case cKeys(cmds.earmor)
                eArmorKey()
            Case cKeys(cmds.eaccessory)
                eOtherKey()
            Case cKeys(cmds.eweapon)
                eWeaponKey()
            Case cKeys(cmds.inspectself)
                selfinpKey()
            Case cKeys(cmds.eat)
                eatKey()
            Case cKeys(cmds.yes)
                yesKey()
            Case cKeys(cmds.no)
                noKey()
            Case Keys.Enter
                oemReturn()
            Case Keys.Up
                player1.moveUp()
                randomEvents()
            Case Keys.Down
                player1.moveDown()
                randomEvents()
            Case Keys.Left
                player1.moveLeft()
                randomEvents()
            Case Keys.Right
                player1.moveRight()
                randomEvents()
            Case Keys.Escape
                If screenSize.Equals("Maximized") Then
                    screenSize = "Large"
                    Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                    Me.WindowState = FormWindowState.Normal
                    Size = New Size(iWidth, iHeight)
                    DDUtils.resizeForm(Me)
                    If Not player1 Is Nothing Then player1.UIupdate()
                    drawBoard()
                    Return True
                End If
        End Select

        Return False
    End Function
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        'processCmdKey is a leftover from an earlier version, and may not be needed anymore
        Const WM_KEYDOWN As Integer = &H100
        If msg.Msg = WM_KEYDOWN Then
            If HandleKeyPress(keyData) Then Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Sub doLblEventOnClose()
        If Not TextEvent.lblEventOnClose Is Nothing Then
            If pnlEvent.Visible Then
                If Not TextEvent.eventDialogBox.hasHitEnd And TextEvent.eventDialogBox.getPageInd < TextEvent.eventDialogBox.getPageCt - 2 Then
                    TextEvent.eventDialogBox.nextpageL()
                    Exit Sub
                End If
            End If
            Dim lastOnClose = TextEvent.lblEventOnClose.Method.Name
            TextEvent.lblEventOnClose()
            If TextEvent.lblEventOnClose.Method.Name.Equals(lastOnClose) Then
                TextEvent.lblEventOnClose = Nothing
            End If

            If Not combat_engaged Or shop_npc_engaged Then player1.canMoveFlag = True
        End If
    End Sub
    '| -- Selection Drivers -- |
    Sub selection(ByVal Keydata As Keys)
        If Keydata.Equals(Keys.Up) Or Keydata.Equals(Keys.Down) Then
            Exit Sub
        End If
        If Keydata.Equals(Keys.Tab) Then
            scrollLstSelec()
            Exit Sub
        End If

        Dim indexes = "abcdefghijklmnopqrstuvwxyz".ToCharArray.ToList
        If indexes.Contains(Keydata.ToString.ToLower) Then
            Dim index As Integer = indexes.IndexOf(Keydata.ToString.ToLower)
            If index > lstSelec.Items.Count - 1 Then
                lblInstruc.Text = "Invalid selection:" & DDUtils.RNRN &
                                  "Please select" & vbCrLf &
                                  "another letter." & DDUtils.RNRN
                Exit Sub
            End If

            selecting = False
            player1.canMoveFlag = True
            pnlSelection.Visible = False

            If selectionType.Equals("Potion") Or selectionType.Equals("Useable") Or selectionType.Equals("Food") Then
                selectItem(index)
            ElseIf selectionType = "Magic" Then
                selectMagic(index)
            ElseIf selectionType = "Spec" Then
                selectSpec(index)
            ElseIf selectionType = "Armor" Then
                selectArmor(index)
            ElseIf selectionType = "Other" Then
                selectOther(index)
            ElseIf selectionType = "Weapon" Then
                selectWeapon(index)
            ElseIf selectionType = "SelfTF" Then
                Dim fN = player1.formName
                Dim cN = player1.className
                selectSelfTFForm(index)
                SelfPolymorph.effectP2(fN, cN)
            ElseIf selectionType = "EnemyTF" Then
                Dim fN = player1.formName
                Dim cN = player1.className
                If Not player1.currTarget Is Nothing Then TextEvent.pushLog(CStr("You transform " & player1.currTarget.getNameWithTitle & "!"))
                selectEnemyTFForm(index)
                EnemyPolymorph.effectP2(fN, cN)
            ElseIf selectionType = "BasicClassChange" Then
                selectBaseClassHypno(index)
            ElseIf selectionType = "AdvClassChange" Then
                selectAdvClassHypno(index)
            ElseIf selectionType = "Weapon" Then
                selectWeapon(index)
            ElseIf selectionType = "manySelect" Then
                selectManySelect(index)
            ElseIf selectionType = "yesNo" Then
                selectYesNo(index)
            End If

            selectedItem = Nothing
            player1.inv.invNeedsUDate = True
            player1.UIupdate()
        End If
    End Sub
    Sub selectItem(ByVal index As Integer)
        Dim subString As String = lstSelec.Items(index).ToString.Split(" (")(2)
        selectedItem = player1.inv.item(lstSelec.Items(index).ToString.Split(" (")(2))
        If Not selectedItem Is Nothing AndAlso selectedItem.getUsable Then selectedItem.use(player1)

        progressTurn()
    End Sub
    Sub selectMagic(ByVal index As Integer)
        turn += 1
        doLblEventOnClose()
        lblCombatEvents.Text = ""
        closeLblEvent()

        If player1.mana <= 0 Then
            TextEvent.push("You don't have enough mana!")
            TextEvent.pushLog("You don't have enough mana!")
            Exit Sub
        End If

        Dim subString As String = lstSelec.Items(index).ToString.Split("-")(1)
        subString = subString.Split("·")(0)
        subString = subString.Trim()

        If combat_engaged Then
            Dim m As NPC = getCombatTarget(player1)

            If subString = FlashBolt.SPELL_NAME Or subString = FlashHeal.SPELL_NAME Then
                Spell.spellCast(m, player1, subString)
            Else
                player1.nextCombatAction = Sub(t As Entity) Spell.spellCast(t, player1, subString)
            End If

            queueSetup()
            updatable_queue.ping()

            'updates the combat banner
            updatePnlCombat(player1, player1.currTarget)
        Else
            Spell.spellCast(Nothing, player1, subString)
        End If

    End Sub
    Sub selectSpec(ByVal index As Integer)
        turn += 1
        doLblEventOnClose()
        lblCombatEvents.Text = ""
        closeLblEvent()

        Dim m As NPC = getCombatTarget(player1)

        Dim subString As String = lstSelec.Items(index).ToString.Split("-")(1)
        subString = subString.Split("·")(0)
        subString = subString.Trim()

        If combat_engaged Then
            player1.nextCombatAction = Sub(t As Entity) Special.specPerform(t, player1, subString)
        Else
            Special.specPerform(m, player1, subString)
        End If

        If cboxSpec.Items.Count = 0 Then
            cboxSpec.Visible = False
            btnSpec.Visible = False
        End If

        cboxSpec.Text = "-- Select --"
        queueSetup()
        updatable_queue.ping()

        'updates the combat banner
        updatePnlCombat(player1, player1.currTarget)
    End Sub
    Sub selectArmor(ByVal index As Integer)
        Dim subString As String = lstSelec.Items(index).ToString.Split(" (")(2)

        EquipmentDialogBackend.equipArmor(player1, subString)

        'updates the player1, the stat display, and the portrait before the form closes
        player1.drawPort()
        player1.UIupdate()

    End Sub
    Sub selectBaseClassHypno(ByVal index As Integer)
        Dim subString As String = lstSelec.Items(index).ToString.Split(" (")(2)

        BasicClassChange.selectedClass = subString
        BasicClassChange.hypnotizeP()
    End Sub
    Sub selectAdvClassHypno(ByVal index As Integer)
        Dim subString As String = lstSelec.Items(index).ToString.Split(" (")(2)

        AdvClassChange.selectedClass = subString
        AdvClassChange.hypnotizeP()
    End Sub
    Sub selectOther(ByVal index As Integer)
        Dim subString As String = lstSelec.Items(index).ToString.Split(" (")(2)

        EquipmentDialogBackend.equipAcce(player1, subString)

        'updates the player1, the stat display, and the portrait before the form closes
        player1.drawPort()
        player1.UIupdate()

    End Sub
    Sub selectSelfTFForm(ByVal index As Integer)
        Dim subString As String = lstSelec.Items(index).ToString.Split(" (")(2)

        Polymorph.transform(player1, subString)
    End Sub
    Sub selectEnemyTFForm(ByVal index As Integer)
        Dim subString As String = lstSelec.Items(index).ToString.Split(" (")(2)
        If player1.currTarget.GetType().IsSubclassOf(GetType(ShopNPC)) Then
            '|-Polymorph a NPC-|
            Polymorph.transformN(player1.currTarget, subString)
        Else
            '|-Polymorph an Enemy-|
            Polymorph.transform(player1.currTarget, subString)
        End If
    End Sub
    Sub selectWeapon(ByVal index As Integer)
        Dim subString As String = lstSelec.Items(index).ToString.Split(" (")(2)

        EquipmentDialogBackend.equipWeapon(player1, subString)

        'updates the player1, the stat display, and the portrait before the form closes
        player1.drawPort()
        player1.UIupdate()

    End Sub
    Sub selectManySelect(ByVal index As Integer)
        Dim subString As String = lstSelec.Items(index).ToString.Substring(4)

        Console.Out.WriteLine(subString)
        selectionList(subString)()
    End Sub
    Sub selectYesNo(ByVal index As Integer)
        Dim tempAct
        If Not TextEvent.yesAction Is Nothing Then tempAct = TextEvent.yesAction.Clone Else tempAct = Nothing

        If index = 0 Then
            If Not TextEvent.yesAction Is Nothing Then TextEvent.yesAction()
        Else
            If Not TextEvent.noAction Is Nothing Then TextEvent.noAction()
        End If

        If tempAct Is TextEvent.yesAction Then
            TextEvent.choiceText = Nothing
            TextEvent.yesAction = Nothing
            TextEvent.noAction = Nothing
        End If
    End Sub
    Sub fillLstSelec(ByVal l As List(Of String), Optional ByVal o As Integer = 0)
        Dim ct = 0

        For i = DDConst.SELECT_INDS.Count * o To (DDConst.SELECT_INDS.Count * (o + 1)) - 1
            If i >= l.Count Then Exit For
            lstSelec.Items.Add(DDConst.SELECT_INDS(ct) & " - " & l(i).ToString)

            ct += 1
        Next

        maxSelectionPages = Math.Ceiling(l.Count / DDConst.SELECT_INDS.Count)
    End Sub
    Sub fillLstSelecItem(ByVal l As List(Of Item), Optional ByVal o As Integer = 0)
        Dim itemNames = New List(Of String)
        For Each i In l
            If i.getCount > 0 Then itemNames.Add(i.getName)
        Next

        fillLstSelec(itemNames, o)
    End Sub
    Sub scrollLstSelec()
        If maxSelectionPages < 2 Then Exit Sub

        If lstSelec.Tag >= maxSelectionPages - 1 Then lstSelec.Tag = 0 Else lstSelec.Tag += 1

        lstSelec.Items.Clear()

        If selectionType.Equals("Potion") Then
            fillLstSelecItem(player1.inv.getPotions.ToList, lstSelec.Tag)
        ElseIf selectionType.Equals("Useable") Then
            fillLstSelecItem(player1.inv.getUseable.ToList, lstSelec.Tag)
        ElseIf selectionType.Equals("Food") Then
            fillLstSelecItem(player1.inv.getFood.ToList, lstSelec.Tag)
        ElseIf selectionType = "Magic" Then
            If shop_npc_engaged Then
                Dim l = New List(Of String)
                For Each i In cboxNPCMG.Items
                    l.Add(lineup(i.ToString, Spell.spellCost(i.ToString)))
                Next
                fillLstSelec(l, lstSelec.Tag)
            Else
                Dim l = New List(Of String)
                For Each i In player1.knownSpells
                    l.Add(lineup(i.ToString, Spell.spellCost(i.ToString)))
                Next
                fillLstSelec(l, lstSelec.Tag)
            End If
        ElseIf selectionType = "Spec" Then
            Dim l = New List(Of String)
            For Each i In cboxSpec.Items
                l.Add(i.ToString)
            Next
            fillLstSelec(l, lstSelec.Tag)
        ElseIf selectionType = "Armor" Then
            Dim l = New List(Of String)
            l.Add("Naked")
            Equipment.defaultClothesOptions(l)
            For Each i In player1.inv.getArmors.Item2
                If i.getCount > 0 Then l.Add(i.getName)
            Next
            fillLstSelec(l, lstSelec.Tag)
        ElseIf selectionType = "Other" Then
            Dim l = New List(Of String)
            l.Add("Nothing")
            For Each i In player1.inv.getAccesories.Item2
                If i.getCount > 0 Then l.Add(i.getName)
            Next
            fillLstSelec(l, lstSelec.Tag)
        ElseIf selectionType = "Weapon" Then
            Dim l = New List(Of String)
            l.Add("Fists")
            For Each i In player1.inv.getWeapons.Item2
                If i.getCount > 0 Then l.Add(i.getName)
            Next
            fillLstSelec(l, lstSelec.Tag)
        ElseIf selectionType = "yesNo" Then
            Exit Sub
        End If

        lblInstruc.Text = "Type the seletion's" & vbCrLf &
                        "letter, and use the" & vbCrLf &
                        "arrow keys to scroll." & DDUtils.RNRN &
                        "Use the tab key to" & vbCrLf &
                        "change pages." & DDUtils.RNRN &
                        (lstSelec.Tag + 1) & " of " & maxSelectionPages
    End Sub
    Sub toPNLSelec(ByVal mode As String)
        selecting = True
        pnlSelection.BringToFront()
        lstSelec.Items.Clear()
        lstSelec.Tag = 0
        lstInventory.Focus()

        Select Case mode
            Case "Potion"
                lblWhat.Text = "Drink what?"
                fillLstSelecItem(player1.inv.getPotions.ToList)
            Case "Useable"
                lblWhat.Text = "Use what?"
                fillLstSelecItem(player1.inv.getUseable.ToList)
            Case "SelfTF"
                lblWhat.Text = "Polymorph to what?"
                fillLstSelec(player1.selfPolyForms)
            Case "BasicClassChange"
                lblWhat.Text = "Change classes to what?"
                fillLstSelec(BasicClassChange.getClasses(player1))
            Case "AdvClassChange"
                lblWhat.Text = "Change classes to what?"
                fillLstSelec(AdvClassChange.getClasses(player1))
            Case "EnemyTF"
                lblWhat.Text = "Polymorph to what?"
                fillLstSelec(player1.enemPolyForms)
            Case "EnemyTF"

            Case "Food"
                lblWhat.Text = "Eat what?"
                fillLstSelecItem(player1.inv.getFood.ToList)
            Case "Magic"
                lblWhat.Text = "Cast what?"
                If shop_npc_engaged Then
                    Dim l = New List(Of String)
                    For Each i In cboxNPCMG.Items
                        l.Add(lineup(i.ToString, Spell.spellCost(i.ToString)))
                    Next
                    fillLstSelec(l)
                Else
                    Dim l = New List(Of String)
                    For Each i In player1.knownSpells
                        l.Add(lineup(i.ToString, Spell.spellCost(i.ToString)))
                    Next
                    fillLstSelec(l)
                End If
            Case "Spec"
                lblWhat.Text = "Perform what?"
                Dim l = New List(Of String)
                For Each i In cboxSpec.Items
                    l.Add(i.ToString)
                Next
                fillLstSelec(l)
            Case "Armor"
                lblWhat.Text = "Equip what?"
                Dim l = New List(Of String)
                l.Add("Naked")
                Equipment.defaultClothesOptions(l)
                For Each i In player1.inv.getArmors.Item2
                    If i.getCount > 0 Then l.Add(i.getName)
                Next
                fillLstSelec(l)
            Case "Other"
                lblWhat.Text = "Equip what?"
                Dim l = New List(Of String)
                l.Add("Nothing")
                For Each i In player1.inv.getAccesories.Item2
                    If i.getCount > 0 Then l.Add(i.getName)
                Next
                fillLstSelec(l)
            Case "Weapon"
                lblWhat.Text = "Equip what?"
                Dim l = New List(Of String)
                l.Add("Fists")
                For Each i In player1.inv.getWeapons.Item2
                    If i.getCount > 0 Then l.Add(i.getName)
                Next
                fillLstSelec(l)
            Case "manySelect"
                lblWhat.Text = TextEvent.choiceText
                Dim l = New List(Of String)(selectionList.Keys)
                fillLstSelec(l)
            Case "yesNo"
                lblWhat.Text = TextEvent.choiceText
                lstSelec.Items.Add("a - Yes") 'cKeys(19).ToString.ToLower & " - Yes")
                lstSelec.Items.Add("b - No") 'cKeys(20).ToString.ToLower & " - No")
                maxPages = 1
        End Select

        lblInstruc.Text = "Type the seletion's" & vbCrLf &
                     "letter, and use the" & vbCrLf &
                     "arrow keys to scroll." & DDUtils.RNRN &
                     "Use the tab key to" & vbCrLf &
                     "change pages." & DDUtils.RNRN &
                     If(maxSelectionPages > 1, (lstSelec.Tag + 1) & " of " & maxSelectionPages, "")

        selectionType = mode
        pnlSelection.Visible = True
    End Sub
    Function lineup(ByVal s1 As String, ByVal s2 As String)
        Dim c As Char = ChrW(8203)

        If s1.Length > 25 Then s1 = s1.Substring(0, 25) & "."
        If s1.Length < 25 Then
            If s1.Length Mod 2 = 1 Then s1 += " "
            For x = s1.Length To 25
                If s1.Last = "​" Then s1 = s1 & " "
                If x Mod 2 = 0 Then s1 += " " Else s1 += "·"
            Next
        End If
        If s1.Length = 25 Then s1 = s1.Substring(0, 24) & "." & c & " "
        Return s1 & c & " " & s2
    End Function

    '| -- Utilities for Command Drivers -- |
    Sub queueSetup()
        'This sets up the update list
        If npc_list.Count > 0 Then
            For i = 0 To npc_list.Count - 1
                updatable_queue.add(npc_list.Item(i), npc_list.Item(i).getSPD)
            Next
        End If

        updatable_queue.add(player1, player1.getSPD)
    End Sub
    Sub randomEvents()
        '|-Set up-|
        Randomize()
        If eClock > 0 Then eClock -= 1

        '|-Should we check for events?-|
        If mDun.numCurrFloor = 5 Or mDun.numCurrFloor = 75 Or mDun.numCurrFloor = 9999 Or mDun.numCurrFloor = 10000 Or combat_engaged = True Or shop_npc_engaged = True Or eClock <> 0 Or Not player1.canMoveFlag Then
            Exit Sub
        End If

        '|-Quest Aquisition-|
        If player1.quests(qInd.darkPact).canGet Then
            player1.quests(qInd.darkPact).init()
            Exit Sub
        End If

        If player1.quests(qInd.outOfTime).canGet Then
            player1.quests(qInd.outOfTime).init()
            Exit Sub
        End If

        If player1.quests(qInd.nineLives).canGet Then
            player1.quests(qInd.nineLives).init()
            Exit Sub
        End If

        If player1.quests(qInd.faewoods1a).canGet Then
            player1.quests(qInd.faewoods1a).init()
            Exit Sub
        End If

        If currFloor.chestList.Count < 1 And player1.quests(qInd.faewoods2a).canGet Then
            player1.quests(qInd.faewoods2a).init()
            Exit Sub
        End If

        '|-Legacy Floor (91017) Events-|
        If mDun.numCurrFloor = 91017 Then
            If Int(Rnd() * 100) = 0 Then
                Dim m = Monster.monsterFactory(11)
                m.currTarget = player1
                toCombat(m)
                TextEvent.pushLog(Trim(m.getName() & " attacks!"))
                eClock = eClockResetVal
            End If
            Exit Sub
        End If

        '|-Fae Floor (13) Events-|
        If mDun.numCurrFloor = 13 Then
            If Int(Rnd() * 130) = 0 Then
                Select Case Int(Rnd() * 7)
                    Case 1
                        TextEvent.pushLog("You feel eyes glaring through the shroud of mist...")
                    Case 2
                        TextEvent.pushLog("You hear a multitude of whispers surrounding you from all directions...")
                    Case 3
                        TextEvent.pushLog("Something lurks menacingly just outside of your vision...")
                    Case 4
                        TextEvent.pushLog("A foreboding bird caws in the distance...")
                    Case 5
                        TextEvent.pushLog("The ground writhes beneath you, slinking out of view...")
                    Case 6
                        TextEvent.pushLog("You feel unwelcome in this place...")
                    Case Else
                        TextEvent.pushLog("A shadow darts behind a tree before peeking back out and staring slightly to your left...")
                End Select
            End If
        End If

        '|-Monster Encounters-|
        Dim enemyTable As Integer() = Monster.floorMonsterTier(mDun.numCurrFloor)

        Dim encounterRoll As Integer = CInt(Int(Rnd() * 1000))
        Dim typeRoll1 As Integer = Int(Rnd() * (UBound(enemyTable) + 1))
        Dim typeRoll2 As Integer = Int(Rnd() * (UBound(enemyTable) + 1))

        If encounterRoll < encounterRate And enemyTable.Length > 0 And Not (player1.perks(perk.stealth) > 0 AndAlso Int(Rnd() * 3) = 0) Then
            Dim m As NPC = Nothing

            If typeRoll2 = UBound(enemyTable) And typeRoll2 = typeRoll1 And Not currFloor.beatBoss And Not mDun.currFloorBoss.Equals("Key") And Not currFloor.floorNumber = 10000 Then
                m = Boss.bossFactory(mDun.numCurrFloor)
            Else
                m = Monster.monsterFactory(enemyTable(typeRoll1))
            End If

            m.currTarget = player1
            toCombat(m)

            TextEvent.pushLog(Trim(m.getName() & " attacks!"))
            eClock = eClockResetVal
        End If
    End Sub
    Sub closeLblEvent()
        If lblEvent.Visible = True Then
            lblEvent.Visible = False
            lblEvent.Text = ""
            lblEvent.ForeColor = Color.White
            drawBoard()
        End If

        If pnlEvent.Visible = True Then
            pnlEvent.Visible = False
            txtPNLEvents.Visible = True
            txtNoteEvent.Visible = False
            txtPNLEvents.Text = ""
            drawBoard()
        End If

        player1.canMoveFlag = True
        btnEQP.Enabled = True
    End Sub
    Function shouldReturnEarly(ByVal Keydata As Keys)
        'This function determines if the key input should be ignored.
        'If it returns true, HandleKeyPress returns false before anything is done

        If Keydata = Keys.Escape Then Return False
        If picStart.Visible = True Then Return True
        If btnS.Visible Then Return True

        If combat_engaged And (Keydata.Equals(cKeys(0)) Or Keydata.Equals(cKeys(1)) Or Keydata.Equals(cKeys(2)) Or Keydata.Equals(cKeys(3)) Or Keydata.Equals(Keys.Left) Or Keydata.Equals(Keys.Right) Or Keydata.Equals(Keys.Down) Or Keydata.Equals(Keys.Up)) And Not selecting Then
            Return True
        ElseIf combat_engaged Then
            Return False
        End If

        If tmrKeyCD.Enabled Then Return True Else tmrKeyCD.Enabled = True
        If (lblEvent.Visible Or pnlEvent.Visible) And shop_npc_engaged = True And Not Keydata.Equals(cKeys(13)) Then
            If Not TextEvent.lblEventOnClose Is Nothing Then
                doLblEventOnClose()
            End If
            Return True
        End If

        If (lblEvent.Visible Or pnlEvent.Visible) And shop_npc_engaged = True And Keydata.Equals(cKeys(13)) Then
            Return False
        End If

        If pnlDescription.Visible And Not lblEvent.Visible Then
            pnlDescription.Visible = False

            Return True
        End If

        If (lblEvent.Visible Or pnlEvent.Visible) And Not (Keydata.Equals(Keys.Enter)) And Not Keydata.Equals(cKeys(0)) And Not Keydata.Equals(cKeys(1)) And Not Keydata.Equals(cKeys(2)) And Not Keydata.Equals(cKeys(3)) _
            And Not Keydata.Equals(Keys.Left) And Not Keydata.Equals(Keys.Right) And Not Keydata.Equals(Keys.Down) And Not Keydata.Equals(Keys.Up) Then

            If Not shop_npc_engaged Then
                closeLblEvent()

                player1.canMoveFlag = True
                If Not combat_engaged Then
                    player1.canMoveFlag = True
                    picNPC.Visible = False
                End If

                doLblEventOnClose()
                drawBoard()

                If btnEQP.Enabled = False Then btnEQP.Enabled = True
            End If

            Return True
        End If
        If (lblEvent.Visible Or pnlEvent.Visible) And (Keydata.Equals(cKeys(0)) Or Keydata.Equals(cKeys(1)) Or Keydata.Equals(cKeys(2)) Or Keydata.Equals(cKeys(3)) _
            Or Keydata.Equals(Keys.Left) Or Keydata.Equals(Keys.Right) Or Keydata.Equals(Keys.Down) Or Keydata.Equals(Keys.Up)) Then
            Return True
        End If

        If last_keys_pressed.Length > 4 Then
            last_keys_pressed = last_keys_pressed.Substring(1, 3)
        End If

        queueSetup()
        Return False
    End Function
    Function isALetter(ByVal s As String)
        Dim letters = "qwertyuiopasdfghjklzxcvbnm".ToList
        If s.Length > 1 Then Return False
        If letters.Contains(s) Then Return True
        Return False
    End Function

    '| - COMMANDS - |
    Sub oemSemiColon()
        If combat_engaged Then Exit Sub

        'oemSemicolon triggers when a player hits the semicolon key, or any of its equivalents
        For Each sNPC In shop_npc_list
            If player1.pos.Equals(sNPC.pos) Then
                npcEncounter(sNPC)
            End If
        Next

        If Not last_tile Is Nothing AndAlso last_tile.Item1 = "a" AndAlso player1.ongoingQuests.contains("Fae Woods Q2A - Simple Instructions") Then FaeWoodsQ2A.passengerDialog(player1.pos)

        If btnEQP.Enabled = False Then btnEQP.Enabled = True

        If currFloor.chestList.Count > 0 Then
            For i = 0 To currFloor.chestList.Count - 1
                If player1.pos = currFloor.chestList.Item(i).pos Then
                    currFloor.chestList.Item(i).open()
                    If currFloor.floorNumber = 13 AndAlso player1.quests(qInd.faewoods2a).canGet Then TextEvent.lblEventOnClose = AddressOf FaeWoodsQ2A.altInit
                    currFloor.chestList.RemoveAt(i)
                    Exit For
                End If
            Next
        End If

        If mDun.floorboss.ContainsKey(mDun.numCurrFloor) Then
            If mDun.currFloorBoss.Equals("Key") And player1.inv.getCountAt("Key") > 0 Then currFloor.beatBoss = True
            If player1.pos = currFloor.stairs And currFloor.beatBoss Then
                If mDun.currFloorBoss.Equals("Key") Then player1.inv.add("Key", -1)
                player1.inv.invNeedsUDate = True
                player1.UIupdate()
                mDun.floorDown()
                mDun.setFloor(currFloor)
                initializeBoard()
                If combat_engaged Then fromCombat()
                player1.canMoveFlag = True
            ElseIf player1.pos = currFloor.stairs Then
                If mDun.currFloorBoss.Equals("Key") Then TextEvent.push("The stairs are behind a locked gate!  Perhaps the key is in a chest..." & DDUtils.RNRN & "[While this game is in development it can also be bought from any shop for 2500]") Else TextEvent.push("You must defeat " & mDun.currFloorBoss & "!")
            End If
        ElseIf player1.pos = currFloor.stairs Then
            If mDun.numCurrFloor = 9999 Or mDun.numCurrFloor = 10000 Then
                mDun.jumpTo(mDun.lastVisitedFloor)
                mDun.setFloor(currFloor)
                TextEvent.push("Spotting a gleaming terminal, you notice the rough layout of the dungeon floor you were previouly on." & DDUtils.RNRN &
                             "You see a holographic button over this section of the map, and with a hesitant press you find yourself sucked through another tear in space-time.  Once again, you join the void until you pop back into the familiar surroundings of the dungeon.", AddressOf initializeBoard)
                Exit Sub
            ElseIf mDun.numCurrFloor = 91017 Then
                mDun.jumpTo(mDun.lastVisitedFloor)
                mDun.setFloor(currFloor)
            ElseIf mDun.numCurrFloor = 9 Then
                mDun.floorDown()
                mDun.setFloor(currFloor)
                TextEvent.push("It looks like while there was once a formidable gate covering the stairway, something has left it rather... well, destroyed.  Glancing back at the smoldering gash in the landscape, " & If(player1.inv.getCountAt("Fox_Statue") > 0, "you fail to notice the slight gleam in the eyes of the fox statue tucked away in your bag.  Even as the flames blaze on above you, you decend to the next floor with chills at the thought of what could have left such a scar...", "you head down to the next floor with chills despite the inferno raging around you..."), AddressOf initializeBoard)
                Exit Sub
            End If

            mDun.floorDown()
            mDun.setFloor(currFloor)
            initializeBoard()

            If mDun.lastVisitedFloor = 13 Then
                If player1.ongoingTFs.contains(tfind.faepie) Then
                    player1.ongoingTFs.remove(tfind.faepie) : TextEvent.pushAndLog("You revert from your fae form!")
                End If
                If player1.equippedAcce.getAName.Equals(CursedBridle.ITEM_NAME) Then
                    CursedBridle.forceUnequip(player1)
                End If
            End If

            mDun.tfNPCToArachne()

            If combat_engaged Then fromCombat()
            player1.canMoveFlag = True
        End If

        If currFloor.statueList.Count > 0 Then
            For i = 0 To currFloor.statueList.Count - 1
                If player1.pos = currFloor.statueList.Item(i).pos Then
                    currFloor.statueList.Item(i).examine()
                    Exit For
                End If
            Next
        End If
    End Sub
    Sub oemReturn()
        'oemReturn triggers when the player hits the enter (return) key
        If DDConst.CHEAT_LIST.Contains(last_keys_pressed) Then
            TextEvent.pushAndLog(last_keys_pressed & " entered!")
            If last_keys_pressed = "asss" Then
                player1.MtF()
                player1.drawPort()
            ElseIf last_keys_pressed = "daaa" Then
                player1.FtM()
                player1.drawPort()
            ElseIf last_keys_pressed = "wawa" Then
                player1.be()
                player1.drawPort()
            ElseIf last_keys_pressed = "sasa" Then
                player1.bs()
                player1.drawPort()
            ElseIf last_keys_pressed = "seee" Then
                For indY = -currFloor.mBoardHeight To currFloor.mBoardHeight
                    For indX = -currFloor.mBoardWidth To currFloor.mBoardWidth
                        If player1.pos.Y + indY < currFloor.mBoardHeight And player1.pos.Y + indY >= 0 And player1.pos.X + indX < currFloor.mBoardWidth And player1.pos.X + indX >= 0 Then
                            If currFloor.mBoard(player1.pos.Y + indY, player1.pos.X + indX).Text = "@" Then currFloor.mBoard(player1.pos.Y + indY, player1.pos.X + indX).Text = ""
                            If currFloor.mBoard(player1.pos.Y + indY, player1.pos.X + indX).Text = "H" And currFloor.mBoard(player1.pos.Y + indY, player1.pos.X + indX).Tag < 2 Then
                                currFloor.mBoard(player1.pos.Y + indY, player1.pos.X + indX).ForeColor = Color.Black
                                TextEvent.pushLog("Floor " & mDun.numCurrFloor & ": Staircase Discovered")
                            End If
                            If currFloor.mBoard(player1.pos.Y + indY, player1.pos.X + indX).Text = "#" And currFloor.mBoard(player1.pos.Y + indY, player1.pos.X + indX).Tag < 2 Then
                                currFloor.mBoard(player1.pos.Y + indY, player1.pos.X + indX).ForeColor = Color.Black
                                TextEvent.pushLog("Chest discovered!")
                            End If
                            If currFloor.mBoard(player1.pos.Y + indY, player1.pos.X + indX).Text = "$" And currFloor.mBoard(player1.pos.Y + indY, player1.pos.X + indX).Tag < 2 Then
                                currFloor.mBoard(player1.pos.Y + indY, player1.pos.X + indX).ForeColor = Color.Navy
                                TextEvent.pushLog("Shop discovered!")
                            End If
                            If currFloor.mBoard(player1.pos.Y + indY, player1.pos.X + indX).Tag = 1 Then currFloor.mBoard(player1.pos.Y + indY, player1.pos.X + indX).Tag = 2
                        End If
                    Next
                Next
            ElseIf last_keys_pressed = "gogo" Then
                Try
                    Dim f As Integer = CInt(InputBox("Which floor?"))
                    quickChangeFloor(f)
                Catch ex As Exception
                End Try
            ElseIf last_keys_pressed = "aeio" Then
                player1.inv.add(149, 1)
                player1.UIupdate()
            ElseIf last_keys_pressed = "aaaa" Then
                Dim name As String = InputBox("Enter a Name:")
                MsgBox("If " & name & " was a bimbo, they'd be " & Polymorph.bimboizeName(name))
            ElseIf last_keys_pressed = "sawd" Then
                player1.lust -= 10
                player1.UIupdate()
            ElseIf last_keys_pressed = "wasd" Then
                Dim ct = New ClothingTester()
                ct.ShowDialog()
                ct.Dispose()
                player1.UIupdate()
            ElseIf last_keys_pressed = "ssss" Then
                Try
                    Dim f As Integer = CInt(InputBox("how many levels?"))
                    player1.deLevel(f)
                Catch ex As Exception
                End Try
            ElseIf last_keys_pressed = "ffff" Then
                Dim p = player1

                FanPhanStep3.losstf(p)
            ElseIf last_keys_pressed = "swda" Then
                Try
                    Dim npcInd As Integer = CInt(InputBox("Enter an NPC index:" & vbCrLf &
                                                     "0 - Shopkeeper" & vbCrLf &
                                                     "1 - Shady Wizard" & vbCrLf &
                                                     "2 - Hypnotist Teacher" & vbCrLf &
                                                     "3 - Food Vendor" & vbCrLf &
                                                     "4 - Weaponsmith" & vbCrLf &
                                                     "5 - Curse Broker" & vbCrLf &
                                                     "6 - Magical Girl"))
                    Dim newpoint = currFloor.getRndAdjPoint(player1)
                    shop_npc_list(npcInd).pos = newpoint
                    currFloor.npcPositions(npcInd) = newpoint

                    drawBoard()
                Catch ex As Exception
                End Try
            ElseIf last_keys_pressed = "eaea" Then
                player1.knownSpecials.Clear()
                player1.knownSpells.Clear()

                For Each s In Spell.spellList.Keys
                    player1.knownSpells.Add(s)
                Next
                For Each s In Special.specialList.Keys
                    player1.knownSpecials.Add(s)
                Next
            End If
        End If
        last_keys_pressed = ""
    End Sub
    Public Sub quickChangeFloor(ByVal f As Integer)
        Try
            mDun.jumpTo(f)
            mDun.setFloor(currFloor)
            TextEvent.push(If(Not lblEvent.Visible,
                            "You draw a circle in chalk on the ground, and think hard about floor number " & f & ".  A portal opens to it, and you jump through, skipping every floor in between.",
                            "You draw a circle in chalk on the ground, and think hard about floor number " & f & ".  A portal opens to it, and you jump through, skipping every floor in between." & DDUtils.RNRN & lblEvent.Text.Split(vbCrLf)(0)),
                        AddressOf initializeBoard)

            mDun.tfNPCToArachne()
        Catch e As Exception
            TextEvent.push("Your attempted teleportation fails in a less than spectacular fashion, the portal you created simply fizzling away to nothingness.")
        End Try
    End Sub
    '| -- Talk -- |
    Sub talkKey()
        If Not shop_npc_engaged Then
            For Each s In shop_npc_list
                If player1.pos.Equals(s.pos) Then npcEncounter(s) : Exit For
            Next

            If Not last_tile Is Nothing AndAlso last_tile.Item1 = "a" AndAlso player1.ongoingQuests.contains("Fae Woods Q2A - Simple Instructions") Then FaeWoodsQ2A.passengerDialog(player1.pos)
        Else
            doLblEventOnClose()
            closeLblEvent()
        End If
    End Sub
    Private Sub btnTalk_Click(sender As Object, e As EventArgs) Handles btnTalk.Click
        talkKey()
    End Sub
    '| -- Attack -- |
    Sub attackKey()
        If combat_engaged Then
            doLblEventOnClose()
            closeLblEvent()

            Dim m As NPC = getCombatTarget(player1)

            player1.nextCombatAction = Sub(t As Entity) player1.attackCMD(t)
        Else
            player1.equippedWeapon.outOfCombatAttack(player1)
        End If

        progressTurn()
    End Sub
    Private Sub btnATK_Click(sender As Object, e As EventArgs) Handles btnATK.Click
        attackKey()
    End Sub
    '| -- Spells -- |
    Sub magicKey()
        If Settings.active(setting.oldspellspec) Then
            toPNLSelec("Magic")
        Else
            CastDialogBackend.toPNLCast(Nothing, Nothing, player1, getCombatTarget(player1), SpellOrSpec.SPELL)
        End If
    End Sub
    Private Sub btnMG_Click(sender As Object, e As EventArgs) Handles btnMG.Click
        magicKey()
    End Sub
    '| -- Specials -- |
    Sub specialKey()
        If Settings.active(setting.oldspellspec) Then
            toPNLSelec("Spec")
        Else
            CastDialogBackend.toPNLCast(Nothing, Nothing, player1, getCombatTarget(player1), SpellOrSpec.SPECIAL)
        End If
    End Sub
    Private Sub btnSpec_Click(sender As Object, e As EventArgs) Handles btnSpec.Click
        specialKey()
    End Sub
    '| -- Drink -- |
    Sub drinkKey()
        toPNLSelec("Potion")
    End Sub
    '| -- Wait -- |
    Sub waitKey()
        closeLblEvent()

        Dim m As NPC = getCombatTarget(player1)
        player1.setTarget(m)

        If Not combat_engaged And Not shop_npc_engaged And player1.quests(qInd.faewoods1b).canGet Then
            player1.quests(qInd.faewoods1b).init()
        End If

        TextEvent.push("You wait for a bit...")
        progressTurn()
    End Sub
    Private Sub btnWait_Click(sender As Object, e As EventArgs) Handles btnWait.Click
        waitKey()
    End Sub
    '| -- Run -- |
    Sub runKey()
        doLblEventOnClose()
        closeLblEvent()

        If combat_engaged Then
            Dim m As NPC = getCombatTarget(player1)

            player1.nextCombatAction = Sub() run()
        Else
            TextEvent.push("You have nothing to run from!")
        End If

        progressTurn()
    End Sub
    Sub run()
        'Targax can't run
        If player1.health < 1 / player1.getMaxHealth Then Exit Sub
        If player1.perks(perk.swordpossess) > -1 Or (player1.name.Equals("Targax") And player1.className.Equals("Soul-Lord")) Then
            TextEvent.pushAndLog("Something inside you decides that running away is cowardly, so you don't.")
            Exit Sub
        End If

        'Standard run procedure
        Dim run As Integer = Int(Rnd() * 4)
        For i = 0 To npc_list.Count() - 1
            If (npc_list.Count() < 1) Then
                Exit Sub
            ElseIf i < npc_list.Count And Not (npc_list.Item(i).GetType() Is GetType(Boss)) And run <> 1 Then
                npc_list.Item(i).despawn("run")
                updatable_queue.clear()
            Else
                updatePnlCombat(player1, player1.currTarget)
                TextEvent.pushAndLog("You can't get away!")
            End If
        Next
    End Sub
    Private Sub btnRUN_Click(sender As Object, e As EventArgs) Handles btnRUN.Click
        runKey()
    End Sub
    '| -- Use -- |
    Sub useKey()
        toPNLSelec("Useable")
    End Sub
    Private Sub btnUse_Click(sender As Object, e As EventArgs) Handles btnUse.Click
        closeLblEvent()
        doLblEventOnClose()
        If Not combat_engaged And Not shop_npc_engaged Then player1.canMoveFlag = True
        If player1.prt.checkNDefMalInd(pInd.mouth, 6) Or player1.prt.checkNDefFemInd(pInd.mouth, 12) Then
            TextEvent.push("You can't use items now!")
            Exit Sub
        End If
        If selectedItem Is Nothing Then Exit Sub
        Dim tmpInd As Integer = lstInventory.TopIndex
        Dim tind = lstInventory.SelectedIndex
        selectedItem.use(player1)

        player1.inv.invNeedsUDate = True
        player1.UIupdate()

        lstInventory.TopIndex = tmpInd

        If selectedItem.count < 1 Then
            lstInventory.SelectedItem = Nothing
            selectedItem = Nothing
            btnUse.Enabled = False
            btnDrop.Enabled = False
            btnLook.Enabled = False
        Else
            lstInventory.SelectedIndex = tind
        End If

        progressTurn()

        lblPHealth.Text = DDUtils.statBar(player1.getIntHealth, player1.getMaxHealth, lblPHealth)
    End Sub
    '| -- Shop -- |
    Sub toShopKey()
        doLblEventOnClose()
        closeLblEvent()

        If player1.pos.Equals(shopkeeper.pos) Then
            active_shop_npc = shopkeeper
        ElseIf player1.pos.Equals(swiz.pos) Then
            active_shop_npc = swiz
        ElseIf player1.pos.Equals(hteach.pos) Then
            active_shop_npc = hteach
        Else
            TextEvent.push("There's no shop here.")
            Exit Sub
        End If

        'Dim s As Shop = New Shop
        Dim s As ShopV3 = New ShopV3
        s.ShowDialog()
        s.Dispose()
    End Sub
    Private Sub btnShop_Click(sender As Object, e As EventArgs) Handles btnShop.Click
        doLblEventOnClose()
        closeLblEvent()
        'Dim s As Shop = New Shop
        shopMenu = New ShopV3
        shopMenu.ShowDialog()
        shopMenu.Dispose()
    End Sub
    '| -- Equip -- |
    Sub eArmorKey()
        If checkIfCantEquip() Then Exit Sub
        toPNLSelec("Armor")
    End Sub
    Sub eOtherKey()
        If checkIfCantEquip() Then Exit Sub
        toPNLSelec("Other")
    End Sub
    Sub eWeaponKey()
        If checkIfCantEquip() Then Exit Sub
        toPNLSelec("Weapon")
    End Sub
    Private Sub btnEQP_Click(sender As Object, e As EventArgs) Handles btnEQP.Click
        If checkIfCantEquip() Then Exit Sub

        EquipmentDialogBackend.showEquipDialog(player1)

        'Dim f3 As Equipment = New Equipment()
        'doLblEventOnClose()
        'f3.ShowDialog()
        'f3.Dispose()
    End Sub
    Function checkIfCantEquip() As Boolean
        If player1 Is Nothing Then Return False

        If player1.formName.Equals("Blowup Doll") Then
            TextEvent.push("Any weapon you try to wield, and any armor or accessories you try to equip slide off.  It doesn't look like you'll be able to do this until you're not a blowup doll.")
            Return True
        ElseIf player1.perks(perk.astatue) > -1 Then
            TextEvent.push("You can't move.")
            Return True
        End If

        Dim b = False
        player1.oneLayerImgCheck(b)

        If b Or player1.formName = "Fae" Or player1.ongoingQuests.contains("Phantastic Fantom") Then
            TextEvent.push("You can't change equipment now!")
            Return True
        End If

        Return False
    End Function
    '| -- Self Inspect -- |
    Sub selfinpKey()
        If turn < 2 Then Exit Sub
        TextEvent.pushLog(player1.description)
        toDesc()
    End Sub
    Sub toDesc()
        If combat_engaged Then
            player1.allRoute()
            Dim description As String = CStr(player1.name & " is a " & player1.sex & " " & player1.formName & " " & player1.className) + DDUtils.RNRN + player1.outPutPerkText() + player1.listQuests()

            TextEvent.push(description)
            'updatePnlCombat(player1, player1.currTarget)
        Else
            If TextEvent.lblEventOnClose Is Nothing Then closeLblEvent() Else TextEvent.pushLog("Press any non-movement key to continue...") : Exit Sub
            If selecting Then TextEvent.pushLog("Press a selection key to continue...") : Exit Sub
            If Settings.active(setting.textcolors) Then txtPlayerDesc.ForeColor = player1.textColor
            txtPlayerDesc.Text = player1.genDescription

            Dim pImg = player1.prt.oneLayerImgCheck(player1.formName, player1.className)
            If player1.prt.oneLayerImgCheck(player1.formName, player1.className) Is Nothing Then
                pImg = player1.prt.drawFull()
            End If

            picDescPort.BackgroundImage = pImg

            pnlDescription.Location = New Point((13 * (Me.Size.Width / 688)), (3 * (Me.Size.Width / 688)))
            pnlDescription.Visible = True
        End If
    End Sub
    '| -- Eat -- |
    Sub eatKey()
        toPNLSelec("Food")
    End Sub
    '| -- Yes/No -- |
    Sub yesKey()

    End Sub
    Sub noKey()

    End Sub
    Public Sub ChallengeBoss()
        '| - Get the Boss For a Floor - |
        Dim m As MiniBoss
        m = Boss.bossFactory(mDun.numCurrFloor)

        '| - Pre-boss-fight dialogs - |
        If Not currFloor.bossDialog And mDun.numCurrFloor = 4 Then
            m.preFightDialog()
            Exit Sub
        End If

        '| - Route Targets - |

        Monster.targetRoute(m)
        toCombat(m)
        queueSetup()

        '| - Print Dialog (if any) -|
        TextEvent.pushLog(Trim(m.getName & " attacks!"))
    End Sub
    '| -- Movement -- |
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

    '| - SAVE/LOAD - |
    Sub save(ByVal a As String)
        'save handles the saving of the game
        Dim writer As IO.StreamWriter
        IO.File.Delete(a)
        writer = IO.File.CreateText(a)

        writer.WriteLine(version)
        writer.WriteLine(sessionID)
        'save the dungeon
        writer.WriteLine("-------------------------------DUNGEON---------------------------------")
        writer.WriteLine(mDun.save)

        'save the player
        writer.WriteLine("----------------------------------PLAYER------------------------------------")
        writer.WriteLine(player1.ToString)
        'save the player's original body prior to the floor 4 body swap
        If (mDun.numCurrFloor = 4 And mDun.floorboss(4) = "Ooze Empress") Then
            writer.WriteLine("placeholder")
            writer.WriteLine("placeholder")
            writer.WriteLine(floor_4_starting_inv.Count - 1)
            For i = 0 To floor_4_starting_inv.Count - 1
                writer.WriteLine(floor_4_starting_inv.Item(i))
            Next
        End If

        'save the shop NPCs
        writer.WriteLine("---------------------------------SHOP NPCs-----------------------------------")
        writer.WriteLine(shop_npc_list.Count - 1)
        For i = 0 To shop_npc_list.Count - 1
            writer.WriteLine(shop_npc_list(i).saveNPC)
        Next

        'save the dungeon generation settings
        writer.WriteLine("--------------------------------DUNGEON SETTINGS---------------------------------")
        writer.WriteLine(mBoardWidth)
        writer.WriteLine(mBoardHeight)
        writer.WriteLine(chestFreqMin)
        writer.WriteLine(chestFreqRange)
        writer.WriteLine(chestSizeDependence)
        writer.WriteLine(chestRichnessBase)
        writer.WriteLine(chestRichnessRange)
        writer.WriteLine(turn)
        writer.WriteLine(encounterRate)
        writer.WriteLine(eClockResetVal)

        writer.Flush()
        writer.Close()
        TextEvent.push("Game successfully saved!")
        player1.solFlag = False
        player1.drawPort()

        'SaveFile.save()
    End Sub
    Sub loadSave(ByVal a As String)
        Dim reader As IO.StreamReader
        reader = IO.File.OpenText(a)

        Dim v = CDbl(reader.ReadLine())
        If v < 0.92 Then
            DDError.incorrectSaveVersionError()
            If mDun Is Nothing Then
                picStart.Location = New Point(-2, picStart.Location.Y)
                picStart.Visible = True
                btnS.Visible = True
                btnL.Visible = True
                btnSettings.Visible = True
                btnControls.Visible = True
                btnAbout.Visible = True
            End If
            Exit Sub
        ElseIf v > 0.92 Then
            sessionID = CInt(reader.ReadLine)
        End If

        'loadSave handles the loading of a game
        Debug_Window.clear()
        cboxNPCMG.Items.Clear()
        cboxNPCMG.Text = "-- Select --"
        cboxSpec.Items.Clear()
        cboxSpec.Text = "-- Select --"
        lstLog.Items.Clear()
        npc_list = New List(Of NPC)
        updatable_queue.clear()
        player_image = mTile.imgLib.getImg(tSet.dungeon, tile.player)
        lblNameTitle.ForeColor = Color.White
        If Not picPortrait.BackgroundImage Is Nothing Then picPortrait.BackgroundImage.Dispose()
        lblEvent.Visible = False
        btnATK.Visible = False
        btnMG.Visible = False
        btnRUN.Visible = False
        picEnemy.Visible = False
        picNPC.Visible = False
        btnSpec.Visible = False
        cboxSpec.Visible = False
        pnlCombatClose()

        player1.canMoveFlag = False
        If picStart.Visible = False Then picStart.Visible = True
        picStart.BringToFront()
        picLoadBar.BringToFront()

        System.Threading.Thread.Sleep(750)

        initLoadBar()

        updateLoadbar(10)

        'load the dungeon
        reader.ReadLine()
        mDun = New Dungeon(reader.ReadLine())
        currFloor = mDun.floors(mDun.numCurrFloor)
        newBoard()
        updateLoadbar(45)

        'load the player
        reader.ReadLine()
        player1 = New Player(reader.ReadLine(), v)
        'load the pre-floor 4 body if needed
        If (mDun.numCurrFloor = 4 And mDun.floorboss(4) = "Ooze Empress") Then
            Dim l1 = reader.ReadLine()
            Dim l2 = reader.ReadLine()
            If Not l1.Equals("placeholder") Then player1.preBSBody.read(l1, version)
            If Not l2.Equals("placeholder") Then player1.preBSStartState.read(l2, version)
            floor_4_starting_inv = New ArrayList
            For i As Integer = 0 To reader.ReadLine()
                floor_4_starting_inv.Add(reader.ReadLine())
            Next
        End If

        If player1.quests(qInd.outOfTime).getComplete Then compOOT = True

        updateLoadbar(60)

        'load the NPCs
        reader.ReadLine()
        shop_npc_list.Clear()
        For i = 0 To CInt(reader.ReadLine())
            shop_npc_list.Add(ShopNPC.shopFactory(i))
            shop_npc_list(i).loadNPC(reader.ReadLine())
        Next
        shopkeeper = shop_npc_list(0)
        swiz = shop_npc_list(1)
        hteach = shop_npc_list(2)
        fvend = shop_npc_list(3)
        wsmith = shop_npc_list(4)
        cbrok = shop_npc_list(5)
        mgirl = shop_npc_list(6)
        ttraveler = shop_npc_list(7)
        fqueen = shop_npc_list(8)
        updateLoadbar(70)

        'load the dungeon generation settings
        reader.ReadLine()
        mBoardWidth = reader.ReadLine()
        mBoardHeight = reader.ReadLine()
        chestFreqMin = reader.ReadLine()
        chestFreqRange = reader.ReadLine()
        chestSizeDependence = reader.ReadLine()
        chestRichnessBase = reader.ReadLine()
        chestRichnessRange = reader.ReadLine()
        turn = reader.ReadLine()
        encounterRate = Int(reader.ReadLine())
        eClockResetVal = Int(reader.ReadLine())
        updateLoadbar(80)

        combat_engaged = False

        Equipment.init()
        reader.Close()

        'update the display
        player1.UIupdate()

        player1.currState.save(player1)
        If Not player1.nextCombatAction Is Nothing Then player1.nextCombatAction(Nothing)

        picStart.Visible = False
        picLoadBar.Visible = False

        TextEvent.push("Game successfully loaded!")
        player1.drawPort()

        updateLoadbar(99)
        boardWorker.CancelAsync()

        drawBoard()
    End Sub
    'save/load drivers
    Private Sub btnSaveTile_Click(sender As Object, e As MouseEventArgs) Handles btnS1.Click, btnS2.Click, btnS3.Click, btnS4.Click, btnS5.Click, btnS6.Click, btnS7.Click, btnS8.Click, btnS9.Click, btnS10.Click
        pnlSaveLoad.Visible = False

        btnS1.Enabled = False
        btnS2.Enabled = False
        btnS3.Enabled = False
        btnS4.Enabled = False
        btnS5.Enabled = False
        btnS6.Enabled = False
        btnS7.Enabled = False
        btnS8.Enabled = False
        btnS9.Enabled = False
        btnS10.Enabled = False

        Dim btn As Button = CType(sender, Button)
        Dim name As String = btn.Name

        Dim fileNum As String = btn.Tag
        Dim mouseEvent As MouseEventArgs = TryCast(e, MouseEventArgs)

        If mouseEvent IsNot Nothing AndAlso mouseEvent.Button = MouseButtons.Left Then
            If solFlag Then
                Try
                    player1.solFlag = True
                    loadSave("saves/s" & fileNum & ".ave")
                    player1.solFlag = False
                Catch ex As System.IO.FileNotFoundException
                    DDError.noSaveDetectedError()
                Catch ex2 As Exception
                    DDError.saveFileError()
                End Try
            Else
                save("saves/s" & fileNum & ".ave")
                imagesWorkerArg = Convert.ToInt32(fileNum)
                imagesWorker.RunWorkerAsync()
            End If
            If picStart.Visible Then closesol()
        End If

        btnS1.Enabled = True
        btnS2.Enabled = True
        btnS3.Enabled = True
        btnS4.Enabled = True
        btnS5.Enabled = True
        btnS6.Enabled = True
        btnS7.Enabled = True
        btnS8.Enabled = True
        btnS9.Enabled = True
        btnS10.Enabled = True
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        pnlSaveLoad.Visible = False
        If picStart.Visible = True Then
            btnS.Visible = True
            btnL.Visible = True
            btnControls.Visible = True
            btnSettings.Visible = True
            btnAbout.Visible = True
        End If
        player1.canMoveFlag = True


        If player1.isDead Then formReset()
    End Sub
    Sub toSOL()
        fromCombat()

        If picStart.Visible = True Then pnlSaveLoad.Location = New Point(208, pnlSaveLoad.Location.Y) Else pnlSaveLoad.Location = New Point(63, pnlSaveLoad.Location.Y)
        pnlSaveLoad.Visible = True


        Dim loops = 0
        While Not savePicsReady
            If loops = 100 Then
                closesol()
                DDError.saveFileImageError()
                Exit While
                Exit Sub
            End If
            loops += 1
            Threading.Thread.Sleep(50)
        End While

        If savePics(1) IsNot Nothing Then
            btnS1.BackgroundImage = savePics(1)
            If Settings.active(setting.noimg) Then btnS1.BackgroundImage = Nothing
        Else
            If solFlag Then btnS1.Enabled = False Else btnS1.Enabled = True
        End If

        If savePics(2) IsNot Nothing Then
            btnS2.BackgroundImage = savePics(2)
            If Settings.active(setting.noimg) Then btnS2.BackgroundImage = Nothing
        Else
            If solFlag Then btnS2.Enabled = False Else btnS2.Enabled = True
        End If

        If savePics(3) IsNot Nothing Then
            btnS3.BackgroundImage = savePics(3)
            If Settings.active(setting.noimg) Then btnS3.BackgroundImage = Nothing
        Else
            If solFlag Then btnS3.Enabled = False Else btnS3.Enabled = True
        End If

        If savePics(4) IsNot Nothing Then
            btnS4.BackgroundImage = savePics(4)
            If Settings.active(setting.noimg) Then btnS4.BackgroundImage = Nothing
        Else
            If solFlag Then btnS4.Enabled = False Else btnS4.Enabled = True
        End If

        If savePics(5) IsNot Nothing Then
            btnS5.BackgroundImage = savePics(5)
            If Settings.active(setting.noimg) Then btnS5.BackgroundImage = Nothing
        Else
            If solFlag Then btnS5.Enabled = False Else btnS5.Enabled = True
        End If

        If savePics(6) IsNot Nothing Then
            btnS6.BackgroundImage = savePics(6)
            If Settings.active(setting.noimg) Then btnS6.BackgroundImage = Nothing
        Else
            If solFlag Then btnS6.Enabled = False Else btnS6.Enabled = True
        End If

        If savePics(7) IsNot Nothing Then
            btnS7.BackgroundImage = savePics(7)
            If Settings.active(setting.noimg) Then btnS7.BackgroundImage = Nothing
        Else
            If solFlag Then btnS7.Enabled = False Else btnS7.Enabled = True
        End If

        If savePics(8) IsNot Nothing Then
            btnS8.BackgroundImage = savePics(8)
            If Settings.active(setting.noimg) Then btnS8.BackgroundImage = Nothing
        Else
            If solFlag Then btnS8.Enabled = False Else btnS8.Enabled = True
        End If

        If savePics(9) IsNot Nothing Then
            btnS9.BackgroundImage = savePics(9)
            If Settings.active(setting.noimg) Then btnS9.BackgroundImage = Nothing
        Else
            If solFlag Then btnS9.Enabled = False Else btnS9.Enabled = True
        End If

        If savePics(10) IsNot Nothing Then
            btnS10.BackgroundImage = savePics(10)
            If Settings.active(setting.noimg) Then btnS10.BackgroundImage = Nothing
        Else
            If solFlag Then btnS10.Enabled = False Else btnS10.Enabled = True
        End If

        Me.Update()
        player1.canMoveFlag = False
    End Sub
    Sub closesol()
        updatable_queue.add(player1, player1.getSPD)
        combat_engaged = False
        If Not mDun Is Nothing Then picStart.Visible = False
        If player1.isDead Then formReset()
        player1.canMoveFlag = True

    End Sub
    'save access files
    Shared Function getImgFromFile(ByVal a As String) As Image
        Dim reader As IO.StreamReader
        reader = IO.File.OpenText(a)
        reader.ReadLine()
        Dim img As Bitmap = Nothing
        Try
            Dim iarr(Portrait.NUM_IMG_LAYERS) As Image
            Dim pState As String() = reader.ReadLine().Split("#")(0).Split("*")
            Dim haircolor = Color.FromArgb(255, CInt(pState(22)), CInt(pState(23)), CInt(pState(24)))
            Dim skincolor = Color.FromArgb(255, CInt(pState(25)), CInt(pState(26)), CInt(pState(27)))
            Dim ids(Portrait.NUM_IMG_LAYERS) As Tuple(Of Integer, Boolean, Boolean)
            For i = 0 To Portrait.NUM_IMG_LAYERS
                Dim arr() As String = pState(32 + CInt(pState(31)) + i).Split("%")
                Dim id = New Tuple(Of Integer, Boolean, Boolean)(CInt(arr(0)), CBool(arr(1)), CBool(arr(2)))

                If id.Item2 Then
                    iarr(i) = Portrait.imgLib.fAttributes(i)(id.Item1)
                Else
                    iarr(i) = Portrait.imgLib.mAttributes(i)(id.Item1)
                End If
                ids(i) = id
                If i = 6 And (id.Item1 = 0 Or id.Item1 = 3) Then iarr(pInd.ears) = Portrait.skinRecolor(iarr(pInd.ears), skincolor)
            Next
            DDUtils.changeHairColor(haircolor, ids, iarr)
            DDUtils.changeSkinColor(skincolor, ids, iarr)

            img = Portrait.CreateBMP(iarr)
        Catch ex As Exception
            Return ShopNPC.gbl_img.atrs(0).getAt(103)
        End Try
        reader.Close()
        Return img
    End Function
    Shared Function getPlayerFromFile(ByVal a As String) As Tuple(Of Player, Double)
        Dim reader As IO.StreamReader
        reader = IO.File.OpenText(a)
        Dim vers As Double = CDbl(reader.ReadLine())
        reader.ReadLine()
        reader.ReadLine()
        reader.ReadLine()
        reader.ReadLine()
        Dim player1 = New Player(reader.ReadLine, vers)
        reader.Close()
        Return New Tuple(Of Player, Double)(player1, vers)
    End Function

    '|COMBAT|
    Function getCombatTarget(ByRef p As Player) As NPC
        For i = 0 To npc_list.Count() - 1
            If npc_list.Item(i).GetType().IsSubclassOf(GetType(NPC)) Or npc_list.Item(i).GetType() Is GetType(NPC) Then
                Return npc_list.Item(i)
            End If
        Next

        Return p.currTarget
    End Function
    Sub toCombat(ByRef m As NPC)
        If shop_npc_engaged Then
            ShopNPCToCombat(m)
            Exit Sub
        End If

        '|-Set up Game-|
        cleanupPanels()
        combat_engaged = True
        npc_list.Add(m)

        '|-Set up the Player-|
        player1.canMoveFlag = False
        player1.specialRoute()
        player1.magicRoute()
        player1.setTarget(m)
        player1.UIupdate()

        '|-Combat Dialog Box-|
        lblCombatEvents.Text = ""
        lblEHealthChange.Tag = 0
        lblPHealtDiff.Tag = 0
        updatePnlCombat(player1, player1.currTarget)
        pnlCombat.Visible = True

        '|-Combat Buttons-|
        btnATK.Visible = True
        btnMG.Visible = True
        btnWait.Visible = True
        btnRUN.Visible = True
        btnSpec.Visible = True
    End Sub
    Public Sub fromCombat()
        '|-Combat Dialog Box-|
        pnlCombatClose()
        picEnemy.Visible = False
        picNPC.Visible = False

        '|-Combat Buttons-|
        btnATK.Visible = False
        btnMG.Visible = False
        btnRUN.Visible = False
        btnWait.Visible = False
        btnSpec.Visible = False

        '|-Clean up Game-|
        combat_engaged = False
        npc_list.Clear()
        updatable_queue.clear()

        '|-Clean up the Player-|
        If player1.perks(perk.astatue) < 0 Then player1.canMoveFlag = True
        player1.clearTarget()
        player1.specialRoute()
        player1.magicRoute()
        player1.skillsUsedThisCombat.Clear()
    End Sub
    'combat pannel
    Sub updatePnlCombat(ByVal p As Player, ByVal t As Entity, Optional turnOverride As Boolean = False)
        Dim ratio As Double = Me.Size.Width / 1024

        '|-- Update the turn counter --|
        If (lblTurn.Text.Equals("Turn: " & turn) And Not turnOverride) Or t Is Nothing Then Exit Sub
        lblTurn.Text = "Turn: " & turn

        '|-- Kill the target, if needed --|
        If t.health <= 0 Then
            t.die()
            Exit Sub
        End If

        '|-- Update the player's information --|
        lblPName.Text = p.getName
        lblPHealth.Text = DDUtils.statBar(p.getIntHealth, p.getMaxHealth, lblPHealth)

        If lblPHealtDiff.Tag > 0 Then
            lblPHealtDiff.Text = "+" & lblPHealtDiff.Tag
            lblPHealtDiff.ForeColor = Color.YellowGreen
        Else
            lblPHealtDiff.Text = lblPHealtDiff.Tag
            lblPHealtDiff.ForeColor = Color.Crimson
        End If

        If lblPHealtDiff.Tag = 0 Then lblPHealtDiff.Visible = False Else lblPHealtDiff.Visible = True
        lblPHealtDiff.Tag = 0
        Dim x As Integer = lblPHealth.Location.X + (((1 - p.getHealth) * 200 * ratio) - (10 * ratio))
        If x > lblPHealth.Location.X + (((0.9) * 200 * ratio) - (10 * ratio)) Then x = lblPHealth.Location.X + (((0.9) * 200 * ratio) - (10 * ratio))
        lblPHealtDiff.Location = New Point(x, lblPHealtDiff.Location.Y)

        If health_bar_color_grad Is Nothing = False Then
            lblPHealth.ForeColor = getHPColor(p.getHealth)
        Else
            If p.getHealth <= 0.2 Then lblPHealth.ForeColor = Color.Crimson Else lblPHealth.ForeColor = Color.YellowGreen
        End If

        '|-- Update the target's information --|
        lblEName.Text = t.getName
        lblEHealth.Text = DDUtils.statBar(t.getIntHealth, t.getMaxHealth, lblEHealth)

        If lblEHealthChange.Tag > 0 Then
            lblEHealthChange.Text = "+" & lblEHealthChange.Tag
            lblEHealthChange.ForeColor = Color.YellowGreen
        Else
            lblEHealthChange.Text = lblEHealthChange.Tag
            lblEHealthChange.ForeColor = Color.Crimson
        End If

        If lblEHealthChange.Tag = 0 Then lblEHealthChange.Visible = False Else lblEHealthChange.Visible = True
        lblEHealthChange.Tag = 0
        x = (lblEHealth.Location.X * ratio) + (t.getHealth * (200 * ratio)) - (lblEHealthChange.Size.Width)
        If x < lblEHealth.Location.X + 10 Then x = lblEHealth.Location.X + 10
        lblEHealthChange.Location = New Point(x, lblEHealthChange.Location.Y)

        If health_bar_color_grad Is Nothing = False Then
            lblEHealth.ForeColor = getHPColor(t.getHealth)
        Else
            If t.getHealth <= 0.2 Then lblEHealth.ForeColor = Color.Crimson Else lblEHealth.ForeColor = Color.YellowGreen
        End If

        '|-- Update the player's health and stat information --|
        player1.UIupdate()
    End Sub
    Shared Function getHPColor(ByVal r As Double) As Color
        Dim place = Int(r * 100)
        If place >= 100 Then place = 99
        If place < 0 Then place = 0

        If Game.health_bar_color_grad Is Nothing Then
            Return Color.YellowGreen
        Else
            Return Game.health_bar_color_grad.GetPixel(place, 0)
        End If
    End Function
    Sub pnlCombatClose()
        pnlCombat.Visible = False

        lblCombatEvents.Text = ""
    End Sub

    '|SPELL/SPECIAL CAST/USE DIALOG BOX|
    Private Sub btnCastSpell_Click(sender As Object, e As EventArgs) Handles btnCastSpell.Click
        CastDialogBackend.doCastUse(sender, e, player1)
    End Sub
    Private Sub btnCastCancel_Click(sender As Object, e As EventArgs) Handles btnCastCancel.Click
        CastDialogBackend.fromPNLCast(sender, e, player1)
    End Sub
    Private Sub cboxCast_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboxCast.SelectedIndexChanged
        CastDialogBackend.cboxCastSelectedItemChanged(sender, e, player1)
    End Sub

    '|INVENTORY DISPLAY|
    Private Sub lstInventory_DrawItem(sender As Object, e As DrawItemEventArgs) Handles lstInventory.DrawItem
        e.DrawBackground()
        Dim textBrush As Brush = New SolidBrush(lstInventory.ForeColor)
        Dim drawFont As Font = e.Font

        If e.Index < 0 Then Exit Sub

        Dim text = DirectCast(sender, ListBox).Items(e.Index).ToString()

        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            e.Graphics.FillRectangle(New SolidBrush(lstInventory.BackColor), e.Bounds)
            If Not text.StartsWith("-") Then textBrush = Brushes.Gold
        End If


        If text.StartsWith("-") Then
            drawFont = DDUtils.scaledFont(drawFont, drawFont.Size, True)
        ElseIf Not (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            Dim i = 80
            textBrush = New SolidBrush(Color.FromArgb(lstInventory.ForeColor.A,
                                                      lstInventory.ForeColor.R - i,
                                                      lstInventory.ForeColor.B - i,
                                                      lstInventory.ForeColor.G - i))
        End If

        e.Graphics.DrawString(text,
                              drawFont,
                              textBrush,
                              e.Bounds,
                              StringFormat.GenericDefault)
    End Sub
    Private Sub lstInventory_MeasureItem(sender As Object, e As MeasureItemEventArgs) Handles lstInventory.MeasureItem
        Dim text = DirectCast(sender, ListBox).Items(e.Index).ToString()

        If Not (text.Equals("")) Then
            e.ItemHeight = TextRenderer.MeasureText(text, DirectCast(sender, ListBox).Font).Height
        Else
            e.ItemHeight *= 0.33
        End If
    End Sub
    Private Sub lstInventory_SelectedValueChanged(sender As Object, e As EventArgs) Handles lstInventory.SelectedValueChanged
        'lstInventory_SelectedValueChanged handles the selecting of items from the inventory listbox
        Try
            If lstInventory.SelectedItem.ToString.Length = 0 OrElse lstInventory.SelectedItem.ToString.EndsWith(":") Then Throw New NullReferenceException
            selectedItem = player1.inv.item(player1.inv.invIDorder(lstInventory.SelectedIndex))
            If Not selectedItem Is Nothing Then
                'MsgBox(aInd & ", " & subString)
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
        InventoryFilterBackend.btnFilter_Click(sender, e)
    End Sub
    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        InventoryFilterBackend.btnOk_Click(sender, e)
    End Sub
    Private Sub chkUseable_CheckedChanged(sender As Object, e As EventArgs) Handles chkUseable.CheckedChanged
        InventoryFilterBackend.fUseable_CheckedChanged(sender, e)
    End Sub
    Private Sub chkPotion_CheckedChanged(sender As Object, e As EventArgs) Handles chkPotion.CheckedChanged
        InventoryFilterBackend.fPotion_CheckedChanged(sender, e)
    End Sub
    Private Sub chkFood_CheckedChanged(sender As Object, e As EventArgs) Handles chkFood.CheckedChanged
        InventoryFilterBackend.fFood_CheckedChanged(sender, e)
    End Sub
    Private Sub chkArmor_CheckedChanged(sender As Object, e As EventArgs) Handles chkArmor.CheckedChanged
        InventoryFilterBackend.fArmor_CheckedChanged(sender, e)
    End Sub
    Private Sub chkWeapon_CheckedChanged(sender As Object, e As EventArgs) Handles chkWeapon.CheckedChanged
        InventoryFilterBackend.fWeapon_CheckedChanged(sender, e)
    End Sub
    Private Sub chkMisc_CheckedChanged(sender As Object, e As EventArgs) Handles chkMisc.CheckedChanged
        InventoryFilterBackend.fMisc_CheckedChanged(sender, e)
    End Sub
    Private Sub chkAcc_CheckedChanged(sender As Object, e As EventArgs) Handles chkAcc.CheckedChanged
        InventoryFilterBackend.chkAcc_CheckedChanged(sender, e)
    End Sub
    Private Sub chkGlasses_CheckedChanged(sender As Object, e As EventArgs) Handles chkGlasses.CheckedChanged
        InventoryFilterBackend.chkGlasses_CheckedChanged(sender, e)
    End Sub
    Private Sub btnAll_Click(sender As Object, e As EventArgs) Handles btnAll.Click
        InventoryFilterBackend.btnAll_Click(sender, e)
    End Sub
    Private Sub btnNone_Click(sender As Object, e As EventArgs) Handles btnNone.Click
        InventoryFilterBackend.btnNone_Click(sender, e)
    End Sub

    '| - NPC - |
    Sub npcEncounter(ByRef m As ShopNPC)
        If m.isDead Then Exit Sub

        '|-NPC Buttons-|
        showNPCButtons()
        If Not m.isShop Then btnShop.Enabled = False

        Dim validSpells() As String = {"Turn to Frog", "Polymorph Enemy", "Petrify", "Petrify II"}
        player1.magicRoute()
        For Each spell In validSpells
            If player1.knownSpells.Contains(spell) Then cboxNPCMG.Items.Add(spell)
        Next

        '|-Set up Game-|
        shop_npc_engaged = True
        active_shop_npc = m
        TextEvent.pushLog(("You approach " & m.getNameWithTitle & "."))

        '|-Set up NPC-|
        npc_list.Clear()
        npc_list.Add(m)
        m.encounter()
        picNPC.Visible = True

        '|-Set up the Player-|
        player1.canMoveFlag = False
    End Sub
    Sub shopNPCToCombat(ByRef m As NPC)
        '|-Set up Game-|
        picNPC.Visible = False
        shop_npc_engaged = False

        '|-Combat Dialog Box-|
        TextEvent.pushLog(DDUtils.capitalizeFirst(m.getNameWithTitle) & " attacks!")

        '|-Combat Buttons-|
        hideNPCButtons()

        toCombat(m)
    End Sub
    Sub showNPCButtons()
        'btnTalk.Visible = True
        btnNPCMG.Visible = True
        cboxNPCMG.Visible = True
        btnShop.Visible = True
        btnFight.Visible = True
        btnLeave.Visible = True
    End Sub

    Sub leaveNPC()
        '|-NPC Buttons-|
        If combat_engaged Then fromCombat()
        closeLblEvent()

        '|-Clean up NPC-|
        Dim m As ShopNPC = Nothing
        For i = 0 To npc_list.Count() - 1
            If npc_list.Item(i).GetType().IsSubclassOf(GetType(ShopNPC)) Then
                m = npc_list.Item(i)
                Exit For
            End If
        Next
        If Not m Is Nothing Then m.despawn("npc")

        '|-Clean up Game-|
        picNPC.Visible = False
        shop_npc_engaged = False
        active_shop_npc = Nothing
        btnEQP.Enabled = True
        npc_list.Clear()
        player1.canMoveFlag = True

        '|-Clean up the Player-|
        player1.clearTarget()
    End Sub
    Sub shopNPCFromCombat(ByRef m As NPC)
        fromCombat()

        '|-Reset the NPC-|
        TextEvent.pushLog(DDUtils.capitalizeFirst(m.getNameWithTitle) & " stops fighting!")
        npcEncounter(m)
    End Sub
    Sub hideNPCButtons()
        'btnTalk.Visible = False
        btnNPCMG.Visible = False
        cboxNPCMG.Visible = False
        btnShop.Visible = False
        btnFight.Visible = False
        btnLeave.Visible = False
    End Sub
    Private Sub btnLeave_Click(sender As Object, e As EventArgs) Handles btnLeave.Click
        leaveNPC()
        doLblEventOnClose()
    End Sub

    Sub npcMG()
        If cboxNPCMG.Text = "-- Select --" Or active_shop_npc Is Nothing Then Exit Sub
        closeLblEvent()

        TextEvent.pushNPCDialog(active_shop_npc.hitBySpell)

        Spell.spellCast(active_shop_npc, player1, cboxNPCMG.Text)

        If combat_engaged Then updatePnlCombat(player1, player1.currTarget)
        active_shop_npc.drawPort()
        drawBoard()
    End Sub
    Private Sub btnNPCMG_Click(sender As Object, e As EventArgs) Handles btnNPCMG.Click
        doLblEventOnClose()
        TextEvent.pushYesNo("Are you sure you want to do this?", AddressOf npcMG, Nothing)
    End Sub

    Sub npcFight()
        If currFloor.floorNumber = 7 And player1.perks(perk.seventailsstage) = 1 Then
            HypnoTeach.sevenTailsFight()
            Exit Sub
        End If

        If active_shop_npc Is Nothing Then Exit Sub

        shopNPCToCombat(active_shop_npc)
        TextEvent.pushNPCDialog(active_shop_npc.toFight())
    End Sub
    Private Sub btnFight_Click(sender As Object, e As EventArgs) Handles btnFight.Click
        doLblEventOnClose()
        TextEvent.pushYesNo("Are you sure you want to do this?", AddressOf npcFight, Nothing)
    End Sub

    '| - UI BUTTONS - |
    Private Sub btnDrop_Click(sender As Object, e As EventArgs) Handles btnDrop.Click
        doLblEventOnClose()
        selectedItem.discard()
        player1.inv.invNeedsUDate = True
        player1.UIupdate()

        lstInventory.SelectedItem = Nothing
        selectedItem = Nothing
        btnUse.Enabled = False
        btnDrop.Enabled = False
        btnLook.Enabled = False
    End Sub
    Private Sub btnLook_Click(sender As Object, e As EventArgs) Handles btnLook.Click
        doLblEventOnClose()
        selectedItem.examine()
        lstInventory.SelectedItem = Nothing
        selectedItem = Nothing
        btnUse.Enabled = False
        btnDrop.Enabled = False
        btnLook.Enabled = False
    End Sub
    Private Sub btnEXM_Click(sender As Object, e As EventArgs) Handles btnEXM.Click
        If Not TextEvent.lblEventOnClose Is Nothing Then Exit Sub
        TextEvent.pushLog(player1.description)
        toDesc()
    End Sub
    Private Sub btnIns_Click(sender As Object, e As EventArgs) Handles btnIns.Click
        doLblEventOnClose()
        HandleKeyPress(Keys.OemSemicolon)
    End Sub
    Private Sub btnS_Click(sender As Object, e As EventArgs) Handles btnS.Click
        'btnS is the new game button on the start menu
        newGame()
    End Sub
    Private Sub btnL_Click(sender As Object, e As EventArgs) Handles btnL.Click
        'btnL is the loadSave button on the start menu
        btnS.Visible = False
        btnL.Visible = False
        btnControls.Visible = False
        btnSettings.Visible = False
        btnAbout.Visible = False
        Application.DoEvents()
        Try
            solFlag = True
            toSOL()
        Catch ex As System.IO.FileNotFoundException
            DDError.noSaveDetectedError()
            btnS.Visible = True
            btnL.Visible = True
            btnControls.Visible = True
            btnSettings.Visible = True
            btnAbout.Visible = True
        Catch ex2 As Exception
            DDError.saveFileError()
            btnS.Visible = True
            btnL.Visible = True
            btnControls.Visible = True
            btnSettings.Visible = True
            btnAbout.Visible = True
        End Try
    End Sub
    Private Sub btnControls_Click(sender As Object, e As EventArgs) Handles btnControls.Click
        Dim f6 As Controls = New Controls
        f6.ShowDialog()
        f6.Dispose()
        loadCKeys()
    End Sub
    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        Dim ss = screenSize.ToString

        Dim s As Settings = New Settings
        s.ShowDialog()
        s.Dispose()

        If screenSize = "Maximized" Then
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Me.WindowState = FormWindowState.Maximized
        Else
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            Me.WindowState = FormWindowState.Normal
        End If

        If Not ss.Equals(screenSize) And Not ss.Equals("Large") Then
            Application.Restart()
        End If
        Game_Resize()
    End Sub
    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        Dim ab1 As About = New About
        ab1.ShowDialog()
        ab1.Dispose()
    End Sub

    '| - UI TOOLSTRIP - |
    Private Sub NewGameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewGameToolStripMenuItem.Click
        'NewGameToolStripMenuItem_Click restarts the application
        'Application.Restart()
        picStart.Visible = True
        newGame()
        HandleKeyPress(cKeys(20))
    End Sub
    Private Sub LoadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadToolStripMenuItem.Click
        If (lblEvent.Visible Or pnlEvent.Visible) Or combat_engaged Or shop_npc_engaged Or Me.MdiChildren.Length > 0 Then
            TextEvent.push("You can't load now!")
            Exit Sub
        End If
        solFlag = True
        toSOL()
    End Sub
    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        solFlag = False
        If (lblEvent.Visible Or pnlEvent.Visible) Or combat_engaged Or shop_npc_engaged Or Me.MdiChildren.Length > 0 Or
            (mDun.numCurrFloor = 4 And mDun.floorboss(4) = "Ooze Empress" And Not player1.preBSStartState.initFlag) Then
            TextEvent.push("You can't save now!")
            Exit Sub
        End If
        toSOL()
    End Sub
    Private Sub InfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InfoToolStripMenuItem.Click
        Dim ab1 As About = New About
        ab1.ShowDialog()
        ab1.Dispose()
    End Sub
    Private Sub DebugToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DebugToolStripMenuItem1.Click
        If debugWindow Is Nothing Then
            debugWindow = New Debug_Window
        End If

        debugWindow.ShowDialog()
        player1.inv.invNeedsUDate = True
        player1.UIupdate()
    End Sub
    Private Sub ReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportToolStripMenuItem.Click
        Process.Start("https://bitbucket.org/VowelHeavyUsername/dungeon_depths/issues?status=new&status=open")
    End Sub
    Private Sub HelpToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem1.Click
        Dim f6 As Controls = New Controls
        f6.ShowDialog()
        f6.Dispose()
        loadCKeys()
    End Sub
    Private Sub RunAutomatedTestsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RunAutomatedTestsToolStripMenuItem.Click
        ' RUNNING TESTS
        Testing.runTests()
        MsgBox("Tests ran!  Check TestLog.txt for their results.")
        ' END OF RUNNING TESTS
    End Sub
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub


    '| - TIMERS - |
    Private Sub tmrKeyCD_Tick(sender As Object, e As EventArgs) Handles tmrKeyCD.Tick
        tmrKeyCD.Enabled = False
    End Sub

    '| - INGAME EVENT DIALOG BOXES - |
    Public Sub cleanupPanels()
        pnlDescription.Visible = False
        pnlEquip.Visible = False
        If Not combat_engaged Then pnlCombat.Visible = False
        pnlEvent.Visible = False
        pnlSaveLoad.Visible = False
        pnlSelection.Visible = False
        selecting = False
        lblEvent.Visible = False

        player1.canMoveFlag = True
        btnEQP.Enabled = True


    End Sub
    Private Sub btnClosePnlEvent_Click(sender As Object, e As EventArgs) Handles btnClosePnlEvent.Click
        closeLblEvent()

        doLblEventOnClose()
    End Sub
    Private Sub btnNextLPnlEvent_Click(sender As Object, e As EventArgs) Handles btnNextLPnlEvent.Click
        TextEvent.eventDialogBox.nextpageL()
    End Sub
    Private Sub btnNextRPnlEvent_Click(sender As Object, e As EventArgs) Handles btnNextRPnlEvent.Click
        TextEvent.eventDialogBox.nextpageR()
    End Sub

    '| - LOADING BAR - |
    Public Sub initLoadBar()
        boardWorker = New BackgroundWorker
        boardWorker.WorkerReportsProgress = True
        boardWorker.WorkerSupportsCancellation = True
        AddHandler boardWorker.DoWork, AddressOf bw_DoWork
        AddHandler boardWorker.ProgressChanged, AddressOf bw_ProgressChanged
        AddHandler boardWorker.RunWorkerCompleted, AddressOf bw_RunWorkerCompleted
        picLoadBar.Size = New Size(10, 17)

        If picLoadBar.Visible = False Then picLoadBar.Visible = True
        Application.DoEvents()

        boardWorker.RunWorkerAsync()
        boardWorker.ReportProgress(0)
    End Sub
    Public Sub updateLoadbar(ByVal progress As Integer)
        If progress < 1 Or progress > 99 Or boardWorker Is Nothing Then Exit Sub
        boardWorker.ReportProgress(progress)
        Application.DoEvents()
    End Sub
    Private Sub bw_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
        While boardWorker.IsBusy
            If boardWorker.CancellationPending = True Then
                e.Cancel = True
                Exit While
            Else
                'Perform a time consuming operation
                System.Threading.Thread.Sleep(50)
            End If
        End While
    End Sub
    Private Sub bw_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs)
        Dim ratio As Double = Me.Size.Width / 1024
        picLoadBar.Size = New Size(((e.ProgressPercentage / 100) * 395) * ratio, 17 * ratio)
    End Sub
    Private Sub bw_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
        'System.Threading.Thread.Sleep(100)
        If e.Cancelled = True Then
            picLoadBar.Size = New Size(395, 17)
            Application.DoEvents()
            picLoadBar.Visible = False
        ElseIf e.Error IsNot Nothing Then
            MsgBox("Error: " & e.Error.Message)
        Else
            picLoadBar.Size = New Size(395, 17)
            Application.DoEvents()
            picLoadBar.Visible = False
        End If
        lblLoadMsg.Visible = False
        player1.canMoveFlag = True
        player1.drawPort()
    End Sub
    Public Sub ppw_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
        player1.drawPort()
    End Sub

    '| - GENERAL USE/UTILITY - |
    Private Sub prefetchImages()
        If imagesWorkerArg Is Nothing Then
            savePicsReady = False

            Try
                savePics(0) = Nothing
            Catch ex As Exception
                savePics.Add(Nothing)
            End Try

            For i = 1 To 10
                If System.IO.File.Exists("saves/s" & i.ToString() & ".ave") Then
                    Dim pic As Image
                    If System.IO.File.Exists("saves/s" & i.ToString() & ".ave.png") Then
                        Using fs As New FileStream("saves/s" & i.ToString() & ".ave.png", FileMode.Open, FileAccess.Read)
                            pic = Image.FromStream(fs)
                        End Using
                    Else
                        pic = getImgFromFile("saves/s" & i.ToString() & ".ave")
                        'System.IO.File.Create("s" & i.ToString() & ".ave.png")
                        pic.Save("saves/s" & i.ToString() & ".ave.png")
                    End If
                    Try
                        savePics(i) = pic
                    Catch ex As Exception
                        savePics.Add(pic)
                    End Try
                Else
                    Try
                        savePics(i) = Nothing
                    Catch ex As Exception
                        savePics.Add(Nothing)
                    End Try
                End If
            Next
            savePicsReady = True
        Else
            If System.IO.File.Exists("saves/s" & imagesWorkerArg.ToString() & ".ave") Then
                'Dim pic As Image = getImgFromFile("s" & imagesWorkerArg.ToString() & ".ave")
                Dim pic As Image = getSavePicture(picPortrait.BackgroundImage.Clone())
                Try
                    savePics(imagesWorkerArg) = pic
                Catch ex As Exception
                    savePics.Add(pic)
                End Try
                pic.Save("saves/s" & imagesWorkerArg.ToString() & ".ave.png")
            Else
                Try
                    savePics(imagesWorkerArg) = Nothing
                Catch ex As Exception
                    savePics.Add(Nothing)
                End Try
            End If
            imagesWorkerArg = Nothing
        End If
    End Sub
    Private Function getSavePicture(ByVal pic As Image)
        Dim g = Graphics.FromImage(pic)
        g.SmoothingMode = Drawing2D.SmoothingMode.None
        g.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor

        Dim f = New System.Drawing.Font(lblNameTitle.Font.FontFamily, Convert.ToSingle(lblNameTitle.Font.SizeInPoints), FontStyle.Bold, lblNameTitle.Font.Unit, lblNameTitle.Font.GdiCharSet)

        Dim n = centerSaveName(player1.name)

        g.DrawString(n, f, Brushes.Black, New Point(1, 190))
        g.DrawString(n, f, Brushes.Black, New Point(3, 190))
        g.DrawString(n, f, Brushes.Black, New Point(5, 190))

        g.DrawString(n, f, Brushes.Black, New Point(1, 188))
        g.DrawString(n, f, Brushes.Black, New Point(3, 188))
        g.DrawString(n, f, Brushes.Black, New Point(5, 188))

        g.DrawString(n, f, Brushes.Black, New Point(1, 192))
        g.DrawString(n, f, Brushes.Black, New Point(3, 192))
        g.DrawString(n, f, Brushes.Black, New Point(5, 192))

        g.DrawString(n, f, Brushes.White, New Point(3, 190))

        Return pic
    End Function
    Private Function centerSaveName(ByVal n As String) As String
        Dim MAX_LENGTH As Integer = 14

        If n.Length > MAX_LENGTH Then Return n.Substring(0, MAX_LENGTH) & "."

        While n.Length < MAX_LENGTH + 1
            n = n & " "
        End While

        Return n
    End Function
    Sub formReset()

        Application.Exit()
        'fromCombat()
        'picStart.Visible = True
        'btnS.Visible = True
        'btnL.Visible = True
        'btnControls.Visible = True
        'player1.canMoveFlag = False
    End Sub
    Private Sub Game_Resize()
        DDUtils.resizeForm(Me, iHeight, iWidth)
        If Not player1 Is Nothing Then player1.UIupdate()
    End Sub
    Private Sub CreateMapAndImages()
        'Dim XSize As Double = 15.0 * (CDbl(Me.Size.Width) / 688.0)
        'Dim YSize As Double = 15.0 * (CDbl(Me.Size.Width) / 688.0)

        'Dim imgSize As Integer = picTile.BackgroundImage.PhysicalDimension.Height
        'boardPic = New Bitmap(mBoardWidth * imgSize, currFloor.mBoardHeight * imgSize)
        'seenBoardPic = New Bitmap(mBoardWidth * imgSize, currFloor.mBoardHeight * imgSize)
        'savedBoardPic = New Bitmap(mBoardWidth * imgSize, currFloor.mBoardHeight * imgSize)
        'boxBoard = New PictureBox()
        'boxBoard.Width = 23 * 25
        'boxBoard.Height = 15 * 25
        'boxBoard.Width = 500
        'boxBoard.Height = 500
        'boxBoard.Size = New Point(YSize * 1.25 * 23, XSize * 1.25 * 15)
        'boxBoard.Location = New Point(60, 75)
        'boxBoard.Location = New Point(50, 50)
        'boxBoard.Visible = True
        'boxBoard.SizeMode = PictureBoxSizeMode.Zoom
        'AddHandler boxBoard.Paint, AddressOf boxBoard_Draw
        'Me.Controls.Add(boxBoard)
        'Me.Controls.SetChildIndex(boxBoard, Me.Controls.GetChildIndex(mPics(0, 0)))
        'boxBoard.BringToFront()

        'savedBoardPic = boardPic.Clone()
        'Using g As Graphics = Graphics.FromImage(savedBoardPic)
        '    g.DrawImageUnscaled(seenBoardPic, 0, 0)
        'End Using
        'boxBoard.Image = savedBoardPic
        'boxBoard.Image = savedBoardPic
    End Sub
    Private Sub LoadMapAndImages()
        'Dim imgSize As Integer = picTile.BackgroundImage.PhysicalDimension.Height
        'Using boardG As Graphics = Graphics.FromImage(boardPic), seenG As Graphics = Graphics.FromImage(seenBoardPic)
        '    For x = 0 To currFloor.mBoardWidth - 1
        '        For y = 0 To currFloor.mBoardHeight - 1
        '            Dim tile As mTile = currFloor.mBoard(y, x)
        '            Dim img As Image = Nothing

        '            If tile.Text = "H" Then 'Stairs
        '                img = picStairs.BackgroundImage
        '            ElseIf tile.Text = "#" OrElse tile.ForeColor = Color.FromArgb(45, 45, 45) Then 'Chest
        '                img = picChest.BackgroundImage
        '            ElseIf tile.Text = "@" And player1.pos.X = x And player1.pos.Y = y Then 'Player
        '                'img = picChest.BackgroundImage
        '                img = picTile.BackgroundImage 'Don't draw the player on the permanently saved background
        '            ElseIf tile.Text = "@" Then 'Statue
        '                img = picStatue.BackgroundImage
        '            ElseIf tile.Text = "$" Then 'NPC
        '                img = picNPC.BackgroundImage
        '            ElseIf tile.Text = "+" Then 'Trap
        '                img = picTrap.BackgroundImage
        '            ElseIf tile.Tag = 2 OrElse tile.Tag = 1 Then 'Seen or Unseen
        '                img = picTile.BackgroundImage
        '                'Else 'Nothing
        '                '    img = picChest.BackgroundImage
        '            End If

        '            If img IsNot Nothing Then
        '                boardG.DrawImage(img, x * imgSize, y * imgSize, imgSize, imgSize)
        '                If tile.Tag = 1 Then
        '                    seenG.FillRectangle(New SolidBrush(Color.FromArgb(39, 39, 39)), x * imgSize, y * imgSize, imgSize, imgSize)
        '                End If
        '            Else
        '                boardG.FillRectangle(Brushes.Black, x * imgSize, y * imgSize, imgSize, imgSize)
        '            End If
        '        Next
        '    Next
        'End Using
        'boardPic.Save("BOARD.png")
        'seenBoardPic.Save("BOARD_SEEN.png")
        'Console.WriteLine("CREATED BOARD AND BOARD_SEEN")

        'savedBoardPic = boardPic.Clone()
        'Using g As Graphics = Graphics.FromImage(savedBoardPic)
        '    g.DrawImageUnscaled(seenBoardPic, 0, 0)
        'End Using
        'savedBoardPic.Save("BOARD_RENDERED.png")
        'boxBoard.Image = savedBoardPic
    End Sub

    '| - EQUIPMENT DIALOG BOX - |
    Private Sub btnEquipCancel_Click(sender As Object, e As EventArgs) Handles btnEquipCancel.Click
        EquipmentDialogBackend.btnEquipCancelOnClick(player1, sender, e)
    End Sub
    Private Sub btnEquipConfirm_Click(sender As Object, e As EventArgs) Handles btnEquipConfirm.Click
        EquipmentDialogBackend.btnEquipConfirmOnClick(player1, sender, e)
    End Sub
    Private Sub equipDialogCBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboxArmor.SelectedValueChanged, cboxAccessory.SelectedValueChanged, cboxGlasses.SelectedValueChanged
        EquipmentDialogBackend.changeCBoxIndex(player1)
    End Sub

    '| - FUSION DIALOG BOX - |
    Private Sub btnFusionAcc_Click(sender As Object, e As EventArgs) Handles btnFusionAcc.Click
        FusionDialogBackend.btnOKOnClick(sender, e, player1)
    End Sub
    Private Sub btnFusionCancel_Click(sender As Object, e As EventArgs) Handles btnFusionCancel.Click
        FusionDialogBackend.btnCancelOnClick(sender, e, player1)
    End Sub
    Private Sub cboxFusion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboxFusionTarget.SelectedIndexChanged
        Dim p2 = Game.getPlayerFromFile("saves/s" & FusionDialogBackend.getSaveInd(cboxFusionTarget.SelectedIndex) & ".ave").Item1

        FusionDialogBackend.updateDisplay(player1, p2)
    End Sub

    '| - BAIT DIALOG BOX - |
    Private Sub btnConfirmBait_Click(sender As Object, e As EventArgs) Handles btnConfirmBait.Click
        SnareDialogBackend.fromPnlSnare(sender, e, player1)
    End Sub

    '| - SPELL/SPECIAL DESCRIPTION DIALOG - |
    Private Sub btnSpellSpecOK_Click(sender As Object, e As EventArgs) Handles btnSpellSpecOK.Click
        SpellSpecDescBackend.fromPNLSpellSpecDesc(sender, e, player1)
    End Sub
    Private Sub cboxSpellSpecialDescSelector_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboxSpellSpecialDescSelector.SelectedIndexChanged
        SpellSpecDescBackend.cboxSpellSpecIndexChanged(sender, e, player1)
    End Sub
End Class