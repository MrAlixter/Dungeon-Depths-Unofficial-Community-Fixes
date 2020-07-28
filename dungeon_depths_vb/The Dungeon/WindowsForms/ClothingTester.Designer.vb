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
        CType(Me.picDescPort, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picDescPort
        '
        Me.picDescPort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picDescPort.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picDescPort.Location = New System.Drawing.Point(291, 12)
        Me.picDescPort.Name = "picDescPort"
        Me.picDescPort.Size = New System.Drawing.Size(180, 593)
        Me.picDescPort.TabIndex = 277
        Me.picDescPort.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(13, 130)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 20)
        Me.Label1.TabIndex = 278
        Me.Label1.Text = "Breast Size"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(13, 206)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 20)
        Me.Label2.TabIndex = 279
        Me.Label2.Text = "Ass Size"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(13, 285)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 20)
        Me.Label3.TabIndex = 280
        Me.Label3.Text = "Clothing"
        '
        'cmbArmor
        '
        Me.cmbArmor.BackColor = System.Drawing.Color.Black
        Me.cmbArmor.Font = New System.Drawing.Font("Consolas", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbArmor.ForeColor = System.Drawing.Color.White
        Me.cmbArmor.FormattingEnabled = True
        Me.cmbArmor.Location = New System.Drawing.Point(12, 308)
        Me.cmbArmor.Name = "cmbArmor"
        Me.cmbArmor.Size = New System.Drawing.Size(234, 23)
        Me.cmbArmor.TabIndex = 281
        '
        'btnBSizeMinus
        '
        Me.btnBSizeMinus.BackColor = System.Drawing.Color.Black
        Me.btnBSizeMinus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnBSizeMinus.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBSizeMinus.ForeColor = System.Drawing.Color.White
        Me.btnBSizeMinus.Location = New System.Drawing.Point(17, 154)
        Me.btnBSizeMinus.Name = "btnBSizeMinus"
        Me.btnBSizeMinus.Size = New System.Drawing.Size(53, 35)
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
        Me.btnBSizePlus.Location = New System.Drawing.Point(76, 154)
        Me.btnBSizePlus.Name = "btnBSizePlus"
        Me.btnBSizePlus.Size = New System.Drawing.Size(53, 35)
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
        Me.btnUSizePlus.Location = New System.Drawing.Point(76, 229)
        Me.btnUSizePlus.Name = "btnUSizePlus"
        Me.btnUSizePlus.Size = New System.Drawing.Size(53, 35)
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
        Me.btnUSizeMinus.Location = New System.Drawing.Point(17, 229)
        Me.btnUSizeMinus.Name = "btnUSizeMinus"
        Me.btnUSizeMinus.Size = New System.Drawing.Size(53, 35)
        Me.btnUSizeMinus.TabIndex = 284
        Me.btnUSizeMinus.Text = "-"
        Me.btnUSizeMinus.UseVisualStyleBackColor = False
        '
        'ClothingTester
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(485, 617)
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
End Class
