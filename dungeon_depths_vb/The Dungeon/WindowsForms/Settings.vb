Public Enum setting
    noimg
    alwaysunwilling
    norng
    oldspellspec
    startwithbooks
    enemiesoverwritess
    nospawnsuccubi
End Enum

Public Class Settings
    Dim ssize As String

    Private Shared initialSettings As Dictionary(Of setting, Boolean)
    Private Shared settingMap As Dictionary(Of setting, CheckBox)

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
        initialSettings.Add(setting.nospawnsuccubi, False)
    End Sub
    Private Sub initSettingsMap()
        settingMap = New Dictionary(Of setting, CheckBox)

        settingMap.Add(setting.noimg, chkNoImg)
        settingMap.Add(setting.alwaysunwilling, chkAlwaysUnwilling)
        settingMap.Add(setting.norng, chkNoRNG)
        settingMap.Add(setting.oldspellspec, chkOldSpellSpec)
        settingMap.Add(setting.startwithbooks, chkStartWithBooks)
        settingMap.Add(setting.enemiesoverwritess, chkEoverSS)
        settingMap.Add(setting.nospawnsuccubi, chkNoSuccubi)
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
    End Sub
    Private Sub loadSettings()
        Dim r As System.IO.StreamReader = IO.File.OpenText("sett.ing")

        Try
            ssize = r.ReadLine
            Game.screenSize = ssize
            For Each setting In settingMap
                setting.Value.Checked = r.ReadLine
            Next
        Finally
            r.Close()
        End Try
    End Sub
    Shared Sub makeNewSetting()
        Dim w As System.IO.StreamWriter
        w = System.IO.File.CreateText("sett.ing")
        w.WriteLine("Large")

        For Each setting In initialSettings
            w.WriteLine(setting.Value)
        Next

        w.Close()
    End Sub

    '| - EVENT HANDLERS - |
    Public Shared Function active(ByVal s As setting) As Boolean
        Return settingMap(s).Checked
    End Function

    '| - EVENT HANDLERS - |
    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'initialize the lists of settings
        initSettingsMap()

        'scale to the screen size
        DDUtils.resizeForm(Me)

        'load all possible settings
        loadSettings()

        cboxScreenSize.Items.Add("Small")
        cboxScreenSize.Items.Add("Medium")
        cboxScreenSize.Items.Add("Large")
        cboxScreenSize.Items.Add("XLarge")
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
End Class