Imports System.Globalization

Public Class ImagePathDump
    Dim paths As List(Of String)
    Public key As pInd

    Sub New(ByVal dir As String)
        paths = getPaths(dir)
    End Sub
    Sub New(ByVal path_list As List(Of String))
        paths = path_list
    End Sub

    Function getPaths() As List(Of String)
        Return paths
    End Function
    Function getPathAt(ByVal i As Integer) As String
        Return paths(i)
    End Function
    Sub setAt(ByVal i As Integer, ByVal path As String)
        paths(i) = path
    End Sub

    Public Sub Add(ByVal path As String)
        paths.Add(path)
    End Sub
    Public Sub AddRange(ByRef b As ImagePathDump)
        paths.AddRange(b.getPaths)
    End Sub
    Public Function Count() As Integer
        Return paths.count
    End Function
    Public Function UBound() As Integer
        Return paths.count - 1
    End Function

    'getImg reads all .png files in a directory into a List data structure
    Shared Function getPaths(ByVal direct As String) As List(Of String)
        Dim dir = New IO.DirectoryInfo(direct)
        Dim images = dir.GetFiles("*.png", IO.SearchOption.AllDirectories).ToList
        Dim paths As New List(Of String)

        Dim previousCulture = Application.CurrentCulture.Clone
        Application.CurrentCulture = New CultureInfo("en-US")

        For Each img In images.OrderBy(Function(i) i.Name)
            paths.Add(img.FullName)
        Next

        Application.CurrentCulture = previousCulture

        Return paths
    End Function
End Class
