Imports System.IO

Public Class PCPreset
    Public iArrInd(Portrait.NUM_IMG_LAYERS) As Tuple(Of Integer, Boolean, Boolean)
    Public pName As String
    Public pClass As String
    Public haircolor, skincolor As Color
    Public sexbool As Boolean

    Sub New()
    End Sub
    Sub New(ByVal p As String)
        loadIMG(p)
    End Sub

    Sub loadIMG(ByVal path As String)
        Dim reader As StreamReader
        reader = New StreamReader(path)

        reader.ReadLine() 'read the version

        'load the player portrait
        Dim readArray() = reader.ReadLine.Split("*")
        For i = 1 To CInt(readArray(0)) + 1
            Dim arr() As String = readArray(i).Split("%")
            iArrInd(i - 1) = New Tuple(Of Integer, Boolean, Boolean)(CInt(arr(0)), CBool(arr(1)), CBool(arr(2)))
        Next

        Dim hcArray() = reader.ReadLine.Split("*")
        haircolor = Color.FromArgb(255, CInt(hcArray(0)), CInt(hcArray(1)), CInt(hcArray(2)))

        Dim scArray() = reader.ReadLine.Split("*")
        skincolor = Color.FromArgb(255, CInt(scArray(0)), CInt(scArray(1)), CInt(scArray(2)))

        pName = reader.ReadLine
        pClass = reader.ReadLine

        sexbool = CBool(reader.ReadLine)
        reader.Close()
    End Sub

    Sub save(ByVal c As String) 'ByVal genSet As GeneratorSettings)
        'set preset values
        ReDim iArrInd(UBound(Game.player1.prt.iArrInd))
        For i = 0 To UBound(iArrInd)
            iArrInd(i) = (Game.player1.prt.iArrInd(i))
        Next
        pName = Game.player1.name
        pClass = c
        haircolor = Game.player1.prt.haircolor
        skincolor = Game.player1.prt.skincolor

        sexbool = Game.player1.prt.sexBool

        Dim path = "presets/" & Game.player1.name & ".pset"
        If IO.File.Exists(path) AndAlso MessageBox.Show("A preset for " & pName & " already exists.  Overwrite existing preset?", "Overwrite Preset?", MessageBoxButtons.YesNo) = DialogResult.No Then Exit Sub
        Dim writer As StreamWriter
        IO.File.Delete(path)
        writer = IO.File.CreateText(path)

        'add a version differentiator
        writer.WriteLine(Game.version)

        'save the player's portrait
        Dim output As String = UBound(iArrInd) & "*"
        For i = 0 To UBound(iArrInd)
            output += (iArrInd(i).Item1 & "%" & iArrInd(i).Item2 & "%" & iArrInd(i).Item3 & "*")
        Next
        writer.WriteLine(output)
        writer.WriteLine(haircolor.R & "*" & haircolor.G & "*" & haircolor.B)
        writer.WriteLine(skincolor.R & "*" & skincolor.G & "*" & skincolor.B)

        writer.WriteLine(pName)
        writer.WriteLine(pClass)

        writer.WriteLine(sexbool)

        writer.Flush()
        writer.Close()
    End Sub
End Class
