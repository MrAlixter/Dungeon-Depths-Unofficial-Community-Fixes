<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditTile
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
        Me.lblPosition = New System.Windows.Forms.Label()
        Me.lblTag = New System.Windows.Forms.Label()
        Me.lblText = New System.Windows.Forms.Label()
        Me.lblCol = New System.Windows.Forms.Label()
        Me.lblType = New System.Windows.Forms.Label()
        Me.boxOptions = New System.Windows.Forms.GroupBox()
        Me.boxSeen = New System.Windows.Forms.CheckBox()
        Me.boxType = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'lblPosition
        '
        Me.lblPosition.AutoSize = True
        Me.lblPosition.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPosition.ForeColor = System.Drawing.Color.White
        Me.lblPosition.Location = New System.Drawing.Point(10, 39)
        Me.lblPosition.Name = "lblPosition"
        Me.lblPosition.Size = New System.Drawing.Size(135, 19)
        Me.lblPosition.TabIndex = 0
        Me.lblPosition.Text = "POSITION: 0, 0"
        '
        'lblTag
        '
        Me.lblTag.AutoSize = True
        Me.lblTag.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTag.ForeColor = System.Drawing.Color.White
        Me.lblTag.Location = New System.Drawing.Point(10, 58)
        Me.lblTag.Name = "lblTag"
        Me.lblTag.Size = New System.Drawing.Size(54, 19)
        Me.lblTag.TabIndex = 1
        Me.lblTag.Text = "TAG: "
        '
        'lblText
        '
        Me.lblText.AutoSize = True
        Me.lblText.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblText.ForeColor = System.Drawing.Color.White
        Me.lblText.Location = New System.Drawing.Point(10, 77)
        Me.lblText.Name = "lblText"
        Me.lblText.Size = New System.Drawing.Size(63, 19)
        Me.lblText.TabIndex = 2
        Me.lblText.Text = "TEXT: "
        '
        'lblCol
        '
        Me.lblCol.AutoSize = True
        Me.lblCol.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCol.ForeColor = System.Drawing.Color.White
        Me.lblCol.Location = New System.Drawing.Point(12, 96)
        Me.lblCol.Name = "lblCol"
        Me.lblCol.Size = New System.Drawing.Size(54, 19)
        Me.lblCol.TabIndex = 3
        Me.lblCol.Text = "COL: "
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblType.ForeColor = System.Drawing.Color.White
        Me.lblType.Location = New System.Drawing.Point(10, 15)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(63, 19)
        Me.lblType.TabIndex = 4
        Me.lblType.Text = "TYPE: "
        '
        'boxOptions
        '
        Me.boxOptions.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.boxOptions.ForeColor = System.Drawing.Color.White
        Me.boxOptions.Location = New System.Drawing.Point(16, 136)
        Me.boxOptions.Name = "boxOptions"
        Me.boxOptions.Size = New System.Drawing.Size(256, 113)
        Me.boxOptions.TabIndex = 6
        Me.boxOptions.TabStop = False
        Me.boxOptions.Text = "OPTIONS"
        '
        'boxSeen
        '
        Me.boxSeen.AutoSize = True
        Me.boxSeen.BackColor = System.Drawing.Color.Black
        Me.boxSeen.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.boxSeen.ForeColor = System.Drawing.Color.White
        Me.boxSeen.Location = New System.Drawing.Point(208, 58)
        Me.boxSeen.Name = "boxSeen"
        Me.boxSeen.Size = New System.Drawing.Size(64, 23)
        Me.boxSeen.TabIndex = 7
        Me.boxSeen.Text = "SEEN"
        Me.boxSeen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.boxSeen.UseVisualStyleBackColor = False
        '
        'boxType
        '
        Me.boxType.BackColor = System.Drawing.Color.Black
        Me.boxType.Font = New System.Drawing.Font("Consolas", 10.0!)
        Me.boxType.ForeColor = System.Drawing.Color.White
        Me.boxType.FormattingEnabled = True
        Me.boxType.Location = New System.Drawing.Point(59, 14)
        Me.boxType.Name = "boxType"
        Me.boxType.Size = New System.Drawing.Size(121, 23)
        Me.boxType.TabIndex = 8
        '
        'EditTile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.boxType)
        Me.Controls.Add(Me.boxSeen)
        Me.Controls.Add(Me.boxOptions)
        Me.Controls.Add(Me.lblType)
        Me.Controls.Add(Me.lblCol)
        Me.Controls.Add(Me.lblText)
        Me.Controls.Add(Me.lblTag)
        Me.Controls.Add(Me.lblPosition)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "EditTile"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edit Tile"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblPosition As Label
    Friend WithEvents lblTag As Label
    Friend WithEvents lblText As Label
    Friend WithEvents lblCol As Label
    Friend WithEvents lblType As Label
    Friend WithEvents boxOptions As GroupBox
    Friend WithEvents boxSeen As CheckBox
    Friend WithEvents boxType As ComboBox
End Class
