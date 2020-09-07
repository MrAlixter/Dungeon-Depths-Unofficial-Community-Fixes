Public Class DDUtils
    Public Const RNRN As String = vbCrLf & vbCrLf
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
    Public Shared Sub append(ByRef a As Integer(), ByVal i As Integer)
        Array.Resize(a, a.Length + 1)
        a(a.Length - 1) = i
    End Sub
    Public Shared Function copyDictionary(ByVal dic As Dictionary(Of perk, Integer)) As Dictionary(Of perk, Integer)
        Return dic
    End Function
    Public Shared Sub shuffle(ByRef a As String())
        For i = 1 To UBound(a)
            Dim j = Int(Rnd() * i + 1)

            Dim tAi = a(i).ToString
            a(i) = a(j)
            a(j) = tAi
        Next
    End Sub



    'Text/Form resizing
    Public Shared Sub resizeForm(ByRef form As Form)
        resizeForm(form, form.Height, form.Width)
    End Sub
    Public Shared Sub resizeForm(ByRef form As Form, ByVal sHeight As Integer, ByVal sWidth As Integer)
        'scale to the screen size
        Dim newSize As Size = New Size(sWidth, sHeight)
        If Game.screenSize = "Small" Then
            newSize = New Size(sWidth * 0.8, sHeight * 0.8)
        ElseIf Game.screenSize = "Medium" Then
            newSize = New Size(sWidth * 0.9, sHeight * 0.9)
        ElseIf Game.screenSize = "XLarge" Or (form.Equals(Game) And Game.screenSize = "Maximized") Then
            newSize = New Size(sWidth * 1.3, sHeight * 1.3)
        ElseIf Game.screenSize = "Maximized" And form.Equals(Game) Then
            newSize = My.Computer.Screen.Bounds.Size
        End If

        If newSize.Equals(form.Size) Then Exit Sub

        Dim RW As Double = (newSize.Width - sWidth) / sWidth ' Ratio change of width
        Dim RH As Double = (newSize.Height - sHeight) / sHeight ' Ratio change of height

        For Each ctrl In form.Controls
            resizeControl(ctrl, RW, RH, newSize.Width / sWidth)
        Next

        form.Size = newSize
    End Sub
    Private Shared Sub resizeControl(ByRef ctrl As Control, ByVal RW As Double, ByVal RH As Double, ByVal fontRatio As Double)
        helperResizeControl(ctrl, RW, RH, fontRatio)

        For Each c In ctrl.Controls
            helperResizeControl(c, RW, RH, fontRatio)
        Next
    End Sub

    Private Shared Sub helperResizeControl(ByRef ctrl As Control, ByVal RW As Double, ByVal RH As Double, ByVal fontRatio As Double)
        Dim newFont As Font = scaledFont(ctrl.Font, (ctrl.Font.Size * fontRatio))

        ctrl.Width += CDbl((ctrl.Width) * RW)
        ctrl.Height += CDbl((ctrl.Height) * RH)
        ctrl.Left += CDbl((ctrl.Left) * RW)
        ctrl.Top += CDbl((ctrl.Top) * RH)

        ctrl.Font = fitFont(ctrl, newFont)
    End Sub
    Public Shared Function fitFont(ByRef ctrl As Control, ByVal newFont As Font) As Font
        While ctrl.Width < TextRenderer.MeasureText(ctrl.Text, newFont).Width
            newFont = New System.Drawing.Font("Consolas", newFont.SizeInPoints * 0.9)
        End While

        Return newFont
    End Function
    Public Shared Function scaledFont(ByVal f As Font, ByVal s As Double, Optional uline As Boolean = False)
        Dim style As FontStyle = f.Style

        If uline Then style = FontStyle.Underline

        Return New System.Drawing.Font(f.FontFamily, Convert.ToSingle(s), style, f.Unit, f.GdiCharSet)
    End Function
    Shared Sub msgFont(ByVal f As Font)
        Dim out = ""

        out += f.Bold.ToString & vbCrLf
        out += f.FontFamily.ToString & vbCrLf
        out += f.GdiCharSet.ToString & vbCrLf
        out += f.GdiVerticalFont.ToString & vbCrLf
        out += f.Height.ToString & vbCrLf
        out += f.IsSystemFont.ToString & vbCrLf
        out += f.IsSystemFont.ToString & vbCrLf
        out += f.Italic.ToString & vbCrLf
        out += f.Name.ToString & vbCrLf
        out += f.Size.ToString & vbCrLf
        out += f.SizeInPoints.ToString & vbCrLf
        out += f.Strikeout.ToString & vbCrLf
        out += f.Style.ToString & vbCrLf
        out += f.SystemFontName.ToString & vbCrLf
        out += f.Underline.ToString & vbCrLf
        out += f.Unit.ToString & vbCrLf

        MsgBox(out)
    End Sub
End Class


