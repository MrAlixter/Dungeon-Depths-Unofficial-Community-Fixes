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

        Dim p = Game.player
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
            Game.player.mana += 5
            Exit Sub
        End If
        Select Case porm
            Case True
                transform(Game.player, cboxPMorph.Text)
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
            revertText = p.pClass.revertPassage & vbCrLf & vbCrLf
        ElseIf Not form.Equals(p.pForm.name) Then
            p.pForm.revert()
            revertText = p.pForm.revertPassage & vbCrLf & vbCrLf
        Else
            MsgBox(form.Equals(p.pClass.name) & " | " & form.Equals(p.pForm.name))
        End If

        'performs the neccisary polymorph
        Dim removeind = New List(Of Integer)
        For i = 0 To p.ongoingTFs.Count - 1
            If p.ongoingTFs(i).GetType().IsSubclassOf(GetType(PolymorphTF)) Then removeind.Add(i)
        Next
        For i = 0 To removeind.Count - 1
            p.ongoingTFs.RemoveAt(removeind(i))
        Next

        p.polymorphs(form) = PolymorphTF.newPoly(form)
        p.ongoingTFs.Add(p.polymorphs(form))

        If p.forms.Keys.Contains(form) Then
            p.pForm = p.forms(form)
        ElseIf p.classes.Keys.Contains(form) Then
            p.pClass = p.classes(form)
        End If

        'cleanup
        p.perks("polymorphed") = p.polymorphs(form).getturnsTilNextStep

        Game.pushLblEvent(revertText & Game.lblEvent.Text.Split(vbCrLf)(0))
        p.specialRoute()
        p.magicRoute()
        p.createP()
    End Sub
    'NPC transform method
    Sub transform(ByRef t As NPC, ByVal s As String)
        Dim title As String = s
        If title = "Sheep" Then
            t.health = 1
            t.maxHealth = 50
            t.attack = 1
            t.defence = 1
            t.tfCt = 1
            t.tfEnd = 6
            t.form = "Sheep"
        ElseIf title = "Princess" Then
            t.health = 1
            t.maxHealth = 60
            t.attack = 5
            t.defence = 1
            t.tfCt = 1
            t.tfEnd = 6
            t.form = "Princess"
        ElseIf title = "Bunny" Then
            t.health = 1
            t.maxHealth = 25
            t.attack = 1
            t.defence = 1
            t.tfCt = 1
            t.tfEnd = 6
            t.form = "Bunny"
        ElseIf title = "Chicken" Then
            t.health = 1
            t.maxHealth = 45
            t.attack = 5
            t.defence = 5
            t.tfCt = 1
            t.tfEnd = 6
            t.form = "Chicken"
        ElseIf title = "Cow" Then
            t.health = 1
            t.maxHealth = 75
            t.attack = 0
            t.defence = 0
            t.tfCt = 1
            t.tfEnd = 6
            t.form = "Cow"
        ElseIf title = "Amnesiac" Then
            t.health = 1
            t.attack = 0
            t.defence = 0
            t.speed = 1
            t.stunct = 1
            t.tfCt = 1
            t.tfEnd = 6
            t.form = "Amnesiac"
        ElseIf title = "Slime​" Then
            t.health = 1
            t.maxHealth = 150
            t.attack = 10
            t.defence = 15
            t.tfCt = 1
            t.tfEnd = 2
            t.form = "Slime"
        ElseIf title = "Succubus​" Then
            t.health = 1
            t.maxHealth = 125
            t.attack = 20
            t.defence = 5
            t.tfCt = 1
            t.tfEnd = 2
            t.form = "Succubus"
        ElseIf title = "Dragon​" Then
            t.health = 1
            t.maxHealth = 200
            t.attack = 15
            t.defence = 30
            t.tfCt = 1
            t.tfEnd = 2
            t.form = "Dragon"
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
        Dim fFNames() As String = {"Anna", "Ann", "Ana", "Alexis", "Allie", "Amber", "Ali", _
                               "Becky", _
                               "Christine", "Casandra", "Cassie", "Cara", "Chloe", _
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
        p.name = fFNames(Int(Rnd() * fFNames.Length))
    End Sub

    Private Sub cboxPMorph_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboxPMorph.SelectedValueChanged
        tfForm = True
    End Sub
End Class