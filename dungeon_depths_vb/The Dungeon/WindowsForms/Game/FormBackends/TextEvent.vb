Public Class TextEvent
    Public Shared lblEventOnClose As Action
    Public Shared eventDialogBox As EventBox
    Public Shared yesAction, noAction As Action
    Public Shared choiceText As String

    Shared Sub New()
        lblEventOnClose = Nothing
        eventDialogBox = New EventBox(Game.txtPNLEvents, Game.pnlEvent)
        yesAction = Nothing
        noAction = Nothing
        choiceText = Nothing
    End Sub

    '| - Push Functions - |
    Public Shared Sub push(ByVal s As String, Optional effect As Action = Nothing)
        If s.Equals("") Then Exit Sub

        If Game.combat_engaged Then
            pushCombat(s)
            Exit Sub
        End If

        If s.Length > 350 Then
            pushEventBox(s, effect)
            Exit Sub
        End If

        Game.cleanupPanels()

        Dim out = wrapText(s)

        If Not Game.combat_engaged Then out += " " & DDUtils.PAKTC Else out += " " & DDUtils.RNRN & "Click a combat button to continue."
        If 1 = 1 Then Game.lblEvent.Text = out Else Game.lblEvent.Text = vbCrLf & "---------------------------------------------------------------------------" & vbCrLf & out
        Game.lblEvent.BringToFront()

        Dim x = (265 * (Game.Size.Width / 688)) - (Game.lblEvent.Size.Width / 2)
        If x < 20 Then x = 20
        Game.lblEvent.Location = New Point(x, (65 * (Game.Size.Width / 688)))
        Game.lblEvent.Visible = True
        If Not effect Is Nothing Then lblEventOnClose = effect
        Game.player1.canMoveFlag = False
    End Sub
    Public Shared Sub push(ByVal s As String, ByRef yes As Action, ByVal no As Action, ByVal text As String)
        'push a choice to the player
        If s.Equals("") Then Exit Sub

        If Game.combat_engaged Then
            pushCombat("Error, choice to be made during combat.")
            Exit Sub
        End If

        Game.cleanupPanels()

        Dim out = wrapText(s)

        out += " " & DDUtils.PAKTC

        Game.lblEvent.Text = out
        Game.lblEvent.BringToFront()

        Dim x = (265 * (Game.Size.Width / 688)) - (Game.lblEvent.Size.Width / 2)
        If x < 20 Then x = 20
        Game.lblEvent.Location = New Point(x, (65 * (Game.Size.Width / 688)))

        Game.lblEvent.Visible = True
        Game.player1.canMoveFlag = False
        lblEventOnClose = AddressOf makeChoice
        yesAction = yes
        noAction = no
        choiceText = text
        Game.btnEQP.Enabled = False
    End Sub
    Public Shared Sub pushEventBox(s As String, Optional onClose As Action = Nothing)
        If s.Equals("") Then Exit Sub

        If Game.combat_engaged Then
            pushCombat(s)
            Exit Sub
        End If

        Game.cleanupPanels()

        eventDialogBox.push(s, onClose)

        Game.pnlEvent.BringToFront()
        Game.pnlEvent.Location = New Point((15 * (Game.Size.Width / 688)), (33 * (Game.Size.Width / 688)))
        Game.pnlEvent.Visible = True
        Game.player1.canMoveFlag = False
        If Not onClose Is Nothing Then lblEventOnClose = onClose
        Game.btnEQP.Enabled = False
    End Sub
    Public Shared Sub pushLog(ByVal s As String)
        Game.lstLog.Items.Add(s)
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Public Shared Sub pushAndLog(ByVal msg As String)
        push(msg)
        pushLog(msg)
    End Sub
    Public Shared Sub pushCombat(ByVal s As String)
        Dim out = wrapText(s, 65)

        Game.lblCombatEvents.Text += (out & "-------------------------------------------------" & vbCrLf)
        Game.player1.specialRoute()
        Game.player1.magicRoute()
    End Sub
    Public Shared Sub pushNPCDialog(ByVal s As String, Optional ByRef effect As Action = Nothing)
        If s = "" Then Exit Sub

        If Game.combat_engaged Then
            pushCombat("""" & s & """")
            Exit Sub
        End If

        Game.cleanupPanels()

        Game.lblEvent.ForeColor = Color.White

        Dim out = wrapText(s, 60)

        Game.lblEvent.Text = out
        If Not effect Is Nothing Then lblEventOnClose = effect
        Game.lblEvent.Location = New Point(150 * Game.Size.Width / 688, 120 * Game.Size.Width / 688)
        Game.lblEvent.Visible = True
        Game.picNPC.Visible = True
    End Sub
    Public Shared Sub pushYesNo(ByVal s As String, ByRef yes As Action, ByRef no As action)
        yesAction = yes
        noAction = no
        choiceText = s
        makeChoice()
    End Sub
    Public Shared Sub pushManySelect(ByVal s As String, ByVal ParamArray options() As Tuple(Of String, Action))
        choiceText = s

        Game.selectionList = New Dictionary(Of String, Action)
        For Each o In options
            Game.selectionList.Add(o.Item1, o.Item2)
        Next

        Game.toPNLSelec("manySelect")
    End Sub
    Public Shared Sub pushManySelect(ByVal s As String, ByVal options As List(Of Tuple(Of String, Action)))
        choiceText = s

        Game.selectionList = New Dictionary(Of String, Action)
        For Each o In options
            Game.selectionList.Add(o.Item1, o.Item2)
        Next

        Game.toPNLSelec("manySelect")
    End Sub
    Public Shared Sub pushNote(s As String, Optional onClose As Action = Nothing)
        'uses special note formatting for the message
        If s.Equals("") Then Exit Sub

        If Game.combat_engaged Then
            pushCombat(s)
            Exit Sub
        End If

        Game.cleanupPanels()

        Game.txtNoteEvent.Text = s

        Game.pnlEvent.BringToFront()
        Game.pnlEvent.Location = New Point((15 * (Game.Size.Width / 688)), (33 * (Game.Size.Width / 688)))
        Game.pnlEvent.Visible = True

        Game.txtNoteEvent.Font = New Font("Segoe Print", 14)

        Game.txtPNLEvents.Visible = False
        Game.txtNoteEvent.Visible = True
        Game.player1.canMoveFlag = False
        If Not onClose Is Nothing Then lblEventOnClose = onClose
        Game.btnEQP.Enabled = False
    End Sub

    '| - Interactions - |
    Private Shared Sub makeChoice()
        Game.toPNLSelec("yesNo")
    End Sub

    '| - Utils - |
    Public Shared Function wrapText(ByVal s As String, Optional ByVal n As Integer = 80)
        Dim cursor As Integer = 0       'index of the current word
        Dim lineLen As Integer = 0      'length of the current line

        Dim out As String = ""

        'Split the string by spaces
        Dim subS() As String = s.Split(" ")

        'Go through each individual word, and break the input into lines of at most length n
        Do While cursor < subS.Length
            'If the word is already a line break, treat it as such (not as a character)
            If subS(cursor).Equals(vbCrLf) Then lineLen = 0

            'if there is room on the line, add the word
            If (lineLen + subS(cursor).Length) < n Then

                subS(cursor) = subS(cursor).Trim

                If subS(cursor).Contains(vbCrLf) Then
                    'if the word already ends with a line break, reset the current line length
                    out += subS(cursor)
                    If Not subS(cursor).EndsWith(vbCrLf) Then out += (" ")
                    lineLen = 0
                Else
                    out += subS(cursor) & " "
                    lineLen += subS(cursor).Length + 1
                End If

                cursor += 1
            Else
                'if there is no more room, start a new line
                out += vbCrLf
                lineLen = 0
            End If
        Loop

        Return out & vbCrLf
    End Function
End Class

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
        If Not oc Is Nothing Then lblEventOnClose = oc
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
