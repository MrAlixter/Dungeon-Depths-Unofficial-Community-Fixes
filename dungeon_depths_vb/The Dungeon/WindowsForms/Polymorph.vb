Public Class Polymorph
    Public Shared porm As Boolean = True
    Public target As NPC
    Public tfForm As Boolean = False
    Shared fFNames() As String = {"Anna", "Ann", "Ana", "Alexis", "Allie", "Amber", "Ali", "Ashlie", _
                               "Becky", "Bambi", "Barbie", _
                               "Christine", "Casandra", "Cassie", "Cara", "Chloe", "Crystal", "Kristal", _
                               "Danica", "Dani", _
                                "Erika", "Emmy", _
                               "Heather", "Hailey", _
                               "Johanna", "Jenna", "Jenni", "Jo-Jo", _
                               "Kelli", _
                               "Lana", "Leora", _
                               "Monica", "Mia", _
                               "Nancy", "Nicole", _
                               "Racheal", _
                               "Sammi", "Sam", "Sally", "Sara", "Sofi", _
                               "Trisha", "Trixie"}
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'scale to the screen size
        Dim startingWidth = Me.Width
        Dim startingHeight = Me.Height
        If Game.screenSize = "Small" Then
            Size = New Size(Size.Width * 0.8, Size.Height * 0.8)
        ElseIf Game.screenSize = "Medium" Then
            Size = New Size(Size.Width * 0.9, Size.Height * 0.9)
        ElseIf Game.screenSize = "XLarge" Then
            Size = New Size(Size.Width * 1.3, Size.Height * 1.3)
        End If
        Dim RW As Double = (Me.Width - startingWidth) / startingWidth ' Ratio change of width
        Dim RH As Double = (Me.Height - startingHeight) / startingHeight ' Ratio change of height
        Dim newFont As Font = New System.Drawing.Font("Consolas", CInt(8 * Me.Size.Width / 210))
        For i = 0 To Me.Controls.Count - 1
            Me.Controls(i).Font = newFont
            Me.Controls(i).Width += CDbl(Me.Controls(i).Width * RW)
            Me.Controls(i).Height += CDbl(Me.Controls(i).Height * RH)
            Me.Controls(i).Left += CDbl(Me.Controls(i).Left * RW)
            Me.Controls(i).Top += CDbl(Me.Controls(i).Top * RH)
        Next

        Dim p = Game.player1
        Select Case porm
            Case True
                For i = 0 To p.selfPolyForms.Count - 1
                    cboxPMorph.Items.Add(p.selfPolyForms.Item(i))
                Next
                If cboxPMorph.Items.Contains(p.pClass.name) Then cboxPMorph.Items.Remove(p.pClass.name)
                If cboxPMorph.Items.Contains(p.pForm.name) Then cboxPMorph.Items.Remove(p.pForm.name)
            Case False
                For i = 0 To p.enemPolyForms.Count - 1
                    cboxPMorph.Items.Add(p.enemPolyForms.Item(i))
                Next
        End Select
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If cboxPMorph.Text = "-- Select --" Or Not tfForm Then
            Me.Close()
            Game.player1.mana += 5
            Exit Sub
        End If
        Select Case porm
            Case True
                transform(Game.player1, cboxPMorph.Text)
            Case False
                If target.GetType().IsSubclassOf(GetType(ShopNPC)) Then transformN(target) Else transform(target, cboxPMorph.Text)
        End Select
        Me.Close()
    End Sub

    'player transform methods
    Sub transform(ByRef p As Player, ByVal form As String)
        If form.Equals(p.pClass.name) Or form.Equals(p.pForm.name) Or Not p.polymorphs.Keys.Contains(form) Then
            Exit Sub
        End If

        'gets the revert text for whatever is being changed
        Dim revertText = ""
        If Not form.Equals(p.pClass.name) Then
            p.pClass.revert()
            revertText = p.pClass.revertPassage & DDUtils.RNRN
        ElseIf Not form.Equals(p.pForm.name) Then
            p.pForm.revert()
            revertText = p.pForm.revertPassage & DDUtils.RNRN
        Else
            MsgBox(form.Equals(p.pClass.name) & " | " & form.Equals(p.pForm.name))
        End If

        'polymorph updates
        p.ongoingTFs.resetPolymorphs()

        p.polymorphs(form) = PolymorphTF.newPoly(form)
        p.ongoingTFs.Add(p.polymorphs(form))
        p.perks(perk.polymorphed) = p.polymorphs(form).getturnsTilNextStep

        If form = "MASBimbo" Then form = "Bimbo"
        If p.forms.Keys.Contains(form) Then
            p.pForm = p.forms(form)
        ElseIf p.classes.Keys.Contains(form) Then
            p.pClass = p.classes(form)
        End If

        'cleanup
        Game.pushLblEvent(revertText & Game.lblEvent.Text.Split(vbCrLf)(0))
        p.specialRoute()
        p.magicRoute()
        p.drawPort()
    End Sub
    'NPC transform method
    Sub transform(ByRef t As NPC, ByVal s As String)
        Dim title As String = s
        If title = "Sheep" Then
            t.maxHealth = 50
            t.attack = 1
            t.defense = 1
            t.tfCt = 1
            t.tfEnd = 6
            t.form = "Sheep"
        ElseIf title = "Princess" Then
            t.maxHealth = 60
            t.attack = 5
            t.defense = 1
            t.tfCt = 1
            t.tfEnd = 6
            t.form = "Princess"
        ElseIf title = "Bunny" Then
            t.maxHealth = 25
            t.attack = 1
            t.defense = 1
            t.tfCt = 1
            t.tfEnd = 6
            t.form = "Bunny"
        ElseIf title = "Chicken" Then
            t.maxHealth = 45
            t.attack = 5
            t.defense = 5
            t.tfCt = 1
            t.tfEnd = 6
            t.form = "Chicken"
        ElseIf title = "Cow" Then
            t.maxHealth = 75
            t.attack = 0
            t.defense = 0
            t.tfCt = 1
            t.tfEnd = 6
            t.form = "Cow"
        ElseIf title = "Amnesiac" Then
            t.attack = 0
            t.defense = 0
            t.speed = 1
            t.stunct = 1
            t.tfCt = 1
            t.tfEnd = 6
            t.form = "Amnesiac"
        ElseIf title = "Slime​" Then
            t.maxHealth = 70
            t.attack = 10
            t.defense = 35
            t.tfCt = 1
            t.tfEnd = 2
            t.form = "Slime"
        ElseIf title = "Succubus​" Then
            t.maxHealth = 125
            t.attack = 20
            t.defense = 5
            t.tfCt = 1
            t.tfEnd = 2
            t.form = "Succubus"
        ElseIf title = "Dragon​" Then
            t.maxHealth = 200
            t.attack = 15
            t.defense = 30
            t.tfCt = 1
            t.tfEnd = 2
            t.form = "Dragon"
        ElseIf title = "Goth​" Then
            t.maxHealth = 200
            t.attack = 6
            t.defense = 6
            t.speed = 2
            t.tfCt = 1
            t.tfEnd = 6
            t.form = "Goth Girl"
        End If
    End Sub
    'npc transform methodF:\dungeon_depths\The Dungeon\img\
    Sub transformN(ByRef t As ShopNPC)
        Dim title As String = cboxPMorph.Text
        If title = "Sheep" Then
            t.toSheep()
        ElseIf title = "Princess" Then
            t.toPrincess()
        ElseIf title = "Bunny" Then
            t.toBunny()
        End If
        Game.npcIndex = t.npcIndex
    End Sub

    Shared Sub giveRNDFName(ByRef p As Player)
        Randomize()
        Dim fFNames() As String = {"Abigail", "Abby", "Anna", "Ann", "Ana", "Alexis", "Allie", _
                               "Becky", _
                               "Christine", "Casandra", "Catherine", "Cassie", "Carol", "Caroline", "Cara", _
                               "Danica", _
                               "Ellen", "Erika", "Erica", _
                               "Heather", _
                               "Iliona", _
                               "Janice", "Johanna", "Jenna", "Judy", "Jennifer", "Jo-Jo", _
                               "Kerry", "Katherine", "Katja", _
                               "Lana", _
                               "Monica", "Mary", _
                               "Nancy", "Nicole", "Nadja", _
                               "Racheal", _
                               "Samantha", "Sarah", "Sally", "Sophie", _
                               "Tanja", "Trisha", _
                               "Vanessa"}
        p.name = fFNames(Int(Rnd() * fFNames.Length))
    End Sub
    Shared Sub giveRNDMName(ByRef p As Player)
        Randomize()
        Dim fFNames() As String = {"Aaron", "Alan", "Alexander", _
                               "Bob", "Bruce", "Brandon", "Bailey", _
                               "Chris", "Ciaran", _
                               "Daniel", "Dave", "David", _
                               "Eric", _
                               "Gerry", _
                               "Hank", _
                               "Issac", "Ian", _
                               "James", "Jimmy", "Jim", "Josh", "John", "Jackson", _
                               "Ken", _
                               "Lorenzo", "Leonard", "Leo", "Lawrence", _
                               "Mark", _
                               "Nathan", "Nick", _
                               "Oliver", _
                               "Richard", "Ryan", _
                               "Samuel", "Stanley", "Stan", "Scott", _
                               "Tanner", "Tristan", "Travis", _
                               "Vance", _
                               "Zachary", "Zack"}
        p.name = fFNames(Int(Rnd() * fFNames.Length))
    End Sub
    Shared Sub giveRNDBimName(ByRef p As Player)
        Randomize()
        p.name = fFNames(Int(Rnd() * fFNames.Length))
    End Sub

    Shared Function bimboizeName(ByVal name As String) As String


        Dim vowels() As String = {"a", "e", "i", "o", "u"}

        Dim oname = name.ToLower
        Dim firstVowel As Integer = oname.Length

        For i = 1 To oname.Length - 1
            If vowels.Contains(oname.Substring(i, 1)) Then
                If Not firstVowel = oname.Length Then firstVowel = i + 1 : Exit For
                firstVowel = i + 1
            End If

        Next
        name = oname.Substring(0, firstVowel)

        If name.EndsWith("ie") Or name.EndsWith("ey") Then
            name = name.Substring(0, name.Length - 1) & "i"
        ElseIf (name.EndsWith("e") Or name.EndsWith("y")) And name.Length > 2 Then
            name = name.Substring(0, name.Length - 1) & "i"
        ElseIf (name.EndsWith("i") Or name.EndsWith("n")) And name.Length > 2 Then
            name = name.Substring(0, name.Length) & "i"
        End If

        name = name.Substring(0, 1).ToUpper() + name.Substring(1, name.Length - 1)

        If (name.EndsWith("chelli")) Then Return name.Substring(0, name.Length - 1) & "e"
        If (name.EndsWith("vi")) Then Return name.Substring(0, name.Length) & "i"
        If (name.EndsWith("Ali")) Then Return "Alli"
        If (name.EndsWith("au")) Then Return name.Substring(0, name.Length) & "li"
        If (name.EndsWith("sa") Or name.EndsWith("sta")) Then Return name.Substring(0, name.Length - 2) & "sie"
        If (name.EndsWith("oo")) Then name = name.Substring(0, name.Length - 1)

        If name.Length <= 2 Then
            If (name.EndsWith("Le") Or name.EndsWith("Se") Or name.EndsWith("Ro") Or name.EndsWith("Fo")) Then
                Return name.Substring(0, name.Length - 1) & "xi"
            ElseIf (name.EndsWith("He") Or name.EndsWith("Ka") Or name.EndsWith("Ke") Or name.EndsWith("Ha")) Then
                Return name.Substring(0, 1) & "aylee"
            ElseIf (name.EndsWith("Ju") Or name.EndsWith("Do") Or name.EndsWith("Ca") Or name.EndsWith("Ho")) Then
                Return name.Substring(0, name.Length - 1) & "li"
            ElseIf (name.EndsWith("Co") Or name.EndsWith("Ko")) Then
                Return name.Substring(0, 1) & "hloe"
            ElseIf (name.EndsWith("Ba")) Then
                Return name.Substring(0, name.Length - 1) & "mbi"
            ElseIf (name.EndsWith("Bo")) Then
                Return name.Substring(0, name.Length) & "obi"
            ElseIf (name.EndsWith("Am")) Then
                Return name.Substring(0, name.Length - 1) & "ber"
            ElseIf (name.EndsWith("Se")) Then
                Return name.Substring(0, 1) & "kye"
            ElseIf (name.EndsWith("Lo")) Then
                Return name.Substring(0, 1) & "oona"
            ElseIf (name.EndsWith("Sa")) Then
                Return name.Substring(0, 1) & "tacey"
            ElseIf (name.EndsWith("i") Or name.EndsWith("o") Or name.EndsWith("u")) Then
                Return name & "-" & name
            ElseIf (name.EndsWith("a")) Then
                Return name.Substring(0, name.Length - 1) & "ia"
            ElseIf (name.EndsWith("e")) Then
                Return name.Substring(0, name.Length - 1) & "na"
            End If
        Else
            Return name
        End If

        Return "Allie"
    End Function

    Private Sub cboxPMorph_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboxPMorph.SelectedValueChanged
        tfForm = True
    End Sub
End Class