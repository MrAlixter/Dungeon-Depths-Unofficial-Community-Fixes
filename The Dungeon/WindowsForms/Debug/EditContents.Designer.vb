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
        Me.boxContents.Size = New System.Drawing.Size(260, 232)
        Me.boxContents.TabIndex = 0
        '
        'EditContents
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.boxContents)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "EditContents"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edit Contents of Chest"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents boxContents As ListBox
End Class
