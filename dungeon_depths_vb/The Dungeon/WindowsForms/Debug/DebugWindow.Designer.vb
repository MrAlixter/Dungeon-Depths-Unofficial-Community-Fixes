<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Debug_Window
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            If Not map Is Nothing Then map.Dispose()
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Debug_Window))
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tabInformation = New System.Windows.Forms.TabPage()
        Me.boxNotes = New System.Windows.Forms.RichTextBox()
        Me.tabGeneral = New System.Windows.Forms.TabPage()
        Me.groupNotes = New System.Windows.Forms.GroupBox()
        Me.boxMap = New System.Windows.Forms.PictureBox()
        Me.groupGeneral = New System.Windows.Forms.GroupBox()
        Me.lblBarrier = New System.Windows.Forms.Label()
        Me.lblTrap = New System.Windows.Forms.Label()
        Me.boxBeaten = New System.Windows.Forms.CheckBox()
        Me.lblSelected = New System.Windows.Forms.Label()
        Me.btnEditSelection = New System.Windows.Forms.Button()
        Me.boxMapControls = New System.Windows.Forms.GroupBox()
        Me.lblZoom = New System.Windows.Forms.Label()
        Me.boxZoom = New System.Windows.Forms.NumericUpDown()
        Me.btnSelect = New System.Windows.Forms.RadioButton()
        Me.btnPan = New System.Windows.Forms.RadioButton()
        Me.lblStatue = New System.Windows.Forms.Label()
        Me.lblStairs = New System.Windows.Forms.Label()
        Me.lblChest = New System.Windows.Forms.Label()
        Me.lblNPC = New System.Windows.Forms.Label()
        Me.lblPlayer = New System.Windows.Forms.Label()
        Me.lblUnseen = New System.Windows.Forms.Label()
        Me.lblSeen = New System.Windows.Forms.Label()
        Me.lblKeyHeader = New System.Windows.Forms.Label()
        Me.boxTurn = New System.Windows.Forms.NumericUpDown()
        Me.boxFloor = New System.Windows.Forms.NumericUpDown()
        Me.lblTurn = New System.Windows.Forms.Label()
        Me.lblFloor = New System.Windows.Forms.Label()
        Me.tabPlayer = New System.Windows.Forms.TabPage()
        Me.boxForm = New System.Windows.Forms.ComboBox()
        Me.lblForm = New System.Windows.Forms.Label()
        Me.boxSex = New System.Windows.Forms.CheckBox()
        Me.boxAlpha = New System.Windows.Forms.NumericUpDown()
        Me.lblAlpha = New System.Windows.Forms.Label()
        Me.lblHC = New System.Windows.Forms.Label()
        Me.pnlHC = New System.Windows.Forms.Panel()
        Me.lblSC = New System.Windows.Forms.Label()
        Me.pnlSC = New System.Windows.Forms.Panel()
        Me.tabPortrait = New System.Windows.Forms.TabControl()
        Me.tabPageBackground = New System.Windows.Forms.TabPage()
        Me.tabPageTail = New System.Windows.Forms.TabPage()
        Me.tabPageWings = New System.Windows.Forms.TabPage()
        Me.tabPageRearHair = New System.Windows.Forms.TabPage()
        Me.tabPageHairAcc = New System.Windows.Forms.TabPage()
        Me.tabPageShoulders = New System.Windows.Forms.TabPage()
        Me.tabPageBody = New System.Windows.Forms.TabPage()
        Me.tabBodyOverlay = New System.Windows.Forms.TabPage()
        Me.tabPageGen = New System.Windows.Forms.TabPage()
        Me.tabPageChest = New System.Windows.Forms.TabPage()
        Me.tabPageClothesBtm = New System.Windows.Forms.TabPage()
        Me.tabPageClothing = New System.Windows.Forms.TabPage()
        Me.tabPageFace = New System.Windows.Forms.TabPage()
        Me.tabPageBlush = New System.Windows.Forms.TabPage()
        Me.tabPageFaceMark = New System.Windows.Forms.TabPage()
        Me.tabPageMiddleHair = New System.Windows.Forms.TabPage()
        Me.tabPageEars = New System.Windows.Forms.TabPage()
        Me.tabPageNose = New System.Windows.Forms.TabPage()
        Me.tabPageMouth = New System.Windows.Forms.TabPage()
        Me.tabPageEyes = New System.Windows.Forms.TabPage()
        Me.tabPageEyebrows = New System.Windows.Forms.TabPage()
        Me.tabPageGlasses = New System.Windows.Forms.TabPage()
        Me.tabPageCloak = New System.Windows.Forms.TabPage()
        Me.tabPageAccessories = New System.Windows.Forms.TabPage()
        Me.tabPageHorns = New System.Windows.Forms.TabPage()
        Me.tabPageFrontHair = New System.Windows.Forms.TabPage()
        Me.tabPageHat = New System.Windows.Forms.TabPage()
        Me.picPreview = New System.Windows.Forms.PictureBox()
        Me.playerDivider = New System.Windows.Forms.TextBox()
        Me.lblGold = New System.Windows.Forms.Label()
        Me.boxEvd = New System.Windows.Forms.NumericUpDown()
        Me.lblEvd = New System.Windows.Forms.Label()
        Me.boxSpd = New System.Windows.Forms.NumericUpDown()
        Me.lblSpd = New System.Windows.Forms.Label()
        Me.boxWil = New System.Windows.Forms.NumericUpDown()
        Me.lblWil = New System.Windows.Forms.Label()
        Me.boxDef = New System.Windows.Forms.NumericUpDown()
        Me.lblDef = New System.Windows.Forms.Label()
        Me.boxAtk = New System.Windows.Forms.NumericUpDown()
        Me.lblAtk = New System.Windows.Forms.Label()
        Me.boxGold = New System.Windows.Forms.NumericUpDown()
        Me.boxStamina = New System.Windows.Forms.NumericUpDown()
        Me.lblstamina = New System.Windows.Forms.Label()
        Me.boxMaxMana = New System.Windows.Forms.NumericUpDown()
        Me.lblOf2 = New System.Windows.Forms.Label()
        Me.boxMana = New System.Windows.Forms.NumericUpDown()
        Me.lblMana = New System.Windows.Forms.Label()
        Me.boxMaxHealth = New System.Windows.Forms.NumericUpDown()
        Me.lblOf1 = New System.Windows.Forms.Label()
        Me.boxHealth = New System.Windows.Forms.NumericUpDown()
        Me.lblHealth = New System.Windows.Forms.Label()
        Me.boxClass = New System.Windows.Forms.ComboBox()
        Me.boxName = New System.Windows.Forms.TextBox()
        Me.lblClass = New System.Windows.Forms.Label()
        Me.lblSex = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.tabPerks = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tabInventory = New System.Windows.Forms.TabPage()
        Me.boxInventoryFilter = New System.Windows.Forms.TextBox()
        Me.boxItemsFilter = New System.Windows.Forms.TextBox()
        Me.number = New System.Windows.Forms.NumericUpDown()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.boxInventory = New System.Windows.Forms.ListBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lblInventory = New System.Windows.Forms.Label()
        Me.boxItems = New System.Windows.Forms.ListBox()
        Me.lblItems = New System.Windows.Forms.Label()
        Me.tabGeneration = New System.Windows.Forms.TabPage()
        Me.boxTrapSizeDependence = New System.Windows.Forms.NumericUpDown()
        Me.lblTrapSizeDependence = New System.Windows.Forms.Label()
        Me.boxTrapFreqMin = New System.Windows.Forms.NumericUpDown()
        Me.boxTrapFreqRange = New System.Windows.Forms.NumericUpDown()
        Me.lblTrapFreqMin = New System.Windows.Forms.Label()
        Me.lblTrapFreqRange = New System.Windows.Forms.Label()
        Me.divider = New System.Windows.Forms.TextBox()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.btnSaveGeneration = New System.Windows.Forms.Button()
        Me.btnGenerationReset = New System.Windows.Forms.Button()
        Me.boxChestRichnessRange = New System.Windows.Forms.NumericUpDown()
        Me.lblChestRichnessRange = New System.Windows.Forms.Label()
        Me.boxChestRichnessBase = New System.Windows.Forms.NumericUpDown()
        Me.lblChestRichnessBase = New System.Windows.Forms.Label()
        Me.boxEClockResetVal = New System.Windows.Forms.NumericUpDown()
        Me.lblEClockResetVal = New System.Windows.Forms.Label()
        Me.boxEncounterRate = New System.Windows.Forms.NumericUpDown()
        Me.lblEncounterRate = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.separator1 = New System.Windows.Forms.GroupBox()
        Me.boxChestSizeDependence = New System.Windows.Forms.NumericUpDown()
        Me.lblChestSize = New System.Windows.Forms.Label()
        Me.boxChestFreqMin = New System.Windows.Forms.NumericUpDown()
        Me.lblChestFreqMin = New System.Windows.Forms.Label()
        Me.boxChestFreqRange = New System.Windows.Forms.NumericUpDown()
        Me.lblChestFreqRange = New System.Windows.Forms.Label()
        Me.boxHeight = New System.Windows.Forms.NumericUpDown()
        Me.boxWidth = New System.Windows.Forms.NumericUpDown()
        Me.lblHeight = New System.Windows.Forms.Label()
        Me.lblWidth = New System.Windows.Forms.Label()
        Me.lblFC = New System.Windows.Forms.Label()
        Me.tabMain.SuspendLayout()
        Me.tabInformation.SuspendLayout()
        Me.tabGeneral.SuspendLayout()
        Me.groupNotes.SuspendLayout()
        CType(Me.boxMap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupGeneral.SuspendLayout()
        Me.boxMapControls.SuspendLayout()
        CType(Me.boxZoom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxTurn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxFloor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPlayer.SuspendLayout()
        CType(Me.boxAlpha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPortrait.SuspendLayout()
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxEvd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxSpd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxWil, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxDef, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxAtk, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxGold, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxStamina, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxMaxMana, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxMana, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxMaxHealth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxHealth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPerks.SuspendLayout()
        Me.tabInventory.SuspendLayout()
        CType(Me.number, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabGeneration.SuspendLayout()
        CType(Me.boxTrapSizeDependence, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxTrapFreqMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxTrapFreqRange, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxChestRichnessRange, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxChestRichnessBase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxEClockResetVal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxEncounterRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxChestSizeDependence, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxChestFreqMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxChestFreqRange, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.tabInformation)
        Me.tabMain.Controls.Add(Me.tabGeneral)
        Me.tabMain.Controls.Add(Me.tabPlayer)
        Me.tabMain.Controls.Add(Me.tabPerks)
        Me.tabMain.Controls.Add(Me.tabInventory)
        Me.tabMain.Controls.Add(Me.tabGeneration)
        Me.tabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMain.Font = New System.Drawing.Font("Consolas", 10.0!)
        Me.tabMain.Location = New System.Drawing.Point(0, 0)
        Me.tabMain.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(1125, 886)
        Me.tabMain.TabIndex = 207
        '
        'tabInformation
        '
        Me.tabInformation.BackColor = System.Drawing.Color.Black
        Me.tabInformation.Controls.Add(Me.boxNotes)
        Me.tabInformation.ForeColor = System.Drawing.Color.White
        Me.tabInformation.Location = New System.Drawing.Point(4, 32)
        Me.tabInformation.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabInformation.Name = "tabInformation"
        Me.tabInformation.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabInformation.Size = New System.Drawing.Size(1117, 850)
        Me.tabInformation.TabIndex = 3
        Me.tabInformation.Text = "INFORMATION"
        '
        'boxNotes
        '
        Me.boxNotes.BackColor = System.Drawing.Color.Black
        Me.boxNotes.ForeColor = System.Drawing.Color.White
        Me.boxNotes.Location = New System.Drawing.Point(202, 85)
        Me.boxNotes.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxNotes.Name = "boxNotes"
        Me.boxNotes.ReadOnly = True
        Me.boxNotes.Size = New System.Drawing.Size(706, 673)
        Me.boxNotes.TabIndex = 2
        Me.boxNotes.Text = resources.GetString("boxNotes.Text")
        '
        'tabGeneral
        '
        Me.tabGeneral.BackColor = System.Drawing.Color.Black
        Me.tabGeneral.Controls.Add(Me.groupNotes)
        Me.tabGeneral.Controls.Add(Me.groupGeneral)
        Me.tabGeneral.Location = New System.Drawing.Point(4, 32)
        Me.tabGeneral.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabGeneral.Name = "tabGeneral"
        Me.tabGeneral.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabGeneral.Size = New System.Drawing.Size(1117, 850)
        Me.tabGeneral.TabIndex = 0
        Me.tabGeneral.Text = "GENERAL"
        '
        'groupNotes
        '
        Me.groupNotes.BackColor = System.Drawing.Color.Black
        Me.groupNotes.Controls.Add(Me.boxMap)
        Me.groupNotes.Location = New System.Drawing.Point(296, 11)
        Me.groupNotes.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.groupNotes.Name = "groupNotes"
        Me.groupNotes.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.groupNotes.Size = New System.Drawing.Size(806, 823)
        Me.groupNotes.TabIndex = 4
        Me.groupNotes.TabStop = False
        '
        'boxMap
        '
        Me.boxMap.BackColor = System.Drawing.Color.Black
        Me.boxMap.Location = New System.Drawing.Point(4, 17)
        Me.boxMap.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxMap.Name = "boxMap"
        Me.boxMap.Size = New System.Drawing.Size(798, 803)
        Me.boxMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.boxMap.TabIndex = 0
        Me.boxMap.TabStop = False
        '
        'groupGeneral
        '
        Me.groupGeneral.BackColor = System.Drawing.Color.Black
        Me.groupGeneral.Controls.Add(Me.lblBarrier)
        Me.groupGeneral.Controls.Add(Me.lblTrap)
        Me.groupGeneral.Controls.Add(Me.boxBeaten)
        Me.groupGeneral.Controls.Add(Me.lblSelected)
        Me.groupGeneral.Controls.Add(Me.btnEditSelection)
        Me.groupGeneral.Controls.Add(Me.boxMapControls)
        Me.groupGeneral.Controls.Add(Me.lblStatue)
        Me.groupGeneral.Controls.Add(Me.lblStairs)
        Me.groupGeneral.Controls.Add(Me.lblChest)
        Me.groupGeneral.Controls.Add(Me.lblNPC)
        Me.groupGeneral.Controls.Add(Me.lblPlayer)
        Me.groupGeneral.Controls.Add(Me.lblUnseen)
        Me.groupGeneral.Controls.Add(Me.lblSeen)
        Me.groupGeneral.Controls.Add(Me.lblKeyHeader)
        Me.groupGeneral.Controls.Add(Me.boxTurn)
        Me.groupGeneral.Controls.Add(Me.boxFloor)
        Me.groupGeneral.Controls.Add(Me.lblTurn)
        Me.groupGeneral.Controls.Add(Me.lblFloor)
        Me.groupGeneral.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.groupGeneral.ForeColor = System.Drawing.Color.White
        Me.groupGeneral.Location = New System.Drawing.Point(9, 11)
        Me.groupGeneral.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.groupGeneral.Name = "groupGeneral"
        Me.groupGeneral.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.groupGeneral.Size = New System.Drawing.Size(278, 823)
        Me.groupGeneral.TabIndex = 3
        Me.groupGeneral.TabStop = False
        Me.groupGeneral.Text = "GENERAL"
        '
        'lblBarrier
        '
        Me.lblBarrier.AutoSize = True
        Me.lblBarrier.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblBarrier.ForeColor = System.Drawing.Color.DarkRed
        Me.lblBarrier.Location = New System.Drawing.Point(84, 782)
        Me.lblBarrier.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBarrier.Name = "lblBarrier"
        Me.lblBarrier.Size = New System.Drawing.Size(103, 28)
        Me.lblBarrier.TabIndex = 210
        Me.lblBarrier.Text = "BARRIER"
        '
        'lblTrap
        '
        Me.lblTrap.AutoSize = True
        Me.lblTrap.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTrap.ForeColor = System.Drawing.Color.Red
        Me.lblTrap.Location = New System.Drawing.Point(105, 754)
        Me.lblTrap.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTrap.Name = "lblTrap"
        Me.lblTrap.Size = New System.Drawing.Size(64, 28)
        Me.lblTrap.TabIndex = 209
        Me.lblTrap.Text = "TRAP"
        '
        'boxBeaten
        '
        Me.boxBeaten.AutoSize = True
        Me.boxBeaten.Location = New System.Drawing.Point(10, 152)
        Me.boxBeaten.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxBeaten.Name = "boxBeaten"
        Me.boxBeaten.Size = New System.Drawing.Size(181, 32)
        Me.boxBeaten.TabIndex = 207
        Me.boxBeaten.Text = "BOSS BEATEN"
        Me.boxBeaten.UseVisualStyleBackColor = True
        '
        'lblSelected
        '
        Me.lblSelected.AutoSize = True
        Me.lblSelected.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblSelected.ForeColor = System.Drawing.Color.HotPink
        Me.lblSelected.Location = New System.Drawing.Point(78, 518)
        Me.lblSelected.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSelected.Name = "lblSelected"
        Me.lblSelected.Size = New System.Drawing.Size(116, 28)
        Me.lblSelected.TabIndex = 206
        Me.lblSelected.Text = "SELECTED"
        '
        'btnEditSelection
        '
        Me.btnEditSelection.BackColor = System.Drawing.Color.Black
        Me.btnEditSelection.Location = New System.Drawing.Point(62, 402)
        Me.btnEditSelection.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnEditSelection.Name = "btnEditSelection"
        Me.btnEditSelection.Size = New System.Drawing.Size(153, 71)
        Me.btnEditSelection.TabIndex = 205
        Me.btnEditSelection.Text = "EDIT SELECTION"
        Me.btnEditSelection.UseVisualStyleBackColor = False
        '
        'boxMapControls
        '
        Me.boxMapControls.Controls.Add(Me.lblZoom)
        Me.boxMapControls.Controls.Add(Me.boxZoom)
        Me.boxMapControls.Controls.Add(Me.btnSelect)
        Me.boxMapControls.Controls.Add(Me.btnPan)
        Me.boxMapControls.ForeColor = System.Drawing.Color.White
        Me.boxMapControls.Location = New System.Drawing.Point(12, 212)
        Me.boxMapControls.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxMapControls.Name = "boxMapControls"
        Me.boxMapControls.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxMapControls.Size = New System.Drawing.Size(254, 175)
        Me.boxMapControls.TabIndex = 1
        Me.boxMapControls.TabStop = False
        Me.boxMapControls.Text = "MAP CONTROLS"
        '
        'lblZoom
        '
        Me.lblZoom.AutoSize = True
        Me.lblZoom.Location = New System.Drawing.Point(20, 128)
        Me.lblZoom.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblZoom.Name = "lblZoom"
        Me.lblZoom.Size = New System.Drawing.Size(64, 28)
        Me.lblZoom.TabIndex = 208
        Me.lblZoom.Text = "ZOOM"
        '
        'boxZoom
        '
        Me.boxZoom.BackColor = System.Drawing.Color.Black
        Me.boxZoom.ForeColor = System.Drawing.Color.White
        Me.boxZoom.Location = New System.Drawing.Point(164, 125)
        Me.boxZoom.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxZoom.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.boxZoom.Name = "boxZoom"
        Me.boxZoom.Size = New System.Drawing.Size(81, 36)
        Me.boxZoom.TabIndex = 207
        Me.boxZoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.boxZoom.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'btnSelect
        '
        Me.btnSelect.AutoSize = True
        Me.btnSelect.Location = New System.Drawing.Point(26, 83)
        Me.btnSelect.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(115, 32)
        Me.btnSelect.TabIndex = 206
        Me.btnSelect.TabStop = True
        Me.btnSelect.Text = "SELECT"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'btnPan
        '
        Me.btnPan.AutoSize = True
        Me.btnPan.Location = New System.Drawing.Point(26, 38)
        Me.btnPan.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnPan.Name = "btnPan"
        Me.btnPan.Size = New System.Drawing.Size(76, 32)
        Me.btnPan.TabIndex = 205
        Me.btnPan.TabStop = True
        Me.btnPan.Text = "PAN"
        Me.btnPan.UseVisualStyleBackColor = True
        '
        'lblStatue
        '
        Me.lblStatue.AutoSize = True
        Me.lblStatue.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblStatue.ForeColor = System.Drawing.Color.Silver
        Me.lblStatue.Location = New System.Drawing.Point(92, 666)
        Me.lblStatue.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStatue.Name = "lblStatue"
        Me.lblStatue.Size = New System.Drawing.Size(90, 28)
        Me.lblStatue.TabIndex = 204
        Me.lblStatue.Text = "STATUE"
        '
        'lblStairs
        '
        Me.lblStairs.AutoSize = True
        Me.lblStairs.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblStairs.ForeColor = System.Drawing.Color.Sienna
        Me.lblStairs.Location = New System.Drawing.Point(92, 725)
        Me.lblStairs.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStairs.Name = "lblStairs"
        Me.lblStairs.Size = New System.Drawing.Size(90, 28)
        Me.lblStairs.TabIndex = 203
        Me.lblStairs.Text = "STAIRS"
        '
        'lblChest
        '
        Me.lblChest.AutoSize = True
        Me.lblChest.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblChest.ForeColor = System.Drawing.Color.Yellow
        Me.lblChest.Location = New System.Drawing.Point(98, 695)
        Me.lblChest.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblChest.Name = "lblChest"
        Me.lblChest.Size = New System.Drawing.Size(77, 28)
        Me.lblChest.TabIndex = 202
        Me.lblChest.Text = "CHEST"
        '
        'lblNPC
        '
        Me.lblNPC.AutoSize = True
        Me.lblNPC.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblNPC.ForeColor = System.Drawing.Color.Blue
        Me.lblNPC.Location = New System.Drawing.Point(111, 635)
        Me.lblNPC.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNPC.Name = "lblNPC"
        Me.lblNPC.Size = New System.Drawing.Size(51, 28)
        Me.lblNPC.TabIndex = 201
        Me.lblNPC.Text = "NPC"
        '
        'lblPlayer
        '
        Me.lblPlayer.AutoSize = True
        Me.lblPlayer.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblPlayer.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblPlayer.Location = New System.Drawing.Point(92, 606)
        Me.lblPlayer.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPlayer.Name = "lblPlayer"
        Me.lblPlayer.Size = New System.Drawing.Size(90, 28)
        Me.lblPlayer.TabIndex = 200
        Me.lblPlayer.Text = "PLAYER"
        '
        'lblUnseen
        '
        Me.lblUnseen.AutoSize = True
        Me.lblUnseen.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblUnseen.ForeColor = System.Drawing.Color.Gray
        Me.lblUnseen.Location = New System.Drawing.Point(92, 577)
        Me.lblUnseen.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUnseen.Name = "lblUnseen"
        Me.lblUnseen.Size = New System.Drawing.Size(90, 28)
        Me.lblUnseen.TabIndex = 199
        Me.lblUnseen.Text = "UNSEEN"
        '
        'lblSeen
        '
        Me.lblSeen.AutoSize = True
        Me.lblSeen.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblSeen.Location = New System.Drawing.Point(105, 548)
        Me.lblSeen.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSeen.Name = "lblSeen"
        Me.lblSeen.Size = New System.Drawing.Size(64, 28)
        Me.lblSeen.TabIndex = 198
        Me.lblSeen.Text = "SEEN"
        '
        'lblKeyHeader
        '
        Me.lblKeyHeader.AutoSize = True
        Me.lblKeyHeader.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Underline)
        Me.lblKeyHeader.Location = New System.Drawing.Point(84, 483)
        Me.lblKeyHeader.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblKeyHeader.Name = "lblKeyHeader"
        Me.lblKeyHeader.Size = New System.Drawing.Size(103, 28)
        Me.lblKeyHeader.TabIndex = 197
        Me.lblKeyHeader.Text = "MAP KEY"
        '
        'boxTurn
        '
        Me.boxTurn.BackColor = System.Drawing.Color.Black
        Me.boxTurn.ForeColor = System.Drawing.Color.White
        Me.boxTurn.Location = New System.Drawing.Point(99, 75)
        Me.boxTurn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxTurn.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.boxTurn.Name = "boxTurn"
        Me.boxTurn.Size = New System.Drawing.Size(170, 36)
        Me.boxTurn.TabIndex = 196
        Me.boxTurn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'boxFloor
        '
        Me.boxFloor.BackColor = System.Drawing.Color.Black
        Me.boxFloor.Enabled = False
        Me.boxFloor.ForeColor = System.Drawing.Color.White
        Me.boxFloor.Location = New System.Drawing.Point(99, 31)
        Me.boxFloor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxFloor.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.boxFloor.Name = "boxFloor"
        Me.boxFloor.Size = New System.Drawing.Size(170, 36)
        Me.boxFloor.TabIndex = 195
        Me.boxFloor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTurn
        '
        Me.lblTurn.AutoSize = True
        Me.lblTurn.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTurn.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblTurn.ForeColor = System.Drawing.Color.White
        Me.lblTurn.Location = New System.Drawing.Point(4, 77)
        Me.lblTurn.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTurn.Name = "lblTurn"
        Me.lblTurn.Padding = New System.Windows.Forms.Padding(0, 0, 0, 15)
        Me.lblTurn.Size = New System.Drawing.Size(90, 43)
        Me.lblTurn.TabIndex = 1
        Me.lblTurn.Text = "TURN: "
        '
        'lblFloor
        '
        Me.lblFloor.AutoSize = True
        Me.lblFloor.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblFloor.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblFloor.ForeColor = System.Drawing.Color.White
        Me.lblFloor.Location = New System.Drawing.Point(4, 34)
        Me.lblFloor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFloor.Name = "lblFloor"
        Me.lblFloor.Padding = New System.Windows.Forms.Padding(0, 0, 0, 15)
        Me.lblFloor.Size = New System.Drawing.Size(103, 43)
        Me.lblFloor.TabIndex = 2
        Me.lblFloor.Text = "FLOOR: "
        '
        'tabPlayer
        '
        Me.tabPlayer.BackColor = System.Drawing.Color.Black
        Me.tabPlayer.Controls.Add(Me.boxForm)
        Me.tabPlayer.Controls.Add(Me.lblForm)
        Me.tabPlayer.Controls.Add(Me.boxSex)
        Me.tabPlayer.Controls.Add(Me.boxAlpha)
        Me.tabPlayer.Controls.Add(Me.lblAlpha)
        Me.tabPlayer.Controls.Add(Me.lblHC)
        Me.tabPlayer.Controls.Add(Me.pnlHC)
        Me.tabPlayer.Controls.Add(Me.lblSC)
        Me.tabPlayer.Controls.Add(Me.pnlSC)
        Me.tabPlayer.Controls.Add(Me.tabPortrait)
        Me.tabPlayer.Controls.Add(Me.picPreview)
        Me.tabPlayer.Controls.Add(Me.playerDivider)
        Me.tabPlayer.Controls.Add(Me.lblGold)
        Me.tabPlayer.Controls.Add(Me.boxEvd)
        Me.tabPlayer.Controls.Add(Me.lblEvd)
        Me.tabPlayer.Controls.Add(Me.boxSpd)
        Me.tabPlayer.Controls.Add(Me.lblSpd)
        Me.tabPlayer.Controls.Add(Me.boxWil)
        Me.tabPlayer.Controls.Add(Me.lblWil)
        Me.tabPlayer.Controls.Add(Me.boxDef)
        Me.tabPlayer.Controls.Add(Me.lblDef)
        Me.tabPlayer.Controls.Add(Me.boxAtk)
        Me.tabPlayer.Controls.Add(Me.lblAtk)
        Me.tabPlayer.Controls.Add(Me.boxGold)
        Me.tabPlayer.Controls.Add(Me.boxStamina)
        Me.tabPlayer.Controls.Add(Me.lblstamina)
        Me.tabPlayer.Controls.Add(Me.boxMaxMana)
        Me.tabPlayer.Controls.Add(Me.lblOf2)
        Me.tabPlayer.Controls.Add(Me.boxMana)
        Me.tabPlayer.Controls.Add(Me.lblMana)
        Me.tabPlayer.Controls.Add(Me.boxMaxHealth)
        Me.tabPlayer.Controls.Add(Me.lblOf1)
        Me.tabPlayer.Controls.Add(Me.boxHealth)
        Me.tabPlayer.Controls.Add(Me.lblHealth)
        Me.tabPlayer.Controls.Add(Me.boxClass)
        Me.tabPlayer.Controls.Add(Me.boxName)
        Me.tabPlayer.Controls.Add(Me.lblClass)
        Me.tabPlayer.Controls.Add(Me.lblSex)
        Me.tabPlayer.Controls.Add(Me.lblName)
        Me.tabPlayer.Location = New System.Drawing.Point(4, 32)
        Me.tabPlayer.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabPlayer.Name = "tabPlayer"
        Me.tabPlayer.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabPlayer.Size = New System.Drawing.Size(1117, 850)
        Me.tabPlayer.TabIndex = 1
        Me.tabPlayer.Text = "PLAYER"
        '
        'boxForm
        '
        Me.boxForm.BackColor = System.Drawing.Color.Black
        Me.boxForm.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.boxForm.ForeColor = System.Drawing.Color.White
        Me.boxForm.FormattingEnabled = True
        Me.boxForm.Location = New System.Drawing.Point(546, 6)
        Me.boxForm.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxForm.Name = "boxForm"
        Me.boxForm.Size = New System.Drawing.Size(199, 36)
        Me.boxForm.TabIndex = 272
        '
        'lblForm
        '
        Me.lblForm.AutoSize = True
        Me.lblForm.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblForm.ForeColor = System.Drawing.Color.White
        Me.lblForm.Location = New System.Drawing.Point(382, 11)
        Me.lblForm.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblForm.Name = "lblForm"
        Me.lblForm.Size = New System.Drawing.Size(64, 28)
        Me.lblForm.TabIndex = 271
        Me.lblForm.Text = "FORM"
        '
        'boxSex
        '
        Me.boxSex.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.boxSex.Location = New System.Drawing.Point(1014, 355)
        Me.boxSex.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxSex.Name = "boxSex"
        Me.boxSex.Size = New System.Drawing.Size(50, 26)
        Me.boxSex.TabIndex = 270
        Me.boxSex.Text = "CheckBox1"
        Me.boxSex.UseVisualStyleBackColor = True
        Me.boxSex.Visible = False
        '
        'boxAlpha
        '
        Me.boxAlpha.BackColor = System.Drawing.Color.Black
        Me.boxAlpha.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.boxAlpha.ForeColor = System.Drawing.Color.White
        Me.boxAlpha.Location = New System.Drawing.Point(668, 325)
        Me.boxAlpha.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxAlpha.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.boxAlpha.Name = "boxAlpha"
        Me.boxAlpha.Size = New System.Drawing.Size(80, 36)
        Me.boxAlpha.TabIndex = 269
        '
        'lblAlpha
        '
        Me.lblAlpha.AutoSize = True
        Me.lblAlpha.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblAlpha.ForeColor = System.Drawing.Color.White
        Me.lblAlpha.Location = New System.Drawing.Point(500, 329)
        Me.lblAlpha.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAlpha.Name = "lblAlpha"
        Me.lblAlpha.Size = New System.Drawing.Size(142, 28)
        Me.lblAlpha.TabIndex = 267
        Me.lblAlpha.Text = "HAIR ALPHA"
        '
        'lblHC
        '
        Me.lblHC.AutoSize = True
        Me.lblHC.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblHC.ForeColor = System.Drawing.Color.White
        Me.lblHC.Location = New System.Drawing.Point(258, 329)
        Me.lblHC.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblHC.Name = "lblHC"
        Me.lblHC.Size = New System.Drawing.Size(142, 28)
        Me.lblHC.TabIndex = 266
        Me.lblHC.Text = "HAIR COLOR"
        '
        'pnlHC
        '
        Me.pnlHC.Location = New System.Drawing.Point(423, 325)
        Me.pnlHC.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pnlHC.Name = "pnlHC"
        Me.pnlHC.Size = New System.Drawing.Size(58, 40)
        Me.pnlHC.TabIndex = 265
        '
        'lblSC
        '
        Me.lblSC.AutoSize = True
        Me.lblSC.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblSC.ForeColor = System.Drawing.Color.White
        Me.lblSC.Location = New System.Drawing.Point(4, 329)
        Me.lblSC.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSC.Name = "lblSC"
        Me.lblSC.Size = New System.Drawing.Size(142, 28)
        Me.lblSC.TabIndex = 264
        Me.lblSC.Text = "SKIN COLOR"
        '
        'pnlSC
        '
        Me.pnlSC.Location = New System.Drawing.Point(172, 325)
        Me.pnlSC.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pnlSC.Name = "pnlSC"
        Me.pnlSC.Size = New System.Drawing.Size(58, 40)
        Me.pnlSC.TabIndex = 263
        '
        'tabPortrait
        '
        Me.tabPortrait.Controls.Add(Me.tabPageBackground)
        Me.tabPortrait.Controls.Add(Me.tabPageTail)
        Me.tabPortrait.Controls.Add(Me.tabPageWings)
        Me.tabPortrait.Controls.Add(Me.tabPageRearHair)
        Me.tabPortrait.Controls.Add(Me.tabPageHairAcc)
        Me.tabPortrait.Controls.Add(Me.tabPageShoulders)
        Me.tabPortrait.Controls.Add(Me.tabPageBody)
        Me.tabPortrait.Controls.Add(Me.tabBodyOverlay)
        Me.tabPortrait.Controls.Add(Me.tabPageGen)
        Me.tabPortrait.Controls.Add(Me.tabPageChest)
        Me.tabPortrait.Controls.Add(Me.tabPageClothesBtm)
        Me.tabPortrait.Controls.Add(Me.tabPageClothing)
        Me.tabPortrait.Controls.Add(Me.tabPageFace)
        Me.tabPortrait.Controls.Add(Me.tabPageBlush)
        Me.tabPortrait.Controls.Add(Me.tabPageFaceMark)
        Me.tabPortrait.Controls.Add(Me.tabPageMiddleHair)
        Me.tabPortrait.Controls.Add(Me.tabPageEars)
        Me.tabPortrait.Controls.Add(Me.tabPageNose)
        Me.tabPortrait.Controls.Add(Me.tabPageMouth)
        Me.tabPortrait.Controls.Add(Me.tabPageEyes)
        Me.tabPortrait.Controls.Add(Me.tabPageEyebrows)
        Me.tabPortrait.Controls.Add(Me.tabPageGlasses)
        Me.tabPortrait.Controls.Add(Me.tabPageCloak)
        Me.tabPortrait.Controls.Add(Me.tabPageAccessories)
        Me.tabPortrait.Controls.Add(Me.tabPageHorns)
        Me.tabPortrait.Controls.Add(Me.tabPageFrontHair)
        Me.tabPortrait.Controls.Add(Me.tabPageHat)
        Me.tabPortrait.Location = New System.Drawing.Point(4, 391)
        Me.tabPortrait.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabPortrait.Name = "tabPortrait"
        Me.tabPortrait.SelectedIndex = 0
        Me.tabPortrait.Size = New System.Drawing.Size(1104, 448)
        Me.tabPortrait.TabIndex = 262
        '
        'tabPageBackground
        '
        Me.tabPageBackground.AutoScroll = True
        Me.tabPageBackground.BackColor = System.Drawing.Color.Black
        Me.tabPageBackground.Location = New System.Drawing.Point(4, 32)
        Me.tabPageBackground.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabPageBackground.Name = "tabPageBackground"
        Me.tabPageBackground.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabPageBackground.Size = New System.Drawing.Size(1096, 412)
        Me.tabPageBackground.TabIndex = 0
        Me.tabPageBackground.Text = "BACKGROUND"
        '
        'tabPageTail
        '
        Me.tabPageTail.BackColor = System.Drawing.Color.Black
        Me.tabPageTail.ForeColor = System.Drawing.Color.White
        Me.tabPageTail.Location = New System.Drawing.Point(4, 32)
        Me.tabPageTail.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabPageTail.Name = "tabPageTail"
        Me.tabPageTail.Size = New System.Drawing.Size(1096, 412)
        Me.tabPageTail.TabIndex = 17
        Me.tabPageTail.Text = " TAIL"
        '
        'tabPageWings
        '
        Me.tabPageWings.BackColor = System.Drawing.Color.Black
        Me.tabPageWings.ForeColor = System.Drawing.Color.White
        Me.tabPageWings.Location = New System.Drawing.Point(4, 32)
        Me.tabPageWings.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabPageWings.Name = "tabPageWings"
        Me.tabPageWings.Size = New System.Drawing.Size(1096, 412)
        Me.tabPageWings.TabIndex = 18
        Me.tabPageWings.Text = "WINGS"
        '
        'tabPageRearHair
        '
        Me.tabPageRearHair.AutoScroll = True
        Me.tabPageRearHair.BackColor = System.Drawing.Color.Black
        Me.tabPageRearHair.Location = New System.Drawing.Point(4, 32)
        Me.tabPageRearHair.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabPageRearHair.Name = "tabPageRearHair"
        Me.tabPageRearHair.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabPageRearHair.Size = New System.Drawing.Size(1096, 412)
        Me.tabPageRearHair.TabIndex = 1
        Me.tabPageRearHair.Text = "REAR HAIR"
        '
        'tabPageHairAcc
        '
        Me.tabPageHairAcc.BackColor = System.Drawing.Color.Black
        Me.tabPageHairAcc.ForeColor = System.Drawing.Color.White
        Me.tabPageHairAcc.Location = New System.Drawing.Point(4, 32)
        Me.tabPageHairAcc.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabPageHairAcc.Name = "tabPageHairAcc"
        Me.tabPageHairAcc.Size = New System.Drawing.Size(1096, 412)
        Me.tabPageHairAcc.TabIndex = 19
        Me.tabPageHairAcc.Text = "HAIR ACC"
        '
        'tabPageShoulders
        '
        Me.tabPageShoulders.BackColor = System.Drawing.Color.Black
        Me.tabPageShoulders.ForeColor = System.Drawing.Color.White
        Me.tabPageShoulders.Location = New System.Drawing.Point(4, 32)
        Me.tabPageShoulders.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabPageShoulders.Name = "tabPageShoulders"
        Me.tabPageShoulders.Size = New System.Drawing.Size(1096, 412)
        Me.tabPageShoulders.TabIndex = 20
        Me.tabPageShoulders.Text = "SHOULDERS"
        '
        'tabPageBody
        '
        Me.tabPageBody.AutoScroll = True
        Me.tabPageBody.BackColor = System.Drawing.Color.Black
        Me.tabPageBody.Location = New System.Drawing.Point(4, 32)
        Me.tabPageBody.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabPageBody.Name = "tabPageBody"
        Me.tabPageBody.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabPageBody.Size = New System.Drawing.Size(1096, 412)
        Me.tabPageBody.TabIndex = 2
        Me.tabPageBody.Text = "BODY"
        '
        'tabBodyOverlay
        '
        Me.tabBodyOverlay.BackColor = System.Drawing.Color.Black
        Me.tabBodyOverlay.ForeColor = System.Drawing.Color.White
        Me.tabBodyOverlay.Location = New System.Drawing.Point(4, 32)
        Me.tabBodyOverlay.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabBodyOverlay.Name = "tabBodyOverlay"
        Me.tabBodyOverlay.Size = New System.Drawing.Size(1096, 412)
        Me.tabBodyOverlay.TabIndex = 21
        Me.tabBodyOverlay.Text = "BODY OVERLAY"
        '
        'tabPageGen
        '
        Me.tabPageGen.BackColor = System.Drawing.Color.Black
        Me.tabPageGen.ForeColor = System.Drawing.Color.White
        Me.tabPageGen.Location = New System.Drawing.Point(4, 32)
        Me.tabPageGen.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabPageGen.Name = "tabPageGen"
        Me.tabPageGen.Size = New System.Drawing.Size(1096, 412)
        Me.tabPageGen.TabIndex = 22
        Me.tabPageGen.Text = "GEN"
        '
        'tabPageChest
        '
        Me.tabPageChest.BackColor = System.Drawing.Color.Black
        Me.tabPageChest.ForeColor = System.Drawing.Color.White
        Me.tabPageChest.Location = New System.Drawing.Point(4, 32)
        Me.tabPageChest.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabPageChest.Name = "tabPageChest"
        Me.tabPageChest.Size = New System.Drawing.Size(1096, 412)
        Me.tabPageChest.TabIndex = 23
        Me.tabPageChest.Text = "CHEST"
        '
        'tabPageClothesBtm
        '
        Me.tabPageClothesBtm.BackColor = System.Drawing.Color.Black
        Me.tabPageClothesBtm.ForeColor = System.Drawing.Color.White
        Me.tabPageClothesBtm.Location = New System.Drawing.Point(4, 32)
        Me.tabPageClothesBtm.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabPageClothesBtm.Name = "tabPageClothesBtm"
        Me.tabPageClothesBtm.Size = New System.Drawing.Size(1096, 412)
        Me.tabPageClothesBtm.TabIndex = 24
        Me.tabPageClothesBtm.Text = "B. CLOTHING"
        '
        'tabPageClothing
        '
        Me.tabPageClothing.AutoScroll = True
        Me.tabPageClothing.BackColor = System.Drawing.Color.Black
        Me.tabPageClothing.Location = New System.Drawing.Point(4, 32)
        Me.tabPageClothing.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabPageClothing.Name = "tabPageClothing"
        Me.tabPageClothing.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabPageClothing.Size = New System.Drawing.Size(1096, 412)
        Me.tabPageClothing.TabIndex = 3
        Me.tabPageClothing.Text = "T. CLOTHING"
        '
        'tabPageFace
        '
        Me.tabPageFace.AutoScroll = True
        Me.tabPageFace.BackColor = System.Drawing.Color.Black
        Me.tabPageFace.Location = New System.Drawing.Point(4, 32)
        Me.tabPageFace.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabPageFace.Name = "tabPageFace"
        Me.tabPageFace.Size = New System.Drawing.Size(1096, 412)
        Me.tabPageFace.TabIndex = 4
        Me.tabPageFace.Text = "FACE"
        '
        'tabPageBlush
        '
        Me.tabPageBlush.BackColor = System.Drawing.Color.Black
        Me.tabPageBlush.Location = New System.Drawing.Point(4, 32)
        Me.tabPageBlush.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabPageBlush.Name = "tabPageBlush"
        Me.tabPageBlush.Size = New System.Drawing.Size(1096, 412)
        Me.tabPageBlush.TabIndex = 26
        Me.tabPageBlush.Text = "BLUSH"
        '
        'tabPageFaceMark
        '
        Me.tabPageFaceMark.AutoScroll = True
        Me.tabPageFaceMark.BackColor = System.Drawing.Color.Black
        Me.tabPageFaceMark.Location = New System.Drawing.Point(4, 32)
        Me.tabPageFaceMark.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabPageFaceMark.Name = "tabPageFaceMark"
        Me.tabPageFaceMark.Size = New System.Drawing.Size(1096, 412)
        Me.tabPageFaceMark.TabIndex = 11
        Me.tabPageFaceMark.Text = "FACE MARK"
        '
        'tabPageMiddleHair
        '
        Me.tabPageMiddleHair.AutoScroll = True
        Me.tabPageMiddleHair.BackColor = System.Drawing.Color.Black
        Me.tabPageMiddleHair.Location = New System.Drawing.Point(4, 32)
        Me.tabPageMiddleHair.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabPageMiddleHair.Name = "tabPageMiddleHair"
        Me.tabPageMiddleHair.Size = New System.Drawing.Size(1096, 412)
        Me.tabPageMiddleHair.TabIndex = 5
        Me.tabPageMiddleHair.Text = "MIDDLE HAIR"
        '
        'tabPageEars
        '
        Me.tabPageEars.AutoScroll = True
        Me.tabPageEars.BackColor = System.Drawing.Color.Black
        Me.tabPageEars.Location = New System.Drawing.Point(4, 32)
        Me.tabPageEars.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabPageEars.Name = "tabPageEars"
        Me.tabPageEars.Size = New System.Drawing.Size(1096, 412)
        Me.tabPageEars.TabIndex = 6
        Me.tabPageEars.Text = "EARS"
        '
        'tabPageNose
        '
        Me.tabPageNose.AutoScroll = True
        Me.tabPageNose.BackColor = System.Drawing.Color.Black
        Me.tabPageNose.Location = New System.Drawing.Point(4, 32)
        Me.tabPageNose.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabPageNose.Name = "tabPageNose"
        Me.tabPageNose.Size = New System.Drawing.Size(1096, 412)
        Me.tabPageNose.TabIndex = 7
        Me.tabPageNose.Text = "NOSE"
        '
        'tabPageMouth
        '
        Me.tabPageMouth.AutoScroll = True
        Me.tabPageMouth.BackColor = System.Drawing.Color.Black
        Me.tabPageMouth.Location = New System.Drawing.Point(4, 32)
        Me.tabPageMouth.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabPageMouth.Name = "tabPageMouth"
        Me.tabPageMouth.Size = New System.Drawing.Size(1096, 412)
        Me.tabPageMouth.TabIndex = 8
        Me.tabPageMouth.Text = "MOUTH"
        '
        'tabPageEyes
        '
        Me.tabPageEyes.AutoScroll = True
        Me.tabPageEyes.BackColor = System.Drawing.Color.Black
        Me.tabPageEyes.Location = New System.Drawing.Point(4, 32)
        Me.tabPageEyes.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabPageEyes.Name = "tabPageEyes"
        Me.tabPageEyes.Size = New System.Drawing.Size(1096, 412)
        Me.tabPageEyes.TabIndex = 9
        Me.tabPageEyes.Text = "EYES"
        '
        'tabPageEyebrows
        '
        Me.tabPageEyebrows.AutoScroll = True
        Me.tabPageEyebrows.BackColor = System.Drawing.Color.Black
        Me.tabPageEyebrows.Location = New System.Drawing.Point(4, 32)
        Me.tabPageEyebrows.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabPageEyebrows.Name = "tabPageEyebrows"
        Me.tabPageEyebrows.Size = New System.Drawing.Size(1096, 412)
        Me.tabPageEyebrows.TabIndex = 10
        Me.tabPageEyebrows.Text = "EYEBROWS"
        '
        'tabPageGlasses
        '
        Me.tabPageGlasses.AutoScroll = True
        Me.tabPageGlasses.BackColor = System.Drawing.Color.Black
        Me.tabPageGlasses.Location = New System.Drawing.Point(4, 32)
        Me.tabPageGlasses.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabPageGlasses.Name = "tabPageGlasses"
        Me.tabPageGlasses.Size = New System.Drawing.Size(1096, 412)
        Me.tabPageGlasses.TabIndex = 12
        Me.tabPageGlasses.Text = "GLASSES"
        '
        'tabPageCloak
        '
        Me.tabPageCloak.AutoScroll = True
        Me.tabPageCloak.BackColor = System.Drawing.Color.Black
        Me.tabPageCloak.Location = New System.Drawing.Point(4, 32)
        Me.tabPageCloak.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabPageCloak.Name = "tabPageCloak"
        Me.tabPageCloak.Size = New System.Drawing.Size(1096, 412)
        Me.tabPageCloak.TabIndex = 13
        Me.tabPageCloak.Text = "CLOAK"
        '
        'tabPageAccessories
        '
        Me.tabPageAccessories.AutoScroll = True
        Me.tabPageAccessories.BackColor = System.Drawing.Color.Black
        Me.tabPageAccessories.Location = New System.Drawing.Point(4, 32)
        Me.tabPageAccessories.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabPageAccessories.Name = "tabPageAccessories"
        Me.tabPageAccessories.Size = New System.Drawing.Size(1096, 412)
        Me.tabPageAccessories.TabIndex = 14
        Me.tabPageAccessories.Text = "ACCESSORIES"
        '
        'tabPageHorns
        '
        Me.tabPageHorns.BackColor = System.Drawing.Color.Black
        Me.tabPageHorns.ForeColor = System.Drawing.Color.White
        Me.tabPageHorns.Location = New System.Drawing.Point(4, 32)
        Me.tabPageHorns.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabPageHorns.Name = "tabPageHorns"
        Me.tabPageHorns.Size = New System.Drawing.Size(1096, 412)
        Me.tabPageHorns.TabIndex = 25
        Me.tabPageHorns.Text = "HORNS"
        '
        'tabPageFrontHair
        '
        Me.tabPageFrontHair.AutoScroll = True
        Me.tabPageFrontHair.BackColor = System.Drawing.Color.Black
        Me.tabPageFrontHair.Location = New System.Drawing.Point(4, 32)
        Me.tabPageFrontHair.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabPageFrontHair.Name = "tabPageFrontHair"
        Me.tabPageFrontHair.Size = New System.Drawing.Size(1096, 412)
        Me.tabPageFrontHair.TabIndex = 15
        Me.tabPageFrontHair.Text = "FRONT HAIR"
        '
        'tabPageHat
        '
        Me.tabPageHat.AutoScroll = True
        Me.tabPageHat.BackColor = System.Drawing.Color.Black
        Me.tabPageHat.Location = New System.Drawing.Point(4, 32)
        Me.tabPageHat.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabPageHat.Name = "tabPageHat"
        Me.tabPageHat.Size = New System.Drawing.Size(1096, 412)
        Me.tabPageHat.TabIndex = 16
        Me.tabPageHat.Text = "HAT"
        '
        'picPreview
        '
        Me.picPreview.Location = New System.Drawing.Point(822, 6)
        Me.picPreview.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.picPreview.Name = "picPreview"
        Me.picPreview.Size = New System.Drawing.Size(219, 332)
        Me.picPreview.TabIndex = 236
        Me.picPreview.TabStop = False
        '
        'playerDivider
        '
        Me.playerDivider.Location = New System.Drawing.Point(372, 5)
        Me.playerDivider.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.playerDivider.Multiline = True
        Me.playerDivider.Name = "playerDivider"
        Me.playerDivider.Size = New System.Drawing.Size(0, 306)
        Me.playerDivider.TabIndex = 235
        '
        'lblGold
        '
        Me.lblGold.AutoSize = True
        Me.lblGold.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblGold.ForeColor = System.Drawing.Color.White
        Me.lblGold.Location = New System.Drawing.Point(375, 278)
        Me.lblGold.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGold.Name = "lblGold"
        Me.lblGold.Size = New System.Drawing.Size(64, 28)
        Me.lblGold.TabIndex = 224
        Me.lblGold.Text = "GOLD"
        '
        'boxEvd
        '
        Me.boxEvd.BackColor = System.Drawing.Color.Black
        Me.boxEvd.Enabled = False
        Me.boxEvd.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.boxEvd.ForeColor = System.Drawing.Color.White
        Me.boxEvd.Location = New System.Drawing.Point(165, 275)
        Me.boxEvd.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxEvd.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.boxEvd.Name = "boxEvd"
        Me.boxEvd.Size = New System.Drawing.Size(201, 36)
        Me.boxEvd.TabIndex = 223
        Me.boxEvd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblEvd
        '
        Me.lblEvd.AutoSize = True
        Me.lblEvd.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblEvd.ForeColor = System.Drawing.Color.White
        Me.lblEvd.Location = New System.Drawing.Point(4, 278)
        Me.lblEvd.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEvd.Name = "lblEvd"
        Me.lblEvd.Size = New System.Drawing.Size(51, 28)
        Me.lblEvd.TabIndex = 222
        Me.lblEvd.Text = "EVD"
        '
        'boxSpd
        '
        Me.boxSpd.BackColor = System.Drawing.Color.Black
        Me.boxSpd.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.boxSpd.ForeColor = System.Drawing.Color.White
        Me.boxSpd.Location = New System.Drawing.Point(546, 231)
        Me.boxSpd.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxSpd.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.boxSpd.Name = "boxSpd"
        Me.boxSpd.Size = New System.Drawing.Size(201, 36)
        Me.boxSpd.TabIndex = 221
        Me.boxSpd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSpd
        '
        Me.lblSpd.AutoSize = True
        Me.lblSpd.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblSpd.ForeColor = System.Drawing.Color.White
        Me.lblSpd.Location = New System.Drawing.Point(375, 234)
        Me.lblSpd.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSpd.Name = "lblSpd"
        Me.lblSpd.Size = New System.Drawing.Size(51, 28)
        Me.lblSpd.TabIndex = 220
        Me.lblSpd.Text = "SPD"
        '
        'boxWil
        '
        Me.boxWil.BackColor = System.Drawing.Color.Black
        Me.boxWil.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.boxWil.ForeColor = System.Drawing.Color.White
        Me.boxWil.Location = New System.Drawing.Point(165, 231)
        Me.boxWil.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxWil.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.boxWil.Name = "boxWil"
        Me.boxWil.Size = New System.Drawing.Size(201, 36)
        Me.boxWil.TabIndex = 219
        Me.boxWil.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblWil
        '
        Me.lblWil.AutoSize = True
        Me.lblWil.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblWil.ForeColor = System.Drawing.Color.White
        Me.lblWil.Location = New System.Drawing.Point(4, 234)
        Me.lblWil.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblWil.Name = "lblWil"
        Me.lblWil.Size = New System.Drawing.Size(64, 28)
        Me.lblWil.TabIndex = 218
        Me.lblWil.Text = "WILL"
        '
        'boxDef
        '
        Me.boxDef.BackColor = System.Drawing.Color.Black
        Me.boxDef.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.boxDef.ForeColor = System.Drawing.Color.White
        Me.boxDef.Location = New System.Drawing.Point(546, 186)
        Me.boxDef.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxDef.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.boxDef.Name = "boxDef"
        Me.boxDef.Size = New System.Drawing.Size(201, 36)
        Me.boxDef.TabIndex = 217
        Me.boxDef.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDef
        '
        Me.lblDef.AutoSize = True
        Me.lblDef.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblDef.ForeColor = System.Drawing.Color.White
        Me.lblDef.Location = New System.Drawing.Point(375, 189)
        Me.lblDef.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDef.Name = "lblDef"
        Me.lblDef.Size = New System.Drawing.Size(51, 28)
        Me.lblDef.TabIndex = 216
        Me.lblDef.Text = "DEF"
        '
        'boxAtk
        '
        Me.boxAtk.BackColor = System.Drawing.Color.Black
        Me.boxAtk.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.boxAtk.ForeColor = System.Drawing.Color.White
        Me.boxAtk.Location = New System.Drawing.Point(165, 186)
        Me.boxAtk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxAtk.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.boxAtk.Name = "boxAtk"
        Me.boxAtk.Size = New System.Drawing.Size(201, 36)
        Me.boxAtk.TabIndex = 215
        Me.boxAtk.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAtk
        '
        Me.lblAtk.AutoSize = True
        Me.lblAtk.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblAtk.ForeColor = System.Drawing.Color.White
        Me.lblAtk.Location = New System.Drawing.Point(4, 189)
        Me.lblAtk.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAtk.Name = "lblAtk"
        Me.lblAtk.Size = New System.Drawing.Size(51, 28)
        Me.lblAtk.TabIndex = 214
        Me.lblAtk.Text = "ATK"
        '
        'boxGold
        '
        Me.boxGold.BackColor = System.Drawing.Color.Black
        Me.boxGold.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.boxGold.ForeColor = System.Drawing.Color.White
        Me.boxGold.Location = New System.Drawing.Point(546, 275)
        Me.boxGold.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxGold.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.boxGold.Name = "boxGold"
        Me.boxGold.Size = New System.Drawing.Size(201, 36)
        Me.boxGold.TabIndex = 213
        Me.boxGold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'boxStamina
        '
        Me.boxStamina.BackColor = System.Drawing.Color.Black
        Me.boxStamina.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.boxStamina.ForeColor = System.Drawing.Color.White
        Me.boxStamina.Location = New System.Drawing.Point(546, 52)
        Me.boxStamina.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxStamina.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.boxStamina.Name = "boxStamina"
        Me.boxStamina.Size = New System.Drawing.Size(201, 36)
        Me.boxStamina.TabIndex = 228
        Me.boxStamina.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblstamina
        '
        Me.lblstamina.AutoSize = True
        Me.lblstamina.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblstamina.ForeColor = System.Drawing.Color.White
        Me.lblstamina.Location = New System.Drawing.Point(382, 55)
        Me.lblstamina.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblstamina.Name = "lblstamina"
        Me.lblstamina.Size = New System.Drawing.Size(103, 28)
        Me.lblstamina.TabIndex = 229
        Me.lblstamina.Text = "STAMINA"
        '
        'boxMaxMana
        '
        Me.boxMaxMana.BackColor = System.Drawing.Color.Black
        Me.boxMaxMana.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.boxMaxMana.ForeColor = System.Drawing.Color.White
        Me.boxMaxMana.Location = New System.Drawing.Point(546, 142)
        Me.boxMaxMana.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxMaxMana.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.boxMaxMana.Name = "boxMaxMana"
        Me.boxMaxMana.Size = New System.Drawing.Size(201, 36)
        Me.boxMaxMana.TabIndex = 231
        Me.boxMaxMana.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblOf2
        '
        Me.lblOf2.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblOf2.ForeColor = System.Drawing.Color.White
        Me.lblOf2.Location = New System.Drawing.Point(366, 143)
        Me.lblOf2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOf2.Name = "lblOf2"
        Me.lblOf2.Size = New System.Drawing.Size(171, 37)
        Me.lblOf2.TabIndex = 233
        Me.lblOf2.Text = "--OUT OF--"
        Me.lblOf2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'boxMana
        '
        Me.boxMana.BackColor = System.Drawing.Color.Black
        Me.boxMana.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.boxMana.ForeColor = System.Drawing.Color.White
        Me.boxMana.Location = New System.Drawing.Point(165, 142)
        Me.boxMana.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxMana.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.boxMana.Name = "boxMana"
        Me.boxMana.Size = New System.Drawing.Size(201, 36)
        Me.boxMana.TabIndex = 230
        Me.boxMana.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMana
        '
        Me.lblMana.AutoSize = True
        Me.lblMana.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblMana.ForeColor = System.Drawing.Color.White
        Me.lblMana.Location = New System.Drawing.Point(4, 148)
        Me.lblMana.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMana.Name = "lblMana"
        Me.lblMana.Size = New System.Drawing.Size(64, 28)
        Me.lblMana.TabIndex = 227
        Me.lblMana.Text = "MANA"
        '
        'boxMaxHealth
        '
        Me.boxMaxHealth.BackColor = System.Drawing.Color.Black
        Me.boxMaxHealth.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.boxMaxHealth.ForeColor = System.Drawing.Color.White
        Me.boxMaxHealth.Location = New System.Drawing.Point(546, 97)
        Me.boxMaxHealth.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxMaxHealth.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.boxMaxHealth.Name = "boxMaxHealth"
        Me.boxMaxHealth.Size = New System.Drawing.Size(201, 36)
        Me.boxMaxHealth.TabIndex = 234
        Me.boxMaxHealth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblOf1
        '
        Me.lblOf1.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblOf1.ForeColor = System.Drawing.Color.White
        Me.lblOf1.Location = New System.Drawing.Point(366, 100)
        Me.lblOf1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOf1.Name = "lblOf1"
        Me.lblOf1.Size = New System.Drawing.Size(171, 37)
        Me.lblOf1.TabIndex = 232
        Me.lblOf1.Text = "--OUT OF--"
        Me.lblOf1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'boxHealth
        '
        Me.boxHealth.BackColor = System.Drawing.Color.Black
        Me.boxHealth.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.boxHealth.ForeColor = System.Drawing.Color.White
        Me.boxHealth.Location = New System.Drawing.Point(165, 97)
        Me.boxHealth.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxHealth.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.boxHealth.Name = "boxHealth"
        Me.boxHealth.Size = New System.Drawing.Size(201, 36)
        Me.boxHealth.TabIndex = 226
        Me.boxHealth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblHealth
        '
        Me.lblHealth.AutoSize = True
        Me.lblHealth.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblHealth.ForeColor = System.Drawing.Color.White
        Me.lblHealth.Location = New System.Drawing.Point(4, 100)
        Me.lblHealth.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblHealth.Name = "lblHealth"
        Me.lblHealth.Size = New System.Drawing.Size(90, 28)
        Me.lblHealth.TabIndex = 225
        Me.lblHealth.Text = "HEALTH"
        '
        'boxClass
        '
        Me.boxClass.BackColor = System.Drawing.Color.Black
        Me.boxClass.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.boxClass.ForeColor = System.Drawing.Color.White
        Me.boxClass.FormattingEnabled = True
        Me.boxClass.Location = New System.Drawing.Point(165, 51)
        Me.boxClass.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxClass.Name = "boxClass"
        Me.boxClass.Size = New System.Drawing.Size(199, 36)
        Me.boxClass.TabIndex = 212
        '
        'boxName
        '
        Me.boxName.BackColor = System.Drawing.Color.Black
        Me.boxName.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.boxName.ForeColor = System.Drawing.Color.White
        Me.boxName.Location = New System.Drawing.Point(165, 6)
        Me.boxName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxName.Name = "boxName"
        Me.boxName.Size = New System.Drawing.Size(199, 36)
        Me.boxName.TabIndex = 211
        '
        'lblClass
        '
        Me.lblClass.AutoSize = True
        Me.lblClass.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblClass.ForeColor = System.Drawing.Color.White
        Me.lblClass.Location = New System.Drawing.Point(4, 55)
        Me.lblClass.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblClass.Name = "lblClass"
        Me.lblClass.Size = New System.Drawing.Size(77, 28)
        Me.lblClass.TabIndex = 210
        Me.lblClass.Text = "CLASS"
        '
        'lblSex
        '
        Me.lblSex.AutoSize = True
        Me.lblSex.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblSex.ForeColor = System.Drawing.Color.White
        Me.lblSex.Location = New System.Drawing.Point(789, 351)
        Me.lblSex.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSex.Name = "lblSex"
        Me.lblSex.Size = New System.Drawing.Size(207, 28)
        Me.lblSex.TabIndex = 208
        Me.lblSex.Text = "SEX (IS FEMALE)"
        Me.lblSex.Visible = False
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblName.ForeColor = System.Drawing.Color.White
        Me.lblName.Location = New System.Drawing.Point(4, 11)
        Me.lblName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(64, 28)
        Me.lblName.TabIndex = 209
        Me.lblName.Text = "NAME"
        '
        'tabPerks
        '
        Me.tabPerks.AutoScroll = True
        Me.tabPerks.BackColor = System.Drawing.Color.Black
        Me.tabPerks.Controls.Add(Me.Panel1)
        Me.tabPerks.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.tabPerks.ForeColor = System.Drawing.Color.White
        Me.tabPerks.Location = New System.Drawing.Point(4, 32)
        Me.tabPerks.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabPerks.Name = "tabPerks"
        Me.tabPerks.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabPerks.Size = New System.Drawing.Size(1117, 850)
        Me.tabPerks.TabIndex = 4
        Me.tabPerks.Text = "PERKS"
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(862, 537)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(225, 125)
        Me.Panel1.TabIndex = 0
        '
        'tabInventory
        '
        Me.tabInventory.BackColor = System.Drawing.Color.Black
        Me.tabInventory.Controls.Add(Me.boxInventoryFilter)
        Me.tabInventory.Controls.Add(Me.boxItemsFilter)
        Me.tabInventory.Controls.Add(Me.number)
        Me.tabInventory.Controls.Add(Me.btnRemove)
        Me.tabInventory.Controls.Add(Me.boxInventory)
        Me.tabInventory.Controls.Add(Me.btnAdd)
        Me.tabInventory.Controls.Add(Me.lblInventory)
        Me.tabInventory.Controls.Add(Me.boxItems)
        Me.tabInventory.Controls.Add(Me.lblItems)
        Me.tabInventory.Location = New System.Drawing.Point(4, 32)
        Me.tabInventory.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabInventory.Name = "tabInventory"
        Me.tabInventory.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabInventory.Size = New System.Drawing.Size(1117, 850)
        Me.tabInventory.TabIndex = 2
        Me.tabInventory.Text = "INVENTORY"
        '
        'boxInventoryFilter
        '
        Me.boxInventoryFilter.BackColor = System.Drawing.Color.Black
        Me.boxInventoryFilter.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.boxInventoryFilter.ForeColor = System.Drawing.Color.White
        Me.boxInventoryFilter.Location = New System.Drawing.Point(12, 18)
        Me.boxInventoryFilter.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxInventoryFilter.Name = "boxInventoryFilter"
        Me.boxInventoryFilter.Size = New System.Drawing.Size(415, 36)
        Me.boxInventoryFilter.TabIndex = 185
        '
        'boxItemsFilter
        '
        Me.boxItemsFilter.BackColor = System.Drawing.Color.Black
        Me.boxItemsFilter.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.boxItemsFilter.ForeColor = System.Drawing.Color.White
        Me.boxItemsFilter.Location = New System.Drawing.Point(684, 18)
        Me.boxItemsFilter.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxItemsFilter.Name = "boxItemsFilter"
        Me.boxItemsFilter.Size = New System.Drawing.Size(415, 36)
        Me.boxItemsFilter.TabIndex = 184
        '
        'number
        '
        Me.number.BackColor = System.Drawing.Color.Black
        Me.number.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.number.ForeColor = System.Drawing.Color.White
        Me.number.Location = New System.Drawing.Point(490, 402)
        Me.number.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.number.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.number.Name = "number"
        Me.number.Size = New System.Drawing.Size(134, 36)
        Me.number.TabIndex = 183
        Me.number.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnRemove
        '
        Me.btnRemove.BackColor = System.Drawing.Color.Black
        Me.btnRemove.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemove.ForeColor = System.Drawing.Color.White
        Me.btnRemove.Location = New System.Drawing.Point(438, 474)
        Me.btnRemove.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(134, 55)
        Me.btnRemove.TabIndex = 182
        Me.btnRemove.Text = "Remove -->"
        Me.btnRemove.UseVisualStyleBackColor = False
        '
        'boxInventory
        '
        Me.boxInventory.BackColor = System.Drawing.Color.Black
        Me.boxInventory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.boxInventory.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.boxInventory.ForeColor = System.Drawing.Color.White
        Me.boxInventory.FormattingEnabled = True
        Me.boxInventory.ItemHeight = 22
        Me.boxInventory.Location = New System.Drawing.Point(9, 68)
        Me.boxInventory.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxInventory.Name = "boxInventory"
        Me.boxInventory.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.boxInventory.Size = New System.Drawing.Size(418, 735)
        Me.boxInventory.Sorted = True
        Me.boxInventory.TabIndex = 8
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.Black
        Me.btnAdd.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(542, 312)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(134, 55)
        Me.btnAdd.TabIndex = 181
        Me.btnAdd.Text = "<-- Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'lblInventory
        '
        Me.lblInventory.AutoSize = True
        Me.lblInventory.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblInventory.ForeColor = System.Drawing.Color.White
        Me.lblInventory.Location = New System.Drawing.Point(432, 9)
        Me.lblInventory.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInventory.Name = "lblInventory"
        Me.lblInventory.Size = New System.Drawing.Size(129, 28)
        Me.lblInventory.TabIndex = 6
        Me.lblInventory.Text = "INVENTORY"
        '
        'boxItems
        '
        Me.boxItems.BackColor = System.Drawing.Color.Black
        Me.boxItems.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.boxItems.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.boxItems.ForeColor = System.Drawing.Color.White
        Me.boxItems.FormattingEnabled = True
        Me.boxItems.ItemHeight = 22
        Me.boxItems.Location = New System.Drawing.Point(684, 68)
        Me.boxItems.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxItems.Name = "boxItems"
        Me.boxItems.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.boxItems.Size = New System.Drawing.Size(418, 735)
        Me.boxItems.TabIndex = 9
        '
        'lblItems
        '
        Me.lblItems.AutoSize = True
        Me.lblItems.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblItems.ForeColor = System.Drawing.Color.White
        Me.lblItems.Location = New System.Drawing.Point(594, 805)
        Me.lblItems.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblItems.Name = "lblItems"
        Me.lblItems.Size = New System.Drawing.Size(77, 28)
        Me.lblItems.TabIndex = 7
        Me.lblItems.Text = "ITEMS"
        '
        'tabGeneration
        '
        Me.tabGeneration.BackColor = System.Drawing.Color.Black
        Me.tabGeneration.Controls.Add(Me.boxTrapSizeDependence)
        Me.tabGeneration.Controls.Add(Me.lblTrapSizeDependence)
        Me.tabGeneration.Controls.Add(Me.boxTrapFreqMin)
        Me.tabGeneration.Controls.Add(Me.boxTrapFreqRange)
        Me.tabGeneration.Controls.Add(Me.lblTrapFreqMin)
        Me.tabGeneration.Controls.Add(Me.lblTrapFreqRange)
        Me.tabGeneration.Controls.Add(Me.divider)
        Me.tabGeneration.Controls.Add(Me.lblInfo)
        Me.tabGeneration.Controls.Add(Me.btnSaveGeneration)
        Me.tabGeneration.Controls.Add(Me.btnGenerationReset)
        Me.tabGeneration.Controls.Add(Me.boxChestRichnessRange)
        Me.tabGeneration.Controls.Add(Me.lblChestRichnessRange)
        Me.tabGeneration.Controls.Add(Me.boxChestRichnessBase)
        Me.tabGeneration.Controls.Add(Me.lblChestRichnessBase)
        Me.tabGeneration.Controls.Add(Me.boxEClockResetVal)
        Me.tabGeneration.Controls.Add(Me.lblEClockResetVal)
        Me.tabGeneration.Controls.Add(Me.boxEncounterRate)
        Me.tabGeneration.Controls.Add(Me.lblEncounterRate)
        Me.tabGeneration.Controls.Add(Me.GroupBox2)
        Me.tabGeneration.Controls.Add(Me.GroupBox1)
        Me.tabGeneration.Controls.Add(Me.separator1)
        Me.tabGeneration.Controls.Add(Me.boxChestSizeDependence)
        Me.tabGeneration.Controls.Add(Me.lblChestSize)
        Me.tabGeneration.Controls.Add(Me.boxChestFreqMin)
        Me.tabGeneration.Controls.Add(Me.lblChestFreqMin)
        Me.tabGeneration.Controls.Add(Me.boxChestFreqRange)
        Me.tabGeneration.Controls.Add(Me.lblChestFreqRange)
        Me.tabGeneration.Controls.Add(Me.boxHeight)
        Me.tabGeneration.Controls.Add(Me.boxWidth)
        Me.tabGeneration.Controls.Add(Me.lblHeight)
        Me.tabGeneration.Controls.Add(Me.lblWidth)
        Me.tabGeneration.Controls.Add(Me.lblFC)
        Me.tabGeneration.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.tabGeneration.ForeColor = System.Drawing.Color.White
        Me.tabGeneration.Location = New System.Drawing.Point(4, 32)
        Me.tabGeneration.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabGeneration.Name = "tabGeneration"
        Me.tabGeneration.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabGeneration.Size = New System.Drawing.Size(1117, 850)
        Me.tabGeneration.TabIndex = 5
        Me.tabGeneration.Text = "GENERATION"
        '
        'boxTrapSizeDependence
        '
        Me.boxTrapSizeDependence.BackColor = System.Drawing.Color.Black
        Me.boxTrapSizeDependence.ForeColor = System.Drawing.Color.White
        Me.boxTrapSizeDependence.Location = New System.Drawing.Point(832, 175)
        Me.boxTrapSizeDependence.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxTrapSizeDependence.Name = "boxTrapSizeDependence"
        Me.boxTrapSizeDependence.Size = New System.Drawing.Size(180, 36)
        Me.boxTrapSizeDependence.TabIndex = 249
        '
        'lblTrapSizeDependence
        '
        Me.lblTrapSizeDependence.AutoSize = True
        Me.lblTrapSizeDependence.Location = New System.Drawing.Point(520, 178)
        Me.lblTrapSizeDependence.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTrapSizeDependence.Name = "lblTrapSizeDependence"
        Me.lblTrapSizeDependence.Size = New System.Drawing.Size(285, 28)
        Me.lblTrapSizeDependence.TabIndex = 248
        Me.lblTrapSizeDependence.Text = "Trap Size Dependence:"
        '
        'boxTrapFreqMin
        '
        Me.boxTrapFreqMin.BackColor = System.Drawing.Color.Black
        Me.boxTrapFreqMin.ForeColor = System.Drawing.Color.White
        Me.boxTrapFreqMin.Location = New System.Drawing.Point(832, 126)
        Me.boxTrapFreqMin.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxTrapFreqMin.Name = "boxTrapFreqMin"
        Me.boxTrapFreqMin.Size = New System.Drawing.Size(180, 36)
        Me.boxTrapFreqMin.TabIndex = 247
        '
        'boxTrapFreqRange
        '
        Me.boxTrapFreqRange.BackColor = System.Drawing.Color.Black
        Me.boxTrapFreqRange.ForeColor = System.Drawing.Color.White
        Me.boxTrapFreqRange.Location = New System.Drawing.Point(832, 77)
        Me.boxTrapFreqRange.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxTrapFreqRange.Name = "boxTrapFreqRange"
        Me.boxTrapFreqRange.Size = New System.Drawing.Size(180, 36)
        Me.boxTrapFreqRange.TabIndex = 246
        '
        'lblTrapFreqMin
        '
        Me.lblTrapFreqMin.AutoSize = True
        Me.lblTrapFreqMin.Location = New System.Drawing.Point(520, 129)
        Me.lblTrapFreqMin.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTrapFreqMin.Name = "lblTrapFreqMin"
        Me.lblTrapFreqMin.Size = New System.Drawing.Size(194, 28)
        Me.lblTrapFreqMin.TabIndex = 245
        Me.lblTrapFreqMin.Text = "Trap Freq Min:"
        '
        'lblTrapFreqRange
        '
        Me.lblTrapFreqRange.AutoSize = True
        Me.lblTrapFreqRange.Location = New System.Drawing.Point(520, 80)
        Me.lblTrapFreqRange.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTrapFreqRange.Name = "lblTrapFreqRange"
        Me.lblTrapFreqRange.Size = New System.Drawing.Size(233, 28)
        Me.lblTrapFreqRange.TabIndex = 244
        Me.lblTrapFreqRange.Text = "Trap Freq Range: "
        '
        'divider
        '
        Me.divider.Location = New System.Drawing.Point(510, 80)
        Me.divider.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.divider.Multiline = True
        Me.divider.Name = "divider"
        Me.divider.Size = New System.Drawing.Size(0, 498)
        Me.divider.TabIndex = 243
        '
        'lblInfo
        '
        Me.lblInfo.Location = New System.Drawing.Point(12, 586)
        Me.lblInfo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(486, 102)
        Me.lblInfo.TabIndex = 46
        Me.lblInfo.Text = "Only changes to the section immediately above will take effect immediately before" & _
    " a floor change"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSaveGeneration
        '
        Me.btnSaveGeneration.BackColor = System.Drawing.Color.DimGray
        Me.btnSaveGeneration.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveGeneration.ForeColor = System.Drawing.Color.White
        Me.btnSaveGeneration.Location = New System.Drawing.Point(988, 783)
        Me.btnSaveGeneration.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSaveGeneration.Name = "btnSaveGeneration"
        Me.btnSaveGeneration.Size = New System.Drawing.Size(112, 48)
        Me.btnSaveGeneration.TabIndex = 45
        Me.btnSaveGeneration.Text = "SAVE"
        Me.btnSaveGeneration.UseVisualStyleBackColor = False
        '
        'btnGenerationReset
        '
        Me.btnGenerationReset.BackColor = System.Drawing.Color.DimGray
        Me.btnGenerationReset.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerationReset.ForeColor = System.Drawing.Color.White
        Me.btnGenerationReset.Location = New System.Drawing.Point(14, 783)
        Me.btnGenerationReset.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnGenerationReset.Name = "btnGenerationReset"
        Me.btnGenerationReset.Size = New System.Drawing.Size(112, 48)
        Me.btnGenerationReset.TabIndex = 44
        Me.btnGenerationReset.Text = "RESET"
        Me.btnGenerationReset.UseVisualStyleBackColor = False
        '
        'boxChestRichnessRange
        '
        Me.boxChestRichnessRange.BackColor = System.Drawing.Color.Black
        Me.boxChestRichnessRange.ForeColor = System.Drawing.Color.White
        Me.boxChestRichnessRange.Location = New System.Drawing.Point(320, 412)
        Me.boxChestRichnessRange.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxChestRichnessRange.Name = "boxChestRichnessRange"
        Me.boxChestRichnessRange.Size = New System.Drawing.Size(180, 36)
        Me.boxChestRichnessRange.TabIndex = 43
        '
        'lblChestRichnessRange
        '
        Me.lblChestRichnessRange.AutoSize = True
        Me.lblChestRichnessRange.Location = New System.Drawing.Point(8, 415)
        Me.lblChestRichnessRange.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblChestRichnessRange.Name = "lblChestRichnessRange"
        Me.lblChestRichnessRange.Size = New System.Drawing.Size(285, 28)
        Me.lblChestRichnessRange.TabIndex = 42
        Me.lblChestRichnessRange.Text = "Chest Richness Range:"
        '
        'boxChestRichnessBase
        '
        Me.boxChestRichnessBase.BackColor = System.Drawing.Color.Black
        Me.boxChestRichnessBase.ForeColor = System.Drawing.Color.White
        Me.boxChestRichnessBase.Location = New System.Drawing.Point(318, 363)
        Me.boxChestRichnessBase.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxChestRichnessBase.Name = "boxChestRichnessBase"
        Me.boxChestRichnessBase.Size = New System.Drawing.Size(180, 36)
        Me.boxChestRichnessBase.TabIndex = 41
        '
        'lblChestRichnessBase
        '
        Me.lblChestRichnessBase.AutoSize = True
        Me.lblChestRichnessBase.Location = New System.Drawing.Point(6, 366)
        Me.lblChestRichnessBase.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblChestRichnessBase.Name = "lblChestRichnessBase"
        Me.lblChestRichnessBase.Size = New System.Drawing.Size(272, 28)
        Me.lblChestRichnessBase.TabIndex = 40
        Me.lblChestRichnessBase.Text = "Chest Richness Base:"
        '
        'boxEClockResetVal
        '
        Me.boxEClockResetVal.BackColor = System.Drawing.Color.Black
        Me.boxEClockResetVal.ForeColor = System.Drawing.Color.White
        Me.boxEClockResetVal.Location = New System.Drawing.Point(320, 542)
        Me.boxEClockResetVal.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxEClockResetVal.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.boxEClockResetVal.Name = "boxEClockResetVal"
        Me.boxEClockResetVal.Size = New System.Drawing.Size(180, 36)
        Me.boxEClockResetVal.TabIndex = 39
        '
        'lblEClockResetVal
        '
        Me.lblEClockResetVal.AutoSize = True
        Me.lblEClockResetVal.Location = New System.Drawing.Point(8, 545)
        Me.lblEClockResetVal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEClockResetVal.Name = "lblEClockResetVal"
        Me.lblEClockResetVal.Size = New System.Drawing.Size(220, 28)
        Me.lblEClockResetVal.TabIndex = 38
        Me.lblEClockResetVal.Text = "Encounter Timer:"
        '
        'boxEncounterRate
        '
        Me.boxEncounterRate.BackColor = System.Drawing.Color.Black
        Me.boxEncounterRate.ForeColor = System.Drawing.Color.White
        Me.boxEncounterRate.Location = New System.Drawing.Point(320, 492)
        Me.boxEncounterRate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxEncounterRate.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.boxEncounterRate.Name = "boxEncounterRate"
        Me.boxEncounterRate.Size = New System.Drawing.Size(180, 36)
        Me.boxEncounterRate.TabIndex = 37
        '
        'lblEncounterRate
        '
        Me.lblEncounterRate.AutoSize = True
        Me.lblEncounterRate.Location = New System.Drawing.Point(8, 495)
        Me.lblEncounterRate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEncounterRate.Name = "lblEncounterRate"
        Me.lblEncounterRate.Size = New System.Drawing.Size(285, 28)
        Me.lblEncounterRate.TabIndex = 36
        Me.lblEncounterRate.Text = "Encounter Rate (.x%):"
        '
        'GroupBox2
        '
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox2.Location = New System.Drawing.Point(14, 462)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Size = New System.Drawing.Size(488, 15)
        Me.GroupBox2.TabIndex = 35
        Me.GroupBox2.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox1.Location = New System.Drawing.Point(12, 175)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(488, 15)
        Me.GroupBox1.TabIndex = 34
        Me.GroupBox1.TabStop = False
        '
        'separator1
        '
        Me.separator1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.separator1.Location = New System.Drawing.Point(12, 43)
        Me.separator1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.separator1.Name = "separator1"
        Me.separator1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.separator1.Size = New System.Drawing.Size(1088, 15)
        Me.separator1.TabIndex = 33
        Me.separator1.TabStop = False
        '
        'boxChestSizeDependence
        '
        Me.boxChestSizeDependence.BackColor = System.Drawing.Color.Black
        Me.boxChestSizeDependence.ForeColor = System.Drawing.Color.White
        Me.boxChestSizeDependence.Location = New System.Drawing.Point(318, 314)
        Me.boxChestSizeDependence.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxChestSizeDependence.Name = "boxChestSizeDependence"
        Me.boxChestSizeDependence.Size = New System.Drawing.Size(180, 36)
        Me.boxChestSizeDependence.TabIndex = 32
        '
        'lblChestSize
        '
        Me.lblChestSize.AutoSize = True
        Me.lblChestSize.Location = New System.Drawing.Point(6, 317)
        Me.lblChestSize.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblChestSize.Name = "lblChestSize"
        Me.lblChestSize.Size = New System.Drawing.Size(298, 28)
        Me.lblChestSize.TabIndex = 31
        Me.lblChestSize.Text = "Chest Size Dependence:"
        '
        'boxChestFreqMin
        '
        Me.boxChestFreqMin.BackColor = System.Drawing.Color.Black
        Me.boxChestFreqMin.ForeColor = System.Drawing.Color.White
        Me.boxChestFreqMin.Location = New System.Drawing.Point(318, 265)
        Me.boxChestFreqMin.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxChestFreqMin.Name = "boxChestFreqMin"
        Me.boxChestFreqMin.Size = New System.Drawing.Size(180, 36)
        Me.boxChestFreqMin.TabIndex = 30
        '
        'lblChestFreqMin
        '
        Me.lblChestFreqMin.AutoSize = True
        Me.lblChestFreqMin.Location = New System.Drawing.Point(6, 268)
        Me.lblChestFreqMin.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblChestFreqMin.Name = "lblChestFreqMin"
        Me.lblChestFreqMin.Size = New System.Drawing.Size(207, 28)
        Me.lblChestFreqMin.TabIndex = 29
        Me.lblChestFreqMin.Text = "Chest Freq Min:"
        '
        'boxChestFreqRange
        '
        Me.boxChestFreqRange.BackColor = System.Drawing.Color.Black
        Me.boxChestFreqRange.ForeColor = System.Drawing.Color.White
        Me.boxChestFreqRange.Location = New System.Drawing.Point(318, 215)
        Me.boxChestFreqRange.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxChestFreqRange.Name = "boxChestFreqRange"
        Me.boxChestFreqRange.Size = New System.Drawing.Size(180, 36)
        Me.boxChestFreqRange.TabIndex = 28
        '
        'lblChestFreqRange
        '
        Me.lblChestFreqRange.AutoSize = True
        Me.lblChestFreqRange.Location = New System.Drawing.Point(6, 218)
        Me.lblChestFreqRange.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblChestFreqRange.Name = "lblChestFreqRange"
        Me.lblChestFreqRange.Size = New System.Drawing.Size(233, 28)
        Me.lblChestFreqRange.TabIndex = 27
        Me.lblChestFreqRange.Text = "Chest Freq Range:"
        '
        'boxHeight
        '
        Me.boxHeight.BackColor = System.Drawing.Color.Black
        Me.boxHeight.ForeColor = System.Drawing.Color.White
        Me.boxHeight.Location = New System.Drawing.Point(318, 126)
        Me.boxHeight.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxHeight.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.boxHeight.Name = "boxHeight"
        Me.boxHeight.Size = New System.Drawing.Size(180, 36)
        Me.boxHeight.TabIndex = 26
        '
        'boxWidth
        '
        Me.boxWidth.BackColor = System.Drawing.Color.Black
        Me.boxWidth.ForeColor = System.Drawing.Color.White
        Me.boxWidth.Location = New System.Drawing.Point(318, 77)
        Me.boxWidth.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxWidth.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.boxWidth.Name = "boxWidth"
        Me.boxWidth.Size = New System.Drawing.Size(180, 36)
        Me.boxWidth.TabIndex = 25
        '
        'lblHeight
        '
        Me.lblHeight.AutoSize = True
        Me.lblHeight.Location = New System.Drawing.Point(6, 129)
        Me.lblHeight.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblHeight.Name = "lblHeight"
        Me.lblHeight.Size = New System.Drawing.Size(194, 28)
        Me.lblHeight.TabIndex = 24
        Me.lblHeight.Text = "Board Height: "
        '
        'lblWidth
        '
        Me.lblWidth.AutoSize = True
        Me.lblWidth.Location = New System.Drawing.Point(6, 80)
        Me.lblWidth.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblWidth.Name = "lblWidth"
        Me.lblWidth.Size = New System.Drawing.Size(181, 28)
        Me.lblWidth.TabIndex = 23
        Me.lblWidth.Text = "Board Width: "
        '
        'lblFC
        '
        Me.lblFC.AutoSize = True
        Me.lblFC.Location = New System.Drawing.Point(6, 9)
        Me.lblFC.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFC.Name = "lblFC"
        Me.lblFC.Size = New System.Drawing.Size(155, 28)
        Me.lblFC.TabIndex = 22
        Me.lblFC.Text = "FloorCode: "
        '
        'Debug_Window
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1125, 886)
        Me.Controls.Add(Me.tabMain)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Debug_Window"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Debug Window"
        Me.tabMain.ResumeLayout(False)
        Me.tabInformation.ResumeLayout(False)
        Me.tabGeneral.ResumeLayout(False)
        Me.groupNotes.ResumeLayout(False)
        CType(Me.boxMap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupGeneral.ResumeLayout(False)
        Me.groupGeneral.PerformLayout()
        Me.boxMapControls.ResumeLayout(False)
        Me.boxMapControls.PerformLayout()
        CType(Me.boxZoom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxTurn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxFloor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPlayer.ResumeLayout(False)
        Me.tabPlayer.PerformLayout()
        CType(Me.boxAlpha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPortrait.ResumeLayout(False)
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxEvd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxSpd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxWil, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxDef, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxAtk, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxGold, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxStamina, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxMaxMana, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxMana, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxMaxHealth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxHealth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPerks.ResumeLayout(False)
        Me.tabInventory.ResumeLayout(False)
        Me.tabInventory.PerformLayout()
        CType(Me.number, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabGeneration.ResumeLayout(False)
        Me.tabGeneration.PerformLayout()
        CType(Me.boxTrapSizeDependence, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxTrapFreqMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxTrapFreqRange, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxChestRichnessRange, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxChestRichnessBase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxEClockResetVal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxEncounterRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxChestSizeDependence, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxChestFreqMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxChestFreqRange, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabMain As TabControl
    Friend WithEvents tabGeneral As TabPage
    Friend WithEvents tabPlayer As TabPage
    Friend WithEvents tabInventory As TabPage
    Friend WithEvents number As NumericUpDown
    Friend WithEvents btnRemove As Button
    Friend WithEvents boxInventory As ListBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents lblInventory As Label
    Friend WithEvents boxItems As ListBox
    Friend WithEvents lblItems As Label
    Friend WithEvents picPreview As PictureBox
    Friend WithEvents playerDivider As TextBox
    Friend WithEvents lblGold As Label
    Friend WithEvents boxEvd As NumericUpDown
    Friend WithEvents lblEvd As Label
    Friend WithEvents boxSpd As NumericUpDown
    Friend WithEvents lblSpd As Label
    Friend WithEvents boxWil As NumericUpDown
    Friend WithEvents lblWil As Label
    Friend WithEvents boxDef As NumericUpDown
    Friend WithEvents lblDef As Label
    Friend WithEvents boxAtk As NumericUpDown
    Friend WithEvents lblAtk As Label
    Friend WithEvents boxGold As NumericUpDown
    Friend WithEvents boxStamina As NumericUpDown
    Friend WithEvents lblstamina As Label
    Friend WithEvents boxMaxMana As NumericUpDown
    Friend WithEvents lblOf2 As Label
    Friend WithEvents boxMana As NumericUpDown
    Friend WithEvents lblMana As Label
    Friend WithEvents boxMaxHealth As NumericUpDown
    Friend WithEvents lblOf1 As Label
    Friend WithEvents boxHealth As NumericUpDown
    Friend WithEvents lblHealth As Label
    Friend WithEvents boxClass As ComboBox
    Friend WithEvents boxName As TextBox
    Friend WithEvents lblClass As Label
    Friend WithEvents lblSex As Label
    Friend WithEvents lblName As Label
    Friend WithEvents tabPortrait As TabControl
    Friend WithEvents tabPageBackground As TabPage
    Friend WithEvents tabPageRearHair As TabPage
    Friend WithEvents tabPageBody As TabPage
    Friend WithEvents tabPageClothing As TabPage
    Friend WithEvents tabPageFace As TabPage
    Friend WithEvents tabPageMiddleHair As TabPage
    Friend WithEvents tabPageEars As TabPage
    Friend WithEvents tabPageNose As TabPage
    Friend WithEvents tabPageMouth As TabPage
    Friend WithEvents tabPageEyes As TabPage
    Friend WithEvents tabPageEyebrows As TabPage
    Friend WithEvents tabPageFaceMark As TabPage
    Friend WithEvents tabPageGlasses As TabPage
    Friend WithEvents tabPageCloak As TabPage
    Friend WithEvents tabPageAccessories As TabPage
    Friend WithEvents tabPageFrontHair As TabPage
    Friend WithEvents tabPageHat As TabPage
    Friend WithEvents groupGeneral As GroupBox
    Friend WithEvents boxTurn As NumericUpDown
    Friend WithEvents boxFloor As NumericUpDown
    Friend WithEvents lblTurn As Label
    Friend WithEvents lblFloor As Label
    Friend WithEvents lblHC As Label
    Friend WithEvents pnlHC As Panel
    Friend WithEvents lblSC As Label
    Friend WithEvents pnlSC As Panel
    Friend WithEvents groupNotes As GroupBox
    Friend WithEvents tabInformation As TabPage
    Friend WithEvents boxNotes As RichTextBox
    Friend WithEvents lblUnseen As Label
    Friend WithEvents lblSeen As Label
    Friend WithEvents lblKeyHeader As Label
    Friend WithEvents lblPlayer As Label
    Friend WithEvents lblStairs As Label
    Friend WithEvents lblChest As Label
    Friend WithEvents lblNPC As Label
    Friend WithEvents lblStatue As Label
    Friend WithEvents boxMap As PictureBox
    Friend WithEvents boxMapControls As GroupBox
    Friend WithEvents btnPan As RadioButton
    Friend WithEvents btnSelect As RadioButton
    Friend WithEvents boxZoom As NumericUpDown
    Friend WithEvents lblZoom As Label
    Friend WithEvents btnEditSelection As Button
    Friend WithEvents lblSelected As Label
    Friend WithEvents boxBeaten As CheckBox
    Friend WithEvents lblTrap As Label
    Friend WithEvents boxItemsFilter As TextBox
    Friend WithEvents boxInventoryFilter As TextBox
    Friend WithEvents boxAlpha As NumericUpDown
    Friend WithEvents lblAlpha As Label
    Friend WithEvents tabPerks As TabPage
    Friend WithEvents tabGeneration As TabPage
    Friend WithEvents boxChestRichnessRange As NumericUpDown
    Friend WithEvents lblChestRichnessRange As Label
    Friend WithEvents boxChestRichnessBase As NumericUpDown
    Friend WithEvents lblChestRichnessBase As Label
    Friend WithEvents boxEClockResetVal As NumericUpDown
    Friend WithEvents lblEClockResetVal As Label
    Friend WithEvents boxEncounterRate As NumericUpDown
    Friend WithEvents lblEncounterRate As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents separator1 As GroupBox
    Friend WithEvents boxChestSizeDependence As NumericUpDown
    Friend WithEvents lblChestSize As Label
    Friend WithEvents boxChestFreqMin As NumericUpDown
    Friend WithEvents lblChestFreqMin As Label
    Friend WithEvents boxChestFreqRange As NumericUpDown
    Friend WithEvents lblChestFreqRange As Label
    Friend WithEvents boxHeight As NumericUpDown
    Friend WithEvents boxWidth As NumericUpDown
    Friend WithEvents lblHeight As Label
    Friend WithEvents lblWidth As Label
    Friend WithEvents lblFC As Label
    Friend WithEvents btnGenerationReset As Button
    Friend WithEvents btnSaveGeneration As Button
    Friend WithEvents lblInfo As Label
    Friend WithEvents boxTrapSizeDependence As NumericUpDown
    Friend WithEvents lblTrapSizeDependence As Label
    Friend WithEvents boxTrapFreqMin As NumericUpDown
    Friend WithEvents boxTrapFreqRange As NumericUpDown
    Friend WithEvents lblTrapFreqMin As Label
    Friend WithEvents lblTrapFreqRange As Label
    Friend WithEvents divider As TextBox
    Friend WithEvents boxSex As CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tabPageTail As System.Windows.Forms.TabPage
    Friend WithEvents tabPageWings As System.Windows.Forms.TabPage
    Friend WithEvents tabPageHairAcc As System.Windows.Forms.TabPage
    Friend WithEvents tabPageShoulders As System.Windows.Forms.TabPage
    Friend WithEvents tabBodyOverlay As System.Windows.Forms.TabPage
    Friend WithEvents tabPageGen As System.Windows.Forms.TabPage
    Friend WithEvents tabPageChest As System.Windows.Forms.TabPage
    Friend WithEvents tabPageClothesBtm As System.Windows.Forms.TabPage
    Friend WithEvents tabPageHorns As System.Windows.Forms.TabPage
    Friend WithEvents tabPageBlush As System.Windows.Forms.TabPage
    Friend WithEvents lblBarrier As System.Windows.Forms.Label
    Friend WithEvents boxForm As System.Windows.Forms.ComboBox
    Friend WithEvents lblForm As System.Windows.Forms.Label
End Class
