<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Settings))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboxScreenSize = New System.Windows.Forms.ComboBox()
        Me.chkNoImg = New System.Windows.Forms.CheckBox()
        Me.chkAlwaysUnwilling = New System.Windows.Forms.CheckBox()
        Me.chkNoRNG = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.Font = New System.Drawing.Font("Consolas", 8.150944!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(93, 203)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 30)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Ok"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(13, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 19)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Window Size:"
        '
        'cboxScreenSize
        '
        Me.cboxScreenSize.BackColor = System.Drawing.Color.Black
        Me.cboxScreenSize.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboxScreenSize.ForeColor = System.Drawing.Color.White
        Me.cboxScreenSize.FormattingEnabled = True
        Me.cboxScreenSize.Location = New System.Drawing.Point(17, 33)
        Me.cboxScreenSize.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboxScreenSize.Name = "cboxScreenSize"
        Me.cboxScreenSize.Size = New System.Drawing.Size(199, 26)
        Me.cboxScreenSize.TabIndex = 19
        Me.cboxScreenSize.Text = "-- Select --"
        '
        'chkNoImg
        '
        Me.chkNoImg.AutoSize = True
        Me.chkNoImg.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNoImg.ForeColor = System.Drawing.Color.White
        Me.chkNoImg.Location = New System.Drawing.Point(17, 78)
        Me.chkNoImg.Name = "chkNoImg"
        Me.chkNoImg.Size = New System.Drawing.Size(199, 23)
        Me.chkNoImg.TabIndex = 21
        Me.chkNoImg.Text = "Load without images"
        Me.chkNoImg.UseVisualStyleBackColor = True
        '
        'chkAlwaysUnwilling
        '
        Me.chkAlwaysUnwilling.AutoSize = True
        Me.chkAlwaysUnwilling.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAlwaysUnwilling.ForeColor = System.Drawing.Color.White
        Me.chkAlwaysUnwilling.Location = New System.Drawing.Point(16, 105)
        Me.chkAlwaysUnwilling.Name = "chkAlwaysUnwilling"
        Me.chkAlwaysUnwilling.Size = New System.Drawing.Size(262, 42)
        Me.chkAlwaysUnwilling.TabIndex = 22
        Me.chkAlwaysUnwilling.Text = "Player is always unwilling" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(regrdless of will)"
        Me.chkAlwaysUnwilling.UseVisualStyleBackColor = True
        '
        'chkNoRNG
        '
        Me.chkNoRNG.AutoSize = True
        Me.chkNoRNG.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNoRNG.ForeColor = System.Drawing.Color.White
        Me.chkNoRNG.Location = New System.Drawing.Point(16, 149)
        Me.chkNoRNG.Name = "chkNoRNG"
        Me.chkNoRNG.Size = New System.Drawing.Size(271, 23)
        Me.chkNoRNG.TabIndex = 23
        Me.chkNoRNG.Text = "Always transform from items"
        Me.chkNoRNG.UseVisualStyleBackColor = True
        '
        'Settings
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(292, 244)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkNoRNG)
        Me.Controls.Add(Me.chkAlwaysUnwilling)
        Me.Controls.Add(Me.chkNoImg)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboxScreenSize)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Settings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboxScreenSize As System.Windows.Forms.ComboBox
    Friend WithEvents chkNoImg As System.Windows.Forms.CheckBox
    Friend WithEvents chkAlwaysUnwilling As System.Windows.Forms.CheckBox
    Friend WithEvents chkNoRNG As System.Windows.Forms.CheckBox
End Class
