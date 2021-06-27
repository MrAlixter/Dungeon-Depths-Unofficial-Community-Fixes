Imports System.IO

Public Class DPreset
    Public floorcode As String
    Public w As Integer
    Public h As Integer
    Public chestFreqMin As Integer
    Public chestFreqRange As Integer
    Public chestSizeDependence As Integer
    Public chestRichnessBase As Integer
    Public chestRichnessRange As Integer
    Public encounterRate As Integer
    Public eClockResetVal As Integer
    Public trapFreqMin As Integer
    Public trapFreqRange As Integer
    Public trapSizeDependence As Integer

    Sub New(ByRef dunSet As GeneratorSettings)
        floorcode = dunSet.txtSeed.Text
        w = dunSet.boxWidth.Value
        h = dunSet.boxHeight.Value
        chestFreqMin = dunSet.boxChestFreqMin.Value
        chestFreqRange = dunSet.boxChestFreqRange.Value
        chestSizeDependence = dunSet.boxChestSizeDependence.Value
        chestRichnessBase = dunSet.boxChestRichnessBase.Value
        chestRichnessRange = dunSet.boxChestRichnessRange.Value
        encounterRate = dunSet.boxEncounterRate.Value
        eClockResetVal = dunSet.boxEClockResetVal.Value
        trapFreqMin = dunSet.boxTrapFreqMin.Value
        trapFreqRange = dunSet.boxTrapFreqRange.Value
        trapSizeDependence = dunSet.boxTrapSizeDependence.Value
    End Sub
    Sub New(ByVal path As String)
        loadPreset(path)
    End Sub

    Sub loadPreset(ByVal path As String)
        Dim reader As StreamReader
        reader = New StreamReader(path)

        reader.ReadLine() 'read the version

        floorcode = reader.ReadLine()
        w = CInt(reader.ReadLine())
        h = CInt(reader.ReadLine())
        chestFreqMin = CInt(reader.ReadLine())
        chestFreqRange = CInt(reader.ReadLine())
        chestSizeDependence = CInt(reader.ReadLine())
        chestRichnessBase = CInt(reader.ReadLine())
        chestRichnessRange = CInt(reader.ReadLine())
        encounterRate = CInt(reader.ReadLine())
        eClockResetVal = CInt(reader.ReadLine())
        trapFreqMin = CInt(reader.ReadLine())
        trapFreqRange = CInt(reader.ReadLine())
        trapSizeDependence = CInt(reader.ReadLine())

        reader.Close()
    End Sub

    Sub save(ByVal name As String) 'ByVal genSet As GeneratorSettings)
        'set preset values
        Dim path = "presets/" & name & ".dset"
        If IO.File.Exists(path) AndAlso MessageBox.Show("A preset named " & name & " already exists.  Overwrite existing preset?", "Overwrite Preset?", MessageBoxButtons.YesNo) = DialogResult.No Then Exit Sub
        Dim writer As StreamWriter
        IO.File.Delete(path)
        writer = IO.File.CreateText(path)

        'add a version differentiator
        writer.WriteLine(Game.version)

        writer.WriteLine(floorcode)
        writer.WriteLine(w)
        writer.WriteLine(h)
        writer.WriteLine(chestFreqMin)
        writer.WriteLine(chestFreqRange)
        writer.WriteLine(chestSizeDependence)
        writer.WriteLine(chestRichnessBase)
        writer.WriteLine(chestRichnessRange)
        writer.WriteLine(encounterRate)
        writer.WriteLine(eClockResetVal)
        writer.WriteLine(trapFreqMin)
        writer.WriteLine(trapFreqRange)
        writer.WriteLine(trapSizeDependence)

        writer.Flush()
        writer.Close()
    End Sub
End Class
