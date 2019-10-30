<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TileSelector
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.picBoard = New System.Windows.Forms.PictureBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.boxMapControls = New System.Windows.Forms.GroupBox()
        Me.lblZoom = New System.Windows.Forms.Label()
        Me.boxZoom = New System.Windows.Forms.NumericUpDown()
        Me.btnSelect = New System.Windows.Forms.RadioButton()
        Me.btnPan = New System.Windows.Forms.RadioButton()
        CType(Me.picBoard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.boxMapControls.SuspendLayout()
        CType(Me.boxZoom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picBoard
        '
        Me.picBoard.BackColor = System.Drawing.Color.Black
        Me.picBoard.Location = New System.Drawing.Point(11, 49)
        Me.picBoard.Name = "picBoard"
        Me.picBoard.Size = New System.Drawing.Size(532, 522)
        Me.picBoard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picBoard.TabIndex = 1
        Me.picBoard.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Black
        Me.btnCancel.Location = New System.Drawing.Point(12, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 31)
        Me.btnCancel.TabIndex = 206
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnConfirm
        '
        Me.btnConfirm.BackColor = System.Drawing.Color.Black
        Me.btnConfirm.Location = New System.Drawing.Point(443, 12)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(100, 31)
        Me.btnConfirm.TabIndex = 207
        Me.btnConfirm.Text = "CONFIRM"
        Me.btnConfirm.UseVisualStyleBackColor = False
        '
        'boxMapControls
        '
        Me.boxMapControls.Controls.Add(Me.lblZoom)
        Me.boxMapControls.Controls.Add(Me.boxZoom)
        Me.boxMapControls.Controls.Add(Me.btnSelect)
        Me.boxMapControls.Controls.Add(Me.btnPan)
        Me.boxMapControls.ForeColor = System.Drawing.Color.White
        Me.boxMapControls.Location = New System.Drawing.Point(12, 577)
        Me.boxMapControls.Name = "boxMapControls"
        Me.boxMapControls.Size = New System.Drawing.Size(531, 66)
        Me.boxMapControls.TabIndex = 208
        Me.boxMapControls.TabStop = False
        Me.boxMapControls.Text = "MAP CONTROLS"
        '
        'lblZoom
        '
        Me.lblZoom.AutoSize = True
        Me.lblZoom.Location = New System.Drawing.Point(408, 27)
        Me.lblZoom.Name = "lblZoom"
        Me.lblZoom.Size = New System.Drawing.Size(45, 19)
        Me.lblZoom.TabIndex = 208
        Me.lblZoom.Text = "ZOOM"
        '
        'boxZoom
        '
        Me.boxZoom.BackColor = System.Drawing.Color.Black
        Me.boxZoom.ForeColor = System.Drawing.Color.White
        Me.boxZoom.Location = New System.Drawing.Point(459, 25)
        Me.boxZoom.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.boxZoom.Name = "boxZoom"
        Me.boxZoom.Size = New System.Drawing.Size(54, 26)
        Me.boxZoom.TabIndex = 207
        Me.boxZoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.boxZoom.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'btnSelect
        '
        Me.btnSelect.AutoSize = True
        Me.btnSelect.Location = New System.Drawing.Point(225, 25)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(81, 23)
        Me.btnSelect.TabIndex = 206
        Me.btnSelect.TabStop = True
        Me.btnSelect.Text = "SELECT"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'btnPan
        '
        Me.btnPan.AutoSize = True
        Me.btnPan.Location = New System.Drawing.Point(17, 25)
        Me.btnPan.Name = "btnPan"
        Me.btnPan.Size = New System.Drawing.Size(54, 23)
        Me.btnPan.TabIndex = 205
        Me.btnPan.TabStop = True
        Me.btnPan.Text = "PAN"
        Me.btnPan.UseVisualStyleBackColor = True
        '
        'TileSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(555, 653)
        Me.Controls.Add(Me.boxMapControls)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnConfirm)
        Me.Controls.Add(Me.picBoard)
        Me.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "TileSelector"
        Me.Text = "TileSelector"
        CType(Me.picBoard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.boxMapControls.ResumeLayout(False)
        Me.boxMapControls.PerformLayout()
        CType(Me.boxZoom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents picBoard As PictureBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnConfirm As Button
    Friend WithEvents boxMapControls As GroupBox
    Friend WithEvents lblZoom As Label
    Friend WithEvents boxZoom As NumericUpDown
    Friend WithEvents btnSelect As RadioButton
    Friend WithEvents btnPan As RadioButton
End Class
