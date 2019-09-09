Imports System.ComponentModel
Imports System.IO
Imports System.Threading
'Imports DDTooltip

Public Class Game
    'Form1 is the main driver form that runs the game

    'board instance variables
    Public mDun As Dungeon
    Public currFloor As mFloor
    Public boardPic As Bitmap
    Public seenBoardPic As Bitmap
    Public savedBoardPic As Bitmap
    Public boxBoard As PictureBox
    Public testingImageBoard As Boolean = False

    Public mPics(,) As PictureBox       '(NOT SAVED)

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

    Public player As Player = New Player()
    Public baseChest As Chest = New Chest()
    'player instance variables
    Public updateList As PQ = New PQ
    Public npcList As List(Of NPC) = New List(Of NPC)     'list of non-player updatables (NOT SAVED)
    Public shopNPCList As List(Of ShopNPC) = New List(Of ShopNPC)
    Public shopkeeper, swiz, hteach, fvend As ShopNPC
    Public currNPC As ShopNPC   'the current npc the player is talking to (NOT SAVED)
    Public pImage As Image  'which tile is used for the player (NOT SAVED)
    Public combatmode As Boolean = True 'indicates if the player is in combat (NOT SAVED)
    Public npcmode As Boolean = False   'indicates if the player is talking to an npc (NOT SAVED)
    Public npcIndex As Integer = 0  'indicates which npc is encountered (NOT SAVED)
    'a list containing all valid cheats
    Public cheatList() As String = {"asss", "daaa", "wawa", "sasa", "gogo", "seee", "aeio"} 'list of cheats (NOT SAVED)
    Dim keyspresed As String = ""   'records last 4 keys pressed (NOT SAVED)
    Public titleList = New List(Of String)
    'other misc form1 instance variables
    Dim selectedItem As Item = New Item()   'the item Fhilighted in the inventory (NOT SAVED)
    Dim monstierTier1() As Integer = {0, 1, 2, 6}
    Dim monstierTier2() As Integer = {0, 1, 2, 4, 6}
    Dim monstierTier3() As Integer = {0, 1, 2, 4, 6, 7}
    Dim monstierTier4() As Integer = {0, 1, 2, 3, 4, 6, 7}
    Public turn As Integer = 0  '(NOT SAVED)
    Public version As Double = 0.9     'the save file version

    Public lblEventOnClose As Action    'the event method preformed when lblEvent closes (NOT SAVED)
    Public eventDialogBox As EventBox
    Public lastKey As String
    Public yesAction, noAction As Action
    Public choiceText As String
    Public invFilters() As Boolean = {True, True, True, True, True, True, True}
    'Dim eClock As Integer = 15
    Dim eClock As Integer = eClockResetVal * 3
    Public solFlag As Boolean = True
    Private trd As Thread
    Dim imagesWorker As BackgroundWorker
    Public boardWorker As BackgroundWorker
    Public playerPortraitWorker As BackgroundWorker
    Private savePics As New List(Of Image)(9)
    Dim imagesWorkerArg = Nothing
    Dim savePicsReady As Boolean = False
    Dim boardReady As Boolean = False

    'for floor 4 body swap
    Public preBSBody As State
    Public preBSStartState As State
    Public preBSInventory As New ArrayList()

    Dim healthCol As Bitmap = Nothing

    Dim selecting As Boolean = False
    Dim selectionType As String = ""

    Dim cKeys As List(Of System.Windows.Forms.Keys) = New List(Of Keys)

    Dim iHeight, iWidth As Integer
    Dim startingHeight As Integer = 0
    Dim startingWidth As Integer = 0

    'settings
    Public screenSize As String
    Public noImg As Boolean
    Public pcUnwilling As Boolean

    Dim debugWindow As Debug_Window
    Public shopMenu As ShopV2

    '|STARTUP|
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Form1_Load handles the loading of the form
        If Not IO.File.Exists("sett.ing") Then createSettings()
        If Not IO.File.Exists("configs.ave") Then createConfigs()

        Dim r As System.IO.StreamReader
        r = IO.File.OpenText("sett.ing")
        screenSize = r.ReadLine
        noImg = r.ReadLine
        r.Close()

        If noImg Then
            picPortrait.Visible = False
            picDescPort.Visible = False
        End If



        iHeight = Size.Height
        iWidth = Size.Width

        startingHeight = CInt(Size.Height.ToString)
        startingWidth = CInt(Size.Width.ToString)
        If screenSize = "Small" Then
            Size = New Size(Size.Width * 0.8, Size.Height * 0.8)
        ElseIf screenSize = "Medium" Then
            Size = New Size(Size.Width * 0.9, Size.Height * 0.9)
        ElseIf screenSize = "XLarge" Then
            Size = New Size(iWidth * 1.3, iHeight * 1.3)
        ElseIf screenSize = "Maximized" Then
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Me.WindowState = FormWindowState.Maximized
        End If

        loadCKeys()
        imagesWorker = New BackgroundWorker
        AddHandler imagesWorker.DoWork, AddressOf prefetchImages
        imagesWorkerArg = Nothing
        imagesWorker.RunWorkerAsync()
        titleList.Addrange({"Warrior", "Mage", "Dragon", "Bimbo", "Paladin", "Succubus", "Slime", "Goddess",
                            "Magic Girl", "Targaxian", "Princess", "Blow-Up Doll", "Cow", "Kitty", "Soul-Lord", "Maid"})

        If (File.Exists("img/LifeColors.png")) Then
            healthCol = Image.FromFile("img/LifeColors.png")
        End If

        'sets the player tile image to the default @
        pImage = picPlayer.BackgroundImage
        'scales the font size to that of the window
        Dim newFont As Font = New System.Drawing.Font("Consolas", CInt(8 * Me.Size.Width / 688))
        For i = 0 To Me.Controls.Count - 1
            Me.Controls(i).Font = newFont
        Next
        For i = 0 To pnlSelection.Controls.Count - 1
            pnlSelection.Controls(i).Font = newFont
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
        For i = 0 To pnlDescript.Controls.Count - 1
            pnlDescript.Controls(i).Font = newFont
        Next

        pnlCombat.Location = New Point(115, pnlCombat.Location.Y)
        pnlDescript.Location = New Point(115, pnlDescript.Location.Y)
        pnlSaveLoad.Location = New Point(188, pnlSaveLoad.Location.Y)
        pnlSelection.Location = New Point(115, pnlSelection.Location.Y)
        picStart.Location = New Point(2, picStart.Location.Y)
        If Not System.IO.File.Exists("dis.cla") Then
            If MessageBox.Show("This game features adult content sexual in nature, and is not for anyone under the age of 18 or otherwise of legal age in their country. By clicking 'Yes' below, you confirm that you are legally an adult in your country.", "Obligatory Disclaimer", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                System.IO.File.CreateText("dis.cla")
            Else
                Me.Close()
            End If
        End If

        eventDialogBox = New EventBox(txtPNLEvents, pnlEvent)
        Game_Resize()
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
    Sub createSettings()
        Dim w As System.IO.StreamWriter
        w = System.IO.File.CreateText("sett.ing")
        w.WriteLine("Large")
        w.WriteLine(False)
        w.WriteLine(False)
        w.Close()
    End Sub
    Sub newGame()
        'newGame prepares the application at the start of a new game
        combatmode = False
        btnS.Visible = False
        btnL.Visible = False
        btnControls.Visible = False
        btnSettings.Visible = False
        btnAbout.Visible = False

        Dim chargen As New CharacterGenerator
        If noImg Then
            chargen.picPort.Visible = False
            chargen.pnlBody.Visible = False
        End If
        chargen.ShowDialog()
        If chargen.quit Then
            btnS.Visible = True
            btnL.Visible = True
            btnControls.Visible = True
            btnSettings.Visible = True
            btnAbout.Visible = True
            Exit Sub
        End If
        chargen.Dispose()
        Dim int As Integer = 100 - player.getSPD
        If int < 1 Then int = 1
        updateList.add(player, int)

        Dim genSet As New GeneratorSettings("{broke atm}")
        genSet.ShowDialog()
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
        Select Case CInt(Rnd() * 2)
            Case Else
                lblLoadMsg.Text = "You can challenge a floor boss at any time by finding the stairs " & vbCrLf &
                                  "and either clicking the ""Challenge Boss?"" button, or hitting the " & vbCrLf &
                                  "yes key (y by default)."
        End Select

        'creates the shopkeepers
        updateLoadbar(10)
        shopNPCList.Clear()
        shopkeeper = ShopNPC.shopFactory(0)
        updateLoadbar(12)
        swiz = ShopNPC.shopFactory(1)
        updateLoadbar(14)
        hteach = ShopNPC.shopFactory(2)
        updateLoadbar(16)
        fvend = ShopNPC.shopFactory(3)
        updateLoadbar(20)
        shopNPCList.AddRange({shopkeeper, swiz, hteach, fvend})

        'create the dungeon
        mDun = New Dungeon
        updateLoadbar(40)
        mDun.setFloor(currFloor)
        initializeBoard(False)
        updateLoadbar(60)
        drawBoard()

        'setup the player
        player.currState = New State(player)
        player.sState = New State(player)
        player.pState = New State(player)

        eClock = eClockResetVal * 3

        turn = 0

        pushLstLog("You see before you a dungeon.")
        picStart.Visible = False

        player.UIupdate()

        updateLoadbar(99)
        boardWorker.CancelAsync()
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

    '|BOARD GENERATION|
    Public Sub initializeBoard(Optional Draw As Boolean = True)
        lblEvent.Visible = False
        player.canMoveFlag = False
        newBoard()

        If Draw Then drawBoard()
    End Sub
    Sub newBoard()
        'newBoard creates a new representation of the board.
        player.setPImage()
        Dim Margin As Integer = 3
        Dim XSize As Double = 15.0 * (CDbl(Me.Size.Width) / 688.0)
        Dim YSize As Double = 15.0 * (CDbl(Me.Size.Width) / 688.0)

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

        If Not testingImageBoard Then
            Dim viewPicsDone As Integer = 0
            For y As Integer = 0 To viewHeight - 1
                For x As Integer = 0 To viewWidth - 1
                    Dim newPicture As PictureBox = New PictureBox()
                    newPicture.Name = "boardBox|" & x & "_" & y
                    newPicture.BackgroundImageLayout = ImageLayout.Stretch
                    newPicture.Size = New Point(YSize * 1.25, XSize * 1.25)
                    newPicture.Location = New Point(60 + x * (XSize * 1.233), 75 + y * (YSize * 1.233))
                    newPicture.Visible = True
                    Me.Controls.Add(newPicture)
                    mPics(y, x) = newPicture

                    viewPicsDone += 1
                Next
            Next
        End If

        If testingImageBoard Then
            CreateMapAndImages()
        End If
    End Sub
    Private Sub boxBoard_Draw(sender As Object, e As PaintEventArgs)
        Dim startTime As Double = (DateTime.Now - New DateTime(1970, 1, 1)).TotalMilliseconds
        e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
        'e.Graphics.DrawImage(map, CInt((picBoard.Width - (map.Width * magnification)) / 2) + xOffset, CInt((picBoard.Height - (map.Height * magnification)) / 2) + yOffset, map.Width * magnification + 0, map.Height * magnification + 0)
        Dim magnification As Double = 25 / 60
        Dim xOffSet As Integer, yOffset As Integer = 0
        xOffSet = player.pos.X * -25
        yOffset = player.pos.Y * -25
        'xOffSet = 25
        'yOffset = 25
        e.Graphics.FillRectangle(Brushes.Purple, 0, 0, boxBoard.Width, boxBoard.Height)
        'e.Graphics.DrawImage(savedBoardPic, CInt(boxBoard.Width / 2) + xOffSet, CInt(boxBoard.Height / 2) + yOffset, CInt(savedBoardPic.Width * magnification), CInt(savedBoardPic.Height * magnification))

        'e.Graphics.DrawImage(boardPic, CInt(boardPic.Width / 2) + xOffSet, CInt(boardPic.Height / 2) + yOffset, CInt(boardPic.Width * magnification), CInt(boardPic.Height * magnification))
        'e.Graphics.DrawImage(seenBoardPic, CInt(seenBoardPic.Width / 2) + xOffSet, CInt(seenBoardPic.Height / 2) + yOffset, CInt(seenBoardPic.Width * magnification), CInt(seenBoardPic.Height * magnification))

        e.Graphics.DrawImage(boardPic, CInt(boxBoard.Width / 2) + xOffSet, CInt(boxBoard.Height / 2) + yOffset, CInt(boardPic.Width * magnification), CInt(boardPic.Height * magnification))
        e.Graphics.DrawImage(seenBoardPic, CInt(boxBoard.Width / 2) + xOffSet, CInt(boxBoard.Height / 2) + yOffset, CInt(boardPic.Width * magnification), CInt(boardPic.Height * magnification))

        '15 tall, 23 wide
        e.Graphics.DrawImage(picPlayer.BackgroundImage, CInt(Math.Floor(11.5 * 25)) - 1, CInt(Math.Floor(7.5 * 25)) - 1, CInt(picPlayer.BackgroundImage.PhysicalDimension.Width * magnification), CInt(picPlayer.BackgroundImage.PhysicalDimension.Height * magnification))
        Dim endTime = (DateTime.Now - New DateTime(1970, 1, 1)).TotalMilliseconds
        Console.WriteLine("DRAW TIME: " + (endTime - startTime).ToString())
    End Sub

    '|DRAW|
    Sub drawBoard()
        'drawBoard updates the board with the players actions

        '"discover" any hidden tiles adjacent to the player and erase the players last location
        viewBubble()
        'moves down the priority que by the updatable's speed
        If pnlCombat.Visible = True Then lblCombatEvents.Text = ""
        Do While updateList.isEmpty() = False
            Dim u As Updatable = updateList.remove()
            u.update()
        Loop
        'updates the combat banner
        If combatmode Then
            updatePnlCombat(player, player.currTarget)
        End If

        'fills in any missing spaces
        If currFloor.mBoard(currFloor.stairs.Y, currFloor.stairs.X).Text <> "H" Then
            currFloor.mBoard(currFloor.stairs.Y, currFloor.stairs.X).Text = "H"
        End If
        If currfloor.chestList.Count > 0 Then
            For i = 0 To currfloor.chestList.Count - 1
                If currfloor.mBoard(currfloor.chestList.Item(i).pos.Y, currfloor.chestList.Item(i).pos.X).Text <> "#" Then
                    currfloor.mBoard(currfloor.chestList.Item(i).pos.Y, currfloor.chestList.Item(i).pos.X).Text = "#"
                End If
            Next
        End If
        If currfloor.statueList.Count > 0 Then
            For i = 0 To currfloor.statueList.Count - 1
                If currfloor.mBoard(currfloor.statueList.Item(i).pos.Y, currfloor.statueList.Item(i).pos.X).Text <> "@" Then
                    currfloor.mBoard(currfloor.statueList.Item(i).pos.Y, currfloor.statueList.Item(i).pos.X).Text = "@"
                End If
            Next
        End If

        For Each sNPC In shopNPCList
            If Not sNPC.isDead And sNPC.pos.X > 0 And sNPC.pos.Y > 0 Then
                currFloor.mBoard(sNPC.pos.Y, sNPC.pos.X).Text = "$"
            End If
        Next

        If currfloor.mBoard(player.pos.Y, player.pos.X).Text = "+" Then
            For i = 0 To currfloor.trapList.Count - 1
                If currfloor.trapList(i).pos = player.pos Then
                    Try
                        currfloor.trapList(i).activate(i)
                    Catch ex As Exception
                        pushLblEvent("As you wander forward, your foot falls on a pressure plate.  As soon as you hear it click, you snap to attention.  Looking around, you see that nothing seems to have happened." & vbCrLf & "𝘚𝘰𝘮𝘦𝘵𝘩𝘪𝘯𝘨 𝘮𝘶𝘴𝘵 𝘩𝘢𝘷𝘦 𝘨𝘰𝘯𝘦 𝘸𝘳𝘰𝘯𝘨 𝘸𝘪𝘵𝘩 𝘵𝘩𝘦 𝘵𝘳𝘢𝘱'𝘴 𝘢𝘤𝘵𝘪𝘷𝘢𝘵𝘪𝘰𝘯...")
                    End Try
                    Exit For
                End If
            Next
        End If

        currfloor.mBoard(player.pos.Y, player.pos.X).Text = "@"

        zoom()

        If mDun.numCurrFloor < 5 And mDun.numCurrFloor >= 0 AndAlso currFloor.beatBoss = False AndAlso Not mDun.floorboss(mDun.numCurrFloor).Equals("Key") And combatmode = False And player.health > 0 And player.canMoveFlag = True AndAlso New Point(player.pos.Y, player.pos.X).Equals(New Point(currFloor.stairs.Y, currFloor.stairs.X)) Then pushPnlYesNo("Challenge the floor boss?", AddressOf ChallengeBoss, Nothing)
        'If picNPC.Visible Then picNPC.BackgroundImage = NPCimgList(npcIndex)

        player.UIupdate()
    End Sub
    Sub viewBubble()
        Dim viewRad = 1
        'viewBubble "discovers" the area around the player and erases the players previous location
        If testingImageBoard Then
            Dim startTime As Double = (DateTime.Now - New DateTime(1970, 1, 1)).TotalMilliseconds
            Dim imgSize As Integer = picTile.BackgroundImage.PhysicalDimension.Height
            Using g As Graphics = Graphics.FromImage(seenBoardPic)
                For indY = -viewRad To viewRad
                    For indX = -viewRad To viewRad
                        If player.pos.Y + indY < mBoardHeight And player.pos.Y + indY >= 0 And player.pos.X + indX < mBoardWidth And player.pos.X + indX > 0 Then
                            If (currfloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Tag = 1) Then
                                'g.FillRectangle(Brushes.Purple, (player.pos.X + indX) * imgSize, (player.pos.Y + indY) * imgSize, imgSize, imgSize)
                                For thisX As Integer = (player.pos.X + indX) * imgSize To (player.pos.X + indX + 1) * imgSize
                                    For thisY As Integer = (player.pos.Y + indY) * imgSize To (player.pos.Y + indY + 1) * imgSize
                                        seenBoardPic.SetPixel(thisX, thisY, Color.Transparent)
                                    Next
                                Next
                                currfloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Tag = 2
                            End If
                            If currfloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "@" Then currfloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Text = ""
                            If currfloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "H" And currfloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Tag < 2 Then
                                currfloor.mBoard(player.pos.Y + indY, player.pos.X + indX).ForeColor = Color.Black
                                pushLstLog("Floor " & mDun.numCurrFloor & ": Staircase Discovered")
                            End If
                            If currfloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "#" And currfloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Tag < 2 Then
                                currfloor.mBoard(player.pos.Y + indY, player.pos.X + indX).ForeColor = Color.Black
                                pushLstLog("Chest discovered!")
                            End If
                            If currfloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "$" And currfloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Tag < 2 Then
                                currfloor.mBoard(player.pos.Y + indY, player.pos.X + indX).ForeColor = Color.Navy
                                pushLstLog("Shop discovered!")
                            End If
                            If currfloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Tag = 1 Then currfloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Tag = 2
                        End If
                    Next
                Next
            End Using
            'seenBoardPic.MakeTransparent(Color.Purple)
            'Using g As Graphics = Graphics.FromImage(savedBoardPic)
            '    g.DrawImageUnscaled(boardPic, 0, 0)
            '    g.DrawImageUnscaled(seenBoardPic, 0, 0)
            'End Using
            Dim endTime = (DateTime.Now - New DateTime(1970, 1, 1)).TotalMilliseconds
            Console.WriteLine("BUBBLE TIME: " + (endTime - startTime).ToString())
        Else
            Dim startTime As Double = (DateTime.Now - New DateTime(1970, 1, 1)).TotalMilliseconds
            For indY = -viewRad To viewRad
                For indX = -viewRad To viewRad
                    If (player.pos.Y + indY < mBoardHeight And player.pos.Y + indY >= 0 And player.pos.X + indX < mBoardWidth And player.pos.X + indX >= 0) Then
                        If currfloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "@" Then currfloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Text = ""
                        If currfloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "H" And currfloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Tag < 2 Then
                            currfloor.mBoard(player.pos.Y + indY, player.pos.X + indX).ForeColor = Color.Black
                            pushLstLog("Floor " & mDun.numCurrFloor & ": Staircase Discovered")
                        End If
                        If currfloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "#" And currfloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Tag < 2 Then
                            currfloor.mBoard(player.pos.Y + indY, player.pos.X + indX).ForeColor = Color.Black
                            pushLstLog("Chest discovered!")
                        End If
                        If currfloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "$" And currfloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Tag < 2 Then
                            currfloor.mBoard(player.pos.Y + indY, player.pos.X + indX).ForeColor = Color.Navy
                            pushLstLog("Shop discovered!")
                        End If
                        If currfloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Tag = 1 Then currfloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Tag = 2
                    End If
                Next
            Next

            Dim endTime = (DateTime.Now - New DateTime(1970, 1, 1)).TotalMilliseconds
            Console.WriteLine("BUBBLE TIME: " + (endTime - startTime).ToString())
        End If
    End Sub
    Sub zoom()
        'zoom interperates the data around the player from mBoard, and displays it on mPics

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
        '9 = locked stairs
        '10 = boss stairs
        '11 = shady wizard
        '12 = crystal
        '13 = path
        '14 = h. teacher
        '15 = f. vendor
        '16 = caelia

        If testingImageBoard Then
            boxBoard.Refresh()
        Else
            'Dim startTime As Double = (DateTime.Now - New DateTime(1970, 1, 1)).TotalMilliseconds
            Dim viewArray(15, 23) As Integer
            Dim x As Integer = 0
            Dim y As Integer = 0
            For indY = -7 To 7
                x = 0
                For indX = -11 To 11
                    If (player.pos.Y + indY >= 0 And player.pos.Y + indY < mBoardHeight) And (player.pos.X + indX >= 0 And player.pos.X + indX < mBoardWidth) Then
                        viewArray(y, x) = currFloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Tag
                        If currFloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Tag = 2 Then
                            If currFloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "" Then viewArray(y, x) = 2
                            If currFloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "x" Then viewArray(y, x) = 13
                            If currFloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "H" Then
                                If mDun.numCurrFloor > 5 Or currFloor.beatBoss Then
                                    viewArray(y, x) = 3
                                ElseIf mDun.numCurrFloor > 5 Or (mDun.numCurrFloor < 5 AndAlso mDun.floorboss(mDun.numCurrFloor).Equals("Key")) Then
                                    viewArray(y, x) = 9
                                Else
                                    viewArray(y, x) = 10
                                End If
                            End If
                            If currFloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "#" Then viewArray(y, x) = 5
                            If currFloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "$" And player.pos.Y + indY = shopkeeper.pos.Y And player.pos.X + indX = shopkeeper.pos.X Then viewArray(y, x) = 6
                            If currFloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "$" And player.pos.Y + indY = swiz.pos.Y And player.pos.X + indX = swiz.pos.X Then viewArray(y, x) = 11
                            If currFloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "$" And player.pos.Y + indY = hteach.pos.Y And player.pos.X + indX = hteach.pos.X Then viewArray(y, x) = 14
                            If currFloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "$" And player.pos.Y + indY = fvend.pos.Y And player.pos.X + indX = fvend.pos.X Then viewArray(y, x) = 15
                            If currFloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "+" Then viewArray(y, x) = 8
                            If currFloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "c" Then viewArray(y, x) = 12
                            If player.perks("blind") > -1 Then viewArray(y, x) = 1
                        End If
                        If currFloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "@" Then
                            If indY = 0 And indX = 0 Then viewArray(y, x) = 4 Else viewArray(y, x) = 7
                        End If
                    Else
                        viewArray(y, x) = 0
                    End If
                    If mDun.numCurrFloor < 6 Then
                        setDungeonTileImg(x, y, viewArray)
                    ElseIf mDun.numCurrFloor = 9999 Then
                        setSpaceTileImg(x, y, viewArray)
                    ElseIf mDun.numCurrFloor = 91017 Then
                        setLegacyTileImg(x, y, viewArray)
                    Else
                        setForestTileImg(x, y, viewArray)
                    End If
                    x += 1
                Next
                y += 1
            Next
            'Dim endTime As Double = (DateTime.Now - New DateTime(1970, 1, 1)).TotalMilliseconds
            'Console.WriteLine("UPDATE TIME: " + (endTime - startTime).ToString())
        End If
    End Sub
    Sub setDungeonTileImg(ByVal x As Integer, ByVal y As Integer, ByRef viewArray As Integer(,))
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
                mPics(y, x).BackgroundImage = player.pImage
            Case 5
                mPics(y, x).BackgroundImage = picChest.BackgroundImage
            Case 6
                mPics(y, x).BackgroundImage = picShopkeepTile.BackgroundImage
            Case 7
                mPics(y, x).BackgroundImage = picStatue.BackgroundImage
            Case 8
                mPics(y, x).BackgroundImage = picTrap.BackgroundImage
            Case 9
                mPics(y, x).BackgroundImage = picStairsLock.BackgroundImage
            Case 10
                mPics(y, x).BackgroundImage = picStairsBoss.BackgroundImage
            Case 11
                mPics(y, x).BackgroundImage = picSWiz.BackgroundImage
            Case 12
                mPics(y, x).BackgroundImage = picCrystal.BackgroundImage
            Case 13
                mPics(y, x).BackgroundImage = picPath.BackgroundImage
            Case 14
                mPics(y, x).BackgroundImage = picHT.BackgroundImage
            Case 15
                mPics(y, x).BackgroundImage = picFVtile.BackgroundImage
        End Select
    End Sub
    Sub setForestTileImg(ByVal x As Integer, ByVal y As Integer, ByRef viewArray As Integer(,))
        Select Case viewArray(y, x)
            Case 0
                mPics(y, x).BackgroundImage = picTree.BackgroundImage
            Case 1
                mPics(y, x).BackgroundImage = Nothing
                mPics(y, x).BackColor = Color.FromArgb(255, 19, 38, 22)
            Case 2
                mPics(y, x).BackgroundImage = picTileF.BackgroundImage
            Case 3
                mPics(y, x).BackgroundImage = picLadderf.BackgroundImage
            Case 4
                mPics(y, x).BackgroundImage = player.pImage
            Case 5
                mPics(y, x).BackgroundImage = picChestf.BackgroundImage
            Case 6
                mPics(y, x).BackgroundImage = picShopkeeperf.BackgroundImage
            Case 7
                mPics(y, x).BackgroundImage = picStatuef.BackgroundImage
            Case 8
                mPics(y, x).BackgroundImage = picTrapf.BackgroundImage
            Case 9
                mPics(y, x).BackgroundImage = picstairslockf.BackgroundImage
            Case 10
                mPics(y, x).BackgroundImage = picstairsbossf.BackgroundImage
            Case 11
                mPics(y, x).BackgroundImage = picSWizF.BackgroundImage
            Case 12
                mPics(y, x).BackgroundImage = picCrystalf.BackgroundImage
            Case 13
                mPics(y, x).BackgroundImage = picPathf.BackgroundImage
            Case 14
                mPics(y, x).BackgroundImage = picHTf.BackgroundImage
            Case 15
                mPics(y, x).BackgroundImage = picFVf.BackgroundImage
        End Select
    End Sub
    Sub setSpaceTileImg(ByVal x As Integer, ByVal y As Integer, ByRef viewArray As Integer(,))
        Select Case viewArray(y, x)
            Case 0
                'MsgBox(x & " " & y)
                mPics(y, x).BackgroundImage = Nothing
                mPics(y, x).BackColor = Color.Black
            Case 1
                mPics(y, x).BackgroundImage = picFog.BackgroundImage
            Case 2
                mPics(y, x).BackgroundImage = picSpaceTile.BackgroundImage
            Case 3
                mPics(y, x).BackgroundImage = picSpaceStairs.BackgroundImage
            Case 4
                mPics(y, x).BackgroundImage = player.pImage
            Case 5
                mPics(y, x).BackgroundImage = picSpaceChest.BackgroundImage
            Case 7
                mPics(y, x).BackgroundImage = picSpaceCrystal.BackgroundImage
            Case 8
                mPics(y, x).BackgroundImage = picSpaceTrap.BackgroundImage
            Case 12
                mPics(y, x).BackgroundImage = picSpaceCrystal.BackgroundImage
            Case 13
                mPics(y, x).BackgroundImage = picSPacePath.BackgroundImage
            Case Else
                mPics(y, x).BackgroundImage = Nothing
                mPics(y, x).BackColor = Color.Black
        End Select
    End Sub
    Sub setLegacyTileImg(ByVal x As Integer, ByVal y As Integer, ByRef viewArray As Integer(,))
        Select Case viewArray(y, x)
            Case 0
                'MsgBox(x & " " & y)
                mPics(y, x).BackgroundImage = Nothing
                mPics(y, x).BackColor = Color.Black
            Case 1
                mPics(y, x).BackgroundImage = picFog.BackgroundImage
            Case 2
                mPics(y, x).BackgroundImage = picLegaTile.BackgroundImage
            Case 3
                mPics(y, x).BackgroundImage = piclegaStairs.BackgroundImage
            Case 4
                mPics(y, x).BackgroundImage = player.pImage
            Case 5
                mPics(y, x).BackgroundImage = picLegaChest.BackgroundImage
            Case 7
                mPics(y, x).BackgroundImage = picLegaCrystal.BackgroundImage
            Case 8
                mPics(y, x).BackgroundImage = picLegaTrap.BackgroundImage
            Case 12
                mPics(y, x).BackgroundImage = picLegaCrystal.BackgroundImage
            Case 13
                mPics(y, x).BackgroundImage = picLegaPath.BackgroundImage
            Case 16
                mPics(y, x).BackgroundImage = picLegaCaelia.BackgroundImage
            Case Else
                mPics(y, x).BackgroundImage = Nothing
                mPics(y, x).BackColor = Color.Black
        End Select
    End Sub
    '|COMMAND DRIVERS|
    Function HandleKeyPress(ByVal Keydata As Keys) As Boolean
        'handleKeyPress handles the players pressed keys, and is the driver function for each one
        Dim startTime As Double = (DateTime.Now - New DateTime(1970, 1, 1)).TotalMilliseconds
        Dim endTime As Double = startTime
        lastKey = Keydata.ToString.ToLower
        If Not selecting Then
            If shouldReturnEarly(Keydata) Then Return True
            Dim spos As Point = player.pos
            If isALetter(Keydata.ToString.ToLower) Then keyspresed += Keydata.ToString.ToLower
            Select Case Keydata
                Case cKeys(0)
                    If player.pClass.name.Equals("Mindless") Then
                        player.wander()
                    Else
                        player.moveUp()
                    End If

                    randomEvents()
                Case cKeys(1)
                    If player.pClass.name.Equals("Mindless") Then
                        player.wander()
                    Else
                        player.moveDown()
                    End If
                    randomEvents()
                Case cKeys(2)
                    If player.pClass.name.Equals("Mindless") Then
                        player.wander()
                    Else
                        player.moveLeft()
                    End If
                    randomEvents()
                Case cKeys(3)
                    If player.pClass.name.Equals("Mindless") Then
                        player.wander()
                    Else
                        player.moveRight()
                    End If
                    randomEvents()
                Case cKeys(4)
                    Try
                        oemSemiColon()
                    Catch ex As Exception
                        Return True
                    End Try
                Case cKeys(5)
                    talkKey()
                Case cKeys(6)
                    attackKey()
                Case cKeys(7)
                    magicKey()
                    Return True
                Case cKeys(8)
                    specialKey()
                Case cKeys(9)
                    waitKey()
                Case cKeys(10)
                    runKey()
                Case cKeys(11)
                    drinkKey()
                Case cKeys(12)
                    useKey()
                Case cKeys(13)
                    toShopKey()
                Case cKeys(14)
                    eArmorKey()
                Case cKeys(15)
                    'accessory
                Case cKeys(16)
                    eWeaponKey()
                Case cKeys(17)
                    selfinpKey()
                Case cKeys(18)
                    eatKey()
                Case cKeys(19)
                    yesKey()
                Case cKeys(20)
                    noKey()
                Case Keys.Enter
                    oemReturn()
                Case Keys.Up
                    If player.pClass.name.Equals("Mindless") Then
                        player.wander()
                    Else
                        player.moveUp()
                    End If
                    randomEvents()
                Case Keys.Down
                    If player.pClass.name.Equals("Mindless") Then
                        player.wander()
                    Else
                        player.moveDown()
                    End If
                    randomEvents()
                Case Keys.Left
                    If player.pClass.name.Equals("Mindless") Then
                        player.wander()
                    Else
                        player.moveLeft()
                    End If
                    randomEvents()
                Case Keys.Right
                    If player.pClass.name.Equals("Mindless") Then
                        player.wander()
                    Else
                        player.moveRight()
                    End If
                    randomEvents()
                Case Keys.Escape
                    If screenSize.Equals("Maximized") Then
                        screenSize = "Large"
                        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                        Me.WindowState = FormWindowState.Normal
                        Size = New Size(iWidth, iHeight)
                        Game_Resize()
                        Return True
                    End If
            End Select
            Dim int As Integer = 100 - player.getSPD
            If int < 1 Then int = 1
            updateList.add(player, (int))
            turn += 1
            If Not Keydata.Equals(cKeys(10)) Then drawBoard()

            endTime = (DateTime.Now - New DateTime(1970, 1, 1)).TotalMilliseconds
            Console.WriteLine("TOTAL TIME: " + (endTime - startTime).ToString())
            Return True
        Else
            If Keydata.Equals(Keys.Up) Then
                lstSelec.TopIndex -= 1
                endTime = (DateTime.Now - New DateTime(1970, 1, 1)).TotalMilliseconds
                Console.WriteLine("TOTAL TIME: " + (endTime - startTime).ToString())
                Return True
            End If
            If Keydata.Equals(Keys.Down) Then
                lstSelec.TopIndex += 1
                endTime = (DateTime.Now - New DateTime(1970, 1, 1)).TotalMilliseconds
                Console.WriteLine("TOTAL TIME: " + (endTime - startTime).ToString())
                Return True
            End If
            If Keydata.Equals(Keys.Back) Then
                selecting = False
                pnlSelection.Location = New Point(1000, pnlSelection.Location.Y)
                pnlSelection.Visible = False
                endTime = (DateTime.Now - New DateTime(1970, 1, 1)).TotalMilliseconds
                Console.WriteLine("TOTAL TIME: " + (endTime - startTime).ToString())
                Return True
            End If
            selection(Keydata)
        End If
        endTime = (DateTime.Now - New DateTime(1970, 1, 1)).TotalMilliseconds
        Console.WriteLine("TOTAL TIME: " + (endTime - startTime).ToString())
        Return True
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
        If Not lblEventOnClose Is Nothing Then
            If pnlEvent.Visible Then
                If Not eventDialogBox.hasHitEnd And eventDialogBox.getPageInd < eventDialogBox.getPageCt - 2 Then
                    eventDialogBox.nextpageL()
                    Exit Sub
                End If
            End If

            Dim lastOnClose = lblEventOnClose.Method.Name
            lblEventOnClose()
            If lblEventOnClose.Method.Name.Equals(lastOnClose) Then
                lblEventOnClose = Nothing
            End If

            If Not combatmode Then player.canMoveFlag = True
        End If
    End Sub

    'selection drivers
    Sub selection(ByVal Keydata As Keys)
        If Keydata.Equals(Keys.Up) Or Keydata.Equals(Keys.Down) Then
            Exit Sub
        End If
        Dim indexes = "abcdefghijklmnopqrstuvwxyz123456789".ToCharArray.ToList
        If indexes.Contains(Keydata.ToString.ToLower) Then
            Dim index = indexes.IndexOf(Keydata.ToString.ToLower)
            If index > lstSelec.Items.Count - 1 Then
                lblInstruc.Text = "Invalid selection:" & vbCrLf & "Please select another letter."
                Exit Sub
            End If
            If selectionType.Equals("Potion") Or selectionType.Equals("Useable") Or selectionType.Equals("Food") Then
                selectItem(index)
            ElseIf selectionType = "Magic" Then
                selectMagic(index)
            ElseIf selectionType = "Spec" Then
                selectSpec(index)
            ElseIf selectionType = "Armor" Then
                selectArmor(index)
            ElseIf selectionType = "Weapon" Then
                selectWeapon(index)
            ElseIf selectionType = "yesNo" Then
                selectYesNo(index)
            End If
            player.inv.invNeedsUDate = True
            player.UIupdate()
            selecting = False
            player.canMoveFlag = True
            pnlSelection.Location = New Point(1000, pnlSelection.Location.Y)
            pnlSelection.Visible = False
            selectedItem = Nothing
        End If
    End Sub
    Sub selectItem(ByVal index As Integer)
        Dim subString As String = lstSelec.Items(index).ToString.Split(" (")(2)
        selectedItem = player.inv.item(lstSelec.Items(index).ToString.Split(" (")(2))
        If Not selectedItem Is Nothing AndAlso selectedItem.getUsable Then selectedItem.use()
    End Sub
    Sub selectMagic(ByVal index As Integer)
        turn += 1
        doLblEventOnClose()
        lblCombatEvents.Text = ""
        closeLblEvent()
        If player.mana <= 0 Then
            pushLblEvent("You don't have enough mana!")
            pushLstLog("You don't have enough mana!")
            Exit Sub
        End If
        Dim subString As String = lstSelec.Items(index).ToString.Split("-")(1)
        subString = subString.Substring(1, subString.Count - 1)

        If combatmode Then
            Dim m As NPC = Nothing
            For i = 0 To npcList.Count() - 1
                If npcList.Item(i).GetType().IsSubclassOf(GetType(NPC)) Or npcList.Item(i).GetType() Is GetType(NPC) Then
                    m = npcList.Item(i)
                    Exit For
                End If
            Next
            player.nextCombatAction = Sub(t As Entity) Spell.spellCast(t, player, subString)
            queueSetup()
            Do While updateList.isEmpty() = False
                Dim u As Updatable = updateList.remove()
                u.update()
            Loop
            'updates the combat banner
            updatePnlCombat(player, player.currTarget)
        Else
            Spell.spellCast(Nothing, player, subString)
        End If
        ttCosts.RemoveAll()
    End Sub
    Sub selectSpec(ByVal index As Integer)
        turn += 1
        doLblEventOnClose()
        lblCombatEvents.Text = ""
        closeLblEvent()
        Dim m As NPC = Nothing
        For i = 0 To npcList.Count() - 1
            If npcList.Item(i).GetType().IsSubclassOf(GetType(NPC)) Or npcList.Item(i).GetType() Is GetType(NPC) Then
                m = npcList.Item(i)
                Exit For
            End If
        Next

        Special.specPerform(m, player, cboxSpec.Items(index))

        If cboxSpec.Items.Count = 0 Then
            cboxSpec.Visible = False
            btnSpec.Visible = False
        End If
        cboxSpec.Text = "-- Select --"
        queueSetup()
        Do While updateList.isEmpty() = False
            Dim u As Updatable = updateList.remove()
            u.update()
        Loop
        'updates the combat banner
        updatePnlCombat(player, player.currTarget)
        ttCosts.RemoveAll()
    End Sub
    Sub selectArmor(ByVal index As Integer)
        Dim subString As String = lstSelec.Items(index).ToString.Split(" (")(2)

        'if clothes offer resistance on the way off, this handles that
        If (player.equippedArmor.getName.Equals("Ropes") And subString <> "Ropes") Or (player.equippedArmor.getName.Equals("Living_Armor") _
            And subString <> "Living_Armor") Or (player.equippedArmor.getName.Equals("Living_Lingerie") And subString <> "Living_Lingerie") Then
            If Int(Rnd() * 2) = 0 Then
                pushLblEvent("Despite a struggle agaisnt your bonds, you are unable to escape!  Oh well, maybe next time...")
                Me.Close()
                Exit Sub
            Else
                pushLblEvent("You deftly take off your clothes, despite the resistance they put up.")
            End If
        End If
        If Not player.equippedArmor.getName.Equals(subString) Then
            player.equippedArmor.onUnequip()
        End If

        'equip the new armor
        Equipment.clothesChange(subString)
        If player.equippedArmor.mBoost > 0 Then player.mana += player.equippedArmor.mBoost

        If player.mana > player.getMaxMana Then player.mana = player.getMaxMana

        'if the player has the slutty dress curse, this takes care of it
        If player.perks("slutcurse") > -1 Then
            Equipment.clothingCurse1()
        End If

        'handles any tfs or triggers triggered by equipping of certain weapons
        If player.pClass.name.Equals("Magic Girl") And player.equippedArmor.getName.Equals("Magic_Girl_Outfit") Then
            player.equippedArmor = player.inv.item(10)
            pushLstLog("A magic girl needs her uniform!")
        End If

        If player.pForm.name.Equals("Blow-Up Doll") Then
            player.equippedArmor = New Naked
        End If

        'handles any tfs or triggers triggered by equipping of certain armors
        If player.equippedArmor.getName = "Living_Armor" And Not player.perks("livearm") > -1 Then
            player.perks("livearm") = 0
        ElseIf player.equippedArmor.getName = "Living_Lingerie" And Not player.perks("livelinge") > -1 Then
            player.perks("livelinge") = 0
        End If

        'updates the player, the stat display, and the portrait before the form closes
        player.createP()
        player.UIupdate()

    End Sub
    Sub selectWeapon(ByVal index As Integer)
        Dim subString As String = lstSelec.Items(index).ToString.Split(" (")(2)

        If Not player.equippedWeapon.getName.Equals(subString) Then
            player.equippedWeapon.onUnequip()
        End If

        'this handles the revert from the magical girl form, if needed
        If player.equippedWeapon.getName.Equals("Magic_Girl_Wand") And player.pClass.name.Equals("Magic Girl") And Not subString.Equals("Magic_Girl_Wand") Then
            pushLstLog("Putting away your wand causes you to change into your regular self!")
            player.inv.add(10, -1)
            player.magGState.save(player)
            player.revertToPState()
        End If

        Dim owName = player.equippedWeapon.getName

        'handles the equiping of weapons
        Dim sWeapon As Weapon = Nothing
        If subString <> "" Then
            For Each k In Equipment.wList.Keys
                If subString.ToString().Split()(0).Equals(k) Then
                    sWeapon = Equipment.wList(k)
                    Exit For
                End If
            Next
            If sWeapon Is Nothing Then Exit Sub
            player.equippedWeapon = sWeapon
        End If
        If player.equippedWeapon.mBoost > 0 Then player.mana += player.equippedWeapon.mBoost
        If player.mana > player.getMaxMana Then player.mana = player.getMaxMana

        'handles any tfs or triggers triggered by equipping of certain weapons
        If Not player.equippedWeapon.getName.Equals(owName) Then
            player.equippedWeapon.onEquip()
        End If

        'updates the player, the stat display, and the portrait before the form closes
        player.createP()
        player.UIupdate()

    End Sub
    Sub selectYesNo(ByVal index As Integer)
        Dim tempAct = yesAction.Clone

        If index = 0 Then
            If Not yesAction Is Nothing Then yesAction()
        Else
            If Not noAction Is Nothing Then noAction()
        End If

        If tempAct Is yesAction Then
            choiceText = Nothing
            yesAction = Nothing
            noAction = Nothing
        End If
    End Sub
    Sub toPNLSelec(ByVal mode As String)
        selecting = True
        pnlSelection.BringToFront()
        lstSelec.Items.Clear()
        lstInventory.Focus()
        lblInstruc.Text = "Type the corresponding letter," & vbCrLf & "and use the arrows to scroll"
        Dim indexes = "abcdefghijklmnopqrstuvwxyz123456789".ToCharArray
        Dim count = 0
        Select Case mode
            Case "Potion"
                lblWhat.Text = "Drink what?"
                Dim potion_list = player.inv.getPotions
                For i = 0 To UBound(potion_list)
                    If potion_list(i).count > 0 Then
                        lstSelec.Items.Add(indexes(count) & " - " & potion_list(i).getName)
                        count += 1
                    End If
                Next
            Case "Useable"
                lblWhat.Text = "Use what?"
                Dim useable_list = player.inv.getUseable
                For i = 0 To UBound(useable_list)
                    If useable_list(i).count > 0 Then
                        lstSelec.Items.Add(indexes(count) & " - " & useable_list(i).getName)
                        count += 1
                    End If
                Next
            Case "Food"
                lblWhat.Text = "Eat what?"
                Dim food_list = player.inv.getFood
                For i = 0 To UBound(food_list)
                    If food_list(i).count > 0 Then
                        lstSelec.Items.Add(indexes(count) & " - " & food_list(i).getName)
                        count += 1
                    End If
                Next
            Case "Magic"
                lblWhat.Text = "Cast what?"
                If npcmode Then
                    For i = 0 To cboxNPCMG.Items.Count - 1
                        lstSelec.Items.Add(indexes(count) & " - " & cboxNPCMG.Items(i).ToString)
                        count += 1
                    Next
                Else
                    For i = 0 To player.knownSpells.Count - 1
                        lstSelec.Items.Add(indexes(count) & " - " & player.knownSpells(i).ToString)
                        count += 1
                    Next
                End If
            Case "Spec"
                lblWhat.Text = "Perform what?"
                For i = 0 To cboxSpec.Items.Count - 1
                    lstSelec.Items.Add(indexes(count) & " - " & cboxSpec.Items(i).ToString)
                    count += 1
                Next
            Case "Armor"
                lblWhat.Text = "Equip what?"
                lstSelec.Items.Add("a - Naked")
                count += 1
                If player.pClass.name = "Bimbo" Or player.perks("slutcurse") > -1 Then
                    lstSelec.Items.Add("b - Skimpy_Clothes")
                ElseIf player.pClass.name = "Princess" Then
                    lstSelec.Items.Add("b - Regal_Gown")
                ElseIf player.pClass.name = "Maid" Then
                    lstSelec.Items.Add("b - Maid_Outfit")
                ElseIf player.pForm.name = "Succubus" Then
                    lstSelec.Items.Add("b - Succubus_Garb")
                ElseIf player.pClass.name = "Goddess" Then
                    lstSelec.Items.Add("b - Goddess_Gown")
                Else
                    lstSelec.Items.Add("b - Common_Clothes")
                End If
                count += 1
                For i = 0 To UBound(player.inv.getArmors.Item2)
                    If player.inv.getArmors.Item2(i).count > 0 Then
                        lstSelec.Items.Add(indexes(count) & " - " & player.inv.getArmors.Item2(i).getName)
                        count += 1
                    End If
                Next
            Case "Weapon"
                lblWhat.Text = "Equip what?"
                lstSelec.Items.Add("a - Fists")
                count += 1
                For i = 0 To UBound(player.inv.getWeapons.Item2)
                    If player.inv.getWeapons.Item2(i).count > 0 Then
                        lstSelec.Items.Add(indexes(count) & " - " & player.inv.getWeapons.Item2(i).getName)
                        count += 1
                    End If
                Next
            Case "yesNo"
                lblWhat.Text = choiceText
                lstSelec.Items.Add("a - Yes") 'cKeys(19).ToString.ToLower & " - Yes")
                lstSelec.Items.Add("b - No") 'cKeys(20).ToString.ToLower & " - No")
        End Select
        selectionType = mode
        pnlSelection.Location = New Point(115, pnlSelection.Location.Y)
        pnlSelection.Visible = True
    End Sub
    Sub makeChoice()
        toPNLSelec("yesNo")
    End Sub
    'utility functions for the command drivers
    Sub queueSetup()
        'This sets up the update list
        Dim int As Integer = 999 - player.getSPD
        If int < 1 Then int = 1

        If npcList.Count > 0 Then
            For i = 0 To npcList.Count - 1
                Dim int1 As Integer = 999 - npcList.Item(i).speed
                If int - int1 = 0 Then int1 -= 1

                If int1 < 1 Then int1 = 1
                updateList.add(npcList.Item(i), (int1))
            Next
        End If

        updateList.add(player, int)
    End Sub
    Sub randomEvents()
        'randomEvents decides whether random encounters will occur, and handles what will be encountered
        If mDun.numCurrFloor = 5 Or mDun.numCurrFloor = 9999 Then Exit Sub
        If mDun.numCurrFloor = 91017 Then
            If Int(Rnd() * 100) = 0 Then
                Dim m = Monster.monsterFactory(11)
                npcList.Add(m)

                player.setTarget(m)
                m.currTarget = player
                toCombat()
                pushLstLog((m.getName() & " attacks!"))
                eClock = eClockResetVal
            End If
            Exit Sub
        End If
        Randomize()
        If eClock > 0 Then eClock -= 1
        If combatmode = True Or npcmode = True Or eClock <> 0 Or Not player.canMoveFlag Then Exit Sub
        Dim currTier As Integer() = monstierTier1
        Select Case mDun.numCurrFloor
            Case 1
                currTier = monstierTier1
            Case 2
                currTier = monstierTier2
            Case 3
                currTier = monstierTier3
            Case 4
                currTier = monstierTier4
            Case Else
                currTier = monstierTier4
        End Select

        Dim rand As Integer = CInt(Int(Rnd() * 1000))
        Dim r As Integer = Int(Rnd() * (UBound(currTier) + 1))
        Dim r2 As Integer = Int(Rnd() * (UBound(currTier) + 1))

        If rand < encounterRate Then
            Dim m As NPC
            If r2 = UBound(currTier) And r2 = r And Not currFloor.beatBoss And Not mDun.currFloorBoss.Equals("Key") Then
                m = New MiniBoss(mDun.numCurrFloor)
            Else
                m = Monster.monsterFactory(currTier(r))
            End If
            npcList.Add(m)

            player.setTarget(m)
            m.currTarget = player
            toCombat()
            pushLstLog((m.getName() & " attacks!"))
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
            txtPNLEvents.Text = ""
            drawBoard()
        End If

        player.canMoveFlag = True
        btnEQP.Enabled = True
    End Sub
    Function shouldReturnEarly(ByVal Keydata As Keys)
        'This function determines if the key input should be ignored.
        'If it returns true, HandleKeyPress returns false before anything is done
        If Keydata = Keys.Escape Then Return False
        If picStart.Visible = True Then Return True
        If combatmode And (Keydata.Equals(cKeys(0)) Or Keydata.Equals(cKeys(1)) Or Keydata.Equals(cKeys(2)) Or Keydata.Equals(cKeys(3)) Or Keydata.Equals(Keys.Left) Or Keydata.Equals(Keys.Right) Or Keydata.Equals(Keys.Down) Or Keydata.Equals(Keys.Up)) And Not selecting Then
            Return True
        End If
        If tmrKeyCD.Enabled Then Return True Else tmrKeyCD.Enabled = True
        If (lblEvent.Visible Or pnlEvent.Visible) And npcmode = True And Not Keydata.Equals(cKeys(13)) Then
            If Not lblEventOnClose Is Nothing Then
                doLblEventOnClose()
            Else
                closeLblEvent()
            End If
            Return True
        End If
        If (lblEvent.Visible Or pnlEvent.Visible) And npcmode = True And Keydata.Equals(cKeys(13)) Then
            Return False
        End If
        If pnlDescript.Visible And Not lblEvent.Visible Then
            pnlDescript.Location = New Point(1000, pnlDescript.Location.Y)
            pnlDescript.Visible = False
            Return True
        End If
        If (lblEvent.Visible Or pnlEvent.Visible) And Not (Keydata.Equals(Keys.Enter)) And Not Keydata.Equals(cKeys(0)) And Not Keydata.Equals(cKeys(1)) And Not Keydata.Equals(cKeys(2)) And Not Keydata.Equals(cKeys(3)) _
            And Not Keydata.Equals(Keys.Left) And Not Keydata.Equals(Keys.Right) And Not Keydata.Equals(Keys.Down) And Not Keydata.Equals(Keys.Up) Then
            If npcmode = False Then
                closeLblEvent()
                player.canMoveFlag = True
                If Not combatmode Then
                    player.canMoveFlag = True
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
        If keyspresed.Length > 4 Then
            keyspresed = keyspresed.Substring(1, 3)
        End If

        Dim m = CInt(7.8152 * Math.Exp(-0.011 * player.getWIL))
        If player.mana < player.getMaxMana And turn Mod m = 0 Then
            Dim mregen = Math.Max(Int(player.getMaxMana / 15), 1)
            player.mana += mregen
            If player.getMaxMana < player.mana Then player.mana = player.getMaxMana
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

    '|COMMANDS|
    Sub oemSemiColon()
        If combatmode Then Exit Sub
        'oemSemicolon triggers when a player hits the semicolon key, or any of its equivalents
        If player.pos.Equals(shopkeeper.pos) Then
            npcEncounter(shopkeeper)
        End If
        If player.pos.Equals(swiz.pos) Then
            npcEncounter(swiz)
        End If
        If player.pos.Equals(hteach.pos) Then
            npcEncounter(hteach)
        End If
        If player.pos.Equals(fvend.pos) Then
            npcEncounter(fvend)
        End If
        If btnEQP.Enabled = False Then btnEQP.Enabled = True
        If currfloor.chestList.Count > 0 Then
            For i = 0 To currfloor.chestList.Count - 1
                If player.pos = currfloor.chestList.Item(i).pos Then
                    currfloor.chestList.Item(i).open()
                    currfloor.chestList.RemoveAt(i)
                    Exit For
                End If
            Next
        End If
        If mDun.numCurrFloor < 5 Then
            If mDun.currFloorBoss.Equals("Key") And player.inv.getCountAt("Key") > 0 Then currFloor.beatBoss = True
            If player.pos = currFloor.stairs And currFloor.beatBoss Then
                If mDun.currFloorBoss.Equals("Key") Then player.inv.add("Key", -1)
                player.inv.invNeedsUDate = True
                player.UIupdate()
                mDun.floorDown()
                mDun.setFloor(currFloor)
                initializeBoard()
                If combatmode Then fromCombat()
                player.canMoveFlag = True
            ElseIf player.pos = currFloor.stairs Then
                If mDun.currFloorBoss.Equals("Key") Then pushLblEvent("The stairs are behind a locked gate!  Perhaps the key is in a chest..." & vbCrLf & "[while this game is in development it can also be bought from the shop for 2500]") Else pushLblEvent("You must defeat " & mDun.currFloorBoss & "!")
            End If
        ElseIf player.pos = currFloor.stairs Then
            If mDun.numCurrFloor = 9999 Then
                mDun.jumpTo(mDun.lastVisitedFloor)
                mDun.setFloor(currFloor)
                pushLblEvent("Spotting a gleaming terminal, you notice the rough layout of the dungeon floor you were previouly on.  Spotting a holographic button over this section of the map, and with a hesitant press you find yourself sucked through another tear in space-time.  Once again, you join the void.  When you pop back into the familiar surroundings of the dungeon, you notice that some things, namely traps and chests, seem to have never been touched.  Time stuff is weird...", AddressOf initializeBoard)
                Exit Sub
            ElseIf mDun.numCurrFloor = 91017 Then
                mDun.jumpTo(mDun.lastVisitedFloor)
                mDun.setFloor(currFloor)
            End If
            mDun.floorDown()
            mDun.setFloor(currFloor)
            initializeBoard()
            If combatmode Then fromCombat()
            player.canMoveFlag = True
        End If

        If currfloor.statueList.Count > 0 Then
            For i = 0 To currfloor.statueList.Count - 1
                If player.pos = currfloor.statueList.Item(i).pos Then
                    currfloor.statueList.Item(i).examine()
                    Exit For
                End If
            Next
        End If
    End Sub
    Sub oemReturn()
        'oemReturn triggers when the player hits the enter (return) key
        If cheatList.Contains(keyspresed) Then
            MsgBox(keyspresed)
            If keyspresed = "asss" Then
                player.MtF()
                player.createP()
            ElseIf keyspresed = "daaa" Then
                player.FtM()
                player.createP()
            ElseIf keyspresed = "wawa" Then
                player.be()
                player.createP()
            ElseIf keyspresed = "sasa" Then
                player.bs()
                player.createP()
            ElseIf keyspresed = "seee" Then
                For indY = -mBoardHeight To mBoardHeight
                    For indX = -mBoardWidth To mBoardWidth
                        If player.pos.Y + indY < mBoardHeight And player.pos.Y + indY >= 0 And player.pos.X + indX < mBoardWidth And player.pos.X + indX >= 0 Then
                            If currFloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "@" Then currFloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Text = ""
                            If currFloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "H" And currFloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Tag < 2 Then
                                currFloor.mBoard(player.pos.Y + indY, player.pos.X + indX).ForeColor = Color.Black
                                pushLstLog("Floor " & mDun.numCurrFloor & ": Staircase Discovered")
                            End If
                            If currFloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "#" And currFloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Tag < 2 Then
                                currFloor.mBoard(player.pos.Y + indY, player.pos.X + indX).ForeColor = Color.Black
                                pushLstLog("Chest discovered!")
                            End If
                            If currFloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "$" And currFloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Tag < 2 Then
                                currFloor.mBoard(player.pos.Y + indY, player.pos.X + indX).ForeColor = Color.Navy
                                pushLstLog("Shop discovered!")
                            End If
                            If currFloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Tag = 1 Then currFloor.mBoard(player.pos.Y + indY, player.pos.X + indX).Tag = 2
                        End If
                    Next
                Next
            ElseIf keyspresed = "gogo" Then
                Dim f As Integer = CInt(InputBox("Which floor?"))
                quickChangeFloor(f)
            ElseIf keyspresed = "aeio" Then
                player.inv.add(149, 1)
                player.UIupdate()
            ElseIf keyspresed = "wasd" Then
                player.inv.add(143, 1)
                player.UIupdate()
            End If
        End If
        keyspresed = ""
    End Sub
    Public Sub quickChangeFloor(ByVal f As Integer)
        Try
            mDun.jumpTo(f)
            mDun.setFloor(currFloor)
            pushLblEvent("You draw a circle on the floor, and think hard about floor " & f & ".  A portal opens to it, and you jump through, skipping every floor in between.", AddressOf initializeBoard)
        Catch e As Exception
            pushLblEvent("Your attempted teleportation fails in a less than spectacular fashion, the portal you created simply fizzling away to nothingness.")
        End Try
    End Sub
    'talk
    Sub talkKey()
        If Not npcmode Then
            If player.pos.Equals(shopkeeper.pos) Then
                npcEncounter(shopkeeper)
            End If
            If player.pos.Equals(swiz.pos) Then
                npcEncounter(swiz)
            End If
            If player.pos.Equals(hteach.pos) Then
                npcEncounter(hteach)
            End If
        Else
            doLblEventOnClose()
            closeLblEvent()
        End If
    End Sub
    Private Sub btnTalk_Click(sender As Object, e As EventArgs) Handles btnTalk.Click
        doLblEventOnClose()
        closeLblEvent()
    End Sub
    'attack
    Sub attackKey()
        If combatmode Then
            turn += 1
            doLblEventOnClose()
            closeLblEvent()
            Dim m As NPC = Nothing
            For i = 0 To npcList.Count() - 1
                If npcList.Item(i).GetType().IsSubclassOf(GetType(NPC)) Or npcList.Item(i).GetType() Is GetType(NPC) Then
                    m = npcList.Item(i)
                    Exit For
                End If
            Next
            player.nextCombatAction = Sub(t As Entity) player.attackCMD(t)
            queueSetup()
        Else
            pushLblEvent("You swing your " & player.equippedWeapon.getName & " at the air.")
        End If
    End Sub
    Private Sub btnATK_Click(sender As Object, e As EventArgs) Handles btnATK.Click
        turn += 1
        doLblEventOnClose()
        closeLblEvent()
        player.nextCombatAction = Sub(t As Entity) player.attackCMD(t)
        queueSetup()
        drawBoard()
    End Sub
    'magic
    Sub magicKey()
        player.magicRoute()
        toPNLSelec("Magic")
    End Sub
    Private Sub btnMG_Click(sender As Object, e As EventArgs) Handles btnMG.Click
        turn += 1
        doLblEventOnClose()
        lblCombatEvents.Text = ""
        closeLblEvent()
        If cboxMG.Text = "-- Select --" Then Exit Sub
        If player.mana <= 0 Then
            pushLblEvent("You don't have enough mana!")
            pushLstLog("You don't have enough mana!")
            Exit Sub
        End If
        player.nextCombatAction = Sub(t As Entity) Spell.spellCast(t, player, cboxMG.Text)
        queueSetup()
        Do While updateList.isEmpty() = False
            Dim u As Updatable = updateList.remove()
            u.update()
        Loop
        If npcmode Then picNPC.BackgroundImage = currNPC.picNCP(currNPC.npcIndex)
        'updates the combat banner
        updatePnlCombat(player, player.currTarget)
        ttCosts.RemoveAll()
    End Sub
    'specials
    Sub specialKey()
        player.specialRoute()
        toPNLSelec("Spec")
    End Sub
    Private Sub btnSpec_Click(sender As Object, e As EventArgs) Handles btnSpec.Click
        turn += 1
        doLblEventOnClose()
        lblCombatEvents.Text = ""
        closeLblEvent()
        If cboxSpec.Text = "-- Select --" Then Exit Sub
        Dim m As NPC = Nothing
        For i = 0 To npcList.Count() - 1
            If npcList.Item(i).GetType().IsSubclassOf(GetType(NPC)) Or npcList.Item(i).GetType() Is GetType(NPC) Then
                m = npcList.Item(i)
                Exit For
            End If
        Next
        Special.specPerform(m, player, cboxSpec.Text)

        If cboxSpec.Items.Count = 0 Then
            cboxSpec.Visible = False
            btnSpec.Visible = False
        End If
        cboxSpec.Text = "-- Select --"
        queueSetup()
        Do While updateList.isEmpty() = False
            Dim u As Updatable = updateList.remove()
            u.update()
        Loop
        'updates the combat banner
        updatePnlCombat(player, player.currTarget)
        ttCosts.RemoveAll()
    End Sub
    'drink
    Sub drinkKey()
        toPNLSelec("Potion")
    End Sub
    'wait
    Sub waitKey()
        turn += 1
        closeLblEvent()
        Dim m As NPC = Nothing
        For i = 0 To npcList.Count() - 1
            If npcList.Item(i).GetType().IsSubclassOf(GetType(NPC)) Or npcList.Item(i).GetType() Is GetType(NPC) Then
                m = npcList.Item(i)
                Exit For
            End If
        Next
        player.setTarget(m)
        queueSetup()
        pushLblEvent("You wait for a bit...")
    End Sub
    Private Sub btnWait_Click(sender As Object, e As EventArgs) Handles btnWait.Click
        turn += 1
        closeLblEvent()
        Dim m As NPC = Nothing
        For i = 0 To npcList.Count() - 1
            If npcList.Item(i).GetType().IsSubclassOf(GetType(NPC)) Or npcList.Item(i).GetType() Is GetType(NPC) Then
                m = npcList.Item(i)
                Exit For
            End If
        Next
        queueSetup()
        drawBoard()
        pushLblCombatEvent("You wait for a bit...")
    End Sub
    'run
    Sub runKey()
        turn += 1
        If combatmode Then
            run()
            'drawBoard()
        Else
            pushLblEvent("You have nothing to run from!")
        End If

    End Sub
    Sub run()
        'run handles the player choice to run from combat
        If player.health < 1 / player.getMaxHealth Then Exit Sub
        If player.perks("swordpossess") > -1 Then
            pushLstLog("Something inside you decides that running away is cowardly, so you don't.")
            pushLblCombatEvent("Something inside you decides that running away is cowardly, so you don't.")

            Exit Sub
        End If
        If player.name.Equals("Targax") And player.pClass.name.Equals("Soul-Lord") Then
            pushLstLog("You decide that running away is cowardly, so you don't.")
            pushLblCombatEvent("You decide that running away is cowardly, so you don't.")

            Exit Sub
        End If
        Dim run As Integer = Int(Rnd() * 3)
        For i = 0 To npcList.Count() - 1
            If Not (npcList.Item(i).GetType() Is GetType(Boss)) Then
                If npcList.Item(i).inv.getCountAt(53) > 0 Then
                    pushLblCombatEvent("The glimmer of a key can be seen with your opponent!")
                    Exit For
                End If
                If run <> 1 Then
                    npcList.Item(i).despawn("run")
                    updateList = New PQ
                Else
                    'updates the combat banner
                    updatePnlCombat(player, player.currTarget)
                    pushLblCombatEvent("You can't get away!")
                    queueSetup()
                    Do While updateList.isEmpty() = False
                        Dim u As Updatable = updateList.remove()
                        u.update()
                    Loop
                    Exit Sub
                End If

                Exit For
            End If
        Next
    End Sub
    Private Sub btnRUN_Click(sender As Object, e As EventArgs) Handles btnRUN.Click
        closeLblEvent()
        doLblEventOnClose()
        turn += 1
        run()
    End Sub
    'use
    Sub useKey()
        toPNLSelec("Useable")
    End Sub
    Private Sub btnUse_Click(sender As Object, e As EventArgs) Handles btnUse.Click
        closeLblEvent()
        doLblEventOnClose()
        If Not combatmode And Not npcmode Then player.canMoveFlag = True
        If player.prt.checkNDefMalInd(8, 6) Or player.prt.checkNDefFemInd(8, 12) Then
            pushLblEvent("You can't use items now!")
            Exit Sub
        End If
        If selectedItem Is Nothing Then Exit Sub
        Dim tmpInd As Integer = lstInventory.TopIndex
        Dim tind = lstInventory.SelectedIndex
        selectedItem.use()
        player.inv.invNeedsUDate = True
        player.UIupdate()
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
        If combatmode Then
            queueSetup()
            Do While updateList.isEmpty() = False
                Dim u As Updatable = updateList.remove()
                u.update()
            Loop
            'updates the combat banner
            updatePnlCombat(player, player.currTarget)
        End If

        lblPHealth.Text = CInt(player.health * player.getMaxHealth) & "/" & player.getMaxHealth
    End Sub
    'shop
    Sub toShopKey()
        doLblEventOnClose()
        closeLblEvent()

        If player.pos.Equals(shopkeeper.pos) Then
            currNPC = shopkeeper
        ElseIf player.pos.Equals(swiz.pos) Then
            currNPC = swiz
        ElseIf player.pos.Equals(hteach.pos) Then
            currNPC = hteach
        Else
            pushLblEvent("There's no shop here.")
            Exit Sub
        End If

        'Dim s As Shop = New Shop
        Dim s As ShopV2 = New ShopV2
        s.ShowDialog()
        s.Dispose()
    End Sub
    Private Sub btnShop_Click(sender As Object, e As EventArgs) Handles btnShop.Click
        doLblEventOnClose()
        closeLblEvent()
        'Dim s As Shop = New Shop
        shopMenu = New ShopV2
        shopMenu.ShowDialog()
        shopMenu.Dispose()
    End Sub
    'equip
    Sub eArmorKey()
        If checkIfCantEquip() Then Exit Sub
        toPNLSelec("Armor")
    End Sub
    Sub eWeaponKey()
        If checkIfCantEquip() Then Exit Sub
        toPNLSelec("Weapon")
    End Sub
    Private Sub btnEQP_Click(sender As Object, e As EventArgs) Handles btnEQP.Click
        If checkIfCantEquip() Then Exit Sub
        Dim f3 As Equipment = New Equipment()
        doLblEventOnClose()
        f3.ShowDialog()
        f3.Dispose()
    End Sub
    Function checkIfCantEquip() As Boolean
        If player.pForm.name.Equals("Blowup Doll") Then
            pushLblEvent("Any weapon you try to wield, and any armor or accessories you try to equip slide off.  It doesn't look like you'll be able to do this until you're not a blowup doll.")
            Return True
        ElseIf player.perks("astatue") > -1 Then
            pushLblEvent("You can't move.")
            Return True
        End If

        Dim b = False
        player.oneLayerImgCheck(b)
        If b Then
            pushLblEvent("You can't change equipment now!")
            Return True
        End If

        Return False
    End Function
    'self inspect
    Sub selfinpKey()
        If turn < 2 Then Exit Sub
        pushLstLog(player.description)
        toDesc()
    End Sub
    Sub toDesc()
        txtDescript.Text = player.genDescription
        picDescPort.BackgroundImage = Portrait.CreateFullBodyBMP(player.prt.iArr)
        pnlDescript.Location = New Point((13 * (Me.Size.Width / 688)), (3 * (Me.Size.Width / 688)))
        pnlDescript.Visible = True
    End Sub
    'eat
    Sub eatKey()
        toPNLSelec("Food")
    End Sub
    'yes/no
    Sub yesKey()

    End Sub
    Sub noKey()

    End Sub
    Private Sub ChallengeBoss()
        Dim m As NPC
        If mDun.numCurrFloor Mod 5 = 0 Then
            m = New Boss(mDun.numCurrFloor)
        Else
            m = New MiniBoss(mDun.numCurrFloor)
        End If

        Monster.targetRoute(m)
        Dim oSpeed = m.getSPD
        m.setSPD(1)
        pushLstLog((m.getName & " attacks!"))
        toCombat()

        queueSetup()
        m.setSPD(oSpeed)
        If mDun.numCurrFloor = 4 Then
            pushLblEvent("As you approach the staircase, you spot the Ooze Empress, hanging over the stairs.  As you wave to get her attention, she plops off the celing to come and greet you.  As you explain your situation to her, she chuckles, catching you off guard.  ""You know, I was placed on this floor as kind of a buffer.  Mistress Medusa isn't interested in weaklings, and if you even want to have a chance at beating her, you need to have a stronger will."".  You notice a shift in her previously bubbly personality, and when the rest of her tentacles drop down, you take a leap back and prepare for combat." & vbCrLf & vbCrLf &
                               """Let's see if you've learned anthing since the last time you tried this,"" she says with an somewhat mencing grin, ""... though I'm sure neither of us would mind a repeat either.""")
        End If
    End Sub
    'movement
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

    '|SAVE/LOAD|
    Sub save(ByVal a As String)
        'save handles the saving of the game
        Dim writer As IO.StreamWriter
        IO.File.Delete(a)
        writer = IO.File.CreateText(a)
        writer.WriteLine(version)
        'save the dungeon
        writer.WriteLine("-------------------------------DUNGEON---------------------------------")
        writer.WriteLine(mDun.save)

        'save the player
        writer.WriteLine("----------------------------------PLAYER------------------------------------")
        writer.WriteLine(player.ToString)
        'save the player's original body prior to the floor 4 body swap
        If mDun.numCurrFloor = 4 And Not preBSBody Is Nothing And Not preBSStartState Is Nothing Then
            writer.WriteLine(preBSBody.write)
            writer.WriteLine(preBSStartState.write)
            writer.WriteLine(preBSInventory.Count - 1)
            For i = 0 To preBSInventory.Count - 1
                writer.WriteLine(preBSInventory.Item(i))
            Next
        End If

        'save the shop NPCs
        writer.WriteLine("---------------------------------SHOP NPCs-----------------------------------")
        writer.WriteLine(shopNPCList.Count - 1)
        For i = 0 To shopNPCList.Count - 1
            writer.WriteLine(shopNPCList(i).saveNPC)
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
        pushLblEvent("Game successfully saved!")
        player.solFlag = False
        player.createP()
    End Sub
    Sub loadSave(ByVal a As String)
        'loadSave handles the loading of a game
        Debug_Window.clear()
        cboxMG.Items.Clear()
        cboxMG.Text = "-- Select --"
        cboxNPCMG.Items.Clear()
        cboxNPCMG.Text = "-- Select --"
        cboxSpec.Items.Clear()
        cboxSpec.Text = "-- Select --"
        lstLog.Items.Clear()
        npcList = New List(Of NPC)
        updateList = New PQ()
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
        cboxSpec.Visible = False
        pnlCombatClose()

        player.canMoveFlag = False
        If picStart.Visible = False Then picStart.Visible = True
        picStart.BringToFront()
        picLoadBar.BringToFront()

        System.Threading.Thread.Sleep(750)

        initLoadBar()

        Dim reader As IO.StreamReader
        reader = IO.File.OpenText(a)
        Dim v = CDbl(reader.ReadLine())
        If v < 0.9 Then
            MsgBox("Error 003: Incorrect save file version!")
            picStart.Visible = True
            btnS.Visible = True
            btnL.Visible = True
            btnAbout.Visible = True
            boardWorker.CancelAsync()
            Exit Sub
        End If
        updateLoadbar(10)

        'load the dungeon
        reader.ReadLine()
        mDun = New Dungeon(reader.ReadLine())
        currFloor = mDun.floors(mDun.numCurrFloor)
        newBoard()
        updateLoadbar(45)

        'load the player
        reader.ReadLine()
        player = New Player(reader.ReadLine(), v)
        'load the pre-floor 4 body if needed
        If mDun.numCurrFloor = 4 Then
            mDun.floorboss(4) = "Ooze Empress"
            preBSBody = New State()
            preBSStartState = New State()
            preBSBody.read(reader.ReadLine)
            preBSStartState.read(reader.ReadLine)
            preBSInventory = New ArrayList
            For i As Integer = 0 To reader.ReadLine()
                preBSInventory.Add(reader.ReadLine())
            Next
        End If
        updateLoadbar(60)

        'load the NPCs
        reader.ReadLine()
        shopNPCList.Clear()
        For i = 0 To CInt(reader.ReadLine())
            shopNPCList.Add(ShopNPC.shopFactory(i))
            shopNPCList(i).loadNPC(reader.ReadLine())
        Next
        shopkeeper = shopNPCList(0)
        swiz = shopNPCList(1)
        hteach = shopNPCList(2)
        fvend = shopNPCList(3)
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

        combatmode = False

        Equipment.init()
        reader.Close()
        player.setPImage()

        drawBoard()

        'update the display
        lblNameTitle.Text = player.name & " the " & player.pClass.name
        lblHealth.Text = "Health = " & CInt(player.health * player.getMaxHealth) & "/" & player.maxHealth
        lblMana.Text = "Mana = " & player.mana & "/" & player.maxMana
        lblHunger.Text = "Hunger = " & player.hunger & "/100"
        lblATK.Text = "ATK = " & player.getATK
        lblDEF.Text = "DEF = " & player.getDEF
        lblSKL.Text = "WIL = " & player.getWIL
        lblSPD.Text = "SPD = " & player.getSPD

        player.currState.save(player)
        If Not player.nextCombatAction Is Nothing Then player.nextCombatAction(Nothing)

        picStart.Visible = False
        picLoadBar.Visible = False

        If testingImageBoard Then
            CreateMapAndImages()
        End If
        If testingImageBoard Then
            LoadMapAndImages()
        End If

        pushLblEvent("Game successfully loaded!")
        player.createP()

        updateLoadbar(99)
        boardWorker.CancelAsync()
    End Sub
    'save/load drivers
    Private Sub btnSavePic_Click(sender As Object, e As MouseEventArgs) Handles btnS1.Click, btnS2.Click, btnS3.Click, btnS4.Click, btnS5.Click, btnS6.Click, btnS7.Click, btnS8.Click
        Dim name As String = CType(sender, Button).Name
        Dim fileNum As String = name(name.Length - 1)
        If e.Button = MouseButtons.Right Then
            MsgBox("Right Button Clicked")
        Else
            If solFlag Then
                Try
                    player.solFlag = True
                    loadSave("s" & fileNum & ".ave")
                    player.solFlag = False
                Catch ex As System.IO.FileNotFoundException
                    MsgBox("Error 004: No save detected!")
                Catch ex2 As Exception
                    If MessageBox.Show("Error 005: Error in loaded in save file!" & vbCrLf & "Restart?", "Error 005", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                        Application.Restart()
                    Else
                        Application.Exit()
                    End If
                End Try
            Else
                save("s" & fileNum & ".ave")
                imagesWorkerArg = Convert.ToInt32(fileNum)
                imagesWorker.RunWorkerAsync()
            End If
            pnlSaveLoad.Location = New Point(1000, pnlSaveLoad.Location.Y)
            pnlSaveLoad.Visible = False
            If picStart.Visible Then closesol()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        pnlSaveLoad.Location = New Point(1000, pnlSaveLoad.Location.Y)
        pnlSaveLoad.Visible = False
        If picStart.Visible = True Then
            btnS.Visible = True
            btnL.Visible = True
            btnControls.Visible = True
            btnSettings.Visible = True
            btnAbout.Visible = True
        End If
        player.canMoveFlag = True
        If player.isDead Then formReset()
    End Sub
    Sub toSOL()
        fromCombat()
        pnlSaveLoad.Location = New Point(188, pnlSaveLoad.Location.Y)
        pnlSaveLoad.Visible = True
        'CharacterGenerator.init()
        Dim loops = 0
        While Not savePicsReady
            If loops = 100 Then
                closesol()
                MsgBox("Error: Missing one or more save images")
                Exit While
                Exit Sub
            End If
            loops += 1
            Threading.Thread.Sleep(50)
        End While
        If System.IO.File.Exists("s.ave") Then convertSave("s.ave")

        If savePics(1) IsNot Nothing Then
            btnS1.BackgroundImage = savePics(1)
            If noImg Then btnS1.BackgroundImage = Nothing
        Else
            If solFlag Then btnS1.Enabled = False Else btnS1.Enabled = True
        End If

        If savePics(2) IsNot Nothing Then
            btnS2.BackgroundImage = savePics(2)
            If noImg Then btnS2.BackgroundImage = Nothing
        Else
            If solFlag Then btnS2.Enabled = False Else btnS2.Enabled = True
        End If

        If savePics(3) IsNot Nothing Then
            btnS3.BackgroundImage = savePics(3)
            If noImg Then btnS3.BackgroundImage = Nothing
        Else
            If solFlag Then btnS3.Enabled = False Else btnS3.Enabled = True
        End If

        If savePics(4) IsNot Nothing Then
            btnS4.BackgroundImage = savePics(4)
            If noImg Then btnS4.BackgroundImage = Nothing
        Else
            If solFlag Then btnS4.Enabled = False Else btnS4.Enabled = True
        End If

        If savePics(5) IsNot Nothing Then
            btnS5.BackgroundImage = savePics(5)
            If noImg Then btnS5.BackgroundImage = Nothing
        Else
            If solFlag Then btnS5.Enabled = False Else btnS5.Enabled = True
        End If

        If savePics(6) IsNot Nothing Then
            btnS6.BackgroundImage = savePics(6)
            If noImg Then btnS6.BackgroundImage = Nothing
        Else
            If solFlag Then btnS6.Enabled = False Else btnS6.Enabled = True
        End If

        If savePics(7) IsNot Nothing Then
            btnS7.BackgroundImage = savePics(7)
            If noImg Then btnS7.BackgroundImage = Nothing
        Else
            If solFlag Then btnS7.Enabled = False Else btnS7.Enabled = True
        End If

        If savePics(8) IsNot Nothing Then
            btnS8.BackgroundImage = savePics(8)
            If noImg Then btnS8.BackgroundImage = Nothing
        Else
            If solFlag Then btnS8.Enabled = False Else btnS8.Enabled = True
        End If

        Me.Update()
        player.canMoveFlag = False
    End Sub
    Sub closesol()
        Dim int As Integer = 100 - player.getSPD
        If int < 1 Then int = 1
        updateList.add(player, int)
        combatmode = False
        picStart.Visible = False
        If player.isDead Then formReset()
        player.canMoveFlag = True
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
            Dim ids(16) As Tuple(Of Integer, Boolean, Boolean)
            For i = 0 To 16
                Dim arr() As String = pState(32 + CInt(pState(31)) + i).Split("%")
                Dim id = New Tuple(Of Integer, Boolean, Boolean)(CInt(arr(0)), CBool(arr(1)), CBool(arr(2)))

                If id.Item2 Then
                    iarr(i) = Portrait.imgLib.fAttributes(i)(id.Item1)
                Else
                    iarr(i) = Portrait.imgLib.mAttributes(i)(id.Item1)
                End If
                ids(i) = id
                If i = 6 And (id.Item1 = 0 Or id.Item1 = 3) Then iarr(6) = CharacterGenerator.recolor2(iarr(6), skincolor)
            Next
            changeHairColor(haircolor, ids, iarr)
            changeSkinColor(skincolor, ids, iarr)

            img = Portrait.CreateBMP(iarr)
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
        reader.ReadLine()
        Dim player = New Player(reader.ReadLine, vers)
        reader.Close()
        Return New Tuple(Of Player, Double)(player, vers)
    End Function
    Shared Sub convertSave(ByVal a As String)
        Dim lines() As String = System.IO.File.ReadAllLines(a)
        Dim player As Player = New Player(lines(UBound(lines)), CDbl(lines(0)))
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

    '|COMBAT|
    Sub toCombat()
        'toCombat displays the players combat menus
        lblCombatEvents.Text = ""
        lblEHealthChange.Tag = 0
        lblPHealtDiff.Tag = 0
        updatePnlCombat(player, player.currTarget)
        pnlCombat.Location = New Point(115, pnlCombat.Location.Y)
        pnlCombat.Visible = True
        combatmode = True
        player.canMoveFlag = False
        btnATK.Visible = True
        btnMG.Visible = True
        btnWait.Visible = True
        btnRUN.Visible = True
        cboxMG.Visible = True
        cboxSpec.Visible = True
        btnSpec.Visible = True
        cboxSpec.Items.Clear()
        cboxSpec.Text = "-- Select --"
        player.specialRoute()
        player.magicRoute()
    End Sub
    Public Sub fromCombat()

        'fromCombat hides the players combat menus
        pnlCombatClose()
        btnATK.Visible = False
        btnMG.Visible = False
        btnRUN.Visible = False
        cboxMG.Visible = False
        picEnemy.Visible = False
        combatmode = False
        picNPC.Visible = False
        btnWait.Visible = False
        If player.perks("astatue") = -1 Then player.canMoveFlag = True
        player.clearTarget()
        cboxSpec.Visible = False
        btnSpec.Visible = False

        npcList.Clear()
        player.specialRoute()
        player.magicRoute()
        ttCosts.RemoveAll()
    End Sub
    Sub NPCtoCombat(ByRef m As NPC)
        'the NPC versions of from and to combat
        player.setTarget(m)
        picNPC.Location = New Point(10, picPortrait.Location.Y)
        lblEHealthChange.Tag = 0
        lblPHealtDiff.Tag = 0
        updatePnlCombat(player, player.currTarget)
        pnlCombat.Location = New Point(115, pnlCombat.Location.Y)
        pnlCombat.Visible = True
        combatmode = True
        npcmode = False
        pushLstLog((m.getName() & " attacks!"))
        btnATK.Visible = True
        btnMG.Visible = True
        btnRUN.Visible = True
        cboxMG.Visible = True
        btnWait.Visible = True
        cboxSpec.Visible = True
        btnSpec.Visible = True
        cboxSpec.Items.Clear()
        player.canMoveFlag = False

        hideNPCButtons()
    End Sub
    Sub NPCfromCombat(ByRef m As NPC)
        pnlCombatClose()
        Dim ratio As Double = Me.Size.Width / 1024
        picNPC.Location = New Point(82 * ratio, 179 * ratio)
        combatmode = False
        npcmode = True
        pushLblEvent((m.getName() & " stops fighting!"))
        pushLstLog((m.getName() & " stops fighting!"))
        btnATK.Visible = False
        btnMG.Visible = False
        btnRUN.Visible = False
        btnWait.Visible = False
        cboxMG.Visible = False
        cboxSpec.Visible = False
        btnSpec.Visible = False
        If player.perks("astatue") = -1 Then player.canMoveFlag = True

        showNPCButtons()
        player.specialRoute()
        player.magicRoute()
    End Sub
    Sub hideNPCButtons()
        'btnTalk.Visible = False
        btnNPCMG.Visible = False
        cboxNPCMG.Visible = False
        btnShop.Visible = False
        btnFight.Visible = False
        btnLeave.Visible = False
    End Sub
    Sub showNPCButtons()
        'btnTalk.Visible = True
        btnNPCMG.Visible = True
        cboxNPCMG.Visible = True
        btnShop.Visible = True
        btnFight.Visible = True
        btnLeave.Visible = True
    End Sub

    'combat pannel
    Sub pushLblCombatEvent(ByVal s As String)
        'cleanupPanels()
        Dim sSplit() As String = s.Split(" ")
        Dim c As Integer = 0
        Dim ct As Integer = 0
        Dim out As String = ""
        Do While c < sSplit.Length
            If ct < 45 Then
                If Not sSplit(c).Contains(vbCrLf) Then
                    out += sSplit(c) & " "
                    ct += sSplit(c).Length + 1
                    c += 1
                Else
                    out += sSplit(c) & " "
                    ct = 0
                    c += 1
                End If
            Else
                out += vbCrLf
                ct = 0
            End If
        Loop
        lblCombatEvents.Text += (out & vbCrLf &
                                 "-------------------------------------------------" & vbCrLf)
        player.specialRoute()
        player.magicRoute()
    End Sub
    Sub updatePnlCombat(ByVal p As Player, ByVal t As Entity)
        lblTurn.Text.Equals("Turn: " & turn)
        If lblTurn.Text.Equals("Turn: " & turn) Or t Is Nothing Then Exit Sub
        If t.health <= 0 Then
            t.die()
            Exit Sub
        End If
        lblPHealth.Text = CInt(p.health * p.getMaxHealth) & "/" & p.getMaxHealth
        lblEHealth.Text = CInt(t.getHealth * t.getMaxHealth) & "/" & t.getMaxHealth
        lblTurn.Text = "Turn: " & turn
        lblPName.Text = p.name
        lblEName.Text = t.getName
        If t.getName.Length > 20 Then
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

        Dim ratio As Double = Me.Size.Width / 1024

        Dim ratioEH As Double = (t.health) * ratio
        picEHbar.Size = New Size(ratioEH * 174, 15 * ratio)

        Dim x As Integer = (picEHbar.Location.X * ratio) + (ratioEH * 174) - (30 * ratio)
        If x < picEHbar.Location.X Then x = picEHbar.Location.X
        lblEHealthChange.Location = New Point(x, lblEHealthChange.Location.Y)


        If healthCol Is Nothing = False Then
            Dim place = Int(ratioEH * 100)
            If place >= 100 Then place = 99
            If place < 0 Then place = 0
            picEHbar.BackColor = healthCol.GetPixel(place, 0)
        Else
            If ratioEH <= 0.2 Then picEHbar.BackColor = Color.Crimson Else picEHbar.BackColor = Color.YellowGreen
        End If

        Dim ratioPH As Double = p.health * ratio
        picPHealth.Size = New Size(ratioPH * 174, 15 * ratio)
        x = picPHealth.Location.X + (ratioPH * 174) - (30 * ratio)
        If x > picPHealth.Location.X + (174 * ratio) - (30 * ratio) Then x = picPHealth.Location.X + (174 * ratio) - (30 * ratio)
        lblPHealtDiff.Location = New Point(x, lblPHealtDiff.Location.Y)
        If healthCol Is Nothing = False Then
            Dim place = Int(ratioPH * 100)
            If place >= 100 Then place = 99
            If place < 0 Then place = 0
            picPHealth.BackColor = healthCol.GetPixel(place, 0)
        Else
            If ratioPH <= 0.2 Then picPHealth.BackColor = Color.Crimson Else picPHealth.BackColor = Color.YellowGreen
        End If

        player.UIupdate()
    End Sub
    Sub pnlCombatClose()
        pnlCombat.Location = New Point(1000, pnlCombat.Location.Y)
        pnlCombat.Visible = False
        lblCombatEvents.Text = ""
    End Sub

    '|INVENTORY|
    Private Sub lstInventory_SelectedValueChanged(sender As Object, e As EventArgs) Handles lstInventory.SelectedValueChanged
        'lstInventory_SelectedValueChanged handles the selecting of items from the inventory listbox
        Try
            If lstInventory.SelectedItem.ToString.Substring(0, 1) = "-" Then Throw New NullReferenceException
            selectedItem = player.inv.item(player.inv.invIDorder(lstInventory.SelectedIndex))
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
        chkUseable.Visible = True
        chkPotion.Visible = True
        chkFood.Visible = True
        chkArmor.Visible = True
        chkWeapon.Visible = True
        chkMisc.Visible = True
        chkAcc.Visible = True
        lstInventory.Items.Clear()
        btnOk.Visible = True
        btnAll.Visible = True
        btnNone.Visible = True

        If chkUseable.Checked Then invFilters(0) = True Else invFilters(0) = False
        If chkPotion.Checked Then invFilters(1) = True Else invFilters(1) = False
        If chkFood.Checked Then invFilters(2) = True Else invFilters(2) = False
        If chkArmor.Checked Then invFilters(3) = True Else invFilters(3) = False
        If chkWeapon.Checked Then invFilters(4) = True Else invFilters(4) = False
        If chkMisc.Checked Then invFilters(5) = True Else invFilters(5) = False
        If chkAcc.Checked Then invFilters(6) = True Else invFilters(6) = False
    End Sub
    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        chkUseable.Visible = False
        chkPotion.Visible = False
        chkFood.Visible = False
        chkArmor.Visible = False
        chkWeapon.Visible = False
        chkMisc.Visible = False
        chkAcc.Visible = False
        btnOk.Visible = False
        btnAll.Visible = False
        btnNone.Visible = False
        player.inv.invNeedsUDate = True
        player.UIupdate()
    End Sub
    Private Sub fUseable_CheckedChanged(sender As Object, e As EventArgs) Handles chkUseable.CheckedChanged
        If chkUseable.Checked Then invFilters(0) = True Else invFilters(0) = False
    End Sub
    Private Sub fPotion_CheckedChanged(sender As Object, e As EventArgs) Handles chkPotion.CheckedChanged
        If chkPotion.Checked Then invFilters(1) = True Else invFilters(1) = False
    End Sub
    Private Sub fFood_CheckedChanged(sender As Object, e As EventArgs) Handles chkFood.CheckedChanged
        If chkFood.Checked Then invFilters(2) = True Else invFilters(2) = False
    End Sub
    Private Sub fArmor_CheckedChanged(sender As Object, e As EventArgs) Handles chkArmor.CheckedChanged
        If chkArmor.Checked Then invFilters(3) = True Else invFilters(3) = False
    End Sub
    Private Sub fWeapon_CheckedChanged(sender As Object, e As EventArgs) Handles chkWeapon.CheckedChanged
        If chkWeapon.Checked Then invFilters(4) = True Else invFilters(4) = False
    End Sub
    Private Sub fMisc_CheckedChanged(sender As Object, e As EventArgs) Handles chkMisc.CheckedChanged
        If chkMisc.Checked Then invFilters(5) = True Else invFilters(5) = False
    End Sub
    Private Sub chkAcc_CheckedChanged(sender As Object, e As EventArgs) Handles chkAcc.CheckedChanged
        If chkAcc.Checked Then invFilters(6) = True Else invFilters(6) = False
    End Sub
    Private Sub btnAll_Click(sender As Object, e As EventArgs) Handles btnAll.Click
        chkUseable.Checked = True
        chkPotion.Checked = True
        chkFood.Checked = True
        chkArmor.Checked = True
        chkWeapon.Checked = True
        chkMisc.Checked = True
        chkAcc.Checked = True
    End Sub
    Private Sub btnNone_Click(sender As Object, e As EventArgs) Handles btnNone.Click
        chkUseable.Checked = False
        chkPotion.Checked = False
        chkFood.Checked = False
        chkArmor.Checked = False
        chkWeapon.Checked = False
        chkMisc.Checked = False
        chkAcc.Checked = False
    End Sub

    '|NPC|
    Sub leaveNPC()
        Dim m As ShopNPC = Nothing
        For i = 0 To npcList.Count() - 1
            If npcList.Item(i).GetType().IsSubclassOf(GetType(ShopNPC)) Then
                m = npcList.Item(i)
                Exit For
            End If
        Next
        closeLblEvent()
        If Not m Is Nothing Then m.despawn("npc")
        npcList.Clear()
        player.clearTarget()
        btnEQP.Enabled = True
        npcmode = False
    End Sub
    Sub npcEncounter(ByRef m As ShopNPC)
        Dim validSpells() As String = {"Turn to Frog", "Polymorph Enemy", "Petrify"}
        player.magicRoute()
        For i = 0 To UBound(validSpells)
            If cboxMG.Items.Contains(validSpells(i)) Then cboxNPCMG.Items.Add(validSpells(i))
        Next

        If m.isDead Then Exit Sub
        npcList.Clear()
        npcList.Add(m)
        npcmode = True
        currNPC = m
        m.encounter()
        pushLstLog(("You walk up to " & m.getName & "!"))
        player.canMoveFlag = False
        picNPC.Visible = True
        'btnTalk.Visible = True
        btnNPCMG.Visible = True
        cboxNPCMG.Visible = True
        btnShop.Visible = True
        If m.isShop Then btnShop.Enabled = True Else btnShop.Enabled = False
        btnFight.Visible = True
        btnLeave.Visible = True

    End Sub
    Sub npcMG()
        closeLblEvent()
        If cboxNPCMG.Text = "-- Select --" Or player.mana <= 0 Then Exit Sub
        Dim m As ShopNPC = Nothing
        For i = 0 To npcList.Count() - 1
            If npcList.Item(i).GetType().IsSubclassOf(GetType(ShopNPC)) Then
                m = npcList.Item(i)
                Exit For
            End If
        Next

        Spell.spellCast(m, player, cboxNPCMG.Text)

        queueSetup()

        pushNPCDialog(m.hitBySpell)

        Dim int As Integer = 100 - player.getSPD
        If int < 1 Then int = 1
        picNPC.BackgroundImage = currNPC.picNCP(currNPC.npcIndex)
        updateList.add(player, int)
        drawBoard()
    End Sub
    Sub npcFight()
        Dim m As ShopNPC = Nothing
        For i = 0 To npcList.Count() - 1
            If npcList.Item(i).GetType().IsSubclassOf(GetType(ShopNPC)) Then
                m = npcList.Item(i)
                Exit For
            End If
        Next
        queueSetup()
        NPCtoCombat(m)

        closeLblEvent()

        pushNPCDialog(m.toFight())
    End Sub
    Private Sub btnNPCMG_Click(sender As Object, e As EventArgs) Handles btnNPCMG.Click
        doLblEventOnClose()
        pushPnlYesNo("Are you sure you want to do this?", AddressOf npcMG, AddressOf nofight)
    End Sub

    Private Sub btnFight_Click(sender As Object, e As EventArgs) Handles btnFight.Click
        doLblEventOnClose()
        pushPnlYesNo("Are you sure you want to do this?", AddressOf npcFight, AddressOf nofight)
    End Sub
    Sub nofight()
        player.canMoveFlag = False
    End Sub
    Private Sub btnLeave_Click(sender As Object, e As EventArgs) Handles btnLeave.Click
        leaveNPC()
        doLblEventOnClose()
    End Sub

    '|UI BUTTONS|
    Private Sub btnDrop_Click(sender As Object, e As EventArgs) Handles btnDrop.Click
        doLblEventOnClose()
        selectedItem.discard()
        player.inv.invNeedsUDate = True
        player.UIupdate()

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
        doLblEventOnClose()
        pushLstLog(player.description)
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
            CharacterGenerator.init()

            solFlag = True
            toSOL()
        Catch ex As System.IO.FileNotFoundException
            MsgBox("Error 004: No save detected!")
            btnS.Visible = True
            btnL.Visible = True
            btnControls.Visible = True
            btnSettings.Visible = True
            btnAbout.Visible = True
        Catch ex2 As Exception
            MsgBox("Error 005: Error in loaded in save file!")
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
        Dim s As Settings = New Settings
        s.ShowDialog()
        s.Dispose()
        If screenSize = "Small" Then
            Size = New Size(iWidth * 0.8, iHeight * 0.8)
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            Me.WindowState = FormWindowState.Normal
        ElseIf screenSize = "Medium" Then
            Size = New Size(iWidth * 0.9, iHeight * 0.9)
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            Me.WindowState = FormWindowState.Normal
        ElseIf screenSize = "XLarge" Then
            Size = New Size(iWidth * 1.3, iHeight * 1.3)
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            Me.WindowState = FormWindowState.Normal
        ElseIf screenSize = "Maximized" Then
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Me.WindowState = FormWindowState.Maximized
        Else
            Size = New Size(iWidth, iHeight)
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            Me.WindowState = FormWindowState.Normal
        End If
        Game_Resize()
    End Sub
    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        Dim ab1 As About = New About
        ab1.ShowDialog()
        ab1.Dispose()
    End Sub

    '|UI TOOLSTRIP|
    Private Sub NewGameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewGameToolStripMenuItem.Click
        'NewGameToolStripMenuItem_Click restarts the application
        Application.Restart()
    End Sub
    Private Sub LoadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadToolStripMenuItem.Click
        If (lblEvent.Visible Or pnlEvent.Visible) Or combatmode Or npcmode Or Me.MdiChildren.Length > 0 Then
            pushLblEvent("You can't load now!")
            Exit Sub
        End If
        solFlag = True
        toSOL()
    End Sub
    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        solFlag = False
        If (lblEvent.Visible Or pnlEvent.Visible) Or combatmode Or npcmode Or Me.MdiChildren.Length > 0 Then
            pushLblEvent("You can't save now!")
            Exit Sub
        End If
        toSOL()
    End Sub
    Private Sub InfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InfoToolStripMenuItem.Click
        Dim ab1 As About = New About
        ab1.ShowDialog()
        ab1.Dispose()
    End Sub
    Private Sub DebugToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DebugToolStripMenuItem.Click
        Try
            debugWindow.ToString() 'Try to do something to check if it exists
        Catch ex As NullReferenceException
            debugWindow = New Debug_Window
        End Try
        debugWindow.ShowDialog()
        player.inv.invNeedsUDate = True
        player.UIupdate()
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

    '|TIMERS|
    Private Sub tmrKeyCD_Tick(sender As Object, e As EventArgs) Handles tmrKeyCD.Tick
        tmrKeyCD.Enabled = False
    End Sub

    '|GENERAL USE/UTILITY
    Public Sub ShuffleArray(ByRef A() As String)
        'ShuffleArray takes an array, and randomizes its order
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
    'pushLblEvent family of functions
    Sub pushLblEvent(ByVal s As String, Optional effect As Action = Nothing)
        'pushLblEvent takes a string, formats it to wrap, and pushes a dialog box containing it
        If combatmode Then
            pushLblCombatEvent(s)
            Exit Sub
        End If
        If s.Length > 250 Then
            pushPnlEvent(s, effect)
            Exit Sub
        End If

        cleanupPanels()

        Dim sSplit() As String = s.Split(" ")
        Dim c As Integer = 0
        Dim ct As Integer = 0
        Dim out As String = ""
        Do While c < sSplit.Length
            If sSplit(c).Equals(vbCrLf) Then ct = 0
            If ct < 70 Then
                If Not sSplit(c).Contains(vbCrLf) Then
                    out += sSplit(c) & " "
                    ct += sSplit(c).Length + 1
                    c += 1
                Else
                    out += sSplit(c) & " "
                    ct = 0
                    c += 1
                End If
            Else
                out += vbCrLf
                ct = 0
            End If
        Loop
        If Not combatmode Then out += " " & vbCrLf & " " & vbCrLf & "Press any non-movement key to continue." Else out += " " & vbCrLf & " " & vbCrLf & "Click a combat button to continue."
        If 1 = 1 Then lblEvent.Text = out Else lblEvent.Text = vbCrLf & "---------------------------------------------------------------------------" & vbCrLf & out
        lblEvent.BringToFront()

        Dim x = (265 * (Me.Size.Width / 688)) - (lblEvent.Size.Width / 2)
        If x < 20 Then x = 20
        lblEvent.Location = New Point(x, (65 * (Me.Size.Width / 688)))
        lblEvent.Visible = True
        If Not effect Is Nothing Then lblEventOnClose = effect
        player.canMoveFlag = False
    End Sub
    Sub pushPnlEvent(s As String, Optional onClose As Action = Nothing)
        If combatmode Then
            pushLblCombatEvent(s)
            Exit Sub
        End If

        cleanupPanels()

        eventDialogBox.push(s, onClose)

        pnlEvent.BringToFront()
        pnlEvent.Location = New Point((15 * (Me.Size.Width / 688)), (33 * (Me.Size.Width / 688)))
        pnlEvent.Visible = True
        player.canMoveFlag = False
        If Not onClose Is Nothing Then lblEventOnClose = onClose
        btnEQP.Enabled = False
    End Sub
    Sub pushLblEvent(ByVal s As String, ByRef yes As Action, ByVal no As Action, ByVal text As String)
        'This pushLblEvent is identical to the second, but to be used in situations where a choice is made.
        If combatmode Then
            pushLblCombatEvent("Error, choice to be made during combat.")
            Exit Sub
        End If

        cleanupPanels()
        Dim sSplit() As String = s.Split(" ")
        Dim c As Integer = 0
        Dim ct As Integer = 0
        Dim out As String = ""
        Do While c < sSplit.Length
            If ct < 70 Then
                If Not sSplit(c).Contains(vbCrLf) Then
                    out += sSplit(c) & " "
                    ct += sSplit(c).Length + 1
                    c += 1
                Else
                    out += sSplit(c) & " "
                    ct = 0
                    c += 1
                End If
            Else
                out += vbCrLf
                ct = 0
            End If
        Loop

        out += " " & vbCrLf & " " & vbCrLf & "Press any non-movement key to continue."

        lblEvent.Text = out
        lblEvent.BringToFront()

        Dim x = (265 * (Me.Size.Width / 688)) - (lblEvent.Size.Width / 2)
        If x < 20 Then x = 20
        lblEvent.Location = New Point(x, (65 * (Me.Size.Width / 688)))

        lblEvent.Visible = True
        player.canMoveFlag = False
        lblEventOnClose = AddressOf makeChoice
        yesAction = yes
        noAction = no
        choiceText = text
        btnEQP.Enabled = False
    End Sub
    Sub pushNPCDialog(ByVal s As String, Optional ByRef effect As Action = Nothing)
        If combatmode Then
            pushLblCombatEvent("""" & s & """")
            Exit Sub
        End If

        cleanupPanels()

        lblEvent.ForeColor = Color.White
        'pushNPCDialog is a variant of pushLblEvent that pushes the string into an NPC dialog box
        Dim sSplit() As String = s.Split(" ")
        Dim c As Integer = 0
        Dim ct As Integer = 0
        Dim out As String = ""
        Do While c < sSplit.Length
            If ct < 50 Then
                If Not sSplit(c).Contains(vbCrLf) Then
                    out += sSplit(c) & " "
                    ct += sSplit(c).Length + 1
                    c += 1
                Else
                    out += sSplit(c) & " "
                    ct = 0
                    c += 1
                End If
            Else
                out += vbCrLf
                ct = 0
            End If
        Loop
        lblEvent.Text = out
        If Not effect Is Nothing Then lblEventOnClose = effect
        lblEvent.Location = New Point(150 * Me.Size.Width / 688, 120 * Me.Size.Width / 688)
        lblEvent.Visible = True
        picNPC.Visible = True
    End Sub
    Sub pushLstLog(ByVal s As String)
        lstLog.Items.Add(s)
        lstLog.TopIndex = lstLog.Items.Count - 1
    End Sub
    Sub pushPnlYesNo(ByVal s As String, ByRef yes As Action, ByRef no As action)
        yesAction = yes
        noAction = no
        choiceText = s
        makeChoice()
    End Sub
    'color shift functions
    Shared Function cShift(ByVal oC As Color, ByVal c As Color, ByVal inc As Integer)
        If oC.Equals(c) Then Return c
        Dim a, r, g, b As Integer
        a = oC.A
        r = oC.R
        g = oC.G
        b = oC.B

        If Math.Abs(a - c.A) < inc Or a > 255 Then
            a = c.A
        Else
            If a > c.A Then a -= inc Else a += inc
        End If
        If Math.Abs(r - c.R) < inc Or r > 255 Then
            r = c.R
        Else
            If r > c.R Then r -= inc Else r += inc
        End If
        If Math.Abs(g - c.G) < inc Or g > 255 Then
            g = c.G
        Else
            If g > c.G Then g -= inc Else g += inc
        End If
        If Math.Abs(b - c.B) < inc Or b > 255 Then
            b = c.B
        Else
            If b > c.B Then b -= inc Else b += inc
        End If

        Return Color.FromArgb(a, r, g, b)
    End Function
    Shared Sub changeHairColor(ByVal c As Color, ByVal iarrind() As Tuple(Of Integer, Boolean, Boolean), ByRef iarr As Image())
        iarr(1) = CharacterGenerator.recolor(Portrait.imgLib.atrs("RearHair2").getAt(iarrind(1)), c)
        iarr(5) = CharacterGenerator.recolor(Portrait.imgLib.atrs("RearHair1").getAt(iarrind(5)), c)
        iarr(10) = CharacterGenerator.recolor(Portrait.imgLib.atrs("Eyebrows").getAt(iarrind(10)), c)
        iarr(15) = CharacterGenerator.recolor(Portrait.imgLib.atrs("FrontHair").getAt(iarrind(15)), c)
    End Sub
    Shared Sub changeSkinColor(ByVal c As Color, ByVal iarrind() As Tuple(Of Integer, Boolean, Boolean), ByRef iarr As Image())
        iarr(2) = CharacterGenerator.recolor2(Portrait.imgLib.atrs("Body").getAt(iarrind(2)), c)
        iarr(4) = CharacterGenerator.recolor2(Portrait.imgLib.atrs("Face").getAt(iarrind(4)), c)
        iarr(6) = CharacterGenerator.recolor2(Portrait.imgLib.atrs("Ears").getAt(iarrind(6)), c)
        iarr(7) = CharacterGenerator.recolor2(Portrait.imgLib.atrs("Nose").getAt(iarrind(7)), c)
    End Sub
    'load bar functions
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
        If progress < 1 Or progress > 99 Then Exit Sub
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
        player.canMoveFlag = True
        player.createP()
    End Sub
    Public Sub ppw_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
        player.createP()
    End Sub
    'cost display for spells and abilities
    Private Sub cboxMG_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboxMG.SelectedIndexChanged
        If Not cboxMG.Text.Equals("-- Select --") And Not cboxMG.Text = "" Then ttCosts.SetToolTip(Me.cboxMG, Spell.spellCost(cboxMG.Text))
    End Sub
    Private Sub cboxNPCMG_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboxNPCMG.SelectedIndexChanged
        If Not cboxNPCMG.Text.Equals("-- Select --") And Not cboxNPCMG.Text = "" Then ttCosts.SetToolTip(Me.cboxNPCMG, Spell.spellCost(cboxNPCMG.Text))
    End Sub
    Private Sub cmboxSpec_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboxSpec.SelectedIndexChanged
        If Not cboxSpec.Text.Equals("-- Select --") And Not cboxSpec.Text = "" Then ttCosts.SetToolTip(Me.cboxSpec, Special.specCost(cboxSpec.Text))
    End Sub
    'other
    Private Sub prefetchImages()
        If imagesWorkerArg Is Nothing Then
            savePicsReady = False
            CharacterGenerator.init()

            Try
                savePics(0) = Nothing
            Catch ex As Exception
                savePics.Add(Nothing)
            End Try

            For i = 1 To 8
                If System.IO.File.Exists("s" & i.ToString() & ".ave") Then
                    Dim pic As Image
                    If System.IO.File.Exists("s" & i.ToString() & ".ave.png") Then
                        Using fs As New FileStream("s" & i.ToString() & ".ave.png", FileMode.Open, FileAccess.Read)
                            pic = Image.FromStream(fs)
                        End Using
                    Else
                        pic = getImgFromFile("s" & i.ToString() & ".ave")
                        'System.IO.File.Create("s" & i.ToString() & ".ave.png")
                        pic.Save("s" & i.ToString() & ".ave.png")
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
            If System.IO.File.Exists("s" & imagesWorkerArg.ToString() & ".ave") Then
                'Dim pic As Image = getImgFromFile("s" & imagesWorkerArg.ToString() & ".ave")
                Dim pic As Image = picPortrait.BackgroundImage.Clone()
                Try
                    savePics(imagesWorkerArg) = pic
                Catch ex As Exception
                    savePics.Add(pic)
                End Try
                pic.Save("s" & imagesWorkerArg.ToString() & ".ave.png")
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
    Sub formReset()
        Application.Exit()
        'fromCombat()
        'picStart.Visible = True
        'btnS.Visible = True
        'btnL.Visible = True
        'btnControls.Visible = True
        'player.canMoveFlag = False
    End Sub
    Private Sub Game_Resize()
        Dim RW As Double = (Me.Width - startingWidth) / startingWidth ' Ratio change of width
        Dim RH As Double = (Me.Height - startingHeight) / startingHeight ' Ratio change of height

        'scales the font size to that of the window
        Dim newFont As Font = New System.Drawing.Font("Consolas", CInt(8 * Me.Size.Width / 688))
        For i = 0 To Me.Controls.Count - 1
            Me.Controls(i).Width += CDbl(Me.Controls(i).Width * RW)
            Me.Controls(i).Height += CDbl(Me.Controls(i).Height * RH)
            Me.Controls(i).Left += CDbl(Me.Controls(i).Left * RW)
            Me.Controls(i).Top += CDbl(Me.Controls(i).Top * RH)
            Me.Controls(i).Font = newFont
        Next
        For i = 0 To pnlSelection.Controls.Count - 1
            pnlSelection.Controls(i).Width += CDbl(pnlSelection.Controls(i).Width * RW)
            pnlSelection.Controls(i).Height += CDbl(pnlSelection.Controls(i).Height * RH)
            pnlSelection.Controls(i).Left += CDbl(pnlSelection.Controls(i).Left * RW)
            pnlSelection.Controls(i).Top += CDbl(pnlSelection.Controls(i).Top * RH)
            pnlSelection.Controls(i).Font = newFont
        Next
        FileToolStripMenuItem.Font = newFont
        SaveToolStripMenuItem.Font = newFont
        LoadToolStripMenuItem.Font = newFont
        HelpToolStripMenuItem.Font = newFont
        HelpToolStripMenuItem1.Font = newFont
        InfoToolStripMenuItem.Font = newFont
        newFont = New System.Drawing.Font("Consolas", CInt(9.25 * Me.Size.Width / 688), FontStyle.Underline)
        lblNameTitle.Font = newFont
        newFont = New System.Drawing.Font("Consolas", CDbl(7 * Me.Size.Width / 688))
        btnDrop.Font = newFont
        btnControls.Font = newFont
        btnSettings.Font = newFont
        btnLook.Font = newFont
        newFont = New System.Drawing.Font("Consolas", CDbl(9 * Me.Size.Width / 688))
        MenuStrip1.Font = newFont
        For i = 0 To pnlCombat.Controls.Count - 1
            pnlCombat.Controls(i).Width += CDbl(pnlCombat.Controls(i).Width * RW)
            pnlCombat.Controls(i).Height += CDbl(pnlCombat.Controls(i).Height * RH)
            pnlCombat.Controls(i).Left += CDbl(pnlCombat.Controls(i).Left * RW)
            pnlCombat.Controls(i).Top += CDbl(pnlCombat.Controls(i).Top * RH)
            pnlCombat.Controls(i).Font = newFont
        Next
        For i = 0 To pnlDescript.Controls.Count - 1
            pnlDescript.Controls(i).Width += CDbl(pnlDescript.Controls(i).Width * RW)
            pnlDescript.Controls(i).Height += CDbl(pnlDescript.Controls(i).Height * RH)
            pnlDescript.Controls(i).Left += CDbl(pnlDescript.Controls(i).Left * RW)
            pnlDescript.Controls(i).Top += CDbl(pnlDescript.Controls(i).Top * RH)
            If Not pnlDescript.Controls(i).Name.Equals("Label5") Then pnlDescript.Controls(i).Font = newFont Else pnlDescript.Controls(i).Font = New System.Drawing.Font("Consolas", CDbl(7.8 * Me.Size.Width / 688))
        Next
        For i = 0 To pnlSaveLoad.Controls.Count - 1
            pnlSaveLoad.Controls(i).Width += CDbl(pnlSaveLoad.Controls(i).Width * RW)
            pnlSaveLoad.Controls(i).Height += CDbl(pnlSaveLoad.Controls(i).Height * RH)
            pnlSaveLoad.Controls(i).Left += CDbl(pnlSaveLoad.Controls(i).Left * RW)
            pnlSaveLoad.Controls(i).Top += CDbl(pnlSaveLoad.Controls(i).Top * RH)
        Next
        For i = 0 To pnlEvent.Controls.Count - 1
            pnlEvent.Controls(i).Width += CDbl(pnlEvent.Controls(i).Width * RW)
            pnlEvent.Controls(i).Height += CDbl(pnlEvent.Controls(i).Height * RH)
            pnlEvent.Controls(i).Left += CDbl(pnlEvent.Controls(i).Left * RW)
            pnlEvent.Controls(i).Top += CDbl(pnlEvent.Controls(i).Top * RH)
            pnlEvent.Controls(i).Font = newFont
        Next

        startingHeight = Height
        startingWidth = Width
        Dim ratio As Double = Me.Size.Width / 1024
        picLoadBar.Location = New Point(306 * ratio, 361 * ratio)
    End Sub
    Private Sub CreateMapAndImages()
        Dim XSize As Double = 15.0 * (CDbl(Me.Size.Width) / 688.0)
        Dim YSize As Double = 15.0 * (CDbl(Me.Size.Width) / 688.0)

        Dim imgSize As Integer = picTile.BackgroundImage.PhysicalDimension.Height
        boardPic = New Bitmap(mBoardWidth * imgSize, mBoardHeight * imgSize)
        seenBoardPic = New Bitmap(mBoardWidth * imgSize, mBoardHeight * imgSize)
        savedBoardPic = New Bitmap(mBoardWidth * imgSize, mBoardHeight * imgSize)
        boxBoard = New PictureBox()
        'boxBoard.Width = 23 * 25
        'boxBoard.Height = 15 * 25
        'boxBoard.Width = 500
        'boxBoard.Height = 500
        boxBoard.Size = New Point(YSize * 1.25 * 23, XSize * 1.25 * 15)
        boxBoard.Location = New Point(60, 75)
        'boxBoard.Location = New Point(50, 50)
        boxBoard.Visible = True
        boxBoard.SizeMode = PictureBoxSizeMode.Zoom
        AddHandler boxBoard.Paint, AddressOf boxBoard_Draw
        Me.Controls.Add(boxBoard)
        'Me.Controls.SetChildIndex(boxBoard, Me.Controls.GetChildIndex(mPics(0, 0)))
        'boxBoard.BringToFront()

        'savedBoardPic = boardPic.Clone()
        'Using g As Graphics = Graphics.FromImage(savedBoardPic)
        '    g.DrawImageUnscaled(seenBoardPic, 0, 0)
        'End Using
        'boxBoard.Image = savedBoardPic
        boxBoard.Image = savedBoardPic
    End Sub
    Private Sub LoadMapAndImages()
        Dim imgSize As Integer = picTile.BackgroundImage.PhysicalDimension.Height
        Using boardG As Graphics = Graphics.FromImage(boardPic), seenG As Graphics = Graphics.FromImage(seenBoardPic)
            For x = 0 To mBoardWidth - 1
                For y = 0 To mBoardHeight - 1
                    Dim tile As mTile = currFloor.mBoard(y, x)
                    Dim img As Image = Nothing

                    If tile.Text = "H" Then 'Stairs
                        img = picStairs.BackgroundImage
                    ElseIf tile.Text = "#" OrElse tile.ForeColor = Color.FromArgb(45, 45, 45) Then 'Chest
                        img = picChest.BackgroundImage
                    ElseIf tile.Text = "@" And player.pos.X = x And player.pos.Y = y Then 'Player
                        'img = picChest.BackgroundImage
                        img = picTile.BackgroundImage 'Don't draw the player on the permanently saved background
                    ElseIf tile.Text = "@" Then 'Statue
                        img = picStatue.BackgroundImage
                    ElseIf tile.Text = "$" Then 'NPC
                        img = picNPC.BackgroundImage
                    ElseIf tile.Text = "+" Then 'Trap
                        img = picTrap.BackgroundImage
                    ElseIf tile.Tag = 2 OrElse tile.Tag = 1 Then 'Seen or Unseen
                        img = picTile.BackgroundImage
                        'Else 'Nothing
                        '    img = picChest.BackgroundImage
                    End If

                    If img IsNot Nothing Then
                        boardG.DrawImage(img, x * imgSize, y * imgSize, imgSize, imgSize)
                        If tile.Tag = 1 Then
                            seenG.FillRectangle(New SolidBrush(Color.FromArgb(39, 39, 39)), x * imgSize, y * imgSize, imgSize, imgSize)
                        End If
                    Else
                        boardG.FillRectangle(Brushes.Black, x * imgSize, y * imgSize, imgSize, imgSize)
                    End If
                Next
            Next
        End Using
        'boardPic.Save("BOARD.png")
        'seenBoardPic.Save("BOARD_SEEN.png")
        Console.WriteLine("CREATED BOARD AND BOARD_SEEN")

        'savedBoardPic = boardPic.Clone()
        'Using g As Graphics = Graphics.FromImage(savedBoardPic)
        '    g.DrawImageUnscaled(seenBoardPic, 0, 0)
        'End Using
        'savedBoardPic.Save("BOARD_RENDERED.png")
        'boxBoard.Image = savedBoardPic
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub


    Public Sub cleanupPanels()
        pnlDescript.Visible = False
        If Not combatmode Then pnlCombat.Visible = False
        pnlEvent.Visible = False
        pnlSaveLoad.Visible = False
        pnlSelection.Visible = False
        selecting = False
        lblEvent.Visible = False

        player.canMoveFlag = True
        btnEQP.Enabled = True
    End Sub
    Private Sub btnClosePnlEvent_Click(sender As Object, e As EventArgs) Handles btnClosePnlEvent.Click
        doLblEventOnClose()
        closeLblEvent()
    End Sub

    Private Sub btnNextLPnlEvent_Click(sender As Object, e As EventArgs) Handles btnNextLPnlEvent.Click
        eventDialogBox.nextpageL()
    End Sub
    Private Sub btnNextRPnlEvent_Click(sender As Object, e As EventArgs) Handles btnNextRPnlEvent.Click
        eventDialogBox.nextpageR()
    End Sub
End Class