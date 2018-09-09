Imports System.ComponentModel
Imports System.IO
Imports System.Threading
'Imports DDTooltip

Public Class Game
    'Form1 is the main driver form that runs the game

    'board instance variables
    Public mBoardWidth As Integer = 60
    Public mBoardHeight As Integer = 60

    Public mBoard(,) As mTile
    Public mPics(,) As PictureBox       '(NOT SAVED)
    Public floor As Integer = 0
    Public floorCode As String
    Public stairs As Point

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

    Public baseChest As Chest = New Chest(player.inventory.Count - 1)
    Public chestList As ArrayList = New ArrayList()
    Public statueList As ArrayList = New ArrayList()    '(NOT SAVED)
    Public trapList As ArrayList = New ArrayList()
    'player instance variables
    Public updatelist As PQ = New PQ
    Public shopkeeper, swiz As NPC
    Public npcList As ArrayList = New ArrayList()     'list of non-player updatables (NOT SAVED)
    Public currNPC As NPC   'the current npc the player is talking to (NOT SAVED)
    Public pImage As Image  'which tile is used for the player (NOT SAVED)
    Public combatmode As Boolean = True 'indicates if the player is in combat (NOT SAVED)
    Public npcmode As Boolean = False   'indicates if the player is talking to an npc (NOT SAVED)
    Public npcIndex As Integer = 0  'indicates which npc is encountered (NOT SAVED)
    'a list containing all valid cheats
    Public cheatList() As String = {"girl", "nude", "blue", "catc", "bmbo", "bigr", "slut", "kill", "dick", "lust", "form", "tfme",
                                    "gogo", "mana", "fuse", "rock", "doll", "seee"} 'list of cheats (NOT SAVED)
    Dim keyspresed As String = ""   'records last 4 keys pressed (NOT SAVED)
    'variables related to the mystery potions
    Public Potions As New ArrayList()
    'Public OHPotionNames() As String = {"Red_Potion", "Green_Potion", "Blue_Potion", "Yellow_Potion", "Glowing_Potion", "Murky_Potion", "Purple_Potion"} '"Clear_Potion", "Smokey_Potion"}
    'Public HPotionNames() As String = OHPotionNames.Clone()
    'Dim APotionNames() As String = {"Blonde_Potion", "Red_Hair_Potion", "Black_Hair_Potion", "Feminine_Potion", "Breast_Enlarging_Potion", "Masculine_Potion", "Breast_Shrinking_Potion"} '"Weakness_Potion", "Shrink_Potion", "Snake_Potion"}
    'save lists of the players polymorph forms
    '      self      enemy
    Public formList, tFormList As New ArrayList()
    Public titleList = New List(Of String)
    'other misc form1 instance variables
    Dim selectedItem As Item    'the item hilighted in the inventory (NOT SAVED)
    Dim monsterTier1() As Integer = {0, 1, 2, 6}
    Dim monsterTier2() As Integer = {0, 1, 2, 4, 6}
    Dim monsterTier3() As Integer = {0, 1, 2, 4, 6, 7}
    Dim monsterTier4() As Integer = {0, 1, 2, 3, 4, 6, 7}
    Public turn As Integer = 0  '(NOT SAVED)
    Public beatboss() As Boolean = {False, False, False, False, False, False}  'which bosses have been beat?
    Public floorboss() As String = {"Floor0", "Marissa the Enchantress", "Targax the Brutal", "Key", "the Explorer", "Medusa"} 'boss names (NOT SAVED)
    Public floorLayouts As ArrayList = New ArrayList()
    Public version As Double = 0.6     'the save file version

    Public lblEventOnClose As Action    'the event method preformed when lblEvent closes (NOT SAVED)
    Public lastKey As String
    Public yesAction, noAction As Action
    Public invFilters() As Boolean = {True, True, True, True, True, True, True}
    'Dim eClock As Integer = 15
    Dim eClock As Integer = eClockResetVal * 3
    Public solFlag As Boolean = True
    Private trd As Thread
    Dim imagesWorker As BackgroundWorker
    Dim boardWorker As BackgroundWorker
    Public playerPortraitWorker As BackgroundWorker
    Private savePics As New List(Of Image)(9)
    Dim imagesWorkerArg = Nothing
    Dim savePicsReady As Boolean = False
    Dim boardReady As Boolean = False

    Dim healthCol As Bitmap = Nothing

    Dim selecting As Boolean = False
    Dim selectionType As String = ""

    Dim cKeys As List(Of System.Windows.Forms.Keys) = New List(Of Keys)

    Dim iHeight, iWidth As Integer
    Dim startingHeight As Integer = 0
    Dim startingWidth As Integer = 0

    'settings
    Public screenSize As String

    Dim debugWindow As Debug_Window

    'startup/new level methods
    'Form1_Load handles the loading of the form
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IO.File.Exists("sett.ing") Then createSettings()
        If Not IO.File.Exists("configs.ave") Then createConfigs()

        Dim r As System.IO.StreamReader
        r = IO.File.OpenText("sett.ing")
        screenSize = r.ReadLine
        r.Close()

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
        End If

        loadcKeys()
        imagesWorker = New BackgroundWorker
        AddHandler imagesWorker.DoWork, AddressOf prefetchImages
        imagesWorkerArg = Nothing
        imagesWorker.RunWorkerAsync()
        loadPotionList()
        titleList.Add("Warrior")
        titleList.Add("Mage")
        titleList.Add("Dragon")
        titleList.Add("Bimbo")
        titleList.Add("Paladin")
        titleList.Add("Succubus")
        titleList.Add("Slime")
        titleList.Add("Black Cat")
        titleList.Add("Chicken")
        titleList.Add("Goddess")
        titleList.Add("Magic Girl")
        titleList.Add("Targaxian")
        titleList.Add("Princess")
        titleList.Add("Blow-Up Doll")
        titleList.Add("Cow")
        titleList.Add("Kitty")
        titleList.Add("Soul-Lord")
        titleList.Add("Maid")

        If (File.Exists("img/LifeColors.png")) Then
            healthCol = Image.FromFile("img/LifeColors.png")
        End If

        'Fill Chest Tier List
        For i = 0 To player.inventory.Count - 1
            If player.inventory(i).tier <> Nothing Then
                baseChest.tiers(player.inventory(i).tier).Add(player.inventory(i))
            End If
        Next

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
        'creates the shopkeeper
        shopkeeper = New NPC(2)
        swiz = New NPC(3)
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
        w.Close()
    End Sub

    Sub loadPotionList()
        Randomize()
        Dim HiddenNames As ArrayList = New ArrayList({"Red_Potion", "Green_Potion", "Blue_Potion", "Yellow_Potion", "Glowing_Potion", "Murky_Potion", "Purple_Potion", "Clear_Potion", "Smokey_Potion", "Rose_Potion", "Aqua_Potion", "Glittery_Potion"})
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
    Sub loadcKeys()
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
    'newGame prepares the application at the start of a new game
    Sub newGame()
        floorLayouts.Add("placeholder")
        floorLayouts.Add(genRNDLVLCode())
        floorLayouts.Add(genRNDLVLCode())
        floorLayouts.Add(genRNDLVLCode())
        floorLayouts.Add(genRNDLVLCode())
        floorLayouts.Add("bossstage")

        combatmode = False
        btnS.Visible = False
        btnL.Visible = False
        btnControls.Visible = False
        btnSettings.Visible = False
        btnAbout.Visible = False
        Dim chargen As New CharacterGenerator
        chargen.currSex = player.sexBool
        chargen.ShowDialog()
        If chargen.quit Then
            btnS.Visible = True
            btnL.Visible = True
            btnControls.Visible = True
            btnSettings.Visible = True
            btnAbout.Visible = True
            Exit Sub
        End If
        picPortrait.BackgroundImage = chargen.ExportIMG()
        chargen.Dispose()
        Dim int As Integer = 100 - player.getSpeed
        If int < 1 Then int = 1
        updatelist.add(player, int)

        Dim genSet As New GeneratorSettings(floorLayouts(1))
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
        If mBoardWidth * mBoardHeight < 4 Then
            Do While mBoardWidth * mBoardHeight < 4
                If mBoardHeight < mBoardWidth Then
                    mBoardHeight += 1
                Else
                    mBoardWidth += 1
                End If
            Loop
        End If




        initializeBoard(False)
        drawBoard()
        player.currState = New State(player)
        player.sState = New State(player)
        player.pState = New State(player)

        eClock = eClockResetVal * 3

        turn = 0
        lstLog.Items.Add("You see before you a dungeon.")
        picStart.Visible = False
        Equipment.portraitUDate()
        player.UIupdate()
        lstLog.TopIndex = lstLog.Items.Count - 1
    End Sub
    'Private Sub workerPrepareBoard(sender As Object, e As DoWorkEventArgs)
    '    Dim arg = e.Argument
    '    initializeBoard(arg)
    'End Sub
    'initializeBoard increments the floor count, and generates the next level
    Private Sub initializeBoard(Optional Draw As Boolean = True)
        floor += 1
        player.canMoveFlag = False
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
        newBoard()
        If floor < 6 Then
            generateLevel(floorLayouts(floor))
        Else
            generateLevel(genRNDLVLCode())
        End If
        If Draw Then drawBoard()
    End Sub
    'newBoard disposes of the old board and its graphical representation
    Sub newBoard()
        If floor > 5 Then
            If player.pClass.name.Equals("Bimbo") Then
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
        Dim XSize As Double = 15.0 * (CDbl(Me.Size.Width) / 688.0)
        Dim YSize As Double = 15.0 * (CDbl(Me.Size.Width) / 688.0)
        'clear the old board
        If Not mBoard Is Nothing Then
            For i = 0 To mBoardHeight - 1
                For j = 0 To mBoardWidth - 1
                    mBoard(i, j).Dispose()
                    If j <= 23 And i <= 15 Then
                        If Not mPics(i, j) Is Nothing Then mPics(i, j).Dispose()
                    End If
                Next
            Next
        End If
        boardWorker.ReportProgress(40)
        'increase the board size slightly on floors after 3
        If floor > 2 And mBoardHeight < 40 Then
            mBoardHeight += 1
            mBoardWidth += 2
        End If
        'create all of  the board lables dynamacly at runtime
        ReDim mBoard(mBoardHeight - 1, mBoardWidth - 1)

        Dim viewWidth = 23
        Dim viewHeight = 15
        ReDim mPics(viewHeight, viewWidth)
        Dim numTiles = mBoardHeight * mBoardWidth
        For yInd = 0 To mBoardHeight - 1
            For xInd = 0 To mBoardWidth - 1
                mBoard(yInd, xInd) = New mTile(0, "", Color.Black)
                'If (xInd < viewWidth And yInd < viewHeight) Then
                '    Dim newPicture As PictureBox = New PictureBox()
                '    newPicture.Name = "boardBox|" & xInd & "_" & yInd
                '    newPicture.BackgroundImageLayout = ImageLayout.Stretch
                '    newPicture.Size = New Point(YSize * 1.25, XSize * 1.25)
                '    newPicture.Location = New Point(60 + xInd * (XSize * 1.25), 75 + yInd * (YSize * 1.25))
                '    newPicture.Visible = True
                '    Me.Controls.Add(newPicture)
                '    mPics(yInd, xInd) = newPicture
                'End If
                Dim progress As Double = (xInd + (yInd * mBoardWidth)) / numTiles
                boardWorker.ReportProgress(40 + (progress * 40))
                Application.DoEvents()
            Next xInd
        Next yInd
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
                Dim progress As Double = (viewPicsDone / (viewHeight * viewWidth))
                boardWorker.ReportProgress(80 + (progress * 20))
            Next
        Next
        boardWorker.ReportProgress(99)
        boardWorker.CancelAsync()
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
        floorCode = code
        Rnd(-1)
        If code.Equals("bossstage") Then
            genBossFloor()
            Exit Sub
        End If
        Randomize(code.GetHashCode)
        Dim numRooms As Integer = CInt(Int(Rnd() * 15) + 1) + Int(2.25 * mBoardWidth / 30)
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

            If Int(Rnd() * 3) = 0 Then
                For yP = pos.Y To yBound
                    For xP = pos.X To xBound
                        mBoard(yP, xP).Tag = 2
                    Next
                Next
            Else
                For yP = pos.Y To yBound
                    For xP = pos.X To xBound
                        mBoard(yP, xP).Tag = 1
                    Next
                Next
            End If

            Dim numExits As Integer = Int(Rnd() * 3)
            Dim mainExit As Point
            Select Case Int(Rnd() * 2)
                Case 0
                    mainExit = (New Point(pos.X + 2, Int(Rnd() * (yBound - pos.Y)) + pos.Y))
                    If mainExit.X - 1 < mBoardWidth And mainExit.X - 1 > 0 AndAlso Not mBoard(mainExit.Y, mainExit.X - 1).Tag = 2 Then mBoard(mainExit.Y, mainExit.X - 1).Tag = 1
                Case Else
                    mainExit = (New Point(Int(Rnd() * (xBound - pos.X)) + pos.X, pos.Y + 2))
                    If mainExit.Y - 1 < mBoardHeight And mainExit.Y - 1 > 0 AndAlso Not mBoard(mainExit.Y - 1, mainExit.X).Tag = 2 Then mBoard(mainExit.Y - 1, mainExit.X).Tag = 1
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
                        If exits.Last.X - 1 < mBoardWidth And exits.Last.X - 1 > 0 AndAlso Not mBoard(exits.Last.Y, exits.Last.X - 1).Tag = 2 Then mBoard(exits.Last.Y, exits.Last.X - 1).Tag = 1
                    Case 1
                        exits.Add(New Point(Int(Rnd() * (xBound - pos.X)) + pos.X, pos.Y + 2))
                        If exits.Last.Y - 1 < mBoardHeight And exits.Last.Y - 1 > 0 AndAlso Not mBoard(exits.Last.Y - 1, exits.Last.X).Tag = 2 Then mBoard(exits.Last.Y - 1, exits.Last.X).Tag = 1
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

        Dim playerX As Integer
        Dim playerY As Integer
        Do While (mBoard(playerY, playerX).Tag <> 1 And mBoard(playerY, playerX).Tag <> 2)
            playerX = CInt(Int(Rnd() * mBoardWidth))
            playerY = CInt(Int(Rnd() * mBoardHeight))
        Loop
        mBoard(playerY, playerX).Text = "@"
        player.pos = New Point(playerX, playerY)

        placeStairs()
        placeChest(code)
        If floor > 2 Then placeTraps()
        placeNPCs()

        'Dim l As List(Of Point()) = New List(Of Point())
        'For x = 0 To mBoardWidth
        '    For y = 0 To mBoardHeight
        '        l.Add(route(player.pos, New Point(x, y), "n/a", New List(Of Point), 0))
        '    Next
        'Next

        'Dim p = route(player.pos, stairs, "n/a", New List(Of Point))
        'For i = 0 To UBound(p)
        '    mBoard(p(i).Y, p(i).X).Tag = 2
        'Next
        'Dim sc = New SlaveCollar
        'sc.onEquip()

    End Sub
    Sub connectRooms(ByVal p1 As Point, ByVal p2 As Point)
        Dim cursor As Point = p1
        Dim xOry As Boolean = CBool(Int(Rnd() * 2))
        If xOry Then
            If p1.Y < p2.Y Then
                For y = p1.Y To p2.Y
                    If y < mBoardHeight And y > 0 And p1.X < mBoardWidth And p1.X > 0 AndAlso Not mBoard(y, p1.X).Tag = 2 Then mBoard(y, p1.X).Tag = 1
                Next
            Else
                For y = p1.Y To p2.Y Step -1
                    If y < mBoardHeight And y > 0 And p1.X < mBoardWidth And p1.X > 0 AndAlso Not mBoard(y, p1.X).Tag = 2 Then mBoard(y, p1.X).Tag = 1
                Next
            End If
            If p1.X < p2.X Then
                For x = p1.X To p2.X
                    If x < mBoardWidth And x > 0 And p2.Y < mBoardHeight And p2.Y > 0 AndAlso Not mBoard(p2.Y, x).Tag = 2 Then mBoard(p2.Y, x).Tag = 1
                Next
            Else
                For x = p1.X To p2.X Step -1
                    If x < mBoardWidth And x > 0 And p2.Y < mBoardHeight And p2.Y > 0 AndAlso Not mBoard(p2.Y, x).Tag = 2 Then mBoard(p2.Y, x).Tag = 1
                Next
            End If
        Else
            If p1.X < p2.X Then
                For x = p1.X To p2.X
                    If x < mBoardWidth And x > 0 And p2.Y < mBoardHeight And p2.Y > 0 AndAlso Not mBoard(p2.Y, x).Tag = 2 Then mBoard(p2.Y, x).Tag = 1
                Next
            Else
                For x = p1.X To p2.X Step -1
                    If x < mBoardWidth And x > 0 And p2.Y < mBoardHeight And p2.Y > 0 AndAlso Not mBoard(p2.Y, x).Tag = 2 Then mBoard(p2.Y, x).Tag = 1
                Next
            End If
            If p1.Y < p2.Y Then
                For y = p1.Y To p2.Y
                    If y < mBoardHeight And y > 0 And p1.X < mBoardWidth And p1.X > 0 AndAlso Not mBoard(y, p1.X).Tag = 2 Then mBoard(y, p1.X).Tag = 1
                Next
            Else
                For y = p1.Y To p2.Y Step -1
                    If y < mBoardHeight And y > 0 And p1.X < mBoardWidth And p1.X > 0 AndAlso Not mBoard(y, p1.X).Tag = 2 Then mBoard(y, p1.X).Tag = 1
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
    Sub genBossFloor()
        For y = 0 To 25
            For x = 3 To 7
                mBoard(y, x).Tag = 2
            Next
        Next
        player.pos = New Point(5, 25)
        stairs = New Point(5, 2)
        If floor = 5 Then genMedusaStatues()
    End Sub
    Sub genMedusaStatues()
        Randomize()
        Dim numStatues As Integer = Int((Rnd() * 5) + 6)
        For i = 0 To numStatues
            Dim x = Int((Rnd() * 4) + 3)
            Dim y = Int((Rnd() * 15) + 3)
            Dim tr As New Monster(-1)
            tr.pos = New Point(x, y)
            statueList.Add(New Statue(tr))
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
    Function chestSpotValid()
        Return True
    End Function
    Sub placeChest(ByVal code As String)
        Rnd(-1)
        Randomize(code.GetHashCode)
        'Dim numChests As Integer = CInt(Int(Rnd() * 8) + 3) * Int((mBoardWidth / 30) + (mBoardHeight / 30) / 2)
        Dim numChests As Integer = CInt(Int(Rnd() * chestFreqRange) + chestFreqMin) * (Int(chestSizeDependence / Math.Sqrt(mBoardWidth * mBoardHeight)) + 1)
        Dim r As Integer
        If floor = 3 Then
            numChests *= 1.5
            r = Int(Rnd() * (numChests))
        End If
        For i = 1 To numChests
            Dim chestX As Integer = CInt(Int(Rnd() * mBoardWidth))
            Dim chestY As Integer = CInt(Int(Rnd() * mBoardHeight))

            If floor > 0 Then
                Do While ((mBoard(chestY, chestX).Tag <> 1 And mBoard(chestY, chestX).Tag <> 2) Or mBoard(chestY, chestX).Text <> "")
                    chestX = CInt(Int(Rnd() * mBoardWidth))
                    chestY = CInt(Int(Rnd() * mBoardHeight))
                Loop
            Else
                Do While (mBoard(chestY, chestX).Tag <> 1 Or mBoard(chestY, chestX).Text <> "")
                    chestX = CInt(Int(Rnd() * mBoardWidth))
                    chestY = CInt(Int(Rnd() * mBoardHeight))
                Loop
            End If

            Dim chest As Chest = baseChest.Create(chestX, chestY, code)
            If r = i Then chest.add(53, 1)
            chestList.Add(chest)
            mBoard(chestY, chestX).ForeColor = Color.FromArgb(45, 45, 45)
            'mBoard(chestY, chestX).Text = "#"
        Next
    End Sub
    Sub placeTraps()
        trapList.Clear()
        Dim numtrap As Integer = CInt(Int(Rnd() * trapFreqRange) + trapFreqMin) * Int(mBoardWidth / trapSizeDependence)
        For i = 1 To numtrap
            Dim trapX As Integer = CInt(Int(Rnd() * mBoardWidth))
            Dim trapY As Integer = CInt(Int(Rnd() * mBoardHeight))
            Do While (mBoard(trapY, trapX).Tag <> 1 Or mBoard(trapY, trapX).Text <> "")
                trapX = CInt(Int(Rnd() * mBoardWidth))
                trapY = CInt(Int(Rnd() * mBoardHeight))
            Loop
            Dim trap As New Trap(New Point(trapX, trapY))
            trapList.Add(trap)
            mBoard(trapY, trapX).ForeColor = Color.FromArgb(45, 45, 45)
            mBoard(trapY, trapX).Text = "+"
        Next
    End Sub
    Sub placeNPCs()
        shopkeeper.pos = New Point(-1, -1)
        swiz.pos = New Point(-1, -1)
        Dim numNpc As Integer = CInt(Int(Rnd() * 2))
        If floor = 1 Then numNpc = 0
        For i = 0 To 0 'numNpc
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
                Case 1
                    swiz.pos = New Point(npcX, npcY)
            End Select
            mBoard(npcY, npcX).ForeColor = Color.FromArgb(45, 45, 45)
            mBoard(npcY, npcX).Text = "$"
        Next
    End Sub

    Function route(ByVal p1 As Point, ByVal p2 As Point) As Point()
        'iterative dijkstra's shortest path implementation
        Dim dist(mBoardWidth, mBoardHeight) As Integer
        Dim allPoints As List(Of Point) = New List(Of Point)
        Dim prev(mBoardWidth, mBoardHeight) As Point
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
                    If dist(allPoints(i).Y, allPoints(i).X) < dist(min.X, min.Y) Then min = allPoints(i)
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
    Function route(ByVal p1 As Point, ByVal p2 As Point, ByVal endp As Point) As Point()
        'iterative dijkstra's shortest path implementation
        Dim dist(mBoardWidth, mBoardHeight) As Integer
        Dim allPoints As List(Of Point) = New List(Of Point)
        Dim prev(mBoardWidth, mBoardHeight) As Point
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
                If dist(allPoints(i).Y, allPoints(i).X) < dist(min.X, min.Y) Then min = allPoints(i)
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
        path.Add(endp)
        Return path.ToArray
    End Function
    Function distance(ByVal x As Point, ByVal y As Point) As Double
        Return Math.Abs(Math.Sqrt(CDbl((y.X - x.X) ^ 2) + CDbl((y.Y - x.Y) ^ 2)))
    End Function

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
        If Not swiz.dead And swiz.pos.X > 0 And swiz.pos.Y > 0 Then
            mBoard(swiz.pos.Y, swiz.pos.X).Text = "$"
        End If
        If mBoard(player.pos.Y, player.pos.X).Text = "+" Then
            For i = 0 To trapList.Count - 1
                If trapList(i).pos = player.pos Then
                    Try
                        trapList(i).activate(i)
                    Catch ex As Exception
                        pushLblEvent("As you wander forward, your foot falls on a pressure plate.  As soon as you hear it click, you snap to attention.  Looking around, you see that nothing seems to have happened." & vbCrLf & "𝘚𝘰𝘮𝘦𝘵𝘩𝘪𝘯𝘨 𝘮𝘶𝘴𝘵 𝘩𝘢𝘷𝘦 𝘨𝘰𝘯𝘦 𝘸𝘳𝘰𝘯𝘨 𝘸𝘪𝘵𝘩 𝘵𝘩𝘦 𝘵𝘳𝘢𝘱'𝘴 𝘢𝘤𝘵𝘪𝘷𝘢𝘵𝘪𝘰𝘯...")
                    End Try
                    Exit For
                End If
            Next
        End If

        mBoard(player.pos.Y, player.pos.X).Text = "@"

        zoom()

        If floor < 5 AndAlso beatboss(floor) = False AndAlso Not floorboss(floor).Equals("Key") And combatmode = False AndAlso New Point(player.pos.Y, player.pos.X).Equals(New Point(stairs.Y, stairs.X)) Then btnChallengeBoss.Visible = True Else btnChallengeBoss.Visible = False
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
        '9 = locked stairs
        '10 = boss stairs
        '11 = shady wizard
        '12 = crystal

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
                        If mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "H" Then
                            If floor > 5 Or (floor < 5 AndAlso beatboss(floor)) Then
                                viewArray(y, x) = 3
                            ElseIf floor > 5 Or (floor < 5 AndAlso floorboss(floor).Equals("Key")) Then
                                viewArray(y, x) = 9
                            Else
                                viewArray(y, x) = 10
                            End If
                        End If
                        If mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "#" Then viewArray(y, x) = 5
                        If mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "$" And player.pos.Y + indY = shopkeeper.pos.Y And player.pos.X + indX = shopkeeper.pos.X Then viewArray(y, x) = 6
                        If mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "$" And player.pos.Y + indY = swiz.pos.Y And player.pos.X + indX = swiz.pos.X Then viewArray(y, x) = 11
                        If mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "+" Then viewArray(y, x) = 8
                        If mBoard(player.pos.Y + indY, player.pos.X + indX).Text = "c" Then viewArray(y, x) = 12
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
                    End Select
                Else
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
        If floor = 5 Then Exit Sub
        Randomize()
        If eClock > 0 Then eClock -= 1
        If combatmode = True Or npcmode = True Or eClock <> 0 Or Not player.canMoveFlag Then Exit Sub
        Dim currTier As Integer() = monsterTier1
        Select Case floor
            Case 1
                currTier = monsterTier1
            Case 2
                currTier = monsterTier2
            Case 3
                currTier = monsterTier3
            Case 4
                currTier = monsterTier4
            Case Else
                currTier = monsterTier4
        End Select

        Dim rand As Integer = CInt(Int(Rnd() * 1000))
        Dim r As Integer = Int(Rnd() * (UBound(currTier) + 1))
        Dim r2 As Integer = Int(Rnd() * (UBound(currTier) + 1))

        If rand < encounterRate Then
            Dim m As Monster
            If r2 = UBound(currTier) And r2 = r And ((floor < 5 AndAlso Not beatboss(floor)) Or floor >= 5) And Not floor = 3 Then
                m = New MiniBoss(floor)
            Else
                m = New Monster(currTier(r))
            End If
            npcList.Add(m)
            player.currTarget = m
            toCombat()
            lstLog.Items.Add((m.getName() & " attacks!"))
            eClock = eClockResetVal
        End If
        lstLog.TopIndex = lstLog.Items.Count - 1
    End Sub
    'handleKeyPress handles the players pressed keys, and is the driver function for each 
    Function shouldReturnEarly(ByVal Keydata As Keys)
        If picStart.Visible = True Then Return True
        If combatmode And (Keydata.Equals(cKeys(0)) Or Keydata.Equals(cKeys(1)) Or Keydata.Equals(cKeys(2)) Or Keydata.Equals(cKeys(3)) Or Keydata.Equals(Keys.Left) Or Keydata.Equals(Keys.Right) Or Keydata.Equals(Keys.Down) Or Keydata.Equals(Keys.Up)) And Not selecting Then
            Return True
        End If
        If tmrKeyCD.Enabled Then Return True Else tmrKeyCD.Enabled = True
        If lblEvent.Visible And npcmode = True And Not Keydata.Equals(cKeys(13)) Then
            oemSemiColon()
            Return True
        End If
        If lblEvent.Visible And npcmode = True And Keydata.Equals(cKeys(13)) Then
            Return False
        End If
        If pnlDescript.Visible And Not lblEvent.Visible Then
            pnlDescript.Location = New Point(1000, pnlDescript.Location.Y)
            pnlDescript.Visible = False
            Return True
        End If
        If lblEvent.Visible And Not (Keydata.Equals(Keys.Enter)) And Not Keydata.Equals(cKeys(0)) And Not Keydata.Equals(cKeys(1)) And Not Keydata.Equals(cKeys(2)) And Not Keydata.Equals(cKeys(3)) _
            And Not Keydata.Equals(Keys.Left) And Not Keydata.Equals(Keys.Right) And Not Keydata.Equals(Keys.Down) And Not Keydata.Equals(Keys.Up) Then
            If npcmode = False Then
                picNPC.Visible = False
                lblEvent.Visible = False
                lblEvent.ForeColor = Color.White
                player.canMoveFlag = True
                If Not combatmode Then player.canMoveFlag = True
                If Not lblEventOnClose Is Nothing Then
                    lblEvent.Visible = True
                    If Not combatmode Then player.canMoveFlag = False
                    lblEventOnClose()
                    lblEventOnClose = Nothing
                End If
                drawBoard()
                If btnEQP.Enabled = False Then btnEQP.Enabled = True
            End If
            Return True
        End If
        If lblEvent.Visible And (Keydata.Equals(cKeys(0)) Or Keydata.Equals(cKeys(1)) Or Keydata.Equals(cKeys(2)) Or Keydata.Equals(cKeys(3)) _
            Or Keydata.Equals(Keys.Left) Or Keydata.Equals(Keys.Right) Or Keydata.Equals(Keys.Down) Or Keydata.Equals(Keys.Up)) Then
            Return True
        End If
        If keyspresed.Length > 4 Then
            keyspresed = keyspresed.Substring(1, 3)
        End If
        'If combatmode = True And Not (Keydata.Equals(Keys.Enter) Or Keydata.Equals(Keys.K) Or Keydata.Equals(Keys.I) Or Keydata.Equals(Keys.L)) Then Return True
        'If npcmode = True Then Return True
        If player.mana < player.getmaxMana And turn Mod 3 = 0 Then player.mana += 1
        If npcList.Count > 0 Then
            For i = 0 To npcList.Count - 1
                Dim int1 As Integer = 100 - npcList.Item(i).speed
                If int1 < 1 Then int1 = 1
                updatelist.add(npcList.Item(i), (int1))
            Next
        End If
        Return False
    End Function
    Function isALetter(ByVal s As String)
        Dim letters = "qwertyuiopasdfghjklzxcvbnm".ToList
        If s.Length > 1 Then Return False
        If letters.Contains(s) Then Return True
        Return False
    End Function
    Function HandleKeyPress(ByVal Keydata As Keys) As Boolean
        lastKey = Keydata.ToString.ToLower
        If Not selecting Then
            If shouldReturnEarly(Keydata) Then Return True
            Dim spos As Point = player.pos
            If isALetter(Keydata.ToString.ToLower) Then keyspresed += Keydata.ToString.ToLower
            Select Case Keydata
                Case cKeys(0)
                    player.moveUp()
                    randomEvents()
                Case cKeys(1)
                    player.moveDown()
                    randomEvents()
                Case cKeys(2)
                    player.moveLeft()
                    randomEvents()
                Case cKeys(3)
                    player.moveRight()
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
            End Select
            Dim int As Integer = 100 - player.getSpeed
            If int < 1 Then int = 1
            updatelist.add(player, (int))
            turn += 1
            If Not Keydata.Equals(cKeys(10)) Then drawBoard()
            lstLog.TopIndex = lstLog.Items.Count - 1
            Return True
        Else
            If Keydata.Equals(Keys.Up) Then
                lstSelec.TopIndex -= 1
                Return True
            End If
            If Keydata.Equals(Keys.Down) Then
                lstSelec.TopIndex += 1
                Return True
            End If
            If Keydata.Equals(Keys.Back) Then
                selecting = False
                pnlSelection.Location = New Point(1000, pnlSelection.Location.Y)
                pnlSelection.Visible = False
                Return True
            End If
            selection(Keydata)
        End If
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
        If player.pos.Equals(swiz.pos) Then
            npcEncounter(swiz)
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
        If floor < 5 Then
            If floorboss(floor).Equals("Key") And player.inventory(53).count > 0 Then beatboss(floor) = True
            If player.pos = stairs And beatboss(floor) Then
                If floor < 5 Then
                    If floorboss(floor).Equals("Key") Then player.inventory(53).add(-1)
                    player.invNeedsUDate = True
                    player.UIupdate()
                    initializeBoard()
                    If combatmode Then fromCombat()
                Else
                    MsgBox("END OF CONTENT")
                End If
            ElseIf player.pos = stairs Then
                If floorboss(floor).Equals("Key") Then pushLblEvent("The stairs are behind a locked gate!  Perhaps the key is in a chest..." & vbCrLf & "[while this game is in development it can also be bought from the shop for 2500]") Else pushLblEvent("You must defeat " & floorboss(floor) & "!")
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
    Sub oemReturn()
        If cheatList.Contains(keyspresed) Then
            MsgBox(keyspresed)
            If keyspresed = "girl" Then
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
                player.perks("bimbotf") = True
            ElseIf keyspresed = "catc" Then
                player.perks("nekocurse") = True
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
            ElseIf keyspresed = "seee" Then
                For indY = -mBoardHeight To mBoardHeight
                    For indX = -mBoardWidth To mBoardWidth
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
                player.perks("slutcurse") = True
                player.inventory(1).add(1)
                player.lust += 20
                player.createP()
            ElseIf keyspresed = "kill" Then
                player.currTarget.takeDMG("9999")
            End If
        End If
        keyspresed = ""
    End Sub
    Sub talkKey()
        If Not npcmode Then
            If player.pos.Equals(shopkeeper.pos) Then
                npcEncounter(shopkeeper)
            End If
            If player.pos.Equals(swiz.pos) Then
                npcEncounter(swiz)
            End If
        Else
            If Not lblEventOnClose Is Nothing Then
                lblEventOnClose()
                lblEventOnClose = Nothing
            End If
            If lblEvent.Visible = True Then
                lblEvent.Visible = False
                lblEvent.ForeColor = Color.White
                drawBoard()
            End If
        End If
    End Sub
    Sub attackKey()
        If combatmode Then
            turn += 1
            If Not lblEventOnClose Is Nothing Then
                lblEventOnClose()
                lblEventOnClose = Nothing
            End If
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
        Else
            pushLblEvent("You swing your " & player.equippedWeapon.getName & " at the air.")
        End If
    End Sub
    Sub magicKey()
        toPNLSelec("Magic")
    End Sub
    Sub specialKey()
        toPNLSelec("Spec")
    End Sub
    Sub drinkKey()
        toPNLSelec("Potion")
    End Sub
    Sub waitKey()
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
        updatelist.add(player, int)
        pushLblEvent("You wait for a bit...")
    End Sub
    Sub runKey()
        turn += 1
        If combatmode Then
            run()
            'drawBoard()
        Else
            pushLblEvent("You have nothing to run from!")
        End If

    End Sub
    Sub useKey()
        toPNLSelec("Useable")
    End Sub
    Sub toShopKey()
        If Not lblEventOnClose Is Nothing Then
            lblEventOnClose()
            lblEventOnClose = Nothing
        End If
        If lblEvent.Visible = True Then
            lblEvent.Visible = False
            lblEvent.ForeColor = Color.White
            drawBoard()
        End If

        If player.pos.Equals(shopkeeper.pos) Then
            currNPC = shopkeeper
        ElseIf player.pos.Equals(swiz.pos) Then
            currNPC = swiz
        Else
            pushLblEvent("There's no shop here.")
            Exit Sub
        End If

        'Dim s As Shop = New Shop
        Dim s As ShopV2 = New ShopV2
        s.ShowDialog()
        s.Dispose()
    End Sub
    Sub eArmorKey()
        toPNLSelec("Armor")
    End Sub
    Sub eWeaponKey()
        toPNLSelec("Weapon")
    End Sub
    Sub selfinpKey()
        If turn < 2 Then Exit Sub
        lstLog.Items.Add(player.description)
        toDesc()
    End Sub
    Sub eatKey()
        toPNLSelec("Food")
    End Sub
    Sub yesKey()
        If btnChallengeBoss.Visible Then
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
        End If
    End Sub
    Sub noKey()

    End Sub

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
            player.invNeedsUDate = True
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
            selectedItem = player.inventory.Item(aInd)
            If selectedItem.getUsable Then selectedItem.use()
        End If
    End Sub
    Sub selectMagic(ByVal index As Integer)
        turn += 1
        If Not lblEventOnClose Is Nothing Then
            lblEventOnClose()
            lblEventOnClose = Nothing
        End If
        lblCombatEvents.Text = ""
        If lblEvent.Visible = True Then
            lblEvent.Visible = False
            lblEvent.ForeColor = Color.White
        End If
        If player.mana <= 0 Then Exit Sub
        Dim m As Monster = Nothing
        For i = 0 To npcList.Count() - 1
            If npcList.Item(i).GetType().IsSubclassOf(GetType(Monster)) Or npcList.Item(i).GetType() Is GetType(Monster) Then
                m = npcList.Item(i)
                Exit For
            End If
        Next
        Spell.spellCast(m, player, cboxMG.Items(index))
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
        ttCosts.RemoveAll()
    End Sub
    Sub selectSpec(ByVal index As Integer)
        turn += 1
        If Not lblEventOnClose Is Nothing Then
            lblEventOnClose()
            lblEventOnClose = Nothing
        End If
        lblCombatEvents.Text = ""
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
        Specials.goSpecial(m, player, cmboxSpec.Items(index))
        If Specials.SPCCost(cmboxSpec.Text).Equals("Useable only once per combat.") Then cmboxSpec.Items.Remove(cmboxSpec.Text)
        If cmboxSpec.Items.Count = 0 Then
            cmboxSpec.Visible = False
            btnSpec.Visible = False
        End If
        cmboxSpec.Text = "-- Select --"
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

        If player.mana > player.getmaxMana Then player.mana = player.getmaxMana

        'if the player has the slutty dress curse, this takes care of it
        If player.perks("slutcurse") > -1 Then
            Equipment.clothingCurse1()
        End If

        'handles any tfs or triggers triggered by equipping of certain weapons
        If player.pClass.name.Equals("Magic Girl") And player.equippedArmor.getName.Equals("Magic_Girl_Outfit") Then
            player.equippedArmor = player.inventory.Item(10)
            lstLog.Items.Add("A magic girl needs her uniform!")
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
        Equipment.portraitUDate()
        player.UIupdate()
        lstLog.TopIndex = lstLog.Items.Count - 1
    End Sub
    Sub selectWeapon(ByVal index As Integer)
        Dim subString As String = lstSelec.Items(index).ToString.Split(" (")(2)

        If Not player.equippedWeapon.getName.Equals(subString) Then
            player.equippedWeapon.onUnequip()
        End If

        'this handles the revert from the magical girl form, if needed
        If player.equippedWeapon.getName.Equals("Magic_Girl_Wand") And player.pClass.name.Equals("Magic Girl") And Not subString.Equals("Magic_Girl_Wand") Then
            lstLog.Items.Add("Putting away your wand causes you to change into your regular self!")
            player.inventory.Item(10).add(-1)
            player.magGState.save(player)
            player.revert2()
        End If

        Dim owName = player.equippedWeapon.getName

        'handles the equiping of weapons
        Dim sWeapon As Weapon = Nothing
        If subString <> "" Then
            For i = 0 To UBound(Equipment.wNameList)
                If subString.ToString().Split()(0) = Equipment.wNameList(i) Then
                    sWeapon = Equipment.wList(i)
                    Exit For
                End If
            Next
            If sWeapon Is Nothing Then Exit Sub
            player.equippedWeapon = sWeapon
        End If
        If player.equippedWeapon.mBoost > 0 Then player.mana += player.equippedWeapon.mBoost
        If player.mana > player.getmaxMana Then player.mana = player.getmaxMana

        'handles any tfs or triggers triggered by equipping of certain weapons
        If Not player.equippedWeapon.getName.Equals(owName) Then
            player.equippedWeapon.onEquip()
        End If

        'updates the player, the stat display, and the portrait before the form closes
        Equipment.portraitUDate()
        player.UIupdate()
        lstLog.TopIndex = lstLog.Items.Count - 1
    End Sub
    Sub selectYesNo(ByVal index As Integer)
        If index = 0 Then
            yesAction()
        Else
            noAction()
        End If
        yesAction = Nothing
        noAction = Nothing
        lblEvent.Visible = False
        lblEventOnClose = Nothing
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
                For i = 0 To UBound(player.potions)
                    If player.potions(i).count > 0 Then
                        lstSelec.Items.Add(indexes(count) & " - " & player.potions(i).getName)
                        count += 1
                    End If
                Next
            Case "Useable"
                lblWhat.Text = "Use what?"
                For i = 0 To UBound(player.useable)
                    If player.useable(i).count > 0 Then
                        lstSelec.Items.Add(indexes(count) & " - " & player.useable(i).getName)
                        count += 1
                    End If
                Next
            Case "Food"
                lblWhat.Text = "Eat what?"
                For i = 0 To UBound(player.food)
                    If player.food(i).count > 0 Then
                        lstSelec.Items.Add(indexes(count) & " - " & player.food(i).getName)
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
                    For i = 0 To cboxMG.Items.Count - 1
                        lstSelec.Items.Add(indexes(count) & " - " & cboxMG.Items(i).ToString)
                        count += 1
                    Next
                End If
            Case "Spec"
                If Not combatmode And Not npcmode Then
                    pushLblEvent("You don't have a target at the moment...")
                    selecting = False
                    Exit Sub
                End If
                lblWhat.Text = "Perform what?"
                If combatmode Then
                    For i = 0 To cmboxSpec.Items.Count - 1
                        lstSelec.Items.Add(indexes(count) & " - " & cmboxSpec.Items(i).ToString)
                        count += 1
                    Next
                End If
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
                For i = 0 To UBound(player.getArmors.Item2)
                    If player.getArmors.Item2(i).count > 0 Then
                        lstSelec.Items.Add(indexes(count) & " - " & player.getArmors.Item2(i).getName)
                        count += 1
                    End If
                Next
            Case "Weapon"
                lblWhat.Text = "Equip what?"
                lstSelec.Items.Add("a - Fists")
                count += 1
                For i = 0 To UBound(player.getWeapons.Item2)
                    If player.getWeapons.Item2(i).count > 0 Then
                        lstSelec.Items.Add(indexes(count) & " - " & player.getWeapons.Item2(i).getName)
                        count += 1
                    End If
                Next
            Case "yesNo"
                lblWhat.Text = "Do you accept?"
                lstSelec.Items.Add("a - Yes") 'cKeys(19).ToString.ToLower & " - Yes")
                lstSelec.Items.Add("b - No") 'cKeys(20).ToString.ToLower & " - No")
        End Select
        selectionType = mode
        pnlSelection.Location = New Point(115, pnlSelection.Location.Y)
        pnlSelection.Visible = True
    End Sub


    'save/loadSave methods
    'save handles the saving of the game
    Sub save(ByVal a As String)
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
        writer.WriteLine(chestFreqMin)
        writer.WriteLine(chestFreqRange)
        writer.WriteLine(chestSizeDependence)
        writer.WriteLine(chestRichnessBase)
        writer.WriteLine(chestRichnessRange)
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
        writer.WriteLine(UBound(beatboss))
        For i = 0 To UBound(beatboss)
            writer.WriteLine(beatboss(i))
        Next
        writer.WriteLine(turn)
        writer.WriteLine(floor)
        writer.WriteLine(floorCode)
        writer.WriteLine(encounterRate)
        writer.WriteLine(eClockResetVal)
        writer.WriteLine(shopkeeper.pos.X)
        writer.WriteLine(shopkeeper.pos.Y)

        writer.WriteLine(floorLayouts.Count - 1)
        For i = 0 To floorLayouts.Count - 1
            writer.WriteLine(floorLayouts(i))
        Next
        writer.WriteLine(swiz.pos.X)
        writer.WriteLine(swiz.pos.Y)

        writer.Flush()
        writer.Close()
        pushLblEvent("Game successfully saved!")
        player.solFlag = False
        player.createP()
    End Sub
    'loadSave handles the loading of a game
    Sub loadSave(ByVal a As String)
        Debug_Window.clear()
        floorCode = ""
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

        player.canMoveFlag = False
        boardWorker = New BackgroundWorker
        boardWorker.WorkerReportsProgress = True
        boardWorker.WorkerSupportsCancellation = True
        AddHandler boardWorker.DoWork, AddressOf bw_DoWork
        AddHandler boardWorker.ProgressChanged, AddressOf bw_ProgressChanged
        AddHandler boardWorker.RunWorkerCompleted, AddressOf bw_RunWorkerCompleted
        picLoadBar.Size = New Size(10, 17)

        If picLoadBar.Visible = False Then picLoadBar.Visible = True
        If picStart.Visible = False Then picStart.Visible = True
        picStart.BringToFront()
        picLoadBar.BringToFront()
        System.Threading.Thread.Sleep(750)

        Application.DoEvents()
        boardWorker.RunWorkerAsync()

        Dim reader As IO.StreamReader
        reader = IO.File.OpenText(a)
        Dim v = CDbl(reader.ReadLine())
        If v < 0.6 Then
            MsgBox("Error 003: Incorrect save file version!")
            picStart.Visible = True
            btnS.Visible = True
            btnL.Visible = True
            btnAbout.Visible = True
            boardWorker.CancelAsync()
            Exit Sub
        End If
        player = New Player(reader.ReadLine(), v)

        If Not mBoard Is Nothing Then
            For i = 0 To mBoardHeight - 1
                For j = 0 To mBoardWidth - 1
                    mBoard(i, j).Dispose()
                    If j < 23 And i < 15 Then
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
        System.Threading.Thread.Sleep(750)
        newBoard()
        For yInd = 0 To b2
            For xInd = 0 To b1
                mBoard(yInd, xInd).Tag = reader.ReadLine()
            Next
        Next
        zoom()

        stairs = New Point(reader.ReadLine(), reader.ReadLine())

        chestFreqMin = reader.ReadLine()
        chestFreqRange = reader.ReadLine()
        chestSizeDependence = reader.ReadLine()
        chestRichnessBase = reader.ReadLine()
        chestRichnessRange = reader.ReadLine()
        Dim uOchests As ArrayList = New ArrayList()
        For i = 0 To CInt(reader.ReadLine())
            Dim newChest = baseChest.Create(reader.ReadLine())
            chestList.Add(newChest)
            uOchests.Add(newChest.pos)
        Next

        Dim ind = CInt(reader.ReadLine())
        For i = 0 To ind
            Dim t = New Trap(reader.ReadLine())
            If Not t.pos.Equals(New Point(-1, -1)) Then
                trapList.Add(t)
            End If
        Next
        For i = 0 To trapList.Count - 1
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
        For i = 0 To CInt(reader.ReadLine())
            beatboss(i) = CBool(reader.ReadLine)
        Next
        turn = reader.ReadLine()
        floor = reader.ReadLine()
        floorCode = reader.ReadLine()
        encounterRate = Int(reader.ReadLine())
        eClockResetVal = Int(reader.ReadLine())
        shopkeeper = New NPC(2)
        shopkeeper.pos.X = reader.ReadLine()
        shopkeeper.pos.Y = reader.ReadLine()

        floorLayouts.Clear()
        For i = 0 To CInt(reader.ReadLine())
            floorLayouts.Add(reader.ReadLine())
        Next

        swiz = New NPC(3)
        swiz.pos.X = reader.ReadLine()
        swiz.pos.Y = reader.ReadLine()

        chestList.Clear()
        If floor < 5 Then
            placeChest(floorLayouts(floor))
        Else
            placeChest(genRNDLVLCode)
        End If

        Dim tCL As ArrayList = New ArrayList()
        For i = 0 To uOchests.Count - 1
            For j = 0 To chestList.Count - 1
                If chestList(j).pos.x.Equals(uOchests(i).x) And chestList(j).pos.y.Equals(uOchests(i).y) Then
                    tCL.Add(chestList(j))
                    Exit For
                End If
            Next
        Next
        chestList.Clear()
        chestList = tCL.Clone()

        If chestList.Count = 0 And uOchests.Count <> 0 Then
            If floor < 4 Then
                placeChest(floorLayouts(floor))
            Else
                placeChest(genRNDLVLCode)
            End If
        End If

        combatmode = False

        Equipment.init()
        reader.Close()
        player.setPImage()

        drawBoard()

        lblNameTitle.Text = player.name & " the " & player.pClass.name
        lblHealth.Text = "Health = " & CInt(player.health * player.getmaxHealth) & "/" & player.maxHealth
        lblMana.Text = "Mana = " & player.mana & "/" & player.maxMana
        lblHunger.Text = "Hunger = " & player.hunger & "/100"
        lblATK.Text = "ATK = " & player.getAttack
        lblDEF.Text = "DEF = " & player.getDefence
        lblSKL.Text = "WIL = " & player.getWillpower
        lblSPD.Text = "SPD = " & player.getSpeed
        lblEVD.Text = "EVD = " & player.evade

        player.currState.save(player)

        picStart.Visible = False

        pushLblEvent("Game successfully loaded!")
        player.solFlag = False
        player.createP()

    End Sub
    Private Sub btnSavePic_Click(sender As Object, e As EventArgs) Handles btnS1.Click, btnS2.Click, btnS3.Click, btnS4.Click, btnS5.Click, btnS6.Click, btnS7.Click, btnS8.Click
        Dim name As String = CType(sender, Button).Name
        Dim fileNum As String = name(name.Length - 1)
        If solFlag Then
            Try
                loadSave("s" & fileNum & ".ave")
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
        Else
            If solFlag Then btnS1.Enabled = False Else btnS1.Enabled = True
        End If

        If savePics(2) IsNot Nothing Then
            btnS2.BackgroundImage = savePics(2)
        Else
            If solFlag Then btnS2.Enabled = False Else btnS2.Enabled = True
        End If

        If savePics(3) IsNot Nothing Then
            btnS3.BackgroundImage = savePics(3)
        Else
            If solFlag Then btnS3.Enabled = False Else btnS3.Enabled = True
        End If

        If savePics(4) IsNot Nothing Then
            btnS4.BackgroundImage = savePics(4)
        Else
            If solFlag Then btnS4.Enabled = False Else btnS4.Enabled = True
        End If

        If savePics(5) IsNot Nothing Then
            btnS5.BackgroundImage = savePics(5)
        Else
            If solFlag Then btnS5.Enabled = False Else btnS5.Enabled = True
        End If

        If savePics(6) IsNot Nothing Then
            btnS6.BackgroundImage = savePics(6)
        Else
            If solFlag Then btnS6.Enabled = False Else btnS6.Enabled = True
        End If

        If savePics(7) IsNot Nothing Then
            btnS7.BackgroundImage = savePics(7)
        Else
            If solFlag Then btnS7.Enabled = False Else btnS7.Enabled = True
        End If

        If savePics(8) IsNot Nothing Then
            btnS8.BackgroundImage = savePics(8)
        Else
            If solFlag Then btnS8.Enabled = False Else btnS8.Enabled = True
        End If

        Me.Update()
        player.canMoveFlag = False
    End Sub
    Sub closesol()
        Dim int As Integer = 100 - player.getSpeed
        If int < 1 Then int = 1
        updatelist.add(player, int)
        combatmode = False
        picStart.Visible = False
        If player.isDead Then formReset()
        player.canMoveFlag = True
    End Sub

    'combat UI methods
    Sub pushLblCombatEvent(ByVal s As String)
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
    End Sub
    Sub updatePnlCombat(ByVal p As Player, ByVal t As Monster)
        If lblTurn.Text.Equals("Turn: " & turn) Or t Is Nothing Then Exit Sub
        If t.health <= 0 Then
            t.Die()
            Exit Sub
        End If
        lblPHealth.Text = CInt(p.health * p.getmaxHealth) & "/" & p.getmaxHealth
        lblEHealth.Text = t.health & "/" & t.maxHealth
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

        Dim ratioEH As Double = (t.health / t.maxHealth) * ratio
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

    'description panel methods
    Sub toDesc()
        txtDescript.Text = player.genDescription
        picDescPort.BackgroundImage = picPortrait.BackgroundImage
        pnlDescript.Location = New Point(115, pnlDescript.Location.Y)
        pnlDescript.Visible = True
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
        chkAcc.Visible = True
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
        If chkAcc.Checked Then invFilters(6) = True Else invFilters(6) = False
    End Sub
    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        fUseable.Visible = False
        fPotion.Visible = False
        fFood.Visible = False
        fArmor.Visible = False
        fWeapon.Visible = False
        fMisc.Visible = False
        chkAcc.Visible = False
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
    Private Sub chkAcc_CheckedChanged(sender As Object, e As EventArgs) Handles chkAcc.CheckedChanged
        If chkAcc.Checked Then invFilters(6) = True Else invFilters(6) = False
    End Sub
    Private Sub btnAll_Click(sender As Object, e As EventArgs) Handles btnAll.Click
        fUseable.Checked = True
        fPotion.Checked = True
        fFood.Checked = True
        fArmor.Checked = True
        fWeapon.Checked = True
        fMisc.Checked = True
        chkAcc.Checked = True
    End Sub
    Private Sub btnNone_Click(sender As Object, e As EventArgs) Handles btnNone.Click
        fUseable.Checked = False
        fPotion.Checked = False
        fFood.Checked = False
        fArmor.Checked = False
        fWeapon.Checked = False
        fMisc.Checked = False
        chkAcc.Checked = False
    End Sub

    'combat functions
    'toCombat displays the players combat menus
    Sub toCombat()
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
        btnWait.Visible = False
        player.canMoveFlag = True
        player.currTarget = Nothing
        cmboxSpec.Visible = False
        btnSpec.Visible = False

        If player.perks("polymorphed") > -1 Then
            player.perks("polymorphed") = -1
            player.revert2()
        End If
        npcList.Clear()
        ttCosts.RemoveAll()
    End Sub
    'the NPC versions of from and to combat
    Sub NPCtoCombat(ByRef m As Monster)
        lblEHealthChange.Tag = 0
        lblPHealtDiff.Tag = 0
        updatePnlCombat(player, m)
        pnlCombat.Visible = True
        combatmode = True
        npcmode = False
        lstLog.Items.Add((m.getName() & " attacks!"))
        btnATK.Visible = True
        btnMG.Visible = True
        btnRUN.Visible = True
        cboxMG.Visible = True
        btnWait.Visible = True
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
        btnWait.Visible = False
        cboxMG.Visible = False
        cmboxSpec.Visible = False
        btnSpec.Visible = False
        player.canMoveFlag = True

        'btnTalk.Visible = True
        btnNPCMG.Visible = True
        cboxNPCMG.Visible = True
        btnShop.Visible = True
        btnFight.Visible = True
        btnLeave.Visible = True

        lstLog.TopIndex = lstLog.Items.Count - 1

        If player.perks("polymorphed") > -1 Then
            player.perks("polymorphed") = 0
            player.revert2()
        End If
    End Sub
    'run handles the player choice to run from combat
    Sub run()
        If player.health < 1 / player.getmaxHealth Then Exit Sub
        If player.perks("swordpossess") > -1 Then
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
                    updatelist = New PQ
                Else
                    'updates the combat banner
                    updatePnlCombat(player, player.currTarget)
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
                    Exit Sub
                End If

                Exit For
            End If
        Next
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
        If Not m Is Nothing Then m.despawn("npc")
        npcList.Clear()
        player.currTarget = Nothing
        npcmode = False
    End Sub
    Sub npcEncounter(ByRef m As NPC)
        Dim validSpells() As String = {"Turn to Frog", "Polymorph Enemy", "Petrify"}
        cboxNPCMG.Items.Clear()
        For i = 0 To UBound(validSpells)
            If cboxMG.Items.Contains(validSpells(i)) Then cboxNPCMG.Items.Add(validSpells(i))
        Next

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
        If player.pClass.name = "Warrior" Or player.pClass.name = "Paladin" Then cmboxSpec.Items.Add("Berserker Rage")
        If player.pClass.name = "Mage" Or player.pClass.name = "Paladin" Then cmboxSpec.Items.Add("Risky Decision")
        If player.breastSize > 3 Then cmboxSpec.Items.Add("Massive Mammaries")
        If player.pForm.name = "Succubus" Then cmboxSpec.Items.Add("Unholy Seduction")
        If player.pForm.name = "Slime" Then cmboxSpec.Items.Add("Absorbtion")
        If player.pForm.name = "Dragon" Then cmboxSpec.Items.Add("Ironhide Fury")
    End Sub

    'button click methods
    Private Sub btnUse_Click(sender As Object, e As EventArgs) Handles btnUse.Click
        lblEvent.Visible = False
        If Not lblEventOnClose Is Nothing Then
            lblEventOnClose()
            lblEventOnClose = Nothing
        End If
        If Not combatmode And Not npcmode Then player.canMoveFlag = True
        If player.iArrInd(8).Equals(New Tuple(Of Integer, Boolean)(6, False)) Or player.iArrInd(8).Equals(New Tuple(Of Integer, Boolean)(12, True)) Then
            pushLblEvent("You can't use items now!")
            Exit Sub
        End If
        Dim tmpInd As Integer = lstInventory.TopIndex
        Dim tind = lstInventory.SelectedIndex
        selectedItem.use()
        player.invNeedsUDate = True
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
        lblPHealth.Text = CInt(player.health * player.getmaxHealth) & "/" & player.getmaxHealth
    End Sub
    Private Sub btnDrop_Click(sender As Object, e As EventArgs) Handles btnDrop.Click
        If Not lblEventOnClose Is Nothing Then
            lblEventOnClose()
            lblEventOnClose = Nothing
        End If
        selectedItem.discard()
        player.invNeedsUDate = True
        player.UIupdate()

        lstInventory.SelectedItem = Nothing
        selectedItem = Nothing
        btnUse.Enabled = False
        btnDrop.Enabled = False
        btnLook.Enabled = False
    End Sub
    Private Sub btnLook_Click(sender As Object, e As EventArgs) Handles btnLook.Click
        If Not lblEventOnClose Is Nothing Then
            lblEventOnClose()
            lblEventOnClose = Nothing
        End If
        selectedItem.examine()
        lstInventory.SelectedItem = Nothing
        selectedItem = Nothing
        btnUse.Enabled = False
        btnDrop.Enabled = False
        btnLook.Enabled = False
    End Sub
    Private Sub btnATK_Click(sender As Object, e As EventArgs) Handles btnATK.Click
        turn += 1
        If Not lblEventOnClose Is Nothing Then
            lblEventOnClose()
            lblEventOnClose = Nothing
        End If
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
        If Not lblEventOnClose Is Nothing Then
            lblEventOnClose()
            lblEventOnClose = Nothing
        End If
        lblCombatEvents.Text = ""
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
        If Specials.SPCCost(cmboxSpec.Text).Equals("Useable only once per combat.") Then cmboxSpec.Items.Remove(cmboxSpec.Text)
        If cmboxSpec.Items.Count = 0 Then
            cmboxSpec.Visible = False
            btnSpec.Visible = False
        End If
        cmboxSpec.Text = "-- Select --"
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
        ttCosts.RemoveAll()
    End Sub
    Private Sub btnRUN_Click(sender As Object, e As EventArgs) Handles btnRUN.Click
        If lblEvent.Visible = True Then
            lblEvent.Visible = False
            lblEvent.ForeColor = Color.White
            drawBoard()
        End If
        If Not lblEventOnClose Is Nothing Then
            lblEventOnClose()
            lblEventOnClose = Nothing
        End If
        turn += 1
        run()
    End Sub
    Private Sub btnMG_Click(sender As Object, e As EventArgs) Handles btnMG.Click
        turn += 1
        If Not lblEventOnClose Is Nothing Then
            lblEventOnClose()
            lblEventOnClose = Nothing
        End If
        lblCombatEvents.Text = ""
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
        Spell.spellCast(m, player, cboxMG.Text)
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
        If npcmode Then picNPC.BackgroundImage = currNPC.picNCP(currNPC.npcIndex)
        'updates the combat banner
        updatePnlCombat(player, player.currTarget)
        ttCosts.RemoveAll()
    End Sub
    Private Sub btnEQP_Click(sender As Object, e As EventArgs) Handles btnEQP.Click
        Dim f3 As Equipment = New Equipment()
        If Not lblEventOnClose Is Nothing Then
            lblEventOnClose()
            lblEventOnClose = Nothing
        End If
        f3.ShowDialog()
        f3.Dispose()
    End Sub
    Private Sub btnEXM_Click(sender As Object, e As EventArgs) Handles btnEXM.Click
        If Not lblEventOnClose Is Nothing Then
            lblEventOnClose()
            lblEventOnClose = Nothing
        End If
        lstLog.Items.Add(player.description)
        toDesc()
        lstLog.TopIndex = lstLog.Items.Count - 1
    End Sub
    Private Sub btnIns_Click(sender As Object, e As EventArgs) Handles btnIns.Click
        If Not lblEventOnClose Is Nothing Then
            lblEventOnClose()
            lblEventOnClose = Nothing
        End If
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
        btnS.Visible = False
        btnL.Visible = False
        btnControls.Visible = False
        btnSettings.Visible = False
        btnAbout.Visible = False
        Application.DoEvents()
        Try
            CharacterGenerator.init()

            CharacterGenerator.fFrontHair(0) = CharacterGenerator.picPort.Image
            CharacterGenerator.mFrontHair(0) = CharacterGenerator.picPort.Image
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
        loadcKeys()
    End Sub
    Private Sub btnTalk_Click(sender As Object, e As EventArgs) Handles btnTalk.Click
        If Not lblEventOnClose Is Nothing Then
            lblEventOnClose()
            lblEventOnClose = Nothing
        End If
        If lblEvent.Visible = True Then
            lblEvent.Visible = False
            lblEvent.ForeColor = Color.White
            drawBoard()
        End If
    End Sub
    Private Sub btnShop_Click(sender As Object, e As EventArgs) Handles btnShop.Click
        If Not lblEventOnClose Is Nothing Then
            lblEventOnClose()
            lblEventOnClose = Nothing
        End If
        If lblEvent.Visible = True Then
            lblEvent.Visible = False
            lblEvent.ForeColor = Color.White
            drawBoard()
        End If
        'Dim s As Shop = New Shop
        Dim s As ShopV2 = New ShopV2
        s.ShowDialog()
        s.Dispose()
    End Sub
    Private Sub btnNPCMG_Click(sender As Object, e As EventArgs) Handles btnNPCMG.Click
        If Not lblEventOnClose Is Nothing Then
            lblEventOnClose()
            lblEventOnClose = Nothing
        End If
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
            'If cboxNPCMG.Text = "Turn to Frog" Then Spells.turnToFrogN(m, player) Else Spell.spellCast(m, player, cboxNPCMG.Text)
            Spell.spellCast(m, player, cboxNPCMG.Text)

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
            picNPC.BackgroundImage = currNPC.picNCP(currNPC.npcIndex)
            updatelist.add(player, int)
            drawBoard()
        End If
    End Sub
    Private Sub btnFight_Click(sender As Object, e As EventArgs) Handles btnFight.Click
        If Not lblEventOnClose Is Nothing Then
            lblEventOnClose()
            lblEventOnClose = Nothing
        End If
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
        If Not lblEventOnClose Is Nothing Then
            lblEventOnClose()
            lblEventOnClose = Nothing
        End If
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
        If lblEvent.Visible = True Or combatmode Or npcmode Or Me.MdiChildren.Length > 0 Then
            pushLblEvent("You can't load now!")
            Exit Sub
        End If
        solFlag = True
        toSOL()
    End Sub
    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        solFlag = False
        If lblEvent.Visible = True Or combatmode Or npcmode Or Me.MdiChildren.Length > 0 Then
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
        player.invNeedsUDate = True
        player.UIupdate()
    End Sub

    'timer methods
    Private Sub tmrKeyCD_Tick(sender As Object, e As EventArgs) Handles tmrKeyCD.Tick
        tmrKeyCD.Enabled = False
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
        If combatmode Then
            pushLblCombatEvent(s)
            Exit Sub
        End If
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
        player.canMoveFlag = False
    End Sub
    'This pushLblEvent is identical to the first, but takes an additional action that it executes on close.
    Sub pushLblEvent(ByVal s As String, ByRef effect As Action)
        If combatmode Then
            lblEventOnClose = effect
            pushLblCombatEvent(s)
            Exit Sub
        End If
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
        If Not combatmode Then out += " " & vbCrLf & " " & vbCrLf & "Press any non-movement key to continue." Else out += " " & vbCrLf & " " & vbCrLf & "Click a combat button to continue."
        lblEvent.Text = out
        lblEvent.BringToFront()

        Dim x = (265 * (Me.Size.Width / 688)) - (lblEvent.Size.Width / 2)
        If x < 20 Then x = 20
        lblEvent.Location = New Point(x, (65 * (Me.Size.Width / 688)))
        lblEvent.Visible = True
        player.canMoveFlag = False
        lblEventOnClose = effect
        btnEQP.Enabled = False
    End Sub
    'This pushLblEvent is identical to the second, but to be used in situations where a choice is made.
    Sub pushLblEvent(ByVal s As String, ByRef yes As Action, ByVal no As Action)
        If combatmode Then
            pushLblCombatEvent("Error, choice to be made during combat.")
            Exit Sub
        End If
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
        btnEQP.Enabled = False
    End Sub
    Sub makeChoice()
        toPNLSelec("yesNo")
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
                Dim arr() As String = pState(32 + CInt(pState(31)) + i).Split("%")
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
            changeSkinColor(skincolor, ids, iarr)

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

    'color shift function
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

    Private Sub ReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportToolStripMenuItem.Click
        Process.Start("https://bitbucket.org/VowelHeavyUsername/dungeon_depths/issues?status=new&status=open")
    End Sub
    Private Sub bw_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
        While boardWorker.IsBusy
            If boardWorker.CancellationPending = True Then
                e.Cancel = True
                Exit While
            Else
                'Perform a time consuming operation
                System.Threading.Thread.Sleep(500)
            End If
        End While
    End Sub
    Private Sub bw_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs)
        Dim ratio As Double = Me.Size.Width / 1024
        picLoadBar.Size = New Size(((e.ProgressPercentage / 100) * 395) * ratio, 17 * ratio)
    End Sub
    Private Sub bw_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
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
        player.canMoveFlag = True
    End Sub
    Public Sub ppw_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
        player.createP()
        Equipment.portraitUDate()
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
            If iarrind(15).Item1 < 6 Then
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
            If iarrind(15).Item1 < 6 Then
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
    Shared Sub changeSkinColor(ByVal c As Color, ByVal iarrind() As Tuple(Of Integer, Boolean), ByRef iarr As Image())
        Dim t(16) As Image
        If iarrind(2).Item2 Then
            If iarrind(2).Item1 = 0 Then
                t(2) = CharacterGenerator.getImg("img/fBody")(iarrind(2).Item1)
                iarr(2) = CharacterGenerator.recolor2(t(2), c)
            Else
                Dim range As List(Of Image)
                Dim offset As Integer

                Dim fTFBody As List(Of Image) = CharacterGenerator.getImg("img/fTF/tfBody")
                offset = fTFBody.Count - 5
                range = fTFBody.GetRange(offset, 5)
                fTFBody = fTFBody.GetRange(0, offset)
                fTFBody.InsertRange(4, range)

                t(2) = fTFBody(iarrind(2).Item1 - 1)
                iarr(2) = CharacterGenerator.recolor2(t(2), c)
            End If
        Else
            If iarrind(2).Item1 = 0 Then
                t(2) = CharacterGenerator.getImg("img/mBody")(iarrind(2).Item1)
                iarr(2) = CharacterGenerator.recolor2(t(2), c)
            Else
                t(2) = CharacterGenerator.getImg("img/mTF/tfBody")(iarrind(2).Item1 - 1)
                iarr(2) = CharacterGenerator.recolor2(t(2), c)
            End If
        End If
        If iarrind(4).Item2 Then
            t(4) = CharacterGenerator.getImg("img/fFace")(iarrind(4).Item1)
            iarr(4) = CharacterGenerator.recolor2(t(4), c)
            If iarrind(7).Item1 = 0 Then
                t(7) = CharacterGenerator.getImg("img/fNose")(iarrind(7).Item1)
                iarr(7) = CharacterGenerator.recolor2(t(7), c)
            End If
            If iarrind(6).Item1 = 0 Or iarrind(6).Item1 = 3 Then
                t(6) = CharacterGenerator.getImg("img/fEars")(iarrind(6).Item1)
                iarr(6) = CharacterGenerator.recolor2(t(6), c)
            ElseIf iarrind(6).Item1 = 6 Or iarrind(6).Item1 = 7 Then
                t(6) = CharacterGenerator.getImg("img/fTF/tfEars")(iarrind(6).Item1 - 5)
                iarr(6) = CharacterGenerator.recolor2(t(6), c)
            End If
        Else
            t(4) = CharacterGenerator.getImg("img/mFace")(iarrind(4).Item1)
            iarr(4) = CharacterGenerator.recolor2(t(4), c)
            If iarrind(6).Item1 = 0 Or iarrind(6).Item1 = 3 Then
                t(6) = CharacterGenerator.getImg("img/mEars")(iarrind(6).Item1)
                iarr(6) = CharacterGenerator.recolor2(t(6), c)
            End If
            If iarrind(7).Item1 = 0 Then
                t(7) = CharacterGenerator.getImg("img/mNose")(iarrind(7).Item1)
                iarr(7) = CharacterGenerator.recolor2(t(7), c)
            End If
        End If
    End Sub
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

    Private Sub btnWait_Click(sender As Object, e As EventArgs) Handles btnWait.Click
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
        updatelist.add(player, int)
        drawBoard()
        pushLblCombatEvent("You wait for a bit...")
    End Sub

    'cost display for spells and abilities
    Private Sub cboxMG_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboxMG.SelectedIndexChanged

    End Sub
    Private Sub cboxNPCMG_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboxNPCMG.SelectedIndexChanged

    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        Dim ab1 As About = New About
        ab1.ShowDialog()
        ab1.Dispose()
    End Sub

    Private Sub cmboxSpec_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmboxSpec.SelectedIndexChanged
        If Not cmboxSpec.Text.Equals("-- Select --") And Not cmboxSpec.Text = "" Then ttCosts.SetToolTip(Me.cmboxSpec, Specials.SPCCost(cmboxSpec.Text))
    End Sub

    'btnStettings
    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        Dim s As Settings = New Settings
        s.ShowDialog()
        s.Dispose()
        If screenSize = "Small" Then
            Size = New Size(iWidth * 0.8, iHeight * 0.8)
        ElseIf screenSize = "Medium" Then
            Size = New Size(iWidth * 0.9, iHeight * 0.9)
        ElseIf screenSize = "XLarge" Then
            Size = New Size(iWidth * 1.3, iHeight * 1.3)
        Else
            Size = New Size(iWidth, iHeight)
        End If
        Game_Resize()
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
            pnlDescript.Controls(i).Font = newFont
        Next
        For i = 0 To pnlSaveLoad.Controls.Count - 1
            pnlSaveLoad.Controls(i).Width += CDbl(pnlSaveLoad.Controls(i).Width * RW)
            pnlSaveLoad.Controls(i).Height += CDbl(pnlSaveLoad.Controls(i).Height * RH)
            pnlSaveLoad.Controls(i).Left += CDbl(pnlSaveLoad.Controls(i).Left * RW)
            pnlSaveLoad.Controls(i).Top += CDbl(pnlSaveLoad.Controls(i).Top * RH)
        Next

        startingHeight = Height
        startingWidth = Width
        Dim ratio As Double = Me.Size.Width / 1024
        picLoadBar.Location = New Point(picLoadBar.Location.X * ratio, picLoadBar.Location.Y * ratio)
    End Sub

    Private Sub HelpToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem1.Click
        Dim f6 As Controls = New Controls
        f6.ShowDialog()
        f6.Dispose()
        loadcKeys()
    End Sub
End Class
