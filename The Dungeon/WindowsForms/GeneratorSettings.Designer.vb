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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
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
        Me.lblFC.AutoSize = True
        Me.lblFC.Location = New System.Drawing.Point(12, 9)
        Me.lblFC.Name = "lblFC"
        Me.lblFC.Size = New System.Drawing.Size(155, 28)
        Me.lblFC.TabIndex = 0
        Me.lblFC.Text = "FloorCode: "
        '
        'lblWidth
        '
        Me.lblWidth.AutoSize = True
        Me.lblWidth.Location = New System.Drawing.Point(12, 55)
        Me.lblWidth.Name = "lblWidth"
        Me.lblWidth.Size = New System.Drawing.Size(181, 28)
        Me.lblWidth.TabIndex = 1
        Me.lblWidth.Text = "Board Width: "
        '
        'lblHeight
        '
        Me.lblHeight.AutoSize = True
        Me.lblHeight.Location = New System.Drawing.Point(12, 87)
        Me.lblHeight.Name = "lblHeight"
        Me.lblHeight.Size = New System.Drawing.Size(194, 28)
        Me.lblHeight.TabIndex = 2
        Me.lblHeight.Text = "Board Height: "
        '
        'boxWidth
        '
        Me.boxWidth.BackColor = System.Drawing.Color.Black
        Me.boxWidth.ForeColor = System.Drawing.Color.White
        Me.boxWidth.Location = New System.Drawing.Point(220, 53)
        Me.boxWidth.Name = "boxWidth"
        Me.boxWidth.Size = New System.Drawing.Size(120, 36)
        Me.boxWidth.TabIndex = 3
        '
        'boxHeight
        '
        Me.boxHeight.BackColor = System.Drawing.Color.Black
        Me.boxHeight.ForeColor = System.Drawing.Color.White
        Me.boxHeight.Location = New System.Drawing.Point(220, 85)
        Me.boxHeight.Name = "boxHeight"
        Me.boxHeight.Size = New System.Drawing.Size(120, 36)
        Me.boxHeight.TabIndex = 4
        '
        'boxChestFreqRange
        '
        Me.boxChestFreqRange.BackColor = System.Drawing.Color.Black
        Me.boxChestFreqRange.ForeColor = System.Drawing.Color.White
        Me.boxChestFreqRange.Location = New System.Drawing.Point(220, 143)
        Me.boxChestFreqRange.Name = "boxChestFreqRange"
        Me.boxChestFreqRange.Size = New System.Drawing.Size(120, 36)
        Me.boxChestFreqRange.TabIndex = 6
        '
        'lblChestFreqRange
        '
        Me.lblChestFreqRange.AutoSize = True
        Me.lblChestFreqRange.Location = New System.Drawing.Point(12, 145)
        Me.lblChestFreqRange.Name = "lblChestFreqRange"
        Me.lblChestFreqRange.Size = New System.Drawing.Size(233, 28)
        Me.lblChestFreqRange.TabIndex = 5
        Me.lblChestFreqRange.Text = "Chest Freq Range:"
        '
        'boxChestFreqMin
        '
        Me.boxChestFreqMin.BackColor = System.Drawing.Color.Black
        Me.boxChestFreqMin.ForeColor = System.Drawing.Color.White
        Me.boxChestFreqMin.Location = New System.Drawing.Point(220, 175)
        Me.boxChestFreqMin.Name = "boxChestFreqMin"
        Me.boxChestFreqMin.Size = New System.Drawing.Size(120, 36)
        Me.boxChestFreqMin.TabIndex = 8
        '
        'lblChestFreqMin
        '
        Me.lblChestFreqMin.AutoSize = True
        Me.lblChestFreqMin.Location = New System.Drawing.Point(12, 177)
        Me.lblChestFreqMin.Name = "lblChestFreqMin"
        Me.lblChestFreqMin.Size = New System.Drawing.Size(207, 28)
        Me.lblChestFreqMin.TabIndex = 7
        Me.lblChestFreqMin.Text = "Chest Freq Min:"
        '
        'boxChestSizeDependence
        '
        Me.boxChestSizeDependence.BackColor = System.Drawing.Color.Black
        Me.boxChestSizeDependence.ForeColor = System.Drawing.Color.White
        Me.boxChestSizeDependence.Location = New System.Drawing.Point(220, 207)
        Me.boxChestSizeDependence.Name = "boxChestSizeDependence"
        Me.boxChestSizeDependence.Size = New System.Drawing.Size(120, 36)
        Me.boxChestSizeDependence.TabIndex = 10
        '
        'lblChestSize
        '
        Me.lblChestSize.AutoSize = True
        Me.lblChestSize.Location = New System.Drawing.Point(12, 209)
        Me.lblChestSize.Name = "lblChestSize"
        Me.lblChestSize.Size = New System.Drawing.Size(298, 28)
        Me.lblChestSize.TabIndex = 9
        Me.lblChestSize.Text = "Chest Size Dependence:"
        '
        'separator1
        '
        Me.separator1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.separator1.Location = New System.Drawing.Point(16, 31)
        Me.separator1.Name = "separator1"
        Me.separator1.Size = New System.Drawing.Size(754, 10)
        Me.separator1.TabIndex = 11
        Me.separator1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox1.Location = New System.Drawing.Point(16, 117)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(325, 10)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox2.Location = New System.Drawing.Point(17, 303)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(325, 10)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        '
        'boxEncounterRate
        '
        Me.boxEncounterRate.BackColor = System.Drawing.Color.Black
        Me.boxEncounterRate.ForeColor = System.Drawing.Color.White
        Me.boxEncounterRate.Location = New System.Drawing.Point(221, 323)
        Me.boxEncounterRate.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.boxEncounterRate.Name = "boxEncounterRate"
        Me.boxEncounterRate.Size = New System.Drawing.Size(120, 36)
        Me.boxEncounterRate.TabIndex = 15
        '
        'lblEncounterRate
        '
        Me.lblEncounterRate.AutoSize = True
        Me.lblEncounterRate.Location = New System.Drawing.Point(13, 325)
        Me.lblEncounterRate.Name = "lblEncounterRate"
        Me.lblEncounterRate.Size = New System.Drawing.Size(285, 28)
        Me.lblEncounterRate.TabIndex = 14
        Me.lblEncounterRate.Text = "Encounter Rate (.x%):"
        '
        'boxEClockResetVal
        '
        Me.boxEClockResetVal.BackColor = System.Drawing.Color.Black
        Me.boxEClockResetVal.ForeColor = System.Drawing.Color.White
        Me.boxEClockResetVal.Location = New System.Drawing.Point(221, 355)
        Me.boxEClockResetVal.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.boxEClockResetVal.Name = "boxEClockResetVal"
        Me.boxEClockResetVal.Size = New System.Drawing.Size(120, 36)
        Me.boxEClockResetVal.TabIndex = 17
        '
        'lblEClockResetVal
        '
        Me.lblEClockResetVal.AutoSize = True
        Me.lblEClockResetVal.Location = New System.Drawing.Point(13, 357)
        Me.lblEClockResetVal.Name = "lblEClockResetVal"
        Me.lblEClockResetVal.Size = New System.Drawing.Size(220, 28)
        Me.lblEClockResetVal.TabIndex = 16
        Me.lblEClockResetVal.Text = "Encounter Timer:"
        '
        'boxChestRichnessBase
        '
        Me.boxChestRichnessBase.BackColor = System.Drawing.Color.Black
        Me.boxChestRichnessBase.ForeColor = System.Drawing.Color.White
        Me.boxChestRichnessBase.Location = New System.Drawing.Point(220, 239)
        Me.boxChestRichnessBase.Name = "boxChestRichnessBase"
        Me.boxChestRichnessBase.Size = New System.Drawing.Size(120, 36)
        Me.boxChestRichnessBase.TabIndex = 19
        '
        'lblChestRichnessBase
        '
        Me.lblChestRichnessBase.AutoSize = True
        Me.lblChestRichnessBase.Location = New System.Drawing.Point(12, 241)
        Me.lblChestRichnessBase.Name = "lblChestRichnessBase"
        Me.lblChestRichnessBase.Size = New System.Drawing.Size(272, 28)
        Me.lblChestRichnessBase.TabIndex = 18
        Me.lblChestRichnessBase.Text = "Chest Richness Base:"
        '
        'boxChestRichnessRange
        '
        Me.boxChestRichnessRange.BackColor = System.Drawing.Color.Black
        Me.boxChestRichnessRange.ForeColor = System.Drawing.Color.White
        Me.boxChestRichnessRange.Location = New System.Drawing.Point(221, 271)
        Me.boxChestRichnessRange.Name = "boxChestRichnessRange"
        Me.boxChestRichnessRange.Size = New System.Drawing.Size(120, 36)
        Me.boxChestRichnessRange.TabIndex = 21
        '
        'lblChestRichnessRange
        '
        Me.lblChestRichnessRange.AutoSize = True
        Me.lblChestRichnessRange.Location = New System.Drawing.Point(13, 273)
        Me.lblChestRichnessRange.Name = "lblChestRichnessRange"
        Me.lblChestRichnessRange.Size = New System.Drawing.Size(285, 28)
        Me.lblChestRichnessRange.TabIndex = 20
        Me.lblChestRichnessRange.Text = "Chest Richness Range:"
        '
        'btnReset
        '
        Me.btnReset.BackColor = System.Drawing.Color.DimGray
        Me.btnReset.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.ForeColor = System.Drawing.Color.White
        Me.btnReset.Location = New System.Drawing.Point(12, 418)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(75, 31)
        Me.btnReset.TabIndex = 22
        Me.btnReset.Text = "RESET"
        Me.btnReset.UseVisualStyleBackColor = False
        '
        'btnConfirm
        '
        Me.btnConfirm.BackColor = System.Drawing.Color.DimGray
        Me.btnConfirm.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirm.ForeColor = System.Drawing.Color.White
        Me.btnConfirm.Location = New System.Drawing.Point(697, 418)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(75, 31)
        Me.btnConfirm.TabIndex = 23
        Me.btnConfirm.Text = "CONFIRM"
        Me.btnConfirm.UseVisualStyleBackColor = False
        '
        'divider
        '
        Me.divider.Location = New System.Drawing.Point(348, 55)
        Me.divider.Multiline = True
        Me.divider.Name = "divider"
        Me.divider.Size = New System.Drawing.Size(1, 325)
        Me.divider.TabIndex = 236
        '
        'boxTrapFreqMin
        '
        Me.boxTrapFreqMin.BackColor = System.Drawing.Color.Black
        Me.boxTrapFreqMin.ForeColor = System.Drawing.Color.White
        Me.boxTrapFreqMin.Location = New System.Drawing.Point(563, 85)
        Me.boxTrapFreqMin.Name = "boxTrapFreqMin"
        Me.boxTrapFreqMin.Size = New System.Drawing.Size(120, 26)
        Me.boxTrapFreqMin.TabIndex = 240
        '
        'boxTrapFreqRange
        '
        Me.boxTrapFreqRange.BackColor = System.Drawing.Color.Black
        Me.boxTrapFreqRange.ForeColor = System.Drawing.Color.White
        Me.boxTrapFreqRange.Location = New System.Drawing.Point(563, 53)
        Me.boxTrapFreqRange.Name = "boxTrapFreqRange"
        Me.boxTrapFreqRange.Size = New System.Drawing.Size(120, 26)
        Me.boxTrapFreqRange.TabIndex = 239
        '
        'lblTrapFreqMin
        '
        Me.lblTrapFreqMin.AutoSize = True
        Me.lblTrapFreqMin.Location = New System.Drawing.Point(355, 87)
        Me.lblTrapFreqMin.Name = "lblTrapFreqMin"
        Me.lblTrapFreqMin.Size = New System.Drawing.Size(135, 19)
        Me.lblTrapFreqMin.TabIndex = 238
        Me.lblTrapFreqMin.Text = "Trap Freq Min:"
        '
        'lblTrapFreqRange
        '
        Me.lblTrapFreqRange.AutoSize = True
        Me.lblTrapFreqRange.Location = New System.Drawing.Point(355, 55)
        Me.lblTrapFreqRange.Name = "lblTrapFreqRange"
        Me.lblTrapFreqRange.Size = New System.Drawing.Size(162, 19)
        Me.lblTrapFreqRange.TabIndex = 237
        Me.lblTrapFreqRange.Text = "Trap Freq Range: "
        '
        'boxTrapSizeDependence
        '
        Me.boxTrapSizeDependence.BackColor = System.Drawing.Color.Black
        Me.boxTrapSizeDependence.ForeColor = System.Drawing.Color.White
        Me.boxTrapSizeDependence.Location = New System.Drawing.Point(563, 117)
        Me.boxTrapSizeDependence.Name = "boxTrapSizeDependence"
        Me.boxTrapSizeDependence.Size = New System.Drawing.Size(120, 26)
        Me.boxTrapSizeDependence.TabIndex = 242
        '
        'lblTrapSizeDependence
        '
        Me.lblTrapSizeDependence.AutoSize = True
        Me.lblTrapSizeDependence.Location = New System.Drawing.Point(355, 119)
        Me.lblTrapSizeDependence.Name = "lblTrapSizeDependence"
        Me.lblTrapSizeDependence.Size = New System.Drawing.Size(198, 19)
        Me.lblTrapSizeDependence.TabIndex = 241
        Me.lblTrapSizeDependence.Text = "Trap Size Dependence:"
        '
        'GeneratorSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(13.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(784, 461)
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
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
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
        Me.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "GeneratorSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Generation Settings"
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
    Friend WithEvents GroupBox2 As GroupBox
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
End Class
