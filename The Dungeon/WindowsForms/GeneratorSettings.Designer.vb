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
        CType(Me.boxWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxHeight, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblWidth.Location = New System.Drawing.Point(12, 41)
        Me.lblWidth.Name = "lblWidth"
        Me.lblWidth.Size = New System.Drawing.Size(72, 19)
        Me.lblWidth.TabIndex = 1
        Me.lblWidth.Text = "Width: "
        '
        'lblHeight
        '
        Me.lblHeight.AutoSize = True
        Me.lblHeight.Location = New System.Drawing.Point(12, 73)
        Me.lblHeight.Name = "lblHeight"
        Me.lblHeight.Size = New System.Drawing.Size(81, 19)
        Me.lblHeight.TabIndex = 2
        Me.lblHeight.Text = "Height: "
        '
        'boxWidth
        '
        Me.boxWidth.BackColor = System.Drawing.Color.Black
        Me.boxWidth.ForeColor = System.Drawing.Color.White
        Me.boxWidth.Location = New System.Drawing.Point(119, 39)
        Me.boxWidth.Name = "boxWidth"
        Me.boxWidth.Size = New System.Drawing.Size(120, 26)
        Me.boxWidth.TabIndex = 3
        '
        'boxHeight
        '
        Me.boxHeight.BackColor = System.Drawing.Color.Black
        Me.boxHeight.ForeColor = System.Drawing.Color.White
        Me.boxHeight.Location = New System.Drawing.Point(119, 71)
        Me.boxHeight.Name = "boxHeight"
        Me.boxHeight.Size = New System.Drawing.Size(120, 26)
        Me.boxHeight.TabIndex = 4
        '
        'GeneratorSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(784, 461)
        Me.Controls.Add(Me.boxHeight)
        Me.Controls.Add(Me.boxWidth)
        Me.Controls.Add(Me.lblHeight)
        Me.Controls.Add(Me.lblWidth)
        Me.Controls.Add(Me.lblFC)
        Me.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "GeneratorSettings"
        Me.Text = "GeneratorSettings"
        CType(Me.boxWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxHeight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblFC As Label
    Friend WithEvents lblWidth As Label
    Friend WithEvents lblHeight As Label
    Friend WithEvents boxWidth As NumericUpDown
    Friend WithEvents boxHeight As NumericUpDown
End Class
