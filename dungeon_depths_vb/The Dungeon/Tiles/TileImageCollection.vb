Public Class TileImageCollection

    Dim cached_tileset As Tuple(Of tSet, ImageDump)

    Sub New()
        cached_tileset = New Tuple(Of tSet, ImageDump)(tSet.dungeon, New ImageDump("img/Tiles/dungeon", True))
    End Sub

    Public Function getImg(ByVal s As tSet, ByVal t As tile) As Image
        If s <> cached_tileset.Item1 Then
            cached_tileset = New Tuple(Of tSet, ImageDump)(s, New ImageDump("img/Tiles/" & s.ToString, True))
        End If

        Try
            Return cached_tileset.Item2.getImageAt(t)
        Catch ex As Exception
            DDError.failedToLoadTile(t, s)
            Return New Bitmap(60, 60)
        End Try
    End Function
End Class
