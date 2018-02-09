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
        Me.lblInventory = New System.Windows.Forms.Label()
        Me.lblItems = New System.Windows.Forms.Label()
        Me.boxInventory = New System.Windows.Forms.ListBox()
        Me.boxItems = New System.Windows.Forms.ListBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.number = New System.Windows.Forms.NumericUpDown()
        Me.groupGeneral.SuspendLayout()
        Me.groupPlayer.SuspendLayout()
        Me.groupItems.SuspendLayout()
        CType(Me.number, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.groupItems.Controls.Add(Me.number)
        Me.groupItems.Controls.Add(Me.btnRemove)
        Me.groupItems.Controls.Add(Me.btnAdd)
        Me.groupItems.Controls.Add(Me.boxItems)
        Me.groupItems.Controls.Add(Me.boxInventory)
        Me.groupItems.Controls.Add(Me.lblItems)
        Me.groupItems.Controls.Add(Me.lblInventory)
        Me.groupItems.Dock = System.Windows.Forms.DockStyle.Left
        Me.groupItems.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.groupItems.ForeColor = System.Drawing.Color.White
        Me.groupItems.Location = New System.Drawing.Point(340, 0)
        Me.groupItems.Name = "groupItems"
        Me.groupItems.Size = New System.Drawing.Size(294, 511)
        Me.groupItems.TabIndex = 5
        Me.groupItems.TabStop = False
        Me.groupItems.Text = "INVENTORY"
        '
        'lblInventory
        '
        Me.lblInventory.AutoSize = True
        Me.lblInventory.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblInventory.ForeColor = System.Drawing.Color.White
        Me.lblInventory.Location = New System.Drawing.Point(6, 216)
        Me.lblInventory.Name = "lblInventory"
        Me.lblInventory.Size = New System.Drawing.Size(90, 19)
        Me.lblInventory.TabIndex = 6
        Me.lblInventory.Text = "INVENTORY"
        '
        'lblItems
        '
        Me.lblItems.AutoSize = True
        Me.lblItems.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblItems.ForeColor = System.Drawing.Color.White
        Me.lblItems.Location = New System.Drawing.Point(234, 283)
        Me.lblItems.Name = "lblItems"
        Me.lblItems.Size = New System.Drawing.Size(54, 19)
        Me.lblItems.TabIndex = 7
        Me.lblItems.Text = "ITEMS"
        '
        'boxInventory
        '
        Me.boxInventory.BackColor = System.Drawing.Color.Black
        Me.boxInventory.ForeColor = System.Drawing.Color.White
        Me.boxInventory.FormattingEnabled = True
        Me.boxInventory.ItemHeight = 19
        Me.boxInventory.Location = New System.Drawing.Point(6, 19)
        Me.boxInventory.Name = "boxInventory"
        Me.boxInventory.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.boxInventory.Size = New System.Drawing.Size(280, 194)
        Me.boxInventory.Sorted = True
        Me.boxInventory.TabIndex = 8
        '
        'boxItems
        '
        Me.boxItems.BackColor = System.Drawing.Color.Black
        Me.boxItems.ForeColor = System.Drawing.Color.White
        Me.boxItems.FormattingEnabled = True
        Me.boxItems.ItemHeight = 19
        Me.boxItems.Location = New System.Drawing.Point(6, 305)
        Me.boxItems.Name = "boxItems"
        Me.boxItems.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.boxItems.Size = New System.Drawing.Size(280, 194)
        Me.boxItems.TabIndex = 9
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.Black
        Me.btnAdd.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(10, 266)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(89, 36)
        Me.btnAdd.TabIndex = 181
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnRemove
        '
        Me.btnRemove.BackColor = System.Drawing.Color.Black
        Me.btnRemove.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemove.ForeColor = System.Drawing.Color.White
        Me.btnRemove.Location = New System.Drawing.Point(197, 219)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(89, 36)
        Me.btnRemove.TabIndex = 182
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = False
        '
        'number
        '
        Me.number.BackColor = System.Drawing.Color.Black
        Me.number.ForeColor = System.Drawing.Color.White
        Me.number.Location = New System.Drawing.Point(103, 242)
        Me.number.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.number.Name = "number"
        Me.number.Size = New System.Drawing.Size(89, 26)
        Me.number.TabIndex = 183
        Me.number.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Debug_Window
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(634, 511)
        Me.Controls.Add(Me.groupItems)
        Me.Controls.Add(Me.groupPlayer)
        Me.Controls.Add(Me.groupGeneral)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Debug_Window"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DebugWindow"
        Me.groupGeneral.ResumeLayout(False)
        Me.groupGeneral.PerformLayout()
        Me.groupPlayer.ResumeLayout(False)
        Me.groupPlayer.PerformLayout()
        Me.groupItems.ResumeLayout(False)
        Me.groupItems.PerformLayout()
        CType(Me.number, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
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
    Friend WithEvents lblItems As Label
    Friend WithEvents lblInventory As Label
    Friend WithEvents boxItems As ListBox
    Friend WithEvents boxInventory As ListBox
    Friend WithEvents btnRemove As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents number As NumericUpDown
End Class
