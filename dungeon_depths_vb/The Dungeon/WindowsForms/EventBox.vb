Public Class EventBox
    Private txt As TextBox
    Private pnl As Panel

    Private pages() As String
    Private pageind As Integer
    Private hitEnd As Boolean

    Public Sub New(ByRef t As TextBox, ByRef p As Panel)
        txt = t
        pnl = p
        pages = (New List(Of String)).ToArray
        pageind = 0
        hitEnd = False
    End Sub
    Public Function getPageInd() As Integer
        Return pageind
    End Function
    Public Function getPageCt() As Integer
        Return pages.Length
    End Function
    Public Function hasHitEnd() As Integer
        Return hitEnd
    End Function


    Public Sub push(ByVal s As String, Optional ByRef oc As Action = Nothing)
        Dim tPages = New List(Of String)

        Dim ct = 0
        Dim tpage = ""
        For i = 0 To s.Length - 1
            Dim c = s.Substring(i, 1)
            If c.Equals("\") Then
                If s.Substring(i + 1, 1).Equals("n") Then
                    tpage += vbCrLf
                    i += 1
                    ct += 72
                ElseIf s.Substring(i + 1, 1).Equals("t") Then
                    tpage += "   "
                    i += 1
                    ct += 3
                Else
                    tPages.Add(tpage)
                    tpage = ""
                    ct = 0
                End If

            Else
                tpage += c
                ct += 1
            End If
        Next
        If ct > 0 Then tPages.Add(tpage)

        hitEnd = False
        pages = tPages.ToArray
        pageind = 0

        txt.Text = pages(pageind)
        If Not oc Is Nothing Then Game.lblEventOnClose = oc
    End Sub

    Public Sub nextpageR()
        pageind += 1
        If pageind > UBound(pages) Then
            pageind = UBound(pages)
            hitEnd = True
        End If
        txt.Text = pages(pageind)
    End Sub
    Public Sub nextpageL()
        pageind -= 1
        If pageind < 0 Then pageind = 0
        txt.Text = pages(pageind)
    End Sub
End Class
