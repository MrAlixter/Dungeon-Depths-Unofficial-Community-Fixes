<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ThistleMenuV3
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ThistleMenuV3))
        Me.boxInventoryFilter = New System.Windows.Forms.TextBox()
        Me.btnSell = New System.Windows.Forms.Button()
        Me.boxInventory = New System.Windows.Forms.ListBox()
        Me.btnBuy = New System.Windows.Forms.Button()
        Me.lblInventory = New System.Windows.Forms.Label()
        Me.boxShopFilter = New System.Windows.Forms.TextBox()
        Me.boxShop = New System.Windows.Forms.ListBox()
        Me.lblPlayer = New System.Windows.Forms.Label()
        Me.lblShopkeeper = New System.Windows.Forms.Label()
        Me.btnInspect = New System.Windows.Forms.Button()
        Me.txtDesc = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'boxInventoryFilter
        '
        Me.boxInventoryFilter.BackColor = System.Drawing.Color.Black
        Me.boxInventoryFilter.Font = New System.Drawing.Font("Consolas", 10.0!)
        Me.boxInventoryFilter.ForeColor = System.Drawing.Color.White
        Me.boxInventoryFilter.Location = New System.Drawing.Point(12, 40)
        Me.boxInventoryFilter.Name = "boxInventoryFilter"
        Me.boxInventoryFilter.Size = New System.Drawing.Size(289, 23)
        Me.boxInventoryFilter.TabIndex = 194
        '
        'btnSell
        '
        Me.btnSell.BackColor = System.Drawing.Color.Black
        Me.btnSell.Font = New System.Drawing.Font("Consolas", 9.0!)
        Me.btnSell.ForeColor = System.Drawing.Color.White
        Me.btnSell.Location = New System.Drawing.Point(314, 360)
        Me.btnSell.Name = "btnSell"
        Me.btnSell.Size = New System.Drawing.Size(100, 36)
        Me.btnSell.TabIndex = 191
        Me.btnSell.Text = "Give -->"
        Me.btnSell.UseVisualStyleBackColor = False
        '
        'boxInventory
        '
        Me.boxInventory.BackColor = System.Drawing.Color.Black
        Me.boxInventory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.boxInventory.Font = New System.Drawing.Font("Consolas", 9.25!)
        Me.boxInventory.ForeColor = System.Drawing.Color.White
        Me.boxInventory.FormattingEnabled = True
        Me.boxInventory.ItemHeight = 17
        Me.boxInventory.Location = New System.Drawing.Point(12, 69)
        Me.boxInventory.Name = "boxInventory"
        Me.boxInventory.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.boxInventory.Size = New System.Drawing.Size(289, 394)
        Me.boxInventory.TabIndex = 188
        '
        'btnBuy
        '
        Me.btnBuy.BackColor = System.Drawing.Color.Black
        Me.btnBuy.Font = New System.Drawing.Font("Consolas", 9.0!)
        Me.btnBuy.ForeColor = System.Drawing.Color.White
        Me.btnBuy.Location = New System.Drawing.Point(472, 360)
        Me.btnBuy.Name = "btnBuy"
        Me.btnBuy.Size = New System.Drawing.Size(100, 36)
        Me.btnBuy.TabIndex = 190
        Me.btnBuy.Text = "<-- Take"
        Me.btnBuy.UseVisualStyleBackColor = False
        '
        'lblInventory
        '
        Me.lblInventory.AutoSize = True
        Me.lblInventory.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblInventory.ForeColor = System.Drawing.Color.White
        Me.lblInventory.Location = New System.Drawing.Point(248, -23)
        Me.lblInventory.Name = "lblInventory"
        Me.lblInventory.Size = New System.Drawing.Size(90, 19)
        Me.lblInventory.TabIndex = 186
        Me.lblInventory.Text = "INVENTORY"
        '
        'boxShopFilter
        '
        Me.boxShopFilter.BackColor = System.Drawing.Color.Black
        Me.boxShopFilter.Font = New System.Drawing.Font("Consolas", 10.0!)
        Me.boxShopFilter.ForeColor = System.Drawing.Color.White
        Me.boxShopFilter.Location = New System.Drawing.Point(584, 40)
        Me.boxShopFilter.Name = "boxShopFilter"
        Me.boxShopFilter.Size = New System.Drawing.Size(289, 23)
        Me.boxShopFilter.TabIndex = 196
        '
        'boxShop
        '
        Me.boxShop.BackColor = System.Drawing.Color.Black
        Me.boxShop.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.boxShop.Font = New System.Drawing.Font("Consolas", 9.25!)
        Me.boxShop.ForeColor = System.Drawing.Color.White
        Me.boxShop.FormattingEnabled = True
        Me.boxShop.ItemHeight = 15
        Me.boxShop.Location = New System.Drawing.Point(584, 69)
        Me.boxShop.Name = "boxShop"
        Me.boxShop.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.boxShop.Size = New System.Drawing.Size(289, 394)
        Me.boxShop.TabIndex = 195
        '
        'lblPlayer
        '
        Me.lblPlayer.BackColor = System.Drawing.Color.Black
        Me.lblPlayer.Font = New System.Drawing.Font("Consolas", 11.0!)
        Me.lblPlayer.ForeColor = System.Drawing.Color.White
        Me.lblPlayer.Location = New System.Drawing.Point(13, 9)
        Me.lblPlayer.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPlayer.Name = "lblPlayer"
        Me.lblPlayer.Size = New System.Drawing.Size(285, 24)
        Me.lblPlayer.TabIndex = 197
        Me.lblPlayer.Text = "You"
        Me.lblPlayer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblShopkeeper
        '
        Me.lblShopkeeper.BackColor = System.Drawing.Color.Black
        Me.lblShopkeeper.Font = New System.Drawing.Font("Consolas", 11.0!)
        Me.lblShopkeeper.ForeColor = System.Drawing.Color.White
        Me.lblShopkeeper.Location = New System.Drawing.Point(583, 9)
        Me.lblShopkeeper.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblShopkeeper.Name = "lblShopkeeper"
        Me.lblShopkeeper.Size = New System.Drawing.Size(289, 24)
        Me.lblShopkeeper.TabIndex = 198
        Me.lblShopkeeper.Text = "Fairy"
        Me.lblShopkeeper.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnInspect
        '
        Me.btnInspect.BackColor = System.Drawing.Color.Black
        Me.btnInspect.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnInspect.Font = New System.Drawing.Font("Consolas", 9.0!)
        Me.btnInspect.ForeColor = System.Drawing.Color.White
        Me.btnInspect.Location = New System.Drawing.Point(314, 234)
        Me.btnInspect.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnInspect.Name = "btnInspect"
        Me.btnInspect.Size = New System.Drawing.Size(258, 38)
        Me.btnInspect.TabIndex = 199
        Me.btnInspect.Text = "Inspect"
        Me.btnInspect.UseVisualStyleBackColor = False
        '
        'txtDesc
        '
        Me.txtDesc.BackColor = System.Drawing.Color.Black
        Me.txtDesc.Font = New System.Drawing.Font("Consolas", 9.0!)
        Me.txtDesc.ForeColor = System.Drawing.Color.White
        Me.txtDesc.Location = New System.Drawing.Point(314, 40)
        Me.txtDesc.Multiline = True
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.ReadOnly = True
        Me.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDesc.Size = New System.Drawing.Size(258, 186)
        Me.txtDesc.TabIndex = 200
        '
        'ThistleMenuV3
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(884, 502)
        Me.Controls.Add(Me.txtDesc)
        Me.Controls.Add(Me.btnInspect)
        Me.Controls.Add(Me.lblShopkeeper)
        Me.Controls.Add(Me.lblPlayer)
        Me.Controls.Add(Me.boxShopFilter)
        Me.Controls.Add(Me.boxShop)
        Me.Controls.Add(Me.boxInventoryFilter)
        Me.Controls.Add(Me.btnSell)
        Me.Controls.Add(Me.boxInventory)
        Me.Controls.Add(Me.btnBuy)
        Me.Controls.Add(Me.lblInventory)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ThistleMenuV3"
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
    Friend WithEvents boxInventoryFilter As TextBox
    Friend WithEvents btnSell As Button
    Friend WithEvents boxInventory As ListBox
    Friend WithEvents btnBuy As Button
    Friend WithEvents lblInventory As Label
    Friend WithEvents boxShopFilter As TextBox
    Friend WithEvents boxShop As ListBox
    Friend WithEvents lblPlayer As Label
    Friend WithEvents lblShopkeeper As Label
    Friend WithEvents btnInspect As Button
    Friend WithEvents txtDesc As System.Windows.Forms.TextBox
End Class
