Public Class GeneratorSettings
    Dim floorcode As String
    Dim width As Integer
    Dim height As Integer

    Sub New(fc As String)
        InitializeComponent()

        floorcode = fc
    End Sub

    Sub GeneratorSettings_Load() Handles Me.Load
        reset()

        lblFC.Text = "Floorcode: " & floorcode
        boxWidth.Value = width
        boxHeight.Value = height
    End Sub

    Sub reset()
        width = 50
        height = 40
    End Sub
End Class