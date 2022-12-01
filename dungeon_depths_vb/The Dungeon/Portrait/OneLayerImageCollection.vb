Public Class OneLayerImageCollection
    Dim imgset As ImageDump

    Sub New()
        imgset = New ImageDump("img/OneLayer")
    End Sub

    Public Function getImg(ByVal i As Integer) As Image
        Try
            Return imgset.getImageAt(i)
        Catch ex As Exception
            DDError.failedToLoadFBImg(i)
            Return Portrait.nullImg
        End Try
    End Function
End Class
