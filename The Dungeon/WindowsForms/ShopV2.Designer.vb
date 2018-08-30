<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ShopV2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ShopV2))
        Me.btnDone = New System.Windows.Forms.Button()
        Me.lblSKG = New System.Windows.Forms.Label()
        Me.lblYG = New System.Windows.Forms.Label()
        Me.boxInventoryFilter = New System.Windows.Forms.TextBox()
        Me.number = New System.Windows.Forms.NumericUpDown()
        Me.btnSell = New System.Windows.Forms.Button()
        Me.boxInventory = New System.Windows.Forms.ListBox()
        Me.btnBuy = New System.Windows.Forms.Button()
        Me.lblInventory = New System.Windows.Forms.Label()
        Me.lblItems = New System.Windows.Forms.Label()
        Me.boxShopFilter = New System.Windows.Forms.TextBox()
        Me.boxShop = New System.Windows.Forms.ListBox()
        Me.lblPlayer = New System.Windows.Forms.Label()
        Me.lblShopkeeper = New System.Windows.Forms.Label()
        Me.btnInspect = New System.Windows.Forms.Button()
        CType(Me.number, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnDone
        '
        Me.btnDone.BackColor = System.Drawing.Color.Black
        Me.btnDone.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDone.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDone.ForeColor = System.Drawing.Color.White
        Me.btnDone.Location = New System.Drawing.Point(238, 446)
        Me.btnDone.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.Size = New System.Drawing.Size(158, 32)
        Me.btnDone.TabIndex = 20
        Me.btnDone.Text = "Done"
        Me.btnDone.UseVisualStyleBackColor = False
        '
        'lblSKG
        '
        Me.lblSKG.AutoSize = True
        Me.lblSKG.BackColor = System.Drawing.Color.Black
        Me.lblSKG.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSKG.ForeColor = System.Drawing.Color.White
        Me.lblSKG.Location = New System.Drawing.Point(417, 469)
        Me.lblSKG.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSKG.Name = "lblSKG"
        Me.lblSKG.Size = New System.Drawing.Size(79, 13)
        Me.lblSKG.TabIndex = 24
        Me.lblSKG.Text = "Gold: 999999"
        '
        'lblYG
        '
        Me.lblYG.AutoSize = True
        Me.lblYG.BackColor = System.Drawing.Color.Black
        Me.lblYG.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYG.ForeColor = System.Drawing.Color.White
        Me.lblYG.Location = New System.Drawing.Point(13, 469)
        Me.lblYG.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblYG.Name = "lblYG"
        Me.lblYG.Size = New System.Drawing.Size(79, 13)
        Me.lblYG.TabIndex = 25
        Me.lblYG.Text = "Gold: 999999"
        '
        'boxInventoryFilter
        '
        Me.boxInventoryFilter.BackColor = System.Drawing.Color.Black
        Me.boxInventoryFilter.Font = New System.Drawing.Font("Consolas", 10.0!)
        Me.boxInventoryFilter.ForeColor = System.Drawing.Color.White
        Me.boxInventoryFilter.Location = New System.Drawing.Point(10, 10)
        Me.boxInventoryFilter.Name = "boxInventoryFilter"
        Me.boxInventoryFilter.Size = New System.Drawing.Size(203, 23)
        Me.boxInventoryFilter.TabIndex = 194
        '
        'number
        '
        Me.number.BackColor = System.Drawing.Color.Black
        Me.number.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.number.ForeColor = System.Drawing.Color.White
        Me.number.Location = New System.Drawing.Point(273, 232)
        Me.number.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.number.Name = "number"
        Me.number.Size = New System.Drawing.Size(89, 26)
        Me.number.TabIndex = 192
        Me.number.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnSell
        '
        Me.btnSell.BackColor = System.Drawing.Color.Black
        Me.btnSell.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSell.ForeColor = System.Drawing.Color.White
        Me.btnSell.Location = New System.Drawing.Point(218, 289)
        Me.btnSell.Name = "btnSell"
        Me.btnSell.Size = New System.Drawing.Size(89, 36)
        Me.btnSell.TabIndex = 191
        Me.btnSell.Text = "Sell -->"
        Me.btnSell.UseVisualStyleBackColor = False
        '
        'boxInventory
        '
        Me.boxInventory.BackColor = System.Drawing.Color.Black
        Me.boxInventory.Font = New System.Drawing.Font("Consolas", 10.0!)
        Me.boxInventory.ForeColor = System.Drawing.Color.White
        Me.boxInventory.FormattingEnabled = True
        Me.boxInventory.ItemHeight = 15
        Me.boxInventory.Location = New System.Drawing.Point(10, 39)
        Me.boxInventory.Name = "boxInventory"
        Me.boxInventory.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.boxInventory.Size = New System.Drawing.Size(202, 424)
        Me.boxInventory.Sorted = True
        Me.boxInventory.TabIndex = 188
        '
        'btnBuy
        '
        Me.btnBuy.BackColor = System.Drawing.Color.Black
        Me.btnBuy.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuy.ForeColor = System.Drawing.Color.White
        Me.btnBuy.Location = New System.Drawing.Point(325, 162)
        Me.btnBuy.Name = "btnBuy"
        Me.btnBuy.Size = New System.Drawing.Size(89, 36)
        Me.btnBuy.TabIndex = 190
        Me.btnBuy.Text = "<-- Buy"
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
        'lblItems
        '
        Me.lblItems.AutoSize = True
        Me.lblItems.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblItems.ForeColor = System.Drawing.Color.White
        Me.lblItems.Location = New System.Drawing.Point(356, 494)
        Me.lblItems.Name = "lblItems"
        Me.lblItems.Size = New System.Drawing.Size(54, 19)
        Me.lblItems.TabIndex = 187
        Me.lblItems.Text = "ITEMS"
        '
        'boxShopFilter
        '
        Me.boxShopFilter.BackColor = System.Drawing.Color.Black
        Me.boxShopFilter.Font = New System.Drawing.Font("Consolas", 10.0!)
        Me.boxShopFilter.ForeColor = System.Drawing.Color.White
        Me.boxShopFilter.Location = New System.Drawing.Point(420, 10)
        Me.boxShopFilter.Name = "boxShopFilter"
        Me.boxShopFilter.Size = New System.Drawing.Size(202, 23)
        Me.boxShopFilter.TabIndex = 196
        '
        'boxShop
        '
        Me.boxShop.BackColor = System.Drawing.Color.Black
        Me.boxShop.Font = New System.Drawing.Font("Consolas", 10.0!)
        Me.boxShop.ForeColor = System.Drawing.Color.White
        Me.boxShop.FormattingEnabled = True
        Me.boxShop.ItemHeight = 15
        Me.boxShop.Location = New System.Drawing.Point(420, 39)
        Me.boxShop.Name = "boxShop"
        Me.boxShop.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.boxShop.Size = New System.Drawing.Size(202, 424)
        Me.boxShop.Sorted = True
        Me.boxShop.TabIndex = 195
        '
        'lblPlayer
        '
        Me.lblPlayer.AutoSize = True
        Me.lblPlayer.BackColor = System.Drawing.Color.Black
        Me.lblPlayer.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlayer.ForeColor = System.Drawing.Color.White
        Me.lblPlayer.Location = New System.Drawing.Point(220, 15)
        Me.lblPlayer.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPlayer.Name = "lblPlayer"
        Me.lblPlayer.Size = New System.Drawing.Size(25, 13)
        Me.lblPlayer.TabIndex = 197
        Me.lblPlayer.Text = "You"
        '
        'lblShopkeeper
        '
        Me.lblShopkeeper.AutoSize = True
        Me.lblShopkeeper.BackColor = System.Drawing.Color.Black
        Me.lblShopkeeper.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShopkeeper.ForeColor = System.Drawing.Color.White
        Me.lblShopkeeper.Location = New System.Drawing.Point(347, 15)
        Me.lblShopkeeper.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblShopkeeper.Name = "lblShopkeeper"
        Me.lblShopkeeper.Size = New System.Drawing.Size(67, 13)
        Me.lblShopkeeper.TabIndex = 198
        Me.lblShopkeeper.Text = "Shopkeeper"
        '
        'btnInspect
        '
        Me.btnInspect.BackColor = System.Drawing.Color.Black
        Me.btnInspect.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnInspect.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInspect.ForeColor = System.Drawing.Color.White
        Me.btnInspect.Location = New System.Drawing.Point(273, 369)
        Me.btnInspect.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnInspect.Name = "btnInspect"
        Me.btnInspect.Size = New System.Drawing.Size(89, 32)
        Me.btnInspect.TabIndex = 199
        Me.btnInspect.Text = "Inspect"
        Me.btnInspect.UseVisualStyleBackColor = False
        '
        'ShopV2
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(634, 491)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnInspect)
        Me.Controls.Add(Me.lblShopkeeper)
        Me.Controls.Add(Me.lblPlayer)
        Me.Controls.Add(Me.boxShopFilter)
        Me.Controls.Add(Me.boxShop)
        Me.Controls.Add(Me.boxInventoryFilter)
        Me.Controls.Add(Me.number)
        Me.Controls.Add(Me.btnSell)
        Me.Controls.Add(Me.boxInventory)
        Me.Controls.Add(Me.btnBuy)
        Me.Controls.Add(Me.lblInventory)
        Me.Controls.Add(Me.lblItems)
        Me.Controls.Add(Me.lblYG)
        Me.Controls.Add(Me.lblSKG)
        Me.Controls.Add(Me.btnDone)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ShopV2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Shop"
        CType(Me.number, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnDone As System.Windows.Forms.Button
    Friend WithEvents lblSKG As System.Windows.Forms.Label
    Friend WithEvents lblYG As System.Windows.Forms.Label
    Friend WithEvents boxInventoryFilter As TextBox
    Friend WithEvents number As NumericUpDown
    Friend WithEvents btnSell As Button
    Friend WithEvents boxInventory As ListBox
    Friend WithEvents btnBuy As Button
    Friend WithEvents lblInventory As Label
    Friend WithEvents lblItems As Label
    Friend WithEvents boxShopFilter As TextBox
    Friend WithEvents boxShop As ListBox
    Friend WithEvents lblPlayer As Label
    Friend WithEvents lblShopkeeper As Label
    Friend WithEvents btnInspect As Button
End Class
