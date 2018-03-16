<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditContents
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
        Me.boxContents = New System.Windows.Forms.ListBox()
        Me.boxItems = New System.Windows.Forms.ListBox()
        Me.btnSub = New System.Windows.Forms.Button()
        Me.boxAmt = New System.Windows.Forms.NumericUpDown()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lblContents = New System.Windows.Forms.Label()
        Me.lblItems = New System.Windows.Forms.Label()
        CType(Me.boxAmt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'boxContents
        '
        Me.boxContents.BackColor = System.Drawing.Color.Black
        Me.boxContents.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.boxContents.ForeColor = System.Drawing.Color.White
        Me.boxContents.FormattingEnabled = True
        Me.boxContents.ItemHeight = 19
        Me.boxContents.Location = New System.Drawing.Point(12, 12)
        Me.boxContents.Name = "boxContents"
        Me.boxContents.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.boxContents.Size = New System.Drawing.Size(260, 384)
        Me.boxContents.TabIndex = 0
        '
        'boxItems
        '
        Me.boxItems.BackColor = System.Drawing.Color.Black
        Me.boxItems.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.boxItems.ForeColor = System.Drawing.Color.White
        Me.boxItems.FormattingEnabled = True
        Me.boxItems.ItemHeight = 19
        Me.boxItems.Location = New System.Drawing.Point(412, 15)
        Me.boxItems.Name = "boxItems"
        Me.boxItems.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.boxItems.Size = New System.Drawing.Size(260, 384)
        Me.boxItems.TabIndex = 1
        '
        'btnSub
        '
        Me.btnSub.BackColor = System.Drawing.Color.Black
        Me.btnSub.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.btnSub.Location = New System.Drawing.Point(278, 224)
        Me.btnSub.Name = "btnSub"
        Me.btnSub.Size = New System.Drawing.Size(50, 29)
        Me.btnSub.TabIndex = 2
        Me.btnSub.Text = "-->"
        Me.btnSub.UseVisualStyleBackColor = False
        '
        'boxAmt
        '
        Me.boxAmt.BackColor = System.Drawing.Color.Black
        Me.boxAmt.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.boxAmt.ForeColor = System.Drawing.Color.White
        Me.boxAmt.Location = New System.Drawing.Point(298, 192)
        Me.boxAmt.Name = "boxAmt"
        Me.boxAmt.Size = New System.Drawing.Size(89, 26)
        Me.boxAmt.TabIndex = 3
        Me.boxAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.Black
        Me.btnAdd.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.btnAdd.Location = New System.Drawing.Point(356, 157)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(50, 29)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "<--"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'lblContents
        '
        Me.lblContents.AutoSize = True
        Me.lblContents.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContents.Location = New System.Drawing.Point(274, 15)
        Me.lblContents.Name = "lblContents"
        Me.lblContents.Size = New System.Drawing.Size(81, 19)
        Me.lblContents.TabIndex = 5
        Me.lblContents.Text = "CONTENTS"
        '
        'lblItems
        '
        Me.lblItems.AutoSize = True
        Me.lblItems.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItems.Location = New System.Drawing.Point(352, 377)
        Me.lblItems.Name = "lblItems"
        Me.lblItems.Size = New System.Drawing.Size(54, 19)
        Me.lblItems.TabIndex = 6
        Me.lblItems.Text = "ITEMS"
        '
        'EditContents
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(684, 411)
        Me.Controls.Add(Me.lblItems)
        Me.Controls.Add(Me.lblContents)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.boxAmt)
        Me.Controls.Add(Me.btnSub)
        Me.Controls.Add(Me.boxItems)
        Me.Controls.Add(Me.boxContents)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "EditContents"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edit Contents of Chest"
        CType(Me.boxAmt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents boxContents As ListBox
    Friend WithEvents boxItems As ListBox
    Friend WithEvents btnSub As Button
    Friend WithEvents boxAmt As NumericUpDown
    Friend WithEvents btnAdd As Button
    Friend WithEvents lblContents As Label
    Friend WithEvents lblItems As Label
End Class
