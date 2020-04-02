<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CharacterGenerator
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CharacterGenerator))
        Me.picPort = New System.Windows.Forms.PictureBox()
        Me.btnFemale = New System.Windows.Forms.Button()
        Me.btnMale = New System.Windows.Forms.Button()
        Me.btnBody = New System.Windows.Forms.Button()
        Me.btnFace = New System.Windows.Forms.Button()
        Me.btnFHair = New System.Windows.Forms.Button()
        Me.btnBHair = New System.Windows.Forms.Button()
        Me.btnEars = New System.Windows.Forms.Button()
        Me.btnMark = New System.Windows.Forms.Button()
        Me.btnClothes = New System.Windows.Forms.Button()
        Me.btnCloak = New System.Windows.Forms.Button()
        Me.btnAcca = New System.Windows.Forms.Button()
        Me.pnlBody = New System.Windows.Forms.Panel()
        Me.btnGlasses = New System.Windows.Forms.Button()
        Me.btnEyes = New System.Windows.Forms.Button()
        Me.btnEyebrows = New System.Windows.Forms.Button()
        Me.btnMouth = New System.Windows.Forms.Button()
        Me.btnHat = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnHC = New System.Windows.Forms.Button()
        Me.btnSC = New System.Windows.Forms.Button()
        Me.btnRandom = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.chkSavePreset = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cBoxPresets = New System.Windows.Forms.ComboBox()
        CType(Me.picPort, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picPort
        '
        Me.picPort.BackgroundImage = CType(resources.GetObject("picPort.BackgroundImage"), System.Drawing.Image)
        Me.picPort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picPort.Image = CType(resources.GetObject("picPort.Image"), System.Drawing.Image)
        Me.picPort.Location = New System.Drawing.Point(10, 121)
        Me.picPort.Name = "picPort"
        Me.picPort.Size = New System.Drawing.Size(146, 217)
        Me.picPort.TabIndex = 0
        Me.picPort.TabStop = False
        '
        'btnFemale
        '
        Me.btnFemale.BackColor = System.Drawing.Color.DimGray
        Me.btnFemale.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFemale.ForeColor = System.Drawing.Color.White
        Me.btnFemale.Location = New System.Drawing.Point(304, 26)
        Me.btnFemale.Name = "btnFemale"
        Me.btnFemale.Size = New System.Drawing.Size(88, 31)
        Me.btnFemale.TabIndex = 1
        Me.btnFemale.Text = "Female"
        Me.btnFemale.UseVisualStyleBackColor = False
        '
        'btnMale
        '
        Me.btnMale.BackColor = System.Drawing.Color.DimGray
        Me.btnMale.Enabled = False
        Me.btnMale.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMale.ForeColor = System.Drawing.Color.White
        Me.btnMale.Location = New System.Drawing.Point(223, 26)
        Me.btnMale.Name = "btnMale"
        Me.btnMale.Size = New System.Drawing.Size(75, 31)
        Me.btnMale.TabIndex = 2
        Me.btnMale.Text = "Male"
        Me.btnMale.UseVisualStyleBackColor = False
        '
        'btnBody
        '
        Me.btnBody.BackColor = System.Drawing.Color.DimGray
        Me.btnBody.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBody.ForeColor = System.Drawing.Color.White
        Me.btnBody.Location = New System.Drawing.Point(166, 120)
        Me.btnBody.Name = "btnBody"
        Me.btnBody.Size = New System.Drawing.Size(89, 31)
        Me.btnBody.TabIndex = 3
        Me.btnBody.Text = "Body"
        Me.btnBody.UseVisualStyleBackColor = False
        '
        'btnFace
        '
        Me.btnFace.BackColor = System.Drawing.Color.DimGray
        Me.btnFace.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFace.ForeColor = System.Drawing.Color.White
        Me.btnFace.Location = New System.Drawing.Point(166, 157)
        Me.btnFace.Name = "btnFace"
        Me.btnFace.Size = New System.Drawing.Size(89, 31)
        Me.btnFace.TabIndex = 4
        Me.btnFace.Text = "Face"
        Me.btnFace.UseVisualStyleBackColor = False
        '
        'btnFHair
        '
        Me.btnFHair.BackColor = System.Drawing.Color.DimGray
        Me.btnFHair.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFHair.ForeColor = System.Drawing.Color.White
        Me.btnFHair.Location = New System.Drawing.Point(261, 120)
        Me.btnFHair.Name = "btnFHair"
        Me.btnFHair.Size = New System.Drawing.Size(126, 31)
        Me.btnFHair.TabIndex = 5
        Me.btnFHair.Text = "Front Hair"
        Me.btnFHair.UseVisualStyleBackColor = False
        '
        'btnBHair
        '
        Me.btnBHair.BackColor = System.Drawing.Color.DimGray
        Me.btnBHair.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBHair.ForeColor = System.Drawing.Color.White
        Me.btnBHair.Location = New System.Drawing.Point(261, 157)
        Me.btnBHair.Name = "btnBHair"
        Me.btnBHair.Size = New System.Drawing.Size(126, 31)
        Me.btnBHair.TabIndex = 6
        Me.btnBHair.Text = "Rear Hair"
        Me.btnBHair.UseVisualStyleBackColor = False
        '
        'btnEars
        '
        Me.btnEars.BackColor = System.Drawing.Color.DimGray
        Me.btnEars.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEars.ForeColor = System.Drawing.Color.White
        Me.btnEars.Location = New System.Drawing.Point(496, 157)
        Me.btnEars.Name = "btnEars"
        Me.btnEars.Size = New System.Drawing.Size(75, 31)
        Me.btnEars.TabIndex = 7
        Me.btnEars.Text = "Ears"
        Me.btnEars.UseVisualStyleBackColor = False
        '
        'btnMark
        '
        Me.btnMark.BackColor = System.Drawing.Color.DimGray
        Me.btnMark.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMark.ForeColor = System.Drawing.Color.White
        Me.btnMark.Location = New System.Drawing.Point(553, 120)
        Me.btnMark.Name = "btnMark"
        Me.btnMark.Size = New System.Drawing.Size(125, 31)
        Me.btnMark.TabIndex = 8
        Me.btnMark.Text = "Facial Mark"
        Me.btnMark.UseVisualStyleBackColor = False
        '
        'btnClothes
        '
        Me.btnClothes.BackColor = System.Drawing.Color.DimGray
        Me.btnClothes.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClothes.ForeColor = System.Drawing.Color.White
        Me.btnClothes.Location = New System.Drawing.Point(577, 157)
        Me.btnClothes.Name = "btnClothes"
        Me.btnClothes.Size = New System.Drawing.Size(101, 31)
        Me.btnClothes.TabIndex = 9
        Me.btnClothes.Text = "Clothes"
        Me.btnClothes.UseVisualStyleBackColor = False
        '
        'btnCloak
        '
        Me.btnCloak.BackColor = System.Drawing.Color.DimGray
        Me.btnCloak.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCloak.ForeColor = System.Drawing.Color.White
        Me.btnCloak.Location = New System.Drawing.Point(777, 157)
        Me.btnCloak.Name = "btnCloak"
        Me.btnCloak.Size = New System.Drawing.Size(83, 31)
        Me.btnCloak.TabIndex = 10
        Me.btnCloak.Text = "Cloak"
        Me.btnCloak.UseVisualStyleBackColor = False
        '
        'btnAcca
        '
        Me.btnAcca.BackColor = System.Drawing.Color.DimGray
        Me.btnAcca.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAcca.ForeColor = System.Drawing.Color.White
        Me.btnAcca.Location = New System.Drawing.Point(684, 120)
        Me.btnAcca.Name = "btnAcca"
        Me.btnAcca.Size = New System.Drawing.Size(105, 31)
        Me.btnAcca.TabIndex = 11
        Me.btnAcca.Text = "Accessory"
        Me.btnAcca.UseVisualStyleBackColor = False
        '
        'pnlBody
        '
        Me.pnlBody.AutoScroll = True
        Me.pnlBody.BackColor = System.Drawing.Color.Gray
        Me.pnlBody.Location = New System.Drawing.Point(180, 197)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.Size = New System.Drawing.Size(659, 140)
        Me.pnlBody.TabIndex = 13
        '
        'btnGlasses
        '
        Me.btnGlasses.BackColor = System.Drawing.Color.DimGray
        Me.btnGlasses.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGlasses.ForeColor = System.Drawing.Color.White
        Me.btnGlasses.Location = New System.Drawing.Point(684, 157)
        Me.btnGlasses.Name = "btnGlasses"
        Me.btnGlasses.Size = New System.Drawing.Size(87, 31)
        Me.btnGlasses.TabIndex = 14
        Me.btnGlasses.Text = "Glasses"
        Me.btnGlasses.UseVisualStyleBackColor = False
        '
        'btnEyes
        '
        Me.btnEyes.BackColor = System.Drawing.Color.DimGray
        Me.btnEyes.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEyes.ForeColor = System.Drawing.Color.White
        Me.btnEyes.Location = New System.Drawing.Point(391, 120)
        Me.btnEyes.Name = "btnEyes"
        Me.btnEyes.Size = New System.Drawing.Size(75, 31)
        Me.btnEyes.TabIndex = 15
        Me.btnEyes.Text = "Eyes"
        Me.btnEyes.UseVisualStyleBackColor = False
        '
        'btnEyebrows
        '
        Me.btnEyebrows.BackColor = System.Drawing.Color.DimGray
        Me.btnEyebrows.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEyebrows.ForeColor = System.Drawing.Color.White
        Me.btnEyebrows.Location = New System.Drawing.Point(391, 157)
        Me.btnEyebrows.Name = "btnEyebrows"
        Me.btnEyebrows.Size = New System.Drawing.Size(101, 31)
        Me.btnEyebrows.TabIndex = 16
        Me.btnEyebrows.Text = "Eyebrows"
        Me.btnEyebrows.UseVisualStyleBackColor = False
        '
        'btnMouth
        '
        Me.btnMouth.BackColor = System.Drawing.Color.DimGray
        Me.btnMouth.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMouth.ForeColor = System.Drawing.Color.White
        Me.btnMouth.Location = New System.Drawing.Point(472, 120)
        Me.btnMouth.Name = "btnMouth"
        Me.btnMouth.Size = New System.Drawing.Size(75, 31)
        Me.btnMouth.TabIndex = 17
        Me.btnMouth.Text = "Mouth"
        Me.btnMouth.UseVisualStyleBackColor = False
        '
        'btnHat
        '
        Me.btnHat.BackColor = System.Drawing.Color.DimGray
        Me.btnHat.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHat.ForeColor = System.Drawing.Color.White
        Me.btnHat.Location = New System.Drawing.Point(795, 120)
        Me.btnHat.Name = "btnHat"
        Me.btnHat.Size = New System.Drawing.Size(65, 31)
        Me.btnHat.TabIndex = 18
        Me.btnHat.Text = "Hat"
        Me.btnHat.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.DimGray
        Me.btnSave.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(385, 353)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(212, 31)
        Me.btnSave.TabIndex = 19
        Me.btnSave.Text = "Confirm Character"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnHC
        '
        Me.btnHC.BackColor = System.Drawing.Color.DimGray
        Me.btnHC.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHC.ForeColor = System.Drawing.Color.White
        Me.btnHC.Location = New System.Drawing.Point(223, 80)
        Me.btnHC.Name = "btnHC"
        Me.btnHC.Size = New System.Drawing.Size(112, 31)
        Me.btnHC.TabIndex = 20
        Me.btnHC.Text = "Hair Color"
        Me.btnHC.UseVisualStyleBackColor = False
        '
        'btnSC
        '
        Me.btnSC.BackColor = System.Drawing.Color.DimGray
        Me.btnSC.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSC.ForeColor = System.Drawing.Color.White
        Me.btnSC.Location = New System.Drawing.Point(341, 80)
        Me.btnSC.Name = "btnSC"
        Me.btnSC.Size = New System.Drawing.Size(112, 31)
        Me.btnSC.TabIndex = 21
        Me.btnSC.Text = "Skin Color"
        Me.btnSC.UseVisualStyleBackColor = False
        '
        'btnRandom
        '
        Me.btnRandom.BackColor = System.Drawing.Color.DimGray
        Me.btnRandom.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRandom.ForeColor = System.Drawing.Color.White
        Me.btnRandom.Location = New System.Drawing.Point(12, 353)
        Me.btnRandom.Name = "btnRandom"
        Me.btnRandom.Size = New System.Drawing.Size(146, 31)
        Me.btnRandom.TabIndex = 22
        Me.btnRandom.Text = "Randomize"
        Me.btnRandom.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.Black
        Me.TextBox1.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.White
        Me.TextBox1.Location = New System.Drawing.Point(12, 31)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(196, 23)
        Me.TextBox1.TabIndex = 24
        Me.TextBox1.Text = "Alex"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(8, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 17)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Name:"
        '
        'ComboBox2
        '
        Me.ComboBox2.BackColor = System.Drawing.Color.Black
        Me.ComboBox2.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox2.ForeColor = System.Drawing.Color.White
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(12, 84)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(196, 23)
        Me.ComboBox2.TabIndex = 26
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(8, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 17)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Class:"
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.DimGray
        Me.btnBack.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.ForeColor = System.Drawing.Color.White
        Me.btnBack.Location = New System.Drawing.Point(777, 12)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(88, 31)
        Me.btnBack.TabIndex = 27
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'chkSavePreset
        '
        Me.chkSavePreset.AutoSize = True
        Me.chkSavePreset.BackColor = System.Drawing.Color.Black
        Me.chkSavePreset.Font = New System.Drawing.Font("Consolas", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSavePreset.ForeColor = System.Drawing.Color.White
        Me.chkSavePreset.Location = New System.Drawing.Point(611, 357)
        Me.chkSavePreset.Name = "chkSavePreset"
        Me.chkSavePreset.Size = New System.Drawing.Size(142, 21)
        Me.chkSavePreset.TabIndex = 28
        Me.chkSavePreset.Text = "Save As Preset"
        Me.chkSavePreset.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(511, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 17)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Preset:"
        '
        'cBoxPresets
        '
        Me.cBoxPresets.BackColor = System.Drawing.Color.Black
        Me.cBoxPresets.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cBoxPresets.ForeColor = System.Drawing.Color.White
        Me.cBoxPresets.FormattingEnabled = True
        Me.cBoxPresets.Items.AddRange(New Object() {"--- (none) ---"})
        Me.cBoxPresets.Location = New System.Drawing.Point(514, 26)
        Me.cBoxPresets.Name = "cBoxPresets"
        Me.cBoxPresets.Size = New System.Drawing.Size(196, 23)
        Me.cBoxPresets.TabIndex = 30
        Me.cBoxPresets.Text = "--- (none) ---"
        '
        'CharacterGenerator
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(877, 396)
        Me.ControlBox = False
        Me.Controls.Add(Me.cBoxPresets)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chkSavePreset)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnRandom)
        Me.Controls.Add(Me.btnSC)
        Me.Controls.Add(Me.btnHC)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnHat)
        Me.Controls.Add(Me.btnMouth)
        Me.Controls.Add(Me.btnEyebrows)
        Me.Controls.Add(Me.btnEyes)
        Me.Controls.Add(Me.btnGlasses)
        Me.Controls.Add(Me.pnlBody)
        Me.Controls.Add(Me.btnAcca)
        Me.Controls.Add(Me.btnCloak)
        Me.Controls.Add(Me.btnClothes)
        Me.Controls.Add(Me.btnMark)
        Me.Controls.Add(Me.btnEars)
        Me.Controls.Add(Me.btnBHair)
        Me.Controls.Add(Me.btnFHair)
        Me.Controls.Add(Me.btnFace)
        Me.Controls.Add(Me.btnBody)
        Me.Controls.Add(Me.btnMale)
        Me.Controls.Add(Me.btnFemale)
        Me.Controls.Add(Me.picPort)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "CharacterGenerator"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = " "
        CType(Me.picPort, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents picPort As System.Windows.Forms.PictureBox
    Friend WithEvents btnFemale As System.Windows.Forms.Button
    Friend WithEvents btnMale As System.Windows.Forms.Button
    Friend WithEvents btnBody As System.Windows.Forms.Button
    Friend WithEvents btnFace As System.Windows.Forms.Button
    Friend WithEvents btnFHair As System.Windows.Forms.Button
    Friend WithEvents btnBHair As System.Windows.Forms.Button
    Friend WithEvents btnEars As System.Windows.Forms.Button
    Friend WithEvents btnMark As System.Windows.Forms.Button
    Friend WithEvents btnClothes As System.Windows.Forms.Button
    Friend WithEvents btnCloak As System.Windows.Forms.Button
    Friend WithEvents btnAcca As System.Windows.Forms.Button
    Friend WithEvents pnlBody As System.Windows.Forms.Panel
    Friend WithEvents btnGlasses As System.Windows.Forms.Button
    Friend WithEvents btnEyes As System.Windows.Forms.Button
    Friend WithEvents btnEyebrows As System.Windows.Forms.Button
    Friend WithEvents btnMouth As System.Windows.Forms.Button
    Friend WithEvents btnHat As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnHC As System.Windows.Forms.Button
    Friend WithEvents btnSC As System.Windows.Forms.Button
    Friend WithEvents btnRandom As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnBack As Button
    Friend WithEvents chkSavePreset As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cBoxPresets As System.Windows.Forms.ComboBox
End Class
