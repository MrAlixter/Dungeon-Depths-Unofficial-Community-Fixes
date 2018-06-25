Public Class GeneratorSettings
    Dim floorcode As String
    Dim width As Integer
    Dim height As Integer
    Dim chestFreqMin As Integer
    Dim chestFreqRange As Integer
    Dim chestSizeDependence As Integer
    Dim encounterRate As Integer

    Sub New(fc As String)
        InitializeComponent()

        floorcode = fc
    End Sub

    Sub GeneratorSettings_Load() Handles Me.Load
        reset()

        lblFC.Text = "Floorcode: " & floorcode
        boxWidth.Value = width
        boxHeight.Value = height
        boxChestFreqMin.Value = chestFreqMin
        boxChestFreqRange.Value = chestFreqRange
        boxChestFreqRange.Value = chestSizeDependence
        boxEncounterRate.Value = encounterRate
    End Sub

    Sub reset()
        width = 50
        height = 40
        chestFreqMin = 3
        chestFreqRange = 8
        chestSizeDependence = 30
        encounterRate = 25
    End Sub
End Class