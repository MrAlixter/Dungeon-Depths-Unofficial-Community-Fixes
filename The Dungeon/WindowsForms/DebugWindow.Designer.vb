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
        Me.groupPlayer = New System.Windows.Forms.GroupBox()
        Me.boxGold = New System.Windows.Forms.NumericUpDown()
        Me.lblGold = New System.Windows.Forms.Label()
        Me.boxForm = New System.Windows.Forms.ComboBox()
        Me.boxName = New System.Windows.Forms.TextBox()
        Me.boxSex = New System.Windows.Forms.ComboBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblSex = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.groupItems = New System.Windows.Forms.GroupBox()
        Me.number = New System.Windows.Forms.NumericUpDown()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.boxItems = New System.Windows.Forms.ListBox()
        Me.boxInventory = New System.Windows.Forms.ListBox()
        Me.lblItems = New System.Windows.Forms.Label()
        Me.lblInventory = New System.Windows.Forms.Label()
        Me.boxAtk = New System.Windows.Forms.NumericUpDown()
        Me.lblAtk = New System.Windows.Forms.Label()
        Me.boxDef = New System.Windows.Forms.NumericUpDown()
        Me.lblDef = New System.Windows.Forms.Label()
        Me.boxWil = New System.Windows.Forms.NumericUpDown()
        Me.lblWil = New System.Windows.Forms.Label()
        Me.boxSpd = New System.Windows.Forms.NumericUpDown()
        Me.lblSpd = New System.Windows.Forms.Label()
        Me.boxEvd = New System.Windows.Forms.NumericUpDown()
        Me.lblEvd = New System.Windows.Forms.Label()
        Me.boxFloor = New System.Windows.Forms.NumericUpDown()
        Me.boxTurn = New System.Windows.Forms.NumericUpDown()
        Me.groupGeneral.SuspendLayout()
        Me.groupPlayer.SuspendLayout()
        CType(Me.boxGold, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupItems.SuspendLayout()
        CType(Me.number, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxAtk, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxDef, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxWil, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxSpd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxEvd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxFloor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.boxTurn, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.groupGeneral.Size = New System.Drawing.Size(185, 511)
        Me.groupGeneral.TabIndex = 3
        Me.groupGeneral.TabStop = False
        Me.groupGeneral.Text = "GENERAL"
        '
        'groupPlayer
        '
        Me.groupPlayer.Controls.Add(Me.lblGold)
        Me.groupPlayer.Controls.Add(Me.boxEvd)
        Me.groupPlayer.Controls.Add(Me.lblEvd)
        Me.groupPlayer.Controls.Add(Me.boxSpd)
        Me.groupPlayer.Controls.Add(Me.lblSpd)
        Me.groupPlayer.Controls.Add(Me.boxWil)
        Me.groupPlayer.Controls.Add(Me.lblWil)
        Me.groupPlayer.Controls.Add(Me.boxDef)
        Me.groupPlayer.Controls.Add(Me.lblDef)
        Me.groupPlayer.Controls.Add(Me.boxAtk)
        Me.groupPlayer.Controls.Add(Me.lblAtk)
        Me.groupPlayer.Controls.Add(Me.boxGold)
        Me.groupPlayer.Controls.Add(Me.boxForm)
        Me.groupPlayer.Controls.Add(Me.boxName)
        Me.groupPlayer.Controls.Add(Me.boxSex)
        Me.groupPlayer.Controls.Add(Me.lblTitle)
        Me.groupPlayer.Controls.Add(Me.lblSex)
        Me.groupPlayer.Controls.Add(Me.lblName)
        Me.groupPlayer.Dock = System.Windows.Forms.DockStyle.Left
        Me.groupPlayer.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.groupPlayer.ForeColor = System.Drawing.Color.White
        Me.groupPlayer.Location = New System.Drawing.Point(185, 0)
        Me.groupPlayer.Name = "groupPlayer"
        Me.groupPlayer.Size = New System.Drawing.Size(203, 511)
        Me.groupPlayer.TabIndex = 4
        Me.groupPlayer.TabStop = False
        Me.groupPlayer.Text = "PLAYER"
        '
        'boxGold
        '
        Me.boxGold.BackColor = System.Drawing.Color.Black
        Me.boxGold.ForeColor = System.Drawing.Color.White
        Me.boxGold.Location = New System.Drawing.Point(63, 252)
        Me.boxGold.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.boxGold.Name = "boxGold"
        Me.boxGold.Size = New System.Drawing.Size(134, 26)
        Me.boxGold.TabIndex = 184
        Me.boxGold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblGold
        '
        Me.lblGold.AutoSize = True
        Me.lblGold.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblGold.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblGold.ForeColor = System.Drawing.Color.White
        Me.lblGold.Location = New System.Drawing.Point(3, 254)
        Me.lblGold.Name = "lblGold"
        Me.lblGold.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.lblGold.Size = New System.Drawing.Size(54, 29)
        Me.lblGold.TabIndex = 194
        Me.lblGold.Text = "GOLD:"
        '
        'boxForm
        '
        Me.boxForm.BackColor = System.Drawing.Color.Black
        Me.boxForm.Enabled = False
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
        Me.groupItems.Location = New System.Drawing.Point(388, 0)
        Me.groupItems.Name = "groupItems"
        Me.groupItems.Size = New System.Drawing.Size(294, 511)
        Me.groupItems.TabIndex = 5
        Me.groupItems.TabStop = False
        Me.groupItems.Text = "INVENTORY"
        '
        'number
        '
        Me.number.BackColor = System.Drawing.Color.Black
        Me.number.ForeColor = System.Drawing.Color.White
        Me.number.Location = New System.Drawing.Point(103, 248)
        Me.number.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.number.Name = "number"
        Me.number.Size = New System.Drawing.Size(89, 26)
        Me.number.TabIndex = 183
        Me.number.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnRemove
        '
        Me.btnRemove.BackColor = System.Drawing.Color.Black
        Me.btnRemove.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemove.ForeColor = System.Drawing.Color.White
        Me.btnRemove.Location = New System.Drawing.Point(197, 216)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(89, 36)
        Me.btnRemove.TabIndex = 182
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.Black
        Me.btnAdd.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(7, 271)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(89, 36)
        Me.btnAdd.TabIndex = 181
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'boxItems
        '
        Me.boxItems.BackColor = System.Drawing.Color.Black
        Me.boxItems.ForeColor = System.Drawing.Color.White
        Me.boxItems.FormattingEnabled = True
        Me.boxItems.ItemHeight = 19
        Me.boxItems.Location = New System.Drawing.Point(6, 311)
        Me.boxItems.Name = "boxItems"
        Me.boxItems.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.boxItems.Size = New System.Drawing.Size(280, 194)
        Me.boxItems.TabIndex = 9
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
        'lblItems
        '
        Me.lblItems.AutoSize = True
        Me.lblItems.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblItems.ForeColor = System.Drawing.Color.White
        Me.lblItems.Location = New System.Drawing.Point(234, 288)
        Me.lblItems.Name = "lblItems"
        Me.lblItems.Size = New System.Drawing.Size(54, 19)
        Me.lblItems.TabIndex = 7
        Me.lblItems.Text = "ITEMS"
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
        'boxAtk
        '
        Me.boxAtk.BackColor = System.Drawing.Color.Black
        Me.boxAtk.ForeColor = System.Drawing.Color.White
        Me.boxAtk.Location = New System.Drawing.Point(63, 107)
        Me.boxAtk.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.boxAtk.Name = "boxAtk"
        Me.boxAtk.Size = New System.Drawing.Size(134, 26)
        Me.boxAtk.TabIndex = 186
        Me.boxAtk.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAtk
        '
        Me.lblAtk.AutoSize = True
        Me.lblAtk.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblAtk.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblAtk.ForeColor = System.Drawing.Color.White
        Me.lblAtk.Location = New System.Drawing.Point(3, 109)
        Me.lblAtk.Name = "lblAtk"
        Me.lblAtk.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.lblAtk.Size = New System.Drawing.Size(45, 29)
        Me.lblAtk.TabIndex = 185
        Me.lblAtk.Text = "ATK:"
        '
        'boxDef
        '
        Me.boxDef.BackColor = System.Drawing.Color.Black
        Me.boxDef.ForeColor = System.Drawing.Color.White
        Me.boxDef.Location = New System.Drawing.Point(63, 136)
        Me.boxDef.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.boxDef.Name = "boxDef"
        Me.boxDef.Size = New System.Drawing.Size(134, 26)
        Me.boxDef.TabIndex = 188
        Me.boxDef.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDef
        '
        Me.lblDef.AutoSize = True
        Me.lblDef.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblDef.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblDef.ForeColor = System.Drawing.Color.White
        Me.lblDef.Location = New System.Drawing.Point(3, 138)
        Me.lblDef.Name = "lblDef"
        Me.lblDef.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.lblDef.Size = New System.Drawing.Size(45, 29)
        Me.lblDef.TabIndex = 187
        Me.lblDef.Text = "DEF:"
        '
        'boxWil
        '
        Me.boxWil.BackColor = System.Drawing.Color.Black
        Me.boxWil.ForeColor = System.Drawing.Color.White
        Me.boxWil.Location = New System.Drawing.Point(63, 165)
        Me.boxWil.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.boxWil.Name = "boxWil"
        Me.boxWil.Size = New System.Drawing.Size(134, 26)
        Me.boxWil.TabIndex = 190
        Me.boxWil.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblWil
        '
        Me.lblWil.AutoSize = True
        Me.lblWil.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblWil.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblWil.ForeColor = System.Drawing.Color.White
        Me.lblWil.Location = New System.Drawing.Point(3, 167)
        Me.lblWil.Name = "lblWil"
        Me.lblWil.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.lblWil.Size = New System.Drawing.Size(45, 29)
        Me.lblWil.TabIndex = 189
        Me.lblWil.Text = "WIL:"
        '
        'boxSpd
        '
        Me.boxSpd.BackColor = System.Drawing.Color.Black
        Me.boxSpd.ForeColor = System.Drawing.Color.White
        Me.boxSpd.Location = New System.Drawing.Point(63, 194)
        Me.boxSpd.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.boxSpd.Name = "boxSpd"
        Me.boxSpd.Size = New System.Drawing.Size(134, 26)
        Me.boxSpd.TabIndex = 192
        Me.boxSpd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSpd
        '
        Me.lblSpd.AutoSize = True
        Me.lblSpd.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSpd.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblSpd.ForeColor = System.Drawing.Color.White
        Me.lblSpd.Location = New System.Drawing.Point(3, 196)
        Me.lblSpd.Name = "lblSpd"
        Me.lblSpd.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.lblSpd.Size = New System.Drawing.Size(45, 29)
        Me.lblSpd.TabIndex = 191
        Me.lblSpd.Text = "SPD:"
        '
        'boxEvd
        '
        Me.boxEvd.BackColor = System.Drawing.Color.Black
        Me.boxEvd.ForeColor = System.Drawing.Color.White
        Me.boxEvd.Location = New System.Drawing.Point(63, 223)
        Me.boxEvd.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.boxEvd.Name = "boxEvd"
        Me.boxEvd.Size = New System.Drawing.Size(134, 26)
        Me.boxEvd.TabIndex = 194
        Me.boxEvd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblEvd
        '
        Me.lblEvd.AutoSize = True
        Me.lblEvd.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblEvd.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblEvd.ForeColor = System.Drawing.Color.White
        Me.lblEvd.Location = New System.Drawing.Point(3, 225)
        Me.lblEvd.Name = "lblEvd"
        Me.lblEvd.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.lblEvd.Size = New System.Drawing.Size(45, 29)
        Me.lblEvd.TabIndex = 193
        Me.lblEvd.Text = "EVD:"
        '
        'boxFloor
        '
        Me.boxFloor.BackColor = System.Drawing.Color.Black
        Me.boxFloor.Enabled = False
        Me.boxFloor.ForeColor = System.Drawing.Color.White
        Me.boxFloor.Location = New System.Drawing.Point(66, 20)
        Me.boxFloor.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.boxFloor.Name = "boxFloor"
        Me.boxFloor.Size = New System.Drawing.Size(113, 26)
        Me.boxFloor.TabIndex = 195
        Me.boxFloor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'boxTurn
        '
        Me.boxTurn.BackColor = System.Drawing.Color.Black
        Me.boxTurn.ForeColor = System.Drawing.Color.White
        Me.boxTurn.Location = New System.Drawing.Point(66, 49)
        Me.boxTurn.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.boxTurn.Name = "boxTurn"
        Me.boxTurn.Size = New System.Drawing.Size(113, 26)
        Me.boxTurn.TabIndex = 196
        Me.boxTurn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Debug_Window
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(684, 511)
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
        CType(Me.boxGold, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupItems.ResumeLayout(False)
        Me.groupItems.PerformLayout()
        CType(Me.number, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxAtk, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxDef, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxWil, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxSpd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxEvd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxFloor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.boxTurn, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents lblItems As Label
    Friend WithEvents lblInventory As Label
    Friend WithEvents boxItems As ListBox
    Friend WithEvents boxInventory As ListBox
    Friend WithEvents btnRemove As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents number As NumericUpDown
    Friend WithEvents boxGold As NumericUpDown
    Friend WithEvents lblGold As Label
    Friend WithEvents boxAtk As NumericUpDown
    Friend WithEvents lblAtk As Label
    Friend WithEvents boxEvd As NumericUpDown
    Friend WithEvents lblEvd As Label
    Friend WithEvents boxSpd As NumericUpDown
    Friend WithEvents lblSpd As Label
    Friend WithEvents boxWil As NumericUpDown
    Friend WithEvents lblWil As Label
    Friend WithEvents boxDef As NumericUpDown
    Friend WithEvents lblDef As Label
    Friend WithEvents boxTurn As NumericUpDown
    Friend WithEvents boxFloor As NumericUpDown
End Class
