Public Class PlayerGhost
    Inherits Monster
    Dim eyeInd As Tuple(Of Integer, Boolean, Boolean)
    Dim className As String = "Classless"
    Dim deathfloor = ""
    Sub New()
        'Throw New Exception
        loadGhost()
        setupMonsterOnSpawn()
        If deathfloor.Equals(Game.currFloor.floorCode) Then inv = New Inventory()
    End Sub

    Private Function loadGhost() As Boolean
        Dim reader As IO.StreamReader
        reader = IO.File.OpenText("gho.sts")

        Dim ghost As String
        Try
            ghost = reader.ReadLine()
            ghost.Split()
        Catch e As Exception
            Return False
        End Try

        Dim ghostArray() As String = ghost.Split("*")

        name = ghostArray(0)
        deathfloor = ghostArray(1)
        className = ghostArray(2)
        health = ghostArray(4)
        maxHealth = ghostArray(4)
        attack = ghostArray(5)
        mana = ghostArray(6)
        defense = ghostArray(7)
        speed = ghostArray(8)
        Dim sexBool As Boolean = CBool(ghostArray(9))
        eyeInd = New Tuple(Of Integer, Boolean, Boolean)(ghostArray(10), ghostArray(11), ghostArray(12))
        Dim haircolor As Color = Color.FromArgb(255, ghostArray(13), ghostArray(14), ghostArray(15))
        inv.load(ghostArray(16))
        reader.Close()

        Dim writer = IO.File.CreateText("gho.sts")
        writer.WriteLine("MTGRAVE")
        writer.Flush()
        writer.Close()
        Return True
    End Function
End Class
