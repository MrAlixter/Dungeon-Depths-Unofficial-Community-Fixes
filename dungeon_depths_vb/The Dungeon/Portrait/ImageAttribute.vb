Public Class ImageAttribute
    Dim fImages As ImageDump
    Public mImages As ImageDump
    Dim fNonDefOffset, mNonDefOffset As Integer
    Public key As pInd
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
    Function getI(ByVal bool As Boolean) As List(Of Image)
        If bool Then
            Return getF()
        Else
            Return getM()
        End If
    End Function
    Function getAt(ByRef ind As Tuple(Of Integer, Boolean, Boolean)) As Image
        If ind.Item3 Then
            If ind.Item2 Then
                ind = New Tuple(Of Integer, Boolean, Boolean)(osf(ind.Item1), True, False)
            Else
                ind = New Tuple(Of Integer, Boolean, Boolean)(osm(ind.Item1), False, False)
            End If
        End If

        If ind.Item2 Then
            Return fImages.getImageAt(ind.Item1)
        Else
            Return mImages.getImageAt(ind.Item1)
        End If
    End Function
    Function getAt(ByVal ind As Integer) As Image
        Dim tind = New Tuple(Of Integer, Boolean, Boolean)(ind, False, False)
        Return getAt(tind)
    End Function
    Sub setAt(ByRef ind As Tuple(Of Integer, Boolean, Boolean), ByRef img As Image)
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

    Function osm(ByVal i As Integer) As Integer
        Return i - ImageAttribute.get0pt7DefaultImageOffsetM(key) + mNonDefOffset
    End Function
    Function osf(ByVal i As Integer) As Integer
        Return i - ImageAttribute.get0pt7DefaultImageOffsetF(key) + fNonDefOffset
    End Function
    Function rosm(ByVal i As Integer) As Integer
        Return i + ImageAttribute.get0pt7DefaultImageOffsetM(key) - mNonDefOffset
    End Function
    Function rosf(ByVal i As Integer) As Integer
        Return i + ImageAttribute.get0pt7DefaultImageOffsetF(key) - fNonDefOffset
    End Function
    Function ndoM() As Integer
        Return mNonDefOffset
    End Function
    Function ndoF() As Integer
        Return fNonDefOffset
    End Function
    Function Count() As Integer
        Return fImages.Count + mImages.Count
    End Function
    Shared Function get0pt7DefaultImageOffsetM(ByVal key As pInd)
        If key = pInd.clothes Then Return 5

        If key = pInd.accessory Or key = pInd.cloak Or key = pInd.eyebrows Or key = pInd.facemark Then
            Return 3
        ElseIf key = pInd.body Or key = pInd.nose Then
            Return 1
        ElseIf key = pInd.clothes Or key = pInd.ears Or key = pInd.eyes Or key = pInd.face Or
            key = pInd.mouth Or key = pInd.rearhair Or key = pInd.midhair Then
            Return 5
        ElseIf key = pInd.fronthair Or key = pInd.glasses Then
            Return 6
        ElseIf key = pInd.hat Then
            Return 2
        ElseIf key = pInd.clothesbtm Then
            Return 14
        Else
            Return 0
        End If
    End Function
    Shared Function get0pt7DefaultImageOffsetF(ByVal key As pInd)
        If key = pInd.accessory Or key = pInd.cloak Then
            Return 4
        ElseIf key = pInd.facemark Then
            Return 3
        ElseIf key = pInd.body Or key = pInd.nose Then
            Return 1
        ElseIf key = pInd.clothes Or key = pInd.ears Or key = pInd.face Or key = pInd.mouth Or
            key = pInd.rearhair Or key = pInd.midhair Then
            Return 5
        ElseIf key = pInd.fronthair Or key = pInd.glasses Then
            Return 6
        ElseIf key = pInd.eyes Then
            Return 7
        ElseIf key = pInd.hat Then
            Return 9
        ElseIf key = pInd.eyebrows Then
            Return 2
        ElseIf key = pInd.clothesbtm Then
            Return 14
        Else
            Return 0
        End If
    End Function

    Sub setDumpKey()
        mImages.key = key
        fImages.key = key
    End Sub
End Class
