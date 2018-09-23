Public Class Polymorph
    Public Shared porm As Boolean = True
    Public target As Monster
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
        Select Case porm
            Case True
                For i = 0 To Game.formList.Count - 1
                    cboxPMorph.Items.Add(Game.formList.Item(i))
                Next
                If cboxPMorph.Items.Contains(Game.player.pClass.name) Then cboxPMorph.Items.Remove(Game.player.pClass.name)
                If cboxPMorph.Items.Contains(Game.player.pForm.name) Then cboxPMorph.Items.Remove(Game.player.pForm.name)
            Case False
                For i = 0 To Game.tFormList.Count - 1
                    cboxPMorph.Items.Add(Game.tFormList.Item(i))
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
                If target.GetType() Is GetType(NPC) Then transformN(target) Else transform(target, cboxPMorph.Text)
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
        Else
            p.pClass = p.classes(form)
        End If

        'cleanup
        p.perks("polymorphed") = 1

        Game.lblEvent.Text = revertText & Game.lblEvent.Text
        Game.cmboxSpec.Items.Clear()
        Game.specialRoute()
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    'monster transform method
    Sub transform(ByRef t As Monster, ByVal s As String)
        Dim title As String = s
        If title = "Sheep" Then
            t.health = 50
            t.maxHealth = 50
            t.attack = 1
            t.defence = 1
            t.tfCt = 1
            t.tfEnd = 6
            t.form = "Sheep"
        ElseIf title = "Princess" Then
            t.health = 60
            t.maxHealth = 60
            t.attack = 5
            t.defence = 1
            t.tfCt = 1
            t.tfEnd = 6
            t.form = "Princess"
        ElseIf title = "Bunny" Then
            t.health = 25
            t.maxHealth = 25
            t.attack = 1
            t.defence = 1
            t.tfCt = 1
            t.tfEnd = 6
            t.form = "Bunny"
        ElseIf title = "Chicken" Then
            t.health = 45
            t.maxHealth = 45
            t.attack = 5
            t.defence = 5
            t.tfCt = 1
            t.tfEnd = 6
            t.form = "Chicken"
        ElseIf title = "Cow" Then
            t.health = 75
            t.maxHealth = 75
            t.attack = 0
            t.defence = 0
            t.tfCt = 1
            t.tfEnd = 6
            t.form = "Cow"
        ElseIf title = "Slime​" Then
            t.health = 150
            t.maxHealth = 150
            t.attack = 10
            t.defence = 15
            t.tfCt = 1
            t.tfEnd = 2
            t.form = "Slime"
        ElseIf title = "Succubus​" Then
            t.health = 125
            t.maxHealth = 125
            t.attack = 20
            t.defence = 5
            t.tfCt = 1
            t.tfEnd = 2
            t.form = "Succubus"
        ElseIf title = "Dragon​" Then
            t.health = 200
            t.maxHealth = 200
            t.attack = 15
            t.defence = 30
            t.tfCt = 1
            t.tfEnd = 2
            t.form = "Dragon"
        End If
    End Sub
    'npc transform methodF:\dungeon_depths\The Dungeon\img\
    Sub transformN(ByRef t As NPC)
        Dim title As String = cboxPMorph.Text
        If title = "Sheep" Then
            t.health = 50
            t.maxHealth = 50
            t.attack = 1
            t.defence = 1
            t.tfCt = 1
            t.tfEnd = 6
            t.npcIndex = 2
            t.form = "Sheep"
        ElseIf title = "Princess" Then
            t.health = 999
            t.maxHealth = 999
            t.attack = 50
            t.defence = 1
            t.tfCt = 1
            t.tfEnd = 15
            t.npcIndex = 3
            t.toFemale("prin")
            t.form = "Princess"
        ElseIf title = "Bunny" Then
            t.health = 500
            t.maxHealth = 500
            t.attack = 1
            t.defence = 1
            t.tfCt = 1
            t.tfEnd = 15
            t.npcIndex = 4
            t.toFemale("bunny")
            t.form = "Bunny Girl"
            Game.NPCfromCombat(t)
        ElseIf title = "Chicken" Then
            t.health = 45
            t.maxHealth = 45
            t.attack = 5
            t.defence = 5
            t.tfCt = 1
            t.tfEnd = 6
            t.npcIndex = 6
            t.form = "Chicken"
        ElseIf title = "Cow" Then
            t.health = 75
            t.maxHealth = 75
            t.attack = 0
            t.defence = 0
            t.tfCt = 1
            t.tfEnd = 6
            t.npcIndex = 7
            t.form = "Cow"
        End If
        Game.npcIndex = t.npcIndex
    End Sub

    Shared Sub giveRNDFFName(ByRef p As Player)
        If Game.floor < 5 Then Randomize(Game.floorLayouts(Game.floor).GetHashCode) Else Randomize()
        Dim fFNames() As String = {"Abigail", "Abby", "Anna", "Ann", "Ana", "Alexis", _
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
                               "Samantha", "Sarah", "Sally", _
                               "Tanja", "Trisha", _
                               "Vanessa"}
        p.name = fFNames(Int(Rnd() * fFNames.Length))
    End Sub

    Private Sub cboxPMorph_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboxPMorph.SelectedValueChanged
        tfForm = True
    End Sub
End Class