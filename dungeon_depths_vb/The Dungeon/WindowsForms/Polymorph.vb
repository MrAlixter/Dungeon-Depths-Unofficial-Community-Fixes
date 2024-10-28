Public Class Polymorph
    Public Shared porm As Boolean = True
    Public target As NPC
    Public tfForm As Boolean = False

    '| - FORM EVENT HANDLERS - |
    Private Sub Polymorph_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'scale to the screen size
        Dim startingWidth = Me.Width
        Dim startingHeight = Me.Height
        If Game.screenSize = "Small" Then
            Size = New Size(Size.Width * 0.8, Size.Height * 0.8)
        ElseIf Game.screenSize = "Medium" Then
            Size = New Size(Size.Width * 0.9, Size.Height * 0.9)
        ElseIf Game.screenSize = "XLarge" Then
            Size = New Size(Size.Width * 1.32, Size.Height * 1.32)
        ElseIf Game.screenSize = "Maximized" Then
            Dim r = Game.Height / Game.iHeight
            Size = New Size(Size.Width * r, Size.Height * r)
        ElseIf Game.screenSize = "Fit-to-Screen" Then
            Dim r = Math.Min((My.Computer.Screen.Bounds.Size.Height - 50) / Game.iHeight, (My.Computer.Screen.Bounds.Size.Width - 50) / Game.iWidth)
            newSize = New Size(Size.Width * r, Size.Height * r)
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
                    cboxPolymorph.Items.Add(p.selfPolyForms.Item(i))
                Next
                If cboxPolymorph.Items.Contains(p.className) Then cboxPolymorph.Items.Remove(p.className)
                If cboxPolymorph.Items.Contains(p.formName) Then cboxPolymorph.Items.Remove(p.formName)
            Case False
                For i = 0 To p.enemPolyForms.Count - 1
                    cboxPolymorph.Items.Add(p.enemPolyForms.Item(i))
                Next
        End Select

        Me.CenterToParent()
    End Sub
    Private Sub BtnPolymorphOK_Click(sender As Object, e As EventArgs) Handles btnPolymorphOK.Click
        'Cancel the polymorph if an invalid form type is selected
        If cboxPolymorph.Text = "-- Select --" Or Not tfForm Then
            Me.Close()
            Game.player1.mana += 12
            Exit Sub
        End If

        'Route the polymorph based on target type
        Select Case porm
            Case True
                '| -- Player -- |
                transform(Game.player1, cboxPolymorph.Text)
            Case False
                If target.GetType().IsSubclassOf(GetType(ShopNPC)) Then
                    '| -- NPC -- |
                    transformN(target, cboxPolymorph.Text)
                Else
                    '| -- Enemy -- |
                    transform(target, cboxPolymorph.Text)
                End If
        End Select

        Me.Close()
    End Sub

    '| - PLAYER TRANSFORMATIONS -|
    Shared Sub transform(ByRef p As Player, ByVal form As String, Optional ByVal checkform As Boolean = True)
        '| -- Pre-transformation Checks -- |
        If checkform AndAlso (form.Equals(p.className) Or form.Equals(p.formName) Or Not p.polymorphs.Keys.Contains(form)) Then
            Exit Sub
        End If

        '| -- Revert Previous Form/Class -- |
        Dim revertText = ""
        If Not form.Equals(p.className) Then
            p.pClass.revert()
            revertText = p.pClass.revertPassage & DDUtils.RNRN
        ElseIf Not form.Equals(p.formName) Then
            p.pForm.revert()
            revertText = p.pForm.revertPassage & DDUtils.RNRN
        Else
            DDError.badPolymorphError(form)
        End If

        '| -- Transformation -- |
        p.ongoingTFs.resetPolymorphs()

        Dim active_polymorph = PolymorphTF.newPoly(form)

        p.polymorphs(form) = active_polymorph
        p.ongoingTFs.add(active_polymorph)
        p.ongoingTFs.ping()

        'If form = "MASBimbo" Then form = "Bimbo"
        'If form = "Succubus Assassin" Then form = "Succubus"

        'If Player.forms.Keys.Contains(form) Then
        '    p.changeForm(form)
        'ElseIf Player.classes.Keys.Contains(form) Then
        '    p.changeClass(form)
        'End If

        '| -- Cleanup -- |
        If Not revertText = "" & DDUtils.RNRN Then TextEvent.fpush(revertText & active_polymorph.getTFText())

        p.specialRoute()
        p.magicRoute()

        p.drawPort()
        p.UIupdate()
    End Sub
    'NPC transform method
    Shared Sub transform(ByRef t As NPC, ByVal s As String)
        Dim original_name As String = CStr(DDUtils.capitalizeFirst(t.getNameWithTitle))

        If s = "Giant Frog" Then
            PolymorphedNPC.polymorph(t, Game.player1, 5, "Giant Frog")
        ElseIf s = "Sheep" Then
            PolymorphedNPC.polymorph(t, Game.player1, 6, "Sheep")
        ElseIf s = "Princess" Then
            PolymorphedNPC.polymorph(t, Game.player1, 6, "Princess")
        ElseIf s = "Cat-Girl" Then
            PolymorphedNPC.polymorph(t, Game.player1, 6, "Cat-Girl")
        ElseIf s = "Bunny" Then
            PolymorphedNPC.polymorph(t, Game.player1, 6, "Bunny")
        ElseIf s = "Cow" Then
            PolymorphedNPC.polymorph(t, Game.player1, 6, "Cow")
        ElseIf s = "Trilobite" Then
            PolymorphedNPC.polymorph(t, Game.player1, 4, "Trilobite")
        ElseIf s = "Amnesiac" Then
            PolymorphedNPC.polymorph(t, Game.player1, 3, "Amnesiac")
        ElseIf s = "Slime​" Then
            PolymorphedNPC.polymorph(t, Game.player1, 4, "Slime​")
        ElseIf s = "Succubus​" Then
            PolymorphedNPC.polymorph(t, Game.player1, 2, "Succubus​")
        ElseIf s = "Dragon​" Then
            PolymorphedNPC.polymorph(t, Game.player1, 2, "Dragon​")
        ElseIf s = "Bee-Girl" Then
            PolymorphedNPC.polymorph(t, Game.player1, 6, "Bee-Girl")
        ElseIf s = "Newt" Then
            PolymorphedNPC.polymorph(t, Game.player1, 3, "Newt")
        ElseIf s = "Pyreslug" Then
            PolymorphedNPC.polymorph(t, Game.player1, 6, "Pyreslug")
        ElseIf s = "Dove" Then
            PolymorphedNPC.polymorph(t, Game.player1, 8, "Dove")
        ElseIf s = "Goblin" Then
            PolymorphedNPC.polymorph(t, Game.player1, 6, "Goblin")
        ElseIf s = "Hellhound" Then
            PolymorphedNPC.polymorph(t, Game.player1, 6, "Hellhound")
        Else
            Exit Sub
        End If

        TextEvent.pushAndLog(original_name & " is turned into a " & s & "!")
    End Sub
    'npc transform method
    Shared Sub transformN(ByRef t As ShopNPC, ByVal s As String)
        Polymorph.transform(t, s)

        If s = "Sheep" Then
            t.toSheep()
        ElseIf s = "Princess" Then
            t.toPrincess()
        ElseIf s = "Bunny" Then
            t.toBunny()
        ElseIf s = "Cat-Girl" Then
            t.toCatgirl()
        ElseIf s = "Trilobite" Then
            t.toTrilobite()
        ElseIf s = "Bee-Girl" Then
            t.toBeeGirl()
        ElseIf s = "Bimbo" Then
            t.toBimbo()
        End If
    End Sub

    Shared Function rndFName() As String
        Randomize()
        Dim fFNames() As String = {"Abigail", "Abby", "Anna", "Ann", "Ana", "Alexis", "Allie", _
                               "Becky", _
                               "Christine", "Casandra", "Catherine", "Cassie", "Carol", "Caroline", "Cara", _
                               "Danica", _
                               "Ellen", "Erika", "Erica", _
                               "Heather", _
                               "Iliona", _
                               "Janice", "Johanna", "Jenna", "Judy", "Jennifer", _
                               "Kerry", "Katherine", "Katja", _
                               "Lana", _
                               "Monica", "Mary", _
                               "Nancy", "Nicole", "Nadja", _
                               "Racheal", _
                               "Samantha", "Sarah", "Sally", "Sophie", _
                               "Tanja", "Trisha", _
                               "Vanessa"}

        Return fFNames(Int(Rnd() * fFNames.Length))
    End Function
    Shared Sub giveRNDFName(ByRef p As Player)
        p.name = rndFName()
    End Sub
    Shared Function rndMName() As String
        Randomize()
        Dim mFNames() As String = {"Aaron", "Alan", "Alexander", _
                               "Bob", "Bruce", "Brandon", "Bailey", _
                               "Chris", "Ciaran", _
                               "Daniel", "Dave", "David", _
                               "Eric", _
                               "Gerry", _
                               "Hank", "Henry", _
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

        Return mFNames(Int(Rnd() * mFNames.Length))
    End Function
    Shared Sub giveRNDMName(ByRef p As Player)
        p.name = rndMName()
    End Sub

    Shared Function rndBimName(ByRef p As Player) As String
        Randomize()
        Dim bimNames As Dictionary(Of Char, String()) = New Dictionary(Of Char, String())
        bimNames.Add("A", {"Alicia", "Ana", "Alexis", "Allie", "Amber", "Ali", "Aurora"})
        bimNames.Add("B", {"Becky", "Becki", "Bambi", "Brandi", "Bunni", "Bianca"})
        bimNames.Add("C", {"Crystal", "Coco", "Cassie", "Cara", "Chloe", "Cindi", "Candi"})
        bimNames.Add("D", {"Daisy", "Dani", "Diamond", "Danni", "Dixi", "Daphne"})
        bimNames.Add("E", {"Erika", "Emmy", "Eliza", "Envi", "Evie", "Emily"})
        bimNames.Add("F", {"Felicity", "Frankie", "Faith", "Foxi", "Fia"})
        bimNames.Add("G", {"Gabi", "Gigi", "Glamour", "Gia", "Gia"})
        bimNames.Add("H", {"Heather", "Hailey", "Honey", "Halli", "Haylee", "Harmoni"})
        bimNames.Add("I", {"Izzy", "Izzi", "Ina", "Ivy"})
        bimNames.Add("J", {"Joni", "Jenna", "Jenni", "Jojo", "Jade"})
        bimNames.Add("K", {"Kelli", "Kelsi", "Krystal", "Kitty", "Kyra"})
        bimNames.Add("L", {"Lana", "Leora", "Lexi", "Lace", "Lacy", "Lia", "Lila", "Lori"})
        bimNames.Add("M", {"Monica", "Mia", "Monique", "Merci", "May", "Misty"})
        bimNames.Add("N", {"Nancy", "Nicki", "Nat", "Nica", "Nina"})
        bimNames.Add("O", {"Opal", "Ophelia", "Olivia"})
        bimNames.Add("P", {"Paris", "Pixi", "Porsche", "Pansi"})
        bimNames.Add("Q", {"Quinn", "Qui"})
        bimNames.Add("R", {"Racheal", "Ruby", "Rita", "Ria", "Rio", "Rosi"})
        bimNames.Add("S", {"Sammi", "Sam", "Salli", "Sara", "Sofi", "Staci", "Sapphire", "Skye"})
        bimNames.Add("T", {"Trisha", "Trixie", "Tiffany", "Thia", "Tara", "Tawni", "Tia", "Tricia", "Tess"})
        bimNames.Add("U", {"Unique"})
        bimNames.Add("V", {"Vivi", "Viola", "Venus", "Vanessa"})
        bimNames.Add("W", {"Wendi", "Willow"})
        bimNames.Add("X", {"Xena", "Xia", "Xiola"})
        bimNames.Add("Y", {"Yvonne", "Yvette"})
        bimNames.Add("Z", {"Zena", "Zoe", "Zozo", "Zi"})

        If bimNames.Keys.Contains(p.name.ToUpper.First) Then
            Dim r = Int(Rnd() * bimNames(p.name.ToUpper.First).Length)
            Return bimNames(p.name.ToUpper.First)(r)
        Else
            Dim r1 = Int(Rnd() * bimNames.Keys.Count)
            Dim r2 = Int(Rnd() * bimNames(bimNames.Keys(r1)).Length)
            Return bimNames(bimNames.Keys(r1))(r2)
        End If
    End Function
    Shared Function bimboizeName(ByVal name As String) As String
        If Settings.active(setting.bimbonames) Then Return rndBimName(Game.player1)

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
        If (name.StartsWith("Ali")) Then Return "Alli"
        If (name.StartsWith("Mel")) Then Return "Mel"
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
                Return name.Substring(0, name.Length) & "na"
            End If
        Else
            Return name
        End If

        Return "Allie"
    End Function

    Private Sub cboxPMorph_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboxPolymorph.SelectedValueChanged
        tfForm = True
    End Sub
End Class