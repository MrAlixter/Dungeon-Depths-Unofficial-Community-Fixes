Public Class ImageAttribute
    Dim fImages As ImageDump
    Dim mImages As ImageDump
    Dim fNonDefOffset, mNonDefOffset As Integer
    Sub New(ByVal i As ImageDump, ByVal ndo As Integer)
        fImages = i
        mImages = i
        fNonDefOffset = ndo
        mNonDefOffset = ndo
    End Sub
    Sub New(ByVal f As ImageDump, ByVal m As ImageDump, ByVal fndo As Integer, ByVal mndo As Integer)
        fImages = f
        mImages = m
        fNonDefOffset = fndo
        mNonDefOffset = mndo
    End Sub
    Function getF() As List(Of Image)
        Return fImages.getImages
    End Function
    Function getM() As List(Of Image)
        Return mImages.getImages
    End Function
    Function getAt(ByRef ind As Tuple(Of Integer, Boolean)) As Image
        If ind.Item2 Then
            Return fImages.getImageAt(ind.Item1)
        Else
            Return mImages.getImageAt(ind.Item1)
        End If
    End Function
    Sub setAt(ByRef ind As Tuple(Of Integer, Boolean), ByRef img As Image)
        If ind.Item2 Then
            fImages.setAt(ind.Item1, img)
        Else
            mImages.setAt(ind.Item1, img)
        End If
    End Sub
    Sub add(ByRef ind As Boolean, ByRef img As Image)
        If ind Then
            fImages.add(img)
        Else
            mImages.add(img)
        End If
    End Sub
    Function getOInd(ByRef ind As Tuple(Of Integer, Boolean)) As Tuple(Of Integer, Boolean)
        'this function calculates the offset index of nondefault options
        If ind.Item2 Then
            Return New Tuple(Of Integer, Boolean)(ind.Item1 + fNonDefOffset, True)
        Else
            Return New Tuple(Of Integer, Boolean)(ind.Item1 + mNonDefOffset, False)
        End If
    End Function
End Class
