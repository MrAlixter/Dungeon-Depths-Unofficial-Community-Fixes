<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClothingTester
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
        Me.picDescPort = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbArmor = New System.Windows.Forms.ComboBox()
        Me.btnBSizeMinus = New System.Windows.Forms.Button()
        Me.btnBSizePlus = New System.Windows.Forms.Button()
        Me.btnUSizePlus = New System.Windows.Forms.Button()
        Me.btnUSizeMinus = New System.Windows.Forms.Button()
        Me.lblAS = New System.Windows.Forms.Label()
        Me.lblBS = New System.Windows.Forms.Label()
        CType(Me.picDescPort, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picDescPort
        '
        Me.picDescPort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picDescPort.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picDescPort.Location = New System.Drawing.Point(218, 10)
        Me.picDescPort.Margin = New System.Windows.Forms.Padding(2)
        Me.picDescPort.Name = "picDescPort"
        Me.picDescPort.Size = New System.Drawing.Size(136, 483)
        Me.picDescPort.TabIndex = 277
        Me.picDescPort.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(10, 106)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 17)
        Me.Label1.TabIndex = 278
        Me.Label1.Text = "Breast Size"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(10, 167)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 17)
        Me.Label2.TabIndex = 279
        Me.Label2.Text = "Ass Size"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(10, 232)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 17)
        Me.Label3.TabIndex = 280
        Me.Label3.Text = "Clothing"
        '
        'cmbArmor
        '
        Me.cmbArmor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbArmor.BackColor = System.Drawing.Color.Black
        Me.cmbArmor.Font = New System.Drawing.Font("Consolas", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbArmor.ForeColor = System.Drawing.Color.White
        Me.cmbArmor.FormattingEnabled = True
        Me.cmbArmor.Location = New System.Drawing.Point(9, 250)
        Me.cmbArmor.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbArmor.Name = "cmbArmor"
        Me.cmbArmor.Size = New System.Drawing.Size(176, 20)
        Me.cmbArmor.TabIndex = 281
        '
        'btnBSizeMinus
        '
        Me.btnBSizeMinus.BackColor = System.Drawing.Color.Black
        Me.btnBSizeMinus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnBSizeMinus.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBSizeMinus.ForeColor = System.Drawing.Color.White
        Me.btnBSizeMinus.Location = New System.Drawing.Point(13, 125)
        Me.btnBSizeMinus.Margin = New System.Windows.Forms.Padding(2)
        Me.btnBSizeMinus.Name = "btnBSizeMinus"
        Me.btnBSizeMinus.Size = New System.Drawing.Size(40, 28)
        Me.btnBSizeMinus.TabIndex = 282
        Me.btnBSizeMinus.Text = "-"
        Me.btnBSizeMinus.UseVisualStyleBackColor = False
        '
        'btnBSizePlus
        '
        Me.btnBSizePlus.BackColor = System.Drawing.Color.Black
        Me.btnBSizePlus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnBSizePlus.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBSizePlus.ForeColor = System.Drawing.Color.White
        Me.btnBSizePlus.Location = New System.Drawing.Point(86, 125)
        Me.btnBSizePlus.Margin = New System.Windows.Forms.Padding(2)
        Me.btnBSizePlus.Name = "btnBSizePlus"
        Me.btnBSizePlus.Size = New System.Drawing.Size(40, 28)
        Me.btnBSizePlus.TabIndex = 283
        Me.btnBSizePlus.Text = "+"
        Me.btnBSizePlus.UseVisualStyleBackColor = False
        '
        'btnUSizePlus
        '
        Me.btnUSizePlus.BackColor = System.Drawing.Color.Black
        Me.btnUSizePlus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnUSizePlus.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUSizePlus.ForeColor = System.Drawing.Color.White
        Me.btnUSizePlus.Location = New System.Drawing.Point(86, 186)
        Me.btnUSizePlus.Margin = New System.Windows.Forms.Padding(2)
        Me.btnUSizePlus.Name = "btnUSizePlus"
        Me.btnUSizePlus.Size = New System.Drawing.Size(40, 28)
        Me.btnUSizePlus.TabIndex = 285
        Me.btnUSizePlus.Text = "+"
        Me.btnUSizePlus.UseVisualStyleBackColor = False
        '
        'btnUSizeMinus
        '
        Me.btnUSizeMinus.BackColor = System.Drawing.Color.Black
        Me.btnUSizeMinus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnUSizeMinus.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUSizeMinus.ForeColor = System.Drawing.Color.White
        Me.btnUSizeMinus.Location = New System.Drawing.Point(13, 186)
        Me.btnUSizeMinus.Margin = New System.Windows.Forms.Padding(2)
        Me.btnUSizeMinus.Name = "btnUSizeMinus"
        Me.btnUSizeMinus.Size = New System.Drawing.Size(40, 28)
        Me.btnUSizeMinus.TabIndex = 284
        Me.btnUSizeMinus.Text = "-"
        Me.btnUSizeMinus.UseVisualStyleBackColor = False
        '
        'lblAS
        '
        Me.lblAS.AutoSize = True
        Me.lblAS.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAS.ForeColor = System.Drawing.Color.White
        Me.lblAS.Location = New System.Drawing.Point(61, 191)
        Me.lblAS.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblAS.Name = "lblAS"
        Me.lblAS.Size = New System.Drawing.Size(24, 17)
        Me.lblAS.TabIndex = 286
        Me.lblAS.Text = "-1"
        Me.lblAS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBS
        '
        Me.lblBS.AutoSize = True
        Me.lblBS.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBS.ForeColor = System.Drawing.Color.White
        Me.lblBS.Location = New System.Drawing.Point(61, 130)
        Me.lblBS.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblBS.Name = "lblBS"
        Me.lblBS.Size = New System.Drawing.Size(24, 17)
        Me.lblBS.TabIndex = 287
        Me.lblBS.Text = "-1"
        Me.lblBS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ClothingTester
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(364, 501)
        Me.Controls.Add(Me.lblBS)
        Me.Controls.Add(Me.lblAS)
        Me.Controls.Add(Me.btnUSizePlus)
        Me.Controls.Add(Me.btnUSizeMinus)
        Me.Controls.Add(Me.btnBSizePlus)
        Me.Controls.Add(Me.btnBSizeMinus)
        Me.Controls.Add(Me.cmbArmor)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.picDescPort)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "ClothingTester"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Clothing Tester"
        CType(Me.picDescPort, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents picDescPort As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbArmor As System.Windows.Forms.ComboBox
    Friend WithEvents btnBSizeMinus As System.Windows.Forms.Button
    Friend WithEvents btnBSizePlus As System.Windows.Forms.Button
    Friend WithEvents btnUSizePlus As System.Windows.Forms.Button
    Friend WithEvents btnUSizeMinus As System.Windows.Forms.Button
    Friend WithEvents lblAS As System.Windows.Forms.Label
    Friend WithEvents lblBS As System.Windows.Forms.Label
End Class
