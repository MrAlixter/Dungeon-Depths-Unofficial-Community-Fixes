Public Class Polymorph
    Public Shared porm As Boolean = True
    Public target As NPC
    Public tfForm As Boolean = False

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
                If cboxPMorph.Items.Contains(p.className) Then cboxPMorph.Items.Remove(p.className)
                If cboxPMorph.Items.Contains(p.formName) Then cboxPMorph.Items.Remove(p.formName)
            Case False
                For i = 0 To p.enemPolyForms.Count - 1
                    cboxPMorph.Items.Add(p.enemPolyForms.Item(i))
                Next
        End Select
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '|--Cancel the Polymorph if an Invalid Form Type is Selected--|
        If cboxPMorph.Text = "-- Select --" Or Not tfForm Then
            Me.Close()
            Game.player1.mana += 12
            Exit Sub
        End If

        '|--Route the Polymorph Based on Target Type--|
        Select Case porm
            Case True
                '|-Polymorph a Player-|
                transform(Game.player1, cboxPMorph.Text)
            Case False
                If target.GetType().IsSubclassOf(GetType(ShopNPC)) Then
                    '|-Polymorph a NPC-|
                    transformN(target, cboxPMorph.Text)
                Else
                    '|-Polymorph an Enemy-|
                    transform(target, cboxPMorph.Text)
                End If
        End Select

        '|--Close the Form--|
        Me.Close()
    End Sub

    'player transform methods
    Shared Sub transform(ByRef p As Player, ByVal form As String)
        If form.Equals(p.className) Or form.Equals(p.formName) Or Not p.polymorphs.Keys.Contains(form) Then
            Exit Sub
        End If

        'gets the revert text for whatever is being changed
        Dim revertText = ""
        If Not form.Equals(p.className) Then
            p.pClass.revert()
            revertText = p.pClass.revertPassage & DDUtils.RNRN
        ElseIf Not form.Equals(p.formName) Then
            p.pForm.revert()
            revertText = p.pForm.revertPassage & DDUtils.RNRN
        Else
            MsgBox(form.Equals(p.className) & " | " & form.Equals(p.formName))
        End If

        'polymorph updates
        p.ongoingTFs.resetPolymorphs()

        p.polymorphs(form) = PolymorphTF.newPoly(form)
        p.ongoingTFs.Add(p.polymorphs(form))
        p.perks(perk.polymorphed) = p.polymorphs(form).getturnsTilNextStep

        If form = "MASBimbo" Then form = "Bimbo"
        If p.forms.Keys.Contains(form) Then
            p.changeForm(form)
        ElseIf p.classes.Keys.Contains(form) Then
            p.changeClass(form)
        End If

        'cleanup
        Game.pushLblEvent(revertText & Game.lblEvent.Text.Split(vbCrLf)(0))
        p.ongoingTFs.ping()
        p.specialRoute()
        p.magicRoute()
        p.drawPort()
    End Sub
    'NPC transform method
    Shared Sub transform(ByRef t As NPC, ByVal s As String)
        If s = "Giant Frog" Then                'Even Debuff
            t.maxHealth *= 0.7
            t.attack *= 0.2
            t.defense *= 0.2
            t.speed *= 0.7
            t.will *= 0.2
            t.tfEnd = 5

        ElseIf s = "Sheep" Then                 'Even Debuff
            t.maxHealth *= 0.5
            t.attack *= 0.5
            t.defense *= 0.5
            t.speed *= 0.5
            t.will *= 0.5
            t.tfEnd = 6

        ElseIf s = "Princess" Then              '+WIL Debuff
            t.maxHealth *= 0.33
            t.attack *= 0.33
            t.defense *= 0.33
            t.speed *= 0.33
            t.will *= 1.0
            t.tfEnd = 6

        ElseIf s = "Cat-Girl" Then              '+WIL/SPD Debuff
            t.maxHealth *= 0.33
            t.attack *= 0.33
            t.defense *= 0.33
            t.speed *= 0.33
            t.will *= 1.0
            t.tfEnd = 6

        ElseIf s = "Bunny" Then                 '+SPD Debuff
            t.maxHealth *= 0.33
            t.attack *= 0.33
            t.defense *= 0.33
            t.speed *= 1.0
            t.will *= 0.33
            t.tfEnd = 6

        ElseIf s = "Cow" Then                   '+HP Debuff
            t.maxHealth *= 1.0
            t.attack *= 0.33
            t.defense *= 0.33
            t.speed *= 0.33
            t.will *= 0.33
            t.tfEnd = 6

        ElseIf s = "Trilobite" Then             '+DEF Debuff
            t.maxHealth *= 0.33
            t.attack *= 0.33
            t.defense *= 1.0
            t.speed *= 0.33
            t.will *= 0.33
            t.tfEnd = 6

        ElseIf s = "Amnesiac" Then              'Even Debuff
            t.maxHealth *= 0.33
            t.attack *= 0.33
            t.defense *= 0.33
            t.speed *= 0.33
            t.will *= 0.33
            t.stunct = 1
            t.tfEnd = 3

        ElseIf s = "Slime​" Then                 '+DEF Buff
            t.maxHealth *= 0.5
            t.attack *= 1.2
            t.defense *= 2.5
            t.speed *= 0.9
            t.will *= 1.0
            t.tfEnd = 2

        ElseIf s = "Succubus​" Then              '+ATK/WIL Buff
            t.maxHealth *= 2.0
            t.attack *= 1.5
            t.defense *= 0.75
            t.speed *= 1.5
            t.will *= 1.25
            t.tfEnd = 2

        ElseIf s = "Dragon​" Then                '+HP/ATK/DEF Buff
            t.maxHealth *= 1.5
            t.attack *= 1.5
            t.defense *= 2.0
            t.speed *= 0.5
            t.will *= 1.25
            t.tfEnd = 2

        Else
            Exit Sub

        End If

        t.tfCt = 1
        t.form = s
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
        End If
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