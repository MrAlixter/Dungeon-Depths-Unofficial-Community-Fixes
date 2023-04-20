Public Enum setting
    noimg
    alwaysunwilling
    norng
    oldspellspec
    startwithbooks
    enemiesoverwritess
    bimbonames
    textcolors
    isotiles
End Enum

Public Class Settings
    Dim ssize As String

    Private Const compressed_X As Integer = 288
    Private Const expanded_X As Integer = 790

    Private Shared initialSettings As Dictionary(Of setting, Boolean)
    Private Shared settingMap As Dictionary(Of setting, CheckBox)
    Private Shared monsterSpawns As Dictionary(Of mInd, Integer)

    Private compressed As Boolean = True

    '| - SETUP - |
    Shared Sub New()
        '| -- Initial Settings -- |
        initialSettings = New Dictionary(Of setting, Boolean)

        initialSettings.Add(setting.noimg, False)
        initialSettings.Add(setting.alwaysunwilling, False)
        initialSettings.Add(setting.norng, False)
        initialSettings.Add(setting.oldspellspec, True)
        initialSettings.Add(setting.startwithbooks, True)
        initialSettings.Add(setting.enemiesoverwritess, True)
        initialSettings.Add(setting.bimbonames, True)
        initialSettings.Add(setting.textcolors, False)
        initialSettings.Add(setting.isotiles, False)

        monsterSpawns = New Dictionary(Of mInd, Integer)
    End Sub
    Private Sub initSettingsMap()
        settingMap = New Dictionary(Of setting, CheckBox)

        settingMap.Add(setting.noimg, chkNoImg)
        settingMap.Add(setting.alwaysunwilling, chkAlwaysUnwilling)
        settingMap.Add(setting.norng, chkNoRNG)
        settingMap.Add(setting.oldspellspec, chkOldSpellSpec)
        settingMap.Add(setting.startwithbooks, chkStartWithBooks)
        settingMap.Add(setting.enemiesoverwritess, chkEoverSS)
        settingMap.Add(setting.bimbonames, chkBimboNames)
        settingMap.Add(setting.textcolors, chkTextColor)
        settingMap.Add(setting.isotiles, chkMakeIso)
    End Sub

    '| - SAVE/LOAD SETTINGS FILE - |
    Public Shared Sub applySavedSettings()
        Dim temp = New Settings

        Try
            temp.initSettingsMap()
            temp.loadSettings()
        Catch ex As Exception
            makeNewSetting()
            DDError.failedToLoadSettings()
        End Try

        temp.Dispose()
    End Sub
    Private Sub saveSettings()
        Dim w As System.IO.StreamWriter
        w = System.IO.File.CreateText("sett.ing")

        w.WriteLine(ssize)
        Game.screenSize = ssize

        For Each setting In settingMap
            w.WriteLine(setting.Value.Checked)
        Next
        w.Flush()
        w.Close()

        w = System.IO.File.CreateText("spawn.rate")
        For Each s_rate In monsterSpawns
            w.WriteLine(s_rate.Key & "|" & s_rate.Value)
        Next

        w.Flush()
        w.Close()
    End Sub
    Private Sub loadSettings()
        Using r As System.IO.StreamReader = IO.File.OpenText("sett.ing")
            ssize = r.ReadLine
            Game.screenSize = ssize
            For Each setting In settingMap
                setting.Value.Checked = r.ReadLine
            Next
        End Using

        Using r As System.IO.StreamReader = IO.File.OpenText("spawn.rate")
            monsterSpawns.Clear()
            While Not r.EndOfStream
                Dim line = r.ReadLine()
                Dim m = line.Split("|")(0)
                Dim i = line.Split("|")(1)

                monsterSpawns.Add(m, i)
            End While
        End Using
    End Sub
    Shared Sub makeNewSetting()
        Dim w As System.IO.StreamWriter
        w = System.IO.File.CreateText("sett.ing")
        w.WriteLine("Large")

        For Each setting In initialSettings
            w.WriteLine(setting.Value)
        Next

        w.Flush()
        w.Close()

        w = System.IO.File.CreateText("spawn.rate")
        w.WriteLine("0|2")

        w.Flush()
        w.Close()
    End Sub

    '| - EVENT HANDLERS - |
    Public Shared Function active(ByVal s As setting) As Boolean
        Return settingMap(s).Checked
    End Function
    Public Shared Function getSpawnRate(ByVal m As mInd) As Integer
        Return If(monsterSpawns.ContainsKey(m), monsterSpawns(m), 2)
    End Function

    '| - EVENT HANDLERS - |
    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'initialize the lists of settings
        initSettingsMap()

        'scale to the screen size
        DDUtils.resizeForm(Me)
        Me.CenterToParent()

        'load all possible settings
        loadSettings()

        cboxScreenSize.Items.Add("Small")
        cboxScreenSize.Items.Add("Medium")
        cboxScreenSize.Items.Add("Large")
        cboxScreenSize.Items.Add("XLarge")
        cboxScreenSize.Items.Add("Fit-to-Screen")
        'cboxScreenSize.Items.Add("Maximized")

        cboxScreenSize.Text = ssize
    End Sub
    Private Sub btnSettingsOK_Click(sender As Object, e As EventArgs) Handles btnSettingsOK.Click
        ssize = cboxScreenSize.Text

        saveSettings()

        Me.Close()
    End Sub
    Private Sub chkNoImg_CheckedChanged(sender As Object, e As EventArgs) Handles chkNoImg.CheckedChanged
        If chkNoImg.Checked Then
            Game.picPortrait.Visible = False
            Game.picDescPort.Visible = False
        Else
            Game.picPortrait.Visible = True
            Game.picDescPort.Visible = True
        End If
    End Sub
    Private Sub cboxScreenSize_TextChanged(sender As Object, e As EventArgs) Handles cboxScreenSize.TextChanged
        If Not cboxScreenSize.Items.Contains(cboxScreenSize.Text) Then cboxScreenSize.Text = "Large"
        btnSettingsOK.Focus()
    End Sub

    '| - ADV. SETTINGS - |
    Private Sub btnAdv_Click(sender As Object, e As EventArgs) Handles btnAdv.Click
        If compressed Then
            Me.Size = New Size(expanded_X * (CDbl(Me.Width) / CDbl(compressed_X)), Me.Height)
            compressed = False

            populateSpawnRatePanel()

            btnAdv.Text = "Basic Settings"
            btnAdv.Location = New Point(555 * (CDbl(Me.Width) / CDbl(expanded_X)), btnAdv.Location.Y)
            btnSettingsOK.Location = New Point(674 * (CDbl(Me.Width) / CDbl(expanded_X)), btnSettingsOK.Location.Y)
        Else
            Me.Size = New Size(compressed_X * (CDbl(Me.Width) / CDbl(expanded_X)), Me.Height)
            compressed = True

            btnAdv.Text = "Adv. Settings"
            btnAdv.Location = New Point(66 * (CDbl(Me.Width) / CDbl(compressed_X)), btnAdv.Location.Y)
            btnSettingsOK.Location = New Point(185 * (CDbl(Me.Width) / CDbl(compressed_X)), btnSettingsOK.Location.Y)
        End If

        Me.CenterToParent()
    End Sub
    Private Sub createSpawnRatePanel(ByVal m_name As String, ByVal m_ind As mInd, ByVal index As Integer)
        Dim r As Double = CDbl(Me.Width) / CDbl(expanded_X)
        Dim pnl As Panel = New Panel()

        pnl.AutoSize = False
        pnl.Size = New Size(440 * r, 25 * r)
        pnl.Location = New Point(6 * r, (8 * r) + (index * pnl.Size.Height))
        pnl.BackColor = Color.Black

        Dim name As Label = New Label()
        name.Text = m_name
        name.AutoSize = False
        name.Size = New Size(198 * r, 21 * r)
        name.Location = New Point(3 * r, 2 * r)
        name.ForeColor = Color.White
        name.BackColor = Color.Black
        name.Font = tabSpawnRates.Font
        pnl.Controls.Add(name)

        Dim rate As TrackBar = New TrackBar()
        rate.Size = New Size(210 * r, 21 * r)
        rate.Location = New Point(227 * r, 2 * r)
        rate.ForeColor = Color.White
        rate.BackColor = Color.Black
        rate.Minimum = 0
        rate.Maximum = 3
        rate.LargeChange = 1
        rate.Tag = m_ind
        AddHandler rate.ValueChanged, AddressOf spawnRateChanged
        If monsterSpawns.ContainsKey(m_ind) Then rate.Value = monsterSpawns(m_ind)
        pnl.Controls.Add(rate)

        tabSpawnRates.Controls.Add(pnl)
    End Sub
    Private Sub populateSpawnRatePanel()
        tabSpawnRates.Controls.Clear()

        Dim l = Monster.getRNGMonsters()

        For i = 0 To l.Count - 1
            If Not Settings.monsterSpawns.ContainsKey(l.Item(i).Item1) Then Settings.monsterSpawns.Add(l.Item(i).Item1, 2)
            createSpawnRatePanel(l.Item(i).Item2, l.Item(i).Item1, i)
        Next
    End Sub

    Private Sub spawnRateChanged(sender As TrackBar, e As EventArgs)
        If Settings.monsterSpawns.ContainsKey(sender.Tag) Then Settings.monsterSpawns(sender.Tag) = sender.Value
    End Sub
End Class