<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbobxArmor = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnACPT = New System.Windows.Forms.Button()
        Me.cmbobxWeapon = New System.Windows.Forms.ComboBox()
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
        Me.Label2.Size = New System.Drawing.Size(135, 19)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Equiped Armor:"
        '
        'cmbobxArmor
        '
        Me.cmbobxArmor.BackColor = System.Drawing.Color.Black
        Me.cmbobxArmor.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbobxArmor.ForeColor = System.Drawing.Color.White
        Me.cmbobxArmor.FormattingEnabled = True
        Me.cmbobxArmor.Location = New System.Drawing.Point(47, 106)
        Me.cmbobxArmor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbobxArmor.Name = "cmbobxArmor"
        Me.cmbobxArmor.Size = New System.Drawing.Size(199, 27)
        Me.cmbobxArmor.TabIndex = 14
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
        Me.Label1.Size = New System.Drawing.Size(144, 19)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Equiped Weapon:"
        '
        'btnACPT
        '
        Me.btnACPT.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnACPT.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnACPT.ForeColor = System.Drawing.Color.Black
        Me.btnACPT.Location = New System.Drawing.Point(105, 148)
        Me.btnACPT.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnACPT.Name = "btnACPT"
        Me.btnACPT.Size = New System.Drawing.Size(89, 32)
        Me.btnACPT.TabIndex = 12
        Me.btnACPT.Text = "OK"
        Me.btnACPT.UseVisualStyleBackColor = False
        '
        'cmbobxWeapon
        '
        Me.cmbobxWeapon.BackColor = System.Drawing.Color.Black
        Me.cmbobxWeapon.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbobxWeapon.ForeColor = System.Drawing.Color.White
        Me.cmbobxWeapon.FormattingEnabled = True
        Me.cmbobxWeapon.Location = New System.Drawing.Point(47, 34)
        Me.cmbobxWeapon.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbobxWeapon.Name = "cmbobxWeapon"
        Me.cmbobxWeapon.Size = New System.Drawing.Size(199, 27)
        Me.cmbobxWeapon.TabIndex = 11
        '
        'Form3
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(291, 203)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbobxArmor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnACPT)
        Me.Controls.Add(Me.cmbobxWeapon)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Equip Menu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbobxArmor As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnACPT As System.Windows.Forms.Button
    Friend WithEvents cmbobxWeapon As System.Windows.Forms.ComboBox
End Class
