<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Game
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
                'If Not seenBoardPic Is Nothing Then seenBoardPic.Dispose()
                'If Not savedBoardPic Is Nothing Then savedBoardPic.Dispose()
                'If Not boardPic Is Nothing Then boardPic.Dispose()
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
        Me.lblInventory = New System.Windows.Forms.Label()
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
        Me.ASCIIKeyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsHumanKey = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsDemonKey = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsItemKey = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsReptileKey = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsAntKey = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsBlobKey = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsDogKey = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsNymphKey = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsQuadrupedKey = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsUnicornKey = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsDragonKey = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RunAutomatedTestsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DebugToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.picPortrait = New System.Windows.Forms.PictureBox()
        Me.btnEXM = New System.Windows.Forms.Button()
        Me.lblGold = New System.Windows.Forms.Label()
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
        Me.btnSpec = New System.Windows.Forms.Button()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.chkUseable = New System.Windows.Forms.CheckBox()
        Me.chkPotion = New System.Windows.Forms.CheckBox()
        Me.chkFood = New System.Windows.Forms.CheckBox()
        Me.chkArmor = New System.Windows.Forms.CheckBox()
        Me.chkWeapon = New System.Windows.Forms.CheckBox()
        Me.chkGlasses = New System.Windows.Forms.CheckBox()
        Me.btnAll = New System.Windows.Forms.Button()
        Me.btnNone = New System.Windows.Forms.Button()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.btnT = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
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
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblEvent = New System.Windows.Forms.Label()
        Me.picLoadBar = New System.Windows.Forms.PictureBox()
        Me.btnWait = New System.Windows.Forms.Button()
        Me.pnlDescription = New System.Windows.Forms.Panel()
        Me.lblNext = New System.Windows.Forms.Label()
        Me.picDescPort = New System.Windows.Forms.PictureBox()
        Me.txtPlayerDesc = New System.Windows.Forms.TextBox()
        Me.btnEditGender = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlSelection = New System.Windows.Forms.Panel()
        Me.lblInstruc = New System.Windows.Forms.Label()
        Me.lblWhat = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lstSelec = New System.Windows.Forms.ListBox()
        Me.chkAcc = New System.Windows.Forms.CheckBox()
        Me.btnAbout = New System.Windows.Forms.Button()
        Me.lblLoadMsg = New System.Windows.Forms.Label()
        Me.pnlEvent = New System.Windows.Forms.Panel()
        Me.txtNoteEvent = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnNextLPnlEvent = New System.Windows.Forms.Button()
        Me.btnNextRPnlEvent = New System.Windows.Forms.Button()
        Me.btnClosePnlEvent = New System.Windows.Forms.Button()
        Me.txtPNLEvents = New System.Windows.Forms.TextBox()
        Me.picPortOutline = New System.Windows.Forms.PictureBox()
        Me.pnlStats = New System.Windows.Forms.Panel()
        Me.lblLust = New System.Windows.Forms.Label()
        Me.lblStats = New System.Windows.Forms.Label()
        Me.pnlMeter = New System.Windows.Forms.Panel()
        Me.lblHealthbarFont = New System.Windows.Forms.Label()
        Me.lblstamina = New System.Windows.Forms.Label()
        Me.lblXP = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pnlFusion = New System.Windows.Forms.Panel()
        Me.lblFusionDisclaimer = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.picFusionPort = New System.Windows.Forms.PictureBox()
        Me.lblFusionHP = New System.Windows.Forms.Label()
        Me.lblFusionMP = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.lblFusionLust = New System.Windows.Forms.Label()
        Me.lblFusionSPD = New System.Windows.Forms.Label()
        Me.lblFusionATK = New System.Windows.Forms.Label()
        Me.lblFusionDEF = New System.Windows.Forms.Label()
        Me.lblFusionWill = New System.Windows.Forms.Label()
        Me.lblFusionLVL = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cboxFusionTarget = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboxFusionAccessory = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cboxFusionArmor = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboxFusionWeapon = New System.Windows.Forms.ComboBox()
        Me.btnFusionAcc = New System.Windows.Forms.Button()
        Me.btnFusionCancel = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.pnlSnare = New System.Windows.Forms.Panel()
        Me.btnConfirmBait = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboxBait = New System.Windows.Forms.ComboBox()
        Me.pnlSpellSpecial = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtSpellSpecialDesc = New System.Windows.Forms.TextBox()
        Me.btnSpellSpecOK = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboxSpellSpecialDescSelector = New System.Windows.Forms.ComboBox()
        Me.pnlCastUse = New System.Windows.Forms.Panel()
        Me.btnCastSpell = New System.Windows.Forms.Button()
        Me.lblCastCost = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtCastDesc = New System.Windows.Forms.TextBox()
        Me.btnCastCancel = New System.Windows.Forms.Button()
        Me.lblKnownAbilities = New System.Windows.Forms.Label()
        Me.cboxCast = New System.Windows.Forms.ComboBox()
        Me.cboxSpec = New System.Windows.Forms.ComboBox()
        Me.pnlEquip = New System.Windows.Forms.Panel()
        Me.lblEquippedGlasses = New System.Windows.Forms.Label()
        Me.cboxGlasses = New System.Windows.Forms.ComboBox()
        Me.lblEquippedAccessory = New System.Windows.Forms.Label()
        Me.cboxAccessory = New System.Windows.Forms.ComboBox()
        Me.lblEquippedArmor = New System.Windows.Forms.Label()
        Me.cboxArmor = New System.Windows.Forms.ComboBox()
        Me.lblEquippedWeapon = New System.Windows.Forms.Label()
        Me.cboxWeapon = New System.Windows.Forms.ComboBox()
        Me.btnEquipCancel = New System.Windows.Forms.Button()
        Me.picEquipPort = New System.Windows.Forms.PictureBox()
        Me.btnEquipConfirm = New System.Windows.Forms.Button()
        Me.chkMisc = New System.Windows.Forms.CheckBox()
        Me.pnlInvFilter = New System.Windows.Forms.Panel()
        Me.picFVTBoss1 = New System.Windows.Forms.PictureBox()
        Me.picFVTBoss2 = New System.Windows.Forms.PictureBox()
        Me.picFVTBoss3 = New System.Windows.Forms.PictureBox()
        Me.picFVTBoss4 = New System.Windows.Forms.PictureBox()
        Me.btnS4 = New System.Windows.Forms.Button()
        Me.btnS5 = New System.Windows.Forms.Button()
        Me.btnS3 = New System.Windows.Forms.Button()
        Me.btnS2 = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnS1 = New System.Windows.Forms.Button()
        Me.btnS9 = New System.Windows.Forms.Button()
        Me.btnS10 = New System.Windows.Forms.Button()
        Me.btnS8 = New System.Windows.Forms.Button()
        Me.btnS7 = New System.Windows.Forms.Button()
        Me.btnS6 = New System.Windows.Forms.Button()
        Me.pnlSaveLoad = New System.Windows.Forms.Panel()
        Me.picBoard = New System.Windows.Forms.PictureBox()
        Me.picPinkMist = New System.Windows.Forms.PictureBox()
        CType(Me.picEnemy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picNPC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picStart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.picPortrait, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLust1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLust2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLust3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLust4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLust5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCombat.SuspendLayout()
        CType(Me.picLoadBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDescription.SuspendLayout()
        CType(Me.picDescPort, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSelection.SuspendLayout()
        Me.pnlEvent.SuspendLayout()
        CType(Me.picPortOutline, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlStats.SuspendLayout()
        Me.pnlMeter.SuspendLayout()
        Me.pnlFusion.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picFusionPort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSnare.SuspendLayout()
        Me.pnlSpellSpecial.SuspendLayout()
        Me.pnlCastUse.SuspendLayout()
        Me.pnlEquip.SuspendLayout()
        CType(Me.picEquipPort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picFVTBoss1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picFVTBoss2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picFVTBoss3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picFVTBoss4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSaveLoad.SuspendLayout()
        CType(Me.picBoard, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPinkMist, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnDrop
        '
        Me.btnDrop.BackColor = System.Drawing.SystemColors.Window
        Me.btnDrop.Enabled = False
        Me.btnDrop.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.btnLook.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.btnControls.Location = New System.Drawing.Point(335, 404)
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
        Me.picStart.Location = New System.Drawing.Point(0, -12)
        Me.picStart.Name = "picStart"
        Me.picStart.Size = New System.Drawing.Size(1024, 731)
        Me.picStart.TabIndex = 160
        Me.picStart.TabStop = False
        '
        'btnEQP
        '
        Me.btnEQP.BackColor = System.Drawing.SystemColors.Window
        Me.btnEQP.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.btnRUN.Location = New System.Drawing.Point(521, 419)
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
        Me.btnMG.Location = New System.Drawing.Point(327, 419)
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
        Me.btnATK.Location = New System.Drawing.Point(128, 419)
        Me.btnATK.Name = "btnATK"
        Me.btnATK.Size = New System.Drawing.Size(89, 36)
        Me.btnATK.TabIndex = 156
        Me.btnATK.Text = "Attack"
        Me.btnATK.UseVisualStyleBackColor = False
        Me.btnATK.Visible = False
        '
        'lblSPD
        '
        Me.lblSPD.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSPD.ForeColor = System.Drawing.Color.White
        Me.lblSPD.Location = New System.Drawing.Point(5, 62)
        Me.lblSPD.Name = "lblSPD"
        Me.lblSPD.Size = New System.Drawing.Size(120, 14)
        Me.lblSPD.TabIndex = 154
        Me.lblSPD.Text = "SPD = TEMP"
        '
        'lblWIL
        '
        Me.lblWIL.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWIL.ForeColor = System.Drawing.Color.White
        Me.lblWIL.Location = New System.Drawing.Point(5, 81)
        Me.lblWIL.Name = "lblWIL"
        Me.lblWIL.Size = New System.Drawing.Size(120, 14)
        Me.lblWIL.TabIndex = 153
        Me.lblWIL.Text = "WILL = TEMP"
        '
        'lblDEF
        '
        Me.lblDEF.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDEF.ForeColor = System.Drawing.Color.White
        Me.lblDEF.Location = New System.Drawing.Point(5, 43)
        Me.lblDEF.Name = "lblDEF"
        Me.lblDEF.Size = New System.Drawing.Size(120, 14)
        Me.lblDEF.TabIndex = 152
        Me.lblDEF.Text = "DEF = TEMP"
        '
        'lblATK
        '
        Me.lblATK.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblATK.ForeColor = System.Drawing.Color.White
        Me.lblATK.Location = New System.Drawing.Point(5, 24)
        Me.lblATK.Name = "lblATK"
        Me.lblATK.Size = New System.Drawing.Size(120, 14)
        Me.lblATK.TabIndex = 151
        Me.lblATK.Text = "ATK = TEMP"
        '
        'lblLevel
        '
        Me.lblLevel.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLevel.ForeColor = System.Drawing.Color.White
        Me.lblLevel.Location = New System.Drawing.Point(5, 6)
        Me.lblLevel.Name = "lblLevel"
        Me.lblLevel.Size = New System.Drawing.Size(120, 14)
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
        Me.lblNameTitle.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNameTitle.ForeColor = System.Drawing.Color.White
        Me.lblNameTitle.Location = New System.Drawing.Point(731, 13)
        Me.lblNameTitle.Margin = New System.Windows.Forms.Padding(0)
        Me.lblNameTitle.MaximumSize = New System.Drawing.Size(270, 20)
        Me.lblNameTitle.Name = "lblNameTitle"
        Me.lblNameTitle.Size = New System.Drawing.Size(270, 20)
        Me.lblNameTitle.TabIndex = 145
        Me.lblNameTitle.Text = "Name the Title"
        Me.lblNameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInventory
        '
        Me.lblInventory.BackColor = System.Drawing.Color.Black
        Me.lblInventory.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInventory.ForeColor = System.Drawing.Color.White
        Me.lblInventory.Location = New System.Drawing.Point(731, 397)
        Me.lblInventory.Margin = New System.Windows.Forms.Padding(0)
        Me.lblInventory.Name = "lblInventory"
        Me.lblInventory.Size = New System.Drawing.Size(152, 18)
        Me.lblInventory.TabIndex = 144
        Me.lblInventory.Text = "Inventory:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnUse
        '
        Me.btnUse.BackColor = System.Drawing.SystemColors.Window
        Me.btnUse.Enabled = False
        Me.btnUse.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUse.Location = New System.Drawing.Point(740, 606)
        Me.btnUse.Name = "btnUse"
        Me.btnUse.Size = New System.Drawing.Size(75, 34)
        Me.btnUse.TabIndex = 3
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
        Me.lstInventory.Size = New System.Drawing.Size(262, 180)
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
        Me.lstLog.Size = New System.Drawing.Size(701, 144)
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
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpToolStripMenuItem1, Me.ASCIIKeyToolStripMenuItem, Me.ReportToolStripMenuItem, Me.InfoToolStripMenuItem, Me.RunAutomatedTestsToolStripMenuItem})
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
        Me.HelpToolStripMenuItem1.Size = New System.Drawing.Size(165, 22)
        Me.HelpToolStripMenuItem1.Text = "Controls"
        '
        'ASCIIKeyToolStripMenuItem
        '
        Me.ASCIIKeyToolStripMenuItem.BackColor = System.Drawing.Color.Black
        Me.ASCIIKeyToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsHumanKey, Me.tsDemonKey, Me.tsItemKey, Me.tsReptileKey, Me.tsAntKey, Me.tsBlobKey, Me.tsDogKey, Me.tsNymphKey, Me.tsQuadrupedKey, Me.tsUnicornKey, Me.tsDragonKey})
        Me.ASCIIKeyToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.ASCIIKeyToolStripMenuItem.Name = "ASCIIKeyToolStripMenuItem"
        Me.ASCIIKeyToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.ASCIIKeyToolStripMenuItem.Text = "ASCII Symbols"
        '
        'tsHumanKey
        '
        Me.tsHumanKey.BackColor = System.Drawing.Color.Black
        Me.tsHumanKey.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsHumanKey.ForeColor = System.Drawing.Color.White
        Me.tsHumanKey.Name = "tsHumanKey"
        Me.tsHumanKey.Size = New System.Drawing.Size(221, 22)
        Me.tsHumanKey.Text = "@ = Human/Humanoid"
        '
        'tsDemonKey
        '
        Me.tsDemonKey.BackColor = System.Drawing.Color.Black
        Me.tsDemonKey.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsDemonKey.ForeColor = System.Drawing.Color.White
        Me.tsDemonKey.Name = "tsDemonKey"
        Me.tsDemonKey.Size = New System.Drawing.Size(221, 22)
        Me.tsDemonKey.Text = "&& = Demon"
        '
        'tsItemKey
        '
        Me.tsItemKey.BackColor = System.Drawing.Color.Black
        Me.tsItemKey.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsItemKey.ForeColor = System.Drawing.Color.White
        Me.tsItemKey.Name = "tsItemKey"
        Me.tsItemKey.Size = New System.Drawing.Size(221, 22)
        Me.tsItemKey.Text = "( = Item"
        '
        'tsReptileKey
        '
        Me.tsReptileKey.BackColor = System.Drawing.Color.Black
        Me.tsReptileKey.ForeColor = System.Drawing.Color.White
        Me.tsReptileKey.Name = "tsReptileKey"
        Me.tsReptileKey.Size = New System.Drawing.Size(221, 22)
        Me.tsReptileKey.Text = ": = Amphibian/Reptile"
        '
        'tsAntKey
        '
        Me.tsAntKey.BackColor = System.Drawing.Color.Black
        Me.tsAntKey.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsAntKey.ForeColor = System.Drawing.Color.White
        Me.tsAntKey.Name = "tsAntKey"
        Me.tsAntKey.Size = New System.Drawing.Size(221, 22)
        Me.tsAntKey.Text = "a = Ant/Insect"
        '
        'tsBlobKey
        '
        Me.tsBlobKey.BackColor = System.Drawing.Color.Black
        Me.tsBlobKey.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsBlobKey.ForeColor = System.Drawing.Color.White
        Me.tsBlobKey.Name = "tsBlobKey"
        Me.tsBlobKey.Size = New System.Drawing.Size(221, 22)
        Me.tsBlobKey.Text = "b = Blob/Slime"
        '
        'tsDogKey
        '
        Me.tsDogKey.BackColor = System.Drawing.Color.Black
        Me.tsDogKey.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsDogKey.ForeColor = System.Drawing.Color.White
        Me.tsDogKey.Name = "tsDogKey"
        Me.tsDogKey.Size = New System.Drawing.Size(221, 22)
        Me.tsDogKey.Text = "d = Dog/Fox"
        '
        'tsNymphKey
        '
        Me.tsNymphKey.BackColor = System.Drawing.Color.Black
        Me.tsNymphKey.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsNymphKey.ForeColor = System.Drawing.Color.White
        Me.tsNymphKey.Name = "tsNymphKey"
        Me.tsNymphKey.Size = New System.Drawing.Size(221, 22)
        Me.tsNymphKey.Text = "n = Nymph/Alraune"
        '
        'tsQuadrupedKey
        '
        Me.tsQuadrupedKey.BackColor = System.Drawing.Color.Black
        Me.tsQuadrupedKey.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsQuadrupedKey.ForeColor = System.Drawing.Color.White
        Me.tsQuadrupedKey.Name = "tsQuadrupedKey"
        Me.tsQuadrupedKey.Size = New System.Drawing.Size(221, 22)
        Me.tsQuadrupedKey.Text = "q = Quadruped/Bovine"
        '
        'tsUnicornKey
        '
        Me.tsUnicornKey.BackColor = System.Drawing.Color.Black
        Me.tsUnicornKey.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsUnicornKey.ForeColor = System.Drawing.Color.White
        Me.tsUnicornKey.Name = "tsUnicornKey"
        Me.tsUnicornKey.Size = New System.Drawing.Size(221, 22)
        Me.tsUnicornKey.Text = "u = Unicorn/Horse"
        '
        'tsDragonKey
        '
        Me.tsDragonKey.BackColor = System.Drawing.Color.Black
        Me.tsDragonKey.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsDragonKey.ForeColor = System.Drawing.Color.White
        Me.tsDragonKey.Name = "tsDragonKey"
        Me.tsDragonKey.Size = New System.Drawing.Size(221, 22)
        Me.tsDragonKey.Text = "D = Dragon"
        '
        'ReportToolStripMenuItem
        '
        Me.ReportToolStripMenuItem.BackColor = System.Drawing.Color.Black
        Me.ReportToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        Me.ReportToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.ReportToolStripMenuItem.Text = "Report"
        '
        'InfoToolStripMenuItem
        '
        Me.InfoToolStripMenuItem.BackColor = System.Drawing.Color.Black
        Me.InfoToolStripMenuItem.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfoToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.InfoToolStripMenuItem.Name = "InfoToolStripMenuItem"
        Me.InfoToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.InfoToolStripMenuItem.Text = "Info"
        '
        'RunAutomatedTestsToolStripMenuItem
        '
        Me.RunAutomatedTestsToolStripMenuItem.BackColor = System.Drawing.Color.Black
        Me.RunAutomatedTestsToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.RunAutomatedTestsToolStripMenuItem.Name = "RunAutomatedTestsToolStripMenuItem"
        Me.RunAutomatedTestsToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.RunAutomatedTestsToolStripMenuItem.Text = "Run Tests"
        Me.RunAutomatedTestsToolStripMenuItem.Visible = False
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
        Me.btnEXM.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEXM.Location = New System.Drawing.Point(860, 345)
        Me.btnEXM.Name = "btnEXM"
        Me.btnEXM.Size = New System.Drawing.Size(136, 33)
        Me.btnEXM.TabIndex = 209
        Me.btnEXM.Text = "Examine Self"
        Me.btnEXM.UseVisualStyleBackColor = False
        '
        'lblGold
        '
        Me.lblGold.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGold.ForeColor = System.Drawing.Color.White
        Me.lblGold.Location = New System.Drawing.Point(5, 119)
        Me.lblGold.Name = "lblGold"
        Me.lblGold.Size = New System.Drawing.Size(120, 14)
        Me.lblGold.TabIndex = 210
        Me.lblGold.Text = "GOLD = 999999+"
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
        'btnSpec
        '
        Me.btnSpec.BackColor = System.Drawing.Color.Black
        Me.btnSpec.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSpec.ForeColor = System.Drawing.Color.White
        Me.btnSpec.Location = New System.Drawing.Point(228, 419)
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
        Me.btnOk.Location = New System.Drawing.Point(897, 564)
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
        Me.chkUseable.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkUseable.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black
        Me.chkUseable.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.chkUseable.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.chkUseable.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkUseable.ForeColor = System.Drawing.Color.White
        Me.chkUseable.Location = New System.Drawing.Point(739, 423)
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
        Me.chkPotion.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkPotion.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black
        Me.chkPotion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.chkPotion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.chkPotion.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPotion.ForeColor = System.Drawing.Color.White
        Me.chkPotion.Location = New System.Drawing.Point(739, 445)
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
        Me.chkFood.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkFood.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black
        Me.chkFood.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.chkFood.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.chkFood.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFood.ForeColor = System.Drawing.Color.White
        Me.chkFood.Location = New System.Drawing.Point(739, 467)
        Me.chkFood.Name = "chkFood"
        Me.chkFood.Size = New System.Drawing.Size(59, 21)
        Me.chkFood.TabIndex = 238
        Me.chkFood.Text = "Food"
        Me.chkFood.UseVisualStyleBackColor = True
        Me.chkFood.Visible = False
        '
        'chkArmor
        '
        Me.chkArmor.AutoSize = True
        Me.chkArmor.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkArmor.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black
        Me.chkArmor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.chkArmor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.chkArmor.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkArmor.ForeColor = System.Drawing.Color.White
        Me.chkArmor.Location = New System.Drawing.Point(739, 489)
        Me.chkArmor.Name = "chkArmor"
        Me.chkArmor.Size = New System.Drawing.Size(67, 21)
        Me.chkArmor.TabIndex = 239
        Me.chkArmor.Text = "Armor"
        Me.chkArmor.UseVisualStyleBackColor = True
        Me.chkArmor.Visible = False
        '
        'chkWeapon
        '
        Me.chkWeapon.AutoSize = True
        Me.chkWeapon.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkWeapon.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black
        Me.chkWeapon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.chkWeapon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.chkWeapon.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkWeapon.ForeColor = System.Drawing.Color.White
        Me.chkWeapon.Location = New System.Drawing.Point(739, 511)
        Me.chkWeapon.Name = "chkWeapon"
        Me.chkWeapon.Size = New System.Drawing.Size(75, 21)
        Me.chkWeapon.TabIndex = 240
        Me.chkWeapon.Text = "Weapon"
        Me.chkWeapon.UseVisualStyleBackColor = True
        Me.chkWeapon.Visible = False
        '
        'chkGlasses
        '
        Me.chkGlasses.AutoSize = True
        Me.chkGlasses.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkGlasses.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black
        Me.chkGlasses.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.chkGlasses.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.chkGlasses.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkGlasses.ForeColor = System.Drawing.Color.White
        Me.chkGlasses.Location = New System.Drawing.Point(739, 555)
        Me.chkGlasses.Name = "chkGlasses"
        Me.chkGlasses.Size = New System.Drawing.Size(83, 21)
        Me.chkGlasses.TabIndex = 241
        Me.chkGlasses.Text = "Glasses"
        Me.chkGlasses.UseVisualStyleBackColor = True
        Me.chkGlasses.Visible = False
        '
        'btnAll
        '
        Me.btnAll.BackColor = System.Drawing.SystemColors.Window
        Me.btnAll.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAll.Location = New System.Drawing.Point(942, 425)
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
        Me.btnNone.Location = New System.Drawing.Point(891, 425)
        Me.btnNone.Name = "btnNone"
        Me.btnNone.Size = New System.Drawing.Size(48, 29)
        Me.btnNone.TabIndex = 243
        Me.btnNone.Text = "None"
        Me.btnNone.UseVisualStyleBackColor = False
        Me.btnNone.Visible = False
        '
        'btnSettings
        '
        Me.btnSettings.BackColor = System.Drawing.Color.Black
        Me.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSettings.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSettings.ForeColor = System.Drawing.Color.White
        Me.btnSettings.Location = New System.Drawing.Point(549, 404)
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
        Me.btnT.Location = New System.Drawing.Point(444, 402)
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
        Me.Button1.Location = New System.Drawing.Point(335, 447)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(313, 39)
        Me.Button1.TabIndex = 248
        Me.Button1.Text = "Custom Content"
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
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
        Me.pnlCombat.Controls.Add(Me.Label18)
        Me.pnlCombat.Controls.Add(Me.Label20)
        Me.pnlCombat.Location = New System.Drawing.Point(1000, 50)
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
        Me.lblCombatEvents.Location = New System.Drawing.Point(8, 93)
        Me.lblCombatEvents.Multiline = True
        Me.lblCombatEvents.Name = "lblCombatEvents"
        Me.lblCombatEvents.ReadOnly = True
        Me.lblCombatEvents.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.lblCombatEvents.Size = New System.Drawing.Size(549, 242)
        Me.lblCombatEvents.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(5, 341)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(280, 14)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Press a combat button to continue . . ."
        '
        'lblPHealtDiff
        '
        Me.lblPHealtDiff.AutoSize = True
        Me.lblPHealtDiff.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPHealtDiff.ForeColor = System.Drawing.Color.White
        Me.lblPHealtDiff.Location = New System.Drawing.Point(354, 68)
        Me.lblPHealtDiff.Name = "lblPHealtDiff"
        Me.lblPHealtDiff.Size = New System.Drawing.Size(35, 14)
        Me.lblPHealtDiff.TabIndex = 8
        Me.lblPHealtDiff.Text = "-999"
        Me.lblPHealtDiff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEHealthChange
        '
        Me.lblEHealthChange.AutoSize = True
        Me.lblEHealthChange.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEHealthChange.ForeColor = System.Drawing.Color.White
        Me.lblEHealthChange.Location = New System.Drawing.Point(179, 68)
        Me.lblEHealthChange.Name = "lblEHealthChange"
        Me.lblEHealthChange.Size = New System.Drawing.Size(35, 14)
        Me.lblEHealthChange.TabIndex = 7
        Me.lblEHealthChange.Text = "-999"
        Me.lblEHealthChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTurn
        '
        Me.lblTurn.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurn.ForeColor = System.Drawing.Color.White
        Me.lblTurn.Location = New System.Drawing.Point(209, 5)
        Me.lblTurn.Name = "lblTurn"
        Me.lblTurn.Size = New System.Drawing.Size(149, 18)
        Me.lblTurn.TabIndex = 6
        Me.lblTurn.Text = "Turn: 99999"
        Me.lblTurn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPHealth
        '
        Me.lblPHealth.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPHealth.ForeColor = System.Drawing.Color.White
        Me.lblPHealth.Location = New System.Drawing.Point(353, 48)
        Me.lblPHealth.Name = "lblPHealth"
        Me.lblPHealth.Size = New System.Drawing.Size(200, 14)
        Me.lblPHealth.TabIndex = 5
        Me.lblPHealth.Text = "9999/9999"
        Me.lblPHealth.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPName
        '
        Me.lblPName.BackColor = System.Drawing.Color.Black
        Me.lblPName.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPName.ForeColor = System.Drawing.Color.White
        Me.lblPName.Location = New System.Drawing.Point(341, 14)
        Me.lblPName.Name = "lblPName"
        Me.lblPName.Size = New System.Drawing.Size(216, 27)
        Me.lblPName.TabIndex = 4
        Me.lblPName.Text = "PlayerName"
        Me.lblPName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEHealth
        '
        Me.lblEHealth.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEHealth.ForeColor = System.Drawing.Color.White
        Me.lblEHealth.Location = New System.Drawing.Point(15, 47)
        Me.lblEHealth.Name = "lblEHealth"
        Me.lblEHealth.Size = New System.Drawing.Size(200, 14)
        Me.lblEHealth.TabIndex = 3
        Me.lblEHealth.Text = "9999/9999"
        Me.lblEHealth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'Label18
        '
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(351, 46)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(205, 19)
        Me.Label18.TabIndex = 12
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label20.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(11, 45)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(205, 19)
        Me.Label20.TabIndex = 13
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.btnWait.Location = New System.Drawing.Point(426, 419)
        Me.btnWait.Name = "btnWait"
        Me.btnWait.Size = New System.Drawing.Size(86, 36)
        Me.btnWait.TabIndex = 272
        Me.btnWait.Text = "Wait"
        Me.btnWait.UseVisualStyleBackColor = False
        Me.btnWait.Visible = False
        '
        'pnlDescription
        '
        Me.pnlDescription.BackgroundImage = CType(resources.GetObject("pnlDescription.BackgroundImage"), System.Drawing.Image)
        Me.pnlDescription.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDescription.Controls.Add(Me.lblNext)
        Me.pnlDescription.Controls.Add(Me.picDescPort)
        Me.pnlDescription.Controls.Add(Me.txtPlayerDesc)
        Me.pnlDescription.Controls.Add(Me.btnEditGender)
        Me.pnlDescription.Controls.Add(Me.Label5)
        Me.pnlDescription.Location = New System.Drawing.Point(1000, 44)
        Me.pnlDescription.Name = "pnlDescription"
        Me.pnlDescription.Size = New System.Drawing.Size(690, 502)
        Me.pnlDescription.TabIndex = 275
        Me.pnlDescription.Visible = False
        '
        'lblNext
        '
        Me.lblNext.BackColor = System.Drawing.Color.Black
        Me.lblNext.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNext.ForeColor = System.Drawing.Color.White
        Me.lblNext.Location = New System.Drawing.Point(23, 475)
        Me.lblNext.Name = "lblNext"
        Me.lblNext.Size = New System.Drawing.Size(469, 14)
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
        'btnEditGender
        '
        Me.btnEditGender.BackColor = System.Drawing.Color.Black
        Me.btnEditGender.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEditGender.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditGender.ForeColor = System.Drawing.Color.Gray
        Me.btnEditGender.Location = New System.Drawing.Point(414, 3)
        Me.btnEditGender.Name = "btnEditGender"
        Me.btnEditGender.Size = New System.Drawing.Size(20, 20)
        Me.btnEditGender.TabIndex = 279
        Me.btnEditGender.Text = "✎"
        Me.btnEditGender.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEditGender.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(93, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(397, 13)
        Me.Label5.TabIndex = 278
        Me.Label5.Text = "Note: Some images have not yet been updated to the full body size"
        Me.Label5.Visible = False
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
        Me.lblInstruc.BackColor = System.Drawing.Color.Black
        Me.lblInstruc.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInstruc.ForeColor = System.Drawing.Color.White
        Me.lblInstruc.Location = New System.Drawing.Point(6, 61)
        Me.lblInstruc.Name = "lblInstruc"
        Me.lblInstruc.Size = New System.Drawing.Size(227, 131)
        Me.lblInstruc.TabIndex = 280
        Me.lblInstruc.Text = "Type the " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "corresponding" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "letter:"
        '
        'lblWhat
        '
        Me.lblWhat.BackColor = System.Drawing.Color.Black
        Me.lblWhat.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWhat.ForeColor = System.Drawing.Color.White
        Me.lblWhat.Location = New System.Drawing.Point(8, 8)
        Me.lblWhat.Name = "lblWhat"
        Me.lblWhat.Size = New System.Drawing.Size(560, 14)
        Me.lblWhat.TabIndex = 279
        Me.lblWhat.Text = "Verb what?"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Black
        Me.Label3.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(7, 262)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(560, 14)
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
        Me.lstSelec.Size = New System.Drawing.Size(330, 140)
        Me.lstSelec.TabIndex = 142
        '
        'chkAcc
        '
        Me.chkAcc.AutoSize = True
        Me.chkAcc.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkAcc.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black
        Me.chkAcc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.chkAcc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.chkAcc.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAcc.ForeColor = System.Drawing.Color.White
        Me.chkAcc.Location = New System.Drawing.Point(739, 533)
        Me.chkAcc.Name = "chkAcc"
        Me.chkAcc.Size = New System.Drawing.Size(115, 21)
        Me.chkAcc.TabIndex = 289
        Me.chkAcc.Text = "Accessories"
        Me.chkAcc.UseVisualStyleBackColor = True
        Me.chkAcc.Visible = False
        '
        'btnAbout
        '
        Me.btnAbout.BackColor = System.Drawing.Color.Black
        Me.btnAbout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAbout.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAbout.ForeColor = System.Drawing.Color.White
        Me.btnAbout.Location = New System.Drawing.Point(441, 596)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(99, 39)
        Me.btnAbout.TabIndex = 292
        Me.btnAbout.Text = "About"
        Me.btnAbout.UseVisualStyleBackColor = False
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
        'pnlEvent
        '
        Me.pnlEvent.AutoScroll = True
        Me.pnlEvent.BackgroundImage = CType(resources.GetObject("pnlEvent.BackgroundImage"), System.Drawing.Image)
        Me.pnlEvent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlEvent.Controls.Add(Me.txtNoteEvent)
        Me.pnlEvent.Controls.Add(Me.Label4)
        Me.pnlEvent.Controls.Add(Me.btnNextLPnlEvent)
        Me.pnlEvent.Controls.Add(Me.btnNextRPnlEvent)
        Me.pnlEvent.Controls.Add(Me.btnClosePnlEvent)
        Me.pnlEvent.Controls.Add(Me.txtPNLEvents)
        Me.pnlEvent.Location = New System.Drawing.Point(1000, 26)
        Me.pnlEvent.Name = "pnlEvent"
        Me.pnlEvent.Size = New System.Drawing.Size(688, 447)
        Me.pnlEvent.TabIndex = 322
        Me.pnlEvent.Visible = False
        '
        'txtNoteEvent
        '
        Me.txtNoteEvent.BackColor = System.Drawing.Color.Black
        Me.txtNoteEvent.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtNoteEvent.Font = New System.Drawing.Font("Segoe Print", 11.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoteEvent.ForeColor = System.Drawing.Color.Peru
        Me.txtNoteEvent.Location = New System.Drawing.Point(93, 13)
        Me.txtNoteEvent.Margin = New System.Windows.Forms.Padding(10)
        Me.txtNoteEvent.Multiline = True
        Me.txtNoteEvent.Name = "txtNoteEvent"
        Me.txtNoteEvent.ReadOnly = True
        Me.txtNoteEvent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNoteEvent.Size = New System.Drawing.Size(488, 389)
        Me.txtNoteEvent.TabIndex = 237
        Me.txtNoteEvent.Text = "iiiiiiiiiiiiiiiii....iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii" & _
    "iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii" & _
    "iiiiiiiiiiiiiiiiiiiiiiiiiiii"
        Me.txtNoteEvent.Visible = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Consolas", 10.2!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(13, 416)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(448, 17)
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
        'picPortOutline
        '
        Me.picPortOutline.BackgroundImage = CType(resources.GetObject("picPortOutline.BackgroundImage"), System.Drawing.Image)
        Me.picPortOutline.Location = New System.Drawing.Point(45, 70)
        Me.picPortOutline.Name = "picPortOutline"
        Me.picPortOutline.Size = New System.Drawing.Size(15, 15)
        Me.picPortOutline.TabIndex = 349
        Me.picPortOutline.TabStop = False
        Me.picPortOutline.Visible = False
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
        'lblLust
        '
        Me.lblLust.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLust.ForeColor = System.Drawing.Color.White
        Me.lblLust.Location = New System.Drawing.Point(5, 100)
        Me.lblLust.Name = "lblLust"
        Me.lblLust.Size = New System.Drawing.Size(120, 14)
        Me.lblLust.TabIndex = 211
        Me.lblLust.Text = "LUST = TEMP"
        '
        'lblStats
        '
        Me.lblStats.BackColor = System.Drawing.Color.Black
        Me.lblStats.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStats.ForeColor = System.Drawing.Color.White
        Me.lblStats.Location = New System.Drawing.Point(731, 129)
        Me.lblStats.Margin = New System.Windows.Forms.Padding(0)
        Me.lblStats.Name = "lblStats"
        Me.lblStats.Size = New System.Drawing.Size(150, 18)
        Me.lblStats.TabIndex = 399
        Me.lblStats.Text = "Stats:"
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
        Me.pnlMeter.Location = New System.Drawing.Point(733, 36)
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
        Me.Label11.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(6, 58)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(28, 14)
        Me.Label11.TabIndex = 153
        Me.Label11.Text = "XP: "
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(6, 6)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(28, 14)
        Me.Label8.TabIndex = 150
        Me.Label8.Text = "HP: "
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(6, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(28, 14)
        Me.Label9.TabIndex = 151
        Me.Label9.Text = "MP: "
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(6, 41)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(28, 14)
        Me.Label10.TabIndex = 152
        Me.Label10.Text = "ST: "
        '
        'pnlFusion
        '
        Me.pnlFusion.BackColor = System.Drawing.Color.Black
        Me.pnlFusion.BackgroundImage = CType(resources.GetObject("pnlFusion.BackgroundImage"), System.Drawing.Image)
        Me.pnlFusion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlFusion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFusion.Controls.Add(Me.lblFusionDisclaimer)
        Me.pnlFusion.Controls.Add(Me.PictureBox1)
        Me.pnlFusion.Controls.Add(Me.picFusionPort)
        Me.pnlFusion.Controls.Add(Me.lblFusionHP)
        Me.pnlFusion.Controls.Add(Me.lblFusionMP)
        Me.pnlFusion.Controls.Add(Me.Label24)
        Me.pnlFusion.Controls.Add(Me.lblFusionLust)
        Me.pnlFusion.Controls.Add(Me.lblFusionSPD)
        Me.pnlFusion.Controls.Add(Me.lblFusionATK)
        Me.pnlFusion.Controls.Add(Me.lblFusionDEF)
        Me.pnlFusion.Controls.Add(Me.lblFusionWill)
        Me.pnlFusion.Controls.Add(Me.lblFusionLVL)
        Me.pnlFusion.Controls.Add(Me.Label16)
        Me.pnlFusion.Controls.Add(Me.cboxFusionTarget)
        Me.pnlFusion.Controls.Add(Me.Label13)
        Me.pnlFusion.Controls.Add(Me.cboxFusionAccessory)
        Me.pnlFusion.Controls.Add(Me.Label14)
        Me.pnlFusion.Controls.Add(Me.cboxFusionArmor)
        Me.pnlFusion.Controls.Add(Me.Label15)
        Me.pnlFusion.Controls.Add(Me.cboxFusionWeapon)
        Me.pnlFusion.Controls.Add(Me.btnFusionAcc)
        Me.pnlFusion.Controls.Add(Me.btnFusionCancel)
        Me.pnlFusion.Controls.Add(Me.PictureBox2)
        Me.pnlFusion.Location = New System.Drawing.Point(1000, 83)
        Me.pnlFusion.Name = "pnlFusion"
        Me.pnlFusion.Size = New System.Drawing.Size(591, 295)
        Me.pnlFusion.TabIndex = 404
        Me.pnlFusion.Visible = False
        '
        'lblFusionDisclaimer
        '
        Me.lblFusionDisclaimer.AutoSize = True
        Me.lblFusionDisclaimer.BackColor = System.Drawing.Color.Black
        Me.lblFusionDisclaimer.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFusionDisclaimer.ForeColor = System.Drawing.Color.White
        Me.lblFusionDisclaimer.Location = New System.Drawing.Point(8, 241)
        Me.lblFusionDisclaimer.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFusionDisclaimer.Name = "lblFusionDisclaimer"
        Me.lblFusionDisclaimer.Size = New System.Drawing.Size(577, 13)
        Me.lblFusionDisclaimer.TabIndex = 226
        Me.lblFusionDisclaimer.Text = "This will rewrite your current player permenantly (Restore potions will restore t" & _
    "o the fusion)."
        Me.lblFusionDisclaimer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(330, 52)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(110, 1)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 224
        Me.PictureBox1.TabStop = False
        '
        'picFusionPort
        '
        Me.picFusionPort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picFusionPort.Location = New System.Drawing.Point(446, 30)
        Me.picFusionPort.Name = "picFusionPort"
        Me.picFusionPort.Size = New System.Drawing.Size(125, 189)
        Me.picFusionPort.TabIndex = 223
        Me.picFusionPort.TabStop = False
        '
        'lblFusionHP
        '
        Me.lblFusionHP.AutoSize = True
        Me.lblFusionHP.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFusionHP.ForeColor = System.Drawing.Color.White
        Me.lblFusionHP.Location = New System.Drawing.Point(328, 74)
        Me.lblFusionHP.Name = "lblFusionHP"
        Me.lblFusionHP.Size = New System.Drawing.Size(98, 14)
        Me.lblFusionHP.TabIndex = 220
        Me.lblFusionHP.Text = "Max HP = TEMP"
        '
        'lblFusionMP
        '
        Me.lblFusionMP.AutoSize = True
        Me.lblFusionMP.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFusionMP.ForeColor = System.Drawing.Color.White
        Me.lblFusionMP.Location = New System.Drawing.Point(328, 93)
        Me.lblFusionMP.Name = "lblFusionMP"
        Me.lblFusionMP.Size = New System.Drawing.Size(98, 14)
        Me.lblFusionMP.TabIndex = 221
        Me.lblFusionMP.Text = "Max MP = TEMP"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Black
        Me.Label24.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(329, 33)
        Me.Label24.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Padding = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label24.Size = New System.Drawing.Size(84, 17)
        Me.Label24.TabIndex = 219
        Me.Label24.Text = "-- Stats --"
        '
        'lblFusionLust
        '
        Me.lblFusionLust.AutoSize = True
        Me.lblFusionLust.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFusionLust.ForeColor = System.Drawing.Color.White
        Me.lblFusionLust.Location = New System.Drawing.Point(328, 188)
        Me.lblFusionLust.Name = "lblFusionLust"
        Me.lblFusionLust.Size = New System.Drawing.Size(84, 14)
        Me.lblFusionLust.TabIndex = 218
        Me.lblFusionLust.Text = "LUST = TEMP"
        '
        'lblFusionSPD
        '
        Me.lblFusionSPD.AutoSize = True
        Me.lblFusionSPD.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFusionSPD.ForeColor = System.Drawing.Color.White
        Me.lblFusionSPD.Location = New System.Drawing.Point(328, 150)
        Me.lblFusionSPD.Name = "lblFusionSPD"
        Me.lblFusionSPD.Size = New System.Drawing.Size(77, 14)
        Me.lblFusionSPD.TabIndex = 216
        Me.lblFusionSPD.Text = "SPD = TEMP"
        '
        'lblFusionATK
        '
        Me.lblFusionATK.AutoSize = True
        Me.lblFusionATK.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFusionATK.ForeColor = System.Drawing.Color.White
        Me.lblFusionATK.Location = New System.Drawing.Point(328, 112)
        Me.lblFusionATK.Name = "lblFusionATK"
        Me.lblFusionATK.Size = New System.Drawing.Size(77, 14)
        Me.lblFusionATK.TabIndex = 213
        Me.lblFusionATK.Text = "ATK = TEMP"
        '
        'lblFusionDEF
        '
        Me.lblFusionDEF.AutoSize = True
        Me.lblFusionDEF.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFusionDEF.ForeColor = System.Drawing.Color.White
        Me.lblFusionDEF.Location = New System.Drawing.Point(328, 131)
        Me.lblFusionDEF.Name = "lblFusionDEF"
        Me.lblFusionDEF.Size = New System.Drawing.Size(77, 14)
        Me.lblFusionDEF.TabIndex = 214
        Me.lblFusionDEF.Text = "DEF = TEMP"
        '
        'lblFusionWill
        '
        Me.lblFusionWill.AutoSize = True
        Me.lblFusionWill.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFusionWill.ForeColor = System.Drawing.Color.White
        Me.lblFusionWill.Location = New System.Drawing.Point(328, 169)
        Me.lblFusionWill.Name = "lblFusionWill"
        Me.lblFusionWill.Size = New System.Drawing.Size(84, 14)
        Me.lblFusionWill.TabIndex = 215
        Me.lblFusionWill.Text = "WILL = TEMP"
        '
        'lblFusionLVL
        '
        Me.lblFusionLVL.AutoSize = True
        Me.lblFusionLVL.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFusionLVL.ForeColor = System.Drawing.Color.White
        Me.lblFusionLVL.Location = New System.Drawing.Point(327, 56)
        Me.lblFusionLVL.Name = "lblFusionLVL"
        Me.lblFusionLVL.Size = New System.Drawing.Size(77, 14)
        Me.lblFusionLVL.TabIndex = 212
        Me.lblFusionLVL.Text = "Level TEMP"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Black
        Me.Label16.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(15, 14)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(105, 15)
        Me.Label16.TabIndex = 154
        Me.Label16.Text = "Fusion Target:"
        '
        'cboxFusionTarget
        '
        Me.cboxFusionTarget.BackColor = System.Drawing.Color.Black
        Me.cboxFusionTarget.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboxFusionTarget.ForeColor = System.Drawing.Color.White
        Me.cboxFusionTarget.FormattingEnabled = True
        Me.cboxFusionTarget.Location = New System.Drawing.Point(16, 33)
        Me.cboxFusionTarget.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboxFusionTarget.Name = "cboxFusionTarget"
        Me.cboxFusionTarget.Size = New System.Drawing.Size(262, 21)
        Me.cboxFusionTarget.TabIndex = 153
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Black
        Me.Label13.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(12, 178)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(231, 15)
        Me.Label13.TabIndex = 152
        Me.Label13.Text = "Equipped Accessory After Fusion:"
        '
        'cboxFusionAccessory
        '
        Me.cboxFusionAccessory.BackColor = System.Drawing.Color.Black
        Me.cboxFusionAccessory.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboxFusionAccessory.ForeColor = System.Drawing.Color.White
        Me.cboxFusionAccessory.FormattingEnabled = True
        Me.cboxFusionAccessory.Location = New System.Drawing.Point(14, 203)
        Me.cboxFusionAccessory.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboxFusionAccessory.Name = "cboxFusionAccessory"
        Me.cboxFusionAccessory.Size = New System.Drawing.Size(264, 21)
        Me.cboxFusionAccessory.TabIndex = 151
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Black
        Me.Label14.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(12, 122)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(203, 15)
        Me.Label14.TabIndex = 150
        Me.Label14.Text = "Equipped Armor After Fusion:"
        '
        'cboxFusionArmor
        '
        Me.cboxFusionArmor.BackColor = System.Drawing.Color.Black
        Me.cboxFusionArmor.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboxFusionArmor.ForeColor = System.Drawing.Color.White
        Me.cboxFusionArmor.FormattingEnabled = True
        Me.cboxFusionArmor.Location = New System.Drawing.Point(14, 147)
        Me.cboxFusionArmor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboxFusionArmor.Name = "cboxFusionArmor"
        Me.cboxFusionArmor.Size = New System.Drawing.Size(264, 21)
        Me.cboxFusionArmor.TabIndex = 149
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Black
        Me.Label15.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(13, 67)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(210, 15)
        Me.Label15.TabIndex = 148
        Me.Label15.Text = "Equipped Weapon After Fusion:"
        '
        'cboxFusionWeapon
        '
        Me.cboxFusionWeapon.BackColor = System.Drawing.Color.Black
        Me.cboxFusionWeapon.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboxFusionWeapon.ForeColor = System.Drawing.Color.White
        Me.cboxFusionWeapon.FormattingEnabled = True
        Me.cboxFusionWeapon.Location = New System.Drawing.Point(14, 92)
        Me.cboxFusionWeapon.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboxFusionWeapon.Name = "cboxFusionWeapon"
        Me.cboxFusionWeapon.Size = New System.Drawing.Size(264, 21)
        Me.cboxFusionWeapon.TabIndex = 147
        '
        'btnFusionAcc
        '
        Me.btnFusionAcc.BackColor = System.Drawing.SystemColors.Window
        Me.btnFusionAcc.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFusionAcc.Location = New System.Drawing.Point(502, 259)
        Me.btnFusionAcc.Name = "btnFusionAcc"
        Me.btnFusionAcc.Size = New System.Drawing.Size(75, 23)
        Me.btnFusionAcc.TabIndex = 145
        Me.btnFusionAcc.Text = "OK"
        Me.btnFusionAcc.UseVisualStyleBackColor = False
        '
        'btnFusionCancel
        '
        Me.btnFusionCancel.BackColor = System.Drawing.SystemColors.Window
        Me.btnFusionCancel.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFusionCancel.Location = New System.Drawing.Point(421, 259)
        Me.btnFusionCancel.Name = "btnFusionCancel"
        Me.btnFusionCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnFusionCancel.TabIndex = 144
        Me.btnFusionCancel.Text = "Back"
        Me.btnFusionCancel.UseVisualStyleBackColor = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Location = New System.Drawing.Point(315, 25)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(261, 199)
        Me.PictureBox2.TabIndex = 225
        Me.PictureBox2.TabStop = False
        '
        'pnlSnare
        '
        Me.pnlSnare.BackgroundImage = CType(resources.GetObject("pnlSnare.BackgroundImage"), System.Drawing.Image)
        Me.pnlSnare.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlSnare.Controls.Add(Me.btnConfirmBait)
        Me.pnlSnare.Controls.Add(Me.Label7)
        Me.pnlSnare.Controls.Add(Me.cboxBait)
        Me.pnlSnare.Location = New System.Drawing.Point(244, 200)
        Me.pnlSnare.Name = "pnlSnare"
        Me.pnlSnare.Size = New System.Drawing.Size(285, 104)
        Me.pnlSnare.TabIndex = 405
        Me.pnlSnare.Visible = False
        '
        'btnConfirmBait
        '
        Me.btnConfirmBait.BackColor = System.Drawing.SystemColors.Window
        Me.btnConfirmBait.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirmBait.Location = New System.Drawing.Point(199, 66)
        Me.btnConfirmBait.Name = "btnConfirmBait"
        Me.btnConfirmBait.Size = New System.Drawing.Size(75, 23)
        Me.btnConfirmBait.TabIndex = 157
        Me.btnConfirmBait.Text = "OK"
        Me.btnConfirmBait.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Black
        Me.Label7.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(11, 14)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(126, 15)
        Me.Label7.TabIndex = 156
        Me.Label7.Text = "Use what as bait?"
        '
        'cboxBait
        '
        Me.cboxBait.BackColor = System.Drawing.Color.Black
        Me.cboxBait.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboxBait.ForeColor = System.Drawing.Color.White
        Me.cboxBait.FormattingEnabled = True
        Me.cboxBait.Location = New System.Drawing.Point(12, 33)
        Me.cboxBait.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboxBait.Name = "cboxBait"
        Me.cboxBait.Size = New System.Drawing.Size(262, 21)
        Me.cboxBait.TabIndex = 155
        '
        'pnlSpellSpecial
        '
        Me.pnlSpellSpecial.BackgroundImage = CType(resources.GetObject("pnlSpellSpecial.BackgroundImage"), System.Drawing.Image)
        Me.pnlSpellSpecial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlSpellSpecial.Controls.Add(Me.Label17)
        Me.pnlSpellSpecial.Controls.Add(Me.txtSpellSpecialDesc)
        Me.pnlSpellSpecial.Controls.Add(Me.btnSpellSpecOK)
        Me.pnlSpellSpecial.Controls.Add(Me.Label12)
        Me.pnlSpellSpecial.Controls.Add(Me.cboxSpellSpecialDescSelector)
        Me.pnlSpellSpecial.Location = New System.Drawing.Point(155, 158)
        Me.pnlSpellSpecial.Name = "pnlSpellSpecial"
        Me.pnlSpellSpecial.Size = New System.Drawing.Size(449, 224)
        Me.pnlSpellSpecial.TabIndex = 406
        Me.pnlSpellSpecial.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Black
        Me.Label17.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(11, 65)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(91, 15)
        Me.Label17.TabIndex = 159
        Me.Label17.Text = "Description:"
        '
        'txtSpellSpecialDesc
        '
        Me.txtSpellSpecialDesc.BackColor = System.Drawing.Color.Black
        Me.txtSpellSpecialDesc.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSpellSpecialDesc.ForeColor = System.Drawing.Color.White
        Me.txtSpellSpecialDesc.Location = New System.Drawing.Point(11, 85)
        Me.txtSpellSpecialDesc.Multiline = True
        Me.txtSpellSpecialDesc.Name = "txtSpellSpecialDesc"
        Me.txtSpellSpecialDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSpellSpecialDesc.Size = New System.Drawing.Size(428, 96)
        Me.txtSpellSpecialDesc.TabIndex = 158
        '
        'btnSpellSpecOK
        '
        Me.btnSpellSpecOK.BackColor = System.Drawing.SystemColors.Window
        Me.btnSpellSpecOK.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSpellSpecOK.Location = New System.Drawing.Point(365, 191)
        Me.btnSpellSpecOK.Name = "btnSpellSpecOK"
        Me.btnSpellSpecOK.Size = New System.Drawing.Size(75, 23)
        Me.btnSpellSpecOK.TabIndex = 157
        Me.btnSpellSpecOK.Text = "OK"
        Me.btnSpellSpecOK.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Black
        Me.Label12.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(11, 14)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(119, 15)
        Me.Label12.TabIndex = 156
        Me.Label12.Text = "Known Abilities:"
        '
        'cboxSpellSpecialDescSelector
        '
        Me.cboxSpellSpecialDescSelector.BackColor = System.Drawing.Color.Black
        Me.cboxSpellSpecialDescSelector.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboxSpellSpecialDescSelector.ForeColor = System.Drawing.Color.White
        Me.cboxSpellSpecialDescSelector.FormattingEnabled = True
        Me.cboxSpellSpecialDescSelector.Location = New System.Drawing.Point(11, 33)
        Me.cboxSpellSpecialDescSelector.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboxSpellSpecialDescSelector.Name = "cboxSpellSpecialDescSelector"
        Me.cboxSpellSpecialDescSelector.Size = New System.Drawing.Size(428, 21)
        Me.cboxSpellSpecialDescSelector.TabIndex = 155
        '
        'pnlCastUse
        '
        Me.pnlCastUse.BackgroundImage = CType(resources.GetObject("pnlCastUse.BackgroundImage"), System.Drawing.Image)
        Me.pnlCastUse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlCastUse.Controls.Add(Me.btnCastSpell)
        Me.pnlCastUse.Controls.Add(Me.lblCastCost)
        Me.pnlCastUse.Controls.Add(Me.Label19)
        Me.pnlCastUse.Controls.Add(Me.txtCastDesc)
        Me.pnlCastUse.Controls.Add(Me.btnCastCancel)
        Me.pnlCastUse.Controls.Add(Me.lblKnownAbilities)
        Me.pnlCastUse.Controls.Add(Me.cboxCast)
        Me.pnlCastUse.Location = New System.Drawing.Point(248, 100)
        Me.pnlCastUse.Name = "pnlCastUse"
        Me.pnlCastUse.Size = New System.Drawing.Size(625, 272)
        Me.pnlCastUse.TabIndex = 407
        Me.pnlCastUse.Visible = False
        '
        'btnCastSpell
        '
        Me.btnCastSpell.BackColor = System.Drawing.SystemColors.Window
        Me.btnCastSpell.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCastSpell.Location = New System.Drawing.Point(456, 235)
        Me.btnCastSpell.Name = "btnCastSpell"
        Me.btnCastSpell.Size = New System.Drawing.Size(75, 23)
        Me.btnCastSpell.TabIndex = 161
        Me.btnCastSpell.Text = "OK"
        Me.btnCastSpell.UseVisualStyleBackColor = False
        '
        'lblCastCost
        '
        Me.lblCastCost.AutoSize = True
        Me.lblCastCost.BackColor = System.Drawing.Color.Black
        Me.lblCastCost.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCastCost.ForeColor = System.Drawing.Color.White
        Me.lblCastCost.Location = New System.Drawing.Point(36, 223)
        Me.lblCastCost.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCastCost.Name = "lblCastCost"
        Me.lblCastCost.Size = New System.Drawing.Size(56, 18)
        Me.lblCastCost.TabIndex = 160
        Me.lblCastCost.Text = "Cost: "
        Me.lblCastCost.UseWaitCursor = True
        Me.lblCastCost.Visible = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Black
        Me.Label19.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(36, 80)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(104, 18)
        Me.Label19.TabIndex = 159
        Me.Label19.Text = "Description:"
        '
        'txtCastDesc
        '
        Me.txtCastDesc.BackColor = System.Drawing.Color.Black
        Me.txtCastDesc.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCastDesc.ForeColor = System.Drawing.Color.White
        Me.txtCastDesc.Location = New System.Drawing.Point(36, 103)
        Me.txtCastDesc.Multiline = True
        Me.txtCastDesc.Name = "txtCastDesc"
        Me.txtCastDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCastDesc.Size = New System.Drawing.Size(554, 96)
        Me.txtCastDesc.TabIndex = 158
        '
        'btnCastCancel
        '
        Me.btnCastCancel.BackColor = System.Drawing.SystemColors.Window
        Me.btnCastCancel.Font = New System.Drawing.Font("Consolas", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCastCancel.Location = New System.Drawing.Point(537, 235)
        Me.btnCastCancel.Name = "btnCastCancel"
        Me.btnCastCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCastCancel.TabIndex = 157
        Me.btnCastCancel.Text = "Cancel"
        Me.btnCastCancel.UseVisualStyleBackColor = False
        '
        'lblKnownAbilities
        '
        Me.lblKnownAbilities.AutoSize = True
        Me.lblKnownAbilities.BackColor = System.Drawing.Color.Black
        Me.lblKnownAbilities.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKnownAbilities.ForeColor = System.Drawing.Color.White
        Me.lblKnownAbilities.Location = New System.Drawing.Point(36, 12)
        Me.lblKnownAbilities.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblKnownAbilities.Name = "lblKnownAbilities"
        Me.lblKnownAbilities.Size = New System.Drawing.Size(136, 18)
        Me.lblKnownAbilities.TabIndex = 156
        Me.lblKnownAbilities.Text = "Known Abilities:"
        '
        'cboxCast
        '
        Me.cboxCast.BackColor = System.Drawing.Color.Black
        Me.cboxCast.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboxCast.ForeColor = System.Drawing.Color.White
        Me.cboxCast.FormattingEnabled = True
        Me.cboxCast.Location = New System.Drawing.Point(36, 38)
        Me.cboxCast.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboxCast.Name = "cboxCast"
        Me.cboxCast.Size = New System.Drawing.Size(553, 21)
        Me.cboxCast.TabIndex = 155
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
        'pnlEquip
        '
        Me.pnlEquip.AutoScroll = True
        Me.pnlEquip.BackgroundImage = CType(resources.GetObject("pnlEquip.BackgroundImage"), System.Drawing.Image)
        Me.pnlEquip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlEquip.Controls.Add(Me.lblEquippedGlasses)
        Me.pnlEquip.Controls.Add(Me.cboxGlasses)
        Me.pnlEquip.Controls.Add(Me.lblEquippedAccessory)
        Me.pnlEquip.Controls.Add(Me.cboxAccessory)
        Me.pnlEquip.Controls.Add(Me.lblEquippedArmor)
        Me.pnlEquip.Controls.Add(Me.cboxArmor)
        Me.pnlEquip.Controls.Add(Me.lblEquippedWeapon)
        Me.pnlEquip.Controls.Add(Me.cboxWeapon)
        Me.pnlEquip.Controls.Add(Me.btnEquipCancel)
        Me.pnlEquip.Controls.Add(Me.picEquipPort)
        Me.pnlEquip.Controls.Add(Me.btnEquipConfirm)
        Me.pnlEquip.Location = New System.Drawing.Point(1000, 40)
        Me.pnlEquip.Name = "pnlEquip"
        Me.pnlEquip.Size = New System.Drawing.Size(350, 445)
        Me.pnlEquip.TabIndex = 323
        Me.pnlEquip.Visible = False
        '
        'lblEquippedGlasses
        '
        Me.lblEquippedGlasses.AutoSize = True
        Me.lblEquippedGlasses.BackColor = System.Drawing.Color.Black
        Me.lblEquippedGlasses.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEquippedGlasses.ForeColor = System.Drawing.Color.White
        Me.lblEquippedGlasses.Location = New System.Drawing.Point(18, 249)
        Me.lblEquippedGlasses.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEquippedGlasses.Name = "lblEquippedGlasses"
        Me.lblEquippedGlasses.Size = New System.Drawing.Size(109, 13)
        Me.lblEquippedGlasses.TabIndex = 288
        Me.lblEquippedGlasses.Text = "Equipped Glasses:"
        '
        'cboxGlasses
        '
        Me.cboxGlasses.BackColor = System.Drawing.Color.Black
        Me.cboxGlasses.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboxGlasses.ForeColor = System.Drawing.Color.White
        Me.cboxGlasses.FormattingEnabled = True
        Me.cboxGlasses.Location = New System.Drawing.Point(20, 274)
        Me.cboxGlasses.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboxGlasses.Name = "cboxGlasses"
        Me.cboxGlasses.Size = New System.Drawing.Size(199, 21)
        Me.cboxGlasses.TabIndex = 287
        '
        'lblEquippedAccessory
        '
        Me.lblEquippedAccessory.AutoSize = True
        Me.lblEquippedAccessory.BackColor = System.Drawing.Color.Black
        Me.lblEquippedAccessory.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEquippedAccessory.ForeColor = System.Drawing.Color.White
        Me.lblEquippedAccessory.Location = New System.Drawing.Point(15, 174)
        Me.lblEquippedAccessory.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEquippedAccessory.Name = "lblEquippedAccessory"
        Me.lblEquippedAccessory.Size = New System.Drawing.Size(121, 13)
        Me.lblEquippedAccessory.TabIndex = 284
        Me.lblEquippedAccessory.Text = "Equipped Accessory:"
        '
        'cboxAccessory
        '
        Me.cboxAccessory.BackColor = System.Drawing.Color.Black
        Me.cboxAccessory.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboxAccessory.ForeColor = System.Drawing.Color.White
        Me.cboxAccessory.FormattingEnabled = True
        Me.cboxAccessory.Location = New System.Drawing.Point(17, 199)
        Me.cboxAccessory.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboxAccessory.Name = "cboxAccessory"
        Me.cboxAccessory.Size = New System.Drawing.Size(199, 21)
        Me.cboxAccessory.TabIndex = 283
        '
        'lblEquippedArmor
        '
        Me.lblEquippedArmor.AutoSize = True
        Me.lblEquippedArmor.BackColor = System.Drawing.Color.Black
        Me.lblEquippedArmor.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEquippedArmor.ForeColor = System.Drawing.Color.White
        Me.lblEquippedArmor.Location = New System.Drawing.Point(12, 99)
        Me.lblEquippedArmor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEquippedArmor.Name = "lblEquippedArmor"
        Me.lblEquippedArmor.Size = New System.Drawing.Size(97, 13)
        Me.lblEquippedArmor.TabIndex = 282
        Me.lblEquippedArmor.Text = "Equipped Armor:"
        '
        'cboxArmor
        '
        Me.cboxArmor.BackColor = System.Drawing.Color.Black
        Me.cboxArmor.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboxArmor.ForeColor = System.Drawing.Color.White
        Me.cboxArmor.FormattingEnabled = True
        Me.cboxArmor.Location = New System.Drawing.Point(14, 124)
        Me.cboxArmor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboxArmor.Name = "cboxArmor"
        Me.cboxArmor.Size = New System.Drawing.Size(199, 21)
        Me.cboxArmor.TabIndex = 281
        '
        'lblEquippedWeapon
        '
        Me.lblEquippedWeapon.AutoSize = True
        Me.lblEquippedWeapon.BackColor = System.Drawing.Color.Black
        Me.lblEquippedWeapon.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEquippedWeapon.ForeColor = System.Drawing.Color.White
        Me.lblEquippedWeapon.Location = New System.Drawing.Point(13, 27)
        Me.lblEquippedWeapon.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEquippedWeapon.Name = "lblEquippedWeapon"
        Me.lblEquippedWeapon.Size = New System.Drawing.Size(103, 13)
        Me.lblEquippedWeapon.TabIndex = 280
        Me.lblEquippedWeapon.Text = "Equipped Weapon:"
        '
        'cboxWeapon
        '
        Me.cboxWeapon.BackColor = System.Drawing.Color.Black
        Me.cboxWeapon.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboxWeapon.ForeColor = System.Drawing.Color.White
        Me.cboxWeapon.FormattingEnabled = True
        Me.cboxWeapon.Location = New System.Drawing.Point(14, 52)
        Me.cboxWeapon.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboxWeapon.Name = "cboxWeapon"
        Me.cboxWeapon.Size = New System.Drawing.Size(199, 21)
        Me.cboxWeapon.TabIndex = 279
        '
        'btnEquipCancel
        '
        Me.btnEquipCancel.BackColor = System.Drawing.Color.Black
        Me.btnEquipCancel.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEquipCancel.ForeColor = System.Drawing.Color.White
        Me.btnEquipCancel.Location = New System.Drawing.Point(185, 407)
        Me.btnEquipCancel.Name = "btnEquipCancel"
        Me.btnEquipCancel.Size = New System.Drawing.Size(73, 28)
        Me.btnEquipCancel.TabIndex = 278
        Me.btnEquipCancel.Text = "Cancel"
        Me.btnEquipCancel.UseVisualStyleBackColor = False
        '
        'picEquipPort
        '
        Me.picEquipPort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picEquipPort.Location = New System.Drawing.Point(235, 12)
        Me.picEquipPort.Name = "picEquipPort"
        Me.picEquipPort.Size = New System.Drawing.Size(104, 384)
        Me.picEquipPort.TabIndex = 277
        Me.picEquipPort.TabStop = False
        '
        'btnEquipConfirm
        '
        Me.btnEquipConfirm.BackColor = System.Drawing.Color.Black
        Me.btnEquipConfirm.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEquipConfirm.ForeColor = System.Drawing.Color.White
        Me.btnEquipConfirm.Location = New System.Drawing.Point(266, 407)
        Me.btnEquipConfirm.Name = "btnEquipConfirm"
        Me.btnEquipConfirm.Size = New System.Drawing.Size(73, 28)
        Me.btnEquipConfirm.TabIndex = 233
        Me.btnEquipConfirm.Text = "Equip"
        Me.btnEquipConfirm.UseVisualStyleBackColor = False
        '
        'chkMisc
        '
        Me.chkMisc.AutoSize = True
        Me.chkMisc.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkMisc.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black
        Me.chkMisc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.chkMisc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.chkMisc.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMisc.ForeColor = System.Drawing.Color.White
        Me.chkMisc.Location = New System.Drawing.Point(739, 576)
        Me.chkMisc.Name = "chkMisc"
        Me.chkMisc.Size = New System.Drawing.Size(59, 21)
        Me.chkMisc.TabIndex = 414
        Me.chkMisc.Text = "Misc"
        Me.chkMisc.UseVisualStyleBackColor = True
        Me.chkMisc.Visible = False
        '
        'pnlInvFilter
        '
        Me.pnlInvFilter.BackgroundImage = CType(resources.GetObject("pnlInvFilter.BackgroundImage"), System.Drawing.Image)
        Me.pnlInvFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlInvFilter.Location = New System.Drawing.Point(734, 419)
        Me.pnlInvFilter.Name = "pnlInvFilter"
        Me.pnlInvFilter.Size = New System.Drawing.Size(262, 180)
        Me.pnlInvFilter.TabIndex = 415
        Me.pnlInvFilter.Visible = False
        '
        'picFVTBoss1
        '
        Me.picFVTBoss1.BackgroundImage = CType(resources.GetObject("picFVTBoss1.BackgroundImage"), System.Drawing.Image)
        Me.picFVTBoss1.Location = New System.Drawing.Point(247, 70)
        Me.picFVTBoss1.Name = "picFVTBoss1"
        Me.picFVTBoss1.Size = New System.Drawing.Size(15, 15)
        Me.picFVTBoss1.TabIndex = 420
        Me.picFVTBoss1.TabStop = False
        Me.picFVTBoss1.Visible = False
        '
        'picFVTBoss2
        '
        Me.picFVTBoss2.BackgroundImage = CType(resources.GetObject("picFVTBoss2.BackgroundImage"), System.Drawing.Image)
        Me.picFVTBoss2.Location = New System.Drawing.Point(268, 70)
        Me.picFVTBoss2.Name = "picFVTBoss2"
        Me.picFVTBoss2.Size = New System.Drawing.Size(15, 15)
        Me.picFVTBoss2.TabIndex = 421
        Me.picFVTBoss2.TabStop = False
        Me.picFVTBoss2.Visible = False
        '
        'picFVTBoss3
        '
        Me.picFVTBoss3.BackgroundImage = CType(resources.GetObject("picFVTBoss3.BackgroundImage"), System.Drawing.Image)
        Me.picFVTBoss3.Location = New System.Drawing.Point(289, 70)
        Me.picFVTBoss3.Name = "picFVTBoss3"
        Me.picFVTBoss3.Size = New System.Drawing.Size(15, 15)
        Me.picFVTBoss3.TabIndex = 422
        Me.picFVTBoss3.TabStop = False
        Me.picFVTBoss3.Visible = False
        '
        'picFVTBoss4
        '
        Me.picFVTBoss4.BackgroundImage = CType(resources.GetObject("picFVTBoss4.BackgroundImage"), System.Drawing.Image)
        Me.picFVTBoss4.Location = New System.Drawing.Point(310, 70)
        Me.picFVTBoss4.Name = "picFVTBoss4"
        Me.picFVTBoss4.Size = New System.Drawing.Size(15, 15)
        Me.picFVTBoss4.TabIndex = 423
        Me.picFVTBoss4.TabStop = False
        Me.picFVTBoss4.Visible = False
        '
        'btnS4
        '
        Me.btnS4.BackColor = System.Drawing.Color.Black
        Me.btnS4.BackgroundImage = CType(resources.GetObject("btnS4.BackgroundImage"), System.Drawing.Image)
        Me.btnS4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnS4.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnS4.ForeColor = System.Drawing.Color.White
        Me.btnS4.Location = New System.Drawing.Point(383, 5)
        Me.btnS4.Name = "btnS4"
        Me.btnS4.Size = New System.Drawing.Size(110, 167)
        Me.btnS4.TabIndex = 252
        Me.btnS4.Tag = "4"
        Me.btnS4.UseVisualStyleBackColor = False
        '
        'btnS5
        '
        Me.btnS5.BackColor = System.Drawing.Color.Black
        Me.btnS5.BackgroundImage = CType(resources.GetObject("btnS5.BackgroundImage"), System.Drawing.Image)
        Me.btnS5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnS5.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnS5.ForeColor = System.Drawing.Color.White
        Me.btnS5.Location = New System.Drawing.Point(508, 5)
        Me.btnS5.Name = "btnS5"
        Me.btnS5.Size = New System.Drawing.Size(110, 167)
        Me.btnS5.TabIndex = 253
        Me.btnS5.Tag = "5"
        Me.btnS5.UseVisualStyleBackColor = False
        '
        'btnS3
        '
        Me.btnS3.BackColor = System.Drawing.Color.Black
        Me.btnS3.BackgroundImage = CType(resources.GetObject("btnS3.BackgroundImage"), System.Drawing.Image)
        Me.btnS3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnS3.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnS3.ForeColor = System.Drawing.Color.White
        Me.btnS3.Location = New System.Drawing.Point(258, 5)
        Me.btnS3.Name = "btnS3"
        Me.btnS3.Size = New System.Drawing.Size(110, 167)
        Me.btnS3.TabIndex = 251
        Me.btnS3.Tag = "3"
        Me.btnS3.UseVisualStyleBackColor = False
        '
        'btnS2
        '
        Me.btnS2.BackColor = System.Drawing.Color.Black
        Me.btnS2.BackgroundImage = CType(resources.GetObject("btnS2.BackgroundImage"), System.Drawing.Image)
        Me.btnS2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnS2.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnS2.ForeColor = System.Drawing.Color.White
        Me.btnS2.Location = New System.Drawing.Point(133, 5)
        Me.btnS2.Name = "btnS2"
        Me.btnS2.Size = New System.Drawing.Size(110, 167)
        Me.btnS2.TabIndex = 250
        Me.btnS2.Tag = "2"
        Me.btnS2.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Black
        Me.btnCancel.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(178, 375)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(272, 37)
        Me.btnCancel.TabIndex = 256
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
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
        Me.btnS1.Size = New System.Drawing.Size(110, 167)
        Me.btnS1.TabIndex = 249
        Me.btnS1.Tag = "1"
        Me.btnS1.UseVisualStyleBackColor = False
        '
        'btnS9
        '
        Me.btnS9.BackColor = System.Drawing.Color.Black
        Me.btnS9.BackgroundImage = CType(resources.GetObject("btnS9.BackgroundImage"), System.Drawing.Image)
        Me.btnS9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnS9.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnS9.ForeColor = System.Drawing.Color.White
        Me.btnS9.Location = New System.Drawing.Point(383, 187)
        Me.btnS9.Name = "btnS9"
        Me.btnS9.Size = New System.Drawing.Size(110, 167)
        Me.btnS9.TabIndex = 260
        Me.btnS9.Tag = "9"
        Me.btnS9.UseVisualStyleBackColor = False
        '
        'btnS10
        '
        Me.btnS10.BackColor = System.Drawing.Color.Black
        Me.btnS10.BackgroundImage = CType(resources.GetObject("btnS10.BackgroundImage"), System.Drawing.Image)
        Me.btnS10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnS10.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnS10.ForeColor = System.Drawing.Color.White
        Me.btnS10.Location = New System.Drawing.Point(508, 187)
        Me.btnS10.Name = "btnS10"
        Me.btnS10.Size = New System.Drawing.Size(110, 167)
        Me.btnS10.TabIndex = 261
        Me.btnS10.Tag = "10"
        Me.btnS10.UseVisualStyleBackColor = False
        '
        'btnS8
        '
        Me.btnS8.BackColor = System.Drawing.Color.Black
        Me.btnS8.BackgroundImage = CType(resources.GetObject("btnS8.BackgroundImage"), System.Drawing.Image)
        Me.btnS8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnS8.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnS8.ForeColor = System.Drawing.Color.White
        Me.btnS8.Location = New System.Drawing.Point(258, 187)
        Me.btnS8.Name = "btnS8"
        Me.btnS8.Size = New System.Drawing.Size(110, 167)
        Me.btnS8.TabIndex = 259
        Me.btnS8.Tag = "8"
        Me.btnS8.UseVisualStyleBackColor = False
        '
        'btnS7
        '
        Me.btnS7.BackColor = System.Drawing.Color.Black
        Me.btnS7.BackgroundImage = CType(resources.GetObject("btnS7.BackgroundImage"), System.Drawing.Image)
        Me.btnS7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnS7.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnS7.ForeColor = System.Drawing.Color.White
        Me.btnS7.Location = New System.Drawing.Point(133, 187)
        Me.btnS7.Name = "btnS7"
        Me.btnS7.Size = New System.Drawing.Size(110, 167)
        Me.btnS7.TabIndex = 258
        Me.btnS7.Tag = "7"
        Me.btnS7.UseVisualStyleBackColor = False
        '
        'btnS6
        '
        Me.btnS6.BackColor = System.Drawing.Color.Black
        Me.btnS6.BackgroundImage = CType(resources.GetObject("btnS6.BackgroundImage"), System.Drawing.Image)
        Me.btnS6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnS6.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnS6.ForeColor = System.Drawing.Color.White
        Me.btnS6.Location = New System.Drawing.Point(8, 187)
        Me.btnS6.Name = "btnS6"
        Me.btnS6.Size = New System.Drawing.Size(110, 167)
        Me.btnS6.TabIndex = 257
        Me.btnS6.Tag = "6"
        Me.btnS6.UseVisualStyleBackColor = False
        '
        'pnlSaveLoad
        '
        Me.pnlSaveLoad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSaveLoad.Controls.Add(Me.btnS6)
        Me.pnlSaveLoad.Controls.Add(Me.btnS7)
        Me.pnlSaveLoad.Controls.Add(Me.btnS8)
        Me.pnlSaveLoad.Controls.Add(Me.btnS10)
        Me.pnlSaveLoad.Controls.Add(Me.btnS9)
        Me.pnlSaveLoad.Controls.Add(Me.btnS1)
        Me.pnlSaveLoad.Controls.Add(Me.btnCancel)
        Me.pnlSaveLoad.Controls.Add(Me.btnS2)
        Me.pnlSaveLoad.Controls.Add(Me.btnS3)
        Me.pnlSaveLoad.Controls.Add(Me.btnS5)
        Me.pnlSaveLoad.Controls.Add(Me.btnS4)
        Me.pnlSaveLoad.Location = New System.Drawing.Point(1012, 35)
        Me.pnlSaveLoad.Name = "pnlSaveLoad"
        Me.pnlSaveLoad.Size = New System.Drawing.Size(628, 430)
        Me.pnlSaveLoad.TabIndex = 258
        Me.pnlSaveLoad.Visible = False
        '
        'picBoard
        '
        Me.picBoard.BackColor = System.Drawing.Color.Black
        Me.picBoard.Location = New System.Drawing.Point(20, 39)
        Me.picBoard.Name = "picBoard"
        Me.picBoard.Size = New System.Drawing.Size(690, 450)
        Me.picBoard.TabIndex = 419
        Me.picBoard.TabStop = False
        '
        'picPinkMist
        '
        Me.picPinkMist.BackgroundImage = CType(resources.GetObject("picPinkMist.BackgroundImage"), System.Drawing.Image)
        Me.picPinkMist.Location = New System.Drawing.Point(331, 70)
        Me.picPinkMist.Name = "picPinkMist"
        Me.picPinkMist.Size = New System.Drawing.Size(15, 15)
        Me.picPinkMist.TabIndex = 424
        Me.picPinkMist.TabStop = False
        Me.picPinkMist.Visible = False
        '
        'Game
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1008, 690)
        Me.Controls.Add(Me.picPinkMist)
        Me.Controls.Add(Me.pnlSelection)
        Me.Controls.Add(Me.pnlSaveLoad)
        Me.Controls.Add(Me.picFVTBoss4)
        Me.Controls.Add(Me.picFVTBoss3)
        Me.Controls.Add(Me.picFVTBoss2)
        Me.Controls.Add(Me.picFVTBoss1)
        Me.Controls.Add(Me.pnlEquip)
        Me.Controls.Add(Me.chkMisc)
        Me.Controls.Add(Me.pnlCombat)
        Me.Controls.Add(Me.pnlEvent)
        Me.Controls.Add(Me.pnlCastUse)
        Me.Controls.Add(Me.pnlSpellSpecial)
        Me.Controls.Add(Me.pnlSnare)
        Me.Controls.Add(Me.pnlFusion)
        Me.Controls.Add(Me.btnAll)
        Me.Controls.Add(Me.btnNone)
        Me.Controls.Add(Me.pnlDescription)
        Me.Controls.Add(Me.lblLoadMsg)
        Me.Controls.Add(Me.btnAbout)
        Me.Controls.Add(Me.chkAcc)
        Me.Controls.Add(Me.picLoadBar)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnT)
        Me.Controls.Add(Me.btnSettings)
        Me.Controls.Add(Me.chkGlasses)
        Me.Controls.Add(Me.chkWeapon)
        Me.Controls.Add(Me.chkArmor)
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
        Me.Controls.Add(Me.lblInventory)
        Me.Controls.Add(Me.btnUse)
        Me.Controls.Add(Me.lstLog)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.btnLook)
        Me.Controls.Add(Me.btnDrop)
        Me.Controls.Add(Me.btnEXM)
        Me.Controls.Add(Me.btnIns)
        Me.Controls.Add(Me.btnR)
        Me.Controls.Add(Me.btnU)
        Me.Controls.Add(Me.BtnD)
        Me.Controls.Add(Me.btnLft)
        Me.Controls.Add(Me.btnFilter)
        Me.Controls.Add(Me.picPortrait)
        Me.Controls.Add(Me.lblEvent)
        Me.Controls.Add(Me.btnWait)
        Me.Controls.Add(Me.btnNPCMG)
        Me.Controls.Add(Me.btnFight)
        Me.Controls.Add(Me.lblStats)
        Me.Controls.Add(Me.pnlStats)
        Me.Controls.Add(Me.pnlMeter)
        Me.Controls.Add(Me.picPortOutline)
        Me.Controls.Add(Me.picLust5)
        Me.Controls.Add(Me.picLust4)
        Me.Controls.Add(Me.picLust3)
        Me.Controls.Add(Me.picLust2)
        Me.Controls.Add(Me.picLust1)
        Me.Controls.Add(Me.pnlInvFilter)
        Me.Controls.Add(Me.lstInventory)
        Me.Controls.Add(Me.btnShop)
        Me.Controls.Add(Me.picBoard)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Game"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Dungeon_Depths"
        CType(Me.picEnemy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picNPC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picStart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.picPortrait, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLust1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLust2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLust3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLust4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLust5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCombat.ResumeLayout(False)
        Me.pnlCombat.PerformLayout()
        CType(Me.picLoadBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDescription.ResumeLayout(False)
        Me.pnlDescription.PerformLayout()
        CType(Me.picDescPort, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSelection.ResumeLayout(False)
        Me.pnlEvent.ResumeLayout(False)
        Me.pnlEvent.PerformLayout()
        CType(Me.picPortOutline, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlStats.ResumeLayout(False)
        Me.pnlMeter.ResumeLayout(False)
        Me.pnlMeter.PerformLayout()
        Me.pnlFusion.ResumeLayout(False)
        Me.pnlFusion.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picFusionPort, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSnare.ResumeLayout(False)
        Me.pnlSnare.PerformLayout()
        Me.pnlSpellSpecial.ResumeLayout(False)
        Me.pnlSpellSpecial.PerformLayout()
        Me.pnlCastUse.ResumeLayout(False)
        Me.pnlCastUse.PerformLayout()
        Me.pnlEquip.ResumeLayout(False)
        Me.pnlEquip.PerformLayout()
        CType(Me.picEquipPort, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picFVTBoss1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picFVTBoss2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picFVTBoss3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picFVTBoss4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSaveLoad.ResumeLayout(False)
        CType(Me.picBoard, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPinkMist, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents lblInventory As System.Windows.Forms.Label
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
    Friend WithEvents btnSpec As System.Windows.Forms.Button
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents chkUseable As System.Windows.Forms.CheckBox
    Friend WithEvents chkPotion As System.Windows.Forms.CheckBox
    Friend WithEvents chkFood As System.Windows.Forms.CheckBox
    Friend WithEvents chkArmor As System.Windows.Forms.CheckBox
    Friend WithEvents chkWeapon As System.Windows.Forms.CheckBox
    Friend WithEvents chkGlasses As System.Windows.Forms.CheckBox
    Friend WithEvents btnAll As System.Windows.Forms.Button
    Friend WithEvents btnNone As System.Windows.Forms.Button
    Friend WithEvents InfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnSettings As System.Windows.Forms.Button
    Friend WithEvents btnT As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
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
    Friend WithEvents lblEvent As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents picLoadBar As System.Windows.Forms.PictureBox
    Friend WithEvents lblCombatEvents As System.Windows.Forms.TextBox
    Friend WithEvents btnWait As System.Windows.Forms.Button
    Friend WithEvents pnlDescription As System.Windows.Forms.Panel
    Friend WithEvents lblNext As System.Windows.Forms.Label
    Friend WithEvents picDescPort As System.Windows.Forms.PictureBox
    Friend WithEvents txtPlayerDesc As System.Windows.Forms.TextBox
    Friend WithEvents pnlSelection As System.Windows.Forms.Panel
    Friend WithEvents lblWhat As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lstSelec As System.Windows.Forms.ListBox
    Friend WithEvents lblInstruc As System.Windows.Forms.Label
    Friend WithEvents chkAcc As System.Windows.Forms.CheckBox
    Friend WithEvents btnAbout As Button
    Friend WithEvents RunAutomatedTestsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblLoadMsg As System.Windows.Forms.Label
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlEvent As System.Windows.Forms.Panel
    Friend WithEvents txtPNLEvents As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnNextLPnlEvent As System.Windows.Forms.Button
    Friend WithEvents btnNextRPnlEvent As System.Windows.Forms.Button
    Friend WithEvents btnClosePnlEvent As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents picPortOutline As System.Windows.Forms.PictureBox
    Friend WithEvents DebugToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlStats As System.Windows.Forms.Panel
    Friend WithEvents lblStats As System.Windows.Forms.Label
    Friend WithEvents pnlMeter As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblstamina As System.Windows.Forms.Label
    Friend WithEvents lblXP As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblHealthbarFont As System.Windows.Forms.Label
    Friend WithEvents lblLust As System.Windows.Forms.Label
    Friend WithEvents pnlFusion As System.Windows.Forms.Panel
    Friend WithEvents btnFusionAcc As System.Windows.Forms.Button
    Friend WithEvents btnFusionCancel As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cboxFusionTarget As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboxFusionAccessory As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboxFusionArmor As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboxFusionWeapon As System.Windows.Forms.ComboBox
    Friend WithEvents lblFusionHP As System.Windows.Forms.Label
    Friend WithEvents lblFusionMP As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents lblFusionLust As System.Windows.Forms.Label
    Friend WithEvents lblFusionSPD As System.Windows.Forms.Label
    Friend WithEvents lblFusionATK As System.Windows.Forms.Label
    Friend WithEvents lblFusionDEF As System.Windows.Forms.Label
    Friend WithEvents lblFusionWill As System.Windows.Forms.Label
    Friend WithEvents lblFusionLVL As System.Windows.Forms.Label
    Friend WithEvents picFusionPort As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lblFusionDisclaimer As System.Windows.Forms.Label
    Friend WithEvents pnlSnare As System.Windows.Forms.Panel
    Friend WithEvents btnConfirmBait As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboxBait As System.Windows.Forms.ComboBox
    Friend WithEvents pnlSpellSpecial As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtSpellSpecialDesc As System.Windows.Forms.TextBox
    Friend WithEvents btnSpellSpecOK As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboxSpellSpecialDescSelector As System.Windows.Forms.ComboBox
    Friend WithEvents pnlCastUse As System.Windows.Forms.Panel
    Friend WithEvents btnCastSpell As System.Windows.Forms.Button
    Friend WithEvents lblCastCost As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtCastDesc As System.Windows.Forms.TextBox
    Friend WithEvents btnCastCancel As System.Windows.Forms.Button
    Friend WithEvents lblKnownAbilities As System.Windows.Forms.Label
    Friend WithEvents cboxCast As System.Windows.Forms.ComboBox
    Friend WithEvents cboxSpec As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtNoteEvent As System.Windows.Forms.TextBox
    Friend WithEvents pnlEquip As System.Windows.Forms.Panel
    Friend WithEvents btnEquipCancel As System.Windows.Forms.Button
    Friend WithEvents picEquipPort As System.Windows.Forms.PictureBox
    Friend WithEvents btnEquipConfirm As System.Windows.Forms.Button
    Friend WithEvents lblEquippedAccessory As System.Windows.Forms.Label
    Friend WithEvents cboxAccessory As System.Windows.Forms.ComboBox
    Friend WithEvents lblEquippedArmor As System.Windows.Forms.Label
    Friend WithEvents cboxArmor As System.Windows.Forms.ComboBox
    Friend WithEvents lblEquippedWeapon As System.Windows.Forms.Label
    Friend WithEvents cboxWeapon As System.Windows.Forms.ComboBox
    Friend WithEvents lblEquippedGlasses As System.Windows.Forms.Label
    Friend WithEvents cboxGlasses As System.Windows.Forms.ComboBox
    Friend WithEvents chkMisc As System.Windows.Forms.CheckBox
    Friend WithEvents pnlInvFilter As System.Windows.Forms.Panel
    Friend WithEvents ASCIIKeyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsHumanKey As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsDemonKey As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsItemKey As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsReptileKey As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsAntKey As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsDogKey As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsBlobKey As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsNymphKey As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsQuadrupedKey As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsUnicornKey As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsDragonKey As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents picFVTBoss1 As System.Windows.Forms.PictureBox
    Friend WithEvents picFVTBoss2 As System.Windows.Forms.PictureBox
    Friend WithEvents picFVTBoss3 As System.Windows.Forms.PictureBox
    Friend WithEvents picFVTBoss4 As System.Windows.Forms.PictureBox
    Friend WithEvents btnS4 As System.Windows.Forms.Button
    Friend WithEvents btnS5 As System.Windows.Forms.Button
    Friend WithEvents btnS3 As System.Windows.Forms.Button
    Friend WithEvents btnS2 As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnS1 As System.Windows.Forms.Button
    Friend WithEvents btnS9 As System.Windows.Forms.Button
    Friend WithEvents btnS10 As System.Windows.Forms.Button
    Friend WithEvents btnS8 As System.Windows.Forms.Button
    Friend WithEvents btnS7 As System.Windows.Forms.Button
    Friend WithEvents btnS6 As System.Windows.Forms.Button
    Friend WithEvents pnlSaveLoad As System.Windows.Forms.Panel
    Friend WithEvents picBoard As System.Windows.Forms.PictureBox
    Friend WithEvents picPinkMist As System.Windows.Forms.PictureBox
    Friend WithEvents btnEditGender As System.Windows.Forms.Button
End Class
