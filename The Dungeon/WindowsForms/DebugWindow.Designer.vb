<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Debug_Window
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Debug_Window))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTurn = New System.Windows.Forms.Label()
        Me.lblFloor = New System.Windows.Forms.Label()
        Me.groupGeneral = New System.Windows.Forms.GroupBox()
        Me.boxTurn = New System.Windows.Forms.TextBox()
        Me.boxFloor = New System.Windows.Forms.TextBox()
        Me.groupPlayer = New System.Windows.Forms.GroupBox()
        Me.boxForm = New System.Windows.Forms.ComboBox()
        Me.boxName = New System.Windows.Forms.TextBox()
        Me.boxSex = New System.Windows.Forms.ComboBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblSex = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.groupItems = New System.Windows.Forms.GroupBox()
        Me.groupGeneral.SuspendLayout()
        Me.groupPlayer.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        '
        'lblTurn
        '
        Me.lblTurn.AutoSize = True
        Me.lblTurn.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTurn.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblTurn.ForeColor = System.Drawing.Color.White
        Me.lblTurn.Location = New System.Drawing.Point(3, 51)
        Me.lblTurn.Name = "lblTurn"
        Me.lblTurn.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.lblTurn.Size = New System.Drawing.Size(63, 29)
        Me.lblTurn.TabIndex = 1
        Me.lblTurn.Text = "TURN: "
        '
        'lblFloor
        '
        Me.lblFloor.AutoSize = True
        Me.lblFloor.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblFloor.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblFloor.ForeColor = System.Drawing.Color.White
        Me.lblFloor.Location = New System.Drawing.Point(3, 22)
        Me.lblFloor.Name = "lblFloor"
        Me.lblFloor.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.lblFloor.Size = New System.Drawing.Size(72, 29)
        Me.lblFloor.TabIndex = 2
        Me.lblFloor.Text = "FLOOR: "
        '
        'groupGeneral
        '
        Me.groupGeneral.Controls.Add(Me.boxTurn)
        Me.groupGeneral.Controls.Add(Me.boxFloor)
        Me.groupGeneral.Controls.Add(Me.lblTurn)
        Me.groupGeneral.Controls.Add(Me.lblFloor)
        Me.groupGeneral.Dock = System.Windows.Forms.DockStyle.Left
        Me.groupGeneral.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.groupGeneral.ForeColor = System.Drawing.Color.White
        Me.groupGeneral.Location = New System.Drawing.Point(0, 0)
        Me.groupGeneral.Name = "groupGeneral"
        Me.groupGeneral.Size = New System.Drawing.Size(137, 511)
        Me.groupGeneral.TabIndex = 3
        Me.groupGeneral.TabStop = False
        Me.groupGeneral.Text = "GENERAL"
        '
        'boxTurn
        '
        Me.boxTurn.BackColor = System.Drawing.Color.Black
        Me.boxTurn.ForeColor = System.Drawing.Color.White
        Me.boxTurn.Location = New System.Drawing.Point(66, 48)
        Me.boxTurn.Name = "boxTurn"
        Me.boxTurn.Size = New System.Drawing.Size(65, 26)
        Me.boxTurn.TabIndex = 7
        '
        'boxFloor
        '
        Me.boxFloor.BackColor = System.Drawing.Color.Black
        Me.boxFloor.ForeColor = System.Drawing.Color.White
        Me.boxFloor.Location = New System.Drawing.Point(66, 19)
        Me.boxFloor.Name = "boxFloor"
        Me.boxFloor.Size = New System.Drawing.Size(65, 26)
        Me.boxFloor.TabIndex = 6
        '
        'groupPlayer
        '
        Me.groupPlayer.Controls.Add(Me.boxForm)
        Me.groupPlayer.Controls.Add(Me.boxName)
        Me.groupPlayer.Controls.Add(Me.boxSex)
        Me.groupPlayer.Controls.Add(Me.lblTitle)
        Me.groupPlayer.Controls.Add(Me.lblSex)
        Me.groupPlayer.Controls.Add(Me.lblName)
        Me.groupPlayer.Dock = System.Windows.Forms.DockStyle.Left
        Me.groupPlayer.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.groupPlayer.ForeColor = System.Drawing.Color.White
        Me.groupPlayer.Location = New System.Drawing.Point(137, 0)
        Me.groupPlayer.Name = "groupPlayer"
        Me.groupPlayer.Size = New System.Drawing.Size(203, 511)
        Me.groupPlayer.TabIndex = 4
        Me.groupPlayer.TabStop = False
        Me.groupPlayer.Text = "PLAYER"
        '
        'boxForm
        '
        Me.boxForm.BackColor = System.Drawing.Color.Black
        Me.boxForm.ForeColor = System.Drawing.Color.White
        Me.boxForm.FormattingEnabled = True
        Me.boxForm.Location = New System.Drawing.Point(63, 77)
        Me.boxForm.Name = "boxForm"
        Me.boxForm.Size = New System.Drawing.Size(134, 27)
        Me.boxForm.TabIndex = 5
        '
        'boxName
        '
        Me.boxName.BackColor = System.Drawing.Color.Black
        Me.boxName.ForeColor = System.Drawing.Color.White
        Me.boxName.Location = New System.Drawing.Point(63, 19)
        Me.boxName.Name = "boxName"
        Me.boxName.Size = New System.Drawing.Size(134, 26)
        Me.boxName.TabIndex = 4
        '
        'boxSex
        '
        Me.boxSex.BackColor = System.Drawing.Color.Black
        Me.boxSex.ForeColor = System.Drawing.Color.White
        Me.boxSex.FormattingEnabled = True
        Me.boxSex.Location = New System.Drawing.Point(63, 48)
        Me.boxSex.Name = "boxSex"
        Me.boxSex.Size = New System.Drawing.Size(134, 27)
        Me.boxSex.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(3, 80)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.lblTitle.Size = New System.Drawing.Size(63, 29)
        Me.lblTitle.TabIndex = 3
        Me.lblTitle.Text = "TITLE:"
        '
        'lblSex
        '
        Me.lblSex.AutoSize = True
        Me.lblSex.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSex.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblSex.ForeColor = System.Drawing.Color.White
        Me.lblSex.Location = New System.Drawing.Point(3, 51)
        Me.lblSex.Name = "lblSex"
        Me.lblSex.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.lblSex.Size = New System.Drawing.Size(54, 29)
        Me.lblSex.TabIndex = 1
        Me.lblSex.Text = "SEX: "
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblName.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblName.ForeColor = System.Drawing.Color.White
        Me.lblName.Location = New System.Drawing.Point(3, 22)
        Me.lblName.Name = "lblName"
        Me.lblName.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.lblName.Size = New System.Drawing.Size(63, 29)
        Me.lblName.TabIndex = 2
        Me.lblName.Text = "NAME: "
        '
        'groupItems
        '
        Me.groupItems.Dock = System.Windows.Forms.DockStyle.Left
        Me.groupItems.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.groupItems.ForeColor = System.Drawing.Color.White
        Me.groupItems.Location = New System.Drawing.Point(340, 0)
        Me.groupItems.Name = "groupItems"
        Me.groupItems.Size = New System.Drawing.Size(194, 511)
        Me.groupItems.TabIndex = 5
        Me.groupItems.TabStop = False
        Me.groupItems.Text = "INVENTORY"
        '
        'Debug_Window
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(534, 511)
        Me.Controls.Add(Me.groupItems)
        Me.Controls.Add(Me.groupPlayer)
        Me.Controls.Add(Me.groupGeneral)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Debug_Window"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DebugWindow"
        Me.groupGeneral.ResumeLayout(False)
        Me.groupGeneral.PerformLayout()
        Me.groupPlayer.ResumeLayout(False)
        Me.groupPlayer.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents lblTurn As Label
    Friend WithEvents lblFloor As Label
    Friend WithEvents groupGeneral As GroupBox
    Friend WithEvents groupPlayer As GroupBox
    Friend WithEvents lblSex As Label
    Friend WithEvents lblName As Label
    Friend WithEvents groupItems As GroupBox
    Friend WithEvents boxForm As ComboBox
    Friend WithEvents boxName As TextBox
    Friend WithEvents boxSex As ComboBox
    Friend WithEvents lblTitle As Label
    Friend WithEvents boxTurn As TextBox
    Friend WithEvents boxFloor As TextBox
End Class
