<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GeneratorSettings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
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
        Me.lblFC = New System.Windows.Forms.Label()
        Me.lblWidth = New System.Windows.Forms.Label()
        Me.lblHeight = New System.Windows.Forms.Label()
        Me.boxWidth = New System.Windows.Forms.NumericUpDown()
        Me.boxHeight = New System.Windows.Forms.NumericUpDown()
        Me.boxChestFreqRange = New System.Windows.Forms.NumericUpDown()
        Me.lblChestFreqRange = New System.Windows.Forms.Label()
        Me.boxChestFreqMin = New System.Windows.Forms.NumericUpDown()
        Me.lblChestFreqMin = New System.Windows.Forms.Label()
        Me.boxChestSizeDependence = New System.Windows.Forms.NumericUpDown()
        Me.lblChestSize = New System.Windows.Forms.Label()
        Me.separator1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.boxEncounterRate = New System.Windows.Forms.NumericUpDown()
        Me.lblEncounterRate = New System.Windows.Forms.Label()
        Me.boxEClockResetVal = New System.Windows.Forms.NumericUpDown()
        Me.lblEClockResetVal = New System.Windows.Forms.Label()
        Me.boxChestRichnessBase = New System.Windows.Forms.NumericUpDown()
        Me.lblChestRichnessBase = New System.Windows.Forms.Label()
        Me.boxChestRichnessRange = New System.Windows.Forms.NumericUpDown()
        Me.lblChestRichnessRange = New System.Windows.Forms.Label()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.divider = New System.Windows.Forms.TextBox()
        Me.boxTrapFreqMin = New System.Windows.Forms.NumericUpDown()
        Me.boxTrapFreqRange = New System.Windows.Forms.NumericUpDown()
        Me.lblTrapFreqMin = New System.Windows.Forms.Label()
        Me.lblTrapFreqRange = New System.Windows.Forms.Label()
        Me.boxTrapSizeDependence = New System.Windows.Forms.NumericUpDown()
        Me.lblTrapSizeDependence = New System.Windows.Forms.Label()
        Me.txtSeed = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cBoxPresets = New System.Windows.Forms.ComboBox()
        Me.lblFS = New System.Windows.Forms.Label()
        Me.chkSavePreset = New System.Windows.Forms.CheckBox()
        CType(Me.boxWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxChestFreqRange, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxChestFreqMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxChestSizeDependence, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxEncounterRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxEClockResetVal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxChestRichnessBase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxChestRichnessRange, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxTrapFreqMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxTrapFreqRange, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxTrapSizeDependence, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblFC
        '
        Me.lblFC.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFC.Location = New System.Drawing.Point(9, 6)
        Me.lblFC.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblFC.Name = "lblFC"
        Me.lblFC.Size = New System.Drawing.Size(90, 17)
        Me.lblFC.TabIndex = 0
        Me.lblFC.Text = "FloorCode: "
        Me.lblFC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWidth
        '
        Me.lblWidth.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWidth.Location = New System.Drawing.Point(9, 41)
        Me.lblWidth.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblWidth.Name = "lblWidth"
        Me.lblWidth.Size = New System.Drawing.Size(180, 17)
        Me.lblWidth.TabIndex = 1
        Me.lblWidth.Text = "Board Width: "
        Me.lblWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblHeight
        '
        Me.lblHeight.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeight.Location = New System.Drawing.Point(9, 64)
        Me.lblHeight.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblHeight.Name = "lblHeight"
        Me.lblHeight.Size = New System.Drawing.Size(180, 17)
        Me.lblHeight.TabIndex = 2
        Me.lblHeight.Text = "Board Height: "
        Me.lblHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'boxWidth
        '
        Me.boxWidth.AutoSize = True
        Me.boxWidth.BackColor = System.Drawing.Color.Black
        Me.boxWidth.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.boxWidth.ForeColor = System.Drawing.Color.White
        Me.boxWidth.Location = New System.Drawing.Point(197, 39)
        Me.boxWidth.Margin = New System.Windows.Forms.Padding(2)
        Me.boxWidth.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.boxWidth.Minimum = New Decimal(New Integer() {15, 0, 0, 0})
        Me.boxWidth.Name = "boxWidth"
        Me.boxWidth.Size = New System.Drawing.Size(87, 23)
        Me.boxWidth.TabIndex = 3
        Me.boxWidth.Value = New Decimal(New Integer() {15, 0, 0, 0})
        '
        'boxHeight
        '
        Me.boxHeight.AutoSize = True
        Me.boxHeight.BackColor = System.Drawing.Color.Black
        Me.boxHeight.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.boxHeight.ForeColor = System.Drawing.Color.White
        Me.boxHeight.Location = New System.Drawing.Point(197, 63)
        Me.boxHeight.Margin = New System.Windows.Forms.Padding(2)
        Me.boxHeight.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.boxHeight.Minimum = New Decimal(New Integer() {15, 0, 0, 0})
        Me.boxHeight.Name = "boxHeight"
        Me.boxHeight.Size = New System.Drawing.Size(87, 23)
        Me.boxHeight.TabIndex = 4
        Me.boxHeight.Value = New Decimal(New Integer() {15, 0, 0, 0})
        '
        'boxChestFreqRange
        '
        Me.boxChestFreqRange.AutoSize = True
        Me.boxChestFreqRange.BackColor = System.Drawing.Color.Black
        Me.boxChestFreqRange.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.boxChestFreqRange.ForeColor = System.Drawing.Color.White
        Me.boxChestFreqRange.Location = New System.Drawing.Point(197, 106)
        Me.boxChestFreqRange.Margin = New System.Windows.Forms.Padding(2)
        Me.boxChestFreqRange.Name = "boxChestFreqRange"
        Me.boxChestFreqRange.Size = New System.Drawing.Size(87, 23)
        Me.boxChestFreqRange.TabIndex = 6
        '
        'lblChestFreqRange
        '
        Me.lblChestFreqRange.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChestFreqRange.Location = New System.Drawing.Point(9, 108)
        Me.lblChestFreqRange.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblChestFreqRange.Name = "lblChestFreqRange"
        Me.lblChestFreqRange.Size = New System.Drawing.Size(185, 17)
        Me.lblChestFreqRange.TabIndex = 5
        Me.lblChestFreqRange.Text = "Chest Freq Range:"
        Me.lblChestFreqRange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'boxChestFreqMin
        '
        Me.boxChestFreqMin.AutoSize = True
        Me.boxChestFreqMin.BackColor = System.Drawing.Color.Black
        Me.boxChestFreqMin.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.boxChestFreqMin.ForeColor = System.Drawing.Color.White
        Me.boxChestFreqMin.Location = New System.Drawing.Point(197, 130)
        Me.boxChestFreqMin.Margin = New System.Windows.Forms.Padding(2)
        Me.boxChestFreqMin.Name = "boxChestFreqMin"
        Me.boxChestFreqMin.Size = New System.Drawing.Size(87, 23)
        Me.boxChestFreqMin.TabIndex = 8
        '
        'lblChestFreqMin
        '
        Me.lblChestFreqMin.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChestFreqMin.Location = New System.Drawing.Point(9, 131)
        Me.lblChestFreqMin.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblChestFreqMin.Name = "lblChestFreqMin"
        Me.lblChestFreqMin.Size = New System.Drawing.Size(185, 17)
        Me.lblChestFreqMin.TabIndex = 7
        Me.lblChestFreqMin.Text = "Chest Freq Min:"
        Me.lblChestFreqMin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'boxChestSizeDependence
        '
        Me.boxChestSizeDependence.AutoSize = True
        Me.boxChestSizeDependence.BackColor = System.Drawing.Color.Black
        Me.boxChestSizeDependence.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.boxChestSizeDependence.ForeColor = System.Drawing.Color.White
        Me.boxChestSizeDependence.Location = New System.Drawing.Point(197, 153)
        Me.boxChestSizeDependence.Margin = New System.Windows.Forms.Padding(2)
        Me.boxChestSizeDependence.Minimum = New Decimal(New Integer() {15, 0, 0, 0})
        Me.boxChestSizeDependence.Name = "boxChestSizeDependence"
        Me.boxChestSizeDependence.Size = New System.Drawing.Size(87, 23)
        Me.boxChestSizeDependence.TabIndex = 10
        Me.boxChestSizeDependence.Value = New Decimal(New Integer() {15, 0, 0, 0})
        '
        'lblChestSize
        '
        Me.lblChestSize.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChestSize.Location = New System.Drawing.Point(9, 155)
        Me.lblChestSize.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblChestSize.Name = "lblChestSize"
        Me.lblChestSize.Size = New System.Drawing.Size(185, 17)
        Me.lblChestSize.TabIndex = 9
        Me.lblChestSize.Text = "Chest Size Dependence:"
        Me.lblChestSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'separator1
        '
        Me.separator1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.separator1.Location = New System.Drawing.Point(12, 23)
        Me.separator1.Margin = New System.Windows.Forms.Padding(2)
        Me.separator1.Name = "separator1"
        Me.separator1.Padding = New System.Windows.Forms.Padding(2)
        Me.separator1.Size = New System.Drawing.Size(546, 7)
        Me.separator1.TabIndex = 11
        Me.separator1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox1.Location = New System.Drawing.Point(12, 96)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(273, 1)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'boxEncounterRate
        '
        Me.boxEncounterRate.AutoSize = True
        Me.boxEncounterRate.BackColor = System.Drawing.Color.Black
        Me.boxEncounterRate.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.boxEncounterRate.ForeColor = System.Drawing.Color.White
        Me.boxEncounterRate.Location = New System.Drawing.Point(197, 239)
        Me.boxEncounterRate.Margin = New System.Windows.Forms.Padding(2)
        Me.boxEncounterRate.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.boxEncounterRate.Name = "boxEncounterRate"
        Me.boxEncounterRate.Size = New System.Drawing.Size(87, 23)
        Me.boxEncounterRate.TabIndex = 15
        '
        'lblEncounterRate
        '
        Me.lblEncounterRate.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncounterRate.Location = New System.Drawing.Point(9, 241)
        Me.lblEncounterRate.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblEncounterRate.Name = "lblEncounterRate"
        Me.lblEncounterRate.Size = New System.Drawing.Size(180, 17)
        Me.lblEncounterRate.TabIndex = 14
        Me.lblEncounterRate.Text = "Encounter Rate (.x%):"
        Me.lblEncounterRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'boxEClockResetVal
        '
        Me.boxEClockResetVal.AutoSize = True
        Me.boxEClockResetVal.BackColor = System.Drawing.Color.Black
        Me.boxEClockResetVal.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.boxEClockResetVal.ForeColor = System.Drawing.Color.White
        Me.boxEClockResetVal.Location = New System.Drawing.Point(197, 263)
        Me.boxEClockResetVal.Margin = New System.Windows.Forms.Padding(2)
        Me.boxEClockResetVal.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.boxEClockResetVal.Name = "boxEClockResetVal"
        Me.boxEClockResetVal.Size = New System.Drawing.Size(87, 23)
        Me.boxEClockResetVal.TabIndex = 17
        '
        'lblEClockResetVal
        '
        Me.lblEClockResetVal.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEClockResetVal.Location = New System.Drawing.Point(9, 264)
        Me.lblEClockResetVal.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblEClockResetVal.Name = "lblEClockResetVal"
        Me.lblEClockResetVal.Size = New System.Drawing.Size(180, 17)
        Me.lblEClockResetVal.TabIndex = 16
        Me.lblEClockResetVal.Text = "Encounter Timer:"
        Me.lblEClockResetVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'boxChestRichnessBase
        '
        Me.boxChestRichnessBase.AutoSize = True
        Me.boxChestRichnessBase.BackColor = System.Drawing.Color.Black
        Me.boxChestRichnessBase.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.boxChestRichnessBase.ForeColor = System.Drawing.Color.White
        Me.boxChestRichnessBase.Location = New System.Drawing.Point(197, 178)
        Me.boxChestRichnessBase.Margin = New System.Windows.Forms.Padding(2)
        Me.boxChestRichnessBase.Name = "boxChestRichnessBase"
        Me.boxChestRichnessBase.Size = New System.Drawing.Size(87, 23)
        Me.boxChestRichnessBase.TabIndex = 19
        '
        'lblChestRichnessBase
        '
        Me.lblChestRichnessBase.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChestRichnessBase.Location = New System.Drawing.Point(9, 178)
        Me.lblChestRichnessBase.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblChestRichnessBase.Name = "lblChestRichnessBase"
        Me.lblChestRichnessBase.Size = New System.Drawing.Size(185, 17)
        Me.lblChestRichnessBase.TabIndex = 18
        Me.lblChestRichnessBase.Text = "Chest Richness Base:"
        Me.lblChestRichnessBase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'boxChestRichnessRange
        '
        Me.boxChestRichnessRange.AutoSize = True
        Me.boxChestRichnessRange.BackColor = System.Drawing.Color.Black
        Me.boxChestRichnessRange.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.boxChestRichnessRange.ForeColor = System.Drawing.Color.White
        Me.boxChestRichnessRange.Location = New System.Drawing.Point(197, 201)
        Me.boxChestRichnessRange.Margin = New System.Windows.Forms.Padding(2)
        Me.boxChestRichnessRange.Name = "boxChestRichnessRange"
        Me.boxChestRichnessRange.Size = New System.Drawing.Size(87, 23)
        Me.boxChestRichnessRange.TabIndex = 21
        '
        'lblChestRichnessRange
        '
        Me.lblChestRichnessRange.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChestRichnessRange.Location = New System.Drawing.Point(9, 202)
        Me.lblChestRichnessRange.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblChestRichnessRange.Name = "lblChestRichnessRange"
        Me.lblChestRichnessRange.Size = New System.Drawing.Size(185, 17)
        Me.lblChestRichnessRange.TabIndex = 20
        Me.lblChestRichnessRange.Text = "Chest Richness Range:"
        Me.lblChestRichnessRange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnReset
        '
        Me.btnReset.BackColor = System.Drawing.Color.DimGray
        Me.btnReset.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.ForeColor = System.Drawing.Color.White
        Me.btnReset.Location = New System.Drawing.Point(9, 310)
        Me.btnReset.Margin = New System.Windows.Forms.Padding(2)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(54, 25)
        Me.btnReset.TabIndex = 22
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = False
        '
        'btnConfirm
        '
        Me.btnConfirm.BackColor = System.Drawing.Color.DimGray
        Me.btnConfirm.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirm.ForeColor = System.Drawing.Color.White
        Me.btnConfirm.Location = New System.Drawing.Point(493, 310)
        Me.btnConfirm.Margin = New System.Windows.Forms.Padding(2)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(67, 25)
        Me.btnConfirm.TabIndex = 23
        Me.btnConfirm.Text = "Confirm"
        Me.btnConfirm.UseVisualStyleBackColor = False
        '
        'divider
        '
        Me.divider.Location = New System.Drawing.Point(292, 46)
        Me.divider.Margin = New System.Windows.Forms.Padding(2)
        Me.divider.Multiline = True
        Me.divider.Name = "divider"
        Me.divider.Size = New System.Drawing.Size(2, 242)
        Me.divider.TabIndex = 236
        '
        'boxTrapFreqMin
        '
        Me.boxTrapFreqMin.AutoSize = True
        Me.boxTrapFreqMin.BackColor = System.Drawing.Color.Black
        Me.boxTrapFreqMin.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.boxTrapFreqMin.ForeColor = System.Drawing.Color.White
        Me.boxTrapFreqMin.Location = New System.Drawing.Point(475, 63)
        Me.boxTrapFreqMin.Margin = New System.Windows.Forms.Padding(2)
        Me.boxTrapFreqMin.Name = "boxTrapFreqMin"
        Me.boxTrapFreqMin.Size = New System.Drawing.Size(87, 23)
        Me.boxTrapFreqMin.TabIndex = 240
        '
        'boxTrapFreqRange
        '
        Me.boxTrapFreqRange.AutoSize = True
        Me.boxTrapFreqRange.BackColor = System.Drawing.Color.Black
        Me.boxTrapFreqRange.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.boxTrapFreqRange.ForeColor = System.Drawing.Color.White
        Me.boxTrapFreqRange.Location = New System.Drawing.Point(475, 39)
        Me.boxTrapFreqRange.Margin = New System.Windows.Forms.Padding(2)
        Me.boxTrapFreqRange.Name = "boxTrapFreqRange"
        Me.boxTrapFreqRange.Size = New System.Drawing.Size(87, 23)
        Me.boxTrapFreqRange.TabIndex = 239
        '
        'lblTrapFreqMin
        '
        Me.lblTrapFreqMin.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTrapFreqMin.Location = New System.Drawing.Point(298, 64)
        Me.lblTrapFreqMin.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTrapFreqMin.Name = "lblTrapFreqMin"
        Me.lblTrapFreqMin.Size = New System.Drawing.Size(176, 17)
        Me.lblTrapFreqMin.TabIndex = 238
        Me.lblTrapFreqMin.Text = "Trap Freq Min:"
        Me.lblTrapFreqMin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTrapFreqRange
        '
        Me.lblTrapFreqRange.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTrapFreqRange.Location = New System.Drawing.Point(298, 41)
        Me.lblTrapFreqRange.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTrapFreqRange.Name = "lblTrapFreqRange"
        Me.lblTrapFreqRange.Size = New System.Drawing.Size(176, 17)
        Me.lblTrapFreqRange.TabIndex = 237
        Me.lblTrapFreqRange.Text = "Trap Freq Range: "
        Me.lblTrapFreqRange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'boxTrapSizeDependence
        '
        Me.boxTrapSizeDependence.AutoSize = True
        Me.boxTrapSizeDependence.BackColor = System.Drawing.Color.Black
        Me.boxTrapSizeDependence.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.boxTrapSizeDependence.ForeColor = System.Drawing.Color.White
        Me.boxTrapSizeDependence.Location = New System.Drawing.Point(475, 87)
        Me.boxTrapSizeDependence.Margin = New System.Windows.Forms.Padding(2)
        Me.boxTrapSizeDependence.Minimum = New Decimal(New Integer() {15, 0, 0, 0})
        Me.boxTrapSizeDependence.Name = "boxTrapSizeDependence"
        Me.boxTrapSizeDependence.Size = New System.Drawing.Size(87, 23)
        Me.boxTrapSizeDependence.TabIndex = 242
        Me.boxTrapSizeDependence.Value = New Decimal(New Integer() {15, 0, 0, 0})
        '
        'lblTrapSizeDependence
        '
        Me.lblTrapSizeDependence.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTrapSizeDependence.Location = New System.Drawing.Point(298, 88)
        Me.lblTrapSizeDependence.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTrapSizeDependence.Name = "lblTrapSizeDependence"
        Me.lblTrapSizeDependence.Size = New System.Drawing.Size(176, 17)
        Me.lblTrapSizeDependence.TabIndex = 241
        Me.lblTrapSizeDependence.Text = "Trap Size Dependence:"
        Me.lblTrapSizeDependence.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSeed
        '
        Me.txtSeed.BackColor = System.Drawing.Color.Black
        Me.txtSeed.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSeed.ForeColor = System.Drawing.Color.White
        Me.txtSeed.Location = New System.Drawing.Point(96, 5)
        Me.txtSeed.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSeed.Name = "txtSeed"
        Me.txtSeed.Size = New System.Drawing.Size(155, 23)
        Me.txtSeed.TabIndex = 243
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox2.Location = New System.Drawing.Point(13, 231)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(273, 1)
        Me.GroupBox2.TabIndex = 244
        Me.GroupBox2.TabStop = False
        '
        'cBoxPresets
        '
        Me.cBoxPresets.BackColor = System.Drawing.Color.Black
        Me.cBoxPresets.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cBoxPresets.ForeColor = System.Drawing.Color.White
        Me.cBoxPresets.FormattingEnabled = True
        Me.cBoxPresets.Items.AddRange(New Object() {"--- (none) ---"})
        Me.cBoxPresets.Location = New System.Drawing.Point(366, 3)
        Me.cBoxPresets.Name = "cBoxPresets"
        Me.cBoxPresets.Size = New System.Drawing.Size(196, 25)
        Me.cBoxPresets.TabIndex = 245
        Me.cBoxPresets.Text = "--- (none) ---"
        '
        'lblFS
        '
        Me.lblFS.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFS.Location = New System.Drawing.Point(300, 6)
        Me.lblFS.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblFS.Name = "lblFS"
        Me.lblFS.Size = New System.Drawing.Size(65, 17)
        Me.lblFS.TabIndex = 246
        Me.lblFS.Text = "Preset:"
        Me.lblFS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkSavePreset
        '
        Me.chkSavePreset.BackColor = System.Drawing.Color.Black
        Me.chkSavePreset.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSavePreset.ForeColor = System.Drawing.Color.White
        Me.chkSavePreset.Location = New System.Drawing.Point(349, 311)
        Me.chkSavePreset.Name = "chkSavePreset"
        Me.chkSavePreset.Size = New System.Drawing.Size(140, 23)
        Me.chkSavePreset.TabIndex = 247
        Me.chkSavePreset.Text = "Save As Preset"
        Me.chkSavePreset.UseVisualStyleBackColor = False
        '
        'GeneratorSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(568, 341)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkSavePreset)
        Me.Controls.Add(Me.cBoxPresets)
        Me.Controls.Add(Me.txtSeed)
        Me.Controls.Add(Me.boxTrapSizeDependence)
        Me.Controls.Add(Me.lblTrapSizeDependence)
        Me.Controls.Add(Me.boxTrapFreqMin)
        Me.Controls.Add(Me.boxTrapFreqRange)
        Me.Controls.Add(Me.lblTrapFreqMin)
        Me.Controls.Add(Me.lblTrapFreqRange)
        Me.Controls.Add(Me.divider)
        Me.Controls.Add(Me.btnConfirm)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.boxChestRichnessRange)
        Me.Controls.Add(Me.lblChestRichnessRange)
        Me.Controls.Add(Me.boxChestRichnessBase)
        Me.Controls.Add(Me.lblChestRichnessBase)
        Me.Controls.Add(Me.boxEClockResetVal)
        Me.Controls.Add(Me.lblEClockResetVal)
        Me.Controls.Add(Me.boxEncounterRate)
        Me.Controls.Add(Me.lblEncounterRate)
        Me.Controls.Add(Me.separator1)
        Me.Controls.Add(Me.boxChestSizeDependence)
        Me.Controls.Add(Me.lblChestSize)
        Me.Controls.Add(Me.boxChestFreqMin)
        Me.Controls.Add(Me.lblChestFreqMin)
        Me.Controls.Add(Me.boxChestFreqRange)
        Me.Controls.Add(Me.lblChestFreqRange)
        Me.Controls.Add(Me.boxHeight)
        Me.Controls.Add(Me.boxWidth)
        Me.Controls.Add(Me.lblHeight)
        Me.Controls.Add(Me.lblWidth)
        Me.Controls.Add(Me.lblFC)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblFS)
        Me.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "GeneratorSettings"
        Me.Text = " "
        CType(Me.boxWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxChestFreqRange, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxChestFreqMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxChestSizeDependence, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxEncounterRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxEClockResetVal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxChestRichnessBase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxChestRichnessRange, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxTrapFreqMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxTrapFreqRange, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxTrapSizeDependence, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblFC As Label
    Friend WithEvents lblWidth As Label
    Friend WithEvents lblHeight As Label
    Friend WithEvents boxWidth As NumericUpDown
    Friend WithEvents boxHeight As NumericUpDown
    Friend WithEvents boxChestFreqRange As NumericUpDown
    Friend WithEvents lblChestFreqRange As Label
    Friend WithEvents boxChestFreqMin As NumericUpDown
    Friend WithEvents lblChestFreqMin As Label
    Friend WithEvents boxChestSizeDependence As NumericUpDown
    Friend WithEvents lblChestSize As Label
    Friend WithEvents separator1 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents boxEncounterRate As NumericUpDown
    Friend WithEvents lblEncounterRate As Label
    Friend WithEvents boxEClockResetVal As NumericUpDown
    Friend WithEvents lblEClockResetVal As Label
    Friend WithEvents boxChestRichnessBase As NumericUpDown
    Friend WithEvents lblChestRichnessBase As Label
    Friend WithEvents boxChestRichnessRange As NumericUpDown
    Friend WithEvents lblChestRichnessRange As Label
    Friend WithEvents btnReset As Button
    Friend WithEvents btnConfirm As Button
    Friend WithEvents divider As TextBox
    Friend WithEvents boxTrapFreqMin As NumericUpDown
    Friend WithEvents boxTrapFreqRange As NumericUpDown
    Friend WithEvents lblTrapFreqMin As Label
    Friend WithEvents lblTrapFreqRange As Label
    Friend WithEvents boxTrapSizeDependence As NumericUpDown
    Friend WithEvents lblTrapSizeDependence As Label
    Friend WithEvents txtSeed As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cBoxPresets As System.Windows.Forms.ComboBox
    Friend WithEvents lblFS As System.Windows.Forms.Label
    Friend WithEvents chkSavePreset As System.Windows.Forms.CheckBox
End Class
