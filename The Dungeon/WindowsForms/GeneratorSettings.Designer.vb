<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GeneratorSettings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
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
        CType(Me.boxWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxChestFreqRange, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxChestFreqMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxChestSizeDependence, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblFC
        '
        Me.lblFC.AutoSize = True
        Me.lblFC.Location = New System.Drawing.Point(12, 9)
        Me.lblFC.Name = "lblFC"
        Me.lblFC.Size = New System.Drawing.Size(108, 19)
        Me.lblFC.TabIndex = 0
        Me.lblFC.Text = "FloorCode: "
        '
        'lblWidth
        '
        Me.lblWidth.AutoSize = True
        Me.lblWidth.Location = New System.Drawing.Point(12, 55)
        Me.lblWidth.Name = "lblWidth"
        Me.lblWidth.Size = New System.Drawing.Size(126, 19)
        Me.lblWidth.TabIndex = 1
        Me.lblWidth.Text = "Board Width: "
        '
        'lblHeight
        '
        Me.lblHeight.AutoSize = True
        Me.lblHeight.Location = New System.Drawing.Point(12, 87)
        Me.lblHeight.Name = "lblHeight"
        Me.lblHeight.Size = New System.Drawing.Size(135, 19)
        Me.lblHeight.TabIndex = 2
        Me.lblHeight.Text = "Board Height: "
        '
        'boxWidth
        '
        Me.boxWidth.BackColor = System.Drawing.Color.Black
        Me.boxWidth.ForeColor = System.Drawing.Color.White
        Me.boxWidth.Location = New System.Drawing.Point(220, 53)
        Me.boxWidth.Name = "boxWidth"
        Me.boxWidth.Size = New System.Drawing.Size(120, 26)
        Me.boxWidth.TabIndex = 3
        '
        'boxHeight
        '
        Me.boxHeight.BackColor = System.Drawing.Color.Black
        Me.boxHeight.ForeColor = System.Drawing.Color.White
        Me.boxHeight.Location = New System.Drawing.Point(220, 85)
        Me.boxHeight.Name = "boxHeight"
        Me.boxHeight.Size = New System.Drawing.Size(120, 26)
        Me.boxHeight.TabIndex = 4
        '
        'boxChestFreqRange
        '
        Me.boxChestFreqRange.BackColor = System.Drawing.Color.Black
        Me.boxChestFreqRange.ForeColor = System.Drawing.Color.White
        Me.boxChestFreqRange.Location = New System.Drawing.Point(220, 143)
        Me.boxChestFreqRange.Name = "boxChestFreqRange"
        Me.boxChestFreqRange.Size = New System.Drawing.Size(120, 26)
        Me.boxChestFreqRange.TabIndex = 6
        '
        'lblChestFreqRange
        '
        Me.lblChestFreqRange.AutoSize = True
        Me.lblChestFreqRange.Location = New System.Drawing.Point(12, 145)
        Me.lblChestFreqRange.Name = "lblChestFreqRange"
        Me.lblChestFreqRange.Size = New System.Drawing.Size(162, 19)
        Me.lblChestFreqRange.TabIndex = 5
        Me.lblChestFreqRange.Text = "Chest Freq Range:"
        '
        'boxChestFreqMin
        '
        Me.boxChestFreqMin.BackColor = System.Drawing.Color.Black
        Me.boxChestFreqMin.ForeColor = System.Drawing.Color.White
        Me.boxChestFreqMin.Location = New System.Drawing.Point(220, 175)
        Me.boxChestFreqMin.Name = "boxChestFreqMin"
        Me.boxChestFreqMin.Size = New System.Drawing.Size(120, 26)
        Me.boxChestFreqMin.TabIndex = 8
        '
        'lblChestFreqMin
        '
        Me.lblChestFreqMin.AutoSize = True
        Me.lblChestFreqMin.Location = New System.Drawing.Point(12, 177)
        Me.lblChestFreqMin.Name = "lblChestFreqMin"
        Me.lblChestFreqMin.Size = New System.Drawing.Size(144, 19)
        Me.lblChestFreqMin.TabIndex = 7
        Me.lblChestFreqMin.Text = "Chest Freq Min:"
        '
        'boxChestSizeDependence
        '
        Me.boxChestSizeDependence.BackColor = System.Drawing.Color.Black
        Me.boxChestSizeDependence.ForeColor = System.Drawing.Color.White
        Me.boxChestSizeDependence.Location = New System.Drawing.Point(220, 207)
        Me.boxChestSizeDependence.Name = "boxChestSizeDependence"
        Me.boxChestSizeDependence.Size = New System.Drawing.Size(120, 26)
        Me.boxChestSizeDependence.TabIndex = 10
        '
        'lblChestSize
        '
        Me.lblChestSize.AutoSize = True
        Me.lblChestSize.Location = New System.Drawing.Point(12, 209)
        Me.lblChestSize.Name = "lblChestSize"
        Me.lblChestSize.Size = New System.Drawing.Size(207, 19)
        Me.lblChestSize.TabIndex = 9
        Me.lblChestSize.Text = "Chest Size Dependence:"
        '
        'separator1
        '
        Me.separator1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.separator1.Location = New System.Drawing.Point(16, 31)
        Me.separator1.Name = "separator1"
        Me.separator1.Size = New System.Drawing.Size(325, 10)
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
        'GeneratorSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(784, 461)
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
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "GeneratorSettings"
        Me.Text = "Generation Settings"
        CType(Me.boxWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxChestFreqRange, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxChestFreqMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxChestSizeDependence, System.ComponentModel.ISupportInitialize).EndInit()
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
End Class
