Public Class ImageAttribute
    Dim fImages As ImageDump
    Dim mImages As ImageDump
    Dim fNonDefOffset, mNonDefOffset As Integer
    Public key As String
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
    Shared Function get0pt7DefaultImageOffsetM(ByVal key As String)

        If key = "AccA" Or key = "Cloak" Or key = "Eyebrows" Or key = "FacialMark" Then
            Return 3
        ElseIf key = "Body" Or key = "Nose" Then
            Return 1
        ElseIf key = "Clothes" Or key = "Ears" Or key = "Eyes" Or key = "Face" Or key = "Mouth" Or key = "RearHair1" Or key = "RearHair2" Then
            Return 5
        ElseIf key = "FrontHair" Or key = "Glasses" Then
            Return 6
        ElseIf key = "Hat" Then
            Return 2
        Else
            Return 0
        End If
    End Function
    Shared Function get0pt7DefaultImageOffsetF(ByVal key As String)
        If key = "AccA" Or key = "Cloak" Then
            Return 4
        ElseIf key = "FacialMark" Then
            Return 3
        ElseIf key = "Body" Or key = "Nose" Then
            Return 1
        ElseIf key = "Clothes" Or key = "Ears" Or key = "Face" Or key = "Mouth" Or key = "RearHair1" Or key = "RearHair2" Then
            Return 5
        ElseIf key = "FrontHair" Or key = "Glasses" Then
            Return 6
        ElseIf key = "Eyes" Or key = "Hat" Then
            Return 7
        ElseIf key = "Eyebrows" Then
            Return 2
        Else
            Return 0
        End If
    End Function
End Class
