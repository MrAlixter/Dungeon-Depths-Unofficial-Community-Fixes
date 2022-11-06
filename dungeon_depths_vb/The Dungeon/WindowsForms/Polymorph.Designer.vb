<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Polymorph
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Polymorph))
        Me.lblPolymorphTo = New System.Windows.Forms.Label()
        Me.btnPolymorphOK = New System.Windows.Forms.Button()
        Me.cboxPolymorph = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'lblPolymorphTo
        '
        Me.lblPolymorphTo.AutoSize = True
        Me.lblPolymorphTo.BackColor = System.Drawing.Color.Black
        Me.lblPolymorphTo.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPolymorphTo.ForeColor = System.Drawing.Color.White
        Me.lblPolymorphTo.Location = New System.Drawing.Point(40, 15)
        Me.lblPolymorphTo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPolymorphTo.Name = "lblPolymorphTo"
        Me.lblPolymorphTo.Size = New System.Drawing.Size(85, 13)
        Me.lblPolymorphTo.TabIndex = 18
        Me.lblPolymorphTo.Text = "Polymorph to:"
        '
        'btnPolymorphOK
        '
        Me.btnPolymorphOK.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnPolymorphOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPolymorphOK.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPolymorphOK.ForeColor = System.Drawing.Color.Black
        Me.btnPolymorphOK.Location = New System.Drawing.Point(98, 76)
        Me.btnPolymorphOK.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnPolymorphOK.Name = "btnPolymorphOK"
        Me.btnPolymorphOK.Size = New System.Drawing.Size(89, 32)
        Me.btnPolymorphOK.TabIndex = 17
        Me.btnPolymorphOK.Text = "OK"
        Me.btnPolymorphOK.UseVisualStyleBackColor = False
        '
        'cboxPolymorph
        '
        Me.cboxPolymorph.BackColor = System.Drawing.Color.Black
        Me.cboxPolymorph.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboxPolymorph.ForeColor = System.Drawing.Color.White
        Me.cboxPolymorph.FormattingEnabled = True
        Me.cboxPolymorph.Location = New System.Drawing.Point(44, 39)
        Me.cboxPolymorph.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboxPolymorph.Name = "cboxPolymorph"
        Me.cboxPolymorph.Size = New System.Drawing.Size(199, 21)
        Me.cboxPolymorph.TabIndex = 16
        Me.cboxPolymorph.Text = "-- Select --"
        '
        'Polymorph
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(291, 131)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblPolymorphTo)
        Me.Controls.Add(Me.btnPolymorphOK)
        Me.Controls.Add(Me.cboxPolymorph)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Polymorph"
        Me.Text = "Polymorph"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblPolymorphTo As System.Windows.Forms.Label
    Friend WithEvents btnPolymorphOK As System.Windows.Forms.Button
    Friend WithEvents cboxPolymorph As System.Windows.Forms.ComboBox
End Class
