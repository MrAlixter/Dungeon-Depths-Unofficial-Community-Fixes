Imports System.Globalization

Public Class ImageDump
    Dim images As List(Of Image)
    Public key As pInd
    Shared Function imgEQ(ByVal a As Bitmap, ByVal b As Bitmap) As Boolean
        Return a Is b
        If a.Size.Equals(b.Size) Then
            For y = 0 To a.Size.Height - 1 Step 12
                For x = 0 To a.Size.Width - 1 Step 12
                    If Not a.GetPixel(x, y).Equals(b.GetPixel(x, y)) Then Return False
                Next
            Next
            Return True
        End If
        Return False
    End Function
    Sub New(ByVal path As String)
        images = getImg(path)
    End Sub
    Sub New(ByVal img As List(Of Image))
        images = img
    End Sub
    Function getImages() As List(Of Image)
        Return images
    End Function
    Function getImageAt(ByVal ind As Integer) As Image
        Try
            Return images(ind)
        Catch e As Exception
            MsgBox(key.ToString & ": Image #" & ind & " not found!")
            Return Nothing
        End Try
    End Function
    Sub add(ByRef img As Image)
        images.Add(img)
    End Sub
    Sub setAt(ByVal imgInd As Integer, ByVal img As Image)
        images(imgInd) = img
    End Sub
    Public Sub merge(ByRef b As ImageDump)
        images.AddRange(b.getImages)
    End Sub
    Public Function Count() As Integer
        Return images.Count
    End Function
    Public Function UBound() As Integer
        Return images.Count - 1
    End Function

    'getImg reads all .png files in a directory into a List data structure
    Shared Function getImg(ByVal direct As String) As List(Of Image)
        Dim dir = New IO.DirectoryInfo(direct)
        Dim images = dir.GetFiles("*.png", IO.SearchOption.AllDirectories).ToList
        Dim pictures As New List(Of Image)

        Dim previousCulture = Application.CurrentCulture.Clone
        Application.CurrentCulture = New CultureInfo("en-US")

        For Each img In images.OrderBy(Function(i) i.Name)
            Dim picture As Image
            picture = Image.FromFile(img.FullName)
            pictures.Add(picture)
        Next

        Application.CurrentCulture = previousCulture

        Return pictures
    End Function
    Shared Function convToStd(ByVal s As String)
        Select Case s
            Case "fTFAcce"
                Return "fAcce"
            Case "fTFBody"
                Return "fBody"
            Case "fTFClothes"
                Return "fClothing"
            Case "fTFClothes2"
                Return "fClothing2"
            Case "fTFEars"
                Return "fEars"
            Case "fTFEyes"
                Return "fEyes"
            Case "fTFface"
                Return "fFace"
            Case "fTfFrontHair"
                Return "fFrontHair"
            Case "fTFMouth"
                Return "fMouth"
            Case "fTfNose"
                Return "fNose"
            Case "fTFRearhair1"
                Return "fRearHair1"
            Case "fTfRearhair2"
                Return "fRearHair2"

            Case "mTFAcce"
                Return "mAcce"
            Case "mTFBody"
                Return "mBody"
            Case "mTFClothes"
                Return "mClothing"
            Case "mTFClothes2"
                Return "mClothing2"
            Case "mTFEars"
                Return "mEars"
            Case "mTFEyes"
                Return "mEyes"
            Case "mTFface"
                Return "mFace"
            Case "mTfFrontHair"
                Return "mFrontHair"
            Case "mTFMouth"
                Return "mMouth"
            Case "mTfNose"
                Return "mNose"
            Case "mTFRearhair1"
                Return "mRearHair1"
            Case "mTfRearhair2"
                Return "mRearHair2"
            Case Else
                Return ""
        End Select
    End Function
End Class
