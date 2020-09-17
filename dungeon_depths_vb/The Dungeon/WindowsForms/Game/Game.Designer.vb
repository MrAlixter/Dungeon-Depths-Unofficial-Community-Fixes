<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Game
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
                If Not seenBoardPic Is Nothing Then seenBoardPic.Dispose()
                If Not savedBoardPic Is Nothing Then savedBoardPic.Dispose()
                If Not boardPic Is Nothing Then boardPic.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Game))
        Me.btnUse1 = New System.Windows.Forms.Button()
        Me.btnDrop = New System.Windows.Forms.Button()
        Me.btnLook = New System.Windows.Forms.Button()
        Me.btnControls = New System.Windows.Forms.Button()
        Me.picEnemy = New System.Windows.Forms.PictureBox()
        Me.btnLeave = New System.Windows.Forms.Button()
        Me.btnFight = New System.Windows.Forms.Button()
        Me.btnNPCMG = New System.Windows.Forms.Button()
        Me.cboxNPCMG = New System.Windows.Forms.ComboBox()
        Me.btnShop = New System.Windows.Forms.Button()
        Me.btnTalk = New System.Windows.Forms.Button()
        Me.picNPC = New System.Windows.Forms.PictureBox()
        Me.picStatue = New System.Windows.Forms.PictureBox()
        Me.picPlayerB = New System.Windows.Forms.PictureBox()
        Me.picChest = New System.Windows.Forms.PictureBox()
        Me.picStairs = New System.Windows.Forms.PictureBox()
        Me.picPlayer = New System.Windows.Forms.PictureBox()
        Me.picFog = New System.Windows.Forms.PictureBox()
        Me.picTile = New System.Windows.Forms.PictureBox()
        Me.btnL = New System.Windows.Forms.Button()
        Me.btnS = New System.Windows.Forms.Button()
        Me.picStart = New System.Windows.Forms.PictureBox()
        Me.btnEQP = New System.Windows.Forms.Button()
        Me.btnRUN = New System.Windows.Forms.Button()
        Me.btnMG = New System.Windows.Forms.Button()
        Me.btnATK = New System.Windows.Forms.Button()
        Me.lblSPD = New System.Windows.Forms.Label()
        Me.lblWIL = New System.Windows.Forms.Label()
        Me.lblDEF = New System.Windows.Forms.Label()
        Me.lblATK = New System.Windows.Forms.Label()
        Me.lblLevel = New System.Windows.Forms.Label()
        Me.lblMana = New System.Windows.Forms.Label()
        Me.lblHealth = New System.Windows.Forms.Label()
        Me.lblNameTitle = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnUse = New System.Windows.Forms.Button()
        Me.lstInventory = New System.Windows.Forms.ListBox()
        Me.lstLog = New System.Windows.Forms.ListBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewGameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RunAutomatedTestsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DebugToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.picPortrait = New System.Windows.Forms.PictureBox()
        Me.btnEXM = New System.Windows.Forms.Button()
        Me.lblGold = New System.Windows.Forms.Label()
        Me.picShopkeepTile = New System.Windows.Forms.PictureBox()
        Me.picLust1 = New System.Windows.Forms.PictureBox()
        Me.picLust2 = New System.Windows.Forms.PictureBox()
        Me.picLust3 = New System.Windows.Forms.PictureBox()
        Me.picLust4 = New System.Windows.Forms.PictureBox()
        Me.picLust5 = New System.Windows.Forms.PictureBox()
        Me.btnIns = New System.Windows.Forms.Button()
        Me.btnR = New System.Windows.Forms.Button()
        Me.btnU = New System.Windows.Forms.Button()
        Me.BtnD = New System.Windows.Forms.Button()
        Me.btnLft = New System.Windows.Forms.Button()
        Me.cboxSpec = New System.Windows.Forms.ComboBox()
        Me.btnSpec = New System.Windows.Forms.Button()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.chkUseable = New System.Windows.Forms.CheckBox()
        Me.chkPotion = New System.Windows.Forms.CheckBox()
        Me.chkFood = New System.Windows.Forms.CheckBox()
        Me.frmArmor = New System.Windows.Forms.CheckBox()
        Me.chkWeapon = New System.Windows.Forms.CheckBox()
        Me.chkMisc = New System.Windows.Forms.CheckBox()
        Me.btnAll = New System.Windows.Forms.Button()
        Me.btnNone = New System.Windows.Forms.Button()
        Me.picTrap = New System.Windows.Forms.PictureBox()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.btnT = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnS8 = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnS7 = New System.Windows.Forms.Button()
        Me.btnS6 = New System.Windows.Forms.Button()
        Me.btnS5 = New System.Windows.Forms.Button()
        Me.btnS4 = New System.Windows.Forms.Button()
        Me.btnS3 = New System.Windows.Forms.Button()
        Me.btnS2 = New System.Windows.Forms.Button()
        Me.btnS1 = New System.Windows.Forms.Button()
        Me.pnlSaveLoad = New System.Windows.Forms.Panel()
        Me.picSheep = New System.Windows.Forms.PictureBox()
        Me.picFrog = New System.Windows.Forms.PictureBox()
        Me.picTileF = New System.Windows.Forms.PictureBox()
        Me.picTree = New System.Windows.Forms.PictureBox()
        Me.picPlayerf = New System.Windows.Forms.PictureBox()
        Me.picLadderf = New System.Windows.Forms.PictureBox()
        Me.picChestf = New System.Windows.Forms.PictureBox()
        Me.picBimbof = New System.Windows.Forms.PictureBox()
        Me.picShopkeeperf = New System.Windows.Forms.PictureBox()
        Me.picStatuef = New System.Windows.Forms.PictureBox()
        Me.picTrapf = New System.Windows.Forms.PictureBox()
        Me.tmrKeyCD = New System.Windows.Forms.Timer(Me.components)
        Me.pnlCombat = New System.Windows.Forms.Panel()
        Me.lblCombatEvents = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblPHealtDiff = New System.Windows.Forms.Label()
        Me.lblEHealthChange = New System.Windows.Forms.Label()
        Me.lblTurn = New System.Windows.Forms.Label()
        Me.lblPHealth = New System.Windows.Forms.Label()
        Me.lblPName = New System.Windows.Forms.Label()
        Me.lblEHealth = New System.Windows.Forms.Label()
        Me.lblEName = New System.Windows.Forms.Label()
        Me.picPHealth = New System.Windows.Forms.PictureBox()
        Me.picEHbar = New System.Windows.Forms.PictureBox()
        Me.lblEvent = New System.Windows.Forms.Label()
        Me.picLoadBar = New System.Windows.Forms.PictureBox()
        Me.btnWait = New System.Windows.Forms.Button()
        Me.picSWiz = New System.Windows.Forms.PictureBox()
        Me.picSWizF = New System.Windows.Forms.PictureBox()
        Me.pnlDescription = New System.Windows.Forms.Panel()
        Me.lblNext = New System.Windows.Forms.Label()
        Me.picDescPort = New System.Windows.Forms.PictureBox()
        Me.txtPlayerDesc = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ttCosts = New System.Windows.Forms.ToolTip(Me.components)
        Me.picStairsLock = New System.Windows.Forms.PictureBox()
        Me.picStairsBoss = New System.Windows.Forms.PictureBox()
        Me.picstairsbossf = New System.Windows.Forms.PictureBox()
        Me.picstairslockf = New System.Windows.Forms.PictureBox()
        Me.pnlSelection = New System.Windows.Forms.Panel()
        Me.lblInstruc = New System.Windows.Forms.Label()
        Me.lblWhat = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lstSelec = New System.Windows.Forms.ListBox()
        Me.picBun = New System.Windows.Forms.PictureBox()
        Me.picPrin = New System.Windows.Forms.PictureBox()
        Me.picmgp1 = New System.Windows.Forms.PictureBox()
        Me.picDragonM = New System.Windows.Forms.PictureBox()
        Me.chkAcc = New System.Windows.Forms.CheckBox()
        Me.picCrystal = New System.Windows.Forms.PictureBox()
        Me.picCrystalf = New System.Windows.Forms.PictureBox()
        Me.btnAbout = New System.Windows.Forms.Button()
        Me.picPath = New System.Windows.Forms.PictureBox()
        Me.picPathf = New System.Windows.Forms.PictureBox()
        Me.lblLoadMsg = New System.Windows.Forms.Label()
        Me.picCake = New System.Windows.Forms.PictureBox()
        Me.picHT = New System.Windows.Forms.PictureBox()
        Me.picHTf = New System.Windows.Forms.PictureBox()
        Me.picFVf = New System.Windows.Forms.PictureBox()
        Me.picFVtile = New System.Windows.Forms.PictureBox()
        Me.picStaffEnd = New System.Windows.Forms.PictureBox()
        Me.picSpaceStairs = New System.Windows.Forms.PictureBox()
        Me.picSpaceTrap = New System.Windows.Forms.PictureBox()
        Me.picSpaceChest = New System.Windows.Forms.PictureBox()
        Me.picSpaceTile = New System.Windows.Forms.PictureBox()
        Me.picPlayerSpace = New System.Windows.Forms.PictureBox()
        Me.picBimboSpace = New System.Windows.Forms.PictureBox()
        Me.picSPacePath = New System.Windows.Forms.PictureBox()
        Me.picSpaceCrystal = New System.Windows.Forms.PictureBox()
        Me.pnlEvent = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnNextLPnlEvent = New System.Windows.Forms.Button()
        Me.btnNextRPnlEvent = New System.Windows.Forms.Button()
        Me.btnClosePnlEvent = New System.Windows.Forms.Button()
        Me.txtPNLEvents = New System.Windows.Forms.TextBox()
        Me.picLegaPath = New System.Windows.Forms.PictureBox()
        Me.picLegaCrystal = New System.Windows.Forms.PictureBox()
        Me.picLegaPlayer = New System.Windows.Forms.PictureBox()
        Me.picLegaBimbo = New System.Windows.Forms.PictureBox()
        Me.picLegaStairs = New System.Windows.Forms.PictureBox()
        Me.picLegaTrap = New System.Windows.Forms.PictureBox()
        Me.picLegaChest = New System.Windows.Forms.PictureBox()
        Me.picLegaTile = New System.Windows.Forms.PictureBox()
        Me.picLegaCaelia = New System.Windows.Forms.PictureBox()
        Me.picWSf = New System.Windows.Forms.PictureBox()
        Me.picWS = New System.Windows.Forms.PictureBox()
        Me.picDragonF = New System.Windows.Forms.PictureBox()
        Me.picCBrok = New System.Windows.Forms.PictureBox()
        Me.picCBrokF = New System.Windows.Forms.PictureBox()
        Me.picPortOutline = New System.Windows.Forms.PictureBox()
        Me.picHalfDragon2 = New System.Windows.Forms.PictureBox()
        Me.picBroodmother = New System.Windows.Forms.PictureBox()
        Me.picHalfDragon1 = New System.Windows.Forms.PictureBox()
        Me.picBlobF = New System.Windows.Forms.PictureBox()
        Me.picHorse = New System.Windows.Forms.PictureBox()
        Me.picBlobM = New System.Windows.Forms.PictureBox()
        Me.picOniF = New System.Windows.Forms.PictureBox()
        Me.picUnicorn = New System.Windows.Forms.PictureBox()
        Me.picTTTile = New System.Windows.Forms.PictureBox()
        Me.picTTTileF = New System.Windows.Forms.PictureBox()
        Me.picCow = New System.Windows.Forms.PictureBox()
        Me.picCheerL = New System.Windows.Forms.PictureBox()
        Me.picMGTile = New System.Windows.Forms.PictureBox()
        Me.picMGTileF = New System.Windows.Forms.PictureBox()
        Me.picCBFog = New System.Windows.Forms.PictureBox()
        Me.picStatueFog = New System.Windows.Forms.PictureBox()
        Me.picCrystalFog = New System.Windows.Forms.PictureBox()
        Me.picPlayerFog = New System.Windows.Forms.PictureBox()
        Me.picPlayerBFog = New System.Windows.Forms.PictureBox()
        Me.picStairFog = New System.Windows.Forms.PictureBox()
        Me.picTrapFog = New System.Windows.Forms.PictureBox()
        Me.picChestFog = New System.Windows.Forms.PictureBox()
        Me.picTileFog = New System.Windows.Forms.PictureBox()
        Me.picFVFog = New System.Windows.Forms.PictureBox()
        Me.picTreeFog = New System.Windows.Forms.PictureBox()
        Me.picBossStairsFog = New System.Windows.Forms.PictureBox()
        Me.picMushroom = New System.Windows.Forms.PictureBox()
        Me.picPFaeShock = New System.Windows.Forms.PictureBox()
        Me.picPFae = New System.Windows.Forms.PictureBox()
        Me.pnlStats = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pnlMeter = New System.Windows.Forms.Panel()
        Me.lblHealthbarFont = New System.Windows.Forms.Label()
        Me.lblstamina = New System.Windows.Forms.Label()
        Me.lblXP = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pic9tailsBimbo = New System.Windows.Forms.PictureBox()
        Me.picFoxStatueGold = New System.Windows.Forms.PictureBox()
        Me.picFoxStatueF = New System.Windows.Forms.PictureBox()
        Me.lblLust = New System.Windows.Forms.Label()
        CType(Me.picEnemy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picNPC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picStatue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPlayerB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picChest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picStairs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPlayer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picFog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picStart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.picPortrait, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picShopkeepTile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLust1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLust2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLust3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLust4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLust5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTrap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSaveLoad.SuspendLayout()
        CType(Me.picSheep, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picFrog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTileF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTree, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPlayerf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLadderf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picChestf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBimbof, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picShopkeeperf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picStatuef, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTrapf, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCombat.SuspendLayout()
        CType(Me.picPHealth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picEHbar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLoadBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSWiz, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSWizF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDescription.SuspendLayout()
        CType(Me.picDescPort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picStairsLock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picStairsBoss, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picstairsbossf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picstairslockf, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSelection.SuspendLayout()
        CType(Me.picBun, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPrin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picmgp1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDragonM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCrystal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCrystalf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPath, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPathf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCake, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picHT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picHTf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picFVf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picFVtile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picStaffEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSpaceStairs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSpaceTrap, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSpaceChest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSpaceTile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPlayerSpace, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBimboSpace, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSPacePath, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSpaceCrystal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEvent.SuspendLayout()
        CType(Me.picLegaPath, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLegaCrystal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLegaPlayer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLegaBimbo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLegaStairs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLegaTrap, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLegaChest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLegaTile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLegaCaelia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picWSf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picWS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDragonF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCBrok, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCBrokF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPortOutline, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picHalfDragon2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBroodmother, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picHalfDragon1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBlobF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picHorse, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBlobM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picOniF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picUnicorn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTTTile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTTTileF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCheerL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMGTile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMGTileF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCBFog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picStatueFog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCrystalFog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPlayerFog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPlayerBFog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picStairFog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTrapFog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picChestFog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTileFog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picFVFog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTreeFog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBossStairsFog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMushroom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPFaeShock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPFae, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlStats.SuspendLayout()
        Me.pnlMeter.SuspendLayout()
        CType(Me.pic9tailsBimbo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picFoxStatueGold, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picFoxStatueF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnUse1
        '
        Me.btnUse1.BackColor = System.Drawing.SystemColors.Window
        Me.btnUse1.Enabled = False
        Me.btnUse1.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUse1.Location = New System.Drawing.Point(739, 607)
        Me.btnUse1.Name = "btnUse1"
        Me.btnUse1.Size = New System.Drawing.Size(75, 33)
        Me.btnUse1.TabIndex = 3
        Me.btnUse1.Text = "Use"
        Me.btnUse1.UseVisualStyleBackColor = False
        '
        'btnDrop
        '
        Me.btnDrop.BackColor = System.Drawing.SystemColors.Window
        Me.btnDrop.Enabled = False
        Me.btnDrop.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDrop.Location = New System.Drawing.Point(820, 606)
        Me.btnDrop.Name = "btnDrop"
        Me.btnDrop.Size = New System.Drawing.Size(75, 34)
        Me.btnDrop.TabIndex = 4
        Me.btnDrop.Text = "Discard"
        Me.btnDrop.UseVisualStyleBackColor = False
        '
        'btnLook
        '
        Me.btnLook.BackColor = System.Drawing.SystemColors.Window
        Me.btnLook.Enabled = False
        Me.btnLook.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLook.Location = New System.Drawing.Point(901, 606)
        Me.btnLook.Name = "btnLook"
        Me.btnLook.Size = New System.Drawing.Size(75, 34)
        Me.btnLook.TabIndex = 5
        Me.btnLook.Text = "Inspect"
        Me.btnLook.UseVisualStyleBackColor = False
        '
        'btnControls
        '
        Me.btnControls.BackColor = System.Drawing.Color.Black
        Me.btnControls.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnControls.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnControls.ForeColor = System.Drawing.Color.White
        Me.btnControls.Location = New System.Drawing.Point(335, 403)
        Me.btnControls.Name = "btnControls"
        Me.btnControls.Size = New System.Drawing.Size(99, 39)
        Me.btnControls.TabIndex = 203
        Me.btnControls.Text = "Controls"
        Me.btnControls.UseVisualStyleBackColor = False
        '
        'picEnemy
        '
        Me.picEnemy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picEnemy.Location = New System.Drawing.Point(48, 203)
        Me.picEnemy.Name = "picEnemy"
        Me.picEnemy.Size = New System.Drawing.Size(125, 189)
        Me.picEnemy.TabIndex = 201
        Me.picEnemy.TabStop = False
        Me.picEnemy.Visible = False
        '
        'btnLeave
        '
        Me.btnLeave.BackColor = System.Drawing.Color.Black
        Me.btnLeave.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLeave.ForeColor = System.Drawing.Color.White
        Me.btnLeave.Location = New System.Drawing.Point(584, 419)
        Me.btnLeave.Name = "btnLeave"
        Me.btnLeave.Size = New System.Drawing.Size(89, 36)
        Me.btnLeave.TabIndex = 186
        Me.btnLeave.Text = "Leave"
        Me.btnLeave.UseVisualStyleBackColor = False
        Me.btnLeave.Visible = False
        '
        'btnFight
        '
        Me.btnFight.BackColor = System.Drawing.Color.Black
        Me.btnFight.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFight.ForeColor = System.Drawing.Color.White
        Me.btnFight.Location = New System.Drawing.Point(488, 419)
        Me.btnFight.Name = "btnFight"
        Me.btnFight.Size = New System.Drawing.Size(89, 36)
        Me.btnFight.TabIndex = 184
        Me.btnFight.Text = "Fight"
        Me.btnFight.UseVisualStyleBackColor = False
        Me.btnFight.Visible = False
        '
        'btnNPCMG
        '
        Me.btnNPCMG.BackColor = System.Drawing.Color.Black
        Me.btnNPCMG.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNPCMG.ForeColor = System.Drawing.Color.White
        Me.btnNPCMG.Location = New System.Drawing.Point(392, 419)
        Me.btnNPCMG.Name = "btnNPCMG"
        Me.btnNPCMG.Size = New System.Drawing.Size(90, 36)
        Me.btnNPCMG.TabIndex = 183
        Me.btnNPCMG.Text = "Magic"
        Me.btnNPCMG.UseVisualStyleBackColor = False
        Me.btnNPCMG.Visible = False
        '
        'cboxNPCMG
        '
        Me.cboxNPCMG.BackColor = System.Drawing.Color.Black
        Me.cboxNPCMG.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboxNPCMG.ForeColor = System.Drawing.Color.White
        Me.cboxNPCMG.FormattingEnabled = True
        Me.cboxNPCMG.Location = New System.Drawing.Point(237, 422)
        Me.cboxNPCMG.Name = "cboxNPCMG"
        Me.cboxNPCMG.Size = New System.Drawing.Size(149, 21)
        Me.cboxNPCMG.TabIndex = 182
        Me.cboxNPCMG.Text = "-- Select --"
        Me.cboxNPCMG.Visible = False
        '
        'btnShop
        '
        Me.btnShop.BackColor = System.Drawing.Color.Black
        Me.btnShop.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShop.ForeColor = System.Drawing.Color.White
        Me.btnShop.Location = New System.Drawing.Point(144, 419)
        Me.btnShop.Name = "btnShop"
        Me.btnShop.Size = New System.Drawing.Size(89, 36)
        Me.btnShop.TabIndex = 181
        Me.btnShop.Text = "Shop"
        Me.btnShop.UseVisualStyleBackColor = False
        Me.btnShop.Visible = False
        '
        'btnTalk
        '
        Me.btnTalk.BackColor = System.Drawing.Color.Black
        Me.btnTalk.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTalk.ForeColor = System.Drawing.Color.White
        Me.btnTalk.Location = New System.Drawing.Point(48, 419)
        Me.btnTalk.Name = "btnTalk"
        Me.btnTalk.Size = New System.Drawing.Size(89, 36)
        Me.btnTalk.TabIndex = 180
        Me.btnTalk.Text = "Talk"
        Me.btnTalk.UseVisualStyleBackColor = False
        Me.btnTalk.Visible = False
        '
        'picNPC
        '
        Me.picNPC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picNPC.Location = New System.Drawing.Point(82, 179)
        Me.picNPC.Name = "picNPC"
        Me.picNPC.Size = New System.Drawing.Size(125, 189)
        Me.picNPC.TabIndex = 179
        Me.picNPC.TabStop = False
        Me.picNPC.Visible = False
        '
        'picStatue
        '
        Me.picStatue.BackgroundImage = CType(resources.GetObject("picStatue.BackgroundImage"), System.Drawing.Image)
        Me.picStatue.Location = New System.Drawing.Point(539, 50)
        Me.picStatue.Name = "picStatue"
        Me.picStatue.Size = New System.Drawing.Size(15, 15)
        Me.picStatue.TabIndex = 172
        Me.picStatue.TabStop = False
        Me.picStatue.Visible = False
        '
        'picPlayerB
        '
        Me.picPlayerB.BackgroundImage = CType(resources.GetObject("picPlayerB.BackgroundImage"), System.Drawing.Image)
        Me.picPlayerB.Location = New System.Drawing.Point(518, 50)
        Me.picPlayerB.Name = "picPlayerB"
        Me.picPlayerB.Size = New System.Drawing.Size(15, 15)
        Me.picPlayerB.TabIndex = 170
        Me.picPlayerB.TabStop = False
        Me.picPlayerB.Visible = False
        '
        'picChest
        '
        Me.picChest.BackgroundImage = CType(resources.GetObject("picChest.BackgroundImage"), System.Drawing.Image)
        Me.picChest.Location = New System.Drawing.Point(539, 29)
        Me.picChest.Name = "picChest"
        Me.picChest.Size = New System.Drawing.Size(15, 15)
        Me.picChest.TabIndex = 169
        Me.picChest.TabStop = False
        Me.picChest.Visible = False
        '
        'picStairs
        '
        Me.picStairs.BackgroundImage = CType(resources.GetObject("picStairs.BackgroundImage"), System.Drawing.Image)
        Me.picStairs.Location = New System.Drawing.Point(560, 29)
        Me.picStairs.Name = "picStairs"
        Me.picStairs.Size = New System.Drawing.Size(15, 15)
        Me.picStairs.TabIndex = 168
        Me.picStairs.TabStop = False
        Me.picStairs.Visible = False
        '
        'picPlayer
        '
        Me.picPlayer.BackgroundImage = CType(resources.GetObject("picPlayer.BackgroundImage"), System.Drawing.Image)
        Me.picPlayer.Location = New System.Drawing.Point(497, 50)
        Me.picPlayer.Name = "picPlayer"
        Me.picPlayer.Size = New System.Drawing.Size(15, 15)
        Me.picPlayer.TabIndex = 167
        Me.picPlayer.TabStop = False
        Me.picPlayer.Visible = False
        '
        'picFog
        '
        Me.picFog.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.picFog.BackgroundImage = CType(resources.GetObject("picFog.BackgroundImage"), System.Drawing.Image)
        Me.picFog.Location = New System.Drawing.Point(518, 29)
        Me.picFog.Name = "picFog"
        Me.picFog.Size = New System.Drawing.Size(15, 15)
        Me.picFog.TabIndex = 166
        Me.picFog.TabStop = False
        Me.picFog.Visible = False
        '
        'picTile
        '
        Me.picTile.BackgroundImage = CType(resources.GetObject("picTile.BackgroundImage"), System.Drawing.Image)
        Me.picTile.Location = New System.Drawing.Point(497, 29)
        Me.picTile.Name = "picTile"
        Me.picTile.Size = New System.Drawing.Size(15, 15)
        Me.picTile.TabIndex = 165
        Me.picTile.TabStop = False
        Me.picTile.Visible = False
        '
        'btnL
        '
        Me.btnL.BackColor = System.Drawing.Color.Black
        Me.btnL.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnL.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnL.ForeColor = System.Drawing.Color.White
        Me.btnL.Location = New System.Drawing.Point(335, 357)
        Me.btnL.Name = "btnL"
        Me.btnL.Size = New System.Drawing.Size(313, 39)
        Me.btnL.TabIndex = 163
        Me.btnL.Text = "Load Game"
        Me.btnL.UseVisualStyleBackColor = False
        '
        'btnS
        '
        Me.btnS.BackColor = System.Drawing.Color.Black
        Me.btnS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnS.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnS.ForeColor = System.Drawing.Color.White
        Me.btnS.Location = New System.Drawing.Point(335, 311)
        Me.btnS.Name = "btnS"
        Me.btnS.Size = New System.Drawing.Size(313, 39)
        Me.btnS.TabIndex = 162
        Me.btnS.Text = "Start New Game"
        Me.btnS.UseVisualStyleBackColor = False
        '
        'picStart
        '
        Me.picStart.BackgroundImage = CType(resources.GetObject("picStart.BackgroundImage"), System.Drawing.Image)
        Me.picStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picStart.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.picStart.Location = New System.Drawing.Point(998, -12)
        Me.picStart.Name = "picStart"
        Me.picStart.Size = New System.Drawing.Size(1024, 731)
        Me.picStart.TabIndex = 160
        Me.picStart.TabStop = False
        '
        'btnEQP
        '
        Me.btnEQP.BackColor = System.Drawing.SystemColors.Window
        Me.btnEQP.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEQP.Location = New System.Drawing.Point(734, 345)
        Me.btnEQP.Name = "btnEQP"
        Me.btnEQP.Size = New System.Drawing.Size(75, 33)
        Me.btnEQP.TabIndex = 161
        Me.btnEQP.Text = "Equip"
        Me.btnEQP.UseVisualStyleBackColor = False
        '
        'btnRUN
        '
        Me.btnRUN.BackColor = System.Drawing.Color.Black
        Me.btnRUN.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRUN.ForeColor = System.Drawing.Color.White
        Me.btnRUN.Location = New System.Drawing.Point(543, 419)
        Me.btnRUN.Name = "btnRUN"
        Me.btnRUN.Size = New System.Drawing.Size(86, 36)
        Me.btnRUN.TabIndex = 159
        Me.btnRUN.Text = "Run"
        Me.btnRUN.UseVisualStyleBackColor = False
        Me.btnRUN.Visible = False
        '
        'btnMG
        '
        Me.btnMG.BackColor = System.Drawing.Color.Black
        Me.btnMG.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMG.ForeColor = System.Drawing.Color.White
        Me.btnMG.Location = New System.Drawing.Point(336, 419)
        Me.btnMG.Name = "btnMG"
        Me.btnMG.Size = New System.Drawing.Size(90, 36)
        Me.btnMG.TabIndex = 158
        Me.btnMG.Text = "Magic"
        Me.btnMG.UseVisualStyleBackColor = False
        Me.btnMG.Visible = False
        '
        'btnATK
        '
        Me.btnATK.BackColor = System.Drawing.Color.Black
        Me.btnATK.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnATK.ForeColor = System.Drawing.Color.White
        Me.btnATK.Location = New System.Drawing.Point(236, 419)
        Me.btnATK.Name = "btnATK"
        Me.btnATK.Size = New System.Drawing.Size(89, 36)
        Me.btnATK.TabIndex = 156
        Me.btnATK.Text = "Attack"
        Me.btnATK.UseVisualStyleBackColor = False
        Me.btnATK.Visible = False
        '
        'lblSPD
        '
        Me.lblSPD.AutoSize = True
        Me.lblSPD.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSPD.ForeColor = System.Drawing.Color.White
        Me.lblSPD.Location = New System.Drawing.Point(5, 62)
        Me.lblSPD.Name = "lblSPD"
        Me.lblSPD.Size = New System.Drawing.Size(77, 14)
        Me.lblSPD.TabIndex = 154
        Me.lblSPD.Text = "SPD = TEMP"
        '
        'lblWIL
        '
        Me.lblWIL.AutoSize = True
        Me.lblWIL.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWIL.ForeColor = System.Drawing.Color.White
        Me.lblWIL.Location = New System.Drawing.Point(5, 81)
        Me.lblWIL.Name = "lblWIL"
        Me.lblWIL.Size = New System.Drawing.Size(84, 14)
        Me.lblWIL.TabIndex = 153
        Me.lblWIL.Text = "WILL = TEMP"
        '
        'lblDEF
        '
        Me.lblDEF.AutoSize = True
        Me.lblDEF.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDEF.ForeColor = System.Drawing.Color.White
        Me.lblDEF.Location = New System.Drawing.Point(5, 43)
        Me.lblDEF.Name = "lblDEF"
        Me.lblDEF.Size = New System.Drawing.Size(77, 14)
        Me.lblDEF.TabIndex = 152
        Me.lblDEF.Text = "DEF = TEMP"
        '
        'lblATK
        '
        Me.lblATK.AutoSize = True
        Me.lblATK.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblATK.ForeColor = System.Drawing.Color.White
        Me.lblATK.Location = New System.Drawing.Point(5, 24)
        Me.lblATK.Name = "lblATK"
        Me.lblATK.Size = New System.Drawing.Size(77, 14)
        Me.lblATK.TabIndex = 151
        Me.lblATK.Text = "ATK = TEMP"
        '
        'lblLevel
        '
        Me.lblLevel.AutoSize = True
        Me.lblLevel.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLevel.ForeColor = System.Drawing.Color.White
        Me.lblLevel.Location = New System.Drawing.Point(5, 6)
        Me.lblLevel.Name = "lblLevel"
        Me.lblLevel.Size = New System.Drawing.Size(77, 14)
        Me.lblLevel.TabIndex = 150
        Me.lblLevel.Text = "Level TEMP"
        '
        'lblMana
        '
        Me.lblMana.Font = New System.Drawing.Font("Consolas", 8.150944!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMana.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.lblMana.Location = New System.Drawing.Point(34, 23)
        Me.lblMana.Name = "lblMana"
        Me.lblMana.Size = New System.Drawing.Size(231, 15)
        Me.lblMana.TabIndex = 147
        Me.lblMana.Text = "||||||||||||||||Mana = TEMP|||||||||||||||||||||||||"
        Me.lblMana.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblHealth
        '
        Me.lblHealth.Font = New System.Drawing.Font("Consolas", 8.150944!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHealth.ForeColor = System.Drawing.Color.White
        Me.lblHealth.Location = New System.Drawing.Point(34, 6)
        Me.lblHealth.Name = "lblHealth"
        Me.lblHealth.Size = New System.Drawing.Size(231, 15)
        Me.lblHealth.TabIndex = 146
        Me.lblHealth.Text = "||||||||||||||||||||Health = TEMP||||||||||||||||||||||||||||" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblHealth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNameTitle
        '
        Me.lblNameTitle.BackColor = System.Drawing.Color.Black
        Me.lblNameTitle.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNameTitle.ForeColor = System.Drawing.Color.White
        Me.lblNameTitle.Location = New System.Drawing.Point(732, 16)
        Me.lblNameTitle.Margin = New System.Windows.Forms.Padding(3)
        Me.lblNameTitle.MaximumSize = New System.Drawing.Size(270, 20)
        Me.lblNameTitle.Name = "lblNameTitle"
        Me.lblNameTitle.Size = New System.Drawing.Size(270, 20)
        Me.lblNameTitle.TabIndex = 145
        Me.lblNameTitle.Text = "PLACEHOLDERTEXTiiiiiiiiiiiiii" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblNameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.Font = New System.Drawing.Font("Consolas", 10.86792!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(730, 395)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 18)
        Me.Label1.TabIndex = 144
        Me.Label1.Text = "Inventory:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnUse
        '
        Me.btnUse.BackColor = System.Drawing.SystemColors.Window
        Me.btnUse.Enabled = False
        Me.btnUse.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUse.Location = New System.Drawing.Point(740, 606)
        Me.btnUse.Name = "btnUse"
        Me.btnUse.Size = New System.Drawing.Size(75, 33)
        Me.btnUse.TabIndex = 143
        Me.btnUse.Text = "Use"
        Me.btnUse.UseVisualStyleBackColor = False
        '
        'lstInventory
        '
        Me.lstInventory.BackColor = System.Drawing.Color.Black
        Me.lstInventory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.lstInventory.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstInventory.ForeColor = System.Drawing.Color.White
        Me.lstInventory.FormattingEnabled = True
        Me.lstInventory.ItemHeight = 14
        Me.lstInventory.Location = New System.Drawing.Point(734, 419)
        Me.lstInventory.Name = "lstInventory"
        Me.lstInventory.Size = New System.Drawing.Size(262, 172)
        Me.lstInventory.TabIndex = 142
        '
        'lstLog
        '
        Me.lstLog.BackColor = System.Drawing.Color.Black
        Me.lstLog.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstLog.ForeColor = System.Drawing.Color.White
        Me.lstLog.FormattingEnabled = True
        Me.lstLog.ItemHeight = 14
        Me.lstLog.Location = New System.Drawing.Point(13, 510)
        Me.lstLog.Name = "lstLog"
        Me.lstLog.Size = New System.Drawing.Size(701, 158)
        Me.lstLog.TabIndex = 141
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Black
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.DebugToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(3, 4)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(156, 24)
        Me.MenuStrip1.TabIndex = 140
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.BackColor = System.Drawing.Color.Black
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.LoadToolStripMenuItem, Me.NewGameToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FileToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(47, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.BackColor = System.Drawing.Color.Black
        Me.SaveToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'LoadToolStripMenuItem
        '
        Me.LoadToolStripMenuItem.BackColor = System.Drawing.Color.Black
        Me.LoadToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.LoadToolStripMenuItem.Name = "LoadToolStripMenuItem"
        Me.LoadToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.LoadToolStripMenuItem.Text = "Load"
        '
        'NewGameToolStripMenuItem
        '
        Me.NewGameToolStripMenuItem.BackColor = System.Drawing.Color.Black
        Me.NewGameToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.NewGameToolStripMenuItem.Name = "NewGameToolStripMenuItem"
        Me.NewGameToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.NewGameToolStripMenuItem.Text = "New Game"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.BackColor = System.Drawing.Color.Black
        Me.ExitToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpToolStripMenuItem1, Me.StatInfoToolStripMenuItem, Me.ReportToolStripMenuItem, Me.InfoToolStripMenuItem, Me.RunAutomatedTestsToolStripMenuItem})
        Me.HelpToolStripMenuItem.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(47, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'HelpToolStripMenuItem1
        '
        Me.HelpToolStripMenuItem1.BackColor = System.Drawing.Color.Black
        Me.HelpToolStripMenuItem1.ForeColor = System.Drawing.Color.White
        Me.HelpToolStripMenuItem1.Name = "HelpToolStripMenuItem1"
        Me.HelpToolStripMenuItem1.Size = New System.Drawing.Size(137, 22)
        Me.HelpToolStripMenuItem1.Text = "Controls"
        '
        'StatInfoToolStripMenuItem
        '
        Me.StatInfoToolStripMenuItem.BackColor = System.Drawing.Color.Black
        Me.StatInfoToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.StatInfoToolStripMenuItem.Name = "StatInfoToolStripMenuItem"
        Me.StatInfoToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.StatInfoToolStripMenuItem.Text = "Stat Info"
        Me.StatInfoToolStripMenuItem.Visible = False
        '
        'ReportToolStripMenuItem
        '
        Me.ReportToolStripMenuItem.BackColor = System.Drawing.Color.Black
        Me.ReportToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        Me.ReportToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.ReportToolStripMenuItem.Text = "Report"
        '
        'InfoToolStripMenuItem
        '
        Me.InfoToolStripMenuItem.BackColor = System.Drawing.Color.Black
        Me.InfoToolStripMenuItem.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfoToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.InfoToolStripMenuItem.Name = "InfoToolStripMenuItem"
        Me.InfoToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.InfoToolStripMenuItem.Text = "Info"
        '
        'RunAutomatedTestsToolStripMenuItem
        '
        Me.RunAutomatedTestsToolStripMenuItem.BackColor = System.Drawing.Color.Black
        Me.RunAutomatedTestsToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.RunAutomatedTestsToolStripMenuItem.Name = "RunAutomatedTestsToolStripMenuItem"
        Me.RunAutomatedTestsToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.RunAutomatedTestsToolStripMenuItem.Text = "Run Tests"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SettingsToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(75, 20)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        Me.SettingsToolStripMenuItem.Visible = False
        '
        'DebugToolStripMenuItem1
        '
        Me.DebugToolStripMenuItem1.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DebugToolStripMenuItem1.ForeColor = System.Drawing.Color.White
        Me.DebugToolStripMenuItem1.Name = "DebugToolStripMenuItem1"
        Me.DebugToolStripMenuItem1.Size = New System.Drawing.Size(54, 20)
        Me.DebugToolStripMenuItem1.Text = "Debug"
        '
        'picPortrait
        '
        Me.picPortrait.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picPortrait.Location = New System.Drawing.Point(871, 150)
        Me.picPortrait.Name = "picPortrait"
        Me.picPortrait.Size = New System.Drawing.Size(125, 189)
        Me.picPortrait.TabIndex = 208
        Me.picPortrait.TabStop = False
        '
        'btnEXM
        '
        Me.btnEXM.BackColor = System.Drawing.SystemColors.Window
        Me.btnEXM.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEXM.Location = New System.Drawing.Point(860, 345)
        Me.btnEXM.Name = "btnEXM"
        Me.btnEXM.Size = New System.Drawing.Size(136, 33)
        Me.btnEXM.TabIndex = 209
        Me.btnEXM.Text = "Examine Self"
        Me.btnEXM.UseVisualStyleBackColor = False
        '
        'lblGold
        '
        Me.lblGold.AutoSize = True
        Me.lblGold.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGold.ForeColor = System.Drawing.Color.White
        Me.lblGold.Location = New System.Drawing.Point(5, 119)
        Me.lblGold.Name = "lblGold"
        Me.lblGold.Size = New System.Drawing.Size(105, 14)
        Me.lblGold.TabIndex = 210
        Me.lblGold.Text = "GOLD = 999999+"
        '
        'picShopkeepTile
        '
        Me.picShopkeepTile.BackgroundImage = CType(resources.GetObject("picShopkeepTile.BackgroundImage"), System.Drawing.Image)
        Me.picShopkeepTile.Location = New System.Drawing.Point(497, 71)
        Me.picShopkeepTile.Name = "picShopkeepTile"
        Me.picShopkeepTile.Size = New System.Drawing.Size(15, 15)
        Me.picShopkeepTile.TabIndex = 211
        Me.picShopkeepTile.TabStop = False
        Me.picShopkeepTile.Visible = False
        '
        'picLust1
        '
        Me.picLust1.BackgroundImage = CType(resources.GetObject("picLust1.BackgroundImage"), System.Drawing.Image)
        Me.picLust1.Location = New System.Drawing.Point(371, 29)
        Me.picLust1.Name = "picLust1"
        Me.picLust1.Size = New System.Drawing.Size(15, 15)
        Me.picLust1.TabIndex = 215
        Me.picLust1.TabStop = False
        Me.picLust1.Visible = False
        '
        'picLust2
        '
        Me.picLust2.BackgroundImage = CType(resources.GetObject("picLust2.BackgroundImage"), System.Drawing.Image)
        Me.picLust2.Location = New System.Drawing.Point(392, 29)
        Me.picLust2.Name = "picLust2"
        Me.picLust2.Size = New System.Drawing.Size(15, 15)
        Me.picLust2.TabIndex = 216
        Me.picLust2.TabStop = False
        Me.picLust2.Visible = False
        '
        'picLust3
        '
        Me.picLust3.BackgroundImage = CType(resources.GetObject("picLust3.BackgroundImage"), System.Drawing.Image)
        Me.picLust3.Location = New System.Drawing.Point(413, 29)
        Me.picLust3.Name = "picLust3"
        Me.picLust3.Size = New System.Drawing.Size(15, 15)
        Me.picLust3.TabIndex = 217
        Me.picLust3.TabStop = False
        Me.picLust3.Visible = False
        '
        'picLust4
        '
        Me.picLust4.BackgroundImage = CType(resources.GetObject("picLust4.BackgroundImage"), System.Drawing.Image)
        Me.picLust4.Location = New System.Drawing.Point(372, 50)
        Me.picLust4.Name = "picLust4"
        Me.picLust4.Size = New System.Drawing.Size(15, 15)
        Me.picLust4.TabIndex = 218
        Me.picLust4.TabStop = False
        Me.picLust4.Visible = False
        '
        'picLust5
        '
        Me.picLust5.Location = New System.Drawing.Point(393, 50)
        Me.picLust5.Name = "picLust5"
        Me.picLust5.Size = New System.Drawing.Size(15, 15)
        Me.picLust5.TabIndex = 219
        Me.picLust5.TabStop = False
        Me.picLust5.Visible = False
        '
        'btnIns
        '
        Me.btnIns.BackColor = System.Drawing.SystemColors.Window
        Me.btnIns.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIns.Location = New System.Drawing.Point(939, 646)
        Me.btnIns.Name = "btnIns"
        Me.btnIns.Size = New System.Drawing.Size(38, 33)
        Me.btnIns.TabIndex = 230
        Me.btnIns.Text = ";"
        Me.btnIns.UseVisualStyleBackColor = False
        '
        'btnR
        '
        Me.btnR.BackColor = System.Drawing.SystemColors.Window
        Me.btnR.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnR.Location = New System.Drawing.Point(873, 646)
        Me.btnR.Name = "btnR"
        Me.btnR.Size = New System.Drawing.Size(38, 33)
        Me.btnR.TabIndex = 229
        Me.btnR.Text = ">"
        Me.btnR.UseVisualStyleBackColor = False
        '
        'btnU
        '
        Me.btnU.BackColor = System.Drawing.SystemColors.Window
        Me.btnU.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnU.Location = New System.Drawing.Point(829, 646)
        Me.btnU.Name = "btnU"
        Me.btnU.Size = New System.Drawing.Size(38, 33)
        Me.btnU.TabIndex = 228
        Me.btnU.Text = "ʌ"
        Me.btnU.UseVisualStyleBackColor = False
        '
        'BtnD
        '
        Me.BtnD.BackColor = System.Drawing.SystemColors.Window
        Me.BtnD.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnD.Location = New System.Drawing.Point(785, 646)
        Me.BtnD.Name = "BtnD"
        Me.BtnD.Size = New System.Drawing.Size(38, 33)
        Me.BtnD.TabIndex = 227
        Me.BtnD.Text = "v"
        Me.BtnD.UseVisualStyleBackColor = False
        '
        'btnLft
        '
        Me.btnLft.BackColor = System.Drawing.SystemColors.Window
        Me.btnLft.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLft.Location = New System.Drawing.Point(741, 646)
        Me.btnLft.Name = "btnLft"
        Me.btnLft.Size = New System.Drawing.Size(38, 33)
        Me.btnLft.TabIndex = 226
        Me.btnLft.Text = "<"
        Me.btnLft.UseVisualStyleBackColor = False
        '
        'cboxSpec
        '
        Me.cboxSpec.BackColor = System.Drawing.Color.Black
        Me.cboxSpec.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboxSpec.ForeColor = System.Drawing.Color.White
        Me.cboxSpec.FormattingEnabled = True
        Me.cboxSpec.Location = New System.Drawing.Point(237, 462)
        Me.cboxSpec.Name = "cboxSpec"
        Me.cboxSpec.Size = New System.Drawing.Size(149, 21)
        Me.cboxSpec.TabIndex = 231
        Me.cboxSpec.Text = "-- Select --"
        Me.cboxSpec.Visible = False
        '
        'btnSpec
        '
        Me.btnSpec.BackColor = System.Drawing.Color.Black
        Me.btnSpec.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSpec.ForeColor = System.Drawing.Color.White
        Me.btnSpec.Location = New System.Drawing.Point(392, 461)
        Me.btnSpec.Name = "btnSpec"
        Me.btnSpec.Size = New System.Drawing.Size(90, 36)
        Me.btnSpec.TabIndex = 232
        Me.btnSpec.Text = "Special"
        Me.btnSpec.UseVisualStyleBackColor = False
        Me.btnSpec.Visible = False
        '
        'btnFilter
        '
        Me.btnFilter.BackColor = System.Drawing.SystemColors.Window
        Me.btnFilter.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFilter.Location = New System.Drawing.Point(888, 384)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(108, 28)
        Me.btnFilter.TabIndex = 233
        Me.btnFilter.Text = "Filter"
        Me.btnFilter.UseVisualStyleBackColor = False
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.SystemColors.Window
        Me.btnOk.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Location = New System.Drawing.Point(896, 556)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(94, 29)
        Me.btnOk.TabIndex = 235
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = False
        Me.btnOk.Visible = False
        '
        'chkUseable
        '
        Me.chkUseable.AutoSize = True
        Me.chkUseable.Checked = True
        Me.chkUseable.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUseable.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkUseable.ForeColor = System.Drawing.Color.White
        Me.chkUseable.Location = New System.Drawing.Point(738, 422)
        Me.chkUseable.Name = "chkUseable"
        Me.chkUseable.Size = New System.Drawing.Size(83, 21)
        Me.chkUseable.TabIndex = 236
        Me.chkUseable.Text = "Useable"
        Me.chkUseable.UseVisualStyleBackColor = True
        Me.chkUseable.Visible = False
        '
        'chkPotion
        '
        Me.chkPotion.AutoSize = True
        Me.chkPotion.Checked = True
        Me.chkPotion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPotion.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPotion.ForeColor = System.Drawing.Color.White
        Me.chkPotion.Location = New System.Drawing.Point(738, 444)
        Me.chkPotion.Name = "chkPotion"
        Me.chkPotion.Size = New System.Drawing.Size(83, 21)
        Me.chkPotion.TabIndex = 237
        Me.chkPotion.Text = "Potions"
        Me.chkPotion.UseVisualStyleBackColor = True
        Me.chkPotion.Visible = False
        '
        'chkFood
        '
        Me.chkFood.AutoSize = True
        Me.chkFood.Checked = True
        Me.chkFood.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFood.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFood.ForeColor = System.Drawing.Color.White
        Me.chkFood.Location = New System.Drawing.Point(738, 466)
        Me.chkFood.Name = "chkFood"
        Me.chkFood.Size = New System.Drawing.Size(59, 21)
        Me.chkFood.TabIndex = 238
        Me.chkFood.Text = "Food"
        Me.chkFood.UseVisualStyleBackColor = True
        Me.chkFood.Visible = False
        '
        'frmArmor
        '
        Me.frmArmor.AutoSize = True
        Me.frmArmor.Checked = True
        Me.frmArmor.CheckState = System.Windows.Forms.CheckState.Checked
        Me.frmArmor.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frmArmor.ForeColor = System.Drawing.Color.White
        Me.frmArmor.Location = New System.Drawing.Point(738, 488)
        Me.frmArmor.Name = "frmArmor"
        Me.frmArmor.Size = New System.Drawing.Size(67, 21)
        Me.frmArmor.TabIndex = 239
        Me.frmArmor.Text = "Armor"
        Me.frmArmor.UseVisualStyleBackColor = True
        Me.frmArmor.Visible = False
        '
        'chkWeapon
        '
        Me.chkWeapon.AutoSize = True
        Me.chkWeapon.Checked = True
        Me.chkWeapon.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkWeapon.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkWeapon.ForeColor = System.Drawing.Color.White
        Me.chkWeapon.Location = New System.Drawing.Point(738, 510)
        Me.chkWeapon.Name = "chkWeapon"
        Me.chkWeapon.Size = New System.Drawing.Size(75, 21)
        Me.chkWeapon.TabIndex = 240
        Me.chkWeapon.Text = "Weapon"
        Me.chkWeapon.UseVisualStyleBackColor = True
        Me.chkWeapon.Visible = False
        '
        'chkMisc
        '
        Me.chkMisc.AutoSize = True
        Me.chkMisc.Checked = True
        Me.chkMisc.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMisc.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMisc.ForeColor = System.Drawing.Color.White
        Me.chkMisc.Location = New System.Drawing.Point(738, 554)
        Me.chkMisc.Name = "chkMisc"
        Me.chkMisc.Size = New System.Drawing.Size(59, 21)
        Me.chkMisc.TabIndex = 241
        Me.chkMisc.Text = "Misc"
        Me.chkMisc.UseVisualStyleBackColor = True
        Me.chkMisc.Visible = False
        '
        'btnAll
        '
        Me.btnAll.BackColor = System.Drawing.SystemColors.Window
        Me.btnAll.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAll.Location = New System.Drawing.Point(941, 424)
        Me.btnAll.Name = "btnAll"
        Me.btnAll.Size = New System.Drawing.Size(49, 29)
        Me.btnAll.TabIndex = 242
        Me.btnAll.Text = "All"
        Me.btnAll.UseVisualStyleBackColor = False
        Me.btnAll.Visible = False
        '
        'btnNone
        '
        Me.btnNone.BackColor = System.Drawing.SystemColors.Window
        Me.btnNone.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNone.Location = New System.Drawing.Point(890, 424)
        Me.btnNone.Name = "btnNone"
        Me.btnNone.Size = New System.Drawing.Size(48, 29)
        Me.btnNone.TabIndex = 243
        Me.btnNone.Text = "None"
        Me.btnNone.UseVisualStyleBackColor = False
        Me.btnNone.Visible = False
        '
        'picTrap
        '
        Me.picTrap.BackgroundImage = CType(resources.GetObject("picTrap.BackgroundImage"), System.Drawing.Image)
        Me.picTrap.Location = New System.Drawing.Point(623, 29)
        Me.picTrap.Name = "picTrap"
        Me.picTrap.Size = New System.Drawing.Size(15, 15)
        Me.picTrap.TabIndex = 244
        Me.picTrap.TabStop = False
        Me.picTrap.Visible = False
        '
        'btnSettings
        '
        Me.btnSettings.BackColor = System.Drawing.Color.Black
        Me.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSettings.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSettings.ForeColor = System.Drawing.Color.White
        Me.btnSettings.Location = New System.Drawing.Point(549, 403)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(99, 39)
        Me.btnSettings.TabIndex = 246
        Me.btnSettings.Text = "Settings"
        Me.btnSettings.UseVisualStyleBackColor = False
        '
        'btnT
        '
        Me.btnT.BackColor = System.Drawing.Color.Black
        Me.btnT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnT.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnT.ForeColor = System.Drawing.Color.White
        Me.btnT.Location = New System.Drawing.Point(441, 403)
        Me.btnT.Name = "btnT"
        Me.btnT.Size = New System.Drawing.Size(99, 39)
        Me.btnT.TabIndex = 247
        Me.btnT.Text = "Tutorial"
        Me.btnT.UseVisualStyleBackColor = False
        Me.btnT.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Black
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(335, 444)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(313, 39)
        Me.Button1.TabIndex = 248
        Me.Button1.Text = "Custom Content"
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'btnS8
        '
        Me.btnS8.BackColor = System.Drawing.Color.Black
        Me.btnS8.BackgroundImage = CType(resources.GetObject("btnS8.BackgroundImage"), System.Drawing.Image)
        Me.btnS8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnS8.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnS8.ForeColor = System.Drawing.Color.White
        Me.btnS8.Location = New System.Drawing.Point(438, 208)
        Me.btnS8.Name = "btnS8"
        Me.btnS8.Size = New System.Drawing.Size(125, 189)
        Me.btnS8.TabIndex = 257
        Me.btnS8.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Black
        Me.btnCancel.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(150, 412)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(272, 37)
        Me.btnCancel.TabIndex = 256
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnS7
        '
        Me.btnS7.BackColor = System.Drawing.Color.Black
        Me.btnS7.BackgroundImage = CType(resources.GetObject("btnS7.BackgroundImage"), System.Drawing.Image)
        Me.btnS7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnS7.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnS7.ForeColor = System.Drawing.Color.White
        Me.btnS7.Location = New System.Drawing.Point(295, 208)
        Me.btnS7.Name = "btnS7"
        Me.btnS7.Size = New System.Drawing.Size(125, 189)
        Me.btnS7.TabIndex = 255
        Me.btnS7.UseVisualStyleBackColor = False
        '
        'btnS6
        '
        Me.btnS6.BackColor = System.Drawing.Color.Black
        Me.btnS6.BackgroundImage = CType(resources.GetObject("btnS6.BackgroundImage"), System.Drawing.Image)
        Me.btnS6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnS6.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnS6.ForeColor = System.Drawing.Color.White
        Me.btnS6.Location = New System.Drawing.Point(150, 208)
        Me.btnS6.Name = "btnS6"
        Me.btnS6.Size = New System.Drawing.Size(125, 189)
        Me.btnS6.TabIndex = 254
        Me.btnS6.UseVisualStyleBackColor = False
        '
        'btnS5
        '
        Me.btnS5.BackColor = System.Drawing.Color.Black
        Me.btnS5.BackgroundImage = CType(resources.GetObject("btnS5.BackgroundImage"), System.Drawing.Image)
        Me.btnS5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnS5.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnS5.ForeColor = System.Drawing.Color.White
        Me.btnS5.Location = New System.Drawing.Point(8, 208)
        Me.btnS5.Name = "btnS5"
        Me.btnS5.Size = New System.Drawing.Size(125, 189)
        Me.btnS5.TabIndex = 253
        Me.btnS5.UseVisualStyleBackColor = False
        '
        'btnS4
        '
        Me.btnS4.BackColor = System.Drawing.Color.Black
        Me.btnS4.BackgroundImage = CType(resources.GetObject("btnS4.BackgroundImage"), System.Drawing.Image)
        Me.btnS4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnS4.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnS4.ForeColor = System.Drawing.Color.White
        Me.btnS4.Location = New System.Drawing.Point(438, 5)
        Me.btnS4.Name = "btnS4"
        Me.btnS4.Size = New System.Drawing.Size(125, 189)
        Me.btnS4.TabIndex = 252
        Me.btnS4.UseVisualStyleBackColor = False
        '
        'btnS3
        '
        Me.btnS3.BackColor = System.Drawing.Color.Black
        Me.btnS3.BackgroundImage = CType(resources.GetObject("btnS3.BackgroundImage"), System.Drawing.Image)
        Me.btnS3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnS3.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnS3.ForeColor = System.Drawing.Color.White
        Me.btnS3.Location = New System.Drawing.Point(295, 5)
        Me.btnS3.Name = "btnS3"
        Me.btnS3.Size = New System.Drawing.Size(125, 189)
        Me.btnS3.TabIndex = 251
        Me.btnS3.UseVisualStyleBackColor = False
        '
        'btnS2
        '
        Me.btnS2.BackColor = System.Drawing.Color.Black
        Me.btnS2.BackgroundImage = CType(resources.GetObject("btnS2.BackgroundImage"), System.Drawing.Image)
        Me.btnS2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnS2.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnS2.ForeColor = System.Drawing.Color.White
        Me.btnS2.Location = New System.Drawing.Point(150, 5)
        Me.btnS2.Name = "btnS2"
        Me.btnS2.Size = New System.Drawing.Size(125, 189)
        Me.btnS2.TabIndex = 250
        Me.btnS2.UseVisualStyleBackColor = False
        '
        'btnS1
        '
        Me.btnS1.BackColor = System.Drawing.Color.Black
        Me.btnS1.BackgroundImage = CType(resources.GetObject("btnS1.BackgroundImage"), System.Drawing.Image)
        Me.btnS1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnS1.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnS1.ForeColor = System.Drawing.Color.White
        Me.btnS1.Location = New System.Drawing.Point(8, 5)
        Me.btnS1.Name = "btnS1"
        Me.btnS1.Size = New System.Drawing.Size(125, 189)
        Me.btnS1.TabIndex = 249
        Me.btnS1.UseVisualStyleBackColor = False
        '
        'pnlSaveLoad
        '
        Me.pnlSaveLoad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSaveLoad.Controls.Add(Me.btnS1)
        Me.pnlSaveLoad.Controls.Add(Me.btnCancel)
        Me.pnlSaveLoad.Controls.Add(Me.btnS8)
        Me.pnlSaveLoad.Controls.Add(Me.btnS7)
        Me.pnlSaveLoad.Controls.Add(Me.btnS2)
        Me.pnlSaveLoad.Controls.Add(Me.btnS6)
        Me.pnlSaveLoad.Controls.Add(Me.btnS3)
        Me.pnlSaveLoad.Controls.Add(Me.btnS5)
        Me.pnlSaveLoad.Controls.Add(Me.btnS4)
        Me.pnlSaveLoad.Location = New System.Drawing.Point(1012, 12)
        Me.pnlSaveLoad.Name = "pnlSaveLoad"
        Me.pnlSaveLoad.Size = New System.Drawing.Size(568, 458)
        Me.pnlSaveLoad.TabIndex = 258
        Me.pnlSaveLoad.Visible = False
        '
        'picSheep
        '
        Me.picSheep.BackgroundImage = CType(resources.GetObject("picSheep.BackgroundImage"), System.Drawing.Image)
        Me.picSheep.Location = New System.Drawing.Point(45, 91)
        Me.picSheep.Name = "picSheep"
        Me.picSheep.Size = New System.Drawing.Size(15, 15)
        Me.picSheep.TabIndex = 259
        Me.picSheep.TabStop = False
        Me.picSheep.Visible = False
        '
        'picFrog
        '
        Me.picFrog.BackgroundImage = CType(resources.GetObject("picFrog.BackgroundImage"), System.Drawing.Image)
        Me.picFrog.Location = New System.Drawing.Point(66, 91)
        Me.picFrog.Name = "picFrog"
        Me.picFrog.Size = New System.Drawing.Size(15, 15)
        Me.picFrog.TabIndex = 260
        Me.picFrog.TabStop = False
        Me.picFrog.Visible = False
        '
        'picTileF
        '
        Me.picTileF.BackgroundImage = CType(resources.GetObject("picTileF.BackgroundImage"), System.Drawing.Image)
        Me.picTileF.Location = New System.Drawing.Point(497, 94)
        Me.picTileF.Name = "picTileF"
        Me.picTileF.Size = New System.Drawing.Size(15, 15)
        Me.picTileF.TabIndex = 261
        Me.picTileF.TabStop = False
        Me.picTileF.Visible = False
        '
        'picTree
        '
        Me.picTree.BackgroundImage = CType(resources.GetObject("picTree.BackgroundImage"), System.Drawing.Image)
        Me.picTree.Location = New System.Drawing.Point(518, 95)
        Me.picTree.Name = "picTree"
        Me.picTree.Size = New System.Drawing.Size(15, 15)
        Me.picTree.TabIndex = 262
        Me.picTree.TabStop = False
        Me.picTree.Visible = False
        '
        'picPlayerf
        '
        Me.picPlayerf.BackgroundImage = CType(resources.GetObject("picPlayerf.BackgroundImage"), System.Drawing.Image)
        Me.picPlayerf.Location = New System.Drawing.Point(518, 115)
        Me.picPlayerf.Name = "picPlayerf"
        Me.picPlayerf.Size = New System.Drawing.Size(15, 15)
        Me.picPlayerf.TabIndex = 263
        Me.picPlayerf.TabStop = False
        Me.picPlayerf.Visible = False
        '
        'picLadderf
        '
        Me.picLadderf.BackgroundImage = CType(resources.GetObject("picLadderf.BackgroundImage"), System.Drawing.Image)
        Me.picLadderf.Location = New System.Drawing.Point(560, 95)
        Me.picLadderf.Name = "picLadderf"
        Me.picLadderf.Size = New System.Drawing.Size(15, 15)
        Me.picLadderf.TabIndex = 264
        Me.picLadderf.TabStop = False
        Me.picLadderf.Visible = False
        '
        'picChestf
        '
        Me.picChestf.BackgroundImage = CType(resources.GetObject("picChestf.BackgroundImage"), System.Drawing.Image)
        Me.picChestf.Location = New System.Drawing.Point(539, 95)
        Me.picChestf.Name = "picChestf"
        Me.picChestf.Size = New System.Drawing.Size(15, 15)
        Me.picChestf.TabIndex = 265
        Me.picChestf.TabStop = False
        Me.picChestf.Visible = False
        '
        'picBimbof
        '
        Me.picBimbof.BackgroundImage = CType(resources.GetObject("picBimbof.BackgroundImage"), System.Drawing.Image)
        Me.picBimbof.Location = New System.Drawing.Point(497, 115)
        Me.picBimbof.Name = "picBimbof"
        Me.picBimbof.Size = New System.Drawing.Size(15, 15)
        Me.picBimbof.TabIndex = 266
        Me.picBimbof.TabStop = False
        Me.picBimbof.Visible = False
        '
        'picShopkeeperf
        '
        Me.picShopkeeperf.BackgroundImage = CType(resources.GetObject("picShopkeeperf.BackgroundImage"), System.Drawing.Image)
        Me.picShopkeeperf.Location = New System.Drawing.Point(497, 136)
        Me.picShopkeeperf.Name = "picShopkeeperf"
        Me.picShopkeeperf.Size = New System.Drawing.Size(15, 15)
        Me.picShopkeeperf.TabIndex = 267
        Me.picShopkeeperf.TabStop = False
        Me.picShopkeeperf.Visible = False
        '
        'picStatuef
        '
        Me.picStatuef.BackgroundImage = CType(resources.GetObject("picStatuef.BackgroundImage"), System.Drawing.Image)
        Me.picStatuef.Location = New System.Drawing.Point(539, 115)
        Me.picStatuef.Name = "picStatuef"
        Me.picStatuef.Size = New System.Drawing.Size(15, 15)
        Me.picStatuef.TabIndex = 268
        Me.picStatuef.TabStop = False
        Me.picStatuef.Visible = False
        '
        'picTrapf
        '
        Me.picTrapf.BackgroundImage = CType(resources.GetObject("picTrapf.BackgroundImage"), System.Drawing.Image)
        Me.picTrapf.Location = New System.Drawing.Point(623, 95)
        Me.picTrapf.Name = "picTrapf"
        Me.picTrapf.Size = New System.Drawing.Size(15, 15)
        Me.picTrapf.TabIndex = 269
        Me.picTrapf.TabStop = False
        Me.picTrapf.Visible = False
        '
        'tmrKeyCD
        '
        Me.tmrKeyCD.Interval = 40
        '
        'pnlCombat
        '
        Me.pnlCombat.BackColor = System.Drawing.Color.Black
        Me.pnlCombat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCombat.Controls.Add(Me.lblCombatEvents)
        Me.pnlCombat.Controls.Add(Me.Label2)
        Me.pnlCombat.Controls.Add(Me.lblPHealtDiff)
        Me.pnlCombat.Controls.Add(Me.lblEHealthChange)
        Me.pnlCombat.Controls.Add(Me.lblTurn)
        Me.pnlCombat.Controls.Add(Me.lblPHealth)
        Me.pnlCombat.Controls.Add(Me.lblPName)
        Me.pnlCombat.Controls.Add(Me.lblEHealth)
        Me.pnlCombat.Controls.Add(Me.lblEName)
        Me.pnlCombat.Controls.Add(Me.picPHealth)
        Me.pnlCombat.Controls.Add(Me.picEHbar)
        Me.pnlCombat.Location = New System.Drawing.Point(983, 50)
        Me.pnlCombat.Name = "pnlCombat"
        Me.pnlCombat.Size = New System.Drawing.Size(568, 362)
        Me.pnlCombat.TabIndex = 270
        Me.pnlCombat.Visible = False
        '
        'lblCombatEvents
        '
        Me.lblCombatEvents.BackColor = System.Drawing.Color.Black
        Me.lblCombatEvents.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblCombatEvents.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblCombatEvents.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCombatEvents.ForeColor = System.Drawing.Color.White
        Me.lblCombatEvents.Location = New System.Drawing.Point(9, 126)
        Me.lblCombatEvents.Multiline = True
        Me.lblCombatEvents.Name = "lblCombatEvents"
        Me.lblCombatEvents.ReadOnly = True
        Me.lblCombatEvents.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.lblCombatEvents.Size = New System.Drawing.Size(549, 205)
        Me.lblCombatEvents.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Consolas", 8.150944!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(5, 338)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(241, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Press a combat button to continue . . ."
        '
        'lblPHealtDiff
        '
        Me.lblPHealtDiff.AutoSize = True
        Me.lblPHealtDiff.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPHealtDiff.ForeColor = System.Drawing.Color.White
        Me.lblPHealtDiff.Location = New System.Drawing.Point(379, 88)
        Me.lblPHealtDiff.Name = "lblPHealtDiff"
        Me.lblPHealtDiff.Size = New System.Drawing.Size(35, 14)
        Me.lblPHealtDiff.TabIndex = 8
        Me.lblPHealtDiff.Text = "-999"
        '
        'lblEHealthChange
        '
        Me.lblEHealthChange.AutoSize = True
        Me.lblEHealthChange.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEHealthChange.ForeColor = System.Drawing.Color.White
        Me.lblEHealthChange.Location = New System.Drawing.Point(139, 91)
        Me.lblEHealthChange.Name = "lblEHealthChange"
        Me.lblEHealthChange.Size = New System.Drawing.Size(35, 14)
        Me.lblEHealthChange.TabIndex = 7
        Me.lblEHealthChange.Text = "-999"
        '
        'lblTurn
        '
        Me.lblTurn.AutoSize = True
        Me.lblTurn.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurn.ForeColor = System.Drawing.Color.White
        Me.lblTurn.Location = New System.Drawing.Point(236, 20)
        Me.lblTurn.Name = "lblTurn"
        Me.lblTurn.Size = New System.Drawing.Size(84, 14)
        Me.lblTurn.TabIndex = 6
        Me.lblTurn.Text = "Turn: 99999"
        '
        'lblPHealth
        '
        Me.lblPHealth.AutoSize = True
        Me.lblPHealth.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPHealth.ForeColor = System.Drawing.Color.White
        Me.lblPHealth.Location = New System.Drawing.Point(450, 48)
        Me.lblPHealth.Name = "lblPHealth"
        Me.lblPHealth.Size = New System.Drawing.Size(70, 14)
        Me.lblPHealth.TabIndex = 5
        Me.lblPHealth.Text = "9999/9999"
        '
        'lblPName
        '
        Me.lblPName.BackColor = System.Drawing.Color.Black
        Me.lblPName.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPName.ForeColor = System.Drawing.Color.White
        Me.lblPName.Location = New System.Drawing.Point(343, 14)
        Me.lblPName.Name = "lblPName"
        Me.lblPName.Size = New System.Drawing.Size(216, 27)
        Me.lblPName.TabIndex = 4
        Me.lblPName.Text = "PlayerName"
        Me.lblPName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEHealth
        '
        Me.lblEHealth.AutoSize = True
        Me.lblEHealth.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEHealth.ForeColor = System.Drawing.Color.White
        Me.lblEHealth.Location = New System.Drawing.Point(20, 49)
        Me.lblEHealth.Name = "lblEHealth"
        Me.lblEHealth.Size = New System.Drawing.Size(70, 14)
        Me.lblEHealth.TabIndex = 3
        Me.lblEHealth.Text = "9999/9999"
        '
        'lblEName
        '
        Me.lblEName.BackColor = System.Drawing.Color.Black
        Me.lblEName.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEName.ForeColor = System.Drawing.Color.White
        Me.lblEName.Location = New System.Drawing.Point(12, 14)
        Me.lblEName.Name = "lblEName"
        Me.lblEName.Size = New System.Drawing.Size(216, 27)
        Me.lblEName.TabIndex = 2
        Me.lblEName.Text = "EnemyName"
        Me.lblEName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'picPHealth
        '
        Me.picPHealth.BackColor = System.Drawing.Color.YellowGreen
        Me.picPHealth.Location = New System.Drawing.Point(374, 73)
        Me.picPHealth.Name = "picPHealth"
        Me.picPHealth.Size = New System.Drawing.Size(174, 15)
        Me.picPHealth.TabIndex = 1
        Me.picPHealth.TabStop = False
        '
        'picEHbar
        '
        Me.picEHbar.BackColor = System.Drawing.Color.YellowGreen
        Me.picEHbar.Location = New System.Drawing.Point(22, 73)
        Me.picEHbar.Name = "picEHbar"
        Me.picEHbar.Size = New System.Drawing.Size(174, 15)
        Me.picEHbar.TabIndex = 0
        Me.picEHbar.TabStop = False
        '
        'lblEvent
        '
        Me.lblEvent.AutoSize = True
        Me.lblEvent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEvent.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEvent.ForeColor = System.Drawing.Color.White
        Me.lblEvent.Location = New System.Drawing.Point(304, 120)
        Me.lblEvent.Name = "lblEvent"
        Me.lblEvent.Size = New System.Drawing.Size(2, 16)
        Me.lblEvent.TabIndex = 271
        Me.lblEvent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEvent.Visible = False
        '
        'picLoadBar
        '
        Me.picLoadBar.BackColor = System.Drawing.Color.White
        Me.picLoadBar.Location = New System.Drawing.Point(306, 361)
        Me.picLoadBar.Name = "picLoadBar"
        Me.picLoadBar.Size = New System.Drawing.Size(395, 17)
        Me.picLoadBar.TabIndex = 11
        Me.picLoadBar.TabStop = False
        Me.picLoadBar.Visible = False
        '
        'btnWait
        '
        Me.btnWait.BackColor = System.Drawing.Color.Black
        Me.btnWait.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWait.ForeColor = System.Drawing.Color.White
        Me.btnWait.Location = New System.Drawing.Point(448, 419)
        Me.btnWait.Name = "btnWait"
        Me.btnWait.Size = New System.Drawing.Size(86, 36)
        Me.btnWait.TabIndex = 272
        Me.btnWait.Text = "Wait"
        Me.btnWait.UseVisualStyleBackColor = False
        Me.btnWait.Visible = False
        '
        'picSWiz
        '
        Me.picSWiz.BackgroundImage = CType(resources.GetObject("picSWiz.BackgroundImage"), System.Drawing.Image)
        Me.picSWiz.Location = New System.Drawing.Point(518, 71)
        Me.picSWiz.Name = "picSWiz"
        Me.picSWiz.Size = New System.Drawing.Size(15, 15)
        Me.picSWiz.TabIndex = 273
        Me.picSWiz.TabStop = False
        Me.picSWiz.Visible = False
        '
        'picSWizF
        '
        Me.picSWizF.BackgroundImage = CType(resources.GetObject("picSWizF.BackgroundImage"), System.Drawing.Image)
        Me.picSWizF.Location = New System.Drawing.Point(518, 136)
        Me.picSWizF.Name = "picSWizF"
        Me.picSWizF.Size = New System.Drawing.Size(15, 15)
        Me.picSWizF.TabIndex = 274
        Me.picSWizF.TabStop = False
        Me.picSWizF.Visible = False
        '
        'pnlDescription
        '
        Me.pnlDescription.BackgroundImage = CType(resources.GetObject("pnlDescription.BackgroundImage"), System.Drawing.Image)
        Me.pnlDescription.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDescription.Controls.Add(Me.lblNext)
        Me.pnlDescription.Controls.Add(Me.picDescPort)
        Me.pnlDescription.Controls.Add(Me.txtPlayerDesc)
        Me.pnlDescription.Controls.Add(Me.Label5)
        Me.pnlDescription.Location = New System.Drawing.Point(1003, 129)
        Me.pnlDescription.Name = "pnlDescription"
        Me.pnlDescription.Size = New System.Drawing.Size(690, 502)
        Me.pnlDescription.TabIndex = 275
        Me.pnlDescription.Visible = False
        '
        'lblNext
        '
        Me.lblNext.AutoSize = True
        Me.lblNext.BackColor = System.Drawing.Color.Black
        Me.lblNext.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNext.ForeColor = System.Drawing.Color.White
        Me.lblNext.Location = New System.Drawing.Point(23, 473)
        Me.lblNext.Name = "lblNext"
        Me.lblNext.Size = New System.Drawing.Size(294, 14)
        Me.lblNext.TabIndex = 277
        Me.lblNext.Text = "Press any non-movement key to continue..."
        '
        'picDescPort
        '
        Me.picDescPort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picDescPort.Location = New System.Drawing.Point(524, 9)
        Me.picDescPort.Name = "picDescPort"
        Me.picDescPort.Size = New System.Drawing.Size(130, 480)
        Me.picDescPort.TabIndex = 276
        Me.picDescPort.TabStop = False
        '
        'txtPlayerDesc
        '
        Me.txtPlayerDesc.BackColor = System.Drawing.Color.Black
        Me.txtPlayerDesc.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlayerDesc.ForeColor = System.Drawing.Color.White
        Me.txtPlayerDesc.Location = New System.Drawing.Point(24, 21)
        Me.txtPlayerDesc.Multiline = True
        Me.txtPlayerDesc.Name = "txtPlayerDesc"
        Me.txtPlayerDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPlayerDesc.Size = New System.Drawing.Size(468, 446)
        Me.txtPlayerDesc.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Corbel", 8.150944!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(103, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(327, 13)
        Me.Label5.TabIndex = 278
        Me.Label5.Text = "NOTE: Full body image view is not complete, and still requires some work."
        '
        'ttCosts
        '
        Me.ttCosts.BackColor = System.Drawing.Color.Black
        Me.ttCosts.ForeColor = System.Drawing.Color.Firebrick
        '
        'picStairsLock
        '
        Me.picStairsLock.BackgroundImage = CType(resources.GetObject("picStairsLock.BackgroundImage"), System.Drawing.Image)
        Me.picStairsLock.Location = New System.Drawing.Point(602, 29)
        Me.picStairsLock.Name = "picStairsLock"
        Me.picStairsLock.Size = New System.Drawing.Size(15, 15)
        Me.picStairsLock.TabIndex = 276
        Me.picStairsLock.TabStop = False
        Me.picStairsLock.Visible = False
        '
        'picStairsBoss
        '
        Me.picStairsBoss.BackgroundImage = CType(resources.GetObject("picStairsBoss.BackgroundImage"), System.Drawing.Image)
        Me.picStairsBoss.Location = New System.Drawing.Point(581, 29)
        Me.picStairsBoss.Name = "picStairsBoss"
        Me.picStairsBoss.Size = New System.Drawing.Size(15, 15)
        Me.picStairsBoss.TabIndex = 277
        Me.picStairsBoss.TabStop = False
        Me.picStairsBoss.Visible = False
        '
        'picstairsbossf
        '
        Me.picstairsbossf.BackgroundImage = CType(resources.GetObject("picstairsbossf.BackgroundImage"), System.Drawing.Image)
        Me.picstairsbossf.Location = New System.Drawing.Point(581, 95)
        Me.picstairsbossf.Name = "picstairsbossf"
        Me.picstairsbossf.Size = New System.Drawing.Size(15, 15)
        Me.picstairsbossf.TabIndex = 279
        Me.picstairsbossf.TabStop = False
        Me.picstairsbossf.Visible = False
        '
        'picstairslockf
        '
        Me.picstairslockf.BackgroundImage = CType(resources.GetObject("picstairslockf.BackgroundImage"), System.Drawing.Image)
        Me.picstairslockf.Location = New System.Drawing.Point(602, 95)
        Me.picstairslockf.Name = "picstairslockf"
        Me.picstairslockf.Size = New System.Drawing.Size(15, 15)
        Me.picstairslockf.TabIndex = 280
        Me.picstairslockf.TabStop = False
        Me.picstairslockf.Visible = False
        '
        'pnlSelection
        '
        Me.pnlSelection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSelection.Controls.Add(Me.lblInstruc)
        Me.pnlSelection.Controls.Add(Me.lblWhat)
        Me.pnlSelection.Controls.Add(Me.Label3)
        Me.pnlSelection.Controls.Add(Me.lstSelec)
        Me.pnlSelection.Location = New System.Drawing.Point(1005, 87)
        Me.pnlSelection.Name = "pnlSelection"
        Me.pnlSelection.Size = New System.Drawing.Size(591, 293)
        Me.pnlSelection.TabIndex = 281
        Me.pnlSelection.Visible = False
        '
        'lblInstruc
        '
        Me.lblInstruc.AutoSize = True
        Me.lblInstruc.BackColor = System.Drawing.Color.Black
        Me.lblInstruc.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInstruc.ForeColor = System.Drawing.Color.White
        Me.lblInstruc.Location = New System.Drawing.Point(6, 61)
        Me.lblInstruc.Name = "lblInstruc"
        Me.lblInstruc.Size = New System.Drawing.Size(98, 42)
        Me.lblInstruc.TabIndex = 280
        Me.lblInstruc.Text = "Type the " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "corresponding" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "letter:"
        '
        'lblWhat
        '
        Me.lblWhat.AutoSize = True
        Me.lblWhat.BackColor = System.Drawing.Color.Black
        Me.lblWhat.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWhat.ForeColor = System.Drawing.Color.White
        Me.lblWhat.Location = New System.Drawing.Point(8, 8)
        Me.lblWhat.Name = "lblWhat"
        Me.lblWhat.Size = New System.Drawing.Size(77, 14)
        Me.lblWhat.TabIndex = 279
        Me.lblWhat.Text = "Verb what?"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Black
        Me.Label3.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(7, 262)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(189, 14)
        Me.Label3.TabIndex = 278
        Me.Label3.Text = "Press backspace to cancel."
        '
        'lstSelec
        '
        Me.lstSelec.BackColor = System.Drawing.Color.Black
        Me.lstSelec.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstSelec.ForeColor = System.Drawing.Color.White
        Me.lstSelec.FormattingEnabled = True
        Me.lstSelec.ItemHeight = 17
        Me.lstSelec.Items.AddRange(New Object() {"oooooooooooooooooooooooooooooo"})
        Me.lstSelec.Location = New System.Drawing.Point(239, 35)
        Me.lstSelec.Name = "lstSelec"
        Me.lstSelec.Size = New System.Drawing.Size(330, 208)
        Me.lstSelec.TabIndex = 142
        '
        'picBun
        '
        Me.picBun.BackgroundImage = CType(resources.GetObject("picBun.BackgroundImage"), System.Drawing.Image)
        Me.picBun.Location = New System.Drawing.Point(87, 91)
        Me.picBun.Name = "picBun"
        Me.picBun.Size = New System.Drawing.Size(15, 15)
        Me.picBun.TabIndex = 285
        Me.picBun.TabStop = False
        Me.picBun.Visible = False
        '
        'picPrin
        '
        Me.picPrin.BackgroundImage = CType(resources.GetObject("picPrin.BackgroundImage"), System.Drawing.Image)
        Me.picPrin.Location = New System.Drawing.Point(108, 91)
        Me.picPrin.Name = "picPrin"
        Me.picPrin.Size = New System.Drawing.Size(15, 15)
        Me.picPrin.TabIndex = 286
        Me.picPrin.TabStop = False
        Me.picPrin.Visible = False
        '
        'picmgp1
        '
        Me.picmgp1.BackgroundImage = CType(resources.GetObject("picmgp1.BackgroundImage"), System.Drawing.Image)
        Me.picmgp1.Location = New System.Drawing.Point(45, 70)
        Me.picmgp1.Name = "picmgp1"
        Me.picmgp1.Size = New System.Drawing.Size(15, 15)
        Me.picmgp1.TabIndex = 287
        Me.picmgp1.TabStop = False
        Me.picmgp1.Visible = False
        '
        'picDragonM
        '
        Me.picDragonM.BackgroundImage = CType(resources.GetObject("picDragonM.BackgroundImage"), System.Drawing.Image)
        Me.picDragonM.Location = New System.Drawing.Point(66, 70)
        Me.picDragonM.Name = "picDragonM"
        Me.picDragonM.Size = New System.Drawing.Size(15, 15)
        Me.picDragonM.TabIndex = 288
        Me.picDragonM.TabStop = False
        Me.picDragonM.Visible = False
        '
        'chkAcc
        '
        Me.chkAcc.AutoSize = True
        Me.chkAcc.Checked = True
        Me.chkAcc.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAcc.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAcc.ForeColor = System.Drawing.Color.White
        Me.chkAcc.Location = New System.Drawing.Point(738, 532)
        Me.chkAcc.Name = "chkAcc"
        Me.chkAcc.Size = New System.Drawing.Size(115, 21)
        Me.chkAcc.TabIndex = 289
        Me.chkAcc.Text = "Accessories"
        Me.chkAcc.UseVisualStyleBackColor = True
        Me.chkAcc.Visible = False
        '
        'picCrystal
        '
        Me.picCrystal.BackgroundImage = CType(resources.GetObject("picCrystal.BackgroundImage"), System.Drawing.Image)
        Me.picCrystal.Location = New System.Drawing.Point(560, 50)
        Me.picCrystal.Name = "picCrystal"
        Me.picCrystal.Size = New System.Drawing.Size(15, 15)
        Me.picCrystal.TabIndex = 290
        Me.picCrystal.TabStop = False
        Me.picCrystal.Visible = False
        '
        'picCrystalf
        '
        Me.picCrystalf.BackgroundImage = CType(resources.GetObject("picCrystalf.BackgroundImage"), System.Drawing.Image)
        Me.picCrystalf.Location = New System.Drawing.Point(560, 115)
        Me.picCrystalf.Name = "picCrystalf"
        Me.picCrystalf.Size = New System.Drawing.Size(15, 15)
        Me.picCrystalf.TabIndex = 291
        Me.picCrystalf.TabStop = False
        Me.picCrystalf.Visible = False
        '
        'btnAbout
        '
        Me.btnAbout.BackColor = System.Drawing.Color.Black
        Me.btnAbout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAbout.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAbout.ForeColor = System.Drawing.Color.White
        Me.btnAbout.Location = New System.Drawing.Point(441, 639)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(99, 39)
        Me.btnAbout.TabIndex = 292
        Me.btnAbout.Text = "About"
        Me.btnAbout.UseVisualStyleBackColor = False
        '
        'picPath
        '
        Me.picPath.BackgroundImage = CType(resources.GetObject("picPath.BackgroundImage"), System.Drawing.Image)
        Me.picPath.Location = New System.Drawing.Point(581, 50)
        Me.picPath.Name = "picPath"
        Me.picPath.Size = New System.Drawing.Size(15, 15)
        Me.picPath.TabIndex = 293
        Me.picPath.TabStop = False
        Me.picPath.Visible = False
        '
        'picPathf
        '
        Me.picPathf.BackgroundImage = CType(resources.GetObject("picPathf.BackgroundImage"), System.Drawing.Image)
        Me.picPathf.Location = New System.Drawing.Point(581, 115)
        Me.picPathf.Name = "picPathf"
        Me.picPathf.Size = New System.Drawing.Size(15, 15)
        Me.picPathf.TabIndex = 294
        Me.picPathf.TabStop = False
        Me.picPathf.Visible = False
        '
        'lblLoadMsg
        '
        Me.lblLoadMsg.AutoSize = True
        Me.lblLoadMsg.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoadMsg.ForeColor = System.Drawing.Color.White
        Me.lblLoadMsg.Location = New System.Drawing.Point(306, 392)
        Me.lblLoadMsg.Name = "lblLoadMsg"
        Me.lblLoadMsg.Size = New System.Drawing.Size(63, 19)
        Me.lblLoadMsg.TabIndex = 295
        Me.lblLoadMsg.Text = "Label2"
        Me.lblLoadMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblLoadMsg.Visible = False
        '
        'picCake
        '
        Me.picCake.BackgroundImage = CType(resources.GetObject("picCake.BackgroundImage"), System.Drawing.Image)
        Me.picCake.Location = New System.Drawing.Point(108, 70)
        Me.picCake.Name = "picCake"
        Me.picCake.Size = New System.Drawing.Size(15, 15)
        Me.picCake.TabIndex = 296
        Me.picCake.TabStop = False
        Me.picCake.Visible = False
        '
        'picHT
        '
        Me.picHT.BackgroundImage = CType(resources.GetObject("picHT.BackgroundImage"), System.Drawing.Image)
        Me.picHT.Location = New System.Drawing.Point(539, 70)
        Me.picHT.Name = "picHT"
        Me.picHT.Size = New System.Drawing.Size(15, 15)
        Me.picHT.TabIndex = 308
        Me.picHT.TabStop = False
        Me.picHT.Visible = False
        '
        'picHTf
        '
        Me.picHTf.BackgroundImage = CType(resources.GetObject("picHTf.BackgroundImage"), System.Drawing.Image)
        Me.picHTf.Location = New System.Drawing.Point(539, 136)
        Me.picHTf.Name = "picHTf"
        Me.picHTf.Size = New System.Drawing.Size(15, 15)
        Me.picHTf.TabIndex = 309
        Me.picHTf.TabStop = False
        Me.picHTf.Visible = False
        '
        'picFVf
        '
        Me.picFVf.BackgroundImage = CType(resources.GetObject("picFVf.BackgroundImage"), System.Drawing.Image)
        Me.picFVf.Location = New System.Drawing.Point(560, 136)
        Me.picFVf.Name = "picFVf"
        Me.picFVf.Size = New System.Drawing.Size(15, 15)
        Me.picFVf.TabIndex = 311
        Me.picFVf.TabStop = False
        Me.picFVf.Visible = False
        '
        'picFVtile
        '
        Me.picFVtile.BackgroundImage = CType(resources.GetObject("picFVtile.BackgroundImage"), System.Drawing.Image)
        Me.picFVtile.Location = New System.Drawing.Point(560, 70)
        Me.picFVtile.Name = "picFVtile"
        Me.picFVtile.Size = New System.Drawing.Size(15, 15)
        Me.picFVtile.TabIndex = 312
        Me.picFVtile.TabStop = False
        Me.picFVtile.Visible = False
        '
        'picStaffEnd
        '
        Me.picStaffEnd.BackgroundImage = CType(resources.GetObject("picStaffEnd.BackgroundImage"), System.Drawing.Image)
        Me.picStaffEnd.Location = New System.Drawing.Point(129, 91)
        Me.picStaffEnd.Name = "picStaffEnd"
        Me.picStaffEnd.Size = New System.Drawing.Size(15, 15)
        Me.picStaffEnd.TabIndex = 313
        Me.picStaffEnd.TabStop = False
        Me.picStaffEnd.Visible = False
        '
        'picSpaceStairs
        '
        Me.picSpaceStairs.BackgroundImage = CType(resources.GetObject("picSpaceStairs.BackgroundImage"), System.Drawing.Image)
        Me.picSpaceStairs.Location = New System.Drawing.Point(539, 159)
        Me.picSpaceStairs.Name = "picSpaceStairs"
        Me.picSpaceStairs.Size = New System.Drawing.Size(15, 15)
        Me.picSpaceStairs.TabIndex = 317
        Me.picSpaceStairs.TabStop = False
        Me.picSpaceStairs.Visible = False
        '
        'picSpaceTrap
        '
        Me.picSpaceTrap.BackgroundImage = CType(resources.GetObject("picSpaceTrap.BackgroundImage"), System.Drawing.Image)
        Me.picSpaceTrap.Location = New System.Drawing.Point(560, 159)
        Me.picSpaceTrap.Name = "picSpaceTrap"
        Me.picSpaceTrap.Size = New System.Drawing.Size(15, 15)
        Me.picSpaceTrap.TabIndex = 316
        Me.picSpaceTrap.TabStop = False
        Me.picSpaceTrap.Visible = False
        '
        'picSpaceChest
        '
        Me.picSpaceChest.BackgroundImage = CType(resources.GetObject("picSpaceChest.BackgroundImage"), System.Drawing.Image)
        Me.picSpaceChest.Location = New System.Drawing.Point(518, 159)
        Me.picSpaceChest.Name = "picSpaceChest"
        Me.picSpaceChest.Size = New System.Drawing.Size(15, 15)
        Me.picSpaceChest.TabIndex = 315
        Me.picSpaceChest.TabStop = False
        Me.picSpaceChest.Visible = False
        '
        'picSpaceTile
        '
        Me.picSpaceTile.BackgroundImage = CType(resources.GetObject("picSpaceTile.BackgroundImage"), System.Drawing.Image)
        Me.picSpaceTile.Location = New System.Drawing.Point(497, 159)
        Me.picSpaceTile.Name = "picSpaceTile"
        Me.picSpaceTile.Size = New System.Drawing.Size(15, 15)
        Me.picSpaceTile.TabIndex = 314
        Me.picSpaceTile.TabStop = False
        Me.picSpaceTile.Visible = False
        '
        'picPlayerSpace
        '
        Me.picPlayerSpace.BackgroundImage = CType(resources.GetObject("picPlayerSpace.BackgroundImage"), System.Drawing.Image)
        Me.picPlayerSpace.Location = New System.Drawing.Point(581, 159)
        Me.picPlayerSpace.Name = "picPlayerSpace"
        Me.picPlayerSpace.Size = New System.Drawing.Size(15, 15)
        Me.picPlayerSpace.TabIndex = 319
        Me.picPlayerSpace.TabStop = False
        Me.picPlayerSpace.Visible = False
        '
        'picBimboSpace
        '
        Me.picBimboSpace.BackgroundImage = CType(resources.GetObject("picBimboSpace.BackgroundImage"), System.Drawing.Image)
        Me.picBimboSpace.Location = New System.Drawing.Point(602, 159)
        Me.picBimboSpace.Name = "picBimboSpace"
        Me.picBimboSpace.Size = New System.Drawing.Size(15, 15)
        Me.picBimboSpace.TabIndex = 318
        Me.picBimboSpace.TabStop = False
        Me.picBimboSpace.Visible = False
        '
        'picSPacePath
        '
        Me.picSPacePath.BackgroundImage = CType(resources.GetObject("picSPacePath.BackgroundImage"), System.Drawing.Image)
        Me.picSPacePath.Location = New System.Drawing.Point(518, 180)
        Me.picSPacePath.Name = "picSPacePath"
        Me.picSPacePath.Size = New System.Drawing.Size(15, 15)
        Me.picSPacePath.TabIndex = 321
        Me.picSPacePath.TabStop = False
        Me.picSPacePath.Visible = False
        '
        'picSpaceCrystal
        '
        Me.picSpaceCrystal.BackgroundImage = CType(resources.GetObject("picSpaceCrystal.BackgroundImage"), System.Drawing.Image)
        Me.picSpaceCrystal.Location = New System.Drawing.Point(497, 180)
        Me.picSpaceCrystal.Name = "picSpaceCrystal"
        Me.picSpaceCrystal.Size = New System.Drawing.Size(15, 15)
        Me.picSpaceCrystal.TabIndex = 320
        Me.picSpaceCrystal.TabStop = False
        Me.picSpaceCrystal.Visible = False
        '
        'pnlEvent
        '
        Me.pnlEvent.BackgroundImage = CType(resources.GetObject("pnlEvent.BackgroundImage"), System.Drawing.Image)
        Me.pnlEvent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlEvent.Controls.Add(Me.Label4)
        Me.pnlEvent.Controls.Add(Me.btnNextLPnlEvent)
        Me.pnlEvent.Controls.Add(Me.btnNextRPnlEvent)
        Me.pnlEvent.Controls.Add(Me.btnClosePnlEvent)
        Me.pnlEvent.Controls.Add(Me.txtPNLEvents)
        Me.pnlEvent.Location = New System.Drawing.Point(997, 26)
        Me.pnlEvent.Name = "pnlEvent"
        Me.pnlEvent.Size = New System.Drawing.Size(688, 447)
        Me.pnlEvent.TabIndex = 322
        Me.pnlEvent.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Consolas", 10.2!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(13, 416)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(336, 17)
        Me.Label4.TabIndex = 236
        Me.Label4.Text = "Press any non-movement key to continue..."
        '
        'btnNextLPnlEvent
        '
        Me.btnNextLPnlEvent.BackColor = System.Drawing.Color.Black
        Me.btnNextLPnlEvent.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNextLPnlEvent.ForeColor = System.Drawing.Color.White
        Me.btnNextLPnlEvent.Location = New System.Drawing.Point(467, 412)
        Me.btnNextLPnlEvent.Name = "btnNextLPnlEvent"
        Me.btnNextLPnlEvent.Size = New System.Drawing.Size(54, 28)
        Me.btnNextLPnlEvent.TabIndex = 235
        Me.btnNextLPnlEvent.Text = "<"
        Me.btnNextLPnlEvent.UseVisualStyleBackColor = False
        Me.btnNextLPnlEvent.Visible = False
        '
        'btnNextRPnlEvent
        '
        Me.btnNextRPnlEvent.BackColor = System.Drawing.Color.Black
        Me.btnNextRPnlEvent.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNextRPnlEvent.ForeColor = System.Drawing.Color.White
        Me.btnNextRPnlEvent.Location = New System.Drawing.Point(523, 412)
        Me.btnNextRPnlEvent.Name = "btnNextRPnlEvent"
        Me.btnNextRPnlEvent.Size = New System.Drawing.Size(54, 28)
        Me.btnNextRPnlEvent.TabIndex = 234
        Me.btnNextRPnlEvent.Text = ">"
        Me.btnNextRPnlEvent.UseVisualStyleBackColor = False
        Me.btnNextRPnlEvent.Visible = False
        '
        'btnClosePnlEvent
        '
        Me.btnClosePnlEvent.BackColor = System.Drawing.Color.Black
        Me.btnClosePnlEvent.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClosePnlEvent.ForeColor = System.Drawing.Color.White
        Me.btnClosePnlEvent.Location = New System.Drawing.Point(603, 412)
        Me.btnClosePnlEvent.Name = "btnClosePnlEvent"
        Me.btnClosePnlEvent.Size = New System.Drawing.Size(73, 28)
        Me.btnClosePnlEvent.TabIndex = 233
        Me.btnClosePnlEvent.Text = "Exit"
        Me.btnClosePnlEvent.UseVisualStyleBackColor = False
        '
        'txtPNLEvents
        '
        Me.txtPNLEvents.BackColor = System.Drawing.Color.Black
        Me.txtPNLEvents.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPNLEvents.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtPNLEvents.Font = New System.Drawing.Font("Consolas", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPNLEvents.ForeColor = System.Drawing.Color.White
        Me.txtPNLEvents.Location = New System.Drawing.Point(11, 7)
        Me.txtPNLEvents.Multiline = True
        Me.txtPNLEvents.Name = "txtPNLEvents"
        Me.txtPNLEvents.ReadOnly = True
        Me.txtPNLEvents.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPNLEvents.Size = New System.Drawing.Size(665, 400)
        Me.txtPNLEvents.TabIndex = 0
        Me.txtPNLEvents.Text = resources.GetString("txtPNLEvents.Text")
        '
        'picLegaPath
        '
        Me.picLegaPath.BackgroundImage = CType(resources.GetObject("picLegaPath.BackgroundImage"), System.Drawing.Image)
        Me.picLegaPath.Location = New System.Drawing.Point(518, 222)
        Me.picLegaPath.Name = "picLegaPath"
        Me.picLegaPath.Size = New System.Drawing.Size(15, 15)
        Me.picLegaPath.TabIndex = 330
        Me.picLegaPath.TabStop = False
        Me.picLegaPath.Visible = False
        '
        'picLegaCrystal
        '
        Me.picLegaCrystal.BackgroundImage = CType(resources.GetObject("picLegaCrystal.BackgroundImage"), System.Drawing.Image)
        Me.picLegaCrystal.Location = New System.Drawing.Point(497, 222)
        Me.picLegaCrystal.Name = "picLegaCrystal"
        Me.picLegaCrystal.Size = New System.Drawing.Size(15, 15)
        Me.picLegaCrystal.TabIndex = 329
        Me.picLegaCrystal.TabStop = False
        Me.picLegaCrystal.Visible = False
        '
        'picLegaPlayer
        '
        Me.picLegaPlayer.BackgroundImage = CType(resources.GetObject("picLegaPlayer.BackgroundImage"), System.Drawing.Image)
        Me.picLegaPlayer.Location = New System.Drawing.Point(581, 201)
        Me.picLegaPlayer.Name = "picLegaPlayer"
        Me.picLegaPlayer.Size = New System.Drawing.Size(15, 15)
        Me.picLegaPlayer.TabIndex = 328
        Me.picLegaPlayer.TabStop = False
        Me.picLegaPlayer.Visible = False
        '
        'picLegaBimbo
        '
        Me.picLegaBimbo.BackgroundImage = CType(resources.GetObject("picLegaBimbo.BackgroundImage"), System.Drawing.Image)
        Me.picLegaBimbo.Location = New System.Drawing.Point(602, 201)
        Me.picLegaBimbo.Name = "picLegaBimbo"
        Me.picLegaBimbo.Size = New System.Drawing.Size(15, 15)
        Me.picLegaBimbo.TabIndex = 327
        Me.picLegaBimbo.TabStop = False
        Me.picLegaBimbo.Visible = False
        '
        'picLegaStairs
        '
        Me.picLegaStairs.BackgroundImage = CType(resources.GetObject("picLegaStairs.BackgroundImage"), System.Drawing.Image)
        Me.picLegaStairs.Location = New System.Drawing.Point(539, 201)
        Me.picLegaStairs.Name = "picLegaStairs"
        Me.picLegaStairs.Size = New System.Drawing.Size(15, 15)
        Me.picLegaStairs.TabIndex = 326
        Me.picLegaStairs.TabStop = False
        Me.picLegaStairs.Visible = False
        '
        'picLegaTrap
        '
        Me.picLegaTrap.BackgroundImage = CType(resources.GetObject("picLegaTrap.BackgroundImage"), System.Drawing.Image)
        Me.picLegaTrap.Location = New System.Drawing.Point(560, 201)
        Me.picLegaTrap.Name = "picLegaTrap"
        Me.picLegaTrap.Size = New System.Drawing.Size(15, 15)
        Me.picLegaTrap.TabIndex = 325
        Me.picLegaTrap.TabStop = False
        Me.picLegaTrap.Visible = False
        '
        'picLegaChest
        '
        Me.picLegaChest.BackgroundImage = CType(resources.GetObject("picLegaChest.BackgroundImage"), System.Drawing.Image)
        Me.picLegaChest.Location = New System.Drawing.Point(518, 201)
        Me.picLegaChest.Name = "picLegaChest"
        Me.picLegaChest.Size = New System.Drawing.Size(15, 15)
        Me.picLegaChest.TabIndex = 324
        Me.picLegaChest.TabStop = False
        Me.picLegaChest.Visible = False
        '
        'picLegaTile
        '
        Me.picLegaTile.BackgroundImage = CType(resources.GetObject("picLegaTile.BackgroundImage"), System.Drawing.Image)
        Me.picLegaTile.Location = New System.Drawing.Point(497, 201)
        Me.picLegaTile.Name = "picLegaTile"
        Me.picLegaTile.Size = New System.Drawing.Size(15, 15)
        Me.picLegaTile.TabIndex = 323
        Me.picLegaTile.TabStop = False
        Me.picLegaTile.Visible = False
        '
        'picLegaCaelia
        '
        Me.picLegaCaelia.BackgroundImage = CType(resources.GetObject("picLegaCaelia.BackgroundImage"), System.Drawing.Image)
        Me.picLegaCaelia.Location = New System.Drawing.Point(539, 222)
        Me.picLegaCaelia.Name = "picLegaCaelia"
        Me.picLegaCaelia.Size = New System.Drawing.Size(15, 15)
        Me.picLegaCaelia.TabIndex = 331
        Me.picLegaCaelia.TabStop = False
        Me.picLegaCaelia.Visible = False
        '
        'picWSf
        '
        Me.picWSf.BackgroundImage = CType(resources.GetObject("picWSf.BackgroundImage"), System.Drawing.Image)
        Me.picWSf.Location = New System.Drawing.Point(581, 136)
        Me.picWSf.Name = "picWSf"
        Me.picWSf.Size = New System.Drawing.Size(15, 15)
        Me.picWSf.TabIndex = 341
        Me.picWSf.TabStop = False
        Me.picWSf.Visible = False
        '
        'picWS
        '
        Me.picWS.BackgroundImage = CType(resources.GetObject("picWS.BackgroundImage"), System.Drawing.Image)
        Me.picWS.Location = New System.Drawing.Point(581, 70)
        Me.picWS.Name = "picWS"
        Me.picWS.Size = New System.Drawing.Size(15, 15)
        Me.picWS.TabIndex = 342
        Me.picWS.TabStop = False
        Me.picWS.Visible = False
        '
        'picDragonF
        '
        Me.picDragonF.BackgroundImage = CType(resources.GetObject("picDragonF.BackgroundImage"), System.Drawing.Image)
        Me.picDragonF.Location = New System.Drawing.Point(87, 70)
        Me.picDragonF.Name = "picDragonF"
        Me.picDragonF.Size = New System.Drawing.Size(15, 15)
        Me.picDragonF.TabIndex = 343
        Me.picDragonF.TabStop = False
        Me.picDragonF.Visible = False
        '
        'picCBrok
        '
        Me.picCBrok.BackgroundImage = CType(resources.GetObject("picCBrok.BackgroundImage"), System.Drawing.Image)
        Me.picCBrok.Location = New System.Drawing.Point(602, 70)
        Me.picCBrok.Name = "picCBrok"
        Me.picCBrok.Size = New System.Drawing.Size(15, 15)
        Me.picCBrok.TabIndex = 347
        Me.picCBrok.TabStop = False
        Me.picCBrok.Visible = False
        '
        'picCBrokF
        '
        Me.picCBrokF.BackgroundImage = CType(resources.GetObject("picCBrokF.BackgroundImage"), System.Drawing.Image)
        Me.picCBrokF.Location = New System.Drawing.Point(602, 136)
        Me.picCBrokF.Name = "picCBrokF"
        Me.picCBrokF.Size = New System.Drawing.Size(15, 15)
        Me.picCBrokF.TabIndex = 348
        Me.picCBrokF.TabStop = False
        Me.picCBrokF.Visible = False
        '
        'picPortOutline
        '
        Me.picPortOutline.BackgroundImage = CType(resources.GetObject("picPortOutline.BackgroundImage"), System.Drawing.Image)
        Me.picPortOutline.Location = New System.Drawing.Point(129, 70)
        Me.picPortOutline.Name = "picPortOutline"
        Me.picPortOutline.Size = New System.Drawing.Size(15, 15)
        Me.picPortOutline.TabIndex = 349
        Me.picPortOutline.TabStop = False
        Me.picPortOutline.Visible = False
        '
        'picHalfDragon2
        '
        Me.picHalfDragon2.BackgroundImage = CType(resources.GetObject("picHalfDragon2.BackgroundImage"), System.Drawing.Image)
        Me.picHalfDragon2.Location = New System.Drawing.Point(66, 112)
        Me.picHalfDragon2.Name = "picHalfDragon2"
        Me.picHalfDragon2.Size = New System.Drawing.Size(15, 15)
        Me.picHalfDragon2.TabIndex = 352
        Me.picHalfDragon2.TabStop = False
        Me.picHalfDragon2.Visible = False
        '
        'picBroodmother
        '
        Me.picBroodmother.BackgroundImage = CType(resources.GetObject("picBroodmother.BackgroundImage"), System.Drawing.Image)
        Me.picBroodmother.Location = New System.Drawing.Point(87, 112)
        Me.picBroodmother.Name = "picBroodmother"
        Me.picBroodmother.Size = New System.Drawing.Size(15, 15)
        Me.picBroodmother.TabIndex = 351
        Me.picBroodmother.TabStop = False
        Me.picBroodmother.Visible = False
        '
        'picHalfDragon1
        '
        Me.picHalfDragon1.BackgroundImage = CType(resources.GetObject("picHalfDragon1.BackgroundImage"), System.Drawing.Image)
        Me.picHalfDragon1.Location = New System.Drawing.Point(45, 112)
        Me.picHalfDragon1.Name = "picHalfDragon1"
        Me.picHalfDragon1.Size = New System.Drawing.Size(15, 15)
        Me.picHalfDragon1.TabIndex = 350
        Me.picHalfDragon1.TabStop = False
        Me.picHalfDragon1.Visible = False
        '
        'picBlobF
        '
        Me.picBlobF.BackgroundImage = CType(resources.GetObject("picBlobF.BackgroundImage"), System.Drawing.Image)
        Me.picBlobF.Location = New System.Drawing.Point(129, 112)
        Me.picBlobF.Name = "picBlobF"
        Me.picBlobF.Size = New System.Drawing.Size(15, 15)
        Me.picBlobF.TabIndex = 355
        Me.picBlobF.TabStop = False
        Me.picBlobF.Visible = False
        '
        'picHorse
        '
        Me.picHorse.BackgroundImage = CType(resources.GetObject("picHorse.BackgroundImage"), System.Drawing.Image)
        Me.picHorse.Location = New System.Drawing.Point(45, 133)
        Me.picHorse.Name = "picHorse"
        Me.picHorse.Size = New System.Drawing.Size(15, 15)
        Me.picHorse.TabIndex = 354
        Me.picHorse.TabStop = False
        Me.picHorse.Visible = False
        '
        'picBlobM
        '
        Me.picBlobM.BackgroundImage = CType(resources.GetObject("picBlobM.BackgroundImage"), System.Drawing.Image)
        Me.picBlobM.Location = New System.Drawing.Point(108, 112)
        Me.picBlobM.Name = "picBlobM"
        Me.picBlobM.Size = New System.Drawing.Size(15, 15)
        Me.picBlobM.TabIndex = 353
        Me.picBlobM.TabStop = False
        Me.picBlobM.Visible = False
        '
        'picOniF
        '
        Me.picOniF.BackgroundImage = CType(resources.GetObject("picOniF.BackgroundImage"), System.Drawing.Image)
        Me.picOniF.Location = New System.Drawing.Point(87, 133)
        Me.picOniF.Name = "picOniF"
        Me.picOniF.Size = New System.Drawing.Size(15, 15)
        Me.picOniF.TabIndex = 358
        Me.picOniF.TabStop = False
        Me.picOniF.Visible = False
        '
        'picUnicorn
        '
        Me.picUnicorn.BackgroundImage = CType(resources.GetObject("picUnicorn.BackgroundImage"), System.Drawing.Image)
        Me.picUnicorn.Location = New System.Drawing.Point(66, 133)
        Me.picUnicorn.Name = "picUnicorn"
        Me.picUnicorn.Size = New System.Drawing.Size(15, 15)
        Me.picUnicorn.TabIndex = 356
        Me.picUnicorn.TabStop = False
        Me.picUnicorn.Visible = False
        '
        'picTTTile
        '
        Me.picTTTile.BackgroundImage = CType(resources.GetObject("picTTTile.BackgroundImage"), System.Drawing.Image)
        Me.picTTTile.Location = New System.Drawing.Point(623, 70)
        Me.picTTTile.Name = "picTTTile"
        Me.picTTTile.Size = New System.Drawing.Size(15, 15)
        Me.picTTTile.TabIndex = 359
        Me.picTTTile.TabStop = False
        Me.picTTTile.Visible = False
        '
        'picTTTileF
        '
        Me.picTTTileF.BackgroundImage = CType(resources.GetObject("picTTTileF.BackgroundImage"), System.Drawing.Image)
        Me.picTTTileF.Location = New System.Drawing.Point(623, 136)
        Me.picTTTileF.Name = "picTTTileF"
        Me.picTTTileF.Size = New System.Drawing.Size(15, 15)
        Me.picTTTileF.TabIndex = 360
        Me.picTTTileF.TabStop = False
        Me.picTTTileF.Visible = False
        '
        'picCow
        '
        Me.picCow.BackgroundImage = CType(resources.GetObject("picCow.BackgroundImage"), System.Drawing.Image)
        Me.picCow.Location = New System.Drawing.Point(108, 133)
        Me.picCow.Name = "picCow"
        Me.picCow.Size = New System.Drawing.Size(15, 15)
        Me.picCow.TabIndex = 374
        Me.picCow.TabStop = False
        Me.picCow.Visible = False
        '
        'picCheerL
        '
        Me.picCheerL.BackgroundImage = CType(resources.GetObject("picCheerL.BackgroundImage"), System.Drawing.Image)
        Me.picCheerL.Location = New System.Drawing.Point(129, 133)
        Me.picCheerL.Name = "picCheerL"
        Me.picCheerL.Size = New System.Drawing.Size(15, 15)
        Me.picCheerL.TabIndex = 375
        Me.picCheerL.TabStop = False
        Me.picCheerL.Visible = False
        '
        'picMGTile
        '
        Me.picMGTile.BackgroundImage = CType(resources.GetObject("picMGTile.BackgroundImage"), System.Drawing.Image)
        Me.picMGTile.Location = New System.Drawing.Point(644, 70)
        Me.picMGTile.Name = "picMGTile"
        Me.picMGTile.Size = New System.Drawing.Size(15, 15)
        Me.picMGTile.TabIndex = 376
        Me.picMGTile.TabStop = False
        Me.picMGTile.Visible = False
        '
        'picMGTileF
        '
        Me.picMGTileF.BackgroundImage = CType(resources.GetObject("picMGTileF.BackgroundImage"), System.Drawing.Image)
        Me.picMGTileF.Location = New System.Drawing.Point(644, 136)
        Me.picMGTileF.Name = "picMGTileF"
        Me.picMGTileF.Size = New System.Drawing.Size(15, 15)
        Me.picMGTileF.TabIndex = 377
        Me.picMGTileF.TabStop = False
        Me.picMGTileF.Visible = False
        '
        'picCBFog
        '
        Me.picCBFog.BackgroundImage = CType(resources.GetObject("picCBFog.BackgroundImage"), System.Drawing.Image)
        Me.picCBFog.Location = New System.Drawing.Point(539, 264)
        Me.picCBFog.Name = "picCBFog"
        Me.picCBFog.Size = New System.Drawing.Size(15, 15)
        Me.picCBFog.TabIndex = 391
        Me.picCBFog.TabStop = False
        Me.picCBFog.Visible = False
        '
        'picStatueFog
        '
        Me.picStatueFog.BackgroundImage = CType(resources.GetObject("picStatueFog.BackgroundImage"), System.Drawing.Image)
        Me.picStatueFog.Location = New System.Drawing.Point(518, 264)
        Me.picStatueFog.Name = "picStatueFog"
        Me.picStatueFog.Size = New System.Drawing.Size(15, 15)
        Me.picStatueFog.TabIndex = 390
        Me.picStatueFog.TabStop = False
        Me.picStatueFog.Visible = False
        '
        'picCrystalFog
        '
        Me.picCrystalFog.BackgroundImage = CType(resources.GetObject("picCrystalFog.BackgroundImage"), System.Drawing.Image)
        Me.picCrystalFog.Location = New System.Drawing.Point(497, 264)
        Me.picCrystalFog.Name = "picCrystalFog"
        Me.picCrystalFog.Size = New System.Drawing.Size(15, 15)
        Me.picCrystalFog.TabIndex = 389
        Me.picCrystalFog.TabStop = False
        Me.picCrystalFog.Visible = False
        '
        'picPlayerFog
        '
        Me.picPlayerFog.BackgroundImage = CType(resources.GetObject("picPlayerFog.BackgroundImage"), System.Drawing.Image)
        Me.picPlayerFog.Location = New System.Drawing.Point(581, 243)
        Me.picPlayerFog.Name = "picPlayerFog"
        Me.picPlayerFog.Size = New System.Drawing.Size(15, 15)
        Me.picPlayerFog.TabIndex = 388
        Me.picPlayerFog.TabStop = False
        Me.picPlayerFog.Visible = False
        '
        'picPlayerBFog
        '
        Me.picPlayerBFog.BackgroundImage = CType(resources.GetObject("picPlayerBFog.BackgroundImage"), System.Drawing.Image)
        Me.picPlayerBFog.Location = New System.Drawing.Point(602, 243)
        Me.picPlayerBFog.Name = "picPlayerBFog"
        Me.picPlayerBFog.Size = New System.Drawing.Size(15, 15)
        Me.picPlayerBFog.TabIndex = 387
        Me.picPlayerBFog.TabStop = False
        Me.picPlayerBFog.Visible = False
        '
        'picStairFog
        '
        Me.picStairFog.BackgroundImage = CType(resources.GetObject("picStairFog.BackgroundImage"), System.Drawing.Image)
        Me.picStairFog.Location = New System.Drawing.Point(539, 243)
        Me.picStairFog.Name = "picStairFog"
        Me.picStairFog.Size = New System.Drawing.Size(15, 15)
        Me.picStairFog.TabIndex = 386
        Me.picStairFog.TabStop = False
        Me.picStairFog.Visible = False
        '
        'picTrapFog
        '
        Me.picTrapFog.BackgroundImage = CType(resources.GetObject("picTrapFog.BackgroundImage"), System.Drawing.Image)
        Me.picTrapFog.Location = New System.Drawing.Point(560, 243)
        Me.picTrapFog.Name = "picTrapFog"
        Me.picTrapFog.Size = New System.Drawing.Size(15, 15)
        Me.picTrapFog.TabIndex = 385
        Me.picTrapFog.TabStop = False
        Me.picTrapFog.Visible = False
        '
        'picChestFog
        '
        Me.picChestFog.BackgroundImage = CType(resources.GetObject("picChestFog.BackgroundImage"), System.Drawing.Image)
        Me.picChestFog.Location = New System.Drawing.Point(518, 243)
        Me.picChestFog.Name = "picChestFog"
        Me.picChestFog.Size = New System.Drawing.Size(15, 15)
        Me.picChestFog.TabIndex = 384
        Me.picChestFog.TabStop = False
        Me.picChestFog.Visible = False
        '
        'picTileFog
        '
        Me.picTileFog.BackgroundImage = CType(resources.GetObject("picTileFog.BackgroundImage"), System.Drawing.Image)
        Me.picTileFog.Location = New System.Drawing.Point(497, 243)
        Me.picTileFog.Name = "picTileFog"
        Me.picTileFog.Size = New System.Drawing.Size(15, 15)
        Me.picTileFog.TabIndex = 383
        Me.picTileFog.TabStop = False
        Me.picTileFog.Visible = False
        '
        'picFVFog
        '
        Me.picFVFog.BackgroundImage = CType(resources.GetObject("picFVFog.BackgroundImage"), System.Drawing.Image)
        Me.picFVFog.Location = New System.Drawing.Point(560, 264)
        Me.picFVFog.Name = "picFVFog"
        Me.picFVFog.Size = New System.Drawing.Size(15, 15)
        Me.picFVFog.TabIndex = 392
        Me.picFVFog.TabStop = False
        Me.picFVFog.Visible = False
        '
        'picTreeFog
        '
        Me.picTreeFog.BackgroundImage = CType(resources.GetObject("picTreeFog.BackgroundImage"), System.Drawing.Image)
        Me.picTreeFog.Location = New System.Drawing.Point(581, 264)
        Me.picTreeFog.Name = "picTreeFog"
        Me.picTreeFog.Size = New System.Drawing.Size(15, 15)
        Me.picTreeFog.TabIndex = 393
        Me.picTreeFog.TabStop = False
        Me.picTreeFog.Visible = False
        '
        'picBossStairsFog
        '
        Me.picBossStairsFog.BackgroundImage = CType(resources.GetObject("picBossStairsFog.BackgroundImage"), System.Drawing.Image)
        Me.picBossStairsFog.Location = New System.Drawing.Point(602, 264)
        Me.picBossStairsFog.Name = "picBossStairsFog"
        Me.picBossStairsFog.Size = New System.Drawing.Size(15, 15)
        Me.picBossStairsFog.TabIndex = 394
        Me.picBossStairsFog.TabStop = False
        Me.picBossStairsFog.Visible = False
        '
        'picMushroom
        '
        Me.picMushroom.BackgroundImage = CType(resources.GetObject("picMushroom.BackgroundImage"), System.Drawing.Image)
        Me.picMushroom.Location = New System.Drawing.Point(150, 112)
        Me.picMushroom.Name = "picMushroom"
        Me.picMushroom.Size = New System.Drawing.Size(15, 15)
        Me.picMushroom.TabIndex = 397
        Me.picMushroom.TabStop = False
        Me.picMushroom.Visible = False
        '
        'picPFaeShock
        '
        Me.picPFaeShock.BackgroundImage = CType(resources.GetObject("picPFaeShock.BackgroundImage"), System.Drawing.Image)
        Me.picPFaeShock.Location = New System.Drawing.Point(150, 91)
        Me.picPFaeShock.Name = "picPFaeShock"
        Me.picPFaeShock.Size = New System.Drawing.Size(15, 15)
        Me.picPFaeShock.TabIndex = 396
        Me.picPFaeShock.TabStop = False
        Me.picPFaeShock.Visible = False
        '
        'picPFae
        '
        Me.picPFae.BackgroundImage = CType(resources.GetObject("picPFae.BackgroundImage"), System.Drawing.Image)
        Me.picPFae.Location = New System.Drawing.Point(150, 70)
        Me.picPFae.Name = "picPFae"
        Me.picPFae.Size = New System.Drawing.Size(15, 15)
        Me.picPFae.TabIndex = 395
        Me.picPFae.TabStop = False
        Me.picPFae.Visible = False
        '
        'pnlStats
        '
        Me.pnlStats.BackgroundImage = CType(resources.GetObject("pnlStats.BackgroundImage"), System.Drawing.Image)
        Me.pnlStats.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlStats.Controls.Add(Me.lblLust)
        Me.pnlStats.Controls.Add(Me.lblSPD)
        Me.pnlStats.Controls.Add(Me.lblGold)
        Me.pnlStats.Controls.Add(Me.lblATK)
        Me.pnlStats.Controls.Add(Me.lblDEF)
        Me.pnlStats.Controls.Add(Me.lblWIL)
        Me.pnlStats.Controls.Add(Me.lblLevel)
        Me.pnlStats.Location = New System.Drawing.Point(734, 150)
        Me.pnlStats.Name = "pnlStats"
        Me.pnlStats.Size = New System.Drawing.Size(131, 140)
        Me.pnlStats.TabIndex = 398
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Black
        Me.Label6.Font = New System.Drawing.Font("Consolas", 10.86792!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(730, 130)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 18)
        Me.Label6.TabIndex = 399
        Me.Label6.Text = "Stats:"
        '
        'pnlMeter
        '
        Me.pnlMeter.BackgroundImage = CType(resources.GetObject("pnlMeter.BackgroundImage"), System.Drawing.Image)
        Me.pnlMeter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlMeter.Controls.Add(Me.lblHealthbarFont)
        Me.pnlMeter.Controls.Add(Me.lblstamina)
        Me.pnlMeter.Controls.Add(Me.lblXP)
        Me.pnlMeter.Controls.Add(Me.Label11)
        Me.pnlMeter.Controls.Add(Me.lblHealth)
        Me.pnlMeter.Controls.Add(Me.lblMana)
        Me.pnlMeter.Controls.Add(Me.Label8)
        Me.pnlMeter.Controls.Add(Me.Label9)
        Me.pnlMeter.Controls.Add(Me.Label10)
        Me.pnlMeter.Location = New System.Drawing.Point(733, 41)
        Me.pnlMeter.Name = "pnlMeter"
        Me.pnlMeter.Size = New System.Drawing.Size(269, 82)
        Me.pnlMeter.TabIndex = 400
        '
        'lblHealthbarFont
        '
        Me.lblHealthbarFont.AutoSize = True
        Me.lblHealthbarFont.Font = New System.Drawing.Font("Consolas", 8.150944!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHealthbarFont.ForeColor = System.Drawing.Color.White
        Me.lblHealthbarFont.Location = New System.Drawing.Point(0, 65)
        Me.lblHealthbarFont.Name = "lblHealthbarFont"
        Me.lblHealthbarFont.Size = New System.Drawing.Size(0, 13)
        Me.lblHealthbarFont.TabIndex = 156
        Me.lblHealthbarFont.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblHealthbarFont.Visible = False
        '
        'lblstamina
        '
        Me.lblstamina.Font = New System.Drawing.Font("Consolas", 8.150944!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblstamina.ForeColor = System.Drawing.Color.LightCoral
        Me.lblstamina.Location = New System.Drawing.Point(34, 41)
        Me.lblstamina.Name = "lblstamina"
        Me.lblstamina.Size = New System.Drawing.Size(231, 15)
        Me.lblstamina.TabIndex = 155
        Me.lblstamina.Text = "ￃￃￃￃￃￃ|stam = TEMP|||||||||||||||||||||||||"
        Me.lblstamina.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblXP
        '
        Me.lblXP.Font = New System.Drawing.Font("Consolas", 8.150944!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblXP.ForeColor = System.Drawing.Color.Gray
        Me.lblXP.Location = New System.Drawing.Point(34, 59)
        Me.lblXP.Name = "lblXP"
        Me.lblXP.Size = New System.Drawing.Size(231, 15)
        Me.lblXP.TabIndex = 154
        Me.lblXP.Text = "||||||||||||||||XP = TEMP|||||||||||||||||||||||||"
        Me.lblXP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(6, 58)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(35, 14)
        Me.Label11.TabIndex = 153
        Me.Label11.Text = "XP: "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(6, 6)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 14)
        Me.Label8.TabIndex = 150
        Me.Label8.Text = "HP: "
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(6, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 14)
        Me.Label9.TabIndex = 151
        Me.Label9.Text = "MP: "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(6, 41)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 14)
        Me.Label10.TabIndex = 152
        Me.Label10.Text = "ST: "
        '
        'pic9tailsBimbo
        '
        Me.pic9tailsBimbo.BackgroundImage = CType(resources.GetObject("pic9tailsBimbo.BackgroundImage"), System.Drawing.Image)
        Me.pic9tailsBimbo.Location = New System.Drawing.Point(150, 133)
        Me.pic9tailsBimbo.Name = "pic9tailsBimbo"
        Me.pic9tailsBimbo.Size = New System.Drawing.Size(15, 15)
        Me.pic9tailsBimbo.TabIndex = 401
        Me.pic9tailsBimbo.TabStop = False
        Me.pic9tailsBimbo.Visible = False
        '
        'picFoxStatueGold
        '
        Me.picFoxStatueGold.BackgroundImage = CType(resources.GetObject("picFoxStatueGold.BackgroundImage"), System.Drawing.Image)
        Me.picFoxStatueGold.Location = New System.Drawing.Point(623, 115)
        Me.picFoxStatueGold.Name = "picFoxStatueGold"
        Me.picFoxStatueGold.Size = New System.Drawing.Size(15, 15)
        Me.picFoxStatueGold.TabIndex = 403
        Me.picFoxStatueGold.TabStop = False
        Me.picFoxStatueGold.Visible = False
        '
        'picFoxStatueF
        '
        Me.picFoxStatueF.BackgroundImage = CType(resources.GetObject("picFoxStatueF.BackgroundImage"), System.Drawing.Image)
        Me.picFoxStatueF.Location = New System.Drawing.Point(602, 115)
        Me.picFoxStatueF.Name = "picFoxStatueF"
        Me.picFoxStatueF.Size = New System.Drawing.Size(15, 15)
        Me.picFoxStatueF.TabIndex = 402
        Me.picFoxStatueF.TabStop = False
        Me.picFoxStatueF.Visible = False
        '
        'lblLust
        '
        Me.lblLust.AutoSize = True
        Me.lblLust.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLust.ForeColor = System.Drawing.Color.White
        Me.lblLust.Location = New System.Drawing.Point(5, 100)
        Me.lblLust.Name = "lblLust"
        Me.lblLust.Size = New System.Drawing.Size(84, 14)
        Me.lblLust.TabIndex = 211
        Me.lblLust.Text = "LUST = TEMP"
        '
        'Game
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1008, 690)
        Me.Controls.Add(Me.picFoxStatueGold)
        Me.Controls.Add(Me.picFoxStatueF)
        Me.Controls.Add(Me.pic9tailsBimbo)
        Me.Controls.Add(Me.pnlSaveLoad)
        Me.Controls.Add(Me.btnAll)
        Me.Controls.Add(Me.btnNone)
        Me.Controls.Add(Me.pnlSelection)
        Me.Controls.Add(Me.pnlEvent)
        Me.Controls.Add(Me.pnlDescription)
        Me.Controls.Add(Me.lblLoadMsg)
        Me.Controls.Add(Me.btnAbout)
        Me.Controls.Add(Me.chkAcc)
        Me.Controls.Add(Me.picLoadBar)
        Me.Controls.Add(Me.pnlCombat)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnT)
        Me.Controls.Add(Me.btnSettings)
        Me.Controls.Add(Me.chkMisc)
        Me.Controls.Add(Me.chkWeapon)
        Me.Controls.Add(Me.frmArmor)
        Me.Controls.Add(Me.chkFood)
        Me.Controls.Add(Me.chkPotion)
        Me.Controls.Add(Me.chkUseable)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnSpec)
        Me.Controls.Add(Me.cboxSpec)
        Me.Controls.Add(Me.btnControls)
        Me.Controls.Add(Me.picEnemy)
        Me.Controls.Add(Me.btnLeave)
        Me.Controls.Add(Me.cboxNPCMG)
        Me.Controls.Add(Me.btnShop)
        Me.Controls.Add(Me.btnTalk)
        Me.Controls.Add(Me.picNPC)
        Me.Controls.Add(Me.btnL)
        Me.Controls.Add(Me.btnS)
        Me.Controls.Add(Me.picStart)
        Me.Controls.Add(Me.btnEQP)
        Me.Controls.Add(Me.btnRUN)
        Me.Controls.Add(Me.btnMG)
        Me.Controls.Add(Me.btnATK)
        Me.Controls.Add(Me.lblNameTitle)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnUse)
        Me.Controls.Add(Me.lstLog)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.btnLook)
        Me.Controls.Add(Me.btnDrop)
        Me.Controls.Add(Me.btnUse1)
        Me.Controls.Add(Me.btnEXM)
        Me.Controls.Add(Me.btnIns)
        Me.Controls.Add(Me.btnR)
        Me.Controls.Add(Me.btnU)
        Me.Controls.Add(Me.BtnD)
        Me.Controls.Add(Me.btnLft)
        Me.Controls.Add(Me.btnFilter)
        Me.Controls.Add(Me.lstInventory)
        Me.Controls.Add(Me.picPortrait)
        Me.Controls.Add(Me.lblEvent)
        Me.Controls.Add(Me.btnWait)
        Me.Controls.Add(Me.btnNPCMG)
        Me.Controls.Add(Me.btnFight)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.pnlStats)
        Me.Controls.Add(Me.pnlMeter)
        Me.Controls.Add(Me.picBossStairsFog)
        Me.Controls.Add(Me.picTreeFog)
        Me.Controls.Add(Me.picFVFog)
        Me.Controls.Add(Me.picCBFog)
        Me.Controls.Add(Me.picStatueFog)
        Me.Controls.Add(Me.picCrystalFog)
        Me.Controls.Add(Me.picPlayerFog)
        Me.Controls.Add(Me.picPlayerBFog)
        Me.Controls.Add(Me.picStairFog)
        Me.Controls.Add(Me.picTrapFog)
        Me.Controls.Add(Me.picChestFog)
        Me.Controls.Add(Me.picTileFog)
        Me.Controls.Add(Me.picMGTileF)
        Me.Controls.Add(Me.picMGTile)
        Me.Controls.Add(Me.picTTTileF)
        Me.Controls.Add(Me.picTTTile)
        Me.Controls.Add(Me.picCBrokF)
        Me.Controls.Add(Me.picCBrok)
        Me.Controls.Add(Me.picWS)
        Me.Controls.Add(Me.picWSf)
        Me.Controls.Add(Me.picLegaCaelia)
        Me.Controls.Add(Me.picLegaPath)
        Me.Controls.Add(Me.picLegaCrystal)
        Me.Controls.Add(Me.picLegaPlayer)
        Me.Controls.Add(Me.picLegaBimbo)
        Me.Controls.Add(Me.picLegaStairs)
        Me.Controls.Add(Me.picLegaTrap)
        Me.Controls.Add(Me.picLegaChest)
        Me.Controls.Add(Me.picLegaTile)
        Me.Controls.Add(Me.picSPacePath)
        Me.Controls.Add(Me.picSpaceCrystal)
        Me.Controls.Add(Me.picPlayerSpace)
        Me.Controls.Add(Me.picBimboSpace)
        Me.Controls.Add(Me.picSpaceStairs)
        Me.Controls.Add(Me.picSpaceTrap)
        Me.Controls.Add(Me.picSpaceChest)
        Me.Controls.Add(Me.picSpaceTile)
        Me.Controls.Add(Me.picFVtile)
        Me.Controls.Add(Me.picFVf)
        Me.Controls.Add(Me.picHTf)
        Me.Controls.Add(Me.picHT)
        Me.Controls.Add(Me.picPathf)
        Me.Controls.Add(Me.picPath)
        Me.Controls.Add(Me.picCrystalf)
        Me.Controls.Add(Me.picCrystal)
        Me.Controls.Add(Me.picstairslockf)
        Me.Controls.Add(Me.picstairsbossf)
        Me.Controls.Add(Me.picStairsBoss)
        Me.Controls.Add(Me.picStairsLock)
        Me.Controls.Add(Me.picSWizF)
        Me.Controls.Add(Me.picSWiz)
        Me.Controls.Add(Me.picTrapf)
        Me.Controls.Add(Me.picStatuef)
        Me.Controls.Add(Me.picShopkeeperf)
        Me.Controls.Add(Me.picBimbof)
        Me.Controls.Add(Me.picChestf)
        Me.Controls.Add(Me.picLadderf)
        Me.Controls.Add(Me.picPlayerf)
        Me.Controls.Add(Me.picTree)
        Me.Controls.Add(Me.picTileF)
        Me.Controls.Add(Me.picTrap)
        Me.Controls.Add(Me.picShopkeepTile)
        Me.Controls.Add(Me.picStatue)
        Me.Controls.Add(Me.picPlayerB)
        Me.Controls.Add(Me.picChest)
        Me.Controls.Add(Me.picStairs)
        Me.Controls.Add(Me.picPlayer)
        Me.Controls.Add(Me.picFog)
        Me.Controls.Add(Me.picTile)
        Me.Controls.Add(Me.picMushroom)
        Me.Controls.Add(Me.picPFaeShock)
        Me.Controls.Add(Me.picPFae)
        Me.Controls.Add(Me.picCheerL)
        Me.Controls.Add(Me.picCow)
        Me.Controls.Add(Me.picOniF)
        Me.Controls.Add(Me.picUnicorn)
        Me.Controls.Add(Me.picBlobF)
        Me.Controls.Add(Me.picHorse)
        Me.Controls.Add(Me.picBlobM)
        Me.Controls.Add(Me.picHalfDragon2)
        Me.Controls.Add(Me.picBroodmother)
        Me.Controls.Add(Me.picHalfDragon1)
        Me.Controls.Add(Me.picPortOutline)
        Me.Controls.Add(Me.picDragonF)
        Me.Controls.Add(Me.picStaffEnd)
        Me.Controls.Add(Me.picCake)
        Me.Controls.Add(Me.picDragonM)
        Me.Controls.Add(Me.picmgp1)
        Me.Controls.Add(Me.picPrin)
        Me.Controls.Add(Me.picBun)
        Me.Controls.Add(Me.picFrog)
        Me.Controls.Add(Me.picSheep)
        Me.Controls.Add(Me.picLust5)
        Me.Controls.Add(Me.picLust4)
        Me.Controls.Add(Me.picLust3)
        Me.Controls.Add(Me.picLust2)
        Me.Controls.Add(Me.picLust1)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Game"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Dungeon_Depths"
        CType(Me.picEnemy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picNPC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picStatue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPlayerB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picChest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picStairs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPlayer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picFog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picStart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.picPortrait, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picShopkeepTile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLust1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLust2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLust3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLust4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLust5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTrap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSaveLoad.ResumeLayout(False)
        CType(Me.picSheep, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picFrog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTileF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTree, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPlayerf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLadderf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picChestf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBimbof, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picShopkeeperf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picStatuef, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTrapf, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCombat.ResumeLayout(False)
        Me.pnlCombat.PerformLayout()
        CType(Me.picPHealth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picEHbar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLoadBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSWiz, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSWizF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDescription.ResumeLayout(False)
        Me.pnlDescription.PerformLayout()
        CType(Me.picDescPort, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picStairsLock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picStairsBoss, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picstairsbossf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picstairslockf, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSelection.ResumeLayout(False)
        Me.pnlSelection.PerformLayout()
        CType(Me.picBun, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPrin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picmgp1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDragonM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCrystal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCrystalf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPath, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPathf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCake, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picHT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picHTf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picFVf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picFVtile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picStaffEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSpaceStairs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSpaceTrap, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSpaceChest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSpaceTile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPlayerSpace, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBimboSpace, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSPacePath, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSpaceCrystal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEvent.ResumeLayout(False)
        Me.pnlEvent.PerformLayout()
        CType(Me.picLegaPath, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLegaCrystal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLegaPlayer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLegaBimbo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLegaStairs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLegaTrap, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLegaChest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLegaTile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLegaCaelia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picWSf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picWS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDragonF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCBrok, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCBrokF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPortOutline, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picHalfDragon2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBroodmother, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picHalfDragon1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBlobF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picHorse, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBlobM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picOniF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picUnicorn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTTTile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTTTileF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCheerL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMGTile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMGTileF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCBFog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picStatueFog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCrystalFog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPlayerFog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPlayerBFog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picStairFog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTrapFog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picChestFog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTileFog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picFVFog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTreeFog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBossStairsFog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMushroom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPFaeShock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPFae, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlStats.ResumeLayout(False)
        Me.pnlStats.PerformLayout()
        Me.pnlMeter.ResumeLayout(False)
        Me.pnlMeter.PerformLayout()
        CType(Me.pic9tailsBimbo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picFoxStatueGold, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picFoxStatueF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnUse1 As System.Windows.Forms.Button
    Friend WithEvents btnDrop As System.Windows.Forms.Button
    Friend WithEvents btnLook As System.Windows.Forms.Button
    Friend WithEvents btnControls As System.Windows.Forms.Button
    Friend WithEvents picEnemy As System.Windows.Forms.PictureBox
    Friend WithEvents btnLeave As System.Windows.Forms.Button
    Friend WithEvents btnFight As System.Windows.Forms.Button
    Friend WithEvents btnNPCMG As System.Windows.Forms.Button
    Friend WithEvents cboxNPCMG As System.Windows.Forms.ComboBox
    Friend WithEvents btnShop As System.Windows.Forms.Button
    Friend WithEvents btnTalk As System.Windows.Forms.Button
    Friend WithEvents picNPC As System.Windows.Forms.PictureBox
    Friend WithEvents picStatue As System.Windows.Forms.PictureBox
    Friend WithEvents picPlayerB As System.Windows.Forms.PictureBox
    Friend WithEvents picChest As System.Windows.Forms.PictureBox
    Friend WithEvents picStairs As System.Windows.Forms.PictureBox
    Friend WithEvents picPlayer As System.Windows.Forms.PictureBox
    Friend WithEvents picFog As System.Windows.Forms.PictureBox
    Friend WithEvents picTile As System.Windows.Forms.PictureBox
    Friend WithEvents btnL As System.Windows.Forms.Button
    Friend WithEvents btnS As System.Windows.Forms.Button
    Friend WithEvents picStart As System.Windows.Forms.PictureBox
    Friend WithEvents btnEQP As System.Windows.Forms.Button
    Friend WithEvents btnRUN As System.Windows.Forms.Button
    Friend WithEvents btnMG As System.Windows.Forms.Button
    Friend WithEvents btnATK As System.Windows.Forms.Button
    Friend WithEvents lblSPD As System.Windows.Forms.Label
    Friend WithEvents lblWIL As System.Windows.Forms.Label
    Friend WithEvents lblDEF As System.Windows.Forms.Label
    Friend WithEvents lblATK As System.Windows.Forms.Label
    Friend WithEvents lblLevel As System.Windows.Forms.Label
    Friend WithEvents lblMana As System.Windows.Forms.Label
    Friend WithEvents lblHealth As System.Windows.Forms.Label
    Friend WithEvents lblNameTitle As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnUse As System.Windows.Forms.Button
    Friend WithEvents lstInventory As System.Windows.Forms.ListBox
    Friend WithEvents lstLog As System.Windows.Forms.ListBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewGameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents picPortrait As System.Windows.Forms.PictureBox
    Friend WithEvents btnEXM As System.Windows.Forms.Button
    Friend WithEvents lblGold As System.Windows.Forms.Label
    Friend WithEvents picShopkeepTile As System.Windows.Forms.PictureBox
    Friend WithEvents picLust1 As System.Windows.Forms.PictureBox
    Friend WithEvents picLust2 As System.Windows.Forms.PictureBox
    Friend WithEvents picLust3 As System.Windows.Forms.PictureBox
    Friend WithEvents picLust4 As System.Windows.Forms.PictureBox
    Friend WithEvents picLust5 As System.Windows.Forms.PictureBox
    Friend WithEvents btnIns As System.Windows.Forms.Button
    Friend WithEvents btnR As System.Windows.Forms.Button
    Friend WithEvents btnU As System.Windows.Forms.Button
    Friend WithEvents BtnD As System.Windows.Forms.Button
    Friend WithEvents btnLft As System.Windows.Forms.Button
    Friend WithEvents cboxSpec As System.Windows.Forms.ComboBox
    Friend WithEvents btnSpec As System.Windows.Forms.Button
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents chkUseable As System.Windows.Forms.CheckBox
    Friend WithEvents chkPotion As System.Windows.Forms.CheckBox
    Friend WithEvents chkFood As System.Windows.Forms.CheckBox
    Friend WithEvents frmArmor As System.Windows.Forms.CheckBox
    Friend WithEvents chkWeapon As System.Windows.Forms.CheckBox
    Friend WithEvents chkMisc As System.Windows.Forms.CheckBox
    Friend WithEvents btnAll As System.Windows.Forms.Button
    Friend WithEvents btnNone As System.Windows.Forms.Button
    Friend WithEvents picTrap As System.Windows.Forms.PictureBox
    Friend WithEvents StatInfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnSettings As System.Windows.Forms.Button
    Friend WithEvents btnT As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnS8 As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnS7 As System.Windows.Forms.Button
    Friend WithEvents btnS6 As System.Windows.Forms.Button
    Friend WithEvents btnS5 As System.Windows.Forms.Button
    Friend WithEvents btnS4 As System.Windows.Forms.Button
    Friend WithEvents btnS3 As System.Windows.Forms.Button
    Friend WithEvents btnS2 As System.Windows.Forms.Button
    Friend WithEvents btnS1 As System.Windows.Forms.Button
    Friend WithEvents pnlSaveLoad As System.Windows.Forms.Panel
    Friend WithEvents picSheep As System.Windows.Forms.PictureBox
    Friend WithEvents picFrog As System.Windows.Forms.PictureBox
    Friend WithEvents picTileF As System.Windows.Forms.PictureBox
    Friend WithEvents picTree As System.Windows.Forms.PictureBox
    Friend WithEvents picPlayerf As System.Windows.Forms.PictureBox
    Friend WithEvents picLadderf As System.Windows.Forms.PictureBox
    Friend WithEvents picChestf As System.Windows.Forms.PictureBox
    Friend WithEvents picBimbof As System.Windows.Forms.PictureBox
    Friend WithEvents picShopkeeperf As System.Windows.Forms.PictureBox
    Friend WithEvents picStatuef As System.Windows.Forms.PictureBox
    Friend WithEvents picTrapf As System.Windows.Forms.PictureBox
    Friend WithEvents tmrKeyCD As System.Windows.Forms.Timer
    Friend WithEvents ReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlCombat As System.Windows.Forms.Panel
    Friend WithEvents lblPHealtDiff As System.Windows.Forms.Label
    Friend WithEvents lblEHealthChange As System.Windows.Forms.Label
    Friend WithEvents lblTurn As System.Windows.Forms.Label
    Friend WithEvents lblPHealth As System.Windows.Forms.Label
    Friend WithEvents lblPName As System.Windows.Forms.Label
    Friend WithEvents lblEHealth As System.Windows.Forms.Label
    Friend WithEvents lblEName As System.Windows.Forms.Label
    Friend WithEvents picPHealth As System.Windows.Forms.PictureBox
    Friend WithEvents picEHbar As System.Windows.Forms.PictureBox
    Friend WithEvents lblEvent As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents picLoadBar As System.Windows.Forms.PictureBox
    Friend WithEvents lblCombatEvents As System.Windows.Forms.TextBox
    Friend WithEvents btnWait As System.Windows.Forms.Button
    Friend WithEvents picSWiz As System.Windows.Forms.PictureBox
    Friend WithEvents picSWizF As System.Windows.Forms.PictureBox
    Friend WithEvents pnlDescription As System.Windows.Forms.Panel
    Friend WithEvents lblNext As System.Windows.Forms.Label
    Friend WithEvents picDescPort As System.Windows.Forms.PictureBox
    Friend WithEvents txtPlayerDesc As System.Windows.Forms.TextBox
    Friend WithEvents ttCosts As System.Windows.Forms.ToolTip
    Friend WithEvents picStairsLock As System.Windows.Forms.PictureBox
    Friend WithEvents picStairsBoss As System.Windows.Forms.PictureBox
    Friend WithEvents picstairsbossf As System.Windows.Forms.PictureBox
    Friend WithEvents picstairslockf As System.Windows.Forms.PictureBox
    Friend WithEvents pnlSelection As System.Windows.Forms.Panel
    Friend WithEvents lblWhat As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lstSelec As System.Windows.Forms.ListBox
    Friend WithEvents lblInstruc As System.Windows.Forms.Label
    Friend WithEvents picBun As System.Windows.Forms.PictureBox
    Friend WithEvents picPrin As System.Windows.Forms.PictureBox
    Friend WithEvents picmgp1 As System.Windows.Forms.PictureBox
    Friend WithEvents picDragonM As System.Windows.Forms.PictureBox
    Friend WithEvents chkAcc As System.Windows.Forms.CheckBox
    Friend WithEvents picCrystal As System.Windows.Forms.PictureBox
    Friend WithEvents picCrystalf As System.Windows.Forms.PictureBox
    Friend WithEvents btnAbout As Button
    Friend WithEvents picPath As System.Windows.Forms.PictureBox
    Friend WithEvents picPathf As System.Windows.Forms.PictureBox
    Friend WithEvents RunAutomatedTestsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblLoadMsg As System.Windows.Forms.Label
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents picCake As System.Windows.Forms.PictureBox
    Friend WithEvents picHT As System.Windows.Forms.PictureBox
    Friend WithEvents picHTf As System.Windows.Forms.PictureBox
    Friend WithEvents picFVf As System.Windows.Forms.PictureBox
    Friend WithEvents picFVtile As System.Windows.Forms.PictureBox
    Friend WithEvents picStaffEnd As System.Windows.Forms.PictureBox
    Friend WithEvents picSpaceStairs As System.Windows.Forms.PictureBox
    Friend WithEvents picSpaceTrap As System.Windows.Forms.PictureBox
    Friend WithEvents picSpaceChest As System.Windows.Forms.PictureBox
    Friend WithEvents picSpaceTile As System.Windows.Forms.PictureBox
    Friend WithEvents picPlayerSpace As System.Windows.Forms.PictureBox
    Friend WithEvents picBimboSpace As System.Windows.Forms.PictureBox
    Friend WithEvents picSPacePath As System.Windows.Forms.PictureBox
    Friend WithEvents picSpaceCrystal As System.Windows.Forms.PictureBox
    Friend WithEvents pnlEvent As System.Windows.Forms.Panel
    Friend WithEvents txtPNLEvents As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnNextLPnlEvent As System.Windows.Forms.Button
    Friend WithEvents btnNextRPnlEvent As System.Windows.Forms.Button
    Friend WithEvents btnClosePnlEvent As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents picLegaPath As System.Windows.Forms.PictureBox
    Friend WithEvents picLegaCrystal As System.Windows.Forms.PictureBox
    Friend WithEvents picLegaPlayer As System.Windows.Forms.PictureBox
    Friend WithEvents picLegaBimbo As System.Windows.Forms.PictureBox
    Friend WithEvents picLegaStairs As System.Windows.Forms.PictureBox
    Friend WithEvents picLegaTrap As System.Windows.Forms.PictureBox
    Friend WithEvents picLegaChest As System.Windows.Forms.PictureBox
    Friend WithEvents picLegaTile As System.Windows.Forms.PictureBox
    Friend WithEvents picLegaCaelia As System.Windows.Forms.PictureBox
    Friend WithEvents picWSf As System.Windows.Forms.PictureBox
    Friend WithEvents picWS As System.Windows.Forms.PictureBox
    Friend WithEvents picDragonF As System.Windows.Forms.PictureBox
    Friend WithEvents picCBrok As System.Windows.Forms.PictureBox
    Friend WithEvents picCBrokF As System.Windows.Forms.PictureBox
    Friend WithEvents picPortOutline As System.Windows.Forms.PictureBox
    Friend WithEvents picHalfDragon2 As System.Windows.Forms.PictureBox
    Friend WithEvents picBroodmother As System.Windows.Forms.PictureBox
    Friend WithEvents picHalfDragon1 As System.Windows.Forms.PictureBox
    Friend WithEvents picBlobF As System.Windows.Forms.PictureBox
    Friend WithEvents picHorse As System.Windows.Forms.PictureBox
    Friend WithEvents picBlobM As System.Windows.Forms.PictureBox
    Friend WithEvents picOniF As System.Windows.Forms.PictureBox
    Friend WithEvents picUnicorn As System.Windows.Forms.PictureBox
    Friend WithEvents picTTTile As System.Windows.Forms.PictureBox
    Friend WithEvents picTTTileF As System.Windows.Forms.PictureBox
    Friend WithEvents DebugToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents picCow As System.Windows.Forms.PictureBox
    Friend WithEvents picCheerL As System.Windows.Forms.PictureBox
    Friend WithEvents picMGTile As System.Windows.Forms.PictureBox
    Friend WithEvents picMGTileF As System.Windows.Forms.PictureBox
    Friend WithEvents picCBFog As System.Windows.Forms.PictureBox
    Friend WithEvents picStatueFog As System.Windows.Forms.PictureBox
    Friend WithEvents picCrystalFog As System.Windows.Forms.PictureBox
    Friend WithEvents picPlayerFog As System.Windows.Forms.PictureBox
    Friend WithEvents picPlayerBFog As System.Windows.Forms.PictureBox
    Friend WithEvents picStairFog As System.Windows.Forms.PictureBox
    Friend WithEvents picTrapFog As System.Windows.Forms.PictureBox
    Friend WithEvents picChestFog As System.Windows.Forms.PictureBox
    Friend WithEvents picTileFog As System.Windows.Forms.PictureBox
    Friend WithEvents picFVFog As System.Windows.Forms.PictureBox
    Friend WithEvents picTreeFog As System.Windows.Forms.PictureBox
    Friend WithEvents picBossStairsFog As System.Windows.Forms.PictureBox
    Friend WithEvents picMushroom As System.Windows.Forms.PictureBox
    Friend WithEvents picPFaeShock As System.Windows.Forms.PictureBox
    Friend WithEvents picPFae As System.Windows.Forms.PictureBox
    Friend WithEvents pnlStats As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents pnlMeter As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblstamina As System.Windows.Forms.Label
    Friend WithEvents lblXP As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblHealthbarFont As System.Windows.Forms.Label
    Friend WithEvents pic9tailsBimbo As System.Windows.Forms.PictureBox
    Friend WithEvents picFoxStatueGold As System.Windows.Forms.PictureBox
    Friend WithEvents picFoxStatueF As System.Windows.Forms.PictureBox
    Friend WithEvents lblLust As System.Windows.Forms.Label
End Class
