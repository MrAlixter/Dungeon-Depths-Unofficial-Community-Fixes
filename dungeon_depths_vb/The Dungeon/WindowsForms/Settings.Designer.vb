<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Settings))
        Me.btnSettingsOK = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboxScreenSize = New System.Windows.Forms.ComboBox()
        Me.chkNoImg = New System.Windows.Forms.CheckBox()
        Me.chkAlwaysUnwilling = New System.Windows.Forms.CheckBox()
        Me.chkNoRNG = New System.Windows.Forms.CheckBox()
        Me.chkOldSpellSpec = New System.Windows.Forms.CheckBox()
        Me.chkStartWithBooks = New System.Windows.Forms.CheckBox()
        Me.chkEoverSS = New System.Windows.Forms.CheckBox()
        Me.chkTextColor = New System.Windows.Forms.CheckBox()
        Me.btnAdv = New System.Windows.Forms.Button()
        Me.tabAdvSettings = New System.Windows.Forms.TabControl()
        Me.tabSpawnRates = New System.Windows.Forms.TabPage()
        Me.tabIsoMaps = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.picSampleIsotile = New System.Windows.Forms.PictureBox()
        Me.chkMakeIso = New System.Windows.Forms.CheckBox()
        Me.chkBimboNames = New System.Windows.Forms.CheckBox()
        Me.chkOldLoot = New System.Windows.Forms.CheckBox()
        Me.tabSeasonalOverride = New System.Windows.Forms.TabPage()
        Me.tabAdvSettings.SuspendLayout()
        Me.tabIsoMaps.SuspendLayout()
        CType(Me.picSampleIsotile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSettingsOK
        '
        Me.btnSettingsOK.BackgroundImage = CType(resources.GetObject("btnSettingsOK.BackgroundImage"), System.Drawing.Image)
        Me.btnSettingsOK.Font = New System.Drawing.Font("Consolas", 8.150944!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSettingsOK.ForeColor = System.Drawing.Color.White
        Me.btnSettingsOK.Location = New System.Drawing.Point(185, 525)
        Me.btnSettingsOK.Name = "btnSettingsOK"
        Me.btnSettingsOK.Size = New System.Drawing.Size(75, 30)
        Me.btnSettingsOK.TabIndex = 0
        Me.btnSettingsOK.Text = "Ok"
        Me.btnSettingsOK.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(13, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 17)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Window Size:"
        '
        'cboxScreenSize
        '
        Me.cboxScreenSize.BackColor = System.Drawing.Color.Black
        Me.cboxScreenSize.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboxScreenSize.ForeColor = System.Drawing.Color.White
        Me.cboxScreenSize.FormattingEnabled = True
        Me.cboxScreenSize.Location = New System.Drawing.Point(17, 33)
        Me.cboxScreenSize.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboxScreenSize.Name = "cboxScreenSize"
        Me.cboxScreenSize.Size = New System.Drawing.Size(199, 25)
        Me.cboxScreenSize.TabIndex = 19
        Me.cboxScreenSize.Text = "-- Select --"
        '
        'chkNoImg
        '
        Me.chkNoImg.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkNoImg.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black
        Me.chkNoImg.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.chkNoImg.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.chkNoImg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkNoImg.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNoImg.ForeColor = System.Drawing.Color.White
        Me.chkNoImg.Location = New System.Drawing.Point(17, 78)
        Me.chkNoImg.Name = "chkNoImg"
        Me.chkNoImg.Size = New System.Drawing.Size(251, 21)
        Me.chkNoImg.TabIndex = 21
        Me.chkNoImg.Text = "Load without images"
        Me.chkNoImg.UseVisualStyleBackColor = True
        '
        'chkAlwaysUnwilling
        '
        Me.chkAlwaysUnwilling.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkAlwaysUnwilling.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black
        Me.chkAlwaysUnwilling.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.chkAlwaysUnwilling.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.chkAlwaysUnwilling.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkAlwaysUnwilling.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAlwaysUnwilling.ForeColor = System.Drawing.Color.White
        Me.chkAlwaysUnwilling.Location = New System.Drawing.Point(16, 107)
        Me.chkAlwaysUnwilling.Name = "chkAlwaysUnwilling"
        Me.chkAlwaysUnwilling.Size = New System.Drawing.Size(251, 55)
        Me.chkAlwaysUnwilling.TabIndex = 22
        Me.chkAlwaysUnwilling.Text = "If an encounter checks WIL, assume the highest possible (does not apply to combat" & _
    ")"
        Me.chkAlwaysUnwilling.UseVisualStyleBackColor = True
        '
        'chkNoRNG
        '
        Me.chkNoRNG.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkNoRNG.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black
        Me.chkNoRNG.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.chkNoRNG.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.chkNoRNG.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkNoRNG.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNoRNG.ForeColor = System.Drawing.Color.White
        Me.chkNoRNG.Location = New System.Drawing.Point(16, 174)
        Me.chkNoRNG.Name = "chkNoRNG"
        Me.chkNoRNG.Size = New System.Drawing.Size(251, 38)
        Me.chkNoRNG.TabIndex = 23
        Me.chkNoRNG.Text = "Reduce RNG in transformative items and quest acquisition"
        Me.chkNoRNG.UseVisualStyleBackColor = True
        '
        'chkOldSpellSpec
        '
        Me.chkOldSpellSpec.Checked = True
        Me.chkOldSpellSpec.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOldSpellSpec.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkOldSpellSpec.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black
        Me.chkOldSpellSpec.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.chkOldSpellSpec.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.chkOldSpellSpec.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkOldSpellSpec.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOldSpellSpec.ForeColor = System.Drawing.Color.White
        Me.chkOldSpellSpec.Location = New System.Drawing.Point(16, 226)
        Me.chkOldSpellSpec.Name = "chkOldSpellSpec"
        Me.chkOldSpellSpec.Size = New System.Drawing.Size(251, 38)
        Me.chkOldSpellSpec.TabIndex = 24
        Me.chkOldSpellSpec.Text = "Use the old spell/special" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "selection window"
        Me.chkOldSpellSpec.UseVisualStyleBackColor = True
        '
        'chkStartWithBooks
        '
        Me.chkStartWithBooks.Checked = True
        Me.chkStartWithBooks.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkStartWithBooks.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkStartWithBooks.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black
        Me.chkStartWithBooks.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.chkStartWithBooks.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.chkStartWithBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkStartWithBooks.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkStartWithBooks.ForeColor = System.Drawing.Color.White
        Me.chkStartWithBooks.Location = New System.Drawing.Point(17, 278)
        Me.chkStartWithBooks.Name = "chkStartWithBooks"
        Me.chkStartWithBooks.Size = New System.Drawing.Size(251, 38)
        Me.chkStartWithBooks.TabIndex = 25
        Me.chkStartWithBooks.Text = "Start with spell/special books"
        Me.chkStartWithBooks.UseVisualStyleBackColor = True
        '
        'chkEoverSS
        '
        Me.chkEoverSS.Checked = True
        Me.chkEoverSS.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEoverSS.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkEoverSS.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black
        Me.chkEoverSS.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.chkEoverSS.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.chkEoverSS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkEoverSS.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEoverSS.ForeColor = System.Drawing.Color.White
        Me.chkEoverSS.Location = New System.Drawing.Point(17, 329)
        Me.chkEoverSS.Name = "chkEoverSS"
        Me.chkEoverSS.Size = New System.Drawing.Size(251, 38)
        Me.chkEoverSS.TabIndex = 26
        Me.chkEoverSS.Text = "Enemies can overwrite the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "player's starting form"
        Me.chkEoverSS.UseVisualStyleBackColor = True
        '
        'chkTextColor
        '
        Me.chkTextColor.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkTextColor.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black
        Me.chkTextColor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.chkTextColor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.chkTextColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkTextColor.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTextColor.ForeColor = System.Drawing.Color.White
        Me.chkTextColor.Location = New System.Drawing.Point(17, 385)
        Me.chkTextColor.Name = "chkTextColor"
        Me.chkTextColor.Size = New System.Drawing.Size(251, 38)
        Me.chkTextColor.TabIndex = 28
        Me.chkTextColor.Text = "Player form changes affect text color"
        Me.chkTextColor.UseVisualStyleBackColor = True
        '
        'btnAdv
        '
        Me.btnAdv.BackgroundImage = CType(resources.GetObject("btnAdv.BackgroundImage"), System.Drawing.Image)
        Me.btnAdv.Font = New System.Drawing.Font("Consolas", 8.150944!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdv.ForeColor = System.Drawing.Color.White
        Me.btnAdv.Location = New System.Drawing.Point(66, 525)
        Me.btnAdv.Name = "btnAdv"
        Me.btnAdv.Size = New System.Drawing.Size(113, 30)
        Me.btnAdv.TabIndex = 29
        Me.btnAdv.Text = "Adv. Settings"
        Me.btnAdv.UseVisualStyleBackColor = True
        '
        'tabAdvSettings
        '
        Me.tabAdvSettings.Controls.Add(Me.tabSpawnRates)
        Me.tabAdvSettings.Controls.Add(Me.tabIsoMaps)
        Me.tabAdvSettings.Controls.Add(Me.tabSeasonalOverride)
        Me.tabAdvSettings.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabAdvSettings.Location = New System.Drawing.Point(281, 33)
        Me.tabAdvSettings.Name = "tabAdvSettings"
        Me.tabAdvSettings.SelectedIndex = 0
        Me.tabAdvSettings.Size = New System.Drawing.Size(470, 475)
        Me.tabAdvSettings.TabIndex = 31
        '
        'tabSpawnRates
        '
        Me.tabSpawnRates.AutoScroll = True
        Me.tabSpawnRates.BackColor = System.Drawing.Color.Black
        Me.tabSpawnRates.Font = New System.Drawing.Font("Consolas", 9.0!)
        Me.tabSpawnRates.ForeColor = System.Drawing.Color.White
        Me.tabSpawnRates.Location = New System.Drawing.Point(4, 24)
        Me.tabSpawnRates.Name = "tabSpawnRates"
        Me.tabSpawnRates.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSpawnRates.Size = New System.Drawing.Size(462, 447)
        Me.tabSpawnRates.TabIndex = 0
        Me.tabSpawnRates.Text = "Monster Spawn Rates"
        '
        'tabIsoMaps
        '
        Me.tabIsoMaps.BackColor = System.Drawing.Color.Black
        Me.tabIsoMaps.Controls.Add(Me.Label2)
        Me.tabIsoMaps.Controls.Add(Me.picSampleIsotile)
        Me.tabIsoMaps.Controls.Add(Me.chkMakeIso)
        Me.tabIsoMaps.ForeColor = System.Drawing.Color.White
        Me.tabIsoMaps.Location = New System.Drawing.Point(4, 24)
        Me.tabIsoMaps.Name = "tabIsoMaps"
        Me.tabIsoMaps.Size = New System.Drawing.Size(462, 447)
        Me.tabIsoMaps.TabIndex = 1
        Me.tabIsoMaps.Text = "Isometric Maps"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(4, 275)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(454, 121)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = resources.GetString("Label2.Text")
        '
        'picSampleIsotile
        '
        Me.picSampleIsotile.BackgroundImage = CType(resources.GetObject("picSampleIsotile.BackgroundImage"), System.Drawing.Image)
        Me.picSampleIsotile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picSampleIsotile.Location = New System.Drawing.Point(74, 37)
        Me.picSampleIsotile.Name = "picSampleIsotile"
        Me.picSampleIsotile.Size = New System.Drawing.Size(320, 230)
        Me.picSampleIsotile.TabIndex = 23
        Me.picSampleIsotile.TabStop = False
        '
        'chkMakeIso
        '
        Me.chkMakeIso.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkMakeIso.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black
        Me.chkMakeIso.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.chkMakeIso.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.chkMakeIso.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMakeIso.ForeColor = System.Drawing.Color.White
        Me.chkMakeIso.Location = New System.Drawing.Point(18, 11)
        Me.chkMakeIso.Name = "chkMakeIso"
        Me.chkMakeIso.Size = New System.Drawing.Size(431, 21)
        Me.chkMakeIso.TabIndex = 22
        Me.chkMakeIso.Text = "Support Isometric Tilesets"
        Me.chkMakeIso.UseVisualStyleBackColor = True
        '
        'chkBimboNames
        '
        Me.chkBimboNames.Checked = True
        Me.chkBimboNames.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBimboNames.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkBimboNames.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black
        Me.chkBimboNames.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.chkBimboNames.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.chkBimboNames.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkBimboNames.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBimboNames.ForeColor = System.Drawing.Color.White
        Me.chkBimboNames.Location = New System.Drawing.Point(16, 430)
        Me.chkBimboNames.Name = "chkBimboNames"
        Me.chkBimboNames.Size = New System.Drawing.Size(251, 39)
        Me.chkBimboNames.TabIndex = 32
        Me.chkBimboNames.Text = "No experimental name changes"
        Me.chkBimboNames.UseVisualStyleBackColor = True
        '
        'chkOldLoot
        '
        Me.chkOldLoot.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkOldLoot.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black
        Me.chkOldLoot.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.chkOldLoot.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.chkOldLoot.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkOldLoot.Font = New System.Drawing.Font("Consolas", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOldLoot.ForeColor = System.Drawing.Color.White
        Me.chkOldLoot.Location = New System.Drawing.Point(16, 471)
        Me.chkOldLoot.Name = "chkOldLoot"
        Me.chkOldLoot.Size = New System.Drawing.Size(251, 39)
        Me.chkOldLoot.TabIndex = 33
        Me.chkOldLoot.Text = "Use old loot tables"
        Me.chkOldLoot.UseVisualStyleBackColor = True
        '
        'tabSeasonalOverride
        '
        Me.tabSeasonalOverride.BackColor = System.Drawing.Color.Black
        Me.tabSeasonalOverride.ForeColor = System.Drawing.Color.White
        Me.tabSeasonalOverride.Location = New System.Drawing.Point(4, 24)
        Me.tabSeasonalOverride.Name = "tabSeasonalOverride"
        Me.tabSeasonalOverride.Size = New System.Drawing.Size(462, 447)
        Me.tabSeasonalOverride.TabIndex = 2
        Me.tabSeasonalOverride.Text = "Seasonal Override"
        '
        'Settings
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(272, 562)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkOldLoot)
        Me.Controls.Add(Me.chkBimboNames)
        Me.Controls.Add(Me.tabAdvSettings)
        Me.Controls.Add(Me.btnAdv)
        Me.Controls.Add(Me.chkTextColor)
        Me.Controls.Add(Me.chkEoverSS)
        Me.Controls.Add(Me.chkStartWithBooks)
        Me.Controls.Add(Me.chkOldSpellSpec)
        Me.Controls.Add(Me.chkNoRNG)
        Me.Controls.Add(Me.chkAlwaysUnwilling)
        Me.Controls.Add(Me.chkNoImg)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboxScreenSize)
        Me.Controls.Add(Me.btnSettingsOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Settings"
        Me.Text = "Settings"
        Me.tabAdvSettings.ResumeLayout(False)
        Me.tabIsoMaps.ResumeLayout(False)
        CType(Me.picSampleIsotile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSettingsOK As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboxScreenSize As System.Windows.Forms.ComboBox
    Friend WithEvents chkNoImg As System.Windows.Forms.CheckBox
    Friend WithEvents chkAlwaysUnwilling As System.Windows.Forms.CheckBox
    Friend WithEvents chkNoRNG As System.Windows.Forms.CheckBox
    Friend WithEvents chkOldSpellSpec As System.Windows.Forms.CheckBox
    Friend WithEvents chkStartWithBooks As System.Windows.Forms.CheckBox
    Friend WithEvents chkEoverSS As System.Windows.Forms.CheckBox
    Friend WithEvents chkTextColor As System.Windows.Forms.CheckBox
    Friend WithEvents btnAdv As System.Windows.Forms.Button
    Friend WithEvents tabAdvSettings As System.Windows.Forms.TabControl
    Friend WithEvents tabSpawnRates As System.Windows.Forms.TabPage
    Friend WithEvents chkBimboNames As System.Windows.Forms.CheckBox
    Friend WithEvents tabIsoMaps As System.Windows.Forms.TabPage
    Friend WithEvents chkMakeIso As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents picSampleIsotile As System.Windows.Forms.PictureBox
    Friend WithEvents chkOldLoot As System.Windows.Forms.CheckBox
    Friend WithEvents tabSeasonalOverride As System.Windows.Forms.TabPage
End Class
