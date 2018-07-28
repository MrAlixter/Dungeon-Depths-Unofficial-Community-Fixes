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
        lblFC.Text = "Floorcode: " & floorcode
        refreshBoxes()

        'scale to the screen size
        Dim startingWidth = Me.Width
        Dim startingHeight = Me.Height
        If Game.screenSize = "Small" Then
            Size = New Size(Size.Width * 0.8, Size.Height * 0.82)
        ElseIf Game.screenSize = "Medium" Then
            Size = New Size(Size.Width * 0.9, Size.Height * 0.95)
        ElseIf Game.screenSize = "XLarge" Then
            Size = New Size(Size.Width * 1.3, Size.Height * 1.3)
        End If
        Dim RW As Double = (Me.Width - startingWidth) / startingWidth ' Ratio change of width
        Dim RH As Double = (Me.Height - startingHeight) / startingHeight ' Ratio change of height
        Dim newFont As Font = New System.Drawing.Font("Consolas", CInt(7 * Me.Size.Width / 500))
        For i = 0 To Me.Controls.Count - 1
            Me.Controls(i).Font = newFont
            Me.Controls(i).Width += CDbl(Me.Controls(i).Width * RW)
            Me.Controls(i).Height += CDbl(Me.Controls(i).Height * RH)
            Me.Controls(i).Left += CDbl(Me.Controls(i).Left * RW)
            Me.Controls(i).Top += CDbl(Me.Controls(i).Top * RH)
        Next
    End Sub

    Sub reset()
        w = 60
        h = 60
        chestFreqMin = 3
        chestFreqRange = 8
        chestSizeDependence = 30
        chestRichnessBase = 1
        chestRichnessRange = 5
        encounterRate = 25
        eClockResetVal = 5
        trapFreqMin = 3
        trapFreqRange = 5
        trapSizeDependence = 30
    End Sub

    Sub refreshBoxes()
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
        Me.Close()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        reset()
        refreshBoxes()
    End Sub
End Class