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

    Sub New(fc As String)
        InitializeComponent()

        floorcode = fc
    End Sub

    Sub GeneratorSettings_Load() Handles Me.Load
        reset()

        lblFC.Text = "Floorcode: " & floorcode
        refreshBoxes()
    End Sub

    Sub reset()
        w = 50
        h = 40
        chestFreqMin = 3
        chestFreqRange = 8
        chestSizeDependence = 30
        chestRichnessBase = 1
        chestRichnessRange = 5
        encounterRate = 25
        eClockResetVal = 5
    End Sub

    Sub refreshBoxes()
        boxWidth.Value = w
        boxHeight.Value = h
        boxChestFreqMin.Value = chestFreqMin
        boxChestFreqRange.Value = chestFreqRange
        boxChestFreqRange.Value = chestSizeDependence
        boxChestRichnessBase.Value = chestRichnessBase
        boxChestRichnessRange.Value = chestRichnessRange
        boxEncounterRate.Value = encounterRate
        boxEClockResetVal.Value = eClockResetVal
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Me.Close()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        reset()
        refreshBoxes()
    End Sub
End Class