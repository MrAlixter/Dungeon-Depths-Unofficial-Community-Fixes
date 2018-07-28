<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Shop
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Shop))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblSKG = New System.Windows.Forms.Label()
        Me.lblYG = New System.Windows.Forms.Label()
        Me.cBoxBuy = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cBoxSell = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnBuy = New System.Windows.Forms.Button()
        Me.btnSell = New System.Windows.Forms.Button()
        Me.cBoxBuyQTY = New System.Windows.Forms.ComboBox()
        Me.cBoxSellQTY = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(40, 247)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(345, 32)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "Done"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'lblSKG
        '
        Me.lblSKG.AutoSize = True
        Me.lblSKG.BackColor = System.Drawing.Color.Black
        Me.lblSKG.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSKG.ForeColor = System.Drawing.Color.White
        Me.lblSKG.Location = New System.Drawing.Point(36, 21)
        Me.lblSKG.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSKG.Name = "lblSKG"
        Me.lblSKG.Size = New System.Drawing.Size(157, 13)
        Me.lblSKG.TabIndex = 24
        Me.lblSKG.Text = "Shopkeeper Gold: = 999999"
        '
        'lblYG
        '
        Me.lblYG.AutoSize = True
        Me.lblYG.BackColor = System.Drawing.Color.Black
        Me.lblYG.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYG.ForeColor = System.Drawing.Color.White
        Me.lblYG.Location = New System.Drawing.Point(36, 53)
        Me.lblYG.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblYG.Name = "lblYG"
        Me.lblYG.Size = New System.Drawing.Size(121, 13)
        Me.lblYG.TabIndex = 25
        Me.lblYG.Text = "Your Gold: = 999999"
        '
        'cBoxBuy
        '
        Me.cBoxBuy.BackColor = System.Drawing.Color.Black
        Me.cBoxBuy.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cBoxBuy.ForeColor = System.Drawing.Color.White
        Me.cBoxBuy.FormattingEnabled = True
        Me.cBoxBuy.Location = New System.Drawing.Point(40, 118)
        Me.cBoxBuy.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cBoxBuy.Name = "cBoxBuy"
        Me.cBoxBuy.Size = New System.Drawing.Size(206, 21)
        Me.cBoxBuy.TabIndex = 19
        Me.cBoxBuy.Text = "-- Select --"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(36, 94)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Buy:"
        '
        'cBoxSell
        '
        Me.cBoxSell.BackColor = System.Drawing.Color.Black
        Me.cBoxSell.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cBoxSell.ForeColor = System.Drawing.Color.White
        Me.cBoxSell.FormattingEnabled = True
        Me.cBoxSell.Location = New System.Drawing.Point(40, 192)
        Me.cBoxSell.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cBoxSell.Name = "cBoxSell"
        Me.cBoxSell.Size = New System.Drawing.Size(206, 21)
        Me.cBoxSell.TabIndex = 22
        Me.cBoxSell.Text = "-- Select --"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(36, 168)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Sell:"
        '
        'btnBuy
        '
        Me.btnBuy.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnBuy.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuy.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuy.ForeColor = System.Drawing.Color.Black
        Me.btnBuy.Location = New System.Drawing.Point(254, 118)
        Me.btnBuy.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnBuy.Name = "btnBuy"
        Me.btnBuy.Size = New System.Drawing.Size(69, 32)
        Me.btnBuy.TabIndex = 26
        Me.btnBuy.Text = "Buy"
        Me.btnBuy.UseVisualStyleBackColor = False
        '
        'btnSell
        '
        Me.btnSell.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnSell.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSell.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSell.ForeColor = System.Drawing.Color.Black
        Me.btnSell.Location = New System.Drawing.Point(254, 192)
        Me.btnSell.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSell.Name = "btnSell"
        Me.btnSell.Size = New System.Drawing.Size(69, 32)
        Me.btnSell.TabIndex = 27
        Me.btnSell.Text = "Sell"
        Me.btnSell.UseVisualStyleBackColor = False
        '
        'cBoxBuyQTY
        '
        Me.cBoxBuyQTY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cBoxBuyQTY.FormattingEnabled = True
        Me.cBoxBuyQTY.Location = New System.Drawing.Point(330, 117)
        Me.cBoxBuyQTY.Name = "cBoxBuyQTY"
        Me.cBoxBuyQTY.Size = New System.Drawing.Size(55, 21)
        Me.cBoxBuyQTY.TabIndex = 28
        '
        'cBoxSellQTY
        '
        Me.cBoxSellQTY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cBoxSellQTY.FormattingEnabled = True
        Me.cBoxSellQTY.Location = New System.Drawing.Point(330, 191)
        Me.cBoxSellQTY.Name = "cBoxSellQTY"
        Me.cBoxSellQTY.Size = New System.Drawing.Size(55, 21)
        Me.cBoxSellQTY.TabIndex = 29
        '
        'Shop
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(422, 293)
        Me.ControlBox = False
        Me.Controls.Add(Me.cBoxSellQTY)
        Me.Controls.Add(Me.cBoxBuyQTY)
        Me.Controls.Add(Me.btnSell)
        Me.Controls.Add(Me.btnBuy)
        Me.Controls.Add(Me.lblYG)
        Me.Controls.Add(Me.lblSKG)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cBoxSell)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cBoxBuy)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Shop"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Shop"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblSKG As System.Windows.Forms.Label
    Friend WithEvents lblYG As System.Windows.Forms.Label
    Friend WithEvents cBoxBuy As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cBoxSell As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnBuy As Button
    Friend WithEvents btnSell As Button
    Friend WithEvents cBoxBuyQTY As ComboBox
    Friend WithEvents cBoxSellQTY As ComboBox
End Class
