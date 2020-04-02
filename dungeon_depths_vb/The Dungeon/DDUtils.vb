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

    Public Shared Sub resizeForm(ByRef form As Form, ByVal oWidth As Integer)
        'scale to the screen size
        Dim startingWidth = form.Width
        Dim startingHeight = form.Height
        If Game.screenSize = "Small" Then
            form.Size = New Size(form.Size.Width * 0.8, form.Size.Height * 0.8)
        ElseIf Game.screenSize = "Medium" Then
            form.Size = New Size(form.Size.Width * 0.9, form.Size.Height * 0.9)
        ElseIf Game.screenSize = "XLarge" Then
            form.Size = New Size(form.Size.Width * 1.3, form.Size.Height * 1.3)
        End If
        Dim RW As Double = (form.Width - startingWidth) / startingWidth ' Ratio change of width
        Dim RH As Double = (form.Height - startingHeight) / startingHeight ' Ratio change of height
        Dim newFont As Font = New System.Drawing.Font("Consolas", CInt(8 * form.Size.Width / oWidth))
        For i = 0 To form.Controls.Count - 1
            form.Controls(i).Font = newFont
            form.Controls(i).Width += CDbl(form.Controls(i).Width * RW)
            form.Controls(i).Height += CDbl(form.Controls(i).Height * RH)
            form.Controls(i).Left += CDbl(form.Controls(i).Left * RW)
            form.Controls(i).Top += CDbl(form.Controls(i).Top * RH)
        Next
    End Sub
End Class
