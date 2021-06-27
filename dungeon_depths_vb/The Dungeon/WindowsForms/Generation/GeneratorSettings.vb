Public Class GeneratorSettings
    Dim floorcode As String
    Dim w As Integer
    Dim h As Integer
    Dim chestFreqMin As Integer
    Dim chestFreqRange As Integer
    Dim chestSizeDependence As Integer
    Dim chestRichnessBase As Integer
    Dim chestRichnessRange As Integer
    Dim encounterRate As Integer
    Dim eClockResetVal As Integer
    Dim trapFreqMin As Integer
    Dim trapFreqRange As Integer
    Dim trapSizeDependence As Integer

    Sub New(fc As String)
        InitializeComponent()
        floorcode = fc
    End Sub

    Sub GeneratorSettings_Load() Handles Me.Load
        reset()
        lblFC.Text = "Floorcode:"
        txtSeed.Text = floorcode
        refreshBoxes()

        getPresets()

        'scale to the screen size
        DDUtils.resizeForm(Me)
    End Sub

    Sub reset()
        w = 60
        h = 60
        chestFreqMin = 3
        chestFreqRange = 8
        chestSizeDependence = 30
        chestRichnessBase = 1
        chestRichnessRange = 4
        encounterRate = 25
        eClockResetVal = 5
        trapFreqMin = 3
        trapFreqRange = 5
        trapSizeDependence = 30
    End Sub

    Sub refreshBoxes()
        txtSeed.Text = floorcode
        boxWidth.Value = w
        boxHeight.Value = h
        boxChestFreqMin.Value = chestFreqMin
        boxChestFreqRange.Value = chestFreqRange
        boxChestSizeDependence.Value = chestSizeDependence
        boxChestRichnessBase.Value = chestRichnessBase
        boxChestRichnessRange.Value = chestRichnessRange
        boxEncounterRate.Value = encounterRate
        boxEClockResetVal.Value = eClockResetVal
        boxTrapFreqMin.Value = trapFreqMin
        boxTrapFreqRange.Value = trapFreqRange
        boxTrapSizeDependence.Value = trapSizeDependence
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        If chkSavePreset.Checked Then
            Dim presetName = InputBox("Please enter a name for this preset:", "Preset Name", "Dungeon Preset")
            Dim preset = New DPreset(Me)
            preset.save(presetName)
        End If
        Me.Close()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        reset()
        refreshBoxes()
    End Sub

    '| -- Dungeon Setting Presets -- |
    Sub getPresets()
        Dim dir = New IO.DirectoryInfo("Presets")
        Try
            Dim presets = dir.GetFiles("*.dset", IO.SearchOption.AllDirectories).ToList
            For Each pset In presets.OrderBy(Function(i) i.Name)
                cBoxPresets.Items.Add(pset.Name)
            Next
        Catch e As Exception
        End Try
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        cBoxPresets.SelectionLength = 0
    End Sub

    Private Sub cBoxPresets_TextChanged(sender As Object, e As EventArgs) Handles cBoxPresets.TextChanged
        If cBoxPresets.Text = "--- (none) ---" Or cBoxPresets.SelectedIndex = -1 Then Exit Sub
        Dim preset = New DPreset("presets/" & cBoxPresets.Text)

        w = preset.w
        h = preset.h
        chestFreqMin = preset.chestFreqMin
        chestFreqRange = preset.chestFreqRange
        chestSizeDependence = preset.chestSizeDependence
        chestRichnessBase = preset.chestRichnessBase
        chestRichnessRange = preset.chestRichnessRange
        encounterRate = preset.encounterRate
        eClockResetVal = preset.eClockResetVal
        trapFreqMin = preset.trapFreqMin
        trapFreqRange = preset.trapFreqRange
        trapSizeDependence = preset.trapSizeDependence

        refreshBoxes()
    End Sub
End Class