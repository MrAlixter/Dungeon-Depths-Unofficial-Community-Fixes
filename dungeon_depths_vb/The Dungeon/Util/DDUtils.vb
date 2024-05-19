Public Class DDUtils
    Public Const RNRN As String = vbCrLf & vbCrLf
    Public Const PAKTC As String = DDUtils.RNRN & "Press any non-movement key to continue."
    Public Const TODO As String = DDUtils.RNRN & "[This transformation/item/etc is still in development, and placeholder values may still be present.]"
    Public Const INTLMT As Integer = 2147483647
    Public Const ALPHA As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOQRSTUVWXYZ"

    '|ARRAY MANIPULATION|
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
    Public Shared Function append(ByVal a As Item, ByVal b As List(Of Item)) As List(Of Item)
        b.Insert(0, a)

        Return b
    End Function
    Public Shared Function append(ByVal a As Integer, ByVal b As List(Of Integer)) As List(Of Integer)
        b.Insert(0, a)

        Return b
    End Function
    Public Shared Function union(ByVal a As List(Of String), ByVal b As List(Of String)) As List(Of String)
        Dim out = New List(Of String)

        For Each s In a
            If Not out.Contains(s) Then out.Add(s)
        Next
        For Each s In b
            If Not out.Contains(s) Then out.Add(s)
        Next

        Return out
    End Function
    Public Shared Function cboxToList(ByVal a As ComboBox.ObjectCollection) As List(Of String)
        Dim out = New List(Of String)

        For Each s In a
            out.Add(s.ToString)
        Next

        Return out
    End Function
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
    Public Shared Function ishuffle(ByVal a As Item()) As Item()
        For i = 1 To UBound(a)
            Dim j = Int(Rnd() * i + 1)

            Dim tAi = a(i)
            a(i) = a(j)
            a(j) = tAi
        Next

        Return a
    End Function
    Public Shared Function sortMaxToMin(ByVal l As List(Of Integer)) As List(Of Integer)
        If l.Count < 2 Then
            Return l
        Else
            Dim max As Integer = -999999999

            For Each i In l
                If i > max Then max = i
            Next

            l.Remove(max)

            Return append(max, l)
        End If
    End Function
    Public Shared Function getClosest(ByVal i As Integer, ByVal arr() As Integer) As Integer
        Dim dif As Integer = 9999
        Dim closest As Integer = -1

        For Each a In arr
            Dim d = Math.Abs(i - a)
            If d < dif Then
                closest = a
                dif = d
            End If
        Next

        Return closest
    End Function

    '|IARRIND|
    Public Shared Function cloneIArrInd(ByVal tup As Tuple(Of Integer, Boolean, Boolean)) As Tuple(Of Integer, Boolean, Boolean)
        Return New Tuple(Of Integer, Boolean, Boolean)(tup.Item1, tup.Item2, tup.Item3)
    End Function

    '|TEXT & FORM RESIZING|
    Public Shared Sub resizeForm(ByRef form As Form)
        resizeForm(form, form.Height, form.Width)
    End Sub
    Public Shared Sub resizeForm(ByRef form As Form, ByVal sHeight As Integer, ByVal sWidth As Integer)
        If Game.screenSize = "Maximized" Then
            Game.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Game.WindowState = FormWindowState.Maximized
        ElseIf Game.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
            Game.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            Game.WindowState = FormWindowState.Normal
        End If

        'scale to the screen size
        Dim newSize As Size = New Size(sWidth, sHeight)
        If Game.screenSize = "Small" Then
            newSize = New Size(sWidth * 0.8, sHeight * 0.8)
        ElseIf Game.screenSize = "Medium" Then
            newSize = New Size(sWidth * 0.9, sHeight * 0.9)
        ElseIf Game.screenSize = "XLarge" Then
            newSize = New Size(sWidth * 1.32, sHeight * 1.32)
        ElseIf Game.screenSize = "Maximized" And form.Equals(Game) Then
            newSize = My.Computer.Screen.Bounds.Size
        ElseIf Game.screenSize = "Maximized" And Not form.Equals(Game) Then
            Dim r = Game.Height / Game.iHeight
            newSize = New Size(sWidth * r, sHeight * r)
        ElseIf Game.screenSize = "Fit-to-Screen" Then
            Dim r = Math.Min((My.Computer.Screen.Bounds.Size.Height - 50) / Game.iHeight, (My.Computer.Screen.Bounds.Size.Width - 50) / Game.iWidth)
            newSize = New Size(sWidth * r, sHeight * r)
        End If

        If newSize.Equals(form.Size) Then Exit Sub

        Dim RW As Double = (newSize.Width - sWidth) / sWidth ' Ratio change of width
        Dim RH As Double = (newSize.Height - sHeight) / sHeight ' Ratio change of height

        If Game.screenSize = "Maximized" Then RW = RH

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
    Public Shared Function fitFont(ByRef ctrl As Control, ByVal newFont As Font, Optional ByVal font As String = "Consolas") As Font
        While (ctrl.Width < TextRenderer.MeasureText(ctrl.Text, newFont).Width And Not ctrl.GetType Is GetType(CheckBox)) Or (ctrl.Height < TextRenderer.MeasureText(ctrl.Text, newFont).Height And Not ctrl.GetType Is GetType(Label))
            newFont = New System.Drawing.Font(font, newFont.SizeInPoints * 0.9)
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
    Shared Function statBar(ByVal cval As Double, ByVal mval As Double, ByVal ctrl As Control, Optional ByVal delim As Char = "ᚋ")
        Dim out As String = " " & DDUtils.formatBigNumber(cval) & "/" & DDUtils.formatBigNumber(mval) & " "

        ctrl.Font = Game.lblHealthbarFont.Font

        While ctrl.Width * Math.Min((cval / mval), 1.0) > TextRenderer.MeasureText(out, ctrl.Font).Width
            out = delim & out & delim
        End While

        While ctrl.Width < TextRenderer.MeasureText(out, ctrl.Font).Width
            out = out.Substring(0, out.Length - 1)
        End While

        If Not out.Contains(delim) Then out.Replace(" ", "")

        Return out
    End Function
    Public Shared Function safeString(ByRef s As String)
        If String.IsNullOrEmpty(s) Then
            Return ""
        Else
            Return s
        End If
    End Function
    Public Shared Function containsIgnoreCase(ByRef s As String, ByRef token As String) As Boolean
        Return s.ToUpper.Contains(token.ToUpper)
    End Function
    Public Shared Function sanitizeString(ByRef s As String) As String
        s = s.Replace("*", "")
        s = s.Replace("~", "")
        s = s.Replace("@", "")
        s = s.Replace(":", "")

        Return s
    End Function

    '|COLOR SHIFT FUNCTIONS|
    Shared Function cEquals(ByVal a As Color, ByVal b As Color)
        Return a.A = b.A And a.R = b.R And a.G = b.G And a.B = b.B
    End Function
    Shared Function cShift(ByVal oC As Color, ByVal c As Color, ByVal inc As Integer, Optional ByVal adjustA As Boolean = True)
        If oC.Equals(c) Then Return c
        Dim a, r, g, b As Integer
        a = oC.A
        r = oC.R
        g = oC.G
        b = oC.B

        If adjustA Then
            If Math.Abs(a - c.A) < inc Or a > 255 Then
                a = c.A
            Else
                If a > c.A Then a -= inc Else a += inc
            End If
        End If
        If Math.Abs(r - c.R) < inc Or r > 255 Then
            r = c.R
        Else
            If r > c.R Then r -= inc Else r += inc
        End If
        If Math.Abs(g - c.G) < inc Or g > 255 Then
            g = c.G
        Else
            If g > c.G Then g -= inc Else g += inc
        End If
        If Math.Abs(b - c.B) < inc Or b > 255 Then
            b = c.B
        Else
            If b > c.B Then b -= inc Else b += inc
        End If

        Return Color.FromArgb(a, r, g, b)
    End Function
    Shared Sub changeHairColor(ByVal c As Color, ByVal iarrind() As Tuple(Of Integer, Boolean, Boolean), ByRef iarr As Image())
        iarr(pInd.rearhair) = Portrait.hairRecolor(Portrait.imgLib.atrs(pInd.rearhair).getAt(iarrind(pInd.rearhair)), c)
        iarr(pInd.midhair) = Portrait.hairRecolor(Portrait.imgLib.atrs(pInd.midhair).getAt(iarrind(pInd.midhair)), c)
        iarr(pInd.eyebrows) = Portrait.hairRecolor(Portrait.imgLib.atrs(pInd.eyebrows).getAt(iarrind(pInd.eyebrows)), c)
        iarr(pInd.fronthair) = Portrait.hairRecolor(Portrait.imgLib.atrs(pInd.fronthair).getAt(iarrind(pInd.fronthair)), c)
    End Sub
    Shared Sub changeSkinColor(ByVal c As Color, ByVal iarrind() As Tuple(Of Integer, Boolean, Boolean), ByRef iarr As Image())
        iarr(pInd.body) = Portrait.skinRecolor(Portrait.imgLib.atrs(pInd.body).getAt(iarrind(pInd.body)), c)
        iarr(pInd.face) = Portrait.skinRecolor(Portrait.imgLib.atrs(pInd.face).getAt(iarrind(pInd.face)), c)
        iarr(pInd.ears) = Portrait.skinRecolor(Portrait.imgLib.atrs(pInd.ears).getAt(iarrind(pInd.ears)), c)
        iarr(pInd.nose) = Portrait.skinRecolor(Portrait.imgLib.atrs(pInd.nose).getAt(iarrind(pInd.nose)), c)
    End Sub

    '|POINT CALCULATION|
    Shared Function distance(ByVal x As Point, ByVal y As Point) As Double
        'the straight-line distance between two points
        Return Math.Abs(Math.Sqrt(CDbl((y.X - x.X) ^ 2) + CDbl((y.Y - x.Y) ^ 2)))
    End Function
    Shared Function withinOnePlusMinus(ByVal p1 As Point, ByVal pList As List(Of Point)) As Boolean
        'indicates whether a point is within plus/minus one space of another in a list of points
        For Each p In pList
            If p.X + 1 = p1.X Or p.X - 1 = p1.X Then Return True
            If p.Y + 1 = p1.Y Or p.Y - 1 = p1.Y Then Return True
        Next
        Return False
    End Function
    Shared Function withinOnePlusMinus(pos As Point, pos1 As Point) As Boolean
        Return (pos.X + 1 = pos1.X Or pos.X - 1 = pos1.X) Or (pos.Y + 1 = pos1.Y Or pos.Y - 1 = pos1.Y)
    End Function
    Shared Function ptEquals(ByVal a As Point, ByVal b As Point) As Boolean
        Return a.X = b.X And a.Y = b.Y
    End Function

    '|STRING UTILS|
    Shared Function capitalizeFirst(ByVal str As String) As String
        Return str.Substring(0, 1).ToUpper() & str.Substring(1, str.Length - 1)
    End Function
    Shared Function countToken(ByVal str As String, ByVal tok As String)
        Return str.Length - str.Replace(tok, "").Length
    End Function
    Shared Sub printToFile(ByVal str As String, ByVal file_name As String)
        Dim writer As IO.StreamWriter
        IO.File.Delete(file_name)
        writer = IO.File.CreateText(file_name)

        writer.WriteLine(str)

        writer.Close()
    End Sub
    Shared Function formatBigNumber(ByVal int As Integer) As String
        If int > 999999999 Then
            Return Math.Round(CDbl(int / 1000000000), 1).ToString & " B"
        ElseIf int > 999999 Then
            Return Math.Round(CDbl(int / 1000000), 1).ToString & " M"
        ElseIf int > 9999 Then
            Return Math.Round(CDbl(int / 1000), 1).ToString & " K"
        Else
            Return int.ToString()
        End If
    End Function
    Shared Function rndAlpha() As String
        Return ALPHA.Substring(Int(Rnd() * ALPHA.Length), 1)
    End Function
    Shared Function amrOrClth(ByRef p As Player) As String
        Return If(p.equippedArmor.getAName.Contains("Armor"), "armor", "clothing")
    End Function
    Shared Function isEmpty(ByVal s As String) As Boolean
        If s Is Nothing Then Return True
        If s.Equals("") Then Return True
        If s.Length = 0 Then Return True

        Return False
    End Function

    '|FILE UTILS|
    Shared Function fileExistsWC(ByVal basePath As String, ByVal wildcard As String) As Boolean
        Dim paths() As String = IO.Directory.GetFiles(basePath, wildcard)

        Return paths.Length > 0
    End Function
    Shared Function getPathUsingWC(ByVal basePath As String, ByVal wildcard As String) As String
        If fileExistsWC(basePath, wildcard) Then Return IO.Directory.GetFiles(basePath, wildcard)(0) Else Return ""
    End Function
    Shared Function getSessionID(ByVal itemFilepath As String) As String
        itemFilepath = itemFilepath.Replace("items\", "")
        Return itemFilepath.Split("_")(0)
    End Function
End Class


