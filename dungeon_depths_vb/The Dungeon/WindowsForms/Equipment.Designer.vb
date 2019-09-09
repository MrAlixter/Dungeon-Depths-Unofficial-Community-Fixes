<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Equipment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Equipment))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboxArmor = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnACPT = New System.Windows.Forms.Button()
        Me.cboxWeapon = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboxAccessory = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(45, 81)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 17)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Equiped Armor:"
        '
        'cboxArmor
        '
        Me.cboxArmor.BackColor = System.Drawing.Color.Black
        Me.cboxArmor.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboxArmor.ForeColor = System.Drawing.Color.White
        Me.cboxArmor.FormattingEnabled = True
        Me.cboxArmor.Location = New System.Drawing.Point(47, 106)
        Me.cboxArmor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboxArmor.Name = "cboxArmor"
        Me.cboxArmor.Size = New System.Drawing.Size(199, 23)
        Me.cboxArmor.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(46, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 17)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Equiped Weapon:"
        '
        'btnACPT
        '
        Me.btnACPT.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnACPT.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnACPT.ForeColor = System.Drawing.Color.Black
        Me.btnACPT.Location = New System.Drawing.Point(105, 224)
        Me.btnACPT.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnACPT.Name = "btnACPT"
        Me.btnACPT.Size = New System.Drawing.Size(89, 32)
        Me.btnACPT.TabIndex = 12
        Me.btnACPT.Text = "OK"
        Me.btnACPT.UseVisualStyleBackColor = False
        '
        'cboxWeapon
        '
        Me.cboxWeapon.BackColor = System.Drawing.Color.Black
        Me.cboxWeapon.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboxWeapon.ForeColor = System.Drawing.Color.White
        Me.cboxWeapon.FormattingEnabled = True
        Me.cboxWeapon.Location = New System.Drawing.Point(47, 34)
        Me.cboxWeapon.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboxWeapon.Name = "cboxWeapon"
        Me.cboxWeapon.Size = New System.Drawing.Size(199, 23)
        Me.cboxWeapon.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Black
        Me.Label3.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(48, 153)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(152, 17)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Equiped Accessory:"
        '
        'cboxAccessory
        '
        Me.cboxAccessory.BackColor = System.Drawing.Color.Black
        Me.cboxAccessory.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboxAccessory.ForeColor = System.Drawing.Color.White
        Me.cboxAccessory.FormattingEnabled = True
        Me.cboxAccessory.Location = New System.Drawing.Point(50, 178)
        Me.cboxAccessory.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboxAccessory.Name = "cboxAccessory"
        Me.cboxAccessory.Size = New System.Drawing.Size(199, 23)
        Me.cboxAccessory.TabIndex = 16
        '
        'Equipment
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(291, 268)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboxAccessory)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboxArmor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnACPT)
        Me.Controls.Add(Me.cboxWeapon)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Equipment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Equip Menu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboxArmor As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnACPT As System.Windows.Forms.Button
    Friend WithEvents cboxWeapon As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboxAccessory As System.Windows.Forms.ComboBox
End Class
