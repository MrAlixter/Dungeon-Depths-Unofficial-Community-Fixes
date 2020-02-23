Public Class DDUtils
    Public Shared Function saveList(ByVal list As List(Of Object)) As String
        Dim out = ""

        out += list.Count & "~"

        For Each itm In list
            out += itm.ToString & "~"
        Next

        Return out
    End Function
    Public Shared Function loadList(ByVal listAsString As String) As List(Of Object)
        Dim out = New List(Of Object)
        Dim list = listAsString.Split("~")

        For i = 1 To CInt(list(0))
            out.Add(CObj(list(i)))
        Next

        Return out
    End Function
End Class
